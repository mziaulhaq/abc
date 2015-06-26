using System;
using System.Data.Objects;
using System.Linq;
using System.Text;
using Ecommerce.App_Start;
using EcommerceDAL;
using Microsoft.Reporting.WebForms;

namespace Ecommerce.EcommerceManager.Downloadables
{
    public partial class SalesReportByDate : AdminBasePage
    {
        private int totalProfit;
        private DateTime? fromTime;
        private DateTime? toTime;
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

                Report();
            }
        }
        private bool DateConversion(string dateValue)
        {
            DateTime dt;
            return DateTime.TryParse(dateValue, out dt);
        }
        private void Report()
        {
            
            var objTotalProfit = new ObjectParameter("TotalProfit", typeof(int));
            using (var clothEntities = new ClothEntities())
            {
                var salesReportDataSet =
                clothEntities.SP_SalesReportByDateForDownload(fromTime, toTime, LoggedStoreId, objTotalProfit).
                        ToList(); 
                totalProfit = Convert.ToInt32(objTotalProfit.Value);
                string headerText = string.Format("Profit Report {0} -->  Total Profit : {1} ", DateRange(), totalProfit);
                ReportViewer1.Reset();
                string reportPath = Server.MapPath("~/EcommerceManager/Reports/ReportSaleByDate.rdlc");
                ReportViewer1.LocalReport.ReportPath = reportPath;
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("SalesReportForDownload", salesReportDataSet));
                var rp = new ReportParameter("HeaderText", headerText);
                ReportViewer1.LocalReport.SetParameters(rp);
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