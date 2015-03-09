using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS91.Services;

namespace HRManager
{
    public class HRLoanManagerDefs
    {
        public class Loan
        {
            #region Loan
            public static readonly String ASSIGNEMPLOAN_UPDATE_SUCCESS = "Employee Loan details updated successfully";
            public static readonly String ASSIGNEMPLOAN_ADDED_SUCCESS = "Employee Loan details added successfully";
            public static readonly String ASSIGNEMPLOAN_UPDATE_FAILURE = "Error on updating the Employee Loan info";
            public static readonly String ASSIGNEMPLOAN_DELETE_SUCCESS = "Employee Loan details deleted successfully";

            public static readonly String LOANREQUEST_UPDATE_SUCCESS = "Loan Request updated successfully";
            public static readonly String LOANREQUEST_ADDED_SUCCESS = "Loan Request sent successfully";
            public static readonly String LOANREQUEST_UPDATE_FAILURE = "Error on updating the Loan Request info";
            public static readonly String LOANREQUEST_DELETE_SUCCESS = "Loan Request deleted successfully";

            public static readonly String LOANREQUEST_ACCEPT_FAILURE = "Error on accepting the Loan Request info";
            public static readonly String LOANREQUEST_ACCEPT_SUCCESS = "Loan Request accepted successfully";

            public static readonly String LOANREQUEST_REJECT_FAILURE = "Error on rejecting the Loan Request info";
            public static readonly String LOANREQUEST_REJECT_SUCCESS = "Loan Request rejected successfully";

            public static readonly String MINSERVICEPERIODFORLOAN = "For applying loan request atleast {0} Years of continuous service with the Company at the time of applying.";
            public static readonly String REMAININGSERVICEFORLOAN = "For applying loan request atleast {0} Years of service remaining with the Company from time of applying.";
            public static readonly String MINLEAVEBALANCEFORLOAN = "Your's Earned Leave credit balance should be more than {0} days in your account at the time of applying the loan.";
            public static readonly String PENDINGPREVIOUSLOAN = "You Cannot apply for another loan till the competion of a further period of 1 year from the closure/completion of repayment of the last loan taken.";
            public static readonly String PENDINGREQUESTLOAN = "Your previous request is under processing,cannot apply for another loan.";
            public static readonly String ONLY_PERMANENT_EMP_CAN_APPLY = "Only Permanent Employee can apply for Loan";
            public static readonly String UNDERPROCESSPREVIOUSLOAN = "You Cannot apply for another loan.Your Previous Requested Loan is under Process";

            public static readonly String FORWARDTOHR = "Loan Approved and Forwarded to HR";
            public static readonly String FORWARDTOFINANCE = "Loan Approved and Forwarded to Finance HOD";
            public static readonly String PASSANDCLOSE = "Loan Passed and Closed Successfully";
            public static readonly String LOANREQUESTREJECT = "Loan Rejected Successfully";
            public static readonly String FORWARDTOHOD = "Forwarded to HOD Successfully";
            public static readonly String FORWARDTOCOO = "Forwarded to COO/MD Successfully";
            public static readonly String FORWARDTOMD = "Forwarded to MD Successfully";
            public static readonly String LOANAPPROVEDBYHOD = "Loan approved Successfully";

            public static readonly String ELIGIBLE = "Eligible For Loan Request";
            public static readonly String NOT_ELIGIBLE = "Not eligible For Loan Request";
            public static readonly String NODEPTHOD = "No HOD Assign to your deparment.Please Contact to HR.";
            public static readonly String PAYROLL_GENETATED = "Payroll is generated for this month/year";
            public static readonly String PAYROLL_NOT_GENETATED = "Payroll is not generated for this month/year";


            #endregion
        }
        public class SalaryAdvance
        {
            public static readonly String SALARYADVANCE_ADDED_SUCCESS = "Salary Advance details added successfully";
            public static readonly String SALARYADVANCE_UPDATED_SUCCESS = "Salary Advance details updated successfully";

            public static readonly String SALARYADVANCE_ACCEPT_FAILURE = "Error on accepting the Salary Advance info";
            public static readonly String SALARYADVANCE_ACCEPT_SUCCESS = "Salary Advance accepted successfully";

            public static readonly String SALARYADVANCE_REJECT_FAILURE = "Error on rejecting the Salary Advance info";
            public static readonly String SALARYADVANCE_REJECT_SUCCESS = "Salary Advance rejected successfully";

            public static readonly String SALARYADVANCE_EXISTS = "This Salary advance type already requested,Waiting for apporval";
        }
        public class LoanRepayment
        {
            public static readonly String LOANREPAYMENT_ADDED_SUCCESS = "Loan Repayment details Added successfully";

        }
        public class SalaryAdvanceRepayment
        {
            public static readonly String SALARYADVANCEREPAYMENT_ADDED_SUCCESS = "Salary Advance Repayment details Added successfully";
            public static readonly String SALARYADVANCEREPAYMENT_ADDED_FAILURE = "Error on adding the Salary Advance repayment details";

        }
        public class AdvanceType
        {
            public static readonly String ADVANCE_TYPE_UPDATE_SUCCESS = "AdvanceType details updated successfully";
            public static readonly String ADVANCE_TYPE_ADDED_SUCCESS = "AdvanceType details added successfully";

            public static readonly String ADVANCE_TYPE_ADDED_FAILURE = "Error on accepting the AdvanceType info";
            public static readonly String ACTIVATE_SUCCESS = "Advance Type activated successfully";

            public static readonly String DEACTIVATE_SUCCESS = "Advance Type deactivated successfully";
            public static readonly String ADVANCETYPE_EXISTS = "The given Advance Type already exists";
            public static readonly String EMPTY_ADVANCETYPE = "Advance type is inactive or no data present";
            public static readonly String NO_ADVANCETYPE = "Advance type is inactive or no data present";

            public static readonly String ADVANCETYPE_REFERED = "The given advance type is referred already";

        }


    }
}
