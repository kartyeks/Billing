using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;

namespace HRManager.DTOEXT.Employees
{
    public class BaseMaster_EmployeeExtened
    {
        public int EmpID;
        public String EmpCode;
        public int EmployeeTypeID;
        public String FirstName;
        public String LastName;
        public String MiddleName;
        public String EmployeeType;
        public String CountryName;
        public String LocationName;
        public String Designation;
        public String TeamName;
        public String ManagerName;
        public String Gender;
        public String EmailID;
    }

    public class EmployeeExitManagementExtened
    {
        public int EmployeeID;
        public DateTime ExitDate;    
        public String EmployeeName;            
        public String EmployeeEmailID;
        public int ManagerID;
        public String ExitType;
    }
    public class EmployeeLeaveExtened
    {
        public int EmpID;
        public int ManagerID;
    }
   
}
