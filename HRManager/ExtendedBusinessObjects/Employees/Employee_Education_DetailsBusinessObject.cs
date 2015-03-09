using System;
using System.Data;
using IS91.Services.DataBlock;
using System.Collections;
using HRManager.DTO;
using HRManager.Entity.EmployeesInfo;

namespace HRManager.BusinessObjects
{
    public partial class Employee_Education_DetailsBusinessObject
    {
        private Employee_Education_Details[] GetEducationalDetails(String Filter)
        {
            String Qry = " SELECT * FROM Employee_Education_Details ";

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

            Employee_Education_Details[] DTO = new Employee_Education_Details[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Employee_Education_Details();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].EmployeeID = (int)dt.Rows[i]["EmployeeID"];
                DTO[i].Education = (String)dt.Rows[i]["Education"];
                DTO[i].Stream = (String)dt.Rows[i]["Stream"];
                DTO[i].University = (String)dt.Rows[i]["University"];
                DTO[i].Percentage = (double)dt.Rows[i]["Percentage"];
                DTO[i].Year = (int)dt.Rows[i]["Year"];
              
            }

            return DTO;
        }

        public Employee_Education_Details[] GetEducationalDetails(int EmployeeID)
        {
            return GetEducationalDetails(" EmployeeID  = " + EmployeeID);
        }
    
        public bool IsEducationExists(String Education, int EmployeeID,int ID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Employee_Education_Details WHERE Education = '{0}' AND EmployeeID = {1} and ID<>{2})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, Education, EmployeeID,ID);
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }
    }
}
