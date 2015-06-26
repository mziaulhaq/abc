using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using EcommerceUtilities;
using EcommerceDAL;
using EcommerceDAL.DataAccessMethods;


namespace Ecommerce.App_Start
{
    public class UserControlBase : System.Web.UI.UserControl,IReadOnlySessionState
    {
        public readonly int LoggedUserId =  1;//LoggedUser.GetUserId();
        public readonly int LoggedStoreId = 1;//LoggedUser.GetStoreId();
        public readonly string ApplicationUrl;
        public UserControlBase()
        {
            
            try
            {
                ApplicationUrl = ConfigurationManager.AppSettings["ApplicationUrl"];
            }
            catch (Exception)
            {

            }
        }

       public string GridViewRowNumberApplication(int rowIndex, int pageIndex, int pageSize)
        {
            if (pageIndex == 0)
                return rowIndex.ToString();
           
                return ((pageIndex*pageSize) + rowIndex).ToString();
            
        }
        public string HomeEditBannerLink(string id,string edit=null)
        {
          if(edit==null)
            return string.Format("{0}/EcommerceManager/AddHomeBanner.aspx?bannerId={1}", ApplicationUrl,id);

          return string.Format("{0}/EcommerceManager/AddHomeBanner.aspx?bannerId={1}&Edit=Edit", ApplicationUrl, id);
          
        }
        public string ProductEditLink(string id)
        {
            return string.Format("{0}/EcommerceManager/ProductsAddEdit.aspx?PId={1}&Edit=Edit", ApplicationUrl, id);
        }
        public string ProductViewLink(string id)
        {
            return string.Format("{0}/EcommerceManager/ProductView.aspx?PId={1}&Edit=Edit", ApplicationUrl, id);
        }
        
    }
}