using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;
using HRManager.Entity;

namespace HRManager.BusinessObjects
{
  public partial  class Master_CandidateBusinessObject
  {

      #region CANDIDATE PERSONAL INFO(CANDIDATE_MASTER)
  
      /// <summary>
        /// Get Candidate By Candidate Name
        /// </summary>
        /// <param name="CandidateName">field contaions Candidate Name</param>
        /// <returns>data related given Candidate Name in case of success otherwise it return null</returns>
      public Master_Candidate GetCandidateByCandidate(String FirstName, String LastName)
        {
            Master_Candidate[] Candidates = GetCandidates(" FirstName = '" + FirstName + "' And LastName = '" + LastName + "'");

            if (Candidates != null && Candidates.Length > 0)
            {
                return Candidates[0];
            }
            else
            {
                return null;
            }
        }

      /// <summary>
      /// Get Candidate By Candidate Name
      /// </summary>
      /// <param name="CandidateName">field contaions Candidate Name</param>
      /// <returns>data related given Candidate Name in case of success otherwise it return null</returns>
      public Master_Candidate[] GetCandidateByCandidate(int CandidateID)
      {
          return GetCandidates("ID = " + CandidateID.ToString());

        
      }
      public CandidatePersonalInfo[] GetCandidateDetailsByCandidate(int CandidateID)
      {
          return GetCandidateDetails("mc.ID = " + CandidateID.ToString());


      }

