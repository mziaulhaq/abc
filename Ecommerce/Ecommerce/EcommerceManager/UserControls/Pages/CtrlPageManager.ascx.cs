using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceDAL;

namespace Ecommerce.EcommerceManager.UserControls.Pages
{
    public partial class CtrlPageManager : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                PopulatePages();
        }

        private void PopulatePages()
        {
            using (var clothEntities = new ClothEntities())
            {
                var allPages = clothEntities.tbl_Pages.Where(pg => pg.StoreId == LoggedStoreId).ToList();
                gdvPages.DataSource = allPages;
                gdvPages.DataBind();
            }
        }
    }
}