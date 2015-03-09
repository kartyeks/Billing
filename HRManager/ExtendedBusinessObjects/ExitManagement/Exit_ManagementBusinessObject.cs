using System;
using System.Globalization;
using HRManager.DTO;
using IS91.Services.DataBlock;
using System.Data;
using HRManager.DTOEXT;

namespace HRManager.BusinessObjects
{
    public partial class ExitManagementBusinessObject
    {
        public Exit_ManagementEXT[] GetExitManagement()
        {
            const String qry = " SELECT  "
                                  + " 	EM.ID "
                                  + " 	,(ME.FirstName+ ' '+MiddleName+' '+ME.LastName)EmployeeName "
                                  + " 	,EmpCode "
                                  + " 	,EM.EmployeeID "
                                  + " 	,TypeOfExitID  "
                                  + " 	,EO.ExitDate"
                                  + " 	,DocumentName"
                                  + " 	,'ExitType'=CASE WHEN (TypeOfExitID=1)THEN 'Resigned' ELSE 'Terminated' END "
                                  + " FROM  Employee_OccupationDetails EO "
                                  + " INNER JOIN "
                                  + " 	Master_Employees ME "
                                  + " ON "
                                  + " 	ME.ID=EO.EmployeeID "
                                  + " INNER JOIN "
                                  + " 	Exit_Management EM "
                                  + " ON "
                                  + " 	EM.EmployeeID=EO.EmployeeID"
                                  + " WHERE TypeOfExitID!=0 AND EO.IsActive=1 AND EM.IsActive=1 ORDER BY EM.ExitDate";

            ExecutionEngine ee = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            var exQry = new ExecutionQuery { Query = string.Format(qry) };
            DataTable dt = ee.ExecuteDataTable(exQry);
            var dto = new Exit_ManagementEXT[dt.Rows.Count];

            for (int i = 0; i < dto.Length; i++)
            {
                dto[i] = new Exit_ManagementEXT
                {
                    ID = (int)dt.Rows[i]["ID"],
                    EmployeeID = (int)dt.Rows[i]["EmployeeID"],
                    EmployeeName = (String)dt.Rows[i]["EmployeeName"],
                    ExitTypeID = (int)dt.Rows[i]["TypeOfExitID"],
                    ExitDate = (DateTime)dt.Rows[i]["ExitDate"],
                    ExitType = (String)dt.Rows[i]["ExitType"],
                    EmployeeCode = (String)dt.Rows[i]["EmpCode"],
                    DocumentName = (String)dt.Rows[i]["DocumentName"]
                };

            }

            return dto;
        }
        public Exit_ManagementEXT[] GetEMPExitManagement(int employeeId)
        {
            const String qry = "  SELECT DISTINCT  "
                                  + " 	EO.EmployeeID ID"
                                  + " 	,(ME.FirstName+ ' '+MiddleName+' '+ME.LastName)EmployeeName    "
                                  + " 	,EO.EmployeeID  "
                                  + " 	,TypeOfExitID   "
                                  + " 	,EO.ExitDate  "
                                  + " 	,ISNULL(DocumentName,'')DocumentName   "
                                  + " 	,EmpCode  "
                                  + " 	,'ExitType'=CASE WHEN (TypeOfExitID=1)THEN 'Resigned' ELSE 'Terminated' END    "
                                  + " FROM Employee_OccupationDetails EO    "
                                  + " INNER JOIN "
                                  + " 	Master_Employees ME  "
                                  + " ON "
                                  + " 	ME.ID=EO.EmployeeID    "
                                  + " LEFT JOIN "
                                  + " 	Exit_Management EM "
                                  + " ON "
                                  + " 	(EM.EmployeeID=EO.EmployeeID AND EM.IsActive=1) "
                                  + " WHERE TypeOfExitID!=0 "
                                  //+ " AND EO.EmployeeID={0} "                                 
                                  + " AND EO.IsActive=1";

            ExecutionEngine ee = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            var exQry = new ExecutionQuery { Query = string.Format(qry, employeeId) };
            DataTable dt = ee.ExecuteDataTable(exQry);
            var dto = new Exit_ManagementEXT[dt.Rows.Count];
            for (int i = 0; i < dto.Length; i++)
            {
                dto[i] = new Exit_ManagementEXT
                {
                    ID = (int)dt.Rows[i]["ID"],
                    EmployeeID = (int)dt.Rows[i]["EmployeeID"],
                    EmployeeName = (String)dt.Rows[i]["EmployeeName"],
                    ExitTypeID = (int)dt.Rows[i]["TypeOfExitID"],
                    ExitDate = (DateTime)dt.Rows[i]["ExitDate"],
                    ExitType = (String)dt.Rows[i]["ExitType"],
                    EmployeeCode = (String)dt.Rows[i]["EmpCode"],
                    DocumentName = (String)dt.Rows[i]["DocumentName"]
                };
            }
            return dto;
        }
        public UploadExitManagementEXT UploadExitManagement(int EmployeeID)
        {
            const String Qry = "SELECT DISTINCT  "
                                  + " 	EO.EmployeeID ID"
                                  + " 	,(ME.FirstName+ ' '+MiddleName+' '+ME.LastName)EmployeeName    "
                                  + " 	,EO.EmployeeID  "
                                  + " 	,ISNULL(EM.EmployeeID,0) EmpExitID  "
                                  + " 	,TypeOfExitID   "
                                  + " 	,EO.ExitDate  "
                                  + " 	,ISNULL(DocumentName,'')DocumentName   "
                                  + " 	,EmpCode  "
                                  + " 	,'ExitType'=CASE WHEN (TypeOfExitID=1)THEN 'Resigned' ELSE 'Terminated' END    "
                                  + " FROM Employee_OccupationDetails EO    "
                                  + " INNER JOIN "
                                  + " 	Master_Employees ME  "
                                  + " ON "
                                  + " 	ME.ID=EO.EmployeeID    "
                                  + " LEFT JOIN "
                                  + " 	Exit_Management EM "
                                  + " ON "
                                  + " 	(EM.EmployeeID=EO.EmployeeID AND EM.IsActive=1) "
                                  + " WHERE TypeOfExitID!=0 "
                                  + " AND EO.EmployeeID={0} "
                                  + " AND EO.IsActive=1";
                                 

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmployeeID.ToString());
            DataTable dt = EE.ExecuteDataTable(exQry);

