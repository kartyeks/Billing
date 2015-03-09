using System;
using System.Data;
using IS91.Services.DataBlock;
using System.Collections;
using HRManager.DTO;
using HRManager.Entity;
namespace HRManager.BusinessObjects
{
    public partial class Employee_PayrollBusinessObject
    {
        public Employee_PayrollBusinessObject(bool Nolock)
        {
            persistent = new PersistentObject(mapped);
            persistent.ExecuteWithNoLocks = Nolock;
        }
        public bool IsPayrollPosted(int month, int year, int empId)
        {
            int cnt = 0;
            const String Qry = "SELECT COUNT(*) FROM Employee_Payroll "
                             + " WHERE [Month]={0} AND [Year]={1} AND EmployeeID={2}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, month, year, empId);
            int.TryParse(string.Concat(EE.ExecuteScalar(exQry)), out cnt);
            return cnt > 0;
        }
        public bool IsAnnualPayrollPosted(int Financialyear, int empId)
        {
            int cnt = 0;
            const String Qry = " SELECT COUNT(*) FROM Employee_Payroll_Anualbenifits P " +
                               "  Inner Join dbo.Employee_Payroll E ON E.ID=P.PayrollID " +
                               " WHERE [FinancialYear]={0} AND EmployeeID={1}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, Financialyear, empId);
            int.TryParse(string.Concat(EE.ExecuteScalar(exQry)), out cnt);
            return cnt > 0;
        }

        public bool IsAnnualBenifitPosted(int Month, int Year)
        {
            int cnt = 0;
            const String Qry = " select ID from Employee_Payroll where "
                + " dbo.fnc_FiscalYear(convert(varchar,Year)+'-'+convert(varchar,Month)+'-01') = "
                + " dbo.fnc_FiscalYear(convert(varchar,{1})+'-'+convert(varchar,{0})+'-01')  "
                + " and IsAnualbenifitsincluded =1 ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, Month, Year);
            int.TryParse(string.Concat(EE.ExecuteScalar(exQry)), out cnt);
            return cnt > 0;
        }
        public DataTable GetEmployeeDetails(int empId, DateTime asOnDate)
        {
            const String Qry = "SELECT E.ID"
                             + " ,FirstName+' ' +MiddleName +' ' +LastName EmployeeName"
                             + " ,E.EmpCode"
                             + " ,DesignationID"
                             + " ,Designation"
                             + " ,EDP.DepartmentID"
                             + " ,DepartmentName Department"
                             + " ,BranchID"
                             + " ,BranchName Branch"
                             + " ,LocationID"
                             + " ,L.LocationName Location"
                             + " FROM Master_Employees E"
                             + " INNER JOIN Master_Candidate C ON C.ID=E.CandidateID"
                             + " INNER JOIN"
                             + " (SELECT TOP 1 EmpID,DesignationID,MAX(ActivatedDate)ActivatedDate FROM"
                             + " Assign_Emp_Designation WHERE ActivatedDate<='{0}'"
                             + " GROUP BY EmpID,DesignationID ORDER BY ActivatedDate DESC"
                             + " )ED ON  ED.EmpID=E.ID"
                             + " INNER JOIN Hr_Designation DM ON DM.ID=ED.DesignationID"
                             + " INNER JOIN"
                             + " (SELECT TOP 1 EmpID,DepartmentID,MAX(ActivatedDate)ActivatedDate FROM"
                             + " Assign_Emp_Department WHERE ActivatedDate<='{0}'"
                             + " GROUP BY EmpID,DepartmentID ORDER BY ActivatedDate DESC"
                             + " )EDP ON EDP.EmpID=E.ID"
                             + " INNER JOIN Hr_Department DP ON DP.ID=EDP.DepartmentID"
                             + " INNER JOIN"
                             + " (SELECT TOP 1 EmpID,BranchID,MAX(ActivatedDate)ActivatedDate FROM"
                             + " Assign_Emp_Branch  WHERE ActivatedDate<='{0}'"
                             + " GROUP BY EmpID,BranchID ORDER BY ActivatedDate DESC"
                             + " )EB ON EB.EmpID=E.ID"
                             + " INNER JOIN Master_Branch BR ON BR.ID=EB.BranchID"
                             + " INNER JOIN Master_Location L ON L.ID=BR.LocationID"
                             + " WHERE "
                             + " E.ID={1}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, asOnDate.ToString("yyyy-MM-dd"), empId);
            return EE.ExecuteDataTable(exQry);

        }


