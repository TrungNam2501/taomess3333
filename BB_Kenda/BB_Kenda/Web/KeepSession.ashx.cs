using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB_Kenda.Web
{
    /// <summary>
    /// Summary description for KeepSession
    /// </summary>
    public class KeepSession : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
           
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}