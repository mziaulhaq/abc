using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceUtilities;
using EcommerceDAL;

namespace Ecommerce.EcommerceManager.UserControls.Products
{
    public partial class CtrlHomePageBanner : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
           {
               PopulateProducts();
           }
        }

        private void PopulateProducts()
        {
            using (var clothEntities = new ClothEntities())
            {
                
            }
        }
    }
}