<%@ Page Title="Manage Product" Language="C#" MasterPageFile="~/SuplierMaster.Master" AutoEventWireup="true" CodeBehind="ManageProduct.aspx.cs" Inherits="TechFix.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .product-form {
            margin: 0 auto;
            padding: 20px;
            width: 50%;
            background-color: #f9f9f9;
            border: 1px solid #ccc;
            border-radius: 8px;
        }
        .product-form h3 {
            margin-bottom: 20px;
            color: #333;
        }
        .form-group {
            margin-bottom: 15px;
        }
        .form-group label {
            display: block;
            font-weight: bold;
        }
        .form-group input[type="text"],
        .form-group input[type="number"],
        .form-group textarea,
        .form-group select {
            width: 100%;
            padding: 8px;
            margin-top: 5px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }
        .btn-group {
            margin-top: 20px;
        }
        .btn-group input {
            margin-right: 10px;
            padding: 10px 20px;
            border: none;
            color: white;
            border-radius: 5px;
            cursor: pointer;
        }
        .btn-add { background-color: #28a745; }
        .btn-find { background-color: #007bff; }
        .btn-update { background-color: #ffc107; }
        .btn-delete { background-color: #dc3545; }
        .success-message {
            color: green;
            font-weight: bold;
            margin-bottom: 20px;
        }
        .error-message {
            color: red;
            font-weight: bold;
            margin-bottom: 20px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="product-form">
        <h3>Manage Products</h3>

        <asp:Label ID="txtMessage" runat="server" CssClass="" Text=""></asp:Label>

        <div class="form-group">
            <label for="txtProductID">Product ID</label>
            <asp:TextBox ID="txtProductID" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtProductName">Product Name</label>
            <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtProductPrice">Product Price</label>
            <asp:TextBox ID="txtProductPrice" runat="server" CssClass="form-control" OnTextChanged="txtProductPrice_TextChanged" />
        </div>

        <div class="form-group">
            <label for="txtProductQuantity">Product Quantity</label>
            <asp:TextBox ID="txtProductQuantity" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtProductDescription">Product Description</label>
            <asp:TextBox ID="txtProductDescription" runat="server" TextMode="MultiLine" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="ddlCategory">Category</label>
            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Category" Value="" />
                <asp:ListItem Text="Electronics" Value="Electronics" />
                <asp:ListItem Text="Hardware" Value="Hardware" />
                <asp:ListItem Text="components" Value="components" />
                <asp:ListItem Text="Furniture" Value="Furniture" />
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="ddlSupplier">Supplier</label>
            <asp:DropDownList ID="ddlSupplier" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Supplier" Value="" />
                <asp:ListItem Text="A" Value="A" />
                <asp:ListItem Text="B" Value="B" />
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="fileProductImage">Product Image</label>
            <asp:FileUpload ID="fileProductImage" runat="server" CssClass="form-control" />
        </div>

        <div class="btn-group">
            <asp:Button ID="btnAdd" runat="server" Text="Add Product" CssClass="btn-add" OnClick="btnAdd_Click" />
            <asp:Button ID="btnFind" runat="server" Text="Find Product" CssClass="btn-find" OnClick="btnFind_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update Product" CssClass="btn-update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete Product" CssClass="btn-delete" OnClick="btnDelete_Click" />
            <asp:Button ID="btnClear" runat="server" Text="Clear Details" CssClass="btn-delete" OnClick="btnClear_Click" />
        </div>
    </div>
</asp:Content>
