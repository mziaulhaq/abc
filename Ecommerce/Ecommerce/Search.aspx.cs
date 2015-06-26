using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceDAL;

namespace Ecommerce
{
    public partial class Search : FrontBase
    {
        private int pageIndex = 1;
        private int pageSize = 25;
        private long totalCount = 0;
        private const string PageIndex = "pageIndex";
        private const string PageSize = "pageSize";
        private const string TotalCount = "totalCount";
        private const string CatId = "_catId";
        private int _catId;
        private string searchText = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateValuesViaViewState();
            if (!IsPostBack)
            {
                if (Request.QueryString["Query"] != null && Request.QueryString["Query"] != string.Empty)
                {
                    FindControlAndResetValue();
                    searchText = Request.QueryString["Query"];
                    PopulateAllProducts();
                }
                else
                {
                    Response.Redirect("Index");
                }
            }

        }

        private void FindControlAndResetValue()
        {
            var mster = this.Master;
            if (mster != null)
            {
                var userControl = mster.FindControl("HeaderMenu");
                if (userControl != null)
                {
                    var textBox = userControl.FindControl("txtSearchValue") as TextBox;
                    if (textBox != null)
                        textBox.Text = Request.QueryString["Query"];
                }
            }
        }

        private void PopulateAllProducts()
        {
            try
            {
                using (var clothEntities = new ClothEntities())
                {
                    var totalRowsCount = new ObjectParameter("TotalCount", "0");
                    var tblProducts = clothEntities.SP_SearchProduct(searchText, (((pageIndex - 1) * pageSize) + 1), (pageIndex * pageSize), StoreId, totalRowsCount).ToList();
                    if(tblProducts.Count == 0)
                    {
                        ResultNotFound();
                        return;
                    }
                    lvLatestProducts.DataSource = tblProducts;
                    lvLatestProducts.DataBind();
                    totalCount = int.Parse(totalRowsCount.Value.ToString());
                    PoulatePaging();
                }
            }
            catch
            {
                ResultNotFound();
            }

        }

        private void ResultNotFound()
        {
            lvLatestProducts.Visible = false;
            rptPagination.Visible = false;
            lblError.Visible = true;
        }

        protected bool EnableDisablePageNumber(string pageNumber)
        {
            if (pageNumber != "Previous" && pageNumber != "First" && pageNumber != "Next" && pageNumber != "Last")
                return pageIndex != Convert.ToInt32(pageNumber);
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

                PopulateAllProducts();
            }
        }
    }

}
