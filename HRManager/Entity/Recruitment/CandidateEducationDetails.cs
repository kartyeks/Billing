using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.BusinessObjects;
using HRManager.DTO;
using IRCAKernel;
using IRCA.Communication;
using HRManager.DTOEXT.Recruitment;

namespace HRManager.Entity.Recruitment
{
    public class CandidateEducationDetails : JGridDataObject
    {
        private Int64 _LocalGridID;
        private int _ID;
        private int _CandidateID;
        private String _Education;
        private String _Stream;
        private String _University;
        private int _Year;
        private double _Percentage;

        public Int64 LocalGridID { get { return _LocalGridID; } set { _LocalGridID = value; } }
        public int ID { get { return _ID; } set { _ID = value; } }
        public int CandidateID { get { return _CandidateID; } set { _CandidateID = value; } }
        public String Education { get { return _Education; } set { _Education = value; } }
        public String Stream { get { return _Stream; } set { _Stream = value; } }
        public String University { get { return _University; } set { _University = value; } }
        public int Year { get { return _Year; } set { _Year = value; } }
        public double Percentage { get { return _Percentage; } set { _Percentage = value; } }

        public CandidateEducationDetails() { }

        public CandidateEducationDetails(int ID) 
        {
            Update(new Candidate_Education_DetailsBusinessObject().GetCandidate_Education_Details(ID));
        }

        private void Update(Candidate_Education_Details DTO)
        {
            if (DTO != null)
            {
                _ID = DTO.ID;
                _CandidateID = DTO.CandidateID;
                _Education = DTO.Education;
                _Stream = DTO.Stream;
                _University = DTO.University;
                _Year = DTO.Year;
                _Percentage = DTO.Percentage;

                if (DTO is Candidate_Education_DetailsEXT)
                {
                    _LocalGridID = ((Candidate_Education_DetailsEXT)DTO).LocalGridID;
                }
            }
        }

        private Candidate_Education_Details GetDTO()
        {
            Candidate_Education_Details DTO = new Candidate_Education_Details();

            DTO.ID = _ID;
            DTO.CandidateID = _CandidateID;
            DTO.Education = _Education;
            DTO.Stream = _Stream;
            DTO.University = _University;
            DTO.Education = _Education;
            DTO.Year = _Year;
            DTO.Percentage = _Percentage;

            return DTO;
        }

        public String Save()
        {
            try
            {
                Candidate_Education_DetailsBusinessObject BO = new Candidate_Education_DetailsBusinessObject();
                Candidate_Education_Details DTO = GetDTO();
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

        public static CandidateEducationDetails[] GetEducationDetailsOfCandidate(int CandidateID)
        {
            Candidate_Education_Details[] EdusDT = new Candidate_Education_DetailsBusinessObject().GetCandidateEducationDetailsByID(CandidateID);

            CandidateEducationDetails[] edu = new CandidateEducationDetails[EdusDT.Length];

            for (int i = 0; i < edu.Length; i++)
            {
                edu[i] = new CandidateEducationDetails();
                edu[i].Update(EdusDT[i]);
            }
            return edu;
        }

        public String DeleteEducationRows(int ID)
        {
            int DeleteCount = new Candidate_Education_DetailsBusinessObject().DeleteEducation(ID);
            return String.Format(HRRecruitmentManagerDefs.DELETED_SUCCESS, DeleteCount);
        }

        #region JGridDataObject Members

        public object GetGridData()
        {
            return this;
        }

        #endregion
    }
}
