using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.Entity;
using IS91.Services.DataBlock;
using System.Data;

namespace HRManager.BusinessObjects
{
    public class Dashboard_Display_DetailsBusinessObject
    {
        public static DashBoardDetails[] GetDashBoardDetails(int EmpID)
        {
            const String Qry = "GetDashBoardLeaveDetails {0}";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            var exQry = new ExecutionQuery { Query = string.Format(Qry, EmpID) };
            DataTable dt = EE.ExecuteDataTable(exQry);
            DashBoardDetails[] DTO = new DashBoardDetails[dt.Rows.Count];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < DTO.Length; i++)
                {
                    DTO[i] = new DashBoardDetails();
                    DTO[i].LeaveType = (string)dt.Rows[i]["LeaveType"];
                    DTO[i].TotalLeave = (double)dt.Rows[i]["TotalLeave"];
                    DTO[i].UsedLeave = (int)dt.Rows[i]["UsedLeave"];
                    DTO[i].BalanceLeave = (double)dt.Rows[i]["BalanceLeave"];
                    DTO[i].RequestedTo = (string)dt.Rows[i]["RequestedTo"];
                    DTO[i].FromDate = (String)dt.Rows[i]["FromDate"];
                    DTO[i].ToDate = (String)dt.Rows[i]["ToDate"];
                    DTO[i].LeaveCount = (double)dt.Rows[i]["DaysCount"];
                    DTO[i].Status = (String)dt.Rows[i]["Status"];
                }
            }
            else
            {
                DTO = null;
            }

