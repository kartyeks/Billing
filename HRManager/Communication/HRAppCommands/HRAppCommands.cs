using System;

public class HRAppCommands : WebAppCommands
{

    #region General
    public static readonly String GET_MENUSTRING = "GET_MENUSTRING";


    public static readonly String GET_PERMISSION_ASSIGNED = "GET_PERMISSION_ASSIGNED";
    public static readonly String DASHBOARDREPORTS_DETAILS = "DASHBOARDREPORTS_DETAILS";
    public static readonly String ROLE_REPORTSINFO = "ROLE_REPORTSINFO";
    public static readonly String PERMISSION_DETAILS = "PERMISSION_DETAILS";
    public static readonly String PERMISSION_INFO = "PERMISSION_INFO";
    #endregion


    #region ExternalUploadResume
    public static readonly String EXTERNAL_UPLOAD_RESUME_DETAILS = "EXTERNAL_UPLOAD_RESUME_DETAILS";
    public static readonly String UPDATE_EXTERNAL_UPLOAD_RESUME = "UPDATE_EXTERNAL_UPLOAD_RESUME";
    public static readonly String ALL_JOBPROFILE_NAMECOMBO_DETAILS = "ALL_JOBPROFILE_NAMECOMBO_DETAILS";
    public static readonly String EXTERNAL_UPLOAD_RESUME_NEW = "NEW";
    public static readonly String REJECT_AGENCY_RESUME = "REJECT_AGENCY_RESUME";
    public static readonly String DELETE_AGENCY_RESUME = "DELETE_AGENCY_RESUME";
    public static readonly String SEND_AGENCY_RESUME = "SEND_AGENCY_RESUME";
    public static readonly String EXTERNAL_UPLOAD_RESUME_VIEW = "EXTERNAL_UPLOAD_RESUME_VIEW";
    public static readonly String SHORTLIST_AGENCY_RESUME = "SHORTLIST_AGENCY_RESUME";
    public static readonly String SEND_ARCHIVE_AGENCY_RESUME = "SEND_ARCHIVE_AGENCY_RESUME";
    public static readonly String GET_ARCHIVE_AGENCY_RESUME = "GET_ARCHIVE_AGENCY_RESUME";
    public static readonly String GET_DASHBOARD_DETAILS = "GET_DASHBOARD_DETAILS";
    

    // For Creating New ExternalUploadResume


    #endregion

    #region Resource Request
    public static readonly String RESOURCEREQUIRED_DETAILS = "RESOURCEREQUIRED_DETAILS";
    public static readonly String UPDATE_RESOURCEREQUEST = "UPDATE_RESOURCEREQUEST";
    public static readonly String UPDATE_RESOURCEACTIVITY = "UPDATE_RESOURCEACTIVITY";
    public static readonly String RESOURCE_HTML = "RESOURCE_HTML";
    public static readonly String APPROVED_RESOURCEREQUIRED_DETAILS = "APPROVED_RESOURCEREQUIRED_DETAILS";

    #endregion

    #region designation
    public static readonly String DESIGNATION_DETAILS = "DESIGNATION_DETAILS";
    public static readonly String GET_ALL_DESIGNATION_DETAILS = "GET_ALL_DESIGNATION_DETAILS";
    public static readonly String DESIGNATION_INFO = "DESIGNATION_INFO";
    public static readonly String DEACTIVATE_DESIGNATION = "DEACTIVATE_DESIGNATION";
    public static readonly String ACTIVATE_DESIGNATION = "ACTIVATE_DESIGNATION";
    public static readonly String UPDATE_DESIGNATION = "UPDATE_DESIGNATION";
    public static readonly String DESIGNATIONCOMBO_DETAILS = "DESIGNATIONCOMBO_DETAILS";
    public static readonly String INACTIVE_DESIGNATION = "INACTIVE_DESIGNATION";
    public static readonly String DESIGNATION_HIRE_INFO = "DESIGNATION_HIRE_INFO";
    public static readonly String ROLE_COMBO = "ROLE_COMBO";
    #endregion

    #region Department
    public static readonly String DEPARTMENT_DETAILS = "DEPARTMENT_DETAILS";
    public static readonly String DEACTIVATE_DEPARTMENT = "DEACTIVATE_DEPARTMENT";
    public static readonly String ACTIVATE_DEPARTMENT = "ACTIVATE_DEPARTMENT";
    public static readonly String UPDATE_DEPARTMENT = "UPDATE_DEPARTMENT";
    public static readonly String DEPARTMENT_HOD_DETAILS = "DEPARTMENT_HOD_DETAILS";
    public static readonly String DEPARTMENTCOMBO_DETAILS = "DEPARTMENTCOMBO_DETAILS";
    public static readonly String DEPARTMENT_BRANCH_DETAILS = "DEPARTMENT_BRANCH_DETAILS";


