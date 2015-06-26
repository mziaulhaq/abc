<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCategories.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.CtrlCategories" %>
<div class="MessageDiv" >
        <asp:Label runat="server" ID="lblMessage" ClientIDMode="Static"></asp:Label>
    </div>
    <div style="width:100%">
        <p>
            <a href="CategoriesAddEdit.aspx">Create New</a>
        </p>
    <asp:GridView ID="GrdCategories" runat="server" AutoGenerateColumns="False" ItemType="EcommerceDAL.Categories" DataKeyNames="CatId"  OnRowCommand="GrdBrandRowCommand" CssClass="mytable" Width="100%">
        <Columns>
            <asp:BoundField DataField="CatName" HeaderText="Name" >
                <HeaderStyle CssClass="GrdFirstHeader"></HeaderStyle>
           </asp:BoundField>
            <asp:BoundField DataField="CatDescription" HeaderText="Description"  />
            <asp:BoundField HeaderText="Hierarchy" DataField="CatHierarchy" />
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server"  
                        Text='<%# EcommerceUtilities.EnablingAndDisabling.EnableDisableLiteral(Convert.ToBoolean(Eval("CatIsActive"))) %>' 
                        CommandArgument='<%# EcommerceUtilities.EnablingAndDisabling.ReturnConcanetatedCommandNameWithRowIndex(Convert.ToString(DataBinder.Eval(Container,"RowIndex")),Convert.ToBoolean(Eval("CatIsActive")))%>'></asp:LinkButton>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="CatId" DataNavigateUrlFormatString="~/EcommerceManager/CategoriesAddEdit.aspx?Id={0}&Edit=1" HeaderText="Edit" Text="Edit" />
            <%--<asp:HyperLinkField DataNavigateUrlFields="CatId" DataNavigateUrlFormatString="CategoriesInformations?Id={0}" HeaderText="Show Update Information" Text="Show History Info" />--%>
        </Columns>
</asp:GridView>
        </div>