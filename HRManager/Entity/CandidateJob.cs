using System;
using System.Collections.Generic;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IS91.Services.DataBlock;


namespace HRManager.Entity
{
   public class CandidateJob
    {
        private int _ID;
        private int _candidateID;
        private int _jobID;
        private String _Status;
        private DateTime _AppliedDate;
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
        public int jobID
        {
            get
            {
                return _jobID;
            }
            set
            {
                _jobID = value;
            }
        }
        public String Status
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
        public DateTime AppliedDate
        {
            get
            {
                return _AppliedDate;
            }
            set
            {
                _AppliedDate = value;
            }
        }
        // <summary>
        /// Update the Candidate field using Master_Candidate.
        /// </summary>
        /// <param name="Candidate">Object of Master_Candidate class</param>

        private void Update( Candidate_JobDetails Jobs)
        {
            if (Jobs != null)
            {
                _ID = Jobs.ID;
                _candidateID = Jobs.CandidateID;
                _jobID = Jobs.JobID;
                _Status = Jobs.Status;
                _AppliedDate = Jobs.AppliedDate;
                
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
        public CandidateJob(Candidate_JobDetails Jobs)
        {
            Update(Jobs);
        }

        /// <summary>
        /// Consturctor of CandidateEducation class.
        /// Update Candidate for given Candidate Education field.
        /// </summary>
        /// <param name="CandidateEducation">field contains Candidate Education</param>
        public CandidateJob(String candidateJobid)
        {
            Update(new Master_CandidateBusinessObject().GetJobsByCandidate(_candidateID));
        }
        /// <summary>
        /// Consturctor of Master_Candidate class.
       /// Update Candidate fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains Candidate ID</param>
        public CandidateJob(int ID)
        {
            Candidate_JobDetails Jobs = new Candidate_JobDetailsBusinessObject().GetCandidate_JobDetails(ID);

            if (Jobs == null && ID > 0)
            {
                throw new IRCAException("Invalid Candidate Job", ID.ToString());
            }

            Update(Jobs);
        }
       
       /// <summary>
        /// Consturctor of CandidatePersonalInfo class.
        /// Set variables for new Candidate.  
        /// </summary>
        public CandidateJob()
        {
            _ID = 0;
            _IsNew = true;
        }
        /// <summary>
        /// Save Candidate.If new Candidate it add and in case of edit it update the Candidate.
        /// </summary>
        /// <returns>empty string</returns>
        public String SaveJobs(Session DBSession)
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

                Candidate_JobDetailsBusinessObject CandJobBO;
                CandJobBO = new Candidate_JobDetailsBusinessObject(DBSession);
            Candidate_JobDetails Jobs = new Candidate_JobDetails();
            Jobs.ID = _ID;
            Jobs.CandidateID = _candidateID;
            Jobs.JobID = _jobID;
            Jobs.Status= _Status;
            Jobs.AppliedDate = _AppliedDate;
            if (_IsNew)
            {

                Jobs.ID = CandJobBO.Create(Jobs);
            }
            else
            {
                Jobs.ID = _ID;
                CandJobBO.Update(Jobs);
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
          // return SaveJobs();
            return string.Empty;
        }

        /// <summary>
        /// Save Candidate.If new Candidate it add and in case of edit it update the Candidate.
        /// </summary>
        /// <returns>empty string</returns>
        private String SaveJobs()
        {
         
            try
            {

                Candidate_JobDetailsBusinessObject CandJobBO;
                CandJobBO = new Candidate_JobDetailsBusinessObject();
                Candidate_JobDetails Jobs = new Candidate_JobDetails();
                Jobs.ID = _ID;
                Jobs.CandidateID = _candidateID;
                Jobs.JobID = _jobID;
                Jobs.Status = _Status;
                Jobs.AppliedDate = _AppliedDate;
                if (_IsNew)
                {

                    Jobs.ID = CandJobBO.Create(Jobs);
                }
                else
                {
                    Jobs.ID = _ID;
                    CandJobBO.Update(Jobs);
                }
                
            }
            catch (Exception e)
            {
                throw e;
            }
            
            return String.Empty;
        }
        /// <summary>
        /// Activate the JobProfile
        /// </summary>
        /// <param name="ActivatedBy">id of user who want to activate JobProfile</param>
        /// <returns>String return from the SaveJobProfile method</returns>
        public String Approve(string Status)
        {
            _AppliedDate = DateTime.Now;
            _Status = Status;
            return SaveJobs();
        }
        /// <summary>
        /// Deactivate the JobProfile
        /// </summary>
        /// <param name="DeActivatedBy">id of user who want to DeActivate JobProfile</param>
        /// <returns>String return from the SaveJobProfile method</returns>
        public String Reject(string Status)
        {
            _AppliedDate = DateTime.Now;
            _Status = Status;
             return SaveJobs();
        }

      
        
    }
   public class OfferLetter
   {
       public int DesignationID;
       public String OfferLetterName;
   }
   public class OfferLetterParameters
   {
       public string CandidateName;
       public string Designation;
       public string Branch;
       public string ReportingTo;
       public string TrainingLocation;
       public string TrainingAddress1;
       public string TrainingAddress2;
       public string TrainingAddress3;
       public string Grade;
       public string ResponseDate;
       public string Sender;
       public string SenderDesignation;
       public string OnlyCandidateName;
       public string Address1;
       public string Address2;
       public string Address3;
       public string Cell;
   }

}
