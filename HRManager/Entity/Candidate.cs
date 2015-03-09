using System;
using System.Collections.Generic;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IS91.Services.DataBlock;


namespace HRManager.Entity
{
  public class Candidate
    {
       public CandidatePersonalInfo PersonalInfo = new CandidatePersonalInfo();
       public CandidateLanguage Language = new CandidateLanguage();
       public CandidateSkill Skill = new CandidateSkill();
       public CandidateEducation Education = new CandidateEducation();
       public CandidateFamilyDetails Family = new CandidateFamilyDetails();
       public CandidatePrevEmployer PrevEmployer = new CandidatePrevEmployer();
       public CandidateQuestioners Questioners = new CandidateQuestioners();
       public CandidateCurrentEmployer CurrentEmployer = new CandidateCurrentEmployer();
       public CandidateJob CandJobs = new CandidateJob();

       #region GET Methods for all Grids CANDIDATE

      
       /// <summary>
       /// Get all Candidates 
       /// </summary>
       public static CandidatePersonalInfo[] getAllCandidates()
       {
           return CandidatePersonalInfo.GetAllCandidates();
       }
       /// <summary>
       /// Get all Candidates 
       /// </summary>
       public static CandidatePersonalInfo[] getAllNonApproveCandidates()
       {
           return CandidatePersonalInfo.GetAllNonApprovedCandidateInfo();
       }
       public static CandidatePersonalInfo[] GetAllCandidateInfoForView(string Emp)
       {
           return CandidatePersonalInfo.GetAllCandidateInfoForView(Emp);
       }
       /// <summary>
       /// Get a particular Candidate
       /// </summary>
       public static CandidatePersonalInfo[] getCandidateInfo(int candidateID)
       {
     
           return CandidatePersonalInfo.GetCandidateInfo(candidateID);
       }
      
          /// <summary>
       /// Get a particular Candidate
       /// </summary>
       public static CandidatePersonalInfo[] GetCandidateDetailsInfo(int candidateID)
       {

           return CandidatePersonalInfo.GetCandidateDetailsInfo(candidateID);
       }
       /// <summary>
       /// Get all Candidates 
       /// </summary>
       public static CandidatePersonalInfo[] getAllApprovedCandidates()
       {
           return CandidatePersonalInfo.GetAllApprovedCandidateInfo();
       }

       /// <summary>
       /// Get Candidate Family details for a particular Candidate
       /// </summary>
       public static CandidateFamilyDetails[] getCandidateFamilyDetails(int candidateID)
       {
           return CandidateFamilyDetails.GetFamilyDetailss(candidateID);
       }

       /// <summary>
       /// Get Candidate Training details for a particular Candidate
       /// </summary>
       public static CandidateTraining[] getCandidateTrainingDetails(int candidateID)
       {
           return CandidateTraining.getCandidateTrainingDetailss(candidateID);
       }
       /// <summary>
       /// Get Candidate Language details for a particular Candidate
       /// </summary>
       public static CandidateLanguage[] getCandidateLanguage(int candidateID)
       {
           return CandidateLanguage.GetAllLanguages(candidateID);
       }

       /// <summary>
       /// Get Candidate Language details for a particular Candidate
       /// </summary>
       public static CandidateSkill[] getCandidateSkill(int candidateID)
       {
           return CandidateSkill.GetAllSkill(candidateID);
       }

       /// <summary>
       /// Get Candidate Education details for a particular Candidate
       /// </summary>
       public static CandidateEducation[] getCandidateEducation(int candidateID)
      {
          return CandidateEducation.GetAllCandidatEducations(candidateID);
      }

       /// <summary>
       /// Get Candidate Previous Employer details for a particular Candidate
       /// </summary>
       public static CandidatePrevEmployer[] getCandidatePrevEmployer(int candidateID)
       {
           return CandidatePrevEmployer.GetAllCandidatEducations(candidateID);
       }

       /// <summary>
       /// Get Candidate Questioners details for a particular Candidate
       /// </summary>
       public static CandidateQuestioners[] getCandidateQuestioners(int candidateID)
       {
           return CandidateQuestioners.GetAllCandidatQuestions(candidateID);
       }

       /// <summary>
       /// Get Candidate Current Employer details for a particular Candidate
       /// </summary>
       public static CandidateCurrentEmployer[] getCandidateCurrentEmployer(int candidateID)
       {
           return CandidateCurrentEmployer.GetAllCandidatCurrEmpl(candidateID);
       }
       #endregion


        # region Update Methods for CANDIDATE

