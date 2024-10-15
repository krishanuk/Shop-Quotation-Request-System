<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="TFViewProduct.aspx.cs" Inherits="TechFix.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <link href='<%= ResolveUrl("~/Style/TFViewProduct.css") %>' rel="stylesheet" type="text/css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-container">
        <asp:Label ID="lblError" runat="server" CssClass="error-message"></asp:Label>

        
        <div style="margin-bottom: 20px;">
            <asp:Label ID="lblShippingAddress" runat="server" Text="Shipping Address:" CssClass="form-label" />
            <asp:TextBox ID="txtShippingAddress" runat="server" CssClass="shipping-address-textbox" TextMode="MultiLine" Rows="3" Width="100%" />
        </div>

        <div class="gridview-container">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID"
                OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" CssClass="gridview">
                <Columns>
                    <asp:BoundField DataField="ProductID" HeaderText="ID" ItemStyle-CssClass="gridview-cell" HeaderStyle-CssClass="gridview-header"/>
                    <asp:BoundField DataField="ProductName" HeaderText="Name" ItemStyle-CssClass="gridview-cell" HeaderStyle-CssClass="gridview-header"/>
                    <asp:BoundField DataField="ProductPrice" HeaderText="Price" ItemStyle-CssClass="gridview-cell" HeaderStyle-CssClass="gridview-header"/>
                    <asp:BoundField DataField="ProductDescription" HeaderText="Description" ItemStyle-CssClass="gridview-cell" HeaderStyle-CssClass="gridview-header"/>
                    <asp:BoundField DataField="Category" HeaderText="Category" ItemStyle-CssClass="gridview-cell" HeaderStyle-CssClass="gridview-header"/>
                    <asp:BoundField DataField="Supplier" HeaderText="Supplier" ItemStyle-CssClass="gridview-cell" HeaderStyle-CssClass="gridview-header"/>
                    <asp:BoundField DataField="ProductQuantity" HeaderText="Quantity" ItemStyle-CssClass="gridview-cell" HeaderStyle-CssClass="gridview-header"/>
                    <asp:TemplateField HeaderText="Product Image">
                        <ItemTemplate>
                            <asp:Image ID="imgProduct" runat="server" CssClass="gridview-image" Width="100px" Height="100px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:TextBox ID="txtOrderQuantity" runat="server" CssClass="order-quantity" Text="1" Width="50px" />
                            <asp:Button ID="btnOrderNow" runat="server" Text="Order Now" CommandName="OrderNow" CommandArgument='<%# Container.DisplayIndex %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
