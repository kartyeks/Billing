using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;
using HRManager.Entity;

namespace HRManager.BusinessObjects
{
    public partial class Loan_RequestBusinessObject
    {

        /// <summary>
        /// Get LocationTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        public LoanRequest[] GetAllLoans()
        {
            const String Qry = "  select lr.ID,lr.EmpID,lr.LoanID,lr.LoanAmount,lr.RepaymentMonths, " +
                                " lr.MonthlyAmount,lr.Reason,lr.AppliedDateTime,lr.AppliedTo,lr.HRRemarks, " +
                //" 'Status' = CASE WHEN lr.Status = 'NEW' THEN 'NEW' WHEN lr.Status = 'REJ' THEN 'REJECTED'  " +
                //" WHEN lr.Status = 'ACC' THEN 'ACCEPTED' WHEN lr.Status = 'FRD' THEN 'FORWARDED'  WHEN lr.Status = 'CLS' THEN 'CLOSED' ELSE 'NEW' END , " +
                                " [dbo].[GetLoanStatusForAdmin](lr.ID) Status, " +
                                " isnull(mc.FirstName,'')+' '+isnull(mc.LastName,'') as eName, " +
                                " ml.LoanName as LoanName,isnull(mcx.FirstName,'')+' '+isnull(mcx.LastName,'') as appliedToName " +// ,mlg.interest as Interest" +
                                " from Loan_Request lr " +
                                " Inner join Master_Employees m on (m.id=lr.empid)  " +
                                " Inner join Master_Candidate mc on (mc.id=m.CandidateID) " +
                                " Inner join Master_Loan ml on (ml.id=lr.LoanID) " +
                                " Inner join Master_Employees mx on (mx.id=lr.appliedto) " +
                                " Inner join Master_Candidate mcx on (mcx.id=mx.CandidateID) ";// +
            //" Inner join Assign_Emp_Grade aeg on (aeg.empid=m.id) " +
            //" Inner join master_loan_grade mlg on (mlg.gradeid=aeg.gradeid and ml.id=mlg.loanid) " +
            //" where mlg.gradeid=(SELECT MAX(gradeid) FROM Assign_Emp_Grade A1  Where A1.EmpID= m.ID) ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            LoanRequest[] LoanDetails = new LoanRequest[dt.Rows.Count];

            for (int i = 0; i < LoanDetails.Length; i++)
            {
                LoanDetails[i] = new LoanRequest();
                LoanDetails[i].ID = (int)dt.Rows[i]["ID"];
                LoanDetails[i].EmpID = (int)dt.Rows[i]["EmpID"];
                LoanDetails[i].LoanID = (int)dt.Rows[i]["LoanID"];
                LoanDetails[i].LoanAmount = (Double)dt.Rows[i]["LoanAmount"];
                LoanDetails[i].RepaymentMonths = (Int16)dt.Rows[i]["RepaymentMonths"];
                LoanDetails[i].MonthlyAmount = (Double)dt.Rows[i]["MonthlyAmount"];
                LoanDetails[i].Reason = (String)dt.Rows[i]["Reason"];
                LoanDetails[i].AppliedDateTime = (DateTime)dt.Rows[i]["AppliedDateTime"];
                LoanDetails[i].AppliedTo = (int)dt.Rows[i]["AppliedTo"];
                LoanDetails[i].HRRemarks = (String)dt.Rows[i]["HRRemarks"];
                LoanDetails[i].Status = (String)dt.Rows[i]["Status"];
                LoanDetails[i].EmpName = (String)dt.Rows[i]["eName"];
                LoanDetails[i].eLoanName = (String)dt.Rows[i]["LoanName"];
                LoanDetails[i].appliedToName = (String)dt.Rows[i]["appliedToName"];
                //LoanDetails[i].Interest = (Double)dt.Rows[i]["Interest"];

            }

            return LoanDetails;
        }