       /// <summary> 
       /// Update Candidate of given ID
       /// </summary>
       public static String UpdateCandidate(int ID,String Title, String FirstName, String LastName,String FatherName, String Sex, String MaritialStatus, String PAddess, String PStreet,
                                            int PStateID, String PCity, String PZipCode, String PPhoneNo, String PMobileNumber, String TStreet, int TStateID,
                                           String TAddess, String TCity, String TZipCode, String TMobileNumber, String TelephoneNoRes, String TelephoneNoOff,
                                            DateTime DOB, String PhysicalDisability, String EMail, bool IsPhysicalDisability, bool IsActive,String Language,
                                            String Family, String Academic, String PastExp, String Skill, String Training,
                                           String Achievements, String Challenges, String Goals, String EmployeerRemarks, short CommitmentYears, double ExpectedMonthlyGross,
                                           double ExpectedMonthlyTakeHome, double ExpectedYearlyCTC, short NoticePeriod, bool WillingToRelocate, bool InBond,
                                           String SelfDetails, String WhyISutie, String FunctionalArea, bool PlaningForStudies, bool AlreadyInterviewed,String InterviewedPosistion,
                                           String Ref1_Name, String Ref1_Address, String Ref1_PhoneNumber, String Ref1_MobileNumber, String Ref2_Name, String Ref2_Address,
                                           String Ref2_PhoneNumber, String Ref2_MobileNumber ,String RelocatePlace,String PlaningForStudydetails,String BondDetails,
                                            // Candidate_Current_Employer data 
                                            String EmployerName,String Address,String BusinessNature,int NoOfEmployess,String AnnualSalesTurnOver,String JoinDesignation,
                                            DateTime JoinDate,String CurrentDesignation,DateTime DesignationEffectFrom,String ReportingOfficer,String ReportingOfficerDesignation,
                                            String ReportingOfficerMobileNo,String ReportingOfficerTeleNo,String Responsible,String Remarks,Double Joining_Basic,
                                            Double Joining_DA,Double Joining_HRA,Double Joining_Conveyance,Double Joining_OtherAllowance,Double Joining_GrossSalary,
                                            Double Joining_LTA,Double Joining_Medical,Double Joining_AnnualBonus,Double Joining_ClubMembership,Double Joining_Others,
                                            Double Joining_MonthlyCTC,Double Current_Basic,Double Current_DA,Double Current_HRA,Double Current_Conveyance,
                                            Double Current_OtherAllowance,Double Current_GrossSalary,Double Current_LTA,Double Current_Medical,Double Current_AnnualBonus,
                                            Double Current_ClubMembership,Double Current_Others,Double Current_MonthlyCTC,bool IsPF,bool IsGratuity,bool IsSuperAnnuation,
                                            String Others, String WeeklyOff, String JobResponsibilities, int JobId, bool IsFresher, bool IsTechnical, string GradudateLevel, string Degree, string ReportingOfficerEmailID)
       {
           Session ss = Session.CreateNewSession();
           String Status = null;
           int CandidateId = 0;
           try
           {
               ss.BeginTransaction();
               bool IsLocalSession = false;
               if (ss == null)
               {
                   IsLocalSession = true;

                   ss = Session.CreateNewSession();

                   ss.BeginTransaction();
               }
               try
               {
               //CandidatePersonalInfo Candidate = new CandidatePersonalInfo(ID);
               CandidatePersonalInfo Candidate = new CandidatePersonalInfo();
               Candidate.Title = Title;
               Candidate.FirstName = FirstName;
               Candidate.LastName = LastName;
               Candidate.FatherName = FatherName;
               Candidate.Sex = Sex;
               Candidate.MaritialStatus = MaritialStatus;
               Candidate.PAddess = PAddess;
               Candidate.PStreet = PStreet;
               Candidate.PStateID = PStateID;
               Candidate.PCity = PCity;
               Candidate.PZipCode = PZipCode;
               Candidate.PPhoneNo = PPhoneNo;
               Candidate.PMobileNumber = PMobileNumber;
               Candidate.TStreet = TStreet;
               Candidate.TStateID = TStateID;
               Candidate.TCity = TCity;
               Candidate.TAddess = TAddess;
               Candidate.TZipCode = TZipCode;
               Candidate.TMobileNumber = TMobileNumber;
               Candidate.TelephoneNoRes = TelephoneNoRes;
               Candidate.TelephoneNoOff = TelephoneNoOff;
               Candidate.DOB = DOB;
               Candidate.PhysicalDisability = PhysicalDisability;
               Candidate.EMailID = EMail;
               Candidate.IsPhysicalDisability = IsPhysicalDisability;
               Candidate.IsActive = true;
               Candidate.IsFresher = IsFresher;
               Candidate.IsTechnical = IsTechnical;
               Candidate.Graduate = GradudateLevel;
               Candidate.Degree = Degree;
              // String Status = Candidate.Save();
               CandidateId = Candidate.SaveRetId(ss);
               if (IsLocalSession)
               {
                   ss.Commit();
               }
               
               }
               catch (Exception ex)
               {
                   IRCAExceptionHandler.HandleException(
                       new IRCAException(ex, HRManagerDefs.CandidatePersonalInfoMessages.CANDIDATE_UPDATE_FAILURE, ID.ToString())
                       );
                   return HRManagerDefs.CandidatePersonalInfoMessages.CANDIDATE_UPDATE_FAILURE;
               }
            
               if (CandidateId != 0)
               {
                   #region language
                   int Lid;
                   String Lang;
                   bool Read;
                   bool Write;
                   bool Speak;
                   bool MotherTongue;

                   string[] lang = Language.Split('~');
                   foreach (string l in lang)
                   {
                       string[] words = l.Split('^');
                       //foreach (string word in words)
                       //{
                       Lid = Convert.ToInt32(words[0]);
                       Lang = words[1].ToString();
                       Read = Convert.ToBoolean(words[2]);
                       Write = Convert.ToBoolean(words[3]);
                       Speak = Convert.ToBoolean(words[4]);
                       MotherTongue = Convert.ToBoolean(words[5]);

                       //}
                       Status = UpdateCandidateLangug(0, CandidateId, Lang, MotherTongue, Read, Speak, Write,ss);
                       if (Status != String.Empty)
                       {
                           goto RollbackStatment;
                       }
                   }
                   #endregion
                   #region Family
                   int Fid;
                   int relation;
                   String name;
                   DateTime dateofbirth=DateTime.Now;
                   String occupation;
                   String annualincome;

                   string[] fam = Family.Split('~');
                   if (fam[0].ToString() != "Blank")
                   {
                       foreach (string f in fam)
                       {
                           string[] words = f.Split('^');
                           //foreach (string word in words)
                           //{
                           Fid = Convert.ToInt32(words[0]);
                           relation = Convert.ToInt32(words[1]);
                           name = words[2].ToString();
                           DateTime.TryParseExact(words[3].ToString() + " " + DateTime.Now.ToLongTimeString(), "dd/MM/yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out dateofbirth);

                           //  dateofbirth = Convert.ToDateTime(words[3]);
                           occupation = words[4].ToString();
                           annualincome = words[5].ToString();

                           //}
                           Status = UpdateCandidateFamily(0, CandidateId, relation, name, dateofbirth, occupation, annualincome, ss);
                           if (Status != String.Empty)
                           {
                               goto RollbackStatment;
                           }
                       }
                   }
                   else { Status= String.Empty; }
                   #endregion
                   #region Skill
                   //int sid;
                   //String skillset;
                   //short noofmonths;
                   //String lastapplied ;

                   //string[] ski = Skill.Split('~');
                   //foreach (string s in ski)
                   //{
                   //    string[] words = s.Split('^');
                   //    sid = Convert.ToInt32(words[0]);
                   //    skillset = words[1].ToString();
                   //    noofmonths = Convert.ToInt16(words[2]);
                   //    lastapplied = words[3].ToString();
                   //    Status = UpdateCandidateSkill(0, CandidateId, skillset, noofmonths, lastapplied, ss);
                   //    if (Status != String.Empty)
                   //    {
                   //        goto RollbackStatment;
                   //    }
                   //}
                   #endregion
                   #region Training
                   if (Training != "Blank")
                   {
                       int tid;
                       String organizedby;
                       String duration;
                       String subject;
                       String certificate;

                       string[] tra = Training.Split('~');
                       foreach (string t in tra)
                       {
                           string[] words = t.Split('^');
                           //foreach (string word in words)
                           //{
                           tid = Convert.ToInt32(words[0]);
                           organizedby = words[1].ToString();
                           //DateTime.TryParseExact(words[2].ToString() + " " + DateTime.Now.ToLongTimeString(), "dd/MM/yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out date);
                           duration = words[2].ToString();
                           subject = words[3].ToString();
                           certificate = words[4].ToString();
                           //}
                           Status = UpdateCandidateTraining(0, CandidateId, organizedby, duration, subject, certificate, ss);
                           if (Status != String.Empty)
                           {
                               goto RollbackStatment;
                           }
                       }
                   }
                   #endregion
                   #region PastExp
                   if (IsFresher == false && PastExp != "Blank")
                   {
                   int Pid;
                   String organization;
                   String designation;
                   String responsibilities;
                   String leavingreason;
                   DateTime workingfrom;
                   DateTime workingto;
                   double yearlyctc;
                   double monthlytakehome;

                   string[] pe = PastExp.Split('~');
                   foreach (string p in pe)
                   {
                       string[] words = p.Split('^');
                       //foreach (string word in words)
                       //{
                       Pid = Convert.ToInt32(words[0]);
                       organization = words[1].ToString();
                       designation = words[2].ToString();
                       responsibilities = words[3].ToString();
                       leavingreason = words[4].ToString();
                       DateTime.TryParseExact(words[5].ToString() + " " + DateTime.Now.ToLongTimeString(), "dd/MM/yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out workingfrom);
                       DateTime.TryParseExact(words[6].ToString() + " " + DateTime.Now.ToLongTimeString(), "dd/MM/yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out workingto);

                       //workingfrom = Convert.ToDateTime(words[5]);
                       //workingto = Convert.ToDateTime(words[6]);
                       yearlyctc = Convert.ToDouble(words[7]);
                       monthlytakehome = Convert.ToDouble(words[8]);
                       //}
                       Status = UpdateCandidatePrevEmp(0, CandidateId, yearlyctc, designation, organization, workingto, leavingreason, responsibilities, workingfrom, monthlytakehome, ss);
                       if (Status != String.Empty)
                       {
                           goto RollbackStatment;
                       }
                   }
                   }
                   #endregion
                   #region Academic
                   int Aid;
                   String academic;
                   String college;
                   DateTime fromdate;
                   DateTime todate;
                   String grade;

                   string[] ad = Academic.Split('~');
                   foreach (string a in ad)
                   {
                       string[] words = a.Split('^');
                       //foreach (string word in words)
                       //{
                       Aid = Convert.ToInt32(words[0]);
                       academic = words[1].ToString();
                       college = words[2].ToString();
                       //fromdate = Convert.ToDateTime(words[3]);
                       //todate = Convert.ToDateTime(words[4]);
                       DateTime.TryParseExact(words[3].ToString() + " " + DateTime.Now.ToLongTimeString(), "dd/MM/yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out fromdate);
                       DateTime.TryParseExact(words[4].ToString() + " " + DateTime.Now.ToLongTimeString(), "dd/MM/yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out todate);

                       grade = words[5].ToString();
                       
                       //}
                       Status = UpdateCandidateEducation(0, CandidateId, academic, college, academic, 00.00, grade, fromdate, todate,ss);
                       if (Status != String.Empty)
                       {
                           goto RollbackStatment;
                       }
                   }
                   #endregion
                   #region questioners
                   Status = UpdateCandidateQuestioners(0, CandidateId, Achievements, AlreadyInterviewed, Challenges, CommitmentYears, EmployeerRemarks, ExpectedMonthlyGross,
                                                        ExpectedMonthlyTakeHome, ExpectedYearlyCTC, FunctionalArea, Goals, InBond, InterviewedPosistion, NoticePeriod,
                                                        PlaningForStudies, Ref1_Address, Ref1_MobileNumber, Ref1_Name, Ref1_PhoneNumber, Ref2_Address, Ref2_MobileNumber,
                                                        Ref2_Name, Ref2_PhoneNumber, SelfDetails, WhyISutie, WillingToRelocate, PlaningForStudydetails,RelocatePlace,BondDetails, ss);
                   if (Status != String.Empty)
                   {
                       goto RollbackStatment;
                   }
                   #endregion
                   #region Candidate Current Employer
                   if (IsFresher == false)
                   {
                       Status = UpdateCandidateCurrEmpl(0, CandidateId, EmployerName, Address, BusinessNature, NoOfEmployess, AnnualSalesTurnOver, JoinDesignation,
                                                               JoinDate, CurrentDesignation, DesignationEffectFrom, ReportingOfficer, ReportingOfficerDesignation,
                                                               ReportingOfficerMobileNo, ReportingOfficerTeleNo, Responsible, Remarks, Joining_Basic, Joining_DA, Joining_HRA,
                                                               Joining_Conveyance, Joining_OtherAllowance, Joining_GrossSalary, Joining_LTA, Joining_Medical,
                                                               Joining_AnnualBonus, Joining_ClubMembership, Joining_Others, Joining_MonthlyCTC, Current_Basic,
                                                               Current_DA, Current_HRA, Current_Conveyance, Current_OtherAllowance, Current_GrossSalary, Current_LTA,
                                                               Current_Medical, Current_AnnualBonus, Current_ClubMembership, Current_Others, Current_MonthlyCTC,
                                                               IsPF, IsGratuity, IsSuperAnnuation, Others, WeeklyOff, JobResponsibilities,ReportingOfficerEmailID, ss);
                       if (Status != String.Empty)
                       {
                           goto RollbackStatment;
                       }
                   }
                   #endregion
                   #region Candidate Job Choosen
                   Status = UpdateCandidateJobApplied(0, CandidateId, JobId,ss);
                   if (Status != String.Empty)
                   {
                       goto RollbackStatment;
                   }
                   #endregion

               
               }
           RollbackStatment:
               if (Status != String.Empty)
               {
                   ss.Rollback();
                   CandidateId = 0;
               }
               else
                   ss.Commit();
              
           }
           catch (Exception ex)
           {
               ss.Rollback();
               IRCAExceptionHandler.HandleException(
                   new IRCAException(ex, HRManagerDefs.CandidatePersonalInfoMessages.CANDIDATE_UPDATE_FAILURE, ID.ToString())
                   );
               return HRManagerDefs.CandidatePersonalInfoMessages.CANDIDATE_UPDATE_FAILURE;
           }
           finally
           {
               ss.Dispose();
           }
           return CandidateId.ToString();
       }


       /// <summary>
       /// Update Candidate Family of given ID
       /// </summary>
       public static String UpdateCandidateFamily(int ID, int CanidateID, int RelationID, String Name, DateTime DateOfBirth, String Occupation, String AnnualIncome, Session DBSession)
       {
           bool IsLocalSession = false;
           if (DBSession == null)
           {
               IsLocalSession = true;

               DBSession = Session.CreateNewSession();

               DBSession.BeginTransaction();
           }
           try
           {
               CandidateFamilyDetails Family = new CandidateFamilyDetails(ID);

               Family.RelationID = RelationID;
               Family.CandidateID = CanidateID;
               Family.Name = Name;
               if (DateOfBirth.Year.Equals(0001))
                   Family.DateOfBirth = Convert.ToDateTime("1900-01-01");
               else
               Family.DateOfBirth = DateOfBirth;
               Family.Occupation = Occupation;
               Family.AnnualIncome = AnnualIncome;

               String Status = Family.Save(DBSession);
               if (IsLocalSession)
               {
                   DBSession.Commit();
               }
               return Status;
           }
           catch (Exception ex)
           {
               IRCAExceptionHandler.HandleException(
                   new IRCAException(ex, HRManagerDefs.Family_DetailsMessages.FAMILY_UPDATE_FAILURE, ID.ToString())
                   );
               return HRManagerDefs.Family_DetailsMessages.FAMILY_UPDATE_FAILURE;
           }
       }


       /// <summary>
       /// Update Candidate Language of given ID
       /// </summary>
       public static String UpdateCandidateLangug(int ID, int CanidateID, String Language, bool isMotherTongue, bool isRead, bool isSpeak, bool isWrite, Session DBSession)
       {
           bool IsLocalSession = false;
           if (DBSession == null)
           {
               IsLocalSession = true;

               DBSession = Session.CreateNewSession();

               DBSession.BeginTransaction();
           }
           try
           {
               CandidateLanguage Languages = new CandidateLanguage(ID);

               Languages.candidateID = CanidateID;
               Languages.Language = Language;
               Languages.MotherTongue = isMotherTongue;
               Languages.Read = isRead;
               Languages.Speak = isSpeak;
               Languages.Write = isWrite;

               String Status = Languages.SaveLanguage(DBSession);
               if (IsLocalSession)
               {
                   DBSession.Commit();
               }
               return Status;
           }
           catch (Exception ex)
           {
               IRCAExceptionHandler.HandleException(
                   new IRCAException(ex, HRManagerDefs.CandidateLaguages.LANGUAGE_UPDATE_FAILURE, ID.ToString())
                   );
               return HRManagerDefs.CandidateLaguages.LANGUAGE_UPDATE_FAILURE;
           }
       }

       /// <summary>
       /// Update Candidate Previous Employer of given ID
       /// </summary>
       public static String UpdateCandidatePrevEmp(int ID, int CanidateID, double CTC, String Designation, String EmployerName, DateTime EndDate, String ResonForLeaving, String Responsibilities, DateTime StartDate, double TakeHome,Session DBSession)
       {
           bool IsLocalSession = false;
           if (DBSession == null)
           {
               IsLocalSession = true;

               DBSession = Session.CreateNewSession();

               DBSession.BeginTransaction();
           }
           try
           {
               CandidatePrevEmployer PrevEmp = new CandidatePrevEmployer(ID);

               PrevEmp.candidateID = CanidateID;
               PrevEmp.CTC = CTC;
               PrevEmp.Designation = Designation;
               PrevEmp.EmployerName = EmployerName;
               PrevEmp.EndDate = EndDate;
               PrevEmp.ResonForLeaving = ResonForLeaving;
               PrevEmp.Responsibilities = Responsibilities;
               PrevEmp.StartDate = StartDate;
               PrevEmp.TakeHome = TakeHome;
               String Status = PrevEmp.SaveCandidatePrev(DBSession);
               if (IsLocalSession)
               {
                   DBSession.Commit();
               }
               return Status;
           }
           catch (Exception ex)
           {
               IRCAExceptionHandler.HandleException(
                   new IRCAException(ex, HRManagerDefs.CandidatePrevEmplo.PREVIOUSEMP_UPDATE_FAILURE, ID.ToString())
                   );
               return HRManagerDefs.CandidatePrevEmplo.PREVIOUSEMP_UPDATE_FAILURE;
           }
       }

       /// <summary>
       /// Update Candidate Previous Employer of given ID
       /// </summary>
       public static String UpdateCandidateSkill(int ID, int CanidateID, String SkillSet, short NoOfMonths, String LastApplied, Session DBSession)
       {
           bool IsLocalSession = false;
           if (DBSession == null)
           {
               IsLocalSession = true;

               DBSession = Session.CreateNewSession();

               DBSession.BeginTransaction();
           }
           try
           {
               CandidateSkill Skill = new CandidateSkill(ID);

               Skill.candidateID = CanidateID;
               Skill.SkillSet = SkillSet;
               Skill.NoOfMonths = NoOfMonths;
               Skill.LastApplied = LastApplied;
               String Status = Skill.SaveSkill(DBSession);
               if (IsLocalSession)
               {
                   DBSession.Commit();
               }
               return Status;
           }
           catch (Exception ex)
           {
               IRCAExceptionHandler.HandleException(
                   new IRCAException(ex, HRManagerDefs.CandidateSkill.SKILL_UPDATE_FAILURE, ID.ToString())
                   );
               return HRManagerDefs.CandidateSkill.SKILL_UPDATE_FAILURE;
           }
       }
       /// <summary>
       /// Update Candidate Training of given ID
       /// </summary>
       public static String UpdateCandidateTraining(int ID,int CanidateID, String OrganizedBy, String Duration, String Subject, String Certificate, Session DBSession)
       {
           bool IsLocalSession = false;
           if (DBSession == null)
           {
               IsLocalSession = true;

               DBSession = Session.CreateNewSession();

               DBSession.BeginTransaction();
           }
           try
           {
               CandidateTraining Training = new CandidateTraining(ID);

               Training.candidateID = CanidateID;
               Training.OrganizedBy = OrganizedBy;
               Training.Duration = Duration;
               Training.Subject = Subject;
               Training.Certificate = Certificate;
               String Status = Training.SaveTraining(DBSession);
               if (IsLocalSession)
               {
                   DBSession.Commit();
               }
               return Status;
           }
           catch (Exception ex)
           {
               IRCAExceptionHandler.HandleException(
                   new IRCAException(ex, HRManagerDefs.CandidateTraining.TRAINING_UPDATE_FAILURE, ID.ToString())
                   );
               return HRManagerDefs.CandidateTraining.TRAINING_UPDATE_FAILURE;
           }
       }
       /// <summary>
       /// Update Candidate Questioners of given ID
       /// </summary>
       public static String UpdateCandidateEducation(int ID, int CanidateID, String Title, String Institute, String Subject, double Percentage, String Grade, DateTime FromDate, DateTime ToDate, Session DBSession)
       {
           bool IsLocalSession = false;
           if (DBSession == null)
           {
               IsLocalSession = true;

               DBSession = Session.CreateNewSession();

               DBSession.BeginTransaction();
           }
           try
           {
               CandidateEducation Education = new CandidateEducation(ID);

               Education.candidateID = CanidateID;
               Education.Title = Title;
               Education.Institute = Institute;
               Education.Subject = Subject;
               Education.Percentage = Percentage;
               Education.Grade = Grade;
               Education.FromDate = FromDate;
               Education.ToDate = ToDate;
               String Status = Education.SaveEducation(DBSession);
               if (IsLocalSession)
               {
                   DBSession.Commit();
               }
               return Status;
           }
           catch (Exception ex)
           {
               IRCAExceptionHandler.HandleException(
                   new IRCAException(ex, HRManagerDefs.CandidateEducational.EDUCATION_UPDATE_FAILURE, ID.ToString())
                   );
               return HRManagerDefs.CandidateEducational.EDUCATION_UPDATE_FAILURE;
           }
       }

       /// <summary>
       /// Update Family of given ID
       /// </summary>
       public static String UpdateCandidateQuestioners(int ID, int CanidateID, String Achievements, bool AlreadyInterviewed, String Challenges, short CommitmentYears, String EmployeerRemarks,double ExpectedMonthlyGross,double ExpectedMonthlyTakeHome,
                                                       double ExpectedYearlyCTC,String FunctionalArea,String Goals,bool InBond,String InterviewedPosistion,short NoticePeriod, bool PlaningForStudies,String Ref1_Address,String Ref1_MobileNumber,String Ref1_Name,String Ref1_PhoneNumber,
                                                       String Ref2_Address, String Ref2_MobileNumber, String Ref2_Name, String Ref2_PhoneNumber, String SelfDetails, String WhyISutie, bool WillingToRelocate,String PlaningForStudydetails, String RelocatePlace,String BondDetails,Session DBSession)
       {
           bool IsLocalSession = false;
           if (DBSession == null)
           {
               IsLocalSession = true;

               DBSession = Session.CreateNewSession();

               DBSession.BeginTransaction();
           }
           try
           {
               CandidateQuestioners Questioners = new CandidateQuestioners();
               //Questioners.CandidateQuestionersNew(ID);
               Questioners.CandidateID = CanidateID;
               Questioners.Achievements = Achievements;
               Questioners.AlreadyInterviewed = AlreadyInterviewed;
               Questioners.Challenges = Challenges;
               Questioners.CommitmentYears = CommitmentYears;
               Questioners.EmployeerRemarks = EmployeerRemarks;
               Questioners.ExpectedMonthlyGross = ExpectedMonthlyGross;
               Questioners.ExpectedMonthlyTakeHome = ExpectedMonthlyTakeHome;
               Questioners.ExpectedYearlyCTC = ExpectedYearlyCTC;
               Questioners.FunctionalArea = FunctionalArea;
               Questioners.Goals = Goals;
               Questioners.InBond = InBond;
               Questioners.InterviewedPosistion = InterviewedPosistion;
               Questioners.NoticePeriod = NoticePeriod;
               Questioners.PlaningForStudies = PlaningForStudies;
               Questioners.Ref1_Address = Ref1_Address;
               Questioners.Ref1_MobileNumber = Ref1_MobileNumber;
               Questioners.Ref1_Name = Ref1_Name;
               Questioners.Ref1_PhoneNumber = Ref1_PhoneNumber;
               Questioners.Ref2_Address = Ref2_Address;
               Questioners.Ref2_MobileNumber = Ref2_MobileNumber;
               Questioners.Ref2_Name = Ref2_Name;
               Questioners.Ref2_PhoneNumber = Ref2_PhoneNumber;
               Questioners.SelfDetails = SelfDetails;
               Questioners.WhyISutie = WhyISutie;
               Questioners.WillingToRelocate = WillingToRelocate;
               Questioners.PlaningForStudydetails = PlaningForStudydetails;
               Questioners.RelocatePlace = RelocatePlace;
               Questioners.BondDetails = BondDetails;
               Questioners.ReferenceCheckerID = -1;
               String Status = Questioners.SaveQuestions(DBSession);
               if (IsLocalSession)
               {
                   DBSession.Commit();
               }
               return Status;
           }
           catch (Exception ex)
           {
               IRCAExceptionHandler.HandleException(
                   new IRCAException(ex, HRManagerDefs.CandidateQuestioners.QUESTION_UPDATE_FAILURE, ID.ToString())
                   );
               return HRManagerDefs.CandidateQuestioners.QUESTION_UPDATE_FAILURE;
           }
       }
       /// <summary>
       /// Update Family of given ID
       /// </summary>
       public static String UpdateCandidateJobApplied(int ID, int CandidateID, int JobId,Session DBSession)
       {
           bool IsLocalSession = false;
           if (DBSession == null)
           {
               IsLocalSession = true;

               DBSession = Session.CreateNewSession();

               DBSession.BeginTransaction();
           }
           try
           {
               CandidateJob Cjob = new CandidateJob(ID);

               Cjob.candidateID = CandidateID;
               Cjob.jobID = JobId;
               //Cjob.AppliedDate = DateTime.Now;
                //Cjob.Status= "";
               Cjob.Status = HRAppCommands.NEW_INTERVIEW;
                Cjob.AppliedDate = DateTime.Now;



                String Status = Cjob.SaveJobs(DBSession);
               if (IsLocalSession)
               {
                   DBSession.Commit();
               }
               return Status;
           }
           catch (Exception ex)
           {
               IRCAExceptionHandler.HandleException(
                   new IRCAException(ex, HRManagerDefs.CandidateQuestioners.QUESTION_UPDATE_FAILURE, ID.ToString())
                   );
               return HRManagerDefs.CandidateQuestioners.QUESTION_UPDATE_FAILURE;
           }
       }
      
       /// <summary>
       /// Update Candidate CurrEmployer of given ID
       /// </summary>
       public static String UpdateCandidateCurrEmpl(int ID, int CanidateID, String EmployerName, String Address, String BusinessNature,
                                                    int NoOfEmployess,String AnnualSalesTurnOver,String JoinDesignation,
                                                    DateTime JoinDate,String CurrentDesignation,DateTime DesignationEffectFrom,
                                                    String ReportingOfficer,String ReportingOfficerDesignation,String ReportingOfficerMobileNo,
                                                    String ReportingOfficerTeleNo,String Responsible,String Remarks,Double Joining_Basic,
                                                    Double Joining_DA,Double Joining_HRA,Double Joining_Conveyance,Double Joining_OtherAllowance,
                                                    Double Joining_GrossSalary,Double Joining_LTA,Double Joining_Medical,Double Joining_AnnualBonus,
                                                    Double Joining_ClubMembership,Double Joining_Others,Double Joining_MonthlyCTC,Double Current_Basic,
                                                    Double Current_DA,Double Current_HRA,Double Current_Conveyance,Double Current_OtherAllowance,
                                                    Double Current_GrossSalary,Double Current_LTA,Double Current_Medical,Double Current_AnnualBonus,
                                                    Double Current_ClubMembership,Double Current_Others,Double Current_MonthlyCTC,bool IsPF,
                                                   bool IsGratuity,bool IsSuperAnnuation,String Others,String WeeklyOff,String JobResponsibilities,String ReportingOfficerEmailID,Session DBSession)
       {
           bool IsLocalSession = false;
           if (DBSession == null)
           {
               IsLocalSession = true;

               DBSession = Session.CreateNewSession();

               DBSession.BeginTransaction();
           }
           try
           {
               CandidateCurrentEmployer UpdateCandidateCurrEmp = new CandidateCurrentEmployer(ID);

               UpdateCandidateCurrEmp.candidateID= CanidateID;
               UpdateCandidateCurrEmp.EmployerName = EmployerName;
               UpdateCandidateCurrEmp.Address = Address;
               UpdateCandidateCurrEmp.BusinessNature = BusinessNature;
               UpdateCandidateCurrEmp.Current_AnnualBonus = Current_AnnualBonus;
               UpdateCandidateCurrEmp.Current_Basic = Current_Basic;
               UpdateCandidateCurrEmp.Current_ClubMembership = Current_ClubMembership;
               UpdateCandidateCurrEmp.Current_Conveyance = Current_Conveyance;
               UpdateCandidateCurrEmp.Current_DA = Current_DA;
               UpdateCandidateCurrEmp.Current_GrossSalary = Current_GrossSalary;
               UpdateCandidateCurrEmp.Current_HRA = Current_HRA;
               UpdateCandidateCurrEmp.Current_LTA = Current_LTA;
               UpdateCandidateCurrEmp.Current_Medical = Current_Medical;
               UpdateCandidateCurrEmp.Current_MonthlyCTC = Current_MonthlyCTC;
               UpdateCandidateCurrEmp.Current_OtherAllowance = Current_OtherAllowance;
               UpdateCandidateCurrEmp.Current_Others = Current_Others;
               UpdateCandidateCurrEmp.CurrentDesignation = CurrentDesignation;
               UpdateCandidateCurrEmp.DesignationEffectFrom = DesignationEffectFrom;
               UpdateCandidateCurrEmp.EmployerName = EmployerName;
               UpdateCandidateCurrEmp.IsGratuity = IsGratuity;
               UpdateCandidateCurrEmp.IsPF = IsPF;
               UpdateCandidateCurrEmp.IsSuperAnnuation = IsSuperAnnuation;
               UpdateCandidateCurrEmp.JoinDate = JoinDate;
               UpdateCandidateCurrEmp.JoinDesignation = JoinDesignation;
               UpdateCandidateCurrEmp.Joining_AnnualBonus = Joining_AnnualBonus;
               UpdateCandidateCurrEmp.Joining_Basic = Joining_Basic;
               UpdateCandidateCurrEmp.Joining_ClubMembership = Joining_ClubMembership;
               UpdateCandidateCurrEmp.Joining_Conveyance= Joining_Conveyance;
               UpdateCandidateCurrEmp.Joining_DA = Joining_DA;
               UpdateCandidateCurrEmp.Joining_GrossSalary = Joining_GrossSalary;
               UpdateCandidateCurrEmp.Joining_HRA = Joining_HRA;
               UpdateCandidateCurrEmp.Joining_LTA = Joining_LTA;
               UpdateCandidateCurrEmp.Joining_Medical = Joining_Medical;
               UpdateCandidateCurrEmp.Joining_MonthlyCTC = Joining_MonthlyCTC;
               UpdateCandidateCurrEmp.Joining_OtherAllowance = Joining_OtherAllowance;
               UpdateCandidateCurrEmp.Joining_Others = Joining_Others;
               UpdateCandidateCurrEmp.NoOfEmployess = NoOfEmployess;
               UpdateCandidateCurrEmp.Others = Others;
               UpdateCandidateCurrEmp.Remarks = Remarks;
               UpdateCandidateCurrEmp.ReportingOfficer = ReportingOfficer;
               UpdateCandidateCurrEmp.ReportingOfficerDesignation = ReportingOfficerDesignation;
               UpdateCandidateCurrEmp.ReportingOfficerMobileNo = ReportingOfficerMobileNo;
               UpdateCandidateCurrEmp.ReportingOfficerTeleNo = ReportingOfficerTeleNo;
               UpdateCandidateCurrEmp.Responsible = Responsible;
               UpdateCandidateCurrEmp.WeeklyOff = WeeklyOff;
               UpdateCandidateCurrEmp.AnnualSalesTurnOver = AnnualSalesTurnOver;
               UpdateCandidateCurrEmp.JobResponsibilities = JobResponsibilities;
               UpdateCandidateCurrEmp.ReportingOfficerEmailID = ReportingOfficerEmailID;
               

               String Status = UpdateCandidateCurrEmp.SaveCandidateCurrEmp(DBSession);
               if (IsLocalSession)
               {
                   DBSession.Commit();
               }
               return Status;
           }
           catch (Exception ex)
           {
               IRCAExceptionHandler.HandleException(
                   new IRCAException(ex, HRManagerDefs.CandidateCurreEmplo.CURRENTEMP_UPDATE_FAILURE, ID.ToString())
                   );
               return HRManagerDefs.CandidateCurreEmplo.CURRENTEMP_UPDATE_FAILURE;
           }
       }


       /// <summary>
       /// Activate JobProfile by ID
       /// </summary>
       /// <param name="ID">field contain JobProfile ID</param>
       /// <param name="ActivatedBy">field contain the user id who activated JobProfile</param>
       /// <returns>empty string for success and error message for failure</returns>
       public static String ApproveCandidate(int ID, string status)
       {
           try
           {
               return new CandidateJob(ID).Approve(status);
           }
           catch (Exception ex)
           {
               IRCAExceptionHandler.HandleException(
                   new IRCAException(ex, HRManagerDefs.CandidatePersonalInfoMessages.CANDIDATE_APPROVED_FAILURE, ID.ToString())
                   );
               return HRManagerDefs.CandidatePersonalInfoMessages.CANDIDATE_APPROVED_FAILURE;
           }
       }
       /// <summary>
       /// Deactivate JobProfile by ID
       /// </summary>
       /// <param name="ID">integer type</param>
       /// <param name="DeactivatedBy">field contain the user id who deactivated JobProfile</param>
       /// <returns>empty string for success and error message for failure</returns>
       public static String RejectCandidate(int ID, string status)
       {
           try
           {
             return new CandidateJob(ID).Reject(status);
           }
           catch (Exception ex)
           {
               IRCAExceptionHandler.HandleException(
                   new IRCAException(ex, HRManagerDefs.CandidatePersonalInfoMessages.CANDIDATE_REJECTED_FAILURE, ID.ToString())
                   );
               return HRManagerDefs.CandidatePersonalInfoMessages.CANDIDATE_REJECTED_FAILURE;
           }
       }

       public static int getCandJobID(int candidateid)
       {
           return new Candidate_JobDetailsBusinessObject().GetCandJobdetailsID(candidateid);
       }
        
        
        
        
        
        #endregion

    }
}
