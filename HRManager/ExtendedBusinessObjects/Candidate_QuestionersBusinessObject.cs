using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;

namespace HRManager.BusinessObjects
{
   public partial class Candidate_QuestionersBusinessObject
    {
        /// <summary>
        /// Get Language By  Candidate
        /// </summary>
        /// <param name="ZoneName">field contaions Language</param>
        /// <returns>data related given Language in case of success otherwise it return null</returns>
       public Candidate_Questioners[] GetQuestionersByCandidate(int candidateID)
        {
            return GetCandQuestionersDetails(" CandidateID=" + candidateID.ToString());
        }
        /// <summary>
        /// Get Language data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Assign_Candidate_Language object</returns>
       public Candidate_Questioners[] GetCandQuestionersDetails(String Filter)
        {
            const String Qry = " SELECT * FROM Candidate_Questioners";

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

            Candidate_Questioners[] GetPrevEmpDetails = new Candidate_Questioners[dt.Rows.Count];

            for (int i = 0; i < GetPrevEmpDetails.Length; i++)
            {
                GetPrevEmpDetails[i] = new Candidate_Questioners();
                GetPrevEmpDetails[i].ID = (int)dt.Rows[i]["ID"];
                GetPrevEmpDetails[i].CandidateID = (int)dt.Rows[i]["CandidateID"];
                GetPrevEmpDetails[i].Achievements = (String)dt.Rows[i]["Achievements"];
                GetPrevEmpDetails[i].AlreadyInterviewed = (bool)dt.Rows[i]["AlreadyInterviewed"];
                GetPrevEmpDetails[i].Challenges = (String)dt.Rows[i]["Challenges"];
                GetPrevEmpDetails[i].CommitmentYears = (short)dt.Rows[i]["CommitmentYears"];
                GetPrevEmpDetails[i].EmployeerRemarks = (String)dt.Rows[i]["EmployeerRemarks"];
                GetPrevEmpDetails[i].ExpectedMonthlyGross = (double)dt.Rows[i]["ExpectedMonthlyGross"];
                GetPrevEmpDetails[i].ExpectedMonthlyTakeHome = (double)dt.Rows[i]["ExpectedMonthlyTakeHome"];
                GetPrevEmpDetails[i].ExpectedYearlyCTC = (double)dt.Rows[i]["ExpectedYearlyCTC"];
                GetPrevEmpDetails[i].FunctionalArea = (String)dt.Rows[i]["FunctionalArea"];
                GetPrevEmpDetails[i].Goals = (String)dt.Rows[i]["Goals"];
                GetPrevEmpDetails[i].InBond = (bool)dt.Rows[i]["InBond"];
                GetPrevEmpDetails[i].WhyISutie = (String)dt.Rows[i]["WhyISutie"];
                GetPrevEmpDetails[i].PlaningForStudies = (bool)dt.Rows[i]["PlaningForStudies"];
                GetPrevEmpDetails[i].WillingToRelocate = (bool)dt.Rows[i]["WillingToRelocate"];
                GetPrevEmpDetails[i].InterviewedPosistion = (String)dt.Rows[i]["InterviewedPosistion"];
                GetPrevEmpDetails[i].NoticePeriod = (short)dt.Rows[i]["NoticePeriod"];
                GetPrevEmpDetails[i].PlaningForStudies = (bool)dt.Rows[i]["PlaningForStudies"];
                GetPrevEmpDetails[i].Ref1_Address = (String)dt.Rows[i]["Ref1_Address"];
                GetPrevEmpDetails[i].Ref1_MobileNumber = (String)dt.Rows[i]["Ref1_MobileNumber"];
                GetPrevEmpDetails[i].Ref1_Name = (String)dt.Rows[i]["Ref1_Name"];
                GetPrevEmpDetails[i].Ref1_PhoneNumber = (String)dt.Rows[i]["Ref1_PhoneNumber"];
                GetPrevEmpDetails[i].Ref2_Address = (String)dt.Rows[i]["Ref2_Address"];
                GetPrevEmpDetails[i].Ref2_MobileNumber = (String)dt.Rows[i]["Ref2_MobileNumber"];
                GetPrevEmpDetails[i].Ref2_Name = (String)dt.Rows[i]["Ref2_Name"];
                GetPrevEmpDetails[i].Ref2_PhoneNumber = (String)dt.Rows[i]["Ref2_PhoneNumber"];
                GetPrevEmpDetails[i].SelfDetails = (String)dt.Rows[i]["SelfDetails"];
                GetPrevEmpDetails[i].PlaningForStudydetails = (String)dt.Rows[i]["PlaningForStudydetails"];
                GetPrevEmpDetails[i].RelocatePlace = (String)dt.Rows[i]["RelocatePlace"];
                GetPrevEmpDetails[i].BondDetails = (String)dt.Rows[i]["BondDetails"];

                GetPrevEmpDetails[i].ReferenceCheckerID = (int)dt.Rows[i]["ReferenceCheckerID"];
                GetPrevEmpDetails[i].Ref1_Remarks = (String)dt.Rows[i]["Ref1_Remarks"];
                GetPrevEmpDetails[i].Ref2_Remarks = (String)dt.Rows[i]["Ref2_Remarks"];
                GetPrevEmpDetails[i].Ref_Remarks = (String)dt.Rows[i]["Ref_Remarks"];
                GetPrevEmpDetails[i].Status = (bool)dt.Rows[i]["Status"];
            }
            return GetPrevEmpDetails;
        }



    }
}
