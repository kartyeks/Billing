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
using AltioStarHR.App_Code;


namespace AltioStarHR.Leave
{
    public partial class LeaveRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           Response.Cache.SetNoStore();
           ExtendedUserInfo objCurrUser = ((ExtendedUserInfo)HttpContext.Current.Session["userInfo"]);          
           hdnempid.Value = objCurrUser.GroupName;
           hdnTotalAnnualLeave.Value = ConfigurationSettings.AppSettings["TotalAnnualLeave"];               
        }
    }
}
