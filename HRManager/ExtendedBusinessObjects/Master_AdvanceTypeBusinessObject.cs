using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;
using HRManager.Entity;

namespace HRManager.BusinessObjects
{
    public partial class Master_AdvanceTypeBusinessObject
    {
        public Master_AdvanceType[] GetAllActiveAdvanceType()
        {
            const String Qry = "SELECT * FROM Master_AdvanceType WHERE IsActive=1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);
            Master_AdvanceType[] AdvanceTypeDetails = new Master_AdvanceType[dt.Rows.Count];

            for (int i = 0; i < AdvanceTypeDetails.Length; i++)
            {
                AdvanceTypeDetails[i] = new Master_AdvanceType();
                AdvanceTypeDetails[i].ID = (int)dt.Rows[i]["ID"];                
                AdvanceTypeDetails[i].AdvanceType = (String)dt.Rows[i]["AdvanceType"];                
                AdvanceTypeDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
            }

            return AdvanceTypeDetails;
        }
       


        public Master_AdvanceType GetAdvanceTypeByAdvanceType(String AdvanceType)
        {
            Master_AdvanceType[] MasterAdvanceType = GetMasterAdvanceTypes(" AdvanceType = '" + AdvanceType + "'");

            if (MasterAdvanceType != null && MasterAdvanceType.Length > 0)
            {
                return MasterAdvanceType[0];
            }
            else
            {
                return null;
            }
        }


        public Master_AdvanceType[] GetMasterAdvanceTypes(String Filter)
        {
            const String Qry = " SELECT * FROM Master_AdvanceType";

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

            Master_AdvanceType[] AdvanceTypeDetails = new Master_AdvanceType[dt.Rows.Count];

            for (int i = 0; i < AdvanceTypeDetails.Length; i++)
            {
                AdvanceTypeDetails[i] = new Master_AdvanceType();
               AdvanceTypeDetails[i].ID = (int)dt.Rows[i]["ID"];
               AdvanceTypeDetails[i].AdvanceType = (String)dt.Rows[i]["AdvanceType"];
               AdvanceTypeDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
            }

            return AdvanceTypeDetails;
        }


        public bool IsAdvanceTypeExists(String Loan, int ID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Master_AdvanceType WHERE AdvanceType = '{0}' AND ID<>{1})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, Loan, ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }


        public Master_AdvanceType[] GetAllAdvanceTypes()
        {
            const String Qry = " SELECT * FROM Master_AdvanceType WHERE IsActive=1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_AdvanceType[] AdvanceTypeDetails = new Master_AdvanceType[dt.Rows.Count];

            for (int i = 0; i < AdvanceTypeDetails.Length; i++)
            {
                AdvanceTypeDetails[i] = new Master_AdvanceType();
                AdvanceTypeDetails[i].ID = (int)dt.Rows[i]["ID"];
                AdvanceTypeDetails[i].AdvanceType = (String)dt.Rows[i]["AdvanceType"];                
                AdvanceTypeDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
            }

            return AdvanceTypeDetails;
        }

        public static MasterAdvanceType[] GetAllInActiveAdvanceTypes()
        {
            Master_AdvanceType[] AdvanceTypesDT = new Master_AdvanceTypeBusinessObject().GetAllInActiveAdvanceTypesOrderByAdvanceType();

            MasterAdvanceType[] AdvanceTypes = new MasterAdvanceType[AdvanceTypesDT.Length];

            for (int i = 0; i < AdvanceTypes.Length; i++)
            {
                AdvanceTypes[i] = new MasterAdvanceType(AdvanceTypesDT[i]);
            }

            return AdvanceTypes;
        }


        public Master_AdvanceType[] GetAllInActiveAdvanceTypesOrderByAdvanceType()
        {
            Master_AdvanceType[] AdvanceType = GetAllInActiveAdvanceType();

            if (AdvanceType != null && AdvanceType.Length >= 0)
            {
                return AdvanceType;
            }
            else
            {
                return null;
            }
        }


        public Master_AdvanceType[] GetAllInActiveAdvanceType()
        {
            const String Qry = "SELECT * FROM Master_AdvanceType WHERE IsActive=0";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);



            Master_AdvanceType[] AdvanceTypeDetails = new Master_AdvanceType[dt.Rows.Count];

            for (int i = 0; i < AdvanceTypeDetails.Length; i++)
            {
                AdvanceTypeDetails[i] = new Master_AdvanceType();
                AdvanceTypeDetails[i].ID = (int)dt.Rows[i]["ID"];
                AdvanceTypeDetails[i].AdvanceType = (String)dt.Rows[i]["AdvanceType"];                
                AdvanceTypeDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
            }

            return AdvanceTypeDetails;
        }
        /// <summary>
        /// check PolicyType Existance in the database.
        /// </summary>
        /// <param name="PolicyType">field contains PolicyType name</param>
        /// <param name="ID">field contains PolicyType ID</param>
        /// <returns>True for Exist and false for not exist</returns>
        public bool IsAdvanceTypeRefered(int ID)
        {
            const String Qry = " IF EXISTS (select ID from Salary_Advance where AdvanceID= '{0}')"
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
