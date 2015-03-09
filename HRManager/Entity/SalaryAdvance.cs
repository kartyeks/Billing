using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IRCA.Communication;


namespace HRManager.Entity
{
    /// <summary>
    /// Represents Grade fields and methods.
    /// </summary>
    public class SalaryAdvance : JGridDataObject
    {
          private int _ID;
          private int _AdvanceTypeID;
          private int _EmpID;
          private Double _AdvanceAmount;
          private Int16 _RepaymentMonths;
          private Double _MonthlyAmount;
          private String _Reason;
          private DateTime _AppliedDateTime;
          private int _AppliedTo;
          private String _HRRemarks;
          private String _Status;
          private bool _IsNew;
          private String _AdvanceType;

          private String _EmpName;
          private String _appliedToName;
          private int _UpdateBy;
          private int _CreatedBy;
          private DateTime _CreatedDate;
          private int _ModifiedBy;
          private DateTime _ModifiedDate;

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
        public int AdvanceTypeID
        {
            get
            {
                return _AdvanceTypeID;
            }
            set
            {
                _AdvanceTypeID = value;
            }
        }
        public String AdvanceType
        {
            get
            {
                return _AdvanceType;
            }
            set
            {
                _AdvanceType = value;
            }
        }
        public int EmpID
        {
            get
            {
                return _EmpID;
            }
            set
            {
                _EmpID = value;
            }
        }
        public Double AdvanceAmount
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
        public Int16 RepaymentMonths
        {
            get
            {
                return _RepaymentMonths;
            }
            set
            {
                _RepaymentMonths = value;
            }
        }
        public Double MonthlyAmount
        {
            get
            {
                return _MonthlyAmount;
            }
            set
            {
                _MonthlyAmount = value;
            }
        }
        public String Reason
        {
            get
            {
                return _Reason;
            }
            set
            {
                _Reason = value;
            }
        }
        public int AppliedTo
        {
            get
            {
                return _AppliedTo;
            }
            set
            {
                _AppliedTo = value;
            }
        }
        public String HRRemarks
        {
            get
            {
                return _HRRemarks;
            }
            set
            {
                _HRRemarks = value;
            }
        }
        public String Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }

        public String EmpName
        {
            get
            {
                return _EmpName;
            }
            set
            {
                _EmpName = value;
            }
        }
        public String appliedToName
        {
            get
            {
                return _appliedToName;
            }
            set
            {
                _appliedToName = value;
            }
        }        
        public DateTime AppliedDateTime
        {
            get
            {
                return _AppliedDateTime;
            }
            set
            {
                _AppliedDateTime = value;
            }
        }
        
        public int UpdatedBy
        {
            get { return _UpdateBy; }
            set { _UpdateBy = value; }
        }
        
       
        /// <summary>
        /// Update the Grade field using Hr_Grade.
        /// </summary>
        /// <param name="Grade">Object of Hr_Grade class</param>
        private void Update(Salary_Advance SalaryAdvance)
        {
            if (SalaryAdvance != null)
            {
                _ID = SalaryAdvance.ID;
                _AdvanceTypeID = SalaryAdvance.AdvanceID;
                _EmpID = SalaryAdvance.EmpID;
                _AdvanceAmount = SalaryAdvance.AdvanceAmount;
                _RepaymentMonths = SalaryAdvance.RepaymentMonths;
                _MonthlyAmount = SalaryAdvance.MonthlyAmount;
                _Reason = SalaryAdvance.Reason;
                _AppliedDateTime = SalaryAdvance.AppliedDateTime;
                _AppliedTo = SalaryAdvance.AppliedTo;
                _HRRemarks = SalaryAdvance.HRRemarks;
                _Status = SalaryAdvance.Status;
                _IsNew = false;
                _CreatedBy = SalaryAdvance.CreatedBy;
                _ModifiedBy = SalaryAdvance.ModifiedBy;
                _CreatedDate = SalaryAdvance.CreatedDate;
                _ModifiedDate = SalaryAdvance.ModifiedDate;
            }
            else
            {
                _IsNew = true;
            }
        }
        /// <summary>
        /// Consturctor of Grade class.
        /// Update Grade fields using Hr_Grade.
        /// </summary>
        /// <param name="Grade">Object of Hr_Grade class</param>
        public SalaryAdvance(Salary_Advance SalaryAdvance)
        {
            Update(SalaryAdvance);
        }
        
        /// <summary>
        /// Consturctor of Grade class.
        /// Update Grade fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains Designation ID</param>
        public SalaryAdvance(int ID)
        {
            Salary_Advance SalaryAdvance = new Salary_AdvanceBusinessObject().GetSalary_Advance(ID);

            if (SalaryAdvance == null && ID > 0)
            {
                throw new IRCAException("Invalid Salary Advance", ID.ToString());
            }

            Update(SalaryAdvance);
        }
        /// <summary>
        /// Consturctor of Grade class.
        /// Set variables for new Grade.  
        /// </summary>
        public SalaryAdvance()
        {
            _ID = 0;
            _IsNew = true;
        }
        
