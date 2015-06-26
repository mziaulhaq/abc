using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EcommerceUtilities
{
    public class Cart
    {
        protected static Dictionary<long, int> AnnonymousCartItems
        {
            get { return HttpContext.Current.Session[SessionCart]!=null ? HttpContext.Current.Session[SessionCart] as Dictionary<long, int>:null; }
        }
        protected const string SessionCart = "Cart";
        protected static bool AddToCart(long productId, int count)
        {
            try
            {
                if (IsAnnonymousCartItemExist)
                {
                    var cartItems = AnnonymousCartItems;
                    if (cartItems != null)
                    {
                        if (!cartItems.Keys.Contains(productId))
                        {
                            cartItems.Add(productId, count);
                            CartItemsToSessin(cartItems);
                        }
                        else
                        {
                            cartItems[productId] = cartItems[productId] + count;
                            CartItemsToSessin(cartItems);
                        }
                    }
                    else
                    {
                        AddFirstCart(productId, count);
                    }
                }
                else
                {
                    AddFirstCart(productId, count);
                }
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        protected static bool IsAnnonymousCartItemExist
        {
            get { return HttpContext.Current.Session[SessionCart] != null; }
        }
        private static void AddFirstCart(long productId, int count)
        {
            var cartItem = new Dictionary<long, int> { { productId, count } };
            CartItemsToSessin(cartItem);
        }
        private static void CartItemsToSessin(Dictionary<long, int> cartItems)
        {
            HttpContext.Current.Session[SessionCart] = cartItems;
        }
        protected static void ReleaseAnnonymousCart()
        {
            HttpContext.Current.Session[SessionCart] = null;
        }
        protected static void DeletFromCart(long productId)
        {
            if(IsAnnonymousCartItemExist)
            {
                var tempCarts = AnnonymousCartItems;
                if (tempCarts != null && tempCarts.Count != 0 && tempCarts.ContainsKey(productId))
                {
                    tempCarts.Remove(productId);
                    CartItemsToSessin(tempCarts);
                }
            }
        }
        
    }
}
