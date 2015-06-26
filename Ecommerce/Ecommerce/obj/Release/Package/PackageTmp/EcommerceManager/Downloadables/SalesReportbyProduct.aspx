<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesReportbyProduct.aspx.cs" Inherits="Ecommerce.EcommerceManager.Downloadables.SalesReportbyProduct" %>
<%@ Register TagPrefix="rsweb" Namespace="Microsoft.Reporting.WebForms" Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sales Report By Product</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="800px" Width="100%">
        </rsweb:ReportViewer>
        
    </div>
    </form>
</body>
</html>
