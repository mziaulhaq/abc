using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceDAL;
using EcommerceUtilities;

namespace Ecommerce.UserControls
{
    public partial class CheckOutStart : UserControlFront
    {
        private Dictionary<long, int> _allcartItems;
        private string _orderSite = ConfigurationManager.AppSettings["ApplicationUrl"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check the user if it logged in then show the user information , otherwise show the loged in page
 
            if (LoggedCustomer.IsUserLogged())
            {
                divUserInfo.Visible = true;
                Divlogin.Visible = false;

            }
            else{
            divUserInfo.Visible = false;
                Divlogin.Visible = true;

            }

            if (!IsPostBack)
            {
                if (!LoggedCustomer.IsUserLogged())
                {
                    Utility.ShowPopUpMessage("Sign In", new List<string>() { "Please Sign In before you confim order" }, this.Page, true);
                }
                PopulateCountry();
                PopulCustomerInformation();
                PopulatePaymentMethods();

                _allcartItems = LoggedCustomer.GetCartItems();
                if (_allcartItems != null && _allcartItems.Count != 0)
                    PopulateCartItems();
            }

        }

        private void PopulateCartItems()
        {
            if (_allcartItems != null && _allcartItems.Count != 0)
            {
                var allCartProducts = _allcartItems.Select(keyValuePair => keyValuePair.Key).ToList();
                using (var clothEntities = new ClothEntities())
                {
                    var allProducts =
                        clothEntities.tbl_Products.Where(prod => allCartProducts.Contains(prod.ProductID)).ToList();
                    GdvCartItems.DataSource = allProducts;
                    GdvCartItems.DataBind();
                }
            }
            else
            {
                GdvCartItems.DataSource = null;
                GdvCartItems.DataBind();
            }

        }

        private void PopulCustomerInformation()
        {
            using (var db = new ClothEntities())
            {
                //long uId = LoggedCustomer.GetLoggedCustomer().Id;
                if (LoggedCustomer.IsUserLogged())
                {
                    long uId = LoggedCustomer.GetLoggedCustomer().Id;
                    tbl_Customers customer = db.tbl_Customers.FirstOrDefault(x => x.CustomerID == uId);
                    if (customer != null)
                    {
                        txtFirstName.Text = customer.FirstName ?? customer.FirstName;
                        txtLastName.Text = customer.LastName ?? customer.LastName;
                        txtMobileNumber.Text = customer.MobileNumber ?? customer.MobileNumber;
                        txtPhoneNumber.Text = customer.TelephoneNumber ?? customer.TelephoneNumber;
                        txtProvinceState.Text = customer.ProvinceOrState ?? customer.ProvinceOrState;
                        txtCompleteAddress.Text = customer.Address ?? customer.Address;
                        //txtDOB.Text = customer.DOB.ToShortDateString();
                        txtEmail.Text = customer.Email ?? customer.Email;
                        ddlCountry.SelectedIndex =
                            ddlCountry.Items.IndexOf(ddlCountry.Items.FindByValue(customer.CountryId.ToString()));
                    }
                    //If the Customs is not loged in then ask him to complete their Address.
                    //else
                    //{
                    //    txtFirstName.Enabled = true;
                    //     txtLastName.Enabled = true;
                    //     txtMobileNumber.Enabled = true;
                    //     txtPhoneNumber.Enabled = true;
                    //     txtProvinceState.Enabled = true;
                    //     txtCompleteAddress.Enabled = true;
                    //     txtEmail.Enabled = true;
                    //     ddlCountry.Enabled = true;
                    //     ddlCountry.Enabled = true;
                    //     Session["FirstTimeCustomer"] = "Yes";
                    //}    
                }
            }
        }

        private void PopulateCountry()
        {
            using (var db = new ClothEntities())
            {
                ddlCountry.DataSource = db.tbl_Country.ToList();
                ddlCountry.DataBind();
                ddlCountry.Items.Insert(0, "--Select Country--");
            }
        }

        private void PopulatePaymentMethods()
        {
            using (var db = new ClothEntities())
            {
                rptPaymentMethods.DataSource = db.tbl_PaymentMethods.ToList();
                rptPaymentMethods.DataBind();
            }
        }

        protected string QuantityOfProductInCartItems(string productId)
        {
            long prodId;
            int quantity;
            if (long.TryParse(productId, out prodId) && LoggedCustomer.IsProductExistPlusProductQuantity(prodId, out quantity))
            {
                return quantity.ToString();
            }
            return "0";
        }

        protected string UnitPrice(string pId)
        {
            long prodId;
            if (long.TryParse(pId, out prodId))
            {
                return UnitPrice(prodId).ToString();
            }
            else
                return "Error";

        }

        private long UnitPrice(long prodId)
        {
            long unitPrice = 0;
            using (var clothEntities = new ClothEntities())
            {
                //unitPrice = Convert.ToInt64(clothEntities.SP_CalculateProductPrice(prodId).ToList()[0]);
                unitPrice = Convert.ToInt64(clothEntities.tbl_Products.First(x => x.ProductID == prodId).ProductUnitPrice);
            }
            return unitPrice;
        }

        protected string ProductCommulativePrice(string pId, string count)
        {
            int quantity;
            long prodId;
            if (long.TryParse(pId, out prodId) && int.TryParse(count, out quantity))
            {
                return (UnitPrice(prodId) * quantity).ToString();
            }
            else
                return "Error";
        }

