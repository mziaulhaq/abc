using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceDAL;

namespace Ecommerce
{
    public partial class ProductsInCategories : FrontBase
    {
        private int pageIndex = 1;
        private int pageSize = 20;
        private long totalCount = 0;
        private const string SearchButtonClickedFlag = "searchButtonClickedFlag";
        private const string PageIndex = "pageIndex";
        private const string PageSize = "pageSize";
        private const string TotalCount = "totalCount";
        private const string CatId = "_catId";
        private int _catId;
        public string CategoryName = "";
        public string CategoryDesc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateValuesViaViewState();
            if (!IsPostBack)
            {
                Session[SearchButtonClickedFlag] = null;

                if (Request.QueryString["CatId"] != null && int.TryParse(Request.QueryString["CatId"], out _catId))
                {
                    #region This block will show the category name and description in aspx page

                    using (var db = new ClothEntities())
                    {
                        var firstOrDefault = db.tbl_Categories.FirstOrDefault(x => x.CatId == _catId);
                        if (firstOrDefault != null)
                        {
                            CategoryName = firstOrDefault.CatName;
                            CategoryDesc = "<br/>" + firstOrDefault.CatDescription;
                        }
                    }

                    #endregion

                    PopulateAllProducts();
                    //Calling search methods here...
                    BindBrandsToCheckBoxList();
                    BindColorsToCheckBoxList();
                    BindMetarialsToCheckBoxList();
                    BindTypesToCheckBoxList();
                    BindGendersToCheckBoxList();
                }
                else
                {
                    Response.Redirect("Index");
                }
            }
        }

        private void PopulateAllProducts()
        {
            using (var clothEntities = new ClothEntities())
            {
                var totalRowsCount = new ObjectParameter("TotalCount", "0");
                var tblProducts = clothEntities.SP_ProductSearchFront(string.Empty, _catId, -1, -1, -1, 1, -1, -1,
                                                                   StoreId, pageIndex, pageSize, string.Empty, string.Empty,
                                                                   totalRowsCount).ToList();
                lvLatestProducts.DataSource = tblProducts;
                lvLatestProducts.DataBind();
                totalCount = int.Parse(totalRowsCount.Value.ToString());
                PoulatePaging();

            }
        }
        protected bool EnableDisablePageNumber(string pageNumber)
        {
            if (pageNumber != "Previous" && pageNumber != "First" && pageNumber != "Next" && pageNumber != "Last")
                return pageIndex != Convert.ToInt32(pageNumber);
            else
                return true;
        }
        private void PoulatePaging()
        {
            rptPagination.DataSource = CreatePagination();
            rptPagination.DataBind();
        }
        private List<ListItem> CreatePagination()
        {
            if (totalCount == 0)
                return null;
            if (totalCount <= pageSize)
                return new List<ListItem>()
                           {
                               new ListItem("1","1")
                           };
            int totalPages = totalCount % pageSize != 0 ? ((int)(totalCount / pageSize)) + 1 : (int)(totalCount / pageSize);

            var pages = new List<ListItem>();
            int pageStartFrom = pageIndex <= 4 ? 1 : SetPageStartPosition();
            int pagesTo = pageStartFrom + 6;
            for (int i = pageStartFrom; i <= totalPages && i <= pagesTo; i++)
            {
                pages.Add(new ListItem(i.ToString(), i.ToString()));
            }
            if (pageIndex != 1)
            {
                pages.Insert(0, new ListItem("Previous", "Previous"));
                pages.Insert(0, new ListItem("First", "First"));

            }
            if (pageIndex != totalPages)
            {
                pages.Add(new ListItem("Next", "Next"));
                pages.Add(new ListItem("Last", "Last"));
            }

            return pages;
        }
        private int SetPageStartPosition()
        {
            if (pageIndex % 5 == 0 && pageSize >= 8)
            {
                return pageIndex;
            }
            else if (pageIndex % 5 == 0 && pageSize < 8)
            {
                return pageIndex - 3;
            }
            else
            {
                return pageIndex - 5;
            }
        }
        protected void Page_PreRender(object sender, EventArgs eventArgs)
        {
            SavePropertiesInViewState();
            try
            {
                var mp = this.Page.Master;
                if (mp != null)
                {
                    var toolkitManger =
                        mp.FindControl("ToolkitScriptManager1") as AjaxControlToolkit.ToolkitScriptManager;
                    if (toolkitManger != null)
                        foreach (RepeaterItem ri in rptPagination.Items)
                        {
                            if (ri.ItemType == ListItemType.Item || ri.ItemType == ListItemType.AlternatingItem)
                            {
                                var lb = (LinkButton)ri.FindControl("lnkPage");
                                if (lb != null) toolkitManger.RegisterAsyncPostBackControl(lb);
                            }
                        }
                }
            }
            catch (Exception)
            {


            }


        }
        private void PopulateValuesViaViewState()
        {
            if (CheckViewState(PageIndex))
                pageIndex = int.Parse(ViewState[PageIndex].ToString());
            if (CheckViewState(PageSize))
                pageSize = int.Parse(ViewState[PageSize].ToString());
            if (CheckViewState(TotalCount))
                totalCount = long.Parse(ViewState[TotalCount].ToString());
            if (CheckViewState(CatId))
                _catId = int.Parse(ViewState[CatId].ToString());

        }
        private void SavePropertiesInViewState()
        {

            ViewState[PageIndex] = pageIndex;
            ViewState[PageSize] = pageSize;
            ViewState[TotalCount] = totalCount;
            ViewState[CatId] = _catId;

        }
        private bool CheckViewState(string vsName)
        {
            return ViewState[vsName] != null;
        }
        protected void PageIndexChanged(object sender, EventArgs e)
        {
            int pages = totalCount % pageSize != 0 ? ((int)(totalCount / pageSize)) + 1 : (int)(totalCount / pageSize);
            var linkButton = sender as LinkButton;
            if (linkButton != null)
            {
                string commandArg = linkButton.CommandArgument;
                if (commandArg.ToLower() == "first")
                    pageIndex = 1;
                else if (commandArg.ToLower() == "previous")
                {
                    pageIndex = pageIndex - 1;
                    if (pageIndex == 0)
                        pageIndex = 1;
                }
                else if (commandArg.ToLower() == "last")
                    pageIndex = pages;
                else if (commandArg.ToLower() == "next")
                {
                    pageIndex = pageIndex + 1;
                    if (pageIndex > pages)
                        pageIndex = pages;
                }
                else
                {
                    pageIndex = int.Parse(commandArg);
                }
                
                if(Session[SearchButtonClickedFlag]==null)
                    PopulateAllProducts();
                else
                    RetrieveProductsBasedOnSearchParameters();
            }
        }


