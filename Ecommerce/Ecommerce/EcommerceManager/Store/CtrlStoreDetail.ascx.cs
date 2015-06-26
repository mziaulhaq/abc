using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceDAL;

namespace Ecommerce.EcommerceManager.Store
{
    public partial class CtrlStoreDetail : UserControlFront
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateSummeryData();
                btnDisableEnable.Text = hdnStatus.Value.ToLower() == "true" ? "Disable" : "Enable";
            }
        }

        /// <summary>
        /// Code added by zia - Show Detail of store
        /// </summary>
        private void PopulateSummeryData()
        {
            int storeId;
            if (Request.QueryString["stId"] != null && int.TryParse(Request.QueryString["stId"], out storeId))
            {
                using (var db = new ClothEntities())
                {
                    var storeInfo = db.tbl_Stores.FirstOrDefault(x => x.StoreId == storeId);
                    if (storeInfo != null)
                    {
                        lblOwnerName.Text = storeInfo.StoreOwnerName;
                        lblOwnerEmail.Text = storeInfo.StoreOwnerEmail;
                        lblOwnerContact.Text = storeInfo.StoreOwnerContact;
                        lblBusinessName.Text = storeInfo.StoreName;
                        lblDomain.Text = storeInfo.StoreDomainName;
                        lblPackage.Text = GetPackageNameById(Convert.ToInt32(storeInfo.PackageId));
                        lblBillingTerm.Text = GetBillingTermById(Convert.ToInt32(storeInfo.BillingTermId));
                        lblCountry.Text = GetCountryNameById(Convert.ToInt32(storeInfo.CountryId));
                        lblCity.Text = storeInfo.StoreCity;
                        lblStoreStatus.Text = GetStoreStatusByBool(Convert.ToBoolean(storeInfo.StoreStatus));
                        hdnStatus.Value = storeInfo.StoreStatus.ToString();
                        lblPostCode.Text = storeInfo.StorePostCode;
                        lblContact.Text = storeInfo.StoreContact;
                        lblAddress.Text = storeInfo.SotreAddress;
                        imgTemplate.ImageUrl = ConfigurationManager.AppSettings["GetTemplates"] + "/" + GetTemplateNameById(1);
                    }
                }

            }
        }
        /// <summary>
        /// Code added by zia - Disable/Enable Store
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnDisableEnableStoreClicked(object sender, EventArgs e)
        {
            using (var db=new ClothEntities())
            {
                int storeId;
                if (Request.QueryString["stId"] != null && int.TryParse(Request.QueryString["stId"], out storeId))
                {
                    var storeInfo = db.tbl_Stores.FirstOrDefault(x => x.StoreId == storeId);
                    if (storeInfo != null)
                    {
                        storeInfo.StoreStatus = lblStoreStatus.Text != "Enabled";
                        if(db.SaveChanges()>0)
                            PopulateSummeryData();
                    }
                }
            }
        }

        /// <summary>
        /// Code added by zia - Billing Detail of Store
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnBillingDetailStoreClicked(object sender, EventArgs e)
        {
            Response.Redirect("~/EcommerceManager/StorePaymentHistory.aspx?StoreId=" + Request.QueryString["stId"]);
            //Response.Redirect("~/EcommerceManager/BillingDetail?id=" + Request.QueryString["stId"]);
        }
    }
}