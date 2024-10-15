<%@ Page Title="" Language="C#" MasterPageFile="~/SuplierMaster.Master" AutoEventWireup="true" CodeBehind="ViewProduct.aspx.cs" Inherits="TechFix.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href='<%= ResolveUrl("~/Style/ViewProduct.css") %>' rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="product-details">
        <asp:Label ID="lblError" runat="server" CssClass="error-message"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="gridview" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="ProductID" HeaderText="ID" />
                <asp:BoundField DataField="ProductName" HeaderText="Name" />
                <asp:BoundField DataField="ProductDescription" HeaderText="Description" />
                <asp:BoundField DataField="Category" HeaderText="Category" />
                <asp:BoundField DataField="Supplier" HeaderText="Supplier" />
                <asp:BoundField DataField="ProductQuantity" HeaderText="Quantity" />
                <asp:TemplateField HeaderText="Product Image">
                    <ItemTemplate>
                        <asp:Image ID="imgProduct" runat="server" Width="100px" Height="100px" CssClass="imgProduct" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
