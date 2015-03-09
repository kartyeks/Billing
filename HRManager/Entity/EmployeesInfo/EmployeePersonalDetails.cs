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
    public class EmployeePersonalDetails : EmployeeInfo
    {
        private int _ID;
        private String _EmpCode;
        private int _EmployeeTypeID;
        private String _FirstName;
        private String _LastName;
        private String _MiddleName;
        private DateTime _DOB;
        private String _Gender;
        private int _MaritalStatusID;
        private String _PermanentAddress;
        private String _CurrentAddress;
        private String _MobileNumber;
        private String _ResidenceNumber;
        private String _EmergencyContactNumber;
        private String _PersonalEmailID;
        private bool _IsActive;
        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _UpdatedBy;
        private DateTime _ModifiedDate;
        private bool _IsDeleted;

        public int ID { get { return _ID; } set { _ID = value; } }
        public String EmpCode { get { return _EmpCode; } set { _EmpCode = value; } }
        public int EmployeeTypeID { get { return _EmployeeTypeID; } set { _EmployeeTypeID = value; } }
        public String FirstName { get { return _FirstName; } set { _FirstName = value; } }
        public String LastName { get { return _LastName; } set { _LastName = value; } }
        public String MiddleName { get { return _MiddleName; } set { _MiddleName = value; } }
        public DateTime DOB { get { return _DOB; } set { _DOB = value; } }
        public String Gender { get { return _Gender; } set { _Gender = value; } }
        public int MaritalStatusID { get { return _MaritalStatusID; } set { _MaritalStatusID = value; } }

        public String PermanentAddress { get { return _PermanentAddress; } set { _PermanentAddress = value; } }
        public String CurrentAddress { get { return _CurrentAddress; } set { _CurrentAddress = value; } }
        public String MobileNumber { get { return _MobileNumber; } set { _MobileNumber = value; } }
        public String ResidenceNumber { get { return _ResidenceNumber; } set { _ResidenceNumber = value; } }
        public String EmergencyContactNumber { get { return _EmergencyContactNumber; } set { _EmergencyContactNumber = value; } }
        public String PersonalEmailID { get { return _PersonalEmailID; } set { _PersonalEmailID = value; } }
        public bool IsActive { get { return _IsActive; } set { _IsActive = value; } }
        public int UpdatedBy { set { _UpdatedBy = value; } }
        public bool IsDeleted { get { return _IsDeleted; } set { _IsDeleted = value; } }

        public EmployeePersonalDetails(int EmployeeID)
        {
            Master_EmployeesBusinessObject BO = new Master_EmployeesBusinessObject();
            Master_Employees DTO = BO.GetMaster_Employees(EmployeeID);
            Update(DTO);

        }

        public EmployeePersonalDetails()
        {

        }

        public void Update(Master_Employees DTO)
        {
            if (DTO != null)
            {
                _ID = DTO.ID;
                _EmpCode = DTO.EmpCode;
                _EmployeeTypeID = DTO.EmployeeTypeID;
                _FirstName = DTO.FirstName;
                _LastName = DTO.LastName;
                _MiddleName = DTO.MiddleName;
                _DOB = DTO.DOB;
                _Gender = DTO.Gender;
                _MaritalStatusID = DTO.MaritalStatusID;
                _PermanentAddress = DTO.PermanentAddress;
                _CurrentAddress = DTO.CurrentAddress;
                _MobileNumber = DTO.MobileNumber;
                _ResidenceNumber = DTO.ResidenceNumber;
                _EmergencyContactNumber = DTO.EmergencyContactNumber;
                _PersonalEmailID = DTO.PersonalEmailID;
                _IsActive = DTO.IsActive;
                _CreatedBy = DTO.CreatedBy;
                _CreatedDate = DTO.CreatedDate;
                _UpdatedBy = DTO.ModifiedBy;
                _ModifiedDate = DTO.ModifiedDate;
                _IsDeleted = DTO.IsDeleted;

            }
        }

        private Master_Employees GetDTO()
        {
            Master_Employees DTO = new Master_Employees();
            DTO.ID = _ID;
            DTO.EmpCode = _EmpCode;
            DTO.FirstName = _FirstName;
            DTO.LastName = _LastName;
            DTO.MiddleName = _MiddleName;
            DTO.EmployeeTypeID = _EmployeeTypeID;
            DTO.MaritalStatusID = _MaritalStatusID;
            DTO.Gender = _Gender;
            if (_DOB.Year.Equals(0001))
            {
                DTO.DOB = Convert.ToDateTime("1900-01-01");
            }
            else
            {
                DTO.DOB = _DOB;
            }
            DTO.PermanentAddress = _PermanentAddress;
            DTO.CurrentAddress = _CurrentAddress;
            DTO.MobileNumber = _MobileNumber;
            DTO.ResidenceNumber = _ResidenceNumber;
            DTO.EmergencyContactNumber = _EmergencyContactNumber;
            DTO.PersonalEmailID = _PersonalEmailID;
            DTO.IsActive = _IsActive;
            DTO.CreatedBy = _CreatedBy;
            if (_CreatedDate.Year.Equals(0001))
            {
                DTO.CreatedDate = Convert.ToDateTime("1900-01-01");
            }
            else
            {
                DTO.CreatedDate = _CreatedDate;
            }
            DTO.ModifiedBy = _UpdatedBy;
            DTO.ModifiedDate = DateTime.Now;
            DTO.IsDeleted = _IsDeleted;

            if (DTO.ID == 0)
            {
                byte[] photo = null;
                photo = new byte[1000 * 1000 * 3];
                DTO.Photo = photo;
                DTO.CreatedBy = _UpdatedBy;
                DTO.CreatedDate = DateTime.Now;
            }
            else
            {
                if (DTO.Photo.Length == 0)
                {
                    byte[] photo = null;
                    photo = new byte[1000 * 1000 * 3];
                    DTO.Photo = photo;
                }
            }

            return DTO;
        }
       
        public String Save()
        {
            Session DBSession = Session.CreateNewSession();
            
            try
            {
                Master_EmployeesBusinessObject BO = new Master_EmployeesBusinessObject(DBSession);
                Master_Employees DTO = GetDTO();
                if (_ID != 0)
                {
                    BO.Update(DTO);
                }
                else
                {
                    Master_EmployeeType objemp = new Master_EmployeeTypeBusinessObject().GetMaster_EmployeeType(DTO.EmployeeTypeID);
                    if (objemp != null)
                    {
                        if (objemp.Name == "Permanent")
                        {
                            _EmpCode = new Master_EmployeesBusinessObject().GetNextEmpCode(string.Empty);
                        }
                        else
                        {
                            _EmpCode = new Master_EmployeesBusinessObject().GetNextEmpCode("C");
                        }
                    }
                    DTO.EmpCode = _EmpCode;
                    _ID = BO.Create(DTO);
                }

                DBSession.Commit();

                return _ID.ToString() + "_" + _EmpCode;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(ex);
                DBSession.Rollback();
                return HREmployeeManagerDefs.Employee.EMPLOYEE_UPDATE_FAILURE; // ex.Message; 
            }
        }

        public static String DeleteEmployee(int RequestID)
        {
            Master_Employees em = new Master_EmployeesBusinessObject().GetMaster_Employees(RequestID);
            em.IsDeleted = true;
            EmployeePersonalDetails e = new EmployeePersonalDetails();
            e.Update(em);
            return e.Save();
        }


        #region JGridDataObject Members

        public object GetGridData()
        {
            return this;
        }

        #endregion
    }
}
