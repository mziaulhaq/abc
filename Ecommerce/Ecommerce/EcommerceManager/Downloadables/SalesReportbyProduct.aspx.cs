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
using Microsoft.Reporting.WebForms;

namespace Ecommerce.EcommerceManager.Downloadables
{
    public partial class SalesReportbyProduct : AdminBasePage
    {
        #region Search Parameters
        private long totalCount = 0;
        private DateTime? fromTime;
        private DateTime? toTime;
        private long pid;
        #endregion
        // In order to handle viewstate Information all these properties are used
        /*
                *  name , catId , dynamicCategory,gender,color,status,featured,brand,pageIndex, pageSize, orderByCol, orderBy
            */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.QueryString["from"] != null && DateConversion(Server.UrlDecode(Request.QueryString["from"])))
                {
                    fromTime = DateTime.Parse(Server.UrlDecode(Request.QueryString["from"]));
                }
                if (Request.QueryString["to"] != null && DateConversion(Server.UrlDecode(Request.QueryString["to"])))
                {
                    toTime = DateTime.Parse(Server.UrlDecode(Request.QueryString["to"]));
                }
                if (Request.QueryString["PId"] != null && long.TryParse(Request.QueryString["PId"], out pid))
                {
                    PopulateReport();
                }
            }

        }



        private bool DateConversion(string dateValue)
        {
            DateTime dt;
            return DateTime.TryParse(dateValue, out dt);
        }

        private void PopulateReport()
        {
            var objTotalProfit = new ObjectParameter("TotalProfit", typeof(int));
            var objTotalCount = new ObjectParameter("TotalCount", typeof(int));
            var objStockAmountSold = new ObjectParameter("StockAmountSold", typeof(int));

            using (var clothEntities = new ClothEntities())
            {
                var product = clothEntities.tbl_Products.FirstOrDefault(prod => prod.ProductID == pid);
                var salesReport = clothEntities.SP_SalesReportByProductForDownload(fromTime, toTime, LoggedStoreId, pid, objStockAmountSold, objTotalProfit, objTotalCount).ToList();
                ReportViewer1.Reset();
                string reportPath = Server.MapPath("~/EcommerceManager/Reports/ReportSaleByProduct.rdlc");
                ReportViewer1.LocalReport.ReportPath = reportPath;
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("SalesReportByProduct", salesReport));
                totalCount = Convert.ToInt32(objTotalCount.Value);
                var rpProductName = new ReportParameter("ProductName", product != null ? product.ProductName : string.Empty);
                var rpDateRange = new ReportParameter("DateRange", DateRange());
                var rpSummaryReport = new ReportParameter("SummaryReport", string.Format("Total Profit : {0} Quantity Sold : {1} ", objTotalProfit.Value, objStockAmountSold.Value));

                ReportViewer1.LocalReport.SetParameters(rpProductName);
                ReportViewer1.LocalReport.SetParameters(rpDateRange);
                ReportViewer1.LocalReport.SetParameters(rpSummaryReport);
                ReportViewer1.LocalReport.Refresh();
            }
        }
        private string DateRange()
        {
            var strDateRange = new StringBuilder();
            strDateRange.AppendFormat(fromTime.HasValue ? string.Format("From {0}", fromTime.Value.ToString("D")) : string.Format("From Start Time"));
            strDateRange.AppendFormat(toTime.HasValue ? string.Format(" To {0}", toTime.Value.ToString("D")) : string.Format(" Till Now"));
            return strDateRange.ToString();
        }

    }
}