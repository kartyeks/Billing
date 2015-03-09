using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
    public class UpdateLoanRepaymentRequest
    {
        public int ID;
        public int EmpID;
        public int LoanID;
        public int LoanRequestID;
        public int Amount;
        public int UpdateBy;    
    }
}
