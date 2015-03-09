using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;
using HRManager.Entity;

namespace HRManager.BusinessObjects
{
    public partial class Master_LeaveBusinessObject
    {
        /// <summary>
        /// Get Grade By Grade Name
        /// </summary>
        /// <param name="GradeName">field contaions Grade Name</param>
        /// <returns>data related given Designation Name in case of success otherwise it return null</returns>
        public Master_Leave GetLeaveByLeave(String LeaveType)
        {
            Master_Leave[] Leave = GetLeaves(" LeaveType = '" + LeaveType + "'");

            if (Leave != null && Leave.Length > 0)
            {
                return Leave[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Get LocationTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        public Master_Leave[] GetAllLeaves()
        {
            const String Qry = " SELECT * FROM Master_Leave WHERE IsActive=1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_Leave[] LeaveDetails = new Master_Leave[dt.Rows.Count];

            for (int i = 0; i < LeaveDetails.Length; i++)
            {
                LeaveDetails[i] = new Master_Leave();


                LeaveDetails[i].ID = (int)dt.Rows[i]["ID"];
                LeaveDetails[i].LeaveType = (String)dt.Rows[i]["LeaveType"];
                LeaveDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];

            }

            return LeaveDetails;
        }

        /// <summary>
        /// Get LocationTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        public Master_Leave[] GetAllLeaveForCombo()
        {
            const String Qry = " SELECT * FROM Master_Leave WHERE IsActive=1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_Leave[] LeaveDetails = new Master_Leave[dt.Rows.Count];

            for (int i = 0; i < LeaveDetails.Length; i++)
            {
                LeaveDetails[i] = new Master_Leave();


                LeaveDetails[i].ID = (int)dt.Rows[i]["ID"];
                LeaveDetails[i].LeaveType = (String)dt.Rows[i]["LeaveType"];
                LeaveDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];

            }

            return LeaveDetails;
        }

        /// <summary>
        /// Get Designation By Designation Name
        /// </summary>
        /// <param name="DesignationName">field contaions Designation Name</param>
        /// <returns>data related given Designation Name in case of success otherwise it return null</returns>
        public Master_Leave[] GetAllInActiveLeavesOrderByLeave()
        {
            Master_Leave[] Leave = GetAllInActiveLeave();

            if (Leave != null && Leave.Length >= 0)
            {
                return Leave;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Get LocationTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        public Master_Leave[] GetAllInActiveLeave()
        {
            const String Qry = "SELECT * FROM Master_Leave WHERE IsActive=0";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);


            Master_Leave[] LeaveDetails = new Master_Leave[dt.Rows.Count];

            for (int i = 0; i < LeaveDetails.Length; i++)
            {
                LeaveDetails[i] = new Master_Leave();


                LeaveDetails[i].ID = (int)dt.Rows[i]["ID"];
                LeaveDetails[i].LeaveType = (String)dt.Rows[i]["LeaveType"];
                LeaveDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];

            }

            return LeaveDetails;
        }

        /// <summary>
        /// Get LocationTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        public Master_Leave[] GetAllActiveLeave()
        {
            const String Qry = "SELECT * FROM Master_Leave WHERE IsActive=1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);
            Master_Leave[] LeaveDetails = new Master_Leave[dt.Rows.Count];

            for (int i = 0; i < LeaveDetails.Length; i++)
            {
                LeaveDetails[i] = new Master_Leave();


                LeaveDetails[i].ID = (int)dt.Rows[i]["ID"];
                LeaveDetails[i].LeaveType = (String)dt.Rows[i]["LeaveType"];
                LeaveDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];

            }

            return LeaveDetails;
        }
        //public LeaveCalenderDetails GetActiveLeaveCalenderDetails(int ID)
        //{
        //    //const String Qry = " select ML.LeaveType, " +
        //    //                    " 'Status' = CASE WHEN LR.Status = 'REQ' THEN 'Requested' " +
        //    //                    " WHEN LR.Status = 'APP' THEN 'Approved' " +
        //    //                    " ELSE 'NEW' END,LR.DayCount,MC.Firstname+' '+isnull(MC.Lastname,'') AppliedManager, " +
        //    //                    " LR.Reason,managerremarks " +
        //    //                    "   FROM Leave_Request LR " +
        //    //                    " inner join master_leave ML on (LR.Leaveid=ML.id)  " +
        //    //                    " inner join master_Employees ME on (ME.id=LR.AppliedTo) " +
        //    //                    " inner join master_Candidate MC on (MC.id=ME.CandidateID) " +
        //    //                    " where LR.ID = '{0}'";
        //    const String Qry = "select ML.LeaveType, " +
        //        " 'Status' = CASE WHEN LR.ReprotingMgrStatus = 'REQ' THEN 'Requested'  WHEN LR.ReprotingMgrStatus = 'APP' THEN 'Approved'  ELSE 'NEW' END," +
        //        " LR.DayCount,MC.Firstname+' '+isnull(MC.Lastname,'') 'AppliedManager', " +
        //        " 'FunctionalManagerStatus'= CASE WHEN LR.FunctionalMgrStatus = 'REQ' THEN 'Requested'  WHEN LR.FunctionalMgrStatus = 'APP' THEN 'Approved'  ELSE 'NEW' END," +
        //        " (select Firstname+' '+isnull(Lastname,'') from master_Employees, master_Candidate where master_Candidate.id=master_Employees.CandidateID and  master_Employees.id=LR.FunctionalMgr) 'FunctionalManager'," +
        //        " LR.Reason,managerremarks " +
        //        " FROM Leave_Request LR  inner join master_leave ML on (LR.Leaveid=ML.id) " +
        //        " inner join master_Employees ME on (ME.id=LR.ReprotingMgr) " +
        //        " inner join master_Candidate MC on (MC.id=ME.CandidateID) " +
        //        " where LR.ID = '{0}'";

