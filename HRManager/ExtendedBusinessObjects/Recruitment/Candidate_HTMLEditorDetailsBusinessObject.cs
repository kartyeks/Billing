using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;
using IS91.Services.DataBlock;
using System.Data;

namespace HRManager.BusinessObjects
{
    public partial class Candidate_HTMLEditorDetailsBusinessObject
    {
        public Candidate_HTMLEditorDetails[] GetCandidateHTMLDetails(string Filter)
        {
            String Query = "SELECT * FROM Candidate_HTMLEditorDetails";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            if (Filter == "")
                exQry.Query = Query;
            else
                exQry.Query = string.Format(Query) + " WHERE " + Filter;


            DataTable dt = EE.ExecuteDataTable(exQry);
            Candidate_HTMLEditorDetails[] DTO = new Candidate_HTMLEditorDetails[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Candidate_HTMLEditorDetails();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].CandidateID = (int)dt.Rows[i]["CandidateID"];
                DTO[i].HTMLContent = (String)dt.Rows[i]["HTMLContent"];
                DTO[i].EditedByUser = (int)dt.Rows[i]["EditedByUser"];
                DTO[i].EditedDateTime = (DateTime)dt.Rows[i]["EditedDateTime"];
                DTO[i].HTMLFileName = (String)dt.Rows[i]["HTMLFileName"];
            }
            return DTO;
        }

        public bool DoesCandidateLetterExists(int CandidateID, string fileName)
        {
            const String Qry = " IF EXISTS (SELECT CandidateID FROM Candidate_HTMLEditorDetails WHERE CandidateID = {0} AND HTMLFileName = '{1}')"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, CandidateID, fileName);
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }

        public DataTable getCandidateLetter(int CandidateID, string fileName)
        {
            const String Qry = "SELECT * FROM Candidate_HTMLEditorDetails " +
                              " WHERE CandidateID = {0} AND HTMLFileName = '{1}'";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, CandidateID, fileName);
            return EE.ExecuteDataTable(exQry);

        }
    }
}
