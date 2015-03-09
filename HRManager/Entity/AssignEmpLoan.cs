using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IRCA.Communication;
using IS91.Services.DataBlock;

namespace HRManager.Entity
{
    /// <summary>
    /// Represents Grade fields and methods.
    /// </summary>
    public class AssignEmpLoan : JGridDataObject
    {
        
        private int _ID;
        private int _EmpID;
        private int _LoanID;
        private int _LoanRequestID;
        private Double _LoanAmount;
        private Double _RepaidAmount;
        private Double _DueAmount;
        private DateTime _LoanTakenOn;
        private DateTime _LoanClosedOn;
        private bool _IsNew;
        private int _UpdateBy;
        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;
        private String _LoanActualName;
        private String _EmployeeName;
        


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

        public Double LoanAmount
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

        public String LoanActualName
        {
            get
            {
                return _LoanActualName;
            }
            set
            {
                _LoanActualName = value;
            }
        }
        public String EmployeeName
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
        public DateTime LoanTakenOn
        {
            get { return _LoanTakenOn; }
            set { _LoanTakenOn = value; }
        }

         public DateTime LoanClosedOn
        {
            get { return _LoanClosedOn; }
            set { _LoanClosedOn = value; }
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
        private void Update(Assign_Emp_Loan AssignEmpLoan)
        {
            if (AssignEmpLoan != null)
            {
                _ID = AssignEmpLoan.ID;
                //_EmpID = AssignEmpLoan.EmpID;
                //_LoanID= AssignEmpLoan.LoanID;
                _LoanRequestID = AssignEmpLoan.LoanRequestID;
                _LoanAmount= AssignEmpLoan.LoanAmount;
                _RepaidAmount= AssignEmpLoan.RepaidAmount;
                _DueAmount= AssignEmpLoan.DueAmount;
                _LoanTakenOn= AssignEmpLoan.LoanTakenOn;
                _LoanClosedOn= AssignEmpLoan.LoanClosedOn;
                _IsNew = false;
                _CreatedBy = AssignEmpLoan.CreatedBy;
                _ModifiedBy = AssignEmpLoan.ModifiedBy;
                _CreatedDate = AssignEmpLoan.CreatedDate;
                _ModifiedDate = AssignEmpLoan.ModifiedDate;
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
        public AssignEmpLoan(Assign_Emp_Loan AssignEmpLoan)
        {
            Update(AssignEmpLoan);
        }
        
        /// <summary>
        /// Consturctor of Grade class.
        /// Update Grade fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains Designation ID</param>
        public AssignEmpLoan(int ID)
        {
            Assign_Emp_Loan AssignEmpLoan = new Assign_Emp_LoanBusinessObject().GetAssign_Emp_Loan(ID);

            if (AssignEmpLoan == null && ID > 0)
            {
                throw new IRCAException("Invalid Assign Employee Loan", ID.ToString());
            }

            Update(AssignEmpLoan);
        }
        public AssignEmpLoan(int LoanRequestID,String ForLoanRequest)
        {
            if (ForLoanRequest == "ForLoanRequest")
            {
                Assign_Emp_Loan AssignEmpLoan = new Assign_Emp_LoanBusinessObject().GetAssign_Emp_LoanByLoanRequestID(LoanRequestID);

                if (AssignEmpLoan == null && ID > 0)
                {
                    throw new IRCAException("Invalid Assign Employee Loan", ID.ToString());
                }

                Update(AssignEmpLoan);
            }
        }

        /// <summary>
        /// Consturctor of Grade class.
        /// Set variables for new Grade.  
        /// </summary>
        public AssignEmpLoan()
        {
            _ID = 0;
            _IsNew = true;
            _RepaidAmount = 0;
            _DueAmount = 0;
            _LoanClosedOn=Convert.ToDateTime("1900-01-01");
            
        }
        /// <summary>
        /// Save Grade.If new Grade it add and in case of edit it update the Grade.
        /// </summary>
        /// <returns>empty string</returns>
        private String SaveAssignEmpLoan(Session DBSession)
        {
            bool IsLocalSession = false;

            if (DBSession == null)
            {
                IsLocalSession = true;

                DBSession = Session.CreateNewSession();

                DBSession.BeginTransaction();
            }
            try
            {
            Assign_Emp_Loan AssignEmpLoan = new Assign_Emp_Loan();
            AssignEmpLoan.ID = _ID;
            AssignEmpLoan.LoanRequestID = _LoanRequestID;
            AssignEmpLoan.LoanAmount = _LoanAmount;
            AssignEmpLoan.RepaidAmount = _RepaidAmount;
            AssignEmpLoan.DueAmount = _DueAmount;
            AssignEmpLoan.LoanTakenOn = _LoanTakenOn;
            AssignEmpLoan.LoanClosedOn = _LoanClosedOn;
            AssignEmpLoan.ModifiedBy = _ModifiedBy;
            AssignEmpLoan.ModifiedDate = DateTime.Now;
            AssignEmpLoan.CreatedBy = _CreatedBy;
            AssignEmpLoan.CreatedDate = _CreatedDate;

            if (_IsNew)
            {
                AssignEmpLoan.CreatedBy = _UpdateBy;
                AssignEmpLoan.CreatedDate = DateTime.Now;
                AssignEmpLoan.ID = new Assign_Emp_LoanBusinessObject(DBSession).Create(AssignEmpLoan);
            }
            else
            {
                AssignEmpLoan.ModifiedBy = _UpdateBy;
                AssignEmpLoan.ModifiedDate = DateTime.Now;
                AssignEmpLoan.ID = _ID;
                new Assign_Emp_LoanBusinessObject(DBSession).Update(AssignEmpLoan);
            }
            if (IsLocalSession)
            {
                DBSession.Commit();
            }
            return String.Empty;

            }
            catch (Exception e)
            {
                if (IsLocalSession)
                {
                    DBSession.Rollback();
                }

                throw e;
            }
            finally
            {
                if (IsLocalSession)
                {
                    DBSession.Dispose();
                }
            }

        }
        /// <summary>
        /// Save Grade.If new Grade it add and in case of edit it update the Grade.
        /// </summary>
        /// <returns>empty string</returns>
        public String DeleteAssignEmpLoan(int id)
        {
            Assign_Emp_LoanBusinessObject AssignEmpLoanBO = new Assign_Emp_LoanBusinessObject();
           AssignEmpLoanBO.Delete(id);

            return String.Empty;
        }
        /// <summary>
        ///Validate Grade for empty and already exist status and then save Grade.
        /// </summary>
        /// <returns>String return from the SaveGrade method</returns> 
        public String Save(Session DBSession)
        {
            String Status = Validate();

            if (Status != String.Empty)
            {
                return Status;
            }

            return SaveAssignEmpLoan(DBSession);
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

        public static AssignEmpLoan[] GetAllAssignEmpLoan()
        {
            Assign_Emp_Loan[] AssignEmpLoansDT = new Assign_Emp_LoanBusinessObject().GetAssign_Emp_Loan();

            AssignEmpLoan[] AssignEmpLoans = new AssignEmpLoan[AssignEmpLoansDT.Length];

            for (int i = 0; i < AssignEmpLoans.Length; i++)
            {
                AssignEmpLoans[i] = new AssignEmpLoan(AssignEmpLoansDT[i]);
            }

            return AssignEmpLoans;
        }
        public static AssignEmpLoan[] GetPendingLoanEmpWise(int EmpID)
        {
            AssignEmpLoan[] AssignEmpLoansDT = new Assign_Emp_LoanBusinessObject().GetPendingLoanEmpWise(EmpID);

            //AssignEmpLoan[] AssignEmpLoans = new AssignEmpLoan[AssignEmpLoansDT.Length];

            //for (int i = 0; i < AssignEmpLoans.Length; i++)
            //{
            //    AssignEmpLoans[i] = new AssignEmpLoan(AssignEmpLoansDT[i]);
            //}

            return AssignEmpLoansDT;
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
            AssignEmpLoanDisplayDetails AssignEmpLoan = new AssignEmpLoanDisplayDetails();

            AssignEmpLoan.ID = _ID;
            AssignEmpLoan.LoanRequestId = _LoanRequestID;
            AssignEmpLoan.EmpID = _EmpID;
            AssignEmpLoan.Emp = EmployeeName;
            AssignEmpLoan.LoanID = _LoanID;
            AssignEmpLoan.Loan = _LoanActualName;
            AssignEmpLoan.LoanAmount = _LoanAmount;
            AssignEmpLoan.RepaidAmount = _RepaidAmount;
            AssignEmpLoan.DueAmount = _DueAmount;
            AssignEmpLoan.LoanTakenOn = _LoanTakenOn;
            AssignEmpLoan.LoanClosedOn = _LoanClosedOn;


            return AssignEmpLoan;
        }

        #endregion
    }
    public class AssignEmpLoanDisplayDetails
    {
        public int ID;
        public int LoanRequestId;
        public int EmpID;
        public String Emp;
        public int LoanID;
        public String Loan;
        public Double LoanAmount;
        public Double RepaidAmount;
        public Double DueAmount;
        public DateTime LoanTakenOn;
        public DateTime LoanClosedOn;
    }
}
