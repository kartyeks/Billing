using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;
using HRManager.Entity;

namespace HRManager.BusinessObjects
{
   public partial class Candidate_JobDetailsBusinessObject
    {

        /// <summary>
        /// Get Language By  Candidate
        /// </summary>
        /// <param name="ZoneName">field contaions Language</param>
        /// <returns>data related given Language in case of success otherwise it return null</returns>
        public Candidate_JobDetails[] GetJobdetailsByCandidate(string candidateID)
        {
            return GetJobDetails(" CandidateID=" + candidateID.ToString());
        }
        /// <summary>
        /// Get Language data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Assign_Candidate_Language object</returns>
        public Candidate_JobDetails[] GetJobDetails(String Filter)
        {
            const String Qry = " SELECT * FROM Candidate_JobDetails";

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

            Candidate_JobDetails[] GetJobDetails = new Candidate_JobDetails[dt.Rows.Count];

            for (int i = 0; i < GetJobDetails.Length; i++)
            {
                GetJobDetails[i] = new Candidate_JobDetails();
                GetJobDetails[i].ID = (int)dt.Rows[i]["ID"];
                GetJobDetails[i].CandidateID = (int)dt.Rows[i]["CandidateID"];
                GetJobDetails[i].JobID = (int)dt.Rows[i]["JobID"];
                GetJobDetails[i].Status = (String)dt.Rows[i]["Status"];
                GetJobDetails[i].AppliedDate = (DateTime)dt.Rows[i]["AppliedDate"];
                
            }
            return GetJobDetails;
        }

        public Int32 GetCandJobdetailsID(int candidateID)
        {
            Int32 id = 0;
            const string qry = "Select ID From Candidate_JobDetails Where CandidateID={0}";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(qry, candidateID);
            Int32.TryParse(string.Concat(EE.ExecuteScalar(exQry), string.Empty), out id);
            return id;
        }
        /// <summary>
        /// Get Offer Letter Details By  Candidate
        /// </summary>
        /// <param name="ZoneName">field contaions Language</param>
        /// <returns>data related given Language in case of success otherwise it return null</returns>
        public OfferLetter GetOfferLetterDetailsByCandidate(int candidateID)
        {
            const String Qry = " select OfferLetter from Candidate_JobDetails CJD " +
                               " Inner Join Master_jobprofile MJP on (MJP.ID=CJD.JobID) " +
                               " Inner join Master_OfferLetter MOL on (MOL.DesignationID = MJP.DesignationID) " +
                               " where CJD.CandidateId={0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
           
            exQry.Query = string.Format(Qry,candidateID.ToString());            

            DataTable dt = EE.ExecuteDataTable(exQry);

            OfferLetter OfferLetterDetails = new OfferLetter();
            if (dt.Rows.Count > 0)
                OfferLetterDetails.OfferLetterName = (String)dt.Rows[0]["OfferLetter"];
            else
                OfferLetterDetails.OfferLetterName = String.Empty;

            return OfferLetterDetails;
        }
       
