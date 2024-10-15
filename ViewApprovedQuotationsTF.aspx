<%@ Page Title="Approved Quotations" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ViewApprovedQuotationsTF.aspx.cs" Inherits="TechFix.WebForm13" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <link href='<%= ResolveUrl("~/Style/ViewApprovedQuotationsTF.css") %>' rel="stylesheet" type="text/css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Quotation Panel -->
    <div class="quotation-panel">
        <div class="quotation-header">All Approved Quotations</div>

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

        <!-- Label for displaying error messages -->
        <asp:Label ID="lblMessage" runat="server" CssClass="error-message" Visible="False"></asp:Label>
    </div>
</asp:Content>
