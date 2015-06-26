using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EcommerceDAL;

namespace Ecommerce.EcommerceManager.Store
{
    public partial class CtrlAllStores : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridForStoreInformation();
            }
        }

        private void PopulateGridForStoreInformation()
        {
            using (var db = new ClothEntities())
            {
                var data = db.tbl_Stores.ToList();
                gvdViewAllStores.DataSource = data;
                gvdViewAllStores.DataBind();
            }
        }
        /// <summary>
        /// Coded added by zia - Delete + Detail of stores 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GvdViewAllStoresRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int stId = Convert.ToInt32(e.CommandArgument);
                using (var db = new ClothEntities())
                {
                    var store = db.tbl_Stores.FirstOrDefault(x => x.StoreId == stId);
                    if (store != null)
                    {
                        db.tbl_Stores.Remove(store);
                        if (db.SaveChanges() > 0)
                        {
                            PopulateGridForStoreInformation();
                        }
                    }
                }
            }
            if (e.CommandName == "Detail")
            {
                Response.Redirect("~/EcommerceManager/StoreDetail.aspx?stId="+e.CommandArgument);
            }
        }
    }
}