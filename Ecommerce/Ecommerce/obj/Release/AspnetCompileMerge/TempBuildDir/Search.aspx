<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Default/OtherPages.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Ecommerce.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
    <p class="commontitle Red LargeFont marginBottomTwenty">Products Falls in this Category</p>
    
    
    
    <div class="controls-row">
                <asp:ListView runat="server" ID="lvLatestProducts" >
                    <ItemTemplate>
                        <div class="span3 text-center">
                            <div class="PositionRelative">
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# BindProducts(Eval("ProductImage"),Convert.ToInt64(Eval("ProductId"))) %>' AlternateText="image" CssClass="table-bordered" />
                                 <asp:Label runat="server" CssClass="OverLaySpan" ID="lblPrice" Text='<%# string.Format("Rs:{0}",Eval("ProductUnitPrice").ToString()) %>'>
                            </asp:Label>
                           </div> 
                           <asp:HyperLink ID="Button1" NavigateUrl='<%# string.Format("~/ProductDetail?PId={0}",Eval("ProductId").ToString()) %>' class="InlineBlock btn-success btn-info btn ShopNow" Text="Shop Now!"  runat="server"/>
                           
                        </div>
                    </ItemTemplate>
                </asp:ListView>
        <label id="lblError" runat="server" Visible="False"> No Data Found Regarding Your Search Query </label>
        </div>
     
    <div style="border-top: 1px solid green;text-align: center">
            <asp:Repeater ID="rptPagination" runat="server">
                <HeaderTemplate>
                    <table>
                        <tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <div style="padding: 4px;display: inline;text-align: center;">
                        <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
            Enabled='<%# EnableDisablePageNumber(Eval("Value").ToString()) %>' CssClass='<%# EnableDisablePageNumber(Eval("Value").ToString())?"EnablePagingHyperLink":"DisablePagingHyperLink" %>' OnClick="PageIndexChanged" OnClientClick='<%# EnableDisablePageNumber(Eval("Value").ToString())? "return true;" : "return false;" %>'></asp:LinkButton>
                        

                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    </tr>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    
    
    
    
    

            <%--<div class="controls-row">
                <asp:ListView runat="server" ID="lvLatestProducts">
                    <ItemTemplate>
                        <div class="span3 text-center">
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# BindProducts(Eval("ProductImage").ToString()) %>' AlternateText="image" CssClass="table-bordered" />
                            <a href="#" class="inline btn-success btn-info btn ShopNow">Shop Now!</a>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>--%>
</asp:Content>
