using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.Entity.EmployeesInfo;
using HRManager.BusinessObjects;
using IRCAKernel;
using CommonManager.Entity;
using HRManager.DTO;
using System.Data;

namespace HRManager.Entity.Recruitment
{
    public class RecruitmentNotification
    {
        String HRMailID = new Appraisal_EmployeeBusinessObject().GetHRManagerComplete().PersonalEmailID;
        String HRName = new Appraisal_EmployeeBusinessObject().GetHRManagerComplete().FirstName
                    + ' ' + new Appraisal_EmployeeBusinessObject().GetHRManagerComplete().MiddleName
                    + ' ' + new Appraisal_EmployeeBusinessObject().GetHRManagerComplete().LastName;

        public String CandidateCreationNotify(int CandidateID, int ManagerID, String LoginType, String RoleName)
        {
            try
            {

                MasterCandidate mc = new MasterCandidate(CandidateID);
                User us = new User(mc.CreatedBy);

                String ManagerMailID = new Employee(ManagerID).OccupationInfo.EmailID;
                String ManagerName = new Employee(ManagerID).PersonalInfo.FirstName + " " + new Employee(ManagerID).PersonalInfo.MiddleName + " " + new Employee(ManagerID).PersonalInfo.LastName;
                
                String filpath = AppDomain.CurrentDomain.BaseDirectory + "/Recruitment/Templates/To manager,HR_Candidate details.htm";
                StringBuilder sb = new StringBuilder(System.IO.File.ReadAllText(filpath));

                if (LoginType == "CNT")
                {
                    String ConsultantName = new ConsultantEntity(us.EmployeeID).ConsultantName;
                    sb = sb.Replace("{!LoginType}", "Consultant");
                    sb = sb.Replace("{!CreaterName}", ConsultantName);
                }
                else if (LoginType == "EMP")
                {
                    String EmpName = new Employee(us.EmployeeID).PersonalInfo.FirstName + " " + new Employee(us.EmployeeID).PersonalInfo.MiddleName + " " + new Employee(us.EmployeeID).PersonalInfo.LastName;
                    sb = sb.Replace("{!LoginType}", "Employee");
                    sb = sb.Replace("{!CreaterName}", EmpName);
                }
                
                if (ManagerMailID != "")
                {
                    MailContent mail = new MailContent();
                    mail.AddToAddress(ManagerMailID);
                    mail.FromAddress = "noreply@ircaindia.com";
                    mail.Subject = "Candidate Created Notification";
                    sb = sb.Replace("{!ManagerORHR}", ManagerName);
                    mail.Body = sb.ToString();
                    IRCAMailHandler.SendMail(mail);
                }
                if (RoleName != "HR" && HRMailID != "")
                {
                    MailContent mail1 = new MailContent();
                    mail1.AddToAddress(HRMailID);
                    mail1.FromAddress = "noreply@ircaindia.com";
                    mail1.Subject = "Candidate Created Notification";
                    sb = sb.Replace(ManagerName, HRName);
                    mail1.Body = sb.ToString();
                    IRCAMailHandler.SendMail(mail1);
                }
                return "";
            }
            catch (Exception w)
            {
                IRCAExceptionHandler.HandleException(w);
                return w.Message;
            }
        }

