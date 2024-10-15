<%@ Page Title="View Quotation Details" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ViewQuotationRequest.aspx.cs" Inherits="TechFix.WebForm8" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <link href='<%= ResolveUrl("~/Style/ViewQuotationRequest.css") %>' rel="stylesheet" type="text/css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="quotation-details">
        <h2>Quotation Details</h2>

        <div class="controls">
            <asp:DropDownList ID="ddlSupplierType" runat="server">
                <asp:ListItem Text="Select Supplier" Value="" />
                <asp:ListItem Text="Supplier A" Value="A" />
                <asp:ListItem Text="Supplier B" Value="B" />
            </asp:DropDownList>
            <asp:Button ID="btnShowDetails" runat="server" Text="Show Details" OnClick="btnShowDetails_Click" />
        </div>

        <asp:Panel ID="pnlQuotationDetails" runat="server">
            <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label>
            <asp:Label ID="lblLoading" runat="server" CssClass="loading-indicator" Text="Loading..." Visible="False"></asp:Label>
            <asp:GridView ID="gvQuotationDetails" runat="server" AutoGenerateColumns="False" DataKeyNames="QuotationRequestID"
                CssClass="gridview" HeaderStyle-CssClass="gridview-header" RowStyle-CssClass="gridview-row"
                FooterStyle-CssClass="gridview-footer" AlternatingRowStyle-CssClass="gridview-alt-row" OnSelectedIndexChanged="gvQuotationDetails_SelectedIndexChanged">
    <Columns>
        <asp:BoundField DataField="QuotationRequestID" HeaderText="Quotation ID" ItemStyle-CssClass="gridview-cell" />
        <asp:BoundField DataField="RequestDate" HeaderText="Request Date" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-CssClass="gridview-cell" />
        <asp:BoundField DataField="RequestedByUserID" HeaderText="Requested By User ID" ItemStyle-CssClass="gridview-cell" />
        <asp:BoundField DataField="SupplierType" HeaderText="Supplier Type" ItemStyle-CssClass="gridview-cell" />
        <asp:BoundField DataField="ProductID" HeaderText="Product ID" ItemStyle-CssClass="gridview-cell" />
        <asp:BoundField DataField="ProductName" HeaderText="Product Name" ItemStyle-CssClass="gridview-cell" />
        <asp:BoundField DataField="Quantity" HeaderText="Quantity" ItemStyle-CssClass="gridview-cell" />
        <asp:BoundField DataField="QuotedPrice" HeaderText="Quoted Price" DataFormatString="{0:C}" ItemStyle-CssClass="gridview-cell" />
        <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" DataFormatString="{0:C}" ItemStyle-CssClass="gridview-cell" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteQuotation" CssClass="btnDelete"
                    CommandArgument='<%# Eval("QuotationRequestID") + "," + Eval("SupplierType") %>'
                    OnClientClick="return confirm('Are you sure you want to delete this quotation?');" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

        </asp:Panel>

        <div class="subtotal-container">
            <asp:Label ID="lblSubtotal" runat="server" Text="Subtotal: $0.00"></asp:Label>
        </div>

        <!-- Add the Send to Approval Button here -->
        <div class="controls">
            <asp:Button ID="btnSendToApproval" runat="server" Text="Send to Approval" OnClick="btnSendToApproval_Click" />
        </div>

    </div>
</asp:Content>