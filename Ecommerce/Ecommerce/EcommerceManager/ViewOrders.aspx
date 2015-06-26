<%@ Page Title="" Language="C#" MasterPageFile="~/EcommerceManager/EcommerceManager.Master" AutoEventWireup="true" CodeBehind="ViewOrders.aspx.cs" Inherits="Ecommerce.EcommerceManager.ViewOrders" %>

<%@ Register Src="~/EcommerceManager/UserControls/CtrlOrders.ascx" TagPrefix="uc1" TagName="CtrlOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   <script type="text/javascript">

   function pageLoad( ) {
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
    <uc1:CtrlOrders runat="server" id="CtrlOrders" />
</asp:Content>
