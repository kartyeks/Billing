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

namespace AltioStarHR.Masters
{
    public partial class Master_Maritial_Status : System.Web.UI.Page
    {
        public static readonly String ModuleName = "li_Setup_MaritalStatus";
        
        protected void Page_Load(object sender, EventArgs e)
        {

            Response.Cache.SetNoStore();
            ExtendedUserInfo objCurrUser = ((ExtendedUserInfo)HttpContext.Current.Session["userInfo"]);
            //hdnEmployeeID.Value = objCurrUser.GroupName;
            //hdnuserid.Value=SessionManager]
            hdnEmployeeID.Value = objCurrUser.GroupName;
        }
        }
}

