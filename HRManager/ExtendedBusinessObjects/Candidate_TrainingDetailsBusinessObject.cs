using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;

namespace HRManager.BusinessObjects
{
    public partial class Candidate_TrainingDetailsBusinessObject
    {
        
        /// <summary>
        /// Get Language By  Candidate
        /// </summary>
        /// <param name="ZoneName">field contaions Language</param>
        /// <returns>data related given Language in case of success otherwise it return null</returns>
        public Candidate_TrainingDetails[] GetTrainingdetailsByCandidate(int candidateID)
        {
           return GetTrainingDetails(" CandidateID=" + candidateID.ToString());
        }
        /// <summary>
        /// Get Language data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Assign_Candidate_Language object</returns>
        public Candidate_TrainingDetails[] GetTrainingDetails(String Filter)
        {
            const String Qry = " SELECT * FROM Candidate_TrainingDetails";

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

            Candidate_TrainingDetails[] GetTrainingDetails = new Candidate_TrainingDetails[dt.Rows.Count];

            for (int i = 0; i < GetTrainingDetails.Length; i++)
            {
                GetTrainingDetails[i] = new Candidate_TrainingDetails();
                GetTrainingDetails[i].ID = (int)dt.Rows[i]["ID"];
                GetTrainingDetails[i].CandidateID = (int)dt.Rows[i]["CandidateID"];
                GetTrainingDetails[i].OrganizedBy = (String)dt.Rows[i]["OrganizedBy"];
                GetTrainingDetails[i].Duration = (String)dt.Rows[i]["Duration"];
                GetTrainingDetails[i].Subject = (String)dt.Rows[i]["Subject"];
                GetTrainingDetails[i].Certificate = (String)dt.Rows[i]["Certificate"];
            }

            return GetTrainingDetails;
        }

        public DataTable GetTrainingDetailsForReport(int CandidateId)
        {
            const String Qry = " SELECT * FROM Candidate_TrainingDetails Where CandidateID = {0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = string.Format(Qry, CandidateId);

            return EE.ExecuteDataTable(exQry);
        }
        
    }
 
}
