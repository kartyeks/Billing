using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
    public class UpdateSalaryAdvanceRepaymentRequest
    {
        public int ID;
        public int EmpID;
        public int AdvanceID;
        public int Amount;
        public int UpdateBy;    
    }
}
