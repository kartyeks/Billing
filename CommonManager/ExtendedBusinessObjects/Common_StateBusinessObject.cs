using System;
using System.Data;

using System.Collections;
using IS91.Services.DataBlock;
using CommonManager.DTO;
using CommonManager.DTOEXT;

namespace CommonManager.BusinessObjects
{
    public partial class Common_StateBusinessObject
    {
        /// <summary>
        /// Get Staes by country ID
        /// </summary>
        /// <param name="CountryID">Country ID</param>
        /// <returns>State DTO Objects</returns>
        public Common_State[] GetStates(int CountryID)
        {
            return GetState("CountryID = " + CountryID.ToString());
        }
        public Common_State[] GetStatesDetails(int RegionID)
        {
            return GetState("(RegionID = " + string.Concat(RegionID) + " OR " + string.Concat(RegionID) + "=0)");
        }

        /// <summary>
        /// Get Staes by any filter
        /// </summary>
        /// <param name="Filter">Filter string</param>
        /// <returns>State DTO Objects</returns>      


        public Common_StateEXT[] GetState(String Filter)
        {
            const String Qry = " SELECT DISTINCT"
                                  + " CS.*, Country, ISNULL(RegionName,'')RegionName"
                                  + " FROM Common_State CS"
                                  + " LEFT JOIN"
                                  + " Common_Country CC"
                                  + " ON"
                                  + " CC.ID=CS.CountryID"
                                  + " LEFT JOIN"
                                  + " Master_Region MR"
                                  + " ON"
                                  + " MR.ID=CS.RegionID";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            if (Filter == String.Empty)
            {
                exQry.Query = string.Format(Qry);
            }
            else
            {
                exQry.Query = string.Format(Qry) + " WHERE " + Filter;
            }

            DataTable dt = EE.ExecuteDataTable(exQry);

            Common_StateEXT[] DTO = new Common_StateEXT[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Common_StateEXT();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].StateName = (String)dt.Rows[i]["StateName"];
                DTO[i].CountryID = (int)dt.Rows[i]["CountryID"];
                DTO[i].RegionID = (int)dt.Rows[i]["RegionID"];
                DTO[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                DTO[i].CountryName = (String)dt.Rows[i]["Country"];
                DTO[i].RegionName = (String)dt.Rows[i]["RegionName"];
            }

            return DTO;
        }
        public Common_State[] GetInActiveStates()
        {
            return GetState(" CS.IsActive = 0");
        }

        public Common_State[] GetAllActiveStates()
        {
            return GetState(" CS.IsActive = 1");
        }

        public bool IsStateExists(String StateName, int ID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Common_State WHERE StateName = '{0}' AND ID<>{1})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";
            StateName = StateName.Replace("'", "''");
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, StateName, ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }
        public bool IsStateRegionRefered(int ID)
        {
            const String Qry = " IF EXISTS ( SELECT ID FROM Common_State WHERE RegionID = '{0}') "
                // + " Union (SELECT ID FROM Assign_Emp_Loan WHERE LoanID = '{0}' ) "
                //               + " Union (SELECT ID FROM Loan_Request WHERE LoanID = '{0}' ) )"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }

        public Common_StateComboEXT[] GetEmpInfoCombo(int CountryID)
        {
            const String Qry = " SELECT * "
                                  + " FROM Common_State Where CountryID = {0} OR CountryID=1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, CountryID);
            DataTable dt = EE.ExecuteDataTable(exQry);
            Common_StateComboEXT[] DTO = new Common_StateComboEXT[dt.Rows.Count];
            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Common_StateComboEXT();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].StateName = (String)dt.Rows[i]["StateName"];              
            }
            return DTO;
        }

        public Common_State GetStateID(String StateName)
        {
            const String Qry = " Select * FROM Common_State WHERE StateName = '{0}' And IsActive=1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, StateName);

            DataTable dt = EE.ExecuteDataTable(exQry);
            Common_State Details = new Common_State();
            if (dt.Rows.Count > 0)
            {
                Details.ID = (int)dt.Rows[0]["ID"];
            }

            return Details;
        }
        
    }
}
