<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlProducts.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.Products.CtrlProducts" %>
<script type="text/javascript">
    function ValidateNumberOrNotForSale(source, args) {
        if(args.Value=="") {
            args.IsValid = false;
            source.errormessage = "Provide Sale Value even (0)";
        }
        else if (args.Value != "") {
            if (isNaN(parseInt(args.Value))) {
                args.IsValid = false;
                source.errormessage = "Provide Number for Sale";
            } else if (!isNaN(parseInt(args.Value)) && (parseInt(args.Value) > 100 || parseInt(args.Value) < 0)) {
                args.IsValid = false;
                source.errormessage = "Provided Number for Sale must be positive less than 100";
            } else {
                args.IsValid = true;
            }
        }
        else {
            args.IsValid = true;
        }
    }

    function ValidateNumberOrNotForStock(source,args) {
        if (args.Value == "") {
            args.IsValid = false;
            source.errormessage = "Provide Sale Value even (0)";
        }
        else if (args.Value != "") {
            if (isNaN(parseInt(args.Value))) {
                args.IsValid = false;
                source.errormessage = "Provide Number for Sale";
            } else if (!isNaN(parseInt(args.Value)) && parseInt(args.Value) < 0) {
                args.IsValid = false;
                source.errormessage = "Provided Number for Stock must be Positive";
            } else {
                args.IsValid = true;
            }
        }
        else {
            args.IsValid = true;
        }
    }

    function ValidateNumberOrNotForPurchasePrice(source,args) {
        if (args.Value == "") {
            args.IsValid = false;
            source.errormessage = "Provide Purchase Price value";
        }
        else if (args.Value != "") {
            if (isNaN(parseInt(args.Value))) {
                args.IsValid = false;
                source.errormessage = "Provide Number for Purchase Price";
            } else if (!isNaN(parseInt(args.Value)) && parseInt(args.Value) < 1) {
                args.IsValid = false;
                source.errormessage = "Provided Number for Purchase Price must be Positive";
            } else {
                args.IsValid = true;
            }
        }
        else {
            args.IsValid = true;
        }
    }
    function ValidateNumberOrNotForUnitPrice(source,args) {
        if (args.Value == "") {
            args.IsValid = false;
            source.errormessage = "Provide Unit Price value";
        }
        else if (args.Value != "") {
            if (isNaN(parseInt(args.Value))) {
                args.IsValid = false;
                source.errormessage = "Provide Number for Unit Price";
            } else if (!isNaN(parseInt(args.Value)) && parseInt(args.Value) < 1) {
                args.IsValid = false;
                source.errormessage = "Provided Number for Unit Price must be Positive";
            } else {
                args.IsValid = true;
            }
        }
        else {
            args.IsValid = true;
        }
    }

    
    function uploadComplete() {
        
        var txtName = document.getElementById('<%=txtProductName.ClientID%>');
        if (txtName.value != "") {
           
           $('#<%=BtnHidden.ClientID%>').click();
        }
    }
    function uploadError(sender,args) {
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
                    <label ID="Label1">Name</label>
                </td>
                <td class="auto-style1" >
                    <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style1" >
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProductName" ErrorMessage="Name" Font-Size="Medium" ForeColor="Red" ValidationGroup="Products">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" >
                    <label ID="Label2">Description</label>
                </td>
                <td class="auto-style1" >
                    <asp:TextBox ID="txtProductDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="auto-style1" >
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtProductDescription" ErrorMessage="Description" Font-Size="Medium" ForeColor="Red" ValidationGroup="Products">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <label ID="Label12">Purchased Price</label>
                </td>
                <td>
                    <asp:TextBox ID="txtPurchasedPrice" runat="server" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:CustomValidator ID="RegularExpressionValidator5" runat="server" ValidationGroup="Products" ForeColor="Red" ClientValidationFunction="ValidateNumberOrNotForPurchasePrice" ControlToValidate="txtPurchasedPrice" ValidateEmptyText="True">*</asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <label ID="Label5">Unit Price</label>
                </td>
                <td>
                    <asp:TextBox ID="txtUnitPrice" runat="server" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:CustomValidator ID="RegularExpressionValidator4" runat="server" ValidationGroup="Products" ForeColor="Red" ClientValidationFunction="ValidateNumberOrNotForUnitPrice" ControlToValidate="txtUnitPrice" ValidateEmptyText="True">*</asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <label ID="Label6">Price Description</label>
                </td>
                <td>
                    <asp:TextBox ID="txtPriceDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <label id="Label7">
                    Stock</label></td>
                <td>
                     <asp:TextBox ID="txtInStock" runat="server" TextMode="Number">0</asp:TextBox></td>
                <td>
                    <asp:CustomValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="Products" ForeColor="Red" ClientValidationFunction="ValidateNumberOrNotForStock" ControlToValidate="txtInStock" ValidateEmptyText="True">*</asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <label ID="Label9">Sale</label></td>
                <td>
                    <asp:TextBox ID="txtSale" runat="server" TextMode="Number">0</asp:TextBox></td>
                <td>
                    <asp:CustomValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="Products" ForeColor="Red" ClientValidationFunction="ValidateNumberOrNotForSale" ControlToValidate="txtSale" ValidateEmptyText="True">*</asp:CustomValidator>
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
                    <label ID="Label10">Featured</label>
                </td>
                <td>
                    <asp:RadioButtonList ID="rblIsFeatured" runat="server">
                        <asp:ListItem Value="1">Yes</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:RadioButtonList>
                    
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="rblIsFeatured" ErrorMessage="Featured" Font-Size="Medium" ForeColor="Red" ValidationGroup="Products">*</asp:RequiredFieldValidator>
                </td>
            </tr>
           <tr>
                <td>
                    <label ID="Label4">Brand</label>
                </td>
                <td>
                    <%-- <asp:DropDownList ID="ddlCategories" runat="server" ItemType="EcommerceDAL.Categories" SelectMethod="GetAllActiveCategories" DataValueField="CatId" DataTextField="CatHierarchy" OnPreRender="DddlCategoriesPreRender">--%>
                        <asp:DropDownList ID="ddlBrands" runat="server" DataValueField="BrandId" DataTextField="BrandName">
                    </asp:DropDownList>
                    
                </td>
                <td>
                    &nbsp;</td>
            </tr>
           <tr>
                <td>
                    <label ID="Label8">SalesTax</label>
                </td>
                <td>
                        <asp:DropDownList ID="ddlSalesTax" runat="server" DataValueField="SalesTaxId" DataTextField="SalesTaxSector">
                    </asp:DropDownList>
                    
                </td>

                <td>
                    &nbsp;</td>
            </tr>
    <tr>
                <td>
                    &nbsp;<label ID="Label11">Featured mage</label>
                </td>
                <td id="uploaderInside">
                  <ajaxToolkit:AsyncFileUpload OnClientUploadStarted="uploadStart" OnClientUploadError="uploadError"
     OnClientUploadComplete="uploadComplete" runat="server"
     ID="ProductImage" UploaderStyle="Traditional"
      OnUploadedComplete="AsyncFileUploadUploadedComplete"/></td>
                <td valign="middle">
                    <asp:Label ID="lblMessageUpload" runat="server" ClientIDMode="Static" Style="display: none" Text="File Upload Complete"></asp:Label>
                    <asp:Image runat="server" Width="176" Height="200" ID="EditImage" />
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
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="BtnHidden" runat="server" OnClick="BtnHiddenClicked" Style="display:none;" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>