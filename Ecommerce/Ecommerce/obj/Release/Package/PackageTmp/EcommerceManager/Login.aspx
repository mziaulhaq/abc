<%@ Page Title="" Language="C#" MasterPageFile="~/EcommerceManager/EcommerceManager.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ecommerce.EcommerceManager.Login" %>
<%@ MasterType VirtualPath="EcommerceManager.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="MessageDiv" >
        <asp:Label runat="server" ID="lblMessage" ClientIDMode="Static"></asp:Label>
    </div>
    <div>
        <table class="ui-accordion">
            <tr>
                <td class="auto-style1" >&nbsp;</td>
                <td class="auto-style1">
                    <label>
                    Login Here</label></td>
                <td class="auto-style1" >&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1" >
                    <label ID="Label1">
                    User Name</label> </td>
                <td class="auto-style1" >
                    <asp:TextBox ID="txtLoginId" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style1" >
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLoginId" ErrorMessage="User Name" Font-Size="Medium" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" >
                    <label ID="Label2">
                    Password</label> </td>
                <td class="auto-style1" >
                    <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td class="auto-style1" >
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPwd" ErrorMessage="Password" Font-Size="Medium" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="BtnLogin" runat="server" Text="Login" OnClick="BtnLoginClicked" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Following are required fields" ShowMessageBox="True" ShowSummary="False" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    
</asp:Content>
