using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.ReportBusinessObjects
{
    public partial class PayrollDetailsBusinessObject
    {
        public DataTable GetSalaryRegister(string Month, string Year)
        {
            const String Qry = " SELECT isnull(IsAnualBenifitsincluded,0) IsAnualBenifitsincluded,E.EmpCode,E.FirstName+ ' '+E.MiddleName+ ' '+E.Lastname EmpName,ESOP,MET.Name Type,Teamname Team,TM.FirstName+ ' '+TM.LastName Manager,"
                            + " CONVERT(VARCHAR(10), JoiningDate, 103) DOJ,CONVERT(VARCHAR(10), E.DOB, 103) DOB,DM.Designation, "
                            + " 'CTC' = case isnull(Round(EP.Basic,0),0) when 0 then Round(S.CTC,0) else (Round(EP.Basic*2.5,0)) end, "
                            + " 'Basic' = case isnull(Round(EP.Basic,0),0) when 0 then Round(S.Basic,0) else Round(EP.Basic*12,0) end, "
                            + " 'HRA' = case isnull(EP.ID,0) when 0 then Round(dbo.GetPayrollAllowanceEmpByType(S.ID,0,'HRA'),0) else Round(dbo.GetPayrollAllowanceEmpByType(0,EP.ID,'HRA'),0) end, "
                            + " 'SPL' = case isnull(EP.ID,0) when 0 then Round(dbo.GetPayrollAllowanceEmpByType(S.ID,0,'SPL'),0) else Round(dbo.GetPayrollAllowanceEmpByType(0,EP.ID,'SPL'),0) end, "
                            + " 'CON' = case isnull(EP.ID,0) when 0 then Round(dbo.GetPayrollAllowanceEmpByType(S.ID,0,'CON'),0) else Round(dbo.GetPayrollAllowanceEmpByType(0,EP.ID,'CON'),0) end, "
                            + " 'LTA' = case isnull(EP.ID,0) when 0 then Round(dbo.GetPayrollAllowanceEmpByType(S.ID,0,'LTA'),0)*12 else Round(dbo.GetPayrollAllowanceEmpByType(0,EP.ID,'LTA'),0)*12 end, "
                            + " 'MED' = case isnull(EP.ID,0) when 0 then Round(dbo.GetPayrollAllowanceEmpByType(S.ID,0,'MED'),0)*12 else Round(dbo.GetPayrollAllowanceEmpByType(0,EP.ID,'MED'),0)*12 end, "
                            + " 'PF' = case isnull(EP.ID,0) when 0 then Round(dbo.GetPayrollAllowanceEmpByType(S.ID,0,'PF'),0) else Round(dbo.GetPayrollAllowanceEmpByType(0,EP.ID,'PF'),0) end "
                            + "     FROM Master_Employees E    "
                            + "     INNER JOIN Employee_Salary S ON S.EmployeeID=E.ID    "
                            + "     INNER JOIN Employee_OccupationDetails ED ON  ED.EmployeeID=E.ID    "
                            + "     INNER JOIN Hr_Designation DM ON DM.ID=ED.DesignationID "
                            + "     INNER JOIN Master_EmployeeType MET ON MET.ID=E.EmployeeTypeID "
                            + "     INNER JOIN Master_Team MT ON MT.ID=ED.TeamID "
                            + "     INNER JOIN Master_Employees TM ON TM.ID=ED.TeamID "
                            + "     LEFT JOIN Employee_Payroll EP ON EP.EmployeeID = E.ID and EP.Year={1} and EP.Month= {0} "
                            + "     WHERE ED.IsActive=1 AND S.CTC>0 AND S.IsActive = 1";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, Month, Year);
            return EE.ExecuteDataTable(exQry);
        }
        
        public DataTable GetEmployeeDetailsForPayroll(string EmpId, int Month, int Year)
        {
            const String Qry = " SELECT isnull(IsAnualBenifitsincluded,0) IsAnualBenifitsincluded,EmpCode,E.FirstName+ ' '+E.MiddleName+ ' '+E.Lastname EmpName,ESOP,"
                            + " CONVERT(VARCHAR(10), JoiningDate, 103) DOJ,CONVERT(VARCHAR(10), DOB, 103) DOB,Designation, "
                            + " 'CTC' = case isnull(Round(EP.Basic,0),0) when 0 then S.CTC else (Round(EP.Basic*2.5,0)) end, "
                            + " 'Basic' = case isnull(Round(EP.Basic,0),0) when 0 then Round(S.Basic,0) else Round(EP.Basic*12,0) end, "
                            + " 'HRA' = case isnull(EP.ID,0) when 0 then Round(dbo.GetPayrollAllowanceEmpByType(S.ID,0,'HRA'),0) else Round(dbo.GetPayrollAllowanceEmpByType(0,EP.ID,'HRA'),0) end, "
                            + " 'SPL' = case isnull(EP.ID,0) when 0 then Round(dbo.GetPayrollAllowanceEmpByType(S.ID,0,'SPL'),0) else Round(dbo.GetPayrollAllowanceEmpByType(0,EP.ID,'SPL'),0) end, "
                            + " 'CON' = case isnull(EP.ID,0) when 0 then Round(dbo.GetPayrollAllowanceEmpByType(S.ID,0,'CON'),0) else Round(dbo.GetPayrollAllowanceEmpByType(0,EP.ID,'CON'),0) end, "
                            + " 'LTA' = case isnull(EP.ID,0) when 0 then Round(dbo.GetPayrollAllowanceEmpByType(S.ID,0,'LTA'),0)*12 else Round(dbo.GetPayrollAllowanceEmpByType(0,EP.ID,'LTA'),0)*12 end, "
                            + " 'MED' = case isnull(EP.ID,0) when 0 then Round(dbo.GetPayrollAllowanceEmpByType(S.ID,0,'MED'),0)*12 else Round(dbo.GetPayrollAllowanceEmpByType(0,EP.ID,'MED'),0)*12 end, "
                            + " 'PF' = case isnull(EP.ID,0) when 0 then Round(dbo.GetPayrollAllowanceEmpByType(S.ID,0,'PF'),0) else Round(dbo.GetPayrollAllowanceEmpByType(0,EP.ID,'PF'),0) end "
                            + "     FROM Master_Employees E    "
                            + "     INNER JOIN Employee_Salary S ON S.EmployeeID=E.ID    "
                            + "     INNER JOIN Employee_OccupationDetails ED ON  ED.EmployeeID=E.ID    "
                            + "     INNER JOIN Hr_Designation DM ON DM.ID=ED.DesignationID "
                            + "     Left Join Employee_Payroll EP ON EP.EmployeeID = E.ID and EP.Year={3} and EP.Month= {2} "
                            + "     WHERE ED.IsActive=1 AND S.CTC>0 AND S.IsActive = 1 and E.ID ={0}";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = string.Format(Qry, EmpId, (new DateTime(Year, Month, 1)).AddMonths(1).ToString("yyyy-MM-dd"), Month, Year, (new DateTime(Year, Month, 1)).AddMonths(1).ToString("yyyy-MM-dd"));
            return EE.ExecuteDataTable(exQry);
        }
    }
}
