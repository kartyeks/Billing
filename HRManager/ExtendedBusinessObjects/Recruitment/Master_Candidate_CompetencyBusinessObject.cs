using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS91.Services.DataBlock;
using System.Data;
using HRManager.DTO;


namespace HRManager.BusinessObjects
{
    public partial class Master_Candidate_CompetencyBusinessObject
    {
        public Master_Candidate_Competency[] GetCandidateCompetency(string Filter)
        {
            String Query = "SELECT * FROM Master_Candidate_Competency";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            if (Filter == "")
                exQry.Query = Query;
            else
                exQry.Query = string.Format(Query) + " WHERE " + Filter;


            DataTable dt = EE.ExecuteDataTable(exQry);
            Master_Candidate_Competency[] DTO = new Master_Candidate_Competency[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Master_Candidate_Competency();
                DTO[i].ID = (int)dt.Rows[i]["ID"];

                DTO[i].CompetencyName = (String)dt.Rows[i]["CompetencyName"];
                DTO[i].CompetencyDescription = (String)dt.Rows[i]["CompetencyDescription"];
                DTO[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                DTO[i].CreatedBy = (int)dt.Rows[i]["CreatedBy"];
                DTO[i].CreatedDate = (DateTime)dt.Rows[i]["CreatedDate"];
                DTO[i].ModifiedBy = (int)dt.Rows[i]["ModifiedBy"];
                DTO[i].ModifiedDate = (DateTime)dt.Rows[i]["ModifiedDate"];

            }

            return DTO;
        }

        public bool IsCandidateCompetencyExists(String CompetencyName, int ID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Master_Candidate_Competency WHERE CompetencyName = '{0}' AND ID<>{1})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";
            CompetencyName = CompetencyName.Replace("'", "''");
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, CompetencyName, ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }

        public bool IsCompetencyUsedIncandidate(int CompetencyID)
        {
            const String Qry = " IF EXISTS ( SELECT ID FROM Candidate_Interview_Result WHERE CompetencyID = '{0}' ) "
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, CompetencyID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }
    }
 }
