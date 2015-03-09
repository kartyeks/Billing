using System;
using System.Collections.Generic;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IS91.Services.DataBlock;
using IRCA.Communication;

namespace HRManager.Entity
{
    /// <summary>
    /// Represents Payroll Earinngs fields and methods.
    /// </summary>
    public class EmployeePayroll : JGridDataObject
    { 
        private int _ID;
        private int _Month;
        private int _Year;
        private int _EmployeeId;
        private int _DepartmentId;
        private int _BranchId;
        private int _LocationId;
        private int _StateId;
        private string _EmployeeCode;
        private string _EmployeeName;
        private double _PresentDays;
        private string _Department;
        private string _Branch;
        private string _Location;
        private PayrollEarnings _Earnings;
        private PayrollDeductions _Deductions;
        private AnualBenifits _ABenifits;
        private double _NetSalary;
        private bool _IsPreviousMonthLOP;
        private int _UpdatedBy;
        private bool _IsABenifitIncluded=false;
        private bool _IsPosted=false;
        private bool _IsNew=true;
        private DateTime _LeavingDate;
        private Double _TotalEarnings;
        private Double _TotalDeductions;
        private Double _Basic;
        private int _EmployeeSalaryID;
        private String _Team;
        private bool _IsABenifitIncludedAll;

        public bool IsABenifitIncludedAll
        {
            get
            {
                return _IsABenifitIncludedAll;
            }
            set
            {
                _IsABenifitIncludedAll = value;
            }
        }
        public int EmployeeSalaryID
        {
            get
            {
                return _EmployeeSalaryID;
            }
            set
            {
                _EmployeeSalaryID = value;
            }
        }
        public Double Basic
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
        public Double TotalEarnings
        {
            get
            {
                return _TotalEarnings;
            }
            set
            {
                _TotalEarnings = value;
            }
        }
        public Double TotalDeductions
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
        public Double PresentDays
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

       

        public int DepartmentId
        {
            get
            {
                return _DepartmentId;
            }
            set
            {
                _DepartmentId= value;
            }
        }

        public int BranchId
        {
            get
            {
                return _BranchId;
            }
            set
            {
                _BranchId= value;
            }
        }

        public int LocationId
        {
            get
            {
                return _LocationId;
            }
            set
            {
               _LocationId  = value;
            }
        }
        public int StateID
        {
            get
            {
                return _StateId;
            }
            set
            {
                _StateId = value;
            }
        }
        public string EmployeeCode
        {
            get
            {
                 return _EmployeeCode;
            }
            set
            {
                _EmployeeCode = value;
            }
        }
        public string EmployeeName
        {
            get
            {
                return _EmployeeName;
            }
            set
            {
                _EmployeeName = value;
            }
        }
        public string Department
        {
            get
            {
                return _Department;
            }
            set
            {
                _Department = value;
            }
        }
        public string Branch
        {
            get
            {
                return _Branch;
            }
            set
            {
                _Branch = value;
            }
        }
        public string Location
        {
            get
            {
                return _Location;
            }
            set
            {
                _Location = value;
            }
        }
        public string Team
        {
            get
            {
                return _Team;
            }
            set
            {
                _Team = value;
            }
        }
        

        public PayrollEarnings Earnings
        {
            get
            {
                return _Earnings;
            }
            set
            {
                _Earnings = value;
            }
        }

        public PayrollDeductions Deductions
        {
            get
            {
                return _Deductions;
            }
            set
            {
                _Deductions = value;
            }
        }
        public AnualBenifits ABenifits
        {
            get
            {
                return _ABenifits;
            }
            set
            {
                _ABenifits = value;
            }
        }

        public double NetSalary
        {
            get
            {
                return Math.Round(_NetSalary,2,MidpointRounding.AwayFromZero);
            }
            set
            {
                _NetSalary = value;
            }
        }

        public bool IsAnnualBenifitIncluded
        {
            get
            {
                return _IsABenifitIncluded;
            }
            set
            {
                _IsABenifitIncluded = value;
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
                _IsPosted= value;
            }
        }

