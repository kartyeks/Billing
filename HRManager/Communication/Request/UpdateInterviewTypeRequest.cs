using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
    public class UpdateInterviewTypeRequest
    {
        public int ID;
        public String InterviewType;
        public String Description;
        public int ModifiedBy;
        public DateTime CreatedDate;
        public bool IsActive;
    }
}
