using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BB_Kenda.CnnSQL;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.ExtendedProperties;

namespace BB_Kenda.Web
{
    public partial class dataoil : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loaddata("");
            }

        }
        private void loaddata(string a)
        {
            string dataOil = "WITH CTE AS (SELECT [ID], [Indat], [Intime], [Result_ActiveUp], [HMI_Barcode], " +
                "[Barcode_left_7bit], ROW_NUMBER() OVER (PARTITION BY [HMI_Barcode] ORDER BY [Indat], [Intime])" +
                " AS RowNum FROM [BB].[dbo].[bb_Oil]) SELECT [ID], [Indat], [Intime], [Result_ActiveUp]," +
                " [HMI_Barcode], [Barcode_left_7bit] FROM CTE WHERE RowNum = 1  "+ a +" ORDER BY [Indat] DESC, [Intime] " +
                "DESC;";
            DataTable dt = cnn.ExecuteQuery33bb(dataOil);
            dataexcel.excel = dt;

            gvDataOil.DataSource = dt;
            gvDataOil.DataBind();

        }

        protected void btnXem_Click(object sender, EventArgs e)
        {
            string a = dr_Loaidau.Text;
            string b = "";
            if (a != "")
            {
                b = "and Barcode_left_7bit = '" + a + "' "; 
            }
            loaddata(b);

        }
        private void exportExcel(DataTable dt, string type)
        {
            DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            DataTable newTable = new DataTable();
            newTable = dt.Clone(); // Sao chép cấu trúc
            foreach (DataRow row in dt.Rows)
            {
                newTable.ImportRow(row); // Thêm dữ liệu
            }
            ds.Tables.Add(newTable);


            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(ds);
                wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                wb.Style.Font.Bold = true;
                string fileName = "";
                if (type == "")
                {
                    fileName = "AllOil.xlsx";
                   
                }
                else
                {
                    fileName = "excel" + type + ".xlsx";
                }
               

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=" + fileName);

                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);

                    Response.Flush();
                    Response.End();
                }
            }
        }
       

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            if (dataexcel.excel.Rows.Count > 0) {
                exportExcel(dataexcel.excel, dr_Loaidau.Text.Trim());
            }
            else
            {
                string script = "alert(\"Không có dữ liệu!! Vui lòng kiểm tra lại\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            
        }
    }
}