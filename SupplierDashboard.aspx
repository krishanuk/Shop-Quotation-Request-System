<%@ Page Title="Supplier Dashboard" Language="C#" MasterPageFile="~/SuplierMaster.Master" AutoEventWireup="true" CodeBehind="SupplierDashboard.aspx.cs" Inherits="TechFix.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <link href='<%= ResolveUrl("~/Style/SupplierDashboard.css") %>' rel="stylesheet" type="text/css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="dashboard-header">Supplier Dashboard</div>

    <div class="dashboard-grid">
        <div class="dashboard-section">
            <h3>Manage Products</h3>
            <p>Manage Youre Products Easily</p>
            <asp:Button ID="btnManageProducts" runat="server" Text="Manage Products" CssClass="btn-action" OnClick="btnManageProducts_Click" />
        </div>

        <div class="dashboard-section">
            <h3>View My Listings</h3>
            <p>View all listings here.</p>
            <asp:Button ID="btnViewOrders" runat="server" Text="My Products" CssClass="btn-action" OnClick="btnViewOrders_Click" />
        </div>

        <div class="dashboard-section">
            <h3>My Notification</h3>
            <p>Track Syastem Notification</p>
            <asp:Button ID="btnManageDeliveries" runat="server" Text="View Notifications" CssClass="btn-action" OnClick="btnManageDeliveries_Click" />
        </div>

        <div class="dashboard-section">
            <h3>View Orders</h3>
            <p>View reports on your sales, orders, and delivery performance.</p>
            <asp:Button ID="btnViewReports" runat="server" Text="View Orders" CssClass="btn-action" OnClick="btnViewReports_Click" />
        </div>

        <div class="dashboard-section">
            <h3>View Approved Quotation</h3>
            <p>View request quotations.</p>
            <asp:Button ID="Button1" runat="server" Text="View Quotation" CssClass="btn-action" OnClick="btnViewQuotation_Click" />
        </div>
    </div>
</asp:Content>
