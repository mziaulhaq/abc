<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlBrandUpdateInformation.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.CtrlBrandUpdateInformation" %>
<div>
        <table class="ui-accordion">
            <tr>
                <td class="auto-style1" >
                    <label ID="Label1">Brand Name</label>
                </td>
                <td class="auto-style1" >
                    <label id="lblBrandName" runat="server"></label></td>
                <td class="auto-style1" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1" >
                    <label ID="Label2">Brand Description</label>
                </td>
                <td class="auto-style1" >
                   <label id="lblBrandDes" runat="server"></label></td>
                <td class="auto-style1" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <label ID="Label3">Brand Status</label>
                </td>
                <td>
                     <label id="lblBrandStatus" runat="server"></label></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <label ID="Label4">User Name</label></td>
                <td>
                    <label runat="server" ID="lblUserName"></label></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <label ID="Label5">Modified On</label></td>
                <td>
                    <label runat="server" ID="lblModifiedOn"></label></td>
                <td>&nbsp;</td>
            </tr>
            </table>
    </div>
    <div>
        <table style="width: 100%">
            <tr>
                <td style="text-align: center"><label>History of Update Information</label></td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" ShowHeaderWhenEmpty="True" CssClass="mytable">
        <Columns>
            <asp:BoundField DataField="BrandName" HeaderText="Brand Name" >
            <HeaderStyle CssClass="GrdFirstHeader" />
            </asp:BoundField>
            <asp:BoundField DataField="BrandDescription" HeaderText="BrandDescription" />
            <asp:BoundField DataField="BrandsModifiedDate" DataFormatString="{0:d}" HeaderText="Modified Date" />
            <asp:TemplateField HeaderText="Status">
               <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# EcommerceUtilities.EnablingAndDisabling.EnableDisableLiteral(Convert.ToBoolean(Eval("IsActive"))) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="UserLoginId" HeaderText="User Id" />
            <asp:BoundField DataField="UserFullName" HeaderText="User Name" />
        </Columns>
                        <EmptyDataTemplate>
                            <label>No Updation History</label>
                        </EmptyDataTemplate>
    </asp:GridView>
                </td>
            </tr>
        </table>
    
   </div>