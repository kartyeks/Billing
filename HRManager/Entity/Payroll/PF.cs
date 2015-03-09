using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IS91.Services.DataBlock;

namespace HRManager.Entity
{
    public class PF  
    {
        private int _ID;
        private int _DeductionID;
        private int _EmployeeID;
        private int _Month;
        private int _Year;
        private Double _Percentage;
        private Double _Amount;
        private Double _Basic;
        private bool _IsTaxExempted;
        

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
                _EmployeeID= value;
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
                _Month= value;
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
                _Year= value;
            }
        }
        public double Percentage
        {
            get
            {
                return _Percentage;
            }
            set
            {
                _Percentage= value;
            }
        }
        public double Amount
        {
            get
            {
                return Math.Round(_Amount,2,MidpointRounding.AwayFromZero);
            }
            set
            {
                _Amount = value;
            }
        }
        public double Basic
        {
            get
            {
                return _Basic;
            }
            set
            {
                _Basic = value;
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

        private bool _IsNew;

        public PF(int empId,int month,int year,double basic)
        {
            _Basic = basic;
            _Month = month;
            _Year = year;
            _EmployeeID = empId;
            if(basic!=0)
                new Employee_Payroll_DeductionsBusinessObject().GetEmployeePF(empId,basic, this);
        }
      
        /// <summary>
        /// Consturctor of PF class.
        /// Update PF fields using Master_Salary_Deductions.
        /// </summary>
        /// <param name="Policy">Object of Master_Policy class</param>
        public PF(int month,int year,int empId)
        {
            new Employee_Payroll_DeductionsBusinessObject().GetEmployeePF(month, year, empId, this);
        }
         /// <summary>
        /// Consturctor of PF class.
        /// Update PF fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains SalaryDeductions ID</param>
        public PF(int ID)
        {
            new Employee_Payroll_DeductionsBusinessObject().GetEmployeePF(ID,this);
        }
        /// <summary>
        /// Consturctor of PF class.
        /// Set variables for new PF.  
        /// </summary>
        public PF()
        {
            _ID = 0;
            _IsNew = true;
        }
       
        /// <summary>
        /// Return all inactive PF
        /// </summary>
        /// <returns>Array of the object of PF class</returns>
        public static PF[] GetAllEmployeesPF(int month,int year)
        {
            PF[] empsPF = new Employee_Payroll_DeductionsBusinessObject().GetAllEmployeesPF(month,year);


            return empsPF;
        }
  

    }
   
}
