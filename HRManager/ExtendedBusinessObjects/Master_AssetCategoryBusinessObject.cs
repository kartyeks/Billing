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
    public partial class Master_AssetCategoryBusinessObject
    {
        public Master_AssetCategory[] GetAssetCategoriesMaster(string Filter)
        {
            String Query = "SELECT * FROM Master_AssetCategory";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            if (Filter == "")
                exQry.Query = Query;
            else
                exQry.Query = string.Format(Query) + " WHERE " + Filter;


            DataTable dt = EE.ExecuteDataTable(exQry);
            Master_AssetCategory[] DTO = new Master_AssetCategory[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Master_AssetCategory();
                DTO[i].ID = (int)dt.Rows[i]["ID"];

                DTO[i].AssetCategory = (String)dt.Rows[i]["AssetCategory"];
                DTO[i].Description = (String)dt.Rows[i]["Description"];
                DTO[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                DTO[i].CreatedBy = (int)dt.Rows[i]["CreatedBy"];
                DTO[i].CreatedDate = (DateTime)dt.Rows[i]["CreatedDate"];
                DTO[i].ModifiedBy = (int)dt.Rows[i]["ModifiedBy"];
                DTO[i].ModifiedDate = (DateTime)dt.Rows[i]["ModifiedDate"];

            }

            return DTO;
        }
        public bool IsAssetCategoryExists(String AssetCategory, int ID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Master_AssetCategory WHERE AssetCategory = '{0}' AND ID<>{1})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";
            AssetCategory = AssetCategory.Replace("'", "''");
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, AssetCategory, ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }
        public ComboBoxValues[] GetAssetCategoryCombo()
        {
            String Query = "SELECT ID,AssetCategory FROM Master_AssetCategory Where IsActive = 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = Query;

            DataTable dt = EE.ExecuteDataTable(exQry);
            ComboBoxValues[] DTO = new ComboBoxValues[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new ComboBoxValues();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].Value = (String)dt.Rows[i]["AssetCategory"];
            }
            return DTO;
        }
        public bool IAssetRefered(int ID)
        {
            const String Qry = " IF EXISTS ( SELECT ID FROM Manage_Assets WHERE AssetCategoryID = '{0}' ) "
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
