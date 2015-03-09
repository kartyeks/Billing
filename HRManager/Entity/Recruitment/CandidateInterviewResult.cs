using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.BusinessObjects;
using HRManager.DTO;
using IRCAKernel;
using HRManager.DTOEXT.Recruitment;
using IRCA.Communication;

namespace HRManager.Entity.Recruitment
{
    public class CandidateInterviewResult : JGridDataObject
    {
        private int _ID;
        private int _CandidateID;
        private String _JobTitle;
        private int _InterviewerID;
        private DateTime _InterviewDate;
        private int _CompetencyID;
        private int _CompetencyValue;
        private String _StrengthandWeakness;
        private String _Recommendation;
        private int _UpdatedBy;
        private DateTime _UpdatedDateTime;

        private int _MCCompetencyID;
        private String _CandidateName;
        private String _CompetencyName;
        private String _CompetencyDescription;
        private String _IntervieweName;
        private bool _Value1;
        private bool _Value2;
        private bool _Value3;
        private bool _Value4;
        private bool _Value5;
        private bool _Value6;

        public int ID { get { return _ID; } set { _ID = value; } }
        public int CandidateID { get { return _CandidateID; } set { _CandidateID = value; } }
        public String JobTitle { get { return _JobTitle; } set { _JobTitle = value; } }
        public int InterviewerID { get { return _InterviewerID; } set { _InterviewerID = value; } }
        public DateTime InterviewDate { get { return _InterviewDate; } set { _InterviewDate = value; } }
        public int CompetencyID { get { return _CompetencyID; } set { _CompetencyID = value; } }
        public int CompetencyValue { get { return _CompetencyValue; } set { _CompetencyValue = value; } }
        public String StrengthandWeakness { get { return _StrengthandWeakness; } set { _StrengthandWeakness = value; } }
        public String Recommendation { get { return _Recommendation; } set { _Recommendation = value; } }
        public int UpdatedBy { get { return _UpdatedBy; } set { _UpdatedBy = value; } }
        public DateTime UpdatedDateTime { get { return _UpdatedDateTime; } set { _UpdatedDateTime = value; } }

        public int MCCompetencyID { get { return _MCCompetencyID; } set { _MCCompetencyID = value; } }
        public String CandidateName { get { return _CandidateName; } set { _CandidateName = value; } }
        public String CompetencyName { get { return _CompetencyName; } set { _CompetencyName = value; } }
        public String CompetencyDescription { get { return _CompetencyDescription; } set { _CompetencyDescription = value; } }
        public String IntervieweName { get { return _IntervieweName; } set { _IntervieweName = value; } }
        public bool Value1 { get { return _Value1; } set { _Value1 = value; } }
        public bool Value2 { get { return _Value2; } set { _Value2 = value; } }
        public bool Value3 { get { return _Value3; } set { _Value3 = value; } }
        public bool Value4 { get { return _Value4; } set { _Value4 = value; } }
        public bool Value5 { get { return _Value5; } set { _Value5 = value; } }
        public bool Value6 { get { return _Value6; } set { _Value6 = value; } }

        public CandidateInterviewResult() { }

        public CandidateInterviewResult(int ID) 
        {
            Update(new Candidate_Interview_ResultBusinessObject().GetCandidate_Interview_Result(ID));
        }

        private void Update(Candidate_Interview_Result DTO)
        {
            if (DTO != null)
            {
                _ID = DTO.Id;
                _CandidateID = DTO.CandidateID;
                _InterviewerID = DTO.InterviewerID;
                _InterviewDate = DTO.InterviewDate;
                _JobTitle = DTO.JobTitle;
                _CompetencyID = DTO.CompetencyID;
                _CompetencyValue = DTO.CompetencyValue;
                _StrengthandWeakness = DTO.StrengthandWeakness;
                _Recommendation = DTO.Recommendation;
                _UpdatedBy = DTO.UpdatedBy;
                _UpdatedDateTime = DTO.UpdatedDateTime;

                if (DTO is Candidate_Interview_ResultEXT)
                {
                    _MCCompetencyID = ((Candidate_Interview_ResultEXT)DTO).MCCompetencyID;
                    _CandidateName = ((Candidate_Interview_ResultEXT)DTO).CandidateName;
                    _CompetencyName = ((Candidate_Interview_ResultEXT)DTO).CompetencyName;
                    _CompetencyDescription = ((Candidate_Interview_ResultEXT)DTO).CompetencyDescription;
                    _Value1 = ((Candidate_Interview_ResultEXT)DTO).Value1;
                    _Value2 = ((Candidate_Interview_ResultEXT)DTO).Value2;
                    _Value3 = ((Candidate_Interview_ResultEXT)DTO).Value3;
                    _Value4 = ((Candidate_Interview_ResultEXT)DTO).Value4;
                    _Value5 = ((Candidate_Interview_ResultEXT)DTO).Value5;
                    _Value6 = ((Candidate_Interview_ResultEXT)DTO).Value6;
                    _IntervieweName = ((Candidate_Interview_ResultEXT)DTO).InteviewerName;
                }
            }
        }

