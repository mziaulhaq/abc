<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlBrandsAddEdit.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.CtrlBrandsAddEdit" %>
<script type="text/javascript">
    function uploadError() {
        alert("Error Occured While Uploading File");
    }
    
    function uploadComplete() {
        $('#lblMessageUpload').show(2000);
    }
</script>
  <div class="MessageDiv" >
        <asp:Label runat="server" ID="lblMessage" ClientIDMode="Static"></asp:Label>
    </div>
    <div>
        
        <table class="ui-accordion">
            <tr>
                <td class="auto-style1" >
                    <label ID="Label1">Brand Name</label>
                </td>
                <td class="auto-style1" >
                    <asp:TextBox ID="txtBrandName" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style1" >
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBrandName" ErrorMessage="Brand Name" Font-Size="Medium" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" >
                    <label ID="Label2">Brand Description</label>
                </td>
                <td class="auto-style1" >
                    <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style1" >
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescription" ErrorMessage="Brand Description" Font-Size="Medium" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" >
                    <label ID="Label4">Brand Image</label>
                </td>
                <td>
                  <ajaxToolkit:AsyncFileUpload OnClientUploadError="uploadError"
     OnClientUploadComplete="uploadComplete" runat="server"
     ID="BrandImage" UploaderStyle="Traditional"
      OnUploadedComplete="AsyncFileUploadUploadedComplete"/></td>
                <td valign="middle">
                    <asp:Label ID="lblMessageUpload" runat="server" ClientIDMode="Static" Style="display: none" Text="File Upload Complete"></asp:Label>
                    <asp:Image runat="server" Width="79" Height="60" ID="EditImage" />
                 </td>
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
                    <asp:Button ID="BtnAddEdit" runat="server" Text="Add Brands" OnClick="AddEditBrand" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Following are required fields" ShowMessageBox="True" ShowSummary="False" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        
    </div>