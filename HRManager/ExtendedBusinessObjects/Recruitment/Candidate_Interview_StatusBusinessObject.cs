using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS91.Services.DataBlock;
using System.Data;
using HRManager.DTO;
using HRManager.DTOEXT.Recruitment;
using IRCA.Communication;

namespace HRManager.BusinessObjects
{
    public partial class Candidate_Interview_StatusBusinessObject
    {
        public Candidate_Interview_StatusEXT[] GetInterviewStatusDetails(int LoggedEmpID, int LoggedUserId,String RoleName)
        {
            String Query = " SELECT "
                            + "     Distinct "
                            + "     CIS.ID "
                            + "     ,CIS.CandidateID "
                            + "     ,CIS.TeamID "
                            + "     ,ISNULL(CIS.CandidateStatus,'') CandidateStatus"
                            + "     ,ISNULL(CTP.InterviewTypeID,0)InterviewTypeID "
                            + "     ,ISNULL(CIS.Date1Time1,'') Date1Time1"
                            + "     ,ISNULL(CIS.Date2Time2,'') Date2Time2"
                            + "     ,CIS.UpdatedBy "
                            + "     ,CIS.UpdatedDateTime "
                            + "     ,CIS.IsCandidateAvailable "
                            + "     ,(MC.FirstName + ' ' + MC.MiddleName + ' ' + MC.LastName) CandidateName "
                            + "     ,ISNULL(MT.TeamName,'') TeamName"
                            + "     ,(ME.FirstName + ' ' + ME.MiddleName + ' ' + ME.LastName) ManagerName "
                            + "     ,ISNULL(MIT.InterviewType,'') InterviewType"
                            + " FROM Candidate_Interview_Status CIS "
                            + "     INNER JOIN Master_Candidate MC ON MC.ID = CIS.CandidateID "
                            + "     INNER JOIN Master_Team MT ON MT.ID = CIS.TeamID "
                            + "     INNER JOIN Master_Employees ME ON ME.ID = MT.ManagerID "
                            + " INNER JOIN "
                            + "     ( SELECT CandidateInterviewStatusID, InterviewTypeID FROM Candidate_Technical_Panel c "
                            + "         WHERE ID =( SELECT MAX(ID) FROM Candidate_Technical_Panel "
                            + "                     WHERE CandidateInterviewStatusID = c.CandidateInterviewStatusID "
                            + "                    )  "
                            + "     )CTP ON CTP.CandidateInterviewStatusID = CIS.ID "
                            + " INNER JOIN Candidate_Technical_Panel CP ON CP.CandidateInterviewStatusID=CTP.CandidateInterviewStatusID "
                            + " AND CP.InterviewTypeID=CTP.InterviewTypeID "
                            + "     LEFT JOIN Master_Interview_Type MIT ON MIT.ID = CTP.InterviewTypeID "
                            + " Where CandidateStatus NOT IN ('RJM','RJ1','RM2','RJ2','RJ3') AND MC.IsDeleted = 0";
            if (RoleName == "Consultant")
                Query = Query + " AND MC.ModifiedBy = {1}";
            else if (RoleName != "HR")
                Query = Query + " AND (CP.TechnicalPanelID = {0} OR MC.ModifiedBy = {1})";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = String.Format(Query,LoggedEmpID, LoggedUserId);


            DataTable dt = EE.ExecuteDataTable(exQry);
            Candidate_Interview_StatusEXT[] DTO = new Candidate_Interview_StatusEXT[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Candidate_Interview_StatusEXT();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].CandidateID = (int)dt.Rows[i]["CandidateID"];
                DTO[i].TeamID = (int)dt.Rows[i]["TeamID"];
                DTO[i].CandidateStatus = (String)dt.Rows[i]["CandidateStatus"];
                DTO[i].InterviewTypeID = (int)dt.Rows[i]["InterviewTypeID"];
                DTO[i].Date1Time1 = (DateTime)dt.Rows[i]["Date1Time1"];
                DTO[i].Date2Time2 = (DateTime)dt.Rows[i]["Date2Time2"];
                DTO[i].UpdatedBy = (int)dt.Rows[i]["UpdatedBy"];
                DTO[i].UpdatedDateTime = (DateTime)dt.Rows[i]["UpdatedDateTime"];
                DTO[i].IsCandidateAvailable = (bool)dt.Rows[i]["IsCandidateAvailable"];

                DTO[i].CandidateName = (String)dt.Rows[i]["CandidateName"];
                DTO[i].TeamName = (String)dt.Rows[i]["TeamName"];
                DTO[i].ManagerName = (String)dt.Rows[i]["ManagerName"];
                DTO[i].InterviewType = (String)dt.Rows[i]["InterviewType"];
            }
            return DTO;
        }

