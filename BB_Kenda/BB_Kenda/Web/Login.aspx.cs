using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BB_Kenda.CnnSQL;

namespace BB_Kenda.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetIP.Text = "IP: "+ HttpContext.Current.Request.UserHostAddress;
        }

        private bool ftpLogin(string id, string pw)
        {
            FtpWebRequest fwr = (FtpWebRequest)WebRequest.Create("ftp://192.1.1.1/");
            fwr.Method = WebRequestMethods.Ftp.ListDirectory;
            fwr.Credentials = new NetworkCredential(id, pw);

            try { FtpWebResponse fwre = (FtpWebResponse)fwr.GetResponse(); return true; }
            catch { return false; }
        }

        private bool login(string empno, string pw)
        {
            string sqlkt = "select empno from [erp].[dbo].[peremp] where empno='" + empno + "' and bithdat='" + pw + "'";
            //DataTable lg = cnn.ExecuteQuery34(sqlkt);
            //if (lg.Rows.Count == 0)
            //{
            //    return false;
            //}
            return true;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text;
            string pass = txtPassword.Text;

            if (login(user, pass) == true || ftpLogin(user, pass) == true)
            {
                Session["username"] = user.Trim();
                Session["IpUser"] = GetIP.Text.Trim();
                Response.Redirect("/Web/home.aspx");
            }
            else
            {
                lblthongbao.Text = "Tài khoản hoặc mật khẩu không đúng!";
            }
        }
    }
}