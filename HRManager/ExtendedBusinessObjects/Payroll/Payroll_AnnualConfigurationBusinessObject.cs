using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;
using HRManager.Entity;

namespace HRManager.BusinessObjects
{
    public partial class Payroll_AnnualConfigurationBusinessObject
   {
        //public Payroll_AnnualConfiguration[] GetActiveAnnualConfig(int FYear, int EmpID)
        //{
        //    const String Qry = "SELECT * FROM Payroll_AnnualConfiguration WHERE EmployeeID={0} and FinancialYear={1}";

        //    ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
        //    ExecutionQuery exQry = new ExecutionQuery();
        //    exQry.Query = string.Format(Qry, EmpID, FYear);
        //    DataTable dt = EE.ExecuteDataTable(exQry);
        //    Payroll_AnnualConfiguration[] IncomeDetails = new Payroll_AnnualConfiguration[dt.Rows.Count];
        //    for (int i = 0; i < IncomeDetails.Length; i++)
        //    {
        //        IncomeDetails[i] = new Payroll_AnnualConfiguration();
        //        IncomeDetails[i].ID = (int)dt.Rows[i]["ID"];
        //        IncomeDetails[i].EmployeeID = (int)dt.Rows[i]["EmployeeID"];
        //        IncomeDetails[i].FinancialYear = (int)dt.Rows[i]["FinancialYear"];
        //        IncomeDetails[i].RentPaid = (double)dt.Rows[i]["RentPaid"];
        //        IncomeDetails[i].TDS = (double)dt.Rows[i]["TDS"];
        //        IncomeDetails[i].LeaveEncashDays = (double)dt.Rows[i]["LeaveEncashDays"];
        //    }

        //    return IncomeDetails;
        //}

        public PayrollAnnualCongiguration GetActiveAnnualConfigs(int FYear, int EmpID)
        {
            const String Qry = " Select * From  Payroll_AnnualConfiguration WHERE EmployeeID = '{0}'" +
                                " and ActivatedDate = (SELECT MAX(ActivatedDate) FROM Payroll_AnnualConfiguration  " +
                                " where EmployeeID ='{0}' and FinancialYear={1})";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmpID, FYear);
            DataTable dt = EE.ExecuteDataTable(exQry);

            PayrollAnnualCongiguration AnnualDetails = new PayrollAnnualCongiguration();
            if (dt.Rows.Count > 0)
            {
                AnnualDetails.ID = (int)dt.Rows[0]["ID"];
                AnnualDetails.EmployeeID = (int)dt.Rows[0]["EmployeeID"];
                AnnualDetails.FinancialYear = (int)dt.Rows[0]["FinancialYear"];
                AnnualDetails.RentPaid = (double)dt.Rows[0]["RentPaid"];
                AnnualDetails.TDS = (double)dt.Rows[0]["TDS"];
                AnnualDetails.LeaveEncashDays = (double)dt.Rows[0]["LeaveEncashDays"];
            }
            return AnnualDetails;
        }
        public bool CheckLeaveEncashStatus(int EmpID, int FYear, double LeaveEncashDays)
        {
            const String Qry = " IF EXISTS (select * from assign_emp_leave AEL "
                                + " Inner join Master_Leave_Employee_Type AEG on (AEL.EmpID=AEL.EmpID) "
                                + " Inner Join (  "
                                + " select EmpTypeid,sum(EncashementMinCount) EncashementMinCount from Master_Leave_Employee_Type  "
                                + " group by EmpTypeid  "
                                + " having sum(EncashementMinCount)>0  "
                                + " ) MLG on (MLG.EmpTypeid=AEG.EmpTypeid)  "
                                + " where AEL.Balanceleave<{2}  and MLG.EncashementMinCount<{2} and AEL.EmpID={0} "
                                + " )  "
                                + " SELECT 0 "
                                + " ELSE "
                                + " SELECT 1" ;

            //const String Qry = " IF EXISTS (select * from assign_emp_leave AEL " 
            //                    + " Inner join assign_emp_grade AEG on (AEL.EmpID=AEL.EmpID) " 
            //                    + " Inner Join (  " 
            //                    + " select Gradeid,sum(EncashementMinCount) EncashementMinCount from master_leave_grade  " 
            //                    + " group by Gradeid  " 
            //                    + " having sum(EncashementMinCount)>0  " 
            //                    + " ) MLG on (MLG.Gradeid=AEG.Gradeid) "
            //                    + " where AEL.Balanceleave<{2}  and MLG.EncashementMinCount<{2} and AEL.EmpID={0} "
            //                    + " and AEG.ActivatedDate = (SELECT MAX(ActivatedDate) FROM assign_emp_grade where empid=AEL.EmpID))"
            //                    + " SELECT 0"
            //                    + " ELSE"
            //                    + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmpID.ToString(), FYear.ToString(), LeaveEncashDays.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }
   }
}
