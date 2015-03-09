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
  public  class CandidateEducation:JGridDataObject
    {
        private int _ID;
        private int _candidateID;
        private String _Title;
        private String _Subject;
        private String _Institute;
        private double _Percentage;
        private String _Grade;
        private DateTime _FromDate;
        private DateTime _ToDate;
        private bool _IsNew;

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
        public int candidateID
        {
            get
            {
                return _candidateID;
            }
            set
            {
                _candidateID = value;
            }
        }
        public String Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
            }
        }
        public String Subject
        {
            get
            {
                return _Subject;
            }
            set
            {
                _Subject = value;
            }
        }
        public String Institute
        {
            get
            {
                return _Institute;
            }
            set
            {
                _Institute = value;
            }
        }
        public String Grade
        {
            get
            {
                return _Grade;
            }
            set
            {
                _Grade = value;
            }
        }
        public double Percentage
        {
            get
            {
                return _Percentage;
            }
            set
            {
                _Percentage = value;
            }
        }
        public DateTime FromDate
        {
            get
            {
                return _FromDate;
            }
            set
            {
                _FromDate = value;
            }
        }
        public DateTime ToDate
        {
            get
            {
                return _ToDate;
            }
            set
            {
                _ToDate = value;
            }
        }
       
      // <summary>
        /// Update the Candidate field using Master_Candidate.
        /// </summary>
        /// <param name="Candidate">Object of Master_Candidate class</param>

        private void Update(Candidate_Education Education)
        {
            if (Education != null)
            {
                _ID = Education.ID;
                _candidateID = Education.CandidateID;
                _Title = Education.Title;
                _Subject = Education.Subject;
                _Institute = Education.Institute;
                _Percentage = Education.Percentage;
                _Grade = Education.Grade;
                _FromDate = Education.FromDate;
                _ToDate = Education.ToDate;
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
        public CandidateEducation(Candidate_Education Education)
        {
            Update(Education);
        }
      /// <summary>
        /// Consturctor of CandidateEducation class.
        /// Update Candidate for given Candidate Education field.
        /// </summary>
        /// <param name="CandidateEducation">field contains Candidate Education</param>
        public CandidateEducation(String Education)
        {
            Update(new Master_CandidateBusinessObject().GetEducationByCandidate(_candidateID));
        }

      /// <summary>
        /// Consturctor of Master_Candidate class.
       /// Update Candidate fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains Candidate ID</param>
        public CandidateEducation(int ID)
        {
            Candidate_Education Education = new Candidate_EducationBusinessObject().GetCandidate_Education(ID);

            if (Education == null && ID > 0)
            {
                throw new IRCAException("Invalid Candidate Education", ID.ToString());
            }

            Update(Education);
        }
      
       /// <summary>
        /// Consturctor of CandidatePersonalInfo class.
        /// Set variables for new Candidate.  
        /// </summary>
        public CandidateEducation()
        {
            _ID = 0;
            _IsNew = true;
        }
      /// <summary>
        /// Save Candidate.If new Candidate it add and in case of edit it update the Candidate.
        /// </summary>
        /// <returns>empty string</returns>
        public String SaveEducation(Session DBSession)
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
                Candidate_EducationBusinessObject CandEducBO;
                CandEducBO = new Candidate_EducationBusinessObject(DBSession);

                Candidate_Education Education = new Candidate_Education();
                Education.ID = _ID;
                Education.CandidateID = _candidateID;
                Education.Title = _Title;
                Education.Subject = _Subject;
                Education.Percentage = _Percentage;
                Education.Institute = _Institute;
                Education.Grade = _Grade;
                Education.FromDate = _FromDate;
                Education.ToDate = _ToDate;
                if (_IsNew)
                {

                    Education.ID = CandEducBO.Create(Education);
                }
                else
                {
                    Education.ID = _ID;
                    CandEducBO.Update(Education);
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
        // <summary>
        ///Validate Candidate for empty and already exist status and then save Candidate.
        /// </summary>
        /// <returns>String return from the SaveCandidate method</returns> 
        public String Save()
        {
            //String Status = Validate();

            //if (Status != String.Empty)
            //{
            //    return Status;
            //}

            //return SaveEducation();
            return string.Empty;
        }
        /// <summary>
        /// Validate CandidateName for empty and already exist status.
        /// </summary>
        /// <returns>empty string</returns>
        private String Validate()
        {
            Master_CandidateBusinessObject CandidateBO = new Master_CandidateBusinessObject();

           if (CandidateBO.IsCandEducationExists(_Subject, _candidateID, _ID))
            {
                return HRManagerDefs.CandidatePersonalInfoMessages.CANDIDATE_EXISTS;
            }
            return String.Empty;
        }
        /// <summary>
        /// Return all Candidates
        /// </summary>
        /// <returns>Array of the object of CandidatePersonalInfo class</returns>
        public static CandidateEducation[] GetAllCandidatEducations()
        {
            Candidate_Education[] EducationDT = new Candidate_EducationBusinessObject().GetCandidate_Education();

            CandidateEducation[] Education = new CandidateEducation[EducationDT.Length];

            for (int i = 0; i < Education.Length; i++)
            {
                Education[i] = new CandidateEducation(EducationDT[i]);
            }

            return Education;
        }
        public static CandidateEducation[] GetAllCandidatEducations(int CandidateID)
        {
            Candidate_Education[] EducationDT = new Candidate_EducationBusinessObject().GetEducationByCandidate(CandidateID);

            CandidateEducation[] Education = new CandidateEducation[EducationDT.Length];

            for (int i = 0; i < Education.Length; i++)
            {
                Education[i] = new CandidateEducation(EducationDT[i]);
            }

            return Education;
        }
        #region JGridDataObject Members

        public object GetGridData()
        {
            CandidateEducationDisplayDetails Education = new CandidateEducationDisplayDetails();

            Education.CandEducatID = _ID;
            Education.CandidateID = _candidateID;
            Education.Title = _Title;
            Education.Specialisation= _Subject;
            Education.College = _Institute;
            Education.Percentage = _Percentage;
            Education.Grade = _Grade;
            Education.FromDate = _FromDate;
            Education.ToDate = _ToDate;
     
            return Education;
        }

        #endregion
    }
  public class CandidateEducationDisplayDetails
  {
      public int CandEducatID;
      public int CandidateID;
      public String Title;
      public String Specialisation;
      public String College;
      public double Percentage;
      public DateTime FromDate;
      public DateTime ToDate;
      public String Grade;

  }
}
