using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace EcommerceUtilities
{
    public  class LoggedUser : IReadOnlySessionState
    {
        public int UserId { get; set; }
        public string UserLoginId { get; set; }
        public int StoreId { get; set; }
        public bool IsActive { get; set; }
        public string UserFullName { get; set; }
        public int UserGroupId { get; set; }
        public string UserEmail { get; set; }
        public List<string> AccessibleScreens { get; set; }
        public LoggedUser()
        {
            AccessibleScreens = new List<string>();
        }
        public static bool UserLoggedIn()
        {
            return HttpContext.Current.Session["LoggedUser"] != null;
        }
        public void CreateUserSessions()
        {
            if(this.UserId!=0 && this.StoreId!=0)
            HttpContext.Current.Session["LoggedUser"] = this;
        }
        public static void ReleaseUserSession()
        {
            HttpContext.Current.Session.Remove("LoggedUser");
            HttpContext.Current.Session.RemoveAll();
            HttpContext.Current.Session.Clear();
        }
        public static int GetUserId()
        {
            if(HttpContext.Current.Session["LoggedUser"] !=null)
            {
                var loggedUser = HttpContext.Current.Session["LoggedUser"] as LoggedUser;
                if (loggedUser != null) return loggedUser.UserId;
            }
            return 0;
        }
        public List<string> GetAccessibleScreens()
        {
            return AccessibleScreens;
        }
        public static int GetStoreId()
        {
            if (HttpContext.Current.Session["LoggedUser"] != null)
            {
                var loggedUser = HttpContext.Current.Session["LoggedUser"] as LoggedUser;
                if (loggedUser != null) return loggedUser.StoreId;
            }
            return 0;
        }
        public static LoggedUser GetLoggedUser()
        {
            try
            {
                if(HttpContext.Current.Session["LoggedUser"] != null)
                {
                    return HttpContext.Current.Session["LoggedUser"] as LoggedUser;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
            
        }
        
        
    }
}
