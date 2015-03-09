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
    public class LoanActivity : JGridDataObject
    {
        private int _ID;
        private int _LoanRequestID;
        private int _Initiator;
        private int _Receiver;
        private String _Status;
        private int _ActivityBy;
        private DateTime _ActivityDate;
        private bool _IsNew;
        private String _InitiatorRemark;
        private String _preComment;
        private String _getLoanStatus;
        private String _DesignationName;
        public String getLoanStatus
        {
            get
            {
                return _getLoanStatus;
            }
            set
            {
                _getLoanStatus = value;
            }
        }
        private String _EmpName;
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
        public String preComment
        {
            get
            {
                return _preComment;
            }
            set
            {
                _preComment = value;
            }
        }
        private String _EmpCode;
        public String EmpCode
        {
            get
            {
                return _EmpCode;
            }
            set
            {
                _EmpCode = value;
            }
        }
        private String _DepartmentName;
        public String DepartmentName
        {
            get
            {
                return _DepartmentName;
            }
            set
            {
                _DepartmentName = value;
            }
        }
       
        public String DesignationName
        {
            get
            {
                return _DesignationName;
            }
            set
            {
                _DesignationName = value;
            }
        }
        private String _LoanName;
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
        private Double _LoanAmount;
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
        private int _RepaymentMonths;
        public int RepaymentMonths
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
        private Double _MaxAmount;
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
        private int _ActualRepaymentMonth;
        public int ActualRepaymentMonth
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
        private String _Reason;
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
        private Double _Interest;
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
        public int Initiator
        {
            get
            {
                return _Initiator;
            }
            set
            {
                _Initiator = value;
            }
        }
        public int Receiver
        {
            get
            {
                return _Receiver;
            }
            set
            {
                _Receiver = value;
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
        public int ActivityBy
        {
            get
            {
                return _ActivityBy;
            }
            set
            {
                _ActivityBy = value;
            }
        }
        public DateTime ActivityDate
        {
            get
            {
                return _ActivityDate;
            }
            set
            {
                _ActivityDate = value;
            }
        }
        public String InitiatorRemark
        {
            get
            {
                return _InitiatorRemark;
            }
            set
            {
                _InitiatorRemark = value;
            }
        }

        /// <summary>
        /// Update the Grade field using Hr_Grade.
        /// </summary>
        /// <param name="Grade">Object of Hr_Grade class</param>
        private void Update(Loan_Activity LoanActivity)
        {
            if (LoanActivity != null)
            {
                _ID = LoanActivity.ID;
                _LoanRequestID = LoanActivity.LoanRequestID;
                _Initiator = LoanActivity.Initiator;
                _Receiver = LoanActivity.Receiver;
                _Status = LoanActivity.Status;
                _ActivityBy = LoanActivity.ActivityBy;
                _ActivityDate = LoanActivity.ActivityDate;
                _InitiatorRemark = LoanActivity.InitiatorRemark;
                
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
        public LoanActivity(Loan_Activity LoanActivity)
        {
            Update(LoanActivity);
        }

        /// <summary>
        /// Consturctor of Grade class.
        /// Update Grade fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains Designation ID</param>
        public LoanActivity(int ID)
        {
            Loan_Activity LoanActivity = new Loan_ActivityBusinessObject().GetLoan_Activity(ID);

            if (LoanActivity == null && ID > 0)
            {
                throw new IRCAException("Invalid loan activity", ID.ToString());
            }

            Update(LoanActivity);
        }
        /// <summary>
        /// Consturctor of Grade class.
        /// Set variables for new Grade.  
        /// </summary>
        public LoanActivity()
        {
            _ID = 0;
            _IsNew = true;

        }
        /// <summary>
        /// Save Grade.If new Grade it add and in case of edit it update the Grade.
        /// </summary>
        /// <returns>empty string</returns>
        private String SaveLoanActivity(Session DBSession)
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
                Loan_Activity LoanActivity = new Loan_Activity();
                LoanActivity.ID = _ID;
                LoanActivity.LoanRequestID = _LoanRequestID;
                LoanActivity.Initiator = _Initiator;
                LoanActivity.Receiver = _Receiver;
                LoanActivity.Status = _Status;
                LoanActivity.ActivityBy = _ActivityBy;
                LoanActivity.ActivityDate = DateTime.Now;
                LoanActivity.InitiatorRemark = _InitiatorRemark;


                if (_IsNew)
                {
                    LoanActivity.ID = new Loan_ActivityBusinessObject(DBSession).Create(LoanActivity);
                }
                else
                {
                    LoanActivity.ID = _ID;
                    new Loan_ActivityBusinessObject(DBSession).Update(LoanActivity);
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

            return SaveLoanActivity(DBSession);
        }
        /// <summary>
        /// Validate GradeName for empty and already exist status.
        /// </summary>
        /// <returns>empty string</returns>
        private String Validate()
        {
            Loan_ActivityBusinessObject AssignEmpLoanBO = new Loan_ActivityBusinessObject();

            return String.Empty;
        }

        public static LoanActivity[] GetProcessedLoan(int EmpID)
        {
            EmployeeOccupationDetails CurrDesig = new Master_EmployeesBusinessObject().GetDesignationEmployees(EmpID);
            LoanActivity[] LoanActivityDT;
            if (new Designation(CurrDesig.DesignationID).DesignationName.Trim() == "MD" || new Designation(CurrDesig.DesignationID).DesignationName.Trim() == "CHAIRMAN & MANAGING DIRECTOR" || new Designation(CurrDesig.DesignationID).DesignationName.Trim() == "MANAGING DIRECTOR" || new Designation(CurrDesig.DesignationID).DesignationName.Trim() == "COO" || new Designation(CurrDesig.DesignationID).DesignationName.Trim() == "CHIEF OPERATING OFFICER")
            {
                LoanActivityDT = new Loan_ActivityBusinessObject().GetProcessedLoanForCOO();
            }
            else
            {
                
                //int DeptID = new EmployeePersonalDetails(EmpID).DepartmentID;
                int DeptID = new RoleMaster(EmpID).ID;
                LoanActivityDT = new Loan_ActivityBusinessObject().GetProcessedLoan(DeptID);
            }

            return LoanActivityDT;
        }
        public static LoanActivity[] GetRequestedLoan(int EmpID)
        {
            EmployeeOccupationDetails CurrDesig = new Master_EmployeesBusinessObject().GetDesignationEmployees(EmpID);
            LoanActivity[] LoanActivityDT;
            if (new Designation(CurrDesig.DesignationID).DesignationName.Trim() == "MD" || new Designation(CurrDesig.DesignationID).DesignationName.Trim() == "CHAIRMAN & MANAGING DIRECTOR" || new Designation(CurrDesig.DesignationID).DesignationName.Trim() == "MANAGING DIRECTOR" || new Designation(CurrDesig.DesignationID).DesignationName.Trim() == "COO" || new Designation(CurrDesig.DesignationID).DesignationName.Trim() == "CHIEF OPERATING OFFICER")
            {
                LoanActivityDT = new Loan_ActivityBusinessObject().GetRequestedLoanForCOO();
            }
            else
            {
                //int DeptID = new Master_EmployeesBusinessObject().GetDesignationRoleIDEmployees(EmpID);
                //int DeptID = new RoleMaster(EmpID).ID;
                
                int DeptID1 = new Master_EmployeesBusinessObject().GetMaangerIDEmployees(EmpID);
                LoanActivityDT = new Loan_ActivityBusinessObject().GetRequestedLoan(DeptID1);
                if (DeptID1 != 0)
                {
                    int DeptID = new Master_EmployeesBusinessObject().GetMangerIDEmployeesfromLoanrequest(EmpID);
                    if (DeptID == 0)
                    {
                        int DepID = new Master_EmployeesBusinessObject().GetAllLoanrequestDetails(EmpID);
                        LoanActivityDT = new Loan_ActivityBusinessObject().GetRequestedLoanDetails(DeptID);
                    }
                    else
                    {
                        LoanActivityDT = new Loan_ActivityBusinessObject().GetRequestedLoanDetails(DeptID);
                    }
                }
            }

            return LoanActivityDT;
        }

        #region JGridDataObject Members

        public object GetGridData()
        {
            //String getLoanStatus="";
            LoanActivityInfo LoanActivity = new LoanActivityInfo();

            LoanActivity.ID = _ID;
            LoanActivity.LoanRequestID = _LoanRequestID;
            LoanActivity.EmpName = _EmpName;
            LoanActivity.EmpCode = _EmpCode;
            LoanActivity.DepartmentName = _DepartmentName;
            LoanActivity.LoanName = _LoanName;
            LoanActivity.LoanAmount = _LoanAmount;
            LoanActivity.RepaymentMonths = _RepaymentMonths;
            LoanActivity.Status = _Status;
            LoanActivity.MaxAmount = _MaxAmount;
            LoanActivity.ActualRepaymentMonth = _ActualRepaymentMonth;
            LoanActivity.Reason = _Reason;
            LoanActivity.Interest = _Interest;
            LoanActivity.preComment = _preComment;
            LoanActivity.RequestedOn = new LoanRequest(_LoanRequestID).AppliedDateTime;
            String setLoanStatus = "";
            if (_getLoanStatus == "New") setLoanStatus = "New";
            else if (_getLoanStatus == "CHK") setLoanStatus = "Pending for HR Comments";
            else if (_getLoanStatus == "COO") setLoanStatus = "Pending for Higher Approval";
            else if (_getLoanStatus == "CLS") setLoanStatus = "Disbursed";
            else if (_getLoanStatus == "RRE") setLoanStatus = "Pending for HOD Approval";
            else if (_getLoanStatus == "REJ") setLoanStatus = "Rejected";
            else if (_getLoanStatus == "APP") setLoanStatus = "In Process";
            else setLoanStatus = _getLoanStatus;
            LoanActivity.LoanStatus = setLoanStatus;

            return LoanActivity;
        }

        #endregion
    }
    public class LoanActivityInfo   //LoanRequestDisplayDetails
    {
        public int ID;
        public int LoanRequestID;
        public String EmpName;
        public String EmpCode;
        public String DepartmentName;
        public String LoanName;
        public Double LoanAmount;
        public DateTime RequestedOn;
        public int RepaymentMonths;
        public String Status;
        public Double MaxAmount;
        public int ActualRepaymentMonth;
        public String Reason;
        public Double Interest;
        public string preComment;
        public string LoanStatus;
    }
}