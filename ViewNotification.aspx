<%@ Page Title="Notifications" Language="C#" MasterPageFile="~/SuplierMaster.Master" AutoEventWireup="true" CodeBehind="ViewNotification.aspx.cs" Inherits="TechFix.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href='<%= ResolveUrl("~/Style/ViewNotification.css") %>' rel="stylesheet" type="text/css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="notification-panel">
        <div class="notification-header">Your Notifications</div>

        <!-- Notification Repeater -->
        <asp:Repeater ID="RepeaterNotifications" runat="server">
            <ItemTemplate>
                <div class="notification-item">
                    <p><%# Eval("NotificationMessage") %></p>
                    <time><%# Eval("DateTime") %></time>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <!-- Label for no notifications -->
        <asp:Label ID="lblNoNotifications" runat="server" Text="No notifications available." Visible="False" />
    </div>
</asp:Content>
