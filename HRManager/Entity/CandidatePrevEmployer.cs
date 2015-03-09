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
  public  class CandidatePrevEmployer:JGridDataObject
    {
        private int _ID;
        private int _candidateID;
        private String _EmployerName;
        private String _Designation;
        private String _Responsibilities;
        private String _ResonForLeaving;
        private double _CTC;
        private double _TakeHome;
        private DateTime _StartDate;
        private DateTime _EndDate;
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
        public String EmployerName
        {
            get
            {
                return _EmployerName;
            }
            set
            {
                _EmployerName = value;
            }
        }
        public String Designation
        {
            get
            {
                return _Designation;
            }
            set
            {
                _Designation = value;
            }
        }
        public String Responsibilities
        {
            get
            {
                return _Responsibilities;
            }
            set
            {
                _Responsibilities = value;
            }
        }
        public String ResonForLeaving
        {
            get
            {
                return _ResonForLeaving;
            }
            set
            {
                _ResonForLeaving = value;
            }
        }
        public double CTC
        {
            get
            {
                return _CTC;
            }
            set
            {
                _CTC = value;
            }
        }
        public double TakeHome
        {
            get
            {
                return _TakeHome;
            }
            set
            {
                _TakeHome = value;
            }
        }
        public DateTime StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                _StartDate = value;
            }
        }
        public DateTime EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                _EndDate = value;
            }
        }

        // <summary>
        /// Update the Candidate PrevEmp field using Candidate_Prev_Employer.
        /// </summary>
        /// <param name="Candidate">Object of Candidate_Prev_Employer class</param>

        private void Update( Candidate_Prev_Employer PrevEmp)
        {
            if (PrevEmp != null)
            {
                _ID = PrevEmp.ID;
                _candidateID = PrevEmp.CandidateID;
                _EmployerName = PrevEmp.EmployerName;
                _Designation = PrevEmp.Designation;
                _Responsibilities = PrevEmp.Responsibilities;
                _ResonForLeaving = PrevEmp.ResonForLeaving;
                _CTC = PrevEmp.CTC;
                _TakeHome = PrevEmp.TakeHome;
                _StartDate = PrevEmp.StartDate;
                _EndDate = PrevEmp.EndDate;
            }
            else
            {
                _IsNew = true;
            }
        }

      /// <summary>
        /// Consturctor of CandidatePrevEmp  class.
        /// Update Candidate fields using Candidate_Education.
        /// </summary>
        /// <param name="Candidate">Object of Candidate_Prev_Employer class</param>
        public CandidatePrevEmployer(Candidate_Prev_Employer PrevEmp)
        {
            Update(PrevEmp);
        }
        /// <summary>
        /// Consturctor of CandidateEducation class.
        /// Update Candidate for given Candidate Education field.
        /// </summary>
        /// <param name="CandidateEducation">field contains Candidate Education</param>
        public CandidatePrevEmployer(String EmployerName,int candidateID)
        {
            Update(new Master_CandidateBusinessObject().GetPrevEmpByCandidate(EmployerName, candidateID));
        }

      /// <summary>
        /// Consturctor of Master_Candidate class.
       /// Update Candidate fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains Candidate ID</param>
        public CandidatePrevEmployer(int ID)
        {
            Candidate_Prev_Employer PrevEmp = new Candidate_Prev_EmployerBusinessObject().GetCandidate_Prev_Employer(ID);

            if (PrevEmp == null && ID > 0)
            {
                throw new IRCAException("Invalid Candidate", ID.ToString());
            }

            Update(PrevEmp);
        }
       /// <summary>
        /// Consturctor of CandidatePersonalInfo class.
        /// Set variables for new Candidate.  
        /// </summary>
        public CandidatePrevEmployer()
        {
            _ID = 0;
            _IsNew = true;
        }
        /// <summary>
        /// Save Candidate.If new Candidate it add and in case of edit it update the Candidate.
        /// </summary>
        /// <returns>empty string</returns>
        public String SaveCandidatePrev(Session DBSession)
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
                Candidate_Prev_EmployerBusinessObject CandPrevBO;
                CandPrevBO = new Candidate_Prev_EmployerBusinessObject(DBSession);

                Candidate_Prev_Employer PrevEmp = new Candidate_Prev_Employer();
                PrevEmp.ID = _ID;
                PrevEmp.CandidateID = _candidateID;
                PrevEmp.EmployerName = _EmployerName;
                PrevEmp.Designation = _Designation;
                PrevEmp.Responsibilities = _Responsibilities;
                PrevEmp.ResonForLeaving = _ResonForLeaving;
                PrevEmp.CTC = _CTC;
                PrevEmp.TakeHome = _TakeHome;
                PrevEmp.StartDate = _StartDate;
                PrevEmp.EndDate = _EndDate;
                if (_IsNew)
                {

                    PrevEmp.ID = CandPrevBO.Create(PrevEmp);
                }
                else
                {
                    PrevEmp.ID = _ID;
                    CandPrevBO.Update(PrevEmp);
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

            //return SaveCandidatePrev();
            return string.Empty;
        }
        /// <summary>
        /// Validate CandidateName for empty and already exist status.
        /// </summary>
        /// <returns>empty string</returns>
        private String Validate()
        {
            Master_CandidateBusinessObject CandidateBO = new Master_CandidateBusinessObject();

            if (CandidateBO.IsCandPrevEmpExists(_EmployerName, _candidateID, _ID))
            {
                return HRManagerDefs.CandidatePersonalInfoMessages.CANDIDATE_EXISTS;
            }
            return String.Empty;
        }
        /// <summary>
        /// Return all Candidates
        /// </summary>
        /// <returns>Array of the object of CandidatePersonalInfo class</returns>
        public static CandidatePrevEmployer[] GetAllCandidatEducations()
        {
            Candidate_Prev_Employer[] PrevEmpDT = new Candidate_Prev_EmployerBusinessObject().GetCandidate_Prev_Employer();

            CandidatePrevEmployer[] PrevEmp = new CandidatePrevEmployer[PrevEmpDT.Length];

            for (int i = 0; i < PrevEmp.Length; i++)
            {
                PrevEmp[i] = new CandidatePrevEmployer(PrevEmpDT[i]);
            }

            return PrevEmp;
        }
        /// <summary>
        /// Return all Candidates
        /// </summary>
        /// <returns>Array of the object of CandidatePersonalInfo class</returns>
        public static CandidatePrevEmployer[] GetAllCandidatEducations(int candidateID)
        {
            Candidate_Prev_Employer[] PrevEmpDT = new Candidate_Prev_EmployerBusinessObject().GetPrevEmpByCandidate(candidateID);

            CandidatePrevEmployer[] PrevEmp = new CandidatePrevEmployer[PrevEmpDT.Length];

            for (int i = 0; i < PrevEmp.Length; i++)
            {
                PrevEmp[i] = new CandidatePrevEmployer(PrevEmpDT[i]);
            }

            return PrevEmp;
        }
        #region JGridDataObject Members

        public object GetGridData()
        {
            CandidatePrevEmpDisplayDetails PrevEMp = new CandidatePrevEmpDisplayDetails();

            PrevEMp.CandPrevEmpID = _ID;
            PrevEMp.CandidateID = _candidateID;
            PrevEMp.Organization = _EmployerName;
            PrevEMp.Designation = _Designation;
            PrevEMp.Responsibilities = _Responsibilities;
            PrevEMp.ReasonForLeaving = _ResonForLeaving;
            PrevEMp.YearlyCTC = _CTC;
            PrevEMp.MonthlyTakeHome = _TakeHome;
            PrevEMp.WorkingFrom = _StartDate;
            PrevEMp.WorkingTo = _EndDate;

            return PrevEMp;
        }

        #endregion

    }
  public class CandidatePrevEmpDisplayDetails
  {
      public int CandPrevEmpID;
      public int CandidateID;
      public String Organization;
      public String Designation;
      public String Responsibilities;
      public String ReasonForLeaving;
      public DateTime WorkingFrom;
      public DateTime WorkingTo;
      public double YearlyCTC;
      public double MonthlyTakeHome;

  }
}
