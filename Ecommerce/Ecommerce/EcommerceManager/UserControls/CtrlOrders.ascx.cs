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
    public partial class CtrlOrders : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hfFrom.Value = string.Empty;
                hfTo.Value = string.Empty;
                tblDetail.Visible = false;
                PopulateAllOrders();
            }
        }

        private void PopulateAllOrders()
        {
            using (var clothEntities = new ClothEntities())
            {
                string from = hfFrom.Value;
                string to = hfTo.Value;
                if (!string.IsNullOrWhiteSpace(txtOrderId.Text))
                {
                    var orderObtained = clothEntities.SP_GetSubmittedtOrdersByOrderId(LoggedStoreId,Convert.ToInt32(txtOrderId.Text)).ToList();
                    gdvHomeBanners.DataSource = orderObtained;
                    gdvHomeBanners.DataBind();
                }
                else if (drpOrderStatusSearch.SelectedValue == "--Select--")
                {
                    var orders = clothEntities.SP_GetSubmittedtOrders(LoggedStoreId, 0, from, to, txtCustomerName.Text).ToList();
                    gdvHomeBanners.DataSource = orders;
                    gdvHomeBanners.DataBind();
                }
                else if (drpOrderStatusSearch.SelectedValue != "--Select--")
                {
                    byte orderStatus = Convert.ToByte(drpOrderStatusSearch.SelectedValue);
                    var orders = clothEntities.SP_GetSubmittedtOrders(LoggedStoreId, orderStatus, from, to, txtCustomerName.Text).ToList();
                    gdvHomeBanners.DataSource = orders;
                    gdvHomeBanners.DataBind();
                }
                
            }
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
                hdnOrderId.Value = gdvHomeBanners.SelectedDataKey["OrderId"].ToString();

            }
        }

        private string PerUnitPrice(string sl, string sTaxRates, string pr)
        {
            double sales = Convert.ToInt32(sl);
            double salesTaxRates = Convert.ToInt32(sTaxRates);
            double price = Convert.ToDouble(pr);
            return Math.Floor(price + ((sales * 100) / price) + salesTaxRates).ToString();
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
            Utility.ShowBootStrapPopUp("rejectOrderComment", this.Page, true);
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
            lblStateOrProvince.Text = string.Empty;
            lblCountry.Text = string.Empty;

        }

        protected void BtnConfirmOrderClicked(object sender, EventArgs e)
        {
            if (gdvHomeBanners.SelectedDataKey != null)
            {
                long orderId = Convert.ToInt64(gdvHomeBanners.SelectedDataKey["OrderId"].ToString());
                using (var clothEntities = new ClothEntities())
                {
                    var objReturnValue = new ObjectParameter("returnVal", typeof(bool)) { Value = "true" };
                    clothEntities.SP_ConfirmOrder(orderId, LoggedUserId, LoggedStoreId, objReturnValue);
                    if (Convert.ToBoolean(objReturnValue.Value) == true)
                    {
                        Utility.ShowPopUpMessage("Successfully Updated", new List<string>() { "Orders Information Successfully Updated" }, this.Page, true); ResetDetailsToDefault();
                        PopulateAllOrders();
                    }
                    else
                    {
                        Utility.ShowPopUpMessage("Error Occured", new List<string>() { "Error Occured While Updating Orders Information" }, this.Page, true);
                    }


                }
            }
        }

        protected void cvDateCheck_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(dtFrom.Text) && !string.IsNullOrEmpty(dtTo.Text))
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
                        Utility.ShowPopUpMessage("Invalid Query Parameters", new List<string>() { "Please provide valid date to query" }, this.Page, true);
                    }

                }
                catch (Exception)
                {
                    args.IsValid = false;
                    Utility.ShowPopUpMessage("Invalid Query Parameters", new List<string>() { "Please provide valid date to query" }, this.Page, true);
                }
            }

        }

        protected void ShowEditQuantityModel(object sender, EventArgs e)
        {
            Utility.ShowBootStrapPopUp("divEditQty", this.Page, true);
        }

        protected void BtnUpdateOrderQtyClicked(object sender, EventArgs e)
        {
            int orderId;
            if (int.TryParse(hdnOrderId.Value, out orderId))
            {
                using (var db = new ClothEntities())
                {
                    var order = db.tbl_Orders.First(x => x.OrderId == orderId);
                    order.Quantity = Convert.ToInt32(txtOrderQuantity.Text);
                    if (db.SaveChanges() > 0)
                        Utility.ShowMessageAndHidePopup("Success", new List<string>() { "Order Info Updated Successfully" }, this.Page, true);
                    else
                        Utility.ShowMessageAndHidePopup("Failure", new List<string>() { "Order Info couldnot be Updated." }, this.Page, true);
                    PopulateAllOrders();
                    tblDetail.Visible = false;
                }
            }
        }

        protected void BtnSubmitCommentClicked(object sender, EventArgs e)
        {
            if (gdvHomeBanners.SelectedDataKey != null)
            {
                //long orderId = Convert.ToInt64(gdvHomeBanners.SelectedDataKey["OrderId"].ToString());
                long orderId = Convert.ToInt64(hdnOrderId.Value);
                using (var clothEntities = new ClothEntities())
                {
                    var order = clothEntities.tbl_Orders.FirstOrDefault(ord => ord.OrderId == orderId);
                    if (order != null)
                    {
                        //new tbl_OrdersUpdation()
                        //{
                        //    OrderStatus = order.OrderStatus,
                        //    OrderStatusUpdateBy = order.OrderStatusUpdateBy,
                        //    OrderStatusUpdatedDate = order.OrderStatusUpdateDate,
                        //    OrderId = order.OrderId
                        //};
                        //order.OrderConfirmBy = LoggedUserId;
                        //order.OrderConfirmationDate = DateTime.Now;
                        order.OrderConfirmation = false;
                        order.OrderStatusUpdateBy = LoggedUserId;
                        order.OrderStatusUpdateDate = DateTime.Now;
                        order.OrderStatus = 4;
                        order.Comment = txtComment.Text;
                        if (clothEntities.SaveChanges() > 0)
                        {
                            EmailManager.SendHtmlFormattedEmail(lblEmail.Text, "Order Status", "Your order for " + lblProductName.Text + " has been rejected due to " + txtComment.Text + ".");
                            Utility.ShowMessageAndHidePopup("Successfully Rejected", new List<string>() { "Orders Information Successfully Rejected" }, this.Page, true);
                            ResetDetailsToDefault();
                            PopulateAllOrders();
                            tblDetail.Visible = false;
                        }
                        else
                        {
                            Utility.ShowMessageAndHidePopup("Error Occured", new List<string>() { "Error Occured While Rejecting Orders Information" }, this.Page, true);
                        }
                    }
                    else
                    {
                        Utility.ShowMessageAndHidePopup("Incorrect Info", new List<string>() { "Information provided for processing is incorrect" }, this.Page, true);
                    }
                }
            }
        }

        protected void SetOrderStatus(object sender, EventArgs e)
        {
            Utility.ShowBootStrapPopUp("setOrderStatus", this.Page, true);
        }

        protected void BtnUpdateOrderStatus(object sender, EventArgs e)
        {
            int orderId;
            short orderStatusVal;
            if (int.TryParse(hdnOrderId.Value, out orderId) && short.TryParse(drpOrderStatus.SelectedValue, out orderStatusVal))
            {
                using (var db = new ClothEntities())
                {
                    tbl_Orders order = db.tbl_Orders.FirstOrDefault(x => x.OrderId == orderId);
                    if (order != null)
                    {
                        order.OrderStatus = Convert.ToByte(orderStatusVal);
                        if (db.SaveChanges() > 0)
                        {
                            switch (orderStatusVal)
                            {
                                case 2:
                                    EmailManager.SendHtmlFormattedEmail(lblEmail.Text, "Order Status", "Your order for " + lblProductName.Text + " has been " + drpOrderStatus.SelectedItem.Text + ". Please check your order status by logging in at www.lahorecloth.com");
                                    break;
                                case 3:
                                    EmailManager.SendHtmlFormattedEmail(lblEmail.Text, "Order Status", "Your order for " + lblProductName.Text + " has been " + drpOrderStatus.SelectedItem.Text + ". Please check your order status by logging in at www.lahorecloth.com");
                                    break;
                                case 5:
                                    EmailManager.SendHtmlFormattedEmail(lblEmail.Text, "Order Status", "Your order for " + lblProductName.Text + " has been " + drpOrderStatus.SelectedItem.Text + ". Please check your order status by logging in at www.lahorecloth.com");
                                    break;
                            }
                            Utility.ShowMessageAndHidePopup("Success", new List<string>() { "Order status updated successfully" }, this.Page, true);
                        }
                    }
                }
            }
        }

        protected void OrdersSearchedClicked(object sender, EventArgs e)
        {
            Page.Validate("OrdersSearch");
            gdvHomeBanners.PageIndex = 0;
            tblDetail.Visible = false;
            hfFrom.Value = dtFrom.Text;
            hfTo.Value = dtTo.Text;
            PopulateAllOrders();
        }
    }
}