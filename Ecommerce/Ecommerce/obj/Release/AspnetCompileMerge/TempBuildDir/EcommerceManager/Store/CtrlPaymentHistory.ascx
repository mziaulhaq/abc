<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPaymentHistory.ascx.cs" Inherits="Ecommerce.EcommerceManager.Store.CtrlPaymentHistory" %>

<div>
    <asp:GridView ID="GvdPaymentHistory" runat="server" AutoGenerateColumns="False" CssClass="mytable" Width="100%" EmptyDataText="No data found">
            <Columns>
                <asp:TemplateField HeaderText="S.No">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Payment Period">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("paymentduration") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="StorePayment" HeaderText="Payment" />
                <asp:BoundField DataField="UserFullName" HeaderText="Inserted By" />
                <asp:BoundField DataField="StorePaymentDate" HeaderText="Insertion Date" DataFormatString="{0:dd MMMM yyyy}"/>
            </Columns>
        </asp:GridView>
    
    <asp:Button runat="server" ID="btnGoBack" Text="Go Back" OnClick="GoBackClicked" CssClass="btn btn-primary"/>
</div>