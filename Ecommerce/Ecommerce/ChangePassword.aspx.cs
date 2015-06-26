using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceUtilities;
using EcommerceDAL;
namespace Ecommerce
{
    public partial class ChangePassword : FrontLoggedCustomer
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!LoggedCustomer.IsUserLogged())
                Response.Redirect("Index",true);
        }

        protected void ChangePasswordClicked(object sender, EventArgs e)
        {
            Validate("ChangePassword");
            if(Page.IsValid && LoggedCustomer.IsUserLogged())
            {
                string oldPassword = PasswordManager.Encrypt(txtOldPassword.Text);
                string newPassword = PasswordManager.Encrypt(txtNewPassword.Text);
                var uid = LoggedCustomer.GetLoggedCustomer().Id; 
                using (var clothEntities = new ClothEntities())
                {
                    var loggedCustomer = clothEntities.tbl_Customers.FirstOrDefault(lc => lc.Pwd == oldPassword && lc.CustomerID==uid);
                    if(loggedCustomer!=null)
                    {
                        loggedCustomer.Pwd = newPassword;
                        if(clothEntities.SaveChanges()==1)
                        {
                            Utility.ShowPopUpMessage("Success Message", new List<string>() { "Password Changed Successfully" }, this.Page, true);
                            txtConfirmPassword.Text = "";
                            txtNewPassword.Text = "";
                            txtOldPassword.Text = "";
                        }
                        else
                        {
                           Utility.ShowPopUpMessage("Error Message", new List<string>() { "Password Could not be change successfully" }, this.Page, true);
                        }
                    }
                    else
                    {
                        Utility.ShowPopUpMessage("Invalid Password", new List<string>() { "Old Password Provided is incorrect" }, this.Page, true);
                    }
                }
            }
            else
            {
                Utility.ShowPopUpMessage("Invalid Request",new List<string>(){"Page Request is Invalid"},this.Page,true);
            }
        }
    }
}