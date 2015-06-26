<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlProductImages.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.Products.CtrlProductImages" %>
<table class="ui-accordion">
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td class="auto-style1">&nbsp;</td>
        <td class="auto-style1" style="text-align: right">
            <asp:LinkButton ID="lnkUploadProductImages" runat="server">Upload Product Images</asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td class="auto-style1" colspan="3">
            
            <asp:GridView ID="gdvImages" runat="server" AutoGenerateColumns="False" CssClass="mytable" DataKeyNames="ProductImageId" OnRowDeleting="GdvImagesRowDeleting">
                <Columns>
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" Target="_blank" runat="server" NavigateUrl='<%# PathUrl(Eval("ImagePathLarge").ToString()) %>'>
                                <asp:Image runat="server" ImageUrl='<%# PathUrl(Eval("ImagePathThumbNail").ToString()) %>' AlternateText="Image"/>
                            </asp:HyperLink>
                        </ItemTemplate>
                        <HeaderStyle CssClass="GrdFirstHeader" />
                    </asp:TemplateField>
                   <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton Width="24px" Height="24px" ID="LinkButton1" OnClientClick="javascript:return confirm('Do You Want to Delete the Picture');" runat="server" ImageUrl="../../../Images/Gridicons/delete.png" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:ImageButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
           <asp:Button runat="server" ID="btnRefresh" ClientIDMode="Static" Style="display: none"  OnClick="OkAndCancelClicked"/> 
        </td>
    </tr>
</table>
<ajaxToolkit:ModalPopupExtender ID="UploadProductImagesModalPopupExtender" runat="server" Enabled="True" TargetControlID="lnkUploadProductImages" PopupControlID="UploadImagesPopUp" BackgroundCssClass="modalBackground" DropShadow="True" CancelControlID="cancelbutton" OkControlID="okbutton">
</ajaxToolkit:ModalPopupExtender>
<asp:Panel ID="UploadImagesPopUp" runat="server" Width="500px" Height="350px" CssClass="modalPopup">
    <iframe id="iframePicture" style="width:500px ; height:350px;border: 0" src="_Upload_Product_Images.aspx"></iframe>
    <asp:Button runat="server" ID="cancelbutton" Text="Cancel" OnClientClick="javascript:document.getElementById('btnRefresh').click();" />
    &nbsp;
    <asp:Button runat="server" ID="okbutton" Text="Ok Uploaded"  OnClientClick="javascript:document.getElementById('btnRefresh').click();" />
</asp:Panel>
