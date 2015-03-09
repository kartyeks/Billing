using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AltioStarHR.Recruitment
{
    public partial class CandidateInterviewForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnCandidateID.Value = Request.QueryString["CandidateID"];
            ExtendedUserInfo objCurrUser = ((ExtendedUserInfo)HttpContext.Current.Session["userInfo"]);
            hdnLoggedEmpID.Value = string.Concat(objCurrUser.GroupName);
            hdnLoggedUserID.Value = string.Concat(objCurrUser.UserId);
            hdnMode.Value = Request.QueryString["mode"];

            string strDetails = objCurrUser.GroupID.ToString(); //This will contain RoleID and RoleName
            String[] strSpit;
            strSpit = strDetails.Split('_');
            if (strSpit.Length != 0)
            {
                hdnRoleName.Value = strSpit[1];
            }
        }
    }
}
