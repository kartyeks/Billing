using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS91.Services;

namespace HRManager
{
    public class HRManagerDefs
    {
        public class DesignationMessages
        {
            #region Designation
            public static readonly String EMPTY_DESIGNATION = "Designation name cannot be empty";
            public static readonly String DESIGNATION_EXISTS = "The given Designation already exists";
            public static readonly String ROOT_DESIGNATION_NOT_ALLOWED = "The given Designation should not be equal to Kurlon";

            public static readonly String DESIGNATION_UPDATE_SUCCESS = "Designation details updated successfully";
            public static readonly String DESIGNATION_ADDED_SUCCESS = "Designation details added successfully";
            public static readonly String DESIGNATION_UPDATE_FAILURE = "Error on updating the Designation details";

            public static readonly String DEACTIVATE_SUCCESS = "Designation deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Designation activated successfully";
            public static readonly String NO_DESIGNATION = "No designation are available";

            public static readonly String DESIGNATION_REFERRED = "Designation is referred,cannot be deactivated";
            #endregion

        }


        public class GradeMessages
        {
            #region Grade
            public static readonly String EMPTY_GRADE = "Grade name cannot be empty";
            public static readonly String GRADE_EXISTS = "The given Grade already exists";

            public static readonly String GRADE_ADDED_SUCCESS = "Grade details added successfully";
            public static readonly String GRADE_UPDATE_SUCCESS = "Grade details updated successfully";
            public static readonly String GRADE_UPDATE_FAILURE = "Error on updating the Grade details";

            public static readonly String DEACTIVATE_SUCCESS = "Grade deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Grade activated successfully";

            public static readonly String GRADE_REFERED = "The selected Grade already referred";
            #endregion
        }

        public class ResourceRequestMessages
        {

            public static readonly String RESOURCEREQUEST_ADDED_SUCCESS = "Resource requested successfully";
            public static readonly String RESOURCEREQUEST_UPDATE_SUCCESS = "Requested resource updated successfully";
            public static readonly String RESOURCEREQUEST_UPDATE_FAILURE = "Error on requesting the Resource";
            // Status
            public static readonly String NEW = "NEW";
            public static readonly String MODIFIED = "MOD";
        }

        public class ZoneMessages
        {
            #region Zone
            public static readonly String EMPTY_ZONE = "Zone name cannot be empty";
            public static readonly String ZONE_EXISTS = "The given Zone already exists";

            public static readonly String ZONE_UPDATE_SUCCESS = "Zone details updated successfully";
            public static readonly String ZONE_ADDED_SUCCESS = "Zone details added successfully";
            public static readonly String ZONE_UPDATE_FAILURE = "Error on updating the Zone details";

            public static readonly String DEACTIVATE_SUCCESS = "Zone deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Zone activated successfully";
            #endregion
        }

        public class RoleMessages
        {
            #region Role
            public static readonly String EMPTY_ROLE = "Role name cannot be empty";
            public static readonly String ROLE_EXISTS = "The given Role already exists ";

            public static readonly String Role_UPDATE_SUCCESS = "Role details updated successfully";
            public static readonly String Role_ADDED_SUCCESS = "Role details added successfully";
            public static readonly String Role_UPDATE_FAILURE = "Error on updating the Role details";

            public static readonly String DEACTIVATE_SUCCESS = "Role deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Role activated successfully";
            public static readonly String NO_ROLE = "No role are available";
            public static readonly String ROLE_REFERED = "The selected Role already referred";
            public static readonly String ROLE_UPDATE_FAILURE = "Error on updating the Role details";
            public static readonly String ROLE_UPDATE_SUCCESS = "Role details updated successfully";
            public static readonly String ROLE_ADDED_SUCCESS = "Role details added successfully";
            #endregion
        }
        public class DepartmentMessages
        {
            #region Department
            public static readonly String EMPTY_DEPARTMENT = "Department name cannot be empty";
            public static readonly String DEPARTMENT_EXISTS = "The given Department already exists";
            public static readonly String ROOT_DEPARTMENT_NOT_ALLOWED = "The given Department should not be equal to Kurlon";

            public static readonly String DEPARTMENT_ADDED_SUCCESS = "Department details added successfully";
            public static readonly String DEPARTMENT_UPDATE_SUCCESS = "Department details updated successfully";
            public static readonly String DEPARTMENT_UPDATE_FAILURE = "Error on updating the Department details";
            #endregion
        }
        public class CountrytMessages
        {
            #region Country
            public static readonly String EMPTY_COUNTRY = "Country name cannot be empty";
            public static readonly String COUNTRY_EXISTS = "The given Country already exists";
            public static readonly String COUNTRY_REFERED = "The Country is already referred";
            // public static readonly String ROOT_COUNTRY_NOT_ALLOWED = "The given Department should not be equal to Kurlon";

            public static readonly String COUNTRY_ADDED_SUCCESS = "Country added successfully";
            public static readonly String COUNTRY_UPDATE_SUCCESS = "Country updated successfully";
            public static readonly String COUNTRY_UPDATE_FAILURE = "Error on updating the Country details";
            #endregion

        }
        public class HolidaysMessages
        {
            #region Holiday
            public static readonly String EMPTY_HOLIDAY = "Holiday name cannot be empty";
            public static readonly String HOLIDAY_EXISTS = "The given Holiday already exists";
            // public static readonly String ROOT_COUNTRY_NOT_ALLOWED = "The given Department should not be equal to Kurlon";

            public static readonly String HOLIDAY_ADDED_SUCCESS = "Holiday added successfully";
            public static readonly String HOLIDAY_UPDATE_SUCCESS = "Holiday updated successfully";
            public static readonly String HOLIDAY_UPDATE_FAILURE = "Error on updating the Holiday details";
            #endregion

        }
        public class candidatecompetencyMessages
        {
            #region candidatecompetency
            public static readonly String EMPTY_CANDIDATE_COMPETANCY = "Candidate Competency Cannot be empty";
            public static readonly String CANDIDATECOMPETANCY_EXISTS = "The given Candidate Competency already exists ";

            public static readonly String CANDIDATECOMPETANCY_UPDATE_SUCCESS = "Candidate Competency details updated successfully";
            public static readonly String CANDIDATECOMPETANCY_ADDED_SUCCESS = "Candidate Competency details added successfully";
            public static readonly String CANDIDATECOMPETANCY_UPDATE_FAILURE = "Error on updating the Candidate Ccompetency details";

