using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using System.Data;

namespace HRManager.Entity
{
   public class IncomeTax
    {
        private int _ID;
        private int _EmployeeID;
        private String _Gender;
        private bool _IsSeniorCitizen;
        private double _HRA;
        private double _TotalBasic;
        private double _HRAExemption;
        private double _HRAPaid;
        private double _HRAPercent=40;
        private double _TotalGrossSalary;
        private double _MaxFoodCouponAmount=0;
        private double _MaxEducationAllowance = 0;
        private double _MaxOtherExemptions = 0;
        private double _MaxMedicalClaim = 0;
        private double _LeaveSalaryLimit;
        private double _LeaveSalary;
        private double _LeaveExemption;
        private int _FinYear;
        private int _StartMonth=0;
        private int _StartYear=0;
        private int _MonthsRemaining = 0;
        private DateTime _StartDate = DateTime.Today;
        private double _AnnualBenifit;
        private double _OtherSourceIncome;
        private double _TotalExemptions;
        private double _TotalTDS;
        private double _TaxExemptionLimit;
        private double _TaxableAmount;
        private double _AdditionalTaxAmount;
        private double _TaxPercentage;
        private double _TaxPayable;
        private EmployeePayroll[] _empPayroll=null;
        private bool _IsCalculated=false;
        private double _TDSAmount;
        private double _EducationCess;
        private DataTable _dtTDS = null; 
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
        public String Gender
        {
            get
            {
                return _Gender;
            }
            set
            {
                _Gender = value;
            }
        }
        public bool IsSeniorCitizen
        {
            get
            {
                return _IsSeniorCitizen;
            }
            set
            {
                _IsSeniorCitizen = value;
            }
        }

        public double TaxExemptionLimit
        {
            get
            {
                return _TaxExemptionLimit;
            }
            set
            {
                _TaxExemptionLimit = value;
            }
        }
         
        public double TaxableAmount
        {
            get
            {
                return _TaxableAmount;
            }
            set
            {
                _TaxableAmount = value;
            }
        }
        public DataTable TDSTable
        {
            get
            {
                return _dtTDS;
            }
        }

        public int MonthsRemaining
        {
            get
            {
                return _MonthsRemaining;
            }
            set
            {
                _MonthsRemaining = value;
            }
        }

        public double AdditionalTaxAmount
        {
            get
            {
                return _AdditionalTaxAmount;
            }
            set
            {
                _AdditionalTaxAmount = value;
            }
        }

        public double TaxPercentage
        {
            get
            {
                return _TaxPercentage;
            }
            set
            {
                _TaxPercentage = value;
            }
        }

        public double TaxPayable
        {
            get
            {
                return _TaxPayable;
            }
            set
            {
                _TaxPayable = value;
            }
        }

        public double LeaveSalaryLimit
        {
            get
            {
                return _LeaveSalaryLimit;
            }
            set
            {
                _LeaveSalaryLimit = value;
            }
        }
        public double MaxFoodCouponAmount
        {
            get
            {
                return _MaxFoodCouponAmount;
            }
            set
            {
                _MaxFoodCouponAmount = value;
            }
        }

        public double MaxEducationAllowance
        {
            get
            {
                return _MaxEducationAllowance;
            }
            set
            {
                _MaxEducationAllowance = value;
            }
        }

        public double MaxOtherExemptions
        {
            get
            {
                return _MaxOtherExemptions;
            }
            set
            {
                _MaxOtherExemptions = value;
            }
        }


        public double MaxMedicalClaim
        {
            get
            {
                return _MaxMedicalClaim;
            }
            set
            {
                _MaxMedicalClaim = value;
            }
        }

        public double EducationCess
        {
            get
            {
                return _EducationCess;
            }
            set
            {
                _EducationCess = value;
            }
        }

        public double TDSAmount
        {
            get
            {
                return _TDSAmount;
            }
            set
            {
                _TDSAmount = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                _StartDate = value;
            }
        }    

