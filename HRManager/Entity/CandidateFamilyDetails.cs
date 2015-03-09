using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IS91.Services.DataBlock;
using IRCA.Communication;


namespace HRManager.Entity
{
    /// <summary>
    /// Represents Family_Details fields and methods.
    /// </summary>
    public class CandidateFamilyDetails : JGridDataObject
    {
        private int _ID;
        private int _CandidateId;
        private int _RelationID;
        private String _Name;
        private DateTime _DateOfBirth;
        private String _Occupation;
        private String _AnnualIncome;
        private bool _IsNew;
        private Relation _Relation = null;
        private bool _IsActive;

        public bool IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                _IsActive = value;
            }
        }

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

        public int CandidateID
        {
            get
            {
                return _CandidateId;
            }
            set
            {
                _CandidateId = value;
            }
        }

        public int RelationID
        {
            get
            {
                return _RelationID;
            }
            set
            {
                _RelationID = value;
            }
        }

        public String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return _DateOfBirth;
            }
            set
            {
                _DateOfBirth = value;
            }
        }

        public String Occupation
        {
            get
            {
                return _Occupation;
            }
            set
            {
                _Occupation = value;
            }
        }

        public String AnnualIncome
        {
            get
            {
                return _AnnualIncome;
            }
            set
            {
                _AnnualIncome = value;
            }
        }

        public Relation Relation
        {
            get
            {
                return _Relation;
            }
            set
            {
                _Relation = value;
            }
        }
        public String RelationName
        {
            get
            {
                if (_Relation != null)
                {
                    return _Relation.RelationName;
                }
                else
                {
                    return String.Empty;
                }
            }
        }
 
        /// <summary>
        /// Update the Family_Details field using Candidate_FamilyDetails.
        /// </summary>
        /// <param name="Family_Details">Object of Candidate_FamilyDetails class</param>
        private void Update(Candidate_FamilyDetails Family_Details)
        {
            if (Family_Details != null)
            {
                _ID = Family_Details.ID;
                _CandidateId = Family_Details.CandidateID;
                _RelationID = Family_Details.RelationID;
                _Relation = new Relation(Family_Details.RelationID);
                _Name = Family_Details.Name;
                _DateOfBirth = Family_Details.DateOfBirth;
                _Occupation = Family_Details.Occupation;
                _AnnualIncome = Family_Details.AnnualIncome;
                _IsActive = Family_Details.IsActive;
                _IsNew = false;
            }
            else
            {
                _IsNew = true;
            }
        }
        /// <summary>
        /// Consturctor of Family_Details class.
        /// Update Family_Details fields using Candidate_FamilyDetails.
        /// </summary>
        /// <param name="Family_Details">Object of Candidate_FamilyDetails class</param>
        public CandidateFamilyDetails(Candidate_FamilyDetails Family_Details)
        {
            Update(Family_Details);
        }
        /// <summary>
        /// Consturctor of Family_Details class.
        /// Update Family_Details for given Family_DetailsName field.
        /// </summary>
        /// <param name="Family_DetailsName">field contains Family_Details Name</param>
        public CandidateFamilyDetails(String Name,int candidateID)
        {
           // Update(new Candidate_FamilyDetailsBusinessObject().GetFamily_DetailsByFamily_Details(Family_DetailsName,candidateID));
         Update(new Candidate_FamilyDetailsBusinessObject().GetFamilydetailsByCandidate(Name,candidateID));
        }
        /// <summary>
        /// Consturctor of Family_Details class.
        /// Update Family_Details fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains Designation ID</param>
        public CandidateFamilyDetails(int ID)
        {
            Candidate_FamilyDetails Family_Details = new Candidate_FamilyDetailsBusinessObject().GetCandidate_FamilyDetails(ID);

            if (Family_Details == null && ID > 0)
            {
                throw new IRCAException("Invalid Family_Details", ID.ToString());
            }

            Update(Family_Details);
        }
        /// <summary>
        /// Consturctor of Family_Details class.
        /// Set variables for new Family_Details.  
        /// </summary>
        public CandidateFamilyDetails()
        {
            _ID = 0;
            _IsNew = true;
        }
        /// <summary>
        /// Save Family_Details.If new Family_Details it add and in case of edit it update the Family_Details.
        /// </summary>
        /// <returns>empty string</returns>
        public String SaveFamily_Details(Session DBSession)
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
                Candidate_FamilyDetailsBusinessObject CandFamilyBO;
                CandFamilyBO = new Candidate_FamilyDetailsBusinessObject(DBSession);

                Candidate_FamilyDetails Family_Details = new Candidate_FamilyDetails();
                Family_Details.ID = _ID;
                Family_Details.CandidateID = _CandidateId;
                Family_Details.RelationID = _RelationID;
                Family_Details.Name = _Name;
                Family_Details.DateOfBirth = _DateOfBirth;
                Family_Details.Occupation = _Occupation;
                Family_Details.AnnualIncome = _AnnualIncome;
                Family_Details.IsActive = true;

                if (_IsNew)
                {
                    Family_Details.ID = CandFamilyBO.Create(Family_Details);
                }
                else
                {
                    Family_Details.ID = _ID;
                    CandFamilyBO.Update(Family_Details);
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
        ///Validate Family_Details for empty and already exist status and then save Family_Details.
        /// </summary>
        /// <returns>String return from the SaveFamily_Details method</returns> 
        public String Save(Session DBSession)
        {
            //String Status = Validate();

            //if (Status != String.Empty)
            //{
            //    return Status;
            //}

            return SaveFamily_Details(DBSession);
            //return string.Empty;
        }
        /// <summary>
        /// Validate Family_DetailsName for empty and already exist status.
        /// </summary>
        /// <returns>empty string</returns>
        private String Validate()
        {
            Candidate_FamilyDetailsBusinessObject Family_DetailsBO = new Candidate_FamilyDetailsBusinessObject();

            if (_Name == String.Empty)
            {
                return HRManagerDefs.Family_DetailsMessages.EMPTY_FAMILY_DETAILS;
            }
            else if(Family_DetailsBO.IsFamilyDetailsExists(_Name,_ID,_CandidateId))
            {
                return HRManagerDefs.Family_DetailsMessages.FAMILY_DETAILS_EXISTS;
            }
            return String.Empty;
        }
        
        /// <summary>
        /// Return all Family_Detailss
        /// </summary>
        /// <returns>Array of the object of Family_Details class</returns>
        public static CandidateFamilyDetails[] GetAllFamily_Detailss()
        {
            Candidate_FamilyDetails[] Family_DetailssDT = new Candidate_FamilyDetailsBusinessObject().GetCandidate_FamilyDetails();

            CandidateFamilyDetails[] Family_Detailss = new CandidateFamilyDetails[Family_DetailssDT.Length];

            for (int i = 0; i < Family_Detailss.Length; i++)
            {
                Family_Detailss[i] = new CandidateFamilyDetails(Family_DetailssDT[i]);
            }

            return Family_Detailss;
        }
        /// <summary>
        /// Return all candidate  related Family_Detailss
        /// </summary>
        /// <returns>Array of the object of Family_Details class</returns>
        public static CandidateFamilyDetails[] GetFamilyDetailss(int candidateID)
        {
            Candidate_FamilyDetails[] Family_DetailssDT = new Candidate_FamilyDetailsBusinessObject().GetFamilydetailsByCandidate(candidateID);

            CandidateFamilyDetails[] Family_Detailss = new CandidateFamilyDetails[Family_DetailssDT.Length];

            for (int i = 0; i < Family_Detailss.Length; i++)
            {
                Family_Detailss[i] = new CandidateFamilyDetails(Family_DetailssDT[i]);
            }

            return Family_Detailss;
        }
        public String Save()
        {
            try
            {
                Candidate_FamilyDetailsBusinessObject BO = new Candidate_FamilyDetailsBusinessObject();
                Candidate_FamilyDetails DTO = GetDTO();

                if (_ID != 0)
                {
                    BO.Update(DTO);
                }
                else
                {
                    _ID = BO.Create(DTO);
                }

                return String.Empty;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(ex);
                return ex.Message;
            }
        }
        private Candidate_FamilyDetails GetDTO()
        {
            Candidate_FamilyDetails DTO = new Candidate_FamilyDetails();
            DTO.ID = _ID;
            DTO.CandidateID = _CandidateId;
            DTO.RelationID = _RelationID;
            DTO.Name = _Name;
            DTO.DateOfBirth = _DateOfBirth;
            DTO.Occupation = _Occupation;
            DTO.AnnualIncome = _AnnualIncome;
            DTO.IsActive = _IsActive;

            return DTO;
        }
        public String ISActiveUpdateFamilyDetails(int CandidateID)
        {
            String Result = String.Empty;

            try
            {
                if (Result == String.Empty)
                {
                    new Candidate_FamilyDetailsBusinessObject().ISActiveUpdateFamilyDetails(CandidateID);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Result;
        }
        #region JGridDataObject Members

        public object GetGridData()
        {
            Family_DetailsDisplayDetails Family_Details = new Family_DetailsDisplayDetails();

            Family_Details.id = _ID;
            Family_Details.candidateID = _CandidateId;
            Family_Details.RelationID = _RelationID ;
            Family_Details.Relation = RelationName;
            String xDate = "";
            if (_DateOfBirth.Date.ToString() != "01/01/1900 00:00:00") xDate = _DateOfBirth.Date.ToString().Substring(0, 10);
            Family_Details.DateOfBirth = xDate;
            Family_Details.Name = _Name;
            Family_Details.Occupation = _Occupation;
            Family_Details.AnnualIncome = _AnnualIncome;

            return Family_Details;
        }

        #endregion
    }
    public class Family_DetailsDisplayDetails
    {
        public int id;
        public int candidateID;
        public int RelationID;
        public String Relation;
        public String Name;
        public String DateOfBirth;
        public String Occupation;
        public String AnnualIncome;
    }
}

 