        public ComboBoxValues[] GetInterViewerComboforCandidate(int CandidateID)
        {
            String Query = " SELECT Distinct ISNULL(ME.ID,0) EmpID"
                            + "     ,ISNULL((ME.FirstName + ' ' + ME.MiddleName + ' ' + ME.LastName),'') InterviewerName "
                            + " FROM Candidate_Interview_Status CIS "
                            + "     INNER JOIN Candidate_Technical_Panel CTP ON CTP.CandidateInterviewStatusID = CIS.ID "
                            + "     LEFT JOIN Master_Employees ME ON ME.ID = CTP.TechnicalPanelID "
                            + " WHERE CIS.CandidateID = {0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = String.Format(Query, CandidateID);

            DataTable dt = EE.ExecuteDataTable(exQry);
            ComboBoxValues[] DTO = new ComboBoxValues[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new ComboBoxValues();
                DTO[i].ID = (int)dt.Rows[i]["EmpID"];
                DTO[i].Value = (String)dt.Rows[i]["InterviewerName"];
            }
            return DTO;
        }

        public ComboBoxValues[] GetHRasCombo()
        {
            String Query = " SELECT Distinct ISNULL(ME.ID,0) EmpID"
                            + "     ,ISNULL((ME.FirstName + ' ' + ME.MiddleName + ' ' + ME.LastName),'') InterviewerName "
                            + " FROM Master_Employees ME "
                            + "     INNER JOIN Employee_OccupationDetails EOD ON ME.ID = EOD.EmployeeID "
                            + "     INNER JOIN Hr_Designation MD ON MD.ID = EOD.DesignationID "
                            + " INNER JOIN Master_Role MR ON MR.ID = MD.RoleID Where MR.Role = 'HR' AND EOD.IsActive = 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = Query;

            DataTable dt = EE.ExecuteDataTable(exQry);
            ComboBoxValues[] DTO = new ComboBoxValues[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new ComboBoxValues();
                DTO[i].ID = (int)dt.Rows[i]["EmpID"];
                DTO[i].Value = (String)dt.Rows[i]["InterviewerName"];
            }
            return DTO;
        }

