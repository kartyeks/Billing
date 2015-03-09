using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.Entity.Recruitment;
using IRCAKernel;

namespace HRManager
{
    public static class HRRecruitmentManager
    {
        #region CandidateEducation

        public static CandidateEducationDetails[] GetCandidateEducationGrid(int CandidateID)
        {
            return CandidateEducationDetails.GetEducationDetailsOfCandidate(CandidateID);
        }

        public static String DeleteCandidateEducationDetails(int TableID)
        {
            return new CandidateEducationDetails().DeleteEducationRows(TableID);
        }
        
        #endregion

        #region Candidate

        public static MasterCandidate[] GetCandidateListGrid(int LoggedEmpID, int LoggedUserID, String RType)
        {
            return MasterCandidate.GetAllCandidateData(LoggedEmpID, LoggedUserID, RType);
        }

        public static string DeleteCandidateFromGrid(int CandidateID)
        {
            return MasterCandidate.DeleteCandidate(CandidateID);
        }

        #endregion

        #region Candidate Interview Status

        public static CandidateInterviewStatus[] GetCandidateInterviewStatusGrid(int LoggedEmpId, int LoggedUserID, String RoleName)
        {
            return new CandidateInterviewStatus().GetAllCandidateInterviewStatusData(LoggedEmpId, LoggedUserID, RoleName);
        }

        public static CandidateInterviewStatus[]FillCandidateInterviewStatusWithTechnicalPanel(int ID)
        {
            return new CandidateInterviewStatus().GetAllCandidateInterviewStatusWithTechnicalPanel(ID);
        }


        public static String UpdateTechnicalPanelAssignment(int ID, int CandidateID, int TeamID, String CandidateStatus, String TechnicalPanelID
            , int UpdatedBy, String RejectionRemarks, int InterviewTypeID)
        {
            try
            {
                CandidateInterviewStatus cand = new CandidateInterviewStatus(ID);

                if (ID == 0)
                {
                    cand.CandidateID = CandidateID;
                    cand.TeamID = TeamID;
                }
                
                cand.ID = ID;
                cand.CandidateStatus = CandidateStatus;
                cand.UpdatedBy = UpdatedBy;
                cand.RejectionRemarks = RejectionRemarks;

                String Result = cand.Save();
                String Final = "";

                int ResultasInt = 0;
                Int32.TryParse(Result, out ResultasInt);
                if (ResultasInt != 0)
                {
                    new CandidateTechnicalPanel().DeleteETechnicalPanelRows(ID);
                    if (TechnicalPanelID != null)
                    {
                        String[] TPIDs = TechnicalPanelID.Split(',');
                        foreach (String TPid in TPIDs)
                        {
                            CandidateTechnicalPanel tech = new CandidateTechnicalPanel();

                            tech.ID = 0;
                            tech.CandidateInterviewStatusID = Convert.ToInt32(Result);
                            tech.TechnicalPanelID = Convert.ToInt32(TPid);
                            tech.InterviewTypeID = InterviewTypeID;

                            Final = tech.Save();
                        }
                    }
                    if(RejectionRemarks == null)
                        new RecruitmentNotification().NotifyTechnicalPanelAssignment(CandidateID, TechnicalPanelID);
                }
                return Result;
            }

            catch (Exception ee)
            {
                IRCAExceptionHandler.HandleException(ee);
                return ee.Message;
            }
        }

