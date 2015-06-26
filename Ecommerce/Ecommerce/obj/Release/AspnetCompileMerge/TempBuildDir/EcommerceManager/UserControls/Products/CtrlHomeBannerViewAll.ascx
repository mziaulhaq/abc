<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlHomeBannerViewAll.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.Products.CtrlHomeBannerViewAll" %>
<style type="text/css">

    .auto-style1 {
        width: 100%;
    }
</style>

<table  class="ui-accordion">
    <tr>
        <td>
            <table class="auto-style1">
                <tr>
                    <td>
                       <label>Name</label> </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" Width="95%"></asp:TextBox>
                    </td>
                    <td>
                 
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        <label>Status</label> </td>
                    <td>
                    <asp:DropDownList ID="rblIsFeatured" runat="server">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem Value="1">Enable</asp:ListItem>
                        <asp:ListItem Value="0">Disable</asp:ListItem>
                    </asp:DropDownList>
                    
                    </td>
                    <td>
                 
                        <asp:ImageButton ID="IBSearch" runat="server" ImageUrl="~/Images/search.png" OnClick="IBSearchClick" Height="32px" Width="32px" />
                    </td>
                </tr>
                </table>
        </td>
    </tr>
    
    <tr>
       <td style="overflow-x: scroll" align="center">
             <asp:GridView ID="gdvHomeBanners" runat="server"  AutoGenerateColumns="False" DataKeyNames="ProductID" CssClass="mytable" AllowPaging="True" PageSize="20" OnPageIndexChanging="GdvHomeBannersPageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No">
                              <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# GridViewRowNumberApplication(Container.DataItemIndex + 1,gdvHomeBanners.PageIndex,gdvHomeBanners.PageSize) %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="30px" Wrap="False" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Product Name" DataField="Name" >
                            <ItemStyle Width="250px" Wrap="False" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" Width="100px" Height="100px" ImageUrl='<%# string.Concat(UploadImagesUrl,Eval("BannerImage").ToString()) %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                               <ItemTemplate>
                                   <asp:HyperLink runat="server" ID="hlEditProduct" NavigateUrl='<%# HomeEditBannerLink(Eval("ProductId").ToString(),"Edit") %>'>
                                    <asp:Image ID="lnkEdit" runat="server" CausesValidation="False" ImageUrl="../../../Images/Gridicons/edit.png"  Width="24px" Height="24px"></asp:Image>
                                   </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
             </asp:GridView>
        </td>
    </tr>
    
    <tr>
        <td>
            &nbsp;</td>
    </tr>
</table>


 
