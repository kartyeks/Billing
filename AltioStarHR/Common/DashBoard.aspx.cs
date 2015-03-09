using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IS91.Services.Web;
using CommonManager.BusinessObjects;
using AltioStarHR.App_Code;


namespace AltioStarHR.Common
{
    public partial class DashBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            ExtendedUserInfo objCurrUser = ((ExtendedUserInfo)HttpContext.Current.Session["userInfo"]);
            hdnEmployeeID.Value = objCurrUser.GroupName; //SessionManager.Session_EmpID;//
            GetApplicableMenuItems();
        }
        private void GetApplicableMenuItems()
        {
            string roleid = string.Empty;
            string rolename = string.Empty;
            string logintype = string.Empty;

            ExtendedUserInfo objCurrUser = ((ExtendedUserInfo)HttpContext.Current.Session["userInfo"]);

            //if (objCurrUser.UserId == 1)
                hdnLoginInfo.Value = objCurrUser.UserName;
            //else
            //    hdnLoginInfo.Value = objCurrUser.UserName; // +" ( " + SessionManager.Session_EmpName + " )";

            //if (objCurrUser == null) return;
           // hdnLoginInfo.Value = SessionManager.Session_EmpName;

            string LoginType = "EMP";// SessionManager.Session_LoginType;

            hdnLoggedEmpID.Value =   string.Concat(objCurrUser.GroupName); // Changed By Vivek // 
            hdnLoggedUserID.Value = string.Concat(objCurrUser.UserId);

           // if (objCurrUser.UserId == 1) return;
           // if (hdnLoggedUserID.Value.ToString() == "1") return;

            string strDetails = objCurrUser.GroupID.ToString(); //This will contain RoleID and RoleName
            String[] strSpit;
            strSpit = strDetails.Split('_');
            if (strSpit.Length != 0)
            {
                roleid = strSpit[0];
                rolename = strSpit[1];
                logintype = strSpit[2];
            }
            hdnRole.Value = rolename; //SessionManager.Session_Role;// 
            hdnRoleID.Value = roleid; //SessionManager.Session_RoleID;// 
            hdnLoginType.Value = logintype; //SessionManager.Session_LoginType;//

            

            string strFnIds = string.Empty;
            //if (LoginType == "EMP")
            //{
            //    int empID = 0;
            //    Int32.TryParse(objCurrUser.GroupID, out empID);
            //    hdnRole.Value = new Common_UserBusinessObject().GetRole(empID);
            //    //AssignEmpDesignation objDesg = new Master_EmployeesBusinessObject().GetDesignationEmployees(Int32.Parse(SessionManager.Session_EmpID));
            //    //if (objDesg != null)
            //    //{
            //    //    string strDesgId = objDesg.DesignationID.ToString();
            //    //    Hr_Designation objDesignation = new Hr_DesignationBusinessObject().GetHr_Designation(strDesgId);
            //    //    if (objDesignation != null)
            //    //    {
            //    //        string strRoleID = objDesignation.RoleID.ToString();
            //    //        hdnRoleID.Value = strRoleID;
            //    //        Role rl = new Role(objDesignation.RoleID);
            //    //        if (rl != null)
            //    //            hdnRole.Value = rl.RoleName;


            //    //    }
            //    //}
            //}
            //else
            //{
            //    hdnRole.Value = "Agency";// SettingConfiguration.AGENCY_ROLE;
            //   // hdnRoleID.Value = new SettingConfiguration(SettingConfiguration.AGENCY_ROLE).Value;//9 For Agency
            //}

        }

    }
}
