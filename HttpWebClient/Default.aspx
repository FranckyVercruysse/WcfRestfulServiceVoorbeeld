<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="HttpWebClient._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        table, th, td {
            border: 1px solid black;
            border-collapse: collapse;
        }

        th, td {
            padding: 5px;
            text-align: left;
        }

        table.fixed {
            table-layout: fixed;
            width: 1000px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table class="fixed">
                <tr>
                    <th>
                        <asp:Button ID="TestGet" runat="server" OnClick="TestGet_Click" Text="Test GET" Width ="120" />
                        <asp:TextBox ID="TextGet" runat="server" Width="200px"></asp:TextBox>
                    </th>
                    <td>
                        <asp:Label ID="lblResultGet" runat="server" BackColor="#FFFFCC"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        <asp:Button ID="TestPost" runat="server" OnClick="TestPost_Click" Text="Test POST" Width="120" /></th>
                    <td>
                        <asp:Label ID="lblResultPost" runat="server" BackColor="#00FF99"></asp:Label>
                        <br />
                        <asp:Label ID="lblResultPostXML" runat="server" BackColor="#FFFF66"></asp:Label>
                    </td>
                    
                </tr>
            </table>
        </div>

    </form>
</body>
</html>
