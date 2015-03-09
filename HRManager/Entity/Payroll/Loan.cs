using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;

namespace HRManager.Entity
{
    public class Loan
    {
        private int _ID; //DeductionID
        private int _LoanID; //LoanID
        private int _DeductionID; //RequestID 
        private int _EmployeeID;
        private int _Month;
        private int _Year;
        private string _Name;
        private Double _Amount; //MonthlyAmount
        private bool _IsNew;

        private Double _LoanAmount;
        private int _Installments;
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
        public string LoanName        
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
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
        public int LoanID
        {
            get
            {
                return _LoanID;
            }
            set
            {
                _LoanID = value;
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
        public double LoanAmount
        {
            get
            {
                return _LoanAmount;
            }
            set
            {
                _LoanAmount = value;
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
                _Installments= value;
            }
        }
        /// Consturctor of Loan class.
        /// Set variables for new Loan.  
        /// </summary>
        public Loan()
        {
            _ID = 0;
            _IsNew = true;
        }

          /// <summary>
        /// Consturctor of Loan class.
        /// Update Loan fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains SalaryDeductions ID</param>
        public Loan(int ID)
        {
            new Employee_Payroll_DeductionsBusinessObject().GetEmployeeLoan(ID,this);
        }


        /// <summary>
        /// Return particular employee Loan for a month and year After post
        /// </summary>
        /// <returns> object of Loan class</returns>
        public Loan(int month, int year, int employeeID)
        {
            new Employee_Payroll_DeductionsBusinessObject().GetEmployeeLoan(month, year, employeeID,this);
        }
        /// <summary>
        /// Return all EmployeesLoan for an month and year After post
        /// </summary>
        /// <returns>Array of the object of Loan class</returns>
        public Loan[] GetAllEmployeesLoan(int month, int year)
        {
            Loan[] ESIDetails = new Employee_Payroll_DeductionsBusinessObject().GetAllEmployeesLoan(month, year);
            return ESIDetails;
        }

        /// <summary>
        /// Return particular employee Loan balance amount Before post
        /// </summary>
        /// <returns> object of Loan class</returns>
        public Loan GetEmployeeLoanBalanceAmount(int employeeID)
        {
            Loan LoanDetails = new Employee_Payroll_DeductionsBusinessObject().GetEmployeeLoanBalanceAmount(employeeID);
            return LoanDetails;
        }
    }
}