        public Candidate_Interview_StatusEXT[] GetInterviewStatusandTechnicalPanel(int CandidateInterviewStatusID)
        {
            String Query = " SELECT CIS.*"
                           + "      ,ISNULL(CTP.TechnicalPanelID,0) TechnicalPanelID "
                           + "      ,ISNULL((ME.FirstName + ' ' + ME.MiddleName + ' ' + ME.LastName),'') EmpName "
                           + "      ,ISNULL(CTP.InterviewTypeID,0) LatestInterviewTypeID "
                           + "      ,ISNULL(MIT.InterviewType,'') InterviewType"
                           + " FROM Candidate_Interview_Status CIS "
                           + "     LEFT JOIN Candidate_Technical_Panel CTP ON CTP.CandidateInterviewStatusID = CIS.ID "
                           + " LEFT JOIN Master_Employees ME ON ME.ID = CTP.TechnicalPanelID "
                           + " LEFT JOIN Master_Interview_type MIT ON MIT.ID = CTP.InterviewTypeID "
                           + " WHERE CIS.ID = {0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = String.Format(Query, CandidateInterviewStatusID) ;

            DataTable dt = EE.ExecuteDataTable(exQry);

            Candidate_Interview_StatusEXT[] DTO = new Candidate_Interview_StatusEXT[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Candidate_Interview_StatusEXT();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].CandidateID = (int)dt.Rows[i]["CandidateID"];
                DTO[i].TeamID = (int)dt.Rows[i]["TeamID"];
                DTO[i].CandidateStatus = (String)dt.Rows[i]["CandidateStatus"];
                DTO[i].InterviewTypeID = (int)dt.Rows[i]["LatestInterviewTypeID"];
                DTO[i].Date1Time1 = (DateTime)dt.Rows[i]["Date1Time1"];
                DTO[i].Date2Time2 = (DateTime)dt.Rows[i]["Date2Time2"];
                DTO[i].UpdatedBy = (int)dt.Rows[i]["UpdatedBy"];
                DTO[i].UpdatedDateTime = (DateTime)dt.Rows[i]["UpdatedDateTime"];
                DTO[i].IsCandidateAvailable = (bool)dt.Rows[i]["IsCandidateAvailable"];
                DTO[i].RejectionRemarks = (String)dt.Rows[i]["RejectionRemarks"];

                DTO[i].TechnicalPanelId = (int)dt.Rows[i]["TechnicalPanelID"];
                DTO[i].InterviewType = (String)dt.Rows[i]["InterviewType"];
                DTO[i].TechPanelName = (String)dt.Rows[i]["EmpName"];

            }
            return DTO;
        }

        public bool IsLoggedEmpinTechnicalPanel(int ID, int LoggedEmpID, String LogRecType, String RoleName, int LoggedUserID)
        {
// 1 Qry, Check if logged Employee is in Technical Panel, if true then display "SCHEDULE INTERVIEW &  UPDATE RESULT button. //
            String AdditionOnEmpLogin = " AND RecruitmentType = 'EMP'";
            const String Qry = " IF EXISTS (SELECT * FROM Candidate_Interview_Status CIS "
                                + "     INNER JOIN Candidate_Technical_Panel CTP ON CIS.ID = CTP.CandidateInterviewStatusID "
                                + "     LEFT JOIN Master_Candidate MC ON MC.ID = CIS.CandidateID"
                                + " WHERE CIS.ID = {0} AND TechnicalPanelID = {1} {2} )"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

// 2nd Qry, check if logged user is HR, if true check is he the canididate creator, if false then display "SCHEDULE INTERVIEW &  UPDATE RESULT button. //  
            String QryHR = "IF EXISTS (SELECT * FROM Candidate_Interview_Status CIS "
                                + "     INNER JOIN Master_Candidate MC ON MC.ID = CIS.CandidateID"
                                + " WHERE CIS.ID = {0} AND MC.CreatedBy = {1} )"
                                + " SELECT 1"
                                + " ELSE"
                                + " SELECT 0";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            if (LogRecType == "EMP")
            {
                if( RoleName == "HR")
                    exQry.Query = string.Format(QryHR, ID, LoggedUserID);
                else
                    exQry.Query = string.Format(Qry, ID, LoggedEmpID, String.Empty);
            }
            else
                exQry.Query = string.Format(Qry, ID, LoggedEmpID, AdditionOnEmpLogin);

            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }

        public Candidate_Interview_Status GetInterviewStatusDetailsByCandID(int CandidateID)
        {
            String Query = " SELECT * "                           
                            + " FROM Candidate_Interview_Status CIS "                            
                            + " Where CandidateID = {0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = String.Format(Query, CandidateID);


            DataTable dt = EE.ExecuteDataTable(exQry);
            Candidate_Interview_Status DTO = new Candidate_Interview_Status();

            if (dt.Rows.Count > 0)
            {
                DTO.ID = (int)dt.Rows[0]["ID"];
                DTO.CandidateID = (int)dt.Rows[0]["CandidateID"];
                DTO.TeamID = (int)dt.Rows[0]["TeamID"];
                DTO.CandidateStatus = (String)dt.Rows[0]["CandidateStatus"];
                DTO.Date1Time1 = (DateTime)dt.Rows[0]["Date1Time1"];
                DTO.Date2Time2 = (DateTime)dt.Rows[0]["Date2Time2"];
                DTO.UpdatedBy = (int)dt.Rows[0]["UpdatedBy"];
                DTO.UpdatedDateTime = (DateTime)dt.Rows[0]["UpdatedDateTime"];
                DTO.IsCandidateAvailable = (bool)dt.Rows[0]["IsCandidateAvailable"];
                DTO.RejectionRemarks = (String)dt.Rows[0]["RejectionRemarks"];

                return DTO;
            }
            else return null;            
        }
    }
}
