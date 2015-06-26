<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAddEditGroups.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.UsersAndScreens.CtrlAddEditGroups" %>
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
                    
                    <label ID="Label1">Group Name</label>
                </td>
                <td >
                    <asp:TextBox ID="txtGroupName" runat="server" ValidationGroup="Group"></asp:TextBox>
                </td>
                <td >
                    &nbsp;</td>
                <td >
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtGroupName" ErrorMessage="Provide Group Name" Font-Size="Medium" ForeColor="Red" ValidationGroup="Group">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    
                    <label ID="Label3">Group Description</label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtDescription" runat="server" ValidationGroup="Group" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    
                    <label ID="Label4">Status</label>
                </td>
                <td colspan="2">
                    <asp:RadioButtonList ID="rblIsActive" runat="server" ValidationGroup="Group">
                        <asp:ListItem Value="1">Enable</asp:ListItem>
                        <asp:ListItem Value="0">Disable</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rblIsActive" ErrorMessage="Brand Status" Font-Size="Medium" ForeColor="Red" ValidationGroup="Group">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="2">
                    <asp:Button ID="BtnAddEdit" runat="server" Text="Add Group" OnClick="AddEditGroup" ValidationGroup="Group" UseSubmitBehavior="true" />
                    &nbsp;
                    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClick="CancelClicked"/>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Following are required fields" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Group" />
                    <asp:HiddenField ID="hdnEdit" runat="server" Value="0" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="GdvGroup" runat="server" AutoGenerateColumns="False" CssClass="mytable" OnRowEditing="GdvScreensRowEditing" DataKeyNames="GroupId" OnRowCommand="GdvGroupRowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Group Name">
                               <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("GroupName") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="GrdFirstHeader" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="GroupDescription">
                               <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("GroupDescription") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    
                                    <asp:LinkButton ID="LnkStatus" runat="server"  CommandName="LnkStatus"
                        Text='<%# EcommerceUtilities.EnablingAndDisabling.EnableDisableLiteral(Convert.ToBoolean(Eval("Status"))) %>' 
                        CommandArgument='<%# EcommerceUtilities.EnablingAndDisabling.ReturnConcanetatedCommandNameWithRowIndex(Convert.ToString(DataBinder.Eval(Container,"RowIndex")),Convert.ToBoolean(Eval("Status")))%>'></asp:LinkButton>
                                 
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
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