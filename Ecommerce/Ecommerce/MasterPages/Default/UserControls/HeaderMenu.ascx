<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderMenu.ascx.cs" Inherits="Ecommerce.UserControls.HeaderMenu" %>

<div class="row-fluid" style="background-color: rgb(247, 247, 247);">
    <div class="span10 offset1 Red">
        <h1 class="title pull-left">Lahore Cloth </h1>

        <div class="topHeaderDivs" style="background-image: url(../../../ContentV2/img/CallUsIcon.png); background-repeat: no-repeat">
            <div class="topHeaderContent">
                <b>Call Us On</b>
                <br />
                051-2355166
            </div>
        </div>

        <div class="topHeaderDivs" style="background-image: url(../../../ContentV2/img/CheapShopingIcon.png);background-repeat: no-repeat">
            <div class="topHeaderContent">
                Enjoy lowest Price
                <br />
                With Free Home Delivery
            </div>
        </div>

        <div class="topHeaderDivs" style="background-image: url(../../../ContentV2/img/EmailUsIcon.png); background-repeat: no-repeat">
            <div class="topHeaderContent">
                <b>Write Us on  </b>
                <br />
                customer@lahorecloth.com
            </div>
        </div>

        <div class="pull-right well TransparentBackground hidden-phone marginZero">
            <asp:HyperLink runat="server" ID="btnSignIn" Text="Log In" Width="70px"  CssClass="InlineBlock btn-success btn-info btn loginButton">
            </asp:HyperLink>
            <asp:HyperLink runat="server" ID="btnRegister" Text="Register" Width="70px" NavigateUrl="~/SignIn.aspx" CssClass="InlineBlock btn-success btn-info btn loginButton"></asp:HyperLink>
        </div>

    </div>
</div>
<div class="clearall row-fluid" style="background-color: #F7F7F7;">
    <nav class="navbar span10 offset1">
        <div class="navbar-inner NavBackground">
            <ul class="nav">
                <li><a class="active" href="index.aspx">Home</a></li>
                <asp:ListView runat="server" ID="lstGender">
                    <ItemTemplate>
                        <li class="Single hidden-phone">|</li>
                        <li><a href="GenderCollections.aspx?Gender=<%# Eval("GenderCatName") %>&GId=<%# Eval("GenderCatId") %>"><%# Eval("GenderCatName") %></a></li>
                    </ItemTemplate>
                </asp:ListView>
            </ul>
            <div class="inline pull-right">
                <ul class="nav fontSmall">
                    <li runat="server" id="liRegister"><a id="aRegister" runat="server" href="~/SignIn.aspx">Register</a></li>
                    <li runat="server" id="liRegisterSeperator" class="Single">|</li>
                    <li runat="server" id="liSignIn" class="dropdown"><a class="dropdown dropdown-toggle" href="#" data-toggle="dropdown">Log In<b class="caret"></b></a>
                        <div class="dropdown-menu" style="padding: 15px; padding-bottom: 0px;">
                            <asp:UpdatePanel runat="server" UpdateMode="Always">
                                <ContentTemplate>
                                    <table class="auto-style1">
                                        <tr>
                                            <td>
                                                <label class="visible-desktop visible-tablet" style="width: 92px">Email Id: </label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="GrpLogin"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is Required" ForeColor="Red" ToolTip="Email is Required" ValidationGroup="GrpLogin">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Valid Email" ForeColor="Red" ToolTip="Valid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="GrpLogin">*</asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label class="visible-desktop visible-tablet" style="width: 100%; white-space: nowrap">Password : </label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" ValidationGroup="GrpLogin"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPwd" ErrorMessage="Password is Required" ForeColor="Red" ToolTip="Password is Required" ValidationGroup="GrpLogin">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>
                                                <asp:Button ID="Button1" runat="server" Text="Login" CssClass="btn btn-info greenbackground" OnClick="LoginClicked" ValidationGroup="GrpLogin" ValidateRequestMode="Enabled" />
                                                <asp:Button runat="server" ID="btnForgotPwd" Text="Forgot Password" CssClass="btn btn-info greenbackground" OnClick="btnForgotPwd_Click" />
                                            </td>
                                            <td></td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </li>
                    <li runat="server" class="dropdown" id="liLoggedUser">
                        <a id="ALoggedUser" href="#" role="button" class="dropdown-toggle" data-toggle="dropdown">
                            <asp:Literal runat="server" ID="litLoggedUser"></asp:Literal><b class="caret"></b></a>
                        <div class="dropdown-menu">
                            <table class="tblDropDown">

                                <tr>
                                    <td>
                                        <a class="nohover" runat="server" id="aChangePassword" href="~/ChangePassword.aspx">Change Password</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <a class="nohover" runat="server" href="~/OrderStatus.aspx" id="aOrderStatus">Order Status</a></td>
                                </tr>
                                <tr>
                                    <td>
                                        <a class="nohover" runat="server" href="~/UpdateProfile.aspx" id="a1">Update Profile</a>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <a class="nohover" runat="server" href="~/Index.aspx?Logout=true" id="aLogout">Logout</a>
                                    </td>
                                </tr>


                            </table>
                        </div>
                    </li>
                    <li class="Single">|</li>
                    <li><a runat="server" href="~/CartItems.aspx">Shopping Cart<img src="images/sc.png" alt="shopping Cart" class="hidden-phone" /></a></li>

                </ul>
                <div class="navbar-search pull-right input-prepend btn-group">
                    <asp:TextBox CssClass="btn" Height="19px" ID="txtSearchValue" runat="server" ClientIDMode="Static" />
                    <asp:Button runat="server" ID="SearchClicked" CssClass="btn greenbackground whiteColor" Text="GO" OnClick="SearchClicked_Click"></asp:Button>
                </div>
            </div>
        </div>
    </nav>
    <div class="clearall"></div>
</div>

<script type="text/javascript">
    $(document).ready(function () {
        $('.dropdown-menu').find('.auto-style1').click(function (e) {
            e.stopPropagation();
        });
        $('#<%=SearchClicked.ClientID%>').click(function () {
            var txtSearchValue = $('#<%=txtSearchValue.ClientID%>');
            if (txtSearchValue.val() == '') {
                alert('Please provide search value');
                return false;
            }
            return true;
        });
    });
</script>
