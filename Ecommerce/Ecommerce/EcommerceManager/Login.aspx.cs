using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceDAL;
using EcommerceUtilities;

namespace Ecommerce.EcommerceManager
{
    public partial class Login : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.CtrlTopMenu2.Visible = false;
        }

        protected void BtnLoginClicked(object sender, EventArgs e)
        {
            Validate();
            if(!Page.IsValid)
                return;
            if (!string.IsNullOrWhiteSpace(txtLoginId.Text) && !string.IsNullOrWhiteSpace(txtPwd.Text))
            {
                using (var clothEntities = new ClothEntities())
                {
                    var user = clothEntities.AuthenticateUser(txtLoginId.Text, txtPwd.Text).ToList();
                    if(user.Count==1)
                    {
                        var users = user[0];
                        var lgdUser = new LoggedUser()
                                          {
                                              UserId = users.UserId,
                                              StoreId = users.StoreId,
                                              IsActive = users.IsActive,
                                              UserEmail = users.UserEmail,
                                              UserFullName = users.UserFullName,
                                              UserGroupId = users.UserGroupId,
                                              UserLoginId = users.UserLoginId
                                          };
                        var accessibleScreens = clothEntities.GetGroupAuthorizedScreens(lgdUser.UserGroupId,
                                                                                   lgdUser.StoreId).ToList();
                        var sList = new List<string>();
                        if(accessibleScreens.Count > 0)
                        {
                            sList.AddRange(from accessibleScreen in accessibleScreens
                                           where accessibleScreen.screenName.IndexOf(".aspx", System.StringComparison.Ordinal) != -1
                                           select accessibleScreen.screenName
                                           into screenName select screenName.Substring(0, screenName.IndexOf(".aspx", System.StringComparison.Ordinal)));
                        }
                        lgdUser.AccessibleScreens = sList;
                        lgdUser.CreateUserSessions();
                        Response.Redirect("~/EcommerceManager/EcomerceHome.aspx");
                    }

                }
            }
        }
    }
}