        public DataTable GetEmployees(int brId, int deptId, DateTime asOnDate)
        {
            const String Qry = "SELECT distinct E.ID"
                             + " ,FirstName+' ' +MiddleName +' ' +LastName EmployeeName"
                             + " ,E.EmpCode"
                             + " ,DesignationID"
                             + " ,Designation"
                             + " ,EDP.DepartmentID"
                             + " ,DepartmentName Department"
                             + " ,BranchID"
                             + " ,BranchName Branch"
                             + " ,LocationID"
                             + " ,L.LocationName Location"
                             + " FROM Master_Employees E"
                             + " INNER JOIN Master_Candidate C ON C.ID=E.CandidateID"
                             + " INNER JOIN Employee_Salary S ON S.EmpID=E.ID"
                             + " INNER JOIN Assign_Emp_Designation ED ON  ED.EmpID=E.ID "
                             + " INNER JOIN Hr_Designation DM ON DM.ID=ED.DesignationID"
                             + " INNER JOIN Assign_Emp_Department EDP ON EDP.EmpID=E.ID"
                             + " INNER JOIN Hr_Department DP ON DP.ID=EDP.DepartmentID"
                             + " INNER JOIN Assign_Emp_Branch  EB ON EB.EmpID=E.ID"
                             + " INNER JOIN Master_Branch BR ON BR.ID=EB.BranchID"
                             + " INNER JOIN Master_Location L ON L.ID=BR.LocationID"
                             + " WHERE ED.ActivatedDate =(SELECT MAX(ActivatedDate) FROM Assign_Emp_Designation WHERE ActivatedDate<='{0}' AND  EmpID=E.ID)"
                             + " AND EDP.ActivatedDate =(SELECT MAX(ActivatedDate) FROM Assign_Emp_Department WHERE ActivatedDate<='{0}' AND  EmpID=E.ID)"
                             + " AND EB.ActivatedDate =(SELECT MAX(ActivatedDate) FROM Assign_Emp_Branch WHERE ActivatedDate<='{0}' AND  EmpID=E.ID)"
                             + " AND E.DateOfJoining<'{0}'  "
                             + " AND S.Basic>0 AND "
                             + " ( BR.ID={1})"
                             + " AND "
                // + " ( DP.ID={2})";
                //+ " ({1}=0 OR BR.ID={1})"
                //+ " AND"
                              + " ({2}=0 OR DP.ID={2})";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, asOnDate.AddMonths(1).ToString("yyyy-MM-dd"), brId, deptId);
            return EE.ExecuteDataTable(exQry);

        }