        public String NotifyApproveoRejectByManager(int CandidateID, String SelectionType, String ResumePath)
        {
            try
            {
                String filpath = "";
                String EmpEmail = "";
                String EmpName = "";
                MasterCandidate mc = new MasterCandidate(CandidateID);
                User us = new User(mc.CreatedBy);
                MailContent mail = new MailContent();

                if (SelectionType == "Approve")
                {
                    filpath = AppDomain.CurrentDomain.BaseDirectory + "/Recruitment/Templates/Candidateshotlisted_toHR,consultant.htm";
                    mail.Subject = "Manager Approval Notification";
                }
                else
                {
                    filpath = AppDomain.CurrentDomain.BaseDirectory + "/Recruitment/Templates/Candidaterejected_toHR,consultant.htm";
                    mail.Subject = "Manager Rejection Notification";
                }

                StringBuilder sb = new StringBuilder(System.IO.File.ReadAllText(filpath));
                CandidateInterviewStatus cs = new CandidateInterviewStatus().GeInterviewStatusByCandidateID(CandidateID);

                if (SelectionType != "Approve")
                    sb = sb.Replace("{!Reason}", cs.RejectionRemarks);

                sb = sb.Replace("{!CandidateName}", mc.FirstName + " " + mc.MiddleName + " " + mc.LastName);

                mail.FromAddress = "noreply@ircaindia.com";
                
                if (mc.RecruitmentType == "CNT" && new ConsultantEntity(us.EmployeeID).EmailID != "")
                {
                    String ConsultantName = new ConsultantEntity(us.EmployeeID).ConsultantName;
                    mail.AddToAddress(new ConsultantEntity(us.EmployeeID).EmailID);
                    sb = sb.Replace("{!ToName}", ConsultantName);
                    mail.Body = sb.ToString();
                    IRCAMailHandler.SendMail(mail);
                }
                else if (mc.RecruitmentType == "EMP" && new Employee(us.EmployeeID).OccupationInfo.EmailID != "")
                {
                    EmpName = new Employee(us.EmployeeID).PersonalInfo.FirstName + " " + new Employee(us.EmployeeID).PersonalInfo.MiddleName + " " + new Employee(us.EmployeeID).PersonalInfo.LastName;
                    EmpEmail = new Employee(us.EmployeeID).OccupationInfo.EmailID;
                    mail.AddToAddress(EmpEmail);
                    sb = sb.Replace("{!ToName}", EmpName);
                    mail.Body = sb.ToString();
                    IRCAMailHandler.SendMail(mail);
                }

                if (HRMailID != "" && HRName != EmpName && HRMailID != EmpEmail)
                {
                    StringBuilder sb1 = new StringBuilder(System.IO.File.ReadAllText(filpath));
                    sb1 = sb1.Replace("{!CandidateName}", mc.FirstName + " " + mc.MiddleName + " " + mc.LastName);

                    MailContent mail1 = new MailContent();
                    mail1.AddToAddress(HRMailID);
                    mail1.FromAddress = "noreply@ircaindia.com";

                    if (SelectionType == "Approve")
                        mail1.Subject = "Manager Approval Notification";
                    else
                    {
                        mail1.Subject = "Manager Rejection Notification";
                        sb1 = sb1.Replace("{!Reason}", cs.RejectionRemarks);
                    }
                    
                    sb1 = sb1.Replace("{!ToName}", HRName);
                    mail1.Body = sb1.ToString();
                    IRCAMailHandler.SendMail(mail1);
                }
                //mail.AddAttachment(System.IO.File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + ResumePath), "Candidate Resume", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
                return "";
            }
            catch (Exception w)
            {
                IRCAExceptionHandler.HandleException(w);
                return w.Message;
            }
        }

        public String NotifyTechnicalPanelAssignment(int CandidateID, String TechPanel)
        {
            try
            {
                MasterCandidate mc = new MasterCandidate(CandidateID);
                User us = new User(mc.CreatedBy);
                String TechMem = "";
                String filpath = AppDomain.CurrentDomain.BaseDirectory + "/Recruitment/Templates/AssignTEchpanel_toTechpanel,HR.htm";
                
                MailContent mail = new MailContent();
                mail.FromAddress = "noreply@ircaindia.com";
                mail.Subject = "Technical panel Assignement";

                if (TechPanel != null)
                {
                    String[] TPIDs = TechPanel.Split(',');
                    foreach (String TPid in TPIDs)
                    {
                        StringBuilder sb = new StringBuilder(System.IO.File.ReadAllText(filpath));
                        Employee emp = new Employee(Convert.ToInt32(TPid));
                        mail.AddToAddress(emp.OccupationInfo.EmailID);
                        String TechMemName = emp.PersonalInfo.FirstName + " " + emp.PersonalInfo.MiddleName + " " + emp.PersonalInfo.LastName;
                        sb = sb.Replace("{!TechPanelName}", TechMemName);
                        if (TechMem == "")
                            TechMem = TechMemName;
                        else
                            TechMem = TechMem + ',' + TechMemName;
                        mail.Body = sb.ToString();
                        IRCAMailHandler.SendMail(mail);
                    }
                }

                filpath = AppDomain.CurrentDomain.BaseDirectory + "/Recruitment/Templates/AssignTEchpanel_toHR.htm";
                StringBuilder sb1 = new StringBuilder(System.IO.File.ReadAllText(filpath));
                sb1 = sb1.Replace("{!HRName}", HRName);
                sb1 = sb1.Replace("{!TechpanelMem}", TechMem);
                MailContent mail1 = new MailContent();
                mail1.FromAddress = "noreply@ircaindia.com";
                mail1.Subject = "Technical panel Assignement";
                mail1.AddToAddress(HRMailID);
                mail1.Body = sb1.ToString();
                IRCAMailHandler.SendMail(mail1);

                return "";
            }
            catch (Exception w)
            {
                IRCAExceptionHandler.HandleException(w);
                return w.Message;
            }
        }