    #endregion

    #region role
    public static readonly String ROLE_DETAILS = "ROLE_DETAILS";
    public static readonly String GET_ALL_ROLETYPE_DETAILS = "GET_ALL_ROLETYPE_DETAILS";
    
    //public static readonly String DEACTIVATE_ROLE = "DEACTIVATE_ROLE";
    //public static readonly String ACTIVATE_ROLE = "ACTIVATE_ROLE";
    //public static readonly String UPDATE_ROLE = "UPDATE_ROLE";
    //public static readonly String ROLECOMBO_DETAILS = "ROLECOMBO_DETAILS";
    //public static readonly String INACTIVE_ROLE = "INACTIVE_ROLE";
    #endregion

    #region location
    public static readonly String COUNTRY_DETAILS = "COUNTRY_DETAILS";
    public static readonly String GET_LOCATION_COMBO = "GET_LOCATION_COMBO";
    public static readonly String LOCATION_DETAILS = "LOCATION_DETAILS";
    public static readonly String DEACTIVATE_LOCATION = "DEACTIVATE_LOCATION";
    public static readonly String ACTIVATE_LOCATION = "ACTIVATE_LOCATION";
    public static readonly String UPDATE_LOCATION = "UPDATE_LOCATION";
    public static readonly String INACTIVE_LOCATION = "INACTIVE_LOCATION";
    #endregion

    #region locationtype
    public static readonly String LOCATIONTYPE_DETAILS = "LOCATIONTYPE_DETAILS";
    public static readonly String DEACTIVATE_LOCATIONTYPE = "DEACTIVATE_LOCATIONTYPE";
    public static readonly String ACTIVATE_LOCATIONTYPE = "ACTIVATE_LOCATIONTYPE";
    public static readonly String UPDATE_LOCATIONTYPE = "UPDATE_LOCATIONTYPE";
    
    public static readonly String LOCATIONTYPEFORSEARCH_DETAILS = "LOCATIONTYPEFORSEARCH_DETAILS";
    public static readonly String INACTIVE_LOCATIONTYPE = "INACTIVE_LOCATIONTYPE";
    #endregion

    #region CANDIDATE

    #region CandidateApplication_PersonalInfo
    public static readonly String CANDIDATE_CHECK = "CANDIDATE_CHECK";
    public static readonly String CANDIDATEPERSONALINFO_DETAILS = "CANDIDATEPERSONALINFO_DETAILS";//For all records
    public static readonly String CANDIDATENONAPPROVEINFO_DETAILS = "CANDIDATENONAPPROVEINFO_DETAILS";//For all non approved records to show in summary
    public static readonly String UPDATE_CANDIDATEPERSONALINFO = "UPDATE_CANDIDATEPERSONALINFO";
    public static readonly String CANDIDATEINFO_DETAILS = "CANDIDATEINFO_DETAILS";// For single record
    public static readonly String UPDATE_CANDIDATEAPPROVE = "UPDATE_CANDIDATEAPPROVE";
    public static readonly String UPDATE_CANDIDATEFINALAPPROVE = "UPDATE_CANDIDATEFINALAPPROVE";
    public static readonly String UPDATE_CANDIDATEREJECT = "UPDATE_CANDIDATEREJECT";
    public static readonly String UPDATE_CANDIDATE_MDAPPROVE = "UPDATE_CANDIDATE_MDAPPROVE";
    public static readonly String UPDATE_CANDIDATECOOAPPROVE = "UPDATE_CANDIDATECOOAPPROVE";
    public static readonly String APPROVE_CANDIDATE = "approved";
    public static readonly String REJECT_CANDIDATE = "rejected";
    public static readonly String MD_APPROVE_CANDIDATE = "MD Approval";
    public static readonly String COO_APPROVE_CANDIDATE = "COO Approval";
    public static readonly String HIGHER_APPROVED_CANDIDATE = "Higher Approved";
    #endregion

    #region Family
    public static readonly String FAMILY_DETAILS = "FAMILY_DETAILS";
    public static readonly String UPDATE_FAMILY = "UPDATE_FAMILY";
    public static readonly String RELATIONNAME_DETAILS = "RELATIONNAME_DETAILS";
    #endregion

    #region Language
    public static readonly String CAN_SKILL_DETAILS = "CAN_SKILL_DETAILS";
    public static readonly String UPDATE_CAN_SKILL = "UPDATE_CAN_SKILL";
    #endregion

    #region Skill candidale
    public static readonly String LANGUAGE_DETAILS = "LANGUAGE_DETAILS";
    public static readonly String UPDATE_LANGUAGE = "UPDATE_LANGUAGE";
    #endregion

