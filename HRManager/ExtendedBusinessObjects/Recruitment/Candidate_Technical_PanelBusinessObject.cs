using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;
using IS91.Services.DataBlock;
using System.Data;
using IRCAKernel;
using IRCA.Communication;

namespace HRManager.BusinessObjects
{
    public partial class Candidate_Technical_PanelBusinessObject
    {
        public Candidate_Technical_Panel[] GetCandidateTechnicalPanel(string Filter)
        {
            String Query = "SELECT * FROM Candidate_Technical_Panel";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            if (Filter == "")
                exQry.Query = Query;
            else
                exQry.Query = string.Format(Query) + " WHERE " + Filter;


            DataTable dt = EE.ExecuteDataTable(exQry);
            Candidate_Technical_Panel[] DTO = new Candidate_Technical_Panel[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Candidate_Technical_Panel();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].CandidateInterviewStatusID = (int)dt.Rows[i]["CandidateInterviewStatusID"];
                DTO[i].TechnicalPanelID = (int)dt.Rows[i]["TechnicalPanelID"];
                DTO[i].InterviewTypeID = (int)dt.Rows[i]["InterviewTypeID"];
            }

            return DTO;
        }

        public Candidate_Technical_Panel[] GetTechnicalPanelBYInterviewStatusID(int InterviewStatusID)
        {
            String Query = "SELECT * FROM Candidate_Technical_Panel Where CandidateInterviewStatusID = {0} AND InterviewTypeID = 0";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = String.Format(Query,InterviewStatusID);

            DataTable dt = EE.ExecuteDataTable(exQry);
            Candidate_Technical_Panel[] DTO = new Candidate_Technical_Panel[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Candidate_Technical_Panel();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].CandidateInterviewStatusID = (int)dt.Rows[i]["CandidateInterviewStatusID"];
                DTO[i].TechnicalPanelID = (int)dt.Rows[i]["TechnicalPanelID"];
                DTO[i].InterviewTypeID = (int)dt.Rows[i]["InterviewTypeID"];
            }

            return DTO;
        }

        public Candidate_Technical_Panel[] GetTechnicalPanelDetBYInterviewStatusID(int InterviewStatusID)
        {
            String Query = "SELECT * FROM Candidate_Technical_Panel Where CandidateInterviewStatusID = {0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = String.Format(Query, InterviewStatusID);

            DataTable dt = EE.ExecuteDataTable(exQry);
            Candidate_Technical_Panel[] DTO = new Candidate_Technical_Panel[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Candidate_Technical_Panel();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].CandidateInterviewStatusID = (int)dt.Rows[i]["CandidateInterviewStatusID"];
                DTO[i].TechnicalPanelID = (int)dt.Rows[i]["TechnicalPanelID"];
                DTO[i].InterviewTypeID = (int)dt.Rows[i]["InterviewTypeID"];
            }

            return DTO;
        }

        public Candidate_Technical_Panel GetTechnicalPanelDetForTechPanelZero(int InterviewStatusID)
        {
            String Query = "SELECT * FROM Candidate_Technical_Panel Where CandidateInterviewStatusID = {0} AND TechnicalPanelID = 0";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = String.Format(Query, InterviewStatusID);

            DataTable dt = EE.ExecuteDataTable(exQry);
            Candidate_Technical_Panel DTO = new Candidate_Technical_Panel();

            if(dt.Rows.Count > 0)
            {
                DTO.ID = (int)dt.Rows[0]["ID"];
                DTO.CandidateInterviewStatusID = (int)dt.Rows[0]["CandidateInterviewStatusID"];
                DTO.TechnicalPanelID = (int)dt.Rows[0]["TechnicalPanelID"];
                DTO.InterviewTypeID = (int)dt.Rows[0]["InterviewTypeID"];
            }

            return DTO;
        }

        public int DeleteTechnicalPanel(int CandidateInterviewStatus)
        {
            try
            {
                String Query = "Delete FROM Candidate_Technical_Panel Where CandidateInterviewStatusID = {0} AND InterviewTypeID = 0";

                ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
                ExecutionQuery exQry = new ExecutionQuery();

                exQry.Query = String.Format(Query, CandidateInterviewStatus);

                int noOfRows = EE.ExecuteNonQuery(exQry);
                return noOfRows;
            }
            catch (Exception ee)
            {
                IRCAExceptionHandler.HandleException(ee);
                return 0;
            }
        }

        public int[] GetTechnicalPanelIDForInterviewType(int InterviewTypeID, int InterviewstatusID)
        {
            String Query = "SELECT TechnicalPanelID FROM Candidate_Technical_Panel Where InterviewTypeID = {0} and CandidateInterviewStatusID = {1}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = String.Format(Query, InterviewTypeID, InterviewstatusID);

            DataTable dt = EE.ExecuteDataTable(exQry);
            int[] DTO = new int[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new int();
                DTO[i] = (int)dt.Rows[i]["TechnicalPanelID"];
            }

            return DTO;
        }

        public Candidate_Technical_Panel[] GetTechnicalPanelByInterviewStatusAndTypeID(int InterviewTypeID, int InterviewstatusID)
        {
            String Query = "SELECT * FROM Candidate_Technical_Panel Where InterviewTypeID = {0} and CandidateInterviewStatusID = {1}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = String.Format(Query, InterviewTypeID, InterviewstatusID);

            DataTable dt = EE.ExecuteDataTable(exQry);
            Candidate_Technical_Panel[] DTO = new Candidate_Technical_Panel[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Candidate_Technical_Panel();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].CandidateInterviewStatusID = (int)dt.Rows[i]["CandidateInterviewStatusID"];
                DTO[i].TechnicalPanelID = (int)dt.Rows[i]["TechnicalPanelID"];
                DTO[i].InterviewTypeID = (int)dt.Rows[i]["InterviewTypeID"];
            }

            return DTO;
        }

        public ComboBoxValues[] GetInterviewTypeComboForDifferentRound(int CandidateInteviewstatusID)
        {
            String Query = String.Empty;

            if (CandidateInteviewstatusID == 0)
                Query = "SELECT ID,InterviewType FROM Master_Interview_Type Where IsActive = 1";
            else
                Query = " SELECT ID,InterviewType From Master_Interview_Type Where ID Not in( "
                        + " SELECT MIT.ID from Master_Interview_Type MIT "
                        + "     INNER JOIN Candidate_Technical_Panel CTP "
                        + "     ON MIT.ID = CTP.InterviewTypeID WHERE CTP.CandidateInterviewStatusID = {0}) AND IsActive = 1 ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            if (CandidateInteviewstatusID == 0)
                exQry.Query = Query;
            else
                exQry.Query = String.Format(Query,CandidateInteviewstatusID);

            DataTable dt = EE.ExecuteDataTable(exQry);
            ComboBoxValues[] DTO = new ComboBoxValues[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new ComboBoxValues();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].Value = (String)dt.Rows[i]["InterviewType"];
            }
            return DTO;
        }
    }
}
