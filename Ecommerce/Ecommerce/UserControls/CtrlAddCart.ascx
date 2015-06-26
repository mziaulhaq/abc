<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAddCart.ascx.cs" Inherits="Ecommerce.UserControls.CtrlAddCart" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" %>
<asp:UpdatePanel runat="server" ID="updCartItems">
    <ContentTemplate>
        <div class="table-responsive">
            <table class="table">
                <tr>
                    <td><span>
                        <b class="icon-info-sign"></b>
                        <asp:Literal ID="ltHeaderMessage" runat="server" Text="Product Detail"></asp:Literal>
                        <asp:Label ID="ltlAlreadyExist" runat="server" CssClass="pull-right Red blink_me"></asp:Label>
                    </span>
                    </td>
                </tr>
            </table>
        </div>
        <div style="width: 100%">
            <div class="span8" style="float: left; padding-top: 22px; padding-right: 8px; border: 1px solid rgb(227, 227, 227); border-radius: 4px">
                <table class="table">
                    <tr>
                        <td><span style="font-weight: bold">Name : </span></td>
                        <td><span id="spProductName" runat="server"></span></td>
                    </tr>
                    <tr>
                        <td><span style="font-weight: bold">Description : </span></td>
                        <td><span id="spProductDescription" runat="server"></span></td>
                    </tr>
                    <tr>
                        <td><span style="font-weight: bold">Brand : </span></td>
                        <td><span id="spBrandName" runat="server"></span></td>
                    </tr>
                    <tr>
                        <td><span style="font-weight: bold">Price : </span></td>
                        <td><span runat="server" id="spPrice"></span></td>
                    </tr>
                    <%--<tr>
                            <td><span class="well">Stock Amount</span></td>
                            <td><span class="well" runat="server" id="spProductInStock">In Stock + Order to be Processed</span></td>
                        </tr>--%>
                    <asp:ListView ID="lstDynamicCategories" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><span>
                                    <asp:Literal runat="server" ID="ltDynamicCat" Text='<%# Bind("DyCatName") %>'></asp:Literal></span></td>
                                <td><span>
                                    <asp:Literal runat="server" ID="ltVal" Text='<%#  Bind("DyCatValue") %>'></asp:Literal></span></td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </table>
            </div>

            <div class="span4" style="border: 1px solid rgb(227, 227, 227); border-radius: 4px">
                <fieldset>
                    <legend style="border-bottom: none">Add To Cart Here</legend>
                    <table class="table">
                        <tr>
                            <td>Quantity :
                                <ew:NumericBox ID="txtQuantity" runat="server" ValidationGroup="AddToCart" Width="30%" Style="margin-bottom: 0px">
                                </ew:NumericBox>

                                <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="CheckCartLimit" ControlToValidate="txtQuantity" ForeColor="Red" ValidationGroup="AddToCart" ValidateEmptyText="True">*</asp:CustomValidator></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnAddToCart" runat="server" CssClass="btn" Text="Add To Cart" ValidationGroup="AddToCart" OnClick="btnAddToCart_Click" />
                                <asp:Button ID="btnCheckOut" runat="server" CssClass="btn" Text="Check Out" ValidationGroup="checkOut" OnClick="btnAddCheckOut_Click" /></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="AddToCart" />
                            </td>
                        </tr>
                    </table>
            </div>
        </div>

        <div class="clearall"></div>
        <div style="margin-top: 10px; border: 1px solid rgb(227, 227, 227);border-radius: 4px; width: 100%">
            <div>
                <asp:ListView runat="server" ID="lstCategories" ItemPlaceholderID="phCategories">
                    <LayoutTemplate>
                        <fieldset>
                            <legend style="margin-bottom: 10px;">More Information
                            </legend>
                            <table style="margin-left: 2%">
                                <asp:PlaceHolder runat="server" ID="phCategories"></asp:PlaceHolder>
                            </table>
                        </fieldset>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr style="border: 1px solid rgb(227, 227, 227);padding: 15px;border-radius: 4px">
                            <td>
                                <span >
                                    <asp:Literal ID="ltCatName" runat="server" Text='<%# Bind("CatName") %>'></asp:Literal>
                                </span>
                            </td>

                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </div>

            <div>
                <fieldset>
                    <legend style="margin-bottom: 10px;">Product Gallery
                    </legend>
                    <ul class="nav" style="margin-left: 2%;list-style: none">
                        <li runat="server" id="liMainImage">
                            <span class="text-center">
                                <asp:HyperLink ID="hyMainLarge" runat="server" rel="lightbox-cats">
                                    <asp:Image ID="imgMainThumbnail" runat="server" Width="148px" Height="148px"></asp:Image>
                                </asp:HyperLink>
                            </span>
                        </li>
                        <asp:ListView runat="server" ID="lstImages">
                            <ItemTemplate>
                                <li>
                                    <span class="text-center">
                                        <asp:HyperLink ID="hyLarge" runat="server" rel="lightbox-cats" NavigateUrl='<%# Bind("Large") %>'>
                                            <asp:Image ID="imgThumbnail" runat="server" ImageUrl='<%# Bind("ThumbNail") %>' Width="148px" Height="148px"></asp:Image>
                                        </asp:HyperLink>
                                    </span>
                                </li>
                            </ItemTemplate>
                        </asp:ListView>

                    </ul>
                </fieldset>
            </div>
        </div>
        <span style="display: none">
            <asp:HiddenField runat="server" ID="hdnstock" />
        </span>
    </ContentTemplate>
</asp:UpdatePanel>

<asp:UpdateProgress ID="UpdateProgress1" runat="server">
    <ProgressTemplate>
        <div id="divUpdateProgress" class="divUpdateProgress">
            <img id="imgUpdateProgress" src="../Images/updateProgress.gif" class="imgUpdateProgress" />
        </div>
    </ProgressTemplate>

</asp:UpdateProgress>
<script type="text/javascript">
    function CheckCartLimit(sender, args) {

        try {
            var stockVal = parseInt($('#<%=hdnstock.ClientID%>').val());
            var quantity = parseInt($('#<%=txtQuantity.ClientID%>').val());
            if (stockVal != NaN && quantity != NaN && stockVal != 0 && quantity != 0) {
                if (stockVal >= quantity) {
                    args.IsValid = true;
                } else {
                    sender.errormessage = "Provide quantity with in the range of (1-StockAmount)";
                    args.IsValid = false;
                }
            } else {
                sender.errormessage = "Provide quantity with in the range of (1-StockAmount)";
                args.IsValid = false;
            }
        } catch (e) {
            sender.errormessage = e.message;
            args.IsValid = false;
        }
    }
</script>

