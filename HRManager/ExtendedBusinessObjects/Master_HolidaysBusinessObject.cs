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
using HRManager.DTOEXT;

namespace HRManager.BusinessObjects
{
    public partial class Master_HolidaysBusinessObject
    {
        public Master_Holidays[] GetHolidayMaster(string Filter)
        {
            String Query = "SELECT "
                          + "(CONVERT(VARCHAR(25),HolidayDate,103)+',  ' +DATENAME(DW, HolidayDate))HolidayDateName"  
                          + " ,* "  
                          + " FROM Master_Holidays";

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
                DTO[i].HolidayDate = (DateTime)dt.Rows[i]["HolidayDateName"];
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
        public bool IsHolidayNameExists(String HolidayName, int CountryID, int ID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Master_Holidays WHERE HolidayName = '{0}' AND LocationID = {2}  AND ID <> {1})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";
            HolidayName = HolidayName.Replace("'", "''");
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, HolidayName, ID.ToString(), CountryID);
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }

        public Master_Holidays[] GetAllActiveLeave()
        {
            const String Qry = "SELECT "
                              + "(CONVERT(VARCHAR(25),HolidayDate,103)+',  ' +DATENAME(DW, HolidayDate))HolidayDateName"  
                              + " ,* "  
                              + " FROM Master_Holidays WHERE IsActive=1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);
            Master_Holidays[] LeaveDetails = new Master_Holidays[dt.Rows.Count];

            for (int i = 0; i < LeaveDetails.Length; i++)
            {
                LeaveDetails[i] = new Master_Holidays();
                LeaveDetails[i].ID = (int)dt.Rows[i]["ID"];
                LeaveDetails[i].HolidayDate = (DateTime)dt.Rows[i]["HolidayDate"];
            }

            return LeaveDetails;
        }

        public Master_HolidayEXT[] GetAllHolidayMaster()
        {
            String Query = "SELECT "
                          + "(CONVERT(VARCHAR(25),HolidayDate,103)+',  ' +DATENAME(DW, HolidayDate))HolidayDateName"
                          + " ,* "
                          + " FROM Master_Holidays";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Query);
            DataTable dt = EE.ExecuteDataTable(exQry);
            Master_HolidayEXT[] DTO = new Master_HolidayEXT[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Master_HolidayEXT();
                DTO[i].ID = (int)dt.Rows[i]["ID"];

                DTO[i].LocationID = (int)dt.Rows[i]["LocationID"];
                DTO[i].HolidayName = (String)dt.Rows[i]["HolidayName"];
                DTO[i].HolidayDateName = (string)dt.Rows[i]["HolidayDateName"];
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
