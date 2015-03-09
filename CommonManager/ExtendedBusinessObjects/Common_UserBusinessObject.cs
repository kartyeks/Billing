using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using CommonManager.DTO;
using CommonManager.Entity;


namespace CommonManager.BusinessObjects
{
    public partial class Common_UserBusinessObject
    {

        /// <summary>
        /// Get Designations data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_Skill object</returns>
        public User[] GetInActiveUsers(string Type)
        {
            const String Qry = "Select ROW_NUMBER() over(order by UserDetails.ID) AS Sno,* from (  " +
                    " Select FirstName + ' ' + LastName AS EmployeeName,EmailID,U.* From Common_User U  " +
                    " Inner Join Master_Employees P ON P.ID=U.EmployeeID  " +
                //" Inner Join Master_Candidate C ON C.ID=P.CandidateID  " +
                    " where U.IsActive=0 and U.LoginType='EMP' " +
                    " Union " +
                    " Select J.Agencyname AS EmployeeName,'0' CandidateID,J.EmailID,U.* From Common_User U   " +
                    " Inner Join master_JobAgency J ON J.ID=U.EmployeeID  " +
                    " where U.IsActive=0 and U.LoginType='CNT' " +
                    " ) UserDetails  Where LoginType='{0}' " +
                    " order by LoginType Desc";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, Type.ToString());

            DataTable dt = EE.ExecuteDataTable(exQry);

            User[] UserDetails = new User[dt.Rows.Count];

            for (int i = 0; i < UserDetails.Length; i++)
            {
                UserDetails[i] = new User();
                if (dt.Rows[i]["Sno"].ToString() != string.Empty)
                    UserDetails[i].Sno = dt.Rows[i]["Sno"].ToString();
                if (dt.Rows[i]["ID"].ToString() != string.Empty)
                    UserDetails[i].UserID = (int)dt.Rows[i]["ID"];
                if (dt.Rows[i]["EmployeeID"].ToString() != string.Empty)
                    UserDetails[i].EmployeeID = (int)dt.Rows[i]["EmployeeID"];
                //if (dt.Rows[i]["CandidateID"].ToString() != string.Empty)
                //    UserDetails[i].CandidateID = (int)dt.Rows[i]["CandidateID"];
                if (dt.Rows[i]["Password"].ToString() != string.Empty)
                    UserDetails[i].Password = IS91.Services.Common.DecryptB64String((String)dt.Rows[i]["Password"]);
                if (dt.Rows[i]["EmployeeName"].ToString() != string.Empty)
                    UserDetails[i].EmployeeName = (String)dt.Rows[i]["EmployeeName"];
                if (dt.Rows[i]["EmailID"].ToString() != string.Empty)
                    UserDetails[i].EmailID = (String)dt.Rows[i]["EmailID"];
                if (dt.Rows[i]["LoginName"].ToString() != string.Empty)
                    UserDetails[i].LoginName = (String)dt.Rows[i]["LoginName"];
                if (dt.Rows[i]["IsActive"].ToString() != string.Empty)
                    UserDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                if (dt.Rows[i]["IsChangePassword"].ToString() != string.Empty)
                    UserDetails[i].IsChangePassword = (bool)dt.Rows[i]["IsChangePassword"];
                if (dt.Rows[i]["IsLocked"].ToString() != string.Empty)
                    UserDetails[i].IsLocked = (bool)dt.Rows[i]["IsLocked"];
                if (dt.Rows[i]["LastLoginTime"].ToString() != string.Empty)
                    UserDetails[i].LastLoginTime = (DateTime)dt.Rows[i]["LastLoginTime"];
                if (dt.Rows[i]["LoginType"].ToString() != string.Empty)
                    UserDetails[i].LoginType = (String)dt.Rows[i]["LoginType"];

            }

