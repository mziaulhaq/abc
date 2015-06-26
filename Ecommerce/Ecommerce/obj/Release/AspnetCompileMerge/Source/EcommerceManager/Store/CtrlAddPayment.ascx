<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAddPayment.ascx.cs" Inherits="Ecommerce.EcommerceManager.Store.CtrlAddPayment" %>

<div>
    <asp:Label runat="server" ID="lblMessage" style="font-weight: bold;text-align: center;font-size: 13px"></asp:Label>
    <table class="ui-accordion">
        <tr>
            <td>Select Store :</td>
            <td>
                <asp:DropDownList runat="server" ID="ddlStore" DataValueField="StoreId" DataTextField="StoreName" AutoPostBack="True" OnSelectedIndexChanged="DdlStoreSelectedIndexChanged" />
                
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="rqdropdown" InitialValue="--Select Store--" Text="(Store required)" ForeColor="Red" ControlToValidate="ddlStore"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="border-bottom: none">From :</td>
            <td>
                <asp:TextBox ID="dtFrom" runat="server" ClientIDMode="Static" ></asp:TextBox>
                
            </td>
            <td><asp:CustomValidator ID="cvDateCheck" runat="server" ClientValidationFunction="ValidateDatesDifference" ForeColor="Red" ValidationGroup="OrdersSearch" OnServerValidate="cvDateCheck_ServerValidate" Text="(Initial Date required)"></asp:CustomValidator></td>
            </tr>
        <tr><td style="border-bottom: none">To :</td>
            <td>
                <asp:TextBox ID="dtTo" runat="server" ClientIDMode="Static"></asp:TextBox>
                
            </td>

            <td>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" Text="(Last Date required)" ForeColor="Red" ControlToValidate="dtTo"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>Amount :</td>
            <td>
                <asp:TextBox ID="txtAmountToPay" runat="server"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" Text="(Amount required)" ForeColor="Red" ControlToValidate="txtAmountToPay"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button runat="server" ID="btnAddPayment" OnClientClick="return confirm('Are you sure to add this payment?')" OnClick="AddPaymentClicked" Text="Add Payment" CssClass="btn btn-primary" /></td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</div>
