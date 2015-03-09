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
    public partial class Candidate_Interview_ResultBusinessObject
    {
        public Candidate_Interview_ResultEXT[] GetInterviewResultDetails(int LoggedEmpID, int CAndidateID)
        {
            String Query = "  SELECT  " 
                            + "     MCC.ID MCCID "
                            + "     ,Isnull(CIR.ID, 0) CIRID "
	                        + "     ,Isnull(CIR.CandidateID,0) CandidateID  "
                            + "     ,Isnull(CompetencyName,'') CompetencyName "
	                        + "     ,Isnull(CompetencyDescription,'')CompetencyDescription  "
	                        + "     ,Isnull(CIR.JobTitle,'')JobTitle "
	                        + "     ,Isnull(CIR.InterviewerID,0)InterviewerID "
	                        + "     ,Isnull(CIR.InterviewDate,'')InterviewDate "
	                        + "     ,Isnull(CIR.CompetencyID,0)CompetencyID "
                            + "     ,Isnull(CIR.StrengthandWeakness,'') StrengthandWeakness"
                            + "     ,Isnull(CIR.Recommendation,'') Recommendation"
                            + "     ,Isnull(CIR.UpdatedBy,0 ) UpdatedBy"
                            + "     ,Isnull(CIR.InterviewerName,'' ) InterviewerName "
                            + "     ,Isnull(CIR.UpdatedDateTime,'') UpdatedDateTime"
	                        + "     ,Isnull(CIR.CandidateName,'')CandidateName "
	                        + "     ,Isnull(CIR.VALUE1,'')VALUE1 "
	                        + "     ,Isnull(CIR.VALUE2,'')VALUE2 "
	                        + "     ,Isnull(CIR.VALUE3,'')VALUE3 "
	                        + "     ,Isnull(CIR.VALUE4,'')VALUE4 "
	                        + "     ,Isnull(CIR.VALUE5,'')VALUE5 "
	                        + "     ,Isnull(CIR.VALUE6,'')VALUE6 "
                            + " FROM Master_Candidate_Competency MCC "
                            + " LEFT JOIN  "
                            + " ( "
	                        + "     SELECT "
                            + "         TR.ID "
		                    + "         ,MC.ID CandidateID "
		                    + "         ,JobTitle "
		                    + "         ,InterviewerID "
                            + "         ,InterviewDate "
                            + "         ,CompetencyID	"
                            + "         ,StrengthandWeakness "
                            + "         ,Recommendation "
                            + "         ,UpdatedBy "
                            + "         ,UpdatedDateTime "
                            + "         ,(MC.FirstName + ' ' + MC.MiddleName + ' ' + MC.LastName)  CandidateName  "
                            + "         ,(ME.FirstName + ' ' + ME.MiddleName + ' ' + ME.LastName)  InterviewerName  "
                            + "         ,(CASE WHEN ISNULL(CompetencyValue,0)=5 THEN 1 ELSE 0 END) VALUE1      "
                            + "         ,(CASE WHEN ISNULL(CompetencyValue,0)=4 THEN 1 ELSE 0 END) VALUE2      "
                            + "         ,(CASE WHEN ISNULL(CompetencyValue,0)=3 THEN 1 ELSE 0 END) VALUE3      "
                            + "         ,(CASE WHEN ISNULL(CompetencyValue,0)=2 THEN 1 ELSE 0 END) VALUE4     "
                            + "         ,(CASE WHEN ISNULL(CompetencyValue,0)=1 THEN 1 ELSE 0 END) VALUE5      "
                            + "         ,(CASE WHEN ISNULL(CompetencyValue,0)=6 THEN 1 ELSE 0 END) VALUE6 "
                            + "     FROM Master_Candidate MC"
                            + "         LEFT JOIN Candidate_Interview_Result TR ON TR.CandidateID=MC.ID "
                            + "         INNER JOIN Master_Employees ME ON ME.ID = InterviewerID "
                            + "     WHERE MC.ID = {0} "
                            + " ) "
                            + " CIR ON (CIR.CompetencyID=MCC.ID OR CIR.CompetencyID IS NULL) WHERE MCC.IsActive = 1";
                           

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = String.Format(Query, CAndidateID);


            DataTable dt = EE.ExecuteDataTable(exQry);
            Candidate_Interview_ResultEXT[] DTO = new Candidate_Interview_ResultEXT[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Candidate_Interview_ResultEXT();
                DTO[i].Id = (int)dt.Rows[i]["CIRID"];
                DTO[i].CandidateID = (int)dt.Rows[i]["CandidateID"];
                DTO[i].JobTitle = (String)dt.Rows[i]["JobTitle"];
                DTO[i].InterviewerID = (int)dt.Rows[i]["InterviewerID"];
                DTO[i].InterviewDate = (DateTime)dt.Rows[i]["InterviewDate"];
                DTO[i].CompetencyID = (int)dt.Rows[i]["CompetencyID"];
                DTO[i].StrengthandWeakness = (String)dt.Rows[i]["StrengthandWeakness"];
                DTO[i].Recommendation = (String)dt.Rows[i]["Recommendation"];
                DTO[i].UpdatedBy = (int)dt.Rows[i]["UpdatedBy"];
                DTO[i].UpdatedDateTime = (DateTime)dt.Rows[i]["UpdatedDateTime"];

                DTO[i].MCCompetencyID = (int)dt.Rows[i]["MCCID"];
                DTO[i].CandidateName = (String)dt.Rows[i]["CandidateName"];
                DTO[i].CompetencyName = (String)dt.Rows[i]["CompetencyName"];
                DTO[i].CompetencyDescription = (String)dt.Rows[i]["CompetencyDescription"];
                DTO[i].InteviewerName = (String)dt.Rows[i]["InterviewerName"];

                if((int)dt.Rows[i]["VALUE1"] == 0)
                    DTO[i].Value1 = false;
                else if((int)dt.Rows[i]["VALUE1"] == 1)
                    DTO[i].Value1 = true;

                if ((int)dt.Rows[i]["VALUE2"] == 0)
                    DTO[i].Value2 = false;
                else if ((int)dt.Rows[i]["VALUE2"] == 1)
                    DTO[i].Value2 = true;

                if ((int)dt.Rows[i]["VALUE3"] == 0)
                    DTO[i].Value3 = false;
                else if ((int)dt.Rows[i]["VALUE3"] == 1)
                    DTO[i].Value3 = true;

                if ((int)dt.Rows[i]["VALUE4"] == 0)
                    DTO[i].Value4 = false;
                else if ((int)dt.Rows[i]["VALUE4"] == 1)
                    DTO[i].Value4 = true;

                if ((int)dt.Rows[i]["VALUE5"] == 0)
                    DTO[i].Value5 = false;
                else if ((int)dt.Rows[i]["VALUE5"] == 1)
                    DTO[i].Value5 = true;

                if ((int)dt.Rows[i]["VALUE6"] == 0)
                    DTO[i].Value6 = false;
                else if ((int)dt.Rows[i]["VALUE6"] == 1)
                    DTO[i].Value6 = true;
            }
            return DTO;
        }

        public Candidate_Interview_Result[] GetResultDetailsByID(int CAndidateId)
        {
            String Query = "  SELECT * FROM Candidate_Interview_Result Where CandidateID = {0} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = String.Format(Query, CAndidateId);


            DataTable dt = EE.ExecuteDataTable(exQry);
            Candidate_Interview_Result[] DTO = new Candidate_Interview_Result[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Candidate_Interview_Result();
                DTO[i].Id = (int)dt.Rows[i]["ID"];
                DTO[i].CandidateID = (int)dt.Rows[i]["CandidateID"];
                DTO[i].JobTitle = (String)dt.Rows[i]["JobTitle"];
                DTO[i].InterviewerID = (int)dt.Rows[i]["InterviewerID"];
                DTO[i].InterviewDate = (DateTime)dt.Rows[i]["InterviewDate"];
                DTO[i].CompetencyID = (int)dt.Rows[i]["CompetencyID"];
                DTO[i].StrengthandWeakness = (String)dt.Rows[i]["StrengthandWeakness"];
                DTO[i].Recommendation = (String)dt.Rows[i]["Recommendation"];
                DTO[i].UpdatedBy = (int)dt.Rows[i]["UpdatedBy"];
                DTO[i].UpdatedDateTime = (DateTime)dt.Rows[i]["UpdatedDateTime"];
            }
            return DTO;
        }
    }
}