    #region Education
    public static readonly String EDUCATION_DETAILS = "EDUCATION_DETAILS";
    public static readonly String UPDATE_EDUCATION = "UPDATE_EDUCATION";
    #endregion

    #region Questioner
    public static readonly String QUESTIONER_DETAILS = "QUESTIONER_DETAILS";
    public static readonly String UPDATE_QUESTIONER = "UPDATE_QUESTIONER";
    #endregion

    #region PreviousEmp
    public static readonly String PREVIOUSEMP_DETAILS = "PREVIOUSEMP_DETAILS";
    public static readonly String UPDATE_PREVIOUSEMP = "UPDATE_PREVIOUSEMP";
    #endregion

    #region CurrentEmp
    public static readonly String CURRENTEMP_DETAILS = "CURRENTEMP_DETAILS";
    public static readonly String UPDATE_CURRENTEMP = "UPDATE_CURRENTEMP";
    #endregion

    #region Location Job Details
    public static readonly String LOCATIONJOBDISPLAY_DETAILS = "LOCATIONJOBDISPLAY_DETAILS";
    public static readonly String CANDIDATEJOBDISPLAY_DETAILS = "CANDIDATEJOBDISPLAY_DETAILS";

    #endregion

    #region Training
    public static readonly String CANDTRAINING_DETAILS = "CANDTRAINING_DETAILS";
    #endregion

    #endregion

    #region SchedulrInterview
    public static readonly String INTERVIEWSCHEDULE_DETAILS = "INTERVIEWSCHEDULE_DETAILS";
    public static readonly String GET_ALL_INTERVIEW_DETAILS = "GET_ALL_INTERVIEW_DETAILS";
    public static readonly String UPDATE_INTERVIEWSCHEDULE = "UPDATE_INTERVIEWSCHEDULE";
    public static readonly String INTERVIEWHIRE_CANDIDATE = "INTERVIEWHIRE_CANDIDATE";
    public static readonly String INTERVIEWREJECT_CANDIDATE = "INTERVIEWREJECT_CANDIDATE";
    public static readonly String UPDATE_INTERVIEWAPPROVAL = "UPDATE_INTERVIEWAPPROVAL";
    public static readonly String REFERENCECHECKER_DETAILS = "REFERENCECHECKER_DETAILS";

    public static readonly String GETAPPROVED_CANDIDATE_DETAILS = "GETAPPROVED_CANDIDATE_DETAILS";

    public static readonly String SCHEDULEINTERVIEWER_DETAILS = "SCHEDULEINTERVIEWER_DETAILS";
    public static readonly String CANDIDATE_DETAILS_FOR_REFERENCE_CHECK = "CANDIDATE_DETAILS_FOR_REFERENCE_CHECK";

    public static readonly String SCHEDULEINTERVIEWER_UPDATE_SELECTED = "SCHEDULEINTERVIEWER_UPDATE_SELECTED";
    public static readonly String SCHEDULEINTERVIEWER_UPDATE_REJECTED = "SCHEDULEINTERVIEWER_UPDATE_REJECTED";


    public static readonly String NEW_INTERVIEW = "NEW";// while uploading resume status 'NEW' in Candidate_JobDetails table
    public static readonly String SCHEDULE_INTERVIEW = "OPN";// While Schedule Interview Change satus as 'OPN' in Candidate_InterviewSchedule table
    public static readonly String NEXTROUND_INTERVIEW = "NXT";//Interviewer selected candidate for next round change status as 'NXT' in Candidate_InterviewSchedule table
    public static readonly String APPROVED_INTERVIEW = "APP";//HR Approve the candidate with CTC and Takehome change status as 'APP' in Candidate_InterviewSchedule table
    public static readonly String HIRE_INTERVIEW = "HIR";//Interviewer selected candidate change status as 'HIR' in Candidate_InterviewSchedule table
    public static readonly String REJECT_INTERVIEW = "REJ";//Interviewer Rejected candidate change status as 'REJ' in Candidate_InterviewSchedule table
    public static readonly String CONFIRM_HIRE = "CHR";//HR confirm hire a candidate change status as 'CHR' in Candidate_InterviewSchedule table and change status as 'HIR' in Candidate_Selected table
    public static readonly String CONFIRM_REJECTION = "CRJ";//HR confirm reject a candidate change status as 'CRJ' in Candidate_InterviewSchedule table

    #endregion

    #region CandidateSelected
    public static readonly String SELECTED_CANDIDATE_DETAILS = "SELECTED_CANDIDATE_DETAILS";
    public static readonly String ISSUEOFFER_CANDIDATE = "ISSUEOFFER_CANDIDATE";
    public static readonly String CLOSE_CANDIDATE = "CLOSE_CANDIDATE";

