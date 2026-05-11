<%@ Page Title="" Language="C#" MasterPageFile="~/Web/MasterWeb.Master" AutoEventWireup="true" CodeBehind="XemMES.aspx.cs" Inherits="BB_Kenda.Web.XemMES" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .cssLabel {
            font-size: 18px;
            font-weight: bold;
            font-family: Arial;
            color: black;
        }

        .trcls {
            height: 65px;
        }

        .form-control {
            font-size: 14px;
            font-weight: bold;
            font-family: Arial;
            color: black;
        }
    </style>
    <script>
        $(document).ready(function () {
            $("#<%=txtFromDay.ClientID%>").datepicker({ dateFormat: "yy-mm-dd" });
        });
        $(document).ready(function () {
            $("#<%=txtToDay.ClientID%>").datepicker({ dateFormat: "yy-mm-dd" });
        });

        function ShowgvInfo() {
            $("#tbl_gvData").fadeIn();
            $("#tbl_gvData1").css("transform", "scale(1)");
        }

        function closeMessage() {
            $("#tbl_gvData").fadeOut(200);
            $("#tbl_Messages").fadeOut(200);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center; height: 60px">
        <p style="font-size: 60px; font-weight: bold; font-family: Arial; color: darkred">Xem dữ liệu mã MES</p>
    </div>
    <hr style="border: 1px solid #007bff;" />
    <div style="padding-left: 30px">
        <table>
            <tr>
                <td>
                    <label class="cssLabel">Từ ngày: </label>
                </td>
                <td>
                    <asp:TextBox ID="txtFromDay" autocomplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
                <td style="padding-left: 25px">
                    <label class="cssLabel">Đến ngày: </label>
                </td>
                <td>
                    <asp:TextBox ID="txtToDay" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                </td>
                <td style="padding-left: 25px">
                    <label class="cssLabel">Xưởng: </label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Tất cả" Value="" Enabled="true"></asp:ListItem>
                        <asp:ListItem Text="KV" Value="4" Enabled="true"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="padding-left: 25px">
                    <label class="cssLabel">Ca: </label>
                </td>
                <td>
                    <asp:DropDownList ID="dr_Ca" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Tất cả" Value="" Enabled="true"></asp:ListItem>
                        <asp:ListItem Text="1" Value="1" Enabled="true"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2" Enabled="true"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="padding-left: 25px">
                    <label class="cssLabel">Loại KEO: </label>
                </td>
                <td>
                    <asp:DropDownList ID="dr_typeRecipe" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Tất cả" Value="" Enabled="true"></asp:ListItem>
                        <asp:ListItem Text="RB" Value="RB" Enabled="true"></asp:ListItem>
                        <asp:ListItem Text="RC" Value="RC" Enabled="true"></asp:ListItem>
                        <asp:ListItem Text="RD" Value="RD" Enabled="true"></asp:ListItem>
                        <asp:ListItem Text="RE" Value="RR" Enabled="true"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="padding-left: 25px">
                    <label class="cssLabel">Máy: </label>
                </td>
                <td>
                    <asp:DropDownList ID="dr_May" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Tất cả" Value="" Enabled="true"></asp:ListItem>
                        <asp:ListItem Text="V-BB3701" Value="V-BB3701"></asp:ListItem>
                        <asp:ListItem Text="V-BB3702" Value="V-BB3702"></asp:ListItem>
                        <asp:ListItem Text="V-BB3703" Value="V-BB3703"></asp:ListItem>
                        <asp:ListItem Text="V-BB3704" Value="V-BB3704"></asp:ListItem>
                        <asp:ListItem Text="V-BB3705" Value="V-BB3705"></asp:ListItem>
                        <asp:ListItem Text="V-BB3706" Value="V-BB3706"></asp:ListItem>
                        <asp:ListItem Text="V-BB3707" Value="V-BB3707"></asp:ListItem>
                        <asp:ListItem Text="V-BB3708" Value="V-BB3708"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="padding-left: 25px">
                    <asp:Button ID="btnXem" runat="server" CssClass="btn btn-danger" OnClick="btnXem_Click" Text="Truy Vấn" />
                </td>
                
            </tr>
            <tr>
                <td colspan="2" style="padding-top:15px">
                    <asp:Label ID="lbCount" runat="server" CssClass="cssLabel" Style="float: right; color: red;font-weight:bold"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div style="height: 30px">
    </div>
    <div class="cell">
        <div style="height: 600px; width: 100%; overflow-y: scroll;">
            <table style="margin: auto;">
                <tr>
                    <td>
                        <asp:GridView ID="gvData" OnRowCommand="gvData_RowCommand" OnRowDataBound="gvData_RowDataBound" runat="server" CssClass="table tablehaile table-hover table-responsive table table-responsive table-bordered" Style="border: double; background-color: white; font-size: 16px; font-weight: bold; font-family: Arial" AutoGenerateColumns="false">
                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                            <RowStyle CssClass="GridViewRowStyle" />
                            <Columns>
                                <asp:TemplateField ShowHeader="false" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderText="Xem Liệu">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton2" ImageUrl="~/Assets/image/eye.png" Width="50px" Height="50px" CommandName="btnCheck" CommandArgument='<%# Eval("mesid") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Số thứ tự">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="subno" ItemStyle-CssClass="jsbang" ItemStyle-HorizontalAlign="Center" HeaderText="Khu Vực" />
                                <asp:BoundField DataField="factory" ItemStyle-CssClass="jsbang" ItemStyle-HorizontalAlign="Center" HeaderText="Xưởng" />
                                <asp:BoundField DataField="machno" ItemStyle-CssClass="jsbang" ItemStyle-HorizontalAlign="Center" HeaderText="Máy" />
                                <asp:BoundField DataField="mesid" ItemStyle-CssClass="jsbang" ItemStyle-HorizontalAlign="Center" HeaderText="Mã MES" />
                                <asp:BoundField DataField="class" ItemStyle-CssClass="jsbang" ItemStyle-HorizontalAlign="Center" HeaderText="Ca" />
                                <asp:BoundField DataField="recipe_name" ItemStyle-CssClass="jsbang" ItemStyle-HorizontalAlign="Center" HeaderText="Tên Keo" />
                                <asp:BoundField DataField="weight" ItemStyle-CssClass="jsbang" ItemStyle-HorizontalAlign="Center" HeaderText="Số mẻ" />
                                <asp:BoundField DataField="pday" ItemStyle-CssClass="jsbang" ItemStyle-HorizontalAlign="Center" HeaderText="Ngày Tạo SX" />
                                <asp:BoundField DataField="indat" ItemStyle-CssClass="jsbang" ItemStyle-HorizontalAlign="Center" HeaderText="Ngày Tạo" />
                                <asp:BoundField DataField="intime" ItemStyle-CssClass="jsbang" ItemStyle-HorizontalAlign="Center" HeaderText="Thời Gian Tạo" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div>
        <table id="tbl_gvData" style="display: none; position: absolute; top: 0; left: 0; width: 100%; height: 100%; background-color: rgba(0, 0, 0, 0.5);">
            <tr>
                <td>
                    <table id="tbl_gvData1" style="background-color: #2471A3; margin-left: auto; margin-right: auto; box-shadow: 0 0 10px 2px gray; border-radius: 5px; width: 95%; height: 70%;">
                        <tr>
                            <td style="height: 35px; padding-left: 10px; color: #EEEEEE;">
                                <asp:Label ID="lbInfo" runat="server" Style="font-size: 18px; font-weight: bold; font-family: Arial;"></asp:Label>
                                <button type="button" class="btn btn-danger btn-sm" style="float: right" onclick="closeMessage();">Đóng</button>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #EEEEEE; vertical-align: top; padding: 10px;">
                                <div style="height: 700px; width: 100%; overflow-y: scroll; border-style: solid;">
                                    <asp:TextBox ID="txtid" runat="server" Visible="false"></asp:TextBox>
                                    <asp:GridView ID="gvInfo" runat="server" CssClass="table tablehaile table-hover table-responsive table table-responsive table-bordered" OnRowDataBound="gvInfo_RowDataBound" Style="border: double; background-color: white; font-size: 16px; font-weight: bold; font-family: Arial" AutoGenerateColumns="false">
                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <Columns>
                                            <asp:BoundField DataField="mesid" ItemStyle-CssClass="jsbang" ItemStyle-HorizontalAlign="Center" HeaderText="Mã MES" />
                                            <asp:BoundField DataField="machno" ItemStyle-CssClass="jsbang" ItemStyle-HorizontalAlign="Center" HeaderText="Máy" />
                                            <asp:BoundField DataField="daylimt" ItemStyle-CssClass="jsbang" ItemStyle-HorizontalAlign="Center" HeaderText="Hạn Sử Dụng" />
                                            <asp:BoundField DataField="barcode" ItemStyle-CssClass="jsbang" ItemStyle-HorizontalAlign="Center" HeaderText="Mã Vạch" />
                                            <asp:BoundField DataField="slipno" ItemStyle-CssClass="jsbang" ItemStyle-HorizontalAlign="Center" HeaderText="Số Lô" />
                                            <asp:BoundField DataField="weight" ItemStyle-CssClass="jsbang" ItemStyle-HorizontalAlign="Center" HeaderText="Trọng Lượng" />
                                            <asp:BoundField DataField="prodat" ItemStyle-CssClass="jsbang" ItemStyle-HorizontalAlign="Center" HeaderText="Ngày Sản Xuất" />
                                            <asp:BoundField DataField="effdat" ItemStyle-CssClass="jsbang" ItemStyle-HorizontalAlign="Center" HeaderText="Ngày Hiệu Lực" />
                                            <asp:BoundField DataField="partno" ItemStyle-CssClass="jsbang" ItemStyle-HorizontalAlign="Center" HeaderText="Tên KEO" />
                                            <asp:BoundField DataField="intime" ItemStyle-CssClass="jsbang" ItemStyle-HorizontalAlign="Center" HeaderText="Thời Gian Quét" />
                                            <asp:BoundField DataField="indat" ItemStyle-CssClass="jsbang" ItemStyle-HorizontalAlign="Center" HeaderText="Ngày Quét" />
                                            <asp:BoundField DataField="usrno" ItemStyle-CssClass="jsbang" ItemStyle-HorizontalAlign="Center" HeaderText="Người Quét" />
                                            <asp:BoundField DataField="pallet_no" ItemStyle-CssClass="jsbang" ItemStyle-HorizontalAlign="Center" HeaderText="Mã Palet" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table id="tbl_Messages" style="display: none; position: absolute; top: 0; left: 0; width: 100%; height: 100%; background-color: rgba(0, 0, 0, 0.5);">
            <tr>
                <td>
                    <table id="tbl_Messages1" style="background-color: #2471A3; margin-left: auto; margin-right: auto; box-shadow: 0 0 10px 2px gray; border-radius: 5px; width: 500px; height: 200px;">
                        <tr>
                            <td style="height: 35px; padding-left: 10px; color: #EEEEEE;">Thông Báo
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #EEEEEE; vertical-align: top; padding: 10px;">
                                <asp:Label runat="server" ID="lbMess" Style="font-family: Arial; font-weight: bold; font-size: 14px; color: black"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 1px; background-color: #DDDDDD; text-align: right; padding: 5px; border-radius: 0 0 5px 5px;">
                                <button type="button" class="btn btn-dark btn-sm" onclick="closeMessage();">Đóng</button>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
