using System;

public class LoanAppCommands : WebAppCommands
{    

    #region Assign Loan To employee 

    //Assing Emp To Loan
    public static readonly String ASSIGNEMPLOAN_DETAILS = "ASSIGNEMPLOAN_DETAILS";
    public static readonly String UPDATE_ASSIGNEMPLOAN = "UPDATE_ASSIGNEMPLOAN";
    public static readonly String DELETE_ASSIGNEMPLOAN = "DELETE_ASSIGNEMPLOAN";
    public static readonly String CHECK_LOAN_START_DATE = "CHECK_LOAN_START_DATE";
    
    
    #endregion

    #region Loan Request
    //Loan Request
    public static readonly String LOANREQUEST_DETAILS = "LOANREQUEST_DETAILS";
    public static readonly String LOANREQUEST_APPLIEDTO_DETAILS = "LOANREQUEST_APPLIEDTO_DETAILS";
    public static readonly String PLACE_LOANREQUEST = "PLACE_LOANREQUEST";
    public static readonly String ACCEPTLOANREQUEST_DETAILS = "ACCEPTLOANREQUEST_DETAILS";
    public static readonly String REJECTLOANREQUEST_DETAILS = "REJECTLOANREQUEST_DETAILS";
    public static readonly String CHECK_EGIBLITY_LOAN_REQUEST = "CHECK_EGIBLITY_LOAN_REQUEST";
    public static readonly String CHECK_LOAN_DEPTHOD = "CHECK_LOAN_DEPTHOD";

    public static readonly String LOANREQUEST_NEW_STATUS = "NEW";
    public static readonly String LOANREQUEST_ACCEPTED_STATUS = "ACC";
    public static readonly String LOANREQUEST_REJECTED_STATUS = "REJ";

    #endregion
    
    #region Loan Repayment 

    //Loan Repayment
    public static readonly String LOANREPAYMENT_DETAILS = "LOANREPAYMENT_DETAILS";
    public static readonly String GET_PENDING_LOAN_EMPWISE = "GET_PENDING_LOAN_EMPWISE";
    public static readonly String UPDATE_LOAN_REPAYMENT = "UPDATE_LOAN_REPAYMENT";
    
    #endregion

    #region Salary Advance
    public static readonly String SALARYADVANCE_DETAILS = "SALARYADVANCE_DETAILS";
    public static readonly String SALARYADVANCE_APPLIEDTO_DETAILS = "SALARYADVANCE_APPLIEDTO_DETAILS";
    public static readonly String PLACE_SALARYADVANCE = "PLACE_SALARYADVANCE";
    public static readonly String ACCEPTSALARYADVANCE_DETAILS = "ACCEPTSALARYADVANCE_DETAILS";
    public static readonly String REJECTSALARYADVANCE_DETAILS = "REJECTSALARYADVANCE_DETAILS";

    public static readonly String SALARYADVANCE_NEW_STATUS = "NEW";
    public static readonly String SALARYADVANCE_ACCEPTED_STATUS = "ACC";
    public static readonly String SALARYADVANCE_REJECTED_STATUS = "REJ";
    #endregion 

    #region Salary Advance Repayment

    public static readonly String GET_PENDING_SALARY_ADVANCE_EMPWISE = "GET_PENDING_SALARY_ADVANCE_EMPWISE";
    public static readonly String UPDATE_SALARYADVANCE_REPAYMENT = "UPDATE_SALARYADVANCE_REPAYMENT";

    #endregion

    #region Advance Type
        public static readonly String ADVANCE_TYPE_DETAILS = "ADVANCE_TYPE_DETAILS";
        public static readonly String UPDATE_ADVANCE_TYPE = "UPDATE_ADVANCE_TYPE";
        public static readonly String ACTIVATE_ADVANCE_TYPE = "ACTIVATE_ADVANCE_TYPE";
        public static readonly String DEACTIVATE_ADVANCE_TYPE = "DEACTIVATE_ADVANCE_TYPE";
        public static readonly String INACTIVE_ADVANCE_TYPE = "INACTIVE_ADVANCE_TYPE";
        public static readonly String COMBOADVANCETYPE_DETAILS = "COMBOADVANCETYPE_DETAILS";
    #endregion 

        #region Loan Activity
        public static readonly String NEW = "NEW";
        public static readonly String FORWARDTOHRCHECK = "CHK";
        public static readonly String REVERTREPORT = "RRE";
        public static readonly String APPROVED = "APP";
        public static readonly String REJECTED = "REJ";
        public static readonly String CLOSE = "CLS";
        public static readonly String FORWARDTOFINANCE = "APP";
        public static readonly String COOAPPROVAL = "COO";
        public static readonly String MDAPPROVAL = "MDA";

        public static readonly String APPROVEDBYADMINHR = "APP";

        public static readonly String REQUESTED_LOAN = "REQUESTED_LOAN";
        public static readonly String PROCESSED_LOAN = "PROCESSED_LOAN";
    
        public static readonly String APPROVE_AND_FORWARD_TO_HR = "APPROVE_AND_FORWARD_TO_HR";
        public static readonly String APPROVE_AND_FORWARD_TO_FINANCE = "APPROVE_AND_FORWARD_TO_FINANCE";
        public static readonly String PASS_LOAN_REQUEST = "PASS_LOAN_REQUEST";
        public static readonly String REJECT_LOAN_REQUEST = "REJECT_LOAN_REQUEST";
        public static readonly String CHECK_REPORT_HOD = "CHECK_REPORT_HOD";
        public static readonly String CHECK_REPORT_COO = "CHECK_REPORT_COO";
        public static readonly String MD_APPROVAL = "MDA";
    
        #endregion 




}