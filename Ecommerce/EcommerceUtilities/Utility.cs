using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceUtilities
{

    public static class Utility
    {
        public static void ShowMessage(ref Label lblMessage, bool successStatus, string message)
        {
            lblMessage.CssClass = successStatus ? "Success" : "Failure";
            lblMessage.Visible = true;
            lblMessage.Text = message;
        }
        public static void MakeLabelInvisible(ref Label lblMessage)
        {
            lblMessage.CssClass = "";
            lblMessage.Text = "";
        }
        private static void ShowPopUpMessage(string title,string message,Page page)
        {
            var rd = DateUtility.UniqueStringFromDate();
            string script = string.Format(@"ShowPopup('{0}','{1}')",title,message);
            page.ClientScript.RegisterStartupScript(page.GetType(),rd,script,true);
        }
        public static void ShowPopUpMessage(string title, List<string> messages, Page page,bool ajax, string subTitle = null)
        {
            var rd = new Random(DateTime.Now.Millisecond);
            if(messages.Count==0)
                ShowPopUpMessage(title,"No Message",page);
            else
            {
                var compiledMessage = new StringBuilder();
                compiledMessage.AppendFormat("<ul>");
                if(subTitle!=null)
                {
                    compiledMessage.AppendFormat("<li>{0}<ul>",subTitle);
                }
                foreach (string message in messages)
                {
                    compiledMessage.AppendFormat("<li>{0}</li>", message);
                }
                if(subTitle!=null)
                {
                    compiledMessage.AppendFormat("</ul></li>");
                }
                compiledMessage.Append("</ul>");

                if(ajax)
                    ShowPopUpAjaxMessage(title, compiledMessage.ToString(), page);
                else
                    ShowPopUpMessage(title, compiledMessage.ToString(), page);
                
            }
        }
        private static void ShowPopUpAjaxMessage(string title, string message, Page page)
        {
            var rd = DateUtility.UniqueStringFromDate();
            string script = string.Format(@"ShowPopup('{0}','{1}')", title, message);
            ScriptManager.RegisterStartupScript(page, page.GetType(), rd, script, true);
        }

        public static void ShowBootStrapPopUp(string divId, Page pg, bool ajax)
        {
            var sb = new System.Text.StringBuilder();
            var rd = DateUtility.UniqueStringFromDate();
            sb.Append(string.Format("$('#{0}').modal('show')", divId));

            if (ajax)
            {
                ScriptManager.RegisterStartupScript(pg, pg.GetType(), rd, sb.ToString(), true);
            }
            else
            {
                pg.ClientScript.RegisterStartupScript(pg.GetType(), rd, sb.ToString(), true);
            }

        }
        public static void ShowMessageAndHidePopup(string title, List<string> messages, Page page, bool ajax, string subTitle = null)
        {
            var rd = DateUtility.UniqueStringFromDate();
            if (messages.Count == 0)
                ShowPopUpMessage(title, "No Message", page);
            else
            {
                var compiledMessage = new StringBuilder();
                compiledMessage.AppendFormat("<ul>");
                if (subTitle != null)
                {
                    compiledMessage.AppendFormat("<li>{0}<ul>", subTitle);
                }
                foreach (string message in messages)
                {
                    compiledMessage.AppendFormat("<li>{0}</li>", message);
                }
                if (subTitle != null)
                {
                    compiledMessage.AppendFormat("</ul></li>");
                }
                compiledMessage.Append("</ul>");
                if (ajax)
                {
                    string script = string.Format(@"ShowPopup('{0}','{1}');$('.modal-backdrop').remove();", title, compiledMessage.ToString());
                    //string script = string.Format(@"alert('{0}');", "Hello");
                    ScriptManager.RegisterStartupScript(page, page.GetType(), rd, script, true);
                }

                else
                {

                    string script = string.Format(@"ShowPopup('{0}','{1}');$('.modal-backdrop').remove();", title, compiledMessage.ToString());
                    page.ClientScript.RegisterStartupScript(page.GetType(), rd, script, true);
                }
            }
        }




        public static string ReturnStatusEnabledOrDisabled(int status)
        {
            switch (status)
            {
                case 0:
                    return "Disabled";
                case 1:
                    return "Enabled";
                default:
                    return "";
            }
        }
    }
}
