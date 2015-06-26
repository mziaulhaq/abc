<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Default/OtherPages.Master" AutoEventWireup="true" CodeBehind="OrderStatus.aspx.cs" Inherits="Ecommerce.OrderStatus" %>

<%@ Register Src="~/UserControls/CtrlOrderStatus.ascx" TagPrefix="uc1" TagName="CtrlOrderStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
    <uc1:CtrlOrderStatus runat="server" ID="CtrlOrderStatus" />
</asp:Content>
