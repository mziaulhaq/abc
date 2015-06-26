<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Default/OtherPages.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Ecommerce.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
    
    <table class="ui-accordion">
        <tr>
            <td colspan="3" style="margin-bottom: 30px"><span class="LargeFont">Change Password Here</span></td>
        </tr>
        <tr>
            <td style="text-align: right">Old Password</td>
            <td style="padding-left: 20px"><asp:TextBox runat="server" ID="txtOldPassword" TextMode="Password"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator runat="server" ID="rfvOldPassword" Text="*" ErrorMessage="Old Password" ControlToValidate="txtOldPassword" ValidationGroup="ChangePassword" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="text-align: right">New Password</td>
            <td style="padding-left: 20px"><asp:TextBox runat="server" ID="txtNewPassword" TextMode="Password"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" Text="*" ErrorMessage="New Password" ControlToValidate="txtNewPassword" ValidationGroup="ChangePassword" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="text-align: right">Confirm Password</td>
            <td style="padding-left: 20px"><asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password"></asp:TextBox></td>
            <td style="margin-left: 80px"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="*" ErrorMessage="Confirm Password" ControlToValidate="txtConfirmPassword" ValidationGroup="ChangePassword" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:CompareValidator runat="server" ID="cvConfirmPassword" ControlToValidate="txtConfirmPassword" ControlToCompare="txtNewPassword" Operator="Equal" ForeColor="Red" ErrorMessage="Password doesn't match" Text="*" ValidationGroup="ChangePassword"></asp:CompareValidator>
            </td>
        </tr>

        <tr>
            <td style="text-align: right">&nbsp;</td>
            <td style="padding-left: 20px"><asp:Button runat="server" ID="btnChangePassword"  ValidationGroup="ChangePassword" OnClick="ChangePasswordClicked" Text="Change Password"/></td>
            <td style="margin-left: 80px">&nbsp;</td>
        </tr>

    </table>
    
</asp:Content>
