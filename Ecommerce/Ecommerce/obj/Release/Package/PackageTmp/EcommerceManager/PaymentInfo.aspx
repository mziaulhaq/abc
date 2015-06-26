<%@ Page Title="" Language="C#" MasterPageFile="~/EcommerceManager/EcommerceManager.Master" AutoEventWireup="true" CodeBehind="PaymentInfo.aspx.cs" Inherits="Ecommerce.EcommerceManager.PaymentInfo" %>

<%@ Register Src="~/EcommerceManager/Store/CtrlPaymentInfo.ascx" TagPrefix="uc1" TagName="CtrlPaymentInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function pageLoad() {
            $(function () {
                $('#dtFrom').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
                $('#dtTo').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlPaymentInfo runat="server" ID="CtrlPaymentInfo" />
</asp:Content>
