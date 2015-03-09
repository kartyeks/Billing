using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS91.Services;

namespace HRManager
{
    public class HREmployeeManagerDefs
    {
        public class Employee
        {
            #region Employee
            public static readonly String EMPLOYEE_ADDED_SUCCESS = "Employee details added successfully";
            public static readonly String EMPLOYEE_UPDATE_SUCCESS = "Employee details updated successfully";
            public static readonly String EMPLOYEE_UPDATE_FAILURE = "Error on updating the Employee info";
            public static readonly String EMPLOYEE_NOT_EXIST = "Employee does not exists";
            public static readonly String EMIAL_EXISTS = "The given email already exists ";
            public static readonly String EMPLOYEECODE_NOT_EXIST = "Employee code does not exists";
            public static readonly String EMPLOYEE_DOCUMENT_DELETED_SUCCESS = "Employee document deleted successfully";
            public static readonly String GET_EMP_ERROR = "Error on getting employee records";

            public static readonly String EDUCATION_EXISTS = "The given education name already exists ";
            public static readonly String COMPANY_EXISTS = "The given company name already exists ";

            public static readonly String FRESHER_EXISTS = "The selected employee has experience  record,You can't add as a fresher ";
            #endregion
        }
       
      
      

    }
}