    public static readonly String OFFERISSUE_CANDIDATE = "OFR"; //While issue offer change status as 'OFR' in  Candidate_Selected table
    public static readonly String JOINED_CANDIDATE = "JON";//While creating employee change status as 'JON in'  Candidate_Selected table
    public static readonly String CLOSED_CANDIDATE = "CLS"; //After issue offer if emp not joined then change status as 'CLS' in  Candidate_Selected table

    public static readonly String ISSUEOFFER_FOR_PRINT = "ISSUEOFFER_FOR_PRINT";

    #endregion

    #region Interview Round
    public static readonly String INTERVIEW_ROUND_DETAILS = "INTERVIEW_ROUND_DETAILS";
    public static readonly String DEACTIVATE_INTERVIEW_ROUND = "DEACTIVATE_INTERVIEW_ROUND";
    public static readonly String ACTIVATE_INTERVIEW_ROUND = "ACTIVATE_INTERVIEW_ROUND";
    public static readonly String UPDATE_INTERVIEW_ROUND = "UPDATE_INTERVIEW_ROUND";
    public static readonly String INACTIVE_INTERVIEW_ROUND = "INACTIVE_INTERVIEW_ROUND";
    #endregion

    #region asset
    public static readonly String ASSET_COMBO_DETAILS = "ASSET_COMBO_DETAILS";
    public static readonly String GET_ALL_ASSET_DETAILS = "GET_ALL_ASSET_DETAILS";
    public static readonly String ASSET_DETAILS = "ASSET_DETAILS";
    public static readonly String DEACTIVATE_ASSET = "DEACTIVATE_ASSET";
    public static readonly String ACTIVATE_ASSET = "ACTIVATE_ASSET";
    public static readonly String UPDATE_ASSET = "UPDATE_ASSET";
    public static readonly String INACTIVE_ASSET = "INACTIVE_ASSET";
    #endregion

    //kartyek 5.2.2015 Loan Management standard Names
    #region Loan
    public static readonly String LOAN_DETAILS = "LOAN_DETAILS";
    public static readonly String DEACTIVATE_LOAN = "DEACTIVATE_LOAN";
    public static readonly String ACTIVATE_LOAN = "ACTIVATE_LOAN";
    public static readonly String UPDATE_LOAN = "UPDATE_LOAN";
    public static readonly String INACTIVE_LOAN = "INACTIVE_LOAN";
    public static readonly String COMBOLOAN_DETAILS = "COMBOLOAN_DETAILS";
    public static readonly String LOANAMOUNTBYLOAN = "LOANAMOUNTBYLOAN";
    public static readonly String LOAN_DETAILS_FOR_TXT = "LOAN_DETAILS_FOR_TXT";
    public static readonly String COMBOLOAN_DETAILS_BYGRADE = "COMBOLOAN_DETAILS_BYGRADE";
    #endregion


    //kartek 6.2.2015 for advance type 

    #region Advance Type
    public static readonly String ADVANCE_TYPE_DETAILS = "ADVANCE_TYPE_DETAILS";
    public static readonly String UPDATE_ADVANCE_TYPE = "UPDATE_ADVANCE_TYPE";
    public static readonly String ACTIVATE_ADVANCE_TYPE = "ACTIVATE_ADVANCE_TYPE";
    public static readonly String DEACTIVATE_ADVANCE_TYPE = "DEACTIVATE_ADVANCE_TYPE";
    public static readonly String INACTIVE_ADVANCE_TYPE = "INACTIVE_ADVANCE_TYPE";
    public static readonly String COMBOADVANCETYPE_DETAILS = "COMBOADVANCETYPE_DETAILS";
    #endregion 

    #region relation
    public static readonly String RELATION_DETAILS = "RELATION_DETAILS";
    public static readonly String GET_ALL_RELATION_DETAILS = "GET_ALL_RELATION_DETAILS";
    public static readonly String DEACTIVATE_RELATION = "DEACTIVATE_RELATION";
    public static readonly String ACTIVATE_RELATION = "ACTIVATE_RELATION";
    public static readonly String UPDATE_RELATION = "UPDATE_RELATION";
    public static readonly String INACTIVE_RELATION = "INACTIVE_RELATION";

    #endregion

    

    #region Email
    public static readonly String EMAIL_STATUS_NEW = "NEW";
    public static readonly String EMAIL_STATUS_RETRY = "RETRY";
    public static readonly String EMAIL_STATUS_FAILED = "FAILED";
    public static readonly String EMAIL_STATUS_SENT = "SENT";
    public static readonly int MAX_RETRY_ATTEMPT = 3;
    #endregion

