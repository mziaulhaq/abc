<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Default/CMSPages.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Ecommerce.ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">

    <table style="border:1px solid darkgrey">
        <tr style="border:1px solid darkgrey">
            <td style="border:1px solid darkgrey">
                <label class="visible-desktop visible-tablet" style="width: 92px">Enter Email: </label>
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="GrpLogin" Height="22px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is Required" ForeColor="Red" ToolTip="Email is Required" ValidationGroup="GrpLogin">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Valid Email" ForeColor="Red" ToolTip="Valid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="GrpLogin">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr style="border:1px solid darkgrey">
            <td style="border:1px solid darkgrey"></td>
            <td>
                <asp:Button ID="Submit" runat="server" Text="Submit" CssClass="btn btn-info greenbackground" OnClick="Submit_Click" ValidationGroup="GrpLogin" ValidateRequestMode="Enabled" />
            </td>
            <td></td>
        </tr>
    </table>
</asp:Content>
