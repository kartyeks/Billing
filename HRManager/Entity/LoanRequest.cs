using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IS91.Services.DataBlock;
using IRCA.Communication;
using HRManager.Entity.EmployeesInfo;

namespace HRManager.Entity
{
    /// <summary>
    /// Represents Grade fields and methods.
    /// </summary>
    public class LoanRequest : JGridDataObject
    {
          private int _ID;
          private int _EmpID;
          private int _LoanID;
          private Double _LoanAmount;
          private Int16 _RepaymentMonths;
          private Double _MonthlyAmount;
          private String _Reason;
          private DateTime _AppliedDateTime;
          private int _AppliedTo;
          private String _HRRemarks;
          private String _Status;
          private bool _IsNew;
          private EmployeePersonalDetails _Employees = null;
          //private CandidatePersonalInfo _Candidate = null;
          private Master_LoansDetails _Loan = null;
          //private int _DesignationID;
          //private int _LocationID;
          private String _EmpName;
          private String _eLoanName;
          private String _appliedToName;
          private Double _Interest;
          private int _UpdateBy;
          private int _CreatedBy;
          private DateTime _CreatedDate;
          private int _ModifiedBy;
          private DateTime _ModifiedDate;
          private DateTime _RepliedDateTime;
          private Double _MaxAmount;
          private Double _ActualRepaymentMonth;

          private DateTime _StartDate;

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
        public Double MaxAmount
        {
            get
            {
                return _MaxAmount;
            }
            set
            {
                _MaxAmount = value;
            }
        }
        public Double ActualRepaymentMonth
        {
            get
            {
                return _ActualRepaymentMonth;
            }
            set
            {
                _ActualRepaymentMonth = value;
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
                _Interest = value;
            }
        }