    #region Locationbranch
    public static readonly String BRANCH_DETAILS = "BRANCH_DETAILS";
    public static readonly String DEACTIVATE_BRANCH = "DEACTIVATE_BRANCH";
    public static readonly String ACTIVATE_BRANCH = "ACTIVATE_BRANCH";
    public static readonly String UPDATE_BRANCH = "UPDATE_BRANCH";
    public static readonly String INACTIVE_BRANCH = "INACTIVE_BRANCH";
    public static readonly String BRANCHCOMBO_DETAILS = "BRANCHCOMBO_DETAILS";
    public static readonly String ALL_BRANCHCOMBO_DETAILS = "ALL_BRANCHCOMBO_DETAILS";

    #endregion

    #region EmployeeType
    public static readonly String EMPLOYEETYPE_DETAILS = "EMPLOYEETYPE_DETAILS";
    public static readonly String DEACTIVATE_EMPLOYEETYPE = "DEACTIVATE_EMPLOYEETYPE";
    public static readonly String ACTIVATE_EMPLOYEETYPE = "ACTIVATE_EMPLOYEETYPE";
    public static readonly String UPDATE_EMPLOYEETYPE = "UPDATE_EMPLOYEETYPE";
    public static readonly String INACTIVE_EMPLOYEETYPE = "INACTIVE_EMPLOYEETYPE";
    public static readonly String COMBOEMPTYPE_DETAILS = "COMBOEMPTYPE_DETAILS";
    public static readonly String EMPLOYEETYPEFORSEARCH_DETAILS = "EMPLOYEETYPEFORSEARCH_DETAILS";
    public static readonly String EMPLOYEENOMINEE_DETAILS = "EMPLOYEENOMINEE_DETAILS";
    public static readonly String UPDATE_EMPLOYEENOMINEE = "UPDATE_EMPLOYEENOMINEE";
    public static readonly String DEACTIVATE_EMPLOYEENOMINEE = "DEACTIVATE_EMPLOYEENOMINEE";
    public static readonly String ACTIVATE_EMPLOYEENOMINEE = "ACTIVATE_EMPLOYEENOMINEE";
    public static readonly String INACTIVE_EMPLOYEENOMINEE = "INACTIVE_EMPLOYEENOMINEE";
    public static readonly String RELATION_COMBO = "RELATION_COMBO";
    #endregion

    #region Setting Configuration
    public static readonly String SETTING_CONFIGURATION_DETAILS = "SETTING_CONFIGURATION_DETAILS";
    public static readonly String UPDATE_SETTING_CONFIGURATION = "UPDATE_SETTING_CONFIGURATION";


    #endregion

    #region Appraisal
    public static readonly String LOCATIONCOMBO_APPRAISAL_DETAILS = "LOCATIONCOMBO_APPRAISAL_DETAILS";

    #endregion

    #region One Time Allowance
    public static readonly String ONE_TIME_ALLOWANCE_DETAILS = "ONE_TIME_ALLOWANCE_DETAILS";
    public static readonly String UPDATE_EMP_ONETIMEALLOWANCE = "UPDATE_EMP_ONETIMEALLOWANCE";
    public static readonly String DELETE_EMP_ONETIMEALLOWANCE = "DELETE_EMP_ONETIMEALLOWANCE";

    #endregion

    #region Other Deductions
    public static readonly String OTHER_DEDUCTION_DETAILS = "OTHER_DEDUCTION_DETAILS";
    public static readonly String UPDATE_EMP_OTHERDEDUCTION = "UPDATE_EMP_OTHERDEDUCTION";
    public static readonly String DELETE_EMP_OTHERDEDUCTION = "DELETE_EMP_OTHERDEDUCTION";

    #endregion

    #region Employee Notification
    public static readonly String EMPLOYEE_NOTIFICATION_DETAILS = "EMPLOYEE_NOTIFICATION_DETAILS";
    public static readonly String UPDATE_EMPLOYEE_NOTIFICATION = "UPDATE_EMPLOYEE_NOTIFICATION";
    public static readonly String DELETE_EMPLOYEE_NOTIFICATION = "DELETE_EMPLOYEE_NOTIFICATION";
    public static readonly String GET_EMPLOYEE_NOTIFICATION = "GET_EMPLOYEE_NOTIFICATION";

    #endregion

    #region Role
    public static readonly String ROLE_MASTER_DETAILS = "ROLE_MASTER_DETAILS";
    public static readonly String DEACTIVATE_ROLE = "DEACTIVATE_ROLE";
    public static readonly String ACTIVATE_ROLE = "ACTIVATE_ROLE";
    public static readonly String INACTIVE_ROLE = "INACTIVE_ROLE";

    //public static readonly String ROLE_REPORTSINFO = "ROLE_REPORTSINFO";
    //public static readonly String DASHBOARDREPORTS_DETAILS = "DASHBOARDREPORTS_DETAILS";
    //public static readonly String PERMISSION_DETAILS = "PERMISSION_DETAILS";
    public static readonly String UPDATE_ROLE = "UPDATE_ROLE";

