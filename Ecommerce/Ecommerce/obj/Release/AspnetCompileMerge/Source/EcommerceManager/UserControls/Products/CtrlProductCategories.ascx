<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlProductCategories.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.Products.CtrlProductCategories" %>
<table class="ui-accordion">
    <tr>
                <td>
                    &nbsp;</td>
            </tr>
    <tr>
        <td>
            <table>
                    <tr>
                <td>
                    <label>Product Name</label></td>
                <td>
                    <label runat="server" ID="lblProductName"></label></td>
                <td style="margin-left: 40px">
                    &nbsp;</td>
            </tr>
                    <tr>
                <td>
                    <label>Category</label></td>
                <td>
                    <asp:DropDownList ID="ddlCategories" runat="server" DataTextField="CatHierarchy" DataValueField="CatId">
                    </asp:DropDownList>
                        </td>
                <td style="margin-left: 40px">
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlCategories" ErrorMessage="Select Category" ForeColor="Red" Operator="NotEqual" ValidationGroup="ProductCategory" ValueToCompare="Select">*</asp:CompareValidator>
                        </td>
            </tr>
                    <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="BtnAddEditProductCategories" runat="server" Text="Add Categories" ValidationGroup="ProductCategory" OnClick="BtnAddEditCategoryClicked" />
                        </td>
                <td style="margin-left: 40px">
                    &nbsp;</td>
            </tr>
                    <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Following are required fields" ShowMessageBox="True" ShowSummary="False" ValidationGroup="ProductCategory" />
                        </td>
                <td style="margin-left: 40px">
                    &nbsp;</td>
            </tr>
            </table>
        </td>
    </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gdvProductToCategories" runat="server"  AutoGenerateColumns="False" DataKeyNames="PCId" OnRowDeleting="GdvProductCateogyDeleting" CssClass="mytable">
                        <Columns>
                            <asp:BoundField HeaderText="Product Name" DataField="ProductName" >
                              <HeaderStyle CssClass="GrdFirstHeader"></HeaderStyle>   
                            <ItemStyle Width="100px" Wrap="True" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Category" DataField="CatHierarchy" >
                            <ItemStyle Width="250px" />
                            </asp:BoundField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:ImageButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="javascript:return confirm('Are you sure you want to delete this record');" ImageUrl="../../../Images/Gridicons/delete.png" Width="23px" Height="24px"></asp:ImageButton>
                                </ItemTemplate>
                                <ItemStyle Width="24px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>