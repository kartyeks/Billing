using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;
using HRManager.Entity;

namespace HRManager.BusinessObjects
{
    public partial class Master_Salary_DeductionsBusinessObject
    {
        //public StandardSalaryDeductions GetSalaryDeductionByCode(String DeductionCode)
        //{
        //    StandardSalaryDeductions[] DTOs = GetSalaryDeductions(" DeductionCode = '" + DeductionCode + "'");

        //    if (DTOs.Length > 0)
        //    {
        //        return DTOs[0];
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //public StandardSalaryDeductions[] GetSalaryDeductions()
        //{
        //    return GetSalaryDeductions("");
        //}

        //private StandardSalaryDeductions[] GetSalaryDeductions(String Filter)
        //{
        //    const String Qry = " SELECT "
        //                     + " 	ID"
        //                     + " 	,Name"
        //                     + " 	,DeductionPeriod"
        //                     + " 	,DeductionCode"
        //                     + " 	,Limit"
        //                     + " 	,IsPercentage "
        //                     + " FROM "
        //                     + " 	Master_Salary_Deductions "
        //                     + " WHERE "
        //                     + " 	IsActive = 1 "
        //                     + " 	AND IsEmployeeLevel = 0"; 

        //    ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
        //    ExecutionQuery exQry = new ExecutionQuery();

        //    if (String.Empty == Filter)
        //    {
        //        exQry.Query = String.Format(Qry);
        //    }
        //    else
        //    {
        //        exQry.Query = Qry + " AND " + Filter;
        //    }
        //    DataTable dt = EE.ExecuteDataTable(exQry);

        //    StandardSalaryDeductions[] SalryDeductDetails = new StandardSalaryDeductions[dt.Rows.Count];

        //    for (int i = 0; i < SalryDeductDetails.Length; i++)
        //    {
        //        SalryDeductDetails[i] = new StandardSalaryDeductions();
        //        SalryDeductDetails[i].DeductionID = (int)dt.Rows[i]["ID"];
        //        SalryDeductDetails[i].DeductionValue = (double)dt.Rows[i]["Limit"];
        //        SalryDeductDetails[i].DeductionName = (String)dt.Rows[i]["Name"];
        //        SalryDeductDetails[i].DeductionCode = (String)dt.Rows[i]["DeductionCode"];
        //        SalryDeductDetails[i].DeductionPeriod = (String)dt.Rows[i]["DeductionPeriod"];
        //        SalryDeductDetails[i].IsPercentage = (bool)dt.Rows[i]["IsPercentage"];
        //    }
        //    return SalryDeductDetails;
        //}

