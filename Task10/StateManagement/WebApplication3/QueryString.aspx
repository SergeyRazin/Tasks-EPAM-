<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryString.aspx.cs" Inherits="WebApplication3.QueryString" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HyperLink ID="HyperLink1"  runat="server" NavigateUrl="QueryString.aspx?hello=10">HyperLink</asp:HyperLink> <br/>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </div>
    </form>
</body>
</html>