    #endregion

    #region Country
    public static readonly String GET_COUNTRY_DETAILS = "GET_COUNTRY_DETAILS";
    public static readonly String GET_ALL_COUNTRY_DETAILS = "GET_ALL_COUNTRY_DETAILS";
    public static readonly String GET_ACTIVE_DEACTIVATE_COUNTRY = "GET_ACTIVE_DEACTIVATE_COUNTRY";
    public static readonly String UPDATE_COUNTRY = "UPDATE_COUNTRY";
    public static readonly String INACTIVE_COUNTRY = "INACTIVE_COUNTRY";

    public static readonly String COUNTRY_COMBO_DETAILS = "COUNTRY_COMBO_DETAILS";
    #endregion

    #region Holidays
    public static readonly String GET_HOLIDAYS_DETAILS = "GET_HOLIDAYS_DETAILS";
    public static readonly String GET_ALL_HOLIDAY_DETAILS = "GET_ALL_HOLIDAY_DETAILS";
    public static readonly String GET_ACTIVE_DEACTIVATE_HOLIDAYS = "GET_ACTIVE_DEACTIVATE_HOLIDAYS";
    public static readonly String UPDATE_HOLIDAYS = "UPDATE_HOLIDAYS";
    public static readonly String INACTIVE_HOLIDAYS = "INACTIVE_HOLIDAYS";
    public static readonly String HOLIDAYS_DETAILS = "HOLIDAYS_DETAILS";

    #endregion

    #region InterviewType
    public static readonly String GET_INTERVIEWTYPE_DETAILS = "GET_INTERVIEWTYPE_DETAILS";
    public static readonly String GET_ACTIVE_DEACTIVATE_INTERVIEWTYPE = "GET_ACTIVE_DEACTIVATE_INTERVIEWTYPE";
    public static readonly String UPDATE_INTERVIEWTYPE = "UPDATE_INTERVIEWTYPE";
    public static readonly String INACTIVE_INTERVIEWTYPE = "INACTIVE_INTERVIEWTYPE";
    public static readonly String INTERVIEWTYPE_DETAILS = "INTERVIEWTYPE_DETAILS";
    public static readonly String INTERVIEWTYPE_COMBO_DETAILS = "INTERVIEWTYPE_COMBO_DETAILS";

    #endregion

    #region Manufacturer
    public static readonly String GET_MANUFACTURER_DETAILS = "GET_MANUFACTURER_DETAILS";
    public static readonly String GET_ALL_MANUFACTURER_DETAILS = "GET_ALL_MANUFACTURER_DETAILS";
    public static readonly String GET_ACTIVE_DEACTIVATE_MANUFACTURER = "GET_ACTIVE_DEACTIVATE_MANUFACTURER";
    public static readonly String UPDATE_MANUFACTURER = "UPDATE_MANUFACTURER";
    public static readonly String INACTIVE_MANUFACTURER = "INACTIVE_MANUFACTURER";
    public static readonly String MANUFACTURER_DETAILS = "MANUFACTURER_DETAILS";

    #endregion

    #region Candidatecompetency
    public static readonly String GET_CANDIDATECOMPETANCY_DETAILS = "GET_CANDIDATECOMPETANCY_DETAILS";
    public static readonly String GET_ALL_CANDIDATE_COMPETENCY_DETAILS = "GET_ALL_CANDIDATE_COMPETENCY_DETAILS";
    public static readonly String GET_ACTIVE_DEACTIVATE_CANDIDATECOMPETANCY = "GET_ACTIVE_DEACTIVATE_CANDIDATECOMPETANCY";
    public static readonly String UPDATE_CANDIDATECOMPETANCY = "UPDATE_CANDIDATECOMPETANCY";
    public static readonly String INACTIVE_CANDIDATECOMPETANCY = "INACTIVE_CANDIDATECOMPETANCY";
    public static readonly String CANDIDATECOMPETANCY_DETAILS = "CANDIDATECOMPETANCY_DETAILS";

    #endregion

    #region AssetCategory
    public static readonly String GET_ASSETCATEGORY_DETAILS = "GET_ASSETCATEGORY_DETAILS";
    public static readonly String GET_ACTIVE_DEACTIVATE_ASSETCATEGORY = "GET_ACTIVE_DEACTIVATE_ASSETCATEGORY";
    public static readonly String UPDATE_ASSETCATEGORY = "UPDATE_ASSETCATEGORY";
    public static readonly String INACTIVE_ASSETCATEGORY = "INACTIVE_ASSETCATEGORY";
    public static readonly String ASSETCATEGORY_DETAILS = "ASSETCATEGORY_DETAILS";

    #endregion

    #region AssetSubCategory

