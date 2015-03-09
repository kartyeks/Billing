using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using HRManager.DTOEXT.Recruitment;
using IRCA.Communication;

namespace HRManager.Entity.Recruitment
{
    public class CandidateInterviewStatus : JGridDataObject
    {
        public int _ID;
        public int _CandidateID;
        public int _TeamID;
        public String _CandidateStatus;
        public int _InterviewTypeID;
        public DateTime _Date1Time1;
        public DateTime _Date2Time2;
        public int _UpdatedBy;
        public DateTime _UpdatedDateTime;
        private bool _IsCandidateAvailable;
        public String _RejectionRemarks;

        public String _CandidateName;
        public String _TeamName;
        public String _ManagerName;
        public String _InterviewType;
        public int _TechnicalPanel;
        public String _TechPanelName;

        public String CandidateName { get { return _CandidateName; } set { _CandidateName = value; } }
        public String TeamName { get { return _TeamName; } set { _TeamName = value; } }
        public String ManagerName { get { return _ManagerName; } set { _ManagerName = value; } }
        public String InterviewType { get { return _InterviewType; } set { _InterviewType = value; } }
        public int TechnicalPanel { get { return _TechnicalPanel; } set { _TechnicalPanel = value; } }
        public String TechPanelName { get { return _TechPanelName; } set { _TechPanelName = value; } }

        public int ID { get { return _ID; } set { _ID = value; } }
        public int CandidateID { get { return _CandidateID; } set { _CandidateID = value; } }
        public int TeamID { get { return _TeamID; } set { _TeamID = value; } }
        public String CandidateStatus { get { return _CandidateStatus; } set { _CandidateStatus = value; } }
        public int InterviewTypeID { get { return _InterviewTypeID; } set { _InterviewTypeID = value; } }
        public DateTime InterviewDateTime1 { get { return _Date1Time1; } set { _Date1Time1 = value; } }
        public DateTime InterviewDateTime2 { get { return _Date2Time2; } set { _Date2Time2 = value; } }
        public int UpdatedBy { get { return _UpdatedBy; } set { _UpdatedBy = value; } }
        public DateTime UpdatedDateTime { get { return _UpdatedDateTime; } set { _UpdatedDateTime = value; } }
        public bool IsCandidateAvailable { get { return _IsCandidateAvailable; } set { _IsCandidateAvailable = value; } }
        public String RejectionRemarks { get { return _RejectionRemarks; } set { _RejectionRemarks = value; } }

        public CandidateInterviewStatus() { }

        public CandidateInterviewStatus(int ID) 
        {
            Update(new Candidate_Interview_StatusBusinessObject().GetCandidate_Interview_Status(ID));
        }


        private void Update(Candidate_Interview_Status DTO)
        {
            if (DTO != null)
            {
                _ID = DTO.ID;
                _CandidateID = DTO.CandidateID;
                _TeamID = DTO.TeamID;
                _CandidateStatus = DTO.CandidateStatus;
                _Date1Time1 = DTO.Date1Time1;
                _Date2Time2 = DTO.Date2Time2;
                _UpdatedBy = DTO.UpdatedBy;
                _UpdatedDateTime = DTO.UpdatedDateTime;
                _IsCandidateAvailable = DTO.IsCandidateAvailable;
                _RejectionRemarks = DTO.RejectionRemarks;

                if (DTO is Candidate_Interview_StatusEXT)
                {
                    _CandidateName = ((Candidate_Interview_StatusEXT)DTO).CandidateName;
                    _TeamName = ((Candidate_Interview_StatusEXT)DTO).TeamName;
                    _ManagerName = ((Candidate_Interview_StatusEXT)DTO).ManagerName;
                    _InterviewTypeID = ((Candidate_Interview_StatusEXT)DTO).InterviewTypeID;
                    _InterviewType = ((Candidate_Interview_StatusEXT)DTO).InterviewType;
                    _TechnicalPanel = ((Candidate_Interview_StatusEXT)DTO).TechnicalPanelId;
                    _TechPanelName = ((Candidate_Interview_StatusEXT)DTO).TechPanelName;
                }
            }
        }

