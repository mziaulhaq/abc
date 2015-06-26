using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceDAL.DataAccessMethods
{
    /// <summary>
    /// This class will provide data information about Categories.
    /// </summary>
    public static class Category   
    {
        private static ClothEntities ReturnEntity()
        {
            return new ClothEntities();
        }
        /// <summary>
        /// This function will provide all the Active Categories for a provided storeid
        /// </summary>
        /// <param name="storeId">Store Id </param>
        /// <returns></returns>
        public static IEnumerable<Categories> GetAllActiveCategories(int storeId)
        {
           using (var clothEntities = ReturnEntity())
            {
                return clothEntities.SP_Categories_GetAllCategories(storeId).ToList();
            }
        }
        /// <summary>
        /// This function will provide all the InActive Categories for a provided storeid
        /// </summary>
        /// <param name="storeId">Store Id </param>
        /// <returns></returns>
        public static IEnumerable<Categories> GetAllInActiveCategories(int storeId)
        {
            using (var clothEntities = ReturnEntity())
            {
                return clothEntities.SP_Categories_GetAllInActiveCategories(storeId).ToList();
            }
        }
        /// <summary>
        /// This function will provide all the Categories for a provided storeid
        /// </summary>
        /// <param name="storeId">Store Id </param>
        /// <returns></returns>
        public static IEnumerable<Categories> GetAllCategories(int storeId)
        {
            using (var clothEntities = ReturnEntity())
            {
                return clothEntities.SP_Categories_GetAllCategories(storeId).ToList();
            }
        }

        /// <summary>
        /// This function will provide all the Child Categories for a provided Category Id with in a provided storeid
        /// </summary>
        /// <param name="storeId">Store Id </param>
        /// <param name="catId"> Category Id</param>
        /// <returns></returns>
        public static IEnumerable<Categories> GetAllCategories(int storeId, int catId)
        {
            using (var clothEntities = ReturnEntity())
            {
                return clothEntities.SP_Categories_GetACategoryChildCategories(storeId,catId).ToList();
            }
        }

        /// <summary>
        /// This function will provide all the Categories on a search value with in a provided storeid
        /// </summary>
        /// <param name="searchVal">Search Value on which the Categories has to be searched</param>
        /// <param name="storeId">Store Id </param>
        /// <returns></returns>
        public static IEnumerable<Categories> GetAllCategories(string searchVal,int storeId)
        {
            using (var clothEntities = ReturnEntity())
            {
                return clothEntities.SP_Categories_SearchWithInCategory(searchVal,storeId).ToList();
            }
        }
    }
    
}
