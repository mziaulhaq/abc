<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlProductDynamicPropertiesView.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.Products.CtrlProductDynamicPropertiesView" %>



<table class="ui-accordion">
            <tr>
                <td><label> Dynamic Properties </label></td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GdvDynamicCategories" runat="server" Width="100%" AutoGenerateColumns="False" CssClass="mytable" DataKeyNames="PDAId">
                        <Columns>
                            <asp:TemplateField HeaderText="Category Name">
                                <EditItemTemplate>
                                    <asp:Label ID="TextBox2" runat="server" Text='<%# Bind("PCDName") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("PCDName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Category Value">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPdCValue" runat="server" Text='<%# Bind("PDCValue") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("PDCValue") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>

