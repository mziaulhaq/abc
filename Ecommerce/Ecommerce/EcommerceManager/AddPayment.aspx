<%@ Page Title="" Language="C#" MasterPageFile="~/EcommerceManager/EcommerceManager.Master" AutoEventWireup="true" CodeBehind="AddPayment.aspx.cs" Inherits="Ecommerce.EcommerceManager.AddPayment" %>

<%@ Register Src="~/EcommerceManager/Store/CtrlAddPayment.ascx" TagPrefix="uc1" TagName="CtrlAddPayment" %>

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
    <script type="text/javascript">

        function ValidateDatesDifference(sender, args) {
            var dtFrom = $('#dtFrom');
            var dtTo = $('#dtTo');
            if (dtFrom.val() == '' && dtTo.val() == '') {
                args.IsValid = false;
                sender.errormessage = "Must provide at least one date";
            }
            else if (dtFrom.val() != '' && dtTo.val()) {
                var dateFrom = new Date(dtFrom.val());
                var dateTo = new Date(dtTo.val());
                if (dateFrom < dateTo) {
                    args.IsValid = true;
                } else {
                    args.IsValid = false;
                    sender.errormessage = "Date From must be less than Date To";
                }
            } else {
                args.IsValid = true;
            }


        }
</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlAddPayment runat="server" id="CtrlAddPayment" />
</asp:Content>
