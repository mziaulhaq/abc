<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlFooter.ascx.cs" Inherits="Ecommerce.UserControls.CtrlFooter" %>
<section class="clearall row-fluid paddingtwentyTop footerSection">
    <ul class="offset1 span2 listIconNone footerColor">
        <li>COMPANY INFO</li>
        <li class="paddingtwentyTop"><a href="Page.aspx?PId=0">About Us</a></li>
        <li><a href="Page.aspx?PId=2">Contact Us</a></li>
        <li><a href="Page.aspx?PId=3">Privacy Policy</a></li>
    </ul>
    <ul class="span2  listIconNone footerColor">
        <li>MY ACCOUNT</li>
        <li class="paddingtwentyTop"><a href="SignIn">Login / Register</a></li>
        <li><a href="CartItems.aspx">Shopping Cart</a></li>
        <li><a href="OrderStatus.aspx">Order Status</a></li>
    </ul>
    <ul class="span2  listIconNone footerColor">
        <li>SITE MAPS</li>
        <li class="paddingtwentyTop"><a href="Page.aspx?PId=0">About Us</a></li>
        <li><a href="Page.aspx?PId=2">Contact Us</a></li>
        <li><a href="Page.aspx?PId=3">Privacy Policy</a></li>
    </ul>
    <ul class="span2  listIconNone footerColor">
        <li>CUSTOMER SERVICE</li>
        <li class="paddingtwentyTop"><a href="Page.aspx?PId=4">Help</a></li>
        <li><a href="Page.aspx?PId=5">Shipping & Deliveries</a></li>
        <li><a href="Page.aspx?PId=6">Returns & Exchange</a></li>
    </ul>
    <ul class="span2  listIconNone footerColor">
        <li>JOIN US ON</li>
        <li style="padding-left: 25px"><a href="https://www.facebook.com/lahoreclothisb">
            <img src="../../ContentV2/img/facebook.png" /></a></li>
        <li style="padding-left: 25px"><a href="https://twitter.com/lahorecloth">
            <img src="../../ContentV2/img/twitter.png" /></a></li>
        <li style="padding-left: 25px"><a href="#">
            <img src="../../ContentV2/img/linkedin.png" /></a></li>
    </ul>
    <table class="span2  listIconNone footerColor">
        <tr>
            <td class="paddingtwentyTop">
                <div class="navbar-search input-prepend btn-group">
                    <asp:TextBox type="text" placeholder="Enter Your Email" CssClass="btn" Height="19px" ID="txtSearchValue" runat="server" />
                    <asp:Button runat="server" ID="SearchClicked" CssClass="btn whiteColor BlueBackground" Text="Submit"></asp:Button>
                </div>
            </td>
        </tr>
        <tr>
            <td style="text-align: center; padding-top: 10px;">&copy; <%= DateTime.Now.Year %> - Lahore Clothes Alright Reserved</td>
        </tr>
    </table>
</section>
