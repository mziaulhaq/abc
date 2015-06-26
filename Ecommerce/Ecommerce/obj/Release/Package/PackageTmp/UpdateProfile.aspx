<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Default/OtherPages.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="Ecommerce.UpdateProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        /*.auto-style1 label {
            display: inline-block;
        }*/
        .positive-integer {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contents" runat="server">
    <div id="MainDiv" runat="Server">
    <table class="auto-style1">
        <tr>
            <td colspan="4"><label class="LargeFont text-center lead">Update Your Profile </label></td>
        </tr>
        <tr>
            <td><label>First Name : </label></td>
            <td>
                <asp:TextBox ID="txtFirstName" runat="server" ValidationGroup="Signup"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName" ErrorMessage="First Name" ForeColor="Red" ValidationGroup="Signup" >*</asp:RequiredFieldValidator>
            </td>
            <td></td>
        </tr>
        <tr>
            <td><label>Last Name : </label></td>
            <td>
                <asp:TextBox ID="txtLastName" runat="server" ValidationGroup="Signup"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName" ErrorMessage="Last Name" ForeColor="Red" ValidationGroup="Signup">*</asp:RequiredFieldValidator>
            </td>
            <td></td>
        </tr>
        <tr>
            <td><label>Email : </label></td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="Signup" ></asp:TextBox>
               <span class="GreenText">Submit correct email, your order delivery status will be sent through email periodically.</span> </td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Valid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Signup">*</asp:RegularExpressionValidator>
            </td>
            <td></td>
        </tr>
     
        
        <tr>
            <td><label title="Date of Birth">DOB: </label></td>
            <td>
                <asp:TextBox ID="txtDOB" runat="server" ValidationGroup="Signup"></asp:TextBox>
              
            </td>
            <td>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDOB" ErrorMessage="Date Of Birth" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                </td>
            <td></td>
        </tr>
        <tr>
            <td><label>Gender : </label></td>
            <td>
                <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" ValidationGroup="Signup">
                    <asp:ListItem Value="1">Male</asp:ListItem>
                    <asp:ListItem Value="2">Female</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="rblGender" ErrorMessage="Gender" ForeColor="Red" ValidationGroup="Signup">*</asp:RequiredFieldValidator>
                </td>
            <td></td>
        </tr>
        <tr>
            <td><label>Phone Number : </label></td>
            <td>
                <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="positive-integer" MaxLength="15" ValidationGroup="Signup"></asp:TextBox>
            </td>
            <td>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPhoneNumber" ErrorMessage="Phone Number" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                </td>
            <td></td>
        </tr>
        <tr>
            <td><label>Mobile Number : </label></td>
            <td>
                <asp:TextBox ID="txtMobileNumber" runat="server" CssClass="positive-integer" MaxLength="15" ValidationGroup="Signup" Width="134px"></asp:TextBox>
                <span class="GreenText"> Submit correct phone number , for order confrimation</span></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtMobileNumber" ErrorMessage="Mobile Number" ForeColor="Red" ValidationGroup="Signup">*</asp:RequiredFieldValidator>
                </td>
            <td></td>
        </tr>
        <tr>
            <td><label>Complete Address : </label></td>
            <td>
                <asp:TextBox ID="txtCompleteAddress" runat="server" TextMode="MultiLine" ValidationGroup="Signup"></asp:TextBox>
                <span class="GreenText"> Submit the address carefully, order will be delivered in this address. </span></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtCompleteAddress" ErrorMessage="Complete Address" ForeColor="Red" ValidationGroup="Signup">*</asp:RequiredFieldValidator>
                </td>
            <td></td>
        </tr>
        <tr>
            <td><label>Province / State : </label></td>
            <td>
                <asp:TextBox ID="txtProvinceState" runat="server" ValidationGroup="Signup"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtProvinceState" ErrorMessage="Province Or State" ForeColor="Red" ValidationGroup="Signup">*</asp:RequiredFieldValidator>
                </td>
            <td></td>
        </tr>
        <tr>
            <td><label>Country : </label></td>
            <td>
                <asp:DropDownList ID="ddlCountry" runat="server" DataTextField="CountryName" DataValueField="CountryId" ValidationGroup="Signup">
                </asp:DropDownList>
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>  <asp:Button ID="btnSignIn" runat="server" Text="Update My Profile" CssClass="inline btn-success btn-info btn ShopNow" OnClick="BtnSignUpClicked" ValidationGroup="Signup" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Following are Required" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Signup" />
            </td>
            <td>
              
            </td>
            <td></td>
        </tr>
    </table>
        </div>
    

      <script type="text/javascript">
          $(function() {
              $('#<%= txtDOB.ClientID %>').datepicker({
                  changeMonth: true,
                  changeYear: true,
                  yearRange: "-100:-10"
              });
          });
          $(".positive-integer").numeric({ decimal: false, negative: false }, function () { alert("Positive integers only"); this.value = ""; this.focus(); });
             </script>
</asp:Content>
