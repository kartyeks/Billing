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
   public class CandidateTraining:JGridDataObject
    {
        private int _ID;
        private int _candidateID;
        private String _OrganizedBy;
        private String _Duration;
        private String _Subject;
        private String _Certificate;
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

        public String OrganizedBy
        {
            get
            {
                return _OrganizedBy;
            }
            set
            {
                _OrganizedBy = value;
            }
        }

        public String Duration
        {
            get
            {
                return _Duration;
            }
            set
            {
                _Duration = value;
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
        public String Certificate
        {
            get
            {
                return _Certificate;
            }
            set
            {
                _Certificate = value;
            }
        }

        /// <summary>
        /// Update the Language field using Assign_Candidate_Language.
        /// </summary>
        /// <param name="Language">Object of Assign_Candidate_Language class</param>
        private void Update(Candidate_TrainingDetails  Training)
        {
            if (Training != null)
            {
                _ID = Training.ID;
                _candidateID = Training.CandidateID;
                _OrganizedBy = Training.OrganizedBy;
                _Duration = Training.Duration;
                _Subject = Training.Subject;
                _Certificate= Training.Certificate;
                _IsNew = false;

            }
            else
            {
                _IsNew = true;
            }
        }

           /// <summary>
       /// Consturctor of Language class.
       /// Update Language fields using Assign_Candidate_Language.
        /// </summary>
       /// <param name="Language">Object of Assign_Candidate_Language class</param>
        public CandidateTraining(Candidate_TrainingDetails Training)
        {
            Update(Training);
        }

        
        /// <summary>
        /// Consturctor of Language class.
       /// Update Language fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains Language ID</param>
        public CandidateTraining(int ID)
        {
            Candidate_TrainingDetails Training = new Candidate_TrainingDetailsBusinessObject().GetCandidate_TrainingDetails(ID);

            if (Training == null && ID > 0)
            {
                throw new IRCAException("Invalid Candidate Training", ID.ToString());
            }

            Update(Training);
        }

         /// <summary>
        /// Consturctor of Language class.
        /// Set variables for new Language.  
        /// </summary>
        public CandidateTraining()
        {
            _ID = 0;
            _IsNew = true;
        }

        /// <summary>
        /// Save Language.If new Language it add and in case of edit it update the Language.
        /// </summary>
        /// <returns>empty string</returns>
        public String SaveTraining(Session DBSession)
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
                Candidate_TrainingDetailsBusinessObject CandTranBO;
                CandTranBO = new Candidate_TrainingDetailsBusinessObject(DBSession);
                Candidate_TrainingDetails Tran = new Candidate_TrainingDetails();
                Tran.ID = _ID;
                Tran.CandidateID = _candidateID;
                Tran.OrganizedBy = _OrganizedBy;
                Tran.Duration = _Duration;
                Tran.Subject = _Subject;
                Tran.Certificate = _Certificate;

                if (_IsNew)
                {

                    Tran.ID = CandTranBO.Create(Tran);
                }
                else
                {
                    Tran.ID = _ID;
                    CandTranBO.Update(Tran);
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
        ///Validate Language for empty and already exist status and then save Language.
        /// </summary>
        /// <returns>String return from the SaveLanguage method</returns> 
        public String Save()
        {
            String Status = string.Empty; // Validate();

            //if (Status != String.Empty)
            //{
            //    return Status;
            //}
            return Status;
           // return SaveLanguage();
        }
        /// <summary>
        /// Return all Language
        /// </summary>
        /// <returns>Array of the object of Language class</returns>
        public static CandidateTraining[] GetAllTrainings()
        {
            Candidate_TrainingDetails[] TrainingDT = new Candidate_TrainingDetailsBusinessObject().GetCandidate_TrainingDetails();

            CandidateTraining[] Training = new CandidateTraining[TrainingDT.Length];

            for (int i = 0; i < Training.Length; i++)
            {
                Training[i] = new CandidateTraining(TrainingDT[i]);
            }

            return Training;
        }
        /// <summary>
        /// Return all candidate  related Family_Detailss
        /// </summary>
        /// <returns>Array of the object of Family_Details class</returns>
        public static CandidateTraining[] getCandidateTrainingDetailss(int candidateID)
        {
            Candidate_TrainingDetails[] Training_DetailssDT = new Candidate_TrainingDetailsBusinessObject().GetTrainingdetailsByCandidate(candidateID);

            CandidateTraining[] CandidateTraining = new CandidateTraining[Training_DetailssDT.Length];

            for (int i = 0; i < CandidateTraining.Length; i++)
            {
                CandidateTraining[i] = new CandidateTraining(Training_DetailssDT[i]);
            }

            return CandidateTraining;
        }
        #region JGridDataObject Members

        public object GetGridData()
        {
            TrainingDisplayDetails Training = new TrainingDisplayDetails();

            Training.TrainingID = _ID;
            Training.TCandidateID = _candidateID;
            Training.OrganizedBy = _OrganizedBy;
            Training.Duration = _Duration;
            Training.Subject = _Subject;
            Training.Certificate = _Certificate;

            return Training;
        }

        #endregion
     
    }
   public class TrainingDisplayDetails
   {
       public int TrainingID;
       public int TCandidateID;
       public String OrganizedBy;
       public String Duration;
       public String Subject;
       public String Certificate;
   }
}