        public LoanRequest[] GetAppliedToLoans(int AppliedToID)
        {
            const String Qry = " SELECT lr.ID,lr.EmpID,lr.LoanID,lr.LoanAmount,lr.RepaymentMonths,  " +
                                " lr.MonthlyAmount,lr.Reason,lr.AppliedDateTime,lr.AppliedTo,lr.HRRemarks,  " +
                                " [dbo].[GetLoanStatusForEmp](lr.ID) Status , " +
                                "  isnull(m.FirstName,'')+' '+isnull(m.LastName,'') as eName, " +
                                " ml.LoanName as LoanName,isnull(m.FirstName,'')+' '+isnull(m.LastName,'') as appliedToName  " +
                                " from Loan_Request lr  " +
                                " Inner join Master_Employees m on (m.id=lr.empid)   " +
                                " Inner join Master_Loan ml on (ml.id=lr.LoanID) " +
                                "  Inner join Master_Employees mx on (mx.id=lr.appliedto)  " +
                                " Where lr.EmpID={0};";


            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, AppliedToID);
            DataTable dt = EE.ExecuteDataTable(exQry);

            LoanRequest[] LoanDetails = new LoanRequest[dt.Rows.Count];

            for (int i = 0; i < LoanDetails.Length; i++)
            {
                LoanDetails[i] = new LoanRequest();
                LoanDetails[i].ID = (int)dt.Rows[i]["ID"];
                LoanDetails[i].EmpID = (int)dt.Rows[i]["EmpID"];
                LoanDetails[i].LoanID = (int)dt.Rows[i]["LoanID"];
                LoanDetails[i].LoanAmount = (Double)dt.Rows[i]["LoanAmount"];
                LoanDetails[i].RepaymentMonths = (Int16)dt.Rows[i]["RepaymentMonths"];
                LoanDetails[i].MonthlyAmount = (Double)dt.Rows[i]["MonthlyAmount"];
                LoanDetails[i].Reason = (String)dt.Rows[i]["Reason"];
                LoanDetails[i].AppliedDateTime = (DateTime)dt.Rows[i]["AppliedDateTime"];
                LoanDetails[i].AppliedTo = (int)dt.Rows[i]["AppliedTo"];
                LoanDetails[i].HRRemarks = (String)dt.Rows[i]["HRRemarks"];
                LoanDetails[i].Status = (String)dt.Rows[i]["Status"];
                LoanDetails[i].EmpName = (String)dt.Rows[i]["eName"];
                LoanDetails[i].eLoanName = (String)dt.Rows[i]["LoanName"];
                LoanDetails[i].appliedToName = (String)dt.Rows[i]["appliedToName"];

            }

            return LoanDetails;
        }

        public bool LoanValidForEmpWorkingDays(int EmpID, int LoanID)
        {
            const String Qry = " DECLARE @MinServicePeriod FLOAT " +
                               " SELECT @MinServicePeriod = MinServicePeriod FROM Master_Loan WHERE ID={1}" +
                               " SELECT 'MinWorkingDays' = CASE WHEN datediff(year,JoiningDate,getdate()) > @MinServicePeriod " +
                                            " THEN  1  " +
                                            " WHEN datediff(year,JoiningDate,getdate()) < @MinServicePeriod " +
                                            " THEN  0 " +
                                            " WHEN (datediff(year,JoiningDate,getdate()) = @MinServicePeriod)  " +
                                            "		AND (datediff(month,JoiningDate,getdate()) > 0) " +
                                            " THEN  1 " +
                                            " WHEN (datediff(year,JoiningDate,getdate()) = @MinServicePeriod)  " +
                                            " 		AND (datediff(month,JoiningDate,getdate()) = 0)  " +
                                            "		AND (datediff(day,JoiningDate,getdate()) >0) " +
                                            " THEN  1 " +
                                            " ELSE  0 " +
                                            " END " +
                                 " FROM Employee_OccupationDetails WHERE EmployeeID={0}";


            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmpID.ToString(), LoanID.ToString());

