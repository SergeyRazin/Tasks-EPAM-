<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfileState.aspx.cs" Inherits="WebApplication3.ProfileState" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="requestedUser" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" />
        

        <%--<div>эта старинца была показана для пользователя <%: GetCounter() %> раз </div>
        <input id="requestedUser" value="Joe" runat="server"/>
        <button type="submit"></button>--%>
    </div>
    </form>
</body>
</html>