       /// <summary>
        /// Get Offer Letter Details By  Candidate
        /// </summary>
        /// <param name="ZoneName">field contaions Language</param>
        /// <returns>data related given Language in case of success otherwise it return null</returns>
        public OfferLetterParameters GetABMOfferLetterParameters(int candidateID)
        {
            const String Qry = " select 'CandidateName' =case when MC.Sex='M' then 'Mr. '+MC.Firstname+' '+isnull(MC.LastName,'') " +
                            " when MC.Sex='F' and MC.MaritialStatus='N' then 'Miss '+MC.Firstname+' '+isnull(MC.LastName,'') " +
                            " when MC.Sex='F' and MC.MaritialStatus='Y' then 'Mrs. '+MC.Firstname+' '+isnull(MC.LastName,'') " +
                            " else MC.Firstname+' '+isnull(MC.LastName,'') " +
                            " end,Temp_Addess Address1,Temp_Street+','+Temp_City Address2, " +
                            " CS.StateName Address3,Temp_MobileNumber Cell, " +
                            " HD.Designation Designation,MB.BranchName,HDR.Designation ReportingTo, " +
                            " MBT.BranchName TrainingLocation, " +
                            " MBT.Address1+','+MBT.Address1 TrainingAddress1, " +
                            " MBT.Address3+','+MBT.City +','+CST.StateName TrainingAddress2, " +
                            " 'Phone : '+MBT.PhoneNumber+',Fax : '+MBT.FaxNumber TrainingAddress3, " +
                            " HG.Grade,Convert(varchar(10),DATEADD(dd, 7, GETDATE()),103) ResponseDate,UPPER(MC.Firstname+' '+isnull(MC.LastName,'')) OnlyCandidateName " +
                            " from master_candidate MC  " +
                            " Inner Join Candidate_JobDetails CJD on (CJD.CandidateID=MC.ID) " +
                            " Inner Join Master_JobProfile MJP on (MJP.ID=CJD.JobID) " +
                            " Inner Join Hr_Designation HD on (HD.ID=MJP.DesignationID) " +
                            " Inner Join Candidate_InterviewSchedule CIS on (CJD.ID=CIS.CandidateJobDetailsID) " +
                            " Inner Join Assign_Candidate_Interview_Approval ACIA on (ACIA.InterviewID=CIS.ID) " +
                            " Inner Join Master_Branch MB on (MB.ID = ACIA.BranchID) " +
                            " Inner Join Master_Branch MBT on (MBT.ID = ACIA.TrainingBranchID) " +
                            " Inner Join Hr_designation HDR on (HDR.id=HD.ParentDesignationID) " +
                            " Inner Join Hr_Grade HG on (HG.ID = ACIA.GradeID) " +
                            " Inner Join Common_State CS on (CS.ID= Temp_StateID) " +
                            " Inner Join Common_State CST on (CST.ID= MBT.State) " +
                            " where MC.id ={0}";    

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
           
            exQry.Query = string.Format(Qry,candidateID.ToString());            

            DataTable dt = EE.ExecuteDataTable(exQry);

            OfferLetterParameters OfferLetterDetails = new OfferLetterParameters();
            if (dt.Rows.Count > 0)
            {
                OfferLetterDetails.CandidateName = (String)dt.Rows[0]["CandidateName"];
                OfferLetterDetails.Designation = (String)dt.Rows[0]["Designation"];
                OfferLetterDetails.Branch = (String)dt.Rows[0]["BranchName"];
                OfferLetterDetails.ReportingTo = (String)dt.Rows[0]["ReportingTo"];
                OfferLetterDetails.TrainingAddress1 = (String)dt.Rows[0]["TrainingAddress1"];
                OfferLetterDetails.TrainingAddress2 = (String)dt.Rows[0]["TrainingAddress2"];
                OfferLetterDetails.TrainingAddress3 = (String)dt.Rows[0]["TrainingAddress3"];
                OfferLetterDetails.Grade = (String)dt.Rows[0]["Grade"];
                OfferLetterDetails.ResponseDate = (String)dt.Rows[0]["ResponseDate"];
                OfferLetterDetails.OnlyCandidateName = (String)dt.Rows[0]["OnlyCandidateName"];
                OfferLetterDetails.Address1 = (String)dt.Rows[0]["Address1"];
                OfferLetterDetails.Address2 = (String)dt.Rows[0]["Address2"];
                OfferLetterDetails.Address3 = (String)dt.Rows[0]["Address3"];
                OfferLetterDetails.Cell = (String)dt.Rows[0]["Cell"];
                OfferLetterDetails.TrainingLocation = (String)dt.Rows[0]["TrainingLocation"];

            }
            else
                OfferLetterDetails= null;

            return OfferLetterDetails;
        }
        /// <summary>
        /// Get Offer Letter Details By  Candidate
        /// </summary>
        /// <param name="ZoneName">field contaions Language</param>
        /// <returns>data related given Language in case of success otherwise it return null</returns>
        public OfferLetterParameters GetBAOfferLetterParameters(int candidateID)
        {
            const String Qry = " select 'CandidateName' =case when MC.Sex='M' then 'Mr. '+MC.Firstname+' '+isnull(MC.LastName,'') " +
                            " when MC.Sex='F' and MC.MaritialStatus='N' then 'Miss '+MC.Firstname+' '+isnull(MC.LastName,'') " +
                            " when MC.Sex='F' and MC.MaritialStatus='Y' then 'Mrs. '+MC.Firstname+' '+isnull(MC.LastName,'') " +
                            " else MC.Firstname+' '+isnull(MC.LastName,'') " +
                            " end,Temp_Addess Address1,Temp_Street+','+Temp_City Address2, " +
                            " CS.StateName Address3,Temp_MobileNumber Cell, " +
                            " HD.Designation Designation,MB.BranchName, " +
                            " HG.Grade,UPPER(MC.Firstname+' '+isnull(MC.LastName,'')) OnlyCandidateName " +
                            " from master_candidate MC  " +
                            " Inner Join Candidate_JobDetails CJD on (CJD.CandidateID=MC.ID) " +
                            " Inner Join Master_JobProfile MJP on (MJP.ID=CJD.JobID) " +
                            " Inner Join Hr_Designation HD on (HD.ID=MJP.DesignationID) " +
                            " Inner Join Candidate_InterviewSchedule CIS on (CJD.ID=CIS.CandidateJobDetailsID) " +
                            " Inner Join Assign_Candidate_Interview_Approval ACIA on (ACIA.InterviewID=CIS.ID) " +
                            " Inner Join Master_Branch MB on (MB.ID = ACIA.BranchID) " +
                            " Inner Join Hr_designation HDR on (HDR.id=HD.ParentDesignationID) " +
                            " Inner Join Hr_Grade HG on (HG.ID = ACIA.GradeID) " +
                            " Inner Join Common_State CS on (CS.ID= Temp_StateID) " +
                            " where MC.id ={0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = string.Format(Qry, candidateID.ToString());

            DataTable dt = EE.ExecuteDataTable(exQry);

            OfferLetterParameters OfferLetterDetails = new OfferLetterParameters();
            if (dt.Rows.Count > 0)
            {
                OfferLetterDetails.CandidateName = (String)dt.Rows[0]["CandidateName"];
                OfferLetterDetails.Designation = (String)dt.Rows[0]["Designation"];
                OfferLetterDetails.Branch = (String)dt.Rows[0]["BranchName"];
                OfferLetterDetails.Grade = (String)dt.Rows[0]["Grade"];
                OfferLetterDetails.OnlyCandidateName = (String)dt.Rows[0]["OnlyCandidateName"];
                OfferLetterDetails.Address1 = (String)dt.Rows[0]["Address1"];
                OfferLetterDetails.Address2 = (String)dt.Rows[0]["Address2"];
                OfferLetterDetails.Address3 = (String)dt.Rows[0]["Address3"];
                OfferLetterDetails.Cell = (String)dt.Rows[0]["Cell"];

            }
            else
                OfferLetterDetails = null;

            return OfferLetterDetails;
        }
        public OfferLetterParameters GetBOOfferLetterParameters(int candidateID)
        {
            const String Qry = " select 'CandidateName' =case when MC.Sex='M' then 'Mr. '+MC.Firstname+' '+isnull(MC.LastName,'') " +
                            " when MC.Sex='F' and MC.MaritialStatus='N' then 'Miss '+MC.Firstname+' '+isnull(MC.LastName,'') " +
                            " when MC.Sex='F' and MC.MaritialStatus='Y' then 'Mrs. '+MC.Firstname+' '+isnull(MC.LastName,'') " +
                            " else MC.Firstname+' '+isnull(MC.LastName,'') " +
                            " end,Temp_Addess Address1,Temp_Street+','+Temp_City Address2, " +
                            " CS.StateName Address3,Temp_MobileNumber Cell, " +
                            " HD.Designation Designation,MB.BranchName, " +
                            " HG.Grade,UPPER(MC.Firstname+' '+isnull(MC.LastName,'')) OnlyCandidateName " +
                            " from master_candidate MC  " +
                            " Inner Join Candidate_JobDetails CJD on (CJD.CandidateID=MC.ID) " +
                            " Inner Join Master_JobProfile MJP on (MJP.ID=CJD.JobID) " +
                            " Inner Join Hr_Designation HD on (HD.ID=MJP.DesignationID) " +
                            " Inner Join Candidate_InterviewSchedule CIS on (CJD.ID=CIS.CandidateJobDetailsID) " +
                            " Inner Join Assign_Candidate_Interview_Approval ACIA on (ACIA.InterviewID=CIS.ID) " +
                            " Inner Join Master_Branch MB on (MB.ID = ACIA.BranchID) " +
                            " Inner Join Hr_designation HDR on (HDR.id=HD.ParentDesignationID) " +
                            " Inner Join Hr_Grade HG on (HG.ID = ACIA.GradeID) " +
                            " Inner Join Common_State CS on (CS.ID= Temp_StateID) " +
                            " where MC.id ={0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = string.Format(Qry, candidateID.ToString());

            DataTable dt = EE.ExecuteDataTable(exQry);

            OfferLetterParameters OfferLetterDetails = new OfferLetterParameters();
            if (dt.Rows.Count > 0)
            {
                OfferLetterDetails.CandidateName = (String)dt.Rows[0]["CandidateName"];
                OfferLetterDetails.Designation = (String)dt.Rows[0]["Designation"];
                OfferLetterDetails.Branch = (String)dt.Rows[0]["BranchName"];
                OfferLetterDetails.Grade = (String)dt.Rows[0]["Grade"];
                OfferLetterDetails.OnlyCandidateName = (String)dt.Rows[0]["OnlyCandidateName"];
                OfferLetterDetails.Address1 = (String)dt.Rows[0]["Address1"];
                OfferLetterDetails.Address2 = (String)dt.Rows[0]["Address2"];
                OfferLetterDetails.Address3 = (String)dt.Rows[0]["Address3"];
                OfferLetterDetails.Cell = (String)dt.Rows[0]["Cell"];

            }
            else
                OfferLetterDetails = null;

            return OfferLetterDetails;
        }
        public OfferLetterParameters GetSBMOfferLetterParameters(int candidateID)
        {
            const String Qry = " select 'CandidateName' =case when MC.Sex='M' then 'Mr. '+MC.Firstname+' '+isnull(MC.LastName,'') " +
                            " when MC.Sex='F' and MC.MaritialStatus='N' then 'Miss '+MC.Firstname+' '+isnull(MC.LastName,'') " +
                            " when MC.Sex='F' and MC.MaritialStatus='Y' then 'Mrs. '+MC.Firstname+' '+isnull(MC.LastName,'') " +
                            " else MC.Firstname+' '+isnull(MC.LastName,'') " +
                            " end,Temp_Addess Address1,Temp_Street+','+Temp_City Address2, " +
                            " CS.StateName Address3,Temp_MobileNumber Cell, " +
                            " HD.Designation Designation,MB.BranchName,HDR.Designation ReportingTo, " +
                            " MBT.BranchName TrainingLocation, " +
                            " MBT.Address1+','+MBT.Address1 TrainingAddress1, " +
                            " MBT.Address3+','+MBT.City +','+CST.StateName TrainingAddress2, " +
                            " 'Phone : '+MBT.PhoneNumber+',Fax : '+MBT.FaxNumber TrainingAddress3, " +
                            " HG.Grade,Convert(varchar(10),DATEADD(dd, 7, GETDATE()),103) ResponseDate,UPPER(MC.Firstname+' '+isnull(MC.LastName,'')) OnlyCandidateName " +
                            " from master_candidate MC  " +
                            " Inner Join Candidate_JobDetails CJD on (CJD.CandidateID=MC.ID) " +
                            " Inner Join Master_JobProfile MJP on (MJP.ID=CJD.JobID) " +
                            " Inner Join Hr_Designation HD on (HD.ID=MJP.DesignationID) " +
                            " Inner Join Candidate_InterviewSchedule CIS on (CJD.ID=CIS.CandidateJobDetailsID) " +
                            " Inner Join Assign_Candidate_Interview_Approval ACIA on (ACIA.InterviewID=CIS.ID) " +
                            " Inner Join Master_Branch MB on (MB.ID = ACIA.BranchID) " +
                            " Inner Join Master_Branch MBT on (MBT.ID = ACIA.TrainingBranchID) " +
                            " Inner Join Hr_designation HDR on (HDR.id=HD.ParentDesignationID) " +
                            " Inner Join Hr_Grade HG on (HG.ID = ACIA.GradeID) " +
                            " Inner Join Common_State CS on (CS.ID= Temp_StateID) " +
                            " Inner Join Common_State CST on (CST.ID= MBT.State) " +
                            " where MC.id ={0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = string.Format(Qry, candidateID.ToString());

            DataTable dt = EE.ExecuteDataTable(exQry);

            OfferLetterParameters OfferLetterDetails = new OfferLetterParameters();
            if (dt.Rows.Count > 0)
            {
                OfferLetterDetails.CandidateName = (String)dt.Rows[0]["CandidateName"];
                OfferLetterDetails.Designation = (String)dt.Rows[0]["Designation"];
                OfferLetterDetails.Branch = (String)dt.Rows[0]["BranchName"];
                OfferLetterDetails.ReportingTo = (String)dt.Rows[0]["ReportingTo"];
                OfferLetterDetails.TrainingAddress1 = (String)dt.Rows[0]["TrainingAddress1"];
                OfferLetterDetails.TrainingAddress2 = (String)dt.Rows[0]["TrainingAddress2"];
                OfferLetterDetails.TrainingAddress3 = (String)dt.Rows[0]["TrainingAddress3"];
                OfferLetterDetails.Grade = (String)dt.Rows[0]["Grade"];
                OfferLetterDetails.ResponseDate = (String)dt.Rows[0]["ResponseDate"];
                OfferLetterDetails.OnlyCandidateName = (String)dt.Rows[0]["OnlyCandidateName"];
                OfferLetterDetails.Address1 = (String)dt.Rows[0]["Address1"];
                OfferLetterDetails.Address2 = (String)dt.Rows[0]["Address2"];
                OfferLetterDetails.Address3 = (String)dt.Rows[0]["Address3"];
                OfferLetterDetails.Cell = (String)dt.Rows[0]["Cell"];
                OfferLetterDetails.TrainingLocation = (String)dt.Rows[0]["TrainingLocation"];

            }
            else
                OfferLetterDetails = null;

            return OfferLetterDetails;
        }
    }
}
