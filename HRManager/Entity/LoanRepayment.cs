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
    public class LoanRepayment : JGridDataObject
    {
          private int _ID;
          private int _EmpID;
          private int _LoanID;
          private int _LoanRequestID;
          private Double _Amount;
          private DateTime _RepaymentDate;
          private bool _IsNew;
          private Employees1 _Employee = null;
          private Loan _Loan = null;
          private String _EmpName;
          private String _eLoanName;
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
         public int LoanRequestID
         {
             get
             {
                 return _LoanRequestID;
             }
             set
             {
                 _LoanRequestID = value;
             }
         }

        public Double Amount
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
        public String eLoanName
        {
            get
            {
                return _eLoanName;
            }
            set
            {
                _eLoanName = value;
            }
        }
        
   
        public Loan Loan
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
        public String LoanName
        {
            get
            {
                if (_Loan != null)
                {
                    return _Loan.LoanName;
                }
                else
                {
                    return String.Empty;
                }
            }
        }
        public Employees1 Employee
        {
            get
            {
                return _Employee;
            }
            set
            {
                _Employee = value;
            }
        }
        public String EmployeeName
        {
            get
            {
                if (_Employee != null)
                {
                    return _Employee.Candidate.FirstName + " " + _Employee.Candidate.LastName;
                }
                else
                {
                    return String.Empty;
                }
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
        private void Update(Loan_Repayments LoanRepayment)
        {
            if (LoanRepayment != null)
            {
                _ID = LoanRepayment.ID;
                _LoanRequestID = LoanRepayment.LoanRequestID;
                _Amount= LoanRepayment.Amount;
                _RepaymentDate= LoanRepayment.RepaymentDate;
                _IsNew = false;
                _CreatedBy = LoanRepayment.CreatedBy;
                _ModifiedBy = LoanRepayment.ModifiedBy;
                _CreatedDate = LoanRepayment.CreatedDate;
                _ModifiedDate = LoanRepayment.ModifiedDate;
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
        public LoanRepayment(Loan_Repayments LoanRepayment)
        {
            Update(LoanRepayment);
        }
        
        /// <summary>
        /// Consturctor of Grade class.
        /// Update Grade fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains Designation ID</param>
        public LoanRepayment(int ID)
        {
            Loan_Repayments LoanRepayment = new Loan_RepaymentsBusinessObject().GetLoan_Repayments(ID);

            if (LoanRepayment == null && ID > 0)
            {
                throw new IRCAException("Invalid loan repayment", ID.ToString());
            }

            Update(LoanRepayment);
        }
        /// <summary>
        /// Consturctor of Grade class.
        /// Set variables for new Grade.  
        /// </summary>
        public LoanRepayment()
        {
            _ID = 0;
            _IsNew = true;
            //_AppliedDateTime = DateTime.Now;
            //_Status = "NEW";

            
        }
        /// <summary>
        /// Save Grade.If new Grade it add and in case of edit it update the Grade.
        /// </summary>
        /// <returns>empty string</returns>
        private String SaveLoanRepayment()
        {

            Loan_Repayments LoanRepayments = new Loan_Repayments();
            LoanRepayments.ID = _ID;
            LoanRepayments.LoanRequestID = _LoanRequestID;
            LoanRepayments.Amount = _Amount;
            LoanRepayments.RepaymentDate = _RepaymentDate;
            LoanRepayments.CreatedBy = _CreatedBy;
            LoanRepayments.CreatedDate = _CreatedDate;
            LoanRepayments.ModifiedBy = _ModifiedBy;
            LoanRepayments.ModifiedDate = DateTime.Now;

            if (_IsNew)
            {
                LoanRepayments.CreatedBy = _UpdateBy;
                LoanRepayments.CreatedDate = DateTime.Now;
                LoanRepayments.ID = new Loan_RepaymentsBusinessObject().Create(LoanRepayments);
            }
            else
            {
                LoanRepayments.ModifiedBy = _UpdateBy;
                LoanRepayments.ModifiedDate = DateTime.Now;
                LoanRepayments.ID = _ID;
                new Loan_RepaymentsBusinessObject().Update(LoanRepayments);
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

            return SaveLoanRepayment();
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

        public static LoanRepayment[] GetAllLoanRepayment()
        {
            Loan_Repayments[] LoanRepaymentsDT = new Loan_RepaymentsBusinessObject().GetLoan_Repayments();

            LoanRepayment[] LoanRepayment = new LoanRepayment[LoanRepaymentsDT.Length];

            for (int i = 0; i < LoanRepayment.Length; i++)
            {
                LoanRepayment[i] = new LoanRepayment(LoanRepaymentsDT[i]);
            }

            return LoanRepayment;
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
            LoanRepaymentDisplayDetails LoanRepayment = new LoanRepaymentDisplayDetails();

            LoanRepayment.ID = _ID;
            LoanRepayment.EmpID = _EmpID;
            LoanRepayment.Emp = EmployeeName;
            LoanRepayment.LoanID = _LoanID;
            LoanRepayment.Loan = LoanName;
            LoanRepayment.Amount = _Amount;
            LoanRepayment.RepaymentDate = _RepaymentDate;

            return LoanRepayment;
        }

        #endregion
    }
    public class LoanRepaymentDisplayDetails
    {

        public int ID;
        public int EmpID;
        public String Emp;
        public int LoanID;
        public String Loan;
        public Double Amount;
        public DateTime RepaymentDate;
    }
}
