using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EcommerceDAL;

namespace Ecommerce.EcommerceManager.UserControls.Products
{
    public partial class CtrlProductImagesView : System.Web.UI.UserControl
    {
        private long _pId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
                if (Request.QueryString["PId"] != null && long.TryParse(Request.QueryString["PId"], out _pId))
                {
                    PopulateGrid();
                }
                
          

        }
        protected string PathUrl(string url)
        {
            return ConfigurationManager.AppSettings["ProductImagePathUrl"] + url;
        }

        private void PopulateGrid()
        {
            using (var clothEntities = new ClothEntities())
            {
                var productImages = clothEntities.tbl_ProductImages.Where(pimg => pimg.ProductId == _pId).ToList();
                gdvImages.DataSource = productImages;
                gdvImages.DataBind();
            }
        }

    }
}