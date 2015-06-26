<%@ Page Title="" Language="C#" MasterPageFile="~/EcommerceManager/EcommerceManager.Master" AutoEventWireup="true" CodeBehind="ProductsAddEdit.aspx.cs" Inherits="Ecommerce.EcommerceManager.ProductsAddEdit" %>

<%@ Register src="UserControls/Products/CtrlProducts.ascx" tagname="CtrlProducts" tagprefix="uc1" %>
<%@ Register Src="~/EcommerceManager/UserControls/Products/CtrlProductCategories.ascx" TagPrefix="uc1" TagName="CtrlProductCategories" %>
<%@ Register Src="~/EcommerceManager/UserControls/Products/CtrlProductColorGender.ascx" TagPrefix="uc1" TagName="CtrlProductColorGender" %>
<%@ Register Src="~/EcommerceManager/UserControls/Products/CtrlProductDynamicProperties.ascx" TagPrefix="uc1" TagName="CtrlProductDynamicProperties" %>
<%@ Register Src="~/EcommerceManager/UserControls/Products/CtrlProductImages.ascx" TagPrefix="uc1" TagName="CtrlProductImages" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function ValidateDynamicProperties(source, args) {

            var txtCat = document.getElementById('txtDynamicCategory').value;
            var ddlCatva = document.getElementById('ddlDynamicCat');
            var ddlCat = ddlCatva.selectedIndex;
            if ((ddlCat == "-1" || ddlCat == "0") && txtCat == "") {
                args.IsValid = false;
                source.errormessage = "Select from the Category List / Enter in the Category Name";
            }
           else if ((ddlCat != "0") && txtCat != "") {
               args.IsValid = false;
               source.errormessage = "Either Select from the Category List or Enter in the Category Name ";
           }
            else {
                args.IsValid = true;
            }
        }

        function ChangeWizard(anchor) {
            var aTag = anchor.innerHTML;
            document.getElementById('<%=hdnNavText.ClientID%>').value = aTag;
            document.getElementById('<%=btnHidden.ClientID%>').click();
        }
    </script>
   </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Wizard ID="ProductWizard" runat="server" OnPreRender="WizardPreRender"  DisplaySideBar="False" OnPreviousButtonClick="ProductWizard_PreviousButtonClick" OnFinishButtonClick="ProductWizardFinishButtonClicked">
    <HeaderTemplate>
        <ul id="wizHeader">
            <asp:Repeater ID="SideBarList" runat="server">
                <ItemTemplate>
                    <li><a style="cursor:pointer"class="<%# GetClassForWizardStep(Container.DataItem) %>" title="<%#Eval("Name")%>" onclick="ChangeWizard(this)"><%# Eval("Name")%></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </HeaderTemplate>
    <WizardSteps>
        <asp:WizardStep runat="server" title="Add Product" ID="AddProduct">
            <uc1:CtrlProducts ID="CtrlProducts1" runat="server" />
        </asp:WizardStep>
        <asp:WizardStep runat="server" title="Add Categories" ID="AddCategories">
            <uc1:CtrlProductCategories runat="server" id="CtrlProductCategories" />
        </asp:WizardStep>
        <asp:WizardStep ID="ColorAndGender" runat="server" Title="Color and Gender">
            <uc1:CtrlProductColorGender runat="server" id="CtrlProductColorGender" />
        </asp:WizardStep>
        <asp:WizardStep ID="DynamicProperties" runat="server" Title="Dynamic Properties">
            <uc1:CtrlProductDynamicProperties runat="server" id="CtrlProductDynamicProperties" />
        </asp:WizardStep>
        <asp:WizardStep ID="UploadImages" runat="server" Title="Upload Images">
            <uc1:CtrlProductImages runat="server" ID="CtrlProductImages" />
        </asp:WizardStep>
    </WizardSteps>
</asp:Wizard>
    <asp:Button runat="server" ID="btnHidden" OnClick="btnHidden_Click" style="display:none" ClientIDMode="Static"/>
    <asp:HiddenField runat="server" ID="hdnNavText" />
</asp:Content>
