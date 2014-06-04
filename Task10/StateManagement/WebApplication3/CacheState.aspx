<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CacheState.aspx.cs" Inherits="WebApplication3.CacheState" %>
<%@ OutputCache Duration="60" VaryByParam="none" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <% Response.Write(DateTime.Now.ToString("G"));  %><br/>
        <asp:Button ID="Button1" runat="server" Text="Button" />
    </div>
    </form>
</body>
</html>
