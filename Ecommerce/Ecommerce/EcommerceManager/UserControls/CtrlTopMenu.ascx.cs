using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EcommerceUtilities;

namespace Ecommerce.EcommerceManager.UserControls
{
    public partial class CtrlTopMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EnableDisableMenuItems();
            }
        }

        private void EnableDisableMenuItems()
        {

            try
            {
                LoggedUser loggedUser = LoggedUser.GetLoggedUser();
                List<string> allScreens = loggedUser.GetAccessibleScreens();
                var allMenuItems = TopMyMenuControl.Items.GetEnumerator();// as IEnumerator<MenuItem>;
                foreach (MenuItem menuItem in TopMyMenuControl.Items)
                {
                    
                   if(menuItem.ChildItems.Count!=0)
                   {
                       if (menuItem.NavigateUrl == "")
                       {
                           ChildMenus(menuItem);
                       }
                       if(menuItem.NavigateUrl!=string.Empty)
                       {
                           if (!allScreens.Contains(menuItem.Value))
                               menuItem.NavigateUrl = "";

                       }

                   }       
                   else if(menuItem.ChildItems.Count == 0 && menuItem.NavigateUrl != string.Empty)
                   {
                       if (!allScreens.Contains(menuItem.Value))
                           menuItem.NavigateUrl = "";
                   }
                   else
                   {
                       menuItem.NavigateUrl = "";
                   }
                }
            }
            catch (Exception)
            {
                TopMyMenuControl.Enabled = false;
                return;
            }

        }
        private void ChildMenus(MenuItem pmenuItem)
        {

        }

    }

}