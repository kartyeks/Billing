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
    public partial class Master_CandidateBusinessObject
    {
        public Master_Candidate[] GetAllCandidateDetails(string Filter)
        {
            String Query = "SELECT * FROM Master_Candidate";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            if (Filter == "")
                exQry.Query = Query;
            else
                exQry.Query = string.Format(Query) + " WHERE " + Filter;


            DataTable dt = EE.ExecuteDataTable(exQry);
            Master_Candidate[] DTO = new Master_Candidate[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Master_Candidate();

                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].TeamID = (int)dt.Rows[i]["TeamID"];
                DTO[i].CandidateType = (String)dt.Rows[i]["CandidateType"];
                DTO[i].FirstName = (String)dt.Rows[i]["FirstName"];
                DTO[i].MiddleName = (String)dt.Rows[i]["MiddleName"];
                DTO[i].LastName = (String)dt.Rows[i]["LastName"];
                DTO[i].CurrentEmployer = (String)dt.Rows[i]["CurrentEmployer"];
                DTO[i].CareerStartDate = (DateTime)dt.Rows[i]["CareerStartDate"];
                DTO[i].Experience = (String)dt.Rows[i]["Experience"];
                DTO[i].TechnologyExpertise = (String)dt.Rows[i]["TechnologyExpertise"];
                DTO[i].ContactNumber = (String)dt.Rows[i]["ContactNumber"];
                DTO[i].EmailID = (String)dt.Rows[i]["EmailID"];
                DTO[i].NoticePeriod = (int)dt.Rows[i]["NoticePeriod"];
                DTO[i].CurrentLocation = (String)dt.Rows[i]["CurrentLocation"];
                DTO[i].ReasonForChange = (String)dt.Rows[i]["ReasonForChange"];
                DTO[i].OffersInHand = (String)dt.Rows[i]["OffersInHand"];
                DTO[i].ResumeFilename = (String)dt.Rows[i]["ResumeFilename"];
                DTO[i].RecruitmentType = (String)dt.Rows[i]["RecruitmentType"];
                DTO[i].CreatedBy = (int)dt.Rows[i]["CreatedBy"];
                DTO[i].CreatedDate = (DateTime)dt.Rows[i]["CreatedDate"];
                DTO[i].ModifiedBy = (int)dt.Rows[i]["ModifiedBy"];
                DTO[i].ModifiedDate = (DateTime)dt.Rows[i]["ModifiedDate"];
            }

            return DTO;
        }

        public Master_CandidateEXT[] GetCandidatesBasedOnLogin(int LoggedEmpID, int LoggedUserID, String RecruitmentType)
        {
            String Query = " SELECT MC.* "
                            + "     ,ISNULL(CIS.CandidateStatus,'') CandidateStatus "
                            + "     ,ISNULL(CIS.ID,0) InterviewStatusID"
                            + "     ,ISNULL((ME.FirstName + ' '+ ' ' + ME.MiddleName + ' ' + ME.LastName),'') ManagerName "
                            + "     ,ISNULL(MT.TeamName,'') TeamName"
                            + "     FROM Master_Candidate MC "
                            + " INNER JOIN Master_Team MT ON MC.TeamID = MT.ID "
                            + "     LEFT JOIN Candidate_Interview_Status CIS ON CIS.CandidateID = MC.ID "
                            + "     LEFT JOIN Master_Employees ME ON ME.ID = MT.ManagerID "
                            + " WHERE (MT.ManagerID = {0} OR (MC.CreatedBy = {1} AND MC.ModifiedBy = {1})) AND MC.IsDeleted = 0";
            if(RecruitmentType == "CNT")
            {
                Query = Query + " AND RecruitmentType = '{2}'";
            }

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = String.Format(Query,LoggedEmpID,LoggedUserID, RecruitmentType);

            DataTable dt = EE.ExecuteDataTable(exQry);
            Master_CandidateEXT[] DTO = new Master_CandidateEXT[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Master_CandidateEXT();

                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].TeamID = (int)dt.Rows[i]["TeamID"];
                DTO[i].CandidateType = (String)dt.Rows[i]["CandidateType"];
                DTO[i].FirstName = (String)dt.Rows[i]["FirstName"];
                DTO[i].MiddleName = (String)dt.Rows[i]["MiddleName"];
                DTO[i].LastName = (String)dt.Rows[i]["LastName"];
                DTO[i].CurrentEmployer = (String)dt.Rows[i]["CurrentEmployer"];
                DTO[i].CareerStartDate = (DateTime)dt.Rows[i]["CareerStartDate"];
                DTO[i].Experience = (String)dt.Rows[i]["Experience"];
                DTO[i].TechnologyExpertise = (String)dt.Rows[i]["TechnologyExpertise"];
                DTO[i].ContactNumber = (String)dt.Rows[i]["ContactNumber"];
                DTO[i].EmailID = (String)dt.Rows[i]["EmailID"];
                DTO[i].NoticePeriod = (int)dt.Rows[i]["NoticePeriod"];
                DTO[i].CurrentLocation = (String)dt.Rows[i]["CurrentLocation"];
                DTO[i].ReasonForChange = (String)dt.Rows[i]["ReasonForChange"];
                DTO[i].OffersInHand = (String)dt.Rows[i]["OffersInHand"];
                DTO[i].ResumeFilename = (String)dt.Rows[i]["ResumeFilename"];
                DTO[i].RecruitmentType = (String)dt.Rows[i]["RecruitmentType"];
                DTO[i].CreatedBy = (int)dt.Rows[i]["CreatedBy"];
                DTO[i].CreatedDate = (DateTime)dt.Rows[i]["CreatedDate"];
                DTO[i].ModifiedBy = (int)dt.Rows[i]["ModifiedBy"];
                DTO[i].ModifiedDate = (DateTime)dt.Rows[i]["ModifiedDate"];

                DTO[i].TeamName = (String)dt.Rows[i]["TeamName"];
                DTO[i].ManagerName = (String)dt.Rows[i]["ManagerName"];
                DTO[i].InterviewStatusID = (int)dt.Rows[i]["InterviewStatusID"];
                DTO[i].Status = (String)dt.Rows[i]["CandidateStatus"];
            }

            return DTO;
        }

        public bool IsLoggedEmpCandidateManager(int LoggedUserID, int CandidateID)
        {
            const String Qry = " IF EXISTS ( "
                            + "     SELECT * FROM Common_user WHERE ID = {0} and LoginType <> 'CNT' and EmployeeID in ( "
                            + "         SELECT ManagerID FROM Master_Candidate MC "
                            + "         INNER JOIN Master_Team MT ON MC.TeamID = MT.ID "
                            + "         WHERE MC.ID = {1} "
                            + "     ) "
                            + " )"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, LoggedUserID, CandidateID);
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }

        public bool IsCandidatealreadyExists(int ID,String FirstName, String LastName, String EmailID)
        {
            const String Qry = " ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = Qry;
            //return string.Concat(EE.ExecuteScalar(exQry)) == "0";
            return true;
        }
    }
}