            return UserDetails;
        }
        public Common_User GetCommon_UserByEmp(int ID, string Colname)
        {
            const String Qry = " Select * from Common_User Where {0}={1} and LoginType='EMP' ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, Colname, ID.ToString());

            DataTable dt = EE.ExecuteDataTable(exQry);

            Common_User[] UserDetails = new Common_User[1];

            for (int i = 0; i < 1; i++)
            {
                UserDetails[i] = new Common_User();

                if (dt.Rows[i]["ID"].ToString() != string.Empty)
                    UserDetails[i].ID = (int)dt.Rows[i]["ID"];
                if (dt.Rows[i]["EmployeeID"].ToString() != string.Empty)
                    UserDetails[i].EmployeeID = (int)dt.Rows[i]["EmployeeID"];
                if (dt.Rows[i]["LoginName"].ToString() != string.Empty)
                    UserDetails[i].LoginName = (String)dt.Rows[i]["LoginName"];
                if (dt.Rows[i]["Password"].ToString() != string.Empty)
                    UserDetails[i].Password = IS91.Services.Common.DecryptB64String((String)dt.Rows[i]["Password"]);
                if (dt.Rows[i]["IsActive"].ToString() != string.Empty)
                    UserDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                if (dt.Rows[i]["IsChangePassword"].ToString() != string.Empty)
                    UserDetails[i].IsChangePassword = (bool)dt.Rows[i]["IsChangePassword"];
                if (dt.Rows[i]["IsLocked"].ToString() != string.Empty)
                    UserDetails[i].IsLocked = (bool)dt.Rows[i]["IsLocked"];
                if (dt.Rows[i]["LastLoginTime"].ToString() != string.Empty)
                    UserDetails[i].LastLoginTime = (DateTime)dt.Rows[i]["LastLoginTime"];
                if (dt.Rows[i]["LoginType"].ToString() != string.Empty)
                    UserDetails[i].LoginType = (String)dt.Rows[i]["LoginType"];    //done by karthik
                if (dt.Rows[i]["IsDefaultUser"].ToString() != string.Empty)
                    UserDetails[i].IsDefaultUser = (bool)dt.Rows[i]["IsDefaultUser"];
                if (dt.Rows[i]["InvalidLoginCount"].ToString() != string.Empty)
                    UserDetails[i].InvalidLoginCount = (Int16)dt.Rows[i]["InvalidLoginCount"];
                if (dt.Rows[i]["CreatedBy"].ToString() != string.Empty)
                    UserDetails[i].CreatedBy = (int)dt.Rows[i]["CreatedBy"];
                if (dt.Rows[i]["CreatedDate"].ToString() != string.Empty)
                    UserDetails[i].CreatedDate = (DateTime)dt.Rows[i]["CreatedDate"];
                if (dt.Rows[i]["ModifiedBy"].ToString() != string.Empty)
                    UserDetails[i].ModifiedBy = (int)dt.Rows[i]["ModifiedBy"];
                if (dt.Rows[i]["ModifiedDate"].ToString() != string.Empty)
                    UserDetails[i].ModifiedDate = (DateTime)dt.Rows[i]["ModifiedDate"];

            }

            return UserDetails[0];
        }
        /// <summary>
        /// Get Designations data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_Skill object</returns>
        public User[] GetUserEmployees(string Type)
        {
            const String Qry = "Select ROW_NUMBER() over(order by UserDetails.ID) AS Sno,* from (  " +
                                " Select FirstName + ' ' + LastName AS EmployeeName,EmailID,U.* From Common_User U  " +
                                " Inner Join Master_Employees P ON P.ID=U.EmployeeID  " +
                //" Inner Join Master_Candidate C ON C.ID=P.CandidateID  " +
                                " where U.IsActive=1 and U.LoginType='EMP' " +
                                " Union " +
                                " Select J.Agencyname AS EmployeeName,J.EmailID,U.* From Common_User U   " +
                                " Inner Join master_JobAgency J ON J.ID=U.EmployeeID  " +
                                " where U.IsActive=1 and U.LoginType='CNT' " +
                                " ) UserDetails  Where LoginType='{0}' " +
                                " order by LoginType Desc";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, Type.ToString());

