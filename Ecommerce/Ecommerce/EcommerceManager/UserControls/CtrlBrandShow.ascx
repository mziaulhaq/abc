<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlBrandShow.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.CtrlBrandShow" %>
  <div class="MessageDiv" >
        <asp:Label runat="server" ID="lblMessage" ClientIDMode="Static"></asp:Label>
    </div>
    <div>
    <asp:GridView ID="GrdBrands" runat="server" AutoGenerateColumns="False" ItemType="EcommerceDAL.tbl_Brands" DataKeyNames="BrandId"  OnRowCommand="GrdBrandRowCommand" Width="100%" CssClass="mytable">
        <Columns>
            <asp:BoundField DataField="BrandName" HeaderText="Name" >
            <HeaderStyle CssClass="GrdFirstHeader" />
            </asp:BoundField>
            <asp:BoundField DataField="BrandDescription" HeaderText="Description" />
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server"  
                        Text='<%# EcommerceUtilities.EnablingAndDisabling.EnableDisableLiteral(Convert.ToBoolean(Eval("IsActive"))) %>' 
                        CommandArgument='<%# EcommerceUtilities.EnablingAndDisabling.ReturnConcanetatedCommandNameWithRowIndex(Convert.ToString(DataBinder.Eval(Container,"RowIndex")),Convert.ToBoolean(Eval("IsActive")))%>'></asp:LinkButton>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="BrandId" DataNavigateUrlFormatString="~/EcommerceManager/BrandsAddEdit.aspx?Id={0}&Edit=1" HeaderText="Edit" Text="Edit" />
            <asp:HyperLinkField DataNavigateUrlFields="BrandId" DataNavigateUrlFormatString="BrandsUpdationInformation.aspx?Id={0}" HeaderText="Show Update Information" Text="Show History Info" Visible="False" />
        </Columns>
</asp:GridView>
        </div>
    