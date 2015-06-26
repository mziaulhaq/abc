<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCreateUser.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.UsersAndScreens.CtrlCreateUser" %>
 <style type="text/css">
     .auto-style1 {
         width: 181px;
     }
 </style>
 <div class="MessageDiv" >
        <asp:Label runat="server" ID="lblMessage" ClientIDMode="Static"></asp:Label>
    </div>
    <div>
        
        <table class="ui-accordion">
            <tr>
                <td class="auto-style1" >
                    <label ID="Label1">Full Name</label>
                </td>
                <td class="auto-style1" >
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style1" >
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName" ErrorMessage="Provide User Full Name" Font-Size="Medium" ForeColor="Red" ValidationGroup="CreateUser">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" >
                    <label ID="Label7">Email</label>
                </td>
                <td class="auto-style1" >
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style1" >
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmail" ErrorMessage="Provide Email" Font-Size="Medium" ForeColor="Red" ValidationGroup="CreateUser">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Provide Valid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="CreateUser">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" >
                    <label ID="Label2">Login Id</label>
                </td>
                <td class="auto-style1" >
                    <asp:TextBox ID="txtLoginId" runat="server" OnTextChanged="LoginTextChanged" AutoPostBack="True"></asp:TextBox>
                    <asp:Label ID="lblLoginIdExist" runat="server" ForeColor="Red" Visible="False" Text="Login Already Exist"></asp:Label>
                </td>
                <td class="auto-style1" >
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLoginId" ErrorMessage="Provide User Login Id" Font-Size="Medium" ForeColor="Red" ValidationGroup="CreateUser">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" >
                    <label ID="Label5">Identity Information</label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtUserIdentityInfo" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtUserIdentityInfo" ErrorMessage="Provide Identity Infromation" Font-Size="Medium" ForeColor="Red" ValidationGroup="CreateUser">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" >
                    <label ID="Label6">Address</label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAddress" ErrorMessage="Provide User Address" Font-Size="Medium" ForeColor="Red" ValidationGroup="CreateUser">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <label ID="Label3">Status</label>
                </td>
                <td class="auto-style1">
                    <asp:RadioButtonList ID="rblIsActive" runat="server">
                        <asp:ListItem Value="1">Enable</asp:ListItem>
                        <asp:ListItem Value="0">Disable</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rblIsActive" ErrorMessage="Provide User Status" Font-Size="Medium" ForeColor="Red" ValidationGroup="CreateUser">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" >
                    <label ID="Label8">Group</label>
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="ddlGroups" runat="server" DataTextField="GroupName" DataValueField="GroupId">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlGroups" ErrorMessage="Select Group" ForeColor="Red" Operator="NotEqual" ValidationGroup="CreateUser" ValueToCompare="Select">*</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style1">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:HiddenField ID="hfEdit" runat="server" Value="0" />
                </td>
                <td class="auto-style1">
                    <asp:Button ID="BtnAddEdit" runat="server" Text="Add User" OnClick="BtnCreateClicked" ValidationGroup="CreateUser" />
                    &nbsp;
                    <asp:Button ID="BtnCancel" runat="server" OnClick="BtnCancelClicked" Text="Cancel" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Following are required fields" ShowMessageBox="True" ShowSummary="False" ValidationGroup="CreateUser" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="GdvUser" runat="server" AutoGenerateColumns="False" CssClass="mytable" OnRowEditing="GdvUserRowEditing" DataKeyNames="UserId,IsActive" OnRowCommand="GdvUserRowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Login Id">
                               
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("UserLoginId") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="GrdFirstHeader" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Full Name">
                             
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("UserFullName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Group Name">
                               <ItemTemplate>
                                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("GroupName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    
                                    <asp:LinkButton ID="LnkStatus" runat="server"  CommandName="Status"
                        Text='<%# EcommerceUtilities.EnablingAndDisabling.EnableDisableLiteral(Convert.ToBoolean(Eval("IsActive"))) %>' 
                        CommandArgument='<%# EcommerceUtilities.EnablingAndDisabling.ReturnConcanetatedCommandNameWithRowIndex(Convert.ToString(DataBinder.Eval(Container,"RowIndex")),Convert.ToBoolean(Eval("IsActive")))%>'></asp:LinkButton>
                                 
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
        </table>
        
    </div>