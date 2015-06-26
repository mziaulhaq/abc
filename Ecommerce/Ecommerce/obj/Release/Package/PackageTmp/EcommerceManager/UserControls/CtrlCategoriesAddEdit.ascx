<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCategoriesAddEdit.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.CtrlCategoriesAddEdit" %>
    <div class="MessageDiv" >
        <asp:Label runat="server" ID="lblMessage" ClientIDMode="Static"></asp:Label>
    </div>
    <div>
        
        <table class="ui-accordion">
            <tr>
                <td class="auto-style1" >
                    &nbsp;</td>
                <td class="auto-style1">
                    <label>Add / Edit Category</label></td>
                <td class="auto-style1" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1" >
                    <label ID="Label1">Name</label>
                </td>
                <td class="auto-style1" >
                    <asp:TextBox ID="txtCategoryName" runat="server" ValidationGroup="CategoriesAddEdit"></asp:TextBox>
                </td>
                <td class="auto-style1" >
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCategoryName" ErrorMessage="Category Name" Font-Size="Medium" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" >
                    <label ID="Label2">Description</label>
                </td>
                <td class="auto-style1" >
                    <asp:TextBox ID="txtCategoryDescription" runat="server" TextMode="MultiLine" ValidationGroup="CategoriesAddEdit"></asp:TextBox>
                </td>
                <td class="auto-style1" >
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCategoryDescription" ErrorMessage="Category Description" Font-Size="Medium" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <label ID="Label3">Status</label>
                </td>
                <td>
                    <asp:RadioButtonList ID="rblIsActive" runat="server" ValidationGroup="CategoriesAddEdit">
                        <asp:ListItem Value="1">Enable</asp:ListItem>
                        <asp:ListItem Value="0">Disable</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rblIsActive" ErrorMessage="Category Description" Font-Size="Medium" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
           <tr>
                <td>
                    <label ID="Label4">Parent Category</label>
                </td>
                <td>
                   <%-- <asp:DropDownList ID="ddlCategories" runat="server" ItemType="EcommerceDAL.Categories" SelectMethod="GetAllActiveCategories" DataValueField="CatId" DataTextField="CatHierarchy" OnPreRender="DddlCategoriesPreRender">--%>
                        <asp:DropDownList ID="ddlCategories" runat="server" DataValueField="CatId" DataTextField="CatHierarchy">
                    </asp:DropDownList>
                    
                </td>
                <td>
                    &nbsp;</td>
            </tr>
           <tr runat="server" id="trOrder">
                <td>
                    Order</td>
                <td>
                    <asp:TextBox runat="server" ID="txtOrder"></asp:TextBox>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="BtnAddEdit" runat="server" Text="Add Category" OnClick="AddEditCategory" ValidationGroup="CategoriesAddEdit" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Following are required fields" ShowMessageBox="True" ShowSummary="False" ValidationGroup="CategoriesAddEdit" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        
    </div>
