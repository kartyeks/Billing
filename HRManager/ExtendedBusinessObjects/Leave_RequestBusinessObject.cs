using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;
using IS91.Services.DataBlock;
using System.Data;
using HRManager.Entity.EmployeeLeave;
using HRManager.DTOEXT;
using HRManager.Entity;

namespace HRManager.BusinessObjects
{
    public partial class Leave_RequestBusinessObject
    {
        public Leave_RequestEXT[] GetLeaveRequest(int EmployeeID)  
        {
            const String Qry = "SELECT LR.ID "  
                              + " 		,LR.EmpID "  
                              + " 		,LR.LeaveID "  
                              + " 		,LR.FromDate "  
                              + " 		,LR.ToDate 	"  
                              + "  		,DaysCount "  
                              + " 		,LR.Reason "  
                              + " 		,LR.AppliedDateTime "  
                              + " 		,LR.Status 	"  
                              + " 		,''LeaveType  "  
                              + " 		,ManagerID  "
                              + " 		,ManagerComments  "
                              + " 		,FromDateHalfDay  "
                              + " 		,ToDateHalfDay  "
                              + " 		,(FirstName+ ' '+MiddleName+' '+ LastName)Managername"  
                              + " 	FROM Leave_Request LR   "  
                              //+ " 	INNER JOIN 	"  
                              //+ " 		Master_Leave ML  "  
                              //+ " 	ON 	"  
                              //+ " 		ML.ID = LR.LeaveID "  
                              + " 	INNER JOIN"  
                              + " 		Master_Employees ME"  
                              + " 	ON"  
                              + " 		ME.ID=LR.ManagerID"  
                              + " 	WHERE LR.EmpID = '{0}' AND LR.Status = 'REQ'  "  
                              + " UNION ALL "  
                              + " 	SELECT LR.ID "  
                              + " 		,LR.EmpID "  
                              + " 		,LR.LeaveID "  
                              + " 		,LR.FromDate "  
                              + " 		,LR.ToDate "  
                              + " 		,DaysCount "  
                              + " 		,LR.Reason "  
                              + " 		,LR.AppliedDateTime "  
                              + " 		,LR.Status "  
                             + " 		,''LeaveType "  
                              + " 		,ManagerID "
                              + " 		,ManagerComments  "
                              + " 		,FromDateHalfDay  "
                              + " 		,ToDateHalfDay  "
                              + " 		,(FirstName+ ' '+MiddleName+' '+ LastName)Managername"  
                              + " 	FROM Leave_Request LR "  
                              //+ " 	INNER JOIN "  
                              //+ " 		Master_Leave ML "  
                              //+ " 	ON 	"  
                              //+ " 		ML.ID = LR.LeaveID 	"  
                              + " 	INNER JOIN"  
                              + " 		Master_Employees ME"  
                              + " 	ON"  
                              + " 		ME.ID=LR.ManagerID"  
                              + " 	WHERE LR.EmpID = '{0}' AND LR.Status = 'APP'  "  
                              + " UNION ALL "  
                              + " 		SELECT LR.ID "  
                              + " 		,LR.EmpID "  
                              + " 		,LR.LeaveID "  
                              + " 		,LR.FromDate "  
                              + " 		,LR.ToDate "  
                              + "  		,DaysCount "  
                              + " 		,LR.Reason "  
                              + " 		,LR.AppliedDateTime "  
                              + " 		,LR.Status "  
                              + " 		,''LeaveType "  
                              + " 		,ManagerID " 
                              + " 		,ManagerComments  "
                              + " 		,FromDateHalfDay  "
                              + " 		,ToDateHalfDay  "
                              + " 		,(FirstName+ ' '+MiddleName+' '+ LastName)Managername"  
                              + " 	FROM Leave_Request LR  "  
                              //+ " 	INNER JOIN 		"  
                              //+ " 		Master_Leave ML "  
                              //+ " 	ON 	"  
                              //+ " 		ML.ID = LR.LeaveID "  
                              + " 	INNER JOIN"  
                              + " 		Master_Employees ME"  
                              + " 	ON"  
                              + " 		ME.ID=LR.ManagerID"  
                              + " 	WHERE LR.EmpID = '{0}' AND LR.Status = 'REJ'" ;

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry,EmployeeID.ToString());
            DataTable dt = EE.ExecuteDataTable(exQry);

