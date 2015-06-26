<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAddCart.ascx.cs" Inherits="Ecommerce.UserControls.CtrlAddCart" %>
<asp:UpdatePanel runat="server" ID="updCartItems">
    <ContentTemplate>
        <table class="auto-style1">
            <tr>
                <td colspan="2"><span class="well">
                    <b class="icon-info-sign"></b>
                    <asp:Literal ID="ltHeaderMessage" runat="server" Text="Product Detail"></asp:Literal>
                    <asp:Label ID="ltlAlreadyExist" runat="server" CssClass="pull-right"></asp:Label>
                </span>
                </td>

            </tr>
            <tr>
                <td>
                    <table style="width: 97%">
                        <tr>
                            <td><span class="well">Product Name</span></td>
                            <td><span class="well" id="spProductName" runat="server"></span></td>
                        </tr>
                        <tr>
                            <td><span class="well">Product Description</span></td>
                            <td><span class="well" id="spProductDescription" runat="server"></span></td>
                        </tr>
                        <tr>
                            <td><span class="well">Brand Name</span></td>
                            <td><span class="well" id="spBrandName" runat="server"></span></td>
                        </tr>
                        <tr>
                            <td><span class="well">Price</span></td>
                            <td><span class="well" runat="server" id="spPrice"></span></td>
                        </tr>
                        <%--<tr>
                            <td><span class="well">Stock Amount</span></td>
                            <td><span class="well" runat="server" id="spProductInStock">In Stock + Order to be Processed</span></td>
                        </tr>--%>
                        <asp:ListView ID="lstDynamicCategories" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><span class="well">
                                        <asp:Literal runat="server" ID="ltDynamicCat" Text='<%# Bind("DyCatName") %>'></asp:Literal></span></td>
                                    <td><span class="well">
                                        <asp:Literal runat="server" ID="ltVal" Text='<%#  Bind("DyCatValue") %>'></asp:Literal></span></td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>


                    </table>
                </td>
                <td width="40%">
                    <div class="well">
                        <fieldset>
                            <legend>Add To Cart Here</legend>
                            <ul style="list-style-type: none; list-style-position: outside; margin: 0;">
                                <li class="well" style="width: 97%">Quantity : 
                          
                                <asp:TextBox ID="txtQuantity" runat="server" Width="30%" Style="margin-bottom: 0px" ValidationGroup="AddToCart"></asp:TextBox>

                                    <%--<asp:RequiredFieldValidator ID="rfvCart" runat="server" ControlToValidate="txtQuantity" ErrorMessage="Please Provide Quantity" ForeColor="Red" ValidationGroup="AddToCart">*</asp:RequiredFieldValidator>--%>
                                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="CheckCartLimit" ControlToValidate="txtQuantity" ForeColor="Red" ValidationGroup="AddToCart" ValidateEmptyText="True">*</asp:CustomValidator>
                                    <%--OnServerValidate="CustomValidatorAddToCart"--%>
                                </li>
                                <li class="well" style="width: 97%">

                                    <asp:Button ID="btnAddToCart" runat="server" CssClass="btn" Text="Add To Cart" ValidationGroup="AddToCart" OnClick="btnAddToCart_Click" />

                                  <%--  <asp:HyperLink ID="hlkcheckOut" CssClass="btn" runat="server" NavigateUrl="~/CartItems.aspx" Style="padding: 4px 12px; display: inline-block">Check Out</asp:HyperLink>--%>
                                    
                                     <asp:Button ID="btnCheckOut" runat="server" CssClass="btn" Text="Check Out" ValidationGroup="checkOut" OnClick="btnAddCheckOut_Click" />

                                    &nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="AddToCart" />

                                </li>

                            </ul>

                        </fieldset>
                    </div>
                </td>
            </tr>
            <tr id="trCategories" runat="server">
                <td colspan="2">
                    <span class="well">
                        <asp:ListView runat="server" ID="lstCategories" ItemPlaceholderID="phCategories">
                            <LayoutTemplate>
                                <fieldset>
                                    <legend style="margin-bottom: 10px;">Categories
                                    </legend>
                                    <table style="margin-left: 2%">

                                        <asp:PlaceHolder runat="server" ID="phCategories"></asp:PlaceHolder>

                                    </table>
                                </fieldset>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <span class="well">
                                            <asp:Literal ID="ltCatName" runat="server" Text='<%# Bind("CatName") %>'></asp:Literal>
                                        </span>
                                    </td>

                                </tr>
                            </ItemTemplate>
                        </asp:ListView>

                    </span>
                </td>
            </tr>
            <tr id="trImages" runat="server" clientidmode="Static">
                <td colspan="2">
                    <span class="well">
                        <fieldset>
                            <legend style="margin-bottom: 10px;">Product Gallery
                            </legend>
                            <ul style="margin-left: 2%">
                                <li runat="server" id="liMainImage">
                                    <span class="well text-center">
                                        <asp:HyperLink ID="hyMainLarge" runat="server" rel="lightbox-cats">
                                            <asp:Image ID="imgMainThumbnail" runat="server" Width="148px" Height="148px"></asp:Image>
                                        </asp:HyperLink>
                                    </span>
                                </li>
                                <asp:ListView runat="server" ID="lstImages">
                                    <ItemTemplate>
                                        <li>
                                            <span class="well text-center">
                                                <asp:HyperLink ID="hyLarge" runat="server" rel="lightbox-cats" NavigateUrl='<%# Bind("Large") %>'>
                                                    <asp:Image ID="imgThumbnail" runat="server" ImageUrl='<%# Bind("ThumbNail") %>' Width="148px" Height="148px"></asp:Image>
                                                </asp:HyperLink>
                                            </span>
                                        </li>
                                    </ItemTemplate>
                                </asp:ListView>

                            </ul>
                        </fieldset>
                    </span>
                </td>
            </tr>
        </table>
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

