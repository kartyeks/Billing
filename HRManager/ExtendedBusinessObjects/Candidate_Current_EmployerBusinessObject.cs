using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;

namespace HRManager.BusinessObjects
{
   public partial class Candidate_Current_EmployerBusinessObject
    {
        /// <summary>
        /// Get Language By  Candidate
        /// </summary>
        /// <param name="ZoneName">field contaions Language</param>
        /// <returns>data related given Language in case of success otherwise it return null</returns>
       public Candidate_Current_Employer[] GetCurrentEmplByCandidate(int candidateID)
        {
            return GetCandCurrentEmplDetails(" CandidateID=" + candidateID.ToString());
        }
        /// <summary>
        /// Get Language data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Assign_Candidate_Language object</returns>
       public Candidate_Current_Employer[] GetCandCurrentEmplDetails(String Filter)
        {
            const String Qry = " SELECT * FROM Candidate_Current_Employer";

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

            Candidate_Current_Employer[] GetCurrEmpDetails = new Candidate_Current_Employer[dt.Rows.Count];

            for (int i = 0; i < GetCurrEmpDetails.Length; i++)
            {
                GetCurrEmpDetails[i] = new Candidate_Current_Employer();
                GetCurrEmpDetails[i].ID = (int)dt.Rows[i]["ID"];
                GetCurrEmpDetails[i].CandidateID = (int)dt.Rows[i]["CandidateID"];
                GetCurrEmpDetails[i].Address = (String)dt.Rows[i]["Address"];
                GetCurrEmpDetails[i].AnnualSalesTurnOver = (String)dt.Rows[i]["AnnualSalesTurnOver"];
                GetCurrEmpDetails[i].BusinessNature = (String)dt.Rows[i]["BusinessNature"];
                GetCurrEmpDetails[i].Current_AnnualBonus = (double)dt.Rows[i]["Current_AnnualBonus"];
                GetCurrEmpDetails[i].Current_Basic = (double)dt.Rows[i]["Current_Basic"];
                GetCurrEmpDetails[i].Current_ClubMembership = (double)dt.Rows[i]["Current_ClubMembership"];
                GetCurrEmpDetails[i].Current_Conveyance = (double)dt.Rows[i]["Current_Conveyance"];
                GetCurrEmpDetails[i].Current_DA = (double)dt.Rows[i]["Current_DA"];
                GetCurrEmpDetails[i].Current_GrossSalary = (double)dt.Rows[i]["Current_GrossSalary"];
                GetCurrEmpDetails[i].Current_HRA = (double)dt.Rows[i]["Current_HRA"];
                GetCurrEmpDetails[i].Current_LTA = (double)dt.Rows[i]["Current_LTA"];
                GetCurrEmpDetails[i].Current_Medical = (double)dt.Rows[i]["Current_Medical"];
                GetCurrEmpDetails[i].Current_MonthlyCTC = (double)dt.Rows[i]["Current_MonthlyCTC"];
                GetCurrEmpDetails[i].Current_OtherAllowance = (double)dt.Rows[i]["Current_OtherAllowance"];
                GetCurrEmpDetails[i].Current_Others = (double)dt.Rows[i]["Current_Others"];
                GetCurrEmpDetails[i].CurrentDesignation = (String)dt.Rows[i]["CurrentDesignation"];
                GetCurrEmpDetails[i].DesignationEffectFrom = (DateTime)dt.Rows[i]["DesignationEffectFrom"];
                GetCurrEmpDetails[i].EmployerName = (String)dt.Rows[i]["EmployerName"];
                GetCurrEmpDetails[i].IsGratuity = (bool)dt.Rows[i]["IsGratuity"];
                GetCurrEmpDetails[i].IsPF = (bool)dt.Rows[i]["IsPF"];
                GetCurrEmpDetails[i].IsSuperAnnuation = (bool)dt.Rows[i]["IsSuperAnnuation"];
                GetCurrEmpDetails[i].JoinDate = (DateTime)dt.Rows[i]["JoinDate"];
                GetCurrEmpDetails[i].JoinDesignation = (String)dt.Rows[i]["JoinDesignation"];
                GetCurrEmpDetails[i].Joining_AnnualBonus = (double)dt.Rows[i]["Joining_AnnualBonus"];
                GetCurrEmpDetails[i].Joining_Basic = (double)dt.Rows[i]["Joining_Basic"];
                GetCurrEmpDetails[i].Joining_ClubMembership = (double)dt.Rows[i]["Joining_ClubMembership"];
                GetCurrEmpDetails[i].Joining_Conveyance = (double)dt.Rows[i]["Joining_Conveyance"];
                GetCurrEmpDetails[i].Joining_DA = (double)dt.Rows[i]["Joining_DA"];
                GetCurrEmpDetails[i].Joining_GrossSalary = (double)dt.Rows[i]["Joining_GrossSalary"];
                GetCurrEmpDetails[i].Joining_HRA = (double)dt.Rows[i]["Joining_HRA"];
                GetCurrEmpDetails[i].Joining_LTA = (double)dt.Rows[i]["Joining_LTA"];
                GetCurrEmpDetails[i].Joining_Medical = (double)dt.Rows[i]["Joining_Medical"];
                GetCurrEmpDetails[i].Joining_MonthlyCTC = (double)dt.Rows[i]["Joining_MonthlyCTC"];
                GetCurrEmpDetails[i].Joining_OtherAllowance = (double)dt.Rows[i]["Joining_OtherAllowance"];
                GetCurrEmpDetails[i].Joining_Others = (double)dt.Rows[i]["Joining_Others"];
                GetCurrEmpDetails[i].NoOfEmployess = (int)dt.Rows[i]["NoOfEmployess"];
                GetCurrEmpDetails[i].Others = (String)dt.Rows[i]["Others"];
                GetCurrEmpDetails[i].Remarks = (String)dt.Rows[i]["Remarks"];
                GetCurrEmpDetails[i].ReportingOfficer = (String)dt.Rows[i]["ReportingOfficer"];
                GetCurrEmpDetails[i].ReportingOfficerDesignation = (String)dt.Rows[i]["ReportingOfficerDesignation"];
                GetCurrEmpDetails[i].ReportingOfficerMobileNo = (String)dt.Rows[i]["ReportingOfficerMobileNo"];
                GetCurrEmpDetails[i].ReportingOfficerTeleNo = (String)dt.Rows[i]["ReportingOfficerTeleNo"];
                GetCurrEmpDetails[i].Responsible = (String)dt.Rows[i]["Responsible"];
                GetCurrEmpDetails[i].JobResponsibilities = (String)dt.Rows[i]["JobResponsibilities"];
                GetCurrEmpDetails[i].WeeklyOff = (String)dt.Rows[i]["WeeklyOff"];
                GetCurrEmpDetails[i].ReportingOfficerEmailID = (String)dt.Rows[i]["ReportingOfficerEmailID"];

            }
            return GetCurrEmpDetails;
        }
    }
}