    public static readonly String ASSETSUB_COMBO_DETAILS = "ASSETSUB_COMBO_DETAILS";
    public static readonly String GET_ALL_SUB_ASSET_DETAILS = "GET_ALL_SUB_ASSET_DETAILS";
    public static readonly String GET_ASSETSUBCATEGORY_DETAILS = "GET_ASSETSUBCATEGORY_DETAILS";
    public static readonly String GET_ACTIVE_DEACTIVATE_ASSETSUBCATEGORY = "GET_ACTIVE_DEACTIVATE_ASSETSUBCATEGORY";
    public static readonly String UPDATE_ASSETSUBCATEGORY = "UPDATE_ASSETSUBCATEGORY";
    public static readonly String INACTIVE_ASSETSUBCATEGORY = "INACTIVE_ASSETSUBCATEGORY";
    public static readonly String ASSETSUBCATEGORY_DETAILS = "ASSETSUBCATEGORY_DETAILS";

    #endregion

    #region MaritalStatus
    public static readonly String GET_MARITALSTATUS_COMBO = "GET_MARITALSTATUS_COMBO";
    public static readonly String GET_ALL_MARITALSTATUS_DETAILS = "GET_ALL_MARITALSTATUS_DETAILS";
    public static readonly String GET_MARITALSTATUS_DETAILS = "GET_MARITALSTATUS_DETAILS";
    public static readonly String GET_ACTIVE_DEACTIVATE_MARITALSTATUS = "GET_ACTIVE_DEACTIVATE_MARITALSTATUS";
    public static readonly String UPDATE_MARITALSTATUS = "UPDATE_MARITALSTATUS";
    public static readonly String INACTIVE_MARITALSTATUS = "INACTIVE_MARITALSTATUS";
    public static readonly String MARITALSTATUS_DETAILS = "MARITALSTATUS_DETAILS";

    #endregion

    #region CONSULTANT

    public static readonly String CONSULTANT_DETAILS = "CONSULTANT_DETAILS";
    public static readonly String GET_ALL_CONSULTANT_DETAILS = "GET_ALL_CONSULTANT_DETAILS";
    public static readonly String DEACTIVATE_CONSULTANT = "DEACTIVATE_CONSULTANT";
    public static readonly String ACTIVATE_CONSULTANT = "ACTIVATE_CONSULTANT";
    public static readonly String INACTIVE_CONSULTANT = "INACTIVE_CONSULTANT";
    public static readonly String UPDATE_CONSULTANT = "UPDATE_CONSULTANT";

    #endregion

    #region Leave

    public static readonly String LEAVE_OVERVIEW_DETAILS = "LEAVE_OVERVIEW_DETAILS";
    public static readonly String LEAVE_REQUEST_DETAILS = "LEAVE_REQUEST_DETAILS";
    public static readonly String LEAVE_TYPE_COMBO = "LEAVE_TYPE_COMBO";
    public static readonly String CALENDER_LEAVE_DETAIL = "CALENDER_LEAVE_DETAIL";
    public static readonly String HOLIDAYS_BY_EMPID_DETAILS = "HOLIDAYS_BY_EMPID_DETAILS";
    public static readonly String UPDATE_LEAVE_REQUEST = "UPDATE_LEAVE_REQUEST";
    public static readonly String CALENDER = "CALENDER";
    public static readonly String DELETE_LEAVE_REQUEST = "DELETE_LEAVE_REQUEST";
    public static readonly String LEAVE_REQUEST_APPROVAL_DETAILS = "LEAVE_REQUEST_APPROVAL_DETAILS"; 
    public static readonly String UPDATE_LEAVE_APPROVAL = "UPDATE_LEAVE_APPROVAL";
    public static readonly String RESETDATE_LEAVE_REQUEST = "RESETDATE_LEAVE_REQUEST";

    #endregion

    #region Team

    public static readonly String TEAM_COMBO_DETAILS = "TEAM_COMBO_DETAILS";
    public static readonly String GET_ALL_TEAM_DETAILS = "GET_ALL_TEAM_DETAILS";
    public static readonly String TEAM_DETAILS_BYID = "TEAM_DETAILS_BYID";
    public static readonly String TEAM_DETAILS = "TEAM_DETAILS";
    public static readonly String UPDATE_TEAM = "UPDATE_TEAM";
    public static readonly String ACTIVATE_TEAM = "ACTIVATE_TEAM";
    public static readonly String DEACTIVATE_TEAM = "DEACTIVATE_TEAM";
    public static readonly String INACTIVE_TEAM = "INACTIVE_TEAM";
    public static readonly String MANAGER_COMBO_DETAILS = "MANAGER_COMBO_DETAILS";

    #endregion

