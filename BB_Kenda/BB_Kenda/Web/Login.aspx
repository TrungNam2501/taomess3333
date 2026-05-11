<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BB_Kenda.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login BB TOOLS</title>
    <link rel="icon" href="../Assets/image/KendaLogo.png" />
    <script src="../Assets/Script/jquery-3.4.0.min.js"></script>
    <script src="../Assets/Script/bootstrap.js"></script>
    <link href="../Assets/Css/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table style="position: absolute; width: 100%; height: 100%; top: 0; left: 0; background-image: url('/Assets/image/nencanh.jpg'); background-repeat: no-repeat; background-size: cover">
            <tr>
                <td>
                    <table style="width: 350px; height: 45%; margin-left: auto; margin-right: auto; box-sizing: border-box; border-radius: 10px; overflow: hidden; background-color: #faf6fe; box-shadow: 0 0 2px 2px;text-align:center">
                        <tr style="text-align: center;height:30%">
                            <td class="auto-style1">
                                <div>
                                    <img width="170" height="170" src="../Assets/image/logokenda.png" />
                                </div>
                            </td>
                        </tr>
                        <tr style="text-align:-webkit-center;height:7%">
                            <td>
                                <asp:Label runat="server" ID="lblthongbao" Style="color: red; font-size: 15px; font-weight: bold; font-family: 'Times New Roman'"></asp:Label>
                            </td>
                        </tr>
                        <tr style="text-align:-webkit-center;height:10px">
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtUsername" required="on" Style="font-family: Arial; font-size: 16px; font-weight: bold; width: 250px; text-align: center; background-color: transparent; color: black" CssClass="form-control" placeholder="User Name" runat="server"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr style="text-align:-webkit-center;height:10px">
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtPassword" required="on" TextMode="Password" Style="font-family: Arial; font-size: 16px; font-weight: bold; width: 250px; text-align: center; background-color: transparent; color: black" CssClass="form-control" placeholder="Password" runat="server"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style=" text-align: center;padding-top:initial;height:40%">
                                <asp:Button ID="btnLogin" CssClass="btn btn-primary" Style="color: white;font-weight:bold;font-family:Arial" OnClick="btnLogin_Click" runat="server" Text="LOGIN" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="GetIP" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
