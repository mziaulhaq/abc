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
    public partial class CtrlProductColorGender : UserControlBase
    {
        private long _pId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PId"] == null)
            {
                this.Page.GetType().InvokeMember("ChangeWizardStep", System.Reflection.BindingFlags.InvokeMethod, null,
                                 this.Page, new object[] { "First" });
            }
            if (Session["PId"] != null)
            {
                lblProductName.InnerText = Session["PName"].ToString();
                _pId = Convert.ToInt64(Session["PId"].ToString());
            }
            if (!IsPostBack)
            {
                PopulateLists();
                if ((Session["PId"] != null && Request.QueryString["Edit"] != null))
                {
                    PopulateGenderAndColorsForEdit();
                }
            }
        }


        private void PopulateGenderAndColorsForEdit(int? whichOne = null) // 1 to populate Color and 2 to populate Gender and null to populate both
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
                                    where prod.ProductID == _pId && prod.StoreId == LoggedStoreId
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
                    }).ToList();

                if (!whichOne.HasValue)
                {
                    gdvColors.DataSource = colors.ToList();
                    gdvColors.DataBind();
                    gdvGender.DataSource = bindedgGender.ToList();
                    gdvGender.DataBind();
                }
                else if (whichOne == 1)
                {
                    gdvColors.DataSource = colors.ToList();
                    gdvColors.DataBind();
                }
                else if (whichOne == 2)
                {
                    gdvGender.DataSource = bindedgGender.ToList();
                    gdvGender.DataBind();
                }
                else if (whichOne == 3)
                {
                    GdvMetarial.DataSource = dataToBind.ToList();
                    GdvMetarial.DataBind();
                }

            }
        }

        private void PopulateLists(int? whichOne = null)
        {
            using (var clothEntities = new ClothEntities())
            {

                var allColorCategories = clothEntities.GetAllColorsNotBindToProduct(LoggedStoreId, _pId);
                var allGenderCategories = clothEntities.GetAllGenderNotBindToProduct(LoggedStoreId, _pId);
                var metarialList = clothEntities.SP_Materials_GetAllMaterialsNotBindToProduct(_pId);
                if (!whichOne.HasValue)
                {
                    ddlColors.DataSource = allColorCategories.ToList();
                    ddlColors.DataBind();
                    ddlColors.Items.Insert(0, new ListItem("Select", "Select"));
                    ddlGender.DataSource = allGenderCategories.ToList();
                    ddlGender.DataBind();
                    ddlGender.Items.Insert(0, new ListItem("Select", "Select"));
                    ddlMetarial.DataSource = metarialList.ToList();
                    ddlMetarial.DataBind();
                    ddlMetarial.Items.Insert(0, new ListItem("Select", "Select"));
                }
                else if (whichOne == 1)
                {
                    ddlColors.DataSource = allColorCategories.ToList();
                    ddlColors.DataBind();
                    ddlColors.Items.Insert(0, new ListItem("Select", "Select"));
                }
                else if (whichOne == 2)
                {
                    ddlGender.DataSource = allGenderCategories.ToList();
                    ddlGender.DataBind();
                    ddlGender.Items.Insert(0, new ListItem("Select", "Select"));
                }
                else if (whichOne == 3)
                {
                    ddlMetarial.DataSource = metarialList.ToList();
                    ddlMetarial.DataBind();
                    ddlMetarial.Items.Insert(0, new ListItem("Select", "Select"));
                }
            }
        }

        protected void BtnProductColors_Click(object sender, EventArgs e)
        {
            if (ddlColors.SelectedIndex != 0)
            {

                using (var clothEntities = new ClothEntities())
                {
                    var productToColors = new tbl_ProductsColors()
                                              {
                                                  ColorId = Convert.ToInt32(ddlColors.SelectedValue),
                                                  ProductId = _pId
                                              };
                    clothEntities.tbl_ProductsColors.Add(productToColors);
                    if (clothEntities.SaveChanges() > 0)
                    {
                        PopulateGenderAndColorsForEdit(1);
                        PopulateLists(1);
                    }
                }
            }
            else
            {
                const string javaScript = "<script language='JavaScript'>alert('Please Select Color from the list');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, javaScript, false);

            }
        }

        protected void BtnGenderClicked(object sender, EventArgs e)
        {
            if (ddlGender.SelectedIndex != 0)
            {

                using (var clothEntities = new ClothEntities())
                {
                    var productToGenders = new tbl_ProductsGender()
                    {
                        PGGenderId = Convert.ToInt32(ddlGender.SelectedValue),
                        PGProductId = _pId
                    };
                    clothEntities.tbl_ProductsGender.Add(productToGenders);
                    if (clothEntities.SaveChanges() > 0)
                    {
                        PopulateGenderAndColorsForEdit(2);
                        PopulateLists(2);
                    }
                }
            }
            else
            {
                const string javaScript = "<script language='JavaScript'>alert('Please Select Gender from the list');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, javaScript, false);

            }
        }


        protected void GdvGenderDeleted(object sender, GridViewDeleteEventArgs e)
        {
            var dataKey = gdvGender.DataKeys[e.RowIndex];
            if (dataKey != null)
            {
                long genderId = Convert.ToInt64(dataKey.Value);
                using (var clothEntities = new ClothEntities())
                {
                    var genderCategories = clothEntities.tbl_ProductsGender.FirstOrDefault(pc => pc.PGId == genderId);
                    if (genderCategories != null)
                    {
                        clothEntities.tbl_ProductsGender.Remove(genderCategories);
                        if (clothEntities.SaveChanges() > 0)
                        {
                            PopulateGenderAndColorsForEdit(2);
                            PopulateLists(2);

                        }
                    }
                }
            }
        }

        protected void GdvColorsDeleted(object sender, GridViewDeleteEventArgs e)
        {
            var dataKey = gdvColors.DataKeys[e.RowIndex];
            if (dataKey != null)
            {
                long colorId = Convert.ToInt64(dataKey.Value);
                using (var clothEntities = new ClothEntities())
                {
                    var colorCategories = clothEntities.tbl_ProductsColors.FirstOrDefault(pc => pc.ProductColorId == colorId);
                    if (colorCategories != null)
                    {
                        clothEntities.tbl_ProductsColors.Remove(colorCategories);
                        if (clothEntities.SaveChanges() > 0)
                        {
                            PopulateGenderAndColorsForEdit(1);
                            PopulateLists(1);

                        }
                    }
                }
            }

        }

        protected void BtnMetarialClicked(object sender, EventArgs e)
        {
            if (ddlMetarial.SelectedIndex != 0)
            {

                using (var clothEntities = new ClothEntities())
                {
                    var productMetarials = new tbl_ProductMetarialInfo();
                    productMetarials.productId = _pId;
                    productMetarials.metarialId = Convert.ToInt32(ddlMetarial.SelectedValue);

                    clothEntities.tbl_ProductMetarialInfo.Add(productMetarials);
                    if (clothEntities.SaveChanges() > 0)
                    {
                        PopulateGenderAndColorsForEdit(3);
                        PopulateLists(3);
                    }
                }
            }
            else
            {
                const string javaScript = "<script language='JavaScript'>alert('Please Select Metarial from the list');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, javaScript, false);

            }
        }

        protected void GdvMetarialDeleted(object sender, GridViewDeleteEventArgs e)
        {
            var dataKey = GdvMetarial.DataKeys[e.RowIndex];
            if (dataKey != null)
            {
                long metarialId = Convert.ToInt64(dataKey.Value);
                using (var clothEntities = new ClothEntities())
                {
                    var metarialInfo = clothEntities.tbl_ProductMetarialInfo.FirstOrDefault(pc => pc.metarialId == metarialId);
                    if (metarialInfo != null)
                    {
                        clothEntities.tbl_ProductMetarialInfo.Remove(metarialInfo);
                        if (clothEntities.SaveChanges() > 0)
                        {
                            PopulateGenderAndColorsForEdit(3);
                            PopulateLists(3);
                        }
                    }
                }
            }
        }
    }
}