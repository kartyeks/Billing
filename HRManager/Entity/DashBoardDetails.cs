using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HRManager.BusinessObjects;

namespace HRManager.Entity
{
    public class DashBoardDetails
    {
        public String LeaveType ;
        public double TotalLeave;
        public int UsedLeave;
        public double BalanceLeave;
        public String RequestedTo;
        public String FromDate;
        public String ToDate;
        public double LeaveCount;
        public String Status;

    }

    public class NewDashBoardDetails
    {
        public string CandidateName;
        public string TeamName;
        public string ManagerName;
        public string Status;
    }
    public class NewEmployeeAppraisal
    {
        public string Year;
        public string OldDesignation;
        public string NewDesignation;
        public string OldCTC;
        public string NewCTC;
    }
    public class NewMonthlyDetails
    {
        public string HolidayName;
        public string HolidayDate;
    }
    public class NewEmployeeExitInThreeMonths
    {
        public string EmployeeCode;
        public string EmployeeName;
        public string Designation;
        public string Team;
        public string TypeOfExit;
        public string ExitDate;
    }
    public class NewCurrentMonthLeaveStatus
    {
        public int LeaveRequest;
        public int LeaveApproved;
        public int LeaveRejected;
    }
    public class AttdendanceDasshboard
    {
        public String Month;
        public double MonthlyDays;
        public double LeaveCount;
        public double WorkedDays;
    }
    public class NewCandidateReferredCount
    {
        public int ConsultantCount;
        public int HRCount;
        public int EmpCount;
    }
    public class OfferIssuedDashboard
    {
        public string Candidate;
        public string JoiningDate;
        public string Designation;
    }

    public class InterviewScheduledDashboard
    {
        public Int64 SlNo;
        public string CandidateName;
    }
}