            DataTable dt = EE.ExecuteDataTable(exQry);

            User[] UserDetails = new User[dt.Rows.Count];

            for (int i = 0; i < UserDetails.Length; i++)
            {
                UserDetails[i] = new User();
                if (dt.Rows[i]["Sno"].ToString() != string.Empty)
                    UserDetails[i].Sno = dt.Rows[i]["Sno"].ToString();
                if (dt.Rows[i]["ID"].ToString() != string.Empty)
                    UserDetails[i].UserID = (int)dt.Rows[i]["ID"];
                if (dt.Rows[i]["EmployeeID"].ToString() != string.Empty)
                    UserDetails[i].EmployeeID = (int)dt.Rows[i]["EmployeeID"];
                //if (dt.Rows[i]["CandidateID"].ToString() != string.Empty)
                //    UserDetails[i].CandidateID = (int)dt.Rows[i]["CandidateID"];
                if (dt.Rows[i]["Password"].ToString() != string.Empty)
                    UserDetails[i].Password = IS91.Services.Common.DecryptB64String((String)dt.Rows[i]["Password"]);
                if (dt.Rows[i]["EmployeeName"].ToString() != string.Empty)
                    UserDetails[i].EmployeeName = (String)dt.Rows[i]["EmployeeName"];
                if (dt.Rows[i]["EmailID"].ToString() != string.Empty)
                    UserDetails[i].EmailID = (String)dt.Rows[i]["EmailID"];
                if (dt.Rows[i]["LoginName"].ToString() != string.Empty)
                    UserDetails[i].LoginName = (String)dt.Rows[i]["LoginName"];
                if (dt.Rows[i]["IsActive"].ToString() != string.Empty)
                    UserDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                if (dt.Rows[i]["IsChangePassword"].ToString() != string.Empty)
                    UserDetails[i].IsChangePassword = (bool)dt.Rows[i]["IsChangePassword"];
                if (dt.Rows[i]["IsLocked"].ToString() != string.Empty)
                    UserDetails[i].IsLocked = (bool)dt.Rows[i]["IsLocked"];
                if (dt.Rows[i]["LastLoginTime"].ToString() != string.Empty)
                    UserDetails[i].LastLoginTime = (DateTime)dt.Rows[i]["LastLoginTime"];
                if (dt.Rows[i]["LoginType"].ToString() != string.Empty)
                    UserDetails[i].LoginType = (String)dt.Rows[i]["LoginType"];

            }

