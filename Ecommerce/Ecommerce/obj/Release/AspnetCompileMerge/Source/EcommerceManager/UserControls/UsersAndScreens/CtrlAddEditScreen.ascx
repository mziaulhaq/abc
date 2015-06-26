<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAddEditScreen.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.UsersAndScreens.CtrlAddEditScreen" %>
 
 <div class="MessageDiv" >
        <asp:Label runat="server" ID="lblMessage" ClientIDMode="Static"></asp:Label>
    </div>
    <div>
        <table class="ui-accordion">
            <tr>
                <td>
                  <table>
            <tr>
                <td>
                    <label ID="Label1">Screen Name</label>
                </td>
                <td >
                    <asp:TextBox ID="txtScreenName" runat="server" ValidationGroup="Screen"></asp:TextBox>
                </td>
                <td >
                    &nbsp;</td>
                <td >
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtScreenName" ErrorMessage="Provide Screen Name" Font-Size="Medium" ForeColor="Red" ValidationGroup="Screen">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="2">
                    <asp:Button ID="BtnAddEdit" runat="server" Text="Add Screen" OnClick="AddEditScreen" ValidationGroup="Screen" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Following are required fields" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Screen" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="GdvScreens" runat="server" AutoGenerateColumns="False" CssClass="mytable" OnRowEditing="GdvScreensRowEditing" OnRowCancelingEdit="GdvCancelEdit" DataKeyNames="ScreenId" OnRowUpdating="GdvScreensRowUpdating">
                        <Columns>
                            <asp:TemplateField HeaderText="Screen Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtScreen" runat="server" Text='<%# Bind("ScreenName") %>'></asp:TextBox><asp:RequiredFieldValidator runat="server" ControlToValidate="txtScreen" ErrorMessage="Please don't leave empty" Text="*"  ValidationGroup="UpdateScreen"></asp:RequiredFieldValidator>
                                     <asp:ValidationSummary ID="ValidationSummary2" runat="server" HeaderText="Following are required fields" ShowMessageBox="True" ShowSummary="False" ValidationGroup="UpdateScreen" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("ScreenName") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="GrdFirstHeader" />
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="lnkUpdate" runat="server"  CommandName="Update" Text="Update"  ValidationGroup="UpdateScreen"></asp:LinkButton>
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
            <tr>
                <td colspan="4">
                   
                
                </td>
            </tr>
        </table>  
                </td>
            </tr>
        </table>
        
        
    </div>