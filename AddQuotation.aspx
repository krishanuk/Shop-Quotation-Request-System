<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AddQuotation.aspx.cs" Inherits="TechFix.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* General page container style */
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f4f4f9;
            margin: 0;
            padding: 0;
        }

        .content-container {
            padding: 20px;
            max-width: 1200px;
            margin: 20px auto;
            background-color: #ffffff;
            border-radius: 10px;
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
        }

        /* Style for error messages */
        .error-message {
            color: #e74c3c;
            font-size: 16px;
            margin-bottom: 20px;
        }

        /* Form label styling */
        .form-label {
            display: block;
            font-weight: bold;
            margin-bottom: 10px;
            font-size: 14px;
        }

        /* Dropdown list styling */
        .ddl-supplier {
            width: 100%;
            padding: 10px;
            border: 1px solid #ced4da;
            border-radius: 5px;
            font-size: 14px;
            box-shadow: inset 0 2px 4px rgba(0, 0, 0, 0.05);
            background-color: #fff;
        }

        /* Textbox styling for quantity input */
        .quantity-textbox {
            padding: 5px;
            border-radius: 5px;
            border: 1px solid #ced4da;
            width: 50px;
            text-align: center;
        }

        .quantity-textbox:focus {
            border-color: #007bff;
            box-shadow: 0 0 5px rgba(0, 123, 255, 0.25);
            outline: none;
        }

        /* Button styling for Add to Quotation */
        .btnAddToQuotation {
            padding: 10px 20px;
            background-color: #28a745;
            color: #fff;
            border: none;
            border-radius: 5px;
            font-size: 14px;
            cursor: pointer;
            transition: background-color 0.3s ease, transform 0.2s ease;
            box-shadow: 0 3px 6px rgba(0, 0, 0, 0.1);
        }

        .btnAddToQuotation:hover {
            background-color: #218838;
            transform: translateY(-3px);
            box-shadow: 0 6px 12px rgba(0, 0, 0, 0.2);
        }

        .btnAddToQuotation:active {
            background-color: #1e7e34;
            transform: translateY(0);
            box-shadow: 0 3px 6px rgba(0, 0, 0, 0.1);
        }

        .btnAddToQuotation:focus {
            outline: none;
            box-shadow: 0 0 10px rgba(40, 167, 69, 0.5);
        }

        /* GridView container style */
        .gridview-container {
            background-color: #fff;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            overflow: hidden;
            border: 1px solid #ddd;
            margin-top: 20px;
        }

        .gridview-container .gridview-header {
            background-color: #007bff;
            color: #fff;
            text-transform: uppercase;
        }

        .gridview-container .gridview-header th {
            padding: 12px;
            text-align: left;
            border-bottom: 1px solid #ddd;
        }

        .gridview-container .gridview-row {
            border-bottom: 1px solid #ddd;
        }

        .gridview-container .gridview-row:hover {
            background-color: #f9f9f9;
        }

        .gridview-container .gridview-cell {
            padding: 12px;
            text-align: left;
        }

        /* Image styling */
        .gridview-image {
            border-radius: 5px;
            border: 1px solid #ddd;
            padding: 2px;
            background-color: #f9f9f9;
        }

        /* Responsive styling for GridView */
        @media (max-width: 768px) {
            .gridview-container .gridview-header th,
            .gridview-container .gridview-cell {
                padding: 8px;
            }

            .gridview-container .gridview-image {
                width: 80px;
                height: 80px;
            }
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-container">
        <asp:Label ID="lblError" runat="server" CssClass="error-message"></asp:Label>
        
        <!-- Supplier Selection Dropdown -->
        <div style="margin-bottom: 20px;">
            <asp:Label ID="lblSelectSupplier" runat="server" Text="Select Supplier: " CssClass="form-label" />
            <asp:DropDownList ID="ddlSupplierSelect" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSupplierSelect_SelectedIndexChanged">
                <asp:ListItem Text="Select Supplier" Value="0" />
                <asp:ListItem Text="Supplier A" Value="A" />
                <asp:ListItem Text="Supplier B" Value="B" />
            </asp:DropDownList>
        </div>
        
        <div class="gridview-container">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" 
              OnRowCommand="GridView1_RowCommand" CssClass="gridview">
                <Columns>
                    <asp:BoundField DataField="ProductID" HeaderText="ID" ItemStyle-CssClass="gridview-cell" HeaderStyle-CssClass="gridview-header"/>
                    <asp:BoundField DataField="ProductName" HeaderText="Name" ItemStyle-CssClass="gridview-cell" HeaderStyle-CssClass="gridview-header"/>
                    <asp:BoundField DataField="ProductPrice" HeaderText="Price" ItemStyle-CssClass="gridview-cell" HeaderStyle-CssClass="gridview-header"/>
                    <asp:BoundField DataField="ProductDescription" HeaderText="Description" ItemStyle-CssClass="gridview-cell" HeaderStyle-CssClass="gridview-header"/>
                    <asp:BoundField DataField="Category" HeaderText="Category" ItemStyle-CssClass="gridview-cell" HeaderStyle-CssClass="gridview-header"/>
                    <asp:BoundField DataField="Supplier" HeaderText="Supplier" ItemStyle-CssClass="gridview-cell" HeaderStyle-CssClass="gridview-header"/>
                    <asp:BoundField DataField="ProductQuantity" HeaderText="Available Quantity" ItemStyle-CssClass="gridview-cell" HeaderStyle-CssClass="gridview-header"/>
                    <asp:TemplateField HeaderText="Product Image">
                        <ItemTemplate>
                            <asp:Image ID="imgProduct" runat="server" CssClass="gridview-image" Width="100px" Height="100px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:TextBox ID="txtQuantity" runat="server" CssClass="quantity-textbox" Text="1" Width="50px" />
                            <asp:Button ID="btnAddToQuotation" runat="server" Text="Add to Quotation" CommandName="AddToQuotation" CommandArgument='<%# Eval("ProductID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
