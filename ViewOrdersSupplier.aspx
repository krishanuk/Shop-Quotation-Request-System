<%@ Page Title="" Language="C#" MasterPageFile="~/SuplierMaster.Master" AutoEventWireup="true" CodeBehind="ViewOrdersSupplier.aspx.cs" Inherits="TechFix.WebForm10" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <link href='<%= ResolveUrl("~/Style/ViewOrdersSupplier.css") %>' rel="stylesheet" type="text/css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="order-details">
        <h2>Your Order Details</h2>

        <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label>
        <asp:Label ID="lblLoading" runat="server" CssClass="loading-indicator" Text="Loading..." Visible="False"></asp:Label>

        <asp:GridView ID="gvOrderDetails" runat="server" AutoGenerateColumns="False" CssClass="gridview" Visible="False" OnRowCommand="gvOrderDetails_RowCommand">
            <Columns>
                <asp:BoundField DataField="OrderID" HeaderText="Order ID" />
                <asp:BoundField DataField="UserID" HeaderText="User ID" />
                <asp:BoundField DataField="OrderDate" HeaderText="Order Date" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField DataField="ProductID" HeaderText="Product ID" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                <asp:BoundField DataField="ProductPrice" HeaderText="Product Price" DataFormatString="{0:C}" />
                <asp:BoundField DataField="ProductQuantity" HeaderText="Quantity" />
                <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" DataFormatString="{0:C}" />
                <asp:TemplateField HeaderText="Order Status">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlOrderStatus" runat="server" SelectedValue='<%# Eval("OrderStatus") %>'>
                            <asp:ListItem Value="Pending">Pending</asp:ListItem>
                            <asp:ListItem Value="Confirmed">Confirmed</asp:ListItem>
                            <asp:ListItem Value="Cancel">Cancel</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Supplier" HeaderText="Supplier" />
                <asp:BoundField DataField="ShippingAddress" HeaderText="Shipping Address" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="btnUpdateStatus" runat="server" CommandName="UpdateStatus" CommandArgument='<%# Eval("OrderID") %>' Text="Update" CssClass="btnUpdateStatus" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
