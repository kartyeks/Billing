using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRCAKernel;
using IRCA.Communication;
using HRManager.Entity.Recruitment;
using HRManager;
using HRManager.Communication.Request;
using HRManager.BusinessObjects;

namespace HRManager
{
    public class HRRecruitmentRequestHandler : IRCARequestHandler
    {
        public override string[] GetCommands()
        {
            if (_Commands.ContainsKey(typeof(RecruitmentAppCommands).Name))
            {
                return _Commands[typeof(RecruitmentAppCommands).Name].ToArray();
            }

            return new String[0];
        }

        public override CommunicationObject ProcessRequest(string RequestCommand, string RequestData)
        {

            CommunicationObject Response = null;
            CommunicationObject RequestDataObject = new CommunicationObject(RequestData);

            try
            {
                if (RequestCommand == RecruitmentAppCommands.GET_CANDIDATE_EDUCATION)
                {
                    Response = GetCandidateEducationGrid(RequestDataObject);
                }
                else if (RequestCommand == RecruitmentAppCommands.GET_CANDIDATE_DETAILS)
                {
                    Response = GetCandidateDetailsGrid(RequestDataObject);
                }
                else if (RequestCommand == RecruitmentAppCommands.GET_CANDIDATE_DETAILS_BY_ID)
                {
                    Response = GetCandidateDetailsByID(RequestDataObject);
                }
                else if (RequestCommand == RecruitmentAppCommands.DELETE_CANDIDATE_EDUCATION)
                {
                    Response = DeleteCandidateEducationGrid(RequestDataObject);
                }
                else if (RequestCommand == RecruitmentAppCommands.GET_INTERVIEW_STATUS_GRID)
                {
                    Response = GetCandidateinterviewStatusGrid(RequestDataObject);
                }
                else if (RequestCommand == RecruitmentAppCommands.UPDATE_INTERVIEW_STATUS)
                {
                    Response = UpdateTechnicalPanelorRejectionRemarks(RequestDataObject);
                }
                else if (RequestCommand == RecruitmentAppCommands.GET_INTERVIEW_RESULT_GRID)
                {
                    Response = GetCandidateinterviewResultGrid(RequestDataObject);
                }
                else if (RequestCommand == RecruitmentAppCommands.GET_INTERVIEW_COMBO_FOR_CANDIDATE)
                {
                    Response = GetCandidateinterviewerCombo(RequestDataObject);
                }
                else if (RequestCommand == RecruitmentAppCommands.GET_HR_COMBO)
                {
                    Response = GetHRCombo(RequestDataObject);
                }
                else if (RequestCommand == RecruitmentAppCommands.UPDATE_INTERVIEW_RESULT)
                {
                    Response = UpdateCandidateInterviewResult(RequestDataObject);
                }
                else if (RequestCommand == RecruitmentAppCommands.CHECK_LOGGED_EMP_ISCANDIDATE_MANAGER)
                {
                    Response = CheckIsLoggedEmpCandidateManager(RequestDataObject);
                }
                else if (RequestCommand == RecruitmentAppCommands.INTERVIEW_STATUS_DET_WITH_TECHNICAL_PANEL)
                {
                    Response = GetCandidateinterviewStatuswithTechnicalPanel(RequestDataObject);
                }
                else if (RequestCommand == RecruitmentAppCommands.CHECK_LOGGED_EMP_IN_TECHNICAL_PANEL)
                {
                    Response = CheckIsLoggedEmpinTechnicalPanel(RequestDataObject);
                }
                else if (RequestCommand == RecruitmentAppCommands.UPDATE_INTERVIEW_SCHEDULED_STATUS)
                {
                    Response = UpdateScheduledInterviewStatus(RequestDataObject);
                }
                else if (RequestCommand == RecruitmentAppCommands.UPDATE_AVAILABILITY_STATUS)
                {
                    Response = UpdateAvailabilityStatus(RequestDataObject);
                }    
                else if (RequestCommand == RecruitmentAppCommands.GET_HIRED_CANDIDATE_GRID)
                {
                    Response = GetHiredCandidateSalaryGrid(RequestDataObject);
                }
                else if (RequestCommand == RecruitmentAppCommands.TECH_PANEL_BY_INTERVIEWTYPE)
                {
                    Response = GetTechPanelForInterviewTypeID(RequestDataObject);
                }
                else if (RequestCommand == RecruitmentAppCommands.UPDATE_CANDIDATE_SALARY)
                {
                    Response = UpdateCandidateSalary(RequestDataObject);
                }
                else if (RequestCommand == RecruitmentAppCommands.NOTIFY_MANAGER_APP_REJ)
                {
                    Response = NotifyManagerApporRej(RequestDataObject);
                }
                else if (RequestCommand == RecruitmentAppCommands.NOTIFY_PREFFERED_DATETIME)
                {
                    Response = NotifyPrefferedDateTime(RequestDataObject);
                }
                else if (RequestCommand == RecruitmentAppCommands.NOTIFY_CANDIDATE_AVAILABILITY)
                {
                    Response = NotifyCandidateAvailability(RequestDataObject);
                }
                else if (RequestCommand == RecruitmentAppCommands.NOTIFY_INTERVIEW_RESULT)
                {
                    Response = NotifyInterviewResult(RequestDataObject);
                }
                else if (RequestCommand == RecruitmentAppCommands.INTERVIEW_DATE_VALIDATE)
                {
                    Response = InterviewDateValidate(RequestDataObject);
                }
                else if (RequestCommand == RecruitmentAppCommands.DELETE_CANDIDATE)
                {
                    Response = EnableCandidateIsDeleted(RequestDataObject);
                }
                else if (RequestCommand == RecruitmentAppCommands.INTERVIEWTYPE_COMBO_BY_STATUSID)
                {
                    Response = GetInterviewTypeComboForAllRounds(RequestDataObject);
                }
            }
            catch (IRCAException ex)
            {
                IRCAExceptionHandler.HandleException(ex);
            }
            catch (Exception ex)
            {
                Response = new CommunicationObject();
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, "Unknown Application Error");

                IRCAException Exception = new IRCAException(ex, WebResponse.Message, "Request Command = " + RequestCommand + "\n Request Data " + RequestData);

                IRCAExceptionHandler.HandleException(Exception);
            }

