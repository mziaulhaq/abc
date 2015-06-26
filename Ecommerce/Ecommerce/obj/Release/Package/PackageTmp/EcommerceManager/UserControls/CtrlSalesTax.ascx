<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlSalesTax.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.CtrlSalesTax" %>
  <div class="MessageDiv" >
        <asp:Label runat="server" ID="lblMessage" ClientIDMode="Static"></asp:Label>
    </div>
    <div>
        
        <table class="ui-accordion">
            <tr>
                <td class="auto-style1" >
                    <label ID="Label1">Sector</label>
                </td>
                <td class="auto-style1" >
                    <asp:TextBox ID="txtSectorName" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style1" >
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSectorName" ErrorMessage="Brand Name" Font-Size="Medium" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" >
                    <label ID="Label4">Rate</label>
                </td>
                <td class="auto-style1" >
                    <asp:TextBox ID="txtRate" runat="server" TextMode="Number"></asp:TextBox>
                </td>
                <td class="auto-style1" >
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtRate" ErrorMessage="Brand Description" Font-Size="Medium" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" >
                    <label ID="Label2">Description</label>
                </td>
                <td class="auto-style1" >
                    <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style1" >
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescription" ErrorMessage="Brand Description" Font-Size="Medium" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <label ID="Label3">Brand Status</label>
                </td>
                <td>
                    <asp:RadioButtonList ID="rblIsActive" runat="server">
                        <asp:ListItem Value="1">Enable</asp:ListItem>
                        <asp:ListItem Value="0">Disable</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rblIsActive" ErrorMessage="Brand Status" Font-Size="Medium" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="BtnAddEdit" runat="server" Text="Add Sales Tax Rates" OnClick="AddEditBrand" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Following are required fields" ShowMessageBox="True" ShowSummary="False" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        
    </div>