using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRCA.Communication;
using HRManager.Communication.Request;
using HRManager.Entity;
using IRCAKernel;
using HRManager.Communication.Response;
using HRManager.DTO;
using HRManager.Entity.EmployeeLeave;
using HRManager.DTOEXT;
using HRManager.BusinessObjects;
using HRManager.Entity.ExitManagement;
using HRManager.Entity.Appraisal;
using HRManager.Entity.Recruitment;
using System.Data;
using HRManager.Communication;

namespace HRManager
{
    public class HRRequestHandler : IRCARequestHandler
    {

        public override String[] GetCommands()
        {
            if (_Commands.ContainsKey(typeof(HRAppCommands).Name))
            {
                return _Commands[typeof(HRAppCommands).Name].ToArray();
            }

            return new String[0];
        }


        public override CommunicationObject ProcessRequest(String RequestCommand, String RequestData)
        {

            CommunicationObject Response = null;
            CommunicationObject RequestDataObject = new CommunicationObject(RequestData);
            try
            {
                if (RequestCommand == HRAppCommands.GET_MENUSTRING)
                {
                    Response = GetMenuString(RequestDataObject);
                }

                else if (RequestCommand == HRAppCommands.SETTING_CONFIGURATION_DETAILS)
                {
                    Response = GetSettingConfiguration(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.UPDATE_SETTING_CONFIGURATION)
                {
                    Response = UpdateSettingConfiguration(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.GET_ALL_DESIGNATION_DETAILS)
                {
                    Response = GetAllDesignationDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.GET_ALL_TEAM_DETAILS)
                {
                    Response = GetAllTypeTeamDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.GET_ALL_RELATION_DETAILS)
                {
                    Response = GetAllRelationDetails(RequestDataObject);
                }
                //kartyek 13.2.2015 for InvestmentGroup
                else if (RequestCommand == HRAppCommands.GET_ALL_INVESTMENTGROUP_DETAILS)
                {
                    Response = GetAllInvestmentDetails(RequestDataObject);
                }





                else if (RequestCommand == HRAppCommands.GET_ALL_ROLETYPE_DETAILS)
                {
                    Response = GetAllRoleTypeDetails(RequestDataObject);
                }


                else if (RequestCommand == HRAppCommands.DESIGNATION_DETAILS)
                {
                    Response = GetAllDesignationDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.DESIGNATION_HIRE_INFO)
                {
                    Response = GetAllDesignationForHigher(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.DESIGNATION_INFO)
                {
                    Response = GetDesignationInfo(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.DEACTIVATE_DESIGNATION)
                {
                    Response = DeActivateDesignation(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.ACTIVATE_DESIGNATION)
                {
                    Response = ActivateDesignation(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.UPDATE_DESIGNATION)
                {
                    Response = UpdateDesignation(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.DESIGNATIONCOMBO_DETAILS)
                {
                    Response = GetDesignationComboDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.ROLE_COMBO)
                {
                    Response = GetRoleCombo(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.INACTIVE_DESIGNATION)
                {
                    Response = GetInActiveDesignation(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.DEPARTMENT_DETAILS)
                {
                    Response = GetDepartmentDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.UPDATE_DEPARTMENT)
                {
                    Response = UpdateDepartment(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.DEPARTMENT_HOD_DETAILS)
                {
                    Response = GetDepartmentHOD(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.DEPARTMENTCOMBO_DETAILS)
                {
                    Response = GetDeptComboDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.COMBOEMPTYPE_DETAILS)
                {
                    Response = GetEmployeeTypeCombo(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.EMPLOYEETYPE_DETAILS)
                {
                    Response = GetEmployeeTypeDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.DEACTIVATE_EMPLOYEETYPE)
                {
                    Response = DeActivateEmployeeType(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.ACTIVATE_EMPLOYEETYPE)
                {
                    Response = ActivateEmployeeType(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.INACTIVE_EMPLOYEETYPE)
                {
                    Response = GetInActiveEmployeeType(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.UPDATE_EMPLOYEETYPE)
                {
                    Response = UpdateEmployeeType(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.ROLE_MASTER_DETAILS)
                {
                    Response = GetRoleDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.DEACTIVATE_ROLE)
                {
                    Response = DeActivateRole(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.ACTIVATE_ROLE)
                {
                    Response = ActivateRole(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.INACTIVE_ROLE)
                {
                    Response = GetInActiveRole(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.UPDATE_ROLE)
                {
                    Response = UpdateRole(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.ROLE_REPORTSINFO)
                {
                    Response = GetRoleWiseDashboardReports(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.DASHBOARDREPORTS_DETAILS)
                {
                    Response = GetDashBoardReports(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.PERMISSION_DETAILS)
                {
                    Response = GetAllPermissions(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.GET_COUNTRY_DETAILS)
                {
                    Response = GetcountryDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.GET_ALL_COUNTRY_DETAILS)
                {
                    Response = GetCompletecountryDetails(RequestDataObject);
                }

                else if (RequestCommand == HRAppCommands.GET_ALL_MARITALSTATUS_DETAILS)
                {
                    Response = GetCompletemaritalstatusDetails(RequestDataObject);
                }

                else if (RequestCommand == HRAppCommands.GET_ALL_ASSET_DETAILS)
                {
                    Response = GetCompleteassetstatusDetails(RequestDataObject);
                }

                //kartyek 5.2.2015 Loan Management Requests
                else if (RequestCommand == HRAppCommands.LOAN_DETAILS)
                {
                    Response = GetLoanDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.UPDATE_LOAN)
                {
                    Response = UpdateLoan(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.DEACTIVATE_LOAN)
                {
                    Response = DeActivateLoan(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.ACTIVATE_LOAN)
                {
                    Response = ActivateLoan(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.INACTIVE_LOAN)
                {
                    Response = GetInActiveLoan(RequestDataObject);
                }

                else if (RequestCommand == HRAppCommands.COMBOLOAN_DETAILS)
                {
                    Response = GetLoanComboDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.LOANAMOUNTBYLOAN)
                {
                    Response = GetLoanAmountByLoanId(RequestDataObject);
                }
                //kartyek 7.2.2015 Loan Management Requests advance type

                else if (RequestCommand == LoanAppCommands.ADVANCE_TYPE_DETAILS)
                {
                    Response = GetAdvanceTypeDetails(RequestDataObject);
                }
                else if (RequestCommand == LoanAppCommands.UPDATE_ADVANCE_TYPE)
                {
                    Response = UpdateAdvanceType(RequestDataObject);
                }
                else if (RequestCommand == LoanAppCommands.ACTIVATE_ADVANCE_TYPE)
                {
                    Response = ActivateAdvanceType(RequestDataObject);
                }
                else if (RequestCommand == LoanAppCommands.DEACTIVATE_ADVANCE_TYPE)
                {
                    Response = DeActivateAdvanceType(RequestDataObject);
                }
                else if (RequestCommand == LoanAppCommands.INACTIVE_ADVANCE_TYPE)
                {
                    Response = GetInActiveAdvanceType(RequestDataObject);
                }




                else if (RequestCommand == HRAppCommands.GET_ALL_SUB_ASSET_DETAILS)
                {
                    Response = GetCompleteassetsubstatusDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.GET_ALL_CONSULTANT_DETAILS)
                {
                    Response = GetCompleteConsultantDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.GET_ALL_HOLIDAY_DETAILS)
                {
                    Response = GetCompleteHolidayDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.GET_ALL_INTERVIEW_DETAILS)
                {
                    Response = GetCompleteInterviewTypeDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.GET_ALL_MANUFACTURER_DETAILS)
                {
                    Response = GetCompleteManufacturerDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.GET_ALL_CANDIDATE_COMPETENCY_DETAILS)
                {
                    Response = GetCompleteCandidatecompetencyDetails(RequestDataObject);
                }

                else if (RequestCommand == HRAppCommands.COUNTRY_COMBO_DETAILS)
                {
                    Response = GetcountryDetailscombo(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.INVESTMENT_COMBO_DETAILS)
                {
                    Response = GetInvestmentDetailscombo(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.COMPANY_COMBO_DETAILS)
                {
                    Response = GetcompanyDetailscombo(RequestDataObject);
                }



                else if (RequestCommand == HRAppCommands.ASSET_COMBO_DETAILS)
                {
                    Response = GetAssetcombo(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.ASSETSUB_COMBO_DETAILS)
                {
                    Response = GetAssetSubcombo(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.RELATION_DETAILS)
                {
                    Response = GetRelationDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.DEACTIVATE_RELATION)
                {
                    Response = DeActivateRelation(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.ACTIVATE_RELATION)
                {
                    Response = ActivateRelation(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.UPDATE_RELATION)
                {
                    Response = UpdateRelation(RequestDataObject);
                }
                //kartyek for InvestmentGroup
                //else if (RequestCommand == HRAppCommands.GET_ALL_INVESTMENTGROUP_DETAILS)
                //{
                //    Response = GetAllInvestmentDetails(RequestDataObject);
                //}
                else if (RequestCommand == HRAppCommands.GET_ALL_COMPANY_DETAILS)
                {
                    Response = GetAllcompanyDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.UPDATE_COMPANY)
                {
                    Response = UpdateCompany(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.DEACTIVATE_COMPANY)
                {
                    Response = DeActivateCompany(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.ACTIVATE_COMPANY)
                {
                    Response = ActivateCompany(RequestDataObject);
                }

                    //kartyek 14.2.2015 Company details
                else if (RequestCommand == HRAppCommands.UPDATE_INVESTMENTGROUP)
                {
                    Response = UpdateInvestmentGroup(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.DEACTIVATE_INVESTMENTGROUP)
                {
                    Response = DeActivateInvestment(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.ACTIVATE_INVESTMENTGROUP)
                {
                    Response = ActivateInvestment(RequestDataObject);
                }
                //Kartyek 17.02.2015 request for project information/Details
                else if (RequestCommand == HRAppCommands.GET_ALL_PROJECT_DETAILS)
                {
                    Response = GetAllProjectDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.UPDATE_PROJECT)
                {
                    Response = UpdateProjectInfo(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.DEACTIVATE_PROJECT)
                {
                    Response = DeActivateProjectInfo(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.ACTIVATE_PROJECT)
                {
                    Response = ActivateProjectInfo(RequestDataObject);
                }



                else if (RequestCommand == HRAppCommands.INACTIVE_RELATION)
                {
                    Response = GetInActiveRelation(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.GET_ACTIVE_DEACTIVATE_COUNTRY)
                {
                    Response = Getactivedeactivecountry(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.UPDATE_COUNTRY)
                {
                    Response = UpdateCountry(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.INACTIVE_COUNTRY)
                {
                    Response = GetInActiveCountries(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.GET_HOLIDAYS_DETAILS)
                {
                    Response = GetHolidayDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.GET_ACTIVE_DEACTIVATE_HOLIDAYS)
                {
                    Response = Getactivedeactiveholiday(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.UPDATE_HOLIDAYS)
                {
                    Response = UpdateHolidays(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.INACTIVE_HOLIDAYS)
                {
                    Response = GetInActiveHolidays(RequestDataObject);
                }
                //else if (RequestCommand == HRAppCommands.UPDATE_LEAVE_GRADE)
                //{
                //    Response = UpdateLeaveGrade(RequestDataObject);
                //}
                //else if (RequestCommand == HRAppCommands.COMBOLEAVEGRADE_DETAILS)
                //{
                //    Response = GetLeaveGradeCombo(RequestDataObject);
                //}
                else if (RequestCommand == HRAppCommands.GET_LOCATION_COMBO)
                {
                    Response = GetLocationCombo(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.LOCATION_DETAILS)
                {
                    Response = GetLocationDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.DEACTIVATE_LOCATION)
                {
                    Response = DeActivateLocation(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.ACTIVATE_LOCATION)
                {
                    Response = ActivateLocation(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.UPDATE_LOCATION)
                {
                    Response = UpdateLocation(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.INACTIVE_LOCATION)
                {
                    Response = GetInActiveLocation(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.COUNTRY_DETAILS)
                {
                    Response = GetcountryDetailscombo(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.CONSULTANT_DETAILS)
                {
                    Response = GetConsultantDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.DEACTIVATE_CONSULTANT)
                {
                    Response = DeActivateConsultant(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.ACTIVATE_CONSULTANT)
                {
                    Response = ActivateConsultant(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.INACTIVE_CONSULTANT)
                {
                    Response = GetInActiveConsultant(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.UPDATE_CONSULTANT)
                {
                    Response = UpdateConsultant(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.GET_MARITALSTATUS_COMBO)
                {
                    Response = GetMaritalStatusCombo(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.GET_MARITALSTATUS_DETAILS)
                {
                    Response = GetMaritalStatusDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.GET_ACTIVE_DEACTIVATE_MARITALSTATUS)
                {
                    Response = GetactivedeactiveMaritalStatus(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.UPDATE_MARITALSTATUS)
                {
                    Response = UpdateMaritalStatus(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.INACTIVE_MARITALSTATUS)
                {
                    Response = GetInActiveMaritalStatus(RequestDataObject);
                }

                else if (RequestCommand == HRAppCommands.GET_INTERVIEWTYPE_DETAILS)
                {
                    Response = GetInterviewTypeDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.GET_ACTIVE_DEACTIVATE_INTERVIEWTYPE)
                {
                    Response = GetactivedeactiveInterviewType(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.UPDATE_INTERVIEWTYPE)
                {
                    Response = UpdateInterviewType(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.INACTIVE_INTERVIEWTYPE)
                {
                    Response = GetInActiveInterviewType(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.INTERVIEWTYPE_DETAILS)
                {
                    Response = GetInterviewTypeDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.INTERVIEWTYPE_COMBO_DETAILS)
                {
                    Response = GetInterviewTypeCombo(RequestDataObject);
                }

                else if (RequestCommand == HRAppCommands.LEAVE_OVERVIEW_DETAILS)
                {
                    Response = GetLeaveOverviewDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.LEAVE_TYPE_COMBO)
                {
                    Response = GetLeaveTypeCombo(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.LEAVE_REQUEST_DETAILS)
                {
                    Response = GetLeaveRequestDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.CALENDER_LEAVE_DETAIL)
                {
                    Response = GetCalendeLeaveRequest(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.HOLIDAYS_BY_EMPID_DETAILS)
                {
                    Response = GetHolidayDate(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.CALENDER)
                {
                    Response = GetCallender(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.UPDATE_LEAVE_REQUEST)
                {
                    Response = UpdateLeaveRequest(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.DELETE_LEAVE_REQUEST)
                {
                    Response = DeleteLeaveRequest(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.RESETDATE_LEAVE_REQUEST)
                {
                    Response = ResetDateLeaveRequest(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.LEAVE_REQUEST_APPROVAL_DETAILS)
                {
                    Response = GetLeaveRequestApprovalDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.UPDATE_LEAVE_APPROVAL)
                {
                    Response = UpdateLeaveRequestApproval(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.TEAM_COMBO_DETAILS)
                {
                    Response = GetTeamCombo(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.TEAM_DETAILS_BYID)
                {
                    Response = GetAllTeamDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.TEAM_DETAILS)
                {
                    Response = GetTeamDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.UPDATE_TEAM)
                {
                    Response = UpdateTeam(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.ACTIVATE_TEAM)
                {
                    Response = ActivateTeam(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.DEACTIVATE_TEAM)
                {
                    Response = GetDeactiveTeam(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.INACTIVE_TEAM)
                {
                    Response = GetInactiveTeam(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.MANAGER_COMBO_DETAILS)
                {
                    Response = GetManagerCombo(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.INTIMATION)
                {
                    Response = Intimation(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.INTIMATE_FOR_APPRAISAL)
                {
                    Response = IntimateForAppraisal(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.DELETE_INTIMATION)
                {
                    Response = DeleteIntimation(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.IS_GOAL_SUBMISSION_STARTED)
                {
                    Response = IsGoalSubmissionStarted(RequestDataObject);
                }

                else if (RequestCommand == HRAppCommands.GET_TEAM_MEMBER_FOR_APPRAISAL)
                {
                    Response = GetTeamMemberForAppraisal(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.GET_ALL_TEAM_MEMBER_FOR_VIEW)
                {
                    Response = GetTeamMemberForView(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.UPDATE_EMP_APPRAISAL_GRADE)
                {
                    Response = UpdateEmployeeAppraisalGrade(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.GET_ALL_TEAM_MEMBER_FOR_APPRAISAL)
                {
                    Response = GetAllTeamMemberForAppraisal(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.GET_ALL_TEAM_MEMBER_FOR_RATING)
                {
                    Response = GetAllTeamMemberForRating(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.GET_ALL_TEAM_MEMBER_FOR_RATING_VIEW)
                {
                    Response = GetAllTeamMemberForRatingView(RequestDataObject);
                }

                else if (RequestCommand == HRAppCommands.EMPLOYEE_HIKE)
                {
                    Response = EmployeeHike(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.EMPLOYEE_PROMOTE)
                {
                    Response = EmployeePromote(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.GET_ASSETCATEGORY_DETAILS)
                {
                    Response = GetAssetcategoriesDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.GET_ACTIVE_DEACTIVATE_ASSETCATEGORY)
                {
                    Response = GetactivedeactiveAssetCategories(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.UPDATE_ASSETCATEGORY)
                {
                    Response = UpdateAssetCategory(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.INACTIVE_ASSETCATEGORY)
                {
                    Response = GetInActiveAssetCategory(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.ASSETCATEGORY_DETAILS)
                {
                    Response = GetAssetcategoriesDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.DESIGNATION_COMBO_DETAILS)
                {
                    Response = DesignationCombo(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.INTIMATEDATE_COMBO_DETAILS)
                {
                    Response = IntimateDateCombo(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.APPRAISAL_SUMBITTED)
                {
                    Response = AppraisalSumittedNotificaion(RequestDataObject);
                }

                else if (RequestCommand == HRAppCommands.CHECK_ALL_APPRAISAL_DOC_SUBMITTED)
                {
                    Response = CheckAllAppraisalDocSubmitted(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.DELETE_EMPLOYEE_GOALS)
                {
                    Response = DeleteEmployeeGoals(RequestDataObject);
                }

                else if (RequestCommand == HRAppCommands.DELETE_EMPLOYEE_GRADE)
                {
                    Response = DeleteEmployeeGrade(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.GET_ASSETSUBCATEGORY_DETAILS)
                {
                    Response = GetAssetSubcategoriesDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.GET_ACTIVE_DEACTIVATE_ASSETSUBCATEGORY)
                {
                    Response = GetactivedeactiveAssetSubCategories(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.UPDATE_ASSETSUBCATEGORY)
                {
                    Response = UpdateAssetSubCategory(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.INACTIVE_ASSETSUBCATEGORY)
                {
                    Response = GetInActiveAssetSubCategory(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.ASSETSUBCATEGORY_DETAILS)
                {
                    Response = GetAssetSubcategoriesDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.GET_MANUFACTURER_DETAILS)
                {
                    Response = GetManufacturerDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.GET_ACTIVE_DEACTIVATE_MANUFACTURER)
                {
                    Response = GetactivedeactiveManufacturer(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.UPDATE_MANUFACTURER)
                {
                    Response = UpdateManufacturer(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.INACTIVE_MANUFACTURER)
                {
                    Response = GetInActiveManufacturer(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.MANUFACTURER_DETAILS)
                {
                    Response = GetManufacturerDetails(RequestDataObject);
                }

                else if (RequestCommand == HRAppCommands.GET_EXIT_MANAGEMENT_DETAILS)
                {
                    Response = GetExitManagementDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.GET_EMPLOYEE_EXIT_MANAGEMENT_DETAILS)
                {
                    Response = GetEMPExitManagementDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.UPDATE_EXIT_MANAGEMENT)
                {
                    Response = UpdateExitManagement(RequestDataObject);
                }


                else if (RequestCommand == HRAppCommands.GET_CANDIDATECOMPETANCY_DETAILS)
                {
                    Response = GetcandidatecompetencyDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.GET_ACTIVE_DEACTIVATE_CANDIDATECOMPETANCY)
                {
                    Response = Getactivedeactivecandidatecompetency(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.UPDATE_CANDIDATECOMPETANCY)
                {
                    Response = Updatecandidatecompetency(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.INACTIVE_CANDIDATECOMPETANCY)
                {
                    Response = GetInActivecandidatecompetency(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.CANDIDATECOMPETANCY_DETAILS)
                {
                    Response = GetcandidatecompetencyDetails(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.GET_EMP_UPLOADED_ATTENDANCE_GRID)
                {
                    Response = GetUploadedEmpAttanceGrid(RequestDataObject);
                }
                else if (RequestCommand == HRAppCommands.PROJECT_COMBO_DETAILS) //added by archana for project combo load 17/02/2015
                {
                    Response = GetProjectCombo(RequestDataObject);
                }

            }
            catch (IRCAException e)
            {
                IRCAExceptionHandler.HandleException(e);
            }
            catch (Exception e)
            {
                Response = new CommunicationObject();
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, "Unknown Application Error");

                IRCAException Exception = new IRCAException(e
                                , WebResponse.Message
                                , "Request Command = " + RequestCommand
                                  + "\n Request Data " + RequestData
                                  );

                IRCAExceptionHandler.HandleException(Exception);
            }

            return Response;
        }

        //private static CommunicationObject GetMenuString(CommunicationObject RequestDataObject)
        //{
        //    CommunicationObject Response = new CommunicationObject();
        //    UpdateRoleRequest role = new UpdateRoleRequest();
        //    RequestDataObject.UpdateDataObject(role);
        //    string mnu = HRManager.GetMenuString(role.Role);


        //    if (mnu.Length >= 0)
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
        //        Response.SetProperty(WebResponse.ResponseObject, mnu);
        //    }
        //    else
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
        //        Response.SetProperty(WebResponse.Message, String.Empty);
        //    }

        //    return Response;
        //}

        #region Designations

        /// <summary>
        /// Send Request to Entity to Get Department Details
        /// </summary>
        /// <param name="RequestDataObject">Department id in form of Request</param>
        /// <returns>error message and success message in form of Response and arrar of Designation object</returns>
        /// 


        private static CommunicationObject GetAllTypeTeamDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();


            TeamDetail[] DesignationData = HRManager.GetAllTeamDetails();

            JGridObjectBuilder Builder = new JGridObjectBuilder("AltioStar", typeof(TeamDetail));

            Builder.AddRow(DesignationData);

            if (DesignationData != null || DesignationData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject GetAllDesignationDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();


            Designation[] DesignationData = HRManager.GetAllActiveDesignationsDetails();

            JGridObjectBuilder Builder = new JGridObjectBuilder("AltioStar", typeof(Designation));

            Builder.AddRow(DesignationData);

            if (DesignationData != null || DesignationData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject GetDesignationDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();


            Designation[] DesignationData = HRManager.GetActiveDesignations();

            JGridObjectBuilder Builder = new JGridObjectBuilder("AltioStar", typeof(Designation));

            Builder.AddRow(DesignationData);

            if (DesignationData != null || DesignationData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        /// <summary>
        /// Send Request to Entity for DeActivate the Designation
        /// </summary>
        /// <param name="RequestDataObject">Designation id and changedby id in form of Request</param>
        /// <returns>error message and success message in form of Response</returns>
        private static CommunicationObject DeActivateDesignation(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            ActiveDeactiveDesignation Request = new ActiveDeactiveDesignation();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.UpdateAcDCDesignation(Request.ID, Request.IsActive);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.IsActive == false)
                {
                    Response.SetProperty(WebResponse.Message, "Deactivated Successfully");
                }
                else
                {
                    Response.SetProperty(WebResponse.Message, "Activated Successfully");
                }

            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.DesignationMessages.DESIGNATION_REFERRED);
            }

            return Response;
        }
        /// <summary>
        /// Send Request to Entity for Activate the Designation
        /// </summary>
        /// <param name="RequestDataObject">Designation id and changedby id in form of Request</param>
        /// <returns>error message and success message in form of Response</returns>
        private static CommunicationObject ActivateDesignation(CommunicationObject RequestDataObject)
        {

            CommunicationObject Response = new CommunicationObject();

            ActiveDeactiveDesignation Request = new ActiveDeactiveDesignation();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.UpdateAcDCDesignation(Request.ID, Request.IsActive);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.IsActive == false)
                {
                    Response.SetProperty(WebResponse.Message, "Deactivated Successfully");
                }
                else
                {
                    Response.SetProperty(WebResponse.Message, "Activated Successfully");
                }

            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.DesignationMessages.DESIGNATION_REFERRED);
            }

            return Response;
        }
        /// <summary>
        /// Send Request to Entity for Update the Designation
        /// </summary>
        /// <param name="RequestDataObject">Designation details in form of Request</param>
        /// <returns>error message and success message in form of Response</returns>
        private static CommunicationObject UpdateDesignation(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateDesignationRequest Request = new UpdateDesignationRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.UpdateDesignation(Request.DesignationID, Request.Designation, Request.IsActive, Request.UpdateBy, Request.RoleID);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.DesignationID == 0)
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.DesignationMessages.DESIGNATION_ADDED_SUCCESS);
                else
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.DesignationMessages.DESIGNATION_UPDATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }

        /// <summary>
        /// Get all the states for a designation.
        /// </summary>
        /// <param name="RequestDataObject">EntityRequest - Will be passed.</param>
        /// <returns></returns>
        private static CommunicationObject GetDesignationComboDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            Designation[] Designation = HRManager.GetActiveDesignations();

            if (Designation.Length != null && Designation.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Designation);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.DesignationMessages.NO_DESIGNATION);
            }

            return Response;
        }
        private static CommunicationObject GetMenuString(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            UpdateRoleRequest role = new UpdateRoleRequest();
            RequestDataObject.UpdateDataObject(role);
            string mnu = HRManager.GetMenuString(role.Role);


            if (mnu.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, mnu);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        /// <summary>
        /// Send Request to Entity to Get Department Details
        /// </summary>
        /// <param name="RequestDataObject">Department id in form of Request</param>
        /// <returns>error message and success message in form of Response and arrar of Designation object</returns>

        /// <summary>
        /// Send Request to Entity to Get Department Details
        /// </summary>
        /// <param name="RequestDataObject">Department id in form of Request</param>
        /// <returns>error message and success message in form of Response and arrar of Designation object</returns>
        /// 


        #region SettingConfiguration

        private static CommunicationObject GetSettingConfiguration(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            Setting_Configuration[] SettingConfiguration = HRManager.GetSettingConfigurations();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(SettingConfigurationDetails));

            Builder.AddRow(SettingConfiguration);

            if (SettingConfiguration != null || SettingConfiguration.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject UpdateSettingConfiguration(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateConfigurationRequest Request = new UpdateConfigurationRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.UpdateSettingConfigurations(Request.ID, Request.ConfigValue, Request.ModifiedBy);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.SettingConfigurationMessages.SETTING_UPDATE_SUCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        #endregion


        private static CommunicationObject GetAllDesignationForHigher(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateDesignationRequest Request = new UpdateDesignationRequest();
            RequestDataObject.UpdateDataObject(Request);
            Designation[] DesignationData = HRManager.GetAllDesignationForHigher(Request.DesignationID);

            //JTreeBuilder Builder = new JTreeBuilder("AltioStar", "Designation");

            //Builder.Add(DesignationData);

            JGridObjectBuilder Builder = new JGridObjectBuilder("DesignationID", typeof(DesignationDetails));

            Builder.AddRow(DesignationData);

            if (DesignationData != null || DesignationData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        /// <summary>
        /// Send Request to Entity to Get Grade Details
        /// </summary>
        /// <param name="RequestDataObject">Grade id in form of Request</param>
        /// <returns>error message and success message in form of Response and arrar of Designation object</returns>
        private static CommunicationObject GetDesignationInfo(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            UpdateDesignationRequest Request = new UpdateDesignationRequest();
            RequestDataObject.UpdateDataObject(Request);
            Designation DesignationData = null;

            DesignationData = HRManager.GetDesignationInfo(Request.DesignationID);

            if (DesignationData != null)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, DesignationData);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        /// <summary>
        /// Send Request to Entity to Get Designation Details
        /// </summary>
        /// <param name="RequestDataObject">Designation id in form of Request</param>
        /// <returns>error message and success message in form of Response and arrar of Designation object</returns>
        ////private static CommunicationObject GetDesignationDetails(CommunicationObject RequestDataObject)
        ////{
        ////    CommunicationObject Response = new CommunicationObject();

        ////    Designation[] DesignationData = HRManager.GetDesignations();

        ////    JGridObjectBuilder Builder = new JGridObjectBuilder("DesignationID", typeof(DesignationDetails));

        ////    Builder.AddRow(DesignationData);

        ////    if (DesignationData != null || DesignationData.Length >= 0)
        ////    {
        ////        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
        ////        Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
        ////    }
        ////    else
        ////    {
        ////        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
        ////        Response.SetProperty(WebResponse.Message, String.Empty);
        ////    }

        ////    return Response;
        ////}
        /// <summary>
        /// Send Request to Entity to Get Designation Details
        /// </summary>
        /// <param name="RequestDataObject">Designation id in form of Request</param>
        /// <returns>error message and success message in form of Response and arrar of Designation object</returns>
        private static CommunicationObject GetInActiveDesignation(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            Designation[] DesignationData = HRManager.GetInActiveDesignations();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(Designation));

            Builder.AddRow(DesignationData);

            if (DesignationData != null || DesignationData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject GetRoleCombo(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            ComboBoxValues[] combo = new Master_RoleBusinessObject().GetRoleCombo();

            if (combo != null && combo.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, combo);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
            }

            return Response;
        }

        #endregion

        #region Department

        /// <summary>
        /// Send Request to Entity for Update Department
        /// </summary>
        /// <param name="RequestDataObject">Department details in form of Request</param>
        /// <returns>error message and success message in form of Response</returns>
        private static CommunicationObject UpdateDepartment(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateDepartmentRequest Request = new UpdateDepartmentRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.UpdateDepartment(Request.DepartmentID, Request.Department, Convert.ToInt32(Request.UpdateBy), Request.ParentID, Request.HOD, Request.IsHR, Request.IsFinance);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.DepartmentID == 0)
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.DepartmentMessages.DEPARTMENT_ADDED_SUCCESS);
                else
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.DepartmentMessages.DEPARTMENT_UPDATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        /// <summary>
        /// Send Request to Entity to Get Department Details
        /// </summary>
        /// <param name="RequestDataObject">Department id in form of Request</param>
        /// <returns>error message and success message in form of Response and arrar of Designation object</returns>
        private static CommunicationObject GetDepartmentDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            Department[] DepartmentData = HRManager.GetDepartments();

            JTreeBuilder Builder = new JTreeBuilder("AltioStar", "Department");

            Builder.Add(DepartmentData);

            if (DepartmentData != null || DepartmentData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetTreeObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        /// <summary>
        /// Send Request to Entity to Get Department Details
        /// </summary>
        /// <param name="RequestDataObject">Department id in form of Request</param>
        /// <returns>error message and success message in form of Response and arrar of Designation object</returns>
        private static CommunicationObject GetFilterDepartmentDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            UpdateEmployeesRequest Request = new UpdateEmployeesRequest();

            RequestDataObject.UpdateDataObject(Request);

            Department[] DepartmentData = HRManager.GetBranchDepartments(Request.BranchID);
            if (DepartmentData.Length != null && DepartmentData.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, DepartmentData);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }
            return Response;
        }
        private static CommunicationObject GetDepartmentHOD(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            EntityRequest Request = new EntityRequest();
            RequestDataObject.UpdateDataObject(Request);
            Department DepartmentData = new Department(Convert.ToInt32(Request.ID));

            if (DepartmentData != null)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, DepartmentData);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="RequestDataObject"></param>
        /// <returns></returns>
        private static CommunicationObject GetDeptComboDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            Department[] DepartmentData = HRManager.GetDepartments();
            if (DepartmentData.Length != null && DepartmentData.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, DepartmentData);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }
            return Response;
        }
        #endregion

        #region EMPLOYEE TYPE

        private static CommunicationObject GetEmployeeTypeCombo(CommunicationObject RequestDataObject)  //For Combo box loading
        {
            CommunicationObject Response = new CommunicationObject();

            EmployeeType[] ctry = HRManager.GetEmployeeTypes();
            if (ctry.Length != null && ctry.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, ctry);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        /// <summary>
        /// Send Request to Entity to Get Grade Details
        /// </summary>
        /// <param name="RequestDataObject">Grade id in form of Request</param>
        /// <returns>error message and success message in form of Response and arrar of Designation object</returns>
        private static CommunicationObject GetEmployeeTypeDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EmployeeType[] EmployeeTypeData = HRManager.GetEmployeeTypes();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(EmployeeTypeDetails));

            Builder.AddRow(EmployeeTypeData);

            if (EmployeeTypeData != null || EmployeeTypeData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        /// <summary>
        /// Send Request to Entity for DeActivate EmployeeType
        /// </summary>
        /// <param name="RequestDataObject">EmployeeType id and changedby id in form of Request</param>
        /// <returns>error message and success message in form of Response</returns>
        private static CommunicationObject DeActivateEmployeeType(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.DeActivateEmployeeType(Convert.ToInt32(Request.ID), Request.ChangedBy);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.EmployeeTypeMessages.DEACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }

        /// <summary>
        /// Send Request to Entity for Activate EmployeeType
        /// </summary>
        /// <param name="RequestDataObject">EmployeeType id and changedby id in form of Request</param>
        /// <returns>error message and success message in form of Response</returns>
        private static CommunicationObject ActivateEmployeeType(CommunicationObject RequestDataObject)
        {

            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.ActivateEmployeeType(Convert.ToInt32(Request.ID), Request.ChangedBy);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.EmployeeTypeMessages.ACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        private static CommunicationObject GetInActiveEmployeeType(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EmployeeType[] EmployeeTypeData = HRManager.GetInActiveEmployeeType();

            JGridObjectBuilder Builder = new JGridObjectBuilder("Id", typeof(EmployeeTypeDetails));

            Builder.AddRow(EmployeeTypeData);

            if (EmployeeTypeData != null || EmployeeTypeData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        /// <summary>
        /// Send Request to Entity for Update EmployeeType
        /// </summary>
        /// <param name="RequestDataObject">EmployeeType details in form of Request</param>
        /// <returns>error message and success message in form of Response</returns>
        private static CommunicationObject UpdateEmployeeType(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateEmployeeTypeRequest Request = new UpdateEmployeeTypeRequest();

            RequestDataObject.UpdateDataObject(Request);

            //String ResponseString = HRManager.UpdateEmployeeType(Request.ID, Request.Name, Request.MinDurationMonth, Request.IsActive, Request.IsService, Request.IsPermanent, Convert.ToInt32(Request.UpdateBy));
            String ResponseString = HRManager.UpdateEmployeeType(Request.ID, Request.Name, Request.IsActive, Convert.ToInt32(Request.UpdateBy));

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.ID == 0)
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.EmployeeTypeMessages.EMPLOYEETYPE_ADDED_SUCCESS);
                else
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.EmployeeTypeMessages.EMPLOYEETYPE_UPDATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        #endregion

        #region Role
        private static CommunicationObject GetRoleDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            RoleMaster[] RoleData = HRManager.GetRoles();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(RoleDisplayDetails));

            Builder.AddRow(RoleData);

            if (RoleData != null || RoleData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject DeActivateRole(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.DeActivateRole(Convert.ToInt32(Request.ID), Request.ChangedBy);
            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.RoleMessages.DEACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        private static CommunicationObject ActivateRole(CommunicationObject RequestDataObject)
        {

            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.ActivateRole(Convert.ToInt32(Request.ID), Request.ChangedBy);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.RoleMessages.ACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        private static CommunicationObject GetInActiveRole(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            RoleMaster[] RoleData = HRManager.GetInActiveRoles();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(RoleDisplayDetails));

            Builder.AddRow(RoleData);

            if (RoleData != null || RoleData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject UpdateRole(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateRoleRequest Request = new UpdateRoleRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.UpdateRole(Request.RoleID, Request.Role, Request.Description, Request.IsActive, Convert.ToInt32(Request.UpdatedBy), Request.Reports, Request.Permissions);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.RoleID == 0)
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.RoleMessages.ROLE_ADDED_SUCCESS);
                else
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.RoleMessages.ROLE_UPDATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        private static CommunicationObject GetRoleWiseDashboardReports(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            UpdateRoleRequest Request = new UpdateRoleRequest();
            RequestDataObject.UpdateDataObject(Request);
            EmpRoleDashboardReports[] ReportInfoData = HRManager.GetRoleWiseDashboardReports(Request.RoleID);

            if (ReportInfoData != null)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, ReportInfoData);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject GetDashBoardReports(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            DashBoardReport[] ReportData = HRManager.GetAllDashBoardReports();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ReportID", typeof(ReportDetails));

            Builder.AddRow(ReportData);

            if (ReportData != null || ReportData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject GetAllPermissions(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            UpdatePermissionRequest Request = new UpdatePermissionRequest();
            RequestDataObject.UpdateDataObject(Request);
            Permission[] ReportData = HRManager.GetAllPermissions(Request.RoleID);

            JGridObjectBuilder Builder = new JGridObjectBuilder("FunctionID", typeof(PermisDetails));

            Builder.AddRow(ReportData);

            if (ReportData != null || ReportData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        #endregion

        private static CommunicationObject GetAllRoleTypeDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            RoleMaster[] RelationData = HRManager.GetAllTypeRoles();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(RoleDisplayDetails));

            Builder.AddRow(RelationData);

            if (RelationData != null || RelationData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        #region Relation

        private static CommunicationObject GetAllRelationDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            Relation[] RelationData = HRManager.GetAllRelationDetails();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(RelationDetails));

            Builder.AddRow(RelationData);

            if (RelationData != null || RelationData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject GetRelationDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            Relation[] RelationData = HRManager.GetRelations();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(RelationDetails));

            Builder.AddRow(RelationData);

            if (RelationData != null || RelationData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }


        private static CommunicationObject GetInActiveRelation(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            Relation[] RelationData = HRManager.GetInActiveRelation();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(RelationDetails));

            Builder.AddRow(RelationData);

            if (RelationData != null || RelationData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        /// <summary>
        /// Send Request to Entity for Activate Role
        /// </summary>
        /// <param name="RequestDataObject">Role id and changedby id in form of Request</param>
        /// <returns>error message and success message in form of Response</returns>
        private static CommunicationObject ActivateRelation(CommunicationObject RequestDataObject)
        {

            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.ActivateRelation(Convert.ToInt32(Request.ID), Request.ChangedBy);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.RelationMessages.ACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }

        private static CommunicationObject DeActivateRelation(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.DeActivateRelation(Convert.ToInt32(Request.ID), Request.ChangedBy);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.RelationMessages.DEACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }

        private static CommunicationObject UpdateRelation(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateRelationRequest Request = new UpdateRelationRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.UpdateRelation(Request.ID, Request.RelationName, Request.IsActive, Convert.ToInt32(Request.UpdateBy));

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.ID == 0)
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.RelationMessages.Relation_ADDED_SUCCESS);
                else
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.RelationMessages.Relation_UPDATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        #endregion


        private static CommunicationObject GetAllcompanyDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            Master_Company[] InvestmentGroupData = HRManager.GetAllCompanyDetails();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(CompanyDetails));

            Builder.AddRow(InvestmentGroupData);

            if (InvestmentGroupData != null || InvestmentGroupData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject UpdateCompany(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateCompany Request = new UpdateCompany();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.UpdateCompany(Request.ID, Request.Companycode, Request.CompanyName, Request.CompanyShortName, Request.Address, Request.Pan, Request.Tin, Request.registrationno, Request.pfno, Request.phone, Request.financialyearstart, Request.financialyearend, Request.financialyearname, Request.voucherstartdate, Request.voucherenddate, Request.investmentgroup, Request.tan, Request.servicetaxregno, Request.website, Request.email, Request.shopsno, Request.esino, Request.IsActive, Convert.ToInt32(Request.UpdateBy));

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.ID == 0)
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.CompanyMessages.COMPANY_ADDED_SUCCESS);
                else
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.CompanyMessages.COMPANY_UPDATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }

        private static CommunicationObject ActivateCompany(CommunicationObject RequestDataObject)
        {

            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.ActivateCompany(Convert.ToInt32(Request.ID), Request.ChangedBy);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.CompanyMessages.ACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }

        private static CommunicationObject DeActivateCompany(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.DeActivateCompany(Convert.ToInt32(Request.ID), Request.ChangedBy);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.CompanyMessages.DEACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }

        //kartyek 17.02.2015 response for project Details/Info

        private static CommunicationObject GetAllProjectDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            ProjectInfo[] ProjectInfoDetails = HRManager.GetAllProjectDetails();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(ProjectInfoDetails));

            Builder.AddRow(ProjectInfoDetails);

            if (ProjectInfoDetails != null || ProjectInfoDetails.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject UpdateProjectInfo(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateProjectInfo Request = new UpdateProjectInfo();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.UpdateProjectInfo(Request.ID, Request.Companyid, Request.ProjectGroup, Request.Projecttype, Request.projectcode, Request.ProjectName, Request.Address, Request.contractown, Request.IsActive, Convert.ToInt32(Request.UpdateBy));

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.ID == 0)
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.ProjectInfoMessages.PROJECTINFO_ADDED_SUCCESS);
                else
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.ProjectInfoMessages.PROJECTINFO_UPDATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }

        private static CommunicationObject ActivateProjectInfo(CommunicationObject RequestDataObject)
        {

            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.ActivateProjectInfo(Convert.ToInt32(Request.ID), Request.ChangedBy);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.ProjectInfoMessages.ACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }

        private static CommunicationObject DeActivateProjectInfo(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.DeActivateProjectInfo(Convert.ToInt32(Request.ID), Request.ChangedBy);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.ProjectInfoMessages.DEACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }





        #region InvestmentGroup

        //kartyek 13.2.2015 GetAllInvestmentDetails
        private static CommunicationObject GetAllInvestmentDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            InvestmentGroup[] InvestmentGroupData = HRManager.GetAllInvestmentGroupDetails();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(InvestmentGroupDetails));

            Builder.AddRow(InvestmentGroupData);

            if (InvestmentGroupData != null || InvestmentGroupData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject UpdateInvestmentGroup(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateInvestmentGroup Request = new UpdateInvestmentGroup();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.UpdateInvestment(Request.ID, Request.GroupName, Request.IsActive, Convert.ToInt32(Request.UpdateBy));

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.ID == 0)
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.InvestmentMessages.INVESTMENT_ADDED_SUCCESS);
                else
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.InvestmentMessages.INVESTMENT_UPDATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }

        private static CommunicationObject ActivateInvestment(CommunicationObject RequestDataObject)
        {

            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.ActivateInvestment(Convert.ToInt32(Request.ID), Request.ChangedBy);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.RelationMessages.ACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }

        private static CommunicationObject DeActivateInvestment(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.DeActivateInvestment(Convert.ToInt32(Request.ID), Request.ChangedBy);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.RelationMessages.DEACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }


        #endregion

        private static CommunicationObject GetAssetSubcombo(CommunicationObject RequestDataObject)  //For Combo box loading
        {
            CommunicationObject Response = new CommunicationObject();

            AssetSubCategory[] ctry = HRManager.GetAllAssetSubCategory();
            if (ctry.Length != null && ctry.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, ctry);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject GetAssetcombo(CommunicationObject RequestDataObject)  //For Combo box loading
        {
            CommunicationObject Response = new CommunicationObject();

            AssetCategory[] ctry = HRManager.GetAllAssetCategory();
            if (ctry.Length != null && ctry.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, ctry);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject GetInvestmentDetailscombo(CommunicationObject RequestDataObject)  //For Combo box loading
        {
            CommunicationObject Response = new CommunicationObject();

            InvestmentGroup[] investment = HRManager.GetInvestmentDetails();
            if (investment.Length != null && investment.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, investment);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }




        private static CommunicationObject GetcompanyDetailscombo(CommunicationObject RequestDataObject)  //For Combo box loading
        {
            CommunicationObject Response = new CommunicationObject();

            Master_Company[] company = HRManager.GetCompanyDetails();
            if (company.Length != null && company.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, company);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        #region Country

        private static CommunicationObject GetcountryDetailscombo(CommunicationObject RequestDataObject)  //For Combo box loading
        {
            CommunicationObject Response = new CommunicationObject();

            Country[] ctry = HRManager.Getcountry();
            if (ctry.Length != null && ctry.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, ctry);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject GetcountryDetails(CommunicationObject RequestDataObject) //For Loading Grid
        {
            CommunicationObject Response = new CommunicationObject();

            Country[] RoleData = HRManager.Getcountry();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(Country));

            Builder.AddRow(RoleData);

            if (RoleData != null || RoleData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }


        private static CommunicationObject GetCompleteHolidayDetails(CommunicationObject RequestDataObject) //For Loading Grid
        {
            CommunicationObject Response = new CommunicationObject();

            Holidays[] RoleData = HRManager.GetAllHolidayDetails();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(HolidayGridDetails));

            Builder.AddRow(RoleData);

            if (RoleData != null || RoleData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject GetCompleteManufacturerDetails(CommunicationObject RequestDataObject) //For Loading Grid
        {
            CommunicationObject Response = new CommunicationObject();

            Manufacturer[] RoleData = HRManager.GetAllManufacturerDetails();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(Manufacturer));

            Builder.AddRow(RoleData);

            if (RoleData != null || RoleData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject GetCompleteCandidatecompetencyDetails(CommunicationObject RequestDataObject) //For Loading Grid
        {
            CommunicationObject Response = new CommunicationObject();

            Candidate_Competency[] RoleData = HRManager.GetAllCandidatecompetencyDetails();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(Candidate_Competency));

            Builder.AddRow(RoleData);

            if (RoleData != null || RoleData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject GetCompleteInterviewTypeDetails(CommunicationObject RequestDataObject) //For Loading Grid
        {
            CommunicationObject Response = new CommunicationObject();

            InterView_Type[] RoleData = HRManager.GetInterviweTypeDetails();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(InterView_Type));

            Builder.AddRow(RoleData);

            if (RoleData != null || RoleData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject GetCompleteConsultantDetails(CommunicationObject RequestDataObject) //For Loading Grid
        {
            CommunicationObject Response = new CommunicationObject();

            ConsultantEntity[] RoleData = HRManager.GetAllConsultantsDetails();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(ConsultantDisplayDetails));

            Builder.AddRow(RoleData);

            if (RoleData != null || RoleData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject GetCompleteassetsubstatusDetails(CommunicationObject RequestDataObject) //For Loading Grid
        {
            CommunicationObject Response = new CommunicationObject();

            AssetSubCategory[] RoleData = HRManager.GetAllAssetSubDetails();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(AssetSubCategory));

            Builder.AddRow(RoleData);

            if (RoleData != null || RoleData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject GetCompleteassetstatusDetails(CommunicationObject RequestDataObject) //For Loading Grid
        {
            CommunicationObject Response = new CommunicationObject();

            AssetCategory[] RoleData = HRManager.GetAllAssetDetails();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(AssetCategory));

            Builder.AddRow(RoleData);

            if (RoleData != null || RoleData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        //kartyek 5.2.2015 Loan Management Reques based respose from Entity
        private static CommunicationObject GetLoanDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            Master_LoansDetails[] LoanData = HRManager.GetLoans();

            JGridObjectBuilder Builder = new JGridObjectBuilder("LoanID", typeof(LoanDetails));

            Builder.AddRow(LoanData);

            if (LoanData != null || LoanData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject UpdateLoan(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateLoanRequest Request = new UpdateLoanRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.UpdateLoan(Request.ID, Request.LoanName, Request.MaxAmount, Request.Interest, Request.IsActive, Convert.ToInt32(Request.UpdateBy), Request.MaxBasicPercentage, Request.MinServicePeriod, Request.MinLeaveBalance, Request.RemainingService, Request.Installment);


            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.ID == 0)
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.LoanMessages.LOAN_ADDED_SUCCESS);
                else
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.LoanMessages.LOAN_UPDATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        private static CommunicationObject DeActivateLoan(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.DeActivateLoan(Convert.ToInt32(Request.ID), Convert.ToInt32(Request.ChangedBy));

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.LoanMessages.DEACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }

        private static CommunicationObject ActivateLoan(CommunicationObject RequestDataObject)
        {

            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.ActivateLoan(Convert.ToInt32(Request.ID), Convert.ToInt32(Request.ChangedBy));

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.LoanMessages.ACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        private static CommunicationObject GetInActiveLoan(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            Master_LoansDetails[] LoanData = HRManager.GetInActiveLoans();

            JGridObjectBuilder Builder = new JGridObjectBuilder("LoanID", typeof(LoanDetails));

            Builder.AddRow(LoanData);

            if (LoanData != null || LoanData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject GetLoanComboDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            Master_LoansDetails[] Loan = HRManager.GetLoanDetailforCombo(Convert.ToInt32(Request.ID));

            if (Loan.Length != null && Loan.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Loan);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.LoanMessages.NO_LOANTYPE);
            }

            return Response;
        }


        private static CommunicationObject GetLoanAmountByLoanId(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateLoanRequest Request = new UpdateLoanRequest();
            RequestDataObject.UpdateDataObject(Request);

            String LoanAmount = HRManager.GetLoanAmountByLoanId(Convert.ToInt32(Request.LoanID), Convert.ToInt32(Request.EmpID));


            if (LoanAmount != null || LoanAmount.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, LoanAmount);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        //kartyek 7.2.2015 Advance Type methods
        #region  Advance Type

        private static CommunicationObject GetAdvanceTypeDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            MasterAdvanceType[] AdvanceTypeData = HRLoanManager.GetAdvanceTypes();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(AdvanceTypeDetails));

            Builder.AddRow(AdvanceTypeData);

            if (AdvanceTypeData != null || AdvanceTypeData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject UpdateAdvanceType(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateAdvanceTypeRequest Request = new UpdateAdvanceTypeRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRLoanManager.UpdateAdvanceType(Request.ID, Request.AdvanceType, Request.IsActive, Request.UpdateBy);


            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.ID == 0)
                {
                    Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.AdvanceType.ADVANCE_TYPE_ADDED_SUCCESS);
                }
                else
                {
                    Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.AdvanceType.ADVANCE_TYPE_UPDATE_SUCCESS);
                }
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }

        private static CommunicationObject DeActivateAdvanceType(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRLoanManager.DeActivateAdvanceType(Convert.ToInt32(Request.ID), Request.ChangedBy);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.AdvanceType.DEACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }

        private static CommunicationObject ActivateAdvanceType(CommunicationObject RequestDataObject)
        {

            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRLoanManager.ActivateAdvanceType(Convert.ToInt32(Request.ID), Request.ChangedBy);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.AdvanceType.ACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }

        private static CommunicationObject GetInActiveAdvanceType(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            MasterAdvanceType[] AdvanceType = HRLoanManager.GetInActiveAdvanceType();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(AdvanceTypeDetails));

            Builder.AddRow(AdvanceType);

            if (AdvanceType != null || AdvanceType.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        /// <summary>
        /// Get all the states for a country.
        /// </summary>
        /// <param name="RequestDataObject">EntityRequest - Will be passed.</param>
        /// <returns></returns>
        private static CommunicationObject GetAdvanceTypeForCombo(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            MasterAdvanceType[] AdvanceType = HRLoanManager.GetAdvanceTypeForCombo();

            if (AdvanceType.Length != null && AdvanceType.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, AdvanceType);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.AdvanceType.NO_ADVANCETYPE);
            }

            return Response;
        }
        #endregion


        private static CommunicationObject GetCompletemaritalstatusDetails(CommunicationObject RequestDataObject) //For Loading Grid
        {
            CommunicationObject Response = new CommunicationObject();

            Master_MaritialStatus[] RoleData = HRManager.GetMaritalDetails();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(Master_MaritialStatus));

            Builder.AddRow(RoleData);

            if (RoleData != null || RoleData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject GetCompletecountryDetails(CommunicationObject RequestDataObject) //For Loading Grid
        {
            CommunicationObject Response = new CommunicationObject();

            Country[] RoleData = HRManager.GetCountryDetails();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(Country));

            Builder.AddRow(RoleData);

            if (RoleData != null || RoleData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject Getactivedeactivecountry(CommunicationObject RequestDataObject)  //For Activate & Deactivate
        {
            CommunicationObject Response = new CommunicationObject();

            ActiveDeactiveCountry Request = new ActiveDeactiveCountry();

            RequestDataObject.UpdateDataObject(Request);

            String ActiveDeactiveData = HRManager.UpdateAcDCcountry(Request.ID, Request.IsActive, Request.EmpID);

            if (ActiveDeactiveData == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.IsActive == false)
                {
                    Response.SetProperty(WebResponse.Message, "Deactivated Successfully");
                }
                else
                {
                    Response.SetProperty(WebResponse.Message, "Activated Successfully");
                }

            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.CountrytMessages.COUNTRY_REFERED);
                //Response.SetProperty(WebResponse.Message, "Failure");
            }

            return Response;
        }
        private static CommunicationObject GetInActiveCountries(CommunicationObject RequestDataObject)  //For Inactive Details While Binding & deactivating
        {
            CommunicationObject Response = new CommunicationObject();

            Country[] RoleData = HRManager.GetInactivecountry();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(Country));

            Builder.AddRow(RoleData);

            if (RoleData != null || RoleData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject UpdateCountry(CommunicationObject RequestDataObject)       //For Updating 
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateCountryRequest Request = new UpdateCountryRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.UpdateCountry(Request.ID, Request.CountryID, Request.CountryName, Request.ModifiedBy, Request.CreatedDate, Request.IsActive);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.ID == 0)
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.CountrytMessages.COUNTRY_ADDED_SUCCESS);
                else
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.CountrytMessages.COUNTRY_UPDATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        #endregion

        #region Holidays
        private static CommunicationObject GetHolidayDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            Holidays[] RoleData = HRManager.GetHoliday();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(HolidayGridDetails));

            Builder.AddRow(RoleData);

            if (RoleData != null || RoleData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject Getactivedeactiveholiday(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            ActiveDeactiveHoliday Request = new ActiveDeactiveHoliday();

            RequestDataObject.UpdateDataObject(Request);

            String ActiveDeactiveData = HRManager.UpdateAcDCholiday(Request.ID, Request.IsActive);

            if (ActiveDeactiveData == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.IsActive == false)
                {
                    Response.SetProperty(WebResponse.Message, "Deactivated Successfully");
                }
                else
                {
                    Response.SetProperty(WebResponse.Message, "Activated Successfully");
                }

            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, "Failure");
            }

            return Response;
        }
        private static CommunicationObject GetInActiveHolidays(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            Holidays[] RoleData = HRManager.GetInactiveholidays();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(HolidayGridDetails));

            Builder.AddRow(RoleData);

            if (RoleData != null || RoleData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject UpdateHolidays(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateHolidayRequest Request = new UpdateHolidayRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.UpdateHoliday(Request.ID, Request.LocationID, Request.HolidayName, Request.HolidayDate, Request.Description, Request.Status, Request.RequestingTo, Request.ModifiedBy, Request.CreatedDate, Request.IsActive);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.ID == 0)
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.HolidaysMessages.HOLIDAY_ADDED_SUCCESS);
                else
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.HolidaysMessages.HOLIDAY_UPDATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        #endregion

        #region Location
        private static CommunicationObject GetLocationCombo(CommunicationObject RequestDataObject)  //For Combo box loading
        {
            CommunicationObject Response = new CommunicationObject();
            UpdateLocationRequest Request = new UpdateLocationRequest();

            RequestDataObject.UpdateDataObject(Request);
            Location[] ctry = HRManager.GetCountryLocation(Request.CountryID);
            if (ctry.Length != null && ctry.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, ctry);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject GetLocationDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            Location[] LocationData = HRManager.GetLocation();

            JGridObjectBuilder Builder = new JGridObjectBuilder("LocationID", typeof(LocationDisplayDetails));

            Builder.AddRow(LocationData);

            if (LocationData != null || LocationData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject DeActivateLocation(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            ActivateLocationRequest Request = new ActivateLocationRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.UpdateAcDCLocation(Request.ID, Request.IsActive);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.IsActive == false)
                {
                    Response.SetProperty(WebResponse.Message, "Deactivated Successfully");
                }
                else
                {
                    Response.SetProperty(WebResponse.Message, "Activated Successfully");
                }

            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, "Already Referred");
            }



            return Response;
        }
        private static CommunicationObject GetInActiveLocation(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            Location[] LocationData = HRManager.GetInActiveLocation();

            JGridObjectBuilder Builder = new JGridObjectBuilder("LocationId", typeof(LocationDisplayDetails));

            Builder.AddRow(LocationData);

            if (LocationData != null || LocationData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject ActivateLocation(CommunicationObject RequestDataObject)
        {

            CommunicationObject Response = new CommunicationObject();

            ActivateLocationRequest Request = new ActivateLocationRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.UpdateAcDCLocation(Convert.ToInt32(Request.ID), Request.IsActive);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.IsActive == false)
                {
                    Response.SetProperty(WebResponse.Message, "Deactivated Successfully");
                }
                else
                {
                    Response.SetProperty(WebResponse.Message, "Activated Successfully");
                }

            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, "Already Referred");
            }

            return Response;
        }
        private static CommunicationObject UpdateLocation(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateLocationRequest Request = new UpdateLocationRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.UpdateLocation(Request.ID, Request.LocationName, Request.CountryID, Convert.ToInt32(Request.UpdateBy), Request.IsActive);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.ID == 0)
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.LocationMessages.LOCATION_ADDED_SUCCESS);
                else
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.LocationMessages.LOCATION_UPDATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }

        #endregion

        #region Consultant

        private static CommunicationObject GetConsultantDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            ConsultantEntity[] LocationData = HRManager.GetConsultantDetails();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(ConsultantDisplayDetails));

            Builder.AddRow(LocationData);

            if (LocationData != null || LocationData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject DeActivateConsultant(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.DeActivateConsultant(Convert.ToInt32(Request.ID), Request.ChangedBy);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.ConsultantMessages.DEACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        private static CommunicationObject ActivateConsultant(CommunicationObject RequestDataObject)
        {

            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.ActivateConsultant(Convert.ToInt32(Request.ID), Request.ChangedBy);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.ConsultantMessages.ACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        private static CommunicationObject GetInActiveConsultant(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            ConsultantEntity[] LocationData = HRManager.GetInActiveConsultant();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(ConsultantDisplayDetails));

            Builder.AddRow(LocationData);

            if (LocationData != null || LocationData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }


        private static CommunicationObject UpdateConsultant(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateConsultantRequest Request = new UpdateConsultantRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.UpdateConsultant(Request.ID, Request.ConsultantName, Request.ContactPerson, Request.TelephoneNo, Request.EmailID, Request.Address, Convert.ToInt32(Request.UpdateBy), Request.IsActive, Request.DesignationID);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.ID == 0)
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.ConsultantMessages.CONSULTANT_ADDED_SUCCESS);
                else
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.ConsultantMessages.CONSULTANT_UPDATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }

        #endregion

        #region MaritalStatus
        private static CommunicationObject GetMaritalStatusCombo(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            Master_MaritialStatus[] Result = HRManager.GetMaritalStatus();

            if (Result.Length != null && Result.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Result);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.MaritalStatusMessages.NO_MARITALSTATUS);
            }

            return Response;
        }

        private static CommunicationObject GetMaritalStatusDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            Master_MaritialStatus[] RoleData = HRManager.GetMaritalStatus();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(Master_MaritialStatus));

            Builder.AddRow(RoleData);

            if (RoleData != null || RoleData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject GetactivedeactiveMaritalStatus(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            ActiveDeactiveMaritalStatus Request = new ActiveDeactiveMaritalStatus();

            RequestDataObject.UpdateDataObject(Request);

            String ActiveDeactiveData = HRManager.UpdateAcDCMaritalStatus(Request.ID, Request.IsActive, Request.EmpID);

            if (ActiveDeactiveData == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.IsActive == false)
                {
                    Response.SetProperty(WebResponse.Message, "Deactivated Successfully");
                }
                else
                {
                    Response.SetProperty(WebResponse.Message, "Activated Successfully");
                }

            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, "Already Referred");
            }

            return Response;
        }
        private static CommunicationObject GetInActiveMaritalStatus(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            Master_MaritialStatus[] RoleData = HRManager.GetInactiveMaritalStatus();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(Master_MaritialStatus));

            Builder.AddRow(RoleData);

            if (RoleData != null || RoleData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject UpdateMaritalStatus(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateMaritalStatusRequest Request = new UpdateMaritalStatusRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.UpdateMaritialStatus(Request.ID, Request.MaritalStatus, Request.ModifiedBy, Request.CreatedDate, Request.IsActive);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.ID == 0)
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.MaritalStatusMessages.MARITALSTATUS_ADDED_SUCCESS);
                else
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.MaritalStatusMessages.MARITALSTATUS_UPDATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        #endregion

        #region InterViewType
        private static CommunicationObject GetInterviewTypeDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            InterView_Type[] RoleData = HRManager.GetInterviewtype();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(InterView_Type));

            Builder.AddRow(RoleData);

            if (RoleData != null || RoleData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject GetactivedeactiveInterviewType(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            ActiveDeactiveInterViewType Request = new ActiveDeactiveInterViewType();

            RequestDataObject.UpdateDataObject(Request);

            String ActiveDeactiveData = HRManager.UpdateAcDCInterviewType(Request.ID, Request.IsActive);

            if (ActiveDeactiveData == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.IsActive == false)
                {
                    Response.SetProperty(WebResponse.Message, "Deactivated Successfully");
                }
                else
                {
                    Response.SetProperty(WebResponse.Message, "Activated Successfully");
                }

            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, "Failure");
            }

            return Response;
        }
        private static CommunicationObject GetInActiveInterviewType(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            InterView_Type[] RoleData = HRManager.GetInactiveInterviewtype();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(InterView_Type));

            Builder.AddRow(RoleData);

            if (RoleData != null || RoleData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }


            return Response;
        }
        private static CommunicationObject UpdateInterviewType(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateInterviewTypeRequest Request = new UpdateInterviewTypeRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.UpdateInterViewType(Request.ID, Request.InterviewType, Request.Description, Request.ModifiedBy, Request.CreatedDate, Request.IsActive);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.ID == 0)
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.InterviewTypesMessages.INTERVIEWTYPE_ADDED_SUCCESS);
                else
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.InterviewTypesMessages.INTERVIEWTYPE_UPDATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }

        private static CommunicationObject GetInterviewTypeCombo(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            ComboBoxValues[] combo = new Master_Interview_TypeBusinessObject().GetInterviewTypeCombo();

            if (combo != null && combo.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, combo);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
            }

            return Response;
        }
        #endregion

        #region Assetcategory
        private static CommunicationObject GetAssetcategoriesDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            AssetCategory[] RoleData = HRManager.GetAllAssetCategory();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(AssetCategory));

            Builder.AddRow(RoleData);

            if (RoleData != null || RoleData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject GetactivedeactiveAssetCategories(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            ActiveDeactiveAssetcategory Request = new ActiveDeactiveAssetcategory();

            RequestDataObject.UpdateDataObject(Request);

            String ActiveDeactiveData = HRManager.UpdateAcDCAssetCategory(Request.ID, Request.IsActive, Request.EmpID);

            if (ActiveDeactiveData == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.IsActive == false)
                {
                    Response.SetProperty(WebResponse.Message, "Deactivated Successfully");
                }
                else
                {
                    Response.SetProperty(WebResponse.Message, "Activated Successfully");
                }

            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, "Already Referred");
            }

            return Response;
        }
        private static CommunicationObject GetInActiveAssetCategory(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            AssetCategory[] RoleData = HRManager.GetInactiveAssetCategory();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(AssetCategory));

            Builder.AddRow(RoleData);

            if (RoleData != null || RoleData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }


            return Response;
        }
        private static CommunicationObject UpdateAssetCategory(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateAssetCategoryRequest Request = new UpdateAssetCategoryRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.UpdateAssetCategory(Request.ID, Request.AssetCategories, Request.Description, Request.ModifiedBy, Request.CreatedDate, Request.IsActive);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.ID == 0)
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.AssetCategoryMessages.ASSET_CATEGORY_ADDED_SUCCESS);
                else
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.AssetCategoryMessages.ASSET_CATEGORY_UPDATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        #endregion

        #region AssetSubcategory
        private static CommunicationObject GetAssetSubcategoriesDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            AssetSubCategory[] RoleData = HRManager.GetAllAssetSubCategory();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(AssetSubCategory));

            Builder.AddRow(RoleData);

            if (RoleData != null || RoleData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject GetactivedeactiveAssetSubCategories(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            ActiveDeactiveAssetSubcategory Request = new ActiveDeactiveAssetSubcategory();

            RequestDataObject.UpdateDataObject(Request);

            String ActiveDeactiveData = HRManager.UpdateAcDCAssetSubCategory(Request.ID, Request.IsActive, Request.EmpID);

            if (ActiveDeactiveData == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.IsActive == false)
                {
                    Response.SetProperty(WebResponse.Message, "Deactivated Successfully");
                }
                else
                {
                    Response.SetProperty(WebResponse.Message, "Activated Successfully");
                }

            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, "Already Referred");
            }

            return Response;
        }
        private static CommunicationObject GetInActiveAssetSubCategory(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            AssetSubCategory[] RoleData = HRManager.GetInactiveAssetSubCategory();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(AssetSubCategory));

            Builder.AddRow(RoleData);

            if (RoleData != null || RoleData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }


            return Response;
        }
        private static CommunicationObject UpdateAssetSubCategory(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateAssetSubCategoryRequest Request = new UpdateAssetSubCategoryRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.UpdateAssetSubCategory(Request.ID, Request.AssetSubCategories, Request.Description, Request.ModifiedBy, Request.CreatedDate, Request.IsActive);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.ID == 0)
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.AssetSubCategoryMessages.ASSET_SUB_CATEGORY_ADDED_SUCCESS);
                else
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.AssetSubCategoryMessages.ASSET_SUB_CATEGORY_UPDATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        #endregion

        #region Manufacturer
        private static CommunicationObject GetManufacturerDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            Manufacturer[] RoleData = HRManager.Getallmanufacturer();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(Manufacturer));

            Builder.AddRow(RoleData);

            if (RoleData != null || RoleData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject GetactivedeactiveManufacturer(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            ActiveDeactiveManufacturer Request = new ActiveDeactiveManufacturer();

            RequestDataObject.UpdateDataObject(Request);

            String ActiveDeactiveData = HRManager.UpdateAcDCManufacturer(Request.ID, Request.IsActive, Request.EmpID);

            if (ActiveDeactiveData == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.IsActive == false)
                {
                    Response.SetProperty(WebResponse.Message, "Deactivated Successfully");
                }
                else
                {
                    Response.SetProperty(WebResponse.Message, "Activated Successfully");
                }

            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, "Already Referred");
            }

            return Response;
        }
        private static CommunicationObject GetInActiveManufacturer(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            Manufacturer[] RoleData = HRManager.GetInactivemanufacturer();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(Manufacturer));

            Builder.AddRow(RoleData);

            if (RoleData != null || RoleData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }


            return Response;
        }
        private static CommunicationObject UpdateManufacturer(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateManufacturerRequest Request = new UpdateManufacturerRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.UpdateaManufacturer(Request.ID, Request.ManufacturerName, Request.Description, Request.ModifiedBy, Request.CreatedDate, Request.IsActive);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.ID == 0)
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.ManufacturerMessages.MANUFACTURER_ADDED_SUCCESS);
                else
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.ManufacturerMessages.MANUFACTURER_UPDATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        #endregion

        #region Leave
        private static CommunicationObject GetLeaveOverviewDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateLeaveRequest Request = new UpdateLeaveRequest();

            RequestDataObject.UpdateDataObject(Request);
            LeaveOverview[] Data = new LeaveOverview().GetLeaveOverview(Request.EmployeeID);

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(LeaveOverViewDetails));

            Builder.AddRow(Data);

            if (Data != null || Data.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject GetLeaveRequestDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateLeaveRequest Request = new UpdateLeaveRequest();

            RequestDataObject.UpdateDataObject(Request);
            LeaveRequest[] Data = new LeaveRequest().GetLeaveRequest(Request.EmployeeID);

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(LeaveRequestDetails));

            Builder.AddRow(Data);

            if (Data != null || Data.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject GetLeaveTypeCombo(CommunicationObject RequestDataObject)
        {

            CommunicationObject Response = new CommunicationObject();

            LeaveRequest Request = new LeaveRequest();

            RequestDataObject.UpdateDataObject(Request);

            LeaveRequest[] arrLeaves = LeaveRequest.GetLeaveTypeCombo();

            if (arrLeaves != null && arrLeaves.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, arrLeaves);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
            }

            return Response;
        }

        private static CommunicationObject GetCallender(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateLeaveRequest Request = new UpdateLeaveRequest();

            RequestDataObject.UpdateDataObject(Request);
            LeaveRequestCalenderEXT[] Details = new LeaveRequest().GetAllActiveLeaveCalender(Request.EmployeeID);
            //LeaveRequestCalenderEXT Details = (LeaveRequestCalenderEXT)(new Leave_RequestBusinessObject().GetAllActiveLeaveCalender(Request.EmployeeID));           

            if (Details != null)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Details);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }
            return Response;
        }
        private static CommunicationObject GetCalendeLeaveRequest(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            UpdateLeaveRequest Request = new UpdateLeaveRequest();

            RequestDataObject.UpdateDataObject(Request);

            LeaveCalenderEXT ProjectStatus = (LeaveCalenderEXT)(new Leave_RequestBusinessObject().GetCalenderDetails(Request.ID));

            if (ProjectStatus != null)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, ProjectStatus);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }
            return Response;

        }
        private static CommunicationObject GetHolidayDate(CommunicationObject RequestDataObject)
        {

            CommunicationObject Response = new CommunicationObject();

            LeaveRequest Request = new LeaveRequest();

            RequestDataObject.UpdateDataObject(Request);

            LeaveRequest[] arrLeaves = LeaveRequest.GetHolidayDate();

            if (arrLeaves != null && arrLeaves.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, arrLeaves);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
            }

            return Response;
        }
        private static CommunicationObject UpdateLeaveRequest(CommunicationObject RequestDataObject)
        {

            CommunicationObject Response = new CommunicationObject();

            UpdateLeave Request = new UpdateLeave();

            RequestDataObject.UpdateDataObject(Request);
            LeaveRequest LeaveApp = new LeaveRequest();
            String ResponseString = LeaveApp.UpdateLeaveApplication(Request.ID, Request.EmpID,
                Request.LeaveID, Request.FromDate, Request.ToDate, Request.Reason,
                Request.AppliedDateTime, Request.Status, Convert.ToDouble(Request.DaysCount), Request.UpdateBy, Request.FromDateHalfDay, Request.ToDateHalfDay);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.MessageDetail, LeaveApp.ID.ToString());
                if (Request.ID == 0)
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.LeaveMessages.LEAVE_ADDED_SUCCESS);
                else
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.LeaveMessages.LEAVE_UPDATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        private static CommunicationObject DeleteLeaveRequest(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            LeaveRequest Request = new LeaveRequest();
            RequestDataObject.UpdateDataObject(Request);
            String ResponseString = HRManager.DeleteLeaveRequset(Convert.ToInt32(Request.ID));
            if (ResponseString == String.Empty)
                Response.SetProperty(WebResponse.Message, HRManagerDefs.LeaveMessages.LEAVE_REQUEST_DELETED);
            else
                Response.SetProperty(WebResponse.Message, ResponseString);
            return Response;
        }
        private static CommunicationObject ResetDateLeaveRequest(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            LeaveRequest Request = new LeaveRequest();
            RequestDataObject.UpdateDataObject(Request);
            String ResponseString = HRManager.ResetDateLeaveRequest(Convert.ToInt32(Request.ID));
            if (ResponseString == String.Empty)
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
            else
                Response.SetProperty(WebResponse.Message, ResponseString);
            return Response;
        }
        private static CommunicationObject UpdateLeaveRequestApproval(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            UpdateLeaveApprovalRequest Request = new UpdateLeaveApprovalRequest();
            RequestDataObject.UpdateDataObject(Request);
            LeaveStatusHistry LeaveApp = new LeaveStatusHistry();
            String ResponseString = LeaveApp.UpdateLeaveRequestApproval(Request.ID, Request.LeaveRequestID, Request.ProcessedBy, Request.Status, Request.Comment);
            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.Status == "APP")
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.LeaveMessages.LEAVE_APP_SUCCESS);
                else
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.LeaveMessages.LEAVE_REJ_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }
            return Response;
        }
        private static CommunicationObject GetLeaveRequestApprovalDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateLeaveRequest Request = new UpdateLeaveRequest();

            RequestDataObject.UpdateDataObject(Request);
            LeaveRequest[] Data = new LeaveRequest().GetLeaveRequestApp(Request.EmployeeID);

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(LeaveRequestDetails));

            Builder.AddRow(Data);

            if (Data != null || Data.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        #endregion

        #region Team

        private static CommunicationObject GetTeamCombo(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            ComboBoxValues[] combo = new Master_TeamBusinessObject().GetTeamCombo();

            if (combo != null && combo.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, combo);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
            }

            return Response;
        }

        private static CommunicationObject GetAllTeamDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            TeamMaster[] combo = HRManager.GetAllTeamDetailsByID(Convert.ToInt32(Request.ID));

            if (combo != null && combo.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, combo);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
            }

            return Response;
        }

        /// <summaryg>
        /// Send Request to Entity to Get Team Details
        /// </summary>
        /// <param name="RequestDataObject">Department id in form of Request</param>
        /// <returns>error message and success message in form of Response and arrar of Designation object</returns>
        private static CommunicationObject GetTeamDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            TeamDetail[] TeamData = HRManager.GetTeams();

            JGridObjectBuilder Builder = new JGridObjectBuilder("AltioStar", typeof(TeamDetail));

            Builder.AddRow(TeamData);

            if (TeamData != null || TeamData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject UpdateTeam(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateTeamRequest Request = new UpdateTeamRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.UpdateTeam(Request.ID, Request.TeamName, Request.ManagerID, Convert.ToInt32(Request.UpdateBy), Request.IsActive);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.ID == 0)
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.TeamMessages.TEAM_ADDED_SUCCESS);
                else
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.TeamMessages.TEAM_UPDATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        private static CommunicationObject ActivateTeam(CommunicationObject RequestDataObject)
        {

            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.ActivateTeam(Convert.ToInt32(Request.ID), Request.ChangedBy);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.TeamMessages.TEAM_UPDATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        private static CommunicationObject GetDeactiveTeam(CommunicationObject RequestDataObject)  //For Activate & Deactivate
        {
            CommunicationObject Response = new CommunicationObject();

            ActiveDeactiveTeam Request = new ActiveDeactiveTeam();

            RequestDataObject.UpdateDataObject(Request);

            //String ResponseString = HRManager.DeActivateTeam(Request.ID, Request.IsActive);
            String ResponseString = HRManager.DeActivateTeam(Convert.ToInt32(Request.ID), Request.ChangedBy);


            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.IsActive == false)
                {
                    Response.SetProperty(WebResponse.Message, "Deactivated Successfully");
                }
                else
                {
                    Response.SetProperty(WebResponse.Message, "Activated Successfully");
                }

            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.TeamMessages.TEAM_REFERED);
                //Response.SetProperty(WebResponse.Message, "Failure");
            }

            return Response;
        }
        private static CommunicationObject GetInactiveTeam(CommunicationObject RequestDataObject)  //For Inactive Details While Binding & deactivating
        {
            CommunicationObject Response = new CommunicationObject();

            TeamDetail[] TeamData = HRManager.GetInactiveTeam();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(TeamDetail));

            Builder.AddRow(TeamData);

            if (TeamData != null || TeamData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject GetManagerCombo(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            ComboBoxValues[] combo = new Master_EmployeesBusinessObject().GetManagerCombo();

            if (combo != null && combo.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, combo);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
            }

            return Response;
        }

        #endregion

        #region Appraisal

        private static CommunicationObject Intimation(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            IntimationEntity[] Data = new IntimationEntity().GetIntimation();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(IntimationDetails));

            Builder.AddRow(Data);

            if (Data != null)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject GetTeamMemberForAppraisal(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            AppraisalListRequest Request = new AppraisalListRequest();

            RequestDataObject.UpdateDataObject(Request);

            IntimationAppraisalEntity[] Data = new IntimationAppraisalEntity().GetTeamMemberForAppraisal(Request.ID, Request.ManagerID);

            JGridObjectBuilder Builder = new JGridObjectBuilder("Sno", typeof(AppraisalDetails));

            Builder.AddRow(Data);

            if (Data != null)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject GetTeamMemberForView(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            AppraisalListRequest Request = new AppraisalListRequest();

            RequestDataObject.UpdateDataObject(Request);

            IntimationAppraisalEntity[] Data = new IntimationAppraisalEntity().GetTeamMemberForView(Request.ID);

            JGridObjectBuilder Builder = new JGridObjectBuilder("Sno", typeof(AppraisalDetails));

            Builder.AddRow(Data);

            if (Data != null)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject GetAllTeamMemberForAppraisal(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            AppraisalListRequest Request = new AppraisalListRequest();

            RequestDataObject.UpdateDataObject(Request);

            IntimationAppraisalEntity[] Data = new IntimationAppraisalEntity().GetAllTeamMemberForAppraisal(Request.ID);

            JGridObjectBuilder Builder = new JGridObjectBuilder("Sno", typeof(AppraisalDetails));

            Builder.AddRow(Data);

            if (Data != null)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject GetAllTeamMemberForRating(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            AppraisalListRequest Request = new AppraisalListRequest();

            RequestDataObject.UpdateDataObject(Request);

            AppraisalEntity[] Data = new AppraisalEntity().GetAllTeamMemberForRating(Request.ID);

            JGridObjectBuilder Builder = new JGridObjectBuilder("Sno", typeof(AppraisalRatingDetails));

            Builder.AddRow(Data);

            if (Data != null)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject GetAllTeamMemberForRatingView(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            AppraisalListRequest Request = new AppraisalListRequest();

            RequestDataObject.UpdateDataObject(Request);

            AppraisalEntity[] Data = new AppraisalEntity().GetAllTeamMemberForRatingView(Request.ID);

            JGridObjectBuilder Builder = new JGridObjectBuilder("Sno", typeof(AppraisalRatingDetails));

            Builder.AddRow(Data);

            if (Data != null)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject IntimateForAppraisal(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = new IntimationEntity().IntimateForAppraisal(Convert.ToInt32(Request.ID));

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.LocationMessages.DEACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }

        private static CommunicationObject DeleteIntimation(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = new IntimationEntity().DeleteIntimation(Convert.ToInt32(Request.ID));

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.LocationMessages.DEACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }

        private static CommunicationObject IsGoalSubmissionStarted(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = new IntimationEntity().IsGoalSubmissionStarted(Convert.ToInt32(Request.ID));

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.LocationMessages.DEACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        private static CommunicationObject UpdateEmployeeAppraisalGrade(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            AppraisalListRequest Request = new AppraisalListRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = new IntimationAppraisalEntity().UpdateEmployeeAppraisalGrade(Request.ID, Request.Grade);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.LocationMessages.DEACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }

        private static CommunicationObject DeleteEmployeeGoals(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            AppraisalListRequest Request = new AppraisalListRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = new IntimationAppraisalEntity().DeleteEmployeeGoals(Request.ID);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.LocationMessages.DEACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }

        private static CommunicationObject CheckAllAppraisalDocSubmitted(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            AppraisalRequest Request = new AppraisalRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = new IntimationAppraisalEntity().CheckAllAppraisalDocSubmitted(Request.IntimationID, Request.TeamID, Request.Type);

            if (ResponseString != String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        private static CommunicationObject DeleteEmployeeGrade(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            AppraisalListRequest Request = new AppraisalListRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = new IntimationAppraisalEntity().DeleteEmployeeGrade(Request.ID);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.LocationMessages.DEACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        private static CommunicationObject EmployeeHike(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            AppraisalRequest Request = new AppraisalRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = new AppraisalEntity().EmployeeHike(Request.ID, Request.EmployeeID, Request.Salary, Request.HikePer, Request.OldSalary, Request.Basic);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.LocationMessages.DEACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        private static CommunicationObject EmployeePromote(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            AppraisalRequest Request = new AppraisalRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = new AppraisalEntity().EmployeePromote(Request.ID, Request.EmployeeID, Request.DesignationID, Request.OldDesignation);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.LocationMessages.DEACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        private static CommunicationObject DesignationCombo(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            ComboBoxValues[] combo = new Appraisal_EmployeeBusinessObject().GetDesignationCombo();

            if (combo != null && combo.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, combo);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
            }

            return Response;
        }

        private static CommunicationObject IntimateDateCombo(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            ComboBoxValues[] combo = new Appraisal_EmployeeBusinessObject().IntimateDateCombo();

            if (combo != null && combo.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, combo);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
            }

            return Response;
        }
        private static CommunicationObject AppraisalSumittedNotificaion(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            AppraisalRequest Request = new AppraisalRequest();

            RequestDataObject.UpdateDataObject(Request);
            String ResponseString = String.Empty;
            if (Request.Type == "Goal")
            {
                new AppraisalNotification().GoalSubmitted(Request.IntimationID, Request.EmployeeID, Request.TeamID);
            }
            else
            {
                new AppraisalNotification().GradeSubmitted(Request.IntimationID, Request.EmployeeID, Request.TeamID);
            }

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, ResponseString);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
            }

            return Response;
        }

        #endregion

        #region ExitMangement

        private static CommunicationObject GetExitManagementDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            //UpdateLeaveRequest Request = new UpdateLeaveRequest();

            //RequestDataObject.UpdateDataObject(Request);
            ExitMangement[] Data = new ExitMangement().GetExitManagement();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(ExitManagermentDisplay));

            Builder.AddRow(Data);

            if (Data != null || Data.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject GetEMPExitManagementDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateEMPExitManagementRequest Request = new UpdateEMPExitManagementRequest();

            RequestDataObject.UpdateDataObject(Request);
            EmployeeExitMangement[] Data = new EmployeeExitMangement().GetEMPExitManagement(Request.EmployeeID);

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(EMPExitManagermentDisplay));

            Builder.AddRow(Data);

            if (Data != null || Data.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject UpdateExitManagement(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            UpdateExitManagementRequest Request = new UpdateExitManagementRequest();
            RequestDataObject.UpdateDataObject(Request);
            ExitMangement LeaveApp = new ExitMangement();
            String ResponseString = LeaveApp.UpdateExitManagement(Request.ID, Request.EmployeeID, Request.ExitTypeID, Request.ExitDate);
            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }
            return Response;
        }
        #endregion

        #region Candidatecompetency
        private static CommunicationObject GetcandidatecompetencyDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            Candidate_Competency[] RoleData = HRManager.GetAllCandidatecompetency();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(Candidate_Competency));

            Builder.AddRow(RoleData);

            if (RoleData != null || RoleData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject Getactivedeactivecandidatecompetency(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            ActiveDeactiveCandidateCompetency Request = new ActiveDeactiveCandidateCompetency();

            RequestDataObject.UpdateDataObject(Request);

            String ActiveDeactiveData = HRManager.UpdateAcDCCandidate_Competency(Request.ID, Request.IsActive);

            if (ActiveDeactiveData == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.IsActive == false)
                {
                    Response.SetProperty(WebResponse.Message, "Deactivated Successfully");
                }
                else
                {
                    Response.SetProperty(WebResponse.Message, "Activated Successfully");
                }

            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ActiveDeactiveData);
            }

            return Response;
        }
        private static CommunicationObject GetInActivecandidatecompetency(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            Candidate_Competency[] RoleData = HRManager.GetInactiveCandidatecompetency();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(Candidate_Competency));

            Builder.AddRow(RoleData);

            if (RoleData != null || RoleData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }


            return Response;
        }
        private static CommunicationObject Updatecandidatecompetency(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateAssetCandidateCompetencyRequest Request = new UpdateAssetCandidateCompetencyRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.UpdateCandidate_Competency(Request.ID, Request.CompetencyName, Request.Description, Request.ModifiedBy, Request.CreatedDate, Request.IsActive);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.ID == 0)
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.candidatecompetencyMessages.CANDIDATECOMPETANCY_ADDED_SUCCESS);
                else
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.candidatecompetencyMessages.CANDIDATECOMPETANCY_UPDATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        #endregion

        #region Employee Uploaded Attendance

        private static CommunicationObject GetUploadedEmpAttanceGrid(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            EmployeeUploadedAttandance[] Data = HRManager.GetUploadedEmpAttendanceGrid(Convert.ToInt32(Request.ID), Request.ChangedBy);

            JGridObjectBuilder Builder = new JGridObjectBuilder("EmployeeCode", typeof(EmployeeUploadedAttendanceDisplay));

            Builder.AddRow(Data);

            if (Data != null || Data.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }


            return Response;
        }

        private static CommunicationObject GetProjectCombo(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            ComboBoxValues[] combo = new Master_ProjectInformationBusinessObject().GetProjrctCombo();

            if (combo != null && combo.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, combo);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
            }

            return Response;
        }

        #endregion


    }
}
