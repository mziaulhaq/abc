<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlHomeBanner.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.Products.CtrlHomeBanner" %>
<script type="text/javascript">
    function BtnHiddenClicked() {
        $('#<%= BtnHidden.ClientID%>').trigger('click');
    }
    function CheckFileUploadedOrNot(sender,args) {
        var hfImage = document.getElementById('<%= hfImageUploaded.ClientID%>');
        if (hfImage.value != "1") {
            args.IsValid = false;
            sender.errormessage = "Please Upload Banner Image";
        } else {
            args.IsValid = true;
        }
    }
    function uploadComplete() {
        BtnHiddenClicked();
    }
    function uploadError(sender, args) {
        var uplctrl = document.getElementById('<%=ProductImage.ClientIDMode%>');
        uplctrl.select();
        clrctrl = uplctrl.createTextRange();
        clrctrl.execCommand('delete');
        uplctrl.focus();
    }
    function uploadStart(sender, args) {
        var filename = args.get_fileName();
        var filext = filename.substring(filename.lastIndexOf(".") + 1);
        var txtName = document.getElementById('<%= txtProductName.ClientID%>');
        if (txtName.value != "") {
            if (filext == "jpg" || filext == "gif" || filext == "png") {
                return true;
            } else {

                alert('Only jpg, gif, png files');
                return false;
            }
        }
        else {

            alert("Please Provide Product Name before Uploading File");

            return false;
        }
    }

</script>
<table class="ui-accordion">
            <tr>
                <td class="auto-style1" >
                    <label ID="Label12">Product Id</label>
                </td>
                <td class="auto-style1" >
                    <asp:Label ID="lblProductId" runat="server"></asp:Label>
                </td>
                <td class="auto-style1" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1" >
                    <label ID="Label1">Product Name</label>
                </td>
                <td class="auto-style1" >
                    <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style1" >
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProductName" ErrorMessage="Name" Font-Size="Medium" ForeColor="Red" ValidationGroup="HomeBanner">*</asp:RequiredFieldValidator>
                </td>
            </tr>
    <tr>
                <td class="auto-style1" >
                    <label ID="Label13">Status</label>
                </td>
                <td id="uploaderInside">
                    <asp:RadioButtonList ID="rblIsFeatured" runat="server">
                        <asp:ListItem Value="1">Enable</asp:ListItem>
                        <asp:ListItem Value="0">Disable</asp:ListItem>
                    </asp:RadioButtonList>
                    
                </td>
                <td valign="middle">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="rblIsFeatured" ErrorMessage="Featured" Font-Size="Medium" ForeColor="Red" ValidationGroup="HomeBanner">*</asp:RequiredFieldValidator>
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
                    <asp:CustomValidator ID="cvImage" runat="server" ClientValidationFunction="CheckFileUploadedOrNot" ErrorMessage="Please Upload Image" ForeColor="Red" ValidationGroup="HomeBanner" OnServerValidate="ImageUploadServerValidate">*</asp:CustomValidator>
                 </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="BtnHidden" runat="server" OnClick="BtnHiddenClicked" Text="Button" Style="display: none" />
                    <asp:HiddenField ID="hfImageUploaded" runat="server" />
                </td>
                <td>
                    <asp:Button ID="BtnBannerEditUpdate" runat="server" Text="Add Home Banner" OnClick="BtnAddEditClick" ValidationGroup="HomeBanner" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Following are required fields" ShowMessageBox="True" ShowSummary="False" ValidationGroup="HomeBanner" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    <asp:Image ID="ImgHomeBanner" runat="server" />
                </td>
            </tr>
            </table>
