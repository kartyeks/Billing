using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.BusinessObjects;
using HRManager.DTO;
using IRCAKernel;

namespace HRManager.Entity.Recruitment
{
    public class CandidateTechnicalPanel
    {
        private int _ID;
        private int _CandidateInterviewStatusID;
        private int _TechnicalPanelID;
        private int _InterviewTypeID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public int CandidateInterviewStatusID
        {
            get { return _CandidateInterviewStatusID; }
            set { _CandidateInterviewStatusID = value; }
        }

        public int TechnicalPanelID
        {
            get { return _TechnicalPanelID; }
            set { _TechnicalPanelID = value; }
        }

        public int InterviewTypeID
        {
            get { return _InterviewTypeID; }
            set { _InterviewTypeID = value; }
        }

        public CandidateTechnicalPanel() { }

        public CandidateTechnicalPanel(int ID)
        {
            Candidate_Technical_Panel EdusDT = new Candidate_Technical_PanelBusinessObject().GetCandidate_Technical_Panel(ID);
            Update(EdusDT);
        }

        private void Update(Candidate_Technical_Panel DTO)
        {
            if (DTO != null)
            {
                _ID = DTO.ID;
                _CandidateInterviewStatusID = DTO.CandidateInterviewStatusID;
                _TechnicalPanelID = DTO.TechnicalPanelID;
                _InterviewTypeID = DTO.InterviewTypeID;
            }
        }

        private Candidate_Technical_Panel GetDTO()
        {
            Candidate_Technical_Panel DTO = new Candidate_Technical_Panel();

            DTO.ID = _ID;
            DTO.CandidateInterviewStatusID = _CandidateInterviewStatusID;
            DTO.TechnicalPanelID = TechnicalPanelID;
            DTO.InterviewTypeID = _InterviewTypeID;

            return DTO;
        }

        public String Save()
        {
            try
            {
                Candidate_Technical_PanelBusinessObject BO = new Candidate_Technical_PanelBusinessObject();
                Candidate_Technical_Panel DTO = GetDTO();
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

        public  CandidateTechnicalPanel[] GetTechnicalPanelByInterviewStatusID(int InterviewStatusID)
        {
            Candidate_Technical_Panel[] EdusDT = new Candidate_Technical_PanelBusinessObject().GetTechnicalPanelBYInterviewStatusID(InterviewStatusID);

            CandidateTechnicalPanel[] edu = new CandidateTechnicalPanel[EdusDT.Length];

            for (int i = 0; i < edu.Length; i++)
            {
                edu[i] = new CandidateTechnicalPanel();
                edu[i].Update(EdusDT[i]);
            }
            return edu;
        }

        public CandidateTechnicalPanel[] GetTechnicalPanelDetByInterviewStatusID(int InterviewStatusID)
        {
            Candidate_Technical_Panel[] EdusDT = new Candidate_Technical_PanelBusinessObject().GetTechnicalPanelDetBYInterviewStatusID(InterviewStatusID);

            CandidateTechnicalPanel[] edu = new CandidateTechnicalPanel[EdusDT.Length];

            for (int i = 0; i < edu.Length; i++)
            {
                edu[i] = new CandidateTechnicalPanel();
                edu[i].Update(EdusDT[i]);
            }
            return edu;
        }

        public CandidateTechnicalPanel[] GetTechnicalPanelDetByInterviewStatusAndTypeID( int InterviewTypeID, int InterviewStatusID)
        {
            Candidate_Technical_Panel[] EdusDT = new Candidate_Technical_PanelBusinessObject().GetTechnicalPanelByInterviewStatusAndTypeID(InterviewTypeID,InterviewStatusID);

            CandidateTechnicalPanel[] edu = new CandidateTechnicalPanel[EdusDT.Length];

            for (int i = 0; i < edu.Length; i++)
            {
                edu[i] = new CandidateTechnicalPanel();
                edu[i].Update(EdusDT[i]);
            }
            return edu;
        }

        public CandidateTechnicalPanel GetTechnicalPanelDetByZeroTechPanel(int InterviewStatusID)
        {
            Candidate_Technical_Panel EdusDT = new Candidate_Technical_PanelBusinessObject().GetTechnicalPanelDetForTechPanelZero(InterviewStatusID);
            CandidateTechnicalPanel edu = new CandidateTechnicalPanel();
            edu.Update(EdusDT);
            return edu;
        }

        public String DeleteETechnicalPanelRows(int InterviewStatusID)
        {
            int DeleteCount = new Candidate_Technical_PanelBusinessObject().DeleteTechnicalPanel(InterviewStatusID);
            return String.Format(HRRecruitmentManagerDefs.DELETED_SUCCESS, DeleteCount);
        }
    }
}
