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

namespace Ecommerce.EcommerceManager.UserControls.SalesReport
{
    public partial class CtrlReportByDate : UserControlBase
    {
        #region Search Parameters
        private int pageIndex = 1;
        private int pageSize = 25;
        private long totalCount = 0;
        private DateTime? fromTime;
        private DateTime? toTime;
        #endregion
        // In order to handle viewstate Information all these properties are used
        /*
            *  name , catId , dynamicCategory,gender,color,status,featured,brand,pageIndex, pageSize, orderByCol, orderBy
            */
        #region ViewState Properties
        
        private const string PageIndex = "pageIndex";
        private const string PageSize = "pageSize";
        private const string TotalCount = "totalCount";
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GdvSales.DataSource = new List<SalesReportByDate>();
                GdvSales.DataBind();
            }
            LoadDatesToVariables();
        }
        protected bool EnableDisablePageNumber(string pageNumber)
        {
            if (pageNumber != "Previous" && pageNumber != "First" && pageNumber != "Next" && pageNumber != "Last")
                return pageIndex != Convert.ToInt32(pageNumber);
            else
                return true;
        }
        private void LoadDatesToVariables()
        {
            if (hfFrom.Value != "" && DateConversion(hfFrom.Value))
                fromTime = DateTime.Parse(hfFrom.Value);
            if (hfTo.Value != "" && DateConversion(hfTo.Value))
                toTime = DateTime.Parse(hfTo.Value);
        }

        protected string SalesReportByProduct(string productId)
        {
            if(fromTime.HasValue && toTime.HasValue)
                return string.Format("~/EcommerceManager/SaleReportByProduct.aspx?PId={0}&from={1}&to={2}", productId, Server.UrlEncode(fromTime.Value.ToShortDateString()), Server.UrlEncode(toTime.Value.ToShortDateString()));
            if(fromTime.HasValue)
                return string.Format("~/EcommerceManager/SaleReportByProduct.aspx?PId={0}&from={1}", productId, fromTime.Value.ToShortDateString());
            if (toTime.HasValue)
                return string.Format("~/EcommerceManager/SaleReportByProduct.aspx?PId={0}&to={1}", productId, toTime.Value.ToShortDateString());
            return string.Format("~/EcommerceManager/SaleReportByProduct.aspx?PId={0}", productId);
        }
        private bool DateConversion(string dateValue)
        {
            DateTime dt;
            return DateTime.TryParse(dateValue, out dt);
        }

        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);
            PopulateValuesViaViewState();
        }
        

        protected void OrdersSearchedClicked(object sender, ImageClickEventArgs e)
        {
            
            ResetDateValues();
            ResetViewStates();
            pageIndex = 1;
            totalCount = 0;
            PopulateDateParameters();
            PopulateGridView();
        }

        private void ResetDateValues()
        {
            fromTime = null;
            toTime = null;
        }

        private void PopulateDateParameters()
        {
            if (dtFrom.Text != string.Empty && DateConversion(dtFrom.Text))
                fromTime = DateTime.Parse(dtFrom.Text);
            if (dtTo.Text != string.Empty && DateConversion(dtTo.Text))
                toTime = DateTime.Parse(dtTo.Text);
        }

        private void PopulateGridView()
        {
            var objTotalProfit = new ObjectParameter("TotalProfit", typeof(int));
            var objTotalCount = new ObjectParameter("TotalCount", typeof(int));
            using (var clothEntities = new ClothEntities())
            {
                var salesReport = clothEntities.SP_SalesReportByDate(fromTime, toTime, LoggedStoreId, pageIndex,pageSize, objTotalProfit,objTotalCount).ToList();
                GdvSales.DataSource = salesReport;
                GdvSales.DataBind();
                totalCount = Convert.ToInt32(objTotalCount.Value);
                PoulatePaging();
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

        }

        private void ResetViewStates()
        {
            ViewState[PageIndex] = null;
            ViewState[PageSize] = null;
            ViewState[TotalCount] = null;

        }
        private void SavePropertiesInViewState()
        {

            ViewState[PageIndex] = pageIndex;
            ViewState[PageSize] = pageSize;
            ViewState[TotalCount] = totalCount;

        }
        private void Page_PreRender(object source,EventArgs e)
        {
            SavePropertiesInViewState();
            hfFrom.Value = fromTime.ToString();
            hfTo.Value = toTime.ToString();
            DownloadUrl();
        }

        private void DownloadUrl()
        {
            string downloadUrl = "~/EcommerceManager/Downloadables/SalesReportByDate.aspx?";
            if (fromTime.HasValue && toTime.HasValue)
                downloadUrl += string.Format("from={0}&to={1}", Server.UrlEncode(fromTime.ToString()),
                                             Server.UrlEncode(toTime.ToString()));
            else if (fromTime.HasValue)
                downloadUrl += string.Format("from={0}", Server.UrlEncode(fromTime.ToString()));
            else if (toTime.HasValue)
                downloadUrl += string.Format("to={0}", Server.UrlEncode(toTime.ToString()));
            hlDownloadAll.NavigateUrl = downloadUrl;
        }

        private void PoulatePaging()
        {
            rptPagination.DataSource = CreatePagination();
            rptPagination.DataBind();
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

        protected void cvDateCheck_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(dtFrom.Text) && !string.IsNullOrEmpty(dtTo.Text))
            {
                try
                {
                    var dateFrom = Convert.ToDateTime(dtFrom.Text);
                    var dateTo = Convert.ToDateTime(dtTo.Text);
                    if (dateFrom < dateTo)
                        args.IsValid = true;
                    else
                    {
                        args.IsValid = false;
                        Utility.ShowPopUpMessage("Invalid Query Parameters", new List<string>() { "Please provide valid date to query" }, this.Page, true);
                    }

                }
                catch (Exception)
                {
                    args.IsValid = false;
                    Utility.ShowPopUpMessage("Invalid Query Parameters", new List<string>() { "Please provide valid date to query" }, this.Page, true);
                }
            }

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
    }
}