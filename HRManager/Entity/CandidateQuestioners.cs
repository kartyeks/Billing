using System;
using System.Collections.Generic;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IS91.Services.DataBlock;

using IRCA.Communication;

namespace HRManager.Entity
{
   public class CandidateQuestioners:JGridDataObject
    {
        private int _ID;
        private int _CandidateID;
        private String _Achievements;
        private String _Challenges;
        private String _Goals;
        private String _EmployeerRemarks;
        private short _CommitmentYears;
        private double _ExpectedMonthlyGross;
        private double _ExpectedMonthlyTakeHome;
        private double _ExpectedYearlyCTC;
        private short _NoticePeriod;
        private bool _WillingToRelocate;
        private bool _InBond;
        private String _SelfDetails;
        private String _WhyISutie;
        private String _FunctionalArea;
        private bool _PlaningForStudies;
        private bool _AlreadyInterviewed;
        private String _InterviewedPosistion;
        private String _Ref1_Name;
        private String _Ref1_Address;
        private String _Ref1_PhoneNumber;
        private String _Ref1_MobileNumber;
        private String _Ref2_Name;
        private String _Ref2_Address;
        private String _Ref2_PhoneNumber;
        private String _Ref2_MobileNumber;
        private String _PlaningForStudydetails;
        private String _RelocatePlace;
        private String _BondDetails;
        private bool _IsNew;
        private String _Ref1_Remarks;
        private String _Ref2_Remarks;
        private String _Ref_Remarks;
        private bool _Status;
        private int _ReferenceCheckerID;

        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
        public int ReferenceCheckerID
        {
            get
            {
                return _ReferenceCheckerID;
            }
            set
            {
                _ReferenceCheckerID = value;
            }
        }
        public int CandidateID
        {
            get
            {
                return _CandidateID;
            }
            set
            {
                _CandidateID = value;
            }
        }
        public String Achievements
        {
            get
            {
                return _Achievements;
            }
            set
            {
                _Achievements = value;
            }
        }
        public String Challenges
        {
            get
            {
                return _Challenges;
            }
            set
            {
                _Challenges = value;
            }
        }
        public String Goals
        {
            get
            {
                return _Goals;
            }
            set
            {
                _Goals = value;
            }
        }
        public String EmployeerRemarks
        {
            get
            {
                return _EmployeerRemarks;
            }
            set
            {
                _EmployeerRemarks = value;
            }
        }
        public short CommitmentYears
        {
            get
            {
                return _CommitmentYears;
            }
            set
            {
                _CommitmentYears = value;
            }
        }
        public double ExpectedMonthlyGross
        {
            get
            {
                return _ExpectedMonthlyGross;
            }
            set
            {
                _ExpectedMonthlyGross = value;
            }
        }
        public double ExpectedMonthlyTakeHome
        {
            get
            {
                return _ExpectedMonthlyTakeHome;
            }
            set
            {
                _ExpectedMonthlyTakeHome = value;
            }
        }
        public double ExpectedYearlyCTC
        {
            get
            {
                return _ExpectedYearlyCTC;
            }
            set
            {
                _ExpectedYearlyCTC = value;
            }
        }
        public short NoticePeriod
        {
            get
            {
                return _NoticePeriod;
            }
            set
            {
                _NoticePeriod = value;
            }
        }
        public bool WillingToRelocate
        {
            get
            {
                return _WillingToRelocate;
            }
            set
            {
                _WillingToRelocate = value;
            }
        }
        public bool InBond
        {
            get
            {
                return _InBond;
            }
            set
            {
                _InBond = value;
            }
        }
        public String SelfDetails
        {
            get
            {
                return _SelfDetails;
            }
            set
            {
                _SelfDetails = value;
            }
        }
        public String WhyISutie
        {
            get
            {
                return _WhyISutie;
            }
            set
            {
                _WhyISutie = value;
            }
        }
        public String FunctionalArea
        {
            get
            {
                return _FunctionalArea;
            }
            set
            {
                _FunctionalArea = value;
            }
        }
        public bool PlaningForStudies
        {
            get
            {
                return _PlaningForStudies;
            }
            set
            {
                _PlaningForStudies = value;
            }
        }
        public bool AlreadyInterviewed
        {
            get
            {
                return _AlreadyInterviewed;
            }
            set
            {
                _AlreadyInterviewed = value;
            }
        }

