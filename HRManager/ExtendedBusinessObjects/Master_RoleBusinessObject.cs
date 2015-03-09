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
    public partial class Master_RoleBusinessObject
    {
        public String GetMenuString(string rolename)
        {
            const String Qry = "SELECT Menu FROM Master_Role WHERE Role='{0}'";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, rolename);
            return string.Concat(EE.ExecuteScalar(exQry));
        }
        public void AddPermissions(int RoleID, ArrayList arrPermitResult, Session ss)
        {

            try
            {
                ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
                ExecutionQuery exQry = new ExecutionQuery();

                exQry.Query = "DELETE FROM Permissions WHERE RoleID ='" + RoleID + "'";
                EE.ExecuteNonQuery(exQry, ss);
                if (arrPermitResult != null)
                {
                    PermissionsBusinessObject objPermBO = new PermissionsBusinessObject(ss);
                    foreach (Permissions objPermit in arrPermitResult)
                    {
                        objPermBO.Create(objPermit);

                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

        }

        public DataTable GetApplicableMenueItems(int RoleID)
        {
            const String Qry = "Select F.Modulename, F.Title from functions F " +
                               " Inner join Permissions P On P.FunctionID=F.ID " +
                               " Where Roleid={0} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, RoleID.ToString());
            return EE.ExecuteDataTable(exQry);
        }
        public Object[] GetMasterDetails(String Filter)
        {
            const String Qry = " SELECT * FROM Master_Role";

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

            Master_Role[] RoleDetails = new Master_Role[dt.Rows.Count];

            for (int i = 0; i < RoleDetails.Length; i++)
            {
                RoleDetails[i] = new Master_Role();
                RoleDetails[i].ID = (int)dt.Rows[i]["ID"];
                RoleDetails[i].Role = (String)dt.Rows[i]["Role"];
                RoleDetails[i].Description = (String)dt.Rows[i]["Description"];
                RoleDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];               
            }

            return RoleDetails;
        }
        public Object[] GetActiveMasters()
        {
            return GetMasterDetails(" IsActive = 1");
        }


        public bool IsRoleReferenced(int ID)
        {
            //const String Qry = " IF EXISTS (SELECT * FROM ( "
            //                    + " SELECT RoleID FROM Hr_Designation "
            //                    //+ " UNION "
            //                    //+ " SELECT RoleID FROM Assign_EmpRole_DashboardReports "
            //                    //+ "  ) M WHERE RoleID ={0})"
            //                    //+ " SELECT 0"
            //                    + " ELSE"
            //                    + " SELECT 1";
            const String Qry = " IF EXISTS "
                                  + " ("
                                  + " 	SELECT * FROM "
                                  + " 	( "
                                  + " 	 SELECT RoleID FROM Hr_Designation "
                                  + " 	) M WHERE RoleID ={0}"
                                  + " )"
                                  + " SELECT 0"
                                  + " ELSE"
                                  + " SELECT 1"; 
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";

        }
        public bool IsRoleExists(String Role, int ID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Master_Role WHERE Role = '{0}' AND ID<>{1})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, Role,ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }

        public Object[] GetInActiveMasters()
        {
            return GetMasterDetails(" IsActive = 0");
        }

        public EmpRoleDashboardReports[] GetRoleWiseDashboardReports(int RoleID)
        {
            const String Qry = "Select * From Assign_EmpRole_DashboardReports Where RoleID={0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, RoleID.ToString());

            DataTable dt = EE.ExecuteDataTable(exQry);

            EmpRoleDashboardReports[] ReportInfo = new EmpRoleDashboardReports[dt.Rows.Count];
            for (int i = 0; i < ReportInfo.Length; i++)
            {
                ReportInfo[i] = new EmpRoleDashboardReports();
                if (dt.Rows[i]["ID"].ToString() != string.Empty)
                    ReportInfo[i].ID = (int)dt.Rows[i]["ID"];
                if (dt.Rows[i]["RoleID"].ToString() != string.Empty)
                    ReportInfo[i].RoleID = (int)dt.Rows[i]["RoleID"];
                if (dt.Rows[i]["ReportID"].ToString() != string.Empty)
                    ReportInfo[i].ReportID = (int)dt.Rows[i]["ReportID"];

            }
            return ReportInfo;
        }

        public Permission[] GetAllPermissions(int RoleID)
        {
            const String Qry = " Select ID FunctID,ModuleName,'' Apply,'' Approvals,'' ViewMode,Category,Title From Functions " +
                           " Where id not in(select functionid from Permissions where RoleID={0}) and ModuleName<>'li_LogOut' " +
                           " Union " +
                           " Select distinct F.ID FunctID,ModuleName,P.Apply,P.Approvals,P.ViewMode,Category,Title from Permissions P " +
                           " Right outer Join Functions F ON F.ID=P.FunctionID where RoleID={0} and ModuleName<>'li_LogOut'  ";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, RoleID);

            DataTable dt = EE.ExecuteDataTable(exQry);

            Permission[] PermissionDetails = new Permission[dt.Rows.Count];

            for (int i = 0; i < PermissionDetails.Length; i++)
            {
                PermissionDetails[i] = new Permission();
                PermissionDetails[i].FunctionID = (int)dt.Rows[i]["FunctID"];
                PermissionDetails[i].FunctionName = (String)dt.Rows[i]["ModuleName"];
                PermissionDetails[i].Category = (String)dt.Rows[i]["Category"];
                PermissionDetails[i].Title = (String)dt.Rows[i]["Title"];
                if (dt.Rows[i]["Apply"].ToString() != string.Empty)
                    PermissionDetails[i].Apply = (bool)dt.Rows[i]["Apply"];
                if (dt.Rows[i]["Approvals"].ToString() != string.Empty)
                    PermissionDetails[i].Approvals = (bool)dt.Rows[i]["Approvals"];
                if (dt.Rows[i]["ViewMode"].ToString() != string.Empty)
                    PermissionDetails[i].ViewMode = (bool)dt.Rows[i]["ViewMode"];
            }

            return PermissionDetails;
        }

        //public Permission[] GetAllPermissions(int RoleID)
        //{
        //    const String Qry = " Select ID FunctID,ModuleName,'' Apply,'' Approvals,'' ViewMode,Category,Title From Functions " +
        //                   " Where id not in(select functionid from Permissions where RoleID={0}) and ModuleName<>'li_LogOut' " +
        //                   " Union " +
        //                   " Select distinct F.ID FunctID,ModuleName,P.Apply,P.Approvals,P.ViewMode,Category,Title from Permissions P " +
        //                   " Right outer Join Functions F ON F.ID=P.FunctionID where RoleID={0} and ModuleName<>'li_LogOut'  ";
        //    ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
        //    ExecutionQuery exQry = new ExecutionQuery();
        //    exQry.Query = string.Format(Qry, RoleID);

        //    DataTable dt = EE.ExecuteDataTable(exQry);

        //    Permission[] PermissionDetails = new Permission[dt.Rows.Count];

        //    for (int i = 0; i < PermissionDetails.Length; i++)
        //    {
        //        PermissionDetails[i] = new Permission();
        //        PermissionDetails[i].FunctionID = (int)dt.Rows[i]["FunctID"];
        //        PermissionDetails[i].FunctionName = (String)dt.Rows[i]["ModuleName"];
        //        PermissionDetails[i].Category = (String)dt.Rows[i]["Category"];
        //        PermissionDetails[i].Title = (String)dt.Rows[i]["Title"];
        //        if (dt.Rows[i]["Apply"].ToString() != string.Empty)
        //            PermissionDetails[i].Apply = (bool)dt.Rows[i]["Apply"];
        //        if (dt.Rows[i]["Approvals"].ToString() != string.Empty)
        //            PermissionDetails[i].Approvals = (bool)dt.Rows[i]["Approvals"];
        //        if (dt.Rows[i]["ViewMode"].ToString() != string.Empty)
        //            PermissionDetails[i].ViewMode = (bool)dt.Rows[i]["ViewMode"];
        //    }

        //    return PermissionDetails;
        //}


        public Permission[] GetRoleWisePermissionInfo(int RoleID)
        {
            const String Qry = " Select ID FunctID,ModuleName,'' Apply,'' Approvals,'' ViewMode From Functions " +
                             " Where id not in(select functionid from Permissions where RoleID={0}) " +
                             " Union " +
                             " Select distinct F.ID FunctID,ModuleName,P.Apply,P.Approvals,P.ViewMode from Permissions P " +
                             " Right outer Join Functions F ON F.ID=P.FunctionID where RoleID={0} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, RoleID);

            DataTable dt = EE.ExecuteDataTable(exQry);

            Permission[] PermissionDetails = new Permission[dt.Rows.Count];

            for (int i = 0; i < PermissionDetails.Length; i++)
            {
                PermissionDetails[i] = new Permission();
                PermissionDetails[i].FunctionID = (int)dt.Rows[i]["FunctionID"];
                PermissionDetails[i].RoleID = (int)dt.Rows[i]["RoleID"];
                PermissionDetails[i].Apply = (bool)dt.Rows[i]["Apply"];
                PermissionDetails[i].Approvals = (bool)dt.Rows[i]["Approvals"];
                PermissionDetails[i].ViewMode = (bool)dt.Rows[i]["ViewMode"];
            }

            return PermissionDetails;
        }

        public Permission GetAssignedPermissions(int FunctionID, int RoleID)
        {
            const String Qry = " Select Apply, Approvals, ViewMode From Permissions  Where FunctionID={0} and RoleID={1} ";


            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, FunctionID, RoleID);

            DataTable dt = EE.ExecuteDataTable(exQry);
            Permission PermissionDetails = new Permission();
            PermissionDetails.Apply = (bool)dt.Rows[0]["Apply"];
            PermissionDetails.Approvals = (bool)dt.Rows[0]["Approvals"];
            PermissionDetails.ViewMode = (bool)dt.Rows[0]["ViewMode"];
            return PermissionDetails;
        }
        public Int32 GetFunctionIdByModuleName(string ModuleName)
        {
            Int32 ID = 0;
            string qry = "Select ID From Functions Where ModuleName='{0}'";
            ExecutionEngine EE1 = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry1 = new ExecutionQuery();
            exQry1.Query = string.Format(qry, ModuleName);
            Int32.TryParse(string.Concat(EE1.ExecuteScalar(exQry1)), out ID);
            return ID;
        }
        public Int32 GetRoleID(int EmployeeID)
        {
            Int32 ID = 0;
            String Qry = " select RoleID from Employee_OccupationDetails EOD "
                        + " Inner Join Assign_Emp_Designation_Role AEDR ON EOD.JobTitleID = AEDR.JobTitleID "
                        + " Where EOD.IsActive=1 And EmployeeID ={0} ";

            ExecutionEngine EE1 = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry1 = new ExecutionQuery();
            exQry1.Query = string.Format(Qry, EmployeeID);
            Int32.TryParse(string.Concat(EE1.ExecuteScalar(exQry1)), out ID);
            return ID;
        }
        public ComboBoxValues[] GetRoleCombo()
        {
            String Query = "SELECT ID,Role FROM Master_Role Where IsActive = 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = Query;

            DataTable dt = EE.ExecuteDataTable(exQry);
            ComboBoxValues[] DTO = new ComboBoxValues[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new ComboBoxValues();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].Value = (String)dt.Rows[i]["Role"];
            }
            return DTO;
        }

        
    }
}
