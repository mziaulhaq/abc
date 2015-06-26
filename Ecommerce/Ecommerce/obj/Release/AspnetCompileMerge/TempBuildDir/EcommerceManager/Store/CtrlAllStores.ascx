<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAllStores.ascx.cs" Inherits="Ecommerce.EcommerceManager.Store.CtrlAllStores" %>
<%@ Import Namespace="Ecommerce.App_Start" %>

<div>
    <asp:GridView ID="gvdViewAllStores" runat="server" AutoGenerateColumns="False" CssClass="mytable" Width="100%" OnRowCommand="GvdViewAllStoresRowCommand">
        <Columns>
            <asp:TemplateField HeaderText="S.No">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Store Name" DataField="StoreName" />
            <asp:BoundField HeaderText="Domain" DataField="StoreDomainName" />
            <asp:TemplateField HeaderText="Status">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblStoreStatus" runat="server" Text='<%#UserControlFront.GetStoreStatusByBool(Convert.ToBoolean(Eval("StoreStatus"))) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Package">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblPackage" runat="server" Text='<%#UserControlFront.GetPackageNameById(Convert.ToInt32(Eval("PackageId"))) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField AccessibleHeaderText="Detail" HeaderText="Detail" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkDetail" runat="server" CausesValidation="False" CommandName="Detail" Text="Detail" CommandArgument='<%#Eval("StoreId") %>'></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete" CommandArgument='<%#Eval("StoreId") %>' Text="Delete" OnClientClick="return confirm('Are you sure to delete the store?')"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
