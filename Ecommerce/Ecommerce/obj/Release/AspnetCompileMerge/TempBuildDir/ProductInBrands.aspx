<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Default/OtherPages.Master" AutoEventWireup="true" CodeBehind="ProductInBrands.aspx.cs" Inherits="Ecommerce.ProductInBrands" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Content/jquery.bxslider.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
    
     <p class="commontitle Red LargeFont marginBottomTwenty">Products Falls in this Brand</p>
    
    
    
    <div class="controls-row">
                <asp:ListView runat="server" ID="lvLatestProducts" >
                    <ItemTemplate>
                        <div class="span3 text-center">
                            <div class="PositionRelative">
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# BindProducts(Eval("ProductImage"),long.Parse(Eval("ProductId").ToString())) %>' AlternateText="image" CssClass="table-bordered" />
                                 <asp:Label runat="server" CssClass="OverLaySpan" ID="lblPrice" Text='<%# string.Format("Rs:{0}",Eval("ProductUnitPrice").ToString()) %>'>
                            </asp:Label>
                           </div> 
                           <asp:HyperLink ID="Button1" NavigateUrl='<%# string.Format("~/ProductDetail?PId={0}",Eval("ProductId").ToString()) %>' class="InlineBlock btn-success btn-info btn ShopNow" Text="Shop Now!"  runat="server"/>
                           
                        </div>
                    </ItemTemplate>
                </asp:ListView>
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
    <div style="margin-top: 20px">
        <p class="Blue LargeFont commontitle">Top Brands</p>
        <ul class="bxslider">
            <asp:ListView runat="server" ID="lvBrands">
                <ItemTemplate>
                    <li class="pull-left marginOfTen">
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# BrandsUrlWithBrandId(Eval("BrandId").ToString()) %>'>
                                    <asp:Image ID="Image2" runat="server" ImageUrl='<%# BindBrands(Eval("BrandImage").ToString()) %>' />
                        </asp:HyperLink>

                    </li>
                </ItemTemplate>
            </asp:ListView>
               </ul>
    </div>
     <script src="Scripts/jquery.bxslider.min.js"></script>
    <script type="text/javascript">
        $('.bxslider').bxSlider({
            minSlides: 3,
            maxSlides: 8,
            slideWidth: 120,
            slideMargin: 10,
            pager: false

        });</script>
</asp:Content>
