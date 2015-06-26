using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceUtilities
{
    public static class ProductStatus
    {
        public static Dictionary<int,string> ListOfProductStatus()
        {
            return new Dictionary<int, string>()
                       {
                            {0,"Inactive"},
                            {1,"Active"},
                            {2,"Upcomming Product"},
                            {3,"Product On Sale"}
                       };
        }
    }
}
