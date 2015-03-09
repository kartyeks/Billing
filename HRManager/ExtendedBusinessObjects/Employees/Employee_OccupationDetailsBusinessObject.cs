using System;
using System.Data;
using IS91.Services.DataBlock;
using System.Collections;
using HRManager.DTO;
using HRManager.Entity.EmployeesInfo;

namespace HRManager.BusinessObjects
{
    public partial class Employee_OccupationDetailsBusinessObject
    {
        private Employee_OccupationDetails[] GetOccupationalDetails(String Filter)
        {
            String Qry = " SELECT DISTINCT"  
                              + "  ID"  
                              + "  ,EmployeeID "  
                              + "  ,CountryID"  
                              + "  ,LocationID"  
                              + "  ,JoiningDate"  
                              + "  ,ExitDate"  
                              + "  ,TypeOfExitID "  
                              + " ,[dbo].[GetLeavesCount](EmployeeID)LeavesCount"  
                              + "  ,TeamID"  
                              + "  ,DesignationID"  
                              + "  ,EmailID"  
                              + "  ,IsActive"  
                              + "  ,ActivatedBy"  
                              + "  ,ActivatedDate"  
                              + "  ,FinancialMonth"
                              +"   ,FinancialYear"
                              + " FROM dbo.Employee_OccupationDetails " ;

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            if (Filter == String.Empty)
            {
                exQry.Query = Qry;
            }
            else
            {
                exQry.Query = Qry + " WHERE " + Filter;
            }

            DataTable dt = EE.ExecuteDataTable(exQry);

            Employee_OccupationDetails[] DTO = new Employee_OccupationDetails[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Employee_OccupationDetails();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].EmployeeID = (int)dt.Rows[i]["EmployeeID"];
                DTO[i].CountryID = (int)dt.Rows[i]["CountryID"];
                DTO[i].LocationID = (int)dt.Rows[i]["LocationID"];
                DTO[i].DesignationID = (int)dt.Rows[i]["DesignationID"];
                DTO[i].TypeOfExitID = (int)dt.Rows[i]["TypeOfExitID"];
                DTO[i].TeamID = (int)dt.Rows[i]["TeamID"];
                DTO[i].JoiningDate = (DateTime)dt.Rows[i]["JoiningDate"];
                DTO[i].ExitDate = (DateTime)dt.Rows[i]["ExitDate"];
                DTO[i].LeavesCount = (Double)dt.Rows[i]["LeavesCount"];
                DTO[i].EmailID = (string)dt.Rows[i]["EmailID"];
                DTO[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                DTO[i].ActivatedBy = (int)dt.Rows[i]["ActivatedBy"];
                DTO[i].ActivatedDate = (DateTime)dt.Rows[i]["ActivatedDate"];
                DTO[i].FinancialMonth = (int)dt.Rows[i]["FinancialMonth"];
                DTO[i].FinancialYear = (int)dt.Rows[i]["FinancialYear"];
               
            }

            return DTO;
        }

        public Employee_OccupationDetails GetOccupationalDetails(int EmployeeID)
        {
            Employee_OccupationDetails[] DTO = GetOccupationalDetails(" IsActive = 1 AND EmployeeID = " + EmployeeID);

            if (DTO.Length == 1)
            {
                return DTO[0];
            }

            return null;
        }

        public bool IsEmailExists(String EmailID, int EmployeeID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Employee_OccupationDetails WHERE EmailID = '{0}' AND EmailID <> ''  AND IsActive=1 AND ID <> {1})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmailID, EmployeeID);
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }

        public void UpdateAnualLeave(int LeaveCount, int curYear)
        {
            const String Qry = "Update dbo.Employee_OccupationDetails Set FinancialMonth=4,FinancialYear={1},LeavesCount=LeavesCount + {0}" +
                               " WHERE FinancialYear<>{1} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, LeaveCount, curYear);
            EE.ExecuteNonQuery(exQry);
        }
    }
}
