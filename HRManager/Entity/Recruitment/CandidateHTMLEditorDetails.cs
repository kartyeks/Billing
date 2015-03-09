using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;

namespace HRManager.Entity.Recruitment
{
    public class CandidateHTMLEditorDetails
    {
        private int _ID;
        private int _CandidateID;
        private String _HTMLContent;
        private int _EditedByUser;
        private DateTime _EditedDateTime;
        private String _HTMLFileName;

        public int ID { get { return _ID; } set { _ID = value; } }
        public int CandidateID { get { return _CandidateID; } set { _CandidateID = value; } }
        public String HTMLContent { get { return _HTMLContent; } set { _HTMLContent = value; } }
        public int EditedByUser { get { return _EditedByUser; } set { _EditedByUser = value; } }
        public DateTime EditedDateTime { get { return _EditedDateTime; } set { _EditedDateTime = value; } }
        public String HTMLFileName { get { return _HTMLFileName; } set { _HTMLFileName = value; } }

        public CandidateHTMLEditorDetails() { }

        public CandidateHTMLEditorDetails(int ID)
        {
            Update(new Candidate_HTMLEditorDetailsBusinessObject().GetCandidate_HTMLEditorDetails(ID));
        }

        private void Update(Candidate_HTMLEditorDetails DTO)
        {
            if (DTO != null)
            {
                _ID = DTO.ID;
                _CandidateID = DTO.CandidateID;
                _HTMLContent = DTO.HTMLContent;
                _EditedByUser = DTO.EditedByUser;
                _EditedDateTime = DTO.EditedDateTime;
                _HTMLFileName = DTO.HTMLFileName;
            }
        }

        private Candidate_HTMLEditorDetails GetDTO()
        {
            Candidate_HTMLEditorDetails DTO = new Candidate_HTMLEditorDetails();

            DTO.ID = _ID;
            DTO.CandidateID = _CandidateID;
            DTO.HTMLContent = _HTMLContent;
            DTO.EditedByUser = _EditedByUser;
            DTO.EditedDateTime = _EditedDateTime;
            DTO.HTMLFileName = _HTMLFileName;

            return DTO;
        }

        public String Save()
        {
            try
            {
                Candidate_HTMLEditorDetailsBusinessObject BO = new Candidate_HTMLEditorDetailsBusinessObject();
                Candidate_HTMLEditorDetails DTO = GetDTO();
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

        public CandidateHTMLEditorDetails GetAllCandidateHTMLData(int CandidateID)
        {
            Candidate_HTMLEditorDetails[] EdusDT = new Candidate_HTMLEditorDetailsBusinessObject().GetCandidateHTMLDetails("CandidateID = " + CandidateID);

            CandidateHTMLEditorDetails edu = new CandidateHTMLEditorDetails();

            if (EdusDT.Length > 0)
                edu.Update(EdusDT[0]);
            else
                return edu;
            return edu;
        }
    }
}
