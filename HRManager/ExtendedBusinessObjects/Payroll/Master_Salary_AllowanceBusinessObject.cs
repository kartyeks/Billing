using System;
using System.Data;
using IS91.Services.DataBlock;
using System.Collections;
using HRManager.DTO;
namespace HRManager.BusinessObjects
{
    public partial class Master_Salary_AllowanceBusinessObject
    {
        public Master_Salary_Allowance[] GetSalaryAllowances(int IsActive)
        {
            const String Qry = "SELECT * FROM Master_Salary_Allowance WHERE IsActive={0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry,IsActive);
            DataTable dt = EE.ExecuteDataTable(exQry);
            Master_Salary_Allowance[] SAllow = null;
            if (dt != null)
            {
                 SAllow = new Master_Salary_Allowance[dt.Rows.Count];

                for (int i = 0; i < SAllow.Length; i++)
                {
                    SAllow[i] = new Master_Salary_Allowance();
                    SAllow[i].ID = (int)dt.Rows[i]["ID"];
                    SAllow[i].AllowanceName = String.Concat(dt.Rows[i]["AllowanceName"]);
                    SAllow[i].AllowanceCode = String.Concat(dt.Rows[i]["AllowanceCode"]);
                    SAllow[i].AllowancePeriod = String.Concat(dt.Rows[i]["AllowancePeriod"]);
                    SAllow[i].IsPercentage = (bool)dt.Rows[i]["IsPercentage"];
                    SAllow[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                    SAllow[i].IsTaxExempted = (bool)dt.Rows[i]["IsTaxExempted"];
                    //SAllow[i].IsOptional = (bool)dt.Rows[i]["IsOptional"];
                    //if(dt.Rows[i]["IsAllowance"].ToString()!=string.Empty)
                    //SAllow[i].IsAllowance = (bool)dt.Rows[i]["IsAllowance"];
                    SAllow[i].DisplayOrder = (int)dt.Rows[i]["DisplayOrder"];
                    SAllow[i].IsOneMonthBasic = (bool)dt.Rows[i]["IsOneMonthBasic"];
                    SAllow[i].Value = (double)dt.Rows[i]["Value"];
                }
            }

            return SAllow;
        }

        public int GetAllowanceIdFromCode(String code)
        {
            const String Qry = "Select ID from Master_Salary_Allowance where AllowanceCode='{0}'";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, code);
            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt.Rows.Count > 0)
            {
                 return (int) dt.Rows[0]["ID"];
            }
            else
            {
                return 0;
            }
        }

        public Master_Salary_Allowance[] GetOptionalSalaryAllowances(int EmpID)
        {
            const String Qry = "SELECT MSA.ID ID,* FROM Assign_Grade_Allowances AGA "
                             + " INNER JOIN Master_Salary_Allowance  MSA " 
                             + " 	ON AGA.AllowanceID=MSA.ID "
                             + " INNER JOIN Assign_Emp_Grade AEG "
                             + " 	ON AEG.GradeID=AGA.GradeID "
                             + " WHERE AEG.EmpID = {0} " //IsOptional=1 
                             + " AND AEG.ActivatedDate=(SELECT Max(ActivatedDate) FROM Assign_Emp_Grade WHERE EmpID=AEG.EmpID)";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry,EmpID.ToString());
            DataTable dt = EE.ExecuteDataTable(exQry);
            Master_Salary_Allowance[] SAllow = null;
            if (dt != null)
            {
                 SAllow = new Master_Salary_Allowance[dt.Rows.Count];

                for (int i = 0; i < SAllow.Length; i++)
                {
                    SAllow[i] = new Master_Salary_Allowance();
                    SAllow[i].ID = (int)dt.Rows[i]["ID"];
                    SAllow[i].AllowanceName = String.Concat(dt.Rows[i]["AllowanceName"]);
                    SAllow[i].AllowanceCode = String.Concat(dt.Rows[i]["AllowanceCode"]);
                    SAllow[i].AllowancePeriod = String.Concat(dt.Rows[i]["AllowancePeriod"]);
                    SAllow[i].IsPercentage = (bool)dt.Rows[i]["IsPercentage"];
                    SAllow[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                    SAllow[i].IsTaxExempted = (bool)dt.Rows[i]["IsTaxExempted"];
                    //SAllow[i].IsOptional = (bool)dt.Rows[i]["IsOptional"];
                    //if (dt.Rows[i]["IsAllowance"].ToString() != string.Empty)
                    //SAllow[i].IsAllowance = (bool)dt.Rows[i]["IsAllowance"];
                }
            }

            return SAllow;
        }
        public double GetEmployeeSalaryAllowancesLimit(int AllowanceID,int EmpID)
        {
            const String Qry = " select 'Amount' = case when ispercentage=1 then (value*Basic/100) "
                                + " 					   else value end " 
                                + "  from Assign_grade_Allowances AGA "
                                + " Inner Join Master_Salary_Allowance MSA "
                                + " 	on MSA.ID=AGA.AllowanceID "
                                + " Inner Join Employee_Salary ES "
                                + " 	on ES.EmpID={1} "
                                + " Inner Join Assign_Emp_Grade AEG  "
                                + " 	on AEG.EmpID={1} "
                                + " where AGA.AllowanceID={0}  "
                                + " and AGA.GradeID=AEG.GradeID "
                                + " and AEG.ActivatedDate = (Select max(ActivatedDate) from Assign_Emp_Grade where EmpID={1}) "
                                + " and ES.ActivatedDate = (Select max(ActivatedDate) from Employee_Salary where EmpID={1})";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry,AllowanceID.ToString(),EmpID.ToString());
            DataTable dt = EE.ExecuteDataTable(exQry);
            //Master_Salary_Allowance[] SAllow = null;
            if (dt.Rows.Count > 0)
            {
                return (double)dt.Rows[0]["Amount"];
            }
            else
                return 0.0;
        }

        public bool IsAllowanceExists(String allowanceName, int ID)
        {
            const String Qry = " SELECT COUNT(*) FROM Master_Salary_Allowance WHERE AllowanceName = '{0}' AND ID<>{1} ";
            
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, allowanceName,ID);
            return string.Concat(EE.ExecuteScalar(exQry)) != "0";
        }

        public bool IsAllowanceRefered(int ID)
        {
            return false;
            //const String Qry = "SELECT COUNT(*) FROM Master_Salary_Allowance WHERE AllowanceID = '{0}' ";
            
            //ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            //ExecutionQuery exQry = new ExecutionQuery();
            //exQry.Query = string.Format(Qry, ID.ToString());
            //return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }       
    }
}
