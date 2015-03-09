using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;
using IS91.Services.DataBlock;
using System.Data;
using IRCA.Communication;
using HRManager.DTOEXT;

namespace HRManager.BusinessObjects
{
    public partial class Master_TeamBusinessObject
    {

        public Master_TeamEXT[] GetTeamMaster()
        {
            const String Qry = "   SELECT  DISTINCT	"
                                  + "   MT.* "
                                  + "  ,ISNULL((FirstName+' ' +MiddleName +' ' +LastName),'')ManagerName   "
                                  + "   FROM  	"
                                  + "   Master_Team MT "
                                  + "   LEFT JOIN   	"
                                  + "   Master_Employees ME  "
                                  + "   ON  	"
                                  + "   ME.ID=MT.ManagerID "
                                  + "   WHERE MT.IsActive=0";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_TeamEXT[] TeamDet = new Master_TeamEXT[dt.Rows.Count];

            for (int i = 0; i < TeamDet.Length; i++)
            {
                TeamDet[i] = new Master_TeamEXT();
                TeamDet[i].ID = (int)dt.Rows[i]["ID"];
                TeamDet[i].TeamName = (String)dt.Rows[i]["TeamName"];
                TeamDet[i].ManagerID = (int)dt.Rows[i]["ManagerID"];
                TeamDet[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                TeamDet[i].ManagerName = (String)dt.Rows[i]["ManagerName"];
            }

            return TeamDet;
        } 

        public ComboBoxValues[] GetTeamCombo()
        {
            String Query = "SELECT ID,TeamName FROM Master_Team Where IsActive = 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            
            exQry.Query = Query;

            DataTable dt = EE.ExecuteDataTable(exQry);
            ComboBoxValues[] DTO = new ComboBoxValues[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new ComboBoxValues();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].Value = (String)dt.Rows[i]["TeamName"];
            }
            return DTO;
        }
        public Master_TeamEXT[] GetAllTeamDetails()
        {
            const String Qry = "     select MT.*,isnull(ME.ID,0) MManagerID, "
             + " ISNULL((FirstName+' ' +MiddleName +' ' +LastName),'') ManagerName from Master_Team MT "
             + "  left Join Employee_OccupationDetails  EOD ON MT.ManagerID=EOD.EmployeeID "
             + "           And TypeOfExitID =0 and EOD.IsActive=1 "
             + " left Join Master_Employees ME On ME.ID = EOD.EmployeeID " ;


            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_TeamEXT[] TeamDet = new Master_TeamEXT[dt.Rows.Count];

            for (int i = 0; i < TeamDet.Length; i++)
            {
                TeamDet[i] = new Master_TeamEXT();
                TeamDet[i].ID = (int)dt.Rows[i]["ID"];
                TeamDet[i].TeamName = (String)dt.Rows[i]["TeamName"];
                TeamDet[i].ManagerID = (int)dt.Rows[i]["MManagerID"];
                TeamDet[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                TeamDet[i].ManagerName = (String)dt.Rows[i]["ManagerName"];
            }

            return TeamDet;
        } 

        public Master_TeamEXT[] GetAllTeams()
        {
            const String Qry = "     select MT.*,isnull(ME.ID,0) MManagerID, "
 + " ISNULL((FirstName+' ' +MiddleName +' ' +LastName),'') ManagerName from Master_Team MT "
 + "  left Join Employee_OccupationDetails  EOD ON MT.ManagerID=EOD.EmployeeID "
 + "           And TypeOfExitID =0 and EOD.IsActive=1 "
 + " left Join Master_Employees ME On ME.ID = EOD.EmployeeID "
 + "   WHERE MT.IsActive=1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_TeamEXT[] TeamDet = new Master_TeamEXT[dt.Rows.Count];

            for (int i = 0; i < TeamDet.Length; i++)
            {
                TeamDet[i] = new Master_TeamEXT();
                TeamDet[i].ID = (int)dt.Rows[i]["ID"];
                TeamDet[i].TeamName = (String)dt.Rows[i]["TeamName"];
                TeamDet[i].ManagerID = (int)dt.Rows[i]["MManagerID"];
                TeamDet[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                TeamDet[i].ManagerName = (String)dt.Rows[i]["ManagerName"];
            }

            return TeamDet;
        }  

        public Master_TeamEXT[] GetAllTeamMaster(string Filter)
        {
            String Query = "SELECT  MT.*, "
                         + " isnull(MEE.FirstName,'') FirstName, "
                         + " isnull(MEE.MiddleName,'') MiddleName, "
                         + " isnull(MEE.LastName,'') LastName "
                         + " FROM Master_Team MT "
                         + " left JOIN "
                         + " (Select ME.* from Master_Employees ME "
                         + " inner Join Employee_OccupationDetails EO On EO.EmployeeID = ME.ID  "
                         + " and EO.TypeOfExitID =0 AND EO.IsActive = 1 "
                         + " ) MEE ON MEE.ID = MT.ManagerID ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            if (Filter == "")
                exQry.Query = Query;
            else
                exQry.Query = string.Format(Query) + " WHERE " + Filter;


            DataTable dt = EE.ExecuteDataTable(exQry);
            Master_TeamEXT[] DTO = new Master_TeamEXT[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Master_TeamEXT();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].TeamName = (String)dt.Rows[i]["TeamName"];
                DTO[i].ManagerID = (int)dt.Rows[i]["ManagerID"];
                DTO[i].ManagerName = (String)dt.Rows[i]["FirstName"] + " " + (String)dt.Rows[i]["MiddleName"] + " " + (String)dt.Rows[i]["LastName"];
                DTO[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                DTO[i].CreatedBy = (int)dt.Rows[i]["CreatedBy"];
                DTO[i].CreatedDate = (DateTime)dt.Rows[i]["CreatedDate"];
                DTO[i].ModifiedBy = (int)dt.Rows[i]["ModifiedBy"];
                DTO[i].ModifiedDate = (DateTime)dt.Rows[i]["ModifiedDate"];
            }
            return DTO;
        }

        public bool IsTeamExists(String TeamName, int ID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Master_Team WHERE TeamName = '{0}' AND ID<>{1})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, TeamName, ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }

        public bool IsTeamRefered(int ID)
        {
            const String Qry = " IF EXISTS ( SELECT ID FROM Employee_OccupationDetails WHERE TeamID = '{0}' ) "
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
