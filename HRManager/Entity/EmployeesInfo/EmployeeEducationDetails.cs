using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IS91.Services.DataBlock;

namespace HRManager.Entity.EmployeesInfo
{
    public class EmployeeEducation : EmployeeInfoList
    {
        public EmployeeEducation(int EmployeeID)
        {
            Employee_Education_DetailsBusinessObject BO = new Employee_Education_DetailsBusinessObject();

            Employee_Education_Details[] DTO = BO.GetEducationalDetails(EmployeeID);

            for (int i = 0; i < DTO.Length; i++)
            {
                EmployeeEducationDetails Edu = new EmployeeEducationDetails();
                Edu.Update(DTO[i]);

                Add(Edu);
            }
        }

        public EmployeeEducation()
        {

        }

        public override String Delete(int ID)
        {
            try
            {
                new Employee_Education_DetailsBusinessObject().Delete(ID);
              //  new Employee_Education_DetailsBusinessObject().DeleteEducation(ID);
                return String.Empty;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(ex);
                return ex.Message;
            }
        }
    }

    public class EmployeeEducationDetails : EmployeeInfo
    {
        private int _ID;
        private int _EmployeeID;
        private String _Education;
        private String _Stream;
        private String _University;
        private Double _Percentage;
        private int _Year;
        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _UpdatedBy;
        private DateTime _ModifiedDate;

        public int ID { get { return _ID; } set { _ID = value; } }
        public int EmployeeID { get { return _EmployeeID; } set { _EmployeeID = value; } }
        public String Education { get { return _Education; } set { _Education = value; } }
        public String Stream { get { return _Stream; } set { _Stream = value; } }
        public String University { get { return _University; } set { _University = value; } }
        public int Year { get { return _Year; } set { _Year = value; } }
        public Double Percentage { get { return _Percentage; } set { _Percentage = value; } }
        public int UpdatedBy { set { _UpdatedBy = value; } }

        internal void Update(Employee_Education_Details DTO)
        {
            if (DTO != null)
            {
                _ID = DTO.ID;
                _EmployeeID = DTO.EmployeeID;
                _Education = DTO.Education;
                _Stream = DTO.Stream;
                _University = DTO.University;
                _Year = DTO.Year;
                _Percentage = DTO.Percentage;
            }
        }
        private Employee_Education_Details GetDTO()
        {
            Employee_Education_Details DTO = new Employee_Education_Details();
            DTO.ID = _ID;
            DTO.EmployeeID = _EmployeeID;
            DTO.Education=_Education;
            DTO.Stream = _Stream;
            DTO.University = _University;
            DTO.Percentage = _Percentage;
            DTO.Year = _Year;
            return DTO;
        }

        public String Save()
        {
            try
            {
                Employee_Education_DetailsBusinessObject BO = new Employee_Education_DetailsBusinessObject();
                Employee_Education_Details DTO = GetDTO();

                bool isExists = BO.IsEducationExists(_Education,_EmployeeID,_ID);
                if (isExists)
                {
                    return HREmployeeManagerDefs.Employee.EDUCATION_EXISTS;
                }
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

        #region JGridDataObject Members

        public object GetGridData()
        {
            return this;
        }

        #endregion
    }
}
