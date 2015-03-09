using System;
using System.Data;
using IS91.Services.DataBlock;
using System.Collections;
using HRManager.DTO;
using HRManager.Entity.EmployeesInfo;

namespace HRManager.BusinessObjects
{
    public partial class Employee_DocumentsBusinessObject
    {
        private Employee_Documents[] GetDocuments(String Filter)
        {
            String Qry = " SELECT * FROM Employee_Documents";

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
            Employee_Documents[] DTO = new Employee_Documents[dt.Rows.Count];
            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Employee_Documents();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].EmployeeID = (int)dt.Rows[i]["EmployeeID"];
                DTO[i].DocumentName = (String)dt.Rows[i]["DocumentName"];
                DTO[i].DocumentTitle = (String)dt.Rows[i]["DocumentTitle"];
            }
            return DTO;
        }

        public Employee_Documents[] GetDocuments(int EmployeeID)
        {
            return GetDocuments("EmployeeID = " + EmployeeID);

        }
    }
}
