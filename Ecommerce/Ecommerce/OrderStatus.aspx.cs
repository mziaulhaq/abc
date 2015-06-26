using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EcommerceUtilities;

namespace Ecommerce
{
    public partial class OrderStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!LoggedCustomer.IsUserLogged())
                Response.Redirect("Index");
        }
    }
}