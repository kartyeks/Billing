using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;
using HRManager.Entity;
using HRManager.DTOEXT;

namespace HRManager.BusinessObjects
{
    public partial class Hr_DesignationBusinessObject
    {
        /// <summary>
        /// Get Designation By Designation Name
        /// </summary>
        /// <param name="DesignationName">field contaions Designation Name</param>
        /// <returns>data related given Designation Name in case of success otherwise it return null</returns>
        public Hr_Designation GetDesignationByDeignation(String DesignationName)
        {
            Hr_Designation[] Designation = GetDesignations(" Designation = '" + DesignationName + "'");

            if (Designation != null && Designation.Length >= 0)
            {
                return Designation[0];
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
        public Hr_Designation[] GetDesignationOrderByDeignation()
        {
            Hr_Designation[] Designation = GetDesignations(String.Empty);

            if (Designation != null && Designation.Length >= 0)
            {
                return Designation;
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
        public Hr_Designation[] GetDesignationForHigher(int ID)
        {
            Hr_Designation[] Designation = GetDesignations(" ID <> '" + ID + "'");

            if (Designation != null && Designation.Length >= 0)
            {
                return Designation;
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
        //public Hr_Designation[] GetAllInActiveDesignationsOrderByDeignation()
        //{
        //    Hr_Designation[] Designation = GetAllInActiveDesignation();

        //    if (Designation != null && Designation.Length >= 0)
        //    {
        //        return Designation;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        /// <summary>
        /// Get LocationTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        //public Hr_Designation[] GetAllInActiveDesignations()
        public Master_DesignationEXT[] GetAllInActiveDesignations()
        {
            //const String Qry = "SELECT * FROM Hr_Designation WHERE IsActive=0";
            const String Qry = "SELECT de.*,mr.Role FROM Hr_Designation de "
                                + " inner join Master_Role mr "
                                + " on  mr.id = de.Roleid WHERE de.IsActive=0 ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            //Hr_Designation[] DesignationDetails = new Hr_Designation[dt.Rows.Count];
            Master_DesignationEXT[] DesignationDetails = new Master_DesignationEXT[dt.Rows.Count];

            for (int i = 0; i < DesignationDetails.Length; i++)
            {
                DesignationDetails[i] = new Master_DesignationEXT();
                DesignationDetails[i].ID = (int)dt.Rows[i]["ID"];
                DesignationDetails[i].ParentDesignationID = (int)dt.Rows[i]["ParentDesignationID"];
                DesignationDetails[i].LeaveAppliedTo = (int)dt.Rows[i]["LeaveAppliedTo"];
                DesignationDetails[i].RoleID = (int)dt.Rows[i]["RoleID"];
                DesignationDetails[i].Designation = (String)dt.Rows[i]["Designation"];
                DesignationDetails[i].Description = (String)dt.Rows[i]["Description"];
                DesignationDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                DesignationDetails[i].Role = (String)dt.Rows[i]["Role"];
            }

            return DesignationDetails;
        }
        
        /// <summary>
        /// Get LocationTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        /// 


        //kartyek 10.2.2015 for checking manager in designation
        public Hr_Designation GetDesignationByIsHR(bool IsHR)
        {
            Hr_Designation[] Designation = GetDesignations(" IsHR = '" + IsHR + "'");

            if (Designation != null && Designation.Length > 0)
            {
                return Designation[0];
            }
            else
            {
                return null;
            }
        }
        //kartyek 10.2.2015 for checking manager in designation
        public Hr_Designation GetDesignationByIsFinance(bool IsFinance)
        {
            Hr_Designation[] Designation = GetDesignations(" IsFinance = '" + IsFinance + "'");

            if (Designation != null && Designation.Length > 0)
            {
                return Designation[0];
            }
            else
            {
                return null;
            }
        }
        public int GetAllActiveDesignationChildCount(int ParentID)
        {
            const String Qry = "SELECT isnull(count(*),0) childCount FROM Hr_Designation WHERE IsActive=1 and ParentDesignationID={0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, ParentID);
            DataTable dt = EE.ExecuteDataTable(exQry);

            return (int)dt.Rows[0]["childCount"];
        }

        //kartyek 12.02.2015 for getting the role of HR
        public Master_DesignationEXT[] GetHRRoles(int EmployeeID)
        {
            const String Qry = "exec Usp_CheckHR {0}";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmployeeID);
            DataTable dt = EE.ExecuteDataTable(exQry);
            if (dt.Rows.Count == 0)
            {
             const String Qry3 = " SELECT Initiator from Loan_request LR " +
                                " INNER JOIN Loan_activity LA " +
                                " ON LA.LoanRequestID=LR.ID " +
                                " WHERE Receiver='{0}' ";
             ExecutionEngine EE3 = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
             ExecutionQuery exQry3 = new ExecutionQuery();
             exQry3.Query = string.Format(Qry3, EmployeeID);
             DataTable dt3 = EE.ExecuteDataTable(exQry3);
             Master_DesignationEXT[] DesignationDetail = new Master_DesignationEXT[dt3.Rows.Count];
             for (int i = 0; i < DesignationDetail.Length; i++)
             {
                 DesignationDetail[i].ID = (int)dt3.Rows[i]["EmployeeID"];
             }
             return DesignationDetail;
            }
            //if (dt.Rows.Count == 0)
            //{
            //    const String Qry1 = "exec Usp_CheckManager {0}";
            //    ExecutionEngine EE2 = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            //    ExecutionQuery exQry2 = new ExecutionQuery();
            //    exQry2.Query = string.Format(Qry1, EmployeeID);
            //    DataTable dt1 = EE.ExecuteDataTable(exQry2);
            //    Master_DesignationEXT[] DesignationDetail = new Master_DesignationEXT[dt1.Rows.Count];

            //    for (int i = 0; i < DesignationDetail.Length; i++)
            //    {
            //        DesignationDetail[i] = new Master_DesignationEXT();
            //        DesignationDetail[i].ID = (int)dt1.Rows[i]["EmployeeID"];
            //        DesignationDetail[i].Role = (String)dt1.Rows[i]["Role"];
            //        //String Role = dt.Rows[0].ItemArray[0].ToString();
            //        //DesignationDetails[i].Role=Role;
            //        // Role = (String)dt.Rows[i]["Role"];
            //        //   DesignationDetails[i].Role=Role;
            //    }
            //    return DesignationDetail;
            //}
            else
            {
                Master_DesignationEXT[] DesignationDetail = new Master_DesignationEXT[dt.Rows.Count];

                for (int i = 0; i < DesignationDetail.Length; i++)
                {
                    DesignationDetail[i] = new Master_DesignationEXT();
                    DesignationDetail[i].ID = (int)dt.Rows[i]["EmployeeID"];
                    DesignationDetail[i].Role = (String)dt.Rows[i]["Role"];
                    //String Role = dt.Rows[0].ItemArray[0].ToString();
                    //DesignationDetails[i].Role=Role;
                    // Role = (String)dt.Rows[i]["Role"];
                    //   DesignationDetails[i].Role=Role;
                }
                return DesignationDetail;
            }

            //return DesignationDetail;
        }

        /// <summary>
        /// Get LocationTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        public Master_DesignationEXT[] GetAllActiveDesignations()
        {
            const String Qry = "SELECT de.*,mr.Role FROM Hr_Designation de "
                                + " inner join Master_Role mr "
                                + " on  mr.id = de.Roleid WHERE de.IsActive=1 ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_DesignationEXT[] DesignationDetails = new Master_DesignationEXT[dt.Rows.Count];

            for (int i = 0; i < DesignationDetails.Length; i++)
            {
                DesignationDetails[i] = new Master_DesignationEXT();
                DesignationDetails[i].ID = (int)dt.Rows[i]["ID"];
                DesignationDetails[i].ParentDesignationID = (int)dt.Rows[i]["ParentDesignationID"];
                DesignationDetails[i].LeaveAppliedTo = (int)dt.Rows[i]["LeaveAppliedTo"];
                DesignationDetails[i].RoleID = (int)dt.Rows[i]["RoleID"];
                DesignationDetails[i].Designation = (String)dt.Rows[i]["Designation"];
                DesignationDetails[i].Description = (String)dt.Rows[i]["Description"];
                DesignationDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                DesignationDetails[i].Role = (String)dt.Rows[i]["Role"];
            }

            return DesignationDetails;
        }
        /// <summary>
        /// Get Designations data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_Role object</returns>
        /// <summary>
        /// Get Designations data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Hr_Designation object</returns>
        public Hr_Designation[] GetDesignations(String Filter)
        {
            const String Qry = "with DesgHierarchy (ParentDesignationID,ID,Designation,LeaveAppliedTo, RoleID, Description, IsActive)As ( "
                            + " SELECT ParentDesignationID,ID,Designation,LeaveAppliedTo, RoleID, Description, IsActive"
                            + " FROM Hr_Designation O WHERE ParentDesignationID='0'"
                            + " Union All "
                            + " SELECT  dt.ParentDesignationID,dt.ID,dt.Designation,dt.LeaveAppliedTo, dt.RoleID, dt.Description, dt.IsActive"
                            + " FROM Hr_Designation dt INNER JOIN DesgHierarchy h ON dt.ParentDesignationID = h.ID )"
                            + " Select * from DesgHierarchy  " ; // SELECT * FROM Hr_Designation WHERE IsActive=1 and ID<>1 ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            if (Filter == String.Empty)
            {
                exQry.Query = string.Format(Qry);// +" order by ParentDesignationID,Designation ";
            }
            else
            {
                //commented by karthik for the doubt
             //   exQry.Query = string.Format(Qry) + " And " + Filter;// +" order by ParentDesignationID,Designation ";
                  exQry.Query = string.Format(Qry);
            }

            DataTable dt = EE.ExecuteDataTable(exQry);

            Hr_Designation[] DesignationDetails = new Hr_Designation[dt.Rows.Count];

            for (int i = 0; i < DesignationDetails.Length; i++)
            {
                DesignationDetails[i] = new Hr_Designation();
                DesignationDetails[i].ID = (int)dt.Rows[i]["ID"];
                DesignationDetails[i].ParentDesignationID = (int)dt.Rows[i]["ParentDesignationID"];
                DesignationDetails[i].LeaveAppliedTo = (int)dt.Rows[i]["LeaveAppliedTo"];
                DesignationDetails[i].RoleID = (int)dt.Rows[0]["RoleID"];
                DesignationDetails[i].Designation = (String)dt.Rows[i]["Designation"];
                DesignationDetails[i].Description = (String)dt.Rows[i]["Description"];
                DesignationDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
            }

            return DesignationDetails;
        }

        public Designation GetDesignationbyID(int designationID)
        {
            const String Qry = " SELECT * FROM Hr_Designation WHERE ID={0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, designationID.ToString());

            DataTable dt = EE.ExecuteDataTable(exQry);

            Designation DesignationDetails = new Designation();

            DesignationDetails = new Designation();
            if (dt.Rows.Count > 0)
            {
                DesignationDetails.ID = (int)dt.Rows[0]["ID"];
                DesignationDetails.RoleID = (int)dt.Rows[0]["RoleID"];
                DesignationDetails.DesignationName = (String)dt.Rows[0]["Designation"];
                DesignationDetails.IsActive = (bool)dt.Rows[0]["IsActive"];
            }
            return DesignationDetails;
        }


        public Designation GetAllDesignationDetails()
        {
            const String Qry = " SELECT * FROM Hr_Designation ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);

            DataTable dt = EE.ExecuteDataTable(exQry);

            Designation DesignationDetails = new Designation();

            DesignationDetails = new Designation();
            if (dt.Rows.Count > 0)
            {
                DesignationDetails.ID = (int)dt.Rows[0]["ID"];
                DesignationDetails.RoleID = (int)dt.Rows[0]["RoleID"];
                DesignationDetails.DesignationName = (String)dt.Rows[0]["Designation"];
                DesignationDetails.IsActive = (bool)dt.Rows[0]["IsActive"];
            }
            return DesignationDetails;
        }
        /// <summary>
        /// Get Role details By locationID
        /// </summary>
        /// <param name="LocationID">field contaions LocationID  </param>
        /// <returns>Array of Role object(details of all roles that exist for given LocationID), in case of success otherwise it return null</returns>
        public Hr_Designation[] GetDesignationDetailsByLocationID(int LocationID)
        {
            const String Qry =  " select distinct HD.ID, HD.Designation " +
                                " from master_jobprofile MJP " +
                                " inner join  Hr_Designation HD on (HD.id=MJP.DesignationID)  " +
                                " WHERE MJP.IsActive=1  and [dbo].[GetSelectedCandidate](MJP.id)<NoOfVacancies " +
                                " and MJP.Status='APP' and MJP.LocationID='{0}'";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, LocationID.ToString());
            DataTable dt = EE.ExecuteDataTable(exQry);

            Hr_Designation[] DesignationDetails = new Hr_Designation[dt.Rows.Count];

            for (int i = 0; i < DesignationDetails.Length; i++)
            {
                DesignationDetails[i] = new Hr_Designation();
                DesignationDetails[i].ID = (int)dt.Rows[i]["ID"];
                DesignationDetails[i].Designation = (String)dt.Rows[i]["Designation"];
            }

            return DesignationDetails;
        }
        /// <summary>
        /// check Designation Existance in the database.
        /// </summary>
        /// <param name="Deignation">field contains designation name</param>
        /// <param name="ID">field contains designation ID</param>
        /// <returns>True for Exist and false for not exist</returns>
        public bool IsDeignationExists(String Deignation, int ID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Hr_Designation WHERE Designation = '{0}' AND ID<>{1})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, Deignation, ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }
        public bool IsDesignationRefered(int ID)
        {
            const String Qry = " IF EXISTS ( SELECT ID FROM Employee_OccupationDetails WHERE DesignationID = '{0}') "
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

        public Master_DesignationEXT[] GetAllActiveDesignationsDetails()
        {
            const String Qry = "SELECT de.*,mr.Role FROM Hr_Designation de "
                                + " inner join Master_Role mr "
                                + " on  mr.id = de.Roleid ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_DesignationEXT[] DesignationDetails = new Master_DesignationEXT[dt.Rows.Count];

            for (int i = 0; i < DesignationDetails.Length; i++)
            {
                DesignationDetails[i] = new Master_DesignationEXT();
                DesignationDetails[i].ID = (int)dt.Rows[i]["ID"];
                DesignationDetails[i].ParentDesignationID = (int)dt.Rows[i]["ParentDesignationID"];
                DesignationDetails[i].LeaveAppliedTo = (int)dt.Rows[i]["LeaveAppliedTo"];
                DesignationDetails[i].RoleID = (int)dt.Rows[i]["RoleID"];
                DesignationDetails[i].Designation = (String)dt.Rows[i]["Designation"];
                DesignationDetails[i].Description = (String)dt.Rows[i]["Description"];
                DesignationDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                DesignationDetails[i].Role = (String)dt.Rows[i]["Role"];
            }

            return DesignationDetails;
        }
                
    }
}
