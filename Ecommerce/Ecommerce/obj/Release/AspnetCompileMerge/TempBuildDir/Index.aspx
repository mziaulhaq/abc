<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Default/Index.Master" AutoEventWireup="true"  CodeBehind="Index.aspx.cs" Inherits="Ecommerce.Index"%>

<%@ Register Src="~/MasterPages/Default/UserControls/CtrlFooter.ascx" TagPrefix="uc1" TagName="CtrlFooter" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content runat="server" ID="MainContents" ContentPlaceHolderID="Contents">
    <section class="clearall row-fluid whitebackground paddingtwentyTop">
        <article class="offset1 well leftArticle span2 hidden-phone">
            <p class="Red text-center LargeFont">Categories</p>
            <ul class="unstyled CategoryLists">
                <asp:ListView runat="server" ID="lvCategories">
                    <ItemTemplate>
                      <li><a href="ProductsInCategories.aspx?CatId=<%# Eval("CatId") %>"><%# Eval("CatName") %></a></li>  
                    </ItemTemplate>
                </asp:ListView>
            </ul>
        </article>
        <article class="well contentArticle span8">
            <p class="commontitle Red LargeFont marginBottomTwenty">Latest Products</p>
            <div class="controls-row">
                <asp:ListView runat="server" ID="lvLatestProducts"  OnItemCommand="LvFeaturedProductsItemCommand">
                    <ItemTemplate>
                        <div class="span3 text-center">
                            <div class="PositionRelative">
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# BindProducts(Eval("ProductImage").ToString()) %>' AlternateText="image" CssClass="table-bordered" />
                                 <asp:Label runat="server" CssClass="OverLaySpan" ID="lblPrice" Text='<%# string.Format("Rs:{0}",Eval("ProductUnitPrice").ToString()) %>'>
                            </asp:Label>
                           </div> 
                            <asp:HyperLink ID="Button1" NavigateUrl='<%# string.Format("~/ProductDetail.aspx?PId={0}",Eval("ProductId").ToString()) %>' CssClass="InlineBlock btn-success btn-info btn ShopNow" Text="Shop Now!" runat="server" />
                           
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
            <p class="commontitle Red LargeFont marginTopTwenty marginBottomTwenty">Featured Products</p>
            <div class="controls-row">
                 <asp:ListView runat="server" ID="lvFeaturedProducts" OnItemCommand="LvFeaturedProductsItemCommand">
                    <ItemTemplate>
                        <div class="span3 text-center">
                            <div class="PositionRelative">
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# BindProducts(Eval("ProductImage").ToString()) %>' AlternateText="image" CssClass="table-bordered" />
                                 <asp:Label runat="server" CssClass="OverLaySpan" ID="lblPrice" Text='<%# string.Format("Rs:{0}",Eval("ProductUnitPrice").ToString()) %>'>
                            </asp:Label>
                           </div> 
                           <asp:HyperLink ID="Button1" NavigateUrl='<%# string.Format("~/ProductDetail.aspx?PId={0}",Eval("ProductId").ToString()) %>' CssClass="InlineBlock btn-success btn-info btn ShopNow" Text="Shop Now!"  runat="server"/>
                           
                        </div>
                    </ItemTemplate>
                </asp:ListView>
               </div>
        </article>
        <div class="clearall"></div>
    </section>
    <div class="clearall row-fluid whitebackground">
        <div class="navbar well span10 offset1 whitebackground hidden-phone">
            <p class="Blue LargeFont commontitle">Top Brands</p>
           <ul class="bxslider">
            <asp:ListView runat="server" ID="lvBrands">
                <ItemTemplate>
                    <li class="pull-left marginOfTen">
                        <asp:HyperLink runat="server" NavigateUrl='<%# BrandsUrlWithBrandId(Eval("BrandId").ToString()) %>'>
                                    <asp:Image runat="server" ImageUrl='<%# BindBrands(Eval("BrandImage").ToString()) %>' />
                        </asp:HyperLink>

                    </li>
                </ItemTemplate>
            </asp:ListView>
               </ul>
        </div>
        <div class="clearall"></div>
    </div>
    <footer>
        <uc1:CtrlFooter runat="server" id="CtrlFooter" />
    </footer>
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
