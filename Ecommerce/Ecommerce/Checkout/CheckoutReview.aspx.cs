using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceDAL;
using EcommerceUtilities;


namespace Ecommerce.Checkout
{
    public partial class CheckoutReview : System.Web.UI.Page
    {
        public Dictionary<long, int> _allcartItems;
        private string _orderSite = ConfigurationManager.AppSettings["ApplicationUrl"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                PayPalFunctions payPalCaller = new PayPalFunctions();

                string retMsg = "";
                string token = "";
                string PayerID = "";
                NVPCodec decoder = new NVPCodec();
                token = Session["token"].ToString();

                bool ret = payPalCaller.GetCheckoutDetails(token, ref PayerID, ref decoder, ref retMsg);
                if (ret)
                {
                    Session["payerId"] = PayerID;
                    // Verify total payment amount as set on CheckoutStart.aspx.
                    try
                    {
                        decimal paymentAmountOnCheckout = Convert.ToDecimal(Session["payment_amt"].ToString());
                        decimal paymentAmoutFromPayPal = Convert.ToDecimal(decoder["AMT"].ToString());
                        if (paymentAmountOnCheckout != paymentAmoutFromPayPal)
                        {
                            Response.Redirect("CheckoutError.aspx?" + "Desc=Amount%20total%20mismatch.");
                        }
                    }
                    catch (Exception)
                    {
                        Response.Redirect("CheckoutError.aspx?" + "Desc=Amount%20total%20mismatch.");
                    }
                    _allcartItems = LoggedCustomer.GetCartItems();
                    if (_allcartItems != null && _allcartItems.Count != 0)
                    {
                        PopulateCartItems();
                        PopulateCustomerInformation();
                        if (Session["payment_amt"] != null)
                            lblTotal.Text = Session["payment_amt"].ToString();

                    }
                }
            }
        }

        private void PopulateCustomerInformation()
        {
            using (var db=new ClothEntities())
            {
                long userId = LoggedCustomer.IsUserLogged()? LoggedCustomer.GetLoggedCustomer().Id
                    : -1;
                dtvShipInfo.DataSource = db.tbl_Customers.Where(x => x.CustomerID == userId).ToList();
                dtvShipInfo.DataBind();
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
                unitPrice = Convert.ToInt64(clothEntities.SP_CalculateProductPrice(prodId).ToList()[0]);
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
        protected void CheckoutConfirm_Click(object sender, EventArgs e)
        {
            Session["userCheckoutCompleted"] = "true";
            Response.Redirect("~/Checkout/CheckoutComplete.aspx");
        }

    }
}