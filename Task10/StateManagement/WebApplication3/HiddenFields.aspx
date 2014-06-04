<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HiddenFields.aspx.cs" Inherits="WebApplication3.HiddenFields" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>чтобы преобразовать в Base64 введите строку и нажмите Button<br/>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br/>
        <asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox><br/>
        <asp:Button ID="Button1" runat="server" Text="Button" />
    </div>
    </form>
</body>
</html>
