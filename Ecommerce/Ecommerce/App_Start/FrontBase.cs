using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using EcommerceDAL;
using EcommerceUtilities;

namespace Ecommerce.App_Start
{
    public class FrontBase : Page
    {
        private static readonly Regex ViewStateRegex = new Regex("<div class=\"aspNetHidden\">*</div>", RegexOptions.Multiline | RegexOptions.Compiled);
        private static readonly Regex ScriptRegex = new Regex("<script.*></script>", RegexOptions.Multiline | RegexOptions.Compiled);
        private static readonly Regex EndFormRegex = new Regex(@"</form>", RegexOptions.Multiline | RegexOptions.Compiled);
        public int StoreId;
        public FrontBase()
        {
            StoreId = int.Parse(ConfigurationManager.AppSettings["StoreId"].ToString(CultureInfo.InvariantCulture));
        }
        protected override void Render(HtmlTextWriter writer)
        {
            var stringWriter = new System.IO.StringWriter();
            var htmlWriter = new HtmlTextWriter(stringWriter);
            base.Render(htmlWriter);
            string html = stringWriter.ToString();
            int index = html.IndexOf("<div class=\"aspNetHidden\"", System.StringComparison.Ordinal);
            if (index > 0)
            {
                int lastIndex = html.IndexOf("</div>", index, System.StringComparison.Ordinal) + 6;
                string removeString = html.Substring(index, lastIndex - index);
                html = html.Replace(removeString, string.Empty);
                int formIndex = html.IndexOf("</form>", System.StringComparison.Ordinal);
                html = html.Insert(formIndex, removeString);
            }
            writer.Write(html);
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
                return  GetProductImage(productId);
            }
            else if (image.ToString() == string.Empty)
            {
                return GetProductImage(productId);
            }

            return ConfigurationManager.AppSettings["ProductImagePathUrl"] + image;
        }
        private string GetProductImage(long productId)
        {
            using (var clothEntities = new ClothEntities())
            {
                var clothEntity = clothEntities.tbl_ProductImages.FirstOrDefault(prod => prod.ProductId == productId);
                if (clothEntity != null)
                    return ConfigurationManager.AppSettings["ProductImagePathUrl"] + clothEntity.ImagePathThumbNail;
                else return "~/Images/NoImage.png";
            }
        }
        public string BrandsUrlWithBrandId(string id)
        {
            return "ProductInBrands.aspx?BrandId=" + id;
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
           Messages.ShowPopUpMessage(this.Page);
        }

        public HtmlGenericControl UList(string id, string cssClass)
        {
            var ul = new HtmlGenericControl("ul") { ID = id };
            
            ul.Attributes.Add("class", cssClass+ " CategoryLists");
            return ul;
        }
        public HtmlGenericControl LiList(string innerHtml, string rel, string url)
        {
            url = "ProductsInCategories.aspx?CatId="+rel;
            var li = new HtmlGenericControl("li");
            li.Attributes.Add("rel", rel);
            li.InnerHtml = "<a href=" + string.Format("{0}", url) + ">" + innerHtml + "</a>";
            return li;
        }
    }
}