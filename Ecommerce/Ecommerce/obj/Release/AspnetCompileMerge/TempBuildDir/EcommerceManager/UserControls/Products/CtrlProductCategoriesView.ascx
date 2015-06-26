<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlProductCategoriesView.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.Products.CtrlProductCategoriesView" %>
<table class="ui-accordion">
            <tr>
                <td><label>Categories</label></td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gdvProductToCategories" runat="server"  AutoGenerateColumns="False" DataKeyNames="PCId" CssClass="mytable" Width="100%">
                        <Columns>
                            <asp:BoundField HeaderText="Category" DataField="CatHierarchy" >
                            <ItemStyle Width="250px" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>