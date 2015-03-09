using System;
using System.Collections.Generic;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IRCA.Communication;
using IS91.Services.DataBlock;

namespace HRManager.Entity
{
    public class Employees1 : JGridDataObject
    {
        private int _ID;
        private int _CandidateID;
        private int _DepartmentID;
        private string _EmpCode;

        private string _FirstName;
        private string _LastName;
        private string _Initial;
        private DateTime _DOB;
        private string _Gender;
        private int _MaritalStatusID;
        private string _PermanentAddress;
        private string _CurrentAddress;
        private string _MobileNumber;
        private string _EmergencyContactNumber;
        //private string _PersonalEmailID;
         
        private string _EMailID;
        private int _EmploymentType;
        private string _Status;
        private string _BloodGroup;
        private DateTime _DateOfJoining;
        private bool _IsNew;
        private byte[] _Photo;

        private string _CandidateName;
        private int _GradeID;
        private int _DesignationID;
        private int _BranchID;
        private int _LocationID;
        private int _RoleID;
        private string _Role;

        private string _DepartmentName;
        private string _Designation;
        private string _Grade;
        private string _Branch;
        private string _Location;
        private double _Basic;
        private double _BasicFund;
        //private CandidatePersonalInfo _Candidate = null;

        private int _UpdateBy;
        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;
        private DateTime _DateOfRetairment;
        private String _KPI;
        private DateTime _AppraisalFromDate;
        private DateTime _AppraisalToDate;
        private DateTime _ConfirmationDate;
        private DateTime _ConfirmationDueDate;

        private DateTime _LeavingDate = Convert.ToDateTime("01/01/1900 00:00:00");
        private String _LeavingStatus;
        private DateTime _WeddingDay = Convert.ToDateTime("01/01/1900 00:00:00");
        public string DepartmentName
        {
            get
            {
                return _DepartmentName;
            }
            set
            {
                _DepartmentName = value;
            }
        }

        public int DepartmentID
        {
            get
            {
                return _DepartmentID;
            }
            set
            {
                _DepartmentID = value;
            }
        }

        public int ID { get { return _ID; } set { _ID = value; } }
        public Byte[] Photo { get { return _Photo; } set { _Photo = value; } }
        public string EmpCode { get { return _EmpCode; } set { _EmpCode = value; } }
        public string FirstName { get { return _FirstName; } set { _FirstName = value; } }
        public string LastName { get { return _LastName; } set { _LastName = value; } }
        public string Initial { get { return _Initial; } set { _Initial = value; } }
        public DateTime DOB { get { return _DOB; } set { _DOB = value; } }
        public string Gender { get { return _Gender; } set { _Gender = value; } }
        public int MaritalStatusID { get { return _MaritalStatusID; } set { _MaritalStatusID = value; } }
        public string PermanentAddress { get { return _PermanentAddress; } set { _PermanentAddress = value; } }
        public string CurrentAddress { get { return _CurrentAddress; } set { _CurrentAddress = value; } }
        public string MobileNumber { get { return _MobileNumber; } set { _MobileNumber = value; } }
        public string EmergencyContactNumber { get { return _EmergencyContactNumber; } set { _EmergencyContactNumber = value; } }
        public string EMailID { get { return _EMailID; } set { _EMailID = value; } }
        

        public Employees1()
        {
        }
        
