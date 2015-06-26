<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlProductsView.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.Products.CtrlProductsView" %>
<table class="ui-accordion">
            <tr>
                <td class="auto-style1" >
                    <label ID="Label1">Name</label>
                </td>
                <td class="auto-style1" >
                    <asp:TextBox ID="txtProductName"  Enabled="False" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" >
                    <label ID="Label2">Description</label>
                </td>
                <td class="auto-style1" >
                    <asp:TextBox ID="txtProductDescription" Enabled="False" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label ID="Label11">Purchased Price</label>
                </td>
                <td>
                    <asp:TextBox ID="txtPurchasedPrice" runat="server" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label ID="Label5">Unit Price</label>
                </td>
                <td>
                    <asp:TextBox ID="txtUnitPrice" runat="server" TextMode="Number" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label ID="Label6">Price Description</label>
                </td>
                <td>
                    <asp:TextBox ID="txtPriceDescription" runat="server" TextMode="MultiLine" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label id="Label7">
                    Stock</label></td>
                <td>
                     <asp:TextBox ID="txtInStock" runat="server" TextMode="Number" Enabled="False">0</asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <label ID="Label9">Sale</label></td>
                <td>
                    <asp:TextBox ID="txtSale" runat="server" TextMode="Number" Enabled="False">0</asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <label ID="Label3">Status</label>
                </td>
                <td>
                    <asp:RadioButtonList ID="rblIsActive" runat="server" DataTextField="Value" DataValueField="Key" Enabled="False">
                    </asp:RadioButtonList>
                </td>
            </tr>
           <tr>
                <td>
                    <label ID="Label10">Featured</label>
                </td>
                <td>
                    <asp:RadioButtonList ID="rblIsFeatured" runat="server" Enabled="False">
                        <asp:ListItem Value="1">Yes</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:RadioButtonList>
                    
                </td>
            </tr>
           <tr>
                <td>
                    <label ID="Label4">Brand</label>
                </td>
                <td>
                    <%-- <asp:DropDownList ID="ddlCategories" runat="server" ItemType="EcommerceDAL.Categories" SelectMethod="GetAllActiveCategories" DataValueField="CatId" DataTextField="CatHierarchy" OnPreRender="DddlCategoriesPreRender">--%>
                        <asp:DropDownList ID="ddlBrands" runat="server" DataValueField="BrandId" DataTextField="BrandName" Enabled="False">
                    </asp:DropDownList>
                    
                </td>
            </tr>
           <tr>
                <td>
                    <label ID="Label8">SalesTax</label>
                </td>
                <td>
                        <asp:DropDownList ID="ddlSalesTax" runat="server" DataValueField="SalesTaxId" DataTextField="SalesTaxSector" Enabled="False">
                    </asp:DropDownList>
                    
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>