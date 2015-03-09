using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRCAKernel;
using HRManager;
using HRManager.DTO;
using HRManager.BusinessObjects;
using System.Data;


namespace AltioStarHR.Payroll
{
    public partial class SalaryAllowances : System.Web.UI.Page
    {
        public static readonly String ModuleName = "li_Employee_Payroll_SalryAllowances";

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            ExtendedUserInfo objCurrUser = ((ExtendedUserInfo)HttpContext.Current.Session["userInfo"]);
            hdnmodule.Value = ModuleName;

            hdnEmployeeID.Value = objCurrUser.GroupName;
            DataTable dtObj = new Master_Salary_AllowanceBusinessObject().GetDataTable();
            if (dtObj != null)
            {
                int i = 1;
                if (dtObj.Rows.Count > 0)
                {
                    
                    foreach (DataRow dr in dtObj.Rows)
                    {
                        displayorder.Items.Add(i.ToString());
                        i++;
                    }
                    displayorder.Items.Add(i.ToString());
                }
            }
            else
            {
                displayorder.Items.Add("1");
            }
            


        }
    }
}
