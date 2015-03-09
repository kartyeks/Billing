using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;

namespace HRManager.DTOEXT.Recruitment
{
    public class Candidate_Interview_StatusEXT : Candidate_Interview_Status
    {
        public String CandidateName;
        public String TeamName;
        public String ManagerName;
        public int InterviewTypeID;
        public String InterviewType;
        public int TechnicalPanelId;
        public String TechPanelName;
    }
}
