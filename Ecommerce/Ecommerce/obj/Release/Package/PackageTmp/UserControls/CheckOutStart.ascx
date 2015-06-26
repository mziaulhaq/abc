<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CheckOutStart.ascx.cs" Inherits="Ecommerce.UserControls.CheckOutStart" %>
<%@ Register Src="~/UserControls/login.ascx" TagPrefix="uc1" TagName="login" %>


<style type="text/css">
    .divForms {
        width: 156px;
        float: left;
        margin-left: 24px;
    }

    input[type="text"] {
        width: 150px;
    }

    select {
        width: 164px;
    }

    textarea {
        width: 336px;
    }

    label {
        display: inline;
        font-weight: bold;
    }

    .h4tyle {
        text-align: center;
    }
</style>

<script type="text/javascript">
    function SelectRadioButton(regexPattern, selectedRadioButton) {
        regex = new RegExp(regexPattern);
        for (i = 0; i < document.forms[0].elements.length; i++) {
            element = document.forms[0].elements[i];
            if (element.type == 'radio' && regex.test(element.name)) {
                element.checked = false;
            }
        }
        selectedRadioButton.checked = true;
    }
</script>
<%--<div style="border: 1px solid"></div>--%>
<div id="divUserInfo" style="border-style: solid; border-color: inherit; border-width: 1px; float: left; width: 35%" runat="server">
    <div>
        <h4 class="h4tyle">1-Customer Information</h4>
    </div>
    <div class="divForms">
        <label>First Name</label>
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName" ErrorMessage="First Name" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
        <asp:TextBox ID="txtFirstName" runat="server" Enabled="False"></asp:TextBox>
    </div>

    <div class="divForms">
        <label>Last Name</label>
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName" ErrorMessage="Last Name" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
        <asp:TextBox ID="txtLastName" runat="server" Enabled="False"></asp:TextBox>
    </div>

    <div class="divForms">
        <label>Email</label>
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
        <asp:TextBox ID="txtEmail" runat="server" Enabled="False"></asp:TextBox>
    </div>

    <div class="divForms" style="display:none">
        <label>Date of Birth</label>
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDOB" ErrorMessage="Date Of Birth" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
        <asp:TextBox ID="txtDOB" runat="server" ClientIDMode="Static" Enabled="False"></asp:TextBox>
    </div>

    <div class="divForms">
        <label>Phone Number</label>
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPhoneNumber" ErrorMessage="Phone Number" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
        <asp:TextBox ID="txtPhoneNumber" runat="server" Enabled="False" MaxLength="15"></asp:TextBox>
    </div>

    <div class="divForms">
        <label>Mobile Number</label>
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtMobileNumber" ErrorMessage="Mobile Number" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
        <asp:TextBox ID="txtMobileNumber" runat="server" Enabled="False" MaxLength="15"></asp:TextBox>
    </div>



    <div class="divForms">
        <label>Country</label>
<%--        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtProvinceState" ErrorMessage="Province Or State" ForeColor="Red">*</asp:RequiredFieldValidator><br />--%>
        <asp:DropDownList ID="ddlCountry" runat="server" DataTextField="CountryName" DataValueField="CountryId" Enabled="False">
        </asp:DropDownList>
    </div>

    <div class="divForms">
        <label>Province / State</label>
<%--        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtProvinceState" ErrorMessage="Province Or State" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
        <asp:TextBox ID="txtProvinceState" runat="server" Enabled="False"></asp:TextBox>
    </div>

    <div class="divForms" style="float:none">
        <label>Complete Address</label>
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtCompleteAddress" ErrorMessage="Complete Address" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
        <asp:TextBox ID="txtCompleteAddress" runat="server" TextMode="MultiLine" Enabled="False"></asp:TextBox>
    </div>

</div>

<div id="Divlogin" runat="server" style="float:left">

    <uc1:login runat="server" ID="login" />
</div>
<div style="border-style: solid; border-color: inherit; border-width: 1px; float: left; width: 25%; margin-left: 25px">
    <div>
        <h4 class="h4tyle">1-Payment Methods</h4>
    </div>
    <asp:Repeater runat="server" ID="rptPaymentMethods">
        <ItemTemplate>
            <div style="border-bottom: 1px solid; border-bottom-color: inherit; margin-top: 5px;">
                <asp:RadioButton runat="server" ID="rdbPaymentMethod" ClientIDMode="Static" Text='<%#Eval("PaymentMethodName") %>' GroupName='zia' onclick="SelectRadioButton('zia$',this)" Checked="True"/>
                <br />
                <p style="margin-left: 24px">
                    <asp:Label runat="server" ID="lblMethodDesc" Text='<%#Eval("PaymentMethodDesc") %>'></asp:Label>
                </p>
                <br />
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>


<div style="border-style: solid; border-color: inherit; border-width: 1px; float: left; width: 34%; margin-left: 25px">
    <div>
        <h4 class="h4tyle">1-Order Information</h4>
        <div>
            <asp:GridView ID="GdvCartItems" runat="server" AutoGenerateColumns="False" BorderStyle="None" CssClass="TableWithNoBorder" BorderWidth="0px" Width="100%" GridLines="None" ShowHeaderWhenEmpty="True" ShowFooter="True">
                <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# QuantityOfProductInCartItems(Eval("ProductId").ToString()) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Unit Price">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# UnitPrice(Eval("ProductId").ToString()) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Price">
                        <FooterTemplate>
                            <asp:Label ID="lblTotal" runat="server"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblPrice" runat="server" Text='<%# ProductCommulativePrice(Eval("ProductId").ToString(),QuantityOfProductInCartItems(Eval("ProductId").ToString()))
                            %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <span id="Label3" runat="server" class="well" text="Currently No Item in Your Cart"></span>
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:Button runat="server" ID="btnConfirm" Text="Confirm Order" OnClick="BtnConfirmClicked" style="float: right" CssClass="inline btn-success btn-info btn ShopNow"/>
        </div>
    </div>

</div>
