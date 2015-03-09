using System;
using System.Data;
using IS91.Services.DataBlock;
using System.Collections;
using HRManager.DTO;
using HRManager.Entity.EmployeesInfo;

namespace HRManager.BusinessObjects
{
    public partial class Employee_CareerBusinessObject
    {
        private Employee_Career[] GetCareerDetails(String Filter)
        {
            String Qry = " SELECT * FROM Employee_Career ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            if (Filter == "")
            {
                exQry.Query = Qry;
            }
            else
            {
                exQry.Query = String.Format(Qry) + " WHERE " + Filter;
            }

            DataTable dt = EE.ExecuteDataTable(exQry);

            Employee_Career[] DTO = new Employee_Career[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Employee_Career();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].EmployeeID = (int)dt.Rows[i]["EmployeeID"];
                DTO[i].CompanyName = (String)dt.Rows[i]["CompanyName"];
                DTO[i].StartDate = (DateTime)dt.Rows[i]["StartDate"];
                DTO[i].EndDate = (DateTime)dt.Rows[i]["EndDate"];
                DTO[i].IsFresher = (bool)dt.Rows[i]["IsFresher"];
            }

            return DTO;
        }

        public Employee_Career[] GetCareerDetails(int EmployeeID)
        {
            return GetCareerDetails(" EmployeeID  = " + EmployeeID);
        }
       
        public bool IsCompanyExists(String CompanyName, int EmployeeID,int ID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Employee_Career WHERE CompanyName = '{0}'  AND EmployeeID = {1} and ID<>{2})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, CompanyName, EmployeeID,ID);
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }

        public bool CheckIsFresher(int EmpID,bool isfresher)
        {
            String Qry = "Select  ID  From Employee_Career Where EmployeeID = {0} AND IsFresher='{1}'";


            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = String.Format(Qry, EmpID, isfresher);

            DataTable dtTable = EE.ExecuteDataTable(exQry);

            if (dtTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
    }
}
