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
using IRCA.Communication;

namespace HRManager.BusinessObjects
{
    public partial class Master_ManufacturerBusinessObject
    {
        public Master_Manufacturer[] GetManufacturerMaster(string Filter)
        {
            String Query = "SELECT * FROM Master_Manufacturer";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            if (Filter == "")
                exQry.Query = Query;
            else
                exQry.Query = string.Format(Query) + " WHERE " + Filter;


            DataTable dt = EE.ExecuteDataTable(exQry);
            Master_Manufacturer[] DTO = new Master_Manufacturer[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Master_Manufacturer();
                DTO[i].ID = (int)dt.Rows[i]["ID"];

                DTO[i].ManufacturerName = (String)dt.Rows[i]["ManufacturerName"];
                DTO[i].Description = (String)dt.Rows[i]["Description"];
                DTO[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                DTO[i].CreatedBy = (int)dt.Rows[i]["CreatedBy"];
                DTO[i].CreatedDate = (DateTime)dt.Rows[i]["CreatedDate"];
                DTO[i].ModifiedBy = (int)dt.Rows[i]["ModifiedBy"];
                DTO[i].ModifiedDate = (DateTime)dt.Rows[i]["ModifiedDate"];

            }

            return DTO;
        }

        public bool IsManufacturerExists(String ManufacturerName, int ID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Master_Manufacturer WHERE ManufacturerName = '{0}' AND ID<>{1})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";
            ManufacturerName = ManufacturerName.Replace("'", "''");
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, ManufacturerName, ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }

        public ComboBoxValues[] GetManufactureCombo()
        {
            String Query = "SELECT ID,ManufacturerName FROM Master_Manufacturer Where IsActive = 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = Query;

            DataTable dt = EE.ExecuteDataTable(exQry);
            ComboBoxValues[] DTO = new ComboBoxValues[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new ComboBoxValues();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].Value = (String)dt.Rows[i]["ManufacturerName"];
            }
            return DTO;
        }
        public bool ImanufacturerRefered(int ID)
        {
            const String Qry = " IF EXISTS ( SELECT ID FROM Manage_Assets WHERE ManufacturerID = '{0}' ) "
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
