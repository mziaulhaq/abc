<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPaymentInfo.ascx.cs" Inherits="Ecommerce.EcommerceManager.Store.CtrlPaymentInfo" %>

<div>
    <asp:TextBox runat="server" ID="dtFrom" ClientIDMode="Static"></asp:TextBox>
    <asp:Button runat="server" ID="btnSearch" OnClick="BtnSearchClicked" Text="Search" CssClass="btn btn-primary"></asp:Button>
    <asp:GridView ID="gvdViewPaymentInfo" runat="server" AutoGenerateColumns="False" CssClass="mytable" Width="100%" DataKeyNames="StoreId,StoreOwnerEmail,StoreOwnerName" OnRowCommand="GvdViewPaymentRowCommand">
        <Columns>
            <asp:TemplateField HeaderText="S.No">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="StoreName" HeaderText="Store Name" />
            <%--<asp:TemplateField HeaderText="Payment Period">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("paymentduration","{0:d}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="Current Payment Status">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("paymentduration") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="PaymentHistory" Text="Payment History" CommandArgument='<%#Eval("StoreId") %>'></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="GenerateEmail" Text="Generate Email" CommandArgument='<%#DataBinder.Eval(Container,"RowIndex") %>'></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>



