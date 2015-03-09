using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using AltioStarHR.App_Code;

namespace AltioStarHR.LoanManagement
{
    public partial class LoanManagement : System.Web.UI.Page
    {
        
        public static readonly String ModuleName = "li_Employee_Loan_LoanManagement";

        protected void Page_Load(object sender, EventArgs e)
        {
            
            hdnLoanReason.Value = ConfigurationSettings.AppSettings["Loan_Reason"];
            Response.Cache.SetNoStore();
            //ExtendedUserInfo objCurrUser = ((ExtendedUserInfo)HttpContext.Current.Session["userInfo"]);
            //hdnmodule.Value = ModuleName;
            //hdnEmployeeID.Value = objCurrUser.GroupID.ToString();// This is an EmployeeID // IS91.Services.Common.GetAppSetting("EmployeeID");
            //hdnEmployeeID.Value = SessionManager.Session_EmpID;

            ExtendedUserInfo objCurrUser = ((ExtendedUserInfo)HttpContext.Current.Session["userInfo"]);
            //hdnLoggedinID.Value = string.Concat(objCurrUser.GroupName);
            hdnEmployeeID.Value = string.Concat(objCurrUser.GroupName);
        }
    }
}
