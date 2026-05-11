using BB_Kenda.CnnSQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BB_Kenda.Web
{
    public partial class NhapTCfloor3 : System.Web.UI.Page
    {
        DropDownList drChildCode8;
        DropDownList drChildCode9;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Validate();
                if (Page.IsValid)
                {
                    LoadGV();
                    editfalse();
                }
            }
        }

        private void edittrue()
        {
            txt_matercode.Enabled = true;
            txt_matername.Enabled = true;
            txt_minitemp.Enabled = true;
            txt_maxtemp.Enabled = true;
            txt_minitime.Enabled = true;
            txt_overtemp.Enabled = true;
            CheckBox1.Enabled = true;
            CheckBox2.Enabled = true;
            txt_reusetime.Enabled = true;
            txt_threetemp1.Enabled = true;
            txt_threetemp2.Enabled = true;
            txt_threetemp3.Enabled = true;
            txt_threetemp4.Enabled = true;
            txt_tablettingtemp.Enabled = true;
            txt_definedate.Enabled = true;
            txt_memnote.Enabled = true;
            cbMay1.Enabled = true;
            cb_dataKEo1.Enabled = true;
            TextBox14.Enabled = true;
            gvData.Enabled = true;
            gvData1.Enabled = true;
            gvData2.Enabled = true;
            gvData3.Enabled = true;
            gvData4.Enabled = true;
            gvData5.Enabled = true;
            gvData6.Enabled = true;
            gvData7.Enabled = true;
            gvData8.Enabled = true;
        }
        private void editfalse()
        {
            txt_matercode.Enabled = false;
            txt_matername.Enabled = false;
            txt_minitemp.Enabled = false;
            txt_maxtemp.Enabled = false;
            txt_minitime.Enabled = false;
            txt_overtemp.Enabled = false;
            CheckBox1.Enabled = false;
            CheckBox2.Enabled = false;
            txt_reusetime.Enabled = false;
            txt_threetemp1.Enabled = false;
            txt_threetemp2.Enabled = false;
            txt_threetemp3.Enabled = false;
            txt_threetemp4.Enabled = false;
            txt_tablettingtemp.Enabled = false;
            txt_definedate.Enabled = false;
            txt_memnote.Enabled = false;
            cbMay1.Enabled = false;
            TextBox14.Enabled = false;
            if (cb_dataKEo1.Text.Trim() == "")
            {
                cb_dataKEo1.Enabled = false;
                Button1.Enabled = false;
                btn_add.Enabled = false;
            }
            else
            {
                cb_dataKEo1.Enabled = true;
                Button1.Enabled = true;
                btn_add.Enabled = true;
            }
            btn_edit.Enabled = false;
            gvData.Enabled = false;
            gvData1.Enabled = false;
            gvData2.Enabled = false;
            gvData3.Enabled = false;
            gvData4.Enabled = false;
            gvData5.Enabled = false;
            gvData6.Enabled = false;
            gvData7.Enabled = false;
            gvData8.Enabled = false;
        }
        private void getData()
        {
            LoadGV();
            string weight_id = "";
            string child_name = "";
            string child_code = "";
            string set_weight = "";
            string error_allow = "";
            string weigh_type = "";
            string edt_code = "";

            string mix_id = "";
            string act_code = "";
            string set_time = "";
            string set_temp = "";
            string set_ener = "";
            string set_power = "";
            string term_code = "";
            string set_pres = "";
            string set_rota = "";

            int a = -1;
            int b = -1;
            int c = -1;
            int d = -1;
            int e = -1;
            int f = -1;
            int g = -1;
            int h = -1;

            string keo = cb_dataKEo1.Text.Trim();
            string may = cbMay.Text.Trim().Substring(6);
            string ip = "";
            switch (cbMay.Text.Trim().Substring(6))
            {
                case "01": ip = "198.1.8.21"; break;
                case "02": ip = "198.1.8.22"; break;
                case "03": ip = "198.1.8.23"; break;
                case "04": ip = "198.1.8.24"; break;
                case "05": ip = "198.1.8.35"; break;
                case "06": ip = "198.1.8.36"; break;
                case "07": ip = "198.1.8.37"; break;
                case "08": ip = "198.1.8.38"; break;
                default:
                    break;
            }
            string GetChildcode = "select mater_name as code from [mfns].[dbo].[pmt_material]";
            string GetChildcode1 = "SELECT [act_code],                                  " +
            " CASE                                                                                  " +
            "     WHEN RTRIM(act_name) = '加胶' THEN RTRIM(act_name)+N' - Thêm cao su'              " +
            "     WHEN RTRIM(act_name) = '降上顶栓' THEN RTRIM(act_name)+N' - Búa xuống'             " +
            "     WHEN RTRIM(act_name) = '开卸料门' THEN RTRIM(act_name)+N' - Mở cửa xả liệu'        " +
            "     WHEN RTRIM(act_name) = '保持' THEN RTRIM(act_name)+N' - Duy trì'                  " +
            "     WHEN RTRIM(act_name) = '升上顶栓' THEN RTRIM(act_name)+N' - Búa lên'               " +
            "     WHEN RTRIM(act_name) = '开加料门' THEN RTRIM(act_name)+N' - Mở cửa vào liệu'       " +
            "     WHEN RTRIM(act_name) = '加油3' THEN RTRIM(act_name)+N' - Thêm dầu 3'              " +
            "     WHEN RTRIM(act_name) = '上顶栓中到位' THEN RTRIM(act_name)+N' - Búa lên giữa'      " +
            "     WHEN RTRIM(act_name) = '上顶栓浮动' THEN RTRIM(act_name)+N' - Búa nhấp nhô'        " +
            "     WHEN RTRIM(act_name) = '加油4' THEN RTRIM(act_name)+N' - Thêm dầu 4'              " +
            "     WHEN RTRIM(act_name) = '关卸料门' THEN RTRIM(act_name)+N' - Đóng cửa xả liệu'      " +
            "     WHEN RTRIM(act_name) = '加油2' THEN RTRIM(act_name)+N' - Thêm dầu 2'              " +
            "     WHEN RTRIM(act_name) = '关加料门' THEN RTRIM(act_name)+N' - Đóng cửa vào liệu'     " +
            "     WHEN RTRIM(act_name) = '加油5' THEN RTRIM(act_name)+N' - Thêm dầu 5'              " +
            "     WHEN RTRIM(act_name) = '加炭黑' THEN RTRIM(act_name)+N' - Thêm Carbon'             " +
            "     WHEN RTRIM(act_name) = '加油1' THEN RTRIM(act_name)+N' - Thêm dầu 1'              " +
            "     WHEN RTRIM(act_name) = '加粉料' THEN RTRIM(act_name)+N' - Thêm bột'                " +
            "     WHEN RTRIM(act_name) = '加小药' THEN RTRIM(act_name)+N' - Thêm ít bột'             " +
            "     ELSE act_name                                                                     " +
            " END as act_name                                                                       " +
            " FROM[mfns].[dbo].[pmt_act]";
                        string GetChildcode2 = "SELECT [term_code]," +
                            " CASE                                                                      " +
            "     WHEN term_code = 1 THEN RTRIM(term_name)+N' - Thời gian'                              " +
            "     WHEN term_code = 2 THEN RTRIM(term_name)+N' - Nhiệt độ'                               " +
            "     WHEN term_code = 3 THEN RTRIM(term_name)+N' - Năng lượng'                             " +
            "     WHEN term_code = 4 THEN RTRIM(term_name)+N' - Thời gian + Nhiệt độ'                   " +
            "     WHEN term_code = 5 THEN RTRIM(term_name)+N' - Thời gian + Năng lượng'                 " +
            "     WHEN term_code = 6 THEN RTRIM(term_name)+N' - Nhiệt độ + Năng lượng'                  " +

            "     WHEN term_code = 7 THEN RTRIM(term_name)+N' - Thời gian hoặc Nhiệt độ + Năng lượng'   " +
            "     WHEN term_code = 8 THEN RTRIM(term_name)+N' - Thời gian hoặc Năng lượng + Nhiệt độ'   " +
            "     WHEN term_code = 9 THEN RTRIM(term_name)+N' - Nhiệt độ hoặc Năng lượng + Thời gian'   " +

            "     WHEN term_code = 10 THEN RTRIM(term_name)+N' - Thời gian + Nhiệt độ + Năng lượng'     " +
            "     WHEN term_code = 11 THEN RTRIM(term_name)+N' - Thực hiện đồng thời'                   " +
            "     WHEN term_code = 12 THEN RTRIM(term_name)+N' - Hoàn thành phối phương'                " +

            "     WHEN term_code = 13 THEN RTRIM(term_name)+N' - Thời gian hoặc Nhiệt độ'               " +

            "     ELSE term_name                                                                   " +
            " END as term_name                                                                         " +

            "   FROM[mfns].[dbo].[pmt_term]";
            string Query = "select weight_id, child_name,child_code,set_weight, error_allow,weigh_type,act_code from [pmt_weigh] where father_code='" + keo + "' ";
            DataTable dtkeo = cnn.ExcuteQueryFloor3(ip, Query);

            string Query1 = " SELECT mix_id, act_code, set_time, set_temp, set_ener, set_power, term_code, set_pres, set_rota FROM pmt_mix where father_code ='" + keo + "' ";
            DataTable dtkeo1 = cnn.ExcuteQueryFloor3(ip, Query1);
            if (dtkeo.Rows.Count == 0)
            {
                //ThongBao("Keo này không tồn tại trong dữ liệu, Chỉ có thể thêm mới! [pmt_weigh]");
                LoadGV();
                //return;
            }
            if (dtkeo1.Rows.Count == 0)
            {
                //ThongBao("Keo này không tồn tại trong dữ liệu, Chỉ có thể thêm mới! [pmt_weigh]");
                LoadGV();
                //return;
            }



            DataTable dtChildCode = cnn.ExecuteQueryWithIP(ip, GetChildcode);
            DataTable dtChildCode1 = cnn.ExecuteQueryWithIP(ip, GetChildcode1);
            DataTable dtChildCode2 = cnn.ExecuteQueryWithIP(ip, GetChildcode2);
            for (int j = 0; j < 35; j++)
            {
                DropDownList drChildCode = (DropDownList)gvData.Rows[j].FindControl("dr_ChildName");
                drChildCode.DataSource = dtChildCode;
                drChildCode.DataTextField = "code";
                drChildCode.DataValueField = "code";
                drChildCode.DataBind();
                drChildCode.Items.Insert(0, new ListItem(""));


                DropDownList drChildCode1 = (DropDownList)gvData1.Rows[j].FindControl("dr_ChildName1");
                drChildCode1.DataSource = dtChildCode;
                drChildCode1.DataTextField = "code";
                drChildCode1.DataValueField = "code";
                drChildCode1.DataBind();
                drChildCode1.Items.Insert(0, new ListItem(""));

                DropDownList drChildCode2 = (DropDownList)gvData2.Rows[j].FindControl("dr_ChildName2");
                drChildCode2.DataSource = dtChildCode;
                drChildCode2.DataTextField = "code";
                drChildCode2.DataValueField = "code";
                drChildCode2.DataBind();
                drChildCode2.Items.Insert(0, new ListItem(""));

                DropDownList drChildCode3 = (DropDownList)gvData3.Rows[j].FindControl("dr_ChildName3");
                drChildCode3.DataSource = dtChildCode;
                drChildCode3.DataTextField = "code";
                drChildCode3.DataValueField = "code";
                drChildCode3.DataBind();
                drChildCode3.Items.Insert(0, new ListItem(""));

                DropDownList drChildCode4 = (DropDownList)gvData4.Rows[j].FindControl("dr_ChildName4");
                drChildCode4.DataSource = dtChildCode;
                drChildCode4.DataTextField = "code";
                drChildCode4.DataValueField = "code";
                drChildCode4.DataBind();
                drChildCode4.Items.Insert(0, new ListItem(""));

                DropDownList drChildCode5 = (DropDownList)gvData5.Rows[j].FindControl("dr_ChildName5");
                drChildCode5.DataSource = dtChildCode;
                drChildCode5.DataTextField = "code";
                drChildCode5.DataValueField = "code";
                drChildCode5.DataBind();
                drChildCode5.Items.Insert(0, new ListItem(""));

                DropDownList drChildCode6 = (DropDownList)gvData6.Rows[j].FindControl("dr_ChildName6");
                drChildCode6.DataSource = dtChildCode;
                drChildCode6.DataTextField = "code";
                drChildCode6.DataValueField = "code";
                drChildCode6.DataBind();
                drChildCode6.Items.Insert(0, new ListItem(""));

                DropDownList drChildCode7 = (DropDownList)gvData7.Rows[j].FindControl("dr_ChildName7");
                drChildCode7.DataSource = dtChildCode;
                drChildCode7.DataTextField = "code";
                drChildCode7.DataValueField = "code";
                drChildCode7.DataBind();
                drChildCode7.Items.Insert(0, new ListItem(""));

                drChildCode8 = (DropDownList)gvData8.Rows[j].FindControl("dr_ChildName1a");
                drChildCode8.DataSource = dtChildCode1;
                drChildCode8.DataTextField = "act_name";
                drChildCode8.DataValueField = "act_code";
                drChildCode8.DataBind();
                drChildCode8.Items.Insert(0, new ListItem(""));

                drChildCode9 = (DropDownList)gvData8.Rows[j].FindControl("dr_ChildName1b");
                drChildCode9.DataSource = dtChildCode2;
                drChildCode9.DataTextField = "term_name";
                drChildCode9.DataValueField = "term_code";
                drChildCode9.DataBind();
                drChildCode9.Items.Insert(0, new ListItem(""));
            }



            #region weight

            if (keo == "")
            {
                ClearTextbox();
                btn_edit.Enabled = false;
                return;
            }
            else
            {
                editfalse();
                btn_edit.Enabled = true;
            }
            string sql = "select [mater_code],[mater_name],mini_temp,max_temp,RecipeType,mini_time,over_temp,black_reuse,reuse_time,ThreeTemp1,ThreeTemp2,ThreeTemp3,ThreeTemp4,tablettingtemp,define_date,ever_used,mem_note from [pmt_recipe] where mater_code ='" + keo + "' ";
            DataTable dt = cnn.ExcuteQueryFloor3(ip, sql);
            if (dt.Rows.Count == 0)
            {
                ClearTextbox();
                //ThongBao("Mã keo này không tồn tại, chỉ có thể tại mới! [Pmt_recipe]");
                return;
            }
            else
            {
                txt_matercode.Text = dt.Rows[0][0].ToString().Trim();
                txt_matername.Text = dt.Rows[0][1].ToString().Trim();
                txt_minitemp.Text = dt.Rows[0][2].ToString().Trim();
                txt_maxtemp.Text = dt.Rows[0][3].ToString().Trim();
                string ac = dt.Rows[0][4].ToString().Trim();

                switch (ac)
                {
                    case "1": cbMay1.SelectedIndex = 1; break;
                    case "2": cbMay1.SelectedIndex = 2; break;
                    case "3": cbMay1.SelectedIndex = 3; break;
                    case "4": cbMay1.SelectedIndex = 4; break;
                    default:
                        break;
                }

                txt_minitime.Text = dt.Rows[0][5].ToString().Trim();
                txt_overtemp.Text = dt.Rows[0][6].ToString().Trim();
                string ab = dt.Rows[0][7].ToString().Trim();
                if (ab == "1")
                {
                    CheckBox1.Checked = true;
                }
                else
                {
                    CheckBox1.Checked = false;
                }
                txt_reusetime.Text = dt.Rows[0][8].ToString().Trim();
                txt_threetemp1.Text = dt.Rows[0][9].ToString().Trim();
                txt_threetemp2.Text = dt.Rows[0][10].ToString().Trim();
                txt_threetemp3.Text = dt.Rows[0][11].ToString().Trim();
                txt_threetemp4.Text = dt.Rows[0][12].ToString().Trim();
                txt_tablettingtemp.Text = dt.Rows[0][13].ToString().Trim();
                txt_definedate.Text = dt.Rows[0][14].ToString().Trim();
                string an = dt.Rows[0][15].ToString().Trim();
                if (an == "1")
                {
                    CheckBox2.Checked = true;
                }
                else
                {
                    CheckBox2.Checked = false;
                }
                txt_memnote.Text = dt.Rows[0][16].ToString().Trim();

            }
            #endregion

            if (keo != "")
            {



                for (int i = 0; i < dtkeo.Rows.Count; i++)
                {

                    weight_id = dtkeo.Rows[i][0].ToString().Trim();
                    child_name = dtkeo.Rows[i][1].ToString().Trim();
                    child_code = dtkeo.Rows[i][2].ToString().Trim();
                    set_weight = dtkeo.Rows[i][3].ToString().Trim();
                    error_allow = dtkeo.Rows[i][4].ToString().Trim();
                    weigh_type = dtkeo.Rows[i][5].ToString().Trim();
                    edt_code = dtkeo.Rows[i][6].ToString().Trim();

                    if (weigh_type == "0")
                    {
                        a++;
                        ((DropDownList)gvData.Rows[a].FindControl("dr_ChildName")).SelectedItem.Text = child_name;


                        if (edt_code == "0")
                        {
                            ((DropDownList)gvData.Rows[a].FindControl("dr_ChildCode")).SelectedIndex = 1;
                        }
                        if (edt_code == "2")
                        {
                            ((DropDownList)gvData.Rows[a].FindControl("dr_ChildCode")).SelectedIndex = 2;
                        }
                        if (edt_code == "")
                        {
                            ((DropDownList)gvData.Rows[a].FindControl("dr_ChildCode")).SelectedIndex = 0;
                        }
                        //((Label)gvData.Rows[a].FindControl("ad")).Text = weight_id;
                        ((TextBox)gvData.Rows[a].FindControl("txt_set_weight")).Text = set_weight;
                        ((TextBox)gvData.Rows[a].FindControl("txt_error_allow")).Text = error_allow;
                        ((TextBox)gvData.Rows[a].FindControl("txt_child_code")).Text = child_code;

                    }
                    if (weigh_type == "1")
                    {
                        b++;

                        ((DropDownList)gvData1.Rows[b].FindControl("dr_ChildName1")).SelectedItem.Text = child_name;

                        if (edt_code == "0")
                        {
                            ((DropDownList)gvData1.Rows[b].FindControl("dr_ChildCode1")).SelectedIndex = 1;
                        }
                        if (edt_code == "2")
                        {
                            ((DropDownList)gvData1.Rows[b].FindControl("dr_ChildCode1")).SelectedIndex = 2;
                        }
                        if (edt_code == "")
                        {
                            ((DropDownList)gvData1.Rows[b].FindControl("dr_ChildCode1")).SelectedIndex = 0;
                        }
                        //((Label)gvData1.Rows[b].FindControl("ad1")).Text = weight_id;
                        ((TextBox)gvData1.Rows[b].FindControl("txt_set_weight1")).Text = set_weight;
                        ((TextBox)gvData1.Rows[b].FindControl("txt_error_allow1")).Text = error_allow;
                        ((TextBox)gvData1.Rows[b].FindControl("txt_child_code1")).Text = child_code;

                    }
                    if (weigh_type == "7")
                    {
                        c++;

                        ((DropDownList)gvData2.Rows[c].FindControl("dr_ChildName2")).SelectedItem.Text = child_name;


                        if (edt_code == "0")
                        {
                            ((DropDownList)gvData2.Rows[c].FindControl("dr_ChildCode2")).SelectedIndex = 1;
                        }
                        if (edt_code == "2")
                        {
                            ((DropDownList)gvData2.Rows[c].FindControl("dr_ChildCode2")).SelectedIndex = 2;
                        }
                        if (edt_code == "")
                        {
                            ((DropDownList)gvData2.Rows[c].FindControl("dr_ChildCode2")).SelectedIndex = 0;
                        }
                        // ((Label)gvData2.Rows[c].FindControl("ad2")).Text = weight_id;
                        ((TextBox)gvData2.Rows[c].FindControl("txt_set_weight2")).Text = set_weight;
                        ((TextBox)gvData2.Rows[c].FindControl("txt_error_allow2")).Text = error_allow;
                        ((TextBox)gvData2.Rows[c].FindControl("txt_child_code2")).Text = child_code;

                    }


                    if (weigh_type == "3")
                    {
                        d++;


                        ((DropDownList)gvData3.Rows[d].FindControl("dr_ChildName3")).SelectedItem.Text = child_name;


                        if (edt_code == "0")
                        {
                            ((DropDownList)gvData3.Rows[d].FindControl("dr_ChildCode3")).SelectedIndex = 1;
                        }
                        if (edt_code == "2")
                        {
                            ((DropDownList)gvData3.Rows[d].FindControl("dr_ChildCode3")).SelectedIndex = 2;
                        }
                        if (edt_code == "")
                        {
                            ((DropDownList)gvData3.Rows[d].FindControl("dr_ChildCode3")).SelectedIndex = 0;
                        }
                        // ((Label)gvData3.Rows[d].FindControl("ad3")).Text = weight_id;
                        ((TextBox)gvData3.Rows[d].FindControl("txt_set_weight3")).Text = set_weight;
                        ((TextBox)gvData3.Rows[d].FindControl("txt_error_allow3")).Text = error_allow;
                        ((TextBox)gvData3.Rows[d].FindControl("txt_child_code3")).Text = child_code;



                    }
                    if (weigh_type == "5")
                    {
                        e++;

                        ((DropDownList)gvData4.Rows[e].FindControl("dr_ChildName4")).SelectedItem.Text = child_name;


                        if (edt_code == "0")
                        {
                            ((DropDownList)gvData4.Rows[e].FindControl("dr_ChildCode4")).SelectedIndex = 1;
                        }
                        if (edt_code == "2")
                        {
                            ((DropDownList)gvData4.Rows[e].FindControl("dr_ChildCode4")).SelectedIndex = 2;
                        }
                        if (edt_code == "")
                        {
                            ((DropDownList)gvData4.Rows[e].FindControl("dr_ChildCode4")).SelectedIndex = 0;
                        }
                        //  ((Label)gvData4.Rows[e].FindControl("ad4")).Text = weight_id;
                        ((TextBox)gvData4.Rows[e].FindControl("txt_set_weight4")).Text = set_weight;
                        ((TextBox)gvData4.Rows[e].FindControl("txt_error_allow4")).Text = error_allow;
                        ((TextBox)gvData4.Rows[e].FindControl("txt_child_code4")).Text = child_code;



                    }
                    if (weigh_type == "8")
                    {
                        f++;

                        ((DropDownList)gvData5.Rows[f].FindControl("dr_ChildName5")).SelectedItem.Text = child_name;


                        if (edt_code == "0")
                        {
                            ((DropDownList)gvData5.Rows[f].FindControl("dr_ChildCode5")).SelectedIndex = 1;
                        }
                        if (edt_code == "2")
                        {
                            ((DropDownList)gvData5.Rows[f].FindControl("dr_ChildCode5")).SelectedIndex = 2;
                        }
                        if (edt_code == "")
                        {
                            ((DropDownList)gvData5.Rows[f].FindControl("dr_ChildCode5")).SelectedIndex = 0;
                        }

                        // ((Label)gvData5.Rows[f].FindControl("ad5")).Text = weight_id;
                        ((TextBox)gvData5.Rows[f].FindControl("txt_set_weight5")).Text = set_weight;
                        ((TextBox)gvData5.Rows[f].FindControl("txt_error_allow5")).Text = error_allow;
                        ((TextBox)gvData5.Rows[f].FindControl("txt_child_code5")).Text = child_code;



                    }
                    if (weigh_type == "2")
                    {
                        g++;


                        ((DropDownList)gvData6.Rows[g].FindControl("dr_ChildName6")).SelectedItem.Text = child_name;

                        // ((Label)gvData6.Rows[g].FindControl("ad6")).Text = weight_id;
                        ((TextBox)gvData6.Rows[g].FindControl("txt_set_weight6")).Text = set_weight;
                        ((TextBox)gvData6.Rows[g].FindControl("txt_error_allow6")).Text = error_allow;
                        ((TextBox)gvData6.Rows[g].FindControl("txt_child_code6")).Text = child_code;


                    }
                    if (weigh_type == "6")
                    {
                        h++;


                        ((DropDownList)gvData7.Rows[h].FindControl("dr_ChildName7")).SelectedItem.Text = child_name;


                        if (edt_code == "0")
                        {
                            ((DropDownList)gvData7.Rows[h].FindControl("dr_ChildCode7")).SelectedIndex = 1;
                        }
                        if (edt_code == "2")
                        {
                            ((DropDownList)gvData7.Rows[h].FindControl("dr_ChildCode7")).SelectedIndex = 2;
                        }
                        if (edt_code == "")
                        {
                            ((DropDownList)gvData7.Rows[h].FindControl("dr_ChildCode7")).SelectedIndex = 0;
                        }
                        //((Label)gvData7.Rows[h].FindControl("ad7")).Text = weight_id;
                        ((TextBox)gvData7.Rows[h].FindControl("txt_set_weight7")).Text = set_weight;
                        ((TextBox)gvData7.Rows[h].FindControl("txt_error_allow7")).Text = error_allow;
                        ((TextBox)gvData7.Rows[h].FindControl("txt_child_code7")).Text = child_code;


                    }
                }
                for (int l = 0; l < dtkeo1.Rows.Count; l++)
                {
                    mix_id = dtkeo1.Rows[l][0].ToString().Trim();
                    act_code = dtkeo1.Rows[l][1].ToString().Trim();
                    set_time = dtkeo1.Rows[l][2].ToString().Trim();
                    set_temp = dtkeo1.Rows[l][3].ToString().Trim();
                    set_ener = dtkeo1.Rows[l][4].ToString().Trim();
                    set_power = dtkeo1.Rows[l][5].ToString().Trim();
                    term_code = dtkeo1.Rows[l][6].ToString().Trim();
                    set_pres = dtkeo1.Rows[l][7].ToString().Trim();
                    set_rota = dtkeo1.Rows[l][8].ToString().Trim();

                    DropDownList drDatat = (DropDownList)gvData8.Rows[l].FindControl("dr_ChildName1a");
                    DropDownList drDatat1 = (DropDownList)gvData8.Rows[l].FindControl("dr_ChildName1b");
                    foreach (ListItem li in drDatat.Items)
                    {
                        if (li.Value.Trim() == act_code.Trim())
                        {
                            ((DropDownList)gvData8.Rows[l].FindControl("dr_ChildName1a")).SelectedItem.Text = li.Text.Trim();

                        }
                    }
                    DropDownList drData1t = (DropDownList)gvData8.Rows[l].FindControl("dr_ChildName1a");

                    foreach (ListItem li in drDatat1.Items)
                    {
                        if (li.Value.Trim() == term_code.Trim())
                        {
                            ((DropDownList)gvData8.Rows[l].FindControl("dr_ChildName1b")).SelectedItem.Text = li.Text.Trim();

                        }
                    }
                    if (!drDatat.Items.Contains(new ListItem("")))
                    {
                        drDatat.Items.Insert(0, new ListItem(""));

                    }
                    if (!drDatat1.Items.Contains(new ListItem("")))
                    {
                        drDatat1.Items.Insert(0, new ListItem(""));

                    }

                    // ((Label)gvData8.Rows[l].FindControl("ad8")).Text = mix_id;
                    ((TextBox)gvData8.Rows[l].FindControl("txt_child_code88")).Text = set_time;
                    ((TextBox)gvData8.Rows[l].FindControl("txt_child_code888")).Text = set_temp;
                    ((TextBox)gvData8.Rows[l].FindControl("txt_child_code8888")).Text = set_ener;
                    ((TextBox)gvData8.Rows[l].FindControl("txt_child_code7888")).Text = set_power;
                    ((TextBox)gvData8.Rows[l].FindControl("txt_set_weight75")).Text = set_pres;
                    ((TextBox)gvData8.Rows[l].FindControl("txt_error_allow76")).Text = set_rota;

                }
            }
            getWeight();
        }
        private void ClearTextbox()
        {
            txt_matercode.Text = "";
            txt_matername.Text = "";
            txt_minitemp.Text = "";
            txt_maxtemp.Text = "";
            txt_minitime.Text = "";
            txt_overtemp.Text = "";
            CheckBox1.Checked = false;
            CheckBox2.Checked = false;
            txt_reusetime.Text = "";
            txt_threetemp1.Text = "";
            txt_threetemp2.Text = "";
            txt_threetemp3.Text = "";
            txt_threetemp4.Text = "";
            txt_tablettingtemp.Text = "";
            txt_definedate.Text = "";
            TextBox14.Text = "";

        }
        private void LoadGV()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("", typeof(string));
            dt.Columns.Add("", typeof(string));
            dt.Columns.Add("", typeof(string));
            dt.Columns.Add("", typeof(string));
            dt.Columns.Add("", typeof(string));




            DataTable dt2 = new DataTable();
            dt2.Columns.Add("", typeof(string));
            dt2.Columns.Add("", typeof(string));
            dt2.Columns.Add("", typeof(string));
            dt2.Columns.Add("", typeof(string));
            dt2.Columns.Add("", typeof(string));
            dt2.Columns.Add("", typeof(string));
            dt2.Columns.Add("", typeof(string));




            DataTable dt1 = new DataTable();
            dt1.Columns.Add("", typeof(string));
            dt1.Columns.Add("", typeof(string));
            dt1.Columns.Add("", typeof(string));
            dt1.Columns.Add("", typeof(string));
            dt1.Columns.Add("", typeof(string));
            dt1.Columns.Add("", typeof(string));
            DataRow row;
            for (int i = 0; i < 35; i++)
            {
                row = dt.NewRow();
                dt.Rows.Add(row);
                row = dt1.NewRow();
                dt1.Rows.Add(row);
                row = dt2.NewRow();
                dt2.Rows.Add(row);
            }
            gvData.DataSource = dt1;
            gvData.DataBind();
            gvData1.DataSource = dt1;
            gvData1.DataBind();
            gvData2.DataSource = dt1;
            gvData2.DataBind();
            gvData3.DataSource = dt1;
            gvData3.DataBind();
            gvData4.DataSource = dt1;
            gvData4.DataBind();
            gvData5.DataSource = dt1;
            gvData5.DataBind();
            gvData6.DataSource = dt;
            gvData6.DataBind();
            gvData7.DataSource = dt1;
            gvData7.DataBind();

            gvData8.DataSource = dt2;
            gvData8.DataBind();

        }
        protected void gvDistricts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex == 0)
                    e.Row.Style.Add("height", "40px");
            }
        }
        private void LoadKeo()
        {
            string ip = "";
            switch (cbMay.Text.Trim().Substring(6))
            {
                case "01": ip = "198.1.8.21"; break;
                case "02": ip = "198.1.8.22"; break;
                case "03": ip = "198.1.8.23"; break;
                case "04": ip = "198.1.8.24"; break;
                case "05": ip = "198.1.8.35"; break;
                case "06": ip = "198.1.8.36"; break;
                case "07": ip = "198.1.8.37"; break;
                case "08": ip = "198.1.8.38"; break;
                default:
                    break;
            }
            cb_dataKEo1.Items.Clear();
            string getData1 = "select LTRIM(RTRIM(mater_code)) mater_code from [mfns].[dbo].[pmt_recipe]";
            DataTable dt = cnn.ExecuteQueryWithIP(ip, getData1);

            cb_dataKEo1.DataSource = dt;
            cb_dataKEo1.DataTextField = "mater_code";
            cb_dataKEo1.DataValueField = "mater_code";
            cb_dataKEo1.DataBind();
            cb_dataKEo1.Items.Insert(0, new ListItem(""));
        }
        protected void cbMay_TextChanged(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                btn_add.Text = "Thêm Mới(添新)";
                btn_edit.Text = "Chỉnh Sửa (编辑)";
                editfalse();
                if (cbMay.SelectedValue == "")
                {
                    ClearTextbox();
                    LoadGV();
                    cb_dataKEo1.Items.Clear();
                    cbMay1.SelectedIndex = 0;
                    return;
                };
                if (cbMay.Text.Trim().Substring(6) == "01")
                {
                    ClearTextbox();
                    LoadGV();
                    cb_dataKEo1.Enabled = true;
                    btn_add.Enabled = true;
                    LoadKeo();
                }
                if (cbMay.Text.Trim().Substring(6) == "02")
                {
                    ClearTextbox();
                    LoadGV();
                    cb_dataKEo1.Enabled = true;
                    btn_add.Enabled = true;
                    LoadKeo();
                }
                if (cbMay.Text.Trim().Substring(6) == "03")
                {
                    ClearTextbox();
                    LoadGV();
                    cb_dataKEo1.Enabled = true;
                    btn_add.Enabled = true;
                    LoadKeo();
                }
                if (cbMay.Text.Trim().Substring(6) == "04")
                {
                    ClearTextbox();
                    LoadGV();
                    cb_dataKEo1.Enabled = true;
                    btn_add.Enabled = true;
                    LoadKeo();
                }
                if (cbMay.Text.Trim().Substring(6) == "05")
                {
                    ClearTextbox();
                    LoadGV();
                    cb_dataKEo1.Enabled = true;
                    btn_add.Enabled = true;
                    LoadKeo();
                }
                if (cbMay.Text.Trim().Substring(6) == "06")
                {
                    ClearTextbox();
                    LoadGV();
                    cb_dataKEo1.Enabled = true;
                    btn_add.Enabled = true;
                    LoadKeo();
                }
                if (cbMay.Text.Trim().Substring(6) == "07")
                {
                    ClearTextbox();
                    LoadGV();
                    cb_dataKEo1.Enabled = true;
                    btn_add.Enabled = true;
                    LoadKeo();
                }
                if (cbMay.Text.Trim().Substring(6) == "08")
                {
                    ClearTextbox();
                    LoadGV();
                    cb_dataKEo1.Enabled = true;
                    btn_add.Enabled = true;
                    LoadKeo();
                }
            }
        }
        protected void cb_dataKEo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                btn_add.Text = "Thêm Mới(添新)";
                btn_edit.Text = "Chỉnh Sửa (编辑)";
                getData();
            }
        }
        protected void btn_edit_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                string ip = "";
                switch (cbMay.Text.Trim().Substring(6))
                {
                    case "01": ip = "198.1.8.21"; break;
                    case "02": ip = "198.1.8.22"; break;
                    case "03": ip = "198.1.8.23"; break;
                    case "04": ip = "198.1.8.24"; break;
                    case "05": ip = "198.1.8.35"; break;
                    case "06": ip = "198.1.8.36"; break;
                    case "07": ip = "198.1.8.37"; break;
                    case "08": ip = "198.1.8.38"; break;
                    default:
                        break;
                }

                if (btn_edit.Text.Trim() == "Cập nhật (更新)")
                {
                    btn_edit.Text = "Chỉnh Sửa (编辑)";
                    InsertDataRecipe(ip, txt_matercode.Text.Trim(), txt_matername.Text.Trim(), cbMay.Text.Trim().Substring(6), 1);
                    editfalse();
                    btn_add.Enabled = true;
                    btn_edit.Enabled = true;
                    cb_dataKEo1.Enabled = true;
                }
                else
                {
                    btn_edit.Text = "Cập nhật (更新)";
                    btn_add.Enabled = false;
                    edittrue();
                    txt_matercode.Enabled = false;
                }
            }
        }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                string ip = "";
                switch (cbMay.Text.Trim().Substring(6))
                {
                    case "01": ip = "198.1.8.21"; break;
                    case "02": ip = "198.1.8.22"; break;
                    case "03": ip = "198.1.8.23"; break;
                    case "04": ip = "198.1.8.24"; break;
                    case "05": ip = "198.1.8.35"; break;
                    case "06": ip = "198.1.8.36"; break;
                    case "07": ip = "198.1.8.37"; break;
                    case "08": ip = "198.1.8.38"; break;
                    default:
                        break;
                }
                if (btn_add.Text == "Thêm Mới(添新)")
                {
                    btn_add.Text = "Save";
                    edittrue();
                    txt_matercode.Text = "";
                    txt_matername.Text = "";
                    txt_minitemp.Text = "";
                    txt_maxtemp.Text = "";
                    txt_minitime.Text = "";
                    txt_overtemp.Text = "";
                    CheckBox1.Checked = false;
                    CheckBox2.Checked = false;
                    Button1.Enabled = false;
                    txt_reusetime.Text = "";
                    txt_threetemp1.Text = "";
                    txt_threetemp2.Text = "";
                    txt_threetemp3.Text = "";
                    txt_threetemp4.Text = "";
                    txt_tablettingtemp.Text = "";
                    txt_definedate.Text = "";
                    cbMay1.SelectedIndex = 0;
                    cb_dataKEo1.SelectedIndex = 0;
                    LoadGV();
                    getData();
                    txt_matercode.Focus();
                }
                else
                {

                    InsertDataRecipe(ip, txt_matercode.Text.Trim(), txt_matername.Text.Trim(), cbMay.Text.Trim().Substring(6), 1);

                }

            }


        }
        private void InsertDataMix(string ip, string mater_code, string may)
        {

            int con = 0;
            string strInsert = "";
            for (int i = 0; i < gvData8.Rows.Count; i++)
            {
                string act_codemix = ((DropDownList)gvData8.Rows[i].FindControl("dr_ChildName1a")).SelectedItem.Text.Trim();
                string set_time = ((TextBox)gvData8.Rows[i].FindControl("txt_child_code88")).Text.ToString().Trim();
                string set_temp = ((TextBox)gvData8.Rows[i].FindControl("txt_child_code888")).Text.ToString().Trim();
                string set_ener = ((TextBox)gvData8.Rows[i].FindControl("txt_child_code8888")).Text.ToString().Trim();
                string set_power = ((TextBox)gvData8.Rows[i].FindControl("txt_child_code7888")).Text.ToString().Trim();
                string term_code = ((DropDownList)gvData8.Rows[i].FindControl("dr_ChildName1b")).SelectedItem.Text.Trim();
                string set_pres = ((TextBox)gvData8.Rows[i].FindControl("txt_set_weight75")).Text.ToString().Trim();
                string set_rota = ((TextBox)gvData8.Rows[i].FindControl("txt_error_allow76")).Text.ToString().Trim();
                // string mix_id = ((TextBox)gvData8.Rows[i].FindControl("ad8")).Text.ToString().Trim();
                string bb = "";
                string ba = "";
                if (mater_code.Trim() != "")
                {
                    DropDownList drDatat1 = (DropDownList)gvData8.Rows[i].FindControl("dr_ChildName1a");
                    foreach (ListItem item in drDatat1.Items)
                    {
                        if (item.ToString().Trim() == act_codemix)
                        {
                            ba = item.Value;
                        }

                    }
                    DropDownList drDatat = (DropDownList)gvData8.Rows[i].FindControl("dr_ChildName1b");
                    foreach (ListItem item in drDatat.Items)
                    {
                        if (item.ToString().Trim() == term_code)
                        {
                            bb = item.Value;
                        }

                    }

                    if (act_codemix == "")
                    {
                        // ThongBao("Vui lòng không bỏ trống [act_code]!");
                        continue;
                    }
                    if (set_time == "")
                    {
                        set_time = "0";
                    }
                    if (set_temp == "")
                    {
                        set_temp = "0";
                    }
                    if (set_ener == "")
                    {
                        set_ener = "0";
                    }
                    if (set_power == "")
                    {
                        set_power = "0";
                    }
                    if (set_pres == "")
                    {
                        set_pres = "0";
                    }
                    if (set_rota == "")
                    {
                        set_rota = "0";
                    }
                    con += 1;
                    strInsert += "Insert into [pmt_mix] values('" + mater_code.Trim() + "','" + may + "',null,'6','" + bb + "','" + set_time + "','" + set_temp + "','" + set_ener + "','" + set_power + "','" + ba + "'," +
                        " " + set_pres + ",'" + set_rota + "',null,null,'" + con + "')";
                }
            }

            DataTable keo = cnn.ExcuteQueryFloor3(ip, "select * from [pmt_mix] where father_code='" + txt_matercode.Text.Trim() + "'");
            if (keo.Rows.Count > 0)
            {
                cnn.ExecuteNonQueryWithIP(ip, "Delete from [pmt_mix] where father_code='" + mater_code.Trim() + "'");
            }

            bool ins_data = cnn.ExecuteNonQueryWithIP(ip, strInsert);

            // bool ins_Log = cnn.ExecuteNonQuery186("insert into Log_TCBBFloor3 values('" + Session["username"].ToString().Trim() + "','" + Session["ipPC"].ToString().Trim() + "','" + txt_matercode.Text.Trim() + "','" + may + "','pmt_mix','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')");
            if (!ins_data)
            {
                //ThongBao("LỖI! Thêm mới Tiêu Chuẩn không thành công! [pmt_mix]");
                return;
            }
            else
            {
                // ThongBao("Thêm mới Tiêu Chuẩn thành công!");
                return;
            }
        }
        private void InsertDataRecipe(string ip, string mater_code, string mater_name, string may, int num)
        {
            if (mater_code == "" || cbMay1.Text == "" || txt_minitemp.Text == "" || txt_minitime.Text == "" || txt_overtemp.Text == "")
            {
                ThongBao("Vui lòng nhập đầy đủ thông tin!");
                return;
            }




            string mini_temp = txt_minitemp.Text.Trim();
            string max_temp = txt_maxtemp.Text.Trim();
            string RecipeType = cbMay1.SelectedValue;
            string mini_time = txt_minitime.Text.Trim();
            string over_temp = txt_overtemp.Text.Trim();
            string black_reuse = "0";
            if (CheckBox1.Checked == true)
            {
                black_reuse = "1";
            }



            string reuse_time = txt_reusetime.Text.Trim();
            string ThreeTemp1 = txt_threetemp1.Text.Trim();
            string ThreeTemp2 = txt_threetemp2.Text.Trim();

            string ThreeTemp3 = txt_threetemp3.Text.Trim();
            string ThreeTemp4 = txt_threetemp4.Text.Trim();
            string tablettingtemp = txt_tablettingtemp.Text.Trim();
            string define_date = txt_definedate.Text.Trim();
            string ever_used = "0";
            if (CheckBox2.Checked == true)
            {
                ever_used = "1";
            }

            string mem_note = txt_memnote.Text.Trim();
            DataTable tstExists = cnn.ExecuteQueryWithIP(ip, "select * from pmt_recipe where mater_code='" + mater_code.Trim() + "'");
            if (tstExists.Rows.Count > 0)
            {
                string delKeo = "delete from pmt_recipe where mater_code='" + mater_code.Trim() + "'";
                bool del = cnn.ExecuteNonQueryWithIP(ip, delKeo);

                if (del)
                {


                }
            }
            string insertData = "insert into [pmt_recipe] values('" + mater_code + "','" + mater_name + "','','" + may + "','" + '6' + "',null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,'" + ever_used + "' " +
               ",'" + black_reuse + "','" + reuse_time + "','" + mini_time + "','" + max_temp + "','" + mini_temp + "','" + over_temp + "',null,null,null,null,'" + mem_note + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," + ThreeTemp1 + "," + ThreeTemp2 + "," + ThreeTemp3 + "," + ThreeTemp4 + ", " +
               "'0','1'," + tablettingtemp + "," + RecipeType + ",null)";

            bool ins = cnn.ExecuteNonQueryWithIP(ip, insertData);
            //bool ins_Log = cnn.ExecuteNonQuery186("insert into Log_TCBBFloor3 values('" + Session["username"].ToString().Trim() + "','" + Session["ipPC"].ToString().Trim() + "','" + txt_matercode.Text.Trim() + "','" + may + "','pmt_recipe','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')");
            if (ins == true)
            {
                InsertDataWeight(ip, mater_code, may);
                InsertDataMix(ip, mater_code, may);
                LoadKeo();
                if (num == 1)
                {

                    cb_dataKEo1.Text = txt_matercode.Text.Trim();
                    getData();
                    editfalse();
                    cb_dataKEo1.Enabled = true;
                    btn_add.Enabled = true;
                    btn_edit.Enabled = true;
                    btn_add.Text = "Thêm Mới(添新)";
                    ThongBao("Lưu thành công!");
                }
                if (num == 2)
                {
                    ThongBao("Copy thành công!");
                }

            }
            else
            {
                ThongBao("Lỗi!");
            }


        }
        private void InsertDataWeight(string ip, string mater_code, string may)
        {


            string ins_wgt = "";
            for (int i = 0; i < gvData.Rows.Count; i++)
            {
                string weight_id = ((Label)gvData.Rows[i].FindControl("ad")).Text.ToString().Trim();
                string act_code = ((DropDownList)gvData.Rows[i].FindControl("dr_ChildCode")).Text.ToString().Trim();
                string child_name = ((DropDownList)gvData.Rows[i].FindControl("dr_ChildName")).Text.ToString().Trim();
                string child_code = ((TextBox)gvData.Rows[i].FindControl("txt_child_code")).Text.ToString().Trim();
                string set_weight = ((TextBox)gvData.Rows[i].FindControl("txt_set_weight")).Text.ToString().Trim();
                string error_allow = ((TextBox)gvData.Rows[i].FindControl("txt_error_allow")).Text.ToString().Trim();



                if (mater_code.Trim() != "" && act_code != "1")
                {
                    if (act_code == "0" && child_name.Trim() == "")
                    {
                        continue;
                    }
                    if (set_weight == "")
                    {
                        set_weight = "0";
                    }

                    if (error_allow == "")
                    {
                        error_allow = "0";
                    }

                    ins_wgt += "insert into [pmt_weigh] values(" + weight_id + ",'" + mater_code.Trim() + "','" + may.Trim() + "','6','0','" + act_code + "','" + child_code + "','" + child_name + "'," + set_weight + "," + error_allow + ",null,null) ";
                }
            }
            for (int i = 0; i < gvData1.Rows.Count; i++)
            {
                string weight_id = ((Label)gvData1.Rows[i].FindControl("ad1")).Text.ToString().Trim();
                string act_code = ((DropDownList)gvData1.Rows[i].FindControl("dr_ChildCode1")).Text.ToString().Trim();
                string child_name = ((DropDownList)gvData1.Rows[i].FindControl("dr_ChildName1")).Text.ToString().Trim();
                string child_code = ((TextBox)gvData1.Rows[i].FindControl("txt_child_code1")).Text.ToString().Trim();
                string set_weight = ((TextBox)gvData1.Rows[i].FindControl("txt_set_weight1")).Text.ToString().Trim();
                string error_allow = ((TextBox)gvData1.Rows[i].FindControl("txt_error_allow1")).Text.ToString().Trim();


                if (mater_code.Trim() != "" && act_code != "1")
                {
                    if (act_code == "0" && child_name.Trim() == "")
                    {
                        continue;
                    }

                    if (set_weight == "")
                    {
                        set_weight = "0";
                    }

                    if (error_allow == "")
                    {
                        error_allow = "0";
                    }

                    ins_wgt += "insert into [pmt_weigh] values(" + weight_id + ",'" + mater_code.Trim() + "','" + may.Trim() + "','6','1','" + act_code + "','" + child_code + "','" + child_name + "'," + set_weight + "," + error_allow + ",null,null) ";
                }
            }
            for (int i = 0; i < gvData2.Rows.Count; i++)
            {
                string weight_id = ((Label)gvData2.Rows[i].FindControl("ad2")).Text.ToString().Trim();
                string act_code = ((DropDownList)gvData2.Rows[i].FindControl("dr_ChildCode2")).Text.ToString().Trim();
                string child_name = ((DropDownList)gvData2.Rows[i].FindControl("dr_ChildName2")).Text.ToString().Trim();
                string child_code = ((TextBox)gvData2.Rows[i].FindControl("txt_child_code2")).Text.ToString().Trim();
                string set_weight = ((TextBox)gvData2.Rows[i].FindControl("txt_set_weight2")).Text.ToString().Trim();
                string error_allow = ((TextBox)gvData2.Rows[i].FindControl("txt_error_allow2")).Text.ToString().Trim();


                if (mater_code.Trim() != "" && act_code != "1")
                {
                    if (act_code == "0" && child_name.Trim() == "")
                    {
                        continue;
                    }

                    if (set_weight == "")
                    {
                        set_weight = "0";
                    }

                    if (error_allow == "")
                    {
                        error_allow = "0";
                    }

                    ins_wgt += "insert into [pmt_weigh] values(" + weight_id + ",'" + mater_code.Trim() + "','" + may.Trim() + "','6','7','" + act_code + "','" + child_code + "','" + child_name + "'," + set_weight + "," + error_allow + ",null,null) ";
                }
            }
            for (int i = 0; i < gvData3.Rows.Count; i++)
            {
                string weight_id = ((Label)gvData3.Rows[i].FindControl("ad3")).Text.ToString().Trim();
                string act_code = ((DropDownList)gvData3.Rows[i].FindControl("dr_ChildCode3")).Text.ToString().Trim();
                string child_name = ((DropDownList)gvData3.Rows[i].FindControl("dr_ChildName3")).Text.ToString().Trim();
                string child_code = ((TextBox)gvData3.Rows[i].FindControl("txt_child_code3")).Text.ToString().Trim();
                string set_weight = ((TextBox)gvData3.Rows[i].FindControl("txt_set_weight3")).Text.ToString().Trim();
                string error_allow = ((TextBox)gvData3.Rows[i].FindControl("txt_error_allow3")).Text.ToString().Trim();


                if (mater_code.Trim() != "" && act_code != "1")
                {
                    if (act_code == "0" && child_name.Trim() == "")
                    {
                        continue;
                    }

                    if (set_weight == "")
                    {
                        set_weight = "0";
                    }

                    if (error_allow == "")
                    {
                        error_allow = "0";
                    }

                    ins_wgt += "insert into [pmt_weigh] values(" + weight_id + ",'" + mater_code.Trim() + "','" + may.Trim() + "','6','3','" + act_code + "','" + child_code + "','" + child_name + "'," + set_weight + "," + error_allow + ",null,null) ";
                }
            }
            for (int i = 0; i < gvData4.Rows.Count; i++)
            {
                string weight_id = ((Label)gvData4.Rows[i].FindControl("ad4")).Text.ToString().Trim();
                string act_code = ((DropDownList)gvData4.Rows[i].FindControl("dr_ChildCode4")).Text.ToString().Trim();
                string child_name = ((DropDownList)gvData4.Rows[i].FindControl("dr_ChildName4")).Text.ToString().Trim();
                string child_code = ((TextBox)gvData4.Rows[i].FindControl("txt_child_code4")).Text.ToString().Trim();
                string set_weight = ((TextBox)gvData4.Rows[i].FindControl("txt_set_weight4")).Text.ToString().Trim();
                string error_allow = ((TextBox)gvData4.Rows[i].FindControl("txt_error_allow4")).Text.ToString().Trim();



                if (mater_code.Trim() != "" && act_code != "1")
                {
                    if (act_code == "0" && child_name.Trim() == "")
                    {
                        continue;
                    }
                    if (set_weight == "")
                    {
                        set_weight = "0";
                    }

                    if (error_allow == "")
                    {
                        error_allow = "0";
                    }

                    ins_wgt += "insert into [pmt_weigh] values(" + weight_id + ",'" + mater_code.Trim() + "','" + may.Trim() + "','6','5','" + act_code + "','" + child_code + "','" + child_name + "'," + set_weight + "," + error_allow + ",null,null) ";
                }
            }
            for (int i = 0; i < gvData5.Rows.Count; i++)
            {
                string weight_id = ((Label)gvData5.Rows[i].FindControl("ad5")).Text.ToString().Trim();
                string act_code = ((DropDownList)gvData5.Rows[i].FindControl("dr_ChildCode5")).Text.ToString().Trim();
                string child_name = ((DropDownList)gvData5.Rows[i].FindControl("dr_ChildName5")).Text.ToString().Trim();
                string child_code = ((TextBox)gvData5.Rows[i].FindControl("txt_child_code5")).Text.ToString().Trim();
                string set_weight = ((TextBox)gvData5.Rows[i].FindControl("txt_set_weight5")).Text.ToString().Trim();
                string error_allow = ((TextBox)gvData5.Rows[i].FindControl("txt_error_allow5")).Text.ToString().Trim();



                if (mater_code.Trim() != "" && act_code != "1")
                {

                    if (act_code == "0" && child_name.Trim() == "")
                    {
                        continue;
                    }
                    if (set_weight == "")
                    {
                        set_weight = "0";
                    }

                    if (error_allow == "")
                    {
                        error_allow = "0";
                    }

                    ins_wgt += "insert into [pmt_weigh] values(" + weight_id + ",'" + mater_code.Trim() + "','" + may.Trim() + "','6','8','" + act_code + "','" + child_code + "','" + child_name + "'," + set_weight + "," + error_allow + ",null,null) ";
                }
            }
            for (int i = 0; i < gvData6.Rows.Count; i++)
            {
                string weight_id = ((Label)gvData6.Rows[i].FindControl("ad6")).Text.ToString().Trim();
                string act_code = "";
                string child_name = ((DropDownList)gvData6.Rows[i].FindControl("dr_ChildName6")).Text.ToString().Trim();
                string child_code = ((TextBox)gvData6.Rows[i].FindControl("txt_child_code6")).Text.ToString().Trim();
                string set_weight = ((TextBox)gvData6.Rows[i].FindControl("txt_set_weight6")).Text.ToString().Trim();
                string error_allow = ((TextBox)gvData6.Rows[i].FindControl("txt_error_allow6")).Text.ToString().Trim();



                if (mater_code.Trim() != "" && child_name != "")
                {

                    if (act_code == "0" && child_name.Trim() == "")
                    {
                        continue;
                    }
                    if (set_weight == "")
                    {
                        set_weight = "0";
                    }

                    if (error_allow == "")
                    {
                        error_allow = "0";
                    }

                    ins_wgt += "insert into [pmt_weigh] values(" + weight_id + ",'" + mater_code.Trim() + "','" + may.Trim() + "','6','2','" + act_code + "','" + child_code + "','" + child_name + "'," + set_weight + "," + error_allow + ",null,null) ";
                }
            }
            for (int i = 0; i < gvData7.Rows.Count; i++)
            {
                string weight_id = ((Label)gvData7.Rows[i].FindControl("ad7")).Text.ToString().Trim();
                string act_code = ((DropDownList)gvData7.Rows[i].FindControl("dr_ChildCode7")).Text.ToString().Trim();
                string child_name = ((DropDownList)gvData7.Rows[i].FindControl("dr_ChildName7")).Text.ToString().Trim();
                string child_code = ((TextBox)gvData7.Rows[i].FindControl("txt_child_code7")).Text.ToString().Trim();
                string set_weight = ((TextBox)gvData7.Rows[i].FindControl("txt_set_weight7")).Text.ToString().Trim();
                string error_allow = ((TextBox)gvData7.Rows[i].FindControl("txt_error_allow7")).Text.ToString().Trim();



                if (mater_code.Trim() != "" && act_code != "1")
                {

                    if (act_code == "0" && child_name.Trim() == "")
                    {
                        continue;
                    }
                    if (set_weight == "")
                    {
                        set_weight = "0";
                    }

                    if (error_allow == "")
                    {
                        error_allow = "0";
                    }

                    ins_wgt += "insert into [pmt_weigh] values(" + weight_id + ",'" + mater_code.Trim() + "','" + may.Trim() + "','6','6','" + act_code + "','" + child_code + "','" + child_name + "'," + set_weight + "," + error_allow + ",null,null) ";
                }
            }
            DataTable tstExists = cnn.ExecuteQueryWithIP(ip, "select * from [pmt_weigh] where father_code='" + mater_code.Trim() + "'");
            if (tstExists.Rows.Count > 0)
            {
                string delKeo = "delete from [pmt_weigh] where father_code='" + mater_code.Trim() + "'";
                bool del = cnn.ExecuteNonQueryWithIP(ip, delKeo);

                if (!del)
                {
                    // ThongBao("Không thể chỉnh sửa tiêu chuẩn KEO! (1) [pmt_weigh]");
                    //return;
                }
            }

            bool insData = cnn.ExecuteNonQueryWithIP(ip, ins_wgt);
            //bool ins_Log = cnn.ExecuteNonQuery186("insert into Log_TCBBFloor3 values('" + Session["username"].ToString().Trim() + "','" + Session["ipPC"].ToString().Trim() + "','" + txt_matercode.Text.Trim() + "','" + may + "','pmt_weigh','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')");
            if (insData)
            {
                //ThongBao("Thêm tiêu chuẩn KEO thành công!");
            }
            else
            {
                // ThongBao("Không thêm mới được tiêu chuẩn KEO (2) [pmt_weigh]");
            }
        }
        private void ThongBao(string content)
        {
            lbMess.Text = content;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "Showmess();", true);
        }
        private void getWeight()
        {
            float a = 0;
            string b = "";
            for (int i = 0; i < gvData.Rows.Count; i++)
            {
                if (((DropDownList)gvData.Rows[i].FindControl("dr_ChildName")).SelectedItem.Text != "")
                {
                    b = ((TextBox)gvData.Rows[i].FindControl("txt_set_weight")).Text;
                    a = a + float.Parse(b);
                }
            }
            for (int i = 0; i < gvData1.Rows.Count; i++)
            {
                if (((DropDownList)gvData1.Rows[i].FindControl("dr_ChildName1")).SelectedItem.Text != "")
                {
                    b = ((TextBox)gvData1.Rows[i].FindControl("txt_set_weight1")).Text;
                    a = a + float.Parse(b);
                }
            }
            for (int i = 0; i < gvData2.Rows.Count; i++)
            {
                if (((DropDownList)gvData2.Rows[i].FindControl("dr_ChildName2")).SelectedItem.Text != "")
                {
                    b = ((TextBox)gvData2.Rows[i].FindControl("txt_set_weight2")).Text;
                    a = a + float.Parse(b);
                }
            }
            for (int i = 0; i < gvData3.Rows.Count; i++)
            {
                if (((DropDownList)gvData3.Rows[i].FindControl("dr_ChildName3")).SelectedItem.Text != "")
                {
                    b = ((TextBox)gvData3.Rows[i].FindControl("txt_set_weight3")).Text;
                    a = a + float.Parse(b);
                }
            }
            for (int i = 0; i < gvData4.Rows.Count; i++)
            {
                if (((DropDownList)gvData4.Rows[i].FindControl("dr_ChildName4")).SelectedItem.Text != "")
                {
                    b = ((TextBox)gvData4.Rows[i].FindControl("txt_set_weight4")).Text;
                    a = a + float.Parse(b);
                }
            }
            for (int i = 0; i < gvData5.Rows.Count; i++)
            {
                if (((DropDownList)gvData5.Rows[i].FindControl("dr_ChildName5")).SelectedItem.Text != "")
                {
                    b = ((TextBox)gvData5.Rows[i].FindControl("txt_set_weight5")).Text;
                    a = a + float.Parse(b);
                }
            }
            for (int i = 0; i < gvData6.Rows.Count; i++)
            {
                if (((DropDownList)gvData6.Rows[i].FindControl("dr_ChildName6")).SelectedItem.Text != "")
                {
                    b = ((TextBox)gvData6.Rows[i].FindControl("txt_set_weight6")).Text;
                    a = a + float.Parse(b);
                }
            }
            for (int i = 0; i < gvData7.Rows.Count; i++)
            {
                if (((DropDownList)gvData7.Rows[i].FindControl("dr_ChildName7")).SelectedItem.Text != "")
                {
                    b = ((TextBox)gvData7.Rows[i].FindControl("txt_set_weight7")).Text;
                    a = a + float.Parse(b);
                }
            }
            TextBox14.Text = a.ToString();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                TextBox1.Text = txt_matercode.Text.Trim();
                TextBox2.Text = txt_matername.Text.Trim();
                ScriptManager.RegisterStartupScript(this, GetType(), "", "ShowgvInfo();", true);
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                if (CheckBox3.Checked == true)
                {
                    InsertDataRecipe("198.1.8.21", TextBox1.Text.Trim(), TextBox2.Text.Trim(), "01", 2);
                }
                if (CheckBox4.Checked == true)
                {
                    InsertDataRecipe("198.1.8.22", TextBox1.Text.Trim(), TextBox2.Text.Trim(), "02", 2);
                }
                if (CheckBox5.Checked == true)
                {
                    InsertDataRecipe("198.1.8.23", TextBox1.Text.Trim(), TextBox2.Text.Trim(), "03", 2);
                }
                if (CheckBox6.Checked == true)
                {
                    InsertDataRecipe("198.1.8.24", TextBox1.Text.Trim(), TextBox2.Text.Trim(), "04", 2);
                }
                if (CheckBox7.Checked == true)
                {
                    InsertDataRecipe("198.1.8.35", TextBox1.Text.Trim(), TextBox2.Text.Trim(), "05", 2);
                }
                if (CheckBox8.Checked == true)
                {
                    InsertDataRecipe("198.1.8.36", TextBox1.Text.Trim(), TextBox2.Text.Trim(), "06", 2);
                }
                if (CheckBox9.Checked == true)
                {
                    InsertDataRecipe("198.1.8.37", TextBox1.Text.Trim(), TextBox2.Text.Trim(), "07", 2);
                }
                if (CheckBox10.Checked == true)
                {
                    InsertDataRecipe("198.1.8.38", TextBox1.Text.Trim(), TextBox2.Text.Trim(), "08", 2);
                }
            }
        }
    }
}