<%@ Page Title="" Language="C#" MasterPageFile="~/EcommerceManager/EcommerceManager.Master" AutoEventWireup="true" CodeBehind="CustomersManager.aspx.cs" Inherits="Ecommerce.EcommerceManager.CustomersManager" %>

<%@ Register Src="~/EcommerceManager/UserControls/CtrlCustomers.ascx" TagPrefix="uc1" TagName="CtrlCustomers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <script type="text/javascript">

        function pageLoad() {
            $(function () {
                $('#dtRegistrationDate').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlCustomers runat="server" id="CtrlCustomers" />
</asp:Content>