        public static String UpdateScheduledInterview(int ID, int CandidateID, int TeamID, String CandidateStatus, int InterviewTypeID
            , int UpdatedBy, bool IsCandidateAvailable,  DateTime Date1Time1, String Time1, DateTime Date2Time2, String Time2, String Role)
        {
            try
            {
                CandidateInterviewStatus cand = new CandidateInterviewStatus(ID);

                if (ID == 0)
                {
                    cand.CandidateID = CandidateID;
                    cand.TeamID = TeamID;
                }

                cand.ID = ID;
                cand.InterviewTypeID = InterviewTypeID;
                cand.CandidateStatus = CandidateStatus;
                DateTime dt1;
                DateTime dt2;

                if (Date1Time1.Year == 1 && Time1 == ":00")
                    dt1 = new DateTime(1900,1,1);
                else
                    dt1 = Convert.ToDateTime(Date1Time1.ToShortDateString() + ' ' + Time1);

                if (Date2Time2.Year == 1 && Time2 == ":00")
                    dt2 = new DateTime(1900, 1, 1);
                else
                    dt2 = Convert.ToDateTime(Date2Time2.ToShortDateString() + ' ' + Time2);

                cand.InterviewDateTime1 = dt1;
                cand.InterviewDateTime2 = dt2;
                cand.UpdatedBy = UpdatedBy;

                if (Role == "HR" && (CandidateStatus == CandidateStatusDescription.HRScheduled))
                {
                    // Adds or Updates a Row in Techpanel Table for Current Interview to update Interview Type when HR LogsIn //
            // The Interview schedule Grid takes Interview Type from Techpanel Table but When HR Schedules interview there is no Tech Panel Assignment //
                    // Hence Now While Scheduling, need to update Techpanel Table of Current Interview //

                    CandidateTechnicalPanel tpHR = new CandidateTechnicalPanel().GetTechnicalPanelDetByZeroTechPanel(ID);
                    tpHR.CandidateInterviewStatusID = ID;
                    tpHR.InterviewTypeID = InterviewTypeID;
                    tpHR.TechnicalPanelID = 0;
                    tpHR.Save();
                }
                else
                {
                    CandidateTechnicalPanel[] TPs = new CandidateTechnicalPanel().GetTechnicalPanelByInterviewStatusID(ID);
                    foreach (CandidateTechnicalPanel tp in TPs)
                    {
                        tp.InterviewTypeID = InterviewTypeID;
                        tp.Save();
                    }
                }

                cand.IsCandidateAvailable = IsCandidateAvailable;

                String Result = cand.Save();
                return Result;
            }

            catch (Exception ee)
            {
                IRCAExceptionHandler.HandleException(ee);
                return ee.Message;
            }
        }
  
        #endregion

        #region Candidate Interview Result

        public static CandidateInterviewResult[] GetCandidateInterviewResultGrid(int LoggedEmpId, int CandidateID)
        {
            return new CandidateInterviewResult().GetAllCandidateInterviewResultData(LoggedEmpId, CandidateID);
        }

        public static String CandidateInterviewResult(String CIRIDs, int CandidateID, String JobTitle, int InterviewerID, String StrengthandWeakness,int UpdatedBy,
            String CompetencyID, String Value1, String Value2, String Value3, String Value4, String Value5, String Value6, DateTime InterviewDate,
            String Recommendation)
        {
            try
            {
                String[] CIRIds = CIRIDs.Split(',');
                String[] Competencyarr = CompetencyID.Split(',');
                String[] Valuearr1 = Value1.Split(',');
                String[] Valuearr2 = Value2.Split(',');
                String[] Valuearr3 = Value3.Split(',');
                String[] Valuearr4 = Value4.Split(',');
                String[] Valuearr5 = Value5.Split(',');
                String[] Valuearr6 = Value6.Split(',');

                for (int t = 0; t < Competencyarr.Length; t++)
                {
                    CandidateInterviewResult cand = new CandidateInterviewResult(Convert.ToInt32(CIRIds[t]));

                    cand.CandidateID = CandidateID;
                    cand.JobTitle = JobTitle;
                    cand.InterviewerID = InterviewerID;
                    cand.InterviewDate = InterviewDate;
                    cand.StrengthandWeakness = StrengthandWeakness;
                    cand.Recommendation = Recommendation;
                    cand.UpdatedBy = UpdatedBy;

                    cand.ID = Convert.ToInt32(CIRIds[t]);
                    cand.CompetencyID = Convert.ToInt32(Competencyarr[t]);
                    cand.Value1 = Convert.ToBoolean(Valuearr1[t]);
                    cand.Value2 = Convert.ToBoolean(Valuearr2[t]);
                    cand.Value3 = Convert.ToBoolean(Valuearr3[t]);
                    cand.Value4 = Convert.ToBoolean(Valuearr4[t]);
                    cand.Value5 = Convert.ToBoolean(Valuearr5[t]);
                    cand.Value6 = Convert.ToBoolean(Valuearr6[t]);

                    cand.Save();
                }

                CandidateInterviewStatus intv = new CandidateInterviewStatus().GeInterviewStatusByCandidateID(CandidateID);
                if (intv.CandidateStatus == CandidateStatusDescription.CandidateAvail 
                || intv.CandidateStatus == CandidateStatusDescription.CandidateAvail2
                || intv.CandidateStatus == CandidateStatusDescription.CandidateAvail3)
                {
                    if (intv.CandidateStatus == CandidateStatusDescription.CandidateAvail && Recommendation == "HR")
                    {
                        intv.CandidateStatus = CandidateStatusDescription.ClearedFirst;
                    }
                    else if(intv.CandidateStatus == CandidateStatusDescription.CandidateAvail && Recommendation == "NH")
                    {
                        intv.CandidateStatus = CandidateStatusDescription.RejectFirst;
                    }
                    else if (intv.CandidateStatus == CandidateStatusDescription.CandidateAvail2 && Recommendation == "HR")
                    {
                        intv.CandidateStatus = CandidateStatusDescription.ClearedSecond;
                    }
                    else if (intv.CandidateStatus == CandidateStatusDescription.CandidateAvail2 && Recommendation == "NH")
                    {
                        intv.CandidateStatus = CandidateStatusDescription.RejectSecond;
                    }
                    else if (intv.CandidateStatus == CandidateStatusDescription.CandidateAvail3 && Recommendation == "HR")
                    {
                        intv.CandidateStatus = CandidateStatusDescription.ClearedHR;
                    }
                    else if (intv.CandidateStatus == CandidateStatusDescription.CandidateAvail3 && Recommendation == "NH")
                    {
                        intv.CandidateStatus = CandidateStatusDescription.RejectHR;
                    }

                    intv.IsCandidateAvailable = false;
                    intv.Save();
                }
                return String.Empty;
            }

            catch (Exception ee)
            {
                IRCAExceptionHandler.HandleException(ee);
                return ee.Message;
            }
        }
        
