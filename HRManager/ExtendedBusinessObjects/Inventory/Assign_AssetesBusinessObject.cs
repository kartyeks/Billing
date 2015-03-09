using System;
using System.Data;
using IS91.Services.DataBlock;
using System.Collections;
using HRManager.DTO;
using HRManager.DTOEXT.Inventory;
using IRCA.Communication;

namespace HRManager.BusinessObjects
{
    public partial class Assign_AssetesBusinessObject
    {
        public Assign_AssetesExt[] GetAssignAssets(string Filter)
        {
            String Query = " SELECT  ISNULL(E.FirstName + ' ' + E.LastName,'') as EmployeeName,isnull(TeamName,'')TeamName, " +
                           " isnull(E1.FirstName + ' ' + E1.LastName,'') as ManagerName,AssetName,UniqueNumber, A.*  " +
                           " FROM Assign_Assetes A " +
                           " INNER JOIN Manage_Assets M ON M.ID=A.AssetID  " +
                           " LEFT JOIN  Master_Team T ON T.ID=A.TeamID  " +
                           " LEFT JOIN  Master_Employees E1 ON T.ManagerID=E1.ID  " +
                           " LEFT JOIN  Master_Employees E ON E.ID=A.EmployeeID  ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            if (Filter == "")
                exQry.Query = Query;
            else
                exQry.Query = string.Format(Query) + " WHERE " + Filter;


            DataTable dt = EE.ExecuteDataTable(exQry);
            Assign_AssetesExt[] DTO = new Assign_AssetesExt[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Assign_AssetesExt();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].AssetID = (int)dt.Rows[i]["AssetID"];
                DTO[i].AssetName = (String)dt.Rows[i]["AssetName"];
                DTO[i].AssetNumber = (String)dt.Rows[i]["UniqueNumber"];
                DTO[i].TeamID = (int)dt.Rows[i]["TeamID"];
                DTO[i].EmployeeID = (int)dt.Rows[i]["EmployeeID"];
                DTO[i].TeamName = (String)dt.Rows[i]["TeamName"];
                DTO[i].ManagerName = (String)dt.Rows[i]["ManagerName"];
                DTO[i].UserName = (String)dt.Rows[i]["EmployeeName"];
                DTO[i].IssuedDate = (DateTime)dt.Rows[i]["IssuedDate"];
                DTO[i].ReturnedDate = (DateTime)dt.Rows[i]["ReturnedDate"];
                DTO[i].IsTeamAssigned = (bool)dt.Rows[i]["IsTeamAssigned"];
                DTO[i].IsReturned = (bool)dt.Rows[i]["IsReturned"];
                DTO[i].Reason = (String)dt.Rows[i]["Reason"];
                DTO[i].LocationOfAsset = (String)dt.Rows[i]["LocationOfAsset"];
                DTO[i].Comments = (String)dt.Rows[i]["Comments"];
                DTO[i].CreatedBy = (int)dt.Rows[i]["CreatedBy"];
                DTO[i].CreatedDate = (DateTime)dt.Rows[i]["CreatedDate"];
                DTO[i].ModifiedBy = (int)dt.Rows[i]["ModifiedBy"];
                DTO[i].ModifiedDate = (DateTime)dt.Rows[i]["ModifiedDate"];

            }

            return DTO;
        }
        public Assign_AssetesExt GetAssignAssetInfo(int ID)
        {
            String Query = " SELECT ISNULL(E.FirstName + ' ' + E.LastName,'') as EmployeeName,isnull(TeamName,'')TeamName, " +
                           " isnull(E1.FirstName + ' ' + E1.LastName,'') as ManagerName,AssetName,UniqueNumber, A.*  " +
                           " FROM Assign_Assetes A " +
                           " INNER JOIN Manage_Assets M ON M.ID=A.AssetID  " +
                           " LEFT JOIN  Master_Team T ON T.ID=A.TeamID  " +
                           " LEFT JOIN  Master_Employees E1 ON T.ManagerID=E1.ID  " +
                           " LEFT JOIN  Master_Employees E ON E.ID=A.EmployeeID Where A.ID={0}  ";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Query, ID);


            DataTable dt = EE.ExecuteDataTable(exQry);
            Assign_AssetesExt DTO = new Assign_AssetesExt();
            if (dt.Rows.Count > 0)
            {
                DTO.ID = (int)dt.Rows[0]["ID"];
                DTO.AssetID = (int)dt.Rows[0]["AssetID"];
                DTO.AssetName = (String)dt.Rows[0]["AssetName"];
                DTO.AssetNumber = (String)dt.Rows[0]["UniqueNumber"];
                DTO.TeamID = (int)dt.Rows[0]["TeamID"];
                DTO.EmployeeID = (int)dt.Rows[0]["EmployeeID"];
                DTO.TeamName = (String)dt.Rows[0]["TeamName"];
                DTO.ManagerName = (String)dt.Rows[0]["ManagerName"];
                DTO.UserName = (String)dt.Rows[0]["EmployeeName"];
                DTO.IssuedDate = (DateTime)dt.Rows[0]["IssuedDate"];
                DTO.ReturnedDate = (DateTime)dt.Rows[0]["ReturnedDate"];
                DTO.IsTeamAssigned = (bool)dt.Rows[0]["IsTeamAssigned"];
                DTO.IsReturned = (bool)dt.Rows[0]["IsReturned"];
                DTO.Reason = (String)dt.Rows[0]["Reason"];
                DTO.LocationOfAsset = (String)dt.Rows[0]["LocationOfAsset"];
                DTO.Comments = (String)dt.Rows[0]["Comments"];
                DTO.CreatedBy = (int)dt.Rows[0]["CreatedBy"];
                DTO.CreatedDate = (DateTime)dt.Rows[0]["CreatedDate"];
                DTO.ModifiedBy = (int)dt.Rows[0]["ModifiedBy"];
                DTO.ModifiedDate = (DateTime)dt.Rows[0]["ModifiedDate"];

            }

            return DTO;
        }
        public bool IsAssetAssigned(int ID,int AssetID)
        {
            const String Qry = " IF EXISTS ( SELECT ID FROM Assign_Assetes WHERE AssetID = {0} AND IsReturned=0 AND ID<>{1}) "
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, AssetID,ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }

        public ComboBoxValues[] GetAssetCombo()
        {
            String Query = "SELECT ID,UniqueNumber,AssetName FROM Manage_Assets Where IsActive = 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = Query;

            DataTable dt = EE.ExecuteDataTable(exQry);
            ComboBoxValues[] DTO = new ComboBoxValues[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new ComboBoxValues();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].Value = (String)dt.Rows[i]["AssetName"] + "(" + (String)dt.Rows[i]["UniqueNumber"] + ")";
            }
            return DTO;
        }
    }
}