        #region Search Crieteria Methods
        private void BindGendersToCheckBoxList()
        {
            using (var db = new ClothEntities())
            {
                cbListGender.DataSource = db.SP_ReturnGenderWithNoOfProducts().ToList();
                cbListGender.DataBind();
            }
        }
        private void BindTypesToCheckBoxList()
        {
            using (var db = new ClothEntities())
            {
                cbListType.DataSource = db.SP_ReturnTypeWithNoOfProducts().ToList();
                cbListType.DataBind();
            }
        }
        private void BindMetarialsToCheckBoxList()
        {
            using (var db = new ClothEntities())
            {
                cbListMetarial.DataSource = db.SP_ReturnMetarialWithNoOfProducts().ToList();
                cbListMetarial.DataBind();
            }
        }
        private void BindColorsToCheckBoxList()
        {
            using (var db = new ClothEntities())
            {
                cbListColor.DataSource = db.SP_ReturnColorsWithNoOfProducts().ToList();
                cbListColor.DataBind();
            }
        }
        private void BindBrandsToCheckBoxList()
        {
            using (var db = new ClothEntities())
            {
                cbListBrand.DataSource = db.SP_ReturnBrandsWithNoOfProducts().ToList();
                cbListBrand.DataBind();
            }
        }
        #endregion

        protected void btnSubmitSearch_Click(object sender, EventArgs e)
        {
            pageIndex = 1;
            if (Session[SearchButtonClickedFlag]==null)
                Session[SearchButtonClickedFlag] = "true";
            RetrieveProductsBasedOnSearchParameters();
        }

        private void RetrieveProductsBasedOnSearchParameters()
        {
            string selectedBrand =
                cbListBrand.Items.Cast<ListItem>()
                    .Where(listItem => listItem.Selected)
                    .Aggregate(string.Empty, (current, listItem) => current + (listItem.Value + ","));

            if (!string.IsNullOrWhiteSpace(selectedBrand))
                selectedBrand = selectedBrand.Substring(0, selectedBrand.Length - 1);

            string selectedColor =
                cbListColor.Items.Cast<ListItem>()
                    .Where(listItem => listItem.Selected)
                    .Aggregate(string.Empty, (current, listItem) => current + (listItem.Value + ","));
            if (!string.IsNullOrWhiteSpace(selectedColor))
                selectedColor = selectedColor.Substring(0, selectedColor.Length - 1);

            string selectedMetarial =
                cbListMetarial.Items.Cast<ListItem>()
                    .Where(listItem => listItem.Selected)
                    .Aggregate(string.Empty, (current, listItem) => current + (listItem.Value + ","));
            if (!string.IsNullOrWhiteSpace(selectedMetarial))
                selectedMetarial = selectedMetarial.Substring(0, selectedMetarial.Length - 1);

            string selectedType = cbListType.Items.Cast<ListItem>()
                .Where(listItem => listItem.Selected)
                .Aggregate(string.Empty, (current, listItem) => current + (listItem.Value + ","));
            if (!string.IsNullOrWhiteSpace(selectedType))
                selectedType = selectedType.Substring(0, selectedType.Length - 1);

            string selectedGender =
                cbListGender.Items.Cast<ListItem>()
                    .Where(listItem => listItem.Selected)
                    .Aggregate(string.Empty, (current, listItem) => current + (listItem.Value + ","));
            if (!string.IsNullOrWhiteSpace(selectedGender))
                selectedGender = selectedGender.Substring(0, selectedGender.Length - 1);

            string minPrice = txtMinPrice.Text;
            string maxPrice = txtMaxPrice.Text;

            using (var db = new ClothEntities())
            {
                var totalRowsCount = new ObjectParameter("TotalCount", "0");
                var data =
                    db.SP_AdvanceSearch(StoreId, selectedType, selectedGender, selectedColor, selectedBrand, selectedMetarial,
                        minPrice, maxPrice,
                        pageIndex, pageSize, string.Empty, string.Empty, totalRowsCount).ToList();
                lvLatestProducts.DataSource = data;
                lvLatestProducts.DataBind();
                totalCount = int.Parse(totalRowsCount.Value.ToString());
                PoulatePaging();
            }
        }

    }

}
