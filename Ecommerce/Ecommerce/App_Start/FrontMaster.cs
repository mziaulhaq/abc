using System.Configuration;
using System.Globalization;
using System.Web.UI;

namespace Ecommerce.App_Start
{
    public class FrontMaster : MasterPage
    {
        public int StoreId;
        public string StoreName;
        public FrontMaster()
        {
            StoreId = int.Parse(ConfigurationManager.AppSettings["StoreId"].ToString(CultureInfo.InvariantCulture));
            StoreName = "Lahore Cloth Islamabad Pakistan";
        }
    }
}