using System;
using System.Data;
using IS91.Services.DataBlock;
using System.Collections;
using HRManager.DTO;
using HRManager.DTOEXT.Inventory;

namespace HRManager.BusinessObjects
{
    public partial class Manage_AssetsBusinessObject
    {
        //public Manage_AssetsExt[] GetManageAssets(int ID)
        //{
        //    String Query = "Select AssetCategory,AssetSubCategory,ManufacturerName,M.*  " +
        //                   " FROM dbo.Manage_Assets M " +
        //                   " INNER JOIN dbo.Master_AssetCategory A ON A.ID=AssetCategoryID " +
        //                   " INNER JOIN dbo.Master_AssetSubCategory SU ON SU.ID=M.AssetSubCategoryID " +
        //                   " INNER JOIN dbo.Master_Manufacturer MF ON MF.ID=M.ManufacturerID " +
        //                   " WHERE M.ID={0} AND M.IsActive=1 ";

        //    ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
        //    ExecutionQuery exQry = new ExecutionQuery();
        // exQry.Query = string.Format(Query,ID);


        //    DataTable dt = EE.ExecuteDataTable(exQry);
        //    Manage_AssetsExt[] DTO = new Manage_AssetsExt[dt.Rows.Count];

        //    for (int i = 0; i < DTO.Length; i++)
        //    {
        //        DTO[i] = new Manage_AssetsExt();
        //        DTO[i].ID = (int)dt.Rows[i]["ID"];
        //        DTO[i].ID = (int)dt.Rows[i]["ID"];
        //        DTO[i].UniqueNumber = (String)dt.Rows[i]["UniqueNumber"];
        //        DTO[i].AssetName = (String)dt.Rows[i]["AssetName"];
        //        DTO[i].AssetCategoryID = (int)dt.Rows[i]["AssetCategoryID"];
        //        DTO[i].AssetSubCategoryID = (int)dt.Rows[i]["AssetSubCategoryID"];
        //        DTO[i].ManufacturerID = (int)dt.Rows[i]["ManufacturerID"];
        //        DTO[i].AssetCost = (String)dt.Rows[i]["AssetCost"];
        //        DTO[i].VendorDetails = (String)dt.Rows[i]["VendorDetails"];
        //        DTO[i].ManufacturerDate = (DateTime)dt.Rows[i]["ManufacturerDate"];
        //        DTO[i].WarrantyDate = (DateTime)dt.Rows[i]["WarrantyDate"];
        //        DTO[i].IsActive = (bool)dt.Rows[i]["IsActive"];
        //        DTO[i].CreatedBy = (int)dt.Rows[i]["CreatedBy"];
        //        DTO[i].CreatedDate = (DateTime)dt.Rows[i]["CreatedDate"];
        //        DTO[i].ModifiedBy = (int)dt.Rows[i]["ModifiedBy"];
        //        DTO[i].ModifiedDate = (DateTime)dt.Rows[i]["ModifiedDate"];
        //        DTO[i].AssetCategName = (String)dt.Rows[i]["AssetCategory"];
        //        DTO[i].AssetSubCateg = (String)dt.Rows[i]["AssetSubCategory"];
        //        DTO[i].ManufacturerName = (String)dt.Rows[i]["ManufacturerName"];
        //    }

