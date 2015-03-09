using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
    public class UpdateLoanRequest
    {
        public int ID;
        public String LoanName;
        public double MaxAmount;
        public double Interest;
        //public int RepaymentMonth;
        public bool IsActive;
        public int EmpID;
        public int LoanID;
        public int GradeID;
        public int UpdateBy;
        public double  MaxBasicPercentage;
        public int MinServicePeriod;
        public int MinLeaveBalance;
        public int RemainingService;
        public string Installment;
        public DateTime LoanStartDate;
        public int LoanRequestID;



    }
}


