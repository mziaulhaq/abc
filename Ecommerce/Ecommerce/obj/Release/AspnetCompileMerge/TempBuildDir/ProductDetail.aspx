<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Default/OtherPages.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="Ecommerce.ProductDetail" %>

<%@ Register Src="~/UserControls/CtrlAddCart.ascx" TagPrefix="uc1" TagName="CtrlCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
    <uc1:CtrlCart runat="server" ID="CtrlCart" />
</asp:Content>
