using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;

namespace HRManager.Entity
{
   public class PayrollTax
    {
        private int _ID;
        private int _TaxID;
        private string _TaxName;
        private string _TaxCode;
        private int _EmployeeID;
        private int _Month;
        private int _Year;
        private int _FinYear;
        private bool _IsFixedPercentage;
        private bool _IsTaxExemppted;
        private Double _PercentageValue;
        private Double _Amount;
        private Double _TotalGrossSalary;
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
        public string TaxCode
        {
            get
            {
                return _TaxCode;
            }
            set
            {
                _TaxCode = value;
            }
        }
        public string TaxName
        {
            get
            {
                return _TaxName;
            }
            set
            {
                _TaxName= value;
            }
        }
        public int TaxID
        {
            get
            {
                return _TaxID;
            }
            set
            {
                _TaxID= value;
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

        public bool IsFixedPercentage
        {
            get
            {
                return _IsFixedPercentage;
            }
            set
            {
                _IsFixedPercentage= value;
            }
        }
        public bool IsTaxExemppted
        {
            get
            {
                return _IsTaxExemppted;
            }
            set
            {
                _IsTaxExemppted = value;
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
                return Math.Round(_Amount,2,MidpointRounding.AwayFromZero);
            }
            set
            {
                _Amount = value;
            }
        }
        public double TotalGrossSalary
        {
            get
            {
                return _TotalGrossSalary;
            }
            set
            {
                _TotalGrossSalary = value;
            }
        }
         
        public PayrollTax()
        {
            _ID = 0;
            _IsNew = true;
        }
        public PayrollTax(int ID)
        {
           new Employee_Payroll_DeductionsBusinessObject().GetEmployeeTax(ID,this);
        }
       
        public PayrollTax(int month, int year, int employeeid, int taxId, double grosssalary)
        {
            _Month = month;
            _Year = year;
            _FinYear = new Employee_PayrollBusinessObject().GetFinancialYear(month, year);
            _EmployeeID = employeeid;
            new Employee_Payroll_DeductionsBusinessObject().GetEmployeeTax(_FinYear, grosssalary, taxId,this);
        }
        public PayrollTax(int month, int year, int employeeid, int taxId, PayrollEarnings earnings)
        {
            _Month = month;
            _Year = year;
            _FinYear = new Employee_PayrollBusinessObject().GetFinancialYear(month, year);
            _EmployeeID = employeeid;
            new Employee_Payroll_DeductionsBusinessObject().GetEmployeeTax(_FinYear, earnings, taxId, this);
        }
    }
}