    //kartyek 13.02.2015 
    #region InvestmentGroupMaster
    public static readonly String GET_ALL_INVESTMENTGROUP_DETAILS = "GET_ALL_INVESTMENTGROUP_DETAILS";
    public static readonly String UPDATE_INVESTMENTGROUP = "UPDATE_INVESTMENTGROUP";
    public static readonly String ACTIVATE_INVESTMENTGROUP = "ACTIVATE_INVESTMENTGROUP";
    public static readonly String DEACTIVATE_INVESTMENTGROUP = "DEACTIVATE_INVESTMENTGROUP";
    
    #endregion


    //kartyek 13.02.2015 
    #region Company
    public static readonly String GET_ALL_COMPANY_DETAILS = "GET_ALL_COMPANY_DETAILS";
    public static readonly String UPDATE_COMPANY = "UPDATE_COMPANY";
    public static readonly String ACTIVATE_COMPANY = "ACTIVATE_COMPANY";
    public static readonly String DEACTIVATE_COMPANY = "DEACTIVATE_COMPANY";
    public static readonly String INVESTMENT_COMBO_DETAILS = "INVESTMENT_COMBO_DETAILS";

    #endregion
    //kartyek 17.02.2015 ProjectInfoDetails
    #region ProjectInfoDetails
    public static readonly String GET_ALL_PROJECT_DETAILS = "GET_ALL_PROJECT_DETAILS";
    public static readonly String UPDATE_PROJECT = "UPDATE_PROJECT";
    public static readonly String ACTIVATE_PROJECT = "ACTIVATE_PROJECT";
    public static readonly String DEACTIVATE_PROJECT = "DEACTIVATE_PROJECT";
    public static readonly String COMPANY_COMBO_DETAILS = "COMPANY_COMBO_DETAILS";

    #endregion
    #region Appraisal

    public static readonly String INTIMATION = "INTIMATION";
    public static readonly String INTIMATE_FOR_APPRAISAL = "INTIMATE_FOR_APPRAISAL";
    public static readonly String GET_TEAM_MEMBER_FOR_APPRAISAL = "GET_TEAM_MEMBER_FOR_APPRAISAL";
    public static readonly String UPDATE_EMP_APPRAISAL_GRADE = "UPDATE_EMP_APPRAISAL_GRADE";
    public static readonly String GET_ALL_TEAM_MEMBER_FOR_APPRAISAL = "GET_ALL_TEAM_MEMBER_FOR_APPRAISAL";
    public static readonly String GET_ALL_TEAM_MEMBER_FOR_RATING = "GET_ALL_TEAM_MEMBER_FOR_RATING";
    public static readonly String EMPLOYEE_HIKE = "EMPLOYEE_HIKE";
    public static readonly String EMPLOYEE_PROMOTE = "EMPLOYEE_PROMOTE";
    public static readonly String DESIGNATION_COMBO_DETAILS = "DESIGNATION_COMBO_DETAILS";
    public static readonly String APPRAISAL_SUMBITTED = "APPRAISAL_SUMBITTED";
    public static readonly String DELETE_EMPLOYEE_GOALS = "DELETE_EMPLOYEE_GOALS";
    public static readonly String DELETE_EMPLOYEE_GRADE = "DELETE_EMPLOYEE_GRADE";
    public static readonly String INTIMATEDATE_COMBO_DETAILS = "INTIMATEDATE_COMBO_DETAILS";
    public static readonly String GET_ALL_TEAM_MEMBER_FOR_VIEW = "GET_ALL_TEAM_MEMBER_FOR_VIEW";
    public static readonly String CHECK_ALL_APPRAISAL_DOC_SUBMITTED = "CHECK_ALL_APPRAISAL_DOC_SUBMITTED";
    public static readonly String GET_ALL_TEAM_MEMBER_FOR_RATING_VIEW = "GET_ALL_TEAM_MEMBER_FOR_RATING_VIEW";
    public static readonly String DELETE_INTIMATION = "DELETE_INTIMATION";
    public static readonly String IS_GOAL_SUBMISSION_STARTED = "IS_GOAL_SUBMISSION_STARTED";

    #endregion

    #region ExitManagement

    public static readonly String GET_EXIT_MANAGEMENT_DETAILS = "GET_EXIT_MANAGEMENT_DETAILS";
    public static readonly String GET_EMPLOYEE_EXIT_MANAGEMENT_DETAILS = "GET_EMPLOYEE_EXIT_MANAGEMENT_DETAILS";
    public static readonly String UPDATE_EXIT_MANAGEMENT = "UPDATE_EXIT_MANAGEMENT";
    #endregion

    #region Employee Uploaded Attendance

    public static readonly String GET_EMP_UPLOADED_ATTENDANCE_GRID = "GET_EMP_UPLOADED_ATTENDANCE_GRID";
    
    #endregion


    public static readonly String PROJECT_COMBO_DETAILS = "PROJECT_COMBO_DETAILS";

    
}
