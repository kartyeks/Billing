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
    public class EmployeeInfoType
    {
        public static readonly String EMP_PERSONAL_INFO = "EMP_PERSONAL_INFO";
        public static readonly String EMP_OCCUPATIONAL_INFO = "EMP_OCCUPATIONAL_INFO";
        public static readonly String EMP_SALARY_INFO = "EMP_SALARY_INFO";
        public static readonly String EMP_EDUCATIONAL_INFO = "EMP_EDUCATIONAL_INFO";
        public static readonly String EMP_CAREER_INFO = "EMP_CAREER_INFO";
        public static readonly String EMP_DOCS_INFO = "EMP_DOCS_INFO";
    }


   public class EmployeeGateWay
    {
        public String Message { set; get; }

        public EmployeeInfo GetEmployeeInfoObject(String EmpInfoType)
        {
            if (EmployeeInfoType.EMP_PERSONAL_INFO == EmpInfoType)
            {
                return new EmployeePersonalDetails();
            }
            else if (EmployeeInfoType.EMP_OCCUPATIONAL_INFO == EmpInfoType)
            {
                return new EmployeeOccupationDetails();
            }
            else if (EmployeeInfoType.EMP_SALARY_INFO == EmpInfoType)
            {
                return new EmployeeSalaryDetails();
            }
            else if (EmployeeInfoType.EMP_EDUCATIONAL_INFO == EmpInfoType)
            {
                return new EmployeeEducationDetails();
            }
            else if (EmployeeInfoType.EMP_CAREER_INFO == EmpInfoType)
            {
                return new EmployeeCareerDetails();
            }
            else if (EmployeeInfoType.EMP_DOCS_INFO == EmpInfoType)
            {
                return new EmployeeDocumentDetails();
            }

            return null;
        }

        public BaseEmployee[] GetEmployees(String FirstName, String LastName, String Empcode, int DesignationID, int CountryID, int LocationID, int TeamID)
        {
            try
            {
                BaseEmployeeList List = new BaseEmployeeList(FirstName, LastName, Empcode, DesignationID,  CountryID, LocationID, TeamID);

                return List.ToArray();
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(ex);
                Message = HREmployeeManagerDefs.Employee.GET_EMP_ERROR;
                return null;
            }
        }

        public Employee GetEmployee(int EmpID)
        {
            try
            {
                return new Employee(EmpID);
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(ex);
                Message = HREmployeeManagerDefs.Employee.GET_EMP_ERROR;
                return null;
            }
        }
        public String UpdateEmployeeInfo(EmployeeInfo Emp)
        {
            Message = Emp.Save();
            return Message;
        }
        public String RemoveEmployeeInfo(String EmpInfoType, int EmpID)
        {
            try
            {
                EmployeeInfoList Emp = null;

                if (EmpInfoType == EmployeeInfoType.EMP_EDUCATIONAL_INFO)
                {
                    Emp = new EmployeeEducation();
                }
                if (EmpInfoType == EmployeeInfoType.EMP_CAREER_INFO)
                {
                    Emp = new EmployeeCareer();
                }
                else if (EmpInfoType == EmployeeInfoType.EMP_DOCS_INFO)
                {
                    Emp = new EmployeeDocument();
                }
                return Emp.Delete(EmpID);
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(ex);
                return ex.Message;
            }
        }

        public bool IsEmpFresher(int empId)
        {
            return new Employee_CareerBusinessObject().CheckIsFresher(empId,true);

        }
    }
}
