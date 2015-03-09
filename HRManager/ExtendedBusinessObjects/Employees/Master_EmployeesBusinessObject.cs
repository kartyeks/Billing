using System;
using System.Data;
using IS91.Services.DataBlock;
using System.Collections;
using HRManager.DTO;
using HRManager.Entity.EmployeesInfo;
using HRManager.DTOEXT.Employees;
using IRCA.Communication;
using HRManager.Entity;

namespace HRManager.BusinessObjects
{
    public partial class Master_EmployeesBusinessObject
    {

        public BaseMaster_EmployeeExtened[] GetBaseMasterEmployee(String FirstName, String LastName, String Empcode, int DesignationID, int CountryID, int LocationID, int TeamID)
        {
            String Qry = " exec Proc_GetEmployeeGridData '{0}','{1}','{2}',{3},{4},{5},{6}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = String.Format(Qry, FirstName, LastName, Empcode, DesignationID, CountryID, LocationID, TeamID);

            DataTable dt = EE.ExecuteDataTable(exQry);

            BaseMaster_EmployeeExtened[] DTO = new BaseMaster_EmployeeExtened[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new BaseMaster_EmployeeExtened();
                DTO[i].EmpID = (int)dt.Rows[i]["EmpID"];
                DTO[i].EmpCode = (String)dt.Rows[i]["EmpCode"];
                DTO[i].EmployeeTypeID = (int)dt.Rows[i]["EmployeeTypeID"];
                DTO[i].FirstName = (String)dt.Rows[i]["FirstName"];
                DTO[i].MiddleName = (String)dt.Rows[i]["MiddleName"];
                DTO[i].LastName = (String)dt.Rows[i]["LastName"];
                DTO[i].EmployeeType = (String)dt.Rows[i]["EmployeeType"];
                DTO[i].CountryName = (String)dt.Rows[i]["CountryName"];
                DTO[i].LocationName = (String)dt.Rows[i]["LocationName"];
                DTO[i].Designation = (String)dt.Rows[i]["Designation"];
                DTO[i].TeamName = (String)dt.Rows[i]["TeamName"];
                DTO[i].ManagerName = (String)dt.Rows[i]["ManagerName"];
                DTO[i].Gender = (String)dt.Rows[i]["Gender"];
                DTO[i].EmailID = (String)dt.Rows[i]["EmailID"];
            }

            return DTO;
        }
        //kartyek 11.02.2015 new added to get roleid based on employee
        public int GetDesignationRoleIDEmployees(int empID)
        {
            const String Qry = " SELECT HRD.RoleID from Employee_OccupationDetails EO " +
                                " INNER join Hr_Designation HRD " +
                                " ON HRD.ID=EO.DesignationID " +
                                " INNER join Master_Role MR " +
                                " ON MR.ID=HRD.RoleID " +
                                " WHERE EmployeeID='{0}'";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, empID);
            int cnt = 0;
            int.TryParse(string.Concat(EE.ExecuteScalar(exQry)), out cnt);
            return cnt;
        }
        //kartyek 12.2.2015 for manager name using employee id
        public int GetMangerIDEmployeesfromLoanrequest(int empID)
        {
            const String Qry = " SELECT Initiator FROM Loan_activity " +
                               " WHERE Receiver='{0}'";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, empID);
            int cnt = 0;
            int.TryParse(string.Concat(EE.ExecuteScalar(exQry)), out cnt);
            return cnt;
        }
       //kartyek 12.02.2015 get all Requested loans for HR display
        public int GetAllLoanrequestDetails(int empID)
        {
            const String Qry = " SELECT  DISTINCT " +
                                " Role   " +
                                " ,EmployeeID  " +
                                " ,(FirstName+ ' '+MiddleName+ ' '+LastName)EmployeeName  " +
                                " FROM  " +
                                " Employee_OccupationDetails EO  " +
                                " INNER JOIN   " +
                                " Master_Employees ME  " +
                                " ON  " +
                                " ME.ID=EO.EmployeeID  " +
                                " INNER JOIN  " +
                                " Hr_Designation HD  " +
                                " ON  " +
                                " HD.ID = EO.DesignationID  " +
                                " INNER JOIN  " +
                                " Master_Role MR  " +
                                " ON  " +
                                " MR.ID=HD.RoleID  " +
                                " WHERE Role='HR'  AND EO.EmployeeID='{0}' " +
                                " AND MR.IsActive=1 ";
  

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, empID);
            int cnt = 0;
            int.TryParse(string.Concat(EE.ExecuteScalar(exQry)), out cnt);
            return cnt;
        }
        //kartyek 11.02.2015 for manager name using employee id
        public int GetMaangerIDEmployees(int empID)
        {
            const String Qry = " SELECT ManagerID from Master_Team MT " +
                                " INNER JOIN Employee_OccupationDetails EO " +
                                " ON EO.TeamID=MT.ID " +
                                " INNER JOIN Master_Employees ME " +
                                " ON " +
                                " ME.ID=MT.ManagerID " +
                                " WHERE EO.EmployeeID='{0}' AND EO.IsActive=1 ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, empID);
            int cnt = 0;
            int.TryParse(string.Concat(EE.ExecuteScalar(exQry)), out cnt);
            return cnt;
        }
        //archana 17.2.2015 new added for latest project belongs to an employee
        public EmployeeOccupationDetails GetProjectEmployees(int empID)
        {
            const String Qry = " Select * From  Employee_OccupationDetails WHERE EmployeeID = '{0}'" +
                                " and ActivatedDate = (SELECT MAX(ActivatedDate) FROM Employee_OccupationDetails  " +
                                " where EmployeeID ='{0}')";


            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, empID.ToString());
            DataTable dt = EE.ExecuteDataTable(exQry);

            EmployeeOccupationDetails empdesig = new EmployeeOccupationDetails();
            if (dt.Rows.Count > 0)
            {
                empdesig.ID = (int)dt.Rows[0]["ID"];
                empdesig.EmployeeID = (int)dt.Rows[0]["EmployeeID"];
                empdesig.ProjectId = (int)dt.Rows[0]["ProjectId"];
                empdesig.IsActive = (Boolean)dt.Rows[0]["IsActive"];
                empdesig.ActivatedDate = (DateTime)dt.Rows[0]["ActivatedDate"];
                //empdesig.CreatedBy = (int)dt.Rows[0]["CreatedBy"];
                //empdesig.CreatedDate = (DateTime)dt.Rows[0]["CreatedDate"];
                //empdesig.ModifiedBy = (int)dt.Rows[0]["ModifiedBy"];
                //empdesig.ModifiedDate = (DateTime)dt.Rows[0]["ModifiedDate"];
            }
            return empdesig;
        }
        //kartyek 9.2.2015 new added for loan activity for designation related
        public EmployeeOccupationDetails GetDesignationEmployees(int empID)
        {
            const String Qry = " Select * From  Employee_OccupationDetails WHERE EmployeeID = '{0}'" +
                                " and ActivatedDate = (SELECT MAX(ActivatedDate) FROM Employee_OccupationDetails  " +
                                " where EmployeeID ='{0}')";


            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, empID.ToString());
            DataTable dt = EE.ExecuteDataTable(exQry);

            EmployeeOccupationDetails empdesig = new EmployeeOccupationDetails();
            if (dt.Rows.Count > 0)
            {
                empdesig.ID = (int)dt.Rows[0]["ID"];
                empdesig.EmployeeID = (int)dt.Rows[0]["EmployeeID"];
                empdesig.DesignationID = (int)dt.Rows[0]["DesignationID"];
                empdesig.IsActive = (Boolean)dt.Rows[0]["IsActive"];
                empdesig.ActivatedDate = (DateTime)dt.Rows[0]["ActivatedDate"];
                //empdesig.CreatedBy = (int)dt.Rows[0]["CreatedBy"];
                //empdesig.CreatedDate = (DateTime)dt.Rows[0]["CreatedDate"];
                //empdesig.ModifiedBy = (int)dt.Rows[0]["ModifiedBy"];
                //empdesig.ModifiedDate = (DateTime)dt.Rows[0]["ModifiedDate"];
            }
            return empdesig;
        }
        //kartyek 9.2.2015 new added for loan request whether the Employee is resigned or not
        public int GetAdminReportingToIDEmployeeForResignation(int empID)
        {
            const String Qry = "select isnull([dbo].[GetAdminReportingMgr]({0}),0) ReportingMgrID ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, empID);
            int cnt = 0;
            int.TryParse(string.Concat(EE.ExecuteScalar(exQry)), out cnt);
            return cnt;
        }
        //kartyek 9.2.2015 new added for assign loan via employee

        public EmployeePersonalDetails GetEmployees(int ID)
        {
            const String Qry =  " Select ME.ID  " +
								" ,ME.EmpCode  " +
								" ,MC.Name EmployeeType   " +
								" ,ME.FirstName + ' ' + isnull(ME.LastName,'') CandidateName  " +
								" ,ME.DOB " +
								" ,ME.Gender " +
								" ,MS. MaritalStatus " +
								" ,ME. PermanentAddress " +
								" ,ME. CurrentAddress " +
								" ,ME. MobileNumber " +
								" ,ME. ResidenceNumber " +
								" ,ME. EmergencyContactNumber " +
								" ,ME. PersonalEmailID " +
								" ,ME. Photo " +
								" ,ME. IsActive " +
								" ,ME. CreatedBy " +
								" ,ME. CreatedDate " +
								" ,ME. ModifiedBy " +
								" ,ME. ModifiedDate " +
								" ,ME. IsDeleted " +
                            	" FROM Master_Employees ME   " +
								" INNER JOIN Master_EmployeeType MC ON MC.ID = ME.EmployeeTypeID " +
								" INNER JOIN Master_MaritalStatus MS ON  MS.ID=ME.MaritalStatusID" +
                                " WHERE ME.ID = '{0}' ; ";


            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, ID.ToString());

            DataTable dt = EE.ExecuteDataTable(exQry);

            EmployeePersonalDetails EmployeeDetails = new EmployeePersonalDetails();
            if (dt.Rows.Count > 0)
            {
                EmployeeDetails.ID = (int)dt.Rows[0]["ID"];
                EmployeeDetails.EmpCode = (string)dt.Rows[0]["EmpCode"];
                EmployeeDetails.EmployeeTypeID = (int)dt.Rows[0]["EmployeeType"];
                EmployeeDetails.FirstName = (string)dt.Rows[0]["CandidateName"];
                if (dt.Rows[0]["DOB"].ToString() != string.Empty)
                    EmployeeDetails.DOB=(DateTime)dt.Rows[0]["DOB"];
                EmployeeDetails.Gender = (string)dt.Rows[0]["Gender"];
                EmployeeDetails.MaritalStatusID = (int)dt.Rows[0]["MaritalStatus"];
                EmployeeDetails.PermanentAddress = (string)dt.Rows[0]["PermanentAddress"];
                EmployeeDetails.CurrentAddress = (string)dt.Rows[0]["CurrentAddress"];
                EmployeeDetails.MobileNumber = (string)dt.Rows[0]["MobileNumber"];
                //EmployeeDetails.ResidenceNumber = (string)dt.Rows[0]["ResidenceNumber"];

                
                //if (dt.Rows[0]["Photo"].ToString() != string.Empty)
                //    EmployeeDetails.Photo = (byte[])dt.Rows[0]["Photo"];
                if (dt.Rows[0]["EMailID"].ToString() != string.Empty)
                    EmployeeDetails.PersonalEmailID = (string)dt.Rows[0]["PersonalEmailID"];



                //EmployeeDetails.CreatedDate = (DateTime)dt.Rows[0]["CreatedDate"];
                //EmployeeDetails.CreatedBy = (int)dt.Rows[0]["CreatedBy"];
                //EmployeeDetails.ModifiedBy = (int)dt.Rows[0]["ModifiedBy"];
                //EmployeeDetails.ModifiedDate = (DateTime)dt.Rows[0]["ModifiedDate"];
                

                //if (dt.Rows[0]["DateOfRetairment"].ToString() != string.Empty)
                //    EmployeeDetails.DateOfRetairment = (DateTime)dt.Rows[0]["DateOfRetairment"];
                //EmployeeDetails.DateOfJoining = (DateTime)dt.Rows[0]["DateOfJoining"];
                //if (dt.Rows[0]["LeavingDate"].ToString() != string.Empty)
                //    EmployeeDetails.LeavingDate = (DateTime)dt.Rows[0]["LeavingDate"];
                //if (dt.Rows[0]["WeddingDay"].ToString() != string.Empty)
                //    EmployeeDetails.WeddingDay = (DateTime)dt.Rows[0]["WeddingDay"];
                //if (dt.Rows[0]["ConfirmationDate"].ToString() != string.Empty)
                //    EmployeeDetails.ConfirmationDate = (DateTime)dt.Rows[0]["ConfirmationDate"];
                //if (dt.Rows[0]["ConfirmationDueDate"].ToString() != string.Empty)
                //    EmployeeDetails.ConfirmationDueDate = (DateTime)dt.Rows[0]["ConfirmationDueDate"];
            }

            return EmployeeDetails;
        }
        //kartyek 9.2.2015 for designation active update
        public Boolean SetDesignationIsActiveFalse(int EmpID)
        {
            const String Qry = " UPDATE Assign_Emp_Designation SET IsActive=0 Where EmpID={0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmpID.ToString());
            Int32 i = EE.ExecuteNonQuery(exQry);
            return i > 0;
        }
        //archana 17.2.2015 for project active update
        public Boolean SetProjectIsActiveFalse(int EmpID)
        {
            const String Qry = " UPDATE Assign_Emp_Project SET IsActive=0 Where EmpID={0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmpID.ToString());
            Int32 i = EE.ExecuteNonQuery(exQry);
            return i > 0;
        }
        public string GetNextEmpCode(string prefx)
        {
            const string qry = "SELECT EmpCode from Master_Employees " +
                               "Where ID =(Select Max(ID) From Master_Employees ";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            if (prefx == "")
            {
                exQry.Query = String.Format(qry) + " WHERE EmpCode not like 'C%')";
            }
            else
            {
                exQry.Query = String.Format(qry) + " WHERE EmpCode like 'C%')";
            }
            string nxtno = string.Concat(EE.ExecuteScalar(exQry), string.Empty);
            if (nxtno != string.Empty)
            {
                if (prefx == string.Empty)
                {
                    Int32 intNxtNo = 0;
                    Int32.TryParse(nxtno, out intNxtNo);
                    nxtno = (intNxtNo + 1).ToString();
                    string retValue = nxtno;
                    for (int i = 0; i < 3 - nxtno.Length; i++)
                    {
                        retValue = retValue.Insert(0, "0");
                    }
                    return retValue;
                }
                else
                {
                    string nxtno1 = nxtno.Substring(1);
                    Int32 intNxtNo = 0;
                    Int32.TryParse(nxtno1, out intNxtNo);
                    nxtno1 = (intNxtNo + 1).ToString();
                    string retValue = nxtno1;
                    for (int i = 0; i < 3 - nxtno1.Length; i++)
                    {
                        retValue = retValue.Insert(0, "0");
                    }
                    return "C" + retValue;
                }
            }
            if (prefx != string.Empty)
            {
                return "C001";
            }
            return "001";
        }

        public ComboBoxValues[] GetManagerCombo()
        {
            String Query = "SELECT DISTINCT ME.ID,FirstName,LastName,EmpCode,isnull(MiddleName,'') MiddleName FROM Master_Employees ME "
                        + " Inner Join Employee_OccupationDetails EO on EO.EmployeeID =ME.ID "
                        + " Where ME.IsActive = 1 and ME.IsDeleted=0 and EO.IsActive = 1 and EO.TypeOfExitID = 0 order by EmpCode asc";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = Query;

            DataTable dt = EE.ExecuteDataTable(exQry);
            ComboBoxValues[] DTO = new ComboBoxValues[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new ComboBoxValues();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].Value = (String)dt.Rows[i]["EmpCode"] + " - " + (String)dt.Rows[i]["FirstName"] + " " + (String)dt.Rows[i]["MiddleName"] + " " + (String)dt.Rows[i]["LastName"];
            }
            return DTO;
        }
        public bool IsEmployeeCodeExists(String EmployeeCode)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM master_employees WHERE EmpCode = '{0}' )"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmployeeCode);
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }

        //public bool IsEmployeeNameExists(String FirstName,String LastName,String EmailID, int EmployeeID)
        //{
        //    const String Qry = " IF EXISTS (SELECT ID FROM master_employees WHERE FirstName = '{0}' And LastName='{1}' AND PersonalEmailID='{2}'  AND ID <> {3})"
        //                        + " SELECT 0"
        //                        + " ELSE"
        //                        + " SELECT 1";

        //    ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
        //    ExecutionQuery exQry = new ExecutionQuery();
        //    exQry.Query = string.Format(Qry, FirstName, LastName, EmailID, EmployeeID);
        //    return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        //}

        public EmployeeLeaveExtened GetManagerNotificationDetails(int LeaveRequestID)
        {
            String Query = "SELECT DISTINCT "
                              + " EmpID"
                              + " ,ManagerID"
                              + " FROM "
                              + " Leave_Request LR"
                              + " 	WHERE ID={0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = String.Format(Query, LeaveRequestID.ToString());
            DataTable dt = EE.ExecuteDataTable(exQry);

            EmployeeLeaveExtened DTO = new EmployeeLeaveExtened();

            if (dt.Rows.Count > 0)
            {
                DTO.EmpID = (int)dt.Rows[0]["EmpID"];
                DTO.ManagerID = (int)dt.Rows[0]["ManagerID"];
            }

            return DTO;
        }

        public BaseMaster_EmployeeExtened GetEmployeeNotificationDetails(int EmployeeID)
        {
            String Query = "   SELECT  DISTINCT "
                              + " 	LR.EmpID ,LR.ManagerID "
                              + " 	,(ME.FirstName+ ' '+ME.MiddleName+' '+ME.LastName)EmployeeName  "
                              + " 	,EO.EmployeeID  ,EO.ExitDate  ,EmpCode  ,EO.EmailID ,TeamName,Designation "
                              + " 	,'ExitType'=CASE WHEN (TypeOfExitID=1)THEN 'Resigned' ELSE 'Terminated' END  "
                              + " FROM Leave_Request LR"
                              + " INNER JOIN "
                              + " 	Employee_OccupationDetails EO"
                              + " ON"
                              + " 	EO.EmployeeID=LR.EmpID"
                              + " INNER JOIN"
                              + " 	Master_Employees ME"
                              + " ON"
                              + " 	ME.ID=LR.EmpID"
                              + " 	INNER JOIN"
                              + " 	Master_Team MT"
                              + " 	ON"
                              + " 	MT.ID=EO.TeamID"
                              + " 	INNER JOIN "
                              + " 	Hr_Designation HD"
                              + " 	ON"
                              + " 	HD.ID=EO.DesignationID"
                              + " WHERE LR.EmpID={0} AND EO.IsActive=1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = String.Format(Query, EmployeeID.ToString());
            DataTable dt = EE.ExecuteDataTable(exQry);

            BaseMaster_EmployeeExtened DTO = new BaseMaster_EmployeeExtened();

            if (dt.Rows.Count > 0)
            {
                DTO.ManagerName = (string)dt.Rows[0]["EmployeeName"];
                DTO.EmpCode = (string)dt.Rows[0]["EmpCode"];
                DTO.EmailID = (string)dt.Rows[0]["EmailID"];
                DTO.TeamName = (String)dt.Rows[0]["TeamName"];
                DTO.Designation = (String)dt.Rows[0]["Designation"];
                DTO.EmpID = (int)dt.Rows[0]["ManagerID"];
            }

            return DTO;
        }

        public EmployeeExitManagementExtened GetEmployeeDetails(int EmployeeID)
        {
            String Query = " SELECT DISTINCT  "
                              + "  (FirstName+ ' '+MiddleName+ ' '+LastName)EmployeeName  "
                              + "  ,ExitDate  "
                              + "  ,EmailID  "
                              + "  ,EmployeeID  "
                              + "  ,ManagerID"
                              + "  ,'ExitType' = CASE WHEN(TypeOfExitID=1)THEN 'Resignation' "
                              + "  WHEN (TypeOfExitID=2)THEN 'Termination' ELSE '' END "
                              + "  FROM   "
                              + "  Employee_OccupationDetails EO   "
                              + "  INNER JOIN   "
                              + "  Master_Employees ME  "
                              + "  ON  "
                              + "  ME.ID=EO.EmployeeID "
                              + "  INNER JOIN"
                              + "  Master_Team MT"
                              + "  ON"
                              + "  MT.ID= EO.TeamID "
                              + "  WHERE  EmployeeID = {0} "
                              + "  AND EO.TypeOfExitID!=0 "
                              + "  AND ME.IsActive=1 "
                              + "  AND EO.IsActive=1 "
                              + "  AND ME.IsDeleted!=1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = String.Format(Query, EmployeeID.ToString());
            DataTable dt = EE.ExecuteDataTable(exQry);

            EmployeeExitManagementExtened DTO = new EmployeeExitManagementExtened();

            if (dt.Rows.Count > 0)
            {
                DTO.EmployeeName = (string)dt.Rows[0]["EmployeeName"];
                DTO.EmployeeEmailID = (string)dt.Rows[0]["EmailID"];
                DTO.ExitDate = (DateTime)dt.Rows[0]["ExitDate"];
                DTO.ManagerID = (int)dt.Rows[0]["ManagerID"];
                DTO.ExitType = (String)dt.Rows[0]["ExitType"];
            }
            return DTO;
        }

        public EmployeeExitManagementExtened[] GetAllEmployee(string strExitdate)
        {
            const String Qry = " SELECT DISTINCT"
                              + "  (FirstName+ ' '+MiddleName+ ' '+LastName)EmployeeName"
                              + "  ,ExitDate"
                              + "  ,EmailID"
                              + "  ,EmployeeID"
                               + "  ,'ExitType' = CASE WHEN(TypeOfExitID=1)THEN 'Resignation' "
                              + "  WHEN (TypeOfExitID=2)THEN 'Termination' ELSE '' END "
                              + "  FROM "
                              + "  Employee_OccupationDetails EO"
                              + "  INNER JOIN"
                              + "  Master_Employees ME"
                              + "  ON"
                              + "  ME.ID=EO.EmployeeID"
                              + "  WHERE  EO.TypeOfExitID!=0 "
                              + "  AND EO.IsActive=1 "
                              + "  AND ME.IsActive=1 "
                              + "  AND ME.IsDeleted!=1"
                              + "  AND ExitDate='{0}'";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, strExitdate);
            DataTable dt = EE.ExecuteDataTable(exQry);
            EmployeeExitManagementExtened[] DTO = new EmployeeExitManagementExtened[dt.Rows.Count];
            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new EmployeeExitManagementExtened();
                DTO[i].EmployeeID = (int)dt.Rows[i]["EmployeeID"];
                DTO[i].EmployeeName = (String)dt.Rows[i]["EmployeeName"];
                DTO[i].EmployeeEmailID = (String)dt.Rows[i]["EmailID"];
                DTO[i].ExitDate = (DateTime)dt.Rows[i]["ExitDate"];
                DTO[i].ExitType = (string)dt.Rows[i]["ExitType"];
            }
            return DTO;
        }
        public int GetAttendanceID(int empID, DateTime DtAttd)
        {
            int id = 0;
            const String Qry = " SELECT ID FROM Employee_Uploaded_Attandance WHERE EmployeeID = '{0}' AND LeaveDate='{1}'";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, empID, DtAttd.ToString("yyyy-MM-dd"));
            int.TryParse(string.Concat(EE.ExecuteScalar(exQry)), out id);
            return id;

        }
        public Master_Employees GetEmployeeDetByCode(String EmpCode)
        {
            const String Qry = " SELECT * FROM Master_Employees WHERE EmpCode = '{0}'";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmpCode);
            DataTable dt = EE.ExecuteDataTable(exQry);
            Master_Employees DTO = new Master_Employees();

            if (dt.Rows.Count > 0)
            {
                DTO.ID = (int)dt.Rows[0]["ID"];
                DTO.EmpCode = (String)dt.Rows[0]["EmpCode"];
                DTO.EmployeeTypeID = (int)dt.Rows[0]["EmployeeTypeID"];
                DTO.FirstName = (String)dt.Rows[0]["FirstName"];
                DTO.LastName = (String)dt.Rows[0]["LastName"];
                DTO.MiddleName = (String)dt.Rows[0]["MiddleName"];
                DTO.DOB = (DateTime)dt.Rows[0]["DOB"];
                DTO.Gender = (String)dt.Rows[0]["Gender"];
                DTO.MaritalStatusID = (int)dt.Rows[0]["MaritalStatusID"];
                DTO.PermanentAddress = (String)dt.Rows[0]["PermanentAddress"];
                DTO.CurrentAddress = (String)dt.Rows[0]["CurrentAddress"];
                DTO.MobileNumber = (String)dt.Rows[0]["MobileNumber"];
                DTO.ResidenceNumber = (String)dt.Rows[0]["ResidenceNumber"];
                DTO.EmergencyContactNumber = (String)dt.Rows[0]["EmergencyContactNumber"];
                DTO.PersonalEmailID = (String)dt.Rows[0]["PersonalEmailID"];
                DTO.Photo = (Byte[])dt.Rows[0]["Photo"];
                DTO.IsActive = (bool)dt.Rows[0]["IsActive"];
                DTO.CreatedBy = (int)dt.Rows[0]["CreatedBy"];
                DTO.CreatedDate = (DateTime)dt.Rows[0]["CreatedDate"];
                DTO.ModifiedBy = (int)dt.Rows[0]["ModifiedBy"];
                DTO.ModifiedDate = (DateTime)dt.Rows[0]["ModifiedDate"];
                DTO.IsDeleted = (bool)dt.Rows[0]["IsDeleted"];

                return DTO;
            }
            else
                return null;
        }

        public DataTable GetEmployeeDetailsEmpCode(string EmpCode)
        {
            const String Qry = " SELECT * FROM Master_Employees ME WHERE ME.EmpCode = '{0}' AND ME.IsActive=1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmpCode);
            return EE.ExecuteDataTable(exQry);
        }

        public byte[] GetEmployeeImageByEmpCode(string EmpCode)
        {
            const String Qry = " SELECT CASE WHEN DATALENGTH(Photo) = 3000000 THEN NULL ELSE Photo END Photo FROM Master_Employees ME WHERE ME.EmpCode = '{0}' AND ME.IsActive=1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmpCode);

            DataTable dtTable = EE.ExecuteDataTable(exQry);

            if (dtTable.Rows.Count > 0)
            {
                if (Convert.ToString(dtTable.Rows[0]["Photo"]) != "")
                {
                    return (byte[])dtTable.Rows[0]["Photo"];
                }
                else
                {
                    return null;
                }
            }
            return null;
        }


    }
}
