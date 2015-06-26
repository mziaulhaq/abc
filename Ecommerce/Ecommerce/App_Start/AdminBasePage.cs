using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using EcommerceUtilities;

namespace Ecommerce.App_Start
{
    public class AdminBasePage : Page
    {
        public string UserSession = "LoggedUser";
        public int LoggedStoreId;
        protected override void OnPreLoad(EventArgs e)
        {
            string requestedScreen = Request.RawUrl;
            if (requestedScreen.Length > requestedScreen.LastIndexOf("/", System.StringComparison.Ordinal))
            {
                requestedScreen = requestedScreen.Substring(Request.RawUrl.LastIndexOf("/", System.StringComparison.Ordinal)+1).ToLower();
                if (requestedScreen.IndexOf(".aspx", System.StringComparison.Ordinal) != -1)
                    requestedScreen = requestedScreen.Substring(0,requestedScreen.IndexOf(".aspx",System.StringComparison.Ordinal));
                if(requestedScreen.IndexOf("?", System.StringComparison.Ordinal)!= -1)
                   requestedScreen = requestedScreen.Substring(0, requestedScreen.IndexOf("?",
                                                                System.StringComparison.Ordinal));

                
            }
            if(LoggedUser.UserLoggedIn())
            {
                
                LoggedUser loggedUser = LoggedUser.GetLoggedUser();
                
                if(loggedUser!=null)
                {
                    LoggedStoreId = loggedUser.StoreId;
                    List<string> authorizedScreens = loggedUser.AccessibleScreens;
                    if (!authorizedScreens.Contains(requestedScreen) && (requestedScreen != "ecomercehome"))
                    {
                      Response.Redirect("~/EcommerceManager/EcomerceHome.aspx");
                    }
                    
                }
                else
               {
                   Response.Redirect("~/EcommerceManager/Login.aspx");
               }
            }
            else
            {
                if(requestedScreen!="login.aspx" && requestedScreen!="login")
                    Response.Redirect("~/EcommerceManager/login.aspx");
               
            }
        }
    }
}