      /// <summary>
      /// Get Candidate data from the database
      /// </summary>
      /// <param name="Filter">Refine the query as per requirment</param>
      /// <returns>Array of Master_Candidate object</returns>
      public Master_Candidate[] GetCandidates(String Filter)
      {
          const String Qry = " SELECT *,isnull(lastname,'') as LastNames FROM Master_Candidate Where IsActive=1";

          ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
          ExecutionQuery exQry = new ExecutionQuery();

          if (Filter == String.Empty)
          {
              exQry.Query = string.Format(Qry);
          }
          else
          {
              exQry.Query = string.Format(Qry) + " And " + Filter;
          }

          DataTable dt = EE.ExecuteDataTable(exQry);

          Master_Candidate[] CandidateDetails = new Master_Candidate[dt.Rows.Count];

          for (int i = 0; i < CandidateDetails.Length; i++)
          {
              CandidateDetails[i] = new Master_Candidate();
              CandidateDetails[i].ID = (int)dt.Rows[i]["ID"];
              CandidateDetails[i].FirstName = (String)dt.Rows[i]["FirstName"];
              CandidateDetails[i].LastName = (String)dt.Rows[i]["LastNames"];
              CandidateDetails[i].Sex = (String)dt.Rows[i]["Sex"];
              CandidateDetails[i].MaritialStatus = (String)dt.Rows[i]["MaritialStatus"];
              CandidateDetails[i].Per_Addess = (String)dt.Rows[i]["Per_Addess"];
              CandidateDetails[i].Per_City = (String)dt.Rows[i]["Per_City"];
              CandidateDetails[i].Per_MobileNumber = (String)dt.Rows[i]["Per_MobileNumber"];
              CandidateDetails[i].Per_PhoneNo = (String)dt.Rows[i]["Per_PhoneNo"];
              CandidateDetails[i].Per_StateID = (int)dt.Rows[i]["Per_StateID"];
              CandidateDetails[i].Per_Street = (String)dt.Rows[i]["Per_Street"];
              CandidateDetails[i].Per_ZipCode = (String)dt.Rows[i]["Per_ZipCode"];
              CandidateDetails[i].Temp_Addess = (String)dt.Rows[i]["Temp_Addess"];
              CandidateDetails[i].Temp_City = (String)dt.Rows[i]["Temp_City"];
              CandidateDetails[i].Temp_MobileNumber = (String)dt.Rows[i]["Temp_MobileNumber"];
              CandidateDetails[i].Temp_StateID = (int)dt.Rows[i]["Temp_StateID"];
              CandidateDetails[i].Temp_Street = (String)dt.Rows[i]["Temp_Street"];
              CandidateDetails[i].Temp_ZipCode = (String)dt.Rows[i]["Temp_ZipCode"];
              CandidateDetails[i].TelephoneNoOff = (String)dt.Rows[i]["TelephoneNoOff"];
              CandidateDetails[i].TelephoneNoRes = (String)dt.Rows[i]["TelephoneNoRes"];
              CandidateDetails[i].DOB = (DateTime)dt.Rows[i]["DOB"];
              CandidateDetails[i].PhysicalDisability = (String)dt.Rows[i]["PhysicalDisability"];
              CandidateDetails[i].EMailID = (String)dt.Rows[i]["EMailID"];
              CandidateDetails[i].IsPhysicalDisability = (bool)dt.Rows[i]["IsPhysicalDisability"];
              CandidateDetails[i].Degree = (String)dt.Rows[i]["Degree"];
          }

          return CandidateDetails;
      }
      /// <summary>
      /// Get Candidate data from the database
      /// </summary>
      /// <param name="Filter">Refine the query as per requirment</param>
      /// <returns>Array of Master_Candidate object</returns>
      public CandidatePersonalInfo[] GetCandidateDetails(String Filter)
      {
          const String Qry = " SELECT *,cs.statename as Lpstate,cse.statename as Ltstate, "+
                             " cc.country as Lpcountry,cce.country as Ltcountry " +
                             " FROM Master_Candidate mc " +
                             " inner Join common_state cs on (mc.Per_StateID=cs.id) "+
                             " inner Join common_state cse on (mc.Temp_StateID=cse.id) "+
                             " inner Join common_country cc on (cs.countryid=cc.id) "+
                             " inner Join common_country cce on (cse.countryid=cce.id) "+
                             " Where mc.IsActive=1 ";

          ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
          ExecutionQuery exQry = new ExecutionQuery();

          exQry.Query = string.Format(Qry);

          if (Filter == String.Empty)
          {
              exQry.Query = string.Format(Qry);
          }
          else
          {
              exQry.Query = string.Format(Qry) + " And " + Filter;
          }

          DataTable dt = EE.ExecuteDataTable(exQry);

          CandidatePersonalInfo[] CandidateDetails = new CandidatePersonalInfo[dt.Rows.Count];

          for (int i = 0; i < CandidateDetails.Length; i++)
          {
              CandidateDetails[i] = new CandidatePersonalInfo();
              if (dt.Rows[i]["ID"].ToString() != string.Empty)
                  CandidateDetails[i].ID = (int)dt.Rows[i]["ID"];
              if (dt.Rows[i]["FirstName"].ToString() != string.Empty)
                  CandidateDetails[i].FirstName = (String)dt.Rows[i]["FirstName"];
              if (dt.Rows[i]["LastName"].ToString() != string.Empty)
                  CandidateDetails[i].LastName = (String)dt.Rows[i]["LastName"];
              if (dt.Rows[i]["FatherName"].ToString() != string.Empty)
                  CandidateDetails[i].FatherName = (String)dt.Rows[i]["FatherName"];
              if (dt.Rows[i]["Sex"].ToString() != string.Empty)
                  CandidateDetails[i].Sex = (String)dt.Rows[i]["Sex"];
              if (dt.Rows[i]["MaritialStatus"].ToString() != string.Empty)
                  CandidateDetails[i].MaritialStatus = (String)dt.Rows[i]["MaritialStatus"];
              if (dt.Rows[i]["Per_Addess"].ToString() != string.Empty)
                  CandidateDetails[i].PAddess = (String)dt.Rows[i]["Per_Addess"];
              if (dt.Rows[i]["Per_City"].ToString() != string.Empty)
                  CandidateDetails[i].PCity = (String)dt.Rows[i]["Per_City"];
              if (dt.Rows[i]["Per_MobileNumber"].ToString() != string.Empty)
                  CandidateDetails[i].PMobileNumber = (String)dt.Rows[i]["Per_MobileNumber"];
              if (dt.Rows[i]["Per_PhoneNo"].ToString() != string.Empty)
                  CandidateDetails[i].PPhoneNo = (String)dt.Rows[i]["Per_PhoneNo"];
              if (dt.Rows[i]["Per_StateID"].ToString() != string.Empty)
                  CandidateDetails[i].PStateID = (int)dt.Rows[i]["Per_StateID"];
              if (dt.Rows[i]["Per_Street"].ToString() != string.Empty)
                  CandidateDetails[i].PStreet = (String)dt.Rows[i]["Per_Street"];
              if (dt.Rows[i]["Per_ZipCode"].ToString() != string.Empty)
                  CandidateDetails[i].PZipCode = (String)dt.Rows[i]["Per_ZipCode"];
              if (dt.Rows[i]["Temp_Addess"].ToString() != string.Empty)
                  CandidateDetails[i].TAddess = (String)dt.Rows[i]["Temp_Addess"];
              if (dt.Rows[i]["Temp_City"].ToString() != string.Empty)
                  CandidateDetails[i].TCity = (String)dt.Rows[i]["Temp_City"];
              if (dt.Rows[i]["Temp_MobileNumber"].ToString() != string.Empty)
                  CandidateDetails[i].TMobileNumber = (String)dt.Rows[i]["Temp_MobileNumber"];
              if (dt.Rows[i]["Temp_StateID"].ToString() != string.Empty)
                  CandidateDetails[i].TStateID = (int)dt.Rows[i]["Temp_StateID"];
              if (dt.Rows[i]["Temp_Street"].ToString() != string.Empty)
                  CandidateDetails[i].TStreet = (String)dt.Rows[i]["Temp_Street"];
              if (dt.Rows[i]["Temp_ZipCode"].ToString() != string.Empty)
                  CandidateDetails[i].TZipCode = (String)dt.Rows[i]["Temp_ZipCode"];
              if (dt.Rows[i]["TelephoneNoOff"].ToString() != string.Empty)
                  CandidateDetails[i].TelephoneNoOff = (String)dt.Rows[i]["TelephoneNoOff"];
              if (dt.Rows[i]["TelephoneNoRes"].ToString() != string.Empty)
                  CandidateDetails[i].TelephoneNoRes = (String)dt.Rows[i]["TelephoneNoRes"];
              if (dt.Rows[i]["DOB"].ToString() != string.Empty)
                  CandidateDetails[i].DOB = (DateTime)dt.Rows[i]["DOB"];
              if (dt.Rows[i]["PhysicalDisability"].ToString() != string.Empty)
                  CandidateDetails[i].PhysicalDisability = (String)dt.Rows[i]["PhysicalDisability"];
              if (dt.Rows[i]["EMailID"].ToString() != string.Empty)
                  CandidateDetails[i].EMailID = (String)dt.Rows[i]["EMailID"];
              if (dt.Rows[i]["IsPhysicalDisability"].ToString() != string.Empty)
                  CandidateDetails[i].IsPhysicalDisability = (bool)dt.Rows[i]["IsPhysicalDisability"];
              if (dt.Rows[i]["IsFresher"].ToString() != string.Empty)
                  CandidateDetails[i].IsFresher = (bool)dt.Rows[i]["IsFresher"];

              if (dt.Rows[i]["IsTechnical"].ToString() != string.Empty)
                  CandidateDetails[i].IsTechnical = (bool)dt.Rows[i]["IsTechnical"];
              if (dt.Rows[i]["Graduate"].ToString() != string.Empty)
                  CandidateDetails[i].Graduate = (String)dt.Rows[i]["Graduate"];
              if (dt.Rows[i]["Degree"].ToString() != string.Empty)
                  CandidateDetails[i].Degree = (String)dt.Rows[i]["Degree"];


              if (dt.Rows[i]["Lpcountry"].ToString() != string.Empty)
                  CandidateDetails[i].Lpcountry = (String)dt.Rows[i]["Lpcountry"];
              if (dt.Rows[i]["Lpstate"].ToString() != string.Empty)
                  CandidateDetails[i].Lpstate = (String)dt.Rows[i]["Lpstate"];
              if (dt.Rows[i]["Ltcountry"].ToString() != string.Empty)
                  CandidateDetails[i].Ltcountry = (String)dt.Rows[i]["Ltcountry"];
              if (dt.Rows[i]["Ltstate"].ToString() != string.Empty)
                  CandidateDetails[i].Ltstate = (String)dt.Rows[i]["Ltstate"];
          }

          return CandidateDetails;
      }
      /// <summary>
      /// Get Candidate By Candidate Name
      /// </summary>
      /// <param name="CandidateName">field contaions Candidate Name</param>
      /// <returns>data related given Candidate Name in case of success otherwise it return null</returns>
      public Master_Candidate[] GetAllApproveCandidates()
      {
          return GetCandidates(" status="+HRAppCommands.APPROVE_CANDIDATE);


      }
      public Master_Candidate[] GetAllNonApproveCandidates()
      {
          return GetApproveCandidates(" status <> '" + HRAppCommands.APPROVE_CANDIDATE + "'");


      }
      /// <summary>
      /// Get Candidate data from the database
      /// </summary>
      /// <param name="Filter">Refine the query as per requirment</param>
      /// <returns>Array of Master_Candidate object</returns>
      public Master_Candidate[] GetApproveCandidates(String Filter)
      {
          const String Qry = " SELECT * FROM Master_Candidate M Inner Join Candidate_JobDetails C ON C.CandidateID=M.ID Where IsActive=1";

          ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
          ExecutionQuery exQry = new ExecutionQuery();

          if (Filter == String.Empty)
          {
              exQry.Query = string.Format(Qry);
          }
          else
          {
              exQry.Query = string.Format(Qry) + " And " + Filter;
          }

          DataTable dt = EE.ExecuteDataTable(exQry);

          Master_Candidate[] CandidateDetails = new Master_Candidate[dt.Rows.Count];

          for (int i = 0; i < CandidateDetails.Length; i++)
          {
              CandidateDetails[i] = new Master_Candidate();
              CandidateDetails[i].ID = (int)dt.Rows[i]["ID"];
              CandidateDetails[i].FirstName = (String)dt.Rows[i]["FirstName"];
              CandidateDetails[i].LastName = (String)dt.Rows[i]["LastName"];
              CandidateDetails[i].Sex = (String)dt.Rows[i]["Sex"];
              CandidateDetails[i].MaritialStatus = (String)dt.Rows[i]["MaritialStatus"];
              CandidateDetails[i].Per_Addess = (String)dt.Rows[i]["Per_Addess"];
              CandidateDetails[i].Per_City = (String)dt.Rows[i]["Per_City"];
              CandidateDetails[i].Per_MobileNumber = (String)dt.Rows[i]["Per_MobileNumber"];
              CandidateDetails[i].Per_PhoneNo = (String)dt.Rows[i]["Per_PhoneNo"];
              CandidateDetails[i].Per_StateID = (int)dt.Rows[i]["Per_StateID"];
              CandidateDetails[i].Per_Street = (String)dt.Rows[i]["Per_Street"];
              CandidateDetails[i].Per_ZipCode = (String)dt.Rows[i]["Per_ZipCode"];
              CandidateDetails[i].Temp_Addess = (String)dt.Rows[i]["Temp_Addess"];
              CandidateDetails[i].Temp_City = (String)dt.Rows[i]["Temp_City"];
              CandidateDetails[i].Temp_MobileNumber = (String)dt.Rows[i]["Temp_MobileNumber"];
              CandidateDetails[i].Temp_StateID = (int)dt.Rows[i]["Temp_StateID"];
              CandidateDetails[i].Temp_Street = (String)dt.Rows[i]["Temp_Street"];
              CandidateDetails[i].Temp_ZipCode = (String)dt.Rows[i]["Temp_ZipCode"];
              CandidateDetails[i].TelephoneNoOff = (String)dt.Rows[i]["TelephoneNoOff"];
              CandidateDetails[i].TelephoneNoRes = (String)dt.Rows[i]["TelephoneNoRes"];
              CandidateDetails[i].DOB = (DateTime)dt.Rows[i]["DOB"];
              CandidateDetails[i].PhysicalDisability = (String)dt.Rows[i]["PhysicalDisability"];
              CandidateDetails[i].EMailID = (String)dt.Rows[i]["EMailID"];
              CandidateDetails[i].IsPhysicalDisability = (bool)dt.Rows[i]["IsPhysicalDisability"];
              CandidateDetails[i].IsFresher = (bool)dt.Rows[i]["IsFresher"];
          }

          return CandidateDetails;
      }