        public IncomeTax()
        {
            _ID = 0;
        }
       /// <summary>
       /// Saves Employee TDS
       /// </summary>
       /// <returns></returns>
       private string SaveTDS()
       {
           if (!_IsCalculated)
               return HRPayrollManagerDefs.TDS.ERROR_CALCULATING;
           Payroll_AnnualConfigurationBusinessObject empTDSBO = new Payroll_AnnualConfigurationBusinessObject();
           Payroll_AnnualConfiguration empTDS= null;
           _ID = new Employee_Payroll_DeductionsBusinessObject().GetTDSID(_EmployeeID, _FinYear);
           if (_ID == 0)
           {
               empTDS = new Payroll_AnnualConfiguration();
               empTDS.TDS = _TDSAmount;
               empTDS.ActivatedDate = DateTime.Now;
               empTDS.EmployeeID = _EmployeeID;
               empTDS.FinancialYear = _FinYear;
               empTDS.LeaveEncashDays = 0;
               empTDS.RentPaid = 0;
               empTDS.ID = empTDSBO.Create(empTDS);
           }
           else
           {
               Payroll_AnnualConfiguration tmpEmpTDS = empTDSBO.GetPayroll_AnnualConfiguration(_ID);
               empTDS = new Payroll_AnnualConfiguration();
               if (tmpEmpTDS == null)
               {
                   empTDS.TDS = _TDSAmount;
                   empTDS.ActivatedDate = DateTime.Now;
                   empTDS.EmployeeID = _EmployeeID;
                   empTDS.FinancialYear = _FinYear;
                   empTDS.LeaveEncashDays = 0;
                   empTDS.RentPaid = 0;
                   empTDS.ID = empTDSBO.Create(empTDS);
               }
               else
               {
                   empTDS.ID = tmpEmpTDS.ID;
                   empTDS.TDS = _TDSAmount;
                   empTDS.ActivatedDate = DateTime.Now;
                   empTDS.EmployeeID = _EmployeeID;
                   empTDS.FinancialYear = _FinYear;
                   empTDS.LeaveEncashDays = tmpEmpTDS.LeaveEncashDays;
                   empTDS.RentPaid = tmpEmpTDS.RentPaid;
                   empTDSBO.Update(empTDS);
               }
           }

           return string.Empty;
       }
       /// <summary>
       /// Validates and saves TDS
       /// </summary>
       /// <returns></returns>
        public String Save()
        {
            String Status = Validate();

            if (Status != String.Empty)
            {
                return Status;
            }

            return SaveTDS();
        }
        /// <summary>
        /// Validate employee for empty and financial year.
        /// </summary>
        /// <returns>empty string</returns>
        private String Validate()
        {
            if (_EmployeeID == 0)
                return HRPayrollManagerDefs.TDS.EMPTY_EMPLOYEE;
            if (_FinYear == 0)
                return HRPayrollManagerDefs.TDS.EMPTY_FINANCIALYEAR;
            return String.Empty;
        }
       /// <summary>
       /// Calculates HRA Exemptions
       /// </summary>
        private void CalculateHRAExemption()
        {
            _HRAPaid = new Employee_PayrollBusinessObject().GetTotalRentPaid(_EmployeeID, _FinYear);
            double tenperc = _HRAPaid - (_TotalBasic * .1);
            if (tenperc < 0) tenperc = 0;
            double mrent = _TotalBasic * _HRAPercent/100;
            _HRAExemption = Math.Min(Math.Min(_HRA, tenperc), mrent);
        }
       /// <summary>
       /// Calculates TDS
       /// </summary>
        public void CalculateIncomeTax()
        {
            DateTime sDate = new DateTime(_StartYear, _StartMonth, 1);
            DateTime eDate = sDate.AddMonths(11);
            int k = 0;
            _TotalGrossSalary = 0;
            double _TotalPF = 0;
            double _TotalOTHDED = 0;
            _TotalExemptions=0;
            double _ExemptionSec10 = 0;
            DateTime lastPosted = sDate;
            double _TotalMedClaim = 0;
            _HRA = 0;
            _TotalBasic = 0;
            EmployeePayroll eproll = null;
            int monthCnt=0;
            _dtTDS = CreateTDSTable();
            DataRow dr = null; 
            _empPayroll = new EmployeePayroll[12];
            do
            {
                if(_StartDate<=sDate)
                    eproll = new EmployeePayroll(sDate.Month, sDate.Year, _EmployeeID);
                if(eproll!=null)
                {
                    
                    if (eproll.IsPosted)
                    {
                        lastPosted = new DateTime(eproll.Year, eproll.Month, 1); 
                    }
                    _TotalGrossSalary = _TotalGrossSalary + Math.Round(eproll.Earnings.TotalEarnings, 0, MidpointRounding.AwayFromZero);
                    
                  _TotalBasic = _TotalBasic +Math.Round(eproll.Earnings.Basic,0,MidpointRounding.AwayFromZero);
                  dr = _dtTDS.NewRow();
                  dr["GroupName"] = "Group1";
                  dr["AllowanceDeducitonName"] = "Basic";
                  dr["Amount"] =Math.Round(eproll.Earnings.Basic,0,MidpointRounding.AwayFromZero);
                  dr["Order"] = 1;
                  _dtTDS.Rows.Add(dr);
                  dr = _dtTDS.NewRow();
                  dr["GroupName"] = "Group2";
                  dr["AllowanceDeducitonName"] = "Special Allowance";
                  dr["Amount"] = Math.Round(eproll.Earnings.SpecialAllowance, 0, MidpointRounding.AwayFromZero);
                  dr["Order"] = 6;
                  _dtTDS.Rows.Add(dr);
                if (eproll.Earnings.Allowances != null)
                {
                    foreach (Allowance al in eproll.Earnings.Allowances)
                    {
                        
                        if (al.IsTaxExempted)
                        {
                            if (al.Code == PayrollAppCommands.FCP)
                            {
                                dr = _dtTDS.NewRow();
                                dr["AllowanceDeducitonName"] = al.Name;
                                dr["Amount"] = Math.Round(al.Amount, 0, MidpointRounding.AwayFromZero); 
                                dr["GroupName"] = "Group3";
                                dr["Order"] = 11;
                                _dtTDS.Rows.Add(dr);
                                continue;
                            }
                            else if (al.Code == PayrollAppCommands.MCL)
                            {
                                _TotalMedClaim = _TotalMedClaim + Math.Round(al.Amount, 0, MidpointRounding.AwayFromZero);
                             
                                continue;
                            }
                            else if (al.Code == PayrollAppCommands.EDN)
                            {
                                if (al.Amount > _MaxEducationAllowance)
                                {
                                    _TotalExemptions = _TotalExemptions + _MaxEducationAllowance;
                                    _ExemptionSec10 = _ExemptionSec10 + _MaxEducationAllowance;
                                }
                                else
                                {
                                    _TotalExemptions = _TotalExemptions + Math.Round(al.Amount,0,MidpointRounding.AwayFromZero);
                                    _ExemptionSec10 = _ExemptionSec10+ Math.Round(al.Amount,0,MidpointRounding.AwayFromZero);
                                }
                                dr = _dtTDS.NewRow();
                                dr["AllowanceDeducitonName"] = al.Name;
                                dr["Amount"] = Math.Round(al.Amount,0,MidpointRounding.AwayFromZero); 
                                dr["GroupName"] = "Group2";
                                dr["Order"] = 12;
                                _dtTDS.Rows.Add(dr);
                                
                               /* dr = _dtTDS.NewRow();
                                dr["GroupName"] = "Group4";
                                dr["AllowanceDeducitonName"] = "Exemption u/s 10";
                                dr["Amount"] = al.Amount; 
                                dr["Order"] = 20;
                                _dtTDS.Rows.Add(dr); */
                                continue;
                            }
                            else if (al.Code == "CNV")
                            {
                                _TotalExemptions = _TotalExemptions + Math.Round(al.Amount,0,MidpointRounding.AwayFromZero);
                                _ExemptionSec10 = _ExemptionSec10 + Math.Round(al.Amount,0,MidpointRounding.AwayFromZero);
                                dr = _dtTDS.NewRow();
                                dr["AllowanceDeducitonName"] = al.Name;
                                dr["Amount"] = al.Amount;
                                dr["GroupName"] = "Group2";
                                dr["Order"] = 4;
                                _dtTDS.Rows.Add(dr);
                                /*dr = _dtTDS.NewRow();
                                dr["GroupName"] = "Group4";
                                dr["AllowanceDeducitonName"] = "Exemption u/s 10";
                                dr["Amount"] = al.Amount;
                                dr["Order"] = 20;
                                _dtTDS.Rows.Add(dr); */
                                continue;
                            }
                            else if (al.Name.ToLower().Contains("leave salary"))
                            {
                                _LeaveSalary = _LeaveSalary + Math.Round(al.Amount,0,MidpointRounding.AwayFromZero);
                                
                                continue;
                            }
                            else
                            {
                                dr = _dtTDS.NewRow();
                                dr["AllowanceDeducitonName"] = al.Name;
                                dr["Amount"] = Math.Round(al.Amount,0,MidpointRounding.AwayFromZero);
                                dr["GroupName"] = "Group3";
                                dr["Order"] = 15;
                                _dtTDS.Rows.Add(dr);
                            }
                            _TotalExemptions = _TotalExemptions + al.Amount;
                            continue;
                          
                        }
                        if (al.Code == PayrollAppCommands.HRA)
                        {
                            _HRA =_HRA + al.Amount;
                            dr = _dtTDS.NewRow();
                            dr["AllowanceDeducitonName"] = al.Name;
                            dr["Amount"] = Math.Round(al.Amount,0,MidpointRounding.AwayFromZero);
                            dr["GroupName"] = "Group2";
                            dr["Order"] = 3;
                            _dtTDS.Rows.Add(dr);
                            continue;
                        }
                        if (al.Name.ToLower() == "bonus")
                        {
                            dr = _dtTDS.NewRow();
                            dr["AllowanceDeducitonName"] = al.Name;
                            dr["Amount"] = Math.Round(al.Amount,0,MidpointRounding.AwayFromZero);
                             dr["GroupName"] = "Group1";
                             dr["Order"] = 2;
                            _dtTDS.Rows.Add(dr);
                            continue;
                        }
                       
                        else if (al.Name.ToLower() == "other allowance")
                        {
                            dr = _dtTDS.NewRow();
                            dr["AllowanceDeducitonName"] = al.Name;
                            dr["Amount"] = Math.Round(al.Amount,0,MidpointRounding.AwayFromZero);
                            dr["GroupName"] = "Group2";
                            dr["Order"] = 7;
                            _dtTDS.Rows.Add(dr);
                            continue;
                        }
                        else if (al.Name.ToLower().Contains("leave salary"))
                        {
                            dr = _dtTDS.NewRow();
                            dr["AllowanceDeducitonName"] = "Leave Salary";
                            dr["Amount"] = Math.Round(al.Amount,0,MidpointRounding.AwayFromZero);
                            dr["GroupName"] = "Group2";
                            dr["Order"] = 8;
                            _dtTDS.Rows.Add(dr);
                            continue;
                        }
                        else if (al.Name.ToLower() == "commission")
                        {
                            dr = _dtTDS.NewRow();
                            dr["AllowanceDeducitonName"] = al.Name;
                            dr["Amount"] = Math.Round(al.Amount,0,MidpointRounding.AwayFromZero);
                            dr["GroupName"] = "Group2";
                            dr["Order"] = 8;
                            _dtTDS.Rows.Add(dr);
                            continue;
                        }
                        else if (al.Name.ToLower() == "transfer of assets")
                        {
                            dr = _dtTDS.NewRow();
                            dr["AllowanceDeducitonName"] = al.Name;
                            dr["Amount"] = Math.Round(al.Amount,0,MidpointRounding.AwayFromZero);
                            dr["GroupName"] = "Group2";
                            dr["Order"] = 8;
                            _dtTDS.Rows.Add(dr);
                            continue;
                        }
                        else if (al.Name.ToLower() == "incentive")
                        {
                            dr = _dtTDS.NewRow();
                            dr["AllowanceDeducitonName"] = al.Name;
                            dr["Amount"] = Math.Round(al.Amount,0,MidpointRounding.AwayFromZero);
                            dr["GroupName"] = "Group2";
                            dr["Order"] = 9;
                            _dtTDS.Rows.Add(dr);
                            continue;
                        }
                        dr = _dtTDS.NewRow();
                        dr["AllowanceDeducitonName"] = al.Name;
                        dr["Amount"] = Math.Round(al.Amount,0,MidpointRounding.AwayFromZero);
                        dr["GroupName"] = "Group3";
                        dr["Order"] = 15;
                        _dtTDS.Rows.Add(dr);
                    }
                }
               
                if (eproll.Deductions!=null)
                {
                    if (eproll.Deductions.PF != null)
                    {
                        if (eproll.Deductions.PF.IsTaxExempted)
                        {
                            //_TotalExemptions = _TotalExemptions + eproll.Deductions.PF.Amount;
                            _TotalPF = _TotalPF + Math.Round(eproll.Deductions.PF.Amount, 0, MidpointRounding.AwayFromZero);
                            /*dr = _dtTDS.NewRow();
                            dr["GroupName"] = "Group6";
                            dr["AllowanceDeducitonName"] = "Less:Investments";
                            dr["Amount"] = eproll.Deductions.PF.Amount;
                            dr["Order"] = 26;
                            _dtTDS.Rows.Add(dr);*/
                        }
                    }
                   /* if (eproll.Deductions.ESI != null)
                    {
                        if (eproll.Deductions.ESI.IsTaxExempted)
                        {
                            _TotalExemptions = _TotalExemptions + eproll.Deductions.ESI.Amount;
                            dr = _dtTDS.NewRow();
                            dr["GroupName"] = "Group4";
                            dr["AllowanceDeducitonName"] = "ESI";
                            dr["Amount"] = eproll.Deductions.ESI.Amount;
                            _dtTDS.Rows.Add(dr);
                        }
                    }*/
                  
                    if (eproll.Deductions.TDSID>0)
                    {
                        _TotalTDS = _TotalTDS + Math.Round(eproll.Deductions.TDS, 0, MidpointRounding.AwayFromZero);
                       
                    }
                   
                if (eproll.Deductions.OtherDeductions != null)
                {
                    foreach (OtherDeductions od in eproll.Deductions.OtherDeductions)
                    {
                        if (od.IsTaxExempted)
                        {
                            if (od.DeductionName == "VPF")
                            {
                                _TotalOTHDED=_TotalOTHDED + Math.Round(od.Deduction,0,MidpointRounding.AwayFromZero);
                              /*  dr = _dtTDS.NewRow();
                                dr["GroupName"] = "Group6";
                                dr["AllowanceDeducitonName"] = "Less:Investments";
                                dr["Amount"] = od.Deduction;
                                dr["Order"] = 26;
                                _dtTDS.Rows.Add(dr);*/
                            }
                            else if (od.DeductionName == "FPF")
                            {
                                _TotalOTHDED = _TotalOTHDED + Math.Round(od.Deduction, 0, MidpointRounding.AwayFromZero);
                              /*  dr = _dtTDS.NewRow();
                                dr["GroupName"] = "Group6";
                                dr["AllowanceDeducitonName"] = "Less:Investments";
                                dr["Amount"] = od.Deduction;
                                dr["Order"] = 26;
                                _dtTDS.Rows.Add(dr);*/
                            }
                            else if (od.DeductionName == "LIC")
                            {
                                _TotalOTHDED = _TotalOTHDED + Math.Round(od.Deduction, 0, MidpointRounding.AwayFromZero);
                              /*  dr = _dtTDS.NewRow();
                                dr["GroupName"] = "Group3";
                                dr["AllowanceDeducitonName"] = "Less:Investments";
                                dr["Amount"] = od.Deduction;
                                dr["Order"] = 26;
                                _dtTDS.Rows.Add(dr);*/
                            }
                            if (od.DeductionCode == PayrollAppCommands.FCP || od.DeductionName.ToLower() == "food coupon")
                            {
                                if (od.Deduction > _MaxFoodCouponAmount)
                                    _TotalExemptions = _TotalExemptions + _MaxFoodCouponAmount;
                                else
                                    _TotalExemptions = _TotalExemptions + Math.Round(od.Deduction, 0, MidpointRounding.AwayFromZero);
                               
                                dr = _dtTDS.NewRow();
                                dr["GroupName"] = "Group4";
                                dr["AllowanceDeducitonName"] = "Exemption u/s 17(2)";
                                dr["Amount"] = Math.Round(od.Deduction, 0, MidpointRounding.AwayFromZero);
                                dr["Order"] = 22;
                                _dtTDS.Rows.Add(dr);
                                continue;
                            }
                            else
                            {
                                _TotalExemptions = _TotalExemptions + Math.Round(od.Deduction, 0, MidpointRounding.AwayFromZero);
                            }
                        }
                        
                    }
                }
                if (eproll.Deductions.TaxDeduction != null)
                {
                    foreach (PayrollTax tx in eproll.Deductions.TaxDeduction)
                    {
                        if (tx.TaxName == "PT" || tx.TaxName == "ProfessionalTax")
                        {
                            _TotalExemptions = _TotalExemptions + Math.Round(tx.Amount, 0, MidpointRounding.AwayFromZero);
                            dr = _dtTDS.NewRow();
                            dr["GroupName"] = "Group5";
                            dr["AllowanceDeducitonName"] = "Less: Tax on Employment";
                            dr["Amount"] = Math.Round(tx.Amount, 0, MidpointRounding.AwayFromZero);
                            dr["Order"] = 23;
                            _dtTDS.Rows.Add(dr);
                            
                        }

                    }
                }
                    }
                _empPayroll[k] = eproll;
                if (eproll.IsPosted)
                {
                    monthCnt = monthCnt + 1;
                }
            }
                sDate = sDate.AddMonths(1);
                k++;
            }
            while (sDate <= eDate);
            _TotalExemptions = _TotalExemptions + Math.Max(_TotalMedClaim - _MaxMedicalClaim, 0);
            CalculateHRAExemption();
            dr = _dtTDS.NewRow();
            dr["GroupName"] = "Group4";
            dr["AllowanceDeducitonName"] = "Less: HRA Exempt";
            dr["Amount"] = Math.Round(_HRAExemption, 0, MidpointRounding.AwayFromZero);
            dr["Order"] = 22;
            _dtTDS.Rows.Add(dr);
           
            dr = _dtTDS.NewRow();
            dr["AllowanceDeducitonName"] = "Medical Allowance";
            dr["Amount"] = Math.Round(_TotalMedClaim, 0, MidpointRounding.AwayFromZero);
            dr["GroupName"] = "Group3";
            dr["Order"] = 13;
            _dtTDS.Rows.Add(dr);

          dr = _dtTDS.NewRow();
          dr["GroupName"] = "Group4";
          dr["AllowanceDeducitonName"] = "Exemption u/s 10";
          dr["Amount"] = Math.Round(_ExemptionSec10, 0, MidpointRounding.AwayFromZero);
          dr["Order"] = 20;
          _dtTDS.Rows.Add(dr); 
              /*  AnualBenifits anb = AnualBenifits.GetAnualBenifits(_FinYear,_EmployeeID);
            if(anb.Allowances!=null)
            {
                foreach (Allowance al in anb.Allowances)
                {
                    if (al.Code == PayrollAppCommands.GRATUITY) continue;
                    if (al.Code == PayrollAppCommands.SUPERANNUATION) continue;
                    if (al.Code == PayrollAppCommands.LEAVE_ENCASHMENT)
                    {
                        _LeaveSalary = al.Amount;
                        continue;
                    }
                    if (al.Code == PayrollAppCommands.MCL)
                    {
                        _AnnualBenifit = _AnnualBenifit + Math.Min(al.Amount,_MaxMedicalClaim) ;
                        continue;
                    }
                    _AnnualBenifit = _AnnualBenifit + al.Amount ;
                }
            }*/

            _OtherSourceIncome = _OtherSourceIncome + new Employee_PayrollBusinessObject().GetIncomeFromOtherSources(_EmployeeID, _FinYear);
            double _Exemptions = new Employee_PayrollBusinessObject().GetTotalExemptions(_EmployeeID, _FinYear, "CHAPTER VI A");
            double _Exemptionsch6 = new Employee_PayrollBusinessObject().GetTotalExemptionsCH6A(_EmployeeID, _FinYear, "CHAPTER VI A");

            double TotalOExemptions = _TotalPF + _TotalOTHDED +_Exemptions;
            TotalOExemptions = Math.Min(TotalOExemptions, _MaxOtherExemptions);
            dr = _dtTDS.NewRow();
            dr["GroupName"] = "Group6";
            dr["AllowanceDeducitonName"] = "Income from other Sources";
            dr["Amount"] = Math.Round(-_OtherSourceIncome, 0, MidpointRounding.AwayFromZero);
            dr["Order"] = 24;
            _dtTDS.Rows.Add(dr);
            dr = _dtTDS.NewRow();
            dr["GroupName"] = "Group6";
            dr["AllowanceDeducitonName"] = "Less:Investments";
            dr["Amount"] = Math.Round(TotalOExemptions, 0, MidpointRounding.AwayFromZero);
            dr["Order"] = 26;
            _dtTDS.Rows.Add(dr);
            _TotalExemptions = _TotalExemptions + TotalOExemptions + _Exemptionsch6;
            if (_LeaveSalary <= _LeaveSalaryLimit)
                _LeaveExemption = Math.Round(_LeaveSalary, 0, MidpointRounding.AwayFromZero);
            else
                _LeaveExemption = _LeaveSalaryLimit;
            
             dr = _dtTDS.NewRow();
            dr["AllowanceDeducitonName"] = "Leave Salary";
            dr["Amount"] = _LeaveExemption;
            dr["GroupName"] = "Group4";
            dr["Order"] = 21;
            _dtTDS.Rows.Add(dr); 
             dr = _dtTDS.NewRow();
             dr["AllowanceDeducitonName"] = "Less: Dedn Chapter VI A";
             dr["Amount"] = _Exemptionsch6;
            dr["GroupName"] = "Group6";
            dr["Order"] = 25;
            _dtTDS.Rows.Add(dr); 
            double taxAmount = _TotalGrossSalary + _OtherSourceIncome - _TotalExemptions - _HRAExemption - _LeaveExemption; //+ _AnnualBenifit 
            new Employee_PayrollBusinessObject().GetTaxExemptedLimit(_FinYear, this);
            if (taxAmount <= _TaxExemptionLimit)
            {
                _TaxPayable = 0;
                return;
            }
            _TaxableAmount = taxAmount;// -_TaxExemptionLimit;

            new Employee_PayrollBusinessObject().GetTaxData(_FinYear,_Gender, this);
            _TaxableAmount = taxAmount -_TaxExemptionLimit;
            _TaxPayable = (_TaxableAmount * _TaxPercentage / 100) + _AdditionalTaxAmount;
            _TaxPayable = Math.Round(_TaxPayable, 0, MidpointRounding.AwayFromZero);
            dr = _dtTDS.NewRow();
            dr["AllowanceDeducitonName"] = "Income Tax";
            dr["Amount"] = _TaxPayable;
            dr["GroupName"] = "Group7";
            dr["Order"] = 27;
            _dtTDS.Rows.Add(dr);
            dr = _dtTDS.NewRow();
            dr["AllowanceDeducitonName"] = "ADD: Surcharge on Tax";
            dr["Amount"] = 0;
            dr["GroupName"] = "Group7";
            dr["Order"] = 28;
            _dtTDS.Rows.Add(dr);
            double edncess = _TaxPayable * _EducationCess / 100;
            edncess = Math.Round(edncess, 0, MidpointRounding.AwayFromZero);
            dr = _dtTDS.NewRow();
            dr["AllowanceDeducitonName"] = "ADD: Education Cess";
            dr["Amount"] = edncess;
            dr["GroupName"] = "Group7";
            dr["Order"] = 29;
            _dtTDS.Rows.Add(dr);

            _TaxPayable = _TaxPayable + edncess;
             dr = _dtTDS.NewRow();
            dr["AllowanceDeducitonName"] = "Total Tax Payable";
            dr["Amount"] = _TaxPayable;
            dr["GroupName"] = "Group70";
            dr["Order"] = 24;
            _dtTDS.Rows.Add(dr);

            _TaxPayable = _TaxPayable - _TotalTDS;
            dr = _dtTDS.NewRow();
            dr["AllowanceDeducitonName"] = "TAX DEDUCTED";
            dr["Amount"] = _TotalTDS;
            dr["GroupName"] = "Group71";
            dr["Order"] = 30;
            _dtTDS.Rows.Add(dr);
            dr = _dtTDS.NewRow();
            dr["AllowanceDeducitonName"] = "BALANCE TAX";
            dr["Amount"] = _TaxPayable;
            dr["GroupName"] = "Group72";
            dr["Order"] = 31;
            _dtTDS.Rows.Add(dr);
            int mnts = 0;
            DateTime ysDate = new DateTime(_StartYear, _StartMonth, 1);
            if (_StartDate > lastPosted)
                monthCnt = (eDate.Year * 12 + eDate.Month) - (_StartDate.Year * 12 + _StartDate.Month) - 1;  //mnts = new DateTime(_StartDate.Subtract(ysDate).Ticks).Month;
            else
                monthCnt = (eDate.Year * 12 + eDate.Month) - (lastPosted.Year * 12 + lastPosted.Month);
            _MonthsRemaining = (monthCnt == 0 ? 1 : monthCnt);
            _TDSAmount = Math.Round(_TaxPayable / (monthCnt==0?1:monthCnt), 2, MidpointRounding.AwayFromZero); //((monthCnt == 12) ? 1 : 12 - monthCnt - mnts)
            dr = _dtTDS.NewRow();
            dr["AllowanceDeducitonName"] = "Deduction Per Month";
            dr["Amount"] = _TDSAmount;
            dr["GroupName"] = "Group73";
            dr["Order"] = 32;
            _dtTDS.Rows.Add(dr);
            dr = _dtTDS.NewRow();
            dr["AllowanceDeducitonName"] = "Remaining Months in Year";
            dr["Amount"] = (monthCnt==0?1:monthCnt);
            dr["GroupName"] = "Group74";
            dr["Order"] = 33;
            _dtTDS.Rows.Add(dr);
            double dblG1=0;
            if(!(_dtTDS.Compute("Sum(Amount)", "GroupName='Group1'") is System.DBNull))
                dblG1=(double)_dtTDS.Compute("Sum(Amount)", "GroupName='Group1'");
            dr = _dtTDS.NewRow();
            dr["AllowanceDeducitonName"] = "Group1Total";
            dr["Amount"] = dblG1;
            dr["GroupName"] = "Group11";
            dr["Order"] = 3;
            _dtTDS.Rows.Add(dr);
            double dblG2 = 0;
            if (!(_dtTDS.Compute("Sum(Amount)", "GroupName='Group2'") is System.DBNull))
                dblG2 = (double)_dtTDS.Compute("Sum(Amount)", "GroupName='Group2'");
            dr = _dtTDS.NewRow();
            dr["AllowanceDeducitonName"] = "Group2Total";
            dr["Amount"] = dblG2;
            dr["GroupName"] = "Group21";
            dr["Order"] =10;
            _dtTDS.Rows.Add(dr);
            double dblG3 = 0;
            if (!(_dtTDS.Compute("Sum(Amount)", "GroupName='Group3'") is System.DBNull))
                dblG3 = (double)_dtTDS.Compute("Sum(Amount)", "GroupName='Group3'");
            dr = _dtTDS.NewRow();
            dr["AllowanceDeducitonName"] = "Group3Total";
            dr["Amount"] =dblG3 ;
            dr["GroupName"] = "Group31";
            dr["Order"] = 18;
            _dtTDS.Rows.Add(dr);
            double dblG4 = 0;
            if (!(_dtTDS.Compute("Sum(Amount)", "GroupName='Group4'") is System.DBNull))
                dblG4 = (double)_dtTDS.Compute("Sum(Amount)", "GroupName='Group4'");
            dr = _dtTDS.NewRow();
            dr["AllowanceDeducitonName"] = "Group4Total";
            dr["Amount"] =dblG4 ;
            dr["GroupName"] = "Group41";
            dr["Order"] = 23;
            
            _dtTDS.Rows.Add(dr);
            dr = _dtTDS.NewRow();
            dr["AllowanceDeducitonName"] = "Total";
            dr["Amount"] = dblG1 + dblG2+dblG3;
            dr["GroupName"] = "Group32";
            dr["Order"] = 24;
            _dtTDS.Rows.Add(dr);

            dr = _dtTDS.NewRow();
            dr["AllowanceDeducitonName"] = "Gross Salary";
            dr["Amount"] = dblG1 + dblG2 + dblG3 - dblG4;
            dr["GroupName"] = "Group41";
            dr["Order"] = 23;
            _dtTDS.Rows.Add(dr);
            double dblG5 = 0;
            if (!(_dtTDS.Compute("Sum(Amount)", "GroupName='Group5'") is System.DBNull))
                dblG5 = (double)_dtTDS.Compute("Sum(Amount)", "GroupName='Group5'");
            dr = _dtTDS.NewRow();
            dr["AllowanceDeducitonName"] = "TAXABLE SALARY";
            dr["Amount"] = dblG1 + dblG2 + dblG3 - dblG4 - dblG5;
            dr["GroupName"] = "Group51";
            dr["Order"] = 24;
            _dtTDS.Rows.Add(dr);
            double dblG6 = 0;
            if (!(_dtTDS.Compute("Sum(Amount)", "GroupName='Group6'") is System.DBNull))
                dblG6 = (double)_dtTDS.Compute("Sum(Amount)", "GroupName='Group6'");
            dr = _dtTDS.NewRow();
            dr["AllowanceDeducitonName"] = "TOTAL TAXABLE INCOME";
            dr["Amount"] = dblG1 + dblG2 + dblG3 - dblG4 - dblG5 - dblG6;
            dr["GroupName"] = "Group61";
            dr["Order"] = 24;
            _dtTDS.Rows.Add(dr);

            _dtTDS.DefaultView.Sort = "GroupName,Order ASC";
            _dtTDS = _dtTDS.DefaultView.ToTable();
            _IsCalculated=true;
           
        }

        private DataTable CreateTDSTable()
        {
            DataTable _dtTDS = new DataTable("TDS");
            _dtTDS.Columns.Add("GroupName",Type.GetType("System.String"));
            _dtTDS.Columns.Add("AllowanceDeducitonName", Type.GetType("System.String"));
            _dtTDS.Columns.Add("Amount", Type.GetType("System.Double"));
            _dtTDS.Columns.Add("Order", Type.GetType("System.Int32"));
            return _dtTDS;
        }
       /// <summary>
       /// Constructor
       /// </summary>
       /// <param name="employeeid"></param>
       /// <param name="finyear"></param>
       /// <param name="gender"></param>
       /// <param name="IsSrCitizen"></param>
       /// <param name="smonth"></param>
       /// <param name="syear"></param>
        public IncomeTax( int employeeid, int finyear)
        {
            
            _EmployeeID = employeeid;
            _FinYear = finyear;
            new Employee_PayrollBusinessObject().GetEmployeeDetails(_EmployeeID, _FinYear, this);
            _StartMonth = 4;
            _StartYear = finyear;
        }
 
    }
}
