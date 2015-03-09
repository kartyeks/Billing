using System;
using System.Collections.Generic;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IRCA.Communication;

namespace HRManager.Entity
{
    /// <summary>
    /// Represents Payroll Earinngs fields and methods.
    /// </summary>
    public class PayrollEarnings
    {
        private int _PayrollID;
        private int _Month;
        private int _Year;
        private int _EmployeeId;
        private int _EmploymentTypeId;
        private int _StateId;
        private double _PresentDays;
        private double _LOPDays;
        private double _Basic;
        private double _ActualBasic;
        private double _SpecialAllowance;
        private double _ActualSpecialAllowance;
        private double _OtherAllowance;
        private double _BasicArrears;
        private double _OtherArrears;
        private double _TotalEarnings;
        private double _TotalMonthlyEarnings;
        private double _ESISalary;
        private double _ESIGrossSalary;
        private double _GrossSalary;
        private Allowance[] _allows;
        private bool _IsPreviousMonthLOP;
        private Double _PreviousLOP;
        private Double _CurrentLOP;
        private Double _OtherLOP;
        private bool _IsNew = true;
        private bool _IsPosted = false;
        private EmployeeLOP[] _EmpLOPs; 
        private DateTime _DateOfJoining;
        private DateTime _LeavingDate;
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

        public int EmployeeId
        {
            get
            {
                return _EmployeeId;
            }
            set
            {
                _EmployeeId = value;
            }
        }
        public int EmploymentTypeId
        {
            get
            {
                return _EmploymentTypeId;
            }
            set
            {
                _EmploymentTypeId = value;
            }
        }
        public EmployeeLOP[] EmpLOPs 
        {
            get
            {
                return _EmpLOPs;
            }
            set
            {
                _EmpLOPs = value;
            }
        }
        public double PresentDays
        {
            get
            {
                return _PresentDays;
            }
            set
            {
                _PresentDays = value;
            }
        }
        public double LOPDays
        {
            get
            {
                return _LOPDays;
            }
            set
            {
                _LOPDays = value;
            }
        }

        public double PreviousLOP
        {
            get
            {
                return _PreviousLOP;
            }
            set
            {
                _PreviousLOP = value;
            }
        }

        public double CurrentLOP
        {
            get
            {
                return _CurrentLOP;
            }
            set
            {
                _CurrentLOP = value;
            }
        }
        public double OtherLOP
        {
            get
            {
                return _OtherLOP;
            }
            set
            {
                _OtherLOP = value;
            }
        }



        public double Basic
        {
            get
            {
                return Math.Round(_Basic,2,MidpointRounding.AwayFromZero);
            }
            set
            {
                _Basic = value;
            }
        }
        public double ActualBasic
        {
            get
            {
                return Math.Round(_ActualBasic, 2, MidpointRounding.AwayFromZero);
            }
            set
            {
                _ActualBasic = value;
            }
        }
        public double SpecialAllowance
        {
            get
            {
                return Math.Round(_SpecialAllowance,2,MidpointRounding.AwayFromZero);
            }
            set
            {
                _SpecialAllowance = value;
            }
        }
        public double ActualSpecialAllowance
        {
            get
            {
                return Math.Round(_ActualSpecialAllowance, 2, MidpointRounding.AwayFromZero);
            }
            set
            {
                _ActualSpecialAllowance = value;
            }
        }
        public double OtherAllowance
        {
            get
            {
                return Math.Round(_OtherAllowance,2,MidpointRounding.AwayFromZero);
            }
            set
            {
                _OtherAllowance = value;
            }
        }

        public double BasicArrears
        {
            get
            {
                return Math.Round(_BasicArrears,2,MidpointRounding.AwayFromZero);
            }
            set
            {
                _BasicArrears = value;
            }
        }

        public double OtherArrears
        {
            get
            {
                return Math.Round(_OtherArrears,2,MidpointRounding.AwayFromZero);
            }
            set
            {
                _OtherArrears = value;
            }
        }
        public Allowance[] Allowances
        {
            get
            {
                return _allows;
            }
            set
            {
                _allows = value;
            }
        }

        public double TotalEarnings
        {
            get
            {
                return Math.Round(_TotalEarnings,2,MidpointRounding.AwayFromZero);
            }
            set
            {
                _TotalEarnings = value;
            }
        }
        public double TotalMonthlyEarnings
        {
            get
            {
                return Math.Round(_TotalMonthlyEarnings, 2, MidpointRounding.AwayFromZero);
            }
            set
            {
                _TotalMonthlyEarnings = value;
            }
        }
        public double ESISalary
        {
            get
            {
                return Math.Round(_ESISalary, 2, MidpointRounding.AwayFromZero);
            }
            set
            {
                _ESISalary = value;
            }
        }
        public double GrossSalary
        {
            get
            {
                return Math.Round(_GrossSalary,2,MidpointRounding.AwayFromZero);
            }
            set
            {
                _GrossSalary = value;
            }
        }
        public double ESIGrossSalary
        {
            get
            {
                return Math.Round(_ESIGrossSalary, 2, MidpointRounding.AwayFromZero);
            }
            set
            {
                _ESIGrossSalary = value;
            }
        }