        public void Update(Master_Employees DTO)
        {
            if (DTO != null)
            {
                _ID = DTO.ID;
                _EmpCode = DTO.EmpCode;
                _FirstName = DTO.FirstName;
                _LastName = DTO.LastName;
                _Initial = DTO.MiddleName;
                _DOB = DTO.DOB;
                _MaritalStatusID = DTO.MaritalStatusID;
                _PermanentAddress = DTO.PermanentAddress;
                _CurrentAddress = DTO.CurrentAddress;
                _MobileNumber = DTO.MobileNumber;
                _EmergencyContactNumber = DTO.EmergencyContactNumber;
                _EMailID = DTO.PersonalEmailID;
                _Photo = DTO.Photo;
               // _CountryCode = DTO.CountryCode;
               // _CountryName = DTO.CountryName;
                //_IsActive = DTO.IsActive;
                _ModifiedBy = DTO.ModifiedBy;
                _ModifiedDate = DTO.ModifiedDate;
                _CreatedBy = DTO.CreatedBy;
                _CreatedDate = DTO.CreatedDate;
            }
        }
        private Master_Employees GetDTO()
        {
            Master_Employees DTO = new Master_Employees();
            DTO.ID = _ID;
            DTO.EmpCode = _EmpCode;
            DTO.FirstName = _FirstName;
            DTO.LastName=_LastName;
            DTO.MiddleName = _Initial;
            DTO.DOB=_DOB;
            DTO.MaritalStatusID=_MaritalStatusID;
            DTO.PermanentAddress=_PermanentAddress;
            DTO.CurrentAddress=_CurrentAddress;
            DTO.MobileNumber=_MobileNumber;
            DTO.EmergencyContactNumber = _EmergencyContactNumber;
            DTO.PersonalEmailID = _EMailID;
            DTO.Photo = _Photo;
            //DTO.CountryCode = _CountryCode;
            //DTO.CountryName = _CountryName;
            DTO.CreatedBy = _CreatedBy;
            DTO.CreatedDate = _CreatedDate;
            DTO.ModifiedBy = _ModifiedBy;
            DTO.ModifiedDate = _ModifiedDate;
            //DTO.IsActive = _IsActive;

            if (_ID == 0)
            {
                DTO.CreatedBy = _CreatedBy;
                DTO.CreatedDate = DateTime.Now;
            }
            DTO.ModifiedBy = _ModifiedBy;
            DTO.ModifiedDate = DateTime.Now;

            return DTO;
        }
          public String Validate()
        {
            return String.Empty;

        }
        public String Save()
        {
            String Status = Validate();
            if (Status != String.Empty)
            {
                return Status;
            }
            try
            {
                Master_EmployeesBusinessObject BO = new Master_EmployeesBusinessObject();
                Master_Employees DTO = GetDTO();

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

        //public static Employees[] GetEmpDeptWise(int Dept)
        //{
            //Employees[] Employee = new Master_EmployeesBusinessObject().GetEmpDeptWise(Dept);

            //return Employee;
        //}
        #region JGridDataObject Members

        public object GetGridData()
        {
            EmployeesDisplayDetails Employee = new EmployeesDisplayDetails();

            Employee.EmployeeID = _ID;
            Employee.CandidateID = _CandidateID;
            Employee.EmployeeName = _CandidateName;
            Employee.Code = _EmpCode;
            Employee.Branch = _Branch;
            Employee.Department = _DepartmentName;
            Employee.Designation = _Designation;
            Employee.Grade = _Grade;
            Employee.EMailID = _EMailID;
            Employee.EmployeeTypeID = _EmploymentType.ToString();
            Employee.EmployeeType = new EmployeeType(_EmploymentType).Name;


            Employee.FirstName = _FirstName;
            Employee.LastName=_LastName;
            Employee.Initial = _Initial;
            Employee.DOB = _DOB.ToString("dd/MM/yyyy");
            Employee.Gender=_Gender;
            Employee.MaritalStatusID = _MaritalStatusID;
            Employee.PermanentAddress=_PermanentAddress;
            Employee.CurrentAddress=_CurrentAddress;
            Employee.MobileNumber=_MobileNumber;
            Employee.EmergencyContactNumber=_EmergencyContactNumber;
            
            return Employee;
        }

        #endregion
    }
    public class EmployeesDisplayDetails
    {
        public int EmployeeID;
        public int CandidateID;
        public string EmployeeTypeID;
        public string EmployeeType;
        public string EmployeeName;
        public string Code;
        public string Branch;
        public string Department;
        public string Designation;
        public string Grade;
        public string EMailID;

        public String FirstName;
        public String LastName;
        public String Initial;
        public String DOB;
        public String Gender;
        public int MaritalStatusID;
        public String PermanentAddress;
        public String CurrentAddress;
        public String MobileNumber;
        public String EmergencyContactNumber;

    }
}
   