        public int GetDeductionsIdFromCode(String code)
        {
            const String Qry = "Select ID from Master_Salary_Deductions where DeductionCode='{0}'";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, code);
            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt.Rows.Count > 0)
            {
                return (int)dt.Rows[0]["ID"];
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// Get AssignGradeSalary data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of AssignGradeSalary object</returns>
        public Master_Salary_Deductions[] GetAllSalaryDeductions()
        {
            const String Qry = " SELECT * FROM Master_Salary_Deductions Where IsActive=1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_Salary_Deductions[] SalryDeductDetails = new Master_Salary_Deductions[dt.Rows.Count];

            for (int i = 0; i < SalryDeductDetails.Length; i++)
            {
                SalryDeductDetails[i] = new Master_Salary_Deductions();
                SalryDeductDetails[i].ID = (int)dt.Rows[i]["ID"];
                SalryDeductDetails[i].Name = (String)dt.Rows[i]["Name"];
                SalryDeductDetails[i].DeductionPeriod = (String)dt.Rows[i]["DeductionPeriod"];
                if (dt.Rows[i]["Limit"].ToString() != string.Empty)
                SalryDeductDetails[i].Limit = (Double)dt.Rows[i]["Limit"];
                SalryDeductDetails[i].IsEmployeeLevel = (bool)dt.Rows[i]["IsEmployeeLevel"];
                if (dt.Rows[i]["IsPercentage"].ToString() != string.Empty)
                SalryDeductDetails[i].IsPercentage = (bool)dt.Rows[i]["IsPercentage"];
                if (dt.Rows[i]["DeductionCode"].ToString() != string.Empty)
                SalryDeductDetails[i].DeductionCode = (string)dt.Rows[i]["DeductionCode"];
                if (dt.Rows[i]["IsTaxExempted"].ToString() != string.Empty)
                    SalryDeductDetails[i].IsTaxExempted = (bool)dt.Rows[i]["IsTaxExempted"];
                SalryDeductDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
            }
            return SalryDeductDetails;
        }
        /// <summary>
        /// Get AssignGradeSalary data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of AssignGradeSalary object</returns>
        public Master_Salary_Deductions[] GetAllEmployeeSalaryDeductions()
        {
            const String Qry = " SELECT ID,Name,DeductionPeriod,Limit,IsEmployeeLevel,IsPercentage,DeductionCode,IsTaxExempted,IsActive,'DED' DeductionType  FROM Master_Salary_Deductions Where IsActive=1 and IsEmployeeLevel=1 " +
                               " UNION " +
                               "  SELECT ID,Name,DeductionPeriod,Limit,IsEmployeeLevel,IsPercentage,DeductionCode,IsTaxExempted,IsActive,'DED' DeductionType  FROM Master_Salary_Deductions Where IsActive=1 and DeductionCode='PF' " +
                               " UNION " +
                               "  SELECT ID,TaxName,'MON' DeductionPeriod,0 Limit,'False' IsEmployeeLevel,'False' IsPercentage,TaxCode,'False' IsTaxExempted,IsActive,'TAX' DeductionType    FROM Master_Tax Where IsActive=1 and (TaxName='TDS' OR TaxCode='TDS') ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_Salary_Deductions[] SalryDeductDetails = new Master_Salary_Deductions[dt.Rows.Count];

            for (int i = 0; i < SalryDeductDetails.Length; i++)
            {
                SalryDeductDetails[i] = new Master_Salary_Deductions();
                SalryDeductDetails[i].ID = (int)dt.Rows[i]["ID"];
                SalryDeductDetails[i].Name = (String)dt.Rows[i]["Name"];
                SalryDeductDetails[i].DeductionPeriod = (String)dt.Rows[i]["DeductionPeriod"];
                if (dt.Rows[i]["Limit"].ToString() != string.Empty)
                    SalryDeductDetails[i].Limit = (Double)dt.Rows[i]["Limit"];
                SalryDeductDetails[i].IsEmployeeLevel = (bool)dt.Rows[i]["IsEmployeeLevel"];
                if (dt.Rows[i]["IsPercentage"].ToString() != string.Empty)
                    SalryDeductDetails[i].IsPercentage = (bool)dt.Rows[i]["IsPercentage"];
                if (dt.Rows[i]["DeductionCode"].ToString() != string.Empty)
                    SalryDeductDetails[i].DeductionCode = (string)dt.Rows[i]["DeductionCode"];
                if (dt.Rows[i]["IsTaxExempted"].ToString() != string.Empty)
                    SalryDeductDetails[i].IsTaxExempted = (bool)dt.Rows[i]["IsTaxExempted"];
                SalryDeductDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];

            }
            return SalryDeductDetails;
        }
        public EmpDeduction[] GetAllEmployeeDeductions()
        {
            const String Qry = " SELECT ID,Name,DeductionPeriod,Limit,IsEmployeeLevel,IsPercentage,DeductionCode,IsTaxExempted,IsActive,'DED' DeductionType  FROM Master_Salary_Deductions Where IsActive=1 and IsEmployeeLevel=1 " +
                               " UNION " +
                               "  SELECT ID,Name,DeductionPeriod,Limit,IsEmployeeLevel,IsPercentage,DeductionCode,IsTaxExempted,IsActive,'DED' DeductionType  FROM Master_Salary_Deductions Where IsActive=1 and DeductionCode in ('PF','ESI') " +
                               " UNION " +
                               "  SELECT ID,TaxName,'MON' DeductionPeriod,0 Limit,'False' IsEmployeeLevel,'False' IsPercentage,TaxCode,'False' IsTaxExempted,IsActive,'TAX' DeductionType    FROM Master_Tax Where IsActive=1 and (TaxName='Income Tax' OR TaxCode='TAX') ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            EmpDeduction[] EmpDed= new EmpDeduction[dt.Rows.Count];

            for (int i = 0; i < EmpDed.Length; i++)
            {
                EmpDed[i] = new EmpDeduction();
                EmpDed[i].ID = (int)dt.Rows[i]["ID"];
                EmpDed[i].Name = (String)dt.Rows[i]["Name"];
                EmpDed[i].DeductionType = String.Concat(dt.Rows[i]["DeductionType"]);
                EmpDed[i].Period = (String)dt.Rows[i]["DeductionPeriod"];
                if (dt.Rows[i]["Limit"].ToString() != string.Empty)
                    EmpDed[i].Limit = (Double)dt.Rows[i]["Limit"];
                EmpDed[i].IsEmployeeLevel = (bool)dt.Rows[i]["IsEmployeeLevel"];
                if (dt.Rows[i]["IsPercentage"].ToString() != string.Empty)
                    EmpDed[i].IsPercentage = (bool)dt.Rows[i]["IsPercentage"];
                if (dt.Rows[i]["DeductionCode"].ToString() != string.Empty)
                    EmpDed[i].Code = (string)dt.Rows[i]["DeductionCode"];
                if (dt.Rows[i]["IsTaxExempted"].ToString() != string.Empty)
                    EmpDed[i].IsTaxExempted = (bool)dt.Rows[i]["IsTaxExempted"];
                EmpDed[i].IsActive = (bool)dt.Rows[i]["IsActive"];

            }
            return EmpDed;
        }


