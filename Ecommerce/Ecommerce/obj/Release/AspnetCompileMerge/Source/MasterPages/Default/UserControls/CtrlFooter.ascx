<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlFooter.ascx.cs" Inherits="Ecommerce.UserControls.CtrlFooter" %>
<section class="clearall row-fluid paddingtwentyTop footerSection">
    <ul class="offset1 span2 listIconNone footerColor">
        <li>COMPANY INFO</li>
        <li class="paddingtwentyTop"><a href="Page.aspx?PId=0">About Us</a></li>
        <li><a href="Page.aspx?PId=1">Contact Us</a></li>
        <li><a href="Page.aspx?PId=2">Privacy Policy</a></li>
    </ul>
    <ul class="span2  listIconNone footerColor">
        <li>MY ACCOUNT</li>
        <li class="paddingtwentyTop"><a href="SignIn">Login / Register</a></li>
        <li><a href="CartItems.aspx">Shopping Cart</a></li>
        <li><a href="OrderStatus.aspx">Order Status</a></li>
    </ul>
    <ul class="span2  listIconNone footerColor">
        <li>SITE MAPS</li>
        <li class="paddingtwentyTop">About Us</li>
        <li>Contact Us</li>
        <li>Privacy Policy</li>
    </ul>
    <ul class="span2  listIconNone footerColor">
        <li>CUSTOMER SERVICE</li>
        <li class="paddingtwentyTop">Help</li>
        <li>Shipping & Deliveries</li>
        <li>Returns & Exchange</li>
    </ul>
    <table class="span2  listIconNone footerColor">
      <tr>
        <td class="paddingtwentyTop"><div class="navbar-search input-prepend btn-group">
                    <asp:TextBox type="text" placeholder="Enter Your Email" CssClass="btn" height="19px" Id="txtSearchValue" runat="server"/>
                    <asp:Button runat="server" ID="SearchClicked" CssClass="btn whiteColor BlueBackground" Text="Submit"></asp:Button>
                </div></td></tr><tr>
        <td style="text-align: center; padding-top: 10px;">&copy; <%= DateTime.Now.Year %> - Lahore Clothes Alright Reserved</td>
    </tr></table>
</section>