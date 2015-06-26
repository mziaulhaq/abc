using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceDAL;
using EcommerceUtilities;

namespace Ecommerce
{
    public partial class SignIn : FrontBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (LoggedCustomer.IsUserLogged())
                Response.Redirect("Index");
            if (!IsPostBack)
            {
                PopulateCountries();
            }
        }

        private void PopulateCountries()
        {
            using (var clothEntities = new ClothEntities())
            {
                ddlCountry.DataSource = clothEntities.tbl_Country.ToList();
                ddlCountry.DataBind();
                ddlCountry.SelectedIndex = ddlCountry.Items.IndexOf(ddlCountry.Items.FindByText("Pakistan"));

            }
        }
        private void ClearAllFields()
        {
            ViewState.Clear();
            txtCompleteAddress.Text = string.Empty;
            txtConfirmPwd.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            rblGender.ClearSelection();
            txtLastName.Text = string.Empty;
            txtMobileNumber.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtProvinceState.Text = string.Empty;
            ddlCountry.SelectedIndex = 0;
        }
        protected void BtnSignUpClicked(object sender, EventArgs e)
        {
            Page.Validate("Signup");
            if (Page.IsValid)
            {
                using (var clothEntities = new ClothEntities())
                {
                    var existEmail = clothEntities.tbl_Customers.FirstOrDefault(cust => cust.Email == txtEmail.Text);
                    if (existEmail == null)
                    {
                        var customer = new tbl_Customers
                        {
                            FirstName = txtFirstName.Text,
                            LastName = txtLastName.Text,
                            Email = txtEmail.Text,
                            TelephoneNumber = txtPhoneNumber.Text,
                            MobileNumber = txtMobileNumber.Text,
                            Gender = rblGender.SelectedValue,
                            ProvinceOrState = txtProvinceState.Text,
                            StoreId = StoreId,
                            CountryId = int.Parse(ddlCountry.SelectedValue),
                            Status = 1,
                            Address = txtCompleteAddress.Text,
                            Pwd = PasswordManager.Encrypt(txtPwd.Text)
                        };
                        clothEntities.tbl_Customers.Add(customer);
                        if (clothEntities.SaveChanges() > 0)
                        {
                            ClearAllFields();
                            string s = "alert('You have been registered successfully.');";
                            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);

                            MainDiv.InnerHtml = "";
                            MainDiv.InnerHtml = "<h1>You have been registered successfully.</h1>";
                            Response.Redirect("Login.aspx");
                        }
                        else
                        {
                            string s = "alert('Error Occured While Saving User Info');";
                            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
                        }
                    }
                    else
                    {
                        string s = "alert('This Email Address is already registered with Us.');";

                        ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);


                        MainDiv.InnerHtml = "";
                        MainDiv.InnerHtml = "<br><h2>This Email Address is already registered with Us. Please Click here to resete your password <a href=\"ForgotPassword.aspx\">Click Here</a></h2><br><br><br><br>";
                    }

                }
            }
        }
    }
}