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
    /// Represents Loan fields and methods.
    /// </summary>
    public class Master_LoansDetails : JGridDataObject
    {
        private int _ID;
        private String _LoanName;
        private Double _MaxAmount;
        private Double _Interest;
        private bool _IsActive;
        private bool _IsNew;
        private int _RepaymentMonth;
        private int _UpdateBy;
        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;

        private double _MaxBasicPercentage;
        private int _MinServicePeriod;
        private int _MinLeaveBalance;
        private int _RemainingService;
        private string _Installment;

        
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
        public String LoanName
        {
            get
            {
                return _LoanName;
            }
            set
            {
                _LoanName = value;
            }
        }

        public Double MaxAmount
        {
            get
            {
                return _MaxAmount;
            }
            set
            {
                _MaxAmount = Convert.ToDouble(value);
            }
        }

        public Double Interest
        {
            get
            {
                return _Interest;
            }
            set
            {
                _Interest = Convert.ToDouble(value);
            }
        }
        public int RepaymentMonth
        {
            get
            {
                return _RepaymentMonth;
            }
            set
            {
                _RepaymentMonth = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                _IsActive = value;
            }
        }
        public int UpdatedBy
        {
            get { return _UpdateBy; }
            set { _UpdateBy = value; }
        }
        public double MaxBasicPercentage
        {
            get
            {
                return _MaxBasicPercentage;
            }
            set
            {
                _MaxBasicPercentage = value;
            }
        }
        public int MinServicePeriod
        {
            get
            {
                return _MinServicePeriod;
            }
            set
            {
                _MinServicePeriod = value;
            }
        }
        public int MinLeaveBalance
        {
            get
            {
                return _MinLeaveBalance;
            }
            set
            {
                _MinLeaveBalance = value;
            }
        }
        public int RemainingService
        {
            get
            {
                return _RemainingService;
            }
            set
            {
                _RemainingService = value;
            }
        }
        public string Installment
        {
            get
            {
                return _Installment;
            }
            set
            {
                _Installment = value;
            }
        }

        
        /// <summary>
        /// Update the Grade field using Hr_Grade.
        /// </summary>
        /// <param name="Grade">Object of Hr_Grade class</param>
        private void Update(Master_Loan Loan)
        {
            if (Loan != null)
            {
                _ID = Loan.ID;
                _LoanName = Loan.LoanName;
                _MaxAmount = Loan.MaxAmount;
                _Interest = Loan.Interest;
                _IsActive = Loan.IsActive;
                _IsNew = false;
                _CreatedBy = Loan.CreatedBy;
                _ModifiedBy = Loan.ModifiedBy;
                _CreatedDate = Loan.CreatedDate;
                _ModifiedDate = Loan.ModifiedDate;
                _MaxBasicPercentage=Loan.MaxBasicPercentage;
                _MinServicePeriod=Loan.MinServicePeriod;
                _MinLeaveBalance=Loan.MinLeaveBalance;
                _RemainingService=Loan.RemainingService;
                _Installment = Loan.Installment;
                
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
        public Master_LoansDetails(Master_Loan Loan)
        {
            Update(Loan);
        }
        /// <summary>
        /// Consturctor of Grade class.
        /// Update Grade for given GradeName field.
        /// </summary>
        /// <param name="GradeName">field contains Grade Name</param>
        public Master_LoansDetails(String LoanName)
        {
            Update(new Master_LoanBusinessObject().GetLoanByLoan(LoanName));                        
        }
        /// <summary>
        /// Consturctor of Grade class.
        /// Update Grade fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains Designation ID</param>
        public Master_LoansDetails(int ID)
        {
            Master_Loan Loan = new Master_LoanBusinessObject().GetMaster_Loan(ID);

            if (Loan == null && ID > 0)
            {
                throw new IRCAException("Invalid Loan", ID.ToString());
            }

            Update(Loan);
        }
        /// <summary>
        /// Consturctor of Grade class.
        /// Set variables for new Grade.  
        /// </summary>
        public Master_LoansDetails()
        {
            _ID = 0;
            _IsNew = true;
        }
        /// <summary>
        /// Save Grade.If new Grade it add and in case of edit it update the Grade.
        /// </summary>
        /// <returns>empty string</returns>
        private String SaveLoan()
        {

            Master_Loan Loan = new Master_Loan();
            Loan.ID = _ID;
            Loan.LoanName = _LoanName;
            Loan.MaxAmount = _MaxAmount;
            Loan.Interest = _Interest;
            Loan.IsActive = _IsActive;
            Loan.ModifiedBy = _ModifiedBy;
            Loan.ModifiedDate = DateTime.Now;
            Loan.CreatedBy = _CreatedBy;
            Loan.CreatedDate = _CreatedDate;
            Loan.MaxBasicPercentage=_MaxBasicPercentage;
            Loan.MinServicePeriod=_MinServicePeriod;
            Loan.MinLeaveBalance=_MinLeaveBalance;
            Loan.RemainingService=_RemainingService;
            Loan.Installment=_Installment;
            //Grade.ModifiedBy = _UpdateBy;
            //Grade.ModifiedDate = DateTime.Now;

            if (_IsNew)
            {
                //Grade.CreatedBy = _UpdateBy;
                //Grade.CreatedDate = DateTime.Now;
                Loan.CreatedBy = _UpdateBy;
                Loan.CreatedDate = DateTime.Now;
                Loan.ID = new Master_LoanBusinessObject().Create(Loan);
            }
            else
            {
                
                Loan.ModifiedBy = _UpdateBy;
                Loan.ModifiedDate = DateTime.Now;
                Loan.ID = _ID;
                new Master_LoanBusinessObject().Update(Loan);
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

            //Status=CheckReference();

            if (Status != String.Empty)
            {
                return Status;
            }

            return SaveLoan();
        }
        /// <summary>
        /// Validate GradeName for empty and already exist status.
        /// </summary>
        /// <returns>empty string</returns>
        private String Validate()
        {
            Master_LoanBusinessObject LoanBo = new Master_LoanBusinessObject();

            if (_LoanName == String.Empty)
            {
                return HRManagerDefs.LoanMessages.EMPTY_LOAN;
            }
            else if (LoanBo.IsLoanExists(_LoanName, _ID))
            {
                return HRManagerDefs.LoanMessages.LOAN_EXISTS;
            }
            if (_ID != 0)
            {
                return CheckReference();
            }
            return String.Empty;
        }

        /// <summary>
        /// Activate the Grade
        /// </summary>
        /// <param name="ActivatedBy">id of user who want to activate Grade</param>
        /// <returns>String return from the SaveGrade method</returns>
        public String Activate(int ActivateBy)
        {
            _UpdateBy = ActivateBy;
            _IsActive = true;

            return SaveLoan();
        }
        /// <summary>
        /// Validate PolicyTypeName for empty and already exist status.
        /// </summary>
        /// <returns>empty string</returns>
        private String CheckReference()
        {
            Master_LoanBusinessObject LoanBO = new Master_LoanBusinessObject();
//kartyek commented for Master_Loan_Grade is not available need to get confirmation
            //if (LoanBO.IsLoanRefered(_ID))
            //{
            //    return HRManagerDefs.LoanMessages.LOAN_REFERED;
            //}
            return String.Empty;
        }
        /// <summary>
        /// Deactivate the Grade
        /// </summary>
        /// <param name="DeActivatedBy">id of user who want to DeActivate Grade</param>
        /// <returns>String return from the SaveGrade method</returns>
        public String DeActivate(int DeActivateBy)
        {
             String Status = CheckReference();

             if (Status != String.Empty)
             {
                 return Status;
             }
             else
             {
                 _UpdateBy = DeActivateBy;
                 _IsActive = false;

                 return SaveLoan();
             }
        }
        /// <summary>
        /// Return all Grades
        /// </summary>
        /// <returns>Array of the object of Grade class</returns>
        public static Master_LoansDetails[] GetAllLoan()
        {
            Master_Loan[] LoansDT = new Master_LoanBusinessObject().GetAllLoans();

            Master_LoansDetails[] Loans = new Master_LoansDetails[LoansDT.Length];

            for (int i = 0; i < Loans.Length; i++)
            {
                Loans[i] = new Master_LoansDetails(LoansDT[i]);
            }

            return Loans;
        }
        /// <summary>
        /// Return all Grades
        /// </summary>
        /// <returns>Array of the object of Grade class</returns>
        public static Master_LoansDetails[] GetLoansForTxt(int LoanID)
        {
            Master_Loan[] LoansDT = new Master_LoanBusinessObject().GetLoansForTxt(LoanID);

            Master_LoansDetails[] Loans = new Master_LoansDetails[LoansDT.Length];

            for (int i = 0; i < Loans.Length; i++)
            {
                Loans[i] = new Master_LoansDetails(LoansDT[i]);
            }

            return Loans;
        }
        /// <summary>
        /// Return all Grades
        /// </summary>
        /// <returns>Array of the object of Grade class</returns>
        public static Master_LoansDetails[] GetAllActiveLoan()
        {
            Master_Loan[] LoansDT = new Master_LoanBusinessObject().GetAllActiveLoan();

            Master_LoansDetails[] Loans = new Master_LoansDetails[LoansDT.Length];

            for (int i = 0; i < Loans.Length; i++)
            {
                Loans[i] = new Master_LoansDetails(LoansDT[i]);
            }

            return Loans;
        }
        /// <summary>
        /// Return all LocationTypes
        /// </summary>
        /// <returns>Array of the object of LocationTypes class</returns>
        public static Master_LoansDetails[] GetAllLoanforCombo(string LoanID)
        {
            Master_Loan[] LoanDT = new Master_LoanBusinessObject().GetAllActLoans(LoanID);

            Master_LoansDetails[] Loan = new Master_LoansDetails[LoanDT.Length];

            for (int i = 0; i < Loan.Length; i++)
            {
                Loan[i] = new Master_LoansDetails(LoanDT[i]);
            }

            return Loan;
        }
        
        /// <summary>
        /// Return all LocationTypes
        /// </summary>
        /// <returns>Array of the object of LocationTypes class</returns>
        public static Master_LoansDetails[] GetAllLoanforComboByGrade(int GradeId)
        {
            Master_Loan[] LoanDT = new Master_LoanBusinessObject().GetAllActLoansByGrade(GradeId);

            Master_LoansDetails[] Loan = new Master_LoansDetails[LoanDT.Length];

            for (int i = 0; i < Loan.Length; i++)
            {
                Loan[i] = new Master_LoansDetails(LoanDT[i]);
            }

            return Loan;
        }
        /// <summary>
        /// Return all LocationTypes
        /// </summary>
        /// <returns>Array of the object of LocationTypes class</returns>
        public static String GetLoanAmountByLoanId(int LoanId,int EmpID)
        {
            String LoanAmount = new Master_LoanBusinessObject().GetLoanAmountByLoanId(LoanId,EmpID);



            return LoanAmount;
        }
        /// <summary>
        /// Return all Designations
        /// </summary>
        /// <returns>Array of the object of Designation class</returns>
        public static Master_LoansDetails[] GetAllInActiveLoans()
        {
            Master_Loan[] LoansDT = new Master_LoanBusinessObject().GetAllInActiveLoansOrderByLoan();

            Master_LoansDetails[] Loans = new Master_LoansDetails[LoansDT.Length];

            for (int i = 0; i < Loans.Length; i++)
            {
                Loans[i] = new Master_LoansDetails(LoansDT[i]);
            }

            return Loans;
        }

        /// <summary>
        /// Return all Designations
        /// </summary>
        /// <returns>Array of the object of Designation class</returns>
        public static Master_LoansDetails[] GetActiveLoans()
        {
            Master_Loan[] LoansDT = new Master_LoanBusinessObject().GetAllActiveLoan();

            Master_LoansDetails[] Loans = new Master_LoansDetails[LoansDT.Length];

            for (int i = 0; i < Loans.Length; i++)
            {
                Loans[i] = new Master_LoansDetails(LoansDT[i]);
            }

            return Loans;
        }
        #region JGridDataObject Members

        public object GetGridData()
        {
            LoanDetails Loan = new LoanDetails();

            Loan.LoanID = _ID;
            Loan.LoanName = _LoanName;
            Loan.MaxAmount=_MaxAmount;
            Loan.Interest=_Interest;
            Loan.IsActive = _IsActive;
            Loan.MaxBasicPercentage = _MaxBasicPercentage;
            Loan.MinServicePeriod = _MinServicePeriod;
            Loan.MinLeaveBalance = _MinLeaveBalance;
            Loan.RemainingService = _RemainingService;
            Loan.Installment = _Installment;
            return Loan;
        }       

        #endregion
    }
    public class LoanDetails
    {
        public int LoanID;
        public String LoanName;
        public double MaxAmount;
        public double Interest;
        public bool IsActive;

        public double MaxBasicPercentage;
        public int MinServicePeriod;
        public int MinLeaveBalance;
        public int RemainingService;
        public string Installment;       
    }
}


 