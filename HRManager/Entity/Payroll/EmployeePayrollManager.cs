using System;
using System.Collections.Generic;
using System.Text;
using HRManager.Entity;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IS91.Services.DataBlock;
using System.Data;

namespace HRManager.Entity
{
    public class EmployeePayrollManager
    {
        #region Monthly Payroll

        public static EmployeePayroll[] GetPayrollForAllEmployees(int month, int year, int branchId, int departmentId, bool IsPreviousLOP, int updatedBy, bool IsAnualbenifitsincluded)
        {
            Employee_PayrollBusinessObject objEPBO = new Employee_PayrollBusinessObject();
            DateTime datPay = new DateTime(year, month, 1);
            DataTable dtPay = objEPBO.GetEmployees(branchId, departmentId, datPay);
            EmployeePayroll[] empPay  = new EmployeePayroll[dtPay.Rows.Count];// null;

            if (dtPay.Rows.Count > 0)
            {
               
                int k = 0;
                foreach (DataRow dr in dtPay.Rows)
                {
                    EmployeePayroll epay = new EmployeePayroll(month, year, (int)dr["ID"]);
                    epay.EmployeeId = (int)dr["ID"];
                    epay.DepartmentId = (int)dr["DepartmentID"];
                    epay.BranchId = (int)dr["BranchID"];
                    epay.LocationId = (int)dr["LocationID"];
                    epay.EmployeeName = string.Concat(dr["EmployeeName"]);
                    epay.EmployeeCode = string.Concat(dr["EmpCode"]);
                    epay.Department = string.Concat(dr["Department"]);
                    epay.Branch = string.Concat(dr["Branch"]);
                    epay.Location = string.Concat(dr["Location"]);
                    epay.IsPreviousMonthLOP = IsPreviousLOP;
                    epay.UpdatedBy = updatedBy;
                    empPay[k] = epay;
                    k++;
                }
            }
            return empPay;
        }
        public static EmployeePayroll[] GetPayrollForAllEmployeesList(int month, int year, int updatedBy)
        {
            DateTime datPay = new DateTime(year, month, 1);
            return new Employee_PayrollBusinessObject().GetPayrollForAllEmployeesList(datPay);
            
        }
        public static EmployeePayroll[] GetPayrollForAllEmployees(int month, int year, int updatedBy)
        {
            Employee_PayrollBusinessObject objEPBO = new Employee_PayrollBusinessObject();
            DateTime datPay = new DateTime(year, month, 1);
            DataTable dtPay = objEPBO.GetEmployees(datPay);
            EmployeePayroll[] empPay  = new EmployeePayroll[dtPay.Rows.Count];// null;

            if (dtPay.Rows.Count > 0)
            {
               
                int k = 0;
                foreach (DataRow dr in dtPay.Rows)
                {
                    EmployeePayroll epay = new EmployeePayroll(month, year, (int)dr["ID"]);
                    epay.EmployeeId = (int)dr["ID"];
                    //epay.DepartmentId = (int)dr["DepartmentID"];
                    //epay.BranchId = (int)dr["BranchID"];
                    //epay.LocationId = (int)dr["LocationID"];
                    epay.EmployeeName = string.Concat(dr["EmployeeName"]);
                    epay.EmployeeCode = string.Concat(dr["EmpCode"]);
                    //epay.Department = string.Concat(dr["Department"]);
                    //epay.Branch = string.Concat(dr["Branch"]);
                    //epay.Location = string.Concat(dr["Location"]);
                    //epay.IsPreviousMonthLOP = false;
                    epay.UpdatedBy = updatedBy;
                    //epay.LeavingDate = (DateTime)dr["LeavingDate"];
                    epay.Month = month;
                    epay.Year = year;
                    epay.NetSalary = (Double)(dr["NetSalary"]); ;
                    epay.TotalDeductions = (Double)(dr["TotalDeductions"]); 
                    epay.TotalEarnings = (Double)(dr["TotalEarnings"]);
                    empPay[k] = epay;
                    k++;
                }
            }
            return empPay;
        }



        public EmployeePayroll GetPayrollForEmployee(int month, int year, int empId,int updatedBy)
        {
            Employee_PayrollBusinessObject objEPBO = new Employee_PayrollBusinessObject();
            DateTime datPay = new DateTime(month, year, 1);
            DataTable dtPay = objEPBO.GetEmployeeDetails(empId, datPay);
            EmployeePayroll epay = null;
            if (dtPay.Rows.Count > 0)
            {
                int k = 0;
                DataRow dr = dtPay.Rows[0];
                epay = new EmployeePayroll(month, year, (int)dr["ID"]);
                epay.ID = (int)dr["ID"];
                epay.EmployeeId = (int)dr["EmployeeID"];
                epay.DepartmentId = (int)dr["DepartmentID"];
                epay.BranchId = (int)dr["BranchID"];
                epay.LocationId = (int)dr["LocationID"];
                epay.EmployeeName = string.Concat(dr["EmployeeName"]);
                epay.EmployeeCode = string.Concat(dr["EmpCode"]);
                epay.Department = string.Concat(dr["Department"]);
                epay.Branch = string.Concat(dr["Branch"]);
                epay.Location = string.Concat(dr["Location"]);
                //epay.IsPreviousMonthLOP = IsPreviousLOP;
                epay.UpdatedBy = updatedBy;
                k++;
            }
            return epay;
        }
        #endregion


    }
}
