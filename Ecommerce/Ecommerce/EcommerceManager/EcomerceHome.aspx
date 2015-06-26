<%@ Page Title="" Language="C#" MasterPageFile="~/EcommerceManager/EcommerceManager.Master" AutoEventWireup="true" CodeBehind="EcomerceHome.aspx.cs" Inherits="Ecommerce.EcommerceManager.EcomerceHome" %>

<%@ Register Src="~/EcommerceManager/UserControls/DashBoard/CtrlAdminDashBoard.ascx" TagPrefix="uc1" TagName="CtrlAdminDashBoard" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <%--<div style="border-style: solid; border-color: inherit; border-width: 2px; float: left; width: 12%; height: 85px;font-size: 15px">--%>
            Online Users :
        <asp:Label runat="server" ID="lblUserCount"></asp:Label>
        <%--</div>--%>
        <div style="clear: both;"></div>
        <div style="float: left">
            <uc1:CtrlAdminDashBoard runat="server" ID="CtrlAdminDashBoard" />
        </div>
    </div>
</asp:Content>