        public DataTable GetEmployees(DateTime asOnDate)
        {
            const String Qry = " SELECT E.ID ,E.ID EmployeeId ,FirstName+' ' +MiddleName +' ' +LastName EmployeeName ,EmpCode EmployeeCode,0 PresentDays , "
                            + " isnull(dbo.GetAllowanceEmp(S.ID),0)+isnull(dbo.GetDeductionEmp(S.ID),0)  TotalEarnings ,isnull(dbo.GetDeductionEmp(S.ID),0) TotalDeductions , "
                            + " isnull(dbo.GetAllowanceEmp(S.ID),0) NetSalary ,0 IsPosted,Basic "
                            + " FROM Master_Employees E  "
                            + " INNER JOIN Employee_Salary S ON S.EmployeeID=E.ID  "
                            + " INNER JOIN Employee_OccupationDetails ED ON  ED.EmployeeID=E.ID  "
                            + " INNER JOIN Hr_Designation DM ON DM.ID=ED.DesignationID "
                            + " INNER JOIN Master_Location L ON L.ID=ED.LocationID  "
                            + " WHERE ED.IsActive=1 AND S.CTC>0 AND ED.JoiningDate<'{0}' AND S.IsActive = 1 ";
            //+ " AND (E.LeavingStatus IS NULL OR E.LeavingStatus='' OR (E.LeavingStatus<>'' AND E.LeavingDate>='{4}' ) ) ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            //exQry.Query = string.Format(Qry, asOnDate.AddMonths(1).ToString("yyyy-MM-dd"), locId, brId, deptId, asOnDate.ToString("yyyy-MM-dd"));
            exQry.Query = string.Format(Qry, asOnDate.AddMonths(1).ToString("yyyy-MM-dd"));
            return EE.ExecuteDataTable(exQry);

        }