        #endregion

        #region Issue Offer

        public static CandidateHiredSalary[] GetCandidateHiredSalaryGrid()
        {
            return CandidateHiredSalary.GetAllCandidateSalaryData();
        }

        public static String UpdateCandidateSalary(int ID, int CandidateID, DateTime JoiningDate, Double CTC, int ESOP)
        {
            try
            {
                CandidateHiredSalary cand = new CandidateHiredSalary(ID);

                cand.ID = ID;
                cand.CandidateID = CandidateID;
                cand.JoiningDate = JoiningDate;
                cand.CTC = CTC;
                cand.ESOP = ESOP;

                String Result = cand.Save();
                
                if (Result == String.Empty)
                {
                    CandidateInterviewStatus intv = new CandidateInterviewStatus().GeInterviewStatusByCandidateID(CandidateID);
                    if (intv.CandidateStatus == CandidateStatusDescription.ClearedHR)
                    {
                        intv.CandidateStatus = CandidateStatusDescription.SalaryFixed;
                        String mg = intv.Save();
                        if (mg != "0")
                            return "";
                    }
                }
                return Result;
            }

            catch (Exception ee)
            {
                IRCAExceptionHandler.HandleException(ee);
                return ee.Message;
            }
        }

        public static String CheckInterviewDateInScheduleInterview(int CAndidateID, DateTime SelectedInterviewDate)
        {
            CandidateInterviewStatus intv = new CandidateInterviewStatus().GeInterviewStatusByCandidateID(CAndidateID);

            if (intv.InterviewDateTime1.Year == 1900)
            {
                if (SelectedInterviewDate.Date < intv.InterviewDateTime2.Date)
                    return "Interview Date should be greater than the second preferred date";
            }
            else if (intv.InterviewDateTime2.Year == 1900)
            {
                if (SelectedInterviewDate.Date < intv.InterviewDateTime1.Date)
                    return "Interview Date should be greater than the first preferred date";
            }
            else
            {
                if (intv.InterviewDateTime1.Date > intv.InterviewDateTime2.Date)
                {
                    if (SelectedInterviewDate.Date < intv.InterviewDateTime2.Date)
                        return "Interview Date should be greater than the second preferred date";
                    
                }
                else
                {
                    if (SelectedInterviewDate.Date < intv.InterviewDateTime1.Date)
                        return "Interview Date should be greater than the first preferred date";
                }
            }
                return "";
        }
        
        #endregion
    }
}
