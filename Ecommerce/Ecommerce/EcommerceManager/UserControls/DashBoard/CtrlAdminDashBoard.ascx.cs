using System;
using EcommerceDAL;
using EcommerceUtilities;
using System.Linq;

namespace Ecommerce.EcommerceManager.UserControls.DashBoard
{
    public partial class CtrlAdminDashBoard : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var clothEntities = new ClothEntities())
                {
                    //todaysOrders.InnerText = clothEntities.tbl_Orders.Count(x => x.OrderDate >= DateTime.Today());

                }
            }
        }
    }
}