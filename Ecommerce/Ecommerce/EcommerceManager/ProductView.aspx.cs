using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;

namespace Ecommerce.EcommerceManager
{
    public partial class ProductView : AdminBasePage
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            if (Request.UrlReferrer == null && (Session["PId"] == null && Request.UrlReferrer.ToString().ToLower().Contains("productsaddedit")))
               Response.Redirect("ProductsAddEdit",true);
            base.OnPreLoad(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}