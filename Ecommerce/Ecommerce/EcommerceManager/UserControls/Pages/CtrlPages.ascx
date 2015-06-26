<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPages.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.Pages.CtrlPages" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
 <div class="MessageDiv" >
        <asp:Label runat="server" ID="lblMessage" ClientIDMode="Static"></asp:Label>
    </div>
    <div>
        
        <table class="ui-accordion">
            <tr>
                <td>
                    <label ID="Label1">Title</label>
                </td>
                <td>
                    <asp:TextBox ID="txtPageName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPageName" ErrorMessage="Page Name" Font-Size="Medium" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <label ID="Label2">Meta Tags</label>
                </td>
                <td>
                    <asp:TextBox ID="txtPageMeta" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDetails" ErrorMessage="Page Detail is Required" Font-Size="Medium" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <label ID="Label5">Detail</label>
                </td>
                <td colspan="2">
                    <CKEditor:CKEditorControl ID="txtDetails" runat="server" BasePath="~/Scripts/Editor/"></CKEditor:CKEditorControl>
                   <%-- <cc1:CKEditor ID="txtDetails" runat="server" BasePath="~/Scripts/Editor/">
                    </cc1:CKEditor>--%>
                </td>
            </tr>
            <tr>
                <td>
                    <label ID="Label3">Status</label>
                </td>
                <td>
                    <asp:RadioButtonList ID="rblIsActive" runat="server">
                        <asp:ListItem Value="1">Enable</asp:ListItem>
                        <asp:ListItem Value="0">Disable</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rblIsActive" ErrorMessage="Page Status" Font-Size="Medium" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="BtnAddEdit" runat="server" Text="Add Page" OnClick="AddEditPage" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Following are required fields" ShowMessageBox="True" ShowSummary="False" />
                </td>
                <td>
                    <asp:HiddenField ID="hfPageName" runat="server" Visible="False" />
                </td>
            </tr>
        </table>
    </div>