            public static readonly String DEACTIVATE_SUCCESS = "Candidate Competency deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Candidate Competency activated successfully";
            #endregion
        }
        public class AssetCategoryMessages
        {
            #region Manufacturer
            public static readonly String EMPTY_ASSET_CATEGORY = "Asset category cannot be empty";
            public static readonly String ASSET_CATEGORY_EXISTS = "The given Asset category already exists ";

            public static readonly String ASSET_CATEGORY_UPDATE_SUCCESS = "Asset category details updated successfully";
            public static readonly String ASSET_CATEGORY_ADDED_SUCCESS = "Asset category details added successfully";
            public static readonly String ASSET_CATEGORY_UPDATE_FAILURE = "Error on updating the Asset category details";

            public static readonly String DEACTIVATE_SUCCESS = "Assetcategory deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Assetcategory activated successfully";
            #endregion

        }
        public class ManageAssets
        {
            public static readonly String MANAGE_ASSET_EXISTS = "The given asset name already exists ";

            public static readonly String MANAGE_ASSET_UPDATE_SUCCESS = "Asset details updated successfully";
            public static readonly String MANAGE_ASSET_ADDED_SUCCESS = "Asset details added successfully";
            public static readonly String MANAGE_ASSET_UPDATE_FAILURE = "Error on updating the Asset details";
            public static readonly String MANAGE_ASSET_REFER = "Selected asset is referred you can't delete";
            public static readonly String MANAGE_ASSET_DELETE = "Asset details deleted successfully";
        }

        public class AssignAssets
        {
            public static readonly String ASSIGN_ASSET_EXISTS = "The selected asset is assigned,not yet returned ";

            public static readonly String ASSIGN_ASSET_UPDATE_SUCCESS = "Assign asset details updated successfully";
            public static readonly String ASSIGN_ASSET_ADDED_SUCCESS = "Assign asset details added successfully";
            public static readonly String ASSIGN_ASSET_UPDATE_FAILURE = "Error on updating the assign asset details";
        }
        public class OutgoingAssets
        {
            public static readonly String OUGOING_ASSET_EXISTS = "The selected asset is already allocated,not yet returned ";

            public static readonly String OUTGOING_ASSET_UPDATE_SUCCESS = "Outgoing asset details updated successfully";
            public static readonly String OUTGOING_ASSET_ADDED_SUCCESS = "Outgoing asset details added successfully";
            public static readonly String OUTGOING_ASSET_UPDATE_FAILURE = "Error on updating the outgoing asset details";
        }
        public class AssetSubCategoryMessages
        {
            #region Manufacturer
            public static readonly String EMPTY_ASSET_SUB_CATEGORY = "Asset SubCategory cannot be empty";
            public static readonly String ASSET_SUB_CATEGORY_EXISTS = "The given Asset SubCategory already exists ";

            public static readonly String ASSET_SUB_CATEGORY_UPDATE_SUCCESS = "Asset SubCategory details updated successfully";
            public static readonly String ASSET_SUB_CATEGORY_ADDED_SUCCESS = "Asset SubCategory details added successfully";
            public static readonly String ASSET_SUB_CATEGORY_UPDATE_FAILURE = "Error on updating the Asset SubCategory details";

            public static readonly String DEACTIVATE_SUCCESS = "Asset SubCategory deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Asset SubCategory activated successfully";
            #endregion
        }
        public class ManufacturerMessages
        {
            #region Manufacturer
            public static readonly String EMPTY_MANUFACTURER = "Manufacturer Name cannot be empty";
            public static readonly String MANUFACTURER_EXISTS = "The given Manufacturer Name already exists ";

            public static readonly String MANUFACTURER_UPDATE_SUCCESS = "Manufacturer details updated successfully";
            public static readonly String MANUFACTURER_ADDED_SUCCESS = "Manufacturer details added successfully";
            public static readonly String MANUFACTURER_UPDATE_FAILURE = "Error on updating the Manufacturer details";

            public static readonly String DEACTIVATE_SUCCESS = "Manufacturer deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Manufacturer activated successfully";
            #endregion
        }
        public class InterviewTypesMessages
        {
            #region InterviewType
            public static readonly String EMPTY_INTERVIEWTYPE = "Interview Type cannot be empty";
            public static readonly String INTERVIEWTYPE_EXISTS = "The given Interview Type already exists ";

            public static readonly String INTERVIEWTYPE_UPDATE_SUCCESS = "Interview Type details updated successfully";
            public static readonly String INTERVIEWTYPE_ADDED_SUCCESS = "Interview Type details added successfully";
            public static readonly String INTERVIEWTYPE_UPDATE_FAILURE = "Error on updating the Interview Type details";

            public static readonly String DEACTIVATE_SUCCESS = "Interview Type deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Interview Type activated successfully";
            #endregion
        }
        public class MaritalStatusMessages
        {
            #region InterviewType
            public static readonly String NO_MARITALSTATUS = "No Marital Status are available";
            public static readonly String EMPTY_MARITALSTATUS = " Marital Status cannot be empty";
            public static readonly String MARITALSTATUS_EXISTS = "The given  Marital Status already exists ";

            public static readonly String MARITALSTATUS_UPDATE_SUCCESS = "Marital Status details updated successfully";
            public static readonly String MARITALSTATUS_ADDED_SUCCESS = "Marital Status details added successfully";
            public static readonly String MARITALSTATUS_UPDATE_FAILURE = "Error on updating the Marital Status details";

            public static readonly String DEACTIVATE_SUCCESS = "Marital Status deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Marital Status activated successfully";
            #endregion
        }

        public class SkillMessages
        {
            #region Skill
            public static readonly String EMPTY_SKILL = "Skill name cannot be empty";
            public static readonly String SKILL_EXISTS = "The given Skill already exists";

            public static readonly String SKILL_UPDATE_SUCCESS = "Skill details updated successfully";
            public static readonly String SKILL_ADDED_SUCCESS = "Skill details added successfully";
            public static readonly String SKILL_UPDATE_FAILURE = "Error on updating the Skill details";

            public static readonly String DEACTIVATE_SUCCESS = "Skill deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Skill activated successfully";
            #endregion
        }
        public class JobProfileMessages
        {
            #region JobProfile
            public static readonly String EMPTY_JOBPROFILE = "JobProfile name cannot be empty";
            public static readonly String JOBPROFILE_EXISTS = "Job Code already exists";
            public static readonly String JOBPROFILELOCDEG_EXISTS = "Job profile already exists for this designation and location";

            public static readonly String JOBPROFILE_UPDATE_SUCCESS = "JobProfile details updated successfully";
            public static readonly String JOBPROFILE_ADDED_SUCCESS = "JobProfile details added successfully";
            public static readonly String JOBPROFILE_UPDATE_FAILURE = "Error on updating the JobProfile details";

