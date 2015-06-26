<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlUploadProductImages.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.Products.CtrlUploadProductImages" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<script type="text/javascript">
    function allComplete() {
        
        document.getElementById('ButtonFileUpload').click();
    }
</script>
<table class="ui-accordion" style="width: 450px">
    
    <tr>
        <td>
            <label>
            Product Name</label></td>
        <td>
            <label id="lblProductName" runat="server">
            </label>
        </td>
        <td class="auto-style1">&nbsp;</td>
    </tr>
    <tr>
        <td colspan="3">
            
           <%-- <ajaxToolkit:AjaxFileUpload ID="productImagesUpload" runat="server" AllowedFileTypes="jpg,jpeg,gif,png" OnUploadComplete="UploadImagesComplete"  MaximumNumberOfFiles="4" Mode="Client" />--%>
            <asp:AjaxFileUpload ID="productImagesUpload" runat="server" AllowedFileTypes="jpg,jpeg,gif,png" OnUploadComplete="UploadImagesComplete"  MaximumNumberOfFiles="4" Mode="Client" />
            <label runat="server" id="limitReached" Visible="False"> You have already uploaded 4 pictures for this product</label>
            <asp:Button runat="server" ClientIDMode="Static" Style="display: none" ID="ButtonFileUpload" OnClick="ButtonFileUploadClicked" />
          
        </td>
    </tr>
</table>