      /// <summary>
      /// Get Candidate data from the database
      /// </summary>
      /// <param name="Filter">Refine the query as per requirment</param>
      /// <returns>Array of Master_Candidate object</returns>
      public Master_Candidate[] GetJobProfileApproverCandidates()
      {
          const String Qry = " exec usp_GetJobProfileApprover ";

          ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
          ExecutionQuery exQry = new ExecutionQuery();
          
          exQry.Query = string.Format(Qry);
          DataTable dt = EE.ExecuteDataTable(exQry);

          Master_Candidate[] CandidateDetails = new Master_Candidate[dt.Rows.Count];

          for (int i = 0; i < CandidateDetails.Length; i++)
          {
              CandidateDetails[i] = new Master_Candidate();
              CandidateDetails[i].ID = (int)dt.Rows[i]["ID"];
              CandidateDetails[i].FirstName = (String)dt.Rows[i]["FirstName"];
              CandidateDetails[i].LastName = (String)dt.Rows[i]["LastName"];              
              CandidateDetails[i].EMailID = (String)dt.Rows[i]["EMailID"];              
          }

          return CandidateDetails;
      }

      public Master_Candidate[] GetCandidateApplicationApprover()
      {
          const String Qry = " exec usp_GetCandidateApplicationApprover ";

          ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
          ExecutionQuery exQry = new ExecutionQuery();

          exQry.Query = string.Format(Qry);
          DataTable dt = EE.ExecuteDataTable(exQry);

          Master_Candidate[] CandidateDetails = new Master_Candidate[dt.Rows.Count];

          for (int i = 0; i < CandidateDetails.Length; i++)
          {
              CandidateDetails[i] = new Master_Candidate();
              CandidateDetails[i].ID = (int)dt.Rows[i]["ID"];
              CandidateDetails[i].FirstName = (String)dt.Rows[i]["FirstName"];
              CandidateDetails[i].LastName = (String)dt.Rows[i]["LastName"];
              CandidateDetails[i].EMailID = (String)dt.Rows[i]["EMailID"];
          }

          return CandidateDetails;
      }

      /// <summary>
      /// Get Candidate data from the database
      /// </summary>
      /// <param name="Filter">Refine the query as per requirment</param>
      /// <returns>Array of Master_Candidate object</returns>
      public CandidatePersonalInfo[] GetApproveCandidates()
      {
          const String Qry = " SELECT *,isnull(LocationName,'PAN INDIA') LocationNam FROM Master_Candidate M Inner Join Candidate_JobDetails C ON C.CandidateID=M.ID " +
                              " Inner Join master_jobprofile mjp on mjp.id=C.jobid " +
                              " left outer Join master_location ml on (ml.id=mjp.locationid) " +               
                              " Where M.IsActive=1 and C.CandidateID  not in (select CandidateID from Master_Employees) " +
                              " and C.CandidateID  not in ( " +
                              " select CandidateId from Candidate_InterviewSchedule CIS " +
                              " inner join  Candidate_JobDetails CJD on (CIS.CandidateJobDetailsID=CJD.ID) " +
                              " where CIS.Status='CRJ' )  order by C.CandidateID desc";

          ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
          ExecutionQuery exQry = new ExecutionQuery();

          exQry.Query = string.Format(Qry);
          DataTable dt = EE.ExecuteDataTable(exQry);

          CandidatePersonalInfo[] CandidateDetails = new CandidatePersonalInfo[dt.Rows.Count];

          for (int i = 0; i < CandidateDetails.Length; i++)
          {
              CandidateDetails[i] = new CandidatePersonalInfo();
              if (dt.Rows[i]["ID"].ToString() != string.Empty)
                  CandidateDetails[i].ID = (int)dt.Rows[i]["ID"];
              if (dt.Rows[i]["FirstName"].ToString() != string.Empty)
              CandidateDetails[i].FirstName = (String)dt.Rows[i]["FirstName"];
              if (dt.Rows[i]["LastName"].ToString() != string.Empty)
              CandidateDetails[i].LastName = (String)dt.Rows[i]["LastName"];
              CandidateDetails[i].Location = (String)dt.Rows[i]["LocationNam"];
              if (dt.Rows[i]["JobProfileName"].ToString() != string.Empty)
                  CandidateDetails[i].JobProfile = (String)dt.Rows[i]["JobProfileName"];
              
               if (dt.Rows[i]["EMailID"].ToString() != string.Empty)
              CandidateDetails[i].EMailID = (String)dt.Rows[i]["EMailID"];
               if (dt.Rows[i]["Status"].ToString() != string.Empty)
                 CandidateDetails[i].Status = (String)dt.Rows[i]["Status"];
               if (dt.Rows[i]["IsFresher"].ToString() != string.Empty)
                   CandidateDetails[i].IsFresher = (bool)dt.Rows[i]["IsFresher"];
          }

          return CandidateDetails;
      }
      public CandidatePersonalInfo[] GetApproveCandidatesForHigherApproval(String RequiredStatus)
      {
          const String Qry = " SELECT *,isnull(LocationName,'PAN INDIA') LocationNam FROM Master_Candidate M Inner Join Candidate_JobDetails C ON C.CandidateID=M.ID " +
                              " Inner Join master_jobprofile mjp on mjp.id=C.jobid " +
                              " left outer Join master_location ml on (ml.id=mjp.locationid) " +
                              " Where M.IsActive=1 and C.CandidateID  not in (select CandidateID from Master_Employees) " +
                              " and C.CandidateID  not in ( " +
                              " select CandidateId from Candidate_InterviewSchedule CIS " +
                              " inner join  Candidate_JobDetails CJD on (CIS.CandidateJobDetailsID=CJD.ID) " +
                              " where CIS.Status='CRJ' ) and C.Status='{0}' order by C.CandidateID desc";

          ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
          ExecutionQuery exQry = new ExecutionQuery();

          exQry.Query = string.Format(Qry, RequiredStatus+" Approval");
          DataTable dt = EE.ExecuteDataTable(exQry);

          CandidatePersonalInfo[] CandidateDetails = new CandidatePersonalInfo[dt.Rows.Count];

          for (int i = 0; i < CandidateDetails.Length; i++)
          {
              CandidateDetails[i] = new CandidatePersonalInfo();
              if (dt.Rows[i]["ID"].ToString() != string.Empty)
                  CandidateDetails[i].ID = (int)dt.Rows[i]["ID"];
              if (dt.Rows[i]["FirstName"].ToString() != string.Empty)
                  CandidateDetails[i].FirstName = (String)dt.Rows[i]["FirstName"];
              if (dt.Rows[i]["LastName"].ToString() != string.Empty)
                  CandidateDetails[i].LastName = (String)dt.Rows[i]["LastName"];
              CandidateDetails[i].Location = (String)dt.Rows[i]["LocationNam"];
              if (dt.Rows[i]["JobProfileName"].ToString() != string.Empty)
                  CandidateDetails[i].JobProfile = (String)dt.Rows[i]["JobProfileName"];

              if (dt.Rows[i]["EMailID"].ToString() != string.Empty)
                  CandidateDetails[i].EMailID = (String)dt.Rows[i]["EMailID"];
              if (dt.Rows[i]["Status"].ToString() != string.Empty)
                  CandidateDetails[i].Status = (String)dt.Rows[i]["Status"];
              if (dt.Rows[i]["IsFresher"].ToString() != string.Empty)
                  CandidateDetails[i].IsFresher = (bool)dt.Rows[i]["IsFresher"];
          }

          return CandidateDetails;
      }
     
