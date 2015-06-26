<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlHomePageBanner.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.Products.CtrlHomePageBanner" %>
<table class="ui-accordion">
            <tr>
                <td class="auto-style1" >
                    <label ID="Label1">Prdoduct</label> Id</td>
                <td class="auto-style1" >
                    <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style1" >
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProductName" ErrorMessage="Name" Font-Size="Medium" ForeColor="Red" ValidationGroup="Products">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <label ID="Label3">Status</label>
                </td>
                <td>
                    <asp:RadioButtonList ID="rblIsActive" runat="server" DataTextField="Value" DataValueField="Key">
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rblIsActive" ErrorMessage="Status" Font-Size="Medium" ForeColor="Red" ValidationGroup="Products">*</asp:RequiredFieldValidator>
                </td>
            </tr>
    <tr>
                <td>
                    <label ID="Label11">Brand Image</label>
                </td>
                <td id="uploaderInside">
                  <ajaxToolkit:AsyncFileUpload OnClientUploadStarted="uploadStart" OnClientUploadError="uploadError"
     OnClientUploadComplete="uploadComplete" runat="server"
     ID="ProductImage" UploaderStyle="Traditional"
      OnUploadedComplete="AsyncFileUploadUploadedComplete"/></td>
                <td valign="middle">
                    <asp:Label ID="lblMessageUpload" runat="server" ClientIDMode="Static" Style="display: none" Text="File Upload Complete"></asp:Label>
                    <asp:Image runat="server" Width="79" Height="60" ID="EditImage" />
                 </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="BtnAddEdit" runat="server" Text="Add Product" OnClick="BtnAddEditClick" ValidationGroup="Products" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Following are required fields" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Products" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>