        //    return DTO;
        //}
        public Manage_AssetsExt[] GetAssetMaster(string Filter)
        {
           // String Query = "SELECT * FROM Manage_Assets";
            String Query = "Select AssetCategory,AssetSubCategory,ManufacturerName,M.*  " +
                         " FROM dbo.Manage_Assets M " +
                         " INNER JOIN dbo.Master_AssetCategory A ON A.ID=AssetCategoryID " +
                         " INNER JOIN dbo.Master_AssetSubCategory SU ON SU.ID=M.AssetSubCategoryID " +
                         " INNER JOIN dbo.Master_Manufacturer MF ON MF.ID=M.ManufacturerID ";
                        

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            if (Filter == "")
                exQry.Query = Query;
            else
                exQry.Query = string.Format(Query) + " WHERE " + Filter;


            DataTable dt = EE.ExecuteDataTable(exQry);
            Manage_AssetsExt[] DTO = new Manage_AssetsExt[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Manage_AssetsExt();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].UniqueNumber = (String)dt.Rows[i]["UniqueNumber"];
                DTO[i].AssetName = (String)dt.Rows[i]["AssetName"];
                DTO[i].AssetCategoryID = (int)dt.Rows[i]["AssetCategoryID"];
                DTO[i].AssetSubCategoryID = (int)dt.Rows[i]["AssetSubCategoryID"];
                DTO[i].ManufacturerID = (int)dt.Rows[i]["ManufacturerID"];
                DTO[i].AssetCost = (String)dt.Rows[i]["AssetCost"];
                DTO[i].VendorDetails = (String)dt.Rows[i]["VendorDetails"];
                DTO[i].ManufacturerDate = (DateTime)dt.Rows[i]["ManufacturerDate"];
                DTO[i].WarrantyDate = (DateTime)dt.Rows[i]["WarrantyDate"];
                DTO[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                DTO[i].CreatedBy = (int)dt.Rows[i]["CreatedBy"];
                DTO[i].CreatedDate = (DateTime)dt.Rows[i]["CreatedDate"];
                DTO[i].ModifiedBy = (int)dt.Rows[i]["ModifiedBy"];
                DTO[i].ModifiedDate = (DateTime)dt.Rows[i]["ModifiedDate"];
                DTO[i].AssetCategName = (String)dt.Rows[i]["AssetCategory"];
                DTO[i].AssetSubCateg = (String)dt.Rows[i]["AssetSubCategory"];
                DTO[i].ManufacturerName = (String)dt.Rows[i]["ManufacturerName"];

            }

            return DTO;
        }
        public bool IsAssetNameExists(String AssetName, int ID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Manage_Assets WHERE AssetName = '{0}' AND IsActive=1 AND ID<>{1})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";
            AssetName = AssetName.Replace("'", "''");
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, AssetName, ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }
        public bool IsAssetRefered(int ID)
        {
            const String Qry = " IF EXISTS ( SELECT ID FROM Assign_Assetes WHERE AssetID = {0}) "
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }
        public Manage_AssetsExt GetManageAssetInfo(int ID)
        {
           // String Query = "SELECT * FROM Manage_Assets Where ID={0}";
            String Query = "Select AssetCategory,AssetSubCategory,ManufacturerName,M.*  " +
                          " FROM dbo.Manage_Assets M " +
                          " INNER JOIN dbo.Master_AssetCategory A ON A.ID=AssetCategoryID " +
                          " INNER JOIN dbo.Master_AssetSubCategory SU ON SU.ID=M.AssetSubCategoryID " +
                          " INNER JOIN dbo.Master_Manufacturer MF ON MF.ID=M.ManufacturerID " +
                          " WHERE M.ID={0} AND M.IsActive=1 ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Query,ID);

         
            DataTable dt = EE.ExecuteDataTable(exQry);
            Manage_AssetsExt DTO = new Manage_AssetsExt();
            if (dt.Rows.Count > 0)
            {
                DTO.ID = (int)dt.Rows[0]["ID"];
                DTO.UniqueNumber = (String)dt.Rows[0]["UniqueNumber"];
                DTO.AssetName = (String)dt.Rows[0]["AssetName"];
                DTO.AssetCategoryID = (int)dt.Rows[0]["AssetCategoryID"];
                DTO.AssetSubCategoryID = (int)dt.Rows[0]["AssetSubCategoryID"];
                DTO.ManufacturerID = (int)dt.Rows[0]["ManufacturerID"];
                DTO.AssetCost = (String)dt.Rows[0]["AssetCost"];
                DTO.VendorDetails = (String)dt.Rows[0]["VendorDetails"];
                DTO.ManufacturerDate = (DateTime)dt.Rows[0]["ManufacturerDate"];
                DTO.WarrantyDate = (DateTime)dt.Rows[0]["WarrantyDate"];
                DTO.IsActive = (bool)dt.Rows[0]["IsActive"];
                DTO.CreatedBy = (int)dt.Rows[0]["CreatedBy"];
                DTO.CreatedDate = (DateTime)dt.Rows[0]["CreatedDate"];
                DTO.ModifiedBy = (int)dt.Rows[0]["ModifiedBy"];
                DTO.ModifiedDate = (DateTime)dt.Rows[0]["ModifiedDate"];
                DTO.AssetCategName = (String)dt.Rows[0]["AssetCategory"];
                DTO.AssetSubCateg = (String)dt.Rows[0]["AssetSubCategory"];
                DTO.ManufacturerName = (String)dt.Rows[0]["ManufacturerName"];

            }

            return DTO;
        }

        public string GetNextAssetUniquember(string prefx)
        {
            const string qry = "SELECT UniqueNumber from Manage_Assets " +
                               "Where ID =(Select Max(ID) From Manage_Assets WHERE UniqueNumber like '{0}%')";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(qry, prefx);
            string nxtno = string.Concat(EE.ExecuteScalar(exQry), string.Empty);
            if (nxtno != string.Empty)
            {
               // string[] strNo = nxtno.Split('-');
                //nxtno = nxtno.Replace(prefx, "");
                //string nxtno1 = strNo[0].Replace(prefx, "");
                string nxtno1 = nxtno.Substring(4);
                Int32 intNxtNo = 0;
                Int32.TryParse(nxtno1, out intNxtNo);
                nxtno1 = (intNxtNo + 1).ToString();
                string retValue = nxtno1;
                for (int i = 0; i < 4 - nxtno1.Length; i++)
                {
                    retValue = retValue.Insert(0, "0");
                }
                return retValue;
            }
            return "0001";
        }
    }
}
