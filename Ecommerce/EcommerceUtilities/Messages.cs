using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace EcommerceUtilities
{
    public class Messages
    {
        
        private const string SessionString = "";
        public string Title { get; set; }
        public List<string> MessageLists { get; set; }
        public string SubTitle { get; set; }
        /// <summary>
        /// Checks if a message is in the session or not
        /// </summary>
        /// <param name="message">Message Object to return if there is a Message object in the session </param>
        /// <returns></returns>
        public static bool CheckMessageSession(out Messages message)
        {
            try
            {
                if (HttpContext.Current.Session[SessionString] != null)
                {
                    message = HttpContext.Current.Session[SessionString] as Messages;
                    return true;
                }
                else
                {
                    message = null;
                    return false;
                }
            }
            catch (Exception)
            {
                message = null;
                return false;
            }
          
           
        }
        /// <summary>
        /// Saves a Message Object in the Session for Next Page Use
        /// </summary>
        /// <param name="msg"></param>
        public static void SaveMessage(Messages msg)
        {
            HttpContext.Current.Session[SessionString] = msg;
        }
        /// <summary>
        /// It Shows Popup Message, it compiles the message object passed to it to Proper Client Message
        /// </summary>
        /// <param name="msg">Instance of Messages </param>
        /// <param name="page"> Instance of the Current Web.Ui.Page</param>
        private static void ShowPopUpMessage(Messages msg, Page page)
        {
            ReleaseSession();
            if(msg!=null)
            {
                if(msg.MessageLists!=null && msg.Title!=null)
                {
                    Utility.ShowPopUpMessage(msg.Title,msg.MessageLists,page,false,msg.SubTitle);
                }
            }
        }
        /// <summary>
        /// This will Create Popup Message of the Message Instance present in Session Message
        /// </summary>
        /// <param name="page"></param>
        public static void ShowPopUpMessage(Page page)
        {
            Messages msg;
            if(CheckMessageSession(out msg))
            {
               ShowPopUpMessage(msg,page);
            }
        }
        private static void ReleaseSession()
        {
            HttpContext.Current.Session[SessionString] = null;
        }
    }
}