        public String NotifyDateTimeScheduled(int ScheduleInterviewID, int ManagerID, String Role, int InterviewTypeID)
        {
            try
            {
                String ManagerMailID = new Employee(ManagerID).OccupationInfo.EmailID;
                String ManagerName = new Employee(ManagerID).PersonalInfo.FirstName + " " + new Employee(ManagerID).PersonalInfo.MiddleName + " " + new Employee(ManagerID).PersonalInfo.LastName;
                CandidateInterviewStatus sts = new CandidateInterviewStatus(ScheduleInterviewID);
                MasterCandidate mc = new MasterCandidate(sts.CandidateID);
                CandidateTechnicalPanel[] tp = new CandidateTechnicalPanel().GetTechnicalPanelDetByInterviewStatusAndTypeID(InterviewTypeID,ScheduleInterviewID);
                User us = new User(mc.CreatedBy);
                InterView_Type itype = null;
                String filpath = AppDomain.CurrentDomain.BaseDirectory + "/Recruitment/Templates/MailtoCOnsultantManagerHR_byTechPanel.htm";
                StringBuilder sb = new StringBuilder(System.IO.File.ReadAllText(filpath));

                MailContent mail = new MailContent();
                String TechPanelName = "";
                if (tp != null)
                {
                    TechPanelName = new Employee(tp[0].TechnicalPanelID).PersonalInfo.FirstName
                                + " " + new Employee(tp[0].TechnicalPanelID).PersonalInfo.MiddleName
                                + " " + new Employee(tp[0].TechnicalPanelID).PersonalInfo.LastName;
                    for (int g = 1; g < tp.Length; g++)
                    {
                        TechPanelName = TechPanelName + "," + new Employee(tp[g].TechnicalPanelID).PersonalInfo.FirstName
                                + " " + new Employee(tp[g].TechnicalPanelID).PersonalInfo.MiddleName
                                + " " + new Employee(tp[g].TechnicalPanelID).PersonalInfo.LastName;
                    }
                }
                if (sts.InterviewTypeID == 0)
                    itype = new InterView_Type(InterviewTypeID);
                else
                    itype = new InterView_Type(sts.InterviewTypeID);

                String CandidateName = new MasterCandidate(sts.CandidateID).FirstName + " " + new MasterCandidate(sts.CandidateID).MiddleName + " " + new MasterCandidate(sts.CandidateID).LastName;
                String Date1 = ""; String Time1 = ""; String Date2 = ""; String Time2 = "";
                if (sts.InterviewDateTime1.Year == 1 || sts.InterviewDateTime1.Year == 1900)
                    Date1 = "";
                else
                    Date1 = sts.InterviewDateTime1.ToString("dd/MM/yyyy");

                if (sts.InterviewDateTime1.Hour == 0)
                    Time1 = "";
                else
                    Time1 = sts.InterviewDateTime1.ToString("HH:mm");

                if (sts.InterviewDateTime2.Year == 1 || sts.InterviewDateTime2.Year == 1900)
                    Date2 = "";
                else
                    Date2 = sts.InterviewDateTime2.ToString("dd/MM/yyyy");

                if (sts.InterviewDateTime2.Hour == 0)
                    Time2 = "";
                else
                    Time2 = sts.InterviewDateTime2.ToString("HH:mm");

                if(TechPanelName.Trim() == String.Empty)
                    sb = sb.Replace("{!TechpanelName}", HRName);
                else
                    sb = sb.Replace("{!TechpanelName}", TechPanelName);

                sb = sb.Replace("{!CandidateName}", CandidateName);
                sb = sb.Replace("{!Date1}", Date1);
                sb = sb.Replace("{!Time1}", Time1);
                sb = sb.Replace("{!Date2}", Date2);
                sb = sb.Replace("{!Time2}", Time2);

                if (itype != null)
                    sb = sb.Replace("{!InterviewType}", itype.InterviewType);

                String EmpEmail = "";
                String EmpName = "";

                if (new MasterCandidate(sts.CandidateID).RecruitmentType == "CNT")
                {
                    String ConsultantName = new ConsultantEntity(us.EmployeeID).ConsultantName;
                    mail.AddToAddress(new ConsultantEntity(us.EmployeeID).EmailID);
                    mail.Subject = "Interview Scheduled Details";
                    sb = sb.Replace("{!CreaterANDHR}", ConsultantName);
                    mail.Body = sb.ToString();
                    IRCAMailHandler.SendMail(mail);
                }
                else if (new MasterCandidate(sts.CandidateID).RecruitmentType == "EMP")
                {
                    EmpName = new Employee(us.EmployeeID).PersonalInfo.FirstName + " " + new Employee(us.EmployeeID).PersonalInfo.MiddleName + " " + new Employee(us.EmployeeID).PersonalInfo.LastName;
                    EmpEmail = new Employee(us.EmployeeID).OccupationInfo.EmailID;
                    if (Role != "HR")
                    {
                        mail.AddToAddress(EmpEmail);
                        mail.Subject = "Interview Scheduled Details";
                        sb = sb.Replace("{!CreaterANDHR}", EmpName);
                        mail.Body = sb.ToString();
                        IRCAMailHandler.SendMail(mail);
                    }
                } 

                if (HRMailID != "" && HRName != EmpName && HRMailID != EmpEmail)
                {
                    StringBuilder sb1 = new StringBuilder(System.IO.File.ReadAllText(filpath));
                    sb1 = sb1.Replace("{!CreaterANDHR}", HRName);
                    sb1 = sb1.Replace("{!CandidateName}", CandidateName);
                    sb1 = sb1.Replace("{!Date1}", Date1);
                    sb1 = sb1.Replace("{!Time1}", Time1);
                    sb1 = sb1.Replace("{!Date2}", Date2);
                    sb1 = sb1.Replace("{!Time2}", Time2);

                    if (TechPanelName.Trim() == String.Empty)
                        sb1 = sb1.Replace("{!TechpanelName}", HRName);
                    else
                        sb1 = sb1.Replace("{!TechpanelName}", TechPanelName);

                    if (itype != null)
                        sb1 = sb1.Replace("{!InterviewType}", itype.InterviewType);

                    MailContent mail1 = new MailContent();
                    mail1.AddToAddress(HRMailID);
                    mail1.FromAddress = "noreply@ircaindia.com";
                    mail1.Subject = "Interview Scheduled Details";
                    sb1 = sb1.Replace("{!CreaterANDHR}", HRName);
                    mail1.Body = sb1.ToString();
                    IRCAMailHandler.SendMail(mail1);
                }

                if (ManagerName != "" && ManagerMailID != "")
                {
                    StringBuilder sb2 = new StringBuilder(System.IO.File.ReadAllText(filpath));
                    sb2 = sb2.Replace("{!CreaterANDHR}", ManagerName);
                    sb2 = sb2.Replace("{!CandidateName}", CandidateName);
                    sb2 = sb2.Replace("{!Date1}", Date1);
                    sb2 = sb2.Replace("{!Time1}", Time1);
                    sb2 = sb2.Replace("{!Date2}", Date2);
                    sb2 = sb2.Replace("{!Time2}", Time2);

                    if (TechPanelName.Trim() == String.Empty)
                        sb2 = sb2.Replace("{!TechpanelName}", HRName);
                    else
                        sb2 = sb2.Replace("{!TechpanelName}", TechPanelName);

                    if (itype != null)
                        sb2 = sb2.Replace("{!InterviewType}", itype.InterviewType);

                    MailContent mail1 = new MailContent();
                    mail1.AddToAddress(ManagerMailID);
                    mail1.FromAddress = "noreply@ircaindia.com";
                    mail1.Subject = "Interview Scheduled Details";
                    sb2 = sb2.Replace("{!CreaterANDHR}", ManagerName);
                    mail1.Body = sb2.ToString();
                    IRCAMailHandler.SendMail(mail1);
                }

                return "";
            }
            catch (Exception w)
            {
                IRCAExceptionHandler.HandleException(w);
                return w.Message;

            }
        }