        public EmployeePayroll[] GetPayrollForAllEmployeesList(DateTime asOnDate)
        {
            const String qry = " SELECT dbo.fnc_IsAnualbenifitsincluded(datepart(month,{1}),datepart(year,{1})) IsAnnual,S.ID,EP.ID,Round(isnull(Round(EP.Basic,0),Round(S.Basic/12,0)),0),isnull(dbo.GetAllowanceEmp(S.ID,isnull(EP.ID,0)),0),E.ID ,E.ID EmployeeId ,FirstName+' ' +MiddleName +' ' +LastName EmployeeName ,EmpCode EmployeeCode, "
    + " isnull(dbo.GetPresentDays(datepart(mm,'{1}'), "
    + "  datepart(yyyy,'{1}'),E.ID),0) PresentDays ,  "
    + "  Round((isnull(EP.Basic,S.Basic/12)+isnull(dbo.GetAllowanceEmp(S.ID,isnull(EP.ID,0)),0)),0)  TotalEarnings , "
    + "  isnull(dbo.GetDeductionEmp(S.ID,isnull(EP.ID,0)),0) TotalDeductions , "
    + "    Round((isnull(EP.Basic,S.Basic/12)+isnull(dbo.GetAllowanceEmp(S.ID,isnull(EP.ID,0)),0)-isnull(dbo.GetDeductionEmp(S.ID,isnull(EP.ID,0)),0)),0) NetSalary , "
    + "    isnull(EP.Basic,S.Basic/12) Basic,S.ID SalaryID   , "
    + "    'IsPosted' = case isnull(EP.ID,0) when 0 then 0 else 1 End,TeamName,isnull(IsAnualbenifitsincluded,'false') IsAnualbenifitsincluded"
    + "     FROM Master_Employees E   "
    + "     INNER JOIN Employee_Salary S ON S.EmployeeID=E.ID    "
    + "     INNER JOIN Employee_OccupationDetails ED ON  ED.EmployeeID=E.ID    "
    + "     Inner Join Master_Team MT ON ED.TeamID = MT.ID  "
    + "     INNER JOIN Hr_Designation DM ON DM.ID=ED.DesignationID  "
    + "     INNER JOIN Master_Location L ON L.ID=ED.LocationID   "
    + "     Left Join Employee_Payroll EP ON EP.EmployeeID = E.ID "
    + "      WHERE ED.IsActive=1 AND S.CTC>0 AND ED.JoiningDate<'{0}' AND S.IsActive = 1 "
    + "      and DATEPART(month,getdate())= DATEPART(month,'{1}') "
    + "     and DATEPART(year,getdate())= DATEPART(year,'{1}')  and TypeOfExitID =0"
    + "      Union "
    + "       SELECT dbo.fnc_IsAnualbenifitsincluded(datepart(month,{1}),datepart(year,{1})) IsAnnual,S.ID,EP.ID,Round(isnull(Round(EP.Basic,0),Round(S.Basic/12,0)),0),isnull(dbo.GetAllowanceEmp(S.ID,isnull(EP.ID,0)),0),E.ID ,E.ID EmployeeId ,FirstName+' ' +MiddleName +' ' +LastName EmployeeName ,EmpCode EmployeeCode, "
    + "  isnull(dbo.GetPresentDays(datepart(mm,'{1}'), "
    + "  datepart(yyyy,'{1}'),E.ID),0) PresentDays ,  "
    + "  Round((isnull(EP.Basic,S.Basic/12)+isnull(dbo.GetAllowanceEmp(S.ID,isnull(EP.ID,0)),0)),0)  TotalEarnings ,"
    + "  isnull(dbo.GetDeductionEmp(S.ID,isnull(EP.ID,0)),0) TotalDeductions , "
    + "    Round((isnull(EP.Basic,S.Basic/12)+isnull(dbo.GetAllowanceEmp(S.ID,isnull(EP.ID,0)),0)-isnull(dbo.GetDeductionEmp(S.ID,isnull(EP.ID,0)),0)),0) NetSalary ,"
    + "   isnull(EP.Basic,S.Basic/12) Basic,S.ID SalaryID   ,"
    + "    'IsPosted' = case isnull(EP.ID,0) when 0 then 0 else 1 End,TeamName,isnull(IsAnualbenifitsincluded,'false') IsAnualbenifitsincluded"
    + "     FROM Master_Employees E   "
    + "     INNER JOIN Employee_Salary S ON S.EmployeeID=E.ID    "
    + "     INNER JOIN Employee_OccupationDetails ED ON  ED.EmployeeID=E.ID    "
    + "     Inner Join Master_Team MT ON ED.TeamID = MT.ID  "
    + "     INNER JOIN Hr_Designation DM ON DM.ID=ED.DesignationID  "
    + "     INNER JOIN Master_Location L ON L.ID=ED.LocationID   "
    + "     Inner Join Employee_Payroll EP ON EP.EmployeeID = E.ID "
    + "      WHERE ED.IsActive=1 AND S.CTC>0 AND ED.JoiningDate<'{1}' AND S.IsActive = 1 "
    + "      and EP.ID is not null "
    + "      and EP.Month = DATEPART(month,'{1}') "
    + "      and EP.Year = DATEPART(year,'{1}') and TypeOfExitID =0 ";

            ExecutionEngine ee = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(qry, asOnDate.AddMonths(1).ToString("yyyy-MM-dd"), asOnDate.ToString("yyyy-MM-dd"));
            DataTable dt = ee.ExecuteDataTable(exQry);
            EmployeePayroll[] details = new EmployeePayroll[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                details[i] = new EmployeePayroll();
                details[i].ID = (int)dt.Rows[i]["ID"];
                details[i].EmployeeId = (int)dt.Rows[i]["EmployeeID"];
                details[i].EmployeeName = (string)dt.Rows[i]["EmployeeName"];
                details[i].EmployeeCode = (string)dt.Rows[i]["EmployeeCode"];
                details[i].PresentDays = Convert.ToDouble(dt.Rows[i]["PresentDays"]);
                details[i].TotalEarnings = Convert.ToDouble(dt.Rows[i]["TotalEarnings"]);
                details[i].TotalDeductions = Convert.ToDouble(dt.Rows[i]["TotalDeductions"]);
                details[i].NetSalary = Convert.ToDouble(dt.Rows[i]["NetSalary"]);
                details[i].IsPosted = Convert.ToBoolean(dt.Rows[i]["IsPosted"]);
                details[i].Basic = Convert.ToDouble(dt.Rows[i]["Basic"]);
                details[i].EmployeeSalaryID = (int)dt.Rows[i]["SalaryID"];
                details[i].Team = dt.Rows[i]["TeamName"].ToString();
                details[i].IsABenifitIncludedAll = Convert.ToInt32(dt.Rows[i]["IsAnnual"]) > 0;
                details[i].IsAnnualBenifitIncluded = Convert.ToBoolean(dt.Rows[i]["IsAnualbenifitsincluded"]); ;    
            }
            return details;

        }

