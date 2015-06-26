<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Default/Index.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Ecommerce.Index" %>

<%@ Import Namespace="System.Linq" %>

<%@ Register Src="~/MasterPages/Default/UserControls/CtrlFooter.ascx" TagPrefix="uc1" TagName="CtrlFooter" %>
<%@ OutputCache Duration="60" VaryByParam="None" Location="Server" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content runat="server" ID="MainContents" ContentPlaceHolderID="Contents">


    <%--            <asp:Panel ID="pnlCategories" runat="server" Width="100%" Style="margin: 0px">
            </asp:Panel>--%>

    <div class="clearall row-fluid whitebackground">
        <div class="offset1 well span10 whitebackground " style="border: 1px solid #999">
            <ul class="bxslider" style="margin: 0px auto; height: 140px">
                <asp:ListView runat="server" ID="lvBrands">
                    <ItemTemplate>
                        <li class="pull-left" >
                            <asp:HyperLink runat="server" NavigateUrl='<%# BrandsUrlWithBrandId(Eval("BrandId").ToString()) %>'>
                            <asp:Image runat="server" ImageUrl='<%# BindBrands(Eval("BrandImage").ToString()) %>'  Width="312" Height="140px"/>
                            </asp:HyperLink>
                        </li>
                    </ItemTemplate>
                </asp:ListView>
            </ul>
        </div>
        <%--<div class="clearall"></div>--%>
    </div>
    <section class="clearall row-fluid whitebackground">
        <article class="offset1 well contentArticle span10">
            <p class="commontitle Red LargeFont marginBottomTwenty">Latest Products</p>
            <div class="controls-row">
                <asp:ListView runat="server" ID="lvLatestProducts" OnItemCommand="LvFeaturedProductsItemCommand">
                    <ItemTemplate>
                        <div class="span3 text-center productDisplayBorder">
                            <div class="PositionRelative">
                                <asp:HyperLink runat="server" NavigateUrl='<%# string.Format("~/ProductDetail.aspx?PId={0}",Eval("ProductId").ToString()) %>'>
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# BindProducts(Eval("ProductImage").ToString()) %>' AlternateText="image" CssClass="table-bordered productImageSize" />
                                </asp:HyperLink>
                                <asp:Label runat="server" CssClass="OverLaySpan" ID="lblPrice" Text='<%# string.Format("Rs:{0}",Math.Round(Convert.ToDecimal(Eval("ProductUnitPrice")),0)) %>'>
                                </asp:Label>
                            </div>
                            <div>
                                <asp:HyperLink runat="server" ID="HyperLink1" NavigateUrl='<%# string.Format("~/ProductDetail.aspx?PId={0}",Eval("ProductId").ToString()) %>' Text='<%#Eval("BrandName") %>' CssClass="productNameAndPrice productBrand"></asp:HyperLink>
                            </div>
                            <div>
                                <div>
                                    <asp:HyperLink runat="server" ID="lnkProductName" NavigateUrl='<%# string.Format("~/ProductDetail.aspx?PId={0}",Eval("ProductId").ToString()) %>' Text='<%#Eval("ProductName").ToString().Length>20?String.Concat(Eval("ProductName").ToString().Substring(0,20),"..."):Eval("ProductName").ToString() %>' CssClass="productNameAndPrice"></asp:HyperLink>
                                </div>
                                <div>
                                    <asp:HyperLink ID="Button1" NavigateUrl='<%# string.Format("~/ProductDetail.aspx?PId={0}",Eval("ProductId").ToString()) %>' CssClass="InlineBlock btn-success btn-info btn ShopNow" Text="Shop Now!" runat="server" />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
            <p class="commontitle Red LargeFont marginTopTwenty marginBottomTwenty">Featured Products</p>
            <div class="productDisplayMarginTop">
                <asp:ListView runat="server" ID="lvFeaturedProducts" OnItemCommand="LvFeaturedProductsItemCommand">
                    <ItemTemplate>
                        <div class="span3 text-center productDisplayBorder">
                            <div class="PositionRelative">
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# BindProducts(Eval("ProductImage").ToString()) %>' AlternateText="image" CssClass="table-bordered productImageSize" />
                                <asp:Label runat="server" CssClass="OverLaySpan" ID="lblPrice" Text='<%# string.Format("Rs:{0}",Math.Round(Convert.ToDecimal(Eval("ProductUnitPrice").ToString()),0)) %>'>
                                </asp:Label>
                            </div>
                            <div>
                                <asp:HyperLink runat="server" ID="HyperLink1" NavigateUrl='<%# string.Format("~/ProductDetail.aspx?PId={0}",Eval("ProductId").ToString()) %>' Text='<%#Eval("BrandName") %>' CssClass="productNameAndPrice productBrand"></asp:HyperLink>
                            </div>
                            <div>
                                <div>
                                    <asp:HyperLink runat="server" ID="lnkProductName" NavigateUrl='<%# string.Format("~/ProductDetail.aspx?PId={0}",Eval("ProductId").ToString()) %>' Text='<%#Eval("ProductName").ToString().Length>20?String.Concat(Eval("ProductName").ToString().Substring(0,20),"..."):Eval("ProductName").ToString() %>' CssClass="productNameAndPrice"></asp:HyperLink>
                                </div>
                                <div>
                                    <asp:HyperLink ID="Button1" NavigateUrl='<%# string.Format("~/ProductDetail.aspx?PId={0}",Eval("ProductId").ToString()) %>' CssClass="InlineBlock btn-success btn-info btn ShopNow" Text="Shop Now!" runat="server" />
                                </div>
                            </div>

                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </article>
        <div class="clearall"></div>
    </section>

    <footer>
        <uc1:CtrlFooter runat="server" ID="CtrlFooter" />
    </footer>
    <script src="Scripts/jquery.bxslider.min.js"></script>
    <script type="text/javascript">
        $('.bxslider').bxSlider({
            minSlides: 3,
            maxSlides: 8,
            slideWidth: 312,
            slideMargin: 10,
            pager: false
        });</script>
</asp:Content>
