using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS91.Services.DataBlock;
using System.Data;
using HRManager.DTO;
using HRManager.DTOEXT.Recruitment;
using IRCAKernel;

namespace HRManager.BusinessObjects
{
    public partial class Candidate_Education_DetailsBusinessObject
    {
        private Candidate_Education_Details[] GetEducationDetails(string Filter)
        {
            String Query = "SELECT * FROM Candidate_Education_Details";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            if (Filter == "")
                exQry.Query = Query;
            else
                exQry.Query = string.Format(Query) + " WHERE " + Filter;


            DataTable dt = EE.ExecuteDataTable(exQry);
            Candidate_Education_Details[] DTO = new Candidate_Education_Details[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Candidate_Education_Details();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].CandidateID = (int)dt.Rows[i]["CandidateID"];
                DTO[i].Education = (String)dt.Rows[i]["Education"];
                DTO[i].Stream = (String)dt.Rows[i]["Stream"];
                DTO[i].University = (String)dt.Rows[i]["University"];
                DTO[i].Year = (int)dt.Rows[i]["Year"];
                DTO[i].Percentage = (double)dt.Rows[i]["Percentage"];
            }
            return DTO;
        }

        public Candidate_Education_DetailsEXT[] GetCandidateEducationDetailsByID(int CandidateID)
        {

            String Query = " SELECT " 
	                        + "     Row_Number() OVER(partition By CandidateID order by ID) AS LocalGridID, "
	                        + "     ID, "
	                        + "     CandidateID, "
	                        + "     Education, "
	                        + "     Stream, "
	                        + "     University, "
	                        + "     Year, "
	                        + "     Percentage "
                            + " FROM " 
	                        + "     Candidate_Education_Details "
                            + " WHERE "
                            + "     CandidateID = {0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = String.Format(Query,CandidateID);

            DataTable dt = EE.ExecuteDataTable(exQry);
            Candidate_Education_DetailsEXT[] DTO = new Candidate_Education_DetailsEXT[dt.Rows.Count];

            for (int i = 0; i < DTO.Length; i++)
            {
                DTO[i] = new Candidate_Education_DetailsEXT();
                DTO[i].ID = (int)dt.Rows[i]["ID"];
                DTO[i].LocalGridID = (Int64)dt.Rows[i]["LocalGridID"];
                DTO[i].CandidateID = (int)dt.Rows[i]["CandidateID"];
                DTO[i].Education = (String)dt.Rows[i]["Education"];
                DTO[i].Stream = (String)dt.Rows[i]["Stream"];
                DTO[i].University = (String)dt.Rows[i]["University"];
                DTO[i].Year = (int)dt.Rows[i]["Year"];
                DTO[i].Percentage = (double)dt.Rows[i]["Percentage"];
            }
            return DTO;
        }

        public int DeleteEducation(int TableID)
        {
            try
            {
                String Query = "Delete FROM Candidate_Education_Details Where ID = {0}";

                ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
                ExecutionQuery exQry = new ExecutionQuery();

                exQry.Query = String.Format(Query, TableID);

                int noOfRows = EE.ExecuteNonQuery(exQry);
                return noOfRows;
            }
            catch (Exception ee)
            {
                IRCAExceptionHandler.HandleException(ee);
                return 0;
            }
        }
    }
}
