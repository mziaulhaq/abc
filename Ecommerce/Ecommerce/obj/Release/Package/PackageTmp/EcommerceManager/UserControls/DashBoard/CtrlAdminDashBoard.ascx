<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAdminDashBoard.ascx.cs" Inherits="Ecommerce.EcommerceManager.UserControls.DashBoard.CtrlAdminDashBoard" %>
<%@ Register Src="~/EcommerceManager/UserControls/DashBoard/CtrlAdminRecentActivity.ascx" TagPrefix="uc1" TagName="CtrlAdminRecentActivity" %>


<div style="width: 50%; float: left">
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/EcommerceManager/ProductViewAll.aspx") %>'>
        <img src="../../../Images/DashBoardImages/session.png" /><span style="margin-top: -14px">Product Manager</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/EcommerceManager/ProductsAddEdit.aspx") %>'>
        <img src="../../../Images/DashBoardImages/research.png" /><span style="margin-top: -14px">Add / Edit Product</span></a></div>

    <div class="DashIcon">
        <a href='<%=VirtualPathUtility.ToAbsolute("~/EcommerceManager/OrdersManager.aspx") %>'>
            <img src="../../../Images/DashBoardImages/orderManager.png" /><span style="margin-top: -3px">Todays Orders</span> </a>
    </div>
    <div class="DashIcon">
        <a href='<%=VirtualPathUtility.ToAbsolute("~/EcommerceManager/CustomersManager.aspx") %>'>
            <img src="../../../Images/DashBoardImages/Student.png" /><span style="margin-top: -14px">Customer Manager</span></a>
    </div>
    <div class="DashIcon">
        <a href='<%=VirtualPathUtility.ToAbsolute("~/EcommerceManager/Categories.aspx") %>'>
            <img src="../../../Images/DashBoardImages/project.png" /><span style="margin-top: -14px">Category Manager</span></a>
    </div>


    <div class="DashIcon">
        <a href='<%=VirtualPathUtility.ToAbsolute("~/EcommerceManager/PageManager.aspx") %>'>
            <img src="../../../Images/DashBoardImages/milestone.png" /><span>Page Manager</span></a>
    </div>
    <div class="DashIcon">
        <a href='<%=VirtualPathUtility.ToAbsolute("~/EcommerceManager/HomeBannerViewAll.aspx") %>'>
            <img src="../../../Images/DashBoardImages/category.png" /><span style="margin-top: -14px">Home Banner Manager</span></a>
    </div>
    <div class="DashIcon">
        <a href='<%=VirtualPathUtility.ToAbsolute("~/EcommerceManager/SaleReportByDate.aspx") %>'>
            <img src="../../../Images/DashBoardImages/announcment.png" /><span style="margin-top: -14px">Report Manager</span>s</a>
    </div>


    <%--   
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Admin/DocumentSubmitted.aspx") %>'><img src="../../../Images/DashBoardImages/PDFDocument.png" /><span style="margin-top: -14px">Document Manager</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Admin/Announcment.aspx") %>'><img src="../../../Images/DashBoardImages/announcment.png" /><span style="margin-top: -14px">Announcments</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Admin/PSViewEdit.aspx") %>'><img src="../../../Images/DashBoardImages/presentation.png" /><span style="margin-top: -14px">Schedule Management</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Admin/RoomsManager.aspx") %>'><img src="../../Images/DashBoardImages/Keynote.png" /><span style="margin-top: -14px">Room Management</span></a></div>
    <div class="DashIcon"><a href='<%=VirtualPathUtility.ToAbsolute("~/Pages/Admin/ProjectDirectory.aspx") %>'><img src="../../../Images/DashBoardImages/directory.png" /><span style="margin-top: -14px">Project Directory</span></a></div>--%>
</div>


<div style="width: 45%; float: right">
    <%--This is just Dummy Text for future Use--%>
    <uc1:CtrlAdminRecentActivity runat="server" ID="CtrlAdminRecentActivity" />
</div>