        public String NotifyCAndidateAvailability(int ScheduleInterviewID, int ManagerID, bool IsCandidateAvail, int interviewtypeid, String Role)
        {
            try
            {
                String ManagerMailID = new Employee(ManagerID).OccupationInfo.EmailID;
                String ManagerName = new Employee(ManagerID).PersonalInfo.FirstName + " " + new Employee(ManagerID).PersonalInfo.MiddleName + " " + new Employee(ManagerID).PersonalInfo.LastName;
                CandidateInterviewStatus sts = new CandidateInterviewStatus(ScheduleInterviewID);
                CandidateTechnicalPanel[] tp = new CandidateTechnicalPanel().GetTechnicalPanelDetByInterviewStatusAndTypeID(interviewtypeid, ScheduleInterviewID);
                User us = new User(sts.UpdatedBy);
                InterView_Type itype = null;
                String filpath = "";
                if(IsCandidateAvail == true)
                    filpath = AppDomain.CurrentDomain.BaseDirectory + "/Recruitment/Templates/CandidateAvailable.htm";
                else
                    filpath = AppDomain.CurrentDomain.BaseDirectory + "/Recruitment/Templates/CandidateNotavailable.htm";

                MailContent mail = new MailContent();
                String TechPanelName = "";
                if (tp != null)
                {
                    TechPanelName = new Employee(tp[0].TechnicalPanelID).PersonalInfo.FirstName
                                + " " + new Employee(tp[0].TechnicalPanelID).PersonalInfo.MiddleName
                                + " " + new Employee(tp[0].TechnicalPanelID).PersonalInfo.LastName;
                    for (int g = 1; g < tp.Length; g++)
                    {
                        TechPanelName = TechPanelName + "," + new Employee(tp[g].TechnicalPanelID).PersonalInfo.FirstName
                                + " " + new Employee(tp[g].TechnicalPanelID).PersonalInfo.MiddleName
                                + " " + new Employee(tp[g].TechnicalPanelID).PersonalInfo.LastName;
                    }
                }

                String CandidateName = new MasterCandidate(sts.CandidateID).FirstName + " " + new MasterCandidate(sts.CandidateID).MiddleName + " " + new MasterCandidate(sts.CandidateID).LastName;
                String Date1 = ""; String Time1 = ""; String Date2 = ""; String Time2 = "";
                if (sts.InterviewDateTime1.Year == 1 || sts.InterviewDateTime1.Year == 1900)
                    Date1 = "";
                else
                    Date1 = sts.InterviewDateTime1.ToString("dd/MM/yyyy");

                if (sts.InterviewDateTime1.Hour == 0)
                    Time1 = "";
                else
                    Time1 = sts.InterviewDateTime1.ToString("HH:mm");

                if (sts.InterviewDateTime2.Year == 1 || sts.InterviewDateTime2.Year == 1900)
                    Date2 = "";
                else
                    Date2 = sts.InterviewDateTime2.ToString("dd/MM/yyyy");

                if (sts.InterviewDateTime2.Hour == 0)
                    Time2 = "";
                else
                    Time2 = sts.InterviewDateTime2.ToString("HH:mm");


                if (sts.InterviewTypeID == 0)
                    itype = new InterView_Type(interviewtypeid);
                else
                    itype = new InterView_Type(sts.InterviewTypeID);

                foreach (CandidateTechnicalPanel tps in tp)
                {
                    StringBuilder sb = new StringBuilder(System.IO.File.ReadAllText(filpath));
                    sb = sb.Replace("{!CandidateName}", CandidateName);

                    if (TechPanelName.Trim() == String.Empty)
                        sb = sb.Replace("{!TechpanelName}", HRName);
                    else
                        sb = sb.Replace("{!TechpanelName}", TechPanelName);

                    sb = sb.Replace("{!Date1}", Date1);
                    sb = sb.Replace("{!Time1}", Time1);
                    sb = sb.Replace("{!Date2}", Date2);
                    sb = sb.Replace("{!Time2}", Time2);

                    if(itype != null)
                        sb = sb.Replace("{!InterviewType}", itype.InterviewType);

                    mail.AddToAddress(new Employee(tps.TechnicalPanelID).OccupationInfo.EmailID);
                    String JustName = new Employee(tps.TechnicalPanelID).PersonalInfo.FirstName + ' ' + new Employee(tps.TechnicalPanelID).PersonalInfo.MiddleName + ' ' + new Employee(tps.TechnicalPanelID).PersonalInfo.LastName;
                    mail.Subject = "Candidate Availability Notification";
                    sb = sb.Replace("{!ToName}", JustName); 
                    mail.Body = sb.ToString();
                    IRCAMailHandler.SendMail(mail);
                }


                if (HRMailID != "" && Role != "HR")
                {
                    StringBuilder sb1 = new StringBuilder(System.IO.File.ReadAllText(filpath));
                    sb1 = sb1.Replace("{!ToName}", HRName);

                    if (TechPanelName.Trim() == String.Empty)
                        sb1 = sb1.Replace("{!TechpanelName}", HRName);
                    else
                        sb1 = sb1.Replace("{!TechpanelName}", TechPanelName);

                    sb1 = sb1.Replace("{!CandidateName}", CandidateName);
                    sb1 = sb1.Replace("{!Date1}", Date1);
                    sb1 = sb1.Replace("{!Time1}", Time1);
                    sb1 = sb1.Replace("{!Date2}", Date2);
                    sb1 = sb1.Replace("{!Time2}", Time2);

                    if (itype != null)
                        sb1 = sb1.Replace("{!InterviewType}", itype.InterviewType);

                    MailContent mail1 = new MailContent();
                    mail1.AddToAddress(HRMailID);
                    mail1.FromAddress = "noreply@ircaindia.com";
                    mail1.Subject = "Candidate Availability Notification";
                    sb1 = sb1.Replace("{!ToName}", HRName);
                    mail1.Body = sb1.ToString();
                    IRCAMailHandler.SendMail(mail1);
                }

                if (ManagerName != "" && ManagerMailID != "")
                {
                    StringBuilder sb2 = new StringBuilder(System.IO.File.ReadAllText(filpath));
                    sb2 = sb2.Replace("{!ToName}", ManagerName);

                    if (TechPanelName.Trim() == String.Empty)
                        sb2 = sb2.Replace("{!TechpanelName}", HRName);
                    else
                        sb2 = sb2.Replace("{!TechpanelName}", TechPanelName);

                    sb2 = sb2.Replace("{!CandidateName}", CandidateName);
                    sb2 = sb2.Replace("{!Date1}", Date1);
                    sb2 = sb2.Replace("{!Time1}", Time1);
                    sb2 = sb2.Replace("{!Date2}", Date2);
                    sb2 = sb2.Replace("{!Time2}", Time2);

                    if (itype != null)
                        sb2 = sb2.Replace("{!InterviewType}", itype.InterviewType);

                    MailContent mail1 = new MailContent();
                    mail1.AddToAddress(ManagerMailID);
                    mail1.FromAddress = "noreply@ircaindia.com";
                    mail1.Subject = "Candidate Availability Notification";
                    sb2 = sb2.Replace("{!ToName}", ManagerName);
                    mail1.Body = sb2.ToString();
                    IRCAMailHandler.SendMail(mail1);
                }
                return "";
            }
            catch (Exception w)
            {
                IRCAExceptionHandler.HandleException(w);
                return w.Message;
            }
        }

