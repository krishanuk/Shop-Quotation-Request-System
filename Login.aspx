<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TechFix.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
<link href="Style/Login.css" rel="stylesheet" type="text/css" />    

</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h1>Login</h1>

            <!-- Error message display -->
            <div class="form-group">
                <asp:Label ID="txtMessage" runat="server" CssClass="error-message" Text=""></asp:Label>
            </div>

            <!-- Username input field -->
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>
                <asp:TextBox ID="uusername" runat="server"></asp:TextBox>
            </div>

            <!-- Password input field -->
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
            </div>

            <!-- Login and Clear buttons -->
            <div class="form-group">
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn btn-primary" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-secondary" />
            </div>
        </div>
    </form>
</body>
</html>
