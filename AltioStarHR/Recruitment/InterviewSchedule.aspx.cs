﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AltioStarHR.Recruitment
{
    public partial class InterviewSchedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ExtendedUserInfo objCurrUser = ((ExtendedUserInfo)HttpContext.Current.Session["userInfo"]);
            hdnLoggedEmpID.Value = string.Concat(objCurrUser.GroupName);
            hdnLoggedUserID.Value = string.Concat(objCurrUser.UserId);

            string strDetails = objCurrUser.GroupID.ToString(); //This will contain RoleID and RoleName
            String[] strSpit;
            strSpit = strDetails.Split('_');
            if (strSpit.Length != 0)
            {
                hdnRoleName.Value = strSpit[1];
                hdnLoginType.Value = strSpit[2];
            }
        }
    }
}