            return Response;
        }

        #region Candidate Education

        private CommunicationObject GetCandidateEducationGrid(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            CandidateEducationDetails[] data = HRRecruitmentManager.GetCandidateEducationGrid(Convert.ToInt32(Request.ID));

            JGridObjectBuilder Builder = new JGridObjectBuilder("LocalGridID", typeof(CandidateEducationDetails));

            Builder.AddRow(data);

            if (data != null || data.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }
            return Response;
        }

        private CommunicationObject DeleteCandidateEducationGrid(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String data = HRRecruitmentManager.DeleteCandidateEducationDetails(Convert.ToInt32(Request.ID));

            if (!data.Contains("0"))
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
            else
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);

            Response.SetProperty(WebResponse.Message, String.Empty);

            return Response;
        }

        #endregion

        #region Candidate Dashboard

        private CommunicationObject GetCandidateDetailsGrid(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            CandidateGridReq Request = new CandidateGridReq();

            RequestDataObject.UpdateDataObject(Request);

            MasterCandidate[] data = HRRecruitmentManager.GetCandidateListGrid(Request.LoggedEmpID, Request.LoggedUserID, Request.RecruitmentLoggerType);

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(CandidateGridDiaplay));

            Builder.AddRow(data);

            if (data != null || data.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }
            return Response;
        }

        private CommunicationObject GetCandidateDetailsByID(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            object obj = new MasterCandidate(Convert.ToInt32(Request.ID)).GetGridData();
            CandidateGridDiaplay data = (CandidateGridDiaplay)obj;

            if (data != null)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, data);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }
            return Response;
        }

        private CommunicationObject CheckIsLoggedEmpCandidateManager(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            bool data = new Master_CandidateBusinessObject().IsLoggedEmpCandidateManager(Convert.ToInt32(Request.ID), Request.ChangedBy);

            if (data != null)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, data);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }
            return Response;
        }

        private CommunicationObject EnableCandidateIsDeleted(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String data =  HRRecruitmentManager.DeleteCandidateFromGrid(Convert.ToInt32(Request.ID));

            if (data != null)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, "Candidate deleted successfully");
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, "Error on processing Deletion Request");
            }
            return Response;
        }

        #endregion

        #region Candidate Interview Status

        private CommunicationObject GetCandidateinterviewStatusGrid(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            CandidateGridReq Request = new CandidateGridReq();

            RequestDataObject.UpdateDataObject(Request);

            CandidateInterviewStatus[] data = HRRecruitmentManager.GetCandidateInterviewStatusGrid(Request.LoggedEmpID, Request.LoggedUserID, Request.RoleName);

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(InterviewStatusDisplay));

            Builder.AddRow(data);

            if (data != null || data.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }
            return Response;
        }

        private CommunicationObject GetCandidateinterviewStatuswithTechnicalPanel(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            CandidateInterviewStatus[] data = HRRecruitmentManager.FillCandidateInterviewStatusWithTechnicalPanel(Convert.ToInt32(Request.ID));

            if (data != null || data.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, data);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }
            return Response;
        }

        private CommunicationObject UpdateTechnicalPanelorRejectionRemarks(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateInterviewStatus Request = new UpdateInterviewStatus();

            RequestDataObject.UpdateDataObject(Request);

            String data = HRRecruitmentManager.UpdateTechnicalPanelAssignment(Request.ID, Request.CandidateID, Request.TeamID, Request.CandidateStatus
                , Request.TechnicalPanelIDs, Request.UpdatedBy,Request.RejectionRemarks, Request.InterviewTypeID);

            if (data != String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.CandidateStatus == CandidateStatusDescription.ManagerApprove
                    || Request.CandidateStatus == CandidateStatusDescription.ManagerApprove2)
                {
                    Response.SetProperty(WebResponse.Message, "Candidate Approved successfully");
                }
                else if (Request.CandidateStatus == CandidateStatusDescription.ManagerReject
                    || Request.CandidateStatus == CandidateStatusDescription.ManagerReject2)
                {
                    Response.SetProperty(WebResponse.Message, "Candidate Rejected successfully");
                }
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }
            return Response;
        }

        private CommunicationObject CheckIsLoggedEmpinTechnicalPanel(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            BeforeLogCheckReq Request = new BeforeLogCheckReq();

            RequestDataObject.UpdateDataObject(Request);

            bool data = new Candidate_Interview_StatusBusinessObject().IsLoggedEmpinTechnicalPanel(Request.ID, Request.LoggedEmpID, Request.RecruitmentLoggerType, Request.RoleName, Request.LoggedUserID);

            //if (Request.RoleName == "HR")
            //    data = true;

            if (data != null)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, data);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }
            return Response;
        }

        private CommunicationObject UpdateScheduledInterviewStatus(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateInterviewStatus Request = new UpdateInterviewStatus();

            RequestDataObject.UpdateDataObject(Request);

            String data = HRRecruitmentManager.UpdateScheduledInterview(Request.ID, Request.CandidateID, Request.TeamID, Request.CandidateStatus
                , Request.InterviewTypeID, Request.UpdatedBy, Request.IsCandidateAvail, Request.Date1Time1, Request.Time1, Request.Date2Time2
                , Request.Time2, Request.RoleName);


            int Res = 0;
            Int32.TryParse(data, out Res);
            if (Res != 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, "Candidate Interview Scheduled successfully");
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }
            return Response;
        }

        private CommunicationObject UpdateAvailabilityStatus(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateInterviewStatus Request = new UpdateInterviewStatus();

            RequestDataObject.UpdateDataObject(Request);

            String data = HRRecruitmentManager.UpdateScheduledInterview(Request.ID, Request.CandidateID, Request.TeamID, Request.CandidateStatus
                , Request.InterviewTypeID, Request.UpdatedBy, Request.IsCandidateAvail, Request.Date1Time1, Request.Time1, Request.Date2Time2
                , Request.Time2, Request.RoleName);

            int Res = 0;
            Int32.TryParse(data, out Res);
            if (Res != 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, "Candidate Availability status Changed successfully");
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }
            return Response;
        }

        private CommunicationObject GetTechPanelForInterviewTypeID(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            int[] data = new Candidate_Technical_PanelBusinessObject().GetTechnicalPanelIDForInterviewType(Convert.ToInt32(Request.ID), Request.ChangedBy);

            if (data != null)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, data);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }
            return Response;
        }

        private static CommunicationObject GetInterviewTypeComboForAllRounds(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            ComboBoxValues[] combo = new Candidate_Technical_PanelBusinessObject().GetInterviewTypeComboForDifferentRound(Convert.ToInt32(Request.ID));

            if (combo != null && combo.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, combo);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
            }

            return Response;
        }

        #endregion

        #region Candidate Interview Result

        private CommunicationObject GetCandidateinterviewResultGrid(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            CandidateInterviewResult[] data = HRRecruitmentManager.GetCandidateInterviewResultGrid(Convert.ToInt32(Request.ID), Request.ChangedBy);

            JGridObjectBuilder Builder = new JGridObjectBuilder("MCCID", typeof(InterviewResultDisplay));

            Builder.AddRow(data);

            if (data != null && data.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }
            return Response;
        }

        private static CommunicationObject GetCandidateinterviewerCombo(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            ComboBoxValues[] combo = new Candidate_Interview_StatusBusinessObject().GetInterViewerComboforCandidate(Convert.ToInt32(Request.ID));

            if (combo != null && combo.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, combo);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
            }

            return Response;
        }

        private static CommunicationObject GetHRCombo(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            ComboBoxValues[] combo = new Candidate_Interview_StatusBusinessObject().GetHRasCombo();

            if (combo != null && combo.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, combo);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
            }

            return Response;
        }

        private static CommunicationObject UpdateCandidateInterviewResult(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateInterviewResult Request = new UpdateInterviewResult();

            RequestDataObject.UpdateDataObject(Request);

            String data = HRRecruitmentManager.CandidateInterviewResult(Request.CIRID, Request.CandidateID, Request.JobTitle, Request.InterviewerID
                ,Request.StrengthandWeakness,Request.UpdatedBy,Request.CompetencyID,Request.Value1,Request.Value2,Request.Value3,Request.Value4
                ,Request.Value5,Request.Value6, Request.InterviewDate, Request.Recommendation);

            if (data == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, "Candidate Interview Result updated successfully");
            }
            else
            {
                Response.SetProperty(WebResponse.Message, "");
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
            }

            return Response;
        }
        
        #endregion

        #region Issue Offer

        private CommunicationObject GetHiredCandidateSalaryGrid(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            //EntityRequest Request = new EntityRequest();

            //RequestDataObject.UpdateDataObject(Request);

            CandidateHiredSalary[] data = HRRecruitmentManager.GetCandidateHiredSalaryGrid();

            JGridObjectBuilder Builder = new JGridObjectBuilder("CandidateID", typeof(CandidateHiredSalaryGrid));

            Builder.AddRow(data);

            if (data != null || data.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }
            return Response;
        }

        private static CommunicationObject UpdateCandidateSalary(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateCandidateSalaryReq Request = new UpdateCandidateSalaryReq();

            RequestDataObject.UpdateDataObject(Request);

            String data = HRRecruitmentManager.UpdateCandidateSalary(Request.ID, Request.CandidateID, Request.JoiningDate, Request.CTC, Request.ESOP);

            if (data == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if(Request.ID == 0)
                    Response.SetProperty(WebResponse.Message, "Candidate Salary added succesfully");
                else
                    Response.SetProperty(WebResponse.Message, "Candidate Salary updated succesfully");
            }
            else
            {
                Response.SetProperty(WebResponse.Message, "");
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
            }

            return Response;
        }

        private static CommunicationObject InterviewDateValidate(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            InterviewDateCheck Request = new InterviewDateCheck();

            RequestDataObject.UpdateDataObject(Request);

            String data = HRRecruitmentManager.CheckInterviewDateInScheduleInterview(Request.CanidateID, Request.InterviewDateFromPage);

            if (data == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
            }

            Response.SetProperty(WebResponse.Message, data);
            return Response;
        }
        
        #endregion

        #region Notification

        private static CommunicationObject NotifyManagerApporRej(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            ManagerApporRejRequest Request = new ManagerApporRejRequest();

            RequestDataObject.UpdateDataObject(Request);

            String data = new RecruitmentNotification().NotifyApproveoRejectByManager(Request.CandidateID, Request.SelectionType, Request.ResumePath);

            if (data == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, " and notified");
            }
            else
            {
                Response.SetProperty(WebResponse.Message, "");
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
            }

            return Response;
        }

        private static CommunicationObject NotifyPrefferedDateTime(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            PrefferedDateTime Request = new PrefferedDateTime();

            RequestDataObject.UpdateDataObject(Request);

            int ManagerID = (HRManager.GetAllTeamDetailsByID(Request.ManagerID))[0].ManagerID;

            String data = new RecruitmentNotification().NotifyDateTimeScheduled(Request.InterviewStatusID, ManagerID, Request.RoleName, Request.InterviewTypeID);

            if (data == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, "Candidate Interview schedule notification done successfully");
            }
            else
            {
                Response.SetProperty(WebResponse.Message, "");
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
            }

            return Response;
        }

        private static CommunicationObject NotifyCandidateAvailability(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            CandidateAvailability Request = new CandidateAvailability();

            RequestDataObject.UpdateDataObject(Request);

            int ManagerID = (HRManager.GetAllTeamDetailsByID(Request.ManagerID))[0].ManagerID;

            String data = new RecruitmentNotification().NotifyCAndidateAvailability(Request.InterviewStatusID, ManagerID, Request.IsCandAvail, Request.InterviewTypeID, Request.Role);

            if (data == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, "Candidate availabiliy notification done successfully");
            }
            else
            {
                Response.SetProperty(WebResponse.Message, "");
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
            }

            return Response;
        }

        private static CommunicationObject NotifyInterviewResult(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            InterviewResultUpdate Request = new InterviewResultUpdate();

            RequestDataObject.UpdateDataObject(Request);

            String data = new RecruitmentNotification().CandidateSelectionUpdate(Request.CandidateID, Request.Role);

            if (data == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, "Candidate Interview Result notified successfully");
            }
            else
            {
                Response.SetProperty(WebResponse.Message, "");
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
            }

            return Response;
        }
        
        #endregion
    }
}
