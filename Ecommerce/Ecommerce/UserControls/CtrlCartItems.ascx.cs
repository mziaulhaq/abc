using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceUtilities;
using EcommerceDAL;
namespace Ecommerce.UserControls
{
    public partial class CtrlCartItems : UserControlFront
    {
        private Dictionary<long, int> _allcartItems;
        private string _orderSite = ConfigurationManager.AppSettings["ApplicationUrl"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                    lstCartItems.DataSource = allProducts;
                    lstCartItems.DataBind();
                }
            }
            else
            {
                lstCartItems.DataSource = null;
                lstCartItems.DataBind();
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

        protected void lstCartItemsRowCommand(object sender, GridViewCommandEventArgs e)
        {
            var btn = e.CommandSource as LinkButton;
            if (btn != null && e.CommandName == "dl")
            {
                long productId;
                if (btn.CommandArgument != string.Empty && long.TryParse(e.CommandArgument.ToString(), out productId))
                {
                    LoggedCustomer.DeleteItemFromCart(productId);
                    _allcartItems = LoggedCustomer.GetCartItems();
                    PopulateCartItems();

                }
            }
        }
        protected void CheckOutClicked(object sender, EventArgs e)
        {
            //var lblTotalAmount = lstCartItems.FooterRow.FindControl("lblTotal") as Label;
            //if (lblTotalAmount != null)
            //    Session["payment_amt"] = lblTotalAmount.Text;
            //else
            //{
            //    Response.Redirect("~/Index.aspx");
            //}
            //Response.Redirect("~/COStart.aspx");
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
                unitPrice = Convert.ToInt64(clothEntities.tbl_Products.First(x=>x.ProductID==prodId).ProductUnitPrice);
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
        protected void Page_PreRender(object sender, EventArgs args)
        {
            decimal totalPrice = 0;
            //if (lstCartItems.Rows.Count != 0)
            //{
            //    foreach (GridViewRow row in lstCartItems.Rows)
            //    {
            //        if (row.RowType == DataControlRowType.DataRow)
            //        {

            //            var priceLabel = row.FindControl("lblPrice") as Label;
            //            decimal price;
            //            if (priceLabel != null && decimal.TryParse(priceLabel.Text, out price))
            //            {
            //                totalPrice += price;
            //            }
            //        }
            //    }
            //    //var gdvR = lstCartItems.FooterRow;
            //    //if (gdvR != null)
            //    //{
            //    //    var totalLabel = gdvR.FindControl("lblTotal") as Label;
            //    //    if (totalLabel != null)
            //    //    {
            //    //        totalLabel.Text = totalPrice.ToString();
            //    //        Session["payment_amt"] = totalLabel.Text;
            //    //    }

            //    //}
            //    lstCartItems.Visible = true;
            //    cartItemsEmpty.Visible = false;
            //    CartCheckOut.Enabled = true;
            //}
            //else
            //{
            //    lstCartItems.Visible = false;
            //    cartItemsEmpty.Visible = true;
            //    CartCheckOut.Enabled = false;
            //}


        }
    }
}