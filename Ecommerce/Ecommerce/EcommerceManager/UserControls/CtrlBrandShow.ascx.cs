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
    public partial class CtrlBrandShow : System.Web.UI.UserControl
    {
        private int _grdPageSize;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridView();
            }
            Utility.MakeLabelInvisible(ref lblMessage);

        }

        private void PopulateGridView(int? recordForPage = null)
        {
            _grdPageSize = GrdBrands.PageSize;
            int skipRecords = 0;
            int storeId = LoggedUser.GetStoreId();
            if (recordForPage != null)
            {
                skipRecords = ((int)recordForPage) * _grdPageSize;
            }
            using (var clothEntities = new ClothEntities())
            {
                var allBrandRecords = clothEntities.tbl_Brands.OrderBy(record => record.BrandId).Skip(skipRecords).Take(_grdPageSize).Where(brnd => brnd.StoreId == storeId).ToList();
                GrdBrands.DataSource = allBrandRecords;
                GrdBrands.DataBind();
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
                        var dataKey = GrdBrands.DataKeys[rowIndex];
                        if (dataKey != null)
                        {
                            int dataKeyVal = int.Parse(dataKey[0].ToString());

                            using (var clothEntities = new ClothEntities())
                            {
                                var brands =
                                    clothEntities.tbl_Brands.FirstOrDefault(brand => brand.BrandId == dataKeyVal);
                                if (brands != null)
                                {
                                    brands.IsActive = !(brands.IsActive);
                                    brands.BrandLastUpdatedBy = LoggedUser.GetUserId();
                                    brands.BrandLastUpdatedDate = DateTime.Now;
                                   
                                    int rowsUpdated = clothEntities.SaveChanges();
                                    if (rowsUpdated > 0)
                                    {
                                        Utility.ShowMessage(ref lblMessage, true, "Brand Information Has Been Successfully Updated");
                                        PopulateGridView();
                                    }
                                    else
                                    {
                                        Utility.ShowMessage(ref lblMessage, false, "Brand Information Couldn't be Successfully Updated");
                                    }
                                }
                            }
                        }

                    }
            }

        }


    }
}