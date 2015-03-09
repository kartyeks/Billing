using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
    public class UpdateSalaryAdvanceRequest
    {
        public int ID;
        public int AdvanceTypeID;
        public int EmpID;
        public Double AdvanceAmount;
        public Int16 RepaymentMonths;
        public Double MonthlyAmount;
        public String Reason;
        public DateTime AppliedDateTime;
        public int AppliedTo;
        public String HRRemarks;
        public String Status;
        public int UpdateBy;
        public int ChangedBy;
    }
}