      /// <summary>
      /// check Candidate Existance in the database.
      /// </summary>
      /// <param name="Candidate">field contains Candidate name</param>
      /// <param name="ID">field contains Candidate ID</param>
      /// <returns>True for Exist and false for not exist</returns>
      public bool IsCandidateeExists(String FirstName, String LastName, int ID,string emailID,DateTime DOB)
      {
          const String Qry = " IF EXISTS (SELECT ID FROM Master_Candidate WHERE FirstName = '{0}' And LastName ='{1}' and EmailID='{3}' And DOB='{4}' AND ID<>{2} And IsActive=1 )"
                              + " SELECT 0"
                              + " ELSE"
                              + " SELECT 1";

          ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
          ExecutionQuery exQry = new ExecutionQuery();
          exQry.Query = string.Format(Qry, FirstName, LastName, ID.ToString(), emailID, DOB.ToString("yyyy-MM-dd"));
          return string.Concat(EE.ExecuteScalar(exQry)) == "0";
      }      
      /// <summary>
      /// check Candidate Existance in the database.
      /// </summary>
      /// <param name="Candidate">field contains Candidate name</param>
      /// <param name="ID">field contains Candidate ID</param>
      /// <returns>True for Exist and false for not exist</returns>
      public bool IsCandidateeAbleToRejoin(String FirstName, String LastName, int ID, string emailID, DateTime DOB)
      {
          //const String Qry = " IF EXISTS (SELECT ID FROM Master_Candidate WHERE FirstName = '{0}' And LastName ='{1}' and EmailID='{3}' And DOB='{4}' AND ID<>{2} And IsActive=1 )"
                             
              
          //                    + " SELECT 0"
          //                    + " ELSE"
          //                    + " SELECT 1";


          const String Qry = " IF EXISTS (Select C.ID FROM Master_Candidate C " +
                           "  Inner Join Master_employees E On E.CandidateID=C.ID " +
                           "  left JOIN ( " +
                           "     SELECT EmpID,ResignationDate LeavingDate,ResignationStatus sStatus FROM RESIGNATION_REQUEST WHERE ResignationStatus='CLS' " +
                           "      UNION  " +
                           "      SELECT EmpID,TerminationDate LeavingDate,Status sStatus FROM TERMINATION_REQUEST WHERE Status='CLS' " +
                           "       UNION " +
                           "      SELECT ID,DateOfRetairment LeavingDate,LeavingStatus sStatus  FROM	master_employees WHERE LeavingStatus='RTR' " +
                           "     )R ON R.EmpID=E.ID  " +
                           "   WHERE FirstName = '{0}' And LastName ='{1}' and C.EmailID='{3}' " +
                           "    And DOB='{4}' AND C. ID<>{2} And IsActive=1 and R.sStatus  in('CLS','RTR')) "
                          + " SELECT 0"
                          + " ELSE"
                          + " SELECT 1";


          ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
          ExecutionQuery exQry = new ExecutionQuery();
          exQry.Query = string.Format(Qry, FirstName, LastName, ID.ToString(), emailID, DOB.ToString("yyyy-MM-dd"));
          return string.Concat(EE.ExecuteScalar(exQry)) == "0";
      }
     /// <summary>
        /// Get Designations data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_Skill object</returns>
        public Employees1[] GetUserEmployees()
        {
            const String Qry = " SELECT ME.ID,FirstName + LastName CandidateName,ME.EmailID,Designation,Role,LocationName, " +
                               " IsPermenant,IsResigned ,IsRetired , " +
                               " IsExtended ,IsProbationaryPeriod ,ProbationaryUpTo,'Status' = CASE WHEN Status = 'APP' THEN 'Approved' WHEN Status = 'REJ' THEN 'Rejected' ELSE 'Cancelled' END,CandidateID,DesignationID,RoleID,LocationID  " +
                               " FROM Master_Employee ME  " +
                               " inner join Master_Employee_Details MED on ME.ID = MED.EmployeeID " +
                               " inner join Master_Candidate MC on ME.CandidateID = MC.ID " +
                               " inner join Master_Location ML on MED.LocationID = ML.ID " +
                               " inner join Hr_Designation D on MED.DesignationID = D.ID " +
                               " inner join Master_Role MR on MED.RoleID = MR.ID " +
                               " Where ME.ID Not In (Select EmployeeID From Common_User) " +
                               " And  Status = 'APP' And  IsResigned=0 And IsRetired=0 And IsPermenant=1  Order by ME.ID ASC ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);

            DataTable dt = EE.ExecuteDataTable(exQry);

            Employee[] EmployeeDetails = new Employee[dt.Rows.Count];

            for (int i = 0; i < EmployeeDetails.Length; i++)
            {
                EmployeeDetails[i] = new Employee();
                EmployeeDetails[i].ID = (int)dt.Rows[i]["ID"];
                EmployeeDetails[i].CandidateID = (int)dt.Rows[i]["CandidateID"];
                EmployeeDetails[i].DesignationID = (int)dt.Rows[i]["DesignationID"];
                EmployeeDetails[i].RoleID = (int)dt.Rows[i]["RoleID"];
                EmployeeDetails[i].LocationID = (int)dt.Rows[i]["LocationID"];
                EmployeeDetails[i].EMailID = (string)dt.Rows[i]["EMailID"];
                EmployeeDetails[i].IsExtended = (bool)dt.Rows[i]["IsExtended"];
                EmployeeDetails[i].IsPermenant = (bool)dt.Rows[i]["IsPermenant"];
                EmployeeDetails[i].IsProbationaryPeriod = (bool)dt.Rows[i]["IsProbationaryPeriod"];
                EmployeeDetails[i].IsResigned = (bool)dt.Rows[i]["IsResigned"];
                EmployeeDetails[i].IsRetired = (bool)dt.Rows[i]["IsRetired"];
                EmployeeDetails[i].ProbationaryUpTo = (DateTime)dt.Rows[i]["ProbationaryUpTo"];
                EmployeeDetails[i].Status = (string)dt.Rows[i]["Status"];
                EmployeeDetails[i].CandidateName = (string)dt.Rows[i]["CandidateName"];
                EmployeeDetails[i].Designation = (string)dt.Rows[i]["Designation"];
                EmployeeDetails[i].Role = (string)dt.Rows[i]["Role"];
                EmployeeDetails[i].Location = (string)dt.Rows[i]["LocationName"];
            }

            return EmployeeDetails;
        }

        public string GetJobProfileApproverID(string EmployeeID)
        {
            const String Qry = " usp_GetJobProfileApproverID {0} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = String.Format(Qry, EmployeeID);
            object ret = EE.ExecuteScalar(exQry);
            return string.Concat(ret, string.Empty);
        }
        //public string GetCandidateSalaryApproverID(string EmployeeID)
        //{
        //    const String Qry = " usp_GetCandidateSalaryApproverID {0} ";

        //    ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
        //    ExecutionQuery exQry = new ExecutionQuery();
        //    exQry.Query = String.Format(Qry, EmployeeID);
        //    object ret = EE.ExecuteScalar(exQry);
        //    return string.Concat(ret, string.Empty);
        //}
        public string GetRefCheckerID(string EmployeeID)
        {
            const String Qry = " usp_GetRefCheckerID {0} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = String.Format(Qry, EmployeeID);
            object ret = EE.ExecuteScalar(exQry);
            return string.Concat(ret, string.Empty);
        }
      

      #endregion

      #region CANDIDATE EDUCATIONAL

