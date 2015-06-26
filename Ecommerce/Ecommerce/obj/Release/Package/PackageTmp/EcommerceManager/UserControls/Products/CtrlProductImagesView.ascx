<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlProductImagesView.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.Products.CtrlProductImagesView" %>

<table class="ui-accordion">
    <tr>
        <td class="auto-style1"><label> Images </label></td>
    </tr>
    <tr>
        <td class="auto-style1">
            
            <asp:GridView ID="gdvImages" runat="server" AutoGenerateColumns="False" CssClass="mytable" ShowHeader="False" >
                <Columns>
                    <asp:TemplateField InsertVisible="False">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" Target="_blank" runat="server" NavigateUrl='<%# PathUrl(Eval("ImagePathLarge").ToString()) %>'>
                                <asp:Image runat="server" ImageUrl='<%# PathUrl(Eval("ImagePathThumbNail").ToString()) %>' AlternateText="Image"/>
                            </asp:HyperLink>
                        </ItemTemplate>
                        <HeaderStyle CssClass="GrdFirstHeader" />
                    </asp:TemplateField>
                </Columns>
                <RowStyle CssClass="trInline" />
            </asp:GridView>
          
            <asp:ListView ID="ListView1" runat="server">
            <ItemTemplate>
                    
            </ItemTemplate>
            </asp:ListView>
            <br />
          
        </td>
    </tr>
</table>


