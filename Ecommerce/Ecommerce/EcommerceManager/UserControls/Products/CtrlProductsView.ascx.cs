using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceDAL;
using EcommerceUtilities;

namespace Ecommerce.EcommerceManager.UserControls.Products
{
    public partial class CtrlProductsView : UserControlBase
    {
        private long _pId;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                PopulateBrandsAndSalesTax();
                PopulateProductStatus();
                if (Request.QueryString["PId"] != null && long.TryParse(Request.QueryString["PId"], out _pId))
                {
                    PopulateProduct();
                }
               
                
            }
        }

        private void PopulateProduct()
        {
            using (var clothEntities = new ClothEntities())
            {
                var product =
                    clothEntities.tbl_Products.FirstOrDefault(pd => pd.ProductID == _pId && pd.StoreId == LoggedStoreId);
                if(product!=null)
                {
                    txtInStock.Text = product.ProductInStock.ToString(CultureInfo.InvariantCulture);
                    txtProductDescription.Text = product.ProductDescription;
                    txtPriceDescription.Text = product.ProductPriceDescription;
                    txtProductName.Text = product.ProductName;
                    txtSale.Text = product.ProductSale.ToString(CultureInfo.InvariantCulture);
                    txtUnitPrice.Text = product.ProductUnitPrice.ToString(CultureInfo.InvariantCulture);
                    ddlBrands.SelectedIndex =
                        ddlBrands.Items.IndexOf(ddlBrands.Items.FindByValue(product.ProductBrandId.ToString()));
                    ddlSalesTax.SelectedIndex =
                        ddlSalesTax.Items.IndexOf(ddlSalesTax.Items.FindByValue(product.SalesTaxId.ToString()));
                    rblIsFeatured.SelectedValue = EnablingAndDisabling.ReturnOneOrZero(Convert.ToBoolean(product.ProductIsFeatured));
                    rblIsActive.SelectedIndex =
                        rblIsActive.Items.IndexOf(rblIsActive.Items.FindByValue(product.ProductStatus.ToString()));
                    txtPurchasedPrice.Text = product.PurchasePrice.ToString();

                }
            }
        }
        private void PopulateBrandsAndSalesTax()
        {
            using (var clothEntities = new ClothEntities())
            {
                var brands = clothEntities.tbl_Brands.Where(brand => brand.StoreId == LoggedStoreId && brand.IsActive).ToList();
                ddlBrands.DataSource = brands;
                ddlBrands.DataBind();
                ddlBrands.Items.Insert(0,new ListItem("Select","Select"));
                var salesTax = clothEntities.tbl_SalesTaxRates.Where(sales => sales.StoreId == LoggedStoreId || sales.StoreId==null).ToList();
                ddlSalesTax.DataSource = salesTax;
                ddlSalesTax.DataBind();
                ddlSalesTax.Items.Insert(0, new ListItem("Select", "Select"));
            }

        }
        private void PopulateProductStatus()
        {
            rblIsActive.DataSource = ProductStatus.ListOfProductStatus();
            rblIsActive.DataBind();
        }
       
    }
}

