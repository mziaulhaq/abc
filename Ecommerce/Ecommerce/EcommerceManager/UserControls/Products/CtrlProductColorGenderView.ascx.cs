using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceDAL;

namespace Ecommerce.EcommerceManager.UserControls.Products
{
    public partial class CtrlProductColorGenderView : UserControlBase
    {
        private long _pId;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(!IsPostBack)
            {
                if (Request.QueryString["PId"] != null && long.TryParse(Request.QueryString["PId"], out _pId))
                 PopulateGenderAndColors();
         
               
            }
        }

        private void PopulateGenderAndColors(int? whichOne=null) // 1 to populate Color and 2 to populate Gender and null to populate both
        {
            using (var clothEntities = new ClothEntities())
            {
                var colors = from prod in clothEntities.tbl_Products
                             join col in clothEntities.tbl_ProductsColors on prod.ProductID equals col.ProductId
                             where prod.ProductID == _pId && prod.StoreId == LoggedStoreId
                             join cols in clothEntities.tbl_Colors on col.ColorId equals cols.ColorId
                             select new
                                        {
                                        ColName = cols.ColorName,
                                        ProdName = prod.ProductName,
                                        ColId = col.ProductColorId
                                        };
                var bindedgGender = from prod in clothEntities.tbl_Products
                                    join genders in clothEntities.tbl_ProductsGender on prod.ProductID equals
                                        genders.PGProductId
                                        where prod.ProductID==_pId && prod.StoreId==LoggedStoreId
                                    join gender in clothEntities.tbl_GenderCategories on genders.PGGenderId equals
                                        gender.GenderCatId
                                    select new
                                    {
                                        GenderName = gender.GenderCatName,
                                        ProdName = prod.ProductName,
                                        GenderId = genders.PGId
                                    };

                var bindedMetarials = clothEntities.tbl_ProductMetarialInfo.Where(x => x.productId == _pId && x.tbl_Products.StoreId==LoggedStoreId).ToList();
                var dataToBind = bindedMetarials.Select(x => new
                {
                    x.tbl_Products.ProductName,
                    x.tbl_Metarial.meterialName,
                    x.metarialId
                });

                if (!whichOne.HasValue)
                {
                    gdvColors.DataSource = colors.ToList();
                    gdvColors.DataBind();
                    gdvGender.DataSource = bindedgGender.ToList();
                    gdvGender.DataBind();
                    gdvMaterials.DataSource = dataToBind.ToList();
                    gdvMaterials.DataBind();
                }
                else if(whichOne==1)
                {
                    gdvColors.DataSource = colors.ToList();
                    gdvColors.DataBind();
                }
                else if(whichOne==2)
                {
                    gdvGender.DataSource = bindedgGender.ToList();
                    gdvGender.DataBind();
                }
                else if (whichOne == 3)
                {
                    gdvMaterials.DataSource = dataToBind.ToList();
                    gdvMaterials.DataBind();
                }
            }
        }
    }
}