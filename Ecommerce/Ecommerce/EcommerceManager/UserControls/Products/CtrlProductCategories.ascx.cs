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
    public partial class CtrlProductCategories : UserControlBase
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
                _pId=Convert.ToInt64(Session["PId"].ToString());
            }
            if(!IsPostBack)
            {
                PopulateCategories();
                
                if ((Session["PId"]!=null && Request.QueryString["Edit"]!=null))
                {
                    PopulateProductCategorisForEdit();
                }
            }
        }

        private void PopulateCategories()
        {
           using(var clothEntities = new ClothEntities())
           {
               var categories = clothEntities.GetAllActiveCategoriesNotBindToAProduct(LoggedStoreId, _pId);
               //var categories = clothEntities.tbl_Categories.Where(x => x.CatParent == null).ToList();
               ddlCategories.DataSource = categories;
               ddlCategories.DataBind();
               ddlCategories.Items.Insert(0,new ListItem("Select","Select"));
           }
        }

        private void PopulateProductCategorisForEdit()
        {
            using (var clothEntities = new ClothEntities())
            {
                var producttoCategories = clothEntities.SP_Product_GetAProductCategories(LoggedStoreId, _pId);
                gdvProductToCategories.DataSource = producttoCategories;
                gdvProductToCategories.DataBind();
            }
        }

        protected void BtnAddEditCategoryClicked(object sender, EventArgs e)
        {
            if(Session["PId"]!=null && Session["PName"]!=null)
            {
                using (var clothEntities = new ClothEntities())
                {
                    var pc = new tbl_ProductCategories()
                                 {
                                     PCCatId = Convert.ToInt32(ddlCategories.SelectedValue),
                                     PCProductId = Convert.ToInt64(Session["PId"].ToString())
                                 };
                    clothEntities.tbl_ProductCategories.Add(pc);
                    if(clothEntities.SaveChanges() > 0)
                    {
                        ddlCategories.SelectedIndex = 0;
                        PopulateProductCategorisForEdit();
                        PopulateCategories();
                    }
                }
            }
        }

        protected void GdvProductCateogyDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var dataKey = gdvProductToCategories.DataKeys[e.RowIndex];
            if (dataKey != null)
            {
                long pcProductId = Convert.ToInt64(dataKey.Value);
                using (var clothEntities = new ClothEntities())
                {
                    var productCategories = clothEntities.tbl_ProductCategories.FirstOrDefault(pc=> pc.PCId==pcProductId);
                    if(productCategories!=null)
                    {
                        clothEntities.tbl_ProductCategories.Remove(productCategories);
                        if(clothEntities.SaveChanges() > 0)
                        {
                           PopulateProductCategorisForEdit();
                            PopulateCategories();
                        }
                    }
                }
            }
        }

        protected void DdlMainCategorySelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}