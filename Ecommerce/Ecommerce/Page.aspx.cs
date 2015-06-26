using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceDAL;

namespace Ecommerce
{
    public partial class Pages : FrontBase
    {
        private int _pageId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["PId"] != null && int.TryParse(Request.QueryString["PId"], out _pageId))
                {
                    PopulatePage();
                }
            }
        }

        private void PopulatePage()
        {
            using (var clothEntities = new ClothEntities())
            {
                var page = clothEntities.tbl_Pages.FirstOrDefault(pg => pg.PageId == _pageId && pg.StoreId == StoreId);
                if(page!=null)
                {
                    ltPage.Text = page.Details;
                }
                else
                {
                    ltPage.Text = "No Such Page Found";
                }
            }
        }
    }
}