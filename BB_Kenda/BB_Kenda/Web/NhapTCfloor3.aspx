<%@ Page Title="" Language="C#" MasterPageFile="~/Web/MasterWeb.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="NhapTCfloor3.aspx.cs" Inherits="BB_Kenda.Web.NhapTCfloor3" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/css/select2.min.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.7.min.js"></script>
    <script src="../Scripts/select2.min.js"></script>
    <script src="Scripts/jquery-1.7.1.js"></script>


    <style>
        .labelform {
            font-family: Arial;
            font-weight: bold;
            font-size: 13px;
            color: black;
            width: 170px;
            margin-left: 15px;
            margin-top: 10px;
        }

        tr {
            height: 40px;
        }

        td, th {
            text-align: left;
            height: auto;
        }

        .table_scroll {
            overflow: auto;
            font-size: 14px;
            height: 200px;
            border: 1px solid #007bff;
            width: 550px;
            margin-left: 5px;
        }

        .test {
            display: inline-block;
            margin-left: 10px;
            width: 1900px;
            height: 650px;
        }

        .FixedHeader {
            position: absolute;
            font-weight: bold;
            vertical-align: text-bottom;
        }

        .auto-style1 {
            height: 40px;
        }
    </style>
    <script>
        $(document).ready(function () {
            $(".clss_weight_id").keyup(function () {
                calcu(this);
            })
        })
        function ShowgvInfo() {
            $("#tbl_gvData").fadeIn();
            $("#tbl_gvData1").css("transform", "scale(1)");
        }
        function closeMessage() {
            $("#tbl_gvData").fadeOut(200);
            $("#tbl_Messages").fadeOut(200);
        }
        function calcu(val) {
            var row = $(val).closest("tr");
            if (row.find(".clss_weight_id").val() == "") {
                row.find(".clss_edt_code").val("");
            } else {
                row.find(".clss_edt_code").val("6");
            }
        }
    </script>

    <%--<script type="text/javascript">
        function DisplayText(control) {
            var timeText = document.getElementById('<%=txt_RecipeName.ClientID%>');
            timeText.value = control.value;
            timeText.focus();
        }
    </script>--%>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />
    <script src="https://code.jquery.com/jquery-1.11.3.js"></script>
    <script src="https://code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <script>

        $(function () {
            $("#contentArea").tabs();
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <table>
                <tr>
                    <td>
                        <label class="labelform">机台编号 - Mã số máy: </label>
                    </td>
                    <td>
                        <asp:DropDownList CssClass="form-control" Style="font-size: 14px; font-weight: bold; text-align: center; font-family: Arial;" runat="server" AutoPostBack="true" ID="cbMay" OnTextChanged="cbMay_TextChanged">

                            <asp:ListItem Enabled="true" Text="-- Chọn máy --" Value=""></asp:ListItem>
                            <asp:ListItem Text="Máy V-BB3701" Value="V-BB3701"></asp:ListItem>
                            <asp:ListItem Text="Máy V-BB3702" Value="V-BB3702"></asp:ListItem>
                            <asp:ListItem Text="Máy V-BB3703" Value="V-BB3703"></asp:ListItem>
                            <asp:ListItem Text="Máy V-BB3704" Value="V-BB3704"></asp:ListItem>
                            <asp:ListItem Text="Máy V-BB3705" Value="V-BB3705"></asp:ListItem>
                            <asp:ListItem Text="Máy V-BB3706" Value="V-BB3706"></asp:ListItem>
                            <asp:ListItem Text="Máy V-BB3707" Value="V-BB3707"></asp:ListItem>
                            <asp:ListItem Text="Máy V-BB3708" Value="V-BB3708"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <label class="labelform">搜索 - Tìm kiếm Keo:</label>
                    <td>
                        <asp:DropDownList ID="cb_dataKEo1" runat="server" CssClass="form-control searh" Style="font-size: 14px; font-weight: bold; font-family: Arial;" AutoPostBack="true" OnSelectedIndexChanged="cb_dataKEo1_SelectedIndexChanged">
                        </asp:DropDownList>
                        <%--<asp:Button ID="btn_chk" OnClick="btn_chk_Click" runat="server" CssClass="btn btn-sm btn-warning" Text="C" Style="margin-left: 7px;font-size: 14px; font-weight: bold; font-family: Broadway;" />--%>
                         
                    </td>
                    <td>
                        <asp:Button ID="btn_add" runat="server" CssClass="btn btn-success" Style="font-size: 14px; font-weight: bold; font-family: Arial; margin-left: 15px" Text="Thêm Mới(添新)" OnClick="btn_add_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btn_edit" runat="server" CssClass="btn btn-danger" Style="font-size: 14px; font-weight: bold; font-family: Arial;" Text="Chỉnh Sửa (编辑)" OnClick="btn_edit_Click" />
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-danger" Style="font-size: 14px; font-weight: bold; margin-left: 15px; font-family: Arial;" Text="Copy Recipe" OnClick="Button1_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label class="labelform">
                            配方编号
                            <br>
                            Mã Phối Phương</label>
                    </td>

                    <td>
                        <asp:TextBox ID="txt_matercode" runat="server" CssClass="form-control" Style="font-size: 14px; font-weight: bold; font-family: Arial;" Width="168px"></asp:TextBox>
                    </td>

                    <td>
                        <label class="labelform">
                            配方名称
                            <br>
                            Tên Phối Phương</label>

                    </td>
                    <td>
                        <asp:TextBox ID="txt_matername" runat="server" CssClass="form-control" Style="font-size: 14px; font-weight: bold; font-family: Arial;" Width="168px"></asp:TextBox>
                    </td>
                    <td>
                        <label class="labelform">
                            进料最高温度<br>
                            Nhiệt độ vào liệu cao nhất</label>
                    </td>


                    <td>
                        <asp:TextBox ID="txt_minitemp" runat="server" CssClass="form-control" Style="font-size: 14px; font-weight: bold; font-family: Arial;" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" Width="168px"></asp:TextBox>
                    </td>
                    <td>
                        <label class="labelform">
                            超温最短排胶时间
                            <br>
                            Thời gian ngắn nhất xả keo quá nhiệt độ</label>
                    </td>

                    <td>
                        <asp:TextBox ID="txt_maxtemp" runat="server" CssClass="form-control" Style="font-size: 14px; font-weight: bold; font-family: Arial;" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" Width="168px"></asp:TextBox>
                    </td>




                    <td>
                        <label class="labelform">
                            配方类型<br>
                            Loại Phối Phương</label>
                    </td>

                    <td>
                        <asp:DropDownList CssClass="form-control" Style="font-size: 14px; font-weight: bold; font-family: Arial;" runat="server" ID="cbMay1" Width="121px">
                            <asp:ListItem Enabled="true" Text="" Value=""></asp:ListItem>
                            <asp:ListItem Text="素炼母胶" Value="1"></asp:ListItem>
                            <asp:ListItem Text="混炼胶" Value="2"></asp:ListItem>
                            <asp:ListItem Text="加促胶" Value="3"></asp:ListItem>
                            <asp:ListItem Text="精炼胶" Value="4"></asp:ListItem>



                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>



                    <td>
                        <label class="labelform">
                            超时最短排胶时间
                            <br>
                            Thời gian ngắn nhất xả keo quá thời gian</label>
                    </td>

                    <td>
                        <asp:TextBox ID="txt_minitime" runat="server" CssClass="form-control" Style="font-size: 14px; font-weight: bold; font-family: Arial;" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" Width="168px"></asp:TextBox>
                    </td>

                    <td>
                        <label class="labelform">
                            超温排胶温度<br />
                            Nhiệt độ xả keo quá nhiệt độ</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_overtemp" runat="server" CssClass="form-control" Style="font-size: 14px; font-weight: bold; font-family: Arial;" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" Width="168px"></asp:TextBox>
                    </td>
                    <td>
                        <label class="labelform">
                            炭黑回收标志<br>
                            Ký hiệu thu hồi Than đen</label>
                    </td>
                    <td>
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="(☐:否 - ☑:是 | ☐:không - ☑:có)" />

                    </td>
                    <td>
                        <label class="labelform">
                            炭黑回收时间<br>
                            Thời gian thu hồi than đen</label>
                    </td>

                    <td>
                        <asp:TextBox ID="txt_reusetime" runat="server" CssClass="form-control" Style="font-size: 14px; font-weight: bold; font-family: Arial;" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" Width="168px"></asp:TextBox>
                    </td>



                </tr>
                <tr>
                    <td class="auto-style1">
                        <label class="labelform">三区温度1 - Nhiệt độ 1</label>
                    </td>

                    <td class="auto-style1">
                        <asp:TextBox ID="txt_threetemp1" runat="server" CssClass="form-control" Style="font-size: 14px; font-weight: bold; font-family: Arial;" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" Width="168px"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                        <label class="labelform">三区温度2 - Nhiệt độ 2</label>
                    </td>

                    <td class="auto-style1">
                        <asp:TextBox ID="txt_threetemp2" runat="server" CssClass="form-control" Style="font-size: 14px; font-weight: bold; font-family: Arial;" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" Width="168px"></asp:TextBox>
                    </td>

                    <td class="auto-style1">
                        <label class="labelform">三区温度3 - Nhiệt độ 3</label>
                    </td>

                    <td class="auto-style1">
                        <asp:TextBox ID="txt_threetemp3" runat="server" CssClass="form-control" Style="font-size: 14px; font-weight: bold; font-family: Arial;" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" Width="168px"></asp:TextBox>
                    </td>


                    <td class="auto-style1">
                        <label class="labelform">挤出机温度 - Nhiệt độ TSR</label>
                    </td>

                    <td class="auto-style1">
                        <asp:TextBox ID="txt_threetemp4" runat="server" CssClass="form-control" Style="font-size: 14px; font-weight: bold; font-family: Arial;" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" Width="168px"></asp:TextBox>
                    </td>

                    <td class="auto-style1">
                        <label class="labelform">压片温度 - Nhiệt độ ép tấm</label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txt_tablettingtemp" runat="server" CssClass="form-control" Style="font-size: 14px; font-weight: bold; font-family: Arial;" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" Width="168px"></asp:TextBox>
                    </td>

                </tr>
                <tr>

                    <td>
                        <label class="labelform">修改时间 - Thời gian sửa</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_definedate" runat="server" CssClass="form-control" Style="font-size: 14px; font-weight: bold; font-family: Arial;" Width="168px"></asp:TextBox>
                    </td>
                    <td>
                        <label class="labelform">
                            使用状态标志<br>
                            Ký hiệu trạng thái sử dụng</label>
                    </td>
                    <td>
                        <asp:CheckBox ID="CheckBox2" runat="server" Text="(☐:否 - ☑:是 | ☐:không - ☑:có)" />
                    </td>

                    <td>
                        <label class="labelform">
                            配方总重
                            <br>
                            Tổng trọng lượng</label>
                    </td>

                    <td>
                        <asp:TextBox ID="TextBox14" runat="server" CssClass="form-control" Style="font-size: 14px; font-weight: bold; font-family: Arial;" Width="168px"></asp:TextBox>
                    </td>

                    <td>
                        <label class="labelform">备注 - Ghi chú</label>
                    </td>

                    <td>
                        <asp:TextBox ID="txt_memnote" runat="server" CssClass="form-control" Style="font-size: 14px; font-weight: bold; font-family: Arial;" Width="168px"></asp:TextBox>
                    </td>
                </tr>
            </table>

        </div>

        <div>
            <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ScriptManager>
            <ajaxToolkit:TabContainer ID="TabContainer2" runat="server" ActiveTabIndex="0" CssClass="test" AutoPostBack="false">
                <ajaxToolkit:TabPanel runat="server" HeaderText="称里规程 - Quy trình cân" ID="TabPanel3">
                    <contenttemplate>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <div style="height: 200px; width: 620px; overflow: auto; border: 1px solid #007bff; text-align: center; margin-left: 2px;">
                                            <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False">
                                                <HeaderStyle BackColor="#007bff" ForeColor="White" CssClass="tdd" />
                                                <RowStyle CssClass="GridViewRowStyle" HorizontalAlign="Center" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="炭黑 <br> Than" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="ad" Width="35px" Text='<%# (Container.DataItemIndex + 1)%>' runat="server">
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="动作 <br>Động tác">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="dr_ChildCode" runat="server" CssClass="form-control clssChildCode" Style="text-align: center; width: 75px; font-weight: bold; font-family: Arial; width: fit-content(); position: inherit !important;">
                                                                <asp:ListItem Text="" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="称里 - Cân" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="卸料 - Xả liệu" Value="2"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="物料名称<br>Tên vật liệu">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="dr_ChildName" runat="server" CssClass="form-control clssChildCode" Style="text-align: center; width: 125px; font-weight: bold; font-family: Arial; width: fit-content(); position: inherit !important;">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="物料代码<br>Mã vật liệu">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_child_code" Style="text-align: center; font-weight: bold; font-family: Arial;" runat="server" Width="75px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="设定重量<br>Thiết lập">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_set_weight" MaxLength="10" CssClass="txtWgt" Style="text-align: center; font-weight: bold; font-family: Arial;" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" runat="server" Width="80px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="设定误差<br>Dung sai">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_error_allow" MaxLength="10" Style="text-align: center; font-weight: bold; font-family: Arial;" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" runat="server" Width="80px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </td>
                                    <td>

                                        <div style="height: 200px; width: 620px; overflow: auto; border: 1px solid #007bff; text-align: center; margin-left: 8px;">
                                            <asp:GridView ID="gvData1" runat="server" AutoGenerateColumns="False" CssClass="tdd">
                                                <HeaderStyle BackColor="#007bff" ForeColor="White" />
                                                <RowStyle CssClass="GridViewRowStyle" HorizontalAlign="Center" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="油11<br>Dầu 11">
                                                        <ItemTemplate>

                                                            <asp:Label ID="ad1" Width="35px" Text='<%# (Container.DataItemIndex + 1)%>' runat="server">
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="动作<br>Động tác">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="dr_ChildCode1" runat="server" CssClass="form-control clssChildCode" Style="text-align: center; width: 75px; font-weight: bold; font-family: Arial; width: fit-content(); position: inherit !important;">
                                                                <asp:ListItem Text="" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="称里 - Cân" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="卸料 - Xả liệu" Value="2"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="物料名称<br>Tên vật liệu">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="dr_ChildName1" runat="server" CssClass="form-control clssChildCode" Style="text-align: center; width: 125px; font-weight: bold; font-family: Arial; width: fit-content(); position: inherit !important;">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="物料代码<br>Mã vật liệu">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_child_code1" Style="text-align: center; font-weight: bold; font-family: Arial; width: 75px" runat="server"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="设定重量<br>Thiết lập">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_set_weight1" MaxLength="10" CssClass="txtWgt" Style="text-align: center; font-weight: bold; font-family: Arial;" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" runat="server" Width="80px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="设定误差<br>Dung sai">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_error_allow1" MaxLength="10" Style="text-align: center; font-weight: bold; font-family: Arial;" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" runat="server" Width="80px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>

                                        </div>
                                    </td>

                                    <td>

                                        <div style="height: 200px; width: 620px; overflow: auto; border: 1px solid #007bff; text-align: center; margin-left: 8px;">
                                            <asp:GridView ID="gvData2" runat="server" AutoGenerateColumns="False">
                                                <HeaderStyle BackColor="#007bff" ForeColor="White" />
                                                <RowStyle CssClass="GridViewRowStyle" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="油14<br>Dầu 14">
                                                        <ItemTemplate>

                                                            <asp:Label ID="ad2" Width="35px" Text='<%# (Container.DataItemIndex + 1)%>' runat="server">
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="动作<br>Động tác">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="dr_ChildCode2" runat="server" CssClass="form-control clssChildCode" Style="text-align: center; width: 75px; font-weight: bold; font-family: Arial; width: fit-content(); position: inherit !important;">
                                                                <asp:ListItem Text="" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="称里 - Cân" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="卸料 - Xả liệu" Value="2"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="物料名称<br>Tên vật liệu">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="dr_ChildName2" runat="server" CssClass="form-control clssChildCode" Style="text-align: center; width: 125px; font-weight: bold; font-family: Arial; width: fit-content(); position: inherit !important;">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="物料代码<br>Mã vật liệu">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_child_code2" Style="text-align: center; font-weight: bold; font-family: Arial;" runat="server" Width="75px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="设定重量<br>Thiết lập">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_set_weight2" MaxLength="10" CssClass="txtWgt" Style="text-align: center; font-weight: bold; font-family: Arial;" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" runat="server" Width="80px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="设定误差<br>Dung sai">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_error_allow2" MaxLength="10" Style="text-align: center; font-weight: bold; font-family: Arial;" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" runat="server" Width="80px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <div style="height: 200px; width: 620px; overflow: auto; border: 1px solid #007bff; text-align: center; margin-left: 2px;">
                                            <asp:GridView ID="gvData3" runat="server" AutoGenerateColumns="False">
                                                <HeaderStyle BackColor="#007bff" ForeColor="White" />
                                                <RowStyle CssClass="GridViewRowStyle" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="粉料<br>Liệu bột">
                                                        <ItemTemplate>

                                                            <asp:Label ID="ad3" Width="45px" Text='<%# (Container.DataItemIndex + 1)%>' runat="server">
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="动作<br>Động tác">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="dr_ChildCode3" runat="server" CssClass="form-control clssChildCode" Style="text-align: center; width: 75px; font-weight: bold; font-family: Arial; width: fit-content(); position: inherit !important;">
                                                                <asp:ListItem Text="" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="称里 - Cân" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="卸料 - Xả liệu" Value="2"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="物料名称<br>Tên vật liệu">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="dr_ChildName3" runat="server" CssClass="form-control clssChildCode" Style="text-align: center; width: 125px; font-weight: bold; font-family: Arial; width: fit-content(); position: inherit !important;">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="物料代码<br>Mã vật liệu">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_child_code3" Style="text-align: center; font-weight: bold; font-family: Arial;" runat="server" Width="85px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="设定重量<br>Thiết lập">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_set_weight3" MaxLength="10" CssClass="txtWgt" Style="text-align: center; font-weight: bold; font-family: Arial; width: 70px" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" runat="server" Width="80px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="设定误差<br>Dung sai">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_error_allow3" MaxLength="10" Style="text-align: center; font-weight: bold; font-family: Arial; width: 70px" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" runat="server" Width="80px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>

                                        </div>
                                    </td>
                                    <td>
                                        <br />
                                        <div style="height: 200px; width: 620px; overflow: auto; border: 1px solid #007bff; text-align: center; margin-left: 8px;">
                                            <asp:GridView ID="gvData4" runat="server" AutoGenerateColumns="False">
                                                <HeaderStyle BackColor="#007bff" ForeColor="White" />
                                                <RowStyle CssClass="GridViewRowStyle" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="油12<br>Dầu 12">
                                                        <ItemTemplate>

                                                            <asp:Label ID="ad4" Width="35px" Text='<%# (Container.DataItemIndex + 1)%>' runat="server">
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="动作<br>Động tác">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="dr_ChildCode4" runat="server" CssClass="form-control clssChildCode" Style="text-align: center; width: 75px; font-weight: bold; font-family: Arial; width: fit-content(); position: inherit !important;">
                                                                <asp:ListItem Text="" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="称里 - Cân" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="卸料 - Xả liệu" Value="2"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="物料名称<br>Tên vật liệu">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="dr_ChildName4" runat="server" CssClass="form-control clssChildCode" Style="text-align: center; width: 125px; font-weight: bold; font-family: Arial; width: fit-content(); position: inherit !important;">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="物料代码<br>Mã vật liệu">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_child_code4" Style="text-align: center; font-weight: bold; font-family: Arial;" runat="server" Width="75px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="设定重量<br>Thiết lập">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_set_weight4" MaxLength="10" CssClass="txtWgt" Style="text-align: center; font-weight: bold; font-family: Arial;" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" runat="server" Width="80px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="设定误差<br>Dung sai">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_error_allow4" MaxLength="10" Style="text-align: center; font-weight: bold; font-family: Arial;" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" runat="server" Width="80px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </td>
                                    <td>
                                        <br />
                                        <div style="height: 200px; width: 620px; overflow: auto; border: 1px solid #007bff; text-align: center; margin-left: 8px;">
                                            <asp:GridView ID="gvData5" runat="server" AutoGenerateColumns="False">
                                                <HeaderStyle BackColor="#007bff" ForeColor="White" />
                                                <RowStyle CssClass="GridViewRowStyle" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="油15<br>Dầu 15">
                                                        <ItemTemplate>

                                                            <asp:Label ID="ad5" Width="35px" Text='<%# (Container.DataItemIndex + 1)%>' runat="server">
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="动作<br>Động tác">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="dr_ChildCode5" runat="server" CssClass="form-control clssChildCode" Style="text-align: center; width: 75px; font-weight: bold; font-family: Arial; width: fit-content(); position: inherit !important;">
                                                                <asp:ListItem Text="" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="称里 - Cân" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="卸料 - Xả liệu" Value="2"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="物料名称<br>Tên vật liệu">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="dr_ChildName5" runat="server" CssClass="form-control clssChildCode" Style="text-align: center; width: 125px; font-weight: bold; font-family: Arial; width: fit-content(); position: inherit !important;">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="物料代码<br>Mã vật liệu">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_child_code5" Style="text-align: center; font-weight: bold; font-family: Arial;" runat="server" Width="75px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="设定重量<br>Thiết lập">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_set_weight5" MaxLength="10" CssClass="txtWgt" Style="text-align: center; font-weight: bold; font-family: Arial;" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" runat="server" Width="80px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="设定误差<br>Dung sai">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_error_allow5" MaxLength="10" Style="text-align: center; font-weight: bold; font-family: Arial;" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" runat="server" Width="80px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <div style="height: 200px; width: 620px; overflow: auto; border: 1px solid #007bff; text-align: center; margin-left: 2px;">
                                            <asp:GridView ID="gvData6" runat="server" AutoGenerateColumns="False">
                                                <HeaderStyle BackColor="#007bff" ForeColor="White" />
                                                <RowStyle CssClass="GridViewRowStyle" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="胶料<br>Liệu keo">
                                                        <ItemTemplate>

                                                            <asp:Label ID="ad6" Width="50px" Text='<%# (Container.DataItemIndex + 1)%>' runat="server">
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="物料名称<br>Tên vật liệu">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="dr_ChildName6" runat="server" CssClass="form-control clssChildCode" Style="text-align: center; width: 200px; font-weight: bold; font-family: Arial; width: fit-content(); position: inherit !important;">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="物料代码<br>Mã vật liệu">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_child_code6" Style="text-align: center; font-weight: bold; font-family: Arial;" runat="server" Width="80px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="设定重量<br>Thiết lập">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_set_weight6" MaxLength="10" CssClass="txtWgt" Style="text-align: center; font-weight: bold; font-family: Arial;" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" runat="server" Width="80px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="设定误差<br>Dung sai">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_error_allow6" MaxLength="10" Style="text-align: center; font-weight: bold; font-family: Arial;" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" runat="server" Width="80px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>

                                        </div>
                                    </td>
                                    <td>
                                        <br />
                                        <div style="height: 200px; width: 620px; overflow: auto; border: 1px solid #007bff; text-align: center; margin-left: 8px;">
                                            <asp:GridView ID="gvData7" runat="server" AutoGenerateColumns="False">
                                                <HeaderStyle BackColor="#007bff" ForeColor="White" />
                                                <RowStyle CssClass="GridViewRowStyle" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="油13<br>Dầu 13">
                                                        <ItemTemplate>

                                                            <asp:Label ID="ad7" Width="35px" Text='<%# (Container.DataItemIndex + 1)%>' runat="server">
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="动作<br>Động tác">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="dr_ChildCode7" runat="server" CssClass="form-control clssChildCode" Style="text-align: center; width: 75px; font-weight: bold; font-family: Arial; width: fit-content(); position: inherit !important;">
                                                                <asp:ListItem Text="" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="称里 - Cân" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="卸料 - Xả liệu" Value="2"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="物料名称<br>Tên vật liệu">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="dr_ChildName7" runat="server" CssClass="form-control clssChildCode" Style="text-align: center; width: 125px; font-weight: bold; font-family: Arial; width: fit-content(); position: inherit !important;">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="物料代码<br>Mã vật liệu">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_child_code7" Style="text-align: center; font-weight: bold; font-family: Arial;" runat="server" Width="75px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="设定重量<br>Thiết lập">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_set_weight7" MaxLength="10" CssClass="txtWgt" Style="text-align: center; font-weight: bold; font-family: Arial;" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" runat="server" Width="80px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="设定误差<br>Dung sai">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_error_allow7" MaxLength="10" Style="text-align: center; font-weight: bold; font-family: Arial;" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" runat="server" Width="80px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </td>

                                </tr>

                            </table>
                        </div>
                    </contenttemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel4" runat="server" HeaderText="混炼规程 - Quy trình luyện keo">
                    <contenttemplate>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <div style="height: 100%; width: 100%; overflow: auto; border: 1px solid #007bff; text-align: center; margin-left: 15px;">
                                            <asp:GridView ID="gvData8" runat="server" AutoGenerateColumns="False">
                                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                <RowStyle CssClass="GridViewRowStyle" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="<br>">
                                                        <ItemTemplate>

                                                            <asp:Label ID="ad8" Width="45px" Text='<%# (Container.DataItemIndex + 1)%>' runat="server">
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="动作 <br>Động tác">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="dr_ChildName1a" runat="server" CssClass="form-control clssChildCode" Style="text-align: center; width: 150px; font-weight: bold; font-family: Arial; width:fit-content; position: inherit !important;">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="时间<br>Thời gian">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_child_code88" MaxLength="20" CssClass="clss_weight_id" Style="text-align: center; font-weight: bold; font-family: Arial;" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" runat="server" Width="80px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="温度<br>Nhiệt độ">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_child_code888" MaxLength="20" CssClass="clss_weight_id" Style="text-align: center; font-weight: bold; font-family: Arial;" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" runat="server" Width="80px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="功率<br>Công suất">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_child_code8888" MaxLength="20" CssClass="clss_weight_id" Style="text-align: center; font-weight: bold; font-family: Arial;" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" runat="server" Width="80px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="能量<br>năng lượng">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_child_code7888" MaxLength="20" CssClass="clss_weight_id" Style="text-align: center; font-weight: bold; font-family: Arial;" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" runat="server" Width="80px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="条件<br>Điều kiện">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="dr_ChildName1b" runat="server" CssClass="form-control clssChildCode" Style="text-align: center; width: 150px; font-weight: bold; font-family: Arial; width: fit-content; position: inherit !important;">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="压力<br>Áp lực">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_set_weight75" MaxLength="10" CssClass="txtWgt" Style="text-align: center; font-weight: bold; font-family: Arial;" TabIndex='0' autocomplete="off" onkeypress="return isFloatNumber(this,event);" runat="server" Width="80px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="转速<br>Tốc độ">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_error_allow76" MaxLength="10" Style="text-align: center; font-weight: bold; font-family: Arial;" TabIndex='0' autocomplete="off" onkeypress="return ValidateKeypress(/\d/,event);" runat="server" Width="80px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>

                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </contenttemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
        </div>



    </div>
    <div>
        <table id="tbl_gvData" style="display: none; position: absolute; top: 115px; left: 1000px; width: 360px; height: 300px;">

            <tr style="background-color: #2471A3; padding: 10px;">
                <td>
                    <table id="tbl_gvData1" style="background-color: #2471A3; margin-left: auto; margin-right: auto; box-shadow: 0 0 10px 2px gray; border-radius: 5px; width: 95%; height: 70%;">
                        <tr>
                            <td style="height: 35px; padding-left: 10px; color: #EEEEEE;">
                                <asp:Label ID="lbInfo" runat="server" Style="font-size: 18px; font-weight: bold; font-family: Arial;" Text="Copy Recipe"></asp:Label>
                                <button type="button" class="btn btn-danger btn-sm" style="float: right" onclick="closeMessage();">Đóng</button>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #EEEEEE; padding: 10px;">
                                <div style="height: auto; margin-bottom: 10px">
                                    <asp:Label runat="server" Text="配方编号 Mã vật liệu"></asp:Label>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

                                </div>
                                <div style="height: auto; margin-bottom: 10px">
                                    <asp:Label runat="server" Text="配方名称 Tên vật liệu"></asp:Label>
                                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

                                </div>
                                <div style="height: auto; margin-bottom: 10px">
                                    <asp:CheckBox ID="CheckBox3" Font-Size="16px" runat="server" Text="V-BB3701" />
                                    <asp:CheckBox ID="CheckBox4" Font-Size="16px" runat="server" Text="V-BB3702" />
                                    <asp:CheckBox ID="CheckBox5" Font-Size="16px" runat="server" Text=" V-BB3703" />

                                </div>
                                <div style="height: auto; margin-bottom: 10px">
                                    <asp:CheckBox ID="CheckBox6" Font-Size="16px" runat="server" Text=" V-BB3704" />
                                    <asp:CheckBox ID="CheckBox7" Font-Size="16px" runat="server" Text=" V-BB3705" />
                                    <asp:CheckBox ID="CheckBox8" Font-Size="16px" runat="server" Text=" V-BB3706" />

                                </div>
                                  <div style="height: auto; margin-bottom: 10px">
                                    <asp:CheckBox ID="CheckBox9" Font-Size="16px" runat="server" Text=" V-BB3707" />
                                     <asp:CheckBox ID="CheckBox10" Font-Size="16px" runat="server" Text=" V-BB3708" />
                                  

                                </div>
                                <div>
                                    <asp:Button ID="Button3" runat="server" CssClass="btn btn-danger" Style="font-size: 14px; font-weight: bold; margin-left: 120px; font-family: Arial;" Text="Copy" OnClick="Button2_Click" />
                                </div>
                            </td>

                        </tr>

                    </table>
                </td>
            </tr>

        </table>
    </div>
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
    <%-- </div>--%>
    <script>
        function ValidateKeypress(numcheck, e) {
            var keynum, keychar, numcheck;
            if (window.event) {//IE
                keynum = e.keyCode;
            }
            else if (e.which) {// Netscape/Firefox/Opera
                keynum = e.which;
            }
            if (keynum == 8 || keynum == 127 || keynum == null || keynum == 9 || keynum == 0 || keynum == 13) return true;
            keychar = String.fromCharCode(keynum);
            var result = numcheck.test(keychar);
            return result;
        }
        $(function () {
            $(".clssChildCode").select2();
            $(".searh").select2();
        })

        $(document).ready(function () {
            $(".txtWgt").keyup(function () {
                calcu(this);
            });

            $(".txtWgt").ready(function () {
                calcu(this);
            });
        })

        function calcu(val) {
            let wgt = 0;

            $(".txtWgt").each(function () {
                if ($(".txtWgt").val() != "") {
                    wgt += Number($(this).val());
                }
            })

            $(".sumWgt").val(parseFloat(wgt).toFixed(2));
        }

    </script>
</asp:Content>
