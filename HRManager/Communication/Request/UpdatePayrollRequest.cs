using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
   public class UpdatePayrollRequest
    {
        public int ID;
        public int BranchID;
        public int LocationID;
        public int DepartmentID;
        public bool IsPreviousLOP;
        public int Month;
        public int Year;
        public int UpdatedBy;
        public String UniqueID;
        public String SessionID;
        public bool IsAnualbenifitsincluded;
        public int EmpID;
        public bool IsOneMonthBasic;
        public double value;
    }
}
