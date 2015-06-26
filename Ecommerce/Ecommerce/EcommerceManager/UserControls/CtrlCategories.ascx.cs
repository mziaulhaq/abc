using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EcommerceDAL;
using EcommerceUtilities;

namespace Ecommerce.EcommerceManager.UserControls
{
    public partial class CtrlCategories : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridView();
            }

        }

        private void PopulateGridView()
        {
            using (var clothEntities = new ClothEntities())
            {
                var allCategories = clothEntities.SP_Categories_GetAllActiveCategories(LoggedUser.GetStoreId()).ToList();
                GrdCategories.DataSource = allCategories;
                GrdCategories.DataBind();
            }
        }

        protected void GrdBrandRowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {

            var lnkEnableButton = e.CommandSource as LinkButton;
            if (lnkEnableButton != null)
            {
                string commandName = lnkEnableButton.CommandArgument;
                int rowIndex = 0;
                if (EnablingAndDisabling.ReturnCommandNameWithRowIndex(commandName, out rowIndex,
                                                                       out commandName))
                    if (true)
                    {
                        var dataKey = GrdCategories.DataKeys[rowIndex];
                        if (dataKey != null)
                        {
                            int dataKeyVal = int.Parse(dataKey[0].ToString());

                            using (var clothEntities = new ClothEntities())
                            {
                                var cat =
                                    clothEntities.tbl_Categories.FirstOrDefault(ct => ct.CatId == dataKeyVal);
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
                                    cat.CatIsActive = !(cat.CatIsActive);
                                    cat.CatLastModifiedBy = LoggedUser.GetUserId();
                                    cat.CatLastModifiedDate = DateTime.Now;
                                    clothEntities.tbl_CategoriesUpdationRecord.Add(catUpdation);
                                    if (clothEntities.SaveChanges() > 0)
                                    {
                                        Utility.ShowMessage(ref lblMessage, true, "Categories Information Has Been Successfully Updated");
                                    }
                                    else
                                    {
                                        Utility.ShowMessage(ref lblMessage, false,
                                                            "Categories Information Couldn't be Successfully Updated");
                                    }
                                }
                            }
                        }

                    }
            }

        }


        protected void BtnSearchCatClicked(object sender, EventArgs e)
        {
            using (var db=new ClothEntities())
            {
                var categories = db.SP_Categories_GetAllActiveCategories(LoggedUser.GetStoreId()).ToList();
                {
                    var categoriesSearched = categories.Where(x => x.CatName.ToLower().Contains(txtSearchCat.Text.ToLower())).ToList();
                    GrdCategories.DataSource = categoriesSearched;
                    GrdCategories.DataBind();
                }
            }
        }
    }
}