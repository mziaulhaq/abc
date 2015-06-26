<%@ Page Title="" Language="C#" MasterPageFile="~/EcommerceManager/EcommerceManager.Master" AutoEventWireup="true" CodeBehind="BrandsAddEdit.aspx.cs" Inherits="Ecommerce.EcommerceManager.BrandsAddEdit" %>
<%@ Register src="UserControls/CtrlBrandsAddEdit.ascx" tagname="ctrlBrandsAddEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
   
    <uc1:ctrlBrandsAddEdit ID="BrandsAddEdit1" runat="server" />
   
</asp:Content>
