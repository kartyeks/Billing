using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
    public class UpdateLeave
    {
        public int ID;
        public int EmpID;
        public int LeaveID;
        public DateTime FromDate;
        public DateTime ToDate;
        public string Reason;
        public DateTime AppliedDateTime;
        public int ManagerID;   
        public Double DaysCount;
        public int UpdateBy;
        public String Status;
        public bool FromDateHalfDay;
        public bool ToDateHalfDay;
    }

    public class UpdateLeaveApprovalRequest
    {
        public int ID;
        public int LeaveRequestID;
        public int ProcessedBy;           
        public String Status;
        public String Comment;
    }
    
}
