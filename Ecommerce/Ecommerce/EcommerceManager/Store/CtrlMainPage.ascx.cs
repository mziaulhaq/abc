using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EcommerceDAL;

namespace Ecommerce.EcommerceManager.Store
{
    public partial class CtrlMainPage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDataLists();
            }
        }
        private void PopulateDataLists()
        {
            using (var db = new ClothEntities())
            {
                lstBasic.DataSource = db.tbl_Packages.Where(x => x.PackageId == 1).ToList();
                lstBasic.DataBind();
                lstBusiness.DataSource = db.tbl_Packages.Where(x => x.PackageId == 2).ToList();
                lstBusiness.DataBind();
                lstPlus.DataSource = db.tbl_Packages.Where(x => x.PackageId == 4).ToList();
                lstPlus.DataBind();
            }
        }
        /// <summary>
        /// Buy Now of Package clicked
        /// </summary>
        protected void BtnBuyNowClicked(object sender, CommandEventArgs e)
        {
            Response.Redirect("~/EcommerceManager/StoreRegWizard.aspx?PackId=" + e.CommandArgument);
        }
        
    }
}