        /// <summary>
        /// Save Grade.If new Grade it add and in case of edit it update the Grade.
        /// </summary>
        /// <returns>empty string</returns>
        private String SaveSalaryAdvance()
        {

            Salary_Advance SalaryAdvance = new Salary_Advance();
            SalaryAdvance.ID = _ID;
            SalaryAdvance.AdvanceID = _AdvanceTypeID;
            SalaryAdvance.EmpID = _EmpID;
            SalaryAdvance.AdvanceAmount = _AdvanceAmount;
            SalaryAdvance.RepaymentMonths = _RepaymentMonths;
            SalaryAdvance.MonthlyAmount = _MonthlyAmount;
            SalaryAdvance.Reason = _Reason;
            SalaryAdvance.AppliedDateTime = _AppliedDateTime;

           // AssignEmpReportingTo Empdetails = new Master_EmployeesBusinessObject().GetEmployeeReportingToPerson(_EmpID);
            int ReprotingMgrID = new Master_EmployeesBusinessObject().GetAdminReportingToIDEmployeeForResignation(EmpID);
            //if (Empdetails.ReprotingMgrID == 0 || Empdetails == null)
            //    _AppliedTo = 1;
            //else
            //    _AppliedTo = Empdetails.ReprotingMgrID;

            if (ReprotingMgrID == 0)
                _AppliedTo = 1;
            else
                _AppliedTo = ReprotingMgrID;

            SalaryAdvance.AppliedTo = _AppliedTo;
            SalaryAdvance.HRRemarks = _HRRemarks;
            SalaryAdvance.Status = _Status;
            SalaryAdvance.ModifiedBy = _ModifiedBy;
            SalaryAdvance.ModifiedDate = DateTime.Now;
            SalaryAdvance.CreatedBy = _CreatedBy;
            SalaryAdvance.CreatedDate = _CreatedDate;

            if (_IsNew)
            {
                SalaryAdvance.CreatedBy = _UpdateBy;
                SalaryAdvance.CreatedDate = DateTime.Now;
                SalaryAdvance.ID = new Salary_AdvanceBusinessObject().Create(SalaryAdvance);
            }
            else
            {
                SalaryAdvance.ModifiedBy = _UpdateBy;
                SalaryAdvance.ModifiedDate = DateTime.Now;
                SalaryAdvance.ID = _ID;
                new Salary_AdvanceBusinessObject().Update(SalaryAdvance);
            }

            return String.Empty;
        }
       
        
        /// <summary>
        ///Validate Grade for empty and already exist status and then save Grade.
        /// </summary>
        /// <returns>String return from the SaveGrade method</returns> 
        public String Save()
        {
            String Status = Validate();

            if (Status != String.Empty)
            {
                return Status;
            }

            return SaveSalaryAdvance();
        }
        /// <summary>
        ///Update User Action without validation
        /// </summary>
        /// <returns>String return from the SaveGrade method</returns> 
        public String SaveAction()
        {          
            return SaveSalaryAdvance();
        }
        /// <summary>
        /// Validate GradeName for empty and already exist status.
        /// </summary>
        /// <returns>empty string</returns>
        private String Validate()
        {
            Salary_AdvanceBusinessObject Salary_AdvanceBO = new Salary_AdvanceBusinessObject();

            if (Salary_AdvanceBO.IsSalaryAdvanceExists(_AdvanceTypeID, _EmpID, _ID))
            {
                return HRLoanManagerDefs.SalaryAdvance.SALARYADVANCE_EXISTS;
            }
            return String.Empty;
        }

        public static SalaryAdvance[] GetAllSalaryAdvance()
        {
            //Salary_Advance[] SalaryAdvancesDT = new Salary_AdvanceBusinessObject().GetSalary_Advance();

            //return LoanRequestsDT;
            SalaryAdvance[] SalaryAdvancesDT = new Salary_AdvanceBusinessObject().GetAllSalaryAdvance();

            //SalaryAdvance[] SalaryAdvances = new SalaryAdvance[SalaryAdvancesDT.Length];

            //for (int i = 0; i < SalaryAdvances.Length; i++)
            //{
            //    SalaryAdvances[i] = new SalaryAdvance(SalaryAdvancesDT[i]);
            //}

            return SalaryAdvancesDT;
        }
        public static SalaryAdvance[] GetAppliedToSalaryAdvance(int AppliedToID)
        {
            SalaryAdvance[] SalaryAdvancesDT = new Salary_AdvanceBusinessObject().GetAppliedToSalaryAdvance(AppliedToID);

            //SalaryAdvance[] SalaryAdvances = new SalaryAdvance[SalaryAdvancesDT.Length];

            //for (int i = 0; i < SalaryAdvances.Length; i++)
            //{
            //    SalaryAdvances[i] = new SalaryAdvance(SalaryAdvancesDT[i]);
            //}

            return SalaryAdvancesDT;
        }

        #region JGridDataObject Members

        public object GetGridData()
        {
            SalaryAdvanceInfo SalaryAdvance = new SalaryAdvanceInfo();

            SalaryAdvance.ID = _ID;
            SalaryAdvance.EmpID = _EmpID;
            SalaryAdvance.AdvanceTypeID = _AdvanceTypeID;
            SalaryAdvance.Emp = _EmpName;
            SalaryAdvance.AdvanceType = _AdvanceType;
            SalaryAdvance.AdvanceAmount = _AdvanceAmount;
            SalaryAdvance.RepaymentMonths = _RepaymentMonths;
            SalaryAdvance.MonthlyAmount = _MonthlyAmount;
            SalaryAdvance.Reason = _Reason;
            SalaryAdvance.AppliedDate = _AppliedDateTime;
            SalaryAdvance.Applied = _AppliedTo;
            SalaryAdvance.HRRemarks = _HRRemarks;
            SalaryAdvance.Status = _Status;
            SalaryAdvance.AppliedTo = _appliedToName;


            return SalaryAdvance;
        }

        #endregion
    }
    public class SalaryAdvanceInfo   //LoanRequestDisplayDetails
    {
        public int ID;
        public int EmpID;
        public int AdvanceTypeID;  
        public String Emp;
        public String AdvanceType;
        public Double AdvanceAmount;
        public Int16 RepaymentMonths;
        public Double MonthlyAmount;
        public String Reason;
        public DateTime AppliedDate;
        public int Applied;
        public String HRRemarks;
        public String Status;
        public String AppliedTo;
    }
}
