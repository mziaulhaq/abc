using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceDAL;
using EcommerceUtilities;

namespace Ecommerce.UserControls
{
    public partial class HeaderMenu : UserControlFront
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                PopulateGenders();
            }
            if (LoggedCustomer.IsUserLogged())
            {
                var loggedUser = LoggedCustomer.GetLoggedCustomer();
                litLoggedUser.Text = "Welcome " + loggedUser.Name ?? string.Empty;
                liLoggedUser.Visible = true;
                liRegister.Visible = false;
                liRegisterSeperator.Visible = false;
                liSignIn.Visible = false;
                btnSignIn.Text = "Log Out";
                btnSignIn.NavigateUrl = "~/Index.aspx?Logout=true";
            }
            else
            {
                liLoggedUser.Visible = false;
                liRegister.Visible = true;
                liRegisterSeperator.Visible = true;
                liSignIn.Visible = true;
                btnSignIn.Text = "Log In";
                btnSignIn.NavigateUrl = "~/Login.aspx";
            }

        }

        private void PopulateGenders()
        {
            using (var clothEntities = new ClothEntities())
            {
                var allGenders = (from gen in clothEntities.tbl_GenderCategories
                                  where gen.StoreId == StoreId
                                  select new
                                             {
                                                 gen.GenderCatName,
                                                 gen.GenderCatId
                                             }).ToList();

                lstGender.DataSource = allGenders;
                lstGender.DataBind();
            }
        }

        protected void LoginClicked(object sender, EventArgs e)
        {
            using (var clothEntities = new ClothEntities())
            {
                string pwd = PasswordManager.Encrypt(txtPwd.Text);
                var frontloggedUser =
                    clothEntities.tbl_Customers.FirstOrDefault(
                        cust => cust.Email == txtEmail.Text && cust.Pwd == pwd && cust.StoreId == StoreId);
                if (frontloggedUser == null)
                {
                    string s = "ShowPopup('Credential Verification','Provided Email Or Password is InCorrect');";
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
                    return;
                }
                var loggedCustomer = new LoggedCustomer()
                {
                    Email = frontloggedUser.Email,
                    Name = frontloggedUser.FirstName + frontloggedUser.LastName,
                    Id = frontloggedUser.CustomerID,
                    StoreId = StoreId
                };
                LoggedCustomer.CreateCustomerSession(loggedCustomer);
                Response.Redirect(HttpContext.Current.Request.RawUrl, true);
            }
        }

        protected void SearchClicked_Click(object sender, EventArgs e)
        {
            if (txtSearchValue.Text != string.Empty)
            {
                Response.Redirect("~/Search.aspx?Query=" + txtSearchValue.Text, true);
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            txtEmail.Attributes.Add("PlaceHolder", "Email");
            txtPwd.Attributes.Add("PlaceHolder", "Password");
            txtSearchValue.Attributes.Add("PlaceHolder", "Search");

            base.OnPreRender(e);
        }

        protected void btnForgotPwd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ForgotPassword.aspx");
        }

    }
}