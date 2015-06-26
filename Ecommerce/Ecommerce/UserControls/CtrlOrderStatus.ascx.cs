using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceUtilities;
using EcommerceDAL;
namespace Ecommerce.UserControls
{
    public partial class CtrlOrderStatus : UserControlFront
    {
        private int pageIndex = 1;
        private int totalCount = 0;
        private int pageSize = 10;
        private string PageIndex = "pageIndex";
        private string PageSize = "pageSize";
        private string TotalCount = "totalCount";
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateValuesViaViewState();
            if(!IsPostBack && LoggedCustomer.IsUserLogged())
            {
                PopulateOrderStatuses();
            }

        }

        private void PopulateOrderStatuses()
        {
            var customerId = LoggedCustomer.GetLoggedCustomer().Id;
            using (var clothEntities = new ClothEntities())
            {
                var totalParam = new ObjectParameter("TotalCount", "0");
                var customerOrders = clothEntities.SP_OrderStatus_Customer(customerId,pageSize,pageIndex,StoreId,totalParam).ToList();
                lstOrders.DataSource = customerOrders;
                lstOrders.DataBind();
                totalCount = Convert.ToInt32(totalParam.Value);
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
                totalCount = int.Parse(ViewState[TotalCount].ToString());
            

        }
        private void SavePropertiesInViewState()
        {

            ViewState[PageIndex] = pageIndex;
            ViewState[PageSize] = pageSize;
            ViewState[TotalCount] = totalCount;
            
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

                PopulateOrderStatuses();
            }
        }
    }
}