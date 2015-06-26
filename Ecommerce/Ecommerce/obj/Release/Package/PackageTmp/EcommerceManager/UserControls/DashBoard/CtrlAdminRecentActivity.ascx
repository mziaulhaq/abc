<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAdminRecentActivity.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.DashBoard.CtrlAdminRecentActivity" %>

<style type="text/css">
    .ui-accordion .ui-accordion-header {
        padding: 6px 20px !important;
    }
</style>

<div class="FieldSet">
    <div id="dvAccordian" style="width: 400px">
        <asp:Repeater ID="rptAccordian" runat="server">
            <ItemTemplate>
                <h3><b style="color: rgb(10, 17, 220)"></b></h3>
                <div>
                    <%#Eval("Description") %>
                    <p>
                        Deadline :
                        till Time
                    </p>
                    <p style="color: red">
                    </p>
                    <p style="color: red">
                        <b>Note : </b>Please get the templates from download portion.
                    </p>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <asp:Repeater ID="rptGeneralAnnouncement" runat="server">
            <ItemTemplate>
                <h3><b style="color: rgb(10, 17, 220)"></b></h3>
                <div>
                    <p>
                    </p>
                    <p style="color: red">
                        
                    </p>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        
    </div>
</div>

