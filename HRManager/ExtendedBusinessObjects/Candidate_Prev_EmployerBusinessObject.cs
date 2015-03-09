using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;

namespace HRManager.BusinessObjects
{
  public partial  class Candidate_Prev_EmployerBusinessObject
    {
        /// <summary>
        /// Get Language By  Candidate
        /// </summary>
        /// <param name="ZoneName">field contaions Language</param>
        /// <returns>data related given Language in case of success otherwise it return null</returns>
        public Candidate_Prev_Employer[] GetPrevEmpByCandidate(int candidateID)
        {
            return GetCandPrevEmpDetails(" CandidateID=" + candidateID.ToString());
        }
        /// <summary>
        /// Get Language data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Assign_Candidate_Language object</returns>
        public Candidate_Prev_Employer[] GetCandPrevEmpDetails(String Filter)
        {
            const String Qry = " SELECT * FROM Candidate_Prev_Employer";

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

            Candidate_Prev_Employer[] GetPrevEmpDetails = new Candidate_Prev_Employer[dt.Rows.Count];

            for (int i = 0; i < GetPrevEmpDetails.Length; i++)
            {
                GetPrevEmpDetails[i] = new Candidate_Prev_Employer();
                GetPrevEmpDetails[i].ID = (int)dt.Rows[i]["ID"];
                GetPrevEmpDetails[i].CandidateID = (int)dt.Rows[i]["CandidateID"];
                GetPrevEmpDetails[i].CTC = (double)dt.Rows[i]["CTC"];
                GetPrevEmpDetails[i].Designation = (String)dt.Rows[i]["Designation"];
                GetPrevEmpDetails[i].EmployerName = (String)dt.Rows[i]["EmployerName"];
                GetPrevEmpDetails[i].EndDate = (DateTime)dt.Rows[i]["EndDate"];
                GetPrevEmpDetails[i].ResonForLeaving = (String)dt.Rows[i]["ResonForLeaving"];
                GetPrevEmpDetails[i].Responsibilities = (String)dt.Rows[i]["Responsibilities"];
                GetPrevEmpDetails[i].StartDate = (DateTime)dt.Rows[i]["StartDate"];
                GetPrevEmpDetails[i].TakeHome = (double)dt.Rows[i]["TakeHome"];
            }

            return GetPrevEmpDetails;
        }

        public DataTable GetCandPrevEmpDetailsForReport(int CandidateId)
        {
            const String Qry = " SELECT * FROM Candidate_Prev_Employer Where CandidateID={0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();


            exQry.Query = string.Format(Qry, CandidateId);
            return EE.ExecuteDataTable(exQry);
        }
    }
}
