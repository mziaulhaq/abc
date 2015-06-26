<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Default/CMSPages.Master" AutoEventWireup="true" CodeBehind="CheckoutComplete.aspx.cs" Inherits="Ecommerce.Checkout.CheckoutComplete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contents" runat="server">

    <h1>Checkout Complete</h1>
    <p></p>
    <h3>Payment Transaction ID:</h3>
    <asp:Label ID="TransactionId" runat="server"></asp:Label>
    <p></p>
    <h3>Thank You!</h3>
    <p></p>
    <hr />
    <asp:Button ID="Continue" runat="server" Text="Continue Shopping" OnClick="Continue_Click" />

</asp:Content>
