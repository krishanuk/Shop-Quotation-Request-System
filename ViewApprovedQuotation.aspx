<%@ Page Title="Approved Quotations" Language="C#" MasterPageFile="~/SuplierMaster.Master" AutoEventWireup="true" CodeBehind="ViewApprovedQuotation.aspx.cs" Inherits="TechFix.WebForm12" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <link href='<%= ResolveUrl("~/Style/ViewApprovedQuotation.css") %>' rel="stylesheet" type="text/css" />
    <style>
        
* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}

body {
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    background-color: #f2f2f2; 
}

/* Quotation Panel Styling */
.quotation-panel {
    background-color: #fff; 
    border-radius: 8px; 
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1); 
    padding: 20px; 
    margin: 20px auto; 
    max-width: 800px; 
}

/* Quotation Header Styling */
.quotation-header {
    font-size: 28px; 
    font-weight: bold; 
    color: #333; 
    margin-bottom: 20px; 
    text-align: center; 
}

/* GridView Container Styling */
.grid-container {
    width: 100%; 
    border-collapse: collapse; 
}

/* GridView Header Styling */
.grid-container th {
    background-color: #007bff; 
    color: #fff; 
    padding: 12px; 
    text-align: left; 
}

.grid-container td {
    border: 1px solid #ddd; 
    padding: 10px; 
    background-color: #f9f9f9; 
}

.grid-container tr:hover {
    background-color: #f1f1f1; 
}

.error-message {
    color: #e74c3c; 
    font-size: 14px; 
    margin-top: 10px; 
}

/* Subtotal Label Styling */
.subtotal-label {
    font-size: 16px; 
    font-weight: bold; 
    margin-top: 20px; 
    color: #333; 
}

    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Quotation Panel -->
    <div class="quotation-panel">
        <div class="quotation-header">Approved Quotations</div>

        <!-- GridView to display approved quotations -->
        <asp:GridView ID="gvApprovedQuotations" runat="server" AutoGenerateColumns="False" CssClass="grid-container" Visible="False">
            <Columns>
                <asp:BoundField DataField="ApprovedQuotationID" HeaderText="Quotation ID" />
                <asp:BoundField DataField="RequestDate" HeaderText="Request Date" DataFormatString="{0:MM/dd/yyyy}" />
                <asp:BoundField DataField="SupplierType" HeaderText="Supplier Type" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="QuotedPrice" HeaderText="Quoted Price" DataFormatString="{0:C}" />
                <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>

        <asp:Label ID="Label3" runat="server" CssClass="error-message" Visible="False"></asp:Label>


        <asp:Label ID="Label2" runat="server" CssClass="error-message" Visible="False"></asp:Label>


        <asp:Label ID="Label1" runat="server" CssClass="error-message" Visible="False"></asp:Label>


        <asp:Label ID="lblSubtotal" runat="server" CssClass="subtotal-label" Visible="False"></asp:Label>

        <asp:Label ID="lblMessage" runat="server" CssClass="error-message" Visible="False"></asp:Label>
    </div>
</asp:Content>
