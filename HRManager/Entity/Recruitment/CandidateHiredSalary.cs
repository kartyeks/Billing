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
    public class CandidateHiredSalary : JGridDataObject
    {
        private int _ID;
        private int _CandidateID;
        private DateTime _JoiningDate;
        private double _CTC;
        private int _ESOP;

        private String _FirstName;
        private String _MiddleName;
        private String _LastName;
        private String _CandidateStatus;
        private DateTime _IssueOfferredDate;

        public String FirstName { get { return _FirstName; } set { _FirstName = value; } }
        public String MiddleName { get { return _MiddleName; } set { _MiddleName = value; } }
        public String LastName { get { return _LastName; } set { _LastName = value; } }
        public String CandidateStatus { get { return _CandidateStatus; } set { _CandidateStatus = value; } }
        public DateTime IssueOfferredDate { get { return _IssueOfferredDate; } set { _IssueOfferredDate = value; } }

        public int ID { get { return _ID; } set { _ID = value; } }
        public int CandidateID { get { return _CandidateID; } set { _CandidateID = value; } }
        public DateTime JoiningDate { get { return _JoiningDate; } set { _JoiningDate = value; } }
        public double CTC { get { return _CTC; } set { _CTC = value; } }
        public int ESOP { get { return _ESOP; } set { _ESOP = value; } }

        public CandidateHiredSalary() { }

        public CandidateHiredSalary(int ID)
        {
            Update(new Candidate_Hired_SalaryBusinessObject().GetCandidate_Hired_Salary(ID));
        }

        private void Update(Candidate_Hired_Salary DTO)
        {
            if (DTO != null)
            {
                _ID = DTO.ID;
                _CandidateID = DTO.CandidateID;
                _JoiningDate = DTO.JoiningDate;
                _CTC = DTO.CTC;
                _ESOP = DTO.ESOP;

                if (DTO is Candidate_Hired_SalaryEXT)
                {
                    _FirstName = ((Candidate_Hired_SalaryEXT)DTO).FirstName;
                    _MiddleName = ((Candidate_Hired_SalaryEXT)DTO).MiddleName;
                    _LastName = ((Candidate_Hired_SalaryEXT)DTO).LastName;
                    _CandidateStatus = ((Candidate_Hired_SalaryEXT)DTO).CandidateStatus;
                    _IssueOfferredDate = ((Candidate_Hired_SalaryEXT)DTO).IssueOfferredDate;
                }
            }
        }

        private Candidate_Hired_Salary GetDTO()
        {
            Candidate_Hired_Salary DTO = new Candidate_Hired_Salary();

            DTO.ID = _ID;
            DTO.CandidateID=_CandidateID;
            DTO.JoiningDate=_JoiningDate;
            DTO.CTC=_CTC;
            DTO.ESOP = _ESOP;

            return DTO;
        }

        public String Save()
        {
            try
            {
                Candidate_Hired_SalaryBusinessObject BO = new Candidate_Hired_SalaryBusinessObject();
                Candidate_Hired_Salary DTO = GetDTO();
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

        public static CandidateHiredSalary[] GetAllCandidateSalaryData()
        {
            Candidate_Hired_Salary[] EdusDT = new Candidate_Hired_SalaryBusinessObject().GetCandidateSalary();

            CandidateHiredSalary[] edu = new CandidateHiredSalary[EdusDT.Length];

            for (int i = 0; i < edu.Length; i++)
            {
                edu[i] = new CandidateHiredSalary();
                edu[i].Update(EdusDT[i]);
            }
            return edu;
        }

        #region JGridDataObject Members

        public object GetGridData()
        {
            CandidateHiredSalaryGrid dis = new CandidateHiredSalaryGrid();
            
            dis.FirstName = _FirstName;
            dis.MiddleName = _MiddleName;
            dis.LastName = _LastName;
            dis.CandidateStatus = new CandidateStatusDescription().FullStatus(_CandidateStatus);
            dis.ID = _ID;
            dis.CandidateID = _CandidateID;

            if (_JoiningDate.Year == 1900 || _JoiningDate.Year == 1)
                dis.JoiningDate = "";
            else
                dis.JoiningDate = _JoiningDate.ToString("dd/MM/yyyy");

            if (_IssueOfferredDate.Year == 1900 || _IssueOfferredDate.Year == 1)
                dis.IssueOfferDate = "";
            else
                dis.IssueOfferDate = _IssueOfferredDate.ToString("dd/MM/yyyy");

            dis.CTC = _CTC;
            dis.ESOP = _ESOP;

            return dis;
        }

        #endregion
    }

    public class CandidateHiredSalaryGrid
    {
        public String FirstName;
        public String MiddleName;
        public String LastName;
        public int ID;
        public int CandidateID;
        public String JoiningDate;
        public String IssueOfferDate;
        public double CTC;
        public int ESOP;
        public String CandidateStatus;
    }
}
