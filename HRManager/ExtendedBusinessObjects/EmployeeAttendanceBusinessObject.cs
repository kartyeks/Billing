using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.BusinessObjects;
using HRManager.DTO;
using System.Data;
using HRManager.Entity;

namespace HRManager.BusinessObjects
{
    public partial class EmployeeAttendanceBusinessObject
    {
        /// <summary>
        /// Get Designations data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_Skill object</returns>
        public Attendance[] GetAllAttendance(int Month, String Year)
        {

            const String Qry = " SELECT MC.ID As CandidateId, ME.ID AS EmployeeID, ME.EmpCode AS EmployeeCode, " +
        " MC.FirstName + ' '  + MC.LastName As EmployeeName, " +
        " DP.DepartmentID, DT.DepartmentName, " +
        " DS.DesignationID, HD.Designation As DesignationName, " +
        " EA.ID As EmpAttendanceRecordID, MM.MonthId, MM.MonthName, EA.[Year], EA.WorkingDays, EA.PresentDays, " +
        " EA.WEndDaysCount As WeekendDays, EA.HoliDaysCount, EA.PunchedDays " +
        " FROM Master_Employees AS ME " +
        " LEFT OUTER JOIN Master_Candidate AS MC ON (MC.ID = ME.CandidateId) " +
        " LEFT OUTER JOIN ( " +
        " 					SELECT EmpID, DepartmentID " +
        " 						FROM Assign_Emp_Department " +
        " 						WHERE ID IN ( SELECT MAX(ID) AS ID " +
        " 										FROM Assign_Emp_Department " +
        " 										GROUP BY EmpID " +
        " 									) " +
        " 				) AS DP ON (DP.EmpID = ME.ID) " +
        " LEFT OUTER JOIN Hr_Department AS DT ON (DT.ID = DP.DepartmentID) " +
        " LEFT OUTER JOIN  " +
        " 	( " +
        " 					SELECT EmpID, DesignationID " +
        " 						FROM Assign_Emp_Designation  " +
        " 						WHERE ID IN ( SELECT MAX(ID) AS ID " +
        " 										FROM Assign_Emp_Designation " +
        " 												GROUP BY EmpID " +
        " 											) " +
        " 			) AS DS ON (DS.EmpId = ME.ID) " +
        " 		LEFT OUTER JOIN Hr_Designation AS HD ON (HD.ID = DS.DesignationID) " +
        " 		LEFT OUTER JOIN EmployeeAttendance AS EA ON (EA.EmployeeID = ME.ID) " +
        " 		LEFT OUTER JOIN Master_Month AS MM ON (MM.MonthId = EA.[Month]) " +
        "       where MM.MonthId={0} and EA.[Year]='{1}'";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = string.Format(Qry, Month, Year);

            DataTable dt = EE.ExecuteDataTable(exQry);

            Attendance[] Attendance = new Attendance[dt.Rows.Count];

            for (int i = 0; i < Attendance.Length; i++)
            {
                Attendance[i] = new Attendance();
                if (dt.Rows[i]["CandidateId"].ToString() != string.Empty)
                    Attendance[i].CandidateID = (int)dt.Rows[i]["CandidateId"];
                if (dt.Rows[i]["EmployeeID"].ToString() != string.Empty)
                    Attendance[i].EmployeeID = (int)dt.Rows[i]["EmployeeID"];
                if (dt.Rows[i]["EmployeeCode"].ToString() != string.Empty)
                    Attendance[i].EmployeeCode = (String)dt.Rows[i]["EmployeeCode"];
                if (dt.Rows[i]["EmployeeName"].ToString() != string.Empty)
                    Attendance[i].EmployeeName = (String)dt.Rows[i]["EmployeeName"];
                if (dt.Rows[i]["DepartmentID"].ToString() != string.Empty)
                    Attendance[i].DepartmentID = (int)dt.Rows[i]["DepartmentID"];
                if (dt.Rows[i]["DepartmentName"].ToString() != string.Empty)
                    Attendance[i].DepartmentName = (String)dt.Rows[i]["DepartmentName"];
                if (dt.Rows[i]["DesignationID"].ToString() != string.Empty)
                    Attendance[i].DesignationID = (int)dt.Rows[i]["DesignationID"];
                if (dt.Rows[i]["DesignationName"].ToString() != string.Empty)
                    Attendance[i].DesignationName = (String)dt.Rows[i]["DesignationName"];
                if (dt.Rows[i]["EmpAttendanceRecordID"].ToString() != string.Empty)
                    Attendance[i].EmpAttendanceRecordID = (int)dt.Rows[i]["EmpAttendanceRecordID"];
                if (dt.Rows[i]["MonthId"].ToString() != string.Empty)
                    Attendance[i].MonthId = (int)dt.Rows[i]["MonthId"];
                if (dt.Rows[i]["MonthName"].ToString() != string.Empty)
                    Attendance[i].MonthName = (String)dt.Rows[i]["MonthName"];
                if (dt.Rows[i]["Year"].ToString() != string.Empty)
                    Attendance[i].Year = (int)dt.Rows[i]["Year"];
                if (dt.Rows[i]["WorkingDays"].ToString() != string.Empty)
                    Attendance[i].WorkingDays = (Double)dt.Rows[i]["WorkingDays"];
                if (dt.Rows[i]["PresentDays"].ToString() != string.Empty)
                    Attendance[i].PresentDays = (Double)dt.Rows[i]["PresentDays"];
                if (dt.Rows[i]["WeekendDays"].ToString() != string.Empty)
                    Attendance[i].WeekendDays = (Double)dt.Rows[i]["WeekendDays"];
                if (dt.Rows[i]["HoliDaysCount"].ToString() != string.Empty)
                    Attendance[i].HolidayCount = (Double)dt.Rows[i]["HoliDaysCount"];
                if (dt.Rows[i]["PunchedDays"].ToString() != string.Empty)
                    Attendance[i].PunchedDays = (Double)dt.Rows[i]["PunchedDays"];

            }

            return Attendance;
        }