            return UserDetails;
        }

        /// <summary>
        /// Get User by the loginname
        /// </summary>
        /// <param name="LoginName">Login name</param>
        /// <returns>User DTO Object</returns>
        public Common_User GetUserByLoginName(String LoginName)
        {
            Common_User[] User = GetUsers(" LoginName = '" + LoginName + "'");

            if (User != null && User.Length > 0)
            {
                return User[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get User by anu filter
        /// </summary>
        /// <param name="Filter">Filter String</param>
        /// <returns>User DTO Object</returns>
        public Common_User[] GetUsers(String Filter)
        {
            const String Qry = " SELECT * FROM Common_User ";

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

            Common_User[] UserDetails = new Common_User[dt.Rows.Count];

            for (int i = 0; i < UserDetails.Length; i++)
            {
                UserDetails[i] = new Common_User();
                UserDetails[i].ID = (int)dt.Rows[i]["ID"];
                UserDetails[i].EmployeeID = (int)dt.Rows[i]["EmployeeID"];
                UserDetails[i].LoginName = (String)dt.Rows[i]["LoginName"];
                UserDetails[i].Password = (String)dt.Rows[i]["Password"];
                UserDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                UserDetails[i].IsChangePassword = (bool)dt.Rows[i]["IsChangePassword"];
                UserDetails[i].IsLocked = (bool)dt.Rows[i]["IsLocked"];
                UserDetails[i].LastLoginTime = (DateTime)dt.Rows[i]["LastLoginTime"];
            }

            return UserDetails;
        }



        /// <summary>
        /// Get User by the loginname
        /// </summary>
        /// <param name="LoginName">Login name</param>
        /// <returns>User DTO Object</returns>
        public User GetUserByLogin(String LoginName)
        {
            User[] User = GetUser(" LoginName = '" + LoginName + "'");

            if (User != null && User.Length > 0)
            {
                return User[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Get User by anu filter
        /// </summary>
        /// <param name="Filter">Filter String</param>
        /// <returns>User DTO Object</returns>
        public User[] GetUser(String Filter)
        {
            ////const String Qry = " Select ROW_NUMBER() over(order by UserDetails.ID) AS Sno,* from (  " +
            ////                     " Select FirstName + ' ' + LastName AS EmployeeName,EmailID,U.* From Common_User U  " +
            ////                     " Inner Join Master_Employees P ON P.ID=U.EmployeeID  " +
            ////                     //" Inner Join Master_Candidate C ON C.ID=P.CandidateID  " +
            ////                     " where U.IsActive=1 and U.EmpType='EMP' " +
            ////                     " Union " +
            ////                     " Select J.Agencyname AS EmployeeName,J.EmailID,U.* From Common_User U   " +
            ////                     " Inner Join master_JobAgency J ON J.ID=U.EmployeeID   " +
            ////                     " where U.IsActive=1 and U.EmpType='AGN' " +
            ////                     " ) UserDetails  ";

            //const String Qry = " Select * From Common_User ";

            const String Qry = " Select distinct ROW_NUMBER() over(order by UserDetails.ID) AS Sno,* from (   " +
                               "   Select distinct RoleID,Role,FirstName + ' ' + LastName AS EmployeeName,PersonalEmailID EmailID,U.* From Common_User U   " +
                               "  Inner Join Master_Employees P ON P.ID=U.EmployeeID  " +
                               "  INNER JOIN dbo.Employee_OccupationDetails EO ON EO.EmployeeID=P.ID " +
                               "  INNER JOIN Hr_Designation D ON D.ID=EO.DesignationID " +
                               "  INNER JOIN dbo.Master_Role R ON R.ID=D.RoleID " +
                               "  where P.IsActive=1 and U.IsActive=1 and P.IsDeleted=0  and EO.IsActive=1 and U.LoginType='EMP' " +
                               " Union  " +
                               " Select distinct  RoleID,Role,J.ConsultantName AS EmployeeName,J.EmailID,U.* From Common_User U    " +
                               " Inner Join Master_Consultant J ON J.ID=U.EmployeeID  " +
                               " INNER JOIN Hr_Designation D ON D.ID=J.DesignationID " +
                               " INNER JOIN dbo.Master_Role R ON R.ID=D.RoleID   " +
                               "  where J.IsActive=1 and U.IsActive=1 and U.LoginType='CNT'    " +
                                "  ) UserDetails  ";
            //Union 
            //Select J.Agencyname AS EmployeeName,J.EmailID,U.* From Common_User U   
            //Inner Join master_JobAgency J ON J.ID=U.EmployeeID   
            // where U.IsActive=1 and U.EmpType='AGN' 


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

            User[] UserDetails = new User[dt.Rows.Count];

            for (int i = 0; i < UserDetails.Length; i++)
            {
                UserDetails[i] = new User();
                UserDetails[i].UserID = (int)dt.Rows[i]["ID"];
                UserDetails[i].EmployeeID = (int)dt.Rows[i]["EmployeeID"];
                UserDetails[i].LoginName = (String)dt.Rows[i]["LoginName"];
                UserDetails[i].Password = (String)dt.Rows[i]["Password"];
                UserDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                UserDetails[i].IsChangePassword = (bool)dt.Rows[i]["IsChangePassword"];
                UserDetails[i].IsLocked = (bool)dt.Rows[i]["IsLocked"];
                UserDetails[i].LastLoginTime = (DateTime)dt.Rows[i]["LastLoginTime"];
                UserDetails[i].RoleID = (int)dt.Rows[i]["RoleID"];
                UserDetails[i].RoleName = (String)dt.Rows[i]["Role"];
                //UserDetails[i].EmployeeName = (String)dt.Rows[i]["EmployeeName"];
                UserDetails[i].LoginType = (String)dt.Rows[i]["LoginType"];
            }

            return UserDetails;
        }
        /// <summary>
        /// Get LocationTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        public Common_User[] GetAllUser()
        {
            const String Qry = " SELECT * FROM Common_User WHERE IsActive=1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Common_User[] UserDetails = new Common_User[dt.Rows.Count];

            for (int i = 0; i < UserDetails.Length; i++)
            {
                UserDetails[i] = new Common_User();
                UserDetails[i].ID = (int)dt.Rows[i]["ID"];
                UserDetails[i].LoginName = (String)dt.Rows[i]["LoginName"];
                UserDetails[i].Password = (String)dt.Rows[i]["Password"];
                UserDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                UserDetails[i].IsChangePassword = (bool)dt.Rows[i]["IsChangePassword"];
                UserDetails[i].IsLocked = (bool)dt.Rows[i]["IsLocked"];
                UserDetails[i].LastLoginTime = (DateTime)dt.Rows[i]["LastLoginTime"];
            }
            return UserDetails;
        }

        /// <summary>
        /// Get LocationTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        public Common_User[] GetAllActiveUsers()
        {
            const String Qry = "SELECT * FROM Common_User WHERE IsActive=1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Common_User[] UserDetails = new Common_User[dt.Rows.Count];

            for (int i = 0; i < UserDetails.Length; i++)
            {
                UserDetails[i] = new Common_User();
                UserDetails[i].ID = (int)dt.Rows[i]["ID"];
                UserDetails[i].LoginName = (String)dt.Rows[i]["LoginName"];
                UserDetails[i].Password = (String)dt.Rows[i]["Password"];
                UserDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                UserDetails[i].IsChangePassword = (bool)dt.Rows[i]["IsChangePassword"];
                UserDetails[i].IsLocked = (bool)dt.Rows[i]["IsLocked"];
                UserDetails[i].LastLoginTime = (DateTime)dt.Rows[i]["LastLoginTime"];
            }
            return UserDetails;
        }

        public Common_User[] GetAllInActiveUsersOrderByUser()
        {
            Common_User[] User = GetAllInActiveUser();

            if (User != null && User.Length >= 0)
            {
                return User;
            }
            else
            {
                return null;
            }
        }

        public static String GetEmpBasedUsers(int EmployeeID, String LoginType)
        {
            const String Qry = " SELECT isnull(LoginName,'')LoginName from Common_User WHERE EmployeeID={0} AND  LoginType = '{1}'";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmployeeID.ToString(), LoginType);
            DataTable dt = EE.ExecuteDataTable(exQry);

            String empdetails = "";

            if (dt.Rows.Count > 0)
                empdetails = (String)dt.Rows[0]["LoginName"];

            return empdetails;


        }
        public static int GetResetUsers(int ID, int EmployeeID, String LoginType)
        {

            const String Qry = " SELECT ID,EmployeeID from Common_User WHERE LoginType = 'CNT' AND EmployeeID={0}";
            int RESULT = 0;
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry,ID);
            DataTable dt = EE.ExecuteDataTable(exQry);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                RESULT = (int)dt.Rows[0]["ID"];
            }

            return RESULT;


        }

        public Common_User[] GetAllInActiveUser()
        {
            const String Qry = "SELECT * FROM Common_User WHERE IsActive=0";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Common_User[] UserDetails = new Common_User[dt.Rows.Count];

            for (int i = 0; i < UserDetails.Length; i++)
            {
                UserDetails[i] = new Common_User();
                UserDetails[i].ID = (int)dt.Rows[i]["ID"];
                UserDetails[i].LoginName = (String)dt.Rows[i]["LoginName"];
                UserDetails[i].Password = (String)dt.Rows[i]["Password"];
                UserDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                UserDetails[i].IsChangePassword = (bool)dt.Rows[i]["IsChangePassword"];
                UserDetails[i].IsLocked = (bool)dt.Rows[i]["IsLocked"];
                UserDetails[i].LastLoginTime = (DateTime)dt.Rows[i]["LastLoginTime"];
            }
            return UserDetails;
        }


        /// <summary>
        /// Checks that the loginname already exists in the system
        /// </summary>
        /// <param name="LoginName">Login ID of the user</param>
        /// <param name="UserID">User ID</param>
        /// <returns></returns>
        public bool IsLoginNameExists(String LoginName, int UserID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Common_User WHERE LoginName = '{0}' AND ID<>{1})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, LoginName, UserID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }

        /// <summary>
        /// Checks that the email already exists in the system
        /// </summary>
        /// <param name="EmailID">EmailID of the user</param>
        /// <param name="UserID">User ID</param>
        /// <returns></returns>
        public bool IsEMailExists(String EmailID, int UserID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Master_Employees WHERE EMailID = '{0}' AND ID<>{1})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmailID, UserID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }

        public string GetUserEmailID(string loginName)
        {
            const String Qry = "Select PersonalEmailID from Master_Employees P " +
                               "INNER JOIN Common_User U ON U.EmployeeID=P.ID " +
                               "Where P.EmpCode='{0}' ";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = String.Format(Qry, loginName);
            object ret = EE.ExecuteScalar(exQry);
            return string.Concat(ret, string.Empty);
        }

        public string GetUserEmailIDOnReset(string loginName)
        {
            const String Qry = " Select EmailID from Master_Consultant C  " +
                               " INNER JOIN Common_User U ON U.EmployeeID=C.ID " +
                               " Where U.LoginName='{0}' ";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = String.Format(Qry, loginName);
            object ret = EE.ExecuteScalar(exQry);
            return string.Concat(ret, string.Empty);
        }

        public Common_User GetUserByLoginNames(String UserLoginName)
        {
            if (String.IsNullOrEmpty(UserLoginName))
            {
                return null;
            }
            QueryCriteria QC = new QueryCriteria(this.mapped);
            QC.Add(CriteriaOperator.Equality, this.mapped.GetField("LoginName"), UserLoginName);
            Array UserObj = persistent.GetTableMetadata(QC);
            if (UserObj.Length < 1)
            {
                return null;
            }
            return (Common_User)UserObj.GetValue(0);
        }
        public DataTable GetUserInfoForEmail(string LoginName)
        {
            const String Qry = " Select EmailID,Password From Common_User U " +
                              " Inner Join dbo.Master_Employees E ON E.ID=U.EmployeeID Where LoginName='{0}'";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, LoginName);
            return EE.ExecuteDataTable(exQry);
        }
        public String GetMenuString(string rolename)
        {
            const String Qry = "SELECT Menu FROM Master_Role WHERE Role='{0}'";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, rolename);
            return string.Concat(EE.ExecuteScalar(exQry));
        }
        public String GetRole(int empID)
        {
            const String Qry = "SELECT Role FROM Assign_Emp_Designation A " +
                               " INNER JOIN Hr_Designation D ON D.ID=A.DesignationID " +
                               " INNER JOIN Master_Role M On M.ID=D.RoleID " +
                               " WHERE EmployeeID={0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, empID);
            return string.Concat(EE.ExecuteScalar(exQry));
        }
    }
}
