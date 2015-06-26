using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceDAL;
using EcommerceUtilities;
using Org.BouncyCastle.Crypto.Tls;

namespace Ecommerce
{
    public partial class UpdateProfile : FrontBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!LoggedCustomer.IsUserLogged())
                Response.Redirect("Index");
            if (!IsPostBack)
            {
                PopulateCountries();
                PopulateUserInfo();
            }
        }


        public void PopulateUserInfo()
        {
            using (var clothEntities = new ClothEntities())
            {
                var customerId = LoggedCustomer.GetLoggedCustomer().Id;
                var Customer = clothEntities.tbl_Customers.FirstOrDefault(cust => cust.CustomerID == customerId);
                if (Customer != null)
                {
                    DateTime? dateOfBith;
                    if (!(string.IsNullOrEmpty(txtDOB.Text.Trim())))
                    {
                        dateOfBith = Convert.ToDateTime(txtDOB.Text);
                    }
                    else
                    {

                        dateOfBith = null;
                    }

                    txtFirstName.Text = Customer.FirstName;
                    txtLastName.Text = Customer.LastName;
                    if (Customer.DOB != null)
                    {
                        txtDOB.Text =Convert.ToDateTime(Customer.DOB.ToString()).ToShortDateString();
                    }
                    txtMobileNumber.Text = Customer.MobileNumber;
                    txtPhoneNumber.Text = Customer.TelephoneNumber;
                    rblGender.SelectedIndex = rblGender.Items.IndexOf(rblGender.Items.FindByValue(Customer.Gender));
                    txtCompleteAddress.Text = Customer.Address;
                    txtProvinceState.Text = Customer.ProvinceOrState;
                    ddlCountry.SelectedIndex =
                    ddlCountry.Items.IndexOf(ddlCountry.Items.FindByValue(Customer.CountryId.ToString()));
                   txtEmail.Text = Customer.Email;


                }
            }
        }

        private void PopulateCountries()
        {
            using (var clothEntities = new ClothEntities())
            {
                ddlCountry.DataSource = clothEntities.tbl_Country.ToList();
                ddlCountry.DataBind();


            }
        }

        private void ClearAllFields()
        {
            ViewState.Clear();
            txtCompleteAddress.Text = string.Empty;

            txtDOB.Text = string.Empty;

            txtFirstName.Text = string.Empty;
            rblGender.ClearSelection();
            txtLastName.Text = string.Empty;
            txtMobileNumber.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtProvinceState.Text = string.Empty;
            ddlCountry.SelectedIndex = 0;
        }

        protected bool checkEmailAddress()
        {

            bool emailExist = false;
            string emailAddress;
            if (txtEmail.Text != "")
            {
                //extract the email address from db to check:

                using (var clothEntities = new ClothEntities())
                {
                    long cutomerID = LoggedCustomer.GetLoggedCustomer().Id;
                    var customer =clothEntities.tbl_Customers.FirstOrDefault(
                            cust => cust.CustomerID == cutomerID);

                    emailAddress = customer.Email;
                }

                if (txtEmail.Text.Trim() != emailAddress)
                {
                    using (var clothEntities = new ClothEntities())
                    {
                        var existEmail =
                            clothEntities.tbl_Customers.FirstOrDefault(cust => cust.Email == txtEmail.Text.Trim());

                        if (existEmail == null)
                        {
                            emailExist = false;
                        }
                        else
                        {
                            emailExist = true;
                        }
                    }
                }
            }
            return emailExist;

        }

        protected void BtnSignUpClicked(object sender, EventArgs e)
        {
            Page.Validate("UpdateProfile");
            if (!Page.IsValid) return;

            bool emailExist = checkEmailAddress();

            if (emailExist==false)
            {
                using (var clothEntities = new ClothEntities())
                {

                    long cutomerID = LoggedCustomer.GetLoggedCustomer().Id;
                    var customer =
                        clothEntities.tbl_Customers.FirstOrDefault(
                            cust => cust.CustomerID ==cutomerID );

                    if (customer==null) return;


                    DateTime? dateOfBith;
                    if (!(string.IsNullOrEmpty(txtDOB.Text.Trim())))
                    {
                        dateOfBith = Convert.ToDateTime(txtDOB.Text);
                    }
                    else
                    {

                        dateOfBith = null;
                    }

                    customer.FirstName = txtFirstName.Text;
                    customer.LastName = txtLastName.Text;
                    customer.TelephoneNumber = txtPhoneNumber.Text;
                    customer.MobileNumber = txtMobileNumber.Text;
                    customer.DOB = dateOfBith??Convert.ToDateTime(dateOfBith);
                    customer.Gender = rblGender.SelectedValue;
                    customer.ProvinceOrState = txtProvinceState.Text;
                    customer.CountryId = int.Parse(ddlCountry.SelectedValue);
                    customer.Status = 1;
                    customer.Address = txtCompleteAddress.Text;
                    if (txtEmail.Text != "" && emailExist==false)
                    {
                        customer.Email = txtEmail.Text;
                    }

                    if (clothEntities.SaveChanges() > 0)
                    {
                        ClearAllFields();
                        string s = "alert('Your Profile Has been Updated Successfully.');";
                        ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);

                        MainDiv.InnerHtml = "";
                        MainDiv.InnerHtml = "<h1>Your Profile Has been Updated Successfully.</h1>";

                    }
                    else
                    {
                        string s = "alert('Error Occured While Saving User Info');";
                        ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
                    }

                }
        }


    else
                    {

                        Utility.ShowPopUpMessage("Email Already Exist",
                            new List<string>(){"You may retreive the password for this email  <a href=\"ForgotPassword.aspx\"> Click Here </a>"}, this.Page, true);

                    }

               
            

        }
    }
}
