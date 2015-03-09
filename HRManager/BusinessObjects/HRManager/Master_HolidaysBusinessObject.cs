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
    public partial class Master_HolidaysBusinessObject
    {
        public Master_Holidays[] GetHolidayMaster(string Filter)
        {
            String Query = "SELECT * FROM Master_Holidays";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            if (Filter == "")
                exQry.Query = Query;
            else
                exQry.Query = string.Format(Query) + " WHERE " + Filter;


            DataTable dt = EE.ExecuteDataTable(exQry);
            Master_Holidays[] DTO = new Master_Holidays[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Master_Holidays();
                DTO[i].ID = (int)dt.Rows[i]["ID"];

                DTO[i].LocationID = (int)dt.Rows[i]["LocationID"];
                DTO[i].HolidayName = (String)dt.Rows[i]["HolidayName"];
                DTO[i].HolidayDate = (DateTime)dt.Rows[i]["HolidayDate"];
                DTO[i].Description = (String)dt.Rows[i]["Description"];
                DTO[i].Status = (String)dt.Rows[i]["Status"];
                DTO[i].RequestingTo = (int)dt.Rows[i]["RequestingTo"];
                DTO[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                DTO[i].CreatedBy = (int)dt.Rows[i]["CreatedBy"];
                DTO[i].CreatedDate = (DateTime)dt.Rows[i]["CreatedDate"];
                DTO[i].ModifiedBy = (int)dt.Rows[i]["ModifiedBy"];
                DTO[i].ModifiedDate = (DateTime)dt.Rows[i]["ModifiedDate"];

            }

            return DTO;
        }
    }
}
