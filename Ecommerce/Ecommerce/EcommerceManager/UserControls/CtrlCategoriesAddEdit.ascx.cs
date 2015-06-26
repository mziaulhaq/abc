using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EcommerceDAL;
using EcommerceUtilities;

namespace Ecommerce.EcommerceManager.UserControls
{
    public partial class CtrlCategoriesAddEdit : System.Web.UI.UserControl
    {
        private const string AddTitle = "Add Category";
        private const string EditTitle = "Edit Category";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                trOrder.Visible = false;
                BindAllActiveCategories();
                int catId;
                if (Request.QueryString["Id"] != null && Request.QueryString["Edit"] != null && int.TryParse(Request.QueryString["Id"], out catId))
                {
                    trOrder.Visible=true;
                    PopulateFormWithCategories(catId);
                    ddlCategories.Items.Remove(ddlCategories.Items.FindByValue(catId.ToString(CultureInfo.InvariantCulture)));
                }
            }
        }

        private void PopulateFormWithCategories(int catId)
        {
            int storeId = LoggedUser.GetStoreId();
            using (var clothEntities = new ClothEntities())
            {
                var cat = clothEntities.tbl_Categories.FirstOrDefault(ct => ct.CatId == catId && ct.StoreId == storeId);
                if (cat != null)
                {
                    txtCategoryName.Text = cat.CatName;
                    txtCategoryDescription.Text = cat.CatDescription;
                    txtOrder.Text = cat.ShowOrder.ToString();
                    rblIsActive.SelectedValue = EnablingAndDisabling.ReturnOneOrZero(cat.CatIsActive);
                    if (cat.CatParent != null && ddlCategories.Items.FindByValue(cat.CatParent.ToString()) != null)
                        ddlCategories.SelectedValue = cat.CatParent != null ? cat.CatParent.ToString() : "0";
                    ViewState["CatId"] = cat.CatId;
                    BtnAddEdit.Text = EditTitle;
                }

            }


        }
        private void ResetControls()
        {
            txtCategoryDescription.Text = "";
            txtCategoryName.Text = "";
            ddlCategories.SelectedIndex = 0;
            BtnAddEdit.Text = AddTitle;

        }
        protected void AddEditCategory(object sender, EventArgs e)
        {
            int catId;
            int storeId = LoggedUser.GetStoreId();
            if (ViewState["CatId"] != null && BtnAddEdit.Text == EditTitle && int.TryParse(ViewState["CatId"].ToString(), out catId))
            {
                using (var clothEntities = new ClothEntities())
                {
                    var cat = clothEntities.tbl_Categories.FirstOrDefault(ct => ct.CatId == catId && ct.StoreId == storeId);
                    if (cat != null)
                    {
                        var catUpdation = new tbl_CategoriesUpdationRecord()
                        {
                            CatDescription = cat.CatDescription,
                            CatIsActive = cat.CatIsActive,
                            CatName = cat.CatName,
                            CatParent = cat.CatParent,
                            CatId = cat.CatId,
                            CatModifiedDate = cat.CatLastModifiedDate ?? cat.CatCreatedDate,
                            CatModifiedBy = cat.CatLastModifiedBy ?? cat.CatCreatedBy
                        };
                        cat.CatName = txtCategoryName.Text;
                        cat.CatDescription = txtCategoryDescription.Text;
                        cat.CatIsActive = EnablingAndDisabling.ReturnBooleanFromOneOrZero(rblIsActive.SelectedValue);
                        if (ddlCategories.SelectedIndex != 0)
                            cat.CatParent = int.Parse(ddlCategories.SelectedValue);
                        cat.CatLastModifiedBy = LoggedUser.GetUserId();
                        cat.CatLastModifiedDate = DateTime.Now;
                        cat.ShowOrder = Convert.ToInt64(txtOrder.Text);
                        clothEntities.tbl_CategoriesUpdationRecord.Add(catUpdation);

                        if (clothEntities.SaveChanges() > 0)
                        {
                            Utility.ShowMessage(ref lblMessage, true, "Categories Information Has Been Successfully Updated");
                            ViewState["CatId"] = null;
                            ResetControls();
                            BindAllActiveCategories();

                        }
                        else
                        {
                            Utility.ShowMessage(ref lblMessage, false,
                                                "Categories Information Couldn't be Successfully Updated");
                            ViewState["CatId"] = null;
                            ResetControls();

                        }
                    }

                }
            }
            else
            {
                using (var clothEntities = new ClothEntities())
                {
                    // Check if the value already exist.
                    Int64 categoryValue = 0;
                    Int64 showOrderMaxValue =0;
                    if (Int64.TryParse(ddlCategories.SelectedValue, out categoryValue))
                    {
                        var chkCat =
                            clothEntities.tbl_Categories.FirstOrDefault(
                                categ =>
                                categ.CatName.Trim() == txtCategoryName.Text.Trim() && categ.CatParent == categoryValue);

                        if (chkCat != null)
                        {
                            Utility.ShowPopUpMessage("Category Already Exist in this parent Category",
                                                     new List<string>() { "This Category is already added, No need to Add again" },
                                                     this.Page,
                                                     true, null);
                            return;
                        }
                    }

                    showOrderMaxValue = clothEntities.tbl_Categories.Count()+1;
                    var cat = new tbl_Categories
                    {
                        CatName = txtCategoryName.Text,
                        CatDescription = txtCategoryDescription.Text,
                        CatIsActive =EnablingAndDisabling.ReturnBooleanFromOneOrZero(rblIsActive.SelectedValue),
                        CatCreatedBy = LoggedUser.GetUserId(),
                        CatCreatedDate = DateTime.Now,
                        StoreId = LoggedUser.GetStoreId(),
                        ShowOrder = showOrderMaxValue
                    };
                    if (ddlCategories.SelectedIndex != 0)
                    {
                        cat.CatParent = int.Parse(ddlCategories.SelectedValue);
                    }

                    clothEntities.tbl_Categories.Add(cat);
                    if (clothEntities.SaveChanges() > 0)
                    {
                        Utility.ShowMessage(ref lblMessage, true, "Categories Information Has Been Successfully Added");
                        BindAllActiveCategories();
                    }
                    else
                    {
                        Utility.ShowMessage(ref lblMessage, false,"Categories Information Couldn't be Successfully Added");
                    }
                }
            }
        }

        private void BindAllActiveCategories()
        {
            ddlCategories.Items.Clear();
            ddlCategories.DataSource = EcommerceDAL.DataAccessMethods.Category.GetAllCategories(LoggedUser.GetStoreId());
            ddlCategories.DataBind();
            ddlCategories.Items.Insert(0, new ListItem("Select", "Select"));

        }

    }
}