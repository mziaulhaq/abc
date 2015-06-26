using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcommerceUtilities;

namespace Ecommerce.App_Start
{
    public class FrontLoggedCustomer : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
          if(!LoggedCustomer.IsUserLogged())
              Response.Redirect("~/Index.aspx");
        }
    }
}