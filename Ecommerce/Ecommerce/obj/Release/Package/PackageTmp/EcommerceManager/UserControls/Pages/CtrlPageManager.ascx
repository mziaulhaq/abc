<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPageManager.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.Pages.CtrlPageManager" %>
<style type="text/css">
    .scroll {
        display: block;
        overflow-y: scroll;
        height: 100px;
    }
</style>
<%@ Import Namespace="EcommerceUtilities" %>
<div>
    
    <asp:GridView ID="gdvPages" runat="server" AutoGenerateColumns="False" DataKeyNames="PageId" Width="100%" CssClass="mytable">
        <Columns>
            <asp:BoundField DataField="PageName" HeaderText="PageName" ReadOnly="True" SortExpression="PageName" >
                <ControlStyle Width="10%" />
                <ItemStyle Width="10%" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Details" SortExpression="Details">
               <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Details") %>' CssClass="scroll"></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="100%" />
                <ItemStyle Width="100%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status" SortExpression="Status">
               <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# EnablingAndDisabling.EnableDisableLiteral(Convert.ToBoolean(Eval("Status"))) %>' ></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="5%" />
                 <ItemStyle Width="5%" />
            </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="PageId" DataNavigateUrlFormatString="~/EcommerceManager/AddEditPages.aspx?PId={0}" HeaderText="Edit" Text="Edit" >
                <ControlStyle Width="5%" />
                 <ItemStyle Width="5%" />
            </asp:HyperLinkField>
        </Columns>
    </asp:GridView>
    
</div>