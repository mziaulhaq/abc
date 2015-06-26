using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceUtilities
{
   public static class OrderStatus
    {
        public static string StatusDescription(int status)
        {
            //0=ToBeProcessed, 1=OrderConfirmationSuccessfull, 2=Delivered , 3=Canceled, 4=RejectedByCustomer
            switch (status)
            {
                case 1:
                    return "Under Process";
                   
                case 2:
                    return "Confirmed";
                    
                case 3:
                    return "Dispatched";
                    
                case 4:
                    return "Rejected/Cancelled";

                case 5:
                    return "Delivered";

                default :
                    return "Undefined";

            }
        }
    }
}
