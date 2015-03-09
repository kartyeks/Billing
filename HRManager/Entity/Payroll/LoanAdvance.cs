using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;

namespace HRManager.Entity
{
    public class LoanAdvance
    {
        private int _ID; //ID
        private int _DeductionID; //AdvanceID 
        private string _AdvanceName;
        private int _EmployeeID;

        private int _Month;
        private int _Year;
        private Double _Amount;
        private bool _IsNew;

        private int _Installments;
        private Double _AdvanceAmount;
        private Double _BalanceAmount;

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
        public string AdvanceName
        {
            get
            {
                return _AdvanceName;
            }
            set
            {
                _AdvanceName = value;
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
        public double AdvanceAmount
        {
            get
            {
                return _AdvanceAmount;
            }
            set
            {
                _AdvanceAmount = value;
            }
        }
        public double BalanceAmount
        {
            get
            {
                return _BalanceAmount;
            }
            set
            {
                _BalanceAmount = value;
            }
        }
        public int Installments
        {
            get
            {
                return _Installments;
            }
            set
            {
                _Installments = value;
            }
        }
        /// Consturctor of Loan class.
        /// Set variables for new Loan.  
        /// </summary>
        public LoanAdvance()
        {
            _ID = 0;
            _IsNew = true;
        }
          /// <summary>
        /// Consturctor of LoanAdvance class.
        /// Update LoanAdvance fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains SalaryDeductions ID</param>
        public LoanAdvance(int ID)
        {
            new Employee_Payroll_DeductionsBusinessObject().GetEmployeeLoanAdvance(ID,this);
        }

        /// <summary>
        /// Return particular employee LoanAdvance for a month and year After post
        /// </summary>
        /// <returns> object of LoanAdvance class</returns>
        public LoanAdvance(int month, int year, int employeeID)
        {
            new Employee_Payroll_DeductionsBusinessObject().GetEmployeeLoanAdvance(month, year, employeeID,this);
        }
        /// <summary>
        /// Return all Employees LoanAdvance for an month and year After post
        /// </summary>
        /// <returns>Array of the object of LoanAdvance class</returns>
        public LoanAdvance[] GetAllEmployeesLoanAdvance(int month, int year)
        {
            LoanAdvance[] ESIDetails = new Employee_Payroll_DeductionsBusinessObject().GetAllEmployeesLoanAdvance(month, year);
            return ESIDetails;
        }

        /// <summary>
        /// Return particular employee LoanAdvance balance amount Before post
        /// </summary>
        /// <returns> object of LoanAdvance class</returns>
        public LoanAdvance GetEmpLoanBalanceAdvAmount(int employeeID)
        {
            LoanAdvance LoanDetails = new Employee_Payroll_DeductionsBusinessObject().GetEmpLoanBalanceAdvAmount(employeeID);
            return LoanDetails;
        }
    }
}
