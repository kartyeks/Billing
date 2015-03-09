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
    /// Represents Loan Repayment fields and methods.
    /// </summary>
    public class SalaryAdvanceRepayment : JGridDataObject
    {
          private int _ID;
          private int _EmpID;
          private int _AdvanceID;
          private Double _AdvanceAmount;
          private DateTime _RepaymentDate;
          private bool _IsNew;
          private Employees1 _Employee = null;
          private Loan _Loan = null;
          private int _UpdateBy;
          private int _CreatedBy;
          private DateTime _CreatedDate;
          private int _ModifiedBy;
          private DateTime _ModifiedDate;
          private Double _RepaidAmount;
          private Double _DueAmount;
          private DateTime _AdvanceTakenOn;

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
        public int AdvanceID
        {
            get
            {
                return _AdvanceID;
            }
            set
            {
                _AdvanceID = value;
            }
        }
        public DateTime AdvanceTakenOn
        {
            get
            {
                return _AdvanceTakenOn;
            }
            set
            {
                _AdvanceTakenOn = value;
            }
        }
        public Double DueAmount
        {
            get
            {
                return _DueAmount;
            }
            set
            {
                _DueAmount = value;
            }
        }
        public Double RepaidAmount
        {
            get
            {
                return _RepaidAmount;
            }
            set
            {
                _RepaidAmount = value;
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

       
        public DateTime RepaymentDate
        {
            get
            {
                return _RepaymentDate;
            }
            set
            {
                _RepaymentDate = value;
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
        private void Update(Salary_AdvanceRepayments SalaryAdvanceRepayment)
        {
            if (SalaryAdvanceRepayment != null)
            {
                _ID = SalaryAdvanceRepayment.ID;
                _EmpID = SalaryAdvanceRepayment.EmpID;
                _AdvanceAmount= SalaryAdvanceRepayment.Amount;
                _RepaymentDate= SalaryAdvanceRepayment.RepaymentDate;
                _IsNew = false;
                _CreatedBy = SalaryAdvanceRepayment.CreatedBy;
                _ModifiedBy = SalaryAdvanceRepayment.ModifiedBy;
                _CreatedDate = SalaryAdvanceRepayment.CreatedDate;
                _ModifiedDate = SalaryAdvanceRepayment.ModifiedDate;
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
        public SalaryAdvanceRepayment(Salary_AdvanceRepayments SalaryAdvanceRepayment)
        {
            Update(SalaryAdvanceRepayment);
        }
        
        /// <summary>
        /// Consturctor of Grade class.
        /// Update Grade fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains Designation ID</param>
        public SalaryAdvanceRepayment(int ID)
        {
            Salary_AdvanceRepayments SalaryAdvanceRepayment = new Salary_AdvanceRepaymentsBusinessObject().GetSalary_AdvanceRepayments(ID);

            if (SalaryAdvanceRepayment == null && ID > 0)
            {
                throw new IRCAException("Invalid Salary Advance Repayment", ID.ToString());
            }

            Update(SalaryAdvanceRepayment);
        }
        /// <summary>
        /// Consturctor of Grade class.
        /// Set variables for new Grade.  
        /// </summary>
        public SalaryAdvanceRepayment()
        {
            _ID = 0;
            _IsNew = true;
        }
        /// <summary>
        /// Save Grade.If new Grade it add and in case of edit it update the Grade.
        /// </summary>
        /// <returns>empty string</returns>
        private String SaveSalaryAdvanceRepayment()
        {

            Salary_AdvanceRepayments SalaryAdvanceRepayment = new Salary_AdvanceRepayments();
            SalaryAdvanceRepayment.ID = _ID;
            SalaryAdvanceRepayment.EmpID = _EmpID;
            SalaryAdvanceRepayment.AdvanceID = _AdvanceID;
            SalaryAdvanceRepayment.Amount = _AdvanceAmount;
            SalaryAdvanceRepayment.RepaymentDate = _RepaymentDate;
            SalaryAdvanceRepayment.CreatedBy = _CreatedBy;
            SalaryAdvanceRepayment.CreatedDate = _CreatedDate;
            SalaryAdvanceRepayment.ModifiedBy = _ModifiedBy;
            SalaryAdvanceRepayment.ModifiedDate = DateTime.Now;

            if (_IsNew)
            {
                SalaryAdvanceRepayment.CreatedBy = _UpdateBy;
                SalaryAdvanceRepayment.CreatedDate = DateTime.Now;
                SalaryAdvanceRepayment.ID = new Salary_AdvanceRepaymentsBusinessObject().Create(SalaryAdvanceRepayment);
            }
            else
            {
                SalaryAdvanceRepayment.ModifiedBy = _UpdateBy;
                SalaryAdvanceRepayment.ModifiedDate = DateTime.Now;
                SalaryAdvanceRepayment.ID = _ID;
                new Salary_AdvanceRepaymentsBusinessObject().Update(SalaryAdvanceRepayment);
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

            return SaveSalaryAdvanceRepayment();
        }
        /// <summary>
        /// Validate GradeName for empty and already exist status.
        /// </summary>
        /// <returns>empty string</returns>
        private String Validate()
        {
            //Assign_Emp_LoanBusinessObject AssignEmpLoanBO = new Assign_Emp_LoanBusinessObject();

            //if (GradeBO.IsGradeExists(_GradeName, _ID))
            //{
            //    return HRManagerDefs.GradeMessages.GRADE_EXISTS;
            //}
            return String.Empty;
        }

        public static SalaryAdvanceRepayment[] GetPendingSalaryAdvanceEmpWise(int EmpID)
        {
            SalaryAdvanceRepayment[] SalaryAdvanceRepaymentDT = new Salary_AdvanceRepaymentsBusinessObject().GetPendingSalaryAdvanceEmpWise(EmpID);

            //AssignEmpLoan[] AssignEmpLoans = new AssignEmpLoan[AssignEmpLoansDT.Length];

            //for (int i = 0; i < AssignEmpLoans.Length; i++)
            //{
            //    AssignEmpLoans[i] = new AssignEmpLoan(AssignEmpLoansDT[i]);
            //}

            return SalaryAdvanceRepaymentDT;
        }


       
        /// <summary>
        /// Deactivate the Grade
        /// </summary>
        /// <param name="DeActivatedBy">id of user who want to DeActivate Grade</param>
        /// <returns>String return from the SaveGrade method</returns>
        //public String DeActivate(int DeActivatedBy)
        //{
        //    _UpdateBy = DeActivatedBy;
        //    _IsActive = false;

        //    return SaveGrade();
        //}
        
        #region JGridDataObject Members

        public object GetGridData()
        {
            SalaryAdvanceRepaymentDisplayDetails SalaryAdvanceRepayment = new SalaryAdvanceRepaymentDisplayDetails();

            SalaryAdvanceRepayment.ID = _ID;
            SalaryAdvanceRepayment.EmpID = _EmpID;
            SalaryAdvanceRepayment.AdvanceAmount = _AdvanceAmount;
            SalaryAdvanceRepayment.RepaidAmount = _RepaidAmount;
            SalaryAdvanceRepayment.DueAmount = _DueAmount;
            SalaryAdvanceRepayment.AdvanceTakenOn = _AdvanceTakenOn;

            return SalaryAdvanceRepayment;
        }

        #endregion
    }
    public class SalaryAdvanceRepaymentDisplayDetails
    {

        public int ID;
        public int EmpID;
        public Double AdvanceAmount;
        public Double RepaidAmount;
        public Double DueAmount;
        public DateTime AdvanceTakenOn;
        
    }
}
