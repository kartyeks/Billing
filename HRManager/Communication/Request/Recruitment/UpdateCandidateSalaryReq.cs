using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
    public class UpdateCandidateSalaryReq
    {
        public int ID;
        public int CandidateID;
        public DateTime JoiningDate;
        public double CTC;
        public int ESOP;
    }

    public class InterviewDateCheck
    {
        public int CanidateID;
        public DateTime InterviewDateFromPage;
    }
}