            public static readonly String DEACTIVATE_SUCCESS = "JobProfile deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "JobProfile activated successfully";

            public static readonly String NO_JOB = "No Job";


            #endregion
        }

        /// <summary>
        /// Contains the static string which will be related to Role / Skill
        /// </summary>
        public class RoleSkillMessages
        {
            public static readonly String NO_ROLE = "No roles are available";
            public static readonly String NO_SKILL = "No skills are available";
        }

        public class LocationTypeMessages
        {
            #region LocationType
            public static readonly String EMPTY_LocationTypeName = "Location Type cannot be empty";
            public static readonly String LOCATIONTYPE_EXISTS = "The given Location Type already exists ";

            public static readonly String LOCATIONTYPE_UPDATE_SUCCESS = "Location type details updated successfully";
            public static readonly String LOCATIONTYPE_ADDED_SUCCESS = "Location type details added successfully";
            public static readonly String LOCATIONTYPE_UPDATE_FAILURE = "Error on updating the Location Type details";

            public static readonly String DEACTIVATE_SUCCESS = "Location Type deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Location Type activated successfully";

            public static readonly String LOCATIONTYPE_REFERED = "The selected location Type already referred";
            #endregion
        }

        public class LocationMessages
        {
            #region Location
            public static readonly String EMPTY_LocationName = "Location cannot be empty";
            public static readonly String LOCATION_EXISTS = "The given Location Name already exists ";

            public static readonly String LOCATION_UPDATE_SUCCESS = "Location details updated successfully";
            public static readonly String LOCATION_ADDED_SUCCESS = "Location details added successfully";
            public static readonly String LOCATION_UPDATE_FAILURE = "Error on updating the Location details";

            public static readonly String DEACTIVATE_SUCCESS = "Location deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Location activated successfully";
            public static readonly String NO_LOCATIONTYPE = "No location types are available";

            public static readonly String NO_LOCATION = "No locations are available";

            public static readonly String LOCATION_REFERED = "The selected Location already referred";

            public static readonly String NO_COUNTRY = "No countries are available";
            #endregion
        }
        #region Investment
        public class InvestmentMessages
        {
            
            public static readonly String NO_INVESTMENT = "No Investment";

            public static readonly String EMPTY_INVESTMENT = "Investment name cannot be empty";
            public static readonly String INVESTMENT_EXISTS = "The given Investment already exists ";

            public static readonly String INVESTMENT_UPDATE_SUCCESS = "Investment details updated successfully";
            public static readonly String INVESTMENT_ADDED_SUCCESS = "Investment details added successfully";
            public static readonly String INVESTMENT_UPDATE_FAILURE = "Error on updating the Investment details";

            public static readonly String DEACTIVATE_SUCCESS = "Investment deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Investment activated successfully";


        }
        #endregion

        //kartyek 17.02.2015 ProjectInfo/Details

        #region ProjectInfo
        public class ProjectInfoMessages
        {

            public static readonly String NO_PROJECTINFO = "No Project";

            public static readonly String EMPTY_PROJECTINFO = "Project name cannot be empty";
            public static readonly String PROJECTINFO_EXISTS = "The given Project name already exists ";

            public static readonly String PROJECTINFO_UPDATE_SUCCESS = "Project details updated successfully";
            public static readonly String PROJECTINFO_ADDED_SUCCESS = "Project details added successfully";
            public static readonly String PROJECTINFO_UPDATE_FAILURE = "Error on updating the Project details";

            public static readonly String DEACTIVATE_SUCCESS = "Project details deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Project details activated successfully";


        }
        #endregion

        #region CompanyDetails
        public class CompanyMessages
        {

            public static readonly String NO_COMPANY = "No Company";

            public static readonly String EMPTY_COMPANY = "Company name cannot be empty";
            public static readonly String COMPANY_EXISTS = "The given Company already exists ";

            public static readonly String COMPANY_UPDATE_SUCCESS = "Company details updated successfully";
            public static readonly String COMPANY_ADDED_SUCCESS = "Company details added successfully";
            public static readonly String COMPANY_UPDATE_FAILURE = "Error on updating the Relation details";

            public static readonly String DEACTIVATE_SUCCESS = "Company deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Company activated successfully";


        }
        #endregion
        public class RelationMessages
        {
            #region Relation
            public static readonly String NO_RELATION = "No Relation";

            public static readonly String EMPTY_Relation = "Relation name cannot be empty";
            public static readonly String Relation_EXISTS = "The given Relation already exists ";

            public static readonly String Relation_UPDATE_SUCCESS = "Relation details updated successfully";
            public static readonly String Relation_ADDED_SUCCESS = "Relation details added successfully";
            public static readonly String Relation_UPDATE_FAILURE = "Error on updating the Relation details";

            public static readonly String DEACTIVATE_SUCCESS = "Relation deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Relation activated successfully";
            #endregion

        }

        public class CandidatePersonalInfoMessages
        {
            #region CandidatePersonalInfo
            public static readonly String NO_CANDIDATEINFO = "Candidate Info not available";
            public static readonly String EMPTY_FIRSTNAME = "First name cannot be empty";
            public static readonly String EMPTY_LASTNAME = "Last name cannot be empty";
            public static readonly String CANDIDATE_EXISTS = "The given Candidate already exists";
            public static readonly String CANDIDATE_UPDATE_SUCCESS = "Candidate details updated successfully";
            public static readonly String CANDIDATE_ADDED_SUCCESS = "Candidate details added successfully";
            public static readonly String CANDIDATE_UPDATE_FAILURE = "Error on updating the Candidate personal info";

            public static readonly String CANDIDATE_REJECTED_SUCCESS = "Candidate rejected successfully";
            public static readonly String CANDIDATE_APPROVED_SUCCESS = "Candidate approved successfully";

            public static readonly String CANDIDATE_REJECTED_FAILURE = "Error on rejecting the Candidate personal info";
            public static readonly String CANDIDATE_APPROVED_FAILURE = "Error on approving the Candidate personal info";


            #endregion
        }