        public DateTime RepliedDateTime
        {
            get
            {
                return _RepliedDateTime;
            }
            set
            {
                _RepliedDateTime = value;
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
        public Master_LoansDetails Loan
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
        public EmployeePersonalDetails Employees
        {
            get
            {
                return _Employees;
            }
            set
            {
                _Employees = value;
            }
        }
        public String EmployeeName
        {
            get
            {
                if (_Employees != null)
                {
                    return _Employees.FirstName + " " + _Employees.LastName;
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
        private void Update(Loan_Request LoanRequest)
        {
            if (LoanRequest != null)
            {
                _ID = LoanRequest.ID;
                _EmpID = LoanRequest.EmpID;
                _LoanID= LoanRequest.LoanID;
                _LoanAmount= LoanRequest.LoanAmount;
                _RepaymentMonths= LoanRequest.RepaymentMonths;
                _MonthlyAmount= LoanRequest.MonthlyAmount;
                _Reason= LoanRequest.Reason;
                _AppliedDateTime= LoanRequest.AppliedDateTime;
                _AppliedTo= LoanRequest.AppliedTo;
                _HRRemarks= LoanRequest.HRRemarks;
                _Status= LoanRequest.Status;
                _RepliedDateTime = LoanRequest.RepliedDateTime;
                _IsNew = false;
                _Loan = new Master_LoansDetails(LoanRequest.LoanID);
                _Employees = new EmployeePersonalDetails(LoanRequest.EmpID);
                _CreatedBy = LoanRequest.CreatedBy;
                _ModifiedBy = LoanRequest.ModifiedBy;
                _CreatedDate = LoanRequest.CreatedDate;
                _ModifiedDate = LoanRequest.ModifiedDate;
                _MaxAmount = LoanRequest.MaxAmount;
                _Interest = LoanRequest.Interest;
                _ActualRepaymentMonth = LoanRequest.ActualRepaymentMonth;
                if (LoanRequest.StartDate.ToString() != "01/01/0001 00:00:00")
                    _StartDate = LoanRequest.StartDate;
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
        public LoanRequest(Loan_Request LoanRequest)
        {
            Update(LoanRequest);
        }
        
        /// <summary>
        /// Consturctor of Grade class.
        /// Update Grade fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains Designation ID</param>
        public LoanRequest(int ID)
        {
            Loan_Request LoanRequest = new Loan_RequestBusinessObject().GetLoan_Request(ID);

            if (LoanRequest == null && ID > 0)
            {
                throw new IRCAException("Invalid loan request", ID.ToString());
            }

            Update(LoanRequest);
        }
        /// <summary>
        /// Consturctor of Grade class.
        /// Set variables for new Grade.  
        /// </summary>
        public LoanRequest()
        {
            _ID = 0;
            _IsNew = true;
            //_AppliedDateTime = DateTime.Now;
            //_Status = "NEW";

            
        }
        public static LoanRequest[] GetAppliedToLoans(int AppliedToID)
        {
            LoanRequest[] LoanRequestsDT = new Loan_RequestBusinessObject().GetAppliedToLoans(AppliedToID);

            return LoanRequestsDT;
        }
        /// <summary>
        /// Save Grade.If new Grade it add and in case of edit it update the Grade.
        /// </summary>
        /// <returns>empty string</returns>
        private String SaveLoanRequest(Session DBSession)
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
                Loan_Request LoanRequest = new Loan_Request();
                LoanRequest.ID = _ID;
                LoanRequest.EmpID = _EmpID;
                LoanRequest.LoanID = _LoanID;
                LoanRequest.LoanAmount = _LoanAmount;
                LoanRequest.RepaymentMonths = _RepaymentMonths;
                LoanRequest.MonthlyAmount = _MonthlyAmount;
                LoanRequest.Reason = _Reason;
                LoanRequest.AppliedDateTime = _AppliedDateTime;
                LoanRequest.AppliedTo = _AppliedTo;
                LoanRequest.HRRemarks = _HRRemarks;
                LoanRequest.Status = _Status;
                LoanRequest.ModifiedBy = _ModifiedBy;
                LoanRequest.ModifiedDate = DateTime.Now;
                LoanRequest.CreatedBy = _CreatedBy;
                LoanRequest.CreatedDate = _CreatedDate;
                LoanRequest.MaxAmount = _MaxAmount;
                LoanRequest.Interest = _Interest;
                LoanRequest.ActualRepaymentMonth = _ActualRepaymentMonth;
                if (_StartDate != null)
                    LoanRequest.StartDate = _StartDate;

                if (_IsNew)
                {
                    LoanRequest.CreatedBy = _UpdateBy;
                    LoanRequest.CreatedDate = DateTime.Now;
                    LoanRequest.ID = new Loan_RequestBusinessObject(DBSession).Create(LoanRequest);
                }
                else
                {
                    LoanRequest.ModifiedBy = _UpdateBy;
                    LoanRequest.ModifiedDate = DateTime.Now;
                    LoanRequest.RepliedDateTime = _RepliedDateTime;
                    LoanRequest.ID = _ID;
                    new Loan_RequestBusinessObject(DBSession).Update(LoanRequest);
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

        public String SaveLoanRequestEmail(Session DBSession)
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
            Loan_Request LoanRequest = new Loan_Request();
            LoanRequest.ID = _ID;
            LoanRequest.EmpID = _EmpID;
            LoanRequest.LoanID = _LoanID;
            LoanRequest.LoanAmount = _LoanAmount;
            LoanRequest.RepaymentMonths = _RepaymentMonths;
            LoanRequest.MonthlyAmount = _MonthlyAmount;
            LoanRequest.Reason = _Reason; 
            LoanRequest.AppliedDateTime = _AppliedDateTime;
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

            LoanRequest.AppliedTo = _AppliedTo;
            //LoanRequest.AppliedTo = _AppliedTo;
            LoanRequest.HRRemarks = _HRRemarks;
            LoanRequest.Status = _Status;
            LoanRequest.ModifiedBy = _ModifiedBy;
            LoanRequest.ModifiedDate = DateTime.Now;
            LoanRequest.CreatedBy = _CreatedBy;
            LoanRequest.CreatedDate = _CreatedDate;
            LoanRequest.MaxAmount = _MaxAmount;
            LoanRequest.Interest = _Interest;
            LoanRequest.ActualRepaymentMonth = _ActualRepaymentMonth;
            if (_StartDate.ToString() != "01/01/0001 00:00:00")
                LoanRequest.StartDate = _StartDate;

            if (_IsNew)
            {
                LoanRequest.CreatedBy = _UpdateBy;
                LoanRequest.CreatedDate = DateTime.Now;
                LoanRequest.ID = new Loan_RequestBusinessObject(DBSession).Create(LoanRequest);
            }
            else
            {
                LoanRequest.ModifiedBy = _UpdateBy;
                LoanRequest.ModifiedDate = DateTime.Now;
                LoanRequest.RepliedDateTime = _RepliedDateTime;
                LoanRequest.ID = _ID;
                new Loan_RequestBusinessObject(DBSession).Update(LoanRequest);
            }
            if (IsLocalSession)
                {
                    DBSession.Commit();
                }
            return LoanRequest.ID.ToString();
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
        ///Validate Grade for empty and already exist status and then save Grade.
        /// </summary>
        /// <returns>String return from the SaveGrade method</returns> 
        public String SaveEmail(Session DBSession)
        {
            bool IsLocalSession = false;
            if (DBSession == null)
            {
                IsLocalSession = true;

                DBSession = Session.CreateNewSession();

                DBSession.BeginTransaction();
            }
            String Status = Validate();

            if (Status != String.Empty)
            {
                return Status;
            }
            return SaveLoanRequestEmail(DBSession);
        }
        public String SaveAction(Session DBSession)
        {
            return SaveLoanRequest(DBSession);
        }
        /// <summary>
        ///Validate Grade for empty and already exist status and then save Grade.
        /// </summary>
        /// <returns>String return from the SaveGrade method</returns> 
        public String Save(Session DBSession)
        {
            bool IsLocalSession = false;

            if (DBSession == null)
            {
                IsLocalSession = true;

                DBSession = Session.CreateNewSession();

                DBSession.BeginTransaction();
            }
            String Status = Validate();

            if (Status != String.Empty)
            {
                return Status;
            }

            return SaveLoanRequest(DBSession);
        }
        ///// <summary>
        /////Validate Grade for empty and already exist status and then save Grade.
        ///// </summary>
        ///// <returns>String return from the SaveGrade method</returns> 
        //public String SaveAction()
        //{
        //    String Status = ValidateAction();

        //    if (Status != String.Empty)
        //    {
        //        return Status;
        //    }

        //    return SaveLoanRequest();
        //}
        /// <summary>
        /// Validate GradeName for empty and already exist status.
        /// </summary>
        /// <returns>empty string</returns>
        private String Validate()
        {
            Loan_RequestBusinessObject AssignEmpLoanBO = new Loan_RequestBusinessObject();

            if (AssignEmpLoanBO.LoanValidForEmpWorkingDays(_EmpID,_LoanID))
            {
                return string.Format(HRLoanManagerDefs.Loan.MINSERVICEPERIODFORLOAN,new Master_LoansDetails(_LoanID).MinServicePeriod );                
            }
            else if (AssignEmpLoanBO.LoanValidFromEmpRetirmentDate(_EmpID, _LoanID))
            {
                return string.Format(HRLoanManagerDefs.Loan.REMAININGSERVICEFORLOAN, new Master_LoansDetails(_LoanID).RemainingService);
            }
            //else if (AssignEmpLoanBO.SavedEncashLeaveBeforeLoanRequest(_EmpID) < (new Loan(_LoanID).MinLeaveBalance))
            //{
            //    return string.Format(HRLoanManagerDefs.Loan.MINLEAVEBALANCEFORLOAN, new Loan(_LoanID).MinLeaveBalance);     \\commented by karthik as per consulted with concern person leave is not included in loan
            //}
            //else if((new AssignEmpLoan(new Loan(_LoanID).ID, "ForLoanRequest").LoanClosedOn).ToString()!= null)
            //{
            //    if ( (new AssignEmpLoan(new Loan(_LoanID).ID, "ForLoanRequest").LoanClosedOn).ToString()=="01/01/1900 00:00:00" )
            //    {
            //        return string.Format(HRLoanManagerDefs.Loan.PENDINGPREVIOUSLOAN);
            //    }
            //    else if ((DateTime.Now).Subtract((new AssignEmpLoan(new Loan(_LoanID).ID, "ForLoanRequest").LoanClosedOn)).Days <365)
            //    {
            //        return string.Format(HRLoanManagerDefs.Loan.PENDINGPREVIOUSLOAN);
            //    }
            //}
            //else if (new LoanRequest(_ID).ToString() != null)
            //{
                if (AssignEmpLoanBO.isNewRequest(_EmpID,_LoanID,_ID))
                {
                    return string.Format(HRLoanManagerDefs.Loan.PENDINGREQUESTLOAN);
                }
                else if (AssignEmpLoanBO.isRequestYearAfterLoanClosedDate(_EmpID, _LoanID,_ID))
                {
                    return string.Format(HRLoanManagerDefs.Loan.UNDERPROCESSPREVIOUSLOAN);
                }
            //}
            return String.Empty;
        }

        public static String CheckEgibility(int ID)
        {
            Loan_RequestBusinessObject AssignEmpLoanBO = new Loan_RequestBusinessObject();

            if ((new EmployeeType(new EmployeePersonalDetails(ID).EmployeeTypeID).IsPermanent != true))
            {
                return HRLoanManagerDefs.Loan.ONLY_PERMANENT_EMP_CAN_APPLY;
            }
            else if (AssignEmpLoanBO.LoanValidForEmpWorkingDays(ID, 1))
            {
                return string.Format(HRLoanManagerDefs.Loan.MINSERVICEPERIODFORLOAN, new Master_LoansDetails(1).MinServicePeriod);
            }
            else if (AssignEmpLoanBO.LoanValidFromEmpRetirmentDate(ID, 1))
            {
                return string.Format(HRLoanManagerDefs.Loan.REMAININGSERVICEFORLOAN, new Master_LoansDetails(1).RemainingService);
            }
            else if (AssignEmpLoanBO.SavedEncashLeaveBeforeLoanRequest(ID) < (new Master_LoansDetails(1).MinLeaveBalance))
            {
                return string.Format(HRLoanManagerDefs.Loan.MINLEAVEBALANCEFORLOAN, new Master_LoansDetails(1).MinLeaveBalance);
            }
            
            return String.Empty;
        }

        public static String CheckEgibility(int ID,int LoanID)
        {
            Loan_RequestBusinessObject AssignEmpLoanBO = new Loan_RequestBusinessObject();

            if ((new EmployeeType(new EmployeePersonalDetails(ID).EmployeeTypeID).IsPermanent != true))
            {
                return HRLoanManagerDefs.Loan.ONLY_PERMANENT_EMP_CAN_APPLY;
            }
            else if (AssignEmpLoanBO.LoanValidForEmpWorkingDays(ID, LoanID))
            {
                return string.Format(HRLoanManagerDefs.Loan.MINSERVICEPERIODFORLOAN, new Master_LoansDetails(LoanID).MinServicePeriod);
            }
            else if (AssignEmpLoanBO.LoanValidFromEmpRetirmentDate(ID, LoanID))
            {
                return string.Format(HRLoanManagerDefs.Loan.REMAININGSERVICEFORLOAN, new Master_LoansDetails(LoanID).RemainingService);
            }
            //else if (AssignEmpLoanBO.SavedEncashLeaveBeforeLoanRequest(ID) < (new Loan(LoanID).MinLeaveBalance))
            //{
            //    return string.Format(HRLoanManagerDefs.Loan.MINLEAVEBALANCEFORLOAN, new Loan(LoanID).MinLeaveBalance);    //Commented by karthik because minimum balance leave is not required for loan as per consulted.
            //}

            return String.Empty;
        }
//kartyek 9.2.2015 for doubts
        public static String CheckDeptHODForLoan(int ID)
        {
            Loan_RequestBusinessObject AssignEmpLoanBO = new Loan_RequestBusinessObject();
            int EmpDeptHod = new TeamDetail(new EmployeeOccupationDetails(ID).TeamID).ManagerID;
            if (EmpDeptHod == null || EmpDeptHod.ToString() == "" || EmpDeptHod == 0)
            {
                return HRLoanManagerDefs.Loan.NODEPTHOD;
            }
            return String.Empty;
        }
        public static String CheckLoanStartDate(DateTime LoanStartDate, int LoanRequestID)
        {
            Employee_PayrollBusinessObject PayrollBO = new Employee_PayrollBusinessObject();
            string[] arrdate = LoanStartDate.ToString().Split('/');
            string year = arrdate[2].Substring(0, 4);
            string month = arrdate[1];
            int EmpID = new LoanRequest(LoanRequestID).EmpID;
            if (PayrollBO.CheckPayrollForGivenDate(month, year, EmpID))
            {
                return HRLoanManagerDefs.Loan.PAYROLL_GENETATED;
            }
            //int EmpDeptHod=new Department(new Employees(ID).DepartmentID).HOD;
            //if (EmpDeptHod == null || EmpDeptHod.ToString() == "" || EmpDeptHod == 0)
            //{
            //    return HRLoanManagerDefs.Loan.NODEPTHOD;
            //}
            return String.Empty;
        }
        /// <summary>
        /// Validate GradeName for empty and already exist status.
        /// </summary>
        /// <returns>empty string</returns>
        private String ValidateAction()
        {
            //Loan_RequestBusinessObject AssignEmpLoanBO = new Loan_RequestBusinessObject();

            //if (Convert.ToDouble(new Loan_RequestBusinessObject().GetLoanAmountByLoanIdForAction(_LoanID,_EmpID))>)
            //{
            //    return string.Format(HRLoanManagerDefs.Loan.MINSERVICEPERIODFORLOAN, new Loan(_LoanID).MinServicePeriod);
            //}           
            return String.Empty;
        }

        public static LoanRequest[] GetAllLoanRequest()
        {
            LoanRequest[] LoanRequestsDT = new Loan_RequestBusinessObject().GetAllLoans();

            return LoanRequestsDT;
        }

        public static String CheckPayrollGenerated(int EmpID, int Month,int Year)
        {
            Employee_PayrollBusinessObject PayrollBO = new Employee_PayrollBusinessObject();
            if (!PayrollBO.CheckPayrollForGivenDate(Month.ToString(), Year.ToString(), EmpID))
            {
                return HRLoanManagerDefs.Loan.PAYROLL_NOT_GENETATED;
            }
            return String.Empty;
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
            EmployeeLoanInfo LoanRequest = new EmployeeLoanInfo();

            LoanRequest.ID = _ID;
            LoanRequest.EmpID = _EmpID;
            LoanRequest.Emp = _EmpName;
            LoanRequest.LoanID = _LoanID;
            LoanRequest.Loan = _eLoanName;
            LoanRequest.LoanAmount = _LoanAmount;
            LoanRequest.RepaymentMonths = _RepaymentMonths;
            LoanRequest.MonthlyAmount = _MonthlyAmount;
            LoanRequest.Reason = _Reason;
            LoanRequest.AppliedDate = _AppliedDateTime;
            LoanRequest.Applied = _AppliedTo;
            LoanRequest.HRRemarks = _HRRemarks;
            LoanRequest.Status = _Status;
            LoanRequest.AppliedTo = _appliedToName;
            //LoanRequest.Interest = _Interest;


            return LoanRequest;
        }

        #endregion
    }
    public class EmployeeLoanInfo   //LoanRequestDisplayDetails
    {
        public int ID;
        public int EmpID;
        public String Emp;
        public int LoanID;
        public String Loan;
        public Double LoanAmount;
        public Int16 RepaymentMonths;
        public Double MonthlyAmount;
        //public Double Interest;
        public String Reason;
        public DateTime AppliedDate;
        public int Applied;
        public String HRRemarks;
        public String Status;
        public String AppliedTo;
    }
}