            return DTO;
        }

        public static NewDashBoardDetails[] CANDIDATEREFERREDSTATUS(int EmpID)
        {
            const string query = "sp_Dashboard_CandidateCreation {0}";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            var ExQry = new ExecutionQuery { Query = string.Format(query, EmpID) };
            DataTable dt = EE.ExecuteDataTable(ExQry);
            NewDashBoardDetails[] DTO = new NewDashBoardDetails[dt.Rows.Count];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < DTO.Length; i++)
                {
                    DTO[i] = new NewDashBoardDetails();
                    DTO[i].CandidateName = (string)dt.Rows[i]["CandidateName"];
                    DTO[i].TeamName = (string)dt.Rows[i]["TeamName"];
                    DTO[i].ManagerName = (string)dt.Rows[i]["ManagerName"];
                    DTO[i].Status = (string)dt.Rows[i]["Status"];
                }
                return DTO;
            }
            else
                return null;
        }

        public static NewEmployeeAppraisal[] EmployeeAppraisal(int EmpID)
        {
            const string query = "sp_Dashboard_EmpAppraisalDetails {0}";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            var ExQry = new ExecutionQuery { Query = string.Format(query, EmpID) };
            DataTable dt = EE.ExecuteDataTable(ExQry);
            NewEmployeeAppraisal[] DTO = new NewEmployeeAppraisal[dt.Rows.Count];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < DTO.Length; i++)
                {
                    DTO[i] = new NewEmployeeAppraisal();
                    DTO[i].Year = dt.Rows[i]["Year"].ToString();
                    DTO[i].OldDesignation = (string)dt.Rows[i]["OldDesignation"];
                    DTO[i].NewDesignation = (string)dt.Rows[i]["NewDesignation"];
                    DTO[i].OldCTC = dt.Rows[i]["OldCTC"].ToString();
                    DTO[i].NewCTC = dt.Rows[i]["NewCTC"].ToString();
                }
                return DTO;
            }
            else
                return null;
        }

        public static NewMonthlyDetails[] MonthlyHolidays()
        {
            const string query = "sp_Dashboard_MonthlyHoildays ";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            var ExQry = new ExecutionQuery { Query = query };
            DataTable dt = EE.ExecuteDataTable(ExQry);
            NewMonthlyDetails[] DTO = new NewMonthlyDetails[dt.Rows.Count];
            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new NewMonthlyDetails();
                DTO[i].HolidayName = (string)dt.Rows[i]["HolidayName"];
                DTO[i].HolidayDate = (string)dt.Rows[i]["HolidayDate"];
            }
            return DTO;
        }

        public static NewEmployeeExitInThreeMonths[] EMPLOYEEEXITINTHREEMONTHS()
        {
            const string query = "EmployeeExit_in_last_three_months ";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            var ExQry = new ExecutionQuery { Query = query };
            DataTable dt = EE.ExecuteDataTable(ExQry);
            NewEmployeeExitInThreeMonths[] DTO = new NewEmployeeExitInThreeMonths[dt.Rows.Count];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < DTO.Length; i++)
                {
                    DTO[i] = new NewEmployeeExitInThreeMonths();
                    DTO[i].EmployeeCode = (string)dt.Rows[i]["EmployeeCode"];
                    DTO[i].EmployeeName = (string)dt.Rows[i]["EmployeeName"];
                    DTO[i].Designation = (string)dt.Rows[i]["Designation"];
                    DTO[i].Team = (string)dt.Rows[i]["Team"];
                    DTO[i].TypeOfExit = (string)dt.Rows[i]["TypeOfExit"];
                    DTO[i].ExitDate = ((DateTime)dt.Rows[i]["ExitDate"]).ToString("dd/MM/yyyy");
                }
                return DTO;
            }
            else
                return null;
        }

        public static NewCandidateReferredCount[] CANDIDATEREFERREDCOUNT()
        {
            const string query = "sp_Dashboard_Candidate_ReferredCount ";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            var ExQry = new ExecutionQuery { Query = query };
            DataTable dt = EE.ExecuteDataTable(ExQry);
            NewCandidateReferredCount[] DTO = new NewCandidateReferredCount[dt.Rows.Count];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < DTO.Length; i++)
                {
                    DTO[i] = new NewCandidateReferredCount();
                    DTO[i].ConsultantCount = (int)dt.Rows[i]["ConsultantCount"];
                    DTO[i].HRCount = (int)dt.Rows[i]["HRCount"];
                    DTO[i].EmpCount = (int)dt.Rows[i]["EmpCount"];
                }
                return DTO;
            }
            else
                return null;
        }

        public static NewCurrentMonthLeaveStatus[] CURRENTMONTHLEAVESTATUS(int EmpID)
        {
            const string query = "sp_DashBoard_CurrentMonth_leaveStatus {0}";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            var ExQry = new ExecutionQuery { Query = string.Format(query, EmpID) };
            DataTable dt = EE.ExecuteDataTable(ExQry);
            NewCurrentMonthLeaveStatus[] DTO = new NewCurrentMonthLeaveStatus[dt.Rows.Count];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < DTO.Length; i++)
                {
                    DTO[i] = new NewCurrentMonthLeaveStatus();
                    DTO[i].LeaveRequest = (int)dt.Rows[i]["LeaveRequested"];
                    DTO[i].LeaveApproved = (int)dt.Rows[i]["LeaveApproved"];
                    DTO[i].LeaveRejected = (int)dt.Rows[i]["LeaveRejected"];
                }
                return DTO;
            }
            else
                return null;
        }
        public static AttdendanceDasshboard[] GetLoggedEmpAttendance(int EmpID)
        {
            const string query = "sp_Dashboard_EmpAttendance_EmpView {0}";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            var ExQry = new ExecutionQuery { Query = String.Format(query,EmpID) };
            DataTable dt = EE.ExecuteDataTable(ExQry);

            AttdendanceDasshboard[] DTO = new AttdendanceDasshboard[dt.Rows.Count];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < DTO.Length; i++)
                {
                    DTO[i] = new AttdendanceDasshboard();
                    DTO[i].Month = (string)dt.Rows[i]["CurentMonth"];
                    DTO[i].MonthlyDays = (double)dt.Rows[i]["TotalDays"];
                    DTO[i].LeaveCount = (double)dt.Rows[i]["LeaveCount"];
                    DTO[i].WorkedDays = (double)dt.Rows[i]["DaysWorked"];
                }
                return DTO;
            }
            else
                return null;
            
        }

        public static OfferIssuedDashboard[] GetCurrentMonthOfferIssued()
        {
            const string query = "sp_Dashboard_OfferIssued";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            var ExQry = new ExecutionQuery { Query = query };
            DataTable dt = EE.ExecuteDataTable(ExQry);

            OfferIssuedDashboard[] DTO = new OfferIssuedDashboard[dt.Rows.Count];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < DTO.Length; i++)
                {
                    DTO[i] = new OfferIssuedDashboard();
                    DTO[i].Candidate = (String)dt.Rows[i]["CandidateName"];
                    DTO[i].JoiningDate = ((DateTime)dt.Rows[i]["JoiningDate"]).ToString("dd/MM/yyyy");
                    DTO[i].Designation = (String)dt.Rows[i]["JobTitle"];
                }
                return DTO;
            }
            else
                return null;

        }

        public static InterviewScheduledDashboard[] GetCurrentMonthScheduledCandidates()
        {
            const string query = "sp_Dashboard_InterviewScheduled_Candidates";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            var ExQry = new ExecutionQuery { Query = query };
            DataTable dt = EE.ExecuteDataTable(ExQry);

            InterviewScheduledDashboard[] DTO = new InterviewScheduledDashboard[dt.Rows.Count];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < DTO.Length; i++)
                {
                    DTO[i] = new InterviewScheduledDashboard();
                    DTO[i].SlNo = (Int64)dt.Rows[i]["SerialNo"];
                    DTO[i].CandidateName = (String)dt.Rows[i]["CandidateName"];
                }
                return DTO;
            }
            else
                return null;

        }
    }
}
