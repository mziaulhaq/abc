using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using EcommerceDAL;

namespace Ecommerce.App_Start
{
    public class UserControlFront : System.Web.UI.UserControl
    {
        public int StoreId;
        public UserControlFront()
        {
            StoreId = int.Parse(ConfigurationManager.AppSettings["StoreId"].ToString(CultureInfo.InvariantCulture));
        }
        public string BindBrands(string image)
        {
            return ConfigurationManager.AppSettings["BrandImagePathUrl"] + image;
        }
        public string BindProducts(string image)
        {

            return ConfigurationManager.AppSettings["ProductImagePathUrl"] + image;

        }
        public string BindProducts(object image, long productId)
        {
            if (image == null)
            {
                return ConfigurationManager.AppSettings["ProductImagePathUrl"] + GetProductImage(productId);
            }
            else if (image.ToString() == string.Empty)
            {
                return ConfigurationManager.AppSettings["ProductImagePathUrl"] + GetProductImage(productId);
            }

            return ConfigurationManager.AppSettings["ProductImagePathUrl"] + image;
        }
        private string GetProductImage(long productId)
        {
            using (var clothEntities = new ClothEntities())
            {
                var clothEntity = clothEntities.tbl_ProductImages.FirstOrDefault(prod => prod.ProductId == productId);
                if (clothEntity != null)
                    return clothEntity.ImagePathThumbNail;
                else return string.Empty;
            }
        }

        /// <summary>
        /// Code added by Zia
        /// Get Package Name by ID
        /// </summary>

        public static string GetPackageNameById(int packageId)
        {
            string packageName = string.Empty;
            using (var db = new ClothEntities())
            {
                var firstOrDefault = db.tbl_Packages.FirstOrDefault(x => x.PackageId == packageId);
                if (firstOrDefault != null)
                    packageName = firstOrDefault.PackageName;
            }
            return packageName;
        }
        /// <summary>
        /// Code added by Zia
        /// Get Template Name by ID
        /// </summary>
        public static string GetTemplateNameById(int tempId)
        {
            string templateName = string.Empty;
            using (var db = new ClothEntities())
            {
                var firstOrDefault = db.tbl_Templates.FirstOrDefault(x => x.TemplateId == tempId);
                if (firstOrDefault != null)
                    templateName = firstOrDefault.TemplateName;
            }
            return templateName;
        }

        /// <summary>
        /// Code added by Zia
        /// Get Template Name by ID
        /// </summary>
        public static int GetTemplateIdByName(string temp)
        {
            int templateId=0;
            using (var db = new ClothEntities())
            {
                var firstOrDefault = db.tbl_Templates.FirstOrDefault(x => x.TemplateName == temp);
                if (firstOrDefault != null)
                    templateId = firstOrDefault.TemplateId;
            }
            return templateId;
        }
        /// <summary>
        /// Code added by Zia
        /// Get Country Name by ID
        /// </summary>
        public static string GetCountryNameById(int countryId)
        {
            string countryName = string.Empty;
            using (var db = new ClothEntities())
            {
                var firstOrDefault = db.tbl_Country.FirstOrDefault(x => x.CountryId == countryId);
                if (firstOrDefault != null)
                    countryName = firstOrDefault.CountryName;
            }
            return countryName;
        }

        /// <summary>
        /// Code added by Zia
        /// Get Billing Term Title by ID
        /// </summary>
        public static string GetBillingTermById(int billingTermId)
        {
            string billingTerm = string.Empty;
            using (var db = new ClothEntities())
            {
                var firstOrDefault = db.tbl_BillingTerm.FirstOrDefault(x => x.BTId == billingTermId);
                if (firstOrDefault != null)
                    billingTerm = firstOrDefault.BTTitle;
            }
            return billingTerm;
        }

        /// <summary>
        /// Code added by Zia
        /// Get Store Status by boolean
        /// </summary>
        public static string GetStoreStatusByBool(bool status)
        {
            string storeStatus = status ? "Enabled" : "Disabled";
            return storeStatus;
        }

        /// <summary>
        /// Code added by Zia
        /// Get Payment Status of a store by from date to To date
        /// </summary>
        public static string GetPaymentStatusOfStoreByFromToStoreId(DateTime dtFrom, DateTime dtTo, int storeId)
        {
            string status;
            using (var db = new ClothEntities())
            {
                var data = (from store in db.tbl_Stores
                           join storePayment in db.tbl_StorePayment on store.StoreId equals storePayment.StoreId
                           where (storePayment.StorePaymentFromDate >= DateTime.Now || storePayment.StorePaymentFromDate >= DateTime.Now) && storePayment.StoreId == storeId
                           select new
                           {
                               store.StoreId,
                               store.StoreName,
                               store.StoreDomainName,
                               storePayment.StorePaymentFromDate,
                               storePayment.StorePaymentToDate
                           }).ToList();

                if (data.Count > 0)
                {
                    status = "Paid";
                }
                else
                {
                    status = "Pending";
                }
            }
            return status;
        }

        /// <summary>
        /// Code added by Zia
        /// Get Payment Duration of a store by from date to To date
        /// </summary>
        public static string GetPaymentDurationOfStoreByFromStoreId( int storeId)
        {
            string duration = string.Empty;
            using (var db = new ClothEntities())
            {
                var storeInfo = (from store in db.tbl_Stores
                    join storePayment in db.tbl_NextStorePaymentSchedule on store.StoreId equals storePayment.StoreId
                    join tblBillingTerm in db.tbl_BillingTerm on store.BillingTermId equals tblBillingTerm.BTId
                    where store.StoreId == storeId
                    select new
                    {
                        store.StoreId,
                        store.StoreName,
                        store.BillingTermId,
                        storePayment.ScheduleDate,
                        tblBillingTerm.BTTitle,
                        tblBillingTerm.BTDuration,
                        tblBillingTerm.BTBill
                    }).FirstOrDefault();

                if (storeInfo != null)
                {
                    var fromDate = storeInfo.ScheduleDate;
                    int months = Convert.ToInt32(storeInfo.BTDuration);
                    var toDate = fromDate.AddMonths(months);

                    duration = fromDate.ToString("dd MMMM yyy") +" TO "+ toDate.ToString("dd MMMM yyy");
                }
            }
            return duration;
        }

        /// <summary>
        /// Code added by Zia
        /// Get Payment method id by name
        /// </summary>
        public static int GetPaymentMethodIdByName(string paymentMethod)
        {
            int pId=-1;
            using (var db=new ClothEntities())
            {
                var tblPaymentMethods = db.tbl_PaymentMethods.FirstOrDefault(x => x.PaymentMethodName == paymentMethod);
                if (tblPaymentMethods != null)
                    pId = tblPaymentMethods.PaymentMethodId;
            }
            return pId;
        }
        
    }
}