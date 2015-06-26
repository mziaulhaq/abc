<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Default/CMSPages.Master" AutoEventWireup="true" CodeBehind="COStart.aspx.cs" Inherits="Ecommerce.COStart" %>

<%@ Register Src="~/UserControls/CheckOutStart.ascx" TagPrefix="uc1" TagName="CheckOutStart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
    <uc1:CheckOutStart runat="server" id="CheckOutStart" />
    
    <script type="text/javascript">
        $(function () {
            $('#txtDOB').datepicker({
                changeMonth: true,
                changeYear: true
            });
        });
</script>
</asp:Content>