        public class Family_DetailsMessages
        {
            #region CandidateFamilyDetails
            public static readonly String EMPTY_FAMILY_DETAILS = "Family details cannot be empty";
            public static readonly String FAMILY_DETAILS_EXISTS = "The given Family details already exists";
            public static readonly String FAMILY_UPDATE_SUCCESS = "Family details added successfully";
            public static readonly String FAMILY_UPDATE_FAILURE = "Error on updating the Family info";
            #endregion
        }
        public class CandidateSkill
        {
            #region CandidateSkill
            public static readonly String EMPTY_SKILL_DETAILS = "Skill details cannot be empty";
            public static readonly String SKILL_DETAILS_EXISTS = "The given Skill details already exists";
            public static readonly String SKILL_UPDATE_SUCCESS = "Skill details added successfully";
            public static readonly String SKILL_UPDATE_FAILURE = "Error on updating the Skill info";
            #endregion
        }
        public class CandidateTraining
        {
            #region CandidateTraining
            public static readonly String EMPTY_TRAINING_DETAILS = "Training details cannot be empty";
            public static readonly String TRAINING_DETAILS_EXISTS = "The given Training details already exists";
            public static readonly String TRAINING_UPDATE_SUCCESS = "Training details added successfully";
            public static readonly String TRAINING_UPDATE_FAILURE = "Error on updating the Training info";
            #endregion
        }
        public class CandidateLaguages
        {
            #region CandidateLaguages
            public static readonly String LANGUAGE_UPDATE_SUCCESS = "Candidate Languages details updated successfully";
            public static readonly String LANGUAGE_UPDATE_FAILURE = "Error on updating the Candidate Languages info";
            #endregion
        }

        public class CandidateQuestioners
        {
            #region CandidateQuestioners
            public static readonly String NO_CANDIDATEINFO = "Candidate Info not available";
            public static readonly String QUESTION_UPDATE_SUCCESS = "Candidate Questioners details updated successfully";
            public static readonly String QUESTION_UPDATE_FAILURE = "Error on updating the Candidate Questioners info";
            #endregion
        }

        public class CandidateCurreEmplo
        {
            #region CandidateCurreEmplo
            public static readonly String NO_CANDIDATEINFO = "Candidate Info not available";
            public static readonly String CURRENTEMP_UPDATE_SUCCESS = "Candidate CurrentEmployer details updated successfully";
            public static readonly String CURRENTEMP_UPDATE_FAILURE = "Error on updating the Candidate CurrentEmployer info";
            #endregion
        }

        public class CandidatePrevEmplo
        {
            #region CandidatePrevEmplo
            public static readonly String PREVIOUSEMP_UPDATE_SUCCESS = "Candidate PreviousEmployer details updated successfully";
            public static readonly String PREVIOUSEMP_UPDATE_FAILURE = "Error on updating the Candidate PreviousEmployer info";
            #endregion
        }

        public class CandidateEducational
        {
            #region CandidateEducational
            public static readonly String EDUCATION_UPDATE_SUCCESS = "Candidate Education details updated successfully";
            public static readonly String EDUCATION_UPDATE_FAILURE = "Error on updating the Candidate Education info";
            #endregion
        }

        public class ScheduleInterview
        {
            #region ScheduleInterview
            public static readonly String SCHEDULEINTERVIEW_UPDATE_SUCCESS = "Candidate Interview Schedule details updated successfully";
            public static readonly String SCHEDULEINTERVIEW_ADDED_SUCCESS = "Candidate Interview Schedule details added successfully";
            public static readonly String SCHEDULEINTERVIEW_UPDATE_FAILURE = "Error on updating the Candidate Interview Schedule info";
            public static readonly String HIRE_CANDIDATE_SUCCESS = "Candidate hired successfully";
            public static readonly String REJECT_CANDIDATE_SUCCESS = "Candidate rejected successfully";
            public static readonly String HIRE_CONFIRM_SUCCESS = "Candidate hired";
            public static readonly String REJECT_CONFIRM_SUCCESS = "Candidate rejected";
            public static readonly String APPROVE_CANDIDATE_SUCCESS = "Candidate Salary Approved Successfully";

            public static readonly String REJECT_CANDIDATE_FAILURE = "Fail to reject candidate";
            #endregion
        }

        public class InterviewRoundMessages
        {
            #region InterviewRound
            public static readonly String EMPTY_INTERVIEWROUND = "Interview Round cannot be empty";
            public static readonly String INTERVIEWROUND_EXISTS = "The given Interview Round already exists";

            public static readonly String INTERVIEWROUND_UPDATE_SUCCESS = "Interview Round details updated successfully";
            public static readonly String INTERVIEWROUND_ADDED_SUCCESS = "Interview Round details added successfully";
            public static readonly String INTERVIEWROUND_UPDATE_FAILURE = "Error on updating the Interview Round details";

            public static readonly String DEACTIVATE_SUCCESS = "Interview Round deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Interview Round activated successfully";
            #endregion
        }

        public class ShiftMessages
        {
            #region Shifts
            public static readonly String EMPTY_SHIFT = "Shift name cannot be empty";
            public static readonly String SHIFT_EXISTS = "The given Shift already exists ";

            public static readonly String SHIFT_UPDATE_SUCCESS = "Shift details updated successfully";
            public static readonly String SHIFT_ADDED_SUCCESS = "Shift details added successfully";
            public static readonly String SHIFT_UPDATE_FAILURE = "Error on updating the Shift details";

            public static readonly String DEACTIVATE_SUCCESS = "Shift deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Shift activated successfully";
            public static readonly String NO_SHIFT = "No shifts are available";
            public static readonly String HASREFERENCE_SHIFT = "Shift is assigened to employees , do you want to deactivate?";
            #endregion
        }

        public class EmployeeShiftMessages
        {
            #region EmployeeShift
            public static readonly String SHIFT_EXISTS = "The Selected Shift already exists for this Employee ";

            public static readonly String SHIFT_UPDATE_SUCCESS = "Shift details updated successfully for an employee";
            public static readonly String SHIFT_ADDED_SUCCESS = "Shift details added successfully for an employee";
            public static readonly String SHIFT_UPDATE_FAILURE = "Error on updating the Shift details for an employee";

            public static readonly String DEACTIVATE_SUCCESS = "Shift deactivated successfully for an employee";
            public static readonly String ACTIVATE_SUCCESS = "Shift activated successfully for an employee";
            #endregion
        }
        public class BranchMessages
        {
            #region Branch
            public static readonly String EMPTY_BRANCHNAME = "Branch name cannot be empty";
            public static readonly String BRANCHNAME_EXISTS = "The given Branch name already exists";
            public static readonly String EMPTY_BRANCHCODE = "Branch code cannot be empty";
            public static readonly String BRANCHCODE_EXISTS = "The given Branch code already exists";
            public static readonly String BRANCHLOC_EXISTS = "The given Branch name for this Location exists already";

            public static readonly String BRANCH_ADDED_SUCCESS = "Branch details added successfully";
            public static readonly String BRANCH_UPDATE_SUCCESS = "Branch details updated successfully";
            public static readonly String BRANCH_UPDATE_FAILURE = "Error on updating the Branch details";