        public String CandidateSelectionUpdate(int CandidateID, String Role)
        {
            try
            {
                MasterCandidate mc = new MasterCandidate(CandidateID);
                CandidateInterviewResult[] res = new CandidateInterviewResult().GetCandidateInterviewResultByCandidateID(CandidateID);
                CandidateInterviewStatus sts = new CandidateInterviewStatus().GeInterviewStatusByCandidateID(CandidateID);
                int ManagerID = (HRManager.GetAllTeamDetailsByID(mc.TeamID))[0].ManagerID;
                User us = new User(mc.CreatedBy);
                InterView_Type itype = null;
                String ManagerMailID = new Employee(ManagerID).OccupationInfo.EmailID;
                String ManagerName = new Employee(ManagerID).PersonalInfo.FirstName + " " + new Employee(ManagerID).PersonalInfo.MiddleName + " " + new Employee(ManagerID).PersonalInfo.LastName;
                String ConsultantName = "";
                String EmpName = "";

                String filpath = AppDomain.CurrentDomain.BaseDirectory + "/Recruitment/Templates/InterviewResultUpdate.htm";
                StringBuilder sb = new StringBuilder(System.IO.File.ReadAllText(filpath));

                sb = sb.Replace("{!CandidateName}", mc.FirstName + ' ' + mc.MiddleName + ' ' + mc.LastName);
                string FirstName = new Employee(new User(res[0].UpdatedBy).EmployeeID).PersonalInfo.FirstName;
                string LastName = new Employee(new User(res[0].UpdatedBy).EmployeeID).PersonalInfo.LastName;
                string MidleName = new Employee(new User(res[0].UpdatedBy).EmployeeID).PersonalInfo.MiddleName;
                MailContent mail = new MailContent();

                sb = sb.Replace("{!TechPanel}", FirstName + ' ' + MidleName + ' ' + LastName);
                sb = sb.Replace("{!Status}", new CandidateStatusDescription().FullStatus(sts.CandidateStatus));

                CandidateTechnicalPanel[] tech = new CandidateTechnicalPanel().GetTechnicalPanelDetByInterviewStatusID(sts.ID);
                int rc = tech.Length - 1;
                if (sts.InterviewTypeID == 0)
                    itype = new InterView_Type(tech[rc].InterviewTypeID);
                else
                    itype = new InterView_Type(sts.InterviewTypeID);

                if (itype != null)
                    sb = sb.Replace("{!InterviewType}", itype.InterviewType);

                StringBuilder sb1 = new StringBuilder(sb.ToString());
                StringBuilder sb2 = new StringBuilder(sb.ToString());

                if (ManagerName != "" && ManagerMailID != "")
                {
                    MailContent mail2 = new MailContent();
                    mail2.AddToAddress(ManagerMailID);

                    if (mc.RecruitmentType == "EMP")
                    {
                        EmpName = new Employee(us.EmployeeID).PersonalInfo.FirstName + " " + new Employee(us.EmployeeID).PersonalInfo.MiddleName + " " + new Employee(us.EmployeeID).PersonalInfo.LastName;
                        sb1 = sb1.Replace("{!CreatorName}", EmpName);
                    }
                    else if (mc.RecruitmentType == "CNT")
                    {
                        ConsultantName = new ConsultantEntity(us.EmployeeID).ConsultantName;
                        sb1 = sb1.Replace("{!CreatorName}", ConsultantName);
                    }

                    if (itype != null)
                        sb1 = sb1.Replace("{!InterviewType}", itype.InterviewType);

                    sb1 = sb1.Replace("{!ToName}", ManagerName);
                    mail2.FromAddress = "noreply@ircaindia.com";
                    mail2.Subject = "Candidate Interview Result";
                    mail2.Body = sb1.ToString();
                    IRCAMailHandler.SendMail(mail2);
                }

                if (Role != "HR" && HRMailID != "")
                {
                    MailContent mail1 = new MailContent();
                    mail1.AddToAddress(HRMailID);

                    if (mc.RecruitmentType == "EMP")
                    {
                        EmpName = new Employee(us.EmployeeID).PersonalInfo.FirstName + " " + new Employee(us.EmployeeID).PersonalInfo.MiddleName + " " + new Employee(us.EmployeeID).PersonalInfo.LastName;
                        sb2 = sb2.Replace("{!CreatorName}", EmpName);
                    }
                    else if (mc.RecruitmentType == "CNT")
                    {
                        ConsultantName = new ConsultantEntity(us.EmployeeID).ConsultantName;
                        sb2 = sb2.Replace("{!CreatorName}", ConsultantName);
                    }

                    if (itype != null)
                        sb2 = sb2.Replace("{!InterviewType}", itype.InterviewType);

                    sb2 = sb2.Replace("{!ToName}", HRName);
                    mail1.FromAddress = "noreply@ircaindia.com";
                    mail1.Subject = "Candidate Interview Result";
                    mail1.Body = sb2.ToString();
                    IRCAMailHandler.SendMail(mail1);
                }

                if (mc.RecruitmentType == "CNT")
                {
                    ConsultantName = new ConsultantEntity(us.EmployeeID).ConsultantName;

                    sb = sb.Replace("{!CreatorName}", ConsultantName);
                    sb = sb.Replace("{!ToName}", ConsultantName);
                    mail.AddToAddress(new ConsultantEntity(us.EmployeeID).EmailID);
                    mail.Subject = "Candidate Interview Result";
                    mail.Body = sb.ToString();
                    IRCAMailHandler.SendMail(mail);
                }
                else if (mc.RecruitmentType == "EMP")
                {
                    String EmpEmail = new Employee(us.EmployeeID).OccupationInfo.EmailID;
                    if (HRName != EmpName && HRMailID != EmpEmail)
                    {
                        EmpName = new Employee(us.EmployeeID).PersonalInfo.FirstName + " " + new Employee(us.EmployeeID).PersonalInfo.MiddleName + " " + new Employee(us.EmployeeID).PersonalInfo.LastName;
                        sb = sb.Replace("{!CreatorName}", EmpName);
                        sb = sb.Replace("{!ToName}", EmpName);
                        mail.AddToAddress(EmpEmail);
                        mail.Subject = "Candidate Interview Result";
                        mail.Body = sb.ToString();
                        IRCAMailHandler.SendMail(mail);
                    }
                }
                return "";
            }
            catch (Exception w)
            {
                IRCAExceptionHandler.HandleException(w);
                return w.Message;
            }
        }

