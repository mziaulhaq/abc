<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlReportByProduct.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.SalesReport.CtrlReportByProduct" %>
<style type="text/css">


    .auto-style1 {
        width: 100%;
    }
    .subheader {
         font-size: 14px;font-family: sans-serif;font-weight: bold;text-decoration: underline;
    }
    </style>

<table  class="ui-accordion">
    <tr>
        <td>
            <table class="auto-style1">
                <tr>
                    <td>
                        Product</td>
                    <td>
                        <asp:DropDownList ID="ddlProducts" runat="server" DataTextField="ProductName" DataValueField="ProductID">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                 
                        &nbsp;</td>
                    <td>
                 
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        From</td>
                    <td>
                        <asp:TextBox ID="dtFrom" runat="server" ClientIDMode="Static"></asp:TextBox>
                    </td>
                    <td>
                        <asp:CustomValidator ID="cvDateCheck" runat="server" ClientValidationFunction="ValidateDatesDifference" ForeColor="Red" ValidationGroup="OrdersSearch" OnServerValidate="cvDateCheck_ServerValidate">*</asp:CustomValidator>
                    </td>
                    <td>
                        To</td>
                    <td>
                        <asp:TextBox ID="dtTo" runat="server" ClientIDMode="Static"></asp:TextBox>
                    </td>
                    <td>
                 
                        <asp:ImageButton ID="IBSearch" runat="server" ImageUrl="~/Images/search.png"  Height="32px" Width="32px" OnClick="OrdersSearchedClicked" ValidationGroup="OrdersSearch" />
                    </td>
                    <td>
                 
                        <asp:HyperLink ID="hlDownSaleReport" runat="server" Target="_blank">Download Report</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td colspan="7">
                        <asp:Label ID="lblReport" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" style="line-height: 40px;vertical-align: middle" Text="Label" Width="100%"></asp:Label>
                    </td>
                </tr>
                </table>
        </td>
    </tr>
    
    <tr>
       <td>
             <asp:GridView ID="GdvSales" runat="server"  AutoGenerateColumns="False" DataKeyNames="ProductId" CssClass="mytable" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="ROWNUMBER" HeaderText="S.No" />
                            <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                            <asp:BoundField DataField="PurchasedPrice" HeaderText="Purchase Price" />
                            <asp:BoundField DataField="PriceAtOrderTime" HeaderText="Sold Price" />
                            <asp:BoundField DataField="SalesAtOrderTime" HeaderText="Sales" />
                            <asp:BoundField DataField="SalesTaxAtOrderTime" HeaderText="SalesTax" />
                            <asp:BoundField DataField="SingleProfit" HeaderText="Unit Profit" />
                            <asp:BoundField DataField="TotalProfit" HeaderText="Total Profit" />
                            <asp:TemplateField HeaderText="Confirmation Date">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# string.Format("{0:D}",Eval("OrderConfirmationDate")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           </Columns>
             </asp:GridView>
          
             <asp:HiddenField ID="hfFrom" runat="server" Visible="False" />
             <asp:HiddenField ID="hfTo" runat="server" Visible="False" />
             
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="OrdersSearch" />
             
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Repeater ID="rptPagination" runat="server">
                <HeaderTemplate>
                    <table>
                        <tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <td style="padding: 4px">
                        <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
            Enabled='<%# EnableDisablePageNumber(Eval("Value").ToString()) %>' CssClass='<%# EnableDisablePageNumber(Eval("Value").ToString())?"EnablePagingHyperLink":"DisablePagingHyperLink" %>' OnClick="PageIndexChanged" OnClientClick='<%# EnableDisablePageNumber(Eval("Value").ToString())? "return true;" : "return false;" %>'></asp:LinkButton>
                        

                    </td>
                </ItemTemplate>
                <FooterTemplate>
                    </tr>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
          </td>
    </tr>
    
    </table>



 