        public int UpdatedBy
        {
            get
            {
                return _UpdatedBy;
            }
            set
            {
                _UpdatedBy = value;
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
       
        /// <summary>
        /// Save Payroll for each employee
        /// </summary>
        /// <param name="DBSession"></param>
        /// <returns></returns>
        private string SaveParoll(Session DBSession)
        {
            try
            {
                if (_NetSalary <= 0) return string.Empty; 

                if (DBSession == null)
                {
                    DBSession = Session.CreateNewSession();
                    DBSession.BeginTransaction();
                }
                Employee_PayrollBusinessObject empPayBo = new Employee_PayrollBusinessObject(DBSession);
                Employee_Payroll empPay = null;
                if (_IsNew)
                {
                    _ID = 0;
                    empPay = new Employee_Payroll();
                    empPay.CreatedBy = _UpdatedBy;
                    empPay.CreatedDate = DateTime.Now;
                }
                else
                {
                    empPay = new Employee_PayrollBusinessObject(true).GetEmployee_Payroll(_ID);
                    if (empPay == null)
                    {
                        _ID = 0;
                        empPay = new Employee_Payroll();
                        empPay.CreatedBy = _UpdatedBy;
                        empPay.CreatedDate = DateTime.Now;
                    }
                    else
                    {
                        empPay.ModifiedBy = _UpdatedBy;
                        empPay.ModifiedDate = DateTime.Now;
                    }

                }
                empPay.EmployeeID = _EmployeeId;
                empPay.Month = _Month;
                empPay.Year = _Year;
                empPay.PresentDays = _PresentDays;
                empPay.Basic = _Basic;
                empPay.NetSalary = _NetSalary;
                empPay.GrossSalary = _TotalDeductions+_TotalEarnings;
                empPay.IsAnualbenifitsincluded = _IsABenifitIncluded;

                if (_ID == 0)
                {
                    _ID = empPayBo.Create(empPay);
                }
                else
                {
                    empPayBo.Update(empPay);
                }
                empPayBo.UpdatePayrollEarningAndDeductios(_EmployeeSalaryID, _ID,_IsABenifitIncluded, DBSession);
                
                DBSession.Commit();
                _IsNew = false;
            }
            catch (Exception e)
            {
                DBSession.Rollback();
                if (_IsNew)
                    _ID = 0;
                throw e;
            }
            finally
            {
                DBSession.Dispose();
            }

            return string.Empty;
        }

        private string Validate()
        {
            if (_EmployeeId == 0)
            {
                return "Invalid Employee";
            }
            if (_Basic == 0)
            {
                return "Enter Basic For Employee";
            }

            return string.Empty;
        }
        /// <summary>
        /// Calls savepayroll methos 
        /// </summary>
        /// <param name="DBSession"></param>
        /// <returns></returns>
        public String Save(Session DBSession)
        {
            String Status = Validate();

            if (Status != String.Empty)
            {
                return Status;
            }

            return SaveParoll(DBSession);
        }

        //public String SaveTemp()
        //{

        //    return SaveTempParoll(null);
        //}

        /// <summary>
        /// Consturctor of EmployeePayroll class.
        /// Update EmployeePayroll fields 
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <param name="empId"></param>
        public EmployeePayroll(int month,int year,int empId)
        {
            Employee_Payroll_EarningsBusinessObject objPEBO=new Employee_Payroll_EarningsBusinessObject();
            if (objPEBO.IsPayrollPosted(month, year, empId))
            {
                _IsNew = false;
                _IsPosted = true;
            }
            _Month = month;
            _Year = year;
            _EmployeeId = empId;
        }
        
        
        /// <summary>
        /// Consturctor of PayrollEarnings class.
        /// Set variables for new PayrollEarnings 
        /// </summary>
        public EmployeePayroll()
        {
            _ID = 0;
            _IsNew = true;
        }
        public static String CheckPayrollGenerated(int EmpID, int Month, int Year)
        {
            Employee_PayrollBusinessObject PayrollBO = new Employee_PayrollBusinessObject();
            if (!PayrollBO.CheckPayrollForGivenDate(Month.ToString(), Year.ToString(), EmpID))
            {
                return "Not Generated";
            }
            return String.Empty;
        }

         
        #region JGridDataObject Members
        /// <summary>
        /// Get Data to show in grid
        /// </summary>
        /// <returns></returns>
        public object GetGridData()
        {
            EmployeePayrollDetails empDetails = new EmployeePayrollDetails();
            empDetails.EmployeeID = _EmployeeId;
            empDetails.ID = _ID;
            empDetails.EmployeeName = _EmployeeName;
            empDetails.EmployeeCode = _EmployeeCode;
            empDetails.Team = _Team;
            empDetails.PresentDays = _PresentDays;
            empDetails.GrossSalary = Math.Round(_TotalEarnings,2,MidpointRounding.AwayFromZero);
            empDetails.Deductions = Math.Round(_TotalDeductions, 2, MidpointRounding.AwayFromZero);
            empDetails.NetSalary = Math.Round(_NetSalary, 2, MidpointRounding.AwayFromZero);
            empDetails.isPosted = _IsPosted;
            empDetails.isAnnual = _IsABenifitIncludedAll;
            empDetails.isAnnualSingle = _IsABenifitIncluded;

            return empDetails;
        }

        #endregion
       
    }
    /// <summary>
    /// class for display data in grid
    /// </summary>
    public class EmployeePayrollDetails
    {        
        public int ID;
        public int EmployeeID;
        public String EmployeeName;
        public String EmployeeCode;
        public String Team;
        public double PresentDays;
        public double GrossSalary;
        public double Deductions;
        public double NetSalary;
        public bool isPosted;
        public bool isAnnual;
        public bool isAnnualSingle;
    }

 }
