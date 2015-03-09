using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
    public class UpdateDepartmentRequest
    {
        public int DepartmentID;
        public String Department;
        public int ParentID;
        //public String Description;
        //public bool IsDepartment;
        //public bool IsActive;
        public int UpdateBy;
        public int HOD;
        public bool IsHR;
        public bool IsFinance;

    }
}
