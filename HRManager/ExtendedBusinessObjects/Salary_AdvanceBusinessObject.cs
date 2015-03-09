using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;
using HRManager.Entity;

namespace HRManager.BusinessObjects
{
    public partial class Salary_AdvanceBusinessObject
    {

        /// <summary>
        /// Get LocationTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        public SalaryAdvance[] GetAllSalaryAdvance()
        {
            const String Qry = " SELECT  SA.ID,SA.EmpID,SA.AdvanceAmount,SA.RepaymentMonths,SA.MonthlyAmount, " +
                                " SA.Reason,SA.AppliedDateTime,SA.AppliedTo,SA.HRRemarks, " +
                                " 'Status' = CASE WHEN SA.Status = 'NEW' THEN 'NEW' WHEN SA.Status = 'REJ' THEN 'REJECTED'  " +
                                " WHEN SA.Status = 'ACC' THEN 'ACCEPTED' ELSE 'NEW' END , " +
                                " SA.RepliedDateTime,SA.CreatedBy,SA.CreatedDate,SA.ModifiedBy, " +
                                " SA.ModifiedDate,isnull(MC.FirstName,'')+' '+isnull(MC.LastName,'') as eName,MAT.AdvanceType,MAT.ID as AdvanceTypeID, " +
                                " isnull(MCA.FirstName,'')+' '+isnull(MCA.LastName,'') as appliedToName " +
                                " FROM Salary_Advance SA  " +
                                " INNER JOIN Master_Employees MP on (SA.EmpID=MP.ID) " +
                                " INNER JOIN Master_Candidate MC on (MC.ID=MP.CandidateID) " +
                                " INNER JOIN Master_Employees MPA on (SA.AppliedTo=MPA.ID) " +
                                " INNER JOIN Master_AdvanceType MAT on (MAT.ID=SA.AdvanceID) " +
                                " INNER JOIN Master_Candidate MCA on (MCA.ID=MPA.CandidateID)";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            SalaryAdvance[] SalaryAdvance = new SalaryAdvance[dt.Rows.Count];

            for (int i = 0; i < SalaryAdvance.Length; i++)
            {
                SalaryAdvance[i] = new SalaryAdvance();
                SalaryAdvance[i].ID = (int)dt.Rows[i]["ID"];
                SalaryAdvance[i].EmpID = (int)dt.Rows[i]["EmpID"];
                SalaryAdvance[i].AdvanceTypeID = (int)dt.Rows[i]["AdvanceTypeID"];
                SalaryAdvance[i].AdvanceType = (String)dt.Rows[i]["AdvanceType"];
                SalaryAdvance[i].AdvanceAmount = (Double)dt.Rows[i]["AdvanceAmount"];
                SalaryAdvance[i].RepaymentMonths = (Int16)dt.Rows[i]["RepaymentMonths"];
                SalaryAdvance[i].MonthlyAmount = (Double)dt.Rows[i]["MonthlyAmount"];
                SalaryAdvance[i].Reason = (String)dt.Rows[i]["Reason"];
                SalaryAdvance[i].AppliedDateTime = (DateTime)dt.Rows[i]["AppliedDateTime"];
                SalaryAdvance[i].AppliedTo = (int)dt.Rows[i]["AppliedTo"];
                SalaryAdvance[i].HRRemarks = (String)dt.Rows[i]["HRRemarks"];
                SalaryAdvance[i].Status = (String)dt.Rows[i]["Status"];
                SalaryAdvance[i].EmpName = (String)dt.Rows[i]["eName"];
                SalaryAdvance[i].appliedToName = (String)dt.Rows[i]["appliedToName"];
            }

            return SalaryAdvance;
        }
        /// <summary>
        /// Get LocationTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        public SalaryAdvance[] GetAppliedToSalaryAdvance(int AppliedToID)
        {
            const String Qry = " SELECT  SA.ID,SA.EmpID,SA.AdvanceAmount,SA.RepaymentMonths,SA.MonthlyAmount, " +
                               " SA.Reason,SA.AppliedDateTime,SA.AppliedTo,SA.HRRemarks, " +
                               " 'Status' = CASE WHEN SA.Status = 'NEW' THEN 'NEW' WHEN SA.Status = 'REJ' THEN 'REJECTED'  " +
                                " WHEN SA.Status = 'ACC' THEN 'ACCEPTED' ELSE 'NEW' END , " +
                               " SA.RepliedDateTime,SA.CreatedBy,SA.CreatedDate,SA.ModifiedBy,MAT.AdvanceType,MAT.ID as AdvanceTypeID, " +
                               " SA.ModifiedDate,isnull(MC.FirstName,'')+' '+isnull(MC.LastName,'') as eName, " +
                               " isnull(MCA.FirstName,'')+' '+isnull(MCA.LastName,'') as appliedToName " +
                               " FROM Salary_Advance SA  " +
                               " INNER JOIN Master_Employees MP on (SA.EmpID=MP.ID) " +
                               " INNER JOIN Master_Candidate MC on (MC.ID=MP.CandidateID) " +
                               " INNER JOIN Master_Employees MPA on (SA.AppliedTo=MPA.ID) " +
                               " INNER JOIN Master_AdvanceType MAT on (MAT.ID=SA.AdvanceID) " +
                               " INNER JOIN Master_Candidate MCA on (MCA.ID=MPA.CandidateID) " +
                               " WHERE SA.AppliedTo={0}  or SA.EmpID={0} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, AppliedToID);
            DataTable dt = EE.ExecuteDataTable(exQry);

            SalaryAdvance[] SalaryAdvance = new SalaryAdvance[dt.Rows.Count];

            for (int i = 0; i < SalaryAdvance.Length; i++)
            {
                SalaryAdvance[i] = new SalaryAdvance();
                SalaryAdvance[i].ID = (int)dt.Rows[i]["ID"];
                SalaryAdvance[i].AdvanceType = (String)dt.Rows[i]["AdvanceType"];
                SalaryAdvance[i].EmpID = (int)dt.Rows[i]["EmpID"];
                SalaryAdvance[i].AdvanceTypeID = (int)dt.Rows[i]["AdvanceTypeID"];
                SalaryAdvance[i].AdvanceAmount = (Double)dt.Rows[i]["AdvanceAmount"];
                SalaryAdvance[i].RepaymentMonths = (Int16)dt.Rows[i]["RepaymentMonths"];
                SalaryAdvance[i].MonthlyAmount = (Double)dt.Rows[i]["MonthlyAmount"];
                SalaryAdvance[i].Reason = (String)dt.Rows[i]["Reason"];
                SalaryAdvance[i].AppliedDateTime = (DateTime)dt.Rows[i]["AppliedDateTime"];
                SalaryAdvance[i].AppliedTo = (int)dt.Rows[i]["AppliedTo"];
                SalaryAdvance[i].HRRemarks = (String)dt.Rows[i]["HRRemarks"];
                SalaryAdvance[i].Status = (String)dt.Rows[i]["Status"];
                SalaryAdvance[i].EmpName = (String)dt.Rows[i]["eName"];
                SalaryAdvance[i].appliedToName = (String)dt.Rows[i]["appliedToName"];
            }

            return SalaryAdvance;
        }
        public bool IsSalaryAdvanceExists(int AdvanceType,int EmployeeID, int ID)
        {
            const String Qry = " IF EXISTS (select ID from salary_advance "
                                + " where EmpId={1} and AdvanceID={0} and Status='NEW' )"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, AdvanceType.ToString(), EmployeeID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }

    }
}
