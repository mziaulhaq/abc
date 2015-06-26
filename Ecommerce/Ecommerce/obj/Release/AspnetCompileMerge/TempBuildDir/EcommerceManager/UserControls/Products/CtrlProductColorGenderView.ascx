<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlProductColorGenderView.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.Products.CtrlProductColorGenderView" %>

<table class="ui-accordion">
    <tr>
                <td>
                    <label>Color</label></td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gdvColors" runat="server" Width="100%" AutoGenerateColumns="False" CssClass="mytable">
                        <Columns>

                            <asp:BoundField HeaderText="Color" DataField="ColName" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <label>Gender</label></td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gdvGender" runat="server" Width="100%" AutoGenerateColumns="False" CssClass="mytable">
                        <Columns>
                            <asp:BoundField HeaderText="Gender" DataField="GenderName" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>