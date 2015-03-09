using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
    public class UpdateInterviewStatus
    {
        public int ID;
        public int CandidateID;
        public int TeamID;
        public String CandidateStatus;
        public String TechnicalPanelIDs;
        public int InterviewTypeID;
        public DateTime Date1Time1;
        public String Time1;
        public DateTime Date2Time2;
        public String Time2;
        public int UpdatedBy;
        public DateTime UpdatedDateTime;
        public bool IsCandidateAvail;
        public String RejectionRemarks;
        public String RoleName;
    }
}
