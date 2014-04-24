<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="StyleSheet1.css" type="text/css"/>
    <title>Hello world</title>
    <style type="text/css">
        .auto-style1
        {
            width: 100%;
            height: 205px;
        }
        .auto-style3
        {
            width: 164px;
        }
        #form1
        {
            height: 458px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style3">
                    <asp:RadioButton ID="radioBinary" runat="server" GroupName="source" />
                </td>
                <td>
                    <asp:RadioButton ID="radioXML" runat="server" GroupName="source" />
                </td>
                <td>
                    <asp:RadioButton ID="radioDB" runat="server" GroupName="source" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButton ID="radioAddPerson" runat="server"  GroupName="action"/>
                </td>
                <td>
                    <asp:RadioButton ID="radioRemovePerson" runat="server" GroupName="action"/>
                </td>
                <td class="auto-style3">
                    <asp:RadioButton ID="radioUpdatePerson" runat="server" GroupName="action" />
                </td>
                <td>
                    <asp:RadioButton ID="radioGetPersonByIndex" runat="server" GroupName="action"/>
                </td>
                <td>
                    <asp:RadioButton ID="radioShowAll" runat="server" GroupName="action"/>
                </td>
                <td>
                    <asp:RadioButton ID="radioCount" runat="server" GroupName="action"/>
                </td>
                <td>
                    <asp:RadioButton ID="radioClear" runat="server" GroupName="action"/>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="labelIndex" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="textboxIndex" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style3">
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="CompareValidator"></asp:CompareValidator>
                </td>
                <td rowspan="3" colspan="3">
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="labelName" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="textboxName" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="labelAge" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="textboxAge" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style3">
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator"></asp:CompareValidator>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="labelPhone" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="textboxPhone" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        
    </div >
        <div align="center" class="grid" class="grid">
            <asp:GridView ID="GridView1" runat="server" Width="400px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#330099" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                <SortedAscendingCellStyle BackColor="#FEFCEB" />
                <SortedAscendingHeaderStyle BackColor="#AF0101" />
                <SortedDescendingCellStyle BackColor="#F6F0C0" />
                <SortedDescendingHeaderStyle BackColor="#7E0000" />
            </asp:GridView>
        </div><br/>
        <div  class="button">
            <asp:Button ID="Button1" runat="server" Text="Ok" Height="66px" Width="146px" OnClick="Button1_Click" />
                    <asp:Label ID="labelError" runat="server" Text=""></asp:Label>
        </div>
        
    </form>
</body>
</html>
