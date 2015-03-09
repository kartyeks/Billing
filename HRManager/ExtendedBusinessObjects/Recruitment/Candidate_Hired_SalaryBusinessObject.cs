using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS91.Services.DataBlock;
using System.Data;
using HRManager.DTO;
using HRManager.DTOEXT.Recruitment;

namespace HRManager.BusinessObjects
{
    public partial class Candidate_Hired_SalaryBusinessObject
    {
        public Candidate_Hired_SalaryEXT[] GetCandidateSalary()
        {
            String Query = " SELECT MC.ID CandidateID "
                            + "     ,MC.FirstName "
                            + "     ,MC.MiddleName "
                            + "     ,MC.LastName "
                            + "     ,ISNULL(CHS.ID,0) CandidateHiredID"
                            + "     ,ISNULL(CHS.JoiningDate,'') JoiningDate"
                            + "     ,ISNULL(CHS.CTC,0) CTC"
                            + "     ,ISNULL(CHS.ESOP,0) ESOP"
                            + "     ,CIS.CandidateStatus "
                            + "     ,ISNULL(EditedDateTime,'') IssueOfferredDate "
                            + "     FROM Candidate_Hired_Salary CHS "
                            + " RIGHT JOIN Master_Candidate MC ON MC.ID = CHS.CandidateID "
                            + " LEFT JOIN Candidate_Interview_Status CIS ON CIS.CandidateID = MC.ID "
                            + " LEFT JOIN Candidate_HTMLEditorDetails CHED ON CHED.CandidateID = MC.ID  "
                            + " WHERE CIS.CandidateStatus IN ('CL3','FIX','ISU') ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = Query;

            DataTable dt = EE.ExecuteDataTable(exQry);
            Candidate_Hired_SalaryEXT[] DTO = new Candidate_Hired_SalaryEXT[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Candidate_Hired_SalaryEXT();

                DTO[i].ID = (int)dt.Rows[i]["CandidateHiredID"];
                DTO[i].CandidateID = (int)dt.Rows[i]["CandidateID"];
                DTO[i].JoiningDate = (DateTime)dt.Rows[i]["JoiningDate"];
                DTO[i].CTC = (double)dt.Rows[i]["CTC"];
                DTO[i].ESOP = (int)dt.Rows[i]["ESOP"];

                DTO[i].FirstName = (String)dt.Rows[i]["FirstName"];
                DTO[i].MiddleName = (String)dt.Rows[i]["MiddleName"];
                DTO[i].LastName = (String)dt.Rows[i]["LastName"];
                DTO[i].CandidateStatus = (String)dt.Rows[i]["CandidateStatus"];
                DTO[i].IssueOfferredDate = (DateTime)dt.Rows[i]["IssueOfferredDate"];
            }

            return DTO;
        }

        public DataTable GetCandidateandSalaryDetails(int CandidateID)
        {
            String Query = " SELECT MC.ID CandidateID "
                            + "     ,MC.FirstName "
                            + "     ,MC.MiddleName "
                            + "     ,MC.LastName "
                            + "     ,ISNULL(CHS.ID,0) CandidateHiredID"
                            + "     ,ISNULL(CHS.JoiningDate,'') JoiningDate"
                            + "     ,ISNULL(CHS.CTC,0) CTC"
                            + "     ,ISNULL(CHS.ESOP,0) ESOP"
                            + "     FROM Candidate_Hired_Salary CHS "
                            + " RIGHT JOIN Master_Candidate MC ON MC.ID = CHS.CandidateID "
                            + " LEFT JOIN Candidate_Interview_Status CIS ON CIS.CandidateID = MC.ID WHERE MC.ID = {0} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = String.Format(Query,CandidateID);

            return EE.ExecuteDataTable(exQry);
        }

        public DataTable GetDataForHRNotification3DaysPrior()
        {
            String Query = " EXEC sp_NotifyJoiningDateToHR";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = String.Format(Query);

            return EE.ExecuteDataTable(exQry);
        }
    }
}
