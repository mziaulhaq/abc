using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EcommerceDAL;
using EcommerceUtilities;

namespace Ecommerce
{
    public partial class Login : System.Web.UI.Page
    {
        private readonly string _emailTemp = ConfigurationManager.AppSettings["EmailTemplates"] + "PasswordReset.html";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// show forgot password popup and send an email to the user
        /// </summary>
        /// <param name="sender">Link button clicked on Login page</param>
        /// <param name="e"></param>
        protected void lnk_Click(object sender, EventArgs e)
        {
            Utility.ShowBootStrapPopUp("forgotPasswordForm", this.Page, true);
        }

        /// <summary>
        /// Login button click event on Login.aspx page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (var clothEntities = new ClothEntities())
            {
                string pwd = PasswordManager.Encrypt(txtPwd.Text);
                var frontloggedUser = clothEntities.tbl_Customers.FirstOrDefault(cust => cust.Email == txtEmail.Text && cust.Pwd == pwd);
                if (frontloggedUser == null)
                {
                    const string s = "ShowPopup('Credential Verification','Provided Email Or Password is InCorrect');";
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
                    return;
                }
                var loggedCustomer = new LoggedCustomer()
                {
                    Email = frontloggedUser.Email,
                    Name = frontloggedUser.FirstName + frontloggedUser.LastName,
                    Id = frontloggedUser.CustomerID,
                    //StoreId = StoreId
                };
                LoggedCustomer.CreateCustomerSession(loggedCustomer);
                Response.Redirect("~/Index.aspx", true);
            }
        }

        /// <summary>
        /// Send button on popu click event to send password on email
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSendClicked_Click(object sender, EventArgs e)
        {
            using (var db = new ClothEntities())
            {
                var email = txtEmail.Text;
                var usr = db.tbl_Customers.SingleOrDefault(x => x.Email == email);
                if (usr != null)
                {
                    var pwd = PasswordManager.Decrypt(usr.Pwd).ToString();
                    string body = EmailManager.PopulateBody(usr.FirstName, "www.lahorecloth.com", " Your password for Lahore cloth Login is <strong> " + pwd + "</strong>", _emailTemp);
                    EmailManager.SendHtmlFormattedEmail(email, "Password Reset ", body);
                    Utility.ShowPopUpMessage("Success", new List<string>() { "An email has been sent to you..." }, this.Page, true);
                    btnSendClicked.Enabled = false;
                }
                else
                {
                    Utility.ShowPopUpMessage("Incorrect Email", new List<string>() { "User with the given email does not exist in our database" }, this.Page, true);
                }
            }
        }
    }
}