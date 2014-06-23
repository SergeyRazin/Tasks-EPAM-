<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebClient.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="MyCss.css"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1
        {
            width: 246px;
        }
        .auto-style2
        {
            width: 165px;
        }
        .auto-style3
        {
            width: 138px;
        }
        .auto-style4
        {
            width: 147px;
        }
        .auto-style5
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%;" id="tableAccessor">
            <tr>
                <td>
                    <asp:RadioButton ID="RadioBinary" runat="server" GroupName="accessor" />бинарный файл</td>
                <td>
                    <asp:RadioButton ID="RadioXML" runat="server" GroupName="accessor" />xml файл</td>
                <td>
                    <asp:RadioButton ID="RadioDB" runat="server" GroupName="accessor" />база данных;</td>
            </tr>
        </table><br/>
        
        
        
        <table style="width: 100%;" id="tableAction">
            <tr>
                <td>
                    <asp:RadioButton ID="RadioAddOil" runat="server" Text="добавить месторождение" GroupName="action" AutoPostBack="True" OnCheckedChanged="RadioAddOil_CheckedChanged" />
                </td>
                <td>
                    
                    <asp:RadioButton ID="RadioCountOilfield" runat="server" Text="показать количество месторождений"  GroupName="action" AutoPostBack="True" OnCheckedChanged="RadioCountOilfield_CheckedChanged"/>
                </td>  
                <td>
                    <asp:RadioButton ID="RadioCountWells" runat="server" Text="показать количество всех скв" GroupName="action" AutoPostBack="True" OnCheckedChanged="RadioCountWells_CheckedChanged"/>
                </td>
            </tr>
            <tr>
                <td><asp:RadioButton ID="RadioRemoveOilfield" runat="server" Text="удалить месторождение" GroupName="action" AutoPostBack="True" OnCheckedChanged="RadioRemoveOilfield_CheckedChanged"/>;</td>
                <td>
                    <asp:RadioButton ID="RadioUpdateOilfield" runat="server" Text="обновить месторождение" GroupName="action" AutoPostBack="True" OnCheckedChanged="RadioUpdateOilfield_CheckedChanged"/>
                </td>
                <td>
                    <asp:RadioButton ID="RadioCountWellsInOilfield" runat="server" Text="показать коли-во скв месторожд." GroupName="action" AutoPostBack="True" OnCheckedChanged="RadioCountWellsInOilfield_CheckedChanged"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButton ID="RadioAddWell" runat="server" Text="добавить скважину" GroupName="action" AutoPostBack="True" OnCheckedChanged="RadioAddWell_CheckedChanged"/>
                </td>
                <td>
                    <asp:RadioButton ID="RadioGetAllOilfield" runat="server" Text="показать все" GroupName="action" AutoPostBack="True" OnCheckedChanged="RadioGetAllOilfield_CheckedChanged"/>
                </td>
                <td>
                    <asp:RadioButton ID="RadioGetOilfieldByIndex" runat="server"  Text="получить месторождение по id" GroupName="action" AutoPostBack="True" OnCheckedChanged="RadioGetOilfieldByIndex_CheckedChanged"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButton ID="RadioRemoveWell" runat="server" Text="удалить скважину" GroupName="action" AutoPostBack="True" OnCheckedChanged="RadioRemoveWell_CheckedChanged"/>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:RadioButton ID="RadioClear" runat="server" Text="удалить все" GroupName="action" AutoPostBack="True" OnCheckedChanged="RadioClear_CheckedChanged"/>
                </td>
            </tr>
        </table><br/>
        

        <div id="insertInfo">
        <table style="width: 538px;" id="oil">
                <tr>
                    <td class="auto-style4">ID месторождения: </td>
                    <td> <asp:TextBox ID="TextBoxIdOil" runat="server" Width="151px"></asp:TextBox></td>
                    <td class="auto-style1">
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator"></asp:CompareValidator>
                    </td>
                   
                </tr>
                <tr>
                    <td class="auto-style4">имя месторождения:</td>
                    <td>
                        <asp:TextBox ID="TextBoxNameOil" runat="server" Width="151px"></asp:TextBox>
                    </td>
                    <td class="auto-style1"></td>
                    
                </tr>
                <tr>
                    <td class="auto-style4">запасы нефти:</td>
                    <td>
                        <asp:TextBox ID="TextBoxReserve" runat="server" Width="152px"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="CompareValidator"></asp:CompareValidator>
                    </td>
                   
                </tr>
            </table><br/>

        <table style="width:539px;" id="well">
            <tr>
                <td class="auto-style3">номер скважины: </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxNumber" runat="server" Width="154px"></asp:TextBox>
                </td>
                <td>
                    <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="CompareValidator"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">дебит скважины:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxDebit" runat="server" Width="154px"></asp:TextBox>
                </td>
                <td>
                    <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="CompareValidator"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">марка насоса:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxPump" runat="server" Width="154px"></asp:TextBox>
                </td>
                <td></td>
            </tr>
        </table>
            
            </div>
        <br/>
        
        <div id="grid">
            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="180px" Width="517px">
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
        </div>
        
        <div id="clear">
            <asp:Panel ID="Panel1" runat="server">
                <table class="auto-style5">
                    <tr>
                        <td>введите значение капчи↓</td>
                    </tr>
                    <tr>
                        <td><img src="myproject/captcha.aspx" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="TextBoxCaptcha" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </div>
        <p>
        <asp:Button ID="ButtonOk" runat="server" Text="Ok" Height="52px" Width="101px" OnClick="ButtonOk_Click" />
        </p>
    </form>
</body>
</html>
