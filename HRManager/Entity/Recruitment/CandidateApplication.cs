using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;

namespace HRManager.Entity.Recruitment
{
    public class MasterCandidate
    {
        private int _ID;
        private String _FirstName;
        private String _MiddleName;
        private String _LastName;
        private String _Education;
        private String _CurrentEmployer;
        private DateTime _CarrierStartDate;
        private String _CurentExperience;
        private String _TechnologyExpertise;
        private String _ContactNumber;
        private String _EmailID;
        private int _NoticePeriod;
        private String _CurrentLocation;
        private String _JobChangeReason;
        private String _OffersinHand;
        private Byte[] _Resume;
        private bool _IsActive;
        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;

        public int ID { get { return _ID; } set { _ID = value; } }
        public String FirstName { get { return _FirstName; } set { _FirstName = value; } }
        public String MiddleName { get { return _MiddleName; } set { _MiddleName = value; } }
        public String LastName { get { return _LastName; } set { _LastName = value; } }
        public String Education { get { return _Education; } set { _Education = value; } }
        public String CurrentEmployer { get { return _CurrentEmployer; } set { _CurrentEmployer = value; } }
        public DateTime CarrierStartDate { get { return _CarrierStartDate; } set { _CarrierStartDate = value; } }
        public String CurentExperience { get { return _CurentExperience; } set { _CurentExperience = value; } }
        public String TechnologyExpertise { get { return _TechnologyExpertise; } set { _TechnologyExpertise = value; } }
        public String ContactNumber { get { return _ContactNumber; } set { _ContactNumber = value; } }
        public String EmailID { get { return _EmailID; } set { _EmailID = value; } }
        public int NoticePeriod { get { return _NoticePeriod; } set { _NoticePeriod = value; } }
        public String CurrentLocation { get { return _CurrentLocation; } set { _CurrentLocation = value; } }
        public String JobChangeReason { get { return _JobChangeReason; } set { _JobChangeReason = value; } }
        public String OffersinHand { get { return _OffersinHand; } set { _OffersinHand = value; } }
        public byte[] Resume { get { return _Resume; } set { _Resume = value; } }
        public bool IsActive { get { return _IsActive; } set { _IsActive = value; } }
        public int CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }
        public DateTime CreatedDate { get { return _CreatedDate; } set { _CreatedDate = value; } }
        public int ModifiedBy { get { return _ModifiedBy; } set { _ModifiedBy = value; } }
        public DateTime ModifiedDate { get { return _ModifiedDate; } set { _ModifiedDate = value; } }

        public MasterCandidate() { }

        public MasterCandidate(int ID)
        {
            Update(new Master_CandidateBusinessObject().GetMaster_Candidate(ID));
        }

        private void Update(Master_Candidate DTO)
        {
            if (DTO != null)
            {
                _ID = DTO.ID;
                _FirstName = DTO.FirstName;
                _MiddleName = DTO.MiddleName;
                _LastName = DTO.LastName;
                _Education = DTO.Education;
                _CurrentEmployer = DTO.CurrentEmployer;
                _CarrierStartDate = DTO.CarrierStartDate;
                _CurentExperience = DTO.CurentExperience;
                _TechnologyExpertise = DTO.TechnologyExpertise;
                _ContactNumber = DTO.ContactNumber;
                _EmailID = DTO.EmailID;
                _NoticePeriod = DTO.NoticePeriod;
                _CurrentLocation = DTO.CurrentLocation;
                _JobChangeReason = DTO.JobChangeReason;
                _OffersinHand = DTO.OffersinHand;
                _Resume = DTO.Resume;
                _IsActive = DTO.IsActive;
                _CreatedBy = DTO.CreatedBy;
                _CreatedDate = DTO.CreatedDate;
                _ModifiedBy = DTO.ModifiedBy;
                _ModifiedDate = DTO.ModifiedDate;
            }
        }

        private Master_Candidate GetDTO()
        {
            Master_Candidate DTO = new Master_Candidate();

            DTO.ID = _ID;
            DTO.FirstName = _FirstName;
            DTO.MiddleName = _MiddleName;
            DTO.LastName = _LastName;
            DTO.Education = _Education;
            DTO.CurrentEmployer = _CurrentEmployer;
            DTO.CarrierStartDate = _CarrierStartDate;
            DTO.CurentExperience = _CurentExperience;
            DTO.TechnologyExpertise = _TechnologyExpertise;
            DTO.ContactNumber = _ContactNumber;
            DTO.EmailID = _EmailID;
            DTO.NoticePeriod = _NoticePeriod;
            DTO.CurrentLocation = _CurrentLocation;
            DTO.JobChangeReason = _JobChangeReason;
            DTO.OffersinHand = _OffersinHand;
            DTO.Resume = _Resume;
            DTO.IsActive = _IsActive;

            if (_ID == 0)
            {
                DTO.CreatedBy = 0;
                DTO.CreatedDate = DateTime.Now;
            }
            else
            {
                DTO.CreatedBy = _CreatedBy;
                DTO.CreatedDate = _CreatedDate;
            }

            DTO.ModifiedBy = _ModifiedBy;
            DTO.ModifiedDate = _ModifiedDate;
            return DTO;
        }

        public String Save() 
        {
            try 
            { 
                Master_CandidateBusinessObject BO = new Master_CandidateBusinessObject();
                Master_Candidate DTO = GetDTO(); 
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
                IRCAExceptionHandler.HandleException(ex); return ex.Message; 
            } 
        }
    }
}