      /// <summary>
      /// Get Candidate By Candidate Education
      /// </summary>
      /// <param name="CandidateName">field contaions Candidate Education</param>
      /// <returns>data related given Candidate Education in case of success otherwise it return null</returns>
      public Candidate_Education GetEducationByCandidate(int CandidateID)
      {
          Candidate_Education[] CandidatesEd = CandidatesEducation(" CandidateID = " + CandidateID);

          if (CandidatesEd != null && CandidatesEd.Length > 0)
          {
              return CandidatesEd[0];
          }
          else
          {
              return null;
          }
      }

      /// <summary>
      /// Get Candidate Education data from the database
      /// </summary>
      /// <param name="Filter">Refine the query as per requirment</param>
      /// <returns>Array of Candidate_Education object</returns>
      public Candidate_Education[] CandidatesEducation(String Filter)
      {
          const String Qry = " SELECT * FROM Candidate_Education E Inner Join Master_Candidate C " +
                             " ON C.CandidateID=E.ID Where IsActive=1";

          ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
          ExecutionQuery exQry = new ExecutionQuery();

          if (Filter == String.Empty)
          {
              exQry.Query = string.Format(Qry);
          }
          else
          {
              exQry.Query = string.Format(Qry) + " And " + Filter;
          }

          DataTable dt = EE.ExecuteDataTable(exQry);

          Candidate_Education[] CandidateEduDetails = new Candidate_Education[dt.Rows.Count];

          for (int i = 0; i < CandidateEduDetails.Length; i++)
          {
              CandidateEduDetails[i] = new Candidate_Education();
              CandidateEduDetails[i].ID = (int)dt.Rows[i]["ID"];
              CandidateEduDetails[i].CandidateID = (int)dt.Rows[i]["CandidateID"];

              CandidateEduDetails[i].Title = (String)dt.Rows[i]["Title"];
              CandidateEduDetails[i].Subject = (String)dt.Rows[i]["Subject"];
              CandidateEduDetails[i].Institute = (String)dt.Rows[i]["Institute"];
              CandidateEduDetails[i].Percentage = (float)dt.Rows[i]["Percentage"];
              CandidateEduDetails[i].Grade = (String)dt.Rows[i]["Grade"];
              CandidateEduDetails[i].FromDate = (DateTime)dt.Rows[i]["FromDate"];
              CandidateEduDetails[i].ToDate = (DateTime)dt.Rows[i]["ToDate"];
             
          }
          return CandidateEduDetails;
      }

      /// <summary>
      /// check Candidate Education Existance in the database.
      /// </summary>
      /// <param name="Candidate">field contains Candidate Education</param>
      /// <param name="ID">field contains Candidate Education ID</param>
      /// <returns>True for Exist and false for not exist</returns>
      public bool IsCandEducationExists(String FirstName, int CandidateID, int ID)
      {
          const String Qry = " IF EXISTS (SELECT ID FROM Candidate_Education WHERE Subject = '{0}' And CandidateID ={1} AND ID<>{2})"
                              + " SELECT 0"
                              + " ELSE"
                              + " SELECT 1";

          ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
          ExecutionQuery exQry = new ExecutionQuery();
          exQry.Query = string.Format(Qry, FirstName, CandidateID.ToString(), ID.ToString());
          return string.Concat(EE.ExecuteScalar(exQry)) == "0";
      }

      #endregion

      #region CANDIDATE PREVIOUS EMPLOYER

      /// <summary>
      /// Get Candidate By Candidate Education
      /// </summary>
      /// <param name="CandidateName">field contaions Candidate Education</param>
      /// <returns>data related given Candidate Education in case of success otherwise it return null</returns>
      public Candidate_Prev_Employer GetPrevEmpByCandidate(string EmployerName,int CandidateID)
      {                                                    
          Candidate_Prev_Employer[] CandidatesPrev = CandidatesPrevEmpl(" EmployerName='" + EmployerName + "' And CandidateID = " + CandidateID);

          if (CandidatesPrev != null && CandidatesPrev.Length > 0)
          {
              return CandidatesPrev[0];
          }
          else
          {
              return null;
          }
      }

      /// <summary>
      /// Get Candidate Education data from the database
      /// </summary>
      /// <param name="Filter">Refine the query as per requirment</param>
      /// <returns>Array of Candidate_Education object</returns>
      public Candidate_Prev_Employer[] CandidatesPrevEmpl(String Filter)
      {
          const String Qry = " SELECT * FROM Candidate_Prev_Employer E Inner Join Master_Candidate C " +
                             " ON C.CandidateID=E.ID Where IsActive=1";

          ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
          ExecutionQuery exQry = new ExecutionQuery();

          if (Filter == String.Empty)
          {
              exQry.Query = string.Format(Qry);
          }
          else
          {
              exQry.Query = string.Format(Qry) + " And " + Filter;
          }

          DataTable dt = EE.ExecuteDataTable(exQry);

          Candidate_Prev_Employer[] CandidatePrevDetails = new Candidate_Prev_Employer[dt.Rows.Count];

          for (int i = 0; i < CandidatePrevDetails.Length; i++)
          {
              CandidatePrevDetails[i] = new Candidate_Prev_Employer();
              CandidatePrevDetails[i].ID = (int)dt.Rows[i]["ID"];
              CandidatePrevDetails[i].CandidateID = (int)dt.Rows[i]["CandidateID"];

              CandidatePrevDetails[i].EmployerName = (String)dt.Rows[i]["EmployerName"];
              CandidatePrevDetails[i].Designation = (String)dt.Rows[i]["Designation"];
              CandidatePrevDetails[i].Responsibilities = (String)dt.Rows[i]["Responsibilities"];
              CandidatePrevDetails[i].ResonForLeaving = (String)dt.Rows[i]["ResonForLeaving"];
              CandidatePrevDetails[i].CTC = (float)dt.Rows[i]["CTC"];
              CandidatePrevDetails[i].TakeHome = (float)dt.Rows[i]["TakeHome"];
              CandidatePrevDetails[i].StartDate = (DateTime)dt.Rows[i]["StartDate"];
              CandidatePrevDetails[i].EndDate = (DateTime)dt.Rows[i]["EndDate"];

          }
          return CandidatePrevDetails;
      }

      /// <summary>
      /// check Candidate Education Existance in the database.
      /// </summary>
      /// <param name="Candidate">field contains Candidate Education</param>
      /// <param name="ID">field contains Candidate Education ID</param>
      /// <returns>True for Exist and false for not exist</returns>
      public bool IsCandPrevEmpExists(String EmployerName, int CandidateID, int ID)
      {
          const String Qry = " IF EXISTS (SELECT ID FROM Candidate_Prev_Employer WHERE EmployerName = '{0}' And CandidateID ={1} AND ID<>{2})"
                              + " SELECT 0"
                              + " ELSE"
                              + " SELECT 1";

          ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
          ExecutionQuery exQry = new ExecutionQuery();
          exQry.Query = string.Format(Qry, EmployerName, CandidateID.ToString(), ID.ToString());
          return string.Concat(EE.ExecuteScalar(exQry)) == "0";
      }

      #endregion

      #region CANDIDATE CURRENT EMPLOYER

      /// <summary>
      /// Get Candidate By Candidate Education
      /// </summary>
      /// <param name="CandidateName">field contaions Candidate Education</param>
      /// <returns>data related given Candidate Education in case of success otherwise it return null</returns>
      public Candidate_Current_Employer GetCurrentEmpByCandidate(string EmployerName)
      {
          Candidate_Current_Employer[] CandidatesPrev = CandidatesCurrEmpl(" EmployerName = " + EmployerName);

          if (CandidatesPrev != null && CandidatesPrev.Length > 0)
          {
              return CandidatesPrev[0];
          }
          else
          {
              return null;
          }
      }

