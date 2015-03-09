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
    public class EmployeeCareer : EmployeeInfoList
    {
        public EmployeeCareer(int EmployeeID)
        {
            Employee_CareerBusinessObject BO = new Employee_CareerBusinessObject();

            Employee_Career[] DTO = BO.GetCareerDetails(EmployeeID);

            for (int i = 0; i < DTO.Length; i++)
            {
                EmployeeCareerDetails Edu = new EmployeeCareerDetails();
                Edu.Update(DTO[i]);

                Add(Edu);
            }
        }

        public EmployeeCareer()
        {

        }

        public override String Delete(int ID)
        {
            try
            {
                new Employee_CareerBusinessObject().Delete(ID);
               // new Employee_CareerBusinessObject().DeleteCareer(ID);
                return String.Empty;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(ex);
                return ex.Message;
            }
        }
    }

    public class EmployeeCareerDetails : EmployeeInfo
    {
        private int _ID;
        private int _EmployeeID;
        private bool _IsFresher;
        private String _CompanyName;
        private DateTime _StartDate;
        private DateTime _EndDate;
        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _UpdatedBy;
        private DateTime _ModifiedDate;

        private string _strStartDate;
        private string _strEndDate;

        public int ID { get { return _ID; } set { _ID = value; } }
        public int EmployeeID { get { return _EmployeeID; } set { _EmployeeID = value; } }
        public bool IsFresher { get { return _IsFresher; } set { _IsFresher = value; } }
        public String CompanyName { get { return _CompanyName; } set { _CompanyName = value; } }
        public DateTime dtStartDate { get { return _StartDate; } set { _StartDate = value; } }
        public DateTime dtEndDate { get { return _EndDate; } set { _EndDate = value; } }
        public string StartDate { get { return _strStartDate; } set { _strStartDate = value; } }
        public string EndDate { get { return _strEndDate; } set { _strEndDate = value; } }
        public int UpdatedBy { set { _UpdatedBy = value; } }


        internal void Update(Employee_Career DTO)
        {
            if (DTO != null)
            {
                _ID = DTO.ID;
                _EmployeeID = DTO.EmployeeID;
                _IsFresher = DTO.IsFresher;
                _CompanyName = DTO.CompanyName;
                if (DTO.StartDate.Year.Equals(1900))
                {
                    _strStartDate = string.Empty;
                }
                else
                {
                    _strStartDate = DTO.StartDate.ToString("dd/MM/yyyy");
                }
                if (DTO.EndDate.Year.Equals(1900))
                {
                    _strEndDate = string.Empty;
                }
                else
                {
                    _strEndDate = DTO.EndDate.ToString("dd/MM/yyyy");
                }
               
                _StartDate = DTO.StartDate;
                _EndDate = DTO.EndDate;
               
               
            }
        }
        private Employee_Career GetDTO()
        {
            Employee_Career DTO = new Employee_Career();
            DTO.ID = _ID;
            DTO.EmployeeID = _EmployeeID;
            DTO.IsFresher = _IsFresher;
            DTO.CompanyName = _CompanyName;
            if (_StartDate.Year.Equals(0001))
            {
                DTO.StartDate = Convert.ToDateTime("1900-01-01");
            }
            else
            {
                DTO.StartDate = _StartDate;
            }
            if (_EndDate.Year.Equals(0001))
            {
                DTO.EndDate = Convert.ToDateTime("1900-01-01");
            }
            else
            {
                DTO.EndDate = _EndDate;
            }
          
       
            return DTO;
        }


        public String Save()
        {
            try
            {
                Employee_CareerBusinessObject BO = new Employee_CareerBusinessObject();
                Employee_Career DTO = GetDTO();

                bool isExists = BO.IsCompanyExists(_CompanyName, _EmployeeID,_ID);
                if (isExists)
                {
                    return HREmployeeManagerDefs.Employee.COMPANY_EXISTS;
                }
                if (_IsFresher)
                {
                    bool isfresher = new Employee_CareerBusinessObject().CheckIsFresher(_EmployeeID,false);
                    if (isfresher)
                    {
                        return HREmployeeManagerDefs.Employee.FRESHER_EXISTS;
                    }
                }
                if (!_IsFresher)
                {
                    bool isfresher = new Employee_CareerBusinessObject().CheckIsFresher(_EmployeeID,true);
                    if (isfresher)
                    {
                        return HREmployeeManagerDefs.Employee.FRESHER_EXISTS;
                    }
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
        //public bool IsEmpFresher(int empID)
        //{
        //    return new Employee_CareerBusinessObject().CheckIsFresher(empID);

        //}

        #region JGridDataObject Members

        public object GetGridData()
        {
            return this;
        }

        #endregion
    }
}
