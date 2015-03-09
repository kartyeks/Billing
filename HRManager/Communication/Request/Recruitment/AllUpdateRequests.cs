using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
    public class CandidateGridReq
    {
        public int LoggedEmpID;
        public int LoggedUserID;
        public String RoleName;
        public String RecruitmentLoggerType;
    }

    public class BeforeLogCheckReq
    {
        public int ID;
        public int LoggedEmpID;
        public int LoggedUserID;
        public String RoleName;
        public String RecruitmentLoggerType;
    }
}