        public Attendance GetAttendanceForEmployee(int month, int year, int empId)
        {

            const String Qry = "select EA.ID,ME.EmpCode,EA.EmployeeID,WorkingDays,WEndDaysCount,HoliDaysCount, " +
                                "PunchedDays,NotPunchedDays,ReasonForNotPunched,PresentDays, " +
                                "MC.firstname+' '+MC.lastname as EmployeeName,DepartmentName,Designation, " +
                                "MB.Branchname,ML.Locationname,MB.ID as BranchID,ML.ID as LocationID,isnull(EA.LOPDays,0) as LOPDays " +
                                " from EmployeeAttendance EA " +
                                "Inner Join Master_Employees ME on (EA.EmployeeID=ME.ID) " +
                                "Inner Join Master_Candidate MC on (ME.CandidateID=MC.ID) " +
                                "Inner Join Hr_Department HD on (HD.ID=ME.DepartmentID)  " +
                                "Inner Join Assign_Emp_Designation AED on (AED.EmpID=EA.EmployeeID) " +
                                "Inner Join Hr_Designation HDT on (HDT.ID=AED.DesignationID) " +
                                "Inner Join Assign_Emp_Branch AEB on (AEB.EmpID=EA.EmployeeID) " +
                                "Inner Join Master_Branch MB on (MB.ID=AEB.BranchID) " +
                                "Inner Join Master_Location ML on (ML.ID=MB.LocationID) " +
                                "where Month={0} and Year={1} and EA.EmployeeID={2} and " +
                                "AED.ActivatedDate = (SELECT MAX(ActivatedDate) FROM Assign_Emp_Designation " +
                                "where EmpID =ME.ID) " +
                                "and AEB.ActivatedDate = (SELECT MAX(ActivatedDate) FROM Assign_Emp_Branch  " +
                                "where EmpID =ME.ID) ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = string.Format(Qry, month, year, empId);

            DataTable dt = EE.ExecuteDataTable(exQry);

            Attendance Attendance = new Attendance();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    Attendance.ID = (int)dr["ID"];
                    Attendance.EmployeeID = (int)dr["EmployeeID"];
                    Attendance.EmployeeCode = (String)dr["EmpCode"];
                    Attendance.EmployeeName = (String)dr["EmployeeName"];
                    Attendance.DepartmentName = (String)dr["DepartmentName"];
                    Attendance.DesignationName = (String)dr["Designation"];
                    Attendance.Branch = (String)dr["Branchname"];
                    Attendance.Location = (String)dr["Locationname"];
                    Attendance.BranchID = (int)dr["BranchID"];
                    Attendance.LocationID = (int)dr["LocationID"];
                    Attendance.WorkingDays = (Double)dr["WorkingDays"];
                    Attendance.PresentDays = (Double)dr["PresentDays"];
                    Attendance.WeekendDays = (Double)dr["WEndDaysCount"];
                    Attendance.HolidayCount = (Double)dr["HoliDaysCount"];
                    Attendance.PunchedDays = (Double)dr["PunchedDays"];
                    Attendance.NotPunchedDays = (Double)dr["NotPunchedDays"];
                    Attendance.ReasonForNotPunched = (String)dr["ReasonForNotPunched"];
                    Attendance.LOPDays = (Double)dr["LOPDays"];

                }
            }
            return Attendance;
        }


        /// <summary>
        /// Get Designations data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_Skill object</returns>
        public Attendance[] GetAllEmpAttendance(int Month, String Year)
        {

            const String Qry = " select EA.ID,ME.EmpCode,EA.EmployeeID,WorkingDays,WEndDaysCount,HoliDaysCount, " +
                               " PunchedDays,NotPunchedDays,ReasonForNotPunched,PresentDays, " +
                               " MC.firstname+' '+MC.lastname as EmployeeName,DepartmentName,Designation, " +
                               " MB.Branchname,ML.Locationname,MB.ID as BranchID,ML.ID as LocationID,isnull(EA.LOPDays,0) as LOPDays,ME.DateOfJoining " +

                               " from EmployeeAttendance EA " +

                               " Inner Join Master_Employees ME on (EA.EmployeeID=ME.ID) " +
                               " Inner Join Master_Candidate MC on (ME.CandidateID=MC.ID) " +
                               " Inner Join Hr_Department HD on (HD.ID=ME.DepartmentID)  " +
                               " Inner Join Assign_Emp_Designation AED on (AED.EmpID=EA.EmployeeID) " +
                               " Inner Join Hr_Designation HDT on (HDT.ID=AED.DesignationID) " +
                               " Inner Join Assign_Emp_Branch AEB on (AEB.EmpID=EA.EmployeeID) " +
                               " Inner Join Master_Branch MB on (MB.ID=AEB.BranchID) " +
                               " Inner Join Master_Location ML on (ML.ID=MB.LocationID) " +
                               " where Month={0} and Year={1} and " +
                               " AED.ActivatedDate = (SELECT MAX(ActivatedDate) FROM Assign_Emp_Designation " +
                               " where EmpID =ME.ID) " +
                               " and AEB.ActivatedDate = (SELECT MAX(ActivatedDate) FROM Assign_Emp_Branch  " +
                               " where EmpID =ME.ID) ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = string.Format(Qry, Month, Year);

            DataTable dt = EE.ExecuteDataTable(exQry);

            Attendance[] Attendance = new Attendance[dt.Rows.Count];

            for (int i = 0; i < Attendance.Length; i++)
            {
                Attendance[i] = new Attendance();
                if (dt.Rows[i]["ID"].ToString() != string.Empty)
                    Attendance[i].ID = (int)dt.Rows[i]["ID"];
                if (dt.Rows[i]["EmployeeID"].ToString() != string.Empty)
                    Attendance[i].EmployeeID = (int)dt.Rows[i]["EmployeeID"];
                if (dt.Rows[i]["EmpCode"].ToString() != string.Empty)
                    Attendance[i].EmployeeCode = (String)dt.Rows[i]["EmpCode"];
                if (dt.Rows[i]["EmployeeName"].ToString() != string.Empty)
                    Attendance[i].EmployeeName = (String)dt.Rows[i]["EmployeeName"];
                //if (dt.Rows[i]["DepartmentID"].ToString() != string.Empty)
                //    Attendance[i].DepartmentID = (int)dt.Rows[i]["DepartmentID"];
                if (dt.Rows[i]["DepartmentName"].ToString() != string.Empty)
                    Attendance[i].DepartmentName = (String)dt.Rows[i]["DepartmentName"];
                //if (dt.Rows[i]["DesignationID"].ToString() != string.Empty)
                //    Attendance[i].DesignationID = (int)dt.Rows[i]["DesignationID"];
                if (dt.Rows[i]["Designation"].ToString() != string.Empty)
                    Attendance[i].DesignationName = (String)dt.Rows[i]["Designation"];
                if (dt.Rows[i]["Branchname"].ToString() != string.Empty)
                    Attendance[i].Branch = (String)dt.Rows[i]["Branchname"];
                if (dt.Rows[i]["Locationname"].ToString() != string.Empty)
                    Attendance[i].Location = (String)dt.Rows[i]["Locationname"];
                if (dt.Rows[i]["BranchID"].ToString() != string.Empty)
                    Attendance[i].BranchID = (int)dt.Rows[i]["BranchID"];
                if (dt.Rows[i]["LocationID"].ToString() != string.Empty)
                    Attendance[i].LocationID = (int)dt.Rows[i]["LocationID"];
                if (dt.Rows[i]["WorkingDays"].ToString() != string.Empty)
                    Attendance[i].WorkingDays = (Double)dt.Rows[i]["WorkingDays"];
                if (dt.Rows[i]["PresentDays"].ToString() != string.Empty)
                    Attendance[i].PresentDays = (Double)dt.Rows[i]["PresentDays"];
                if (dt.Rows[i]["WEndDaysCount"].ToString() != string.Empty)
                    Attendance[i].WeekendDays = (Double)dt.Rows[i]["WEndDaysCount"];
                if (dt.Rows[i]["HoliDaysCount"].ToString() != string.Empty)
                    Attendance[i].HolidayCount = (Double)dt.Rows[i]["HoliDaysCount"];
                if (dt.Rows[i]["PunchedDays"].ToString() != string.Empty)
                    Attendance[i].PunchedDays = (Double)dt.Rows[i]["PunchedDays"];
                if (dt.Rows[i]["NotPunchedDays"].ToString() != string.Empty)
                    Attendance[i].NotPunchedDays = (Double)dt.Rows[i]["NotPunchedDays"];
                if (dt.Rows[i]["ReasonForNotPunched"].ToString() != string.Empty)
                    Attendance[i].ReasonForNotPunched = (String)dt.Rows[i]["ReasonForNotPunched"];
                if (dt.Rows[i]["LOPDays"].ToString() != string.Empty)
                    Attendance[i].LOPDays = (Double)dt.Rows[i]["LOPDays"];
                if (dt.Rows[i]["DateOfJoining"].ToString() != string.Empty)
                    Attendance[i].DateOfJoining = (DateTime)dt.Rows[i]["DateOfJoining"];

            }

            return Attendance;
        }
        /// <summary>
        /// Get Designations data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_Skill object</returns>
        public Attendance[] GetAllAttendanceDetailsByMonYearLoc(int Month, String Year, int LocationID)
        {

            const String Qry = "  SELECT MC.ID As CandidateId, ME.ID AS EmployeeID, ME.EmpCode AS EmployeeCode, " +
            " MC.FirstName + ' '  + MC.LastName As EmployeeName, " +
            " DP.DepartmentID, DT.DepartmentName, " +
            " DS.DesignationID, HD.Designation As DesignationName, " +
            " EA.ID As EmpAttendanceRecordID, MM.MonthId, MM.MonthName, EA.[Year], EA.WorkingDays, EA.PresentDays, " +
            " EA.WEndDaysCount As WeekendDays, EA.HoliDaysCount, EA.PunchedDays " +
            " FROM Master_Employees AS ME " +
            " LEFT OUTER JOIN Master_Candidate AS MC ON (MC.ID = ME.CandidateId) " +
            " LEFT OUTER JOIN ( " +
            " 					SELECT EmpID, DepartmentID " +
            " 						FROM Assign_Emp_Department " +
            " 						WHERE ID IN ( SELECT MAX(ID) AS ID " +
            " 										FROM Assign_Emp_Department " +
            " 										GROUP BY EmpID " +
            " 									) " +
            " 				) AS DP ON (DP.EmpID = ME.ID) " +
            " LEFT OUTER JOIN Hr_Department AS DT ON (DT.ID = DP.DepartmentID) " +
            " LEFT OUTER JOIN  " +
            " 	( " +
            " 					SELECT EmpID, DesignationID " +
            " 						FROM Assign_Emp_Designation  " +
            " 						WHERE ID IN ( SELECT MAX(ID) AS ID " +
            " 										FROM Assign_Emp_Designation " +
            " 												GROUP BY EmpID " +
            " 											) " +
            " 			) AS DS ON (DS.EmpId = ME.ID) " +
            " 		LEFT OUTER JOIN Hr_Designation AS HD ON (HD.ID = DS.DesignationID) " +
            " 		LEFT OUTER JOIN EmployeeAttendance AS EA ON (EA.EmployeeID = ME.ID) " +
            " 		LEFT OUTER JOIN Master_Month AS MM ON (MM.MonthId = EA.[Month]) " +
            "       where MM.MonthId={0} and EA.[Year]={1}  ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = string.Format(Qry, Month, Year);

            DataTable dt = EE.ExecuteDataTable(exQry);

            Attendance[] Attendance = new Attendance[dt.Rows.Count];

            for (int i = 0; i < Attendance.Length; i++)
            {
                Attendance[i] = new Attendance();
                if (dt.Rows[i]["CandidateId"].ToString() != string.Empty)
                    Attendance[i].CandidateID = (int)dt.Rows[i]["CandidateId"];
                if (dt.Rows[i]["EmployeeID"].ToString() != string.Empty)
                    Attendance[i].EmployeeID = (int)dt.Rows[i]["EmployeeID"];
                if (dt.Rows[i]["EmployeeCode"].ToString() != string.Empty)
                    Attendance[i].EmployeeCode = (String)dt.Rows[i]["EmployeeCode"];
                if (dt.Rows[i]["EmployeeName"].ToString() != string.Empty)
                    Attendance[i].EmployeeName = (String)dt.Rows[i]["EmployeeName"];
                if (dt.Rows[i]["DepartmentID"].ToString() != string.Empty)
                    Attendance[i].DepartmentID = (int)dt.Rows[i]["DepartmentID"];
                if (dt.Rows[i]["DepartmentName"].ToString() != string.Empty)
                    Attendance[i].DepartmentName = (String)dt.Rows[i]["DepartmentName"];
                if (dt.Rows[i]["DesignationID"].ToString() != string.Empty)
                    Attendance[i].DesignationID = (int)dt.Rows[i]["DesignationID"];
                if (dt.Rows[i]["DesignationName"].ToString() != string.Empty)
                    Attendance[i].DesignationName = (String)dt.Rows[i]["DesignationName"];
                if (dt.Rows[i]["EmpAttendanceRecordID"].ToString() != string.Empty)
                    Attendance[i].EmpAttendanceRecordID = (int)dt.Rows[i]["EmpAttendanceRecordID"];
                if (dt.Rows[i]["MonthId"].ToString() != string.Empty)
                    Attendance[i].MonthId = (int)dt.Rows[i]["MonthId"];
                if (dt.Rows[i]["MonthName"].ToString() != string.Empty)
                    Attendance[i].MonthName = (String)dt.Rows[i]["MonthName"];
                if (dt.Rows[i]["Year"].ToString() != string.Empty)
                    Attendance[i].Year = (int)dt.Rows[i]["Year"];
                if (dt.Rows[i]["WorkingDays"].ToString() != string.Empty)
                    Attendance[i].WorkingDays = (Double)dt.Rows[i]["WorkingDays"];
                if (dt.Rows[i]["PresentDays"].ToString() != string.Empty)
                    Attendance[i].PresentDays = (Double)dt.Rows[i]["PresentDays"];
                if (dt.Rows[i]["WeekendDays"].ToString() != string.Empty)
                    Attendance[i].WeekendDays = (Double)dt.Rows[i]["WeekendDays"];
                if (dt.Rows[i]["HoliDaysCount"].ToString() != string.Empty)
                    Attendance[i].HolidayCount = (Double)dt.Rows[i]["HoliDaysCount"];
                if (dt.Rows[i]["PunchedDays"].ToString() != string.Empty)
                    Attendance[i].PunchedDays = (Double)dt.Rows[i]["PunchedDays"];

            }

            return Attendance;
        }

        public EmployeeLeaveDetails[] GetEmployeeAttendanceDetails(int EmployeeId)
        {

            const String Qry =
                "  SELECT LR.EmpID As EmployeeId, LR.LeaveID As LeaveTypeID, ML.LeaveType,  " +
                "  CASE  " +
                "       WHEN 'APR'= LR.LeaveStatus THEN 'Approved' " +
                "        WHEN 'REQ'= LR.LeaveStatus THEN 'Requested' " +
                "    END As LeaveStatus,  " +
                "    SUM(LR.LeaveCount) AS NoOfLeaveTaken " +
                "    FROM " +
                "    ( " +
                "        SELECT LV.EmpID, LV.LeaveID,  " +
                /* If half day leave taken then if one day then .5  else NoOfHalfDayLeave/2 */
                "            CASE  " +
                "                WHEN 1 = LV.IsHalfDay AND 0 = LV.LeaveCount THEN 0.5 " +
                "                WHEN 1 = LV.IsHalfDay AND 0 != LV.LeaveCount THEN LV.LeaveCount / 2 " +
                "                ELSE LV.LeaveCount  " +
                "            END AS LeaveCount, " +
                "            LV.IsHalfDay, LV.LeaveStatus " +
                "        FROM " +
                "        ( " +
                "            SELECT LR.EmpID, LR.LeaveID,  " +
                "            datediff(dd, LR.FromDate, LR.ToDate) As LeaveCount, " +
                "            LR.IsHalfDay,  " +
                "                LR.[Status] As LeaveStatus " +
                "                FROM Leave_Request LR " +
                "           WHERE LR.EmpID = {0}/* Selected employee */ " +
                "             AND LR.[Status] = 'APP' /* Only not rejected leaves considered */ " +
                "        ) AS LV  " +
                "    ) AS LR " +
                "    LEFT OUTER JOIN Master_Leave ML ON ( ML.ID = LR.LeaveID ) " +
                "    GROUP BY LR.EmpID, LR.LeaveID, ML.LeaveType, LR.LeaveStatus ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = string.Format(Qry, EmployeeId);

            DataTable dt = EE.ExecuteDataTable(exQry);

            EmployeeLeaveDetails[] EmployeeLeaveDetails = new EmployeeLeaveDetails[dt.Rows.Count];

            for (int i = 0; i < EmployeeLeaveDetails.Length; i++)
            {
                EmployeeLeaveDetails[i] = new EmployeeLeaveDetails();
                if (dt.Rows[i]["EmployeeId"].ToString() != string.Empty)
                    EmployeeLeaveDetails[i].EmployeeId = (int)dt.Rows[i]["EmployeeId"];
                if (dt.Rows[i]["LeaveTypeID"].ToString() != string.Empty)
                    EmployeeLeaveDetails[i].LeaveTypeID = (int)dt.Rows[i]["LeaveTypeID"];
                if (dt.Rows[i]["LeaveType"].ToString() != string.Empty)
                    EmployeeLeaveDetails[i].LeaveType = (String)dt.Rows[i]["LeaveType"];
                if (dt.Rows[i]["LeaveStatus"].ToString() != string.Empty)
                    EmployeeLeaveDetails[i].LeaveStatus = (String)dt.Rows[i]["LeaveStatus"];
                if (dt.Rows[i]["NoOfLeaveTaken"].ToString() != string.Empty)
                {
                    String strNoNoOfLeaveTaken = dt.Rows[i]["NoOfLeaveTaken"].ToString();
                    Double dblNoNoOfLeaveTaken;
                    Double.TryParse(strNoNoOfLeaveTaken, out dblNoNoOfLeaveTaken);
                    EmployeeLeaveDetails[i].NoOfLeaveTaken = dblNoNoOfLeaveTaken;
                }
                if (dt.Rows[i]["YearlyLeave"].ToString() != string.Empty)
                {
                    String strYearlyLeave = dt.Rows[i]["YearlyLeave"].ToString();
                    Double dblYearlyLeave;
                    Double.TryParse(strYearlyLeave, out dblYearlyLeave);
                    EmployeeLeaveDetails[i].YearlyLeave = dblYearlyLeave;
                }
                if (dt.Rows[i]["BalLeave"].ToString() != string.Empty)
                {
                    String strBalLeave = dt.Rows[i]["BalLeave"].ToString();
                    Double dblBalLeave;
                    Double.TryParse(strBalLeave, out dblBalLeave);
                    EmployeeLeaveDetails[i].BalLeave = dblBalLeave;
                }

            }
            return EmployeeLeaveDetails;

        }

        public EmployeeLeaveDetails[] GetEmploLeaveDetails(int EmployeeId, int Month, int Year)
        {
            const String Qry = "[usp_EmpLeaveDetails] {0},{1},{2}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = string.Format(Qry, Month, Year, EmployeeId);

            DataTable dt = EE.ExecuteDataTable(exQry);

            EmployeeLeaveDetails[] EmployeeLeaveDetails = new EmployeeLeaveDetails[dt.Rows.Count];

            for (int i = 0; i < EmployeeLeaveDetails.Length; i++)
            {
                EmployeeLeaveDetails[i] = new EmployeeLeaveDetails();
                if (dt.Rows[i]["LeaveTypeID"].ToString() != string.Empty)
                    EmployeeLeaveDetails[i].LeaveTypeID = (int)dt.Rows[i]["LeaveTypeID"];
                if (dt.Rows[i]["LeaveType"].ToString() != string.Empty)
                    EmployeeLeaveDetails[i].LeaveType = (String)dt.Rows[i]["LeaveType"];
                if (dt.Rows[i]["NoOfLeaveTaken"].ToString() != string.Empty)
                {
                    String strNoNoOfLeaveTaken = dt.Rows[i]["NoOfLeaveTaken"].ToString();
                    Double dblNoNoOfLeaveTaken;
                    Double.TryParse(strNoNoOfLeaveTaken, out dblNoNoOfLeaveTaken);
                    EmployeeLeaveDetails[i].NoOfLeaveTaken = dblNoNoOfLeaveTaken;
                }
                if (dt.Rows[i]["YearlyLeave"].ToString() != string.Empty)
                {
                    String strYearlyLeave = dt.Rows[i]["YearlyLeave"].ToString();
                    Double dblYearlyLeave;
                    Double.TryParse(strYearlyLeave, out dblYearlyLeave);
                    EmployeeLeaveDetails[i].YearlyLeave = dblYearlyLeave;
                }
                if (dt.Rows[i]["BalLeave"].ToString() != string.Empty)
                {
                    String strBalLeave = dt.Rows[i]["BalLeave"].ToString();
                    Double dblBalLeave;
                    Double.TryParse(strBalLeave, out dblBalLeave);
                    EmployeeLeaveDetails[i].BalLeave = dblBalLeave;
                }

            }
            return EmployeeLeaveDetails;

        }

        public EmployeeLeaveDetails[] GetShowEmploLeaveDetails(int EmployeeId, int Month, int Year)
        {
            const String Qry = "[usp_EmpLeaveDetails] {1},{2},{0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = string.Format(Qry, EmployeeId, Month, Year);

            DataTable dt = EE.ExecuteDataTable(exQry);

            EmployeeLeaveDetails[] EmployeeLeaveDetails = new EmployeeLeaveDetails[dt.Rows.Count];

            for (int i = 0; i < EmployeeLeaveDetails.Length; i++)
            {
                EmployeeLeaveDetails[i] = new EmployeeLeaveDetails();
                if (dt.Rows[i]["Leavetypeid"].ToString() != string.Empty)
                    EmployeeLeaveDetails[i].LeaveTypeID = (int)dt.Rows[i]["Leavetypeid"];
                if (dt.Rows[i]["leavetype"].ToString() != string.Empty)
                    EmployeeLeaveDetails[i].LeaveType = (String)dt.Rows[i]["leavetype"];
                if (dt.Rows[i]["noofleavetaken"].ToString() != string.Empty)
                {
                    String strNoNoOfLeaveTaken = dt.Rows[i]["noofleavetaken"].ToString();
                    Double dblNoNoOfLeaveTaken;
                    Double.TryParse(strNoNoOfLeaveTaken, out dblNoNoOfLeaveTaken);
                    EmployeeLeaveDetails[i].NoOfLeaveTaken = dblNoNoOfLeaveTaken;
                }
                if (dt.Rows[i]["YearlyLeave"].ToString() != string.Empty)
                {
                    String strYearlyLeave = dt.Rows[i]["YearlyLeave"].ToString();
                    Double dblYearlyLeave;
                    Double.TryParse(strYearlyLeave, out dblYearlyLeave);
                    EmployeeLeaveDetails[i].YearlyLeave = dblYearlyLeave;
                }
                if (dt.Rows[i]["BalLeave"].ToString() != string.Empty)
                {
                    String strBalLeave = dt.Rows[i]["BalLeave"].ToString();
                    Double dblBalLeave;
                    Double.TryParse(strBalLeave, out dblBalLeave);
                    EmployeeLeaveDetails[i].BalLeave = dblBalLeave;
                }

            }
            return EmployeeLeaveDetails;

        }
        public int GetEmployeeDaysWorked(string Month, string Year, string employeeID, string LoacationID)
        {
            int intH = 0;
             const String Qry = " prcGetEmployeeAttendanceDaysWorked '{0}','{1}','{2}','{3}'";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, Month, Year, employeeID, LoacationID);
            //const String Qry = "Select count(DISTINCT D.Date) DaysWorked from Employee_DailyAttendance D " +
            //                   "INNER JOIN Master_Employees E ON E.ID=D.EmployeeID " +
            //                   "where  EmployeeID='{2}' and (month(date)={0}) and (year(date)={1})";
          
            int.TryParse(string.Concat(EE.ExecuteScalar(exQry)), out intH);
            return intH;
        }
        public EmployeeMonthAttendance GetMonthlyPreEmployeeAttendnceDetails(int Month, int Year, int BranchID, int LoacationID)
        {
            const String Qry = " prcGetPreEmployeeMonthlyAttendanceDetails '{0}','{1}','{2}','{3}'";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, Month, Year, BranchID, LoacationID);
            DataTable dt = EE.ExecuteDataTable(exQry);

            EmployeeMonthAttendance EmployeeMonthAttendance = new EmployeeMonthAttendance();

            if (dt.Rows[0]["NoOfWeeklyOff"].ToString() != string.Empty)
            {
                String strNoOfWeeklyOff = dt.Rows[0]["NoOfWeeklyOff"].ToString();
                Double dblNoOfWeeklyOff;
                Double.TryParse(strNoOfWeeklyOff, out dblNoOfWeeklyOff);
                EmployeeMonthAttendance.NoOfWeeklyOff = dblNoOfWeeklyOff;
            }
            if (dt.Rows[0]["NoOfHilodays"].ToString() != string.Empty)
            {
                String strNoOfHilodays = dt.Rows[0]["NoOfHilodays"].ToString();
                Double dblNoOfHilodays;
                Double.TryParse(strNoOfHilodays, out dblNoOfHilodays);
                EmployeeMonthAttendance.NoOfHilodays = dblNoOfHilodays;
            }
            return EmployeeMonthAttendance;

        }

        public EmployeeMonthAttendance GetMonthlyPreEmployeeAttendnceDetailsForJoining(int Month, int Year, int BranchID, int LoacationID, int Day)
        {
            const String Qry = " prcGetPreEmployeeMonthlyAttendanceDetailsForJoining '{0}','{1}','{2}','{3}','{4}'";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, Month, Year, BranchID, LoacationID, Day);
            DataTable dt = EE.ExecuteDataTable(exQry);

            EmployeeMonthAttendance EmployeeMonthAttendance = new EmployeeMonthAttendance();

            if (dt.Rows[0]["NoOfWeeklyOff"].ToString() != string.Empty)
            {
                String strNoOfWeeklyOff = dt.Rows[0]["NoOfWeeklyOff"].ToString();
                Double dblNoOfWeeklyOff;
                Double.TryParse(strNoOfWeeklyOff, out dblNoOfWeeklyOff);
                EmployeeMonthAttendance.NoOfWeeklyOff = dblNoOfWeeklyOff;
            }
            if (dt.Rows[0]["NoOfHilodays"].ToString() != string.Empty)
            {
                String strNoOfHilodays = dt.Rows[0]["NoOfHilodays"].ToString();
                Double dblNoOfHilodays;
                Double.TryParse(strNoOfHilodays, out dblNoOfHilodays);
                EmployeeMonthAttendance.NoOfHilodays = dblNoOfHilodays;
            }
            return EmployeeMonthAttendance;

        }

        public EmployeeMonthAttendance GetMonthlyEmployeeAttendnceDetails(int EmployeeId, int Month, int Year)
        {
            const String Qry = " prcGetEmployeeMonthlyAttendanceDetails '{0}','{1}','{2}'";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmployeeId, Month, Year);
            DataTable dt = EE.ExecuteDataTable(exQry);

            EmployeeMonthAttendance EmployeeMonthAttendance = new EmployeeMonthAttendance();

            if (dt.Rows[0]["NoOfPunchedDays"].ToString() != string.Empty)
            {
                String strNoOfPunchedDays = dt.Rows[0]["NoOfPunchedDays"].ToString();
                Double dblNoOfPunchedDays;
                Double.TryParse(strNoOfPunchedDays, out dblNoOfPunchedDays);
                EmployeeMonthAttendance.NoOfPunchedDays = (Double)dt.Rows[0]["NoOfPunchedDays"];
            }


            return EmployeeMonthAttendance;

        }

        public bool IsEmpAttendanceAdded(int month, int year, int empid)
        {
            const String Qry = " Select Count(1) from Employee_Payroll Where Month={0} AND Year={1} AND EmployeeID = {2} ";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = String.Format(Qry, month.ToString(), year.ToString(), empid.ToString());
            object ret = EE.ExecuteScalar(exQry);
            if (ret != null)
            {
                Int32 intret = 0;
                Int32.TryParse(ret.ToString(), out intret);
                if (intret > 0) { return false; }
            }
            return true;
        }

        public Boolean DeleteDuplication(string EmployeeID, string Date)
        {
            const String QryInv = " DELETE FROM Employee_DailyAttendance Where EmployeeID = '{0}' AND Date = '{1}' ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(QryInv, EmployeeID, Date);
            bool retval = false;
            bool.TryParse(string.Concat(EE.ExecuteScalar(exQry), string.Empty), out retval);
            return retval;
        }
    }
}
