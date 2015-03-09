using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
    public class UpdateLoanActivityRequest
    {
        public int EmpID;
        public int LoanRequestID;
        public int ChangeBy;
        public String Remarks;
        public DateTime LoanStartOn;
    }
}
