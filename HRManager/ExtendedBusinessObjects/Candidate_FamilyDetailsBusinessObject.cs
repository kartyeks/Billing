using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;

namespace HRManager.BusinessObjects
{
    public partial class Candidate_FamilyDetailsBusinessObject
    {
        /// <summary>
        /// Get Language By  Candidate
        /// </summary>
        /// <param name="ZoneName">field contaions Language</param>
        /// <returns>data related given Language in case of success otherwise it return null</returns>
        public Candidate_FamilyDetails GetFamilydetailsByCandidate(String Name, int candidateID)
        {
            Candidate_FamilyDetails[] FamilyDetails = GetFamilyDetails(" Name = '" + Name + "' And CandidateID=" + candidateID);

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
        public Candidate_FamilyDetails[] GetFamilydetailsByCandidate(int candidateID)
        {
           //return GetFamilyDetails(" CandidateID=" + candidateID.ToString());
            return GetFamilyDetails(" CandidateID='" + candidateID.ToString() + "' And IsActive= 1");
        }
        /// <summary>
        /// Get Language data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Assign_Candidate_Language object</returns>
        public Candidate_FamilyDetails[] GetFamilyDetails(String Filter)
        {
            const String Qry = " SELECT * FROM Candidate_FamilyDetails";

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

            Candidate_FamilyDetails[] GetFamilyDetails = new Candidate_FamilyDetails[dt.Rows.Count];

            for (int i = 0; i < GetFamilyDetails.Length; i++)
            {
                 GetFamilyDetails[i] = new Candidate_FamilyDetails();
                 GetFamilyDetails[i].ID = (int)dt.Rows[i]["ID"];
                 GetFamilyDetails[i].CandidateID = (int)dt.Rows[i]["CandidateID"];
                 GetFamilyDetails[i].RelationID = (int)dt.Rows[i]["RelationID"];
                 GetFamilyDetails[i].Name = (String)dt.Rows[i]["Name"];
                if(dt.Rows[i]["DateOfBirth"].ToString()!=string.Empty)
                 GetFamilyDetails[i].DateOfBirth = (DateTime)dt.Rows[i]["DateOfBirth"];
                if (dt.Rows[i]["Occupation"].ToString() != string.Empty)
                 GetFamilyDetails[i].Occupation = (String)dt.Rows[i]["Occupation"];
                if (dt.Rows[i]["AnnualIncome"].ToString() != string.Empty)
                 GetFamilyDetails[i].AnnualIncome = (String)dt.Rows[i]["AnnualIncome"];
            }

            return GetFamilyDetails;
        }

        public DataTable GetFamilyDetailsforReport(int CandidateId)
        {
            const String Qry = " SELECT MR.RelationName Relation,CF.Name,CF.DateOfBirth,CF.Occupation,CF.AnnualIncome FROM Candidate_FamilyDetails CF "
                                + " INNER JOIN Master_Relation MR ON CF.RelationID = MR.ID  Where CF.CandidateID={0} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry,CandidateId);

            return EE.ExecuteDataTable(exQry);
        }

        /// <summary>
        /// check Language Existance in the database.
        /// </summary>
        /// <param name="Role">field contains Language</param>
        /// <param name="ID">field contains Language ID</param>
        /// <returns>True for Exist and false for not exist</returns>
        public bool IsFamilyDetailsExists(String Name, int ID, int candidateID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Candidate_FamilyDetails WHERE Name = '{0}' AND ID<>{1} AND CandidateID={2})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, Name, ID.ToString(), candidateID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }

        public Candidate_FamilyDetails GetFamilyCandidateID(int CandidateID)
        {
            const String Qry = " Select ID,CandidateID FROM Candidate_FamilyDetails WHERE CandidateID = '{0}'";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, CandidateID);
            // exQry.Query = string.Format(Qry);

            DataTable dt = EE.ExecuteDataTable(exQry);
            Candidate_FamilyDetails Details = new Candidate_FamilyDetails();
            if (dt.Rows.Count > 0)
            {
                Details.ID = (int)dt.Rows[0]["ID"];
                Details.CandidateID = (int)dt.Rows[0]["CandidateID"];
            }

            return Details;
        }

        public void ISActiveUpdateFamilyDetails(int CandidateID)
        {
            String Qry = " UPDATE Candidate_FamilyDetails SET IsActive=0 WHERE CandidateID = {0} ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = String.Format(Qry, CandidateID);

            EE.ExecuteNonQuery(exQry);
        }
    }
 
}
