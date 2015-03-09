using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;

namespace HRManager.Entity
{
   public class ESI
    {
        private int _ID;
        private int _DeductionID;
        private int _EmployeeID;
        private int _Month;
        private int _Year;
        private Double _PercentageValue;
        private Double _Amount;
        private Double _GrossSalary;
        private bool _IsTaxExempted;
        private bool _IsNew;

        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
        public int DeductionID
        {
            get
            {
                return _DeductionID;
            }
            set
            {
                _DeductionID = value;
            }
        }
        public int EmployeeID
        {
            get
            {
                return _EmployeeID;
            }
            set
            {
                _EmployeeID = value;
            }
        }
        public int Month
        {
            get
            {
                return _Month;
            }
            set
            {
                _Month = value;
            }
        }
        public int Year
        {
            get
            {
                return _Year;
            }
            set
            {
                _Year = value;
            }
        }
        public double PercentageValue
        {
            get
            {
                return _PercentageValue;
            }
            set
            {
                _PercentageValue = value;
            }
        }
        public double Amount
        {
            get
            {
                return _Amount;
            }
            set
            {
                _Amount = value;
            }
        }
        public double GrossSalary
        {
            get
            {
                return _GrossSalary;
            }
            set
            {
                _GrossSalary = value;
            }
        }

        public bool IsTaxExempted 
        {
            get
            {
                return _IsTaxExempted;
            }
            set
            {
                _IsTaxExempted = value;
            }
        }
        /// Consturctor of ESI class.
        /// Set variables for new ESI.  
        /// </summary>
        public ESI()
        {
            _ID = 0;
            _IsNew = true;
        }
        /// <summary>
        /// Consturctor of ESI class.
        /// Update ESI fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains SalaryDeductions ID</param>
        public ESI(int ID)
        {
            new Employee_Payroll_DeductionsBusinessObject().GetEmployeeESI(ID,this);
        }
        /// <summary>
        /// Return particular employee ESI for a month and year after post
        /// </summary>
        /// <returns> object of ESI class</returns>
        public ESI(int month, int year, int employeeID)
        {
            new Employee_Payroll_DeductionsBusinessObject().GetEmployeeESI(month, year, employeeID, this);
        }
        /// <summary>
        /// Return all EmployeesESI for an month and year after post
        /// </summary>
        /// <returns>Array of the object of ESI class</returns>
        public ESI[] GetAllEmployeesESI(int month,int year)
        {
            ESI[] ESIDetails = new Employee_Payroll_DeductionsBusinessObject().GetAllEmployeesESI(month, year);
            return ESIDetails;
        }

        public ESI (int month, int year, int employeeid, double grosssalary,double esiSalary)
        {
            Master_Employees oEmp = new Master_EmployeesBusinessObject().GetMaster_Employees(employeeid);
            if (oEmp != null)
            {
                //if (oEmp.EmploymentType == 4)
                //{
                //    Amount = 0;
                    return;
                //}
            }
            new Employee_Payroll_DeductionsBusinessObject().GetEmployeeESI(month, year, employeeid, this);
            if (this._DeductionID > 0)
            {
                //double dblPercentageValue = new Employee_Payroll_DeductionsBusinessObject().getDeductionPercentage();
                double dblPercentageValue = new Employee_Payroll_DeductionsBusinessObject().GetESIPercentage(employeeid);
                double esilimit = double.Parse(IS91.Services.Common.GetAppSetting("ESILimit"));
                if (esiSalary > esilimit)
                {
                    _Amount = 0;
                }
                else
                {
                    if (grosssalary != 0)
                        _Amount = (grosssalary * dblPercentageValue) / 100;
                }
            }
        }
        public ESI(double grosssalary)
        {
           
            double dblPercentageValue = new Employee_Payroll_DeductionsBusinessObject().getDeductionPercentage();
            double esilimit = double.Parse(IS91.Services.Common.GetAppSetting("ESILimit"));
            if (grosssalary > esilimit)
            {
                _Amount = 0;
            }
            else
            {
                if (grosssalary != 0)
                    _Amount = (grosssalary * dblPercentageValue) / 100;
            }
       }
        public ESI(double grosssalary,int empId)
        {
            Master_Employees oEmp = new Master_EmployeesBusinessObject().GetMaster_Employees(empId);
            if (oEmp != null)
            {
                //if (oEmp.EmploymentType == 4)
                //{
                //    Amount = 0;
                    return;
                //}
            }
            double dblPercentageValue = new Employee_Payroll_DeductionsBusinessObject().GetESIPercentage(empId);
            double esilimit = double.Parse(IS91.Services.Common.GetAppSetting("ESILimit"));
            if (grosssalary > esilimit)
            {
                _Amount = 0;
            }
            else
            {
                if (grosssalary != 0)
                    _Amount = (grosssalary * dblPercentageValue) / 100;
            }
        }
    }
}
