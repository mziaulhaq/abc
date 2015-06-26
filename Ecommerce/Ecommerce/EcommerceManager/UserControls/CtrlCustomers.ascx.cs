using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Objects;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceDAL;
using EcommerceUtilities;

namespace Ecommerce.EcommerceManager.UserControls
{
    public partial class CtrlCustomers : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateAllCutomers();
            }
        }

        private void PopulateAllCutomers()
        {
            using (var clothEntities = new ClothEntities())
            {
                var customers = clothEntities.tbl_Customers.ToList();
                gdvCustomers.DataSource = customers;
                gdvCustomers.DataBind();
            }
        }

        protected void CustomerSearchedClicked(object sender, EventArgs e)
        {
            using (var db=new ClothEntities())
            {
                if (drpCustomerStatusSearch.SelectedValue == "--Select--")
                {
                    int selectedValue = Convert.ToInt32(drpCustomerStatusSearch.SelectedValue);
                    var customers =
                        db.SP_GetCustomerInfo(LoggedStoreId, selectedValue, dtRegistrationDate.Text, txtName.Text, txtEmail.Text)
                            .ToList();
                    gdvCustomers.DataSource = customers;
                    gdvCustomers.DataBind();
                }
                else if (drpCustomerStatusSearch.SelectedValue != "--Select--")
                {
                    int selectedValue = Convert.ToInt32(drpCustomerStatusSearch.SelectedValue);
                    var customers =
                        db.SP_GetCustomerInfo(LoggedStoreId, selectedValue, dtRegistrationDate.Text,
                                                         txtName.Text, txtEmail.Text).ToList();
                    gdvCustomers.DataSource = customers;
                    gdvCustomers.DataBind();
                }
            }
        }
    }
}