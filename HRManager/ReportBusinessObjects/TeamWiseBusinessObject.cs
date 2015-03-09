using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS91.Services.DataBlock;
using HRManager.DTO;
using System.Data;
namespace HRManager.ReportBusinessObjects
{
    public partial class TeamWiseBusinessObject
    {
        public DataTable GetTeamWiseBusinessObject(int IsTeam,int ID)
        {
            const String Qry = "sp_GetUspAssetsAssigned {0},{1}";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, IsTeam,ID);
            return EE.ExecuteDataTable(exQry);
        }
        public DataTable GetOutgoingAssetsBusinessObject(string fromdate,string todate)
        {
            const String Qry = "sp_UspGetOutstandingAsset '{0}','{1}'";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, fromdate, todate);
            return EE.ExecuteDataTable(exQry);
        }
        public DataTable GetTeamWiseEmployeeBusinessObject(int TeamID)
        {
            const String Qry = "sp_team_wise_employee {0}";
            
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, TeamID);
            return EE.ExecuteDataTable(exQry);
        }
        public DataTable GetAssetCategoryBusinessObject(int AssetCategoryID)
        {
            const String Qry = "sp_manage_category_id {0}";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, AssetCategoryID);
            return EE.ExecuteDataTable(exQry); 
        }
        public DataTable GetAssetSubCategoryBusinessObject(int AssetSubCategoryID)
        {
            const String Qry = "sp_manage_sub_category_id {0}";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, AssetSubCategoryID);
            return EE.ExecuteDataTable(exQry);
        }
        public DataTable GetAllAssetBusinessObject()
        {
            const String Qry = "sp_manage_all_assets";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            return EE.ExecuteDataTable(exQry);
        }
        public DataTable GetExitMgmtAssetsBusinessObject()
        {
            const String Qry = "sp_EmployeeExit ";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            return EE.ExecuteDataTable(exQry);
        }
        public DataTable GetEmployeeJoiningtypeBusinessObject(String FromDate,String ToDate)
        {
            const String Qry = "sp_employee_joining_report '{0}','{1}'";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, FromDate,ToDate);
            return EE.ExecuteDataTable(exQry);
        }
        public DataTable GetEmployeetypeBusinessObject(String EmploymentType)
        {
            const String Qry = "sp_employee_by_employeetype '{0}'";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry,EmploymentType);
            return EE.ExecuteDataTable(exQry);
        }

        public DataTable GetAllEmpdetailsBusinessObject()
        {
            const String Qry = "sp_all_employee_details ";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            return EE.ExecuteDataTable(exQry);
        }
        public DataTable GetAllEmpCareerSumary(int EmpID)
        {
            const String Qry = "AllEMPCreerSummarySubReport {0}";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmpID);
            return EE.ExecuteDataTable(exQry);
        }
        public DataTable GetAllEmpEducationDetails(int EmpID)
        {
            const String Qry = "AllEMPEducationDetailsSubReport {0} ";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmpID);
            return EE.ExecuteDataTable(exQry);
        }
        public DataSet GetEmployeedetailsBusinessObject(int EmpID)
        {
            const String Qry = "EmployeeDetailsReport '{0}'";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmpID);
            return EE.ExecuteDataSet(exQry);
        }
        
    }
}
