<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCustomers.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.CtrlCustomers" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }

    .subheader {
        font-size: 14px;
        font-family: sans-serif;
        font-weight: bold;
        text-decoration: underline;
    }
</style>
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

<table class="ui-accordion">
    <tr>
        <td>
            <table class="auto-style1">
                <tr>
                    <td>Name</td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" ClientIDMode="Static"></asp:TextBox>
                    </td>
                    <td>
                        <%--<asp:CustomValidator ID="cvDateCheck" runat="server" ClientValidationFunction="ValidateDatesDifference" ForeColor="Red" ValidationGroup="OrdersSearch" OnServerValidate="cvDateCheck_ServerValidate">*</asp:CustomValidator>--%>
                    </td>
                    <td>Date Added</td>
                    <td>
                        <asp:TextBox ID="dtRegistrationDate" runat="server" ClientIDMode="Static"></asp:TextBox>
                    </td>
                    <td>

                        <%--<asp:ImageButton ID="IBSearch" runat="server" ImageUrl="~/Images/search.png" Height="32px" Width="32px" OnClick="OrdersSearchedClicked" ValidationGroup="OrdersSearch" />--%>
                    </td>
                    <td>

                        <%--<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="OrdersSearch" />--%>
                    </td>
                </tr>
                <tr>
                    <td>Email</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" ClientIDMode="Static"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>Status</td>
                    <td>
                        <asp:DropDownList ID="drpCustomerStatusSearch" runat="server">
                            <asp:ListItem Value="-1">--Select--</asp:ListItem>
                            <asp:ListItem Value="1">Enabled</asp:ListItem>
                            <asp:ListItem Value="0">Disabled</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">&nbsp;</td>
                    <td>
                        <i aria-hidden="true" class="glyphicon glyphicon-search">
                            <asp:Button ID="btnSearch" runat="server" Text="Filter" Width="125px" CssClass="btn btn-info btn-large" OnClick="CustomerSearchedClicked"></asp:Button></i>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </td>
    </tr>

    <tr>
        <td style="overflow-x: scroll" align="center">
            <asp:GridView ID="gdvCustomers" runat="server" AutoGenerateColumns="False" CssClass="mytable" AllowPaging="True" PageSize="25" Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="S.No">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# GridViewRowNumberApplication(Container.DataItemIndex + 1,gdvCustomers.PageIndex,gdvCustomers.PageSize) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="30px" Wrap="False" />
                    </asp:TemplateField>

                    <asp:BoundField DataField="FirstName" HeaderText="Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="TelephoneNumber" HeaderText="Telephone" />
                    <asp:BoundField DataField="MobileNumber" HeaderText="Mobile " />
                    <asp:BoundField DataField="RegistrationDate" HeaderText="Registered On" DataFormatString="{0:d}"/>
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Label ID="OrderStatusLabel" runat="server" Text='<%# EcommerceUtilities.Utility.ReturnStatusEnabledOrDisabled(Convert.ToInt32(Eval("Status"))) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:CommandField SelectText="Details" ShowSelectButton="True" />--%>
                </Columns>
            </asp:GridView>

            <br />

        </td>
    </tr>

</table>