        public String InterviewedPosistion
        {
            get
            {
                return _InterviewedPosistion;
            }
            set
            {
                _InterviewedPosistion = value;
            }
        }
        public String Ref1_Name
        {
            get
            {
                return _Ref1_Name;
            }
            set
            {
                _Ref1_Name = value;
            }
        }
        public String Ref1_Address
        {
            get
            {
                return _Ref1_Address;
            }
            set
            {
                _Ref1_Address = value;
            }
        }

        public String Ref1_PhoneNumber
        {
            get
            {
                return _Ref1_PhoneNumber;
            }
            set
            {
                _Ref1_PhoneNumber = value;
            }
        }
        public String Ref1_MobileNumber
        {
            get
            {
                return _Ref1_MobileNumber;
            }
            set
            {
                _Ref1_MobileNumber = value;
            }
        }
        public String Ref2_Name
        {
            get
            {
                return _Ref2_Name;
            }
            set
            {
                _Ref2_Name = value;
            }
        }
        public String Ref2_Address
        {
            get
            {
                return _Ref2_Address;
            }
            set
            {
                _Ref2_Address = value;
            }
        }
        public String Ref2_PhoneNumber
        {
            get
            {
                return _Ref2_PhoneNumber;
            }
            set
            {
                _Ref2_PhoneNumber = value;
            }
        }
        public String Ref2_MobileNumber
        {
            get
            {
                return _Ref2_MobileNumber;
            }
            set
            {
                _Ref2_MobileNumber = value;
            }
        }
        public String PlaningForStudydetails
        {
            get
            {
                return _PlaningForStudydetails;
            }
            set
            {
                _PlaningForStudydetails = value;
            }
        }
        public String RelocatePlace
        {
            get
            {
                return _RelocatePlace;
            }
            set
            {
                _RelocatePlace = value;
            }
        }
        public String BondDetails
        {
            get
            {
                return _BondDetails;
            }
            set
            {
                _BondDetails = value;
            }
        }
        public String Ref1_Remarks
        {
            get
            {
                return _Ref1_Remarks;
            }
            set
            {
                _Ref1_Remarks = value;
            }
        }
        public String Ref2_Remarks
        {
            get
            {
                return _Ref2_Remarks;
            }
            set
            {
                _Ref2_Remarks = value;
            }
        }
        public String Ref_Remarks
        {
            get
            {
                return _Ref_Remarks;
            }
            set
            {
                _Ref_Remarks = value;
            }
        }
        public bool Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }

        // <summary>
        /// Update the Candidate field using Master_Candidate.
        /// </summary>
        /// <param name="Candidate">Object of Master_Candidate class</param>

