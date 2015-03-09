using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;
using HRManager.Entity;
namespace HRManager.BusinessObjects
{
    public partial class Salary_AdvanceRepaymentsBusinessObject
    {

        /// <summary>
        /// Get Designations data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_Skill object</returns>
        public SalaryAdvanceRepayment[] GetPendingSalaryAdvanceEmpWise(int EmpID)
        {
            const String Qry =  " select SA.ID as ID ,SA.AdvanceAmount as AdvanceAmount,SA.AppliedDateTime as AdvanceTakenOn, " +
                                " [dbo].[GetSalaryAdvanceRepaidAmount](SA.EmpID,SA.ID) as RepaidAmount,SA.EmpID as EmpID, " +
                                " (AdvanceAmount-[dbo].[GetSalaryAdvanceRepaidAmount](SA.EmpID,SA.ID)) as DueAmount " +
                                " from Salary_Advance SA " +
                                " where Empid={0} and SA.Status='ACC'";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmpID);

            DataTable dt = EE.ExecuteDataTable(exQry);

            SalaryAdvanceRepayment[] SalaryAdvanceRepayment = new SalaryAdvanceRepayment[dt.Rows.Count];
            for (int i = 0; i < SalaryAdvanceRepayment.Length; i++)
            {
                SalaryAdvanceRepayment[i] = new SalaryAdvanceRepayment();
                if (dt.Rows[i]["ID"].ToString() != string.Empty)
                    SalaryAdvanceRepayment[i].ID = (Int32)dt.Rows[i]["ID"];
                if (dt.Rows[i]["EmpID"].ToString() != string.Empty)
                    SalaryAdvanceRepayment[i].EmpID = (Int32)dt.Rows[i]["EmpID"];
                if (dt.Rows[i]["AdvanceAmount"].ToString() != string.Empty)
                    SalaryAdvanceRepayment[i].AdvanceAmount = (Double)dt.Rows[i]["AdvanceAmount"];
                if (dt.Rows[i]["RepaidAmount"].ToString() != string.Empty)
                    SalaryAdvanceRepayment[i].RepaidAmount = (Double)dt.Rows[i]["RepaidAmount"];
                if (dt.Rows[i]["DueAmount"].ToString() != string.Empty)
                    SalaryAdvanceRepayment[i].DueAmount = (Double)dt.Rows[i]["DueAmount"];
                if (dt.Rows[i]["AdvanceTakenOn"].ToString() != string.Empty)
                    SalaryAdvanceRepayment[i].AdvanceTakenOn = (DateTime)dt.Rows[i]["AdvanceTakenOn"];
            }
            return SalaryAdvanceRepayment;
        }

        
    }
}