            Leave_RequestEXT[] DTO = new Leave_RequestEXT[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Leave_RequestEXT();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].EmpID = (int)dt.Rows[i]["EmpID"];
                DTO[i].LeaveID = (int)dt.Rows[i]["LeaveID"];
                DTO[i].ManagerID = (int)dt.Rows[i]["ManagerID"];
                DTO[i].DaysCount = (double)dt.Rows[i]["DaysCount"];
                DTO[i].FromDate = (DateTime)dt.Rows[i]["FromDate"];
                DTO[i].ToDate = (DateTime)dt.Rows[i]["ToDate"];
                DTO[i].AppliedDateTime = (DateTime)dt.Rows[i]["AppliedDateTime"];
                DTO[i].Reason = (String)dt.Rows[i]["Reason"];
                DTO[i].Status = (String)dt.Rows[i]["Status"];
                DTO[i].ManagerName = (String)dt.Rows[i]["Managername"];
                DTO[i].ManagerComments = (String)dt.Rows[i]["ManagerComments"];
                DTO[i].FromDateHalfDay = (bool)dt.Rows[i]["FromDateHalfDay"];
                DTO[i].ToDateHalfDay = (bool)dt.Rows[i]["ToDateHalfDay"]; 
            }

            return DTO;
        }

        public LeaveOverViewEXT[] GetLeaveOverview(int EmployeeID)
        {
            const String Qry = "  SELECT DISTINCT "  
                                  + " 	(FirstName+ ' '+MiddleName+' '+LastName)EmployeeName"  
                                  + " 	,'LeaveType' = CASE WHEN (LeaveType!='')THEN ML.LeaveType ELSE 'Annual Leave' END 	"  
                                  + " 	,ISNULL(EmpID,0)EmpID 	"
                                  + " 	,(SELECT ISNULL(LeavesCount,0)FROM Employee_OccupationDetails WHERE  ActivatedDate=(SELECT MIN(ActivatedDate)FROM Employee_OccupationDetails WHERE EmployeeID = {0} AND (IsActive=1 OR IsActive=0)))TotalLeave "  
                                  + " 	,ISNULL(([dbo].[GetUsedLeave](EmpID)),0) UsedLeave   	"  
                                  + "  	,(CONVERT(FLOAT,LeavesCount) - ISNULL(([dbo].[GetRequestedLeave](EmpID)),0))BalLeaveRequested  "
                                  + " 	,ISNULL([dbo].[GetLeavesCount](EmployeeID),0)BalanceLeave,LR.LeaveID  "  
                                  + " FROM Employee_OccupationDetails EO"  
                                  + " LEFT JOIN  	"  
                                  + " 	Leave_Request LR "  
                                  + " ON  	"  
                                  + " 	LR.EmpID=EO.EmployeeID"  
                                  + " LEFT JOIN  	"  
                                  + " 	Master_Leave ML  "  
                                  + " ON  	"  
                                  + " 	ML.ID= LR.LeaveID"  
                                  + " LEFT JOIN"  
                                  + " 	Master_Employees ME"  
                                  + " ON"  
                                  + " 	ME.ID=EO.EmployeeID"
                                  + " WHERE  EO.EmployeeID={0} AND EO.IsActive=1 AND ME.IsActive=1 AND ME.IsDeleted!=1 AND LR.LeaveID!=2";                                  

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry,EmployeeID.ToString());
            DataTable dt = EE.ExecuteDataTable(exQry);

            LeaveOverViewEXT[] DTO = new LeaveOverViewEXT[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new LeaveOverViewEXT();
                //DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].TotalLeave = (Double)dt.Rows[i]["TotalLeave"]; 
                DTO[i].UsedLeave = (double)dt.Rows[i]["UsedLeave"];
                DTO[i].BalanceLeave = (Double)dt.Rows[i]["BalanceLeave"];
                DTO[i].LeaveType = (String)dt.Rows[i]["LeaveType"];
                DTO[i].EmployeeName = (String)dt.Rows[i]["EmployeeName"];
                DTO[i].LeaveRequested = (Double)dt.Rows[i]["BalLeaveRequested"];
                DTO[i].LeaveID = (int)dt.Rows[i]["LeaveID"]; 
            }

            return DTO;
        }

        public  LeaveRequestCalenderEXT[] GetAllActiveLeaveCalender(int EmployeeID)
        {
            const String Qry = "SELECT ID,EmpID,FromDate,ToDate FROM Leave_Request WHERE (Status='{0}' OR Status = '{1}' OR Status = '{2}') and EmpID = '{3}'";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, LeaveAppCommands.LEAVE_REQ_STATUS_APPROVE, LeaveAppCommands.LEAVE_REQ_STATUS_REQUEST, LeaveAppCommands.LEAVE_REQ_STATUS_REJECT, EmployeeID);
            DataTable dt = EE.ExecuteDataTable(exQry);
            LeaveRequestCalenderEXT[] DTO = new LeaveRequestCalenderEXT[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new LeaveRequestCalenderEXT();
                DTO[i].id = (int)dt.Rows[i]["ID"];
                DTO[i].title = "Leave Request";
                DTO[i].start = (DateTime)dt.Rows[i]["FromDate"];
                DTO[i].end = (DateTime)dt.Rows[i]["ToDate"];                
            }           

            return DTO;
        }


        public LeaveCalenderEXT GetActiveLeaveCalenderDetails(int ID)
        {
            String Query = "SELECT ML.LeaveType, "
                          + "  'Status' = CASE WHEN LR.Status = 'REQ' THEN 'Requested'  WHEN LR.Status = 'APP' THEN 'Approved'  ELSE 'NEW' END,"
                          + "  LR.DaysCount,ME.Firstname+ ' '+isnull(MiddleName,'')+' '+isnull(ME.Lastname,'') 'Manager',"
                          + "  LR.Reason"
                          + "  FROM Leave_Request LR  inner join Master_Leave ML on (LR.Leaveid=ML.id) "
                          + "  INNER JOIN Master_Employees ME on (ME.ID=LR.ManagerID)"
                          + "  WHERE LR.ID = '{0}'";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = String.Format(Query, ID.ToString());
            DataTable dt = EE.ExecuteDataTable(exQry);

            LeaveCalenderEXT DTO = new LeaveCalenderEXT();

            if (dt.Rows.Count > 0)
            {
                DTO.LeaveType = (string)dt.Rows[0]["LeaveType"];
                DTO.Status = (string)dt.Rows[0]["Status"];
                DTO.DaysCount = (double)dt.Rows[0]["DaysCount"];
                DTO.Manager = (string)dt.Rows[0]["Manager"];
                DTO.Reason = (string)dt.Rows[0]["Reason"]; 
            }

            return DTO;
        }

        public LeaveCalenderEXT GetCalenderDetails(int ID)
        {
            LeaveCalenderEXT objarr = GetActiveLeaveCalenderDetails(ID);
            return objarr;
        }
        public void DeleteLeaveRequest(int ID)
        {
            String Qry = " DELETE FROM Leave_Request WHERE ID = {0} AND Status='REQ'";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = String.Format(Qry, ID);

            EE.ExecuteNonQuery(exQry);
        }
        public void ResetDateLeaveRequest(int ID)
        {
            String Qry = " UPDATE Leave_Request SET FromDate='' , ToDate='' , DaysCount='' WHERE ID = {0} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = String.Format(Qry, ID);

            EE.ExecuteNonQuery(exQry);
        }

        public LeaveRequest GetTeamManagerID(int EmpID)
        {
            String Query = "SELECT DISTINCT "
                              + " EmpID"
                              + " ,TeamID"
                              + " ,MT.ManagerID "
                              + " FROM Employee_OccupationDetails EO"
                              + " INNER JOIN "
                              + " 	Leave_Request LR"
                              + " ON"
                              + " 	LR.EmpID=EO.EmployeeID"
                              + " INNER JOIN "
                              + " 	Master_Team MT"
                              + " ON"
                              + " 	MT.ID=EO.TeamID"
                              + " 	WHERE EmpID={0} AND EO.IsActive=1 AND MT.IsActive=1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = String.Format(Query, EmpID.ToString());
            DataTable dt = EE.ExecuteDataTable(exQry);
            LeaveRequest DTO = new LeaveRequest();
            if (dt.Rows.Count > 0)
            {
                DTO.EmpID = (int)dt.Rows[0]["EmpID"];
                DTO.ManagerID = (int)dt.Rows[0]["ManagerID"];
                DTO.TeamID = (int)dt.Rows[0]["TeamID"];    
            }
            return DTO;
        }
        public LeaveRequest GetApprovalTeamManagerID(int EmpID)
        {
            String Query = "SELECT DISTINCT "
                              + " EmpID"
                              + " ,TeamID"
                              + " ,MT.ManagerID "
                              + " FROM Employee_OccupationDetails EO"
                              + " INNER JOIN "
                              + " 	Leave_Request LR"
                              + " ON"
                              + " 	LR.EmpID=EO.EmployeeID"
                              + " INNER JOIN "
                              + " 	Master_Team MT"
                              + " ON"
                              + " 	MT.ID=EO.TeamID"
                              + " 	WHERE LR.ManagerID={0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = String.Format(Query, EmpID.ToString());
            DataTable dt = EE.ExecuteDataTable(exQry);
            LeaveRequest DTO = new LeaveRequest();
            if (dt.Rows.Count > 0)
            {
                DTO.EmpID = (int)dt.Rows[0]["EmpID"];
                DTO.ManagerID = (int)dt.Rows[0]["ManagerID"];
                DTO.TeamID = (int)dt.Rows[0]["TeamID"];
            }
            return DTO;
        }

        public Leave_RequestEXT[] GetLeaveRequestApp(int ManagerID)
        {
            const String Qry = "SELECT LR.ID "
                              + " 		,LR.EmpID "
                              + " 		,LR.LeaveID "
                              + " 		,LR.FromDate "
                              + " 		,LR.ToDate 	"
                              + "  		,DaysCount "
                              + " 		,LR.Reason "
                              + " 		,LR.AppliedDateTime "
                              + " 		,LR.Status 	"
                              + " 		,''LeaveType  "
                              + " 		,ManagerID  "
                              + " 		,ManagerComments  "
                              + " 		,(FirstName+ ' '+MiddleName+' '+LastName)Employeename"
                              + " 	FROM Leave_Request LR   "
                              //+ " 	INNER JOIN 	"
                              //+ " 		Master_Leave ML  "
                              //+ " 	ON 	"
                              //+ " 		ML.ID = LR.LeaveID "
                              + " 	INNER JOIN"
                              + " 		Master_Employees ME"
                              + " 	ON"
                              + " 		ME.ID=LR.EmpID"
                              + " 	WHERE LR.ManagerID = '{0}' AND LR.Status = 'REQ'  "
                              + " UNION ALL "
                              + " 	SELECT LR.ID "
                              + " 		,LR.EmpID "
                              + " 		,LR.LeaveID "
                              + " 		,LR.FromDate "
                              + " 		,LR.ToDate "
                              + " 		,DaysCount "
                              + " 		,LR.Reason "
                              + " 		,LR.AppliedDateTime "
                              + " 		,LR.Status "
                              + " 		,''LeaveType "
                              + " 		,ManagerID "
                              + " 		,ManagerComments  "
                              + " 		,(FirstName+ ' '+MiddleName+' '+LastName)Employeename"
                              + " 	FROM Leave_Request LR "
                              //+ " 	INNER JOIN "
                              //+ " 		Master_Leave ML "
                              //+ " 	ON 	"
                              //+ " 		ML.ID = LR.LeaveID 	"
                              + " 	INNER JOIN"
                              + " 		Master_Employees ME"
                              + " 	ON"
                              + " 		ME.ID=LR.EmpID"
                              + " 	WHERE LR.ManagerID = '{0}' AND LR.Status = 'APP'  "
                              + " UNION ALL "
                              + " 		SELECT LR.ID "
                              + " 		,LR.EmpID "
                              + " 		,LR.LeaveID "
                              + " 		,LR.FromDate "
                              + " 		,LR.ToDate "
                              + "  		,DaysCount "
                              + " 		,LR.Reason "
                              + " 		,LR.AppliedDateTime "
                              + " 		,LR.Status "
                              + " 		,''LeaveType "
                              + " 		,ManagerID "
                              + " 		,ManagerComments  "
                              + " 		,(FirstName+ ' '+MiddleName+' '+LastName)Employeename"
                              + " 	FROM Leave_Request LR  "
                              //+ " 	INNER JOIN 		"
                              //+ " 		Master_Leave ML "
                              //+ " 	ON 	"
                              //+ " 		ML.ID = LR.LeaveID "
                              + " 	INNER JOIN"
                              + " 		Master_Employees ME"
                              + " 		ON"
                              + " 	ME.ID=LR.EmpID"
                              + " 	WHERE LR.ManagerID = '{0}' AND LR.Status = 'REJ' ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, ManagerID.ToString());
            DataTable dt = EE.ExecuteDataTable(exQry);

            Leave_RequestEXT[] DTO = new Leave_RequestEXT[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Leave_RequestEXT();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].EmpID = (int)dt.Rows[i]["EmpID"];
                DTO[i].LeaveID = (int)dt.Rows[i]["LeaveID"];
                DTO[i].ManagerID = (int)dt.Rows[i]["ManagerID"];
                DTO[i].DaysCount = (double)dt.Rows[i]["DaysCount"];
                DTO[i].FromDate = (DateTime)dt.Rows[i]["FromDate"];
                DTO[i].ToDate = (DateTime)dt.Rows[i]["ToDate"];
                DTO[i].AppliedDateTime = (DateTime)dt.Rows[i]["AppliedDateTime"];
                DTO[i].Reason = (String)dt.Rows[i]["Reason"];
                DTO[i].Status = (String)dt.Rows[i]["Status"];
                DTO[i].EmployeeName = (String)dt.Rows[i]["Employeename"];
                DTO[i].ManagerComments = (String)dt.Rows[i]["ManagerComments"];
            }

            return DTO;
        }
        public Leave_Request GetDate(int EmpID,String Status)
        {
            String Query = "SELECT "
                          + " 	EmpID"
                          + " 	,FromDate 	"
                          + " 	,ToDate 	"
                          + " 	,DaysCount"
                          + " 	,ModifiedDate "
                          + " FROM  Leave_Request "
                          + " WHERE EmpID={0} AND Status='{1}'"
                          + " AND "
                          + " 	ModifiedDate ="
                          + " 	("
                          + " 		Select "
                          + " 		MAX(ModifiedDate) "
                          + " 		From "
                          + " 		Leave_Request "
                          + " 		WHERE EmpID={0} AND Status='{1}'"
                          + " 	)";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = String.Format(Query, EmpID.ToString(),Status);
            DataTable dt = EE.ExecuteDataTable(exQry);
            Leave_Request DTO = new Leave_Request();
            if (dt.Rows.Count > 0)
            {
                DTO.EmpID = (int)dt.Rows[0]["EmpID"];
                DTO.FromDate = (DateTime)dt.Rows[0]["FromDate"];
                DTO.ToDate = (DateTime)dt.Rows[0]["ToDate"];
                DTO.DaysCount = (double)dt.Rows[0]["DaysCount"];
            } 
            return DTO;
        }

        public DataTable GetLeaveReportBalance(int cmbteamname)
        {
            const String qry = "sp_LeaveBalance_report '{0}'";
            ExecutionEngine ee = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            var exQry = new ExecutionQuery {Query = string.Format(qry, cmbteamname)};
            return ee.ExecuteDataTable(exQry);
        }
        public DataTable GetLeaveReportRequest(string fromDate, string toDate, int cmbteamname)
        {
            const String qry = "sp_leave_request_report '{0}','{1}',{2}";
            ExecutionEngine ee = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            var exQry = new ExecutionQuery { Query = string.Format(qry, fromDate, toDate, cmbteamname) };
            return ee.ExecuteDataTable(exQry);
        }
        public DataTable GetLeaveReportActivity(string fromDate, string toDate, int cmbteamname)
        {
            const String qry = "sp_LeaveActivity_Report '{0}','{1}',{2}";
            ExecutionEngine ee = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            var exQry = new ExecutionQuery { Query = string.Format(qry, fromDate, toDate, cmbteamname) };
            return ee.ExecuteDataTable(exQry);
        }
        public DataTable GetWorkFromHomeReport(string fromDate, string toDate, int cmbteamname)
        {
            const String qry = "sp_leave_request_workfromhome_report '{0}','{1}',{2}";
            ExecutionEngine ee = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            var exQry = new ExecutionQuery { Query = string.Format(qry, fromDate, toDate, cmbteamname) };
            return ee.ExecuteDataTable(exQry);
        }
    }
}
