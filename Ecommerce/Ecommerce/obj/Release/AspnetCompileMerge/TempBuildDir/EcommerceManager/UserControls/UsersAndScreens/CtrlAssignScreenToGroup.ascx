<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAssignScreenToGroup.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.UsersAndScreens.CtrlAssignScreenToGroup" %>
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
                    
                    <label ID="Label3">Group Name</label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlGroupName" runat="server" DataTextField="GroupName" DataValueField="GroupId" AutoPostBack="True" OnSelectedIndexChanged="ddlGroupName_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="vertical-align: top">
                    
                    <label ID="Label6">Screen Names</label>
                </td>
                <td>
                    <asp:CheckBoxList ID="CkhScreens" runat="server" Height="200px" DataTextField="ScreenName" DataValueField="ScreenId" CssClass="CheckBoxList" RepeatLayout="UnorderedList">
                    </asp:CheckBoxList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="BtnAddEdit" runat="server" Text="Assign Screens" OnClick="AddEditAssignSceenGroupClicked" ValidationGroup="Group" />
                    &nbsp;
                    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClick="CancelClicked"/>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Following are required fields" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Group" />
                    <asp:HiddenField ID="hdnEdit" runat="server" Value="0" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                   
                
                </td>
            </tr>
        </table>  
                </td>
            </tr>
        </table>
        
        
    </div>
