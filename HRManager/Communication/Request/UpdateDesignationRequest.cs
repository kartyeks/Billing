using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
    public class UpdateDesignationRequest
    {
        public int DesignationID;
        public String Designation;
        public int ParentDesignationID;
        public int LeaveAppliedTo;
        public int RoleID;
        public String Description;
        public bool IsActive;
        public int UpdateBy;
    }
}
