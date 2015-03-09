using System;
using System.Data;
using IS91.Services.DataBlock;
using System.Collections;
using HRManager.DTO;
using HRManager.Entity;
namespace HRManager.BusinessObjects
{
    public partial class Employee_Payroll_EarningsBusinessObject
    {
        public Employee_Payroll_EarningsBusinessObject(bool noLock)
        {
            persistent = new PersistentObject(mapped);
            persistent.ExecuteWithNoLocks = noLock;
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

        public void GetEmployeePayroll(int month, int year, int empId, PayrollEarnings allow)
        {
            const String Qry = "SELECT P.ID, EmployeeID,[Month],[Year],PresentDays,LOP,P.[Basic],P.Special,P.Others,BasicArrears,OtherArrears,S.Basic ActualBasic,Round(S.Special,2) ActualSpecial,P.GrossSalary,EmploymentType  FROM Employee_Payroll P "
                             + " INNER JOIN Employee_Salary S ON S.EmpID=P.EmployeeID "
                             + " INNER JOIN Master_Employees E ON E.ID=P.EmployeeID "
                             + " WHERE [Month]={0} AND [Year]={1} AND EmployeeID={2} "
                             + " AND ActivatedDate=(SELECT MAX(ActivatedDate) FROM Employee_Salary WHERE EMPID=S.EMPID AND ActivatedDate< dateadd(m,1, cast(rtrim(P.Year*10000+ P.Month *100+ 1) as datetime)) )";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, month, year, empId);
            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    if (allow == null)
                        allow = new PayrollEarnings();
                    allow.PayrollID = (int)dr["ID"];
                    allow.EmployeeId = (int)dr["EmployeeId"];
                    allow.EmploymentTypeId = (int)dr["EmploymentType"];
                    allow.Month = (int)dr["Month"];
                    allow.Year = (int)dr["Year"];
                    allow.Basic = (double)dr["Basic"];
                    allow.SpecialAllowance = (double)dr["Special"];
                    allow.ActualBasic = (double)dr["ActualBasic"];
                    allow.ActualSpecialAllowance = (double)dr["ActualSpecial"];
                    allow.OtherAllowance = (double)dr["Others"];
                    allow.BasicArrears = (double)dr["BasicArrears"];
                    allow.OtherArrears = (double)dr["OtherArrears"];
                    allow.PresentDays = (double)dr["PresentDays"];
                    allow.LOPDays = (double)dr["LOP"];
                    allow.IsPosted = true;
                    allow.GrossSalary = (double)dr["GrossSalary"];
                }
            }
        }

        public void GetEmployeePayrollEarnings(int payrollId, PayrollEarnings earng)
        {
            const String Qry = "SELECT E.ID,PayrollID,E.AllowanceID,AllowanceName,AllowanceCode,E.Amount,S.Amount ActualAmount,Narration,A.IsTaxExempted FROM Employee_Payroll_Earnings E "
                             + " INNER JOIN Employee_Payroll P ON P.ID=E.PayrollID "
                             + " INNER JOIN Master_Salary_Allowance A ON A.ID=E.AllowanceID "
                             + " Left Outer JOIN Assign_emp_Allowance S ON S.AllowanceID=E.AllowanceID AND S.EmpID=P.EmployeeID "
                             + " left outer JOIN Assign_Emp_OneTimeAllowance A1 ON A1.AllowanceID=E.AllowanceID AND A1.EmpID=P.EmployeeID AND A1.Month=P.Month AND A1.Year=P.Year "
                             + " WHERE PayrollID={0} order by DisplayOrder asc";


            //+ " INNER JOIN Assign_emp_Allowance S ON S.AllowanceID=E.AllowanceID AND S.EmpID=P.EmployeeID "

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, payrollId);
            DataTable dt = EE.ExecuteDataTable(exQry);
            double totamt = 0;
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (earng == null)
                        earng = new PayrollEarnings();
                    earng.Allowances = new Allowance[dt.Rows.Count];
                    Allowance allow = null;
                    int k = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        allow = new Allowance();
                        allow.ID = (int)dr["ID"];
                        allow.AllowanceID = (int)dr["AllowanceID"];
                        allow.Name = string.Concat(dr["AllowanceName"]);
                        allow.Code = string.Concat(dr["AllowanceCode"]); 
                        allow.Amount = (double)dr["Amount"];
                        if(dr["ActualAmount"].ToString()==string.Empty)
                            allow.ActualAmount = (double)dr["Amount"];
                        else
                        allow.ActualAmount = (double)dr["ActualAmount"];
                        allow.IsPercentage = false;
                        allow.Percentage = 0;
                        allow.IsTaxExempted =  (bool)dr["IsTaxExempted"];
                        allow.AllowanceType = "";
                        allow.Mode = ""; ;
                        allow.IsOneMonthBasic = false; ;
                        allow.Basic = 0;
                        allow.Narration = string.Concat(dr["Narration"]);
                        totamt += allow.Amount;
                        earng.Allowances[k] = allow;
                        k++;
                    }
                    earng.TotalEarnings = totamt;
                }
            }
        }

        public DataTable GetPayrollEarnings(string payrollId)
        {
            const String Qry = "EXEC USP_GetPayrollEarningsActual {0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, payrollId);
            return EE.ExecuteDataTable(exQry);
        }

        public DataTable GetPayrollEarnings(string forDate, string empId)
        {
            const String Qry = "EXEC USP_GetPayrollEarnings  {0},'{1}'";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, empId, forDate);
            return EE.ExecuteDataTable(exQry);
        }


        public void GetEmployeeAllowance(int ID, DateTime datAllow, int empId, string mode, Allowance allow)
        {
            const String Qry = "SELECT A.ID,AllowanceName,IsPercentage,G.Value, A.IsTaxExempted,A.AllowanceCode,G.IsOneMonthSalary  FROM Master_Salary_Allowance A "
                             + " INNER JOIN Assign_Grade_Allowances G ON G.AllowanceID=A.ID "
                             + " INNER JOIN Assign_Emp_Grade E ON E.GradeID=G.GradeID "
                             + " WHERE A.ID={0} AND E.ActivatedDate=( "
                             + " Select Max(ActivatedDate) From Assign_Emp_Grade Where EmpID=E.EmpID "
                             + " And ActivatedDate<=DateAdd(m,1,'{1}')) AND G.ActivatedDate=( "
                             + " Select Max(ActivatedDate) From Assign_Grade_Allowances Where GradeID=G.GradeID AND AllowanceID=A.ID "
                             + " And ActivatedDate<=DateAdd(m,1,'{1}')) AND EmpID={2} AND AllowancePeriod='{3}'";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, ID, datAllow.ToString("yyyy-MM-dd"), empId, mode);
            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    if (allow == null)
                        allow = new Allowance();
                    allow.AllowanceID = (int)dr["ID"];
                    allow.Name = string.Concat(dr["AllowanceName"]);
                    allow.IsPercentage = (bool)dr["IsPercentage"];
                    if (allow.IsPercentage)
                        allow.Percentage = (double)dr["Value"];
                    else
                        allow.Amount = (double)dr["Value"];
                    allow.IsTaxExempted = (bool)dr["IsTaxExempted"];
                    allow.Code = string.Concat(dr["AllowanceCode"]);
                    allow.IsOneMonthBasic = (bool)dr["IsOneMonthSalary"];
                }
            }
        }

        public void CalculateEmployeeEarnings(int month, int year, int empId, string mode, PayrollEarnings pay)
        {
            //DateTime datAllow = new DateTime(year, month, 1);

            //const String Qry = "SELECT ER.*,EmploymentType,DateOfJoining,LeavingDate,DateOfRetairment FROM ("
            //                 + "SELECT E.EmpID, E.[Basic], E.Special,S.Amount,A.ID,AllowanceName,IsPercentage, A.IsTaxExempted,A.AllowanceCode,0 OTA,'' Narration,ISNULL(DisplayOrder,0) DisplayOrder,AllowancePeriod FROM Employee_Salary E "
            //                 + " LEFT JOIN Assign_emp_Allowance S ON S.EmpID=E.EmpID and  S.AllowanceID  not in "
            //                 + " ( SELECT AllowanceID FROM Assign_Emp_OneTimeAllowance G where G.EmpID=S.EmpID and G.Month={3} and G.year={4}) "
            //                 + " AND S.ActivatedDate=( Select Max(ActivatedDate) From Assign_emp_Allowance  "
            //                 + " Where EmpID=S.EmpID and AllowanceID=S.AllowanceID  And ActivatedDate<=DateAdd(m,1,'{0}')) "
            //                 + " LEFT JOIN Master_Salary_Allowance A ON A.ID=S.AllowanceID  "
            //                 + " AND AllowancePeriod='{2}' AND A.IsActive=1  AND IsAllowance=1 " 
            //                 + " WHERE E.ActivatedDate=( Select Max(ActivatedDate) From Employee_Salary "
            //                 + " Where EmpID=E.EmpID AND ActivatedDate<=DateAdd(m,1,'{0}')) "
            //                 + " AND E.EmpID={1} "
            //                 + " Union "
            //                 + " Select E.EmpID,E.[Basic], E.Special,S.Amount,A.ID,AllowanceName,IsPercentage, A.IsTaxExempted,A.AllowanceCode,1 OTA,S.Narration,ISNULL(DisplayOrder,0) DisplayOrder,AllowancePeriod "
            //                 + " FROM Employee_Salary E "
            //                 + " LEFT JOIN Assign_Emp_OneTimeAllowance S ON S.EmpID=E.EmpID "
            //                 + " LEFT JOIN Master_Salary_Allowance A ON A.ID=S.AllowanceID "
            //                 + "  AND A.IsActive=1 AND IsAllowance=1"
            //                 + " WHERE S.Month={3} and year={4} "
            //                 + " AND E.ActivatedDate=( Select Max(ActivatedDate) From Employee_Salary  Where EmpID=E.EmpID "
            //                 + " AND ActivatedDate<=DateAdd(m,1,'{0}'))  AND E.EmpID={1} "
            //                 + " UNION"
            //                 + " Select E.EmpID,E.[Basic], E.Special,0 Amount,A.ID,AllowanceName,IsPercentage, A.IsTaxExempted,A.AllowanceCode,1 OTA,'' Narration,ISNULL(DisplayOrder,0) DisplayOrder,AllowancePeriod "
            //                 + " FROM Employee_Salary E "
            //                 + " LEFT JOIN Master_Salary_Allowance A ON A.ID<>0 "
            //                 + " WHERE A.AllowanceCode IN ('BAR','OAR') AND EmpID={1}"
            //                 + " AND A.ID NOT IN (SELECT AllowanceID FROM Assign_Emp_OneTimeAllowance "
            //                 + " WHERE EmpID=E.EmpID AND AllowanceID=A.ID AND MONTH={3} AND YEAR={4}) "
            //                 + ")ER "
            //                 + " INNER JOIN Master_Employees ME ON ME.ID=ER.EmpID "
            //                 + " ORDER BY DisplayOrder asc";
            //ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            //ExecutionQuery exQry = new ExecutionQuery();

            ////string qry1 = "SELECT COUNT(*) FROM Assign_emp_Allowance WHERE EmpID={0} ";
            ////exQry.Query = string.Format(qry1,empId);
            ////int cnt = 0;
            ////int.TryParse(string.Concat(EE.ExecuteScalar(exQry)), out cnt);
            

            //exQry.Query = string.Format(Qry, datAllow.ToString("yyyy-MM-dd"), empId, mode, month, year);
            ////  exQry.Query = string.Format(Qry, datAllow.ToString("yyyy-MM-dd"), empId, mode);
            //DataTable dt = EE.ExecuteDataTable(exQry);
            //if (dt != null)
            //{
            //    if (dt.Rows.Count > 0)
            //    {
            //        DataRow[] drs = dt.Select("ID IS NOT NULL");
            //        pay.Allowances = new Allowance[drs.Length];
            //        int k = 0;
            //        DataRow dre = dt.Rows[0];
            //        pay.Basic = (double)dre["Basic"];
            //        pay.ActualBasic = (double)dre["Basic"];
            //        pay.SpecialAllowance = (double)dre["Special"];
            //        pay.ActualSpecialAllowance = (double)dre["Special"];
            //        pay.EmploymentTypeId = (int)dre["EmploymentType"];
            //        pay.DateOfJoining = (DateTime)dre["DateOfJoining"];
            //        DateTime retDate = (DateTime)dre["DateOfRetairment"];
            //        if (retDate.Month == month && retDate.Year == year)
            //        {
            //            pay.LeavingDate = retDate;
            //        }
            //        else
            //        {
            //            pay.LeavingDate = (DateTime)dre["LeavingDate"];
            //        }
                    
            //        pay.IsPosted = false;
            //        foreach (DataRow dr in dt.Rows)
            //        {
            //            if (string.Concat(dr["ID"]) != "")
            //            {
            //                pay.Allowances[k] = new Allowance();

            //                pay.Allowances[k].AllowanceID = (int)dr["ID"];
            //                pay.Allowances[k].Name = string.Concat(dr["AllowanceName"]);
            //                pay.Allowances[k].IsPercentage = (bool)dr["IsPercentage"];
            //                pay.Allowances[k].Amount = (double)dr["Amount"];
            //                pay.Allowances[k].ActualAmount = (string.Concat(dr["OTA"]) == "1" ? 0 : (double)dr["Amount"]); 
            //                pay.Allowances[k].IsTaxExempted = (bool)dr["IsTaxExempted"];
            //                pay.Allowances[k].IsOneTimeAllowance = (string.Concat(dr["OTA"]) == "1" ? true : false);
            //                pay.Allowances[k].Code = string.Concat(dr["AllowanceCode"]);
            //                pay.Allowances[k].Narration = string.Concat(dr["Narration"]);
            //                pay.Allowances[k].AllowanceType= string.Concat(dr["AllowancePeriod"]);
            //                k++;
            //            }
            //        }
            //    }
            //}
        }

        public void CalculateEmployeeAnualBenifits(DateTime datAllow, int empId, AnualBenifits Apay)
        {
            const String Qry = "SELECT  S.[Basic], S.Special,S.Others, A.ID,Name,Limit,IsPercentage,'false' IsTaxExempted,AnnualCode AllowanceCode,'false' IsOneMonthSalary,1 OTA  FROM Master_Annual_Additions A "
                             + " LEFT JOIN Employee_Salary S ON S.EmpID>0 WHERE EmpID={1} AND IsActive=1"
                             + " UNION ALL "
                             + " SELECT S.[Basic], S.Special,S.Others, A.ID,AllowanceName,G.Value,IsPercentage, A.IsTaxExempted,A.AllowanceCode,G.IsOneMonthSalary,1 OTA  FROM Master_Salary_Allowance A"
                             + " INNER JOIN Assign_Grade_Allowances G ON G.AllowanceID=A.ID "
                             + " INNER JOIN Assign_Emp_Grade E ON E.GradeID=G.GradeID "
                             + " INNER JOIN Employee_Salary S ON S.EmpID=E.EmpID "
                             + " WHERE E.ActivatedDate=( "
                             + " Select Max(ActivatedDate) From Assign_Emp_Grade Where EmpID=E.EmpID "
                             + " And ActivatedDate<=DateAdd(m,1,'{0}'))  AND G.ActivatedDate=( "
                             + " Select Max(ActivatedDate) From Assign_Grade_Allowances Where GradeID=G.GradeID AND AllowanceID=A.ID"
                             + " And ActivatedDate<=DateAdd(m,1,'{0}'))  AND E.EmpID={1} AND AllowancePeriod='YRL' AND A.IsActive=1 AND G.IsActive=1   ";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, datAllow.ToString("yyyy-MM-dd"), empId);
            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    Apay.Allowances = new Allowance[dt.Rows.Count];
                    int k = 0;
                    DataRow dre = dt.Rows[0];
                    foreach (DataRow dr in dt.Rows)
                    {
                        Apay.Allowances[k] = new Allowance();
                        Apay.Allowances[k].AllowanceID = (int)dr["ID"];
                        Apay.Allowances[k].Name = string.Concat(dr["Name"]);
                        Apay.Allowances[k].IsPercentage = (bool)dr["IsPercentage"];
                        Apay.Allowances[k].IsOneMonthBasic = (bool)dr["IsOneMonthSalary"];
                        if (Apay.Allowances[k].IsPercentage)
                        {
                            Apay.Allowances[k].Percentage = (double)dr["Limit"];
                            Apay.Allowances[k].Amount = (double)dr["Basic"] * Apay.Allowances[k].Percentage / 100;
                        }
                        else if (Apay.Allowances[k].IsOneMonthBasic)
                        {
                            Apay.Allowances[k].Amount = (double)dr["Basic"];
                        }
                        else
                            Apay.Allowances[k].Amount = (double)dr["Limit"];

                        Apay.Allowances[k].IsTaxExempted = (bool)dr["IsTaxExempted"];
                        Apay.Allowances[k].IsOneTimeAllowance = (string.Concat(dr["OTA"]) == "1" ? true : false);
                        Apay.Allowances[k].Code = string.Concat(dr["AllowanceCode"]);

                        k++;
                    }
                }
            }
        }

        public AnualBenifits GetAnualBenifits(int Fyear, int employeeID)
        {
            const String Qry = " SELECT  *  FROM ("
                             + " SELECT EmployeeID EmpID, E.[Basic], E.Special,E.Others, A.ID,Name,Limit,Amount,IsPercentage,'false' IsTaxExempted,AnnualCode AllowanceCode,'false' IsOneMonthSalary,1 OTA,AllowanceType   FROM Master_Annual_Additions A "
                             + " INNER JOIN Employee_Payroll_Anualbenifits P ON P.AllowanceID=A.ID"
                             + " INNER JOIN Employee_Payroll E ON E.ID=P.PayrollID "
                             + " Where FinancialYear={0} AND EmployeeID={1} AND AllowanceType='A'"
                             + " UNION ALL"
                             + " SELECT EmployeeID, E.[Basic], E.Special,E.Others, A.ID,AllowanceName,G.Value,Amount,IsPercentage, A.IsTaxExempted,A.AllowanceCode,G.IsOneMonthSalary,1 OTA,AllowanceType  FROM Master_Salary_Allowance A "
                             + " INNER JOIN Employee_Payroll_Anualbenifits P ON P.AllowanceID=A.ID"
                             + " INNER JOIN Employee_Payroll E ON E.ID=P.PayrollID "
                             + " INNER JOIN Assign_Grade_Allowances G ON G.AllowanceID=A.ID "
                             + " INNER JOIN Assign_Emp_Grade EG ON EG.GradeID=G.GradeID "
                             + " WHERE FinancialYear={0} AND EmployeeID={1} AND AllowanceType<>'A' )AP"
                             + " WHERE ID NOT IN (SELECT AllowanceID FROM Assign_Emp_OneTimeAllowance WHERE EmpID=AP.EmpID "
                             + " AND CAST( CAST([Year] AS NVARCHAR(4)) + '-' + (CASE WHEN [Month]<9 THEN '0' ELSE '' END) + CAST([Month] AS NVARCHAR(2)) + '-' +'01'  AS DATETIME)>'{0}-03-31' "
                             + " AND CAST( CAST([Year] AS NVARCHAR(4)) + '-' + (CASE WHEN [Month]<9 THEN '0' ELSE '' END) + CAST([Month] AS NVARCHAR(2)) +  '-' + '01'  AS DATETIME)<'{2}-04-01' )"
                             + "  UNION ALL"
                             + " SELECT G.EmpID,S.[Basic], S.Special,S.Others, A.ID,AllowanceName,G.Amount,G.Amount,IsPercentage, A.IsTaxExempted,A.AllowanceCode,'false',1 OTA,'S' AllowanceType  FROM Master_Salary_Allowance A"
                             + " INNER JOIN Assign_Emp_OneTimeAllowance G ON G.AllowanceID=A.ID "
                             + " INNER JOIN Employee_Salary S ON S.EmpID=G.EmpID "
                             + " WHERE G.EmpID={1} AND AllowancePeriod='YRL' AND A.IsActive=1"
                             + " AND CAST( CAST([Year] AS NVARCHAR(4)) + '-' + (CASE WHEN [Month]<9 THEN '0' ELSE '' END) + CAST([Month] AS NVARCHAR(2)) + '-' +'01'  AS DATETIME)>'{0}-03-31' "
                             + " AND CAST( CAST([Year] AS NVARCHAR(4)) + '-' + (CASE WHEN [Month]<9 THEN '0' ELSE '' END) + CAST([Month] AS NVARCHAR(2)) +  '-' + '01'  AS DATETIME)<'{2}-04-01' ";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, Fyear, employeeID, Fyear+1);

            DataTable dt = EE.ExecuteDataTable(exQry);
            AnualBenifits arrAnualBenifits = new AnualBenifits();
            double tot = 0;
            if (dt.Rows.Count > 0)
            {

                int k = 0;
                arrAnualBenifits.Allowances = new Allowance[dt.Rows.Count];
                foreach (DataRow dr in dt.Rows)
                {
                    Allowance al = new Allowance();
                    al.AllowanceID = (int)dr["ID"];
                    al.AllowanceType = string.Concat(dr["AllowanceType"]);  
                    al.Code = string.Concat(dr["AllowanceCode"]);
                    al.Name = string.Concat(dr["Name"]);
                    al.Basic = (double)dr["Basic"];
                    al.IsTaxExempted = (bool)dr["IsTaxExempted"];
                    al.IsOneMonthBasic = (bool)dr["IsOneMonthSalary"];
                    al.IsOneTimeAllowance = (string.Concat(dr["OTA"]) == "1" ? true : false);
                    al.IsPercentage = (bool)dr["IsPercentage"];
                    al.Amount = (double)dr["Limit"];
                    al.Amount = (double)dr["Amount"];
                    tot += al.Amount;
                    arrAnualBenifits.Allowances[k] = al;
                    k++;
                }
            }
            arrAnualBenifits.TotalAmount = tot;

            return arrAnualBenifits;
        }

        public AnualBenifits GetAnualBenifits(PayrollEarnings PayEarnings, int FYear, DateTime datAllow, int empId)
        {
            const String Qry = " SELECT  * FROM ("
                             + " SELECT  S.EmpID,S.[Basic], S.Special,S.Others, A.ID,Name,Limit,IsPercentage,'false' IsTaxExempted,AnnualCode AllowanceCode,'false' IsOneMonthSalary,1 OTA,'A' AllowanceType  FROM Master_Annual_Additions A "
                             + " LEFT JOIN Employee_Salary S ON S.EmpID>0 WHERE EmpID={1} AND A.IsActive=1"
                             + " UNION ALL "
                             + " SELECT  S.EmpID,S.[Basic], S.Special,S.Others, A.ID,AllowanceName,G.Value,IsPercentage, A.IsTaxExempted,A.AllowanceCode,G.IsOneMonthSalary,1 OTA,'S' AllowanceType  FROM Master_Salary_Allowance A"
                             + " INNER JOIN Assign_Grade_Allowances G ON G.AllowanceID=A.ID "
                             + " INNER JOIN Assign_Emp_Grade E ON E.GradeID=G.GradeID "
                             + " INNER JOIN Employee_Salary S ON S.EmpID=E.EmpID "
                             + " WHERE E.ActivatedDate=( "
                             + " Select Max(ActivatedDate) From Assign_Emp_Grade Where EmpID=E.EmpID "
                             + " And ActivatedDate<=DateAdd(m,1,'{0}'))  AND G.ActivatedDate=( "
                             + " Select Max(ActivatedDate) From Assign_Grade_Allowances Where GradeID=G.GradeID AND AllowanceID=A.ID"
                             + " And ActivatedDate<=DateAdd(m,1,'{0}'))  AND E.EmpID={1} AND AllowancePeriod='YRL' AND A.IsActive=1 AND G.IsActive=1)AP   "
                             + " WHERE ID NOT IN (SELECT AllowanceID FROM Assign_Emp_OneTimeAllowance WHERE EmpID=AP.EmpID "
                             + " AND CAST( CAST([Year] AS NVARCHAR(4)) + '-' + (CASE WHEN [Month]<9 THEN '0' ELSE '' END) + CAST([Month] AS NVARCHAR(2)) + '-' +'01'  AS DATETIME)>'{2}-03-31' "
                             + " AND CAST( CAST([Year] AS NVARCHAR(4)) + '-' + (CASE WHEN [Month]<9 THEN '0' ELSE '' END) + CAST([Month] AS NVARCHAR(2)) +  '-' + '01'  AS DATETIME)<'{3}-04-01' )"
                             + "  UNION ALL"
                             + " SELECT G.EmpID,S.[Basic], S.Special,S.Others, A.ID,AllowanceName,G.Amount,IsPercentage, A.IsTaxExempted,A.AllowanceCode,'FALSE',1 OTA,'S' AllowanceType  FROM Master_Salary_Allowance A"
                             + " INNER JOIN Assign_Emp_OneTimeAllowance G ON G.AllowanceID=A.ID "
                             + " INNER JOIN Employee_Salary S ON S.EmpID=G.EmpID "
                             + " WHERE G.EmpID={1} AND AllowancePeriod='YRL' AND A.IsActive=1" 
                             + " AND CAST( CAST([Year] AS NVARCHAR(4)) + '-' + (CASE WHEN [Month]<9 THEN '0' ELSE '' END) + CAST([Month] AS NVARCHAR(2)) + '-' +'01'  AS DATETIME)>'{2}-03-31' "
                             + " AND CAST( CAST([Year] AS NVARCHAR(4)) + '-' + (CASE WHEN [Month]<9 THEN '0' ELSE '' END) + CAST([Month] AS NVARCHAR(2)) +  '-' + '01'  AS DATETIME)<'{3}-04-01' " ;
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, datAllow.ToString("yyyy-MM-dd"), empId,FYear,FYear+1);

            DataTable dt = EE.ExecuteDataTable(exQry);
            AnualBenifits arrAnualBenifits = new AnualBenifits();
            double tot = 0;
            if (dt.Rows.Count > 0)
            {
                int k = 0;
                arrAnualBenifits.Allowances = new Allowance[dt.Rows.Count];
                foreach (DataRow dr in dt.Rows)
                {
                    Allowance al = new Allowance();
                    al.AllowanceID = (int)dr["ID"];
                    al.AllowanceType = string.Concat(dr["AllowanceType"]);
                    al.Code = string.Concat(dr["AllowanceCode"]);
                    al.Name = string.Concat(dr["Name"]);
                    al.Basic = PayEarnings.Basic;
                    al.IsOneMonthBasic = false;
                    al.IsTaxExempted = (bool)dr["IsTaxExempted"];
                    al.IsOneMonthBasic = (bool)dr["IsOneMonthSalary"];
                    al.IsOneTimeAllowance = (string.Concat(dr["OTA"]) == "1" ? true : false);
                    al.IsPercentage = (bool)dr["IsPercentage"];

                    if (al.Code == PayrollAppCommands.LEAVE_ENCASHMENT)
                    {
                        double endays = 0;
                        PayrollAnnualCongiguration config = PayrollAnnualCongiguration.GetAllPayrollAnnualConfigurations(FYear, PayEarnings.EmployeeId);
                        if (config != null)
                        {
                            endays = config.LeaveEncashDays;
                        }
                        double grsal = PayEarnings.GrossSalary;
                        double conv = 0;
                        if (PayEarnings.Allowances != null)
                        {
                            Allowance eal = Array.Find<Allowance>(PayEarnings.Allowances, (x => x.Code == PayrollAppCommands.Conveyance));
                            if (eal != null)
                            {
                                conv = eal.Amount;
                            }
                        }
                        al.Amount = Math.Round((grsal - conv) * endays / 30, 2, MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        if (al.IsOneMonthBasic)
                        {
                            al.Amount = Math.Round(al.Basic, 2, MidpointRounding.AwayFromZero);
                        }
                        else if (al.IsPercentage)
                        {
                            al.Percentage = (double)dr["Limit"];
                            al.Amount = Math.Round((al.Basic) * 12 * (double)dr["Limit"] / 100, 2, MidpointRounding.AwayFromZero);
                        }
                        else
                        {
                            al.Amount = (double)dr["Limit"];
                        }
                    }
                    tot += al.Amount;
                    arrAnualBenifits.Allowances[k] = al;
                    k++;
                }
            }
            arrAnualBenifits.TotalAmount = tot;
            return arrAnualBenifits;

        }
    }
}
