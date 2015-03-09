using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
    //public class UpdateRoleRequest
    //{
    //    public int RoleID;
    //    public String Role;
    //    public String Description;
    //    public bool IsActive;
    //    public int UpdatedBy;
    //    public string Reports;

    //    public string Permissions;
    //}
    public class UpdateRoleRequest
    {
        public int RoleID;
        public String Role;
        public String Description;
        public bool IsActive;
        public int UpdatedBy;
        public string Reports;
        public string Permissions;
        public int[] JobTitleIDs;
    }
}
