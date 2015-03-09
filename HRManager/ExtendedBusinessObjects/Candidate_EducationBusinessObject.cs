using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;

namespace HRManager.BusinessObjects
{
  public partial  class Candidate_EducationBusinessObject
    {
        /// <summary>
        /// Get Language By  Candidate
        /// </summary>
        /// <param name="ZoneName">field contaions Language</param>
        /// <returns>data related given Language in case of success otherwise it return null</returns>
      public Candidate_Education GetEducationByCandidate(String Title, int candidateID)
        {
            Candidate_Education[] FamilyDetails = GetEducationDetails(" Title = '" + Title + "' And CandidateID=" + candidateID);

            if (FamilyDetails != null && FamilyDetails.Length > 0)
            {
                return FamilyDetails[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Get Language By  Candidate
        /// </summary>
        /// <param name="ZoneName">field contaions Language</param>
        /// <returns>data related given Language in case of success otherwise it return null</returns>
      public Candidate_Education[] GetEducationByCandidate(int candidateID)
        {
            return GetEducationDetails(" CandidateID=" + candidateID.ToString());
        }
        /// <summary>
        /// Get Language data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Assign_Candidate_Language object</returns>
        public Candidate_Education[] GetEducationDetails(String Filter)
        {
            const String Qry = " SELECT * FROM Candidate_Education";

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

            Candidate_Education[] GetEducationDetails = new Candidate_Education[dt.Rows.Count];

            for (int i = 0; i < GetEducationDetails.Length; i++)
            {
                GetEducationDetails[i] = new Candidate_Education();
                GetEducationDetails[i].ID = (int)dt.Rows[i]["ID"];
                GetEducationDetails[i].CandidateID = (int)dt.Rows[i]["CandidateID"];
                GetEducationDetails[i].Title = (String)dt.Rows[i]["Title"];
                if(dt.Rows[i]["Subject"].ToString()!=string.Empty)
                GetEducationDetails[i].Subject = (String)dt.Rows[i]["Subject"];
                if (dt.Rows[i]["Institute"].ToString() != string.Empty)
                GetEducationDetails[i].Institute = (String)dt.Rows[i]["Institute"];
                if (dt.Rows[i]["Percentage"].ToString() != string.Empty)
                    GetEducationDetails[i].Percentage = (double)dt.Rows[i]["Percentage"];
                else
                    GetEducationDetails[i].Percentage = (double)(0);
                if (dt.Rows[i]["Grade"].ToString() != string.Empty)
                GetEducationDetails[i].Grade = (String)dt.Rows[i]["Grade"];
                if (dt.Rows[i]["FromDate"].ToString() != string.Empty)
                GetEducationDetails[i].FromDate = (DateTime)dt.Rows[i]["FromDate"];
                if (dt.Rows[i]["ToDate"].ToString() != string.Empty)
                GetEducationDetails[i].ToDate = (DateTime)dt.Rows[i]["ToDate"];

            }

            return GetEducationDetails;
        }

        public DataTable GetEducationDetailsForReport(int CandidateId)
        {
            const String Qry = " SELECT * FROM Candidate_Education Where CandidateID={0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, CandidateId);
            return EE.ExecuteDataTable(exQry);
        }

        
    }
}