        private void Update( Candidate_Questioners Questions)
        {
            if (Questions != null)
            {
                _ID = Questions.ID;
                _CandidateID = Questions.CandidateID;
                _Achievements = Questions.Achievements;
                _AlreadyInterviewed  = Questions.AlreadyInterviewed;
                _Challenges = Questions.Challenges;
                _CommitmentYears = Questions.CommitmentYears;
                _EmployeerRemarks = Questions.EmployeerRemarks;
                _ExpectedMonthlyGross = Questions.ExpectedMonthlyGross;
                _ExpectedMonthlyTakeHome = Questions.ExpectedMonthlyTakeHome;
                _ExpectedYearlyCTC = Questions.ExpectedYearlyCTC;
                _FunctionalArea = Questions.FunctionalArea;
                _Goals = Questions.Goals;
                _InBond = Questions.InBond;
                _InterviewedPosistion = Questions.InterviewedPosistion;
                _NoticePeriod = Questions.NoticePeriod;
                _PlaningForStudies = Questions.PlaningForStudies;
                _Ref1_Address = Questions.Ref1_Address;
                _Ref1_MobileNumber = Questions.Ref1_MobileNumber;
                _Ref1_Name = Questions.Ref1_Name;
                _Ref1_PhoneNumber = Questions.Ref1_PhoneNumber;
                _Ref2_Address = Questions.Ref2_Address;
                _Ref2_MobileNumber = Questions.Ref2_MobileNumber;
                _Ref2_Name = Questions.Ref2_Name;
                _Ref2_PhoneNumber = Questions.Ref2_PhoneNumber;
                _SelfDetails = Questions.SelfDetails;
                _WhyISutie = Questions.WhyISutie;
                _WillingToRelocate = Questions.WillingToRelocate;
                _PlaningForStudydetails = Questions.PlaningForStudydetails;
                _RelocatePlace = Questions.RelocatePlace;
                _BondDetails = Questions.BondDetails;
                _Ref1_Remarks = Questions.Ref1_Remarks;
                _Ref2_Remarks = Questions.Ref2_Remarks;
                _Ref_Remarks = Questions.Ref_Remarks;
                _Status = Questions.Status;
                _ReferenceCheckerID = Questions.ReferenceCheckerID;
            }
            else
            {
                _IsNew = true;
            }
        }

        /// <summary>
        /// Consturctor of CandidateEducation  class.
        /// Update Candidate fields using Candidate_Education.
        /// </summary>
        /// <param name="Candidate">Object of Candidate_Education class</param>
        public CandidateQuestioners(Candidate_Questioners Questions)
        {
            Update(Questions);
        }
       /// <summary>
        /// Consturctor of CandidateEducation class.
        /// Update Candidate for given Candidate Education field.
        /// </summary>
        /// <param name="CandidateEducation">field contains Candidate Education</param>
        public CandidateQuestioners(string Achievements)
        {
            Update(new Master_CandidateBusinessObject().GetQuestionsByCandidate(Achievements));
        }

       /// <summary>
        /// Consturctor of Master_Candidate class.
       /// Update Candidate fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains Candidate ID</param>
        public CandidateQuestioners(int ID)
        {
            Candidate_Questioners[] Questions = new Candidate_QuestionersBusinessObject().GetQuestionersByCandidate(ID);

            if (Questions == null && ID > 0)
            {
                throw new IRCAException("Invalid Candidate ", ID.ToString());
            }

            Update(Questions[0]);
        }
        //public Candidate_Questioners CandidateQuestionersNew(int ID)
        //{
        //    Candidate_Questioners Questions = new Candidate_QuestionersBusinessObject().GetCandidate_Questioners(ID);

        //    if (Questions == null && ID > 0)
        //    {
        //        throw new IRCAException("Invalid Candidate ", ID.ToString());
        //    }

        //    return Questions;
        //}
      /// <summary>
        /// Consturctor of CandidatePersonalInfo class.
        /// Set variables for new Candidate.  
        /// </summary>
        public CandidateQuestioners()
        {
            _ID = 0;
            _IsNew = true;
        }
        /// <summary>
        /// Save Candidate.If new Candidate it add and in case of edit it update the Candidate.
        /// </summary>
        /// <returns>empty string</returns>
        public String SaveQuestions(Session DBSession)
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
                Candidate_QuestionersBusinessObject CandQuestBO;
                CandQuestBO = new Candidate_QuestionersBusinessObject(DBSession);

