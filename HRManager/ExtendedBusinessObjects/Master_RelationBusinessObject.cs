using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;

namespace HRManager.BusinessObjects
{
    public partial class Master_RelationBusinessObject
    {
        /// <summary>
        /// Get Relation By Relation Name
        /// </summary>
        /// <param name="ZoneName">field contaions Relation Name</param>
        /// <returns>data related given Designation Name in case of success otherwise it return null</returns>
        public Master_Relation GetRelationByRelation(String Relation)
        {
            Master_Relation[] Relations = GetRelations(" Relation = '" + Relation + "'");

            if (Relations != null && Relations.Length > 0)
            {
                return Relations[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get Designation By Designation Name
        /// </summary>
        /// <param name="DesignationName">field contaions Designation Name</param>
        /// <returns>data related given Designation Name in case of success otherwise it return null</returns>
        public Master_Relation[] GetAllInActiveRelationOrderByRelation()
        {
            Master_Relation[] Relation = GetAllInActiveRelation();

            if (Relation != null && Relation.Length >= 0)
            {
                return Relation;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Get LocationTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        public Master_Relation[] GetAllInActiveRelation()
        {
            const String Qry = "SELECT * FROM Master_Relation WHERE IsActive=0 ORDER BY RelationName";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_Relation[] RelationDetails = new Master_Relation[dt.Rows.Count];

            for (int i = 0; i < RelationDetails.Length; i++)
            {
                RelationDetails[i] = new Master_Relation();
                RelationDetails[i].ID = (int)dt.Rows[i]["ID"];
                RelationDetails[i].RelationName = (String)dt.Rows[i]["RelationName"];
                RelationDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
            }

            return RelationDetails;
        }

        /// <summary>
        /// Get LocationTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        public Master_Relation[] GetAllActiveRelation()
        {
            const String Qry = "SELECT * FROM Master_Relation WHERE IsActive=1 ORDER BY RelationName";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_Relation[] RelationDetails = new Master_Relation[dt.Rows.Count];

            for (int i = 0; i < RelationDetails.Length; i++)
            {
                RelationDetails[i] = new Master_Relation();
                RelationDetails[i].ID = (int)dt.Rows[i]["ID"];
                RelationDetails[i].RelationName = (String)dt.Rows[i]["RelationName"];
                RelationDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
            }

            return RelationDetails;
        }
        public Master_Relation[] GetAllRelationDetails()
        {
            const String Qry = "SELECT * FROM Master_Relation ORDER BY RelationName";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_Relation[] RelationDetails = new Master_Relation[dt.Rows.Count];

            for (int i = 0; i < RelationDetails.Length; i++)
            {
                RelationDetails[i] = new Master_Relation();
                RelationDetails[i].ID = (int)dt.Rows[i]["ID"];
                RelationDetails[i].RelationName = (String)dt.Rows[i]["RelationName"];
                RelationDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
            }

            return RelationDetails;
        }
        /// <summary>
        /// Get Designations data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_Relation object</returns>
        public Master_Relation[] GetRelations(String Filter)
        {
            const String Qry = " SELECT * FROM Master_Relation WHERE IsActive=1 ORDER BY RelationName";

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

            Master_Relation[] RelationDetails = new Master_Relation[dt.Rows.Count];

            for (int i = 0; i < RelationDetails.Length; i++)
            {
                RelationDetails[i] = new Master_Relation();
                RelationDetails[i].ID = (int)dt.Rows[i]["ID"];
                RelationDetails[i].RelationName = (String)dt.Rows[i]["RelationName"];
                RelationDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
            }

            return RelationDetails;
        }
        /// <summary>
        /// check Relation Existance in the database.
        /// </summary>
        /// <param name="Relation">field contains Relation name</param>
        /// <param name="ID">field contains Relation ID</param>
        /// <returns>True for Exist and false for not exist</returns>
        public bool IsRelationExists(String Relation, int ID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Master_Relation WHERE RelationName = '{0}' AND ID<>{1})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, Relation, ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }

    }
}
