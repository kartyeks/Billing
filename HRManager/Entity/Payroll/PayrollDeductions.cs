using System;
using System.Collections.Generic;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;

namespace HRManager.Entity
{
  public class PayrollDeductions
    {
        private int _PayrollID;  
        private int _EmployeeID;
        private int _Month;
        private int _Year;
        private double _TDS;
        private int _TDSID;
        private ESI _ESI;
        private PF _PF;
        private Loan[] _Loan;
        private LoanAdvance[] _LoanAdvance;
        private PayrollTax[] _TaxDeduction;
        private double _TotalDeductions;
        private bool _IsNew=true;

        private OtherDeductions[] _Otherdeductions;
       
        
        public int PayrollID
        {
            get
            {
                return _PayrollID;
            }
            set
            {
                _PayrollID = value;
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
        
        public ESI ESI
        {
            get
            {
                return _ESI;
            }
            set
            {
                _ESI = value;
            }
        }
        public PF PF
        {
            get
            {
                return _PF;
            }
            set
            {
                _PF = value;
            }
        }
        public Loan[] Loan
        {
            get
            {
                return _Loan;
            }
            set
            {
                _Loan = value;
            }
        }
        public LoanAdvance[] LoanAdvance
        {
            get
            {
                return _LoanAdvance;
            }
            set
            {
                _LoanAdvance = value;
            }
        }
        public PayrollTax[] TaxDeduction
        {
            get
            {
                return _TaxDeduction;
            }
            set
            {
                _TaxDeduction = value;
            }
        }
        public OtherDeductions[] OtherDeductions
        {
            get
            {
                return _Otherdeductions;
            }
            set
            {
                _Otherdeductions = value;
            }
        }

        public double TDS
        {
            get
            {
                return Math.Round(_TDS,2,MidpointRounding.AwayFromZero);
            }
            set
            {
                _TDS = value;
            }
        }

        public int TDSID
        {
            get
            {
                return _TDSID;
            }
            set
            {
                _TDSID = value;
            }
        }
        public double TotalDeductions
        {
            get
            {
                return _TotalDeductions;
            }
            set
            {
                _TotalDeductions = value;
            }
        }

      /// <summary>
      /// Calculates Total Deductions
      /// </summary>
        private void GetTotalDeduction()
        {
            double totLn = 0;
            double totAdv = 0;
            if (_Loan != null)
            {
                foreach (Loan ln in _Loan)
                {
                    if (ln.Amount > 0)
                        totLn = totLn + ln.Amount;
                }
            }
            if (_LoanAdvance != null)
            {
                foreach (LoanAdvance adv in _LoanAdvance)
                {
                    if (adv.Amount > 0)
                        totAdv = totAdv + adv.Amount;
                }
            }
 

            double tot =  Math.Ceiling(_ESI.Amount) + totLn + totAdv + _TDS;

            if (_Otherdeductions != null)
            {
                foreach (OtherDeductions de in _Otherdeductions)
                {
                    tot = tot + de.Deduction;
                }
            }
            if (_TaxDeduction!= null)
            {
                foreach (PayrollTax tx in _TaxDeduction)
                {
                    tot = tot + tx.Amount;
                }
            }
            _TotalDeductions = tot;
        }
        /// <summary>
        /// Consturctor of Salary Allowance class.
        /// Set variables for new Salary Allowance.  
        /// </summary>
        public PayrollDeductions()
        {
            _IsNew = true;
        }

        /// <summary>
        /// Construnctor For Saved Payroll
        /// </summary>
        /// <param name="payrollId"></param>
        public PayrollDeductions(int payrollId)
        {
            Employee_Payroll_DeductionsBusinessObject PayDedBO = new Employee_Payroll_DeductionsBusinessObject();
                int Id = PayDedBO.GetESIID(payrollId);
                _ESI = new ESI(Id);
                PayDedBO.GetLoanDeduction(payrollId, this);
                PayDedBO.GetAdvacneDeduction(payrollId, this);
                //Id = new Employee_Payroll_DeductionsBusinessObject().GetADVID(payrollId);
                //_LoanAdvance = new LoanAdvance(Id);
                Id = new Employee_Payroll_DeductionsBusinessObject().GetPFID(payrollId);
                _PF = new PF(Id);
                _TDSID= new Employee_Payroll_DeductionsBusinessObject().GetTDSID(payrollId);
                _TDS = new Employee_Payroll_DeductionsBusinessObject().GetTDS(payrollId);
                new Employee_Payroll_DeductionsBusinessObject().GetEmployeePayrollTaxes(payrollId, this);
                new Employee_Payroll_DeductionsBusinessObject().GetEmployeePayrollDeductions(payrollId, this);
                GetTotalDeduction();
        }
      /// <summary>
      /// Constructor For Calculating Deductions
      /// </summary>
      /// <param name="PayEarnings"></param>
        public PayrollDeductions(PayrollEarnings PayEarnings)
        {
            if (PayEarnings != null)
            {
                _Month = PayEarnings.Month;
                _Year = PayEarnings.Year;
                _EmployeeID = PayEarnings.EmployeeId;
                bool blnConsultant = false;
                Master_Employees oEmp = new Master_EmployeesBusinessObject().GetMaster_Employees(_EmployeeID);
                //if (oEmp != null)
                //{
                //    blnConsultant = (oEmp.EmploymentType == 4);
                //}
                Employee_Payroll_DeductionsBusinessObject PayDedBO = new Employee_Payroll_DeductionsBusinessObject();
               _ESI = new ESI(PayEarnings.Month, PayEarnings.Year, PayEarnings.EmployeeId, PayEarnings.ESIGrossSalary,PayEarnings.ESISalary);
               //PayDedBO.GetLoansForDeduction(_EmployeeID, this, _Month,_Year);
               //PayDedBO.GetAdvanceForDeduction(_EmployeeID, this);
                //_LoanAdvance = new LoanAdvance().GetEmpLoanBalanceAdvAmount(PayEarnings.EmployeeId);
                //_PF = new PF(PayEarnings.EmployeeId, PayEarnings.Month, PayEarnings.Year, PayEarnings.Basic);
               double basicArr = 0;
//               int ind = Array.FindIndex<Allowance>(PayEarnings.Allowances, (x) => (x.Name.ToLower() == "basic arrears" || x.Name.ToLower() == "bar"));
//               if (ind > -1)
//                   basicArr = PayEarnings.Allowances[ind].Amount;
//               _PF = new PF(PayEarnings.EmployeeId, PayEarnings.Month, PayEarnings.Year, PayEarnings.Basic + PayEarnings.BasicArrears + basicArr);
//                int FYear = new Employee_PayrollBusinessObject().GetFinancialYear(PayEarnings.Month, PayEarnings.Year);
                
//                //_TDS = new Employee_Payroll_DeductionsBusinessObject().GetTDS(PayEarnings.EmployeeId, FYear);
//                _TDS = new Employee_Payroll_DeductionsBusinessObject().GetTDS(PayEarnings.EmployeeId, PayEarnings.Basic + PayEarnings.BasicArrears + basicArr, _Month, _Year);
//                new Employee_Payroll_DeductionsBusinessObject().GetPayrollTaxes(PayEarnings, this);
////                new Employee_Payroll_DeductionsBusinessObject().GetPayrollOtherDeductions(PayEarnings.Basic, this);
//                //if(!blnConsultant)
//                new Employee_Payroll_DeductionsBusinessObject().GetPayrollOtherDeductions(PayEarnings.Basic, this);

                GetTotalDeduction();
            }
        }
      /// <summary>
        /// Consturctor of PayrollEarnings class.
        /// Update PayrollEarnings fields 
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <param name="empId"></param>
        public PayrollDeductions(int month, int year, int empId)
        {
            Employee_Payroll_EarningsBusinessObject objPEBO = new Employee_Payroll_EarningsBusinessObject();
            if (objPEBO.IsPayrollPosted(month, year, empId))
                _IsNew = false;
            if (!_IsNew)
            {
                Employee_Payroll_DeductionsBusinessObject objPDBO = new Employee_Payroll_DeductionsBusinessObject();
                
                objPDBO.GetEmployeePayroll(month, year, empId,this);
                objPDBO.GetEmployeePayrollDeductions(this.PayrollID, this);
            }
          
        }
    }

/// <summary>
/// Class for Deductions Other Than Standar One.
/// </summary>
  public class OtherDeductions
  {
      private int _ID;
      private int _DeductionID;
      private bool _IsPercentage;
      private double _Percentage;
      private double _Deduction;
      private string _DeductionName;
      private string _DeductionCode;
      private string _DeductionType;
      private bool _IsTaxExempted;
      private string _Narration;

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

      public bool IsPercentage
      {
          get
          {
              return _IsPercentage;
          }
          set
          {
              _IsPercentage = value;
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
      public Double Percentage
      {
          get
          {
              return _Percentage;
          }
          set
          {
              _Percentage = value;
          }
      }

      public Double Deduction
      {
          get
          {
              return Math.Round(_Deduction,2,MidpointRounding.AwayFromZero);
          }
          set
          {
              _Deduction = value;
          }
      }
      public String DeductionName
      {
          get
          {
              return _DeductionName;
          }
          set
          {
              _DeductionName = value;
          }
      }

      public String DeductionCode
      {
          get
          {
              return _DeductionCode;
          }
          set
          {
              _DeductionCode = value;
          }
      }
      public String DeductionType
      {
          get
          {
              return _DeductionType;
          }
          set
          {
              _DeductionType = value;
          }
      }
      public String Narration
      {
          get
          {
              return _Narration;
          }
          set
          {
              _Narration = value;
          }
      }
      public OtherDeductions()
      {

      }
      

  }
}
