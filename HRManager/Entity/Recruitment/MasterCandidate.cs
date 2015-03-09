using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.BusinessObjects;
using IRCAKernel;
using HRManager.DTO;
using IRCA.Communication;
using HRManager.DTOEXT.Recruitment;

namespace HRManager.Entity.Recruitment
{
    public class MasterCandidate : JGridDataObject
    {
        private int _ID;
        private int _TeamID;
        private String _CandidateType;
        private String _FirstName;
        private String _MiddleName;
        private String _LastName;
        private String _CurrentEmployer;
        private DateTime _CareerStartDate;
        private String _Experience;
        private String _TechnologyExpertise;
        private String _ContactNumber;
        private String _EmailID;
        private int _NoticePeriod;
        private String _CurrentLocation;
        private String _ReasonForChange;
        private String _OffersInHand;
        private String _ResumeFilename;
        private String _RecruitmentType;
        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;
        private bool _IsDeleted;

        private String _TeamName;
        private String _ManagerName;
        private int _InterviewStatusID;
        private String _Status;

        public int ID { get { return _ID; } set { _ID = value; } }
        public int TeamID { get { return _TeamID; } set { _TeamID = value; } }
        public String CandidateType { get { return _CandidateType; } set { _CandidateType = value; } }
        public String FirstName { get { return _FirstName; } set { _FirstName = value; } }
        public String MiddleName { get { return _MiddleName; } set { _MiddleName = value; } }
        public String LastName { get { return _LastName; } set { _LastName = value; } }
        public String CurrentEmployer { get { return _CurrentEmployer; } set { _CurrentEmployer = value; } }
        public DateTime CareerStartDate { get { return _CareerStartDate; } set { _CareerStartDate = value; } }
        public String Experience { get { return _Experience; } set { _Experience = value; } }
        public String TechnologyExpertise { get { return _TechnologyExpertise; } set { _TechnologyExpertise = value; } }
        public String ContactNumber { get { return _ContactNumber; } set { _ContactNumber = value; } }
        public String EmailID { get { return _EmailID; } set { _EmailID = value; } }
        public int NoticePeriod { get { return _NoticePeriod; } set { _NoticePeriod = value; } }
        public String CurrentLocation { get { return _CurrentLocation; } set { _CurrentLocation = value; } }
        public String ReasonForChange { get { return _ReasonForChange; } set { _ReasonForChange = value; } }
        public String OffersInHand { get { return _OffersInHand; } set { _OffersInHand = value; } }
        public String ResumeFilename { get { return _ResumeFilename; } set { _ResumeFilename = value; } }
        public String RecruitmentType { get { return _RecruitmentType; } set { _RecruitmentType = value; } }
        public int CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }
        public DateTime CreatedDate { get { return _CreatedDate; } set { _CreatedDate = value; } }
        public int ModifiedBy { get { return _ModifiedBy; } set { _ModifiedBy = value; } }
        public DateTime ModifiedDate { get { return _ModifiedDate; } set { _ModifiedDate = value; } }
        public bool IsDeleted { get { return _IsDeleted; } set { _IsDeleted = value; } }

        public String TeamName { get { return _TeamName; } set { _TeamName = value; } }
        public String ManagerName { get { return _ManagerName; } set { _ManagerName = value; } }
        public int InterviewStatusID { get { return _InterviewStatusID; } set { _InterviewStatusID = value; } }
        public String Status { get { return _Status; } set { _Status = value; } }

        public MasterCandidate() { }

        public MasterCandidate(int ID)
        {
            Update(new Master_CandidateBusinessObject().GetMaster_Candidate(ID));
        }

        public static String DeleteCandidate(int CandidateID)
        {
            Master_Candidate em = new Master_CandidateBusinessObject().GetMaster_Candidate(CandidateID);
            em.IsDeleted = true;
            MasterCandidate e = new MasterCandidate();
            e.Update(em);
            return e.Save();
        }

        private void Update(Master_Candidate DTO)
        {
            if (DTO != null)
            {
                _ID = DTO.ID;
                _TeamID = DTO.TeamID;
                _CandidateType = DTO.CandidateType;
                _FirstName = DTO.FirstName;
                _MiddleName = DTO.MiddleName;
                _LastName = DTO.LastName;
                _CurrentEmployer = DTO.CurrentEmployer;
                _CareerStartDate = DTO.CareerStartDate;
                _Experience = DTO.Experience;
                _TechnologyExpertise = DTO.TechnologyExpertise;
                _ContactNumber = DTO.ContactNumber;
                _EmailID = DTO.EmailID;
                _NoticePeriod = DTO.NoticePeriod;
                _CurrentLocation = DTO.CurrentLocation;
                _ReasonForChange = DTO.ReasonForChange;
                _OffersInHand = DTO.OffersInHand;
                _ResumeFilename = DTO.ResumeFilename;
                _RecruitmentType = DTO.RecruitmentType;
                _CreatedBy = DTO.CreatedBy;
                _CreatedDate = DTO.CreatedDate;
                _ModifiedBy = DTO.ModifiedBy;
                _ModifiedDate = DTO.ModifiedDate;
                _IsDeleted = DTO.IsDeleted;

                if(DTO is Master_CandidateEXT)
                {
                    _Status = ((Master_CandidateEXT)DTO).Status;
                    _InterviewStatusID = ((Master_CandidateEXT)DTO).InterviewStatusID;
                    _TeamName = ((Master_CandidateEXT)DTO).TeamName;
                    _ManagerName = ((Master_CandidateEXT)DTO).ManagerName;
                }
            }
        }

