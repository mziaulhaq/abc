<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlOrders.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.CtrlOrders" %>
<style type="text/css">

    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        width: 192px;
    }
    .subheader {
         font-size: 14px;font-family: sans-serif;font-weight: bold;text-decoration: underline;
    }
    .auto-style3 {
        width: 192px;
        height: 23px;
    }
    .auto-style4 {
        height: 23px;
    }
    .auto-style5 {
        width: 192px;
        height: 22px;
    }
    .auto-style6 {
        height: 22px;
    }
</style>
<script type="text/javascript">
    
    function ValidateDatesDifference(sender, args) {
        var dtFrom =$('#dtFrom');
        var dtTo = $('#dtTo');
        if(dtFrom.val()=='' && dtTo.val()=='') {
            args.IsValid = false;
            sender.errormessage = "Must provide at least one date";
        }
        else if (dtFrom.val() != '' && dtTo.val()) {
            var dateFrom = new Date(dtFrom.val());
            var dateTo = new Date(dtTo.val());
            if (dateFrom < dateTo) {
                args.IsValid = true;
            } else {
                args.IsValid = false;
                sender.errormessage = "Date From must be less than Date To";
            }
        } else {
            args.IsValid = true;
        }

        
    }
</script>

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
                 
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="OrdersSearch" />
                    </td>
                </tr>
                </table>
        </td>
    </tr>
    
    <tr>
       <td style="overflow-x: scroll" align="center">
             <asp:GridView ID="gdvHomeBanners" runat="server"  AutoGenerateColumns="False" DataKeyNames="OrderId,ProductId,CustomerId,PaymentMethodId,Quantity,PriceAtOrderTime,OrderDate,OrderConfirmation,OrderConfirmationDate,OrderConfirmBy,OrderStatus,OrderStatusUpdateBy,OrderStatusUpdateDate,StoreID,ProductName,ProductInStock,ProductIsFeatured,ProductStatus,ProductSale,SalesTaxId,SalesTaxRate,ProductImage,FirstName,LastName,Email,Address,CountryId,ProvinceOrState,CountryName,Status,CustomerName,SalesAtOrderTime,SalesTaxAtOrderTime,MobileNumber,TelephoneNumber" CssClass="mytable" AllowPaging="True" PageSize="25" Width="100%" OnSelectedIndexChanged="gdvHomeBanners_SelectedIndexChanged" OnPageIndexChanged="gdvHomeBanners_PageIndexChanged" OnPageIndexChanging="gdvHomeBanners_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No">
                              <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# GridViewRowNumberApplication(Container.DataItemIndex + 1,gdvHomeBanners.PageIndex,gdvHomeBanners.PageSize) %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="30px" Wrap="False" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                            <asp:BoundField DataField="PriceAtOrderTime" HeaderText="Price at Order Time" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                            <asp:BoundField DataField="CustomerName" HeaderText="Order By" />
                            <asp:CommandField SelectText="Details" ShowSelectButton="True" />
                           </Columns>
             </asp:GridView>
             
             <br />
             <asp:HiddenField ID="hfFrom" runat="server" Visible="False" />
             <asp:HiddenField ID="hfTo" runat="server" Visible="False" />
             
        </td>
    </tr>
    
    <tr>
        <td>
            <table class="auto-style1" runat="server" id="tblDetail">
                <tr>
                    <td colspan="4">
                       <h3>Detail for the Order</h3>
                    </td>
                </tr>
                  <tr>
                    <td colspan="4">&nbsp;</td>
                </tr>
                  <tr>
                    <td colspan="4"><span class="subheader">Order Detail</span></td>
                </tr>
                  <tr>
                    <td colspan="4">&nbsp;</td>
                </tr>
                   <tr>
                    <td class="auto-style5"><span>Product Name</span></td>
                    <td class="auto-style6">
                        <asp:Label ID="lblProductName" runat="server"></asp:Label>
                       </td>
                    <td class="auto-style6">
                        <asp:HyperLink ID="hlProduct" runat="server" Target="_blank">Click For Product Detail</asp:HyperLink>
                       </td>
                    <td class="auto-style6"></td>
                </tr>
                   <tr>
                    <td class="auto-style2">Quantity</td>
                    <td>
                        <asp:Label ID="lblQuantity" runat="server"></asp:Label>
                       </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                   <tr>
                    <td class="auto-style2"><span>Price At Order Time</span></td>
                    <td>
                        <asp:Label ID="lblPriceAtOrderTime" runat="server"></asp:Label>
                       </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                   <tr>
                    <td class="auto-style2"><span>Sale at Order Time</span></td>
                    <td>
                        <asp:Label ID="lblSaleAtOrderTime" runat="server"></asp:Label>
                       </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                   <tr>
                    <td class="auto-style2"><span>Sales Tax at Order Time</span></td>
                    <td>
                        <asp:Label ID="lblSalesTaxAtOrderTime" runat="server"></asp:Label>
                       </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                   <tr>
                    <td class="auto-style2"><span>Price Per Unit at Order Time</span></td>
                    <td>
                        <asp:Label ID="lblPricePerUnitAtOrderTime" runat="server"></asp:Label>
                       </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                   <tr>
                    <td class="auto-style2"><span>Total Price</span></td>
                    <td>
                        <asp:Label ID="lblTotalPrice" runat="server"></asp:Label>
                       </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                   <%--<tr>
                    <td class="auto-style2"><span>Order Site</span></td>
                    <td>
                        <asp:Label ID="lblOrderSite" runat="server"></asp:Label>
                       </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>--%>
                   <tr>
                    <td class="auto-style3"><span></span></td>
                    <td class="auto-style4"></td>
                    <td class="auto-style4"></td>
                    <td class="auto-style4"></td>
                </tr>
                   <tr>
                    <td class="auto-style2"><span></span></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <span class="subheader">Customer Details</span></td>
                </tr>
                <tr>
                    <td colspan="4">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2"><span>Name</span></td>
                    <td>
                        <asp:Label ID="lblName" runat="server"></asp:Label>
                       </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2"><span>Email</span></td>
                    <td>
                        <asp:Label ID="lblEmail" runat="server"></asp:Label>
                       </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2"><span>Mobile Number</span></td>
                    <td>
                        <asp:Label ID="lblMobileNumber" runat="server"></asp:Label>
                       </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2"><span>Phone Number</span></td>
                    <td>
                        <asp:Label ID="lblPhoneNumber" runat="server"></asp:Label>
                       </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2"><span>Address</span></td>
                    <td>
                        <asp:Label ID="lblAddress" runat="server"></asp:Label>
                       </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2"><span>State Or Province</span></td>
                    <td>
                        <asp:Label ID="lblStateOrProvince" runat="server"></asp:Label>
                       </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2"><span>Country</span></td>
                    <td>
                        <asp:Label ID="lblCountry" runat="server"></asp:Label>
                       </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2"><span></span></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2"><span></span></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2"><span></span></td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="BtnConfirmOrder" runat="server" Height="26px" OnClick="BtnConfirmOrderClicked" Text="Confirm Order" OnClientClick="javascript:return confirm('Are you sure you want to confirm this order');" />
&nbsp;&nbsp;
                        <asp:Button ID="BtnRejectOrder" runat="server" OnClick="BtnRejectOrderClicked" Text="Reject Order"  OnClientClick="javascript:return confirm('Are you sure you want to reject this order');" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                 
            </table>
        </td>
    </tr>

</table>



 

