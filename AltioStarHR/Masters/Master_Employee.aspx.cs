using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRManager.Entity.EmployeesInfo;
using HRManager.BusinessObjects;
using HRManager.DTO;
using System.Data;

namespace AltioStarHR.Masters
{
    public partial class Master_Employee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            //Master_Salary_Allowance[] MSA = new Master_Salary_AllowanceBusinessObject().GetMaster_Salary_Allowance();
            //Master_Salary_Deductions[] MSD = new Master_Salary_DeductionsBusinessObject().GetAllEmployeeSalaryDeductions();
            //foreach (Master_Salary_Allowance obj in MSA)
            //{
            //    if (obj.AllowanceCode == "HRA")
            //    {
            //        hdnHRA.Value = obj.Value;
            //    }
            //}
            ExtendedUserInfo objCurrUser = ((ExtendedUserInfo)HttpContext.Current.Session["userInfo"]);
            hdnLoggedinID.Value = string.Concat(objCurrUser.GroupName);
            if (string.Concat(Request.QueryString["Type"]) == "self")
            {
                hdnEmployeeID.Value = string.Concat(objCurrUser.GroupName);
                hdnType.Value = "self";
            }
            else
            {
                hdnEmployeeID.Value = string.Concat(Request.QueryString["employeeid"]);
            }
            if (hdnEmployeeID.Value == string.Empty) hdnEmployeeID.Value = "0";
            if (hdnEmployeeID.Value != "0")
            {
                Master_Employees objEmp = new Master_EmployeesBusinessObject().GetMaster_Employees(hdnEmployeeID.Value);
                if (objEmp != null)
                {
                    if (objEmp.Photo.Length == 0)
                        hdnPhoto.Value = "false";
                    else
                        hdnPhoto.Value = "true";
                }
            }
            DataTable dtTable = new Setting_ConfigurationBusinessObject().GetDataTable();
            if (dtTable != null && dtTable.Rows.Count > 0)
            {
                for (int i = 0; i < dtTable.Rows.Count; i++)
                {
                    if (dtTable.Rows[i]["Name"].ToString() == "Annual Conveyance Allowance")
                        hdnCA.Value = dtTable.Rows[i]["Value"].ToString();
                    if (dtTable.Rows[i]["Name"].ToString() == "Medical Reimbursement")
                        hdnMedicalReimb.Value = dtTable.Rows[i]["Value"].ToString();
                    if (dtTable.Rows[i]["Name"].ToString() == "Leave Count")
                        hdnLeaveCount.Value = dtTable.Rows[i]["Value"].ToString();
                }

            }
            hdnEmpPersonalTab.Value = EmployeeInfoType.EMP_PERSONAL_INFO;
            hdnEmpOccupationalTab.Value = EmployeeInfoType.EMP_OCCUPATIONAL_INFO;
            hdnMasterAcademic.Value = EmployeeInfoType.EMP_EDUCATIONAL_INFO;
            hdnMasterEmpSalary.Value = EmployeeInfoType.EMP_SALARY_INFO;
            hdnMasterDocs.Value = EmployeeInfoType.EMP_DOCS_INFO;
            hdnCareerInfo.Value = EmployeeInfoType.EMP_CAREER_INFO;
        }
    }
}
