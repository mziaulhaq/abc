<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="login.ascx.cs" Inherits="Ecommerce.UserControls.login" %>

    <div>
        <div style=" color: gray">
            <h3>Login Here befor confirm order</h3>
        </div>
        <div class="row" style="margin-left: 2%">
            <div class="span4" style="color: black;">

                <div>
                    <div>
                        <asp:TextBox runat="server" Style="width: 200px;" ID="txtEmail" type="text" class="form-control" placeholder="Enter Email"></asp:TextBox>
                    </div>
                </div>


                <div>
                    <div>
                        <asp:TextBox runat="server" Style="width: 200px;" ID="txtPwd" type="password" class="form-control" placeholder="Enter Password"></asp:TextBox>
                    </div>
                </div>
            </div>



        </div>
        <div class="row" style="margin-left: 2%">
            <div class="span4">
                <div>
                    <asp:LinkButton ID="lnk" Style="margin-left: 0%;" runat="server" OnClick="lnk_Click">Forgot Password</asp:LinkButton>
                </div>
                <div style="width: 292px">
                    <asp:Button Style="float: left" ID="btnLogin" runat="server" Width="100px" Height="35px" class="InlineBlock btn-success btn-info btn loginButton" Text="Sign In" ValidationGroup="vgLogin" OnClick="btnLogin_Click" />
                    <asp:Label runat="server" ID="lblMessage" ForeColor="DarkGreen" Style="margin-left: 60px;"></asp:Label>
                </div>
            </div>
        </div>
    </div>


    <div id="forgotPasswordForm" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header" style="padding: 0px">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
            <h5 id="myModalLabel">Enter Your Email</h5>
        </div>
        <div class="modal-body">
            <table border="1">
                <tr>
                    <td>
                        <label class="visible-desktop visible-tablet" style="width: 92px">Enter Email: </label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" ValidationGroup="GrpLogin" Height="22px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is Required" ForeColor="Red" ToolTip="Email is Required" ValidationGroup="GrpLogin">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Valid Email" ForeColor="Red" ToolTip="Valid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="GrpLogin">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr style="border: 1px solid darkgrey">
                    <td style="border: 1px solid darkgrey"></td>
                    <td>
                        <asp:Button ID="btnSendClicked" runat="server" Text="Send" Width="100px" CssClass="btn btn-info greenbackground" ValidationGroup="GrpLogin" ValidateRequestMode="Enabled" OnClick="btnSendClicked_Click" />
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>
    </div>