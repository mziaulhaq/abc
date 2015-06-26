<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Default/OtherPages.Master" AutoEventWireup="true" CodeBehind="ProductsInCategories.aspx.cs" Inherits="Ecommerce.ProductsInCategories" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="ContentSearchProduct" ContentPlaceHolderID="contentSearch" runat="server">
    <p class="Red text-center LargeFont"><span class="glyphicon glyphicon-search"></span>Search Here...</p>

    <%--Brand Selection--%>
    <div class="outerDivSearch">
        <p class="text-center LargeFont" style="text-align: left">-Brand</p>
        <div class="scrollingDiv">
            <ul class="unstyled CategoryLists" style="height: 80px">
                <asp:CheckBoxList runat="server" ID="cbListBrand" DataTextField="BrandName" DataValueField="BrandId" Height="162px" RepeatDirection="Vertical" RepeatLayout="Flow" TextAlign="Right">
                </asp:CheckBoxList>
            </ul>
        </div>
    </div>

    <%--Color Selection--%>
    <div class="outerDivSearch">
        <p class="text-center LargeFont" style="text-align: left">-Color</p>
        <div class="scrollingDiv">
            <ul class="unstyled CategoryLists" style="height: 80px">
                <asp:CheckBoxList runat="server" ID="cbListColor" DataTextField="ColorName" DataValueField="ColorId" Height="162px" RepeatDirection="Vertical" RepeatLayout="Flow" TextAlign="Right">
                </asp:CheckBoxList>
            </ul>
        </div>
    </div>

    <%--Price Range Selection--%>
    <div class="outerDivSearch">
        <p class="text-center LargeFont" style="text-align: left">-Price Range</p>
        <div class="scrollingDiv">
            <div style="float: left;">
                <ew:NumericBox id="txtMinPrice" runat="server" placeholder="Min" width="62px">
                                </ew:NumericBox>
            </div>
            <div style="float: left; margin-left: 5px">
                <ew:Numericbox id="txtMaxPrice" runat="server" placeholder="Max" width="62px">
                                </ew:Numericbox>
            </div>
        </div>
    </div>

    <%--Metarial Selection--%>
    <div class="outerDivSearch">
        <p class="text-center LargeFont" style="text-align: left">-Metarial</p>
        <div class="scrollingDiv">
            <ul class="unstyled CategoryLists" style="height: 80px">
                <asp:CheckBoxList runat="server" ID="cbListMetarial" DataTextField="MaterialName" DataValueField="meterialId" Height="162px" RepeatDirection="Vertical" RepeatLayout="Flow" TextAlign="Right">
                </asp:CheckBoxList>
            </ul>
        </div>
    </div>

    <%--Type Selection--%>
    <div class="outerDivSearch">
        <p class="text-center LargeFont" style="text-align: left">-Type</p>
        <div class="scrollingDiv">
            <ul class="unstyled CategoryLists" style="height: 80px">
                <asp:CheckBoxList runat="server" ID="cbListType" DataTextField="ProductType" DataValueField="CatId" Height="162px" RepeatDirection="Vertical" RepeatLayout="Flow" TextAlign="Right">
                </asp:CheckBoxList>
            </ul>
        </div>
    </div>

    <%--Gender Selection--%>
    <div class="outerDivSearch">
        <p class="text-center LargeFont" style="text-align: left">-Gender</p>
        <div class="scrollingDiv" style="padding-bottom: 0px">
            <ul class="unstyled CategoryLists" style="height: 55px">
                <asp:CheckBoxList runat="server" ID="cbListGender" Height="65px" RepeatDirection="Vertical" RepeatLayout="Flow" TextAlign="Right" DataTextField="ProductGender" DataValueField="GenderCatId">
                </asp:CheckBoxList>
            </ul>
        </div>
    </div>

    <%--Submit Search Here--%>

    <asp:Button runat="server" ID="btnSubmitSearch" Text="Submit Search" CssClass="InlineBlock btn-success btn-info btn SearchButton" OnClick="btnSubmitSearch_Click" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
    <div style="border-bottom: 1px solid green; margin-bottom: 20px">
        <p class="commontitle Red LargeFont marginBottomTwenty">Product fall in <%=CategoryName%></p>
        <%=CategoryDesc %>
    </div>


    <div class="controls-row">
        <asp:ListView runat="server" ID="lvLatestProducts">
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

    <div style="text-align: center; margin-top: 15px">
        <asp:Repeater ID="rptPagination" runat="server">
            <HeaderTemplate>
                <table>
                    <tr>
            </HeaderTemplate>
            <ItemTemplate>
                <div style="padding: 4px; display: inline; text-align: center;">
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