                Candidate_Questioners Questions = new Candidate_Questioners();
                Questions.ID = _ID;
                Questions.CandidateID = _CandidateID;
                Questions.Achievements = _Achievements;
                Questions.AlreadyInterviewed = _AlreadyInterviewed;
                Questions.Challenges = _Challenges;
                Questions.CommitmentYears = _CommitmentYears;
                Questions.EmployeerRemarks = _EmployeerRemarks;
                Questions.ExpectedMonthlyGross = _ExpectedMonthlyGross;
                Questions.ExpectedMonthlyTakeHome = _ExpectedMonthlyTakeHome;
                Questions.ExpectedYearlyCTC = _ExpectedYearlyCTC;
                Questions.FunctionalArea = _FunctionalArea;
                Questions.Goals = _Goals;
                Questions.InBond = _InBond;
                Questions.InterviewedPosistion = _InterviewedPosistion;
                Questions.NoticePeriod = _NoticePeriod;
                Questions.PlaningForStudies = _PlaningForStudies;
                Questions.Ref1_Address = _Ref1_Address;
                Questions.Ref1_MobileNumber = _Ref1_MobileNumber;
                Questions.Ref1_Name = _Ref1_Name;
                Questions.Ref1_PhoneNumber = _Ref1_PhoneNumber;
                Questions.Ref2_Address = _Ref2_Address;
                Questions.Ref2_MobileNumber = _Ref2_MobileNumber;
                Questions.Ref2_Name = _Ref2_Name;
                Questions.Ref2_PhoneNumber = _Ref2_PhoneNumber;
                Questions.SelfDetails = _SelfDetails;
                Questions.WhyISutie = _WhyISutie;
                Questions.WillingToRelocate = _WillingToRelocate;
                Questions.PlaningForStudydetails = _PlaningForStudydetails;
                Questions.RelocatePlace = _RelocatePlace;
                Questions.BondDetails = _BondDetails;
                Questions.Ref1_Remarks = _Ref1_Remarks;
                Questions.Ref2_Remarks = _Ref2_Remarks;
                Questions.Ref_Remarks = _Ref_Remarks;
                Questions.Status = _Status;
                Questions.ReferenceCheckerID = _ReferenceCheckerID;

