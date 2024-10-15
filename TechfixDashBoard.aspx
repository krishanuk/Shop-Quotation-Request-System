<%@ Page Title="TechFix Admin Dashboard" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="TechfixDashBoard.aspx.cs" Inherits="TechFix.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href='<%= ResolveUrl("~/Style/TechfixDashBoard.css") %>' rel="stylesheet" type="text/css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="dashboard-header">TechFix Admin Dashboard</div>

    <div class="dashboard-grid">
        <div class="dashboard-section">
            <h3>View Products</h3>
            <p>Admin can View, All Products in the system.</p>
            <asp:Button ID="btnManageUsers" runat="server" Text="View Products" CssClass="btn-action" OnClick="btnManageUsers_Click" />
        </div>

        <div class="dashboard-section">
            <h3>Add Quotation</h3>
            <p>Add Youre Quotation Here.</p>
            <asp:Button ID="btnViewReports" runat="server" Text="Add Quotation" CssClass="btn-action" OnClick="btnViewReports_Click" />
        </div>

        <div class="dashboard-section">
            <h3>Manage Quotation</h3>
            <p>View and Manage Quotation in the system.</p>
            <asp:Button ID="btnManageOrders" runat="server" Text="Manage Quotation" CssClass="btn-action" OnClick="btnManageOrders_Click" />
        </div>

        <div class="dashboard-section">
            <h3>View Orders</h3>
            <p>View All The TechFix Orders.</p>
            <asp:Button ID="btnManageInventory" runat="server" Text="My Orders" CssClass="btn-action" OnClick="btnManageInventory_Click" />
        </div>

        <div class="dashboard-section">
            <h3>View Approved Quotations Request</h3>
            <p>View all approved quotations in the system.</p>
            <asp:Button ID="btnViewApprovedQuotations" runat="server" Text="View Approved Quotations" CssClass="btn-action" OnClick="btnViewApprovedQuotations_Click" />
        </div>

        <div class="dashboard-section">
            <h3>View Approved Quotations</h3>
            <p>View all approved quotations in the system.</p>
            <asp:Button ID="Button1" runat="server" Text="View Approved Quotations" CssClass="btn-action" OnClick="Button1_Click" />
        </div>

    </div>
</asp:Content>
