﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesReportByDate.aspx.cs" Inherits="Ecommerce.EcommerceManager.Downloadables.SalesReportByDate" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sales Report By Date</title>
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
