<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlReportByDate.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.SalesReport.CtrlReportByDate" %>
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
                 
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td colspan="3" style="text-align: right">
                 
             <asp:HyperLink ID="hlDownloadAll" runat="server"  Target="_blank">Download Complete Report</asp:HyperLink>
             
                    </td>
                </tr>
                </table>
        </td>
    </tr>
    
    <tr>
       <td>
             <asp:GridView ID="GdvSales" runat="server"  AutoGenerateColumns="False" DataKeyNames="ProductId" CssClass="mytable" Width="100%" ShowHeaderWhenEmpty="True">
                        <Columns>
                            <asp:BoundField DataField="ROWNUMBER" HeaderText="S.No" />
                            <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                            <asp:BoundField DataField="Profit" HeaderText="Profit" />
                            <asp:TemplateField HeaderText="Detail">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# SalesReportByProduct(Eval("ProductId").ToString()) %>' Text="Details"></asp:HyperLink>
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



 


