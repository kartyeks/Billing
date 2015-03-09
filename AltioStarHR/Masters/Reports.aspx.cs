﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace AltioStarHR.Masters
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            hdnReportType.Value = string.Concat(Request.QueryString["rtype"]);
            hdnMode.Value = string.Concat(Request.QueryString["mode"]);
            hdnHeader.Value = string.Concat(Request.QueryString["cap"]);
        }
    }
}
