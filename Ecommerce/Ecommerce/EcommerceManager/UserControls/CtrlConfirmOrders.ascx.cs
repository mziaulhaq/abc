using System;
using System.Collections.Generic;
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
    public partial class CtrlConfirmOrders : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                hfFrom.Value = string.Empty;
                hfTo.Value = string.Empty;
                tblDetail.Visible = false;
                PopulateAllOrders();
            }
        }

        private void PopulateAllOrders()
        {
            using (var clothEntities=new ClothEntities())
            {
                string from = hfFrom.Value;
                string to = hfTo.Value;
                var orders = clothEntities.SP_GetSubmittedtOrders(LoggedStoreId, 1, from, to,"");
                gdvHomeBanners.DataSource = orders;
                gdvHomeBanners.DataBind();
            }
        }

        protected void OrdersSearchedClicked(object sender, ImageClickEventArgs e)
        {
            Page.Validate("OrdersSearch");
            gdvHomeBanners.PageIndex = 0;
            tblDetail.Visible = false;
            hfFrom.Value = dtFrom.Text;
            hfTo.Value = dtTo.Text;
            PopulateAllOrders();
        }

        protected void gdvHomeBanners_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gdvHomeBanners.SelectedDataKey != null)
            {
                tblDetail.Visible = true;
                hlProduct.NavigateUrl = "~/EcommerceManager/ProductView?PId=" + gdvHomeBanners.SelectedDataKey["ProductId"].ToString();
                lblProductName.Text = gdvHomeBanners.SelectedDataKey["ProductName"].ToString();
                lblQuantity.Text = gdvHomeBanners.SelectedDataKey["Quantity"].ToString();
                lblPriceAtOrderTime.Text = gdvHomeBanners.SelectedDataKey["PriceAtOrderTime"].ToString();
                lblSaleAtOrderTime.Text = gdvHomeBanners.SelectedDataKey["SalesAtOrderTime"].ToString();
                lblSalesTaxAtOrderTime.Text = gdvHomeBanners.SelectedDataKey["SalesTaxAtOrderTime"].ToString();
                lblPricePerUnitAtOrderTime.Text =
                    PerUnitPrice(gdvHomeBanners.SelectedDataKey["SalesAtOrderTime"].ToString(),
                                 gdvHomeBanners.SelectedDataKey["SalesTaxAtOrderTime"].ToString(),
                                 gdvHomeBanners.SelectedDataKey["PriceAtOrderTime"].ToString());
                lblTotalPrice.Text = (Convert.ToDouble(lblPricePerUnitAtOrderTime.Text) * Convert.ToDouble(gdvHomeBanners.SelectedDataKey["Quantity"].ToString())).ToString();
                lblName.Text = gdvHomeBanners.SelectedDataKey["CustomerName"].ToString();
                lblEmail.Text = gdvHomeBanners.SelectedDataKey["Email"].ToString();
                lblAddress.Text = gdvHomeBanners.SelectedDataKey["Address"].ToString();
                lblStateOrProvince.Text = gdvHomeBanners.SelectedDataKey["ProvinceOrState"].ToString();
                lblCountry.Text = gdvHomeBanners.SelectedDataKey["CountryName"].ToString();
                lblPhoneNumber.Text = gdvHomeBanners.SelectedDataKey["TelephoneNumber"].ToString();
                lblMobileNumber.Text = gdvHomeBanners.SelectedDataKey["MobileNumber"].ToString();
            }
        }
        private string PerUnitPrice(string sl, string sTaxRates, string pr)
        {
            double sales = Convert.ToInt32(sl);
            double salesTaxRates = Convert.ToInt32(sTaxRates);
            double price = Convert.ToDouble(pr);
            return Math.Floor(price + ((sales*100)/price) + salesTaxRates).ToString();

        }
        protected void gdvHomeBanners_PageIndexChanged(object sender, EventArgs e)
        {
            tblDetail.Visible = false;
        }
        protected void gdvHomeBanners_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            tblDetail.Visible = false;
            gdvHomeBanners.PageIndex = e.NewPageIndex;
            PopulateAllOrders();
        }

        protected void BtnRejectOrderClicked(object sender, EventArgs e)
        {
            if (gdvHomeBanners.SelectedDataKey != null)
            {
                long orderId = Convert.ToInt64(gdvHomeBanners.SelectedDataKey["OrderId"].ToString());
                using (var clothEntities = new ClothEntities())
                {
                    var status = new ObjectParameter("ReturnVal", typeof(bool));
                    clothEntities.SP_RejectOrderAfterConfirmation(orderId, LoggedUserId, LoggedStoreId, status);

                    if (Convert.ToBoolean(status.Value))
                    {
                        Utility.ShowPopUpMessage("Successfully Rejected",
                                                 new List<string>() { "Orders Information Successfully Rejected" },
                                                 this.Page, true);
                        ResetDetailsToDefault();
                        PopulateAllOrders();
                    }
                    else
                    {
                        Utility.ShowPopUpMessage("Error Occured",
                                                 new List<string>() { "Error Occured While Rejecting Orders Information" }, this.Page,
                                                 true);
                    }
                }
            }
            else
            {
                Utility.ShowPopUpMessage("Incorrect Info",
                                         new List<string>() {"Information provided for processing is incorrect"},
                                         this.Page,
                                         true);
            }
        }
        private void ResetDetailsToDefault()
        {
            tblDetail.Visible = false;
            hlProduct.NavigateUrl = string.Empty;
            lblProductName.Text = string.Empty;
            lblQuantity.Text = string.Empty;
            lblPriceAtOrderTime.Text = string.Empty;
            lblSaleAtOrderTime.Text = string.Empty;
            lblSalesTaxAtOrderTime.Text = string.Empty;
            lblPricePerUnitAtOrderTime.Text = string.Empty;
            lblTotalPrice.Text = string.Empty;
            lblName.Text = string.Empty;
            lblEmail.Text = string.Empty;
            lblAddress.Text = string.Empty;
            lblStateOrProvince.Text =  string.Empty;
            lblCountry.Text = string.Empty;

        }

        protected void BtnDeliverOrderClicked(object sender, EventArgs e)
        {
            if(gdvHomeBanners.SelectedDataKey!=null)
            {
                long orderId = Convert.ToInt64(gdvHomeBanners.SelectedDataKey["OrderId"].ToString());
                using (var clothEntities = new ClothEntities())
                {
                     var order = clothEntities.tbl_Orders.FirstOrDefault(ord => ord.OrderId == orderId);
                     if (order != null)
                     {
                         var tblOrderUpdation = new tbl_OrdersUpdation()
                                                    {
                                                        OrderStatus = order.OrderStatus,
                                                        OrderStatusUpdateBy = order.OrderStatusUpdateBy,
                                                        OrderStatusUpdatedDate = order.OrderStatusUpdateDate,
                                                        OrderId = order.OrderId
                                                    };
                         order.OrderStatusUpdateBy = LoggedUserId;
                         order.OrderStatusUpdateDate = DateTime.Now;
                         order.OrderStatus = 2;
                         if (clothEntities.SaveChanges() > 0)
                         {
                             Utility.ShowPopUpMessage("Successfully Delivered",
                                                      new List<string>() {"Orders Information Successfully Set to Delivered"},
                                                      this.Page, true);
                             ResetDetailsToDefault();
                             PopulateAllOrders();
                         }
                         else
                         {
                             Utility.ShowPopUpMessage("Error Occured",
                                                      new List<string>()
                                                          {"Error Occured While Updating Order to deliver"}, this.Page,
                                                      true);
                         }

                     }
                     else
                     {
                          Utility.ShowPopUpMessage("Incorrect information",
                                                      new List<string>() {"Information provided is incorrect, there is no such Order"},
                                                      this.Page, true);
                     }
                }
            }
        }

        protected void cvDateCheck_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if(!string.IsNullOrEmpty(dtFrom.Text) && !string.IsNullOrEmpty(dtTo.Text))
            {
                try
                {
                    var dateFrom = Convert.ToDateTime(dtFrom.Text);
                    var dateTo = Convert.ToDateTime(dtTo.Text);
                    if (dateFrom < dateTo)
                        args.IsValid = true;
                    else
                    {
                        args.IsValid = false;
                        Utility.ShowPopUpMessage("Invalid Query Parameters", new List<string>(){"Please provide valid date to query"},this.Page,true);
                    }

                }
                catch (Exception)
                {
                    args.IsValid = false;
                    Utility.ShowPopUpMessage("Invalid Query Parameters", new List<string>() { "Please provide valid date to query" }, this.Page, true);
                }
           }
            
        }
    }
}