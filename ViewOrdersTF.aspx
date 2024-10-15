<%@ Page Title="View Order Details" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ViewOrdersTF.aspx.cs" Inherits="TechFix.WebForm9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
           <link href='<%= ResolveUrl("~/Style/ViewOrdersTF.css") %>' rel="stylesheet" type="text/css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="order-details">
        <h2>Your Order Details</h2>

        <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label>
        <asp:Label ID="lblLoading" runat="server" CssClass="loading-indicator" Text="Loading..." Visible="False"></asp:Label>

        <asp:GridView ID="gvOrderDetails" runat="server" AutoGenerateColumns="False" CssClass="table" Visible="False">
            <Columns>
                <asp:BoundField DataField="OrderID" HeaderText="Order ID" />
                <asp:BoundField DataField="UserID" HeaderText="User ID" />
                <asp:BoundField DataField="OrderDate" HeaderText="Order Date" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField DataField="ProductID" HeaderText="Product ID" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                <asp:BoundField DataField="ProductPrice" HeaderText="Product Price" DataFormatString="{0:C}" />
                <asp:BoundField DataField="ProductQuantity" HeaderText="Quantity" />
                <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" DataFormatString="{0:C}" />
                <asp:BoundField DataField="OrderStatus" HeaderText="Order Status" />
                <asp:BoundField DataField="Supplier" HeaderText="Supplier" />
                <asp:BoundField DataField="ShippingAddress" HeaderText="Shipping Address" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
