using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using EcommerceDAL;
using Ecommerce.App_Start;

namespace Ecommerce
{
    public partial class IndexMaster : FrontMaster
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateBannerImages();
                LoadCategories();
            }
        }

        private void PopulateBannerImages()
        {
           using(var clothEntities = new ClothEntities())
           {
               var banners = clothEntities.tbl_HomePageBanners.Take(10).Where(ban => ban.IsActive == true).ToList();
               lstcarousel.DataSource = banners;
               lstcarousel.DataBind();
           }
        }
        public string BindBannerImages(string img)
        {
            return ConfigurationManager.AppSettings["HomeBannerImagePathUrl"] + img;
        }

        private void LoadCategories()
        {
            using (var clothEntities = new ClothEntities())
            {

                var tblCategories =
                    clothEntities.tbl_Categories.Where(categories => categories.StoreId == StoreId && categories.CatIsActive && categories.CatParent == null).OrderBy(y => y.ShowOrder).ToList();
                lvCategories.DataSource = tblCategories;
                lvCategories.DataBind();

            }
        }
    }
}