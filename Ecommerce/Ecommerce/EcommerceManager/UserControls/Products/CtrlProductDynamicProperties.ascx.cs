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
    public partial class CtrlProductDynamicProperties : UserControlBase
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
                    PopulateDynamicCategoriesForEdit();
                }

            }
        }

        private void PopulateDynamicCategoriesForEdit()
        {
            using (var clothEntities = new ClothEntities())
            {
                var allDynamicCategoriesOfProduct = clothEntities.GetAllDynamicCategoriesofProduct(LoggedStoreId, _pId);
                GdvDynamicCategories.DataSource = allDynamicCategoriesOfProduct.ToList();
                GdvDynamicCategories.DataBind();
            }

        }

        private void PopulateLists()
        {
            using (var clothEntities=new ClothEntities())
            {
                var dynamicCategories =
                    clothEntities.GetDistinctDynamicCatNotBindToProduct(LoggedStoreId, _pId).ToList();
              
                ddlDynamicCat.DataSource = dynamicCategories;
                ddlDynamicCat.DataBind();
                ddlDynamicCat.Items.Insert(0,new ListItem("Select","Select"));
            }
          
        }

       
        protected void GdvDynamicCategoriesRowEditing(object sender, GridViewEditEventArgs e)
        {
            GdvDynamicCategories.EditIndex = e.NewEditIndex;
            PopulateDynamicCategoriesForEdit();
        }

        protected void GdvDynamicCategoriesRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            var rowIndex = GdvDynamicCategories.EditIndex;
            using (var clothEntities = new ClothEntities())
            {
                var dataKey = GdvDynamicCategories.DataKeys[rowIndex];
                var txtValue = (TextBox)GdvDynamicCategories.Rows[e.RowIndex].FindControl("txtPdCValue");
                if (dataKey != null)
                {
                    var pdcId = Convert.ToInt64(dataKey.Value);
                    var dynamicCategoryRecord =
                        clothEntities.tbl_ProductDynamicAttributes.FirstOrDefault(pd => pd.PDAId == pdcId);
                    if(dynamicCategoryRecord!=null)
                    {
                        dynamicCategoryRecord.PDCValue = txtValue.Text;
                        if(clothEntities.SaveChanges()>0)
                        {
                            GdvDynamicCategories.EditIndex = -1;
                            PopulateDynamicCategoriesForEdit();
                            PopulateLists();
                        }
                        else
                        {
                            const string javaScript = "<script language='JavaScript'>alert('Error Occured while updating record, try again later');</script>";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, javaScript, false);
                        }
                    }
                }
            }
        }

        protected void GdvCancelEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GdvDynamicCategories.EditIndex = -1;
            PopulateDynamicCategoriesForEdit();
        }

        protected void GdvDynamicCategoriesRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var dataKey = GdvDynamicCategories.DataKeys[e.RowIndex];
            if (dataKey != null)
            {
                var dataValue = Convert.ToInt64(dataKey.Value);
                using (var clothEntities = new ClothEntities())
                {
                    var dynamicCategoryRecord =
                        clothEntities.tbl_ProductDynamicAttributes.FirstOrDefault(pd => pd.PDAId == dataValue);
                    if (dynamicCategoryRecord != null)
                    {
                        clothEntities.tbl_ProductDynamicAttributes.Remove(dynamicCategoryRecord);
                        if (clothEntities.SaveChanges() > 0)
                        {
                            PopulateDynamicCategoriesForEdit();
                            PopulateLists();
                        }
                        else
                        {
                            const string javaScript = "<script language='JavaScript'>alert('Error Occured while deleting record, try again later');</script>";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, javaScript, false);
                        }
                    }
                }
            }
        }

        protected void BtnAddDynamicProperties_Click(object sender, EventArgs e)
        {
            bool status = false;
            if(txtDynamicCategory.Text !=string.Empty && ddlDynamicCat.SelectedIndex!=0)
            {
                const string javaScript = "<script language='JavaScript'>alert('Either Select from the Category List or Enter Text in the Category');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, javaScript, false);
                return;
            }
            else if((txtDynamicCategory.Text!=string.Empty || ddlDynamicCat.SelectedIndex!=0) && txtDynamicCatValue.Text!=string.Empty)
            {
                using (var clothEntities = new ClothEntities())
                {
                    if(ddlDynamicCat.SelectedIndex!=0)
                    {
                        var dynamicAttributes = new tbl_ProductDynamicAttributes()
                                                    {
                                                        PDCId = Convert.ToInt64(ddlDynamicCat.SelectedValue),
                                                        PDCValue = txtDynamicCatValue.Text,
                                                        ProductID = _pId
                                                    };
                        clothEntities.tbl_ProductDynamicAttributes.Add(dynamicAttributes);
                        if(clothEntities.SaveChanges()>0)
                        {
                            status = true;
                        }

                    }
                    else if(txtDynamicCategory.Text!=string.Empty)
                    {
                        var checkNewCategory =
                            clothEntities.tbl_ProductDynamicCategories.FirstOrDefault(
                                dc => dc.PCDName == txtDynamicCategory.Text);
                        if (checkNewCategory == null)
                        {
                            var tblDynamicCategories = new tbl_ProductDynamicCategories()
                                                           {
                                                               PCDName = txtDynamicCategory.Text,
                                                               StoreId = LoggedStoreId
                                                           };
                            clothEntities.tbl_ProductDynamicCategories.Add(tblDynamicCategories);
                            if (clothEntities.SaveChanges() > 0)
                            {
                                var dynamicAttributes = new tbl_ProductDynamicAttributes()
                                                            {
                                                                PDCId = tblDynamicCategories.PDCId,
                                                                PDCValue = txtDynamicCatValue.Text,
                                                                ProductID = _pId
                                                            };
                                clothEntities.tbl_ProductDynamicAttributes.Add(dynamicAttributes);
                                if (clothEntities.SaveChanges() > 0)
                                {
                                    status = true;
                                }
                            }
                        }
                        else
                        {
                            var dynamicAttributes = new tbl_ProductDynamicAttributes()
                            {
                                PDCId = checkNewCategory.PDCId,
                                PDCValue = txtDynamicCatValue.Text,
                                ProductID = _pId
                            };
                            clothEntities.tbl_ProductDynamicAttributes.Add(dynamicAttributes);
                            if (clothEntities.SaveChanges() > 0)
                            {
                                status = true;
                            }
                        }

                    }
                }
            }
            else
            {
                const string javaScript = "<script language='JavaScript'>alert('Please fill the form correctly and submit');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), UniqueID, javaScript, false);
            }
            if(status)
            {
                PopulateDynamicCategoriesForEdit();
                PopulateLists();
            }
        }
    }
}