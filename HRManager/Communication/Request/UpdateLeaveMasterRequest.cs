using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
    public class UpdateLeaveMasterRequest
    {
        public int ID;
        public String LeaveType;
        public bool IsActive;
        public int UpdateBy;

    }
}
