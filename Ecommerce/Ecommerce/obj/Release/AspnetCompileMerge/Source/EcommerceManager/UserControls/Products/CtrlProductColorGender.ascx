<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlProductColorGender.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.Products.CtrlProductColorGender" %>
<table class="ui-accordion">
    <tr>
                <td colspan="2">
                    <label>Add Color</label></td>
                <td>
                    &nbsp;</td>
            </tr>
    <tr>
                <td>
                    <label>Product Name</label></td>
                <td>
                   <label runat="server" ID="lblProductName"></label></td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <label>Color</label></td>
                <td>
                    <asp:DropDownList ID="ddlColors" runat="server" ValidationGroup="ProductColor" DataTextField="ColorName" DataValueField="ColorId">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlColors" ErrorMessage="Select Color" ForeColor="Red" Operator="NotEqual" ValidationGroup="ProductColor" ValueToCompare="Select">*</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="BtnProductColors" runat="server" Text="Add Color" ValidationGroup="ProductColor" OnClick="BtnProductColors_Click" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Following are required fields" ShowMessageBox="True" ShowSummary="False" ValidationGroup="ProductColor" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="gdvColors" runat="server" Width="100%" AutoGenerateColumns="False" CssClass="mytable" DataKeyNames="ColId" OnRowDeleting="GdvColorsDeleted">
                        <Columns>
                            <asp:BoundField HeaderText="Product Name" DataField="ProdName" >

                            <HeaderStyle CssClass="GrdFirstHeader" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="Color" DataField="ColName" />
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                <asp:ImageButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="javascript:return confirm('Are you sure you want to delete this record');" ImageUrl="../../../Images/Gridicons/delete.png" Width="24px" Height="24px"></asp:ImageButton>
                                </ItemTemplate>
                                <ItemStyle Width="24px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <label>Add Color</label></td>
            </tr>
            <tr>
                <td>
                   <label>Gender</label> </td>
                <td>
                    <asp:DropDownList ID="ddlGender" runat="server" ValidationGroup="ProductGender" DataTextField="GenderCatName" DataValueField="GenderCatId">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlGender" ErrorMessage="Please Select Color" ForeColor="Red" ValidationGroup="ProductGender" ValueToCompare="Select" Operator="NotEqual">*</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnGender" runat="server" Text="Add Gender" ValidationGroup="ProductGender" OnClick="BtnGenderClicked" />
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" HeaderText="Following are required fields" ShowMessageBox="True" ShowSummary="False" ValidationGroup="ProductGender" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="gdvGender" runat="server" Width="100%" AutoGenerateColumns="False" CssClass="mytable" DataKeyNames="GenderId" OnRowDeleting="GdvGenderDeleted">
                        <Columns>
                            <asp:BoundField HeaderText="Product Name" DataField="ProdName" >
                            
                            <HeaderStyle CssClass="GrdFirstHeader" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Gender" DataField="GenderName" />
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                  <asp:ImageButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="javascript:return confirm('Are you sure you want to delete this record');" ImageUrl="../../../Images/Gridicons/delete.png" Width="24px" Height="24px"></asp:ImageButton>
                                </ItemTemplate>
                                <ItemStyle Width="24px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>