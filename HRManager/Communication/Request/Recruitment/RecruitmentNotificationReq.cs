using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
    public class ManagerApporRejRequest 
    {
        public int CandidateID;
        public String SelectionType;
        public String ResumePath;
    }

    public class PrefferedDateTime
    {
        public int InterviewStatusID;
        public int ManagerID;
        public String RoleName;
        public int InterviewTypeID;
    }

    public class CandidateAvailability
    {
        public int InterviewStatusID;
        public int ManagerID;
        public bool IsCandAvail;
        public int InterviewTypeID;
        public String Role;
    }

    public class InterviewResultUpdate
    {
        public int CandidateID;
        public int ManagerID; public String LoginType; public int IntStatusID; public String Role;
    }
}
