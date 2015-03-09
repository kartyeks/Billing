using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IS91.Services.DataBlock;
using IRCA.Communication;
using HRManager.DTOEXT.Employees;

namespace HRManager.Entity.EmployeesInfo
{
    public class BaseEmployeeList : List<BaseEmployee>
    {
        public BaseEmployeeList(string firstName, string LastName, string Empcode, int DesignationID, int CountryID, int LocationID, int TeamID)
        {
             BaseMaster_EmployeeExtened[] DTO = new Master_EmployeesBusinessObject().GetBaseMasterEmployee(firstName, LastName, Empcode, DesignationID, CountryID, LocationID, TeamID);
            for (int i = 0; i < DTO.Length; i++)
            {
                BaseEmployee Emp = new BaseEmployee();
                Emp.Update(DTO[i]);
                Add(Emp);
            }
        }

    }


    public class BaseEmployee : JGridDataObject
    {
        private int _EmpID;
        private String _EmployeeCode;
        private int _EmpTypeID;
        private String _FirstName;
        private String _MiddleName;
        private String _LastName;
        private String _EmployeeType;
        private String _Country;
        private String _LocationName;
        private String _Designation;
        private String _Team;
         private String _ManagerName;
        private String _Gender;
        private String _EmailID;

        public int EmpID { get { return _EmpID; } }
        public int EmpTypeID { get { return _EmpTypeID; } }
        public String EmployeeCode { get { return _EmployeeCode; } }
        public String EmployeeType { get { return _EmployeeType; } }
        public String FirstName { get { return _FirstName; } }
        public String MiddleName { get { return _MiddleName; } }
        public String LastName { get { return _LastName; } }
        public String Country { get { return _Country; } }
        public String Location { get { return _LocationName; } }
        public String Designation { get { return _Designation; } }
        public String Team { get { return _Team; } }
        public String ManagerName { get { return _ManagerName; } }
        public String Gender { get { return _Gender; } }
        public String EmailID { get { return _EmailID; } }

        internal virtual void Update(BaseMaster_EmployeeExtened DTO)
        {
            _EmpID = DTO.EmpID;
            _EmployeeCode = DTO.EmpCode;
            _EmpTypeID = DTO.EmployeeTypeID;
            _FirstName = DTO.FirstName;
            _MiddleName = DTO.MiddleName;
            _LastName = DTO.LastName;
            _EmployeeType = DTO.EmployeeType;
            _Country = DTO.CountryName;
            _LocationName = DTO.LocationName;
            _Designation = DTO.Designation;
            _Team = DTO.TeamName;
            _ManagerName = DTO.ManagerName;
            _Gender = DTO.Gender;
            _EmailID = DTO.EmailID;
        }

        public BaseEmployee()
        {

        }

        //public BaseEmployee(String EmpCode)
        //{
        //    BaseMaster_EmployeeExtened DTO = new Master_EmployeeBusinessObject().GetBaseMasterEmployee(EmpCode);
        //    Update(DTO);
        //}


        #region JGridDataObject Members

        public object GetGridData()
        {
            return this;
        }

        #endregion
    }
    public class Employee : BaseEmployee
    {
        private int _ID;
        private EmployeePersonalDetails _PersonalInfo;
        private EmployeeOccupationDetails _OccupationInfo;
        private EmployeeSalaryDetails _SalaryInfo;
        private EmployeeEducation _EducationInfo;
        private EmployeeCareer _CareerInfo;
        private EmployeeDocument _EmpDocs;

        public EmployeePersonalDetails PersonalInfo { get { return _PersonalInfo; } }
        public EmployeeOccupationDetails OccupationInfo { get { return _OccupationInfo; } }
        public EmployeeSalaryDetails SalaryInfo { get { return _SalaryInfo; } }


        public Object EducationInfo
        {
            get
            {
                JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(EmployeeEducationDetails));
                Builder.AddRow(_EducationInfo.ToArray());
                return Builder.GetGridObject();
            }
        }
        public Object EmpDocs
        {
            get
            {
                JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(EmployeeDocumentDetails));
                Builder.AddRow(_EmpDocs.ToArray());
                return Builder.GetGridObject();
            }
        }
        public Object CareerInfo
        {
            get
            {
                JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(EmployeeCareerDetails));
                Builder.AddRow(_CareerInfo.ToArray());
                return Builder.GetGridObject();
            }
        }
        public Employee(int EmpID)
        {
            _ID = EmpID;
            _PersonalInfo = new EmployeePersonalDetails(_ID);
            _OccupationInfo = new EmployeeOccupationDetails(_ID);
            _SalaryInfo = new EmployeeSalaryDetails(_ID);
            _CareerInfo = new EmployeeCareer(_ID);
            _EducationInfo = new EmployeeEducation(_ID);
            _EmpDocs = new EmployeeDocument(_ID);
        }
    }
}