        protected void BtnConfirmClicked(object sender, EventArgs e)
        {
            var rdbPayment = new RadioButton();

            foreach (RepeaterItem item in rptPaymentMethods.Items)
            {
                if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
                {
                    rdbPayment = item.FindControl("rdbPaymentMethod") as RadioButton;
                    if (rdbPayment != null && rdbPayment.Checked)
                        break;
                }
            }
            if (rdbPayment != null && (rdbPayment.Checked && rdbPayment.Text == "Cash On Delivery"))
            {
                var loggedUser = LoggedCustomer.IsUserLogged() ? LoggedCustomer.GetLoggedCustomer() : null;
                if (loggedUser != null)
                {
                    using (var clothEntities = new ClothEntities())
                    {
                        var orderLists = new List<tbl_Orders>();
                        _allcartItems = LoggedCustomer.GetCartItems();
                        if (_allcartItems != null && _allcartItems.Count != 0)
                        {
                            var productLists = _allcartItems.Select(cart => cart.Key).ToList();
                            var allProducts =
                                clothEntities.tbl_Products.Where(prod => productLists.Contains(prod.ProductID)).ToList();
                            if (productLists.Count == allProducts.Count)
                            {
                                orderLists.AddRange(allProducts.Select(prod => new tbl_Orders()
                                                                                    {
                                                                                        ProductId = prod.ProductID,
                                                                                        CustomerId = loggedUser.Id,
                                                                                        StoreID = StoreId,
                                                                                        OrderStatus = 1,
                                                                                        PriceAtOrderTime = prod.ProductUnitPrice,
                                                                                        Quantity = _allcartItems[prod.ProductID],
                                                                                        OrderDate = DateTime.Now,
                                                                                        SalesAtOrderTime = prod.ProductSale,
                                                                                        PurchasedPrice = prod.PurchasePrice,
                                                                                        PaymentMethodId = GetPaymentMethodIdByName(rdbPayment.Text),
                                                                                        // This will be changed to dynamic for implementing other payment methods 
                                                                                    }));
                                if (orderLists.Count != 0)
                                {
                                    foreach (var tblProducts in orderLists)
                                    {
                                        tblProducts.SalesTaxAtOrderTime =
                                           Convert.ToInt32(clothEntities.SP_GetSalesTaxRateForProduct(tblProducts.ProductId).ToList()[0]);
                                        clothEntities.tbl_Orders.Add(tblProducts);
                                    }
                                    try
                                    {
                                        if (clothEntities.SaveChanges() > 0)
                                        {
                                            Utility.ShowPopUpMessage("Thank You !! for Shopping with Us", new List<string>() { "Your Order has been placed Successfully" }, this.Page, true);
                                            LoggedCustomer.RemoveAllCartItems();
                                            _allcartItems = LoggedCustomer.GetCartItems();
                                            Response.Redirect("~/OrderStatus.aspx");
                                        }

                                    }
                                    catch (Exception)
                                    {

                                        Utility.ShowPopUpMessage("Order Placement UnSuccessful", new List<string>() { "Your order could not be placed successfully!! due to error" }, this.Page, true);
                                    }


                                }
                            }
                        }
                        else
                        {

                            GdvCartItems.DataSource = null;
                            GdvCartItems.DataBind();
                            //cartItemsEmpty.Visible = true;
                            GdvCartItems.Visible = false;


                        }
                    }
                }
                else
                {
                    Utility.ShowPopUpMessage("Your are not loged In", new List<string>() { "Please get loged in by email and password before confim order" }, this.Page, true);
                }
            }
            #region If paypal integrated later
            //else if (rdbPayment != null && (rdbPayment.Checked && rdbPayment.Text == "Pay Pal"))
            //{
            //    Session["CartItems"] = null;
            //    Dictionary<long, int> allCartItems = LoggedCustomer.GetCartItems();
            //    if (allCartItems != null && allCartItems.Count != 0)
            //    {
            //        var allCartProducts = allCartItems.Select(keyValuePair => keyValuePair.Key).ToList();
            //        using (var clothEntities = new ClothEntities())
            //        {
            //            var allProducts =
            //                clothEntities.tbl_Products.Where(prod => allCartProducts.Contains(prod.ProductID)).ToList();

            //            Session["CartItems"] = allProducts;
            //        }
            //    }
            //    Response.Redirect("~/Checkout/CheckoutStart.aspx");
            //    //VirtualPathUtility.ToAbsolute("~/Checkout/CheckoutStart.aspx");
            //}
            #endregion
            else
            {
                Utility.ShowPopUpMessage("Payment methods not selected", new List<string>() { "Please select one payment method before you proceed" }, this.Page, true);
            }
        }

        protected void Page_PreRender(object sender, EventArgs args)
        {
            decimal totalPrice = 0;
            if (GdvCartItems.Rows.Count != 0)
            {
                foreach (GridViewRow row in GdvCartItems.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {

                        var priceLabel = row.FindControl("lblPrice") as Label;
                        decimal price;
                        if (priceLabel != null && decimal.TryParse(priceLabel.Text, out price))
                        {
                            totalPrice += price;
                        }
                    }
                }
                var gdvR = GdvCartItems.FooterRow;
                if (gdvR != null)
                {
                    var totalLabel = gdvR.FindControl("lblTotal") as Label;
                    if (totalLabel != null)
                        totalLabel.Text = "Total : " + totalPrice.ToString();

                }
                GdvCartItems.Visible = true;
            }
            else
            {
                GdvCartItems.Visible = false;
            }
        }
    }
}