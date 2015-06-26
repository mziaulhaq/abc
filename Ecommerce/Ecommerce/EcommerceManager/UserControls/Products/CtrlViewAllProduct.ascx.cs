using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceDAL;
using EcommerceUtilities;

namespace Ecommerce.EcommerceManager.UserControls.Products
{

    public partial class CtrlViewAllProduct : UserControlBase
    {
        #region Search Parameters
        private string name = string.Empty;
        private int catId = -1;
        private long dynamicCategory = -1;
        private int gender = -1;
        private int color = -1;
        private short status = -1;
        private int featured = -1;
        private int brand = -1;
        private int pageIndex = 1;
        private int pageSize = 25;
        private string orderByCol = string.Empty;
        private string orderBy = string.Empty;
        private long totalCount = 0;
        #endregion
        // In order to handle viewstate Information all these properties are used
        /*
            *  name , catId , dynamicCategory,gender,color,status,featured,brand,pageIndex, pageSize, orderByCol, orderBy
            */
        #region ViewState Properties
        private const string Name = "name";
        private const string CatId = "catId";
        private const string DynamicCategory = "dynamicCategory";
        private const string Gender = "gender";
        private const string Color = "color";
        private const string Status = "status";
        private const string Featured = "featured";
        private const string Brand = "brand";
        private const string PageIndex = "pageIndex";
        private const string PageSize = "pageSize";
        private const string OrderByCol = "orderByCol";
        private const string OrderBy = "orderBy";
        private const string TotalCount = "totalCount";
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateStatuses();
                PopulateAllCategories();
                PopulateAllDyamicCategories();
                PopulateAllGenders();
                PopulateAllColors();
                PopulateGridView();
            }
            PopulateValuesViaViewState();
        }
        protected bool EnableDisablePageNumber(string pageNumber)
        {
            if (pageNumber != "Previous" && pageNumber != "First" && pageNumber != "Next" && pageNumber != "Last")
                return pageIndex != Convert.ToInt32(pageNumber);
            else
                return true;
        }
        private void PopulateValuesViaViewState()
        {
            if (CheckViewState(CatId))
                catId = int.Parse(ViewState[CatId].ToString());
            if (CheckViewState(Name))
                name = ViewState[Name].ToString();
            if (CheckViewState(DynamicCategory))
                dynamicCategory = long.Parse(ViewState[DynamicCategory].ToString());
            if (CheckViewState(Gender))
                gender = int.Parse(ViewState[Gender].ToString());
            if (CheckViewState(Color))
                color = int.Parse(ViewState[Color].ToString());
            if (CheckViewState(Status))
                status = short.Parse(ViewState[Status].ToString());
            if (CheckViewState(Featured))
                featured = int.Parse(ViewState[Featured].ToString());
            if (CheckViewState(Brand))
                brand = int.Parse(ViewState[Brand].ToString());
            if (CheckViewState(PageIndex))
                pageIndex = int.Parse(ViewState[PageIndex].ToString());
            if (CheckViewState(PageSize))
                pageSize = int.Parse(ViewState[PageSize].ToString());
            if (CheckViewState(OrderByCol))
                orderByCol = ViewState[OrderByCol].ToString();
            if (CheckViewState(OrderBy))
                orderBy = ViewState[OrderBy].ToString();
            if (CheckViewState(TotalCount))
                totalCount = long.Parse(ViewState[TotalCount].ToString());

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
            if (pageIndex % 5 == 0)
            {
                return pageIndex;
            }
            else
            {
                return pageIndex - 5;
            }
        }
        private void ResetPropertiesValues()
        {
            name = string.Empty;
            catId = -1;
            dynamicCategory = -1;
            gender = -1;
            color = -1;
            status = -1;
            featured = -1;
            brand = -1;
            pageIndex = 1;
            orderByCol = string.Empty;
            orderBy = string.Empty;
            totalCount = 0;
        }
        private void ResetViewStates()
        {

            ViewState[CatId] = null;
            ViewState[Name] = null;
            ViewState[DynamicCategory] = null;
            ViewState[Gender] = null;
            ViewState[Color] = null;
            ViewState[Status] = null;
            ViewState[Featured] = null;
            ViewState[Brand] = null;
            ViewState[PageIndex] = null;
            ViewState[PageSize] = null;
            ViewState[OrderByCol] = null;
            ViewState[OrderBy] = null;
            ViewState[TotalCount] = null;

        }
        private void SavePropertiesInViewState()
        {

            ViewState[CatId] = catId;
            ViewState[Name] = name;
            ViewState[DynamicCategory] = dynamicCategory;
            ViewState[Gender] = gender;
            ViewState[Color] = color;
            ViewState[Status] = status;
            ViewState[Featured] = featured;
            ViewState[Brand] = brand;
            ViewState[PageIndex] = pageIndex;
            ViewState[PageSize] = pageSize;
            ViewState[OrderByCol] = orderByCol;
            ViewState[OrderBy] = orderBy;
            ViewState[TotalCount] = totalCount;

        }
        private void PopulateValuesViaForm()
        {
            if (!string.IsNullOrEmpty(txtName.Text))
                name = txtName.Text;
            if (ddlCategory.SelectedIndex != 0)
                catId = int.Parse(ddlCategory.SelectedValue);
            if (ddlDynamicCategory.SelectedIndex != 0)
                dynamicCategory = int.Parse(ddlDynamicCategory.SelectedValue);
            if (ddlIsActive.SelectedIndex != 0)
                status = short.Parse(ddlIsActive.SelectedValue);
            if (ddlIsFeatured.SelectedIndex != 0)
                featured = int.Parse(ddlIsFeatured.SelectedValue);
            if (ddlGender.SelectedIndex != 0)
                gender = int.Parse(ddlGender.SelectedValue);
            if (ddlColor.SelectedIndex != 0)
                color = int.Parse(ddlColor.SelectedValue);
            pageIndex = 1;

        }
        private void PopulateGridView()
        {

            var objTotalCount = new ObjectParameter("totalCount", "0");
            using (var clothEntities = new ClothEntities())
            {
                // gdvProductToCategories.DataSource  = clothEntities.SP_ProductSearch(name: name, catId: catId, dynamicCategory: dynamicCategory, gender: gender, color: color, status: status, featured: featured, brand: brand, storeId: LoggedStoreId, pageIndex: pageIndex, pageSize: pageSize, orderByCol: orderByCol, orderBy: orderBy, totalCount: objTotalCount).ToList();
                var data = clothEntities.SP_ProductSearch(name.Trim(), catId, dynamicCategory, gender, color, status, featured, brand, LoggedStoreId, pageIndex, pageSize, orderByCol, orderBy, objTotalCount).ToList();
                gdvProductToCategories.DataSource = data;

                gdvProductToCategories.DataBind();
                totalCount = long.Parse(objTotalCount.Value.ToString());
                PoulatePaging();


            }

        }
        private void PoulatePaging()
        {
            rptPagination.DataSource = CreatePagination();
            rptPagination.DataBind();
        }
        private void PopulateAllColors()
        {
            using (var clothEntities = new ClothEntities())
            {
                ddlColor.DataSource = clothEntities.tbl_Colors.Where(cl => cl.StoreId == LoggedStoreId).ToList();
                ddlColor.DataBind();
                ddlColor.Items.Insert(0, new ListItem("Select", "Select"));
            }
        }
        private void PopulateAllGenders()
        {
            using (var clothEntities = new ClothEntities())
            {
                ddlGender.DataSource = clothEntities.tbl_GenderCategories.Where(gc => gc.StoreId == LoggedStoreId).ToList();
                ddlGender.DataBind();
                ddlGender.Items.Insert(0, new ListItem("Select", "Select"));
            }
        }
        private void PopulateAllDyamicCategories()
        {
            using (var clothEntities = new ClothEntities())
            {
                ddlDynamicCategory.DataSource =
                    clothEntities.tbl_ProductDynamicCategories.Where(pdc => pdc.StoreId == LoggedStoreId).ToList();
                ddlDynamicCategory.DataBind();
                ddlDynamicCategory.Items.Insert(0, new ListItem("Select", "Select"));
            }
        }
        private void PopulateAllCategories()
        {
            using (var clothEntities = new ClothEntities())
            {
                ddlCategory.DataSource = clothEntities.SP_Categories_GetAllCategories(LoggedStoreId).ToList();
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("Select", "Select"));
            }
        }
        protected void IBSearchClick(object sender, ImageClickEventArgs e)
        {
            ResetPropertiesValues();
            ResetViewStates();
            PopulateValuesViaForm();
            PopulateGridView();


        }
        public void PopulateStatuses()
        {
            ddlIsActive.DataSource = ProductStatus.ListOfProductStatus();
            ddlIsActive.DataBind();
            ddlIsActive.Items.Insert(0, new ListItem("Select", "Select"));
        }
        protected void Page_PreRender(object sender, EventArgs eventArgs)
        {
            SavePropertiesInViewState();
            try
            {
                MasterPage mp = this.Page.Master;
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

                PopulateGridView();
            }
        }
    }
}