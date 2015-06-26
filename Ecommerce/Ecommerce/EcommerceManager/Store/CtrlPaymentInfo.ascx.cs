using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceDAL;
using EcommerceUtilities;

namespace Ecommerce.EcommerceManager.Store
{
    public partial class CtrlPaymentInfo : UserControlFront
    {
        private readonly string _emailTemp = ConfigurationManager.AppSettings["EmailTemplates"] + "PaymentDelayed.html";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridForPaymentInfo();
            }

        }


        /// <summary>
        /// Code added by zia - Bind Grid
        /// </summary>
        private void PopulateGridForPaymentInfo()
        {
            using (var db = new ClothEntities())
            {
                var raw = (from store in db.tbl_Stores
                           join storePayment in db.tbl_StorePayment on store.StoreId equals storePayment.StoreId into combine
                           from cm in combine.DefaultIfEmpty()
                           select new
                           {
                               store.StoreId,
                               store.StoreName,
                               store.StoreDomainName,
                               cm.StorePaymentFromDate,
                               cm.StorePaymentToDate,
                               store.StoreOwnerName,
                               store.StoreOwnerContact,
                               store.StoreOwnerEmail
                           }).ToList();


                var data = raw.Select(y => new
                {
                    y.StoreId,
                    y.StoreName,
                    y.StoreOwnerContact,
                    y.StoreOwnerEmail,
                    y.StoreOwnerName,
                    y.StoreDomainName,
                    y.StorePaymentFromDate,
                    y.StorePaymentToDate,
                    paymentduration =
                        y.StorePaymentFromDate != null && y.StorePaymentToDate != null ? "Paid" : "Pending"
                }).ToList();
                gvdViewPaymentInfo.DataSource = data;
                gvdViewPaymentInfo.DataBind();
            }
        }

        /// <summary>
        /// code added by zia - Search payment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSearchClicked(object sender, EventArgs e)
        {
            using (var db = new ClothEntities())
            {
                DateTime dtText = Convert.ToDateTime(dtFrom.Text);
                var raw = (from store in db.tbl_Stores
                           join storePayment in db.tbl_StorePayment on store.StoreId equals storePayment.StoreId
                           where storePayment.StorePaymentFromDate >= dtText && dtText <= storePayment.StorePaymentToDate
                           select new
                           {
                               store.StoreId,
                               store.StoreName,
                               store.StoreDomainName,
                               storePayment.StorePaymentFromDate,
                               storePayment.StorePaymentToDate
                           }).ToList();


                var data = raw.Select(y => new
                {
                    y.StoreId,
                    y.StoreName,
                    y.StoreDomainName,
                    y.StorePaymentFromDate,
                    y.StorePaymentToDate,
                    paymentduration =
                        y.StorePaymentFromDate.Value.ToString("dd MMMM yyyy") + " - " +
                        y.StorePaymentToDate.Value.ToString("dd MMMM yyyy "),
                }).ToList();
                gvdViewPaymentInfo.DataSource = data;
                gvdViewPaymentInfo.DataBind();
            }
        }

        /// <summary>
        /// Code added by zia - redirect pages
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GvdViewPaymentRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "PaymentHistory")
            {
                Response.Redirect("~/EcommerceManager/StorePaymentHistory.aspx?StoreId=" + e.CommandArgument);
            }
            if (e.CommandName == "GenerateEmail")
            {
                DataKey dk = gvdViewPaymentInfo.DataKeys[Convert.ToInt32(e.CommandArgument)];
                if (dk != null && dk.Values != null)
                {
                    int storeId = Convert.ToInt32(dk.Values["StoreId"]);
                    var ownerName = dk.Values["StoreOwnerName"].ToString();
                    var ownerEmail = dk.Values["StoreOwnerEmail"].ToString();
                    string body=EmailManager.PopulateBody(ownerName, "www.ultimatesoft.com",
                        "Please pay the dues within 7 days after this mail received, alternatively our sevices can be closed. ",
                        _emailTemp,GetPaymentDurationOfStoreByFromStoreId(storeId));
                    EmailManager.SendHtmlFormattedEmail(ownerEmail,"Payments due",body);
                    Utility.ShowPopUpMessage("Success",new List<string>(){"Email sent successfully"},this.Page,true );
                }
            }
        }
    }
}