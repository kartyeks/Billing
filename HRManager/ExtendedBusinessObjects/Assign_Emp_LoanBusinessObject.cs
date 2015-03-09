using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;
using HRManager.Entity;
namespace HRManager.BusinessObjects
{
    public partial class Assign_Emp_LoanBusinessObject
    {

        /// <summary>
        /// Get Designations data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_Skill object</returns>
        public AssignEmpLoan[] GetPendingLoanEmpWise(int EmpID)
        {
            const String Qry = " select AEL.ID as ID,LR.EmpID as EmpID,MC.Firstname+' '+MC.LastName as Emp, " +
                                " LR.LoanID as LoanID,ML.Loanname as Loan,AEL.LoanAmount as LoanAmount, " +
                                " AEL.RepaidAmount as RepaidAmount,AEL.DueAmount as DueAmount, " +
                                " AEL.LoanTakenOn as LoanTakenOn,AEL.LoanClosedOn as LoanClosedOn,LR.id as LoanRequestID " +
                                " from assign_emp_loan AEL " +
                                " inner join loan_request LR on (LR.id=AEL.loanRequestId) " +
                                " inner join Master_employees ME on (ME.id=LR.EmpID) " +
                                " inner join Master_Candidate MC on (MC.id=ME.CandidateID) " +
                                " Inner join Master_Loan ML on (ML.Id=LR.LoanID) " +
                                " where LR.Empid={0} and AEL.DueAmount>0";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmpID);

            DataTable dt = EE.ExecuteDataTable(exQry);

            AssignEmpLoan[] AssignEmpLoan = new AssignEmpLoan[dt.Rows.Count];
            for (int i = 0; i < AssignEmpLoan.Length; i++)
            {
                AssignEmpLoan[i] = new AssignEmpLoan();
                if (dt.Rows[i]["ID"].ToString() != string.Empty)
                    AssignEmpLoan[i].ID = (Int32)dt.Rows[i]["ID"];
                if (dt.Rows[i]["EmpID"].ToString() != string.Empty)
                    AssignEmpLoan[i].EmpID = (Int32)dt.Rows[i]["EmpID"];
                if (dt.Rows[i]["LoanRequestID"].ToString() != string.Empty)
                    AssignEmpLoan[i].LoanRequestID = (Int32)dt.Rows[i]["LoanRequestID"];
                if (dt.Rows[i]["LoanID"].ToString() != string.Empty)
                    AssignEmpLoan[i].LoanID = (Int32)dt.Rows[i]["LoanID"];
                if (dt.Rows[i]["Loan"].ToString() != string.Empty)
                    AssignEmpLoan[i].LoanActualName = (String)dt.Rows[i]["Loan"];
                if (dt.Rows[i]["LoanAmount"].ToString() != string.Empty)
                    AssignEmpLoan[i].LoanAmount = (Double)dt.Rows[i]["LoanAmount"];
                if (dt.Rows[i]["RepaidAmount"].ToString() != string.Empty)
                    AssignEmpLoan[i].RepaidAmount = (Double)dt.Rows[i]["RepaidAmount"];
                if (dt.Rows[i]["DueAmount"].ToString() != string.Empty)
                    AssignEmpLoan[i].DueAmount = (Double)dt.Rows[i]["DueAmount"];
                if (dt.Rows[i]["LoanTakenOn"].ToString() != string.Empty)
                    AssignEmpLoan[i].LoanTakenOn = (DateTime)dt.Rows[i]["LoanTakenOn"];
                if (dt.Rows[i]["LoanClosedOn"].ToString() != string.Empty)
                    AssignEmpLoan[i].LoanClosedOn = (DateTime)dt.Rows[i]["LoanClosedOn"];
            }
            return AssignEmpLoan;
        }
        
        /// <summary>
        /// Get Designations data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_Skill object</returns>
        public Assign_Emp_Loan GetAssign_Emp_LoanByLoanRequestID(int LoanRequestID)
        {
            const String Qry = " SELECT * FROM Assign_Emp_Loan WHERE LoanRequestID={0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, LoanRequestID);

            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt.Rows.Count == 0)
                return null;
            Assign_Emp_Loan AssignEmpLoan = new Assign_Emp_Loan();
                if (dt.Rows[0]["ID"].ToString() != string.Empty)
                    AssignEmpLoan.ID = (Int32)dt.Rows[0]["ID"];
                if (dt.Rows[0]["LoanRequestID"].ToString() != string.Empty)
                    AssignEmpLoan.LoanRequestID = (Int32)dt.Rows[0]["LoanRequestID"];
                if (dt.Rows[0]["LoanAmount"].ToString() != string.Empty)
                    AssignEmpLoan.LoanAmount = (Double)dt.Rows[0]["LoanAmount"];
                if (dt.Rows[0]["RepaidAmount"].ToString() != string.Empty)
                    AssignEmpLoan.RepaidAmount = (Double)dt.Rows[0]["RepaidAmount"];
                if (dt.Rows[0]["DueAmount"].ToString() != string.Empty)
                    AssignEmpLoan.DueAmount = (Double)dt.Rows[0]["DueAmount"];
                if (dt.Rows[0]["LoanTakenOn"].ToString() != string.Empty)
                    AssignEmpLoan.LoanTakenOn = (DateTime)dt.Rows[0]["LoanTakenOn"];
                if (dt.Rows[0]["LoanClosedOn"].ToString() != string.Empty)
                    AssignEmpLoan.LoanClosedOn = (DateTime)dt.Rows[0]["LoanClosedOn"];
            
            return AssignEmpLoan;
        }
    }
}