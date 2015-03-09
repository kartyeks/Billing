using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;

namespace HRManager.BusinessObjects
{
    public partial class Candidate_SkillsBusinessObject
    {
        /// <summary>
        /// Get Language By  Candidate
        /// </summary>
        /// <param name="ZoneName">field contaions Language</param>
        /// <returns>data related given Language in case of success otherwise it return null</returns>
        public Candidate_Skills[] GetSkillByCandidate(int candidateID)
        {
            return GetSkillDetails(" CandidateID=" + candidateID.ToString());
        }
        /// <summary>
        /// Get Language By  Candidate
        /// </summary>
        /// <param name="ZoneName">field contaions Language</param>
        /// <returns>data related given Language in case of success otherwise it return null</returns>
        public Candidate_Skills GetSkilldetailsByCandidate(String Name, int candidateID)
        {
            Candidate_Skills[] SkillDetails = GetSkillDetails(" skillset = '" + Name + "' And CandidateID=" + candidateID);

            if (SkillDetails != null && SkillDetails.Length > 0)
            {
                return SkillDetails[0];
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
        public Candidate_Skills[] GetSkilldetailsByCandidate(int candidateID)
        {
           return GetSkillDetails(" CandidateID=" + candidateID.ToString());
        }
        /// <summary>
        /// Get Language data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Assign_Candidate_Language object</returns>
        public Candidate_Skills[] GetSkillDetails(String Filter)
        {
            const String Qry = " SELECT * FROM Candidate_Skills";

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

            Candidate_Skills[] GetSkillDetails = new Candidate_Skills[dt.Rows.Count];

            for (int i = 0; i < GetSkillDetails.Length; i++)
            {
                GetSkillDetails[i] = new Candidate_Skills();
                 GetSkillDetails[i].ID = (int)dt.Rows[i]["ID"];
                 GetSkillDetails[i].CandidateID = (int)dt.Rows[i]["CandidateID"];
                 GetSkillDetails[i].SkillSet = (String)dt.Rows[i]["SkillSet"];
                if(dt.Rows[i]["NoOfMonths"].ToString()!=string.Empty)
                 GetSkillDetails[i].NoOfMonths = (short)dt.Rows[i]["NoOfMonths"];
                if (dt.Rows[i]["LastApplied"].ToString() != string.Empty)
                 GetSkillDetails[i].LastApplied = (String)dt.Rows[i]["LastApplied"];
            }

            return GetSkillDetails;
        }

        /// <summary>
        /// check Language Existance in the database.
        /// </summary>
        /// <param name="Role">field contains Language</param>
        /// <param name="ID">field contains Language ID</param>
        /// <returns>True for Exist and false for not exist</returns>
        public bool IsSkillDetailsExists(String SkillSet, int ID, int candidateID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Candidate_Skills WHERE SkillSet = '{0}' AND ID<>{1} AND CandidateID={2})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, SkillSet, ID.ToString(), candidateID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }
    }
 
}