        public bool IsPreviousMonthLOP
        {
            get
            {
                return _IsPreviousMonthLOP;
            }
            set
            {
                _IsPreviousMonthLOP = value;
            }
        }
        public bool IsPosted
        {
            get
            {
                return _IsPosted;
            }
            set
            {
                _IsPosted = value;
            }
        }
        public DateTime DateOfJoining
        {
            get
            {
                return _DateOfJoining;
            }
            set
            {
                _DateOfJoining = value;
            }
        }

        public DateTime LeavingDate
        {
            get
            {
                return _LeavingDate;
            }
            set
            {
                _LeavingDate = value;
            }
        }

        /// <summary>
        /// Calculate Total Earnings
        /// </summary>
        private void CalculateTotalEarnings()
        {
            //string esiCodes = IS91.Services.Common.GetAppSetting("ESIExcludedCodes");
            //double totesigross = 0;
            if (!_IsNew)
            {
               // yogesh
                _TotalEarnings = 0;
                _TotalMonthlyEarnings = 0;
                _ESIGrossSalary = 0;
                _ESISalary = 0;
                //_GrossSalary = totl;
                
                //return;
            }
            return;
           
        }

        /// <summary>
        /// Get Gross Salary 
        /// </summary>
        /// <param name="mnt"></param>
        /// <param name="yr"></param>
        /// <param name="empId"></param>
        /// <returns></returns>
        private static PayrollEarnings GetGrossSalary(int mnt, int yr, int empId)
        {
            Employee_Payroll_EarningsBusinessObject objPayBO = new Employee_Payroll_EarningsBusinessObject();
            PayrollEarnings tmp = new PayrollEarnings();
            objPayBO.CalculateEmployeeEarnings(mnt, yr, empId, PayrollAppCommands.ALLOWANCE_MONTHLY, tmp);

            double tot = tmp.Basic + tmp.SpecialAllowance + tmp.OtherAllowance;
            foreach (Allowance al in tmp.Allowances)
            {
                tot = tot + al.Amount;
            }
            tmp.GrossSalary = tot;
            return tmp;
        }
        
        /// <summary>
        /// Consturctor of PayrollEarnings class.
        /// Update PayrollEarnings fields 
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <param name="empId"></param>
        public PayrollEarnings(int month, int year, int empId)
        {
            Employee_Payroll_EarningsBusinessObject objPEBO = new Employee_Payroll_EarningsBusinessObject();
            if (objPEBO.IsPayrollPosted(month, year, empId))_IsNew = false;
            
            //_StateId = stateId;
            if (!_IsNew)
            {
                objPEBO.GetEmployeePayroll(month, year, empId, this);
                objPEBO.GetEmployeePayrollEarnings(this.PayrollID, this);
                CalculateTotalEarnings();
            }
            else
            {
                _Month = month;
                _Year = year;
                _EmployeeId = empId;
                //_IsPreviousMonthLOP = IsPrevLOP;
                DateTime datPrev = new DateTime(year, month, 1).AddMonths(-1);
                objPEBO.CalculateEmployeeEarnings(month, year, empId, PayrollAppCommands.ALLOWANCE_MONTHLY, this);
                CalculateTotalEarnings();
            }
        }

        /// <summary>
        /// Consturctor of PayrollEarnings class.
        /// Set variables for new PayrollEarnings 
        /// </summary>
        public PayrollEarnings()
        {
            _IsNew = true;
        }



    }
    /// <summary>
    /// Allowance class for payroll
    /// </summary>
    public class Allowance : JGridDataObject
    {
        private int _ID;
        private int _AllowanceID;
        private String _Name;
        private String _Code;
        private bool _IsPercentage;
        private double _Percentage;
        private bool _IsTaxExempted;
        private double _Amount;
        private double _ActualAmount;
        private String _AllowanceType;
        private String _Mode;
        private bool _IsOneMonthBasic;
        private bool _IsOneTimeAllowance;
        private double _Basic;
        private String _Narration;
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
        public int AllowanceID
        {
            get
            {
                return _AllowanceID;
            }
            set
            {
                _AllowanceID = value;
            }
        }

        public String Name
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

        public String Code
        {
            get
            {
                return _Code;
            }
            set
            {
                _Code = value;
            }
        }



        public String AllowanceType
        {
            get
            {
                return _AllowanceType;
            }
            set
            {
                _AllowanceType = value;
            }
        }
        public String Mode
        {
            get
            {
                return _Mode;
            }
            set
            {
                _Mode = value;
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
        public double Percentage
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
        
        public double ActualAmount
        {
            get
            {
                return Math.Round(_ActualAmount,2,MidpointRounding.AwayFromZero);
            }
            set
            {
                _ActualAmount= value;
            }
        }
        
        public bool IsOneMonthBasic
        {
            get
            {
                return _IsOneMonthBasic;
            }
            set
            {
                _IsOneMonthBasic = value;
            }
        }
        public bool IsOneTimeAllowance
        {
            get
            {
                return _IsOneTimeAllowance;
            }
            set
            {
                _IsOneTimeAllowance = value;
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
        public Allowance()
        {


        }

        public Allowance(int ID)
        {

        }

        #region JGridDataObject Members
        /// <summary>
        /// Get Data for display
        /// </summary>
        /// <returns></returns>
        public object GetGridData()
        {
            AnualBenifitsDetails AnnuDetails = new AnualBenifitsDetails();
            AnnuDetails.ID = _ID;
            AnnuDetails.Name = _Name;
            AnnuDetails.Amount = _Amount;
            return AnnuDetails;
        }

        #endregion

    }
}
