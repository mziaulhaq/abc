using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EcommerceDAL;

namespace Ecommerce.EcommerceManager.Store
{
    public partial class CtrlPaymentHistory : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGrid();
            }
        }
        /// <summary>
        /// Code added by zia - Populate Payment History
        /// </summary>
        private void PopulateGrid()
        {
            int storeId;
            if (Request.QueryString["StoreId"] != null && int.TryParse(Request.QueryString["StoreId"], out storeId))
            {
                using (var db = new ClothEntities())
                {
                    var raw = (from store in db.tbl_Stores
                        join storePayment in db.tbl_StorePayment on store.StoreId equals storePayment.StoreId
                        join usr in db.tbl_Users on storePayment.StorePaymentInsertedBy equals usr.UserId
                        where store.StoreId == storeId
                        select new
                        {
                            store.StoreId,
                            store.StoreName,
                            store.StoreDomainName,
                            storePayment.StorePaymentFromDate,
                            storePayment.StorePaymentToDate,
                            usr.UserId,
                            usr.UserFullName,
                            storePayment.StorePayment,
                            storePayment.StorePaymentDate
                        }).ToList();


                    var data = raw.Select(y => new
                    {
                        y.StoreId,
                        y.StoreName,
                        y.StoreDomainName,
                        y.StorePaymentFromDate,
                        y.StorePaymentToDate,
                        y.StorePayment,
                        y.StorePaymentDate,
                        y.UserFullName,
                        y.UserId,
                        paymentduration =
                            y.StorePaymentFromDate.Value.ToString("dd MMMM yyyy") + " - " +
                            y.StorePaymentToDate.Value.ToString("dd MMMM yyyy "),
                    }).ToList();

                    GvdPaymentHistory.DataSource = data;
                    GvdPaymentHistory.DataBind();
                }
            }
        }

        protected void GoBackClicked(object sender, EventArgs e)
        {
            Response.Redirect("~/EcommerceManager/PaymentInfo.aspx");
        }
    }
}