<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dataoil.aspx.cs" Inherits="BB_Kenda.Web.dataoil" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Xem dữ liệu quét bồn dầu</title>
    <link href="../Assets/Css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/Css/CssGV123.css" rel="stylesheet" />
    <link href="../Assets/Script/jquery-ui.css" rel="stylesheet" />
    <script src="../Assets/master/jquery.min.js"></script>
    <script src="../Assets/master/bootstrap.min.js"></script>
    <script src="../Assets/Script/jquery-ui.js"></script>

    <style>
        /* CSS tùy chỉnh cho giao diện */
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f5f5f5;
        }

        .container {
            display: flex;
            justify-content: flex-start;
            padding: 10px;
        }

        /* Sidebar bên trái */
        .sidebar {
            width: 20%; /* Thay đổi giá trị width để sidebar rộng hơn */
            padding: 10px;
            background-color: gainsboro;
            border: 1px solid #ddd;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }



        /* Nội dung chính bên phải */
        .content {
            flex-grow: 1;
            padding: 20px;
            background-color: #f9f9f9;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            width: 80%; /* Đảm bảo rằng content chiếm phần còn lại */
        }

        h1 {
            font-size: 24px;
            color: darkred;
            text-align: center;
            margin-bottom: 20px;
        }

        /* Tùy chỉnh GridView */
        .custom-grid {
            border: 1px solid #ccc;
            font-size: 14px;
            width: 100%;
            background-color: #ffffff;
            border-collapse: collapse;
            table-layout: fixed;
        }

            .custom-grid th {
                background-color: #007bff;
                color: white;
                font-weight: bold;
                text-align: center;
                padding: 10px;
                position: sticky;
                top: 0; /* Giữ tiêu đề ở trên cùng */
                z-index: 10;
            }

            .custom-grid td {
                padding: 8px;
                text-align: center;
                border-bottom: 1px solid #ddd;
            }

            .custom-grid tr:hover {
                background-color: #f1f1f1;
            }

        .form-control, .btn {
            font-size: 14px;
            margin: 10px 0;
        }

        .btn {
            margin-right: 10px;
        }

        hr {
            border: 1px solid #007bff;
        }

        /* Thanh cuộn cho bảng */
        .grid-container {
            height: 650px; /* Chiều cao cố định của khu vực bảng */
            overflow-y: auto;
            width: 100%;
        }

        /* Responsive */
        @media (max-width: 768px) {
            .container {
                flex-direction: column;
            }

            .sidebar {
                width: 100%;
                border-right: none;
                border-bottom: 1px solid #ddd;
            }

            .content {
                margin-top: 20px;
            }
        }

        .filter-container {
            display: flex;
            flex-direction: column;
            align-items: center; /* Căn giữa các phần tử */
            margin: 20px 0;
        }

        .form-group {
            display: flex;
            align-items: center;
            margin-bottom: 15px;
        }

        .cssLabel {
            margin-right: 10px; /* Khoảng cách giữa label và dropdown */
            font-weight: bold;
        }

        .button-group {
            display: flex;
            gap: 10px; /* Khoảng cách giữa hai nút bấm */
            justify-content: center;
        }

        .form-control {
            width: 100px; /* Điều chỉnh chiều rộng dropdown */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <!-- Sidebar bên trái -->
            <div class="sidebar">
                <h1>View oil tank scan data</h1>
                <hr />
                <div class="filter-container">
                    <div class="form-group">
                        <label class="cssLabel">Oil type:</label>
                        <asp:DropDownList ID="dr_Loaidau" runat="server" CssClass="form-control">
                            <asp:ListItem Text="ALL" Value="" Enabled="true"></asp:ListItem>
                            <asp:ListItem Text="41037" Value="41037"></asp:ListItem>
                            <asp:ListItem Text="68041" Value="68041"></asp:ListItem>
                            <asp:ListItem Text="68010" Value="68010"></asp:ListItem>
                            <asp:ListItem Text="68046" Value="68046"></asp:ListItem>
                            <asp:ListItem Text="68020" Value="68020"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="button-group">
                        <asp:Button ID="btnXem" OnClick="btnXem_Click" runat="server" CssClass="btn btn-success" Text="Search" />
                        <asp:Button ID="btnExcel" OnClick="btnExcel_Click" runat="server" CssClass="btn btn-primary" Text="Export excel" />
                    </div>
                </div>

            </div>

            <!-- Nội dung chính chứa GridView -->
            <div class="content">
                <div class="grid-container">
                    <asp:GridView ID="gvDataOil" runat="server" CssClass="custom-grid table-hover" AutoGenerateColumns="false">
                        <HeaderStyle CssClass="custom-grid-header" />
                        <RowStyle CssClass="custom-grid-row" />
                        <Columns>
                            <asp:BoundField DataField="Indat" HeaderText="Indat" />
                            <asp:BoundField DataField="Intime" HeaderText="Intime" />
                            <asp:BoundField DataField="Result_ActiveUp" HeaderText="Result_ActiveUp" />
                            <asp:BoundField DataField="HMI_Barcode" HeaderText="HMI_Barcode" />
                            <asp:BoundField DataField="Barcode_left_7bit" HeaderText="Barcode_left_7bit" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

