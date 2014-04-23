<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 313px">
    
        <asp:Panel ID="Panel1" runat="server" Height="50px">
            <table class="auto-style1">
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:RadioButton ID="radioBinary" runat="server" GroupName="source" Text="Binary File" />
                    </td>
                    <td>
                        <asp:RadioButton ID="radioXML" runat="server" GroupName="source" Text="XML File" />
                    </td>
                    <td>
                        <asp:RadioButton ID="radioDB" runat="server" GroupName="source" Text="Data Base" />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:RadioButton ID="radioAddPerson" runat="server" GroupName="action" Text="Add Person" />
                    </td>
                    <td>
                        <asp:RadioButton ID="radionRemovePerson" runat="server" GroupName="action" Text="Remove Person" />
                    </td>
                    <td>
                        <asp:RadioButton ID="radioInsertPerson" runat="server" GroupName="action" Text="Insert Person" />
                    </td>
                    <td>
                        <asp:RadioButton ID="radioGetPersonByIndex" runat="server" GroupName="action" Text="Get Person By Index" />
                    </td>
                    <td>
                        <asp:RadioButton ID="radioShowAll" runat="server" GroupName="action" Text="Show All" />
                    </td>
                    <td>
                        <asp:RadioButton ID="radioCount" runat="server" GroupName="action" Text="Count" />
                    </td>
                    <td>
                        <asp:RadioButton ID="radioClear" runat="server" GroupName="action" Text="Clear" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Height="121px" Width="161px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>

            &nbsp;<table class="auto-style1">
                <tr>
                    <td>
                        <asp:Label ID="LabelName" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LabelAge" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxAge" runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LabelIndex" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxIndex" runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="CompareValidator"></asp:CompareValidator>
                    </td>
                </tr>
            </table>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br/><br/>
            &nbsp;
            <br/>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" Height="52px" Width="158px" />
            <br/>
            &nbsp;
            <br/>
            <br/>
            <br/><br/>
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