                if (_IsNew)
                {

                    Questions.ID = CandQuestBO.Create(Questions);
                }
                else
                {
                    Questions.ID = _ID;
                    CandQuestBO.Update(Questions);
                }
                if (IsLocalSession)
                {
                    DBSession.Commit();
                }
            }
            catch (Exception e)
            {
                if (IsLocalSession)
                {
                    DBSession.Rollback();
                }

                throw e;
            }
            finally
            {
                if (IsLocalSession)
                {
                    DBSession.Dispose();
                }
            }
            return String.Empty;
        }

        /// <summary>
        /// Save Candidate.If new Candidate it add and in case of edit it update the Candidate.
        /// </summary>
        /// <returns>empty string</returns>
        public String SaveRemarks(int ID, int ReferenceCheckerID, string Ref1_Remarks, string Ref2_Remarks, string Ref_Remarks, bool Status)
        {           
            try
            {
                Candidate_QuestionersBusinessObject CandQuestBO;
                CandQuestBO = new Candidate_QuestionersBusinessObject();

                Candidate_Questioners Questions = new Candidate_Questioners();
                Questions.ID = ID;
                Questions.ReferenceCheckerID = ReferenceCheckerID;
                Questions.Ref1_Remarks = Ref1_Remarks;
                Questions.Ref2_Remarks = Ref2_Remarks;
                Questions.Ref_Remarks = Ref_Remarks;
                Questions.Status = Status;
                              
                CandQuestBO.Update(Questions);
                
            }
            catch (Exception e)
            { 
                throw e;
            }
            finally
            {                
            }
            return String.Empty;
        }

        // <summary>
        ///Validate Candidate for empty and already exist status and then save Candidate.
        /// </summary>
        /// <returns>String return from the SaveCandidate method</returns> 
        public String Save()
        {
            //return SaveQuestions();
            return string.Empty;
        }
        /// <summary>
        /// Return all Candidates
        /// </summary>
        /// <returns>Array of the object of CandidatePersonalInfo class</returns>
        public static CandidateQuestioners[] GetAllCandidatQuestions()
        {
            Candidate_Questioners[] QuestionDT = new Candidate_QuestionersBusinessObject().GetCandidate_Questioners();

            CandidateQuestioners[] Question = new CandidateQuestioners[QuestionDT.Length];

            for (int i = 0; i < Question.Length; i++)
            {
                Question[i] = new CandidateQuestioners(QuestionDT[i]);
            }

            return Question;
        }

        /// <summary>
        /// Return all Candidates
        /// </summary>
        /// <returns>Array of the object of CandidatePersonalInfo class</returns>
        public static CandidateQuestioners[] GetAllCandidatQuestions(int candidateID)
        {
            Candidate_Questioners[] QuestionDT = new Candidate_QuestionersBusinessObject().GetQuestionersByCandidate(candidateID);

            CandidateQuestioners[] Question = new CandidateQuestioners[QuestionDT.Length];

            for (int i = 0; i < Question.Length; i++)
            {
                Question[i] = new CandidateQuestioners(QuestionDT[i]);
            }

            return Question;
        }
        #region JGridDataObject Members

        public object GetGridData()
        {
            CandidatQuestionDisplayDetails Questions = new CandidatQuestionDisplayDetails();

            Questions.CandQuestID= _ID;
            Questions.CandidateID = _CandidateID;
            Questions.Achievements = _Achievements;
            Questions.AlreadyInterviewed = _AlreadyInterviewed;
            Questions.Challenges = _Challenges;
            Questions.CommitmentYears = _CommitmentYears;
            Questions.EmployeerRemarks= _EmployeerRemarks;
            Questions.ExpectedMonthlyGross = _ExpectedMonthlyGross;
            Questions.ExpectedMonthlyTakeHome = _ExpectedMonthlyTakeHome;
            Questions.ExpectedYearlyCTC = _ExpectedYearlyCTC;
            Questions.FunctionalArea = _FunctionalArea;
            Questions.Goals = _Goals;
            Questions.InBond = _InBond;
            Questions.InterviewedPosistion = _InterviewedPosistion;
            Questions.NoticePeriod = _NoticePeriod;
            Questions.PlaningForStudies = _PlaningForStudies;
            Questions.Ref1_Address = _Ref1_Address;
            Questions.Ref1_MobileNumber = _Ref1_MobileNumber;
            Questions.Ref1_Name = _Ref1_Name;
            Questions.Ref1_PhoneNumber = _Ref1_PhoneNumber;
            Questions.Ref2_Address = _Ref2_Address;
            Questions.Ref2_MobileNumber = _Ref2_MobileNumber;
            Questions.Ref2_Name = _Ref2_Name;
            Questions.Ref2_PhoneNumber = _Ref2_PhoneNumber;
            Questions.SelfDetails = _SelfDetails;
            Questions.WhyISutie = _WhyISutie;
            Questions.WillingToRelocate = _WillingToRelocate;
            Questions.PlaningForStudydetails = _PlaningForStudydetails;
            Questions.RelocatePlace = _RelocatePlace;
            Questions.BondDetails = _BondDetails;
            Questions.Ref1_Remarks = _Ref1_Remarks;
            Questions.Ref2_Remarks = _Ref2_Remarks;
            Questions.Ref_Remarks = _Ref_Remarks;
            Questions.Status = _Status;
            Questions.ReferenceCheckerID = _ReferenceCheckerID;
            return Questions;
        }

        #endregion
    }
   public class CandidatQuestionDisplayDetails
   {
       public int CandQuestID;
       public int CandidateID;
       public String Achievements;
       public String Challenges;
       public String Goals;
       public String EmployeerRemarks;
       public short CommitmentYears;
       public double ExpectedMonthlyGross;
       public double ExpectedMonthlyTakeHome;
       public double ExpectedYearlyCTC;
       public short NoticePeriod;
       public bool WillingToRelocate;
       public bool InBond;
       public String SelfDetails;
       public String WhyISutie;
       public String FunctionalArea;
       public bool PlaningForStudies;
       public bool AlreadyInterviewed;
       public String InterviewedPosistion;
       public String Ref1_Name;
       public String Ref1_Address;
       public String Ref1_PhoneNumber;
       public String Ref1_MobileNumber;
       public String Ref2_Name;
       public String Ref2_Address;
       public String Ref2_PhoneNumber;
       public String Ref2_MobileNumber;
       public String PlaningForStudydetails;
       public String RelocatePlace;
       public String BondDetails;
       public String Ref1_Remarks;
       public String Ref2_Remarks;
       public String Ref_Remarks;
       public bool Status;
       public int ReferenceCheckerID;

   }
}
