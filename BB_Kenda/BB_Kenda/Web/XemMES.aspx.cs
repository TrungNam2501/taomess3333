using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BB_Kenda.CnnSQL;

namespace BB_Kenda.Web
{
    public partial class XemMES : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            string fromDay = txtFromDay.Text.Trim().Replace("-", "");
            string toDay = txtToDay.Text.Trim().Replace("-", "");
            string ca = dr_Ca.Text.Trim();
            string recipeType = dr_typeRecipe.Text.Trim();
            string may = dr_May.Text.Trim();
            if (dr_May.Text.Trim().Length > 6)
            {
                may = dr_May.Text.Trim().Substring(6, 2);
            }

            if (fromDay == "")
            {
                ThongBao("Xin vui lòng chọn ngày!");
                return;
            }

            DataTable dt = new DataTable();
            string GetData = "";
            //if (fromDay == "" && toDay == "" && may == "" && recipeType == "" && may == "")
            //{
            //    GetData = "select [subno],[factory],[mesid],[shift],[recipe_name],[machno],[weight],[indat],[intime],[pday] from [InTem].[dbo].[KEORE] where subno=4 and pday='" + DateTime.Now.ToString("yyyyMMdd") + "'";
            //}

            if (ca != "")
            {
                ca = " and b.class='" + ca.Trim() + "' ";
            }
            if (recipeType != "")
            {
                recipeType = " and b.barcode like '" + recipeType.Trim() + "%' ";
            }
            if (may != "")
            {
                may = " and a.machno='" + may.Trim() + "' ";
            }

            if (fromDay != "" && toDay == "")
            {
                GetData = " select a.[subno],a.[factory],a.[mesid],b.[class],a.[recipe_name],b.[machno],a.[weight],a.[indat],a.[intime],a.[pday] from [198.1.9.186].[InTem].[dbo].[KEORE] a,[erp].[dbo].[prdebe] b " +
                "where a.mesid = b.mesid and pday >= '" + fromDay + "' " + ca + recipeType + may + " " +
                "group by a.[subno],a.[factory],a.[mesid],b.[class],a.[recipe_name],b.[machno],a.[weight],a.[indat],a.[intime],a.[pday] order by a.pday desc,a.intime desc";
            }

            if (fromDay != "" && toDay != "")
            {
                GetData = "select a.[subno],a.[factory],a.[mesid],b.[class],a.[recipe_name],b.[machno],a.[weight],a.[indat],a.[intime],a.[pday] " +
                "from [198.1.9.186].[InTem].[dbo].[KEORE] a,[erp].[dbo].[prdebe] b " +
                "where a.mesid = b.mesid and pday >= '" + fromDay + "' and pday <= '" + toDay + "' " + ca + recipeType + may + " " +
                "group by a.[subno],a.[factory],a.[mesid],b.[class],a.[recipe_name],b.[machno],a.[weight],a.[indat],a.[intime],a.[pday] order by a.pday desc,a.intime desc";
            }

            dt = cnn.ExecuteQuery33(GetData);
            lbCount.Text = "Tổng số dữ liệu: " + dt.Rows.Count.ToString().Trim();
            if (dt.Rows.Count == 0)
            {

                gvData.DataSource = null;
                gvData.DataBind();
                ThongBao("Không có dữ liệu!");
                return;
            }
            gvData.DataSource = dt;
            gvData.DataBind();
        }

        protected void gvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "btnCheck":
                    DataTable getInfor = cnn.ExecuteQuery33("select mesid,machno,daylimt,barcode,slipno,weight,prodat,effdat,partno,intime,indat,usrno,pallet_no " +
                        "from [erp].[dbo].[prdebe] where subno=4 and factory='V' and mesid='" + id + "' order by indat desc,intime desc");
                    gvInfo.DataSource = getInfor;
                    gvInfo.DataBind();
                    lbInfo.Text = "Thông Tin Mã MES: " + id + " - Tổng số dữ liệu:" + getInfor.Rows.Count.ToString(); ;
                    ScriptManager.RegisterStartupScript(this, GetType(), "", "ShowgvInfo();", true);
                    break;
            }
        }

        private void ThongBao(string content)
        {
            lbMess.Text = content;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "Showmess();", true);
        }

        protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string ca = e.Row.Cells[6].Text.Trim();

                if (ca == "1")
                {
                    e.Row.Cells[6].Text = "Ngày";
                }
                else
                {
                    e.Row.Cells[6].Text = "Đêm";
                }
            }
        }

        protected void btnXem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void gvInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}