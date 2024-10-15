<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManage.aspx.cs" Inherits="TechFix.UserManage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Management</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }
        form {
            width: 100%;
            max-width: 600px;
            margin: 50px auto;
            padding: 20px;
            background-color: #fff;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }
        div {
            margin-bottom: 15px;
        }
        label {
            font-weight: bold;
            display: block;
            margin-bottom: 5px;
        }
        input[type="text"], input[type="password"] {
            width: 100%;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }
        .button-group {
            display: flex;
            justify-content: space-between;
        }
        input[type="submit"], input[type="button"] {
            padding: 10px 20px;
            background-color: #007BFF;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }
        input[type="submit"]:hover, input[type="button"]:hover {
            background-color: #0056b3;
        }
        #txtMessage {
            color: red;
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>User Management</h2>
        <div>
            <label for="uuserid">User ID</label>
            <asp:TextBox ID="uuserid" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="uusername">Username</label>
            <asp:TextBox ID="uusername" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="password">Password</label>
            <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <label for="email">Email</label>
            <asp:TextBox ID="email" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="role">Role</label>
            <asp:TextBox ID="role" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="shop">Shop</label>
            <asp:TextBox ID="shop" runat="server"></asp:TextBox>
        </div>
        <asp:Label ID="txtMessage" runat="server" Text=""></asp:Label>
        <div class="button-group">
            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnFind" runat="server" Text="Find" OnClick="btnFind_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        </div>
    </form>
</body>
</html>
