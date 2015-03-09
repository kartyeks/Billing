using System;
using System.Data;
using IS91.Services.DataBlock;
using System.Collections;
using HRManager.DTO;
using HRManager.Entity.EmployeesInfo;

namespace HRManager.BusinessObjects
{
    public partial class Employee_SalaryBusinessObject
    {
        private Employee_Salary[] GetSalaryDetails(String Filter)
        {
            String Qry = " SELECT * FROM Employee_Salary";

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

            Employee_Salary[] DTO = new Employee_Salary[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Employee_Salary();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].EmployeeID = (int)dt.Rows[i]["EmployeeID"];
                DTO[i].CTC = (Double)dt.Rows[i]["CTC"];
                DTO[i].ESOP = (int)dt.Rows[i]["ESOP"];
                DTO[i].Basic = Convert.ToDouble(dt.Rows[i]["Basic"]);
                DTO[i].IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
                DTO[i].EffectedDate = Convert.ToDateTime(dt.Rows[i]["EffectedDate"]);
            }

            return DTO;
        }

        public Employee_Salary GetSalaryDetails(int EmployeeID)
        {
            Employee_Salary[] DTO = GetSalaryDetails(" EmployeeID = " + EmployeeID+" and Isactive = 1");

            if (DTO.Length == 1)
            {
                return DTO[0];
            }

            return null;
        }
        public void DeactivePreRecords(int employeeId)
        {
            const String qryInv = " Update Employee_Salary set IsActive=0 where EmployeeID={0} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(qryInv, employeeId);
            EE.ExecuteNonQuery(exQry);
        }
        public Employee_Salary GetEmployeeSalaryDetails(int EmployeeID)
        {
            String Query = " SELECT * FROM Employee_Salary WHERE EmployeeID = {0} AND IsActive=1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = String.Format(Query, EmployeeID);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Employee_Salary DTO = new Employee_Salary();

            if (dt.Rows.Count > 0)
            {
                DTO.ID = (int)dt.Rows[0]["ID"];
                DTO.EmployeeID = (int)dt.Rows[0]["EmployeeID"];
                DTO.CTC = (Double)dt.Rows[0]["CTC"];
                DTO.ESOP = (int)dt.Rows[0]["ESOP"];
                DTO.Basic = Convert.ToDouble(dt.Rows[0]["Basic"]);
                //DTO.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                //DTO.EffectedDate = Convert.ToDateTime(dt.Rows[0]["EffectedDate"]);
            }
            return DTO;
        }

    }
}