            public static readonly String DEACTIVATE_SUCCESS = "Branch deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Branch activated successfully";

            public static readonly String BRANCH_REFERED = "The selected Branch already referred";

            #endregion
        }

        public class BankBranchMessages
        {
            #region BankBranch
            public static readonly String EMPTY_BANKBRANCHNAME = "Bank Branch name cannot be empty";
            public static readonly String BANKBRANCHNAME_EXISTS = "The given Bank Branch name already exists";
            public static readonly String EMPTY_BANKBRANCHCODE = "Bank Branch code cannot be empty";
            public static readonly String BANKBRANCHCODE_EXISTS = "The given Bank Branch code already exists";
            public static readonly String BANKBRANCH_EXISTS = "Branch For Selected Bank already exists";

            public static readonly String BANKBRANCH_ADDED_SUCCESS = "Bank Branch details added successfully";
            public static readonly String BANKBRANCH_UPDATE_SUCCESS = "Bank Branch details updated successfully";
            public static readonly String BANKBRANCH_UPDATE_FAILURE = "Error on updating the Bank Branch details";

            public static readonly String DEACTIVATE_SUCCESS = "Bank Branch deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Bank Branch activated successfully";
            #endregion
        }

        public class PolicyTypeMessages
        {
            #region PolicyType
            public static readonly String EMPTY_POLICYTYPE = "Policy Type Name cannot be Empty";
            public static readonly String POLICYTYPE_EXISTS = "The Given Policy Type Already Exists";

            public static readonly String POLICYTYPE_UPDATE_SUCCESS = "Policy Type Updated successfully";
            public static readonly String POLICYTYPE_ADDED_SUCCESS = "Policy Type Added Successfully";
            public static readonly String POLICYTYPE_UPDATE_FAILURE = "Error on Updating the Policy Type";

            public static readonly String DEACTIVATE_SUCCESS = "Policy Type deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Policy Type activated successfully";

            public static readonly String NO_ACTIVE_POLICYTYPE = "No Active Policy Type Present";
            public static readonly String POLICYTYPE_REFERED = "The selectecd Policy Type already referred";

            #endregion
        }

        public class PolicyMessages
        {
            #region Policy
            public static readonly String EMPTY_POLICY = "Policy Name cannot be Empty";
            public static readonly String POLICY_EXISTS = "The given Policy Already Exists";

            public static readonly String POLICY_UPDATE_SUCCESS = "Policy Updated Successfully";
            public static readonly String POLICY_ADDED_SUCCESS = "Policy Added Successfully";
            public static readonly String POLICY_UPDATE_FAILURE = "Error on Updating the Policy ";
            public static readonly String POLICY_DELETE_SUCCESS = "Policy Deleted Successfully";
            public static readonly String POLICY_DELETE_FAILURE = "Error on Deleting the Policy";


            public static readonly String POLICYCHANGES_UPDATE_SUCCESS = "Policy Changes Updated Successfully";
            public static readonly String POLICYCHANGES_ADDED_SUCCESS = "Policy Changes Added Successfully";

            public static readonly String POLICY_UNPUBLISH_FAILURE = "Error on Unpublishing the Policy";
            public static readonly String POLICY_UNPUBLISH_SUCCESS = "Policy Unpublished Successfully";

            public static readonly String DEACTIVATE_SUCCESS = "Policy Deactivated Successfully";
            public static readonly String ACTIVATE_SUCCESS = "Policy Activated Successfully";

            public static readonly String POLICY_REJECTED_SUCCESS = "Policy Rejected Successfully";
            public static readonly String POLICY_REJECTED_FAILURE = "Error on Rejecting the Policy";

            public static readonly String POLICY_APPROVE_SUCCESS = "Policy Approved successfully";
            public static readonly String POLICY_APPROVE_FAILURE = "Error on approving the Policy";

            public static readonly String PUBLISH_POLICY_SUCCESS = "Policy Published successfully";
            public static readonly String PUBLISH_POLICY_FAILURE = "Error on publishing the Policy";

            public static readonly String PUBLISH_POLICY_REJECT = "Requesting managers needs to give confirmation for the published policy";
            public static readonly String POLICY_CHANGE_DELETE_SUCCESS = "Policy change deleted successfully";
            public static readonly String POLICY_CHANGE_DELETE_FAILURE = "Error on deleting the Policy change";

            public static readonly String POLICY_CHANGE_ACCEPT_SUCCESS = "Policy change accepted successfully";
            public static readonly String POLICY_CHANGE_ACCEPT_FAILURE = "Error on accepting the Policy change";
            public static readonly String POLICY_CHANGE_REJECT_SUCCESS = "Policy change rejected successfully";
            public static readonly String POLICY_CHANGE_REJECT_FAILURE = "Error on rejecting the Policy change";

            #endregion
        }

        public class LoanMessages
        {
            #region Loan
            public static readonly String EMPTY_LOAN = "Loan name cannot be empty";
            public static readonly String LOAN_EXISTS = "The given Loan already exists";

            public static readonly String LOAN_UPDATE_SUCCESS = "Loan details updated successfully";
            public static readonly String LOAN_ADDED_SUCCESS = "Loan details added successfully";
            public static readonly String LOAN_UPDATE_FAILURE = "Error on updating the Loan details";

            public static readonly String DEACTIVATE_SUCCESS = "Loan deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Loan activated successfully";
            public static readonly String NO_LOANTYPE = "No Loan types are available";

            public static readonly String LOAN_REFERED = "The selected Loan is already referred";


            #endregion
        }

        public class InsuranceMessages
        {
            #region Insurance
            public static readonly String EMPTY_INSURANCE = "Insurance name cannot be empty";
            public static readonly String INSURANCE_EXISTS = "The given Insurance already exists";

            public static readonly String INSURANCE_ADDED_SUCCESS = "Insurance details added successfully";
            public static readonly String INSURANCE_UPDATE_SUCCESS = "Insurance details updated successfully";
            public static readonly String INSURANCE_UPDATE_FAILURE = "Error on updating the Insurance details";

            public static readonly String DEACTIVATE_SUCCESS = "Insurance deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Insurance activated successfully";
            #endregion
        }

        public class JobAgencyMessages
        {
            #region Job Agency Messages
            public static readonly String EMPTY_JOBAGENCY = "Job Agency name cannot be empty";
            public static readonly String JOBAGENCY_EXISTS = "The given Job Agency already exists";

