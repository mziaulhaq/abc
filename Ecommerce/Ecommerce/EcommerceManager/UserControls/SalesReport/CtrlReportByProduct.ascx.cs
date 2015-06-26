using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.App_Start;
using EcommerceDAL;
using EcommerceUtilities;

namespace Ecommerce.EcommerceManager.UserControls.SalesReport
{
    public partial class CtrlReportByProduct : UserControlBase
    {
        #region Search Parameters
        private int pageIndex = 1;
        private int pageSize = 25;
        private long totalCount = 0;
        private DateTime? fromTime;
        private DateTime? toTime;
        private long pid;
        #endregion
        // In order to handle viewstate Information all these properties are used
        /*
                *  name , catId , dynamicCategory,gender,color,status,featured,brand,pageIndex, pageSize, orderByCol, orderBy
            */
        #region ViewState Properties

        private const string PageIndex = "pageIndex";
        private const string PageSize = "pageSize";
        private const string TotalCount = "totalCount";
        private const string PId = "pid";
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateProducts();
                if (Request.QueryString["from"] != null && DateConversion(Server.UrlDecode(Request.QueryString["from"])))
                {
                    fromTime = DateTime.Parse(Server.UrlDecode(Request.QueryString["from"]));
                }
                if (Request.QueryString["to"] != null && DateConversion(Server.UrlDecode(Request.QueryString["to"])))
                {
                    toTime = DateTime.Parse(Server.UrlDecode(Request.QueryString["to"]));
                }
                if(Request.QueryString["PId"]!=null && long.TryParse(Request.QueryString["PId"],out pid))
                {
                    PopulateGridView();
                    SelectProductFromDropDown();
                }
            }
            LoadDatesToVariables();
        }

        private void SelectProductFromDropDown()
        {
           if(ddlProducts.Items.Count>1 )
           {
               ddlProducts.SelectedIndex = ddlProducts.Items.IndexOf(ddlProducts.Items.FindByValue(pid.ToString()));
           }
        }

        private void PopulateProducts()
        {
            using (var clothEntities = new ClothEntities())
            {
                var allProducts = (from prod in clothEntities.tbl_Products
                                  select new
                                             {
                                                 prod.ProductID,
                                                 prod.ProductName

                                             }).ToList();
                ddlProducts.DataSource = allProducts;
                ddlProducts.DataBind();
               
                ddlProducts.Items.Insert(0,  new ListItem("Select","0"));
            }
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
            SelectProductIdFromDropDown();
            PopulateGridView();
        }

        private void SelectProductIdFromDropDown()
        {
            try
            {
                pid = Convert.ToInt64(ddlProducts.SelectedValue);
            }
            catch (Exception)
            {

                pid = 0;
            }
        }

        private void ResetDateValues()
        {
            fromTime = null;
            toTime = null;
            pid = 0;
        }

        private void PopulateDateParameters()
        {
            if (dtFrom.Text != string.Empty && DateConversion(dtFrom.Text))
                fromTime = DateTime.Parse(dtFrom.Text);
            if (dtTo.Text != string.Empty && DateConversion(dtTo.Text))
                toTime = DateTime.Parse(dtTo.Text);
        }
        private void DownloadUrl()
        {
            string downloadUrl = string.Format("~/EcommerceManager/Downloadables/SalesReportByProduct.aspx?PId={0}&",pid);
            if (fromTime.HasValue && toTime.HasValue)
                downloadUrl += string.Format("from={0}&to={1}", Server.UrlEncode(fromTime.ToString()),
                                             Server.UrlEncode(toTime.ToString()));
            else if (fromTime.HasValue)
                downloadUrl += string.Format("from={0}", Server.UrlEncode(fromTime.ToString()));
            else if (toTime.HasValue)
                downloadUrl += string.Format("to={0}", Server.UrlEncode(toTime.ToString()));
            hlDownSaleReport.NavigateUrl = downloadUrl;
        }
        private void PopulateGridView()
        {
            var objTotalProfit = new ObjectParameter("TotalProfit", typeof(int));
            var objTotalCount = new ObjectParameter("TotalCount", typeof(int));
            var objStockAmountSold = new ObjectParameter("StockAmountSold", typeof(int));
            using (var clothEntities = new ClothEntities())
            {
                var salesReport = clothEntities.SP_SalesReportByProduct(fromTime, toTime, LoggedStoreId, pageIndex, pageSize, pid, objStockAmountSold, objTotalProfit, objTotalCount).ToList();
                GdvSales.DataSource = salesReport;
                GdvSales.DataBind();
                totalCount = Convert.ToInt32(objTotalCount.Value);
                if (pageIndex == 1)
                {
                    var product = clothEntities.tbl_Products.FirstOrDefault(prod => prod.ProductID == pid);
                    lblReport.Text =
                        string.Format(
                            "Profit Report for Product : {0} <br> {1} <br >Total Profit : {2} Quantity Sold : {3} ",
                            product!=null?product.ProductName:string.Empty, DateRange(), objTotalProfit.Value, objStockAmountSold.Value);
                }
                PoulatePaging();
            }
        }
        private string DateRange()
        {
            var strDateRange = new StringBuilder();
            strDateRange.AppendFormat(fromTime.HasValue ? string.Format("From {0}", fromTime.Value.ToString("D")) : string.Format("From Start Time"));
            strDateRange.AppendFormat(toTime.HasValue ? string.Format(" To {0}", toTime.Value.ToString("D")) : string.Format(" Till Now"));
            return strDateRange.ToString();
        }
        private void PopulateValuesViaViewState()
        {
            if (CheckViewState(PageIndex))
                pageIndex = int.Parse(ViewState[PageIndex].ToString());
            if (CheckViewState(PageSize))
                pageSize = int.Parse(ViewState[PageSize].ToString());
            if (CheckViewState(TotalCount))
                totalCount = long.Parse(ViewState[TotalCount].ToString());
            if (CheckViewState(PId))
                pid = long.Parse(ViewState[PId].ToString());
        }

        private void ResetViewStates()
        {
            ViewState[PageIndex] = null;
            ViewState[PageSize] = null;
            ViewState[TotalCount] = null;
            ViewState[PId] = null;

        }
        private void SavePropertiesInViewState()
        {

            ViewState[PageIndex] = pageIndex;
            ViewState[PageSize] = pageSize;
            ViewState[TotalCount] = totalCount;
            ViewState[PId] = pid;

        }
        private void Page_PreRender(object source, EventArgs e)
        {
            SavePropertiesInViewState();
            hfFrom.Value = fromTime.ToString();
            hfTo.Value = toTime.ToString();
            if (GdvSales.Rows.Count == 0)
            {
                GdvSales.DataSource = new List<SalesReportByProduct>();
                GdvSales.DataBind();
            }
            DownloadUrl();

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