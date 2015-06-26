using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.util;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EcommerceDAL;
using EcommerceUtilities;


namespace Ecommerce.Checkout
{
    public partial class CheckoutComplete : System.Web.UI.Page
    {
        private Dictionary<long, int> _allcartItems;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verify user has completed the checkout process.
                if ((string)Session["userCheckoutCompleted"] != "true")
                {
                    Session["userCheckoutCompleted"] = string.Empty;
                    Response.Redirect("CheckoutError.aspx?" + "Desc=Unvalidated%20Checkout.");
                }

                PayPalFunctions payPalCaller = new PayPalFunctions();

                string retMsg = "";
                string token = "";
                string finalPaymentAmount = "";
                string PayerID = "";
                NVPCodec decoder = new NVPCodec();

                token = Session["token"].ToString();
                PayerID = Session["payerId"].ToString();
                finalPaymentAmount = Session["payment_amt"].ToString();

                bool ret = payPalCaller.DoCheckoutPayment(finalPaymentAmount, token, PayerID, ref decoder, ref retMsg);
                if (ret)
                {
                    Session["payerId"] = PayerID;
                    // Retrieve PayPal confirmation value.
                    string PaymentConfirmation = decoder["PAYMENTINFO_0_TRANSACTIONID"].ToString();
                    _allcartItems = LoggedCustomer.GetCartItems();
                    if (_allcartItems != null && _allcartItems.Count != 0)
                    {
                        var allCartProducts = _allcartItems.Select(keyValuePair => keyValuePair.Key).ToList();
                        using (var db = new ClothEntities())
                        {
                            var allProducts = db.tbl_Products.Where(prod => allCartProducts.Contains(prod.ProductID)).ToList();
                            foreach (var item in _allcartItems)
                            {
                                var orders = new tbl_Orders();
                                orders.CustomerId = LoggedCustomer.GetLoggedCustomer().Id;
                                orders.ProductId = item.Key;
                                orders.PaymentMethodId = 2;
                                orders.Quantity = item.Value;
                                orders.PriceAtOrderTime = allProducts.First(x => x.ProductID == item.Key).ProductUnitPrice;
                                orders.SalesAtOrderTime = allProducts.First(x => x.ProductID == item.Key).ProductSale;
                                orders.SalesTaxAtOrderTime = allProducts.First(x => x.ProductID == item.Key).SalesTaxId;
                                orders.PurchasedPrice = allProducts.First(x => x.ProductID == item.Key).PurchasePrice;
                                orders.OrderDate = DateTime.Now;
                                orders.OrderConfirmation = null;
                                orders.OrderConfirmationDate = DateTime.Now;
                                orders.OrderConfirmBy = null;
                                orders.OrderStatus = 1;
                                orders.OrderStatusUpdateBy = null;
                                orders.OrderStatusUpdateDate = null;
                                orders.StoreID = allProducts.First(x => x.ProductID == item.Key).StoreId;
                                orders.TransactionId = PaymentConfirmation;
                                orders.RefStoreId = null;//later it will be changed accordingly
                                db.tbl_Orders.Add(orders);
                            }
                            if (db.SaveChanges()>0)
                            {
                                Utility.ShowPopUpMessage("Success",new List<string>(){"Orders inserted successfully"},this.Page,true );
                            }
                            else
                            {
                                Utility.ShowPopUpMessage("Error", new List<string>() { "Orders could not be inserted. please try again" }, this.Page, true);
                            }
                        }
                    }

                    TransactionId.Text = PaymentConfirmation;


                    // Clear order id.
                    Session["currentOrderId"] = string.Empty;
                }
                else
                {
                    Response.Redirect("CheckoutError.aspx?" + retMsg);
                }
            }
        }


        protected void Continue_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");

        }
    }
}