            public static readonly String JOBAGENCY_ADDED_SUCCESS = "Job Agency details added successfully";
            public static readonly String JOBAGENCY_UPDATE_SUCCESS = "Job Agency details updated successfully";
            public static readonly String JOBAGENCY_UPDATE_FAILURE = "Error on updating the Job Agency details";
            public static readonly String JOBAGENCY_NOTIFY_SUCCESS = "Job Agency details Notify successfully";
            public static readonly String JOBAGENCY_NOTIFYE_FAILURE = "Error on updating the Job Agency details";

            public static readonly String DEACTIVATE_SUCCESS = "Job Agency deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Job Agency activated successfully";
            #endregion
        }

        public class AssetMessages
        {
            #region Asset
            public static readonly String EMPTY_Asset = "Asset name cannot be empty";
            public static readonly String Asset_EXISTS = "The given Asset already exists ";

            public static readonly String Asset_UPDATE_SUCCESS = "Asset details updated successfully";
            public static readonly String Asset_ADDED_SUCCESS = "Asset details added successfully";
            public static readonly String Asset_UPDATE_FAILURE = "Error on updating the Asset details";

            public static readonly String DEACTIVATE_SUCCESS = "Asset deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Asset activated successfully";
            public static readonly String NO_ASSET = "No Assets are available";
            #endregion
        }

        public class InterviewedCandidateSelected
        {
            #region InterviewedCandidateSelected
            public static readonly String SELECTEDCANDIDATE_OFFER_SUCCESS = "Selected Candidate Offer Issued successfully";
            public static readonly String SELECTEDCANDIDATE_CLOSE_SUCCESS = "Candidate Closed successfully";
            public static readonly String SELECTEDCANDIDATE_UPDATE_FAILURE = "Error on updating the Selected Candidate info";
            public static readonly String SELECTEDCANDIDATE_SELECT_SUCCESS = "Candidate Selected successfully";
            #endregion
        }

        public class ReimbursementTypeMessages
        {
            #region ReimbursementType
            public static readonly String EMPTY_REIMBURSEMENTTYPE = "Reimbursement Type name cannot be empty";
            public static readonly String REIMBURSEMENTTYPE_EXISTS = "The given Reimbursement Type already exists";

            public static readonly String REIMBURSEMENTTYPE_UPDATE_SUCCESS = "Reimbursement Type details updated successfully";
            public static readonly String REIMBURSEMENTTYPE_ADDED_SUCCESS = "Reimbursement Type details added successfully";
            public static readonly String REIMBURSEMENTTYPE_UPDATE_FAILURE = "Error on updating the Reimbursement Type details";

            public static readonly String DEACTIVATE_SUCCESS = "Reimbursement Type deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Reimbursement Type activated successfully";

            public static readonly String NO_ACTIVE_REIMBURSEMENTTYPE = "No Active Reimbursement Type Present";

            public static readonly String REIMBURSEMENT_REFERED = "The selected Reimbusement is already referred";
            #endregion
        }
        public class LoanGradeMessages
        {
            #region LoanGrade
            public static readonly String LOANGRADE_EXISTS = "The given Loan Grade Type already exists";

            public static readonly String LOANGRADE_UPDATE_SUCCESS = "Loan Grade details updated successfully";
            public static readonly String LOANGRADE_ADDED_SUCCESS = "Loan Grade details added successfully";
            public static readonly String LOANGRADE_UPDATE_FAILURE = "Error on updating the Loan Grade details";

            #endregion
        }

        public class ReimbursementTypeGradeMessages
        {
            #region ReimbursementTypeGrade
            public static readonly String REIMBURSEMENTTYPEGRADE_EXISTS = "The given Reimbursement Type Grade already exists";

            public static readonly String REIMBURSEMENTTYPEGRADE_UPDATE_SUCCESS = "Reimbursement Type Grade details updated successfully";
            public static readonly String REIMBURSEMENTTYPEGRADE_ADDED_SUCCESS = "Reimbursement Type Grade details added successfully";
            public static readonly String REIMBURSEMENTTYPEGRADE_UPDATE_FAILURE = "Error on updating the Reimbursement Type Grade details";
            public static readonly String NO_REIMBURSEMENTTYPE = "No Reimbursement Type are available";
            #endregion
        }
        public class LeaveMessages 
        {
            #region Leave
            public static readonly String LEAVE_ADDED_SUCCESS = "Leave request submitted successfully";
            public static readonly String LEAVE_UPDATE_SUCCESS = "Modified Successfully";
            public static readonly String LEAVE_REQUEST_DELETED = "Deleted successfully";
            public static readonly String LEAVE_APP_SUCCESS = "Approved Successfully";
            public static readonly String LEAVE_REJ_SUCCESS = "Rejected successfully";


            public static readonly String EMPTY_LEAVE = "Leave name cannot be empty";
            public static readonly String LEAVE_EXISTS = "The given Leave already exists";


            public static readonly String LEAVE_UPDATE_FAILURE = "Error on updating the Leave details";

            public static readonly String NOT_ELIGBLE = " You are not eligible for apply this leave";
            public static readonly String INVALID_POST_SUBMITION = " {0} canot be requested for past dates";

            public static readonly String DEACTIVATE_SUCCESS = "Leave deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Leave activated successfully";
            public static readonly String NO_LEAVETYPE = "No Leave Types";
            public static readonly String INVALID_LEAVE_REQUEST = "{0} can't be applied for more than {1} consecutive days and it should not be less than {2} day(s).";
            public static readonly String ONLY_FEMALE = "This Leave is only for Female employees";
            public static readonly String MATERNITY_LEAVE_NOT_ACTIVE = " Days after the Joining,maternity Leave Activate";
            public static readonly String MATERNITY_LEAVE_COUNT = " Times maternity leave allowed";
            public static readonly String MATERNITY_YEAR_COUNT = " Times maternity leave allowed";
            public static readonly String MATERNITY_LEAVE_DIFFERENCE = "This Leave Type activated as per policy";
            public static readonly String NOT_EDITABLE_LEAVE = "This Leave cannot edit";
            public static readonly String INVALID_LEAVE_DAYS = "Requested Leaves can't be Friday To Monday.";
            public static readonly String INVALID_EXTEND_FROM_DATE = "The the starting can't be edited.";
            public static readonly String INVALID_EXTEND_END_DATE = "The the starting can't be less than the aproved leave.";
            public static readonly String PROVIDE_ADDRESS = "Please provide us the contact address to proceed the requested leave.";
            public static readonly String PROVIDE_PHONE = "Please provide us the contact number to proceed the requested leave.";
            public static readonly String LEAVE_MORETHAN_AVAIL = "Leave cannot be applied for days more than the available leave balance.";
            public static readonly String SICKLEAVE_IN_POSTDATE = "You can't apply sick leave for a future date.";
            public static readonly String UPLOAD_DOCUMENT = "Please upload the document to proceed the requested leave.";
            public static readonly String NOT_CONFIRMED = "Employee Not Confirmed";
            public static readonly String CANNOT_TAKE_LEAVE = "Cannot take leave.already leave has been issued for the define period.";
            public static readonly String DELETE_FAILURE = "Error on Deleting Leave Request";
            #endregion

        }