        //    ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
        //    ExecutionQuery exQry = new ExecutionQuery();
        //    exQry.Query = string.Format(Qry, ID);
        //    DataTable dt = EE.ExecuteDataTable(exQry);
        //    LeaveCalenderDetails LeaveDetails = new LeaveCalenderDetails();

        //    //for (int i = 0; i < LeaveDetails.Length; i++)
        //    //{
        //    //LeaveDetails[i] = new LeaveCalenderDetails();

        //    LeaveDetails.LeaveType = (string)dt.Rows[0]["LeaveType"];
        //    LeaveDetails.Status = (string)dt.Rows[0]["Status"];
        //    LeaveDetails.DayCount = (Double)dt.Rows[0]["DayCount"];
        //    LeaveDetails.AppliedManager = (string)dt.Rows[0]["AppliedManager"];
        //    LeaveDetails.managerremarks = (string)dt.Rows[0]["managerremarks"];
        //    LeaveDetails.FunctionalManager = (string)dt.Rows[0]["FunctionalManager"];
        //    LeaveDetails.FunctionalManagerStatus = (string)dt.Rows[0]["FunctionalManagerStatus"];
        //    LeaveDetails.Reason = (string)dt.Rows[0]["Reason"];
        //    //}

        //    return LeaveDetails;
        //}
        //Backup of Upper code
        //public LeaveCalender[] GetAllActiveLeaveCalender(int EmployeeID)
        //{
        //    const String Qry = "SELECT ID,FromDate,ToDate FROM Leave_Request where (status='{0}' or status = '{1}') and EmpID = '{2}'";
        //    ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
        //    ExecutionQuery exQry = new ExecutionQuery();
        //    exQry.Query = string.Format(Qry, LeaveAppCommands.LEAVE_REQ_STATUS_APPROVE, LeaveAppCommands.LEAVE_REQ_STATUS_REQUEST, EmployeeID);
        //    DataTable dt = EE.ExecuteDataTable(exQry);
        //    LeaveCalender[] LeaveDetails = new LeaveCalender[dt.Rows.Count];

        //    for (int i = 0; i < LeaveDetails.Length; i++)
        //    {
        //        LeaveDetails[i] = new LeaveCalender();

        //        LeaveDetails[i].id = (int)dt.Rows[i]["ID"];
        //        LeaveDetails[i].title = "Leave Request";
        //        LeaveDetails[i].start = (DateTime)dt.Rows[i]["FromDate"];
        //        LeaveDetails[i].end = (DateTime)dt.Rows[i]["ToDate"];
        //    }

        //    return LeaveDetails;
        //}
        /// <summary>
        /// Get Leave Type data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Hr_Grade object</returns>
        public Master_Leave[] GetLeaves(String Filter)
        {
            const String Qry = " SELECT * FROM Master_Leave";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            if (Filter == String.Empty)
            {
                exQry.Query = string.Format(Qry);
            }
            else
            {
                exQry.Query = string.Format(Qry) + " WHERE " + Filter;
            }

            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_Leave[] LeaveDetails = new Master_Leave[dt.Rows.Count];

            for (int i = 0; i < LeaveDetails.Length; i++)
            {
                LeaveDetails[i] = new Master_Leave();


                LeaveDetails[i].ID = (int)dt.Rows[i]["ID"];
                LeaveDetails[i].LeaveType = (String)dt.Rows[i]["LeaveType"];
                LeaveDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];

            }

            return LeaveDetails;
        }

        /// <summary>
        /// Get LeaveTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        public Master_Leave[] GetAllActLeaves()
        {
            const String Qry = " SELECT * FROM Master_Leave WHERE IsActive=1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_Leave[] LeaveDetails = new Master_Leave[dt.Rows.Count];

            for (int i = 0; i < LeaveDetails.Length; i++)
            {
                LeaveDetails[i] = new Master_Leave();


                LeaveDetails[i].ID = (int)dt.Rows[i]["ID"];
                LeaveDetails[i].LeaveType = (String)dt.Rows[i]["LeaveType"];
                LeaveDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];

            }

            return LeaveDetails;
        }

        /// <summary>
        /// check Grade Existance in the database.
        /// </summary>
        /// <param name="Grade">field contains Grade name</param>
        /// <param name="ID">field contains Grade ID</param>
        /// <returns>True for Exist and false for not exist</returns>
        public bool IsLeaveExists(String LeaveType, int ID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Master_Leave WHERE LeaveType = '{0}' AND ID<>{1})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, LeaveType, ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }
        public string GetLeaveID(string LeaveType)
        {
            const String Qry = " SELECT ID FROM Master_Leave WHERE LeaveType = '{0}' ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, LeaveType);

            object ret = EE.ExecuteScalar(exQry);
            return string.Concat(ret, string.Empty);
        }

        public bool IsLeaveRefered(int ID)
        {
            const String Qry = " IF EXISTS ( SELECT ID FROM Leave_Request WHERE LeaveID = '{0}') "
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }

    }
}
