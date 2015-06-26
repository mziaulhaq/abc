<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlStoreWizard.ascx.cs" Inherits="Ecommerce.EcommerceManager.Store.CtrlStoreWizard" %>



<div>
    <asp:Wizard ID="wzStoreRegistration" runat="server" CancelDestinationPageUrl="~/EcommerceManager/EcomerceHome.aspx" Width="100%" CssClass="btn btn-primary" DisplayCancelButton="True" DisplaySideBar="False" HeaderText="Step 1-Package" OnNextButtonClick="NextButtonClicked" OnFinishButtonClick="FinishButtonClicked" ActiveStepIndex="0">
        <FinishCompleteButtonStyle CssClass="btn btn-primary" />
        <FinishPreviousButtonStyle CssClass="btn btn-primary" />
        <HeaderStyle BackColor="#CAE8EA" Font-Bold="True" Font-Size="25px" />
        <NavigationButtonStyle CssClass="btn btn-primary" />
        <StartNextButtonStyle CssClass="btn btn-primary" />
        <StepNextButtonStyle CssClass="btn btn-primary" />
        <StepPreviousButtonStyle CssClass="btn btn-primary" />
        <WizardSteps>
            <asp:WizardStep ID="wzStep1" runat="server" Title="Step 1-Package">
                <div style="border: 1px solid #CAE8EA; width: 100%">
                    <table class="mytable" style="width: 102%; border-left: 1px solid #C1DAD7;">
                        <thead style="text-align: center">
                            <tr>
                                <td style="width: 35%; font-size: 18px; font-weight: bold">Your Package</td>
                                <td style="font-size: 18px; font-weight: bold">Package Detail</td>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:ListView runat="server" ID="lstPackage" ItemPlaceholderID="plItems">
                                        <LayoutTemplate>
                                            <table class="mytable" style="text-align: center; width: 100%; border-left: 1px solid #C1DAD7;">
                                                <tbody>
                                                    <asp:PlaceHolder runat="server" ID="plItems"></asp:PlaceHolder>
                                                </tbody>
                                            </table>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <th style="text-align: center">
                                                <asp:Label ID="lblPackageName" runat="server" Text='<%# Eval("PackageName") %>'></asp:Label>
                                            </th>
                                            <tr>
                                                <td>USD
                        <asp:Label ID="lblPackageCost" runat="server" Text='<%# Eval("PackagePerMonthCost") %>'></asp:Label>
                                                    /Month
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblPercentagePerTransaction" runat="server" Text='<%#Eval("PackageTransactionPercentage") %>'></asp:Label>%
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Detail") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Free Setup
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Unlimited Products
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Unlimited Bandwidth
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:ListView>
                                </td>
                                <td>
                                    <h2>Can I switch package at any time?</h2>
                                    <p>Yes, at any time. This is handled automatically in your back office. When upgrading or downgrading your website plan, you will receive either a partial-month upgrade fee, or a partial-month refund depending on the cost of your new plan.</p>

                                    <h2>How do I cancel service?</h2>
                                    <p>Just email us and it's done. Canceling your GetWebShop shop is an instantaneous and no questions asked process. It's done the minute we receive your request.</p>
                                </td>
                            </tr>
                        </tbody>

                    </table>
                </div>

            </asp:WizardStep>
            <asp:WizardStep ID="wzStep2" runat="server" Title="Step 2-Select Template">
                <div style="border: 1px solid #CAE8EA; width: 100%">
                    <table class="mytable" style="width: 102%; border-left: 1px solid #C1DAD7;">
                        <thead style="text-align: center">
                            <tr>
                                <td style="width: 25%; font-size: 18px; font-weight: bold">Your Template</td>
                                <td style="font-size: 18px; font-weight: bold">Select on of the Template </td>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td style="text-align: center">
                                    <asp:Image ImageUrl="../../Images/empty.jpg" Style="height: 400px" ID="imgSide" ClientIDMode="Static" runat="server" /></td>
                                <td>
                                    <div class="row-fluid">
                                        <ul class="thumbnails" style="list-style: none">
                                            <asp:Repeater ID="rptTemplates" runat="server">
                                                <ItemTemplate>
                                                    <li class="span4">
                                                        <article class="thumbnail">

                                                            <asp:Image runat="server" ImageUrl='<%#string.Format("{0}/{1}",ConfigurationManager.AppSettings["GetTemplates"],Eval("TemplateName")) %>' />
                                                            <div>
                                                                <asp:Button runat="server" ID="btnSelectTemplate" Text="Select Template" Style="text-align: center" ClientIDMode="Static" />
                                                            </div>

                                                        </article>

                                                    </li>

                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                        <asp:Label runat="server" ID="lblTemplateId" ClientIDMode="Static" Style="display: none"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtTemplateId" ClientIDMode="Static" Style="display: none"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                        </tbody>

                    </table>
                </div>

            </asp:WizardStep>
            <asp:WizardStep ID="wzStep3" runat="server" Title="Step 3-Complete Form">
                <div style="width: 102%">
                    <fieldset style="border: 1px solid">
                        <legend class="legendStyle">Domain Information</legend>
                        <table class="mytable" style="width: 100%">
                            <tr>
                                <td>Domain Name :</td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtDomainName"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Store Name :</td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtStoreName"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtStoreName" runat="server" ForeColor="Red">(Store Name Required)</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>Billing Term :</td>
                                <td>
                                    <asp:RadioButtonList runat="server" ID="rblBillingTerm" DataTextField="BillingTerm" DataValueField="BTId" RepeatDirection="Horizontal" RepeatLayout="Flow" TextAlign="Left">
                                    </asp:RadioButtonList>
                            </tr>
                        </table>

                    </fieldset>

                    <fieldset style="border: 1px solid">
                        <legend style="padding: 15px; font-size: 24px; display: block">Personal Information</legend>
                        <table class="mytable" style="width: 100%">
                            <tr>
                                <td>Name :</td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtOwnerName"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtOwnerName" runat="server" ForeColor="Red">(Owner Name Required)</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>Contact :</td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtOwnerContact"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtOwnerContact" runat="server" ForeColor="Red">(Owner Contact Required)</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>Email :</td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtOwnerEmail"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtOwnerEmail" runat="server" ForeColor="Red">(Owner Email Required)</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtOwnerEmail" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">(Incorrect Email)</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                        </table>

                    </fieldset>

                    <fieldset style="border: 1px solid">
                        <legend style="padding: 15px; font-size: 24px; display: block">Business Information</legend>
                        <table class="mytable" style="width: 100%">
                            <tr>
                                <td>Country :</td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlStoreCountry" DataValueField="CountryId" DataTextField="CountryName"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="ddlStoreCountry" runat="server" ForeColor="Red" InitialValue="--Select Country--">(Country Required)</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>City :</td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtStoreCity"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtStoreCity" runat="server" ForeColor="Red">(City Required)</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>Post Code :</td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtStorePostCode"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtStorePostCode" runat="server" ForeColor="Red">(Post Code Required)</asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td>Contact :</td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtStoreContact"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtStoreContact" runat="server" ForeColor="Red">(Store Contact Required)</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>Store Status :</td>
                                <td>
                                    <%--<asp:RadioButton runat="server" ID="rdbEnabled" Checked="True" Text="Enable"></asp:RadioButton>
                                    <asp:RadioButton runat="server" ID="rdbDisabled" Text="Disable"></asp:RadioButton>--%>
                                    <asp:RadioButtonList runat="server" ID="rblStatus" RepeatDirection="Horizontal" RepeatLayout="Flow" TextAlign="Left">
                                        <asp:ListItem>Enabled</asp:ListItem>
                                        <asp:ListItem>Disabled</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td>Address :</td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtStoreAddress" TextMode="MultiLine" Width="400px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txtStoreAddress" runat="server" ForeColor="Red">(Store Address Required)</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
            </asp:WizardStep>
            <asp:WizardStep ID="wzStep4" runat="server" Title="Step 4-Summery">

                <div style="float: left">
                    <fieldset style="border: 1px solid">
                        <legend class="legendStyle">Owner's Information</legend>
                        <table class="mytable" style="width: 100%">
                            <tr>
                                <td>Name:</td>
                                <td>
                                    <asp:Label runat="server" ID="lblOwnerName"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Email:</td>
                                <td>
                                    <asp:Label runat="server" ID="lblOwnerEmail"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Contact:</td>
                                <td>
                                    <asp:Label runat="server" ID="lblOwnerContact"></asp:Label></td>
                            </tr>
                        </table>
                    </fieldset>

                    <div style="float: left; width: 70%">
                        <fieldset style="border: 1px solid">
                            <legend class="legendStyle">Business's Information</legend>
                            <table class="mytable" style="width: 100%">
                                <tr>
                                    <td>Business Name:</td>
                                    <td>
                                        <asp:Label runat="server" ID="lblBusinessName"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Domain:</td>
                                    <td>
                                        <asp:Label runat="server" ID="lblDomain"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Package:</td>
                                    <td>
                                        <asp:Label runat="server" ID="lblPackage"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Billing Term:</td>
                                    <td>
                                        <asp:Label runat="server" ID="lblBillingTerm"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Country:</td>
                                    <td>
                                        <asp:Label runat="server" ID="lblCountry"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>City:</td>
                                    <td>
                                        <asp:Label runat="server" ID="lblCity"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Post Code:</td>
                                    <td>
                                        <asp:Label runat="server" ID="lblPostCode"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Contact Number:</td>
                                    <td>
                                        <asp:Label runat="server" ID="lblContact"></asp:Label></td>
                                </tr>

                                <tr>
                                    <td>Store Status:</td>
                                    <td>
                                        <asp:Label runat="server" ID="lblStoreStatus"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Address:</td>
                                    <td>
                                        <asp:Label runat="server" ID="lblAddress"></asp:Label></td>
                                </tr>
                            </table>
                        </fieldset>
                    </div>
                    <asp:Label runat="server" ID="lblmsg"></asp:Label>
                    <div style="width: 25%; float: left; margin-left: 54px">
                        <fieldset style="border: 1px solid">
                            <legend class="legendStyle">Template</legend>
                            <table class="mytable" style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:Image runat="server" ID="imgTemplate" Width="300px" Height="350px" ImageAlign="Top" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>

                    </div>
                </div>
            </asp:WizardStep>
        </WizardSteps>
    </asp:Wizard>
</div>
<asp:HiddenField ID="hdTemplateId" runat="server" />

<script type="text/javascript">


    $(document).on('click', '.thumbnail input', function () {

        var iUrl = $(this).closest('.thumbnail').find('img').attr('src');
        $(this).parents('tr').find('td:eq(0) img').attr('src', iUrl);
        //$('#lblTemplateId').text(iUrl);
        $('#<%=txtTemplateId.ClientID%>').val(iUrl);
        return false;

    });

</script>