        private Candidate_Interview_Result GetDTO()
        {
            Candidate_Interview_Result DTO = new Candidate_Interview_Result();

            DTO.Id= _ID;
            DTO.CandidateID = _CandidateID;
            DTO.JobTitle = _JobTitle;
            DTO.InterviewerID = _InterviewerID;
            DTO.InterviewDate = _InterviewDate;
            DTO.CompetencyID = _CompetencyID;

            if(Value1 == true)
                DTO.CompetencyValue = 5;
            else if (Value2 == true)
                DTO.CompetencyValue = 4;
            else if (Value3 == true)
                DTO.CompetencyValue = 3;
            else if (Value4 == true)
                DTO.CompetencyValue = 2;
            else if (Value5 == true)
                DTO.CompetencyValue = 1;
            else if (Value6 == true)
                DTO.CompetencyValue = 6;

            DTO.StrengthandWeakness = _StrengthandWeakness;
            DTO.Recommendation = _Recommendation;
            DTO.UpdatedBy = _UpdatedBy;
            DTO.UpdatedDateTime = DateTime.Now;

            return DTO;
        }

        public String Save()
        {
            try
            {
                Candidate_Interview_ResultBusinessObject BO = new Candidate_Interview_ResultBusinessObject();
                Candidate_Interview_Result DTO = GetDTO();
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

        public CandidateInterviewResult[] GetAllCandidateInterviewResultData(int LoggedUserID, int CandidateID)
        {
            Candidate_Interview_ResultEXT[] EdusDT = new Candidate_Interview_ResultBusinessObject().GetInterviewResultDetails(LoggedUserID, CandidateID);

            CandidateInterviewResult[] edu = new CandidateInterviewResult[EdusDT.Length];

            for (int i = 0; i < edu.Length; i++)
            {
                edu[i] = new CandidateInterviewResult();
                edu[i].Update(EdusDT[i]);
            }
            return edu;
        }

        public CandidateInterviewResult[] GetCandidateInterviewResultByCandidateID(int CandidateID)
        {
            Candidate_Interview_Result[] EdusDT = new Candidate_Interview_ResultBusinessObject().GetResultDetailsByID(CandidateID);

            CandidateInterviewResult[] edu = new CandidateInterviewResult[EdusDT.Length];

            for (int i = 0; i < edu.Length; i++)
            {
                edu[i] = new CandidateInterviewResult();
                edu[i].Update(EdusDT[i]);
            }
            return edu;
        }

        #region JGridDataObject Members

        public object GetGridData()
        {
            InterviewResultDisplay dis = new InterviewResultDisplay();

            dis.ID = _ID;
            dis.MCCID = _MCCompetencyID;
            dis.CandidateID = _CandidateID;
            dis.CandidateName = _CandidateName;
            dis.JobTitle = _JobTitle;
            dis.InterviewerID = _InterviewerID;

            StringBuilder sbCompetency = new StringBuilder("<b>" + _CompetencyName + "</b> </br>" + _CompetencyDescription);
            dis.Competency = sbCompetency.ToString();

            if (_InterviewDate.Year == 1900 || _InterviewDate.Year == 1)
                dis.InterviewDate = "";
            else
                dis.InterviewDate = _InterviewDate.ToString("dd/MM/yyyy");

            dis.Value1 = _Value1;
            dis.Value2 = _Value2;
            dis.Value3 = _Value3;
            dis.Value4 = _Value4;
            dis.Value5 = _Value5;
            dis.Value6 = _Value6;
            dis.SandW = _StrengthandWeakness;
            dis.Recommendation = _Recommendation;

            return dis;
        }

        #endregion
    }

    public class InterviewResultDisplay
    {
        public int ID;
        public int MCCID;
        public int CandidateID;
        public String CandidateName;
        public String JobTitle;
        public int InterviewerID;
        public String InterviewDate;
        public String Competency;
        public bool Value1;
        public bool Value2;
        public bool Value3;
        public bool Value4;
        public bool Value5;
        public bool Value6;
        public String SandW;
        public String Recommendation;
    }
}
