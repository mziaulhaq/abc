using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceDAL;

namespace Ecommerce.EcommerceManager.UserControls.Products
{
    public partial class CtrlProductDynamicPropertiesView : UserControlBase
    {
        private long _pId;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                if (Request.QueryString["PId"] != null && long.TryParse(Request.QueryString["PId"], out _pId))
                {
                    PopulateDynamicCategories();
                }
                   
             

            }
        }

        private void PopulateDynamicCategories()
        {
            using (var clothEntities = new ClothEntities())
            {
                var allDynamicCategoriesOfProduct = clothEntities.GetAllDynamicCategoriesofProduct(LoggedStoreId, _pId);
                GdvDynamicCategories.DataSource = allDynamicCategoriesOfProduct.ToList();
                GdvDynamicCategories.DataBind();
            }

        }

       
    }
}