        /// <summary>
        /// Get AssignGradeSalary data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of AssignGradeSalary object</returns>
        public Master_Salary_Deductions[] GetAllInactiveSalaryDeductions()
        {
            const String Qry = " SELECT * FROM Master_Salary_Deductions Where IsActive=0 ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_Salary_Deductions[] SalryDeductDetails = new Master_Salary_Deductions[dt.Rows.Count];

            for (int i = 0; i < SalryDeductDetails.Length; i++)
            {
                SalryDeductDetails[i] = new Master_Salary_Deductions();
                SalryDeductDetails[i].ID = (int)dt.Rows[i]["ID"];
                SalryDeductDetails[i].Name = (String)dt.Rows[i]["Name"];
                SalryDeductDetails[i].DeductionPeriod = (String)dt.Rows[i]["DeductionPeriod"];
                if (dt.Rows[i]["Limit"].ToString() != string.Empty)
                SalryDeductDetails[i].Limit = (Double)dt.Rows[i]["Limit"];
                SalryDeductDetails[i].IsEmployeeLevel = (bool)dt.Rows[i]["IsEmployeeLevel"];
                if (dt.Rows[i]["IsPercentage"].ToString() != string.Empty)
                SalryDeductDetails[i].IsPercentage = (bool)dt.Rows[i]["IsPercentage"];
                if (dt.Rows[i]["DeductionCode"].ToString() != string.Empty)
                SalryDeductDetails[i].DeductionCode = (string)dt.Rows[i]["DeductionCode"];
                if (dt.Rows[i]["IsTaxExempted"].ToString() != string.Empty)
                    SalryDeductDetails[i].IsTaxExempted = (bool)dt.Rows[i]["IsTaxExempted"];
                SalryDeductDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
            }
            return SalryDeductDetails;
        }

        /// <summary>
        /// check Location Existance in the database.
        /// </summary>
        /// <param name="Role">field contains Location name</param>
        /// <param name="ID">field contains Location ID</param>
        /// <returns>True for Exist and false for not exist</returns>
        public bool IsDeductionExists(String Name, int ID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Master_Salary_Deductions WHERE Name = '{0}' AND ID<>{1})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, Name, ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }
    }
}
