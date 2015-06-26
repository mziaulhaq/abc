using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceUtilities
{
    public class DateUtility
    {
        public static DateTime ReturnNotNullDate(DateTime? istDate,DateTime? secondDate)
        {
            if(istDate!=null)
            {
                return ((DateTime) istDate);
            }
            else if(secondDate!=null)
            {
                return ((DateTime) secondDate);
            }
            return DateTime.Now;
        }
        public static string UniqueStringFromDate()
        {
            DateTime dateTime = DateTime.Now;
            return ((dateTime.ToShortDateString() + dateTime.ToShortTimeString()).Replace("/", "").Replace(":","").Replace(" ",""));
        }
        /// <summary>
        /// This function will convert inputted string to date time. if the inputted string is not valid date then it will return null.
        /// </summary>
        /// <param name="convertToDate">Input string to be converted to Date Time</param>
        /// <returns></returns>
        public static DateTime? ConvertToDateTime(string convertToDate)
        {
            try
            {
                if (string.IsNullOrEmpty(convertToDate))
                    return (DateTime?) null;
                return Convert.ToDateTime(convertToDate);
            }
            catch (Exception)
            {
                return (DateTime?) null;
            }
        }
    }
}
