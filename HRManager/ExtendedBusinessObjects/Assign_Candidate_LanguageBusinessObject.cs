using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;

namespace HRManager.BusinessObjects
{
  public partial  class Assign_Candidate_LanguageBusinessObject
    {
        /// <summary>
        /// Get Language By  Candidate
        /// </summary>
        /// <param name="ZoneName">field contaions Language</param>
        /// <returns>data related given Language in case of success otherwise it return null</returns>
      public Assign_Candidate_Language GetLanguageByCandidate(String Language, int candidateID)
        {
            Assign_Candidate_Language[] Languages = GetLanguages(" CLanguage = '" + Language + "' And CandidateID=" + candidateID);

            if (Languages != null && Languages.Length > 0)
            {
                return Languages[0];
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
      public Assign_Candidate_Language[] GetLanguageByCandidate(int candidateID)
      {
          return GetLanguages(" CandidateID=" + candidateID.ToString());
      }
      /// <summary>
        /// Get Language data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Assign_Candidate_Language object</returns>
        public Assign_Candidate_Language[] GetLanguages(String Filter)
        {
            const String Qry = " SELECT * FROM Assign_Candidate_Language";

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

            Assign_Candidate_Language[]LanguageDetails = new Assign_Candidate_Language[dt.Rows.Count];

            for (int i = 0; i < LanguageDetails.Length; i++)
            {
                LanguageDetails[i] = new Assign_Candidate_Language();
                LanguageDetails[i].ID = (int)dt.Rows[i]["ID"];
                LanguageDetails[i].CandidateID = (int)dt.Rows[i]["CandidateID"];
                LanguageDetails[i].CLanguage = (String)dt.Rows[i]["CLanguage"];
                LanguageDetails[i].CRead = (Boolean)dt.Rows[i]["CRead"];
                LanguageDetails[i].CWrite = (Boolean)dt.Rows[i]["CWrite"];
                LanguageDetails[i].CSpeak = (Boolean)dt.Rows[i]["CSpeak"];
                LanguageDetails[i].CMotherTongue = (Boolean)dt.Rows[i]["CMotherTongue"];

            }

            return LanguageDetails;
        }

        public Assign_Candidate_Language GetLanguageCandidateID(int CandidateID)
        {
            const String Qry = " Select ID,CandidateID FROM Assign_Candidate_Language WHERE CandidateID = '{0}' ORDER BY ID DESC";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, CandidateID);
            // exQry.Query = string.Format(Qry);

            DataTable dt = EE.ExecuteDataTable(exQry);
            Assign_Candidate_Language Details = new Assign_Candidate_Language();
            if (dt.Rows.Count > 0)
            {
                Details.ID = (int)dt.Rows[0]["ID"];
                Details.CandidateID = (int)dt.Rows[0]["CandidateID"];
            }

            return Details;
        }
       
    }
}