        private Master_Candidate GetDTO()
        {
            Master_Candidate DTO = new Master_Candidate();
            DTO.ID = _ID;
            DTO.TeamID = _TeamID;
            DTO.CandidateType = _CandidateType;
            DTO.FirstName = _FirstName;
            DTO.MiddleName = _MiddleName;
            DTO.LastName = _LastName;
            DTO.CurrentEmployer = _CurrentEmployer;
            DTO.CareerStartDate = _CareerStartDate;
            DTO.Experience = _Experience;
            DTO.TechnologyExpertise = _TechnologyExpertise;
            DTO.ContactNumber = _ContactNumber;
            DTO.EmailID = _EmailID;
            DTO.NoticePeriod = _NoticePeriod;
            DTO.CurrentLocation = _CurrentLocation;
            DTO.ReasonForChange = _ReasonForChange;
            DTO.OffersInHand = _OffersInHand;
            DTO.ResumeFilename = _ResumeFilename;
            DTO.RecruitmentType = _RecruitmentType;
            DTO.CreatedBy = _CreatedBy;
            DTO.IsDeleted = _IsDeleted;

            if (_ID == 0)
                DTO.CreatedDate = DateTime.Now;
            else
                DTO.CreatedDate = _CreatedDate;    

            DTO.ModifiedBy = _ModifiedBy;
            DTO.ModifiedDate = DateTime.Now;

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
                return _ID.ToString();
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(ex); return ex.Message;
            }
        }

        public String Validate()
        {
            return "";
        }

        public static MasterCandidate[] GetAllCandidateData(int LoggedEmpID, int LoggedUserID, String RType)
        {
            Master_Candidate[] EdusDT = new Master_CandidateBusinessObject().GetCandidatesBasedOnLogin(LoggedEmpID, LoggedUserID, RType);

            MasterCandidate[] edu = new MasterCandidate[EdusDT.Length];

            for (int i = 0; i < edu.Length; i++)
            {
                edu[i] = new MasterCandidate();
                edu[i].Update(EdusDT[i]);
            }
            return edu;
        }

        #region JGridDataObject Members

        public object GetGridData()
        {
            CandidateGridDiaplay dis = new CandidateGridDiaplay();

            dis.ID = _ID.ToString();
            dis.TeamID = _TeamID.ToString();
            dis.CandidateType = _CandidateType;
            dis.FirstName = _FirstName;
            dis.MiddleName = _MiddleName;
            dis.LastName = _LastName;
            dis.CurrentEmployer = _CurrentEmployer;

            if (_CareerStartDate.Year == 1900 || _CareerStartDate.Year == 1)
                dis.CareerStartDate = "";
            else
                dis.CareerStartDate = _CareerStartDate.ToString("dd/MM/yyyy");

            dis.Experience = _Experience;
            dis.TechnologyExpertise = _TechnologyExpertise;
            dis.ContactNumber = _ContactNumber;
            dis.EmailId = _EmailID;
            dis.NoticePeriod = _NoticePeriod.ToString();
            dis.CurrentLocation = _CurrentLocation;
            dis.ReasonForChange = _ReasonForChange;
            dis.OffersInHand = _OffersInHand;
            dis.ResumeFilename = _ResumeFilename;

            if(_RecruitmentType == "CNT")
                dis.References = "Consultant";
            else if (_RecruitmentType == "EMP")
                dis.References = "Employee";

            dis.CreatedBy = _CreatedBy;
            dis.CreatedDate = _CreatedDate;
            dis.InterviewStatusID = _InterviewStatusID;
            dis.Status = new CandidateStatusDescription().FullStatus(_Status);
            dis.IsDeleted = _IsDeleted;
            dis.Team = _TeamName;
            dis.Manager = _ManagerName;

            return dis;
        }

        #endregion
    }

    public class CandidateGridDiaplay
    {
        public String ID;
        public String TeamID;
        public String CandidateType;
        public String FirstName;
        public String MiddleName;
        public String LastName;
        public String Team;
        public String Manager;
        public String CurrentEmployer;
        public String CareerStartDate;
        public String Experience;
        public String TechnologyExpertise;
        public String ContactNumber;
        public String EmailId;
        public String NoticePeriod;
        public String CurrentLocation;
        public String ReasonForChange;
        public String OffersInHand;
        public String ResumeFilename;
        public String References;
        public int CreatedBy;
        public DateTime CreatedDate;
        public int InterviewStatusID;
        public String Status;
        public bool IsDeleted;
    }
}
