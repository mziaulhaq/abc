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
    public partial class CtrlProductImages : System.Web.UI.UserControl
    {
        private long _pid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PId"] != null)
            {

                try
                {
                    _pid = Convert.ToInt64(Session["PId"].ToString());
                }
                catch
                {
                    
                }
            }
            if (!IsPostBack)
                PopulateGrid();
          

        }
        protected string PathUrl(string url)
        {
            return ConfigurationManager.AppSettings["ProductImagePathUrl"] + url;
        }

        private void PopulateGrid()
        {
            using (var clothEntities = new ClothEntities())
            {
                var productImages = clothEntities.tbl_ProductImages.Where(pimg => pimg.ProductId == _pid).ToList();
                gdvImages.DataSource = productImages;
                gdvImages.DataBind();
            }
        }

        protected void GdvImagesRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var key = gdvImages.DataKeys[e.RowIndex];
            if (key != null)
            {
                var dataKey = Convert.ToInt64(key.Value);
                using (var clothEntities = new ClothEntities())
                {
                    var img =
                        clothEntities.tbl_ProductImages.FirstOrDefault(
                            im => im.ProductImageId == dataKey && im.ProductId == _pid);
                    if(img!=null)
                    {
                        clothEntities.tbl_ProductImages.Remove(img);
                        if(clothEntities.SaveChanges()>0)
                        {
                            PopulateGrid();
                        }
                    }
                }
            }
        }

        protected void OkAndCancelClicked(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        protected void okbutton_Click(object sender, EventArgs e)
        {

        }
    }
}