using System;
using System.Data;
using IS91.Services.DataBlock;
using System.Collections;
using HRManager.DTO;
using HRManager.DTOEXT.Inventory;
using IRCA.Communication;

namespace HRManager.BusinessObjects
{
    public partial class Asset_OutgoingDevicesBusinessObject
    {
        public Asset_OutgoingDevicesExt[] GetOutgoingAssets(string Filter)
        {
            String Query = " SELECT AssetName,UniqueNumber, A.*  " +
                           " FROM Asset_OutgoingDevices A " +
                           " INNER JOIN Manage_Assets M ON M.ID=A.AssetID  ";
                          

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            if (Filter == "")
                exQry.Query = Query;
            else
                exQry.Query = string.Format(Query) + " WHERE " + Filter;


            DataTable dt = EE.ExecuteDataTable(exQry);
            Asset_OutgoingDevicesExt[] DTS = new Asset_OutgoingDevicesExt[dt.Rows.Count];

            for (int i = 0; i < DTS.Length; i++)
            {
                DTS[i] = new Asset_OutgoingDevicesExt();
                DTS[i].ID = (int)dt.Rows[i]["ID"];
                DTS[i].AssetID = (int)dt.Rows[i]["AssetID"];
                DTS[i].OutgoingDate = (DateTime)dt.Rows[i]["OutgoingDate"];
                DTS[i].ReturningDate = (DateTime)dt.Rows[i]["ReturningDate"];
                DTS[i].Reason = (String)dt.Rows[i]["Reason"];
                DTS[i].AssetName = (String)dt.Rows[i]["AssetName"];
                DTS[i].AssetNumber = (String)dt.Rows[i]["UniqueNumber"];
                DTS[i].CreatedBy = (int)dt.Rows[i]["CreatedBy"];
                DTS[i].CreatedDate = (DateTime)dt.Rows[i]["CreatedDate"];
                DTS[i].ModifiedBy = (int)dt.Rows[i]["ModifiedBy"];
                DTS[i].ModifiedDate = (DateTime)dt.Rows[i]["ModifiedDate"];
                DTS[i].IsReturned = (bool)dt.Rows[i]["IsReturned"];

            }

            return DTS;
        }

        public Asset_OutgoingDevicesExt GetOutgoingAssetInfo(int ID)
        {
            String Query = " SELECT AssetName,UniqueNumber, A.*  " +
                           " FROM Asset_OutgoingDevices A " +
                           " INNER JOIN Manage_Assets M ON M.ID=A.AssetID  " +
                           " Where A.ID={0}  ";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Query, ID);


            DataTable dt = EE.ExecuteDataTable(exQry);
            Asset_OutgoingDevicesExt DTO = new Asset_OutgoingDevicesExt();
            if (dt.Rows.Count > 0)
            {
                DTO.ID = (int)dt.Rows[0]["ID"];
                DTO.AssetID = (int)dt.Rows[0]["AssetID"];
                DTO.OutgoingDate = (DateTime)dt.Rows[0]["OutgoingDate"];
                DTO.ReturningDate = (DateTime)dt.Rows[0]["ReturningDate"];
                DTO.Reason = (String)dt.Rows[0]["Reason"];
                DTO.AssetName = (String)dt.Rows[0]["AssetName"];
                DTO.AssetNumber = (String)dt.Rows[0]["UniqueNumber"];
                DTO.CreatedBy = (int)dt.Rows[0]["CreatedBy"];
                DTO.CreatedDate = (DateTime)dt.Rows[0]["CreatedDate"];
                DTO.ModifiedBy = (int)dt.Rows[0]["ModifiedBy"];
                DTO.ModifiedDate = (DateTime)dt.Rows[0]["ModifiedDate"];
                DTO.IsReturned = (bool)dt.Rows[0]["IsReturned"];

            }

            return DTO;
        }

        public bool IsAssetOutgoing(int ID, int AssetID)
        {
            const String Qry = " IF EXISTS ( SELECT ID FROM Asset_OutgoingDevices WHERE AssetID = {0} AND IsReturned=0 AND ID<>{1}) "
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, AssetID, ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }
    }
}
