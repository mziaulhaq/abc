<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlViewAllProduct.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.Products.CtrlViewAllProduct" %>

<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
</style>

<table  class="ui-accordion">
    <tr>
        <td>
            <table class="auto-style1">
                <tr>
                    <td>
                       <label>Name</label> </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" Width="95%"></asp:TextBox>
                    </td>
                    <td>
                        <label>Category</label> </td>
                    <td>
                    <asp:DropDownList ID="ddlCategory" runat="server" DataTextField="CatName" DataValueField="CatId" Width="100%">
                    </asp:DropDownList>
                    </td>
                    <td>
                        <label style="text-wrap: none;">Dynamic Category</label> </td>
                    <td>
                        <asp:DropDownList ID="ddlDynamicCategory" runat="server" DataTextField="PCDName" DataValueField="PDCId" Width="100%">
                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Status</label></td>
                    <td>
                    <asp:DropDownList ID="ddlIsActive" runat="server" DataTextField="Value" DataValueField="Key" Width="100%">
                    </asp:DropDownList>
                    </td>
                    <td>
                        <label>Featured</label></td>
                    <td>
                    <asp:DropDownList ID="ddlIsFeatured" runat="server" Width="100%">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem Value="1">True</asp:ListItem>
                        <asp:ListItem Value="0">False</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                    <td>
                        <label>Gender</label></td>
                    <td>
                    <asp:DropDownList ID="ddlGender" runat="server" DataTextField="GenderCatName" DataValueField="GenderCatId" Width="100%">
                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><label>Color</label></td>
                    <td>
                     <asp:DropDownList ID="ddlColor" runat="server" DataTextField="ColorName" DataValueField="ColorId" Width="100%">
                    </asp:DropDownList>
                    </td>
                    <td>
                        <asp:ImageButton ID="IBSearch" runat="server" ImageUrl="~/Images/search.png" OnClick="IBSearchClick" Height="32px" Width="32px" />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </td>
    </tr>
    
    <tr>
       <td style="overflow-x: scroll;text-align: center">
             <asp:GridView ID="gdvProductToCategories" runat="server"  AutoGenerateColumns="False" DataKeyNames="ProductID" CssClass="mytable">
                        <Columns>
                            <asp:BoundField HeaderText="S.No" DataField="RowNumber" >
                            <ItemStyle Width="30px" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Product Name" DataField="ProductName" >
                            <ItemStyle Width="150px" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Unit Price" DataField="ProductUnitPrice">
                            <ItemStyle Width="150px" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ProductInStock" HeaderText="Stock">
                            <ItemStyle Width="150px" Wrap="False" />
                            </asp:BoundField>
                            <asp:HyperLinkField DataNavigateUrlFields="ProductId" DataNavigateUrlFormatString="~/EcommerceManager/ProductView.aspx?PId={0}" Target="_blank" Text="View" >
                            <ItemStyle Width="100px" Wrap="False" />
                            </asp:HyperLinkField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemStyle Width="100px" Wrap="False"></ItemStyle>                                
                               <ItemTemplate>
                                   <asp:HyperLink runat="server" ID="hlEditProduct" NavigateUrl='<%# ProductEditLink(Eval("ProductId").ToString()) %>'>
                                    <asp:Image ID="lnkEdit" runat="server" ImageUrl="../../../Images/Gridicons/edit.png"  Width="24px" Height="24px"></asp:Image>
                                       <%--CausesValidation="False"--%>
                                   </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField>
                                <ItemStyle Width="100px" Wrap="False"></ItemStyle>
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl=<%# HomeEditBannerLink(Eval("ProductId").ToString()) %> Text="">
                                        <asp:Image runat="server" ID="imgBanner" ImageUrl="../../../Images/Gridicons/bnner.png"/>
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            </Columns>
             </asp:GridView>
        </td>
    </tr>
    <tr>
        <td  runat="server" id="paginationRow"><%--align="center"--%>
            <asp:Repeater ID="rptPagination" runat="server">
                <HeaderTemplate>
                    <table>
                        <tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <td style="padding: 4px">
                        <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
            Enabled='<%# EnableDisablePageNumber(Eval("Value").ToString()) %>' CssClass='<%# EnableDisablePageNumber(Eval("Value").ToString())?"EnablePagingHyperLink":"DisablePagingHyperLink" %>' OnClick="PageIndexChanged" OnClientClick='<%# EnableDisablePageNumber(Eval("Value").ToString())? "return true;" : "return false;" %>'></asp:LinkButton>
                        

                    </td>
                </ItemTemplate>
                <FooterTemplate>
                    </tr>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
          </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
</table>


 