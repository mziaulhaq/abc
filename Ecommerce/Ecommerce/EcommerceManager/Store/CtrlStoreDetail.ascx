<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlStoreDetail.ascx.cs" Inherits="Ecommerce.EcommerceManager.Store.CtrlStoreDetail" %>

<div>
    <div style="float: left">
        <fieldset style="border: 1px solid">
            <legend class="legendStyle">Owner's Information</legend>
            <table class="mytable" style="width: 100%">
                <tr>
                    <td>Name:</td>
                    <td>
                        <asp:Label runat="server" ID="lblOwnerName"></asp:Label></td>
                </tr>
                <tr>
                    <td>Email:</td>
                    <td>
                        <asp:Label runat="server" ID="lblOwnerEmail"></asp:Label></td>
                </tr>
                <tr>
                    <td>Contact:</td>
                    <td>
                        <asp:Label runat="server" ID="lblOwnerContact"></asp:Label></td>
                </tr>
            </table>
        </fieldset>

        <div style="float: left; width: 70%">
            <fieldset style="border: 1px solid">
                <legend class="legendStyle">Business's Information</legend>
                <table class="mytable" style="width: 100%">
                    <tr>
                        <td>Business Name:</td>
                        <td>
                            <asp:Label runat="server" ID="lblBusinessName"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Domain:</td>
                        <td>
                            <asp:Label runat="server" ID="lblDomain"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Package:</td>
                        <td>
                            <asp:Label runat="server" ID="lblPackage"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Billing Term:</td>
                        <td>
                            <asp:Label runat="server" ID="lblBillingTerm"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Country:</td>
                        <td>
                            <asp:Label runat="server" ID="lblCountry"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>City:</td>
                        <td>
                            <asp:Label runat="server" ID="lblCity"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Post Code:</td>
                        <td>
                            <asp:Label runat="server" ID="lblPostCode"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Contact Number:</td>
                        <td>
                            <asp:Label runat="server" ID="lblContact"></asp:Label></td>
                    </tr>

                    <tr>
                        <td>Store Status:</td>
                        <td>
                            <asp:Label runat="server" ID="lblStoreStatus"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Address:</td>
                        <td>
                            <asp:Label runat="server" ID="lblAddress"></asp:Label></td>
                    </tr>
                </table>
            </fieldset>
        </div>
        <div style="width: 20%; float: left; margin-left: 54px">
            <fieldset style="border: 1px solid">
                <legend class="legendStyle">Template</legend>
                <table class="mytable" style="width: 100%">
                    <tr>
                        <td>
                            <asp:Image runat="server" ID="imgTemplate" Width="250px" Height="300px" ImageAlign="Top" />
                        </td>
                    </tr>
                </table>
            </fieldset>

        </div>
        
        <div style="float: left;width: 100%">
            <table>
                <tr>
                    <td><asp:Button runat="server" ID="btnDisableEnable" OnClientClick="return confirm('Are you sure?')" OnClick="BtnDisableEnableStoreClicked"></asp:Button></td>
                    <td><asp:Button runat="server" ID="btnBillingDetail" Text="Billing Detail" OnClick="BtnBillingDetailStoreClicked"/></td>
                </tr>
            </table>
        </div>
        
    </div>
</div>
<asp:HiddenField ID="hdnStatus" runat="server" />