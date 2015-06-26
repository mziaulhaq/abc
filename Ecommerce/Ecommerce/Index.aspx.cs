using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceDAL;
using EcommerceUtilities;

namespace Ecommerce
{
    public partial class Index : FrontBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["Logout"] != null && Request.QueryString["Logout"] == "true")
                    LoggedCustomer.ReleaseSession();
                LoadTopBrands();
                //LoadCategories();
                //LoadMainAndSubCategories();
                LoadLatestProducts();
                LoadFeaturedProducts();
            }
        }

        //private void LoadMainAndSubCategories()
        //{
        //    using (var db= new ClothEntities())
        //    {
        //        HtmlGenericControl main = UList("Menuid", "menu");
        //        var tblCategories =
        //            db.tbl_Categories.Where(categories => categories.StoreId == StoreId && categories.CatIsActive && categories.CatParent == null).OrderBy(y => y.ShowOrder).ToList();
        //        if (tblCategories.Count>0)
        //        {
        //            foreach (var item in tblCategories)
        //            {
        //                var subCatList = db.tbl_Categories.Where(x => x.CatParent == item.CatId).ToList();
        //                if (subCatList.Count > 0)
        //                {
        //                    HtmlGenericControl subMenu = LiList(item.CatName,item.CatId.ToString(),"");
        //                    var ul = new HtmlGenericControl("ul");
        //                    foreach (var subCat in subCatList)
        //                    {
        //                        ul.Controls.Add(LiList(subCat.CatName, subCat.CatId.ToString(),""));
        //                    }
        //                    subMenu.Controls.Add(ul);
        //                    main.Controls.Add(subMenu);    
        //                }
        //                else
        //                {
        //                    main.Controls.Add(LiList(item.CatName,item.CatId.ToString(),""));
        //                }
        //            }
        //            pnlCategories.Controls.Add(main);
        //        }
        //    }
        //}

        private void LoadFeaturedProducts()
        {
            using (var clothEntities = new ClothEntities())
            {

                var data = (from prod in clothEntities.tbl_Products
                            join brand in clothEntities.tbl_Brands on prod.ProductBrandId equals brand.BrandId
                            where
                                prod.StoreId == StoreId && prod.ProductStatus != 0 && prod.ProductIsFeatured == true &&
                                prod.ProductImage != string.Empty
                            select new
                            {
                                prod.ProductName,
                                prod.ProductID,
                                prod.ProductImage,
                                prod.ProductUnitPrice,
                                prod.ProductInsertedDate,
                                brand.BrandName
                            }).OrderByDescending(product => product.ProductInsertedDate).Take(8).ToList();

                lvFeaturedProducts.DataSource = data;
                lvFeaturedProducts.DataBind();
            }
        }


        private void LoadLatestProducts()
        {
            using (var clothEntities = new ClothEntities())
            {
                var data = (from prod in clothEntities.tbl_Products
                            join brand in clothEntities.tbl_Brands on prod.ProductBrandId equals brand.BrandId
                            where
                                prod.StoreId == StoreId && prod.ProductStatus != 0 && prod.ProductIsFeatured == false &&
                                prod.ProductImage != string.Empty
                            select new
                            {
                                prod.ProductName,
                                prod.ProductID,
                                prod.ProductImage,
                                prod.ProductUnitPrice,
                                prod.ProductInsertedDate,
                                brand.BrandName
                            }).OrderByDescending(product => product.ProductInsertedDate).Take(20).ToList();

                lvLatestProducts.DataSource = data;
                lvLatestProducts.DataBind();
            }
        }

        private void LoadTopBrands()
        {
            using (var clothEntities = new ClothEntities())
            {
                var tblBrands =
                     clothEntities.tbl_Brands.Where(brand => brand.StoreId == StoreId && brand.BrandImage != string.Empty && brand.IsActive).ToList();
                lvBrands.DataSource = tblBrands;
                lvBrands.DataBind();

            }
        }

        protected void LvFeaturedProductsItemCommand(object sender, ListViewCommandEventArgs e)
        {

            if (e.CommandName == "ButtonClicked")
            {
                string id = e.CommandArgument.ToString();

            }

        }

    }
}