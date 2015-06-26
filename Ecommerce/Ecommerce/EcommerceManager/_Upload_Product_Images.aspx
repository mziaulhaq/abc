<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_Upload_Product_Images.aspx.cs" Inherits="Ecommerce.EcommerceManager._Upload_Product_Images" %>

<%@ Register Src="~/EcommerceManager/UserControls/Products/CtrlUploadProductImages.ascx" TagPrefix="uc1" TagName="CtrlUploadProductImages" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server" >
        <title></title>
     </head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <div>
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>
        <uc1:CtrlUploadProductImages runat="server" ID="CtrlUploadProductImages" />
    </div>
    </form>
</body>
</html>
