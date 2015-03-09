using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Entity.Recruitment
{
    public class CandidateStatusDescription
    {
        #region Round1

        public static readonly String NewCandidate = "NEW";

        public static readonly String ManagerApprove = "APM";
        public static readonly String ManagerReject = "RJM";

        public static readonly String InterviewScheduled = "SCH";

        public static readonly String CandidateUnAvail = "UAL";
        public static readonly String CandidateAvail = "AVL";

        public static readonly String ClearedFirst = "CL1";
        public static readonly String RejectFirst = "RJ1";

        public static readonly String ManagerApproveFULL = "Manager Approved";
        public static readonly String ManagerRejectFULL = "Manager Rejected";

        public static readonly String InterviewScheduledFULL = "Interview Scheduled";

        public static readonly String CandidateUnAvailFULL = "Candidate UnAvailable for 1st Round";
        public static readonly String CandidateAvailFULL = "Candidate Available for 1st Round";

        public static readonly String ClearedFirstFULL = "First Round Cleared";
        public static readonly String RejectFirstFULL = "First Round Rejected";
        
        #endregion

        #region Round2

        public static readonly String ManagerApprove2 = "AM2";
        public static readonly String ManagerReject2 = "RM2";

        public static readonly String InterviewScheduled2 = "SH2";

        public static readonly String CandidateUnAvail2 = "UL2";
        public static readonly String CandidateAvail2 = "AL2";

        public static readonly String InterviewScheduled2FULL = "2nd Round Interview Scheduled";

        public static readonly String ManagerApprove2FULL = "Manager Approved 2nd Round";
        public static readonly String ManagerReject2FULL = "Manager Rejected 2nd Round";

        public static readonly String CandidateUnAvail2FULL = "Candidate UnAvailable for Round 2";
        public static readonly String CandidateAvail2FULL = "Candidate Available for Round 2";

        public static readonly String ClearedSecond = "CL2";
        public static readonly String RejectSecond = "RJ2";

        public static readonly String ClearedSecondFULL = "Second Round Cleared";
        public static readonly String RejectSecondFULL = "Second Round Rejected";

        #endregion

        #region HRRound

        public static readonly String HRScheduled = "SH3";

        public static readonly String HRScheduledFULL = "HR Round Scheduled";

        public static readonly String CandidateUnAvail3 = "UL3";
        public static readonly String CandidateAvail3 = "AL3";

        public static readonly String CandidateUnAvail3FULL = "Candidate UnAvailable for HR Round";
        public static readonly String CandidateAvail3FULL = "Candidate Available  for HR Round";

        public static readonly String ClearedHR = "CL3";
        public static readonly String RejectHR = "RJ3";

        public static readonly String ClearedHRFULL = "HR Round Cleared";
        public static readonly String RejectHRFULL = "HR Round Rejected";
        
        #endregion

        #region Offer Letter

        public static readonly String SalaryFixed = "FIX";
        public static readonly String SalaryFixedFULL = "Salary Fixed";

        public static readonly String OfferIssued = "ISU";
        public static readonly String OfferIssuedFULL = "Offer Issued";

        #endregion

        public String FullStatus(String StatusCode)
        {
            String msg = String.Empty;
            if (StatusCode == ManagerApprove)
                msg = ManagerApproveFULL;

            else if (StatusCode == ManagerReject)
                msg = ManagerRejectFULL;

            else if (StatusCode == InterviewScheduled)
                msg = InterviewScheduledFULL;

            else if (StatusCode == CandidateUnAvail)
                msg = CandidateUnAvailFULL;

            else if (StatusCode == CandidateAvail)
                msg = CandidateAvailFULL;

            else if (StatusCode == ClearedFirst)
                msg = ClearedFirstFULL;

            else if (StatusCode == RejectFirst)
                msg = RejectFirstFULL;

            else if (StatusCode == ManagerApprove2)
                msg = ManagerApprove2FULL;

            else if (StatusCode == ManagerReject2)
                msg = ManagerReject2FULL;

            else if (StatusCode == InterviewScheduled2)
                msg = InterviewScheduled2FULL;

            else if (StatusCode == CandidateUnAvail2)
                msg = CandidateUnAvail2FULL;

            else if (StatusCode == CandidateAvail2)
                msg = CandidateAvail2FULL;

            else if (StatusCode == ClearedSecond)
                msg = ClearedSecondFULL;

            else if (StatusCode == RejectSecond)
                msg = RejectSecondFULL;

            else if (StatusCode == HRScheduled)
                msg = HRScheduledFULL;

            else if (StatusCode == CandidateUnAvail3)
                msg = CandidateUnAvail3FULL;

            else if (StatusCode == CandidateAvail3)
                msg = CandidateAvail3FULL;

            else if (StatusCode == ClearedHR)
                msg = ClearedHRFULL;

            else if (StatusCode == RejectHR)
                msg = RejectHRFULL;

            else if (StatusCode == SalaryFixed)
                msg = SalaryFixedFULL;

            else if (StatusCode == OfferIssued)
                msg = OfferIssuedFULL;

            else
                msg = NewCandidate;
            
            return msg;
        }
    }
}
