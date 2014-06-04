<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlState.aspx.cs" Inherits="WebApplication3.ControlState" EnableViewState="false" %>

<%@ Register Src="~/App/WebUserControl1.ascx" TagPrefix="uc1" TagName="WebUserControl1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:WebUserControl1 runat="server" id="WebUserControl1" />
    </div>
    </form>
</body>
</html>
