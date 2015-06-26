using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceUtilities;

namespace Ecommerce.EcommerceManager
{
    public partial class EcomerceHome : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUserCount.Text = Application["sessionCount"].ToString();
            if (Request.QueryString["cmd"] != null && Request.QueryString["cmd"] == "logout")
            {
                LoggedUser.ReleaseUserSession();
                Response.Redirect("login");
            }
        }
       
    }
}