using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.ReportBusinessObjects
{
    public class AppraisalBusinessObject
    {
        public DataTable GetPromotionReport(String FromDate, String ToDate, int TeamID)
        {
            const String Qry = "Exec sp_promotion_report '{0}','{1}',{2}";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, FromDate, ToDate,TeamID);
            return EE.ExecuteDataTable(exQry);
        }

        public DataTable GetSalaryHikeReport(String FromDate, String ToDate, int TeamID)
        {
            const String Qry = " Exec sp_salary_hike_report '{0}','{1}',{2}";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = string.Format(Qry, FromDate, ToDate, TeamID);
            return EE.ExecuteDataTable(exQry);
        }
    }
}