      /// <summary>
      /// Get Candidate Education data from the database
      /// </summary>
      /// <param name="Filter">Refine the query as per requirment</param>
      /// <returns>Array of Candidate_Education object</returns>
      public Candidate_Current_Employer[] CandidatesCurrEmpl(String Filter)
      {
          const String Qry = " SELECT * FROM Candidate_Current_Employer E Inner Join Master_Candidate C " +
                             " ON C.CandidateID=E.ID Where IsActive=1";

          ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
          ExecutionQuery exQry = new ExecutionQuery();

          if (Filter == String.Empty)
          {
              exQry.Query = string.Format(Qry);
          }
          else
          {
              exQry.Query = string.Format(Qry) + " And " + Filter;
          }

          DataTable dt = EE.ExecuteDataTable(exQry);

          Candidate_Current_Employer[] CandidateCurrDetails = new Candidate_Current_Employer[dt.Rows.Count];

          for (int i = 0; i < CandidateCurrDetails.Length; i++)
          {
              CandidateCurrDetails[i] = new Candidate_Current_Employer();
              CandidateCurrDetails[i].ID = (int)dt.Rows[i]["ID"];
              CandidateCurrDetails[i].CandidateID = (int)dt.Rows[i]["CandidateID"];
              CandidateCurrDetails[i].EmployerName = (String)dt.Rows[i]["EmployerName"];
              CandidateCurrDetails[i].Address = (String)dt.Rows[i]["Address"];
              CandidateCurrDetails[i].BusinessNature = (String)dt.Rows[i]["BusinessNature"];
              CandidateCurrDetails[i].NoOfEmployess = (int)dt.Rows[i]["NoOfEmployess"];
              CandidateCurrDetails[i].AnnualSalesTurnOver = (String)dt.Rows[i]["AnnualSalesTurnOver"];
              CandidateCurrDetails[i].JoinDesignation = (String)dt.Rows[i]["JoinDesignation"];
              CandidateCurrDetails[i].JoinDate = (DateTime)dt.Rows[i]["JoinDate"];
              CandidateCurrDetails[i].CurrentDesignation = (String)dt.Rows[i]["CurrentDesignation"];
              CandidateCurrDetails[i].DesignationEffectFrom = (DateTime)dt.Rows[i]["DesignationEffectFrom"];
              CandidateCurrDetails[i].ReportingOfficer = (String)dt.Rows[i]["ReportingOfficer"];
              CandidateCurrDetails[i].ReportingOfficerDesignation = (String)dt.Rows[i]["ReportingOfficerDesignation"];
              CandidateCurrDetails[i].ReportingOfficerMobileNo = (String)dt.Rows[i]["ReportingOfficerMobileNo"];
              CandidateCurrDetails[i].ReportingOfficerTeleNo = (String)dt.Rows[i]["ReportingOfficerTeleNo"];
              CandidateCurrDetails[i].Responsible = (String)dt.Rows[i]["Responsible"];
              CandidateCurrDetails[i].Remarks = (String)dt.Rows[i]["Remarks"];
              CandidateCurrDetails[i].Joining_Basic = (float)dt.Rows[i]["Joining_Basic"];
              CandidateCurrDetails[i].Joining_DA = (float)dt.Rows[i]["Joining_DA"];
              CandidateCurrDetails[i].Joining_HRA = (float)dt.Rows[i]["Joining_HRA"];
              CandidateCurrDetails[i].Joining_Conveyance = (float)dt.Rows[i]["Joining_Conveyance"];
              CandidateCurrDetails[i].Joining_OtherAllowance = (float)dt.Rows[i]["Joining_OtherAllowance"];
              CandidateCurrDetails[i].Joining_GrossSalary = (float)dt.Rows[i]["Joining_GrossSalary"];
              CandidateCurrDetails[i].Joining_LTA = (float)dt.Rows[i]["Joining_LTA"];
              CandidateCurrDetails[i].Joining_Medical = (float)dt.Rows[i]["Joining_Medical"];
              CandidateCurrDetails[i].Joining_AnnualBonus = (float)dt.Rows[i]["Joining_AnnualBonus"];
              CandidateCurrDetails[i].Joining_ClubMembership = (float)dt.Rows[i]["Joining_ClubMembership"];
              CandidateCurrDetails[i].Joining_Others = (float)dt.Rows[i]["Joining_Others"];
              CandidateCurrDetails[i].Joining_MonthlyCTC = (float)dt.Rows[i]["Joining_MonthlyCTC"];
              CandidateCurrDetails[i].Current_Basic = (float)dt.Rows[i]["Current_Basic"];
              CandidateCurrDetails[i].Current_DA = (float)dt.Rows[i]["Current_DA"];
              CandidateCurrDetails[i].Current_HRA = (float)dt.Rows[i]["Current_HRA"];
              CandidateCurrDetails[i].Current_Conveyance = (float)dt.Rows[i]["Current_Conveyance"];
              CandidateCurrDetails[i].Current_OtherAllowance = (float)dt.Rows[i]["Current_OtherAllowance"];
              CandidateCurrDetails[i].Current_GrossSalary = (float)dt.Rows[i]["Current_GrossSalary"];
              CandidateCurrDetails[i].Current_LTA = (float)dt.Rows[i]["Current_LTA"];
              CandidateCurrDetails[i].Current_Medical = (float)dt.Rows[i]["Current_Medical"];
              CandidateCurrDetails[i].Current_AnnualBonus = (float)dt.Rows[i]["Current_AnnualBonus"];
              CandidateCurrDetails[i].Current_ClubMembership = (float)dt.Rows[i]["Current_ClubMembership"];
              CandidateCurrDetails[i].Current_Others = (float)dt.Rows[i]["Current_Others"];
              CandidateCurrDetails[i].Current_MonthlyCTC = (float)dt.Rows[i]["Current_MonthlyCTC"];
              CandidateCurrDetails[i].IsPF = (bool)dt.Rows[i]["IsPF"];
              CandidateCurrDetails[i].IsGratuity = (bool)dt.Rows[i]["IsGratuity"];
              CandidateCurrDetails[i].IsSuperAnnuation = (bool)dt.Rows[i]["IsSuperAnnuation"];
              CandidateCurrDetails[i].Others = (String)dt.Rows[i]["Others"];
              CandidateCurrDetails[i].WeeklyOff = (String)dt.Rows[i]["WeeklyOff"];

          }
          return CandidateCurrDetails;
      }
     

      #endregion

      #region CANDIDATE QUESTIONERS

      /// <summary>
      /// Get Candidate By Candidate Education
      /// </summary>
      /// <param name="CandidateName">field contaions Candidate Education</param>
      /// <returns>data related given Candidate Education in case of success otherwise it return null</returns>
      public Candidate_Questioners GetQuestionsByCandidate(string Achievements)
      {
          Candidate_Questioners[] CandidatesQuset = CandidatesQuestions(" Achievements = " + Achievements);

          if (CandidatesQuset != null && CandidatesQuset.Length > 0)
          {
              return CandidatesQuset[0];
          }
          else
          {
              return null;
          }
      }

