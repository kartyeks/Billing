using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.ReportBusinessObjects
{
    public class CandiateBusinessObject
    {
        public DataTable GetCandidateDetailsbyConsultantReport(String FromDate, String ToDate)
        {
            const String Qry = "Exec CandidateDetailsConsultant '{0}','{1}'";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, FromDate, ToDate);
            return EE.ExecuteDataTable(exQry);
        }

        public DataTable GetCandidateDetailsbyReferralReport(String FromDate, String ToDate)
        {
            const String Qry = " Exec CandidateDetailsReferral '{0}','{1}'";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = string.Format(Qry, FromDate, ToDate);
            return EE.ExecuteDataTable(exQry);
        }

        public DataTable GetCandidateInterviewDetailsReport(String FromDate, String ToDate)
        {
            const String Qry = "Exec CandidateInterviewDetailsReport '{0}','{1}'";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, FromDate, ToDate);
            return EE.ExecuteDataTable(exQry);
        }

        public DataTable GetOfferLetterIssuedReport(String FromDate, String ToDate)
        {
            const String Qry = " Exec CandidateOfferLetterIssued '{0}','{1}'";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = string.Format(Qry, FromDate, ToDate);
            return EE.ExecuteDataTable(exQry);
        }

        public DataTable GetShortlistedCandidateReport(String FromDate, String ToDate)
        {
            const String Qry = " Exec CandidateShortlistedApplication '{0}','{1}'";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = string.Format(Qry, FromDate, ToDate);
            return EE.ExecuteDataTable(exQry);
        }
    }
}