            UploadExitManagementEXT DTO = new UploadExitManagementEXT();

            if (dt.Rows.Count > 0)
            {
                DTO.ID = (int)dt.Rows[0]["ID"];
                DTO.EmployeeID = (int)dt.Rows[0]["EmployeeID"];
                DTO.ExitTypeID = (int)dt.Rows[0]["TypeOfExitID"];
                DTO.ExitDate = (DateTime)dt.Rows[0]["ExitDate"];
                DTO.DocumentName = (string)dt.Rows[0]["DocumentName"];
                DTO.EmpExitID = (int)dt.Rows[0]["EmpExitID"];
            }
            return DTO;
        }

        public Exit_Management DownLoadExitManagement(String EmployeeID)
        {
            const String Qry = "SELECT EmployeeID,DocumentName FROM  Exit_Management  WHERE  EmployeeID={0} AND IsActive=1  ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmployeeID);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Exit_Management DTO = new Exit_Management();

            if (dt.Rows.Count > 0)
            {
                DTO.EmployeeID = (int)dt.Rows[0]["EmployeeID"];
                DTO.DocumentName = (string)dt.Rows[0]["DocumentName"];
            }
            return DTO;
        }
        public Exit_Management GETExitManagement(int EmployeeID)
        {
            const String Qry = "SELECT EmployeeID,DocumentName FROM  Exit_Management  WHERE  EmployeeID={0} AND IsActive=1  ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmployeeID);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Exit_Management DTO = new Exit_Management();

            if (dt.Rows.Count > 0)
            {
                DTO.EmployeeID = (int)dt.Rows[0]["EmployeeID"];
                DTO.DocumentName = (string)dt.Rows[0]["DocumentName"];
            }
            return DTO;
        }

        public void ISActiveUpdate(int EmployeeID)
        {
            String Qry = " UPDATE Exit_Management SET IsActive=0 WHERE EmployeeID = {0} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = String.Format(Qry, EmployeeID);

            EE.ExecuteNonQuery(exQry);
        }


        public DataTable GetHrEmailIDs()
        {
            const String qry = "exec GetHRManagerData ";
            ExecutionEngine ee = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            var exQry = new ExecutionQuery { Query = string.Format(qry) };
            return ee.ExecuteDataTable(exQry);
        }
        public DataTable GetAdminEmailIDs()
        {
            const String qry = "exec GetAdminData ";
            ExecutionEngine ee = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            var exQry = new ExecutionQuery { Query = string.Format(qry) };
            return ee.ExecuteDataTable(exQry);
        }

        public DataTable GetManagerEmailIDs(int employeeId)
        {
            const String qry = "GetTeamWiseManagerData {0} ";
            ExecutionEngine ee = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            var exQry = new ExecutionQuery { Query = string.Format(qry, employeeId.ToString(CultureInfo.InvariantCulture)) };
            return ee.ExecuteDataTable(exQry);
        }

        public DataTable GetExitManagementResignationReport(string fromDate, string toDate)
        {
            const String qry = "sp_ExitManagement_Resignation_Report '{0}','{1}'";
            ExecutionEngine ee = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            var exQry = new ExecutionQuery { Query = string.Format(qry, fromDate, toDate) };
            return ee.ExecuteDataTable(exQry);
        }
        public DataTable GetExitManagementTerminationReport(string fromDate, string toDate)
        {
            const String qry = "sp_ExitManagement_Termination_Report '{0}','{1}'";
            ExecutionEngine ee = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            var exQry = new ExecutionQuery { Query = string.Format(qry, fromDate, toDate) };
            return ee.ExecuteDataTable(exQry);
        }
        public DataTable GetExitManagementTeamWiseReport(int cmbteamname)
        {
            const String qry = "sp_ExitManagement_TeamWise_Report '{0}'";
            ExecutionEngine ee = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            var exQry = new ExecutionQuery { Query = string.Format(qry, cmbteamname) };
            return ee.ExecuteDataTable(exQry);
        }
        public DataTable GetRoleEmailANDName(int employeeId)
        {
            const String qry = "exec GetRoleData {0} ";
            ExecutionEngine ee = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            var exQry = new ExecutionQuery { Query = string.Format(qry, employeeId) };
            return ee.ExecuteDataTable(exQry);
        }

    }
}