        public class EmailMessages
        {
            #region Email
            public static readonly String TOADDRESS_EMPTY = "To Address is empty";

            #endregion

        }
        public class LeaveEmpTypeMessages
        {
            #region LeaveGrade
            public static readonly String LEAVEEMPTYPE_EXISTS = "The given Leave Grade Type already exists";

            public static readonly String NO_LEAVETYPE = "The given Leave Grade Type already exists";
            public static readonly String LEAVEEMPTYPE_UPDATE_SUCCESS = "Leave Grade details updated successfully";
            public static readonly String LEAVEEMPTYPE_ADDED_SUCCESS = "Leave Grade details added successfully";
            public static readonly String LEAVEEMPTYPE_UPDATE_FAILURE = "Error on updating the Leave Grade details";
            public static readonly String CARRY_COUNT_MORE_THAN_LEAVES = "Carry forward count is greater than number of assigned leaves.";
            public static readonly String ENCASH_COUNT_MORE_THAN_LEAVES = "Encashment count is greater than number of assigned leaves.";
            public static readonly String LEAVEEMPTYPE_DEACTIVATE_SUCCESS = "Leave Grade deactivated successfully";
            public static readonly String LEAVEEMPTYPE_DEACTIVATE_ERROR = "Error while Deactivating Leave Grade";
            public static readonly String LEAVEEMPTYPE_ACTIVATE_SUCCESS = "Leave Grade activated successfully";
            public static readonly String LEAVEEMPTYPE_DEACTIVATE_ERROR_REASON1 = "Pending Leave Requests exist for this assign leave. this assigned Leave cannot be deactivated.";
            public static readonly String LEAVE_REQUEST_DELETED = "Leave deleted successfully";
            #endregion
        }


        public class BankMessages
        {
            #region Bank
            public static readonly String EMPTY_BANK = "Bank name cannot be empty";
            public static readonly String BANKCODE_EXISTS = "The Entered Bank Code already exists";
            public static readonly String BANKNAME_EXISTS = "The Entered Bank Name already exists";

            public static readonly String BANK_UPDATE_SUCCESS = "Bank details updated successfully";
            public static readonly String BANK_ADDED_SUCCESS = "Bank details added successfully";
            public static readonly String BANK_UPDATE_FAILURE = "Error on updating the Bank details";

            public static readonly String DEACTIVATE_SUCCESS = "Bank deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Bank activated successfully";
            //public static readonly String NO_LEAVETYPE = "No Leave Types";
            //public static readonly String NO_Leave = "No Leave are available";
            public static readonly String BANK_REFERED = "The selected BankName is already referred";

            #endregion

        }


        public class EmployeeTypeMessages
        {
            #region EmployeeType
            public static readonly String EMPTY_EMPLOYEETYPE = "EmployeeType name cannot be empty";
            public static readonly String EMPLOYEETYPE_EXISTS = "The given EmployeeType already exists";

            public static readonly String EMPLOYEETYPE_ADDED_SUCCESS = "EmployeeType details added successfully";
            public static readonly String EMPLOYEETYPE_UPDATE_SUCCESS = "EmployeeType details updated successfully";
            public static readonly String EMPLOYEETYPE_UPDATE_FAILURE = "Error on updating the EmployeeType details";

            public static readonly String DEACTIVATE_SUCCESS = "EmployeeType deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "EmployeeType activated successfully";

            public static readonly String EMPLOYEETYPE_REFERED = "The selected EmployeeType is already referred";
            #endregion
        }

        public class EmployeeNominee
        {
            #region EmployeeNominee
            public static readonly String EMPLOYEENOMINEE_ADDEDD_SUCCESS = "EmployeeNominee details added successfully";
            public static readonly String EMPLOYEENOMINEE_UPDATE_SUCCESS = "EmployeeNominee details update successfully";
            public static readonly String EMPLOYEENOMINEE_ADDEDD_FAILURE = "Error on updating the EmployeeNominee details";

            #endregion
        }


        public class SkillSetMessages
        {
            #region SkillSet
            public static readonly String EMPTY_SKILLSET = "SkillSet name cannot be empty";
            public static readonly String SKILLSET_EXISTS = "The given SkillSet already exists";

            public static readonly String SKILLSET_ADDED_SUCCESS = "SkillSet details added successfully";
            public static readonly String SKILLSET_UPDATE_SUCCESS = "SkillSet details updated successfully";
            public static readonly String SKILLSET_UPDATE_FAILURE = "Error on updating the SkillSet details";

            public static readonly String DEACTIVATE_SUCCESS = "SkillSet deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "SkillSet activated successfully";

            public static readonly String SKILLSET_REFERED = "The selected SkillSet is already referred";
            #endregion
        }

        public class AssignCompanyBankMessages
        {
            #region AssignCompanyBank
            public static readonly String EMPTY_ACCOUNT_NUMBER = "Account cannot be empty";
            public static readonly String ACCOUNT_EXISTS = "The given Account already exists ";

            public static readonly String ASSIGN_COMPANY_BANK_UPDATE_SUCCESS = "Assign Company Bank details updated successfully";
            public static readonly String ASSIGN_COMPANY_BANK_ADDED_SUCCESS = "Assign Company Bank details added successfully";
            public static readonly String ASSIGN_COMPANY_BANK_UPDATE_FAILURE = "Error on updating the Assign Company Bank details";

            public static readonly String DEACTIVATE_SUCCESS = "Assign Company Bank deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Assign Company Bank activated successfully";


            public static readonly String NO_ASSIGN_COMPANY_BANK = "No Assign Company Bank are available";

            public static readonly String ASSIGN_COMPANY_BANK_REFERED = "The selected Assign Company Bank already referred";
            public static readonly String NO_BrancheS = "Error on updating the Branch details";

            #endregion
        }

        public class SettingConfigurationMessages
        {
            #region SettingConfiguration
            public static readonly String SETTING_UPDATE_SUCESS = "Setting Configuration updated successfully";
            public static readonly String SETTING_UPDATE_FAILURE = "Error on updating the Setting Configuration details";
            public static readonly String SETTING_ADDED_SUCCESS = "Setting Configuration details added successfully";


