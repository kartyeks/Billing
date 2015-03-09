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
    public partial class Master_MaritalStatusBusinessObject
    {
        public Master_Marital_Status[] GetMaritialStatusMaster(string Filter)
        {
            String Query = "SELECT * FROM Master_MaritalStatus";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            if (Filter == "")
                exQry.Query = Query;
            else
                exQry.Query = string.Format(Query) + " WHERE " + Filter;


            DataTable dt = EE.ExecuteDataTable(exQry);
            Master_Marital_Status[] DTO = new Master_Marital_Status[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Master_Marital_Status();
                DTO[i].ID = (int)dt.Rows[i]["ID"];

                DTO[i].MaritalStatus = (String)dt.Rows[i]["MaritalStatus"];
                DTO[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                DTO[i].CreatedBy = (int)dt.Rows[i]["CreatedBy"];
                DTO[i].CreatedDate = (DateTime)dt.Rows[i]["CreatedDate"];
                DTO[i].ModifiedBy = (int)dt.Rows[i]["ModifiedBy"];
                DTO[i].ModifiedDate = (DateTime)dt.Rows[i]["ModifiedDate"];

            }

            return DTO;
        }
        public bool IsMaritialStatusExists(String MaritalStatus, int ID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Master_MaritalStatus WHERE MaritalStatus = '{0}' AND ID<>{1})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";
            MaritalStatus = MaritalStatus.Replace("'", "''");
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, MaritalStatus, ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }
        public bool IMaritalstatusReferedinEmployee(int ID)
        {
            const String Qry = " IF EXISTS ( SELECT ID FROM Master_Employees WHERE MaritalStatusID = '{0}') "
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