        public String NotifyJoiningDatetoHR3DaysPrior()
        {
            try
            {
                DataTable dt = new Candidate_Hired_SalaryBusinessObject().GetDataForHRNotification3DaysPrior();
                String JoiningDate = ((DateTime)dt.Rows[0]["JoiningDate"]).ToString("dd/MM/yyyy");
                String CreateTable = String.Empty;

                for (int e = 0; e < dt.Rows.Count; e++)
                {
                    String CandName = (String)dt.Rows[e]["CandidateName"];
                    String Desig = (String)dt.Rows[e]["JobTitle"];
                    String InterviewDate = ((DateTime)dt.Rows[e]["InterviewDate"]).ToString("dd/MM/yyyy");

                    CreateTable = CreateTable + "<tr><td>" + CandName + "</td>"
                        + "<td>" + Desig + "</td>"
                        + "<td>" + InterviewDate + "</td></tr>";
                }
                if (dt.Rows.Count > 0)
                {
                    String filpath = AppDomain.CurrentDomain.BaseDirectory + "/Recruitment/Templates/NotifyHRPriorJoining.htm";
                    StringBuilder sb = new StringBuilder(System.IO.File.ReadAllText(filpath));
                    sb = sb.Replace("{!ToName}", HRName);
                    sb = sb.Replace("{!JDate}", JoiningDate);
                    sb = sb.Replace("{!LoadContent}", CreateTable);

                    MailContent mail = new MailContent();
                    mail.AddToAddress(HRMailID);
                    mail.FromAddress = "noreply@ircaindia.com";
                    mail.Subject = "Candidate Joining Details Notification";
                    mail.Body = sb.ToString();
                    IRCAMailHandler.SendMail(mail);
                }
                return String.Empty;
            }
            catch (Exception ee)
            {
                IRCAExceptionHandler.HandleException(ee);
                return ee.Message;
            }
        }
    }
}