      /// <summary>
      /// Get Candidate Education data from the database
      /// </summary>
      /// <param name="Filter">Refine the query as per requirment</param>
      /// <returns>Array of Candidate_Education object</returns>
      public Candidate_Questioners[] CandidatesQuestions(String Filter)
      {
          const String Qry = " SELECT * FROM Candidate_Questioners E Inner Join Master_Candidate C " +
                             " ON C.CandidateID=E.ID Where IsActive=1";

          ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
          ExecutionQuery exQry = new ExecutionQuery();

          if (Filter == String.Empty)
          {
              exQry.Query = string.Format(Qry);
          }
          else
          {
              exQry.Query = string.Format(Qry) + " And " + Filter;
          }

          DataTable dt = EE.ExecuteDataTable(exQry);

          Candidate_Questioners[] CandidateQuestDetails = new Candidate_Questioners[dt.Rows.Count];

          for (int i = 0; i < CandidateQuestDetails.Length; i++)
          {
              CandidateQuestDetails[i] = new Candidate_Questioners();
              CandidateQuestDetails[i].ID = (int)dt.Rows[i]["ID"];
              CandidateQuestDetails[i].CandidateID = (int)dt.Rows[i]["CandidateID"];
              CandidateQuestDetails[i].Achievements = (String)dt.Rows[i]["Achievements"];
              CandidateQuestDetails[i].AlreadyInterviewed = (bool)dt.Rows[i]["AlreadyInterviewed"];
              CandidateQuestDetails[i].Challenges = (String)dt.Rows[i]["Challenges"];
              CandidateQuestDetails[i].CommitmentYears = (short)dt.Rows[i]["CommitmentYears"];
              CandidateQuestDetails[i].EmployeerRemarks = (String)dt.Rows[i]["EmployeerRemarks"];
              CandidateQuestDetails[i].ExpectedMonthlyGross = (double)dt.Rows[i]["ExpectedMonthlyGross"];
              CandidateQuestDetails[i].ExpectedMonthlyTakeHome = (double)dt.Rows[i]["ExpectedMonthlyTakeHome"];
              CandidateQuestDetails[i].ExpectedYearlyCTC = (double)dt.Rows[i]["ExpectedYearlyCTC"];
              CandidateQuestDetails[i].FunctionalArea = (String)dt.Rows[i]["FunctionalArea"];
              CandidateQuestDetails[i].Goals = (String)dt.Rows[i]["Goals"];
              CandidateQuestDetails[i].InBond = (bool)dt.Rows[i]["InBond"];
              CandidateQuestDetails[i].InterviewedPosistion = (String)dt.Rows[i]["InterviewedPosistion"];
              CandidateQuestDetails[i].NoticePeriod = (short)dt.Rows[i]["NoticePeriod"];
              CandidateQuestDetails[i].PlaningForStudies = (bool)dt.Rows[i]["PlaningForStudies"];
              CandidateQuestDetails[i].Ref1_Address = (String)dt.Rows[i]["Ref1_Address"];
              CandidateQuestDetails[i].Ref1_MobileNumber = (String)dt.Rows[i]["Ref1_MobileNumber"];
              CandidateQuestDetails[i].Ref1_Name = (String)dt.Rows[i]["Ref1_Name"];
              CandidateQuestDetails[i].Ref1_PhoneNumber = (String)dt.Rows[i]["Ref1_PhoneNumber"];
              CandidateQuestDetails[i].Ref2_Address = (String)dt.Rows[i]["Ref2_Address"];
              CandidateQuestDetails[i].Ref2_MobileNumber = (String)dt.Rows[i]["Ref2_MobileNumber"];
              CandidateQuestDetails[i].Ref2_Name = (String)dt.Rows[i]["Ref2_Name"];
              CandidateQuestDetails[i].Ref2_PhoneNumber = (String)dt.Rows[i]["Ref2_PhoneNumber"];
              CandidateQuestDetails[i].SelfDetails = (String)dt.Rows[i]["SelfDetails"];
              CandidateQuestDetails[i].WhyISutie = (String)dt.Rows[i]["WhyISutie"];
              CandidateQuestDetails[i].WillingToRelocate = (bool)dt.Rows[i]["WillingToRelocate"];
            
          }
          return CandidateQuestDetails;
      }


      #endregion

      #region CANDIDATE JOBS
      /// <summary>
      /// Get Candidate By Candidate Education
      /// </summary>
      /// <param name="CandidateName">field contaions Candidate Education</param>
      /// <returns>data related given Candidate Education in case of success otherwise it return null</returns>
      public Candidate_JobDetails GetJobsByCandidate(int CandidateID)
      {
          Candidate_JobDetails[] CandidatesJob = CandidatesJobs(" CandidateID = " + CandidateID);

          if (CandidatesJob != null && CandidatesJob.Length > 0)
          {
              return CandidatesJob[0];
          }
          else
          {
              return null;
          }
      }

      /// <summary>
      /// Get Candidate Education data from the database
      /// </summary>
      /// <param name="Filter">Refine the query as per requirment</param>
      /// <returns>Array of Candidate_Education object</returns>
      public Candidate_JobDetails[] CandidatesJobs(String Filter)
      {
          const String Qry = " SELECT * FROM Candidate_JobDetails E Inner Join Master_Candidate C " +
                             " ON C.CandidateID=E.ID Where IsActive=1";

          ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
          ExecutionQuery exQry = new ExecutionQuery();

          if (Filter == String.Empty)
          {
              exQry.Query = string.Format(Qry);
          }
          else
          {
              exQry.Query = string.Format(Qry) + " And " + Filter;
          }

          DataTable dt = EE.ExecuteDataTable(exQry);

          Candidate_JobDetails[] CandidateJobs = new Candidate_JobDetails[dt.Rows.Count];

          for (int i = 0; i < CandidateJobs.Length; i++)
          {
              CandidateJobs[i] = new Candidate_JobDetails();
              CandidateJobs[i].ID = (int)dt.Rows[i]["ID"];
              CandidateJobs[i].CandidateID = (int)dt.Rows[i]["CandidateID"];
              CandidateJobs[i].JobID = (int)dt.Rows[i]["JobID"];
              CandidateJobs[i].Status = (String)dt.Rows[i]["Status"];
              CandidateJobs[i].AppliedDate = (DateTime)dt.Rows[i]["AppliedDate"];

          }
          return CandidateJobs;
      }


#endregion

      #region Candidate For Employee


      /// <summary>
      /// Get JobProfile By JobProfile Name
      /// </summary>
      /// <param name="JobProfileName">field contaions JobProfile Name</param>
      /// <returns>data related given Designation Name in case of success otherwise it return null</returns>
      public Master_Candidate[] GetEmployeesForInterview(int LocationID, int DesignationID)
      {
          Master_Candidate[] EmployeeDetails = GetInterviewEmployeeDetails(" LocationID = '" + LocationID + "' and DesignationID  = '" + DesignationID + "'");

          if (EmployeeDetails != null && EmployeeDetails.Length > 0)
          {
              return EmployeeDetails;
          }
          else
          {
              return null;
          }
      }

      /// <summary>
      /// Get JobProfile By JobProfile Name
      /// </summary>
      /// <param name="JobProfileName">field contaions JobProfile Name</param>
      /// <returns>data related given Designation Name in case of success otherwise it return null</returns>
      public Master_Candidate[] GetEmployeesForInterview(int DesignationID,int DepartmentID,int BranchID,int GradeID,int LocationID)
      {
          string strFilter = string.Empty;
          if (BranchID.ToString() != "0")
          {
              strFilter = strFilter + " AND B.BranchID = " + BranchID.ToString();
          }
          if (DepartmentID.ToString() != "0")
          {
              strFilter = strFilter + " AND E.DepartmentID = " + DepartmentID.ToString();
          }
          if (DesignationID.ToString() != "0")
          {
              strFilter = strFilter + " AND DS.DesignationID = " + DesignationID.ToString();
          }
          if (GradeID.ToString() != "0")
          {
              strFilter = strFilter + " AND G.GradeID = " + GradeID.ToString();
          }
          if (LocationID.ToString() != "0")
          {
              strFilter = strFilter + " AND L.LocationID = " + LocationID.ToString();
          }

          //Master_Candidate[] EmployeeDetails = GetInterviewEmployeeDetails(" DS.DesignationID  = '" + DesignationID + "' or E.DepartmentID  = '" + DepartmentID + "' or B.BranchID  = '" + BranchID + "' or G.GradeID  = '" + GradeID + "'");
          Master_Candidate[] EmployeeDetails = GetInterviewEmployeeDetailsNew(strFilter);

          if (EmployeeDetails != null && EmployeeDetails.Length > 0)
          {
              return EmployeeDetails;
          }
          else
          {
              return null;
          }
      }
      /// <summary>
      /// Get JobProfile By JobProfile Name
      /// </summary>
      /// <param name="JobProfileName">field contaions JobProfile Name</param>
      /// <returns>data related given Designation Name in case of success otherwise it return null</returns>
      public Master_Candidate[] GetEmployeesForReportingTo(int LocationID)
      {
          Master_Candidate[] EmployeeDetails = GetInterviewEmployeeDetails(" LocationID = '" + LocationID + "'");

          if (EmployeeDetails != null && EmployeeDetails.Length > 0)
          {
              return EmployeeDetails;
          }
          else
          {
              return null;
          }
      }
      /// <summary>
      /// Get Designations data from the database
      /// </summary>
      /// <param name="Filter">Refine the query as per requirment</param>
      /// <returns>Array of Master_JobProfile object</returns>

