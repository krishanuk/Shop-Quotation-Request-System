<%@ Page Title="View Quotation Details" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WebForm14.aspx.cs" Inherits="TechFix.WebForm14" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
       
        .quotation-details {
            margin: 20px auto;
            width: 80%;
            padding: 20px;
            background-color: #f9f9f9;
            border-radius: 10px;
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
        }

        /* Header styling */
        .quotation-details h2 {
            text-align: center;
            margin-bottom: 20px;
            font-size: 24px;
            font-weight: bold;
            color: #333;
        }

        /* Controls styling */
        .controls {
            text-align: center;
            margin-bottom: 20px;
        }

        /* Dropdown list */
        .controls select {
            padding: 10px;
            font-size: 16px;
            border: 1px solid #ccc;
            border-radius: 5px;
            width: 200px;
        }

        /* Button styling */
        .controls button, .controls .btn-action {
            padding: 10px 20px;
            font-size: 16px;
            color: white;
            background-color: #007bff;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        /* Hover effect for buttons */
        .controls button:hover, .controls .btn-action:hover {
            background-color: #0056b3;
        }

        /* Error/success message styling */
        .message {
            color: #e74c3c;
            font-size: 16px;
            text-align: center;
            margin-bottom: 20px;
        }

        /* Loading indicator */
        .loading-indicator {
            display: none;
            text-align: center;
            font-size: 18px;
            color: #007bff;
        }

        /* GridView styling */
        .quotation-details .gridview {
            width: 100%;
            margin-top: 20px;
            border-collapse: collapse;
        }

        .quotation-details .gridview th {
            background-color: #007bff;
            color: white;
            padding: 12px;
            text-align: left;
        }

        .quotation-details .gridview td {
            padding: 12px;
            border-bottom: 1px solid #ddd;
        }

        /* Hover effect for rows */
        .quotation-details .gridview tr:hover {
            background-color: #f1f1f1;
        }

        /* Subtotal container */
        .subtotal-container {
            text-align: center;
            font-size: 18px;
            font-weight: bold;
            margin-top: 20px;
            color: #333;
        }

        /* Delete button styling */
        .btnDelete {
            background-color: #e74c3c;
            color: white;
            padding: 8px 16px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .btnDelete:hover {
            background-color: #c0392b;
        }

        /* Send to approval button */
        .btnSendToApproval {
            padding: 10px 20px;
            background-color: #28a745;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .btnSendToApproval:hover {
            background-color: #218838;
        }
    </style>
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
            <asp:Button ID="btnShowDetails" runat="server" Text="Show Details" OnClick="btnShowDetails_Click" CssClass="btn-action" />
        </div>

        <asp:Panel ID="pnlQuotationDetails" runat="server">
            <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label>
            <asp:Label ID="lblLoading" runat="server" CssClass="loading-indicator" Text="Loading..." Visible="False"></asp:Label>

            <asp:GridView ID="gvQuotationDetails" runat="server" AutoGenerateColumns="False" DataKeyNames="QuotationRequestID" CssClass="gridview"
                OnRowCommand="gvQuotationDetails_RowCommand">
                <Columns>
                    <asp:BoundField DataField="QuotationRequestID" HeaderText="Quotation ID" />
                    <asp:BoundField DataField="RequestDate" HeaderText="Request Date" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="RequestedByUserID" HeaderText="Requested By User ID" />
                    <asp:BoundField DataField="SupplierType" HeaderText="Supplier Type" />
                    <asp:BoundField DataField="ProductID" HeaderText="Product ID" />
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="QuotedPrice" HeaderText="Quoted Price" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" DataFormatString="{0:C}" />
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

        <div class="controls">
            <asp:Button ID="btnSendToApproval" runat="server" Text="Send to Approval" OnClick="btnSendToApproval_Click" CssClass="btnSendToApproval" />
        </div>

    </div>
</asp:Content>