            return string.Concat(EE.ExecuteScalar(exQry)) == "0";

        }
        public bool isNewRequest(int EmpID, int LoanID, int ID)
        {
            const String Qry = " IF EXISTS (SELECT "
                                + " 	ID "
                                + " FROM  "
                                + "	    Loan_Request "
                                + " Where  "
                                + "	    EmpID={0}"
                                + " AND "
                                + "	    RepliedDateTime= '1753-01-01 00:00:00.000' "
                                + " AND LoanID={1} AND Status<>'REJ' AND ID<>{2} ) "
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmpID.ToString(), LoanID.ToString(), ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";

        }

        public bool isRequestYearAfterLoanClosedDate(int EmpID, int LoanID, int ID)
        {
            const String Qry = " IF EXISTS (SELECT "
                                + " 	ID "
                                + " FROM  "
                                + "	    Loan_Request "
                                + " Where  "
                                + "	    ((DATEADD(month,RepaymentMonths, DATEADD(MONTH, DATEDIFF(MONTH, 0, RepliedDateTime) + 2, 0)))>getdate()) "
                                + " AND "
                                + "	    RepliedDateTime<> '1753-01-01 00:00:00.000' "
                                + " AND "
                                + "	    EmpID={0}"
                                + " AND "
                                + "	    LoanID={1}"
                                + " AND ID<>{2}) "
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmpID.ToString(), LoanID.ToString(), ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";

        }

        public bool LoanValidFromEmpRetirmentDate(int EmpID, int LoanID)
        {
            const String Qry = " DECLARE @RemainingService FLOAT " +
                               " SELECT @RemainingService = RemainingService FROM Master_Loan WHERE ID={1}" +
                               " SELECT 'EligibleForLoan' = CASE WHEN datediff(year,getdate(),ExitDate) > @RemainingService " +
                                            " THEN  1  " +
                                            " WHEN datediff(year,ExitDate,getdate()) < @RemainingService " +
                                            " THEN  0 " +
                                            " WHEN (datediff(year,getdate(),ExitDate) = @RemainingService)  " +
                                            "		AND (datediff(month,getdate(),ExitDate) > 0) " +
                                            " THEN  1 " +
                                            " WHEN (datediff(year,getdate(),ExitDate) = @RemainingService)  " +
                                            " 		AND (datediff(month,getdate(),ExitDate) = 0)  " +
                                            "		AND (datediff(day,getdate(),ExitDate) >0) " +
                                            " THEN  1 " +
                                            " ELSE  0 " +
                                            " END " +
                                 " FROM Employee_OccupationDetails WHERE EmployeeID={0} AND IsActive=1";


            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmpID.ToString(), LoanID.ToString());

            return string.Concat(EE.ExecuteScalar(exQry)) == "0";

        }
        public int SavedEncashLeaveBeforeLoanRequest(int EmpID)
        {
            const String Qry = "  SELECT " +
                                "	    ISNULL(SUM(BalanceLeave),0)  " +
                                " FROM  " +
                                " 	    Assign_Emp_Leave AEL " +
                                " INNER JOIN  " +
                                "	    Master_Leave_Employee_Type MLET  " +
                                " ON " +
                                "	    AEL.LeaveID = MLET.LeaveID " +
                                " WHERE  " +
                                "	    EmpID={0}  " +
                                "	    AND CanBeEncashed = 1 " +
                                "	    AND MLET.IsActive = 1 " +
                                "	    AND AEL.IsActive = 1 ";


            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmpID.ToString());

            return Convert.ToInt32(string.Concat(EE.ExecuteScalar(exQry)));

        }

        public string UpdateLoanDetails(Loan_Request oLoan)
        {
            Session DBSession = Session.CreateNewSession();
            try
            {
               
                DBSession.BeginTransaction();
                Loan_RequestBusinessObject oLoanBO = new Loan_RequestBusinessObject(DBSession);
                int lId= oLoanBO.Create(oLoan);
                Loan_Activity oLAct = new Loan_Activity();
                oLAct.LoanRequestID = lId;
                oLAct.ActivityBy = oLoan.EmpID; 
                oLAct.ActivityDate = oLoan.StartDate;
                oLAct.Receiver = 1;
                oLAct.Status="CLS";
                oLAct.Initiator = oLoan.EmpID;
                oLAct.InitiatorRemark = string.Empty;
                Loan_ActivityBusinessObject oLActBO=new Loan_ActivityBusinessObject(DBSession);
                oLActBO.Create(oLAct);
                DBSession.Commit();
            }
            catch(Exception ex)
            {
                DBSession.Rollback();
                return ex.Message;
            }
            return string.Empty;
        }

        
        /// <summary>
        /// Get LocationTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        public String GetLoanAmountByLoanIdForAction(int LoanId, int EmpID)
        {

            const String Qry = "usp_GetLoanByLoanIDDetailsForAction {0},{1} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, LoanId, EmpID);
            DataTable dt = EE.ExecuteDataTable(exQry);

            String rMaxAmount = dt.Rows[0]["MaxLoanAmount"].ToString();

            return rMaxAmount;
        }
    }
}

