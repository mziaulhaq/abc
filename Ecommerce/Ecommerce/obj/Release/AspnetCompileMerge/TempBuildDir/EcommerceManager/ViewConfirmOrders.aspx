<%@ Page Title="" Language="C#" MasterPageFile="~/EcommerceManager/EcommerceManager.Master" AutoEventWireup="true" CodeBehind="ViewConfirmOrders.aspx.cs" Inherits="Ecommerce.EcommerceManager.ViewConfirmOrders" %>
<%@ Register src="UserControls/CtrlConfirmOrders.ascx" tagname="CtrlConfirmOrders" tagprefix="uc1" %>
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
    
    <uc1:CtrlConfirmOrders ID="CtrlConfirmOrders1" runat="server" />
    
</asp:Content>
