using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
    public class UpdatePermissionRequest
    {
        public int FunctionID;
        public int RoleID;
        public bool Apply;
        public bool Approvals;
        public bool View;
        public int UpdateBy;
        public string FunctionName;
        public int EmployeeID;
    }
}
