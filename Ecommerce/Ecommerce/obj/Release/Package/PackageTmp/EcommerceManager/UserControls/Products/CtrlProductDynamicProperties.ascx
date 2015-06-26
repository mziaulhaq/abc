<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlProductDynamicProperties.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.Products.CtrlProductDynamicProperties" %>



<table class="ui-accordion">
    <tr>
                <td colspan="3">
                    (Note: if your Category doesn&#39;t exist in the list then add new in the textbox)</td>
            </tr>
    <tr>
                <td>
                    <label>Product Name</label></td>
                <td>
                   <label runat="server" ID="lblProductName"></label></td>
                <td class="auto-style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <label>Dynamic Category</label></td>
                <td>
                    <asp:DropDownList ID="ddlDynamicCat" runat="server" ClientIDMode="Static" DataTextField="PCDName" DataValueField="PID">
                    </asp:DropDownList>
                </td>
                <td class="auto-style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <label>Dynamic Category</label></td>
                <td>
                    <asp:TextBox ID="txtDynamicCategory" runat="server" ClientIDMode="Static"></asp:TextBox>
                </td>
                <td class="auto-style1">
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ForeColor="Red" ValidationGroup="DynamicCategory" ControlToValidate="txtDynamicCategory" ClientValidationFunction="ValidateDynamicProperties" ValidateEmptyText="True">*</asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <label>Value</label></td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtDynamicCatValue" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Dynamic Category Value" ForeColor="Red" ValidationGroup="DynamicCategory" ControlToValidate="txtDynamicCatValue">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="BtnAddDynamicProperties" runat="server" Text="Add Categories" ValidationGroup="DynamicCategory" OnClick="BtnAddDynamicProperties_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Following are required fields" ShowMessageBox="True" ShowSummary="False" ValidationGroup="DynamicCategory" />
                </td>
                <td class="auto-style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="GdvDynamicCategories" runat="server" Width="100%" AutoGenerateColumns="False" CssClass="mytable" OnRowEditing="GdvDynamicCategoriesRowEditing" OnRowCancelingEdit="GdvCancelEdit" DataKeyNames="PDAId" OnRowDeleting="GdvDynamicCategoriesRowDeleting" OnRowUpdating="GdvDynamicCategoriesRowUpdating">
                        <Columns>
                            <asp:TemplateField HeaderText="Product Name">
                                <EditItemTemplate>
                                    <asp:Label ID="TextBox1" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="GrdFirstHeader" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Category Name">
                                <EditItemTemplate>
                                    <asp:Label ID="TextBox2" runat="server" Text='<%# Bind("PCDName") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("PCDName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Category Value">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPdCValue" runat="server" Text='<%# Bind("PDCValue") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("PDCValue") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="../../../Images/Gridicons/delete.png" OnClientClick="javascript:return confirm('Are you sure you want to delete this record');" Width="24px" Height="24px"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" ImageUrl="../../../Images/Gridicons/edit.png"  Width="24px" Height="24px"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>

