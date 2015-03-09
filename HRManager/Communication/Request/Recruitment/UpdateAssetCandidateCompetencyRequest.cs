using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
    public class UpdateAssetCandidateCompetencyRequest
    {
        public int ID;
        public String CompetencyName;
        public String Description;
        public int ModifiedBy;
        public DateTime CreatedDate;
        public bool IsActive;
    }
}
