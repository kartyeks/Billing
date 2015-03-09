using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;

namespace HRManager.DTOEXT
{
    public class Leave_RequestEXT : Leave_Request
    {
        public string Title;
        public String EmployeeName;
        public String ManagerName;
    }
   
    public class LeaveCalenderEXT
    {
        public string LeaveType;
        public string Status;
        public Double DaysCount;
        public string Manager;
        public string Reason;       
    }

    public class LeaveOverViewEXT
    {
        public int ID;
        public String LeaveType;
        public Double TotalLeave;
        public double UsedLeave;
        public Double BalanceLeave;
        public Double LeaveRequested;
        public String EmployeeName;
        public int LeaveID;
    }
    public class LeaveRequestCalenderEXT
    {
        //public int ID;
        //public int EmpID;
        //public string Title;
        //public DateTime FromDate;
        //public DateTime ToDate;
        public int id;
        public String title;
        public DateTime start;
        public DateTime end;
    }
}
