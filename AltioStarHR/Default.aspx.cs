using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IS91.Services.Web;
using IRCAKernel;

//namespace AltioStarHR
//{
   public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            String xTraParam = String.Concat(Request.QueryString["serve"]);
            if (xTraParam.Contains("LoginHR,"))
            {
               xTraParam=xTraParam.Replace("LoginHR,", string.Empty);
            }
            if (!String.IsNullOrEmpty(xTraParam))
            {
                Server.Transfer(WebModule.GetVirtualPathForAspx(xTraParam), true);
            }

           
        }
    }
//}
