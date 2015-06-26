using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EcommerceUtilities
{
    /// <summary>
    /// This Class will handle Customers (Users) along with the Cart 
    /// </summary>
    public class LoggedCustomer : Cart
    {
        private const string SessionString = "LoggedCustomer";
        public long Id;
        public string Name;
        public string Email;
        public int StoreId;

        /// <summary>
        /// Checks that the current session is logged in or not
        /// </summary>
        /// <returns></returns>
        public static bool IsUserLogged()
        {
            return HttpContext.Current.Session[SessionString] != null;
        }

        /// <summary>
        /// Creates Session for Customer User
        /// </summary>
        /// <param name="loggedCustomer">Instance of Logged User that has to be put in Session </param>
        /// <returns></returns>
        public static bool CreateCustomerSession(LoggedCustomer loggedCustomer)
        {
            try
            {
                if (loggedCustomer == null)
                {
                    return false;
                }
                HttpContext.Current.Session[SessionString] = loggedCustomer;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Get the Instance of Logged User that is in the session
        /// </summary>
        /// <returns></returns>
        public static LoggedCustomer GetLoggedCustomer()
        {
            if(HttpContext.Current.Session[SessionString]!=null)
            {
                return HttpContext.Current.Session[SessionString] as LoggedCustomer;
            }
            return null;
        }

        /// <summary>
        /// Adds a Product in the Cart with the total count of order of that product.
        /// </summary>
        /// <param name="productId">Product Id of the Product</param>
        /// <param name="productCount">Order Count of the product</param>
        /// <returns></returns>
        public new static bool AddToCart(long productId,int productCount)
        {
            try
            {
                if (productCount == 0)
                    return false;
                Cart.AddToCart(productId, productCount);
                    return true;
                
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        /// <summary>
        /// Getting all the cart items of a Logged Customer
        /// </summary>
        /// <returns></returns>
        public static Dictionary<long,int> GetCartItems()
        {
            var retCartItems = new Dictionary<long, int>();
            try
            {

                if (!IsAnnonymousCartItemExist && !IsUserLogged())
                    return retCartItems;
                if(IsAnnonymousCartItemExist)
                {
                    foreach (var cartItem in AnnonymousCartItems)
                    {
                        retCartItems.Add(cartItem.Key, cartItem.Value);
                    }
                }
               
            }
            catch (Exception)
            {
                return null;
            }
            return retCartItems;
        }

        /// <summary>
        /// Release the logged Customer
        /// </summary>
        public static void ReleaseSession()
        {
            HttpContext.Current.Session[SessionString] = null;
        }

        public static bool IsProductExist(long productId)
        {
            var allCartItems = GetCartItems();
            if (allCartItems == null || allCartItems.Count == 0)
                return false;
            return allCartItems.ContainsKey(productId);
        }

        /// <summary>
        /// This function will check if a product item exist in the cart or not. If it exist then it will set count otherwise count will be set to 0
        /// </summary>
        /// <param name="productId">Product Id that has to be checked in the Cart Items</param>
        /// <param name="count">Count is out, If product Id exist in the cart items then this function will set the count variable otherwise it will set it to zero </param>
        /// <returns></returns>
        public static bool IsProductExistPlusProductQuantity(long productId,out int count)
        {
            var allCartItems = GetCartItems();
            if (allCartItems == null || allCartItems.Count == 0)
            {
                count = 0;
                return false;
            }
            if(allCartItems.ContainsKey(productId))
            {
                count = allCartItems[productId];
                return true;
            }
            count = 0;
            return false;
        }

        public static void DeleteItemFromCart(long productId)
        {
            try
            {
                if (productId == 0)
                    return;
                Cart.DeletFromCart(productId);
                    return;
               
            }
            catch (Exception)
            {
                return;
            }
            
        }

        public static void RemoveAllCartItems()
        {
            if(IsAnnonymousCartItemExist)
                ReleaseAnnonymousCart();
        }
    }
    
}
