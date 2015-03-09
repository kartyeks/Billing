using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
    public class UpdateLoanRequestRequest
    {
          public int ID;
          public int EmpID;
          public int LoanID;
          public Double LoanAmount;
          public Int16 RepaymentMonths;
          public Double MonthlyAmount;
          public String Reason;
          public DateTime AppliedDateTime;
          public int AppliedTo;
          public String HRRemarks;
          public String Status;
          public String UpdateBy;
          public int ChangedBy;

          public Double MaxAmount;
          public Double Interest;
          public int ActualRepaymentMonth;


    }
}