      public Master_Candidate[] GetInterviewEmployeeDetails(String Filter)
      {
          //const String Qry = " Select distinct FirstName + ' ' + LastName EmployeeName,E.ID,Per_StateID,Temp_StateID From Master_Candidate C  " +
          //                  " Inner Join Master_Employee E ON E.CandidateID=C.ID Inner Join Master_Employee_Details M  ON M.EmployeeID=E.ID ";

          const String Qry = "Select distinct FirstName + ' ' + LastName EmployeeName,E.ID,Per_StateID,Temp_StateID ,E.DepartmentID,B.BranchID,DS.DesignationID,G.GradeID " +
                            " From Master_Candidate C " +
                            " Inner Join Master_Employees E ON E.CandidateID=C.ID " +
                            " Inner Join Assign_Emp_Branch B  ON E.ID=B.EmpID " +
              // " Inner Join Assign_Emp_Department D  ON E.ID=D.EmpID " +
                            " Inner Join Assign_Emp_Designation DS  ON E.ID=DS.EmpID " +
                            " Inner Join Assign_Emp_Grade G  ON E.ID=G.EmpID WHERE C.IsActive=1 And EmploymentType not in ('RET','TER','RES') and " +
                            "  G.ActivatedDate = (SELECT MAX(ActivatedDate) FROM Assign_Emp_Grade A1 Where A1.EmpID= E.ID ) and " +
                            "  DS.ActivatedDate = (SELECT MAX(ActivatedDate) FROM Assign_Emp_Designation DS1 Where DS1.EmpID= E.ID ) and " +
                            "  B.ActivatedDate = (SELECT MAX(ActivatedDate) FROM Assign_Emp_Branch B1 Where B1.EmpID= E.ID ) ";

          ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
          ExecutionQuery exQry = new ExecutionQuery();

          if (Filter == String.Empty)
          {
              exQry.Query = string.Format(Qry);
          }
          else
          {
              exQry.Query = string.Format(Qry) + "  And " + Filter;
          }

          DataTable dt = EE.ExecuteDataTable(exQry);

          Master_Candidate[] EmployeeDetails = new Master_Candidate[dt.Rows.Count];

          for (int i = 0; i < EmployeeDetails.Length; i++)
          {
              EmployeeDetails[i] = new Master_Candidate();
              EmployeeDetails[i].ID = (int)dt.Rows[i]["ID"];
              EmployeeDetails[i].FirstName = (String)dt.Rows[i]["EmployeeName"];
              EmployeeDetails[i].Per_StateID = (int)dt.Rows[i]["Per_StateID"];
              if (dt.Rows[i]["Temp_StateID"].ToString() != string.Empty)
              EmployeeDetails[i].Temp_StateID = (int)dt.Rows[i]["Temp_StateID"];
          }

          return EmployeeDetails;
      }
      /// <summary>
      /// Get Designations data from the database
      /// </summary>
      /// <param name="Filter">Refine the query as per requirment</param>
      /// <returns>Array of Master_JobProfile object</returns>

      public Master_Candidate[] GetInterviewEmployeeDetailsNew(String Filter)
      {
          //const String Qry = " Select distinct FirstName + ' ' + LastName EmployeeName,E.ID,Per_StateID,Temp_StateID From Master_Candidate C  " +
          //                  " Inner Join Master_Employee E ON E.CandidateID=C.ID Inner Join Master_Employee_Details M  ON M.EmployeeID=E.ID ";

          const String Qry = "Select distinct FirstName + ' ' + LastName EmployeeName,E.ID,Per_StateID,Temp_StateID ,E.DepartmentID,B.BranchID,DS.DesignationID,G.GradeID,L.LocationID " +
                            " From Master_Candidate C " +
                            " Inner Join Master_Employees E ON E.CandidateID=C.ID " +
                            " Inner Join Assign_Emp_Branch B  ON E.ID=B.EmpID " +
              // " Inner Join Assign_Emp_Department D  ON E.ID=D.EmpID " +
                            " Inner Join Assign_Emp_Locations L  ON E.ID=L.EmpID " +
                            " Inner Join Assign_Emp_Designation DS  ON E.ID=DS.EmpID " +
                            " Inner Join Master_EmployeeType MET  ON E.EmploymentType=MET.ID " +
                            " Inner Join Assign_Emp_Grade G  ON E.ID=G.EmpID WHERE C.IsActive=1 and MET.IsService=1 and" +//And EmploymentType not in ('RET','TER','RES') and " +
                            "  G.ActivatedDate = (SELECT MAX(ActivatedDate) FROM Assign_Emp_Grade A1 Where A1.EmpID= E.ID ) and " +
                            "  DS.ActivatedDate = (SELECT MAX(ActivatedDate) FROM Assign_Emp_Designation DS1 Where DS1.EmpID= E.ID ) and " +
                            "  B.ActivatedDate = (SELECT MAX(ActivatedDate) FROM Assign_Emp_Branch B1 Where B1.EmpID= E.ID ) and "+
                            "  L.ActivatedDate = (SELECT MAX(ActivatedDate) FROM Assign_Emp_Locations L1 Where L1.EmpID= E.ID ) ";

          ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
          ExecutionQuery exQry = new ExecutionQuery();

          if (Filter == String.Empty)
          {
              exQry.Query = string.Format(Qry);
          }
          else
          {
              exQry.Query = string.Format(Qry) + " " + Filter;
          }

          DataTable dt = EE.ExecuteDataTable(exQry);

          Master_Candidate[] EmployeeDetails = new Master_Candidate[dt.Rows.Count];

          for (int i = 0; i < EmployeeDetails.Length; i++)
          {
              EmployeeDetails[i] = new Master_Candidate();
              EmployeeDetails[i].ID = (int)dt.Rows[i]["ID"];
              EmployeeDetails[i].FirstName = (String)dt.Rows[i]["EmployeeName"];
              EmployeeDetails[i].Per_StateID = (int)dt.Rows[i]["Per_StateID"];
              if (dt.Rows[i]["Temp_StateID"].ToString() != string.Empty)
                  EmployeeDetails[i].Temp_StateID = (int)dt.Rows[i]["Temp_StateID"];
          }

          return EmployeeDetails;
      }
      #endregion

      public Master_Candidate GetExistCandidateID(String EmpCode)
      {
          const String Qry = "SELECT CandidateID ID" 
                              + " FROM "
                              + " Master_Candidate MC " 
                              + "  INNER JOIN Master_Employees ME "
                              + "  ON " 
                              + "  ME.CandidateID = MC.ID"
                              + "  WHERE EmpCode='{0}'";
                                

          ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
          ExecutionQuery exQry = new ExecutionQuery();
          exQry.Query = string.Format(Qry, EmpCode);
          DataTable dt = EE.ExecuteDataTable(exQry);
          Master_Candidate DTO = new Master_Candidate();
          if (dt.Rows.Count > 0)
          {
              DTO.ID = (int)dt.Rows[0]["ID"];              
          }
          return DTO;
      }

      public Master_Candidate GetNewCandidateID()
      {
          const String Qry = "SELECT ID FROM Master_Candidate WHERE ID!=1 ORDER BY ID DESC ";
          ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
          ExecutionQuery exQry = new ExecutionQuery();
          exQry.Query = string.Format(Qry);
          DataTable dt = EE.ExecuteDataTable(exQry);
          Master_Candidate DTO = new Master_Candidate();
          if (dt.Rows.Count > 0)
          {
              DTO.ID = (int)dt.Rows[0]["ID"];
          }
          return DTO;
      }
  }
 
}
