<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Default/OtherPages.Master" AutoEventWireup="true" CodeBehind="CartItems.aspx.cs" Inherits="Ecommerce.CartItems" %>
<%@ Register src="UserControls/CtrlCartItems.ascx" tagname="CtrlCartItems" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
    <uc1:CtrlCartItems ID="CtrlCartItems1" runat="server" />
</asp:Content>
