using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;

namespace HRManager.DTOEXT.Recruitment
{
    public class Candidate_Hired_SalaryEXT : Candidate_Hired_Salary
    {
        public String FirstName;
        public String MiddleName;
        public String LastName;
        public String CandidateStatus;
        public DateTime IssueOfferredDate;
    }
}