        private Candidate_Interview_Status GetDTO()
        {
            Candidate_Interview_Status DTO = new Candidate_Interview_Status();

            DTO.ID = _ID;
            DTO.CandidateID = _CandidateID;
            DTO.TeamID = _TeamID;
            DTO.CandidateStatus = _CandidateStatus;

            if (_Date1Time1.Year == 1)
                DTO.Date1Time1 = new DateTime(1900, 01, 01);
            else
                DTO.Date1Time1 = _Date1Time1;

            if(_Date2Time2.Year == 1)
                DTO.Date2Time2 = new DateTime(1900, 01, 01);
            else
                DTO.Date2Time2 = _Date2Time2;

            DTO.UpdatedBy = _UpdatedBy;
            DTO.UpdatedDateTime =  DateTime.Now;
            DTO.IsCandidateAvailable = _IsCandidateAvailable;
            DTO.RejectionRemarks = _RejectionRemarks;

            return DTO;
        }

        public String Save()
        {
            try
            {
                Candidate_Interview_StatusBusinessObject BO = new Candidate_Interview_StatusBusinessObject();
                Candidate_Interview_Status DTO = GetDTO();
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

        public CandidateInterviewStatus[] GetAllCandidateInterviewStatusData(int LoggedEmpID, int LoggedUserID, String RoleName)
        {
            Candidate_Interview_Status[] EdusDT = new Candidate_Interview_StatusBusinessObject().GetInterviewStatusDetails(LoggedEmpID, LoggedUserID, RoleName);

            CandidateInterviewStatus[] edu = new CandidateInterviewStatus[EdusDT.Length];

            for (int i = 0; i < edu.Length; i++)
            {
                edu[i] = new CandidateInterviewStatus();
                edu[i].Update(EdusDT[i]);
            }
            return edu;
        }

        public CandidateInterviewStatus[] GetAllCandidateInterviewStatusWithTechnicalPanel(int ID)
        {
            Candidate_Interview_Status[] EdusDT = new Candidate_Interview_StatusBusinessObject().GetInterviewStatusandTechnicalPanel(ID);

            CandidateInterviewStatus[] edu = new CandidateInterviewStatus[EdusDT.Length];

            for (int i = 0; i < edu.Length; i++)
            {
                edu[i] = new CandidateInterviewStatus();
                edu[i].Update(EdusDT[i]);
            }
            return edu;
        }

        public CandidateInterviewStatus GeInterviewStatusByCandidateID(int CAndID)
        {
            Candidate_Interview_Status EdusDT = new Candidate_Interview_StatusBusinessObject().GetInterviewStatusDetailsByCandID(CAndID);

            CandidateInterviewStatus edu = new CandidateInterviewStatus();
            edu.Update(EdusDT);

            return edu;
        }

        #region JGridDataObject Members

        public object GetGridData()
        {
            InterviewStatusDisplay dis = new InterviewStatusDisplay();

            dis.CandidateName = _CandidateName;
            dis.TeamName = _TeamName;
            dis.ManagerName = _ManagerName;
            dis.InterviewType = _InterviewType;
            dis.ID = _ID;
            dis.CandidateID = _CandidateID;
            dis.TeamID = _TeamID;
            dis.CandidateStatus = new CandidateStatusDescription().FullStatus(_CandidateStatus);
            dis.InterviewTypeID = _InterviewTypeID;

            if (_Date1Time1.Year == 1900 || _Date1Time1.Year == 1)
                dis.InterviewDateTime1 = "";
            else
                dis.InterviewDateTime1 = _Date1Time1.ToString("dd/MM/yyyy HH:mm");

            if (_Date2Time2.Year == 1900 || _Date2Time2.Year == 1)
                dis.InterviewDateTime2 = "";
            else
                dis.InterviewDateTime2 = _Date2Time2.ToString("dd/MM/yyyy HH:mm");

            dis.UpdatedBy = _UpdatedBy;
            dis.UpdatedDateTime = _UpdatedDateTime;
            dis.IsCandidateAvial = _IsCandidateAvailable;

            return dis;
        }

        #endregion
    }

    public class InterviewStatusDisplay
    {
        public String CandidateName;
        public String TeamName;
        public String ManagerName;
        public String InterviewType;
        public int ID;
        public int CandidateID;
        public int TeamID;
        public int InterviewTypeID;
        public String InterviewDateTime1;
        public String InterviewDateTime2;
        public int UpdatedBy;
        public DateTime UpdatedDateTime;
        public bool IsCandidateAvial;
        public String CandidateStatus;
    }
}
