<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlOrders.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.CtrlOrders" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }

    .auto-style2 {
        width: 192px;
    }

    .subheader {
        font-size: 14px;
        font-family: sans-serif;
        font-weight: bold;
        text-decoration: underline;
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
        var dtFrom = $('#dtFrom');
        var dtTo = $('#dtTo');
        if (dtFrom.val() == '' && dtTo.val() == '') {
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

<table class="ui-accordion">
    <tr>
        <td>
            <table class="auto-style1">
                <tr>
                    <td>From</td>
                    <td>
                        <asp:TextBox ID="dtFrom" runat="server" ClientIDMode="Static"></asp:TextBox>
                    </td>
                    <td>
                        <%--<asp:CustomValidator ID="cvDateCheck" runat="server" ClientValidationFunction="ValidateDatesDifference" ForeColor="Red" ValidationGroup="OrdersSearch" OnServerValidate="cvDateCheck_ServerValidate">*</asp:CustomValidator>--%>
                    </td>
                    <td>To</td>
                    <td>
                        <asp:TextBox ID="dtTo" runat="server" ClientIDMode="Static"></asp:TextBox>
                    </td>
                    <td>

                        <%--<asp:ImageButton ID="IBSearch" runat="server" ImageUrl="~/Images/search.png" Height="32px" Width="32px" OnClick="OrdersSearchedClicked" ValidationGroup="OrdersSearch" />--%>
                    </td>
                    <td>

                        <%--<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="OrdersSearch" />--%>
                    </td>
                </tr>
                <tr>
                    <td>Order ID</td>
                    <td>
                        <asp:TextBox ID="txtOrderId" runat="server" ClientIDMode="Static"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>Customer Name</td>
                    <td>
                        <asp:TextBox ID="txtCustomerName" runat="server" ClientIDMode="Static"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Order Status</td>
                    <td>
                        <asp:DropDownList ID="drpOrderStatusSearch" runat="server" Width="127px" Height="34px">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem Value="2">Confirmed</asp:ListItem>
                            <asp:ListItem Value="3">Dispatched</asp:ListItem>
                            <asp:ListItem Value="5">Delivered</asp:ListItem>
                        </asp:DropDownList>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <i aria-hidden="true" class="glyphicon glyphicon-search">
                            <asp:Button ID="btnSearch" runat="server" Text="Filter" Width="125px" CssClass="btn btn-info btn-large" OnClick="OrdersSearchedClicked"></asp:Button></i>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </td>
    </tr>

    <tr>
        <td style="overflow-x: scroll" align="center">
            <asp:GridView ID="gdvHomeBanners" runat="server" AutoGenerateColumns="False" DataKeyNames="OrderId,ProductId,CustomerId,PaymentMethodId,Quantity,PriceAtOrderTime,OrderDate,OrderConfirmation,OrderConfirmationDate,OrderConfirmBy,OrderStatus,OrderStatusUpdateBy,OrderStatusUpdateDate,StoreID,ProductName,ProductInStock,ProductIsFeatured,ProductStatus,ProductSale,SalesTaxId,SalesTaxRate,ProductImage,FirstName,LastName,Email,Address,CountryId,ProvinceOrState,CountryName,Status,CustomerName,SalesAtOrderTime,SalesTaxAtOrderTime,MobileNumber,TelephoneNumber" CssClass="mytable" AllowPaging="True" PageSize="25" Width="100%" OnSelectedIndexChanged="gdvHomeBanners_SelectedIndexChanged" OnPageIndexChanged="gdvHomeBanners_PageIndexChanged" OnPageIndexChanging="gdvHomeBanners_PageIndexChanging">
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
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Label ID="OrderStatusLabel" runat="server" Text='<%# EcommerceUtilities.OrderStatus.StatusDescription(int.Parse(Eval("OrderStatus").ToString())) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
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
                        <asp:HyperLink ID="hlProduct" runat="server" Target="_blank">Product Detail</asp:HyperLink>
                    </td>
                    <td class="auto-style6"></td>
                </tr>
                <tr>
                    <td class="auto-style2">Quantity</td>
                    <td>
                        <asp:Label ID="lblQuantity" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkEditQty" runat="server" OnClick="ShowEditQuantityModel">Edit Quantity</asp:LinkButton>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2"><span>Price At Order Time</span></td>
                    <td>
                        <asp:Label ID="lblPriceAtOrderTime" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkSetOrderStatus" runat="server" OnClick="SetOrderStatus">Set Order Status</asp:LinkButton>
                    </td>
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

                <tr>
                    <td class="auto-style3"><span>
                        <asp:HiddenField runat="server" ID="hdnOrderId"></asp:HiddenField>
                    </span></td>
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
                    <td colspan="4">&nbsp;</td>
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
                        <asp:Button ID="BtnRejectOrder" runat="server" OnClick="BtnRejectOrderClicked" Text="Reject Order" OnClientClick="javascript:return confirm('Are you sure you want to reject this order');" />
                    </td>
                    <td>&nbsp;</td>
                </tr>

            </table>
        </td>
    </tr>

</table>

<div id="divEditQty" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-header" style="padding: 0px">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
        <h5 id="myModalLabel">Edit Order Quantity</h5>
    </div>
    <div class="modal-body">
        <table runat="server" id="Table1">
            <tr>
                <td></td>
            </tr>
            <tr>
                <td>Quantity :</td>
                <td>
                    <asp:TextBox ID="txtOrderQuantity" runat="server" Width="210px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtOrderQuantity" Text="Please enter Quantity" ForeColor="red" ValidationGroup="quantityUpdate"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="BtnUpdateOrderQty" runat="server" Height="26px" OnClick="BtnUpdateOrderQtyClicked" ValidationGroup="quantityUpdate" Text="Update Order Qty" Width="177px" />
                </td>
            </tr>

        </table>
    </div>

</div>

<div id="rejectOrderComment" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-header" style="padding: 0px">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
        <h5 id="H1">Please submit comment</h5>
    </div>
    <div class="modal-body">
        <table runat="server" id="Table2">
            <tr>
                <td></td>
            </tr>
            <tr>
                <td>Reason : </td>
                <td>
                    <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Width="210px"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtComment" Text="Please enter rejection reason" ForeColor="red" ValidationGroup="rejectComment"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnSubmitComment" runat="server" Height="26px" OnClick="BtnSubmitCommentClicked" ValidationGroup="rejectComment" Text="Submit" Width="177px" />
                </td>
            </tr>

        </table>
    </div>

</div>

<div id="setOrderStatus" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-header" style="padding: 0px">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
        <h5 id="H2">Change order status</h5>
    </div>
    <div class="modal-body">
        <table runat="server" id="Table3">
            <tr>
                <td></td>
            </tr>
            <tr>
                <td>Order Status :</td>
                <td>
                    <asp:DropDownList ID="drpOrderStatus" runat="server" Width="189px" Height="31px">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem Value="2">Confirmed</asp:ListItem>
                        <asp:ListItem Value="3">Dispatched</asp:ListItem>
                        <asp:ListItem Value="5">Delivered</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="drpOrderStatus" Text="Please select status" ForeColor="red" ValidationGroup="updateOrderStatus" InitialValue="--Select--"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnUpdateOrderStatus" runat="server" Height="26px" OnClick="BtnUpdateOrderStatus" ValidationGroup="updateOrderStatus" Text="Update Order Status" Width="177px" />
                </td>
            </tr>

        </table>
    </div>

</div>





