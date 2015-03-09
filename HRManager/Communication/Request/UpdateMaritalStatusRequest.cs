using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
    public class UpdateMaritalStatusRequest
    {
        public int ID;
        public String MaritalStatus;
        public int ModifiedBy;
        public DateTime CreatedDate;
        public bool IsActive;
    }
}