            #endregion
        }


        public class BonusMessages
        {
            #region Bonus
            public static readonly String EMPTY_BONUS = "Bonus name cannot be empty";
            public static readonly String BONUS_EXISTS = "The given Bonus already exists ";

            public static readonly String BONUS_UPDATE_SUCESS = "Bonus details updated successfully";
            public static readonly String BONUS_ADDED_SUCCESS = "Bonus details added successfully";
            public static readonly String BONUS_UPDATE_FAILURE = "Error on updating the Bonus details";

            public static readonly String DEACTIVATE_SUCCESS = "Bonus deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Bonus activated successfully";
            public static readonly String NO_BONUS = "No Bonus are available";
            #endregion
        }
        public class ExternalUploadResumeMessages
        {
            #region ExternalUploadResume
            public static readonly String EXTERNAL_UPLOAD_RESUME_ADDED_SUCCESS = "Candidate details added successfully";
            public static readonly String EXTERNAL_UPLOAD_RESUME_UPDATE_SUCESS = "Candidate details updated successfully";
            public static readonly String EXTERNAL_UPLOAD_RESUME_UPDATE_FAILURE = "Error on updating the Candidate details";
            public static readonly String EMPTY_UPLOAD_RESUME_UPDATE_FAILURE = "Resume name cannot be empty";
            public static readonly String UPLOAD_RESUME_UPDATE_FAILURE_EXISTS = "The given Resume already exists ";
            public static readonly String NO_PROFILE_NAME = "No Profile name are available ";
            public static readonly String REJECT_SUCCESS = "Resume Rejected successfully ";
            public static readonly String REJECT_FAILURE = "Error on rejecting the resume";
            public static readonly String DELETE_SUCCESS = "Resume Deleted successfully ";
            public static readonly String DELETE_FAILURE = "Error on deleting the resume";
            public static readonly String SEND_SUCCESS = "Resume Send successfully ";
            public static readonly String SEND_FAILURE = "Error on sending the resume";
            public static readonly String SHORTLIST_SUCCESS = "Resume Shortlisted successfully";
            public static readonly String SHORTLIST_FAILURE = "Error on shortlisting the resume";
            public static readonly String ARCHIVE_SUCCESS = "Resume saved in Archive successfully";
            public static readonly String ARCHIVE_FAILURE = "Error on saving the resume in archive";
            public static readonly String GET_ARCHIVE_SUCCESS = "Getting resume from archive successfully";
            public static readonly String GET_ARCHIVE_FAILURE = "Error on getting the resume in archive";
            #endregion
        }
        public class OneTimeAllowanceMessages
        {
            #region OneTimeAllowance
            public static readonly String NO_ONE_TIME_ALLOWANCE = "No Allowance for this month";
            public static readonly String ONE_TIME_ALLOWANCE_UPDATE_SUCESS = "Onetime allowance details updated successfully";
            public static readonly String ONE_TIME_ALLOWANCE_ADDED_SUCCESS = "Onetime allowance details added successfully";
            public static readonly String ONE_TIME_ALLOWANCE_UPDATE_FAILURE = "Error on updating the Onetime allowance details";
            public static readonly String ALLOWANCE_EXISTS = "Selected Allowance already exists";
            #endregion
        }
        public class OtherDeductionMessages
        {
            #region OtherDeduction
            public static readonly String NO_OTHERDEDUCTION = "No Other Deductions for this month";
            public static readonly String OTHER_DEDUCTION_UPDATE_SUCSESS = "Other Deduction details updated successfully";
            public static readonly String OTHER_DEDUCTION_ADDED_SUCCESS = "Other Deduction details added successfully";
            public static readonly String OTHER_DEDUCTION_UPDATE_FAILURE = "Error on updating the Other Deduction details";
            public static readonly String OTHER_DEDUCTION__EXISTS = "Selected Other Deduction already exists";
            #endregion
        }
        public class EmployeeNotificationMessages
        {
            #region EmployeeNotification
            public static readonly String EMPLOYEE_NOTIFICATION_ADDED_SUCCESS = "Employee notification added successfully";
            public static readonly String EMPLOYEE_NOTIFICATION_UPDATE_SUCCESS = "Employee notification updated successfully";
            public static readonly String EMPLOYEE_NOTIFICATION_UPDATE_FAILURE = "Error on updating Employee notification details";
            public static readonly String EMPLOYEE_NOTIFICATION_DELETED_SUCCESS = "Employee notification deleted successfully";
            public static readonly String EMPLOYEE_NOTIFICATION_DELETED_FAILURE = "Error on deleting the employee notification details";
            public static readonly String RELATIONS_COMBO_EMPTY = "No Relations";

            #endregion
        }

        #region Consultant
        public class ConsultantMessages
        {
            public static readonly String EMPTY_CONSULTANT = "Consultant cannot be empty";
            public static readonly String CONSULTANT_EXISTS = "The given Consultant Name already exists ";
            public static readonly String CONSULTANT_EMAILID_EXISTS = "The given Consultant Email ID already exists ";
            public static readonly String CONSULTANT_TEL_EXISTS = "The given Consultant Telephone Number already exists ";

            public static readonly String CONSULTANT_UPDATE_SUCCESS = "Consultant details updated successfully";
            public static readonly String CONSULTANT_ADDED_SUCCESS = "Consultant details added successfully";
            public static readonly String CONSULTANT_UPDATE_FAILURE = "Error on updating the Consultant details";
            public static readonly String DEACTIVATE_SUCCESS = "Consultant deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Consultant activated successfully";
            public static readonly String NO_CONSULTANT = "No Consultant are available";
            public static readonly String CONSULTANT_REFERED = "The selected Consultant already referred";

        }

        #endregion

        #region Team
        public class TeamMessages
        {
            public static readonly String EMPTY_TEAM = "Team cannot be empty";
            public static readonly String TEAM_EXISTS = "The given Team Name already exists ";
            public static readonly String TEAM_UPDATE_SUCCESS = "Team details updated successfully";
            public static readonly String TEAM_ADDED_SUCCESS = "Team details added successfully";
            public static readonly String TEAM_UPDATE_FAILURE = "Error on updating the Team details";
            public static readonly String TEAM_REFERED = "The selected Team is referred";
        }

        #endregion


        public class EmployeeAttendanceMessages
        {
            public static readonly String PAYROLL_ADDED = "Employee payroll is already added for the month and year";
            public static readonly String PAYROLL_ADDED_LEAVE = "Cannot request for leave because employee payroll is already added for the month and year";

        }


       
    }
}

