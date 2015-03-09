using System;
using System.Collections.Generic;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;

namespace HRManager.Entity
{
    public class AnualBenifits  
    {
        private int _ID;
        private int _PayrollID;
        private int _Month;
        private int _Year;
        private int _EmployeeId;
        private int _AllowanceID;
        private double _Amount;
        private Allowance[] _allows;
        private bool _IsPosted = false;
        private bool _IsNew = true;
        private double _TotalAmount;
        private bool _IsPercentage;
        private string _Name;

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
                return _Amount;
            }
            set
            {
                _Amount = value;
            }
        }
        public double TotalAmount
        {
            get
            {
                return _TotalAmount;
            }
            set
            {
                _TotalAmount = value;
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
        public string Name
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
        /// <summary>
        /// Consturctor of AnualBenifits class.
        /// Set variables for new AnualBenifits 
        /// </summary>
        public AnualBenifits()
        {
            _IsNew = true;
        }

       

          /// <summary>
        /// Consturctor of EmployeePayroll class.
        /// Update EmployeePayroll fields 
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <param name="empId"></param>
        public static AnualBenifits GetAnualBenifits(int month, int year, int empId)
        {
            AnualBenifits AnnualsDT = null;

            Employee_Payroll_EarningsBusinessObject objPEBO = new Employee_Payroll_EarningsBusinessObject();
            int financialyear = new Employee_PayrollBusinessObject().GetFinancialYear(month, year);

            //if (new Employee_PayrollBusinessObject().IsAnnualPayrollPosted(financialyear, empId))
            if(objPEBO.IsPayrollPosted(month, year, empId))
            {
                AnnualsDT = new Employee_Payroll_EarningsBusinessObject().GetAnualBenifits(financialyear, empId);
            }
            else
            {
              PayrollEarnings  _Earnings = new PayrollEarnings(month, year, empId);
               AnnualsDT = new Employee_Payroll_EarningsBusinessObject().GetAnualBenifits(_Earnings,financialyear,new DateTime(year,month,1),empId);
            }
            return AnnualsDT;
        }
        public static AnualBenifits GetAnualBenifits(PayrollEarnings _Earnings)
        {
            AnualBenifits AnnualsDT = null;

            Employee_Payroll_EarningsBusinessObject objPEBO = new Employee_Payroll_EarningsBusinessObject();
            int financialyear = new Employee_PayrollBusinessObject().GetFinancialYear(_Earnings.Month, _Earnings.Year);

            if (new Employee_PayrollBusinessObject().IsAnnualPayrollPosted(financialyear, _Earnings.EmployeeId))
            {
                AnnualsDT = new Employee_Payroll_EarningsBusinessObject().GetAnualBenifits(financialyear, _Earnings.EmployeeId);
            }
            else
            {
                //PayrollEarnings _Earnings = new PayrollEarnings(month, year, empId, false);
                AnnualsDT = new Employee_Payroll_EarningsBusinessObject().GetAnualBenifits(_Earnings, financialyear, new DateTime(_Earnings.Year, _Earnings.Month, 1), _Earnings.EmployeeId);
            }
            return AnnualsDT;
        }

        private  void CalculateTotalBenifits()
        {
            double tot=0;
            foreach (Allowance al in _allows)
            {
                tot = tot + al.Amount;
            }
            _TotalAmount = tot;
             
        }

        public static AnualBenifits GetAnualBenifits(int Fyear, int empId)
        {
            AnualBenifits AnnualsDT = null;

            Employee_Payroll_EarningsBusinessObject objPEBO = new Employee_Payroll_EarningsBusinessObject();

            if (new Employee_PayrollBusinessObject().IsAnnualPayrollPosted(Fyear, empId))
            {
                AnnualsDT = new Employee_Payroll_EarningsBusinessObject().GetAnualBenifits(Fyear, empId);
            }
            else
            {
                DateTime dtDate = new Employee_PayrollBusinessObject().GetCurrentDateForFinancialYear(Fyear);
                PayrollEarnings _Earnings = new PayrollEarnings(dtDate.Month, dtDate.Year, empId);
                AnnualsDT = new Employee_Payroll_EarningsBusinessObject().GetAnualBenifits(_Earnings, Fyear, new DateTime(dtDate.Year, dtDate.Month,1), empId);
            }
            return AnnualsDT;
        }
        /// <summary>
        /// Return all Assets
        /// </summary>
        /// <returns>Array of the object of Asset class</returns>
        //public static AnualBenifits[] GetAnualBenifits(int EmployeeID)
        //{
        //    AnualBenifits[] AnnualsDT = new Employee_Payroll_EarningsBusinessObject().GetAnualBenifits(EmployeeID);
        //    return AnnualsDT;
        //}
        #region JGridDataObject Members

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

    public class AnualBenifitsDetails
    {
        public int ID;
        public String Name;
        public Double Amount;

    }
}