        public void GetEmployeeDetails(int empId, int fYear, IncomeTax itax)
        {
            string Qry = "SELECT Sex,DOB,DateOfJoining FROM Master_Candidate C "
                       + " INNER JOIN Master_Employees E ON E.CandidateID=C.ID "
                       + " WHERE E.ID={0}";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, empId);
            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    itax.Gender = string.Concat(dr["Sex"]);
                    DateTime sdat = new DateTime(fYear, 4, 1);

                    DateTime edat = sdat.AddMonths(1);
                    DateTime dob = (DateTime)dr["DOB"];
                    DateTime doj = (DateTime)dr["DateOfJoining"];
                    itax.StartDate = doj;
                    //int yrs = new DateTime(edat.Subtract(dob).Ticks).Year - 1;
                    int age = edat.Year - dob.Year;
                    if (edat.Month < dob.Month || (edat.Month == dob.Month && edat.Day < dob.Day)) age--;
                    if (age >= 65)
                        itax.IsSeniorCitizen = true;

                }
            }
        }
        public int GetFinancialYear(int month, int year)
        {
            if (month > 3 && month < 13)
                return year;
            else if (month < 4)
                return year - 1;

            return year;
        }

        public DateTime GetCurrentDateForFinancialYear(int fyear)
        {
            string Qry = "SELECT MAX(CAST(cast(year as nvarchar(4))+'-'+cast(month as nvarchar(2))+'-'+'01' as datetime)) FROM Employee_Payroll "
                       + " WHERE (Case when [month]<4 then [year]-1 else [year] end)={0}";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, fyear);
            DateTime tmp = DateTime.Today;
            string res = string.Concat(EE.ExecuteScalar(exQry));
            if (res == string.Empty)
            {
                return new DateTime(fyear, 4, 1);
            }
            else
            {
                DateTime.TryParse(res, out tmp);

            }
            return tmp;
        }

        public double GetIncomeFromOtherSources(int empId, int fyear)
        {
            double dbl = 0;
            const String Qry = "SELECT SUM(Amount) Amount FROM Employee_IncomeFromOtherSource "
                             + " WHERE EmployeeID={0} AND FinancialYear={1} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, empId, fyear);
            double.TryParse(string.Concat(EE.ExecuteScalar(exQry)), out dbl);
            return dbl;
        }
        public double GetTotalExemptions(int empId, int fyear, string chapter6a)
        {
            double dbl = 0;
            const String Qry = "SELECT SUM(Value) Amount FROM ("
                             + " SELECT distinct ExemptionID,Value FROM Assign_Employee_Tax_Declaration E"
                             + " INNER JOIN Master_Tax_Exemptions T ON T.ID=E.ExemptionID"
                             + " INNER JOIN Master_Tax_Excemption_Groups G  ON G.ID=T.ExemptionGroupID"
                             + " WHERE IsProjections=0 AND EmpID={0} AND FinancialYear={1}"
                             + " AND G.TaxExcemptionName<>'{2}'"
                             + " UNION "
                             + " SELECT distinct ExemptionID,Value FROM Assign_Employee_Tax_Declaration E"
                             + " INNER JOIN Master_Tax_Exemptions T ON T.ID=E.ExemptionID"
                             + " INNER JOIN Master_Tax_Excemption_Groups G  ON G.ID=T.ExemptionGroupID"
                             + " WHERE IsProjections=1 AND EmpID={0} AND FinancialYear={1}"
                             + " AND ExemptionID NOT IN (SELECT ExemptionID FROM Assign_Employee_Tax_Declaration "
                             + " WHERE IsProjections=0 AND EmpID={0} AND FinancialYear={1})"
                             + " AND G.TaxExcemptionName<>'{2}'"
                             + " )EX";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, empId, fyear, chapter6a);
            double.TryParse(string.Concat(EE.ExecuteScalar(exQry)), out dbl);
            return dbl;
        }

        public double GetTotalExemptionsCH6A(int empId, int fyear, string chapter6a)
        {
            double dbl = 0;
            const String Qry = "SELECT SUM(Value) Amount FROM ("
                             + " SELECT distinct ExemptionID,Value FROM Assign_Employee_Tax_Declaration E"
                             + " INNER JOIN Master_Tax_Exemptions T ON T.ID=E.ExemptionID"
                             + " INNER JOIN Master_Tax_Excemption_Groups G  ON G.ID=T.ExemptionGroupID"
                             + " WHERE IsProjections=0 AND EmpID={0} AND FinancialYear={1}"
                             + " AND G.TaxExcemptionName='{2}'"
                             + " UNION "
                             + " SELECT distinct ExemptionID,Value FROM Assign_Employee_Tax_Declaration E"
                             + " INNER JOIN Master_Tax_Exemptions T ON T.ID=E.ExemptionID"
                             + " INNER JOIN Master_Tax_Excemption_Groups G  ON G.ID=T.ExemptionGroupID"
                             + " WHERE IsProjections=1 AND EmpID={0} AND FinancialYear={1}"
                             + " AND ExemptionID NOT IN (SELECT ExemptionID FROM Assign_Employee_Tax_Declaration "
                             + " WHERE IsProjections=0 AND EmpID={0} AND FinancialYear={1})"
                             + " AND G.TaxExcemptionName='{2}'"
                             + " )EX";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, empId, fyear, chapter6a);
            double.TryParse(string.Concat(EE.ExecuteScalar(exQry)), out dbl);
            return dbl;
        }

        public double GetTotalRentPaid(int empId, int fyear)
        {
            double dbl = 0;
            const String Qry = "SELECT TOP 1 RentPaid FROM Payroll_AnnualConfiguration "
                             + " WHERE EmployeeID={0} AND FinancialYear={1}  ORDER BY ActivatedDate DESC ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, empId, fyear);
            double.TryParse(string.Concat(EE.ExecuteScalar(exQry)), out dbl);
            return dbl;
        }

        public int GetNoOfChildren(int empId)
        {
            int noch = 0;
            const String Qry = "SELECT  COUNT(C.ID) FROM Master_Employees E"
                             + " INNER JOIN Candidate_FamilyDetails C ON C.CandidateID=E.CandidateID"
                             + " INNER JOIN Master_Relation R ON R.ID=C.RelationID"
                             + " WHERE RelationName IN ('Child1','Child2','Child3','Son','Daughter') AND E.ID={0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, empId);
            int.TryParse(string.Concat(EE.ExecuteScalar(exQry)), out noch);
            return noch;
        }

        public void GetTaxExemptedLimit(int fyear, IncomeTax itax)
        {
            const String Qry = "SELECT MaxLimitMale,MaxLimitFemale,MaxLimitSenior "
                             + " FROM Master_Tax_Excemption_Groups"
                             + " WHERE FinancialYear={0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, fyear);
            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    if (itax.IsSeniorCitizen)
                        itax.TaxExemptionLimit = (double)dr["MaxLimitSenior"];
                    else if (itax.Gender == "M")
                        itax.TaxExemptionLimit = (double)dr["MaxLimitMale"];
                    else
                        itax.TaxExemptionLimit = (double)dr["MaxLimitFeMale"];
                }
            }

        }

        public void GetTaxData(int fyear, string gender, IncomeTax itax)
        {
            const String Qry = "SELECT IsPercentage,Value,AddValue,S.MinAmount FROM Master_Tax_Slabs S "
                                + " INNER JOIN Master_Tax E ON E.ID=S.TaxID"
                                + " where E.TaxName='TDS' AND S.FinancialYear={0} "
                                + " AND {1}>MinAmount AND ({1}<MaxAmount OR MAxAmount=0) AND [Type]='{2}'";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, fyear, itax.TaxableAmount, gender);
            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    itax.TaxPercentage = (double)dr["Value"];
                    itax.AdditionalTaxAmount = (double)dr["AddValue"];
                    itax.TaxExemptionLimit = ((double)dr["MinAmount"]) - 1;
                }
            }

        }

        public void UpdateLoanDetails(int loanreqId, double amt, int usrId, Session ss)
        {

            const String Qry = "Update Assign_Emp_Loan SET RepaidAmount=RepaidAmount+{0},DueAmount= DueAmount-{0},ModifiedBy={2},ModifiedDate=getDate() WHERE LoanRequestID={1}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, amt, loanreqId, usrId);
            EE.ExecuteNonQuery(exQry, ss);
        }

        public void Delete(int Month, int Year)
        {

            const String Qry = "Delete From Employee_Payroll where Month={0} and Year ={1}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, Month, Year);
            EE.ExecuteNonQuery(exQry);
        }
        /// <summary>
        /// check gratuity Existance in the database for a particular employee.
        /// </summary>
        /// <param name="Asset">field contains employee ide</param>
        /// <param name="ID">field contains gratuity ID</param>
        /// <returns>True for Exist and false for not exist</returns>
        public bool IsGratuityExistsForEmployee(int employeeID, int ID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM GratuityCalculation WHERE EmployeeID = {0} AND ID<>{1})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, employeeID.ToString(), ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }
        public bool CheckPayrollForGivenDate(string month, string year, int EmpID)
        {
            const String Qry = " IF EXISTS (select ID from Employee_Payroll where Month ={0} and year ={1} and EmployeeID ={2})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, month, year, EmpID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }

        public void UpdatePayrollEarningAndDeductios(int EmployeeSalaryID, int PayrollID,bool IsABenifitIncluded, Session ss)
        {
            String Qry = string.Empty ;
            if (IsABenifitIncluded)
            {
                Qry = "INSERT INTO Employee_Payroll_Deductions (PayrollID, DeductionID, Amount, DeductionType) "
                            + " SELECT {1} PayrollID,DeductionID ,Value Amount,'' DeductionType  "
                            + " FROM Assign_Emp_Deduction where EmployeeSalaryID={0} ;"

                            + " INSERT INTO Employee_Payroll_Earnings (PayrollID, AllowanceID, Amount)"
                            + " SELECT {1} PayrollID,AllowanceID ,Value Amount "
                            + " FROM Assign_Emp_Allowance where EmployeeSalaryID={0}";
            }
            else
            {
                Qry = "INSERT INTO Employee_Payroll_Deductions (PayrollID, DeductionID, Amount, DeductionType) "
                            + " SELECT {1} PayrollID,DeductionID ,Value Amount,'' DeductionType  "
                            + " FROM Assign_Emp_Deduction where EmployeeSalaryID={0} ;"

                            + " INSERT INTO Employee_Payroll_Earnings (PayrollID, AllowanceID, Amount)"
                            + " SELECT {1} PayrollID,AllowanceID ,AEA.Value Amount "
                            + " FROM Assign_Emp_Allowance AEA "
                            + " Inner JOin Master_Salary_Allowance MSA ON MSA.ID  = AEA.AllowanceID "
                            + " where EmployeeSalaryID={0} and AllowancePeriod <> 'YRL'";
            }
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmployeeSalaryID, PayrollID);
            EE.ExecuteNonQuery(exQry, ss);
        }
    }
}
