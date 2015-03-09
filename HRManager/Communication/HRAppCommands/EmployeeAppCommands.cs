using System;

public class EmployeeAppCommands : WebAppCommands
{    

    #region Employee
    public static readonly String CHECK_EMP_ISFRESHER = "CHECK_EMP_ISFRESHER";
    public static readonly String DELETE_EMPLOYEE = "DELETE_EMPLOYEE";
    public static readonly String GET_EMPLOYEE = "GET_EMPLOYEE";
    public static readonly String REMOVE_EMPLOYEE_INFO = "REMOVE_EMPLOYEE_INFO";

    public static readonly String UPDATE_EMPLOYEE_INFO = "UPDATE_EMPLOYEE_INFO";
    public static readonly String GET_EMPLOYEE_GRIDDETAILS = "GET_EMPLOYEE_GRIDDETAILS";

    public static readonly String EMPLOYEE_DETAILS = "EMPLOYEE_DETAILS";
    public static readonly String EMPLOYEECOMBO_DETAILS_FOR_RESOURCEREQUEST = "EMPLOYEECOMBO_DETAILS_FOR_RESOURCEREQUEST";
    public static readonly String EMPLOYEEAPPROVED_DETAILS = "EMPLOYEEAPPROVED_DETAILS";
    public static readonly String EMPLOYEECOMBO_DETAILS = "EMPLOYEECOMBO_DETAILS";
    public static readonly String EMPLOYEEUSER_DETAILS = "EMPLOYEEUSER_DETAILS";
    public static readonly String EMPLOYEECOMBO_LOCATION_DETAILS = "EMPLOYEECOMBO_LOCATION_DETAILS";
    public static readonly String ONLYEMPLOYEEAPPROVED_DETAILS = "ONLYEMPLOYEEAPPROVED_DETAILS";
    public static readonly String EMPLOYEELOCDESGAPP_DETAILS = "EMPLOYEELOCDESGAPP_DETAILS";
    public static readonly String EMPLOYEEDISPLAY_DETAILS = "EMPLOYEEDISPLAY_DETAILS";
    public static readonly String UPDATE_EMPLOYEE_FAMILY = "UPDATE_EMPLOYEE_FAMILY";
    public static readonly String UPDATE_EMPLOYEE_PREVEMPLOYMENT = "UPDATE_EMPLOYEE_PREVEMPLOYMENT";
    public static readonly String UPDATE_EMPLOYEE_ACADEMIC = "UPDATE_EMPLOYEE_ACADEMIC";
    public static readonly String UPDATE_EMPLOYEE_SHIFT = "UPDATE_EMPLOYEE_SHIFT";
    public static readonly String EMPLOYEEINFO_DETAILS = "EMPLOYEEINFO_DETAILS";
    public static readonly String EMPLOYEE_DETAILS_BYLOCBRA = "EMPLOYEE_DETAILS_BYLOCBRA";
    public static readonly String EMPLOYEE_DETAILS_FOR_POLICY = "EMPLOYEE_DETAILS_FOR_POLICY";
    public static readonly String ALL_EMPLOYEES = "ALL_EMPLOYEES";
    public static readonly String ALL_USER_EMPLOYEES = "ALL_USER_EMPLOYEES";
    public static readonly String EMPLOYEEPOLICYFILTER_DETAILS = "EMPLOYEEPOLICYFILTER_DETAILS";
    public static readonly String REPORTINGTO_DETAILS = "REPORTINGTO_DETAILS";
    public static readonly String UPDATE_EMPLOYEE_TRAINING = "UPDATE_EMPLOYEE_TRAINING";
    public static readonly String ALL_EMPLOYEES_BRANCHWISE_SALCER = "ALL_EMPLOYEES_BRANCHWISE_SALCER";
    public static readonly String ALL_EMPLOYEES_JOINING_BRANCHWISE_BETWEEN_DATE = "ALL_EMPLOYEES_JOINING_BRANCHWISE_BETWEEN_DATE";
    public static readonly String ALL_EMPLOYEES_BRANCHWISE_FOR_ATTENDANCE = "ALL_EMPLOYEES_BRANCHWISE_FOR_ATTENDANCE";
    public static readonly String EMPLOYEES_FOR_OVERTIME = "EMPLOYEES_FOR_OVERTIME";
    public static readonly String ALL_EMPLOYEES_JOINING_BRANCHWISE_SALCER = "ALL_EMPLOYEES_JOINING_BRANCHWISE_SALCER";
    public static readonly String ALL_EMPLOYEES_BRANCH_LOC_DEPT = "ALL_EMPLOYEES_BRANCH_LOC_DEPT";
    public static readonly String ALL_EMPLOYEES_EMPLOYEE_NOTIFICATION = "ALL_EMPLOYEES_EMPLOYEE_NOTIFICATION";
    public static readonly String EMPLOYEE_NOTIFICATION_HTML = "EMPLOYEE_NOTIFICATION_HTML";
    public static readonly String ALL_EMPLOYEES_LEAVE_BALANCE = "ALL_EMPLOYEES_LEAVE_BALANCE";
    public static readonly String REPORTING_MANGER_DETAILS = "REPORTING_MANGER_DETAILS";
    public static readonly String FUNCTIONAL_REPORTING_MANGER_DETAILS = "FUNCTIONAL_REPORTING_MANGER_DETAILS";
    public static readonly String REPORTING_MANGER_NAME = "REPORTING_MANGER_NAME";

    
    

    public static readonly String EMPLOYEESHIFT_DETAILS = "EMPLOYEESHIFT_DETAILS";
    public static readonly String GETEMPLOYEEGRADE = "GETEMPLOYEEGRADE";
    public static readonly String ALL_EMPLOYEES_BRANCHWISE = "ALL_EMPLOYEES_BRANCHWISE";
    public static readonly String ALL_EMPLOYEES_BRANCHWISE_FOR_REPAYMENT = "ALL_EMPLOYEES_BRANCHWISE_FOR_REPAYMENT";
    public static readonly String ALL_EMPLOYEES_BRANCHWISE_FOR_ADVANCEREPAYMENT = "ALL_EMPLOYEES_BRANCHWISE_FOR_ADVANCEREPAYMENT";
    
    public static readonly String POLICY_DOWNLOAD_DETAILS = "POLICY_DOWNLOAD_DETAILS";

    public static readonly String ALL_EMPLOYEES_DOCUMENTS = "ALL_EMPLOYEES_DOCUMENTS";

    public static readonly String UPDATE_CANDIDATEREMARK = "UPDATE_CANDIDATEREMARK";
    public static readonly String EMPDEPTWISE_DETAILS = "EMPDEPTWISE_DETAILS";
    public static readonly String ALL_EMPLOYEES_SUMMARY = "ALL_EMPLOYEES_SUMMARY";
    public static readonly String EMPLOYEETYPEFORSEARCH_DETAILS = "EMPLOYEETYPEFORSEARCH_DETAILS";
    public static readonly String FUNCTIONAL_REPORTINGTO_DETAILS = "FUNCTIONAL_REPORTINGTO_DETAILS";
    public static readonly String EMPLOYEE_DETAILS_FOR_EXITINTERVIEW = "EMPLOYEE_DETAILS_FOR_EXITINTERVIEW";
    public static readonly String EMPLOYEES_TO_TERMINATE = "EMPLOYEES_TO_TERMINATE";
    public static readonly String EMPLOYEE_DETAILS_FOR_SUBMIT_APPRAISAL = "EMPLOYEE_DETAILS_FOR_SUBMIT_APPRAISAL";
    public static readonly String EMPLOYEE_DETAILS_FOR_APPRAISAL_SELFCOMMENT = "EMPLOYEE_DETAILS_FOR_APPRAISAL_SELFCOMMENT";
    public static readonly String ALL_EMPLOYEES_GRIEVANCE = "ALL_EMPLOYEES_GRIEVANCE";
    public static readonly String UPDATE_EMPLOYEE_RETIREMENTDATE = "UPDATE_EMPLOYEE_RETIREMENTDATE";

    public static readonly String ALL_EMPLOYEE_BY_NAME = "ALL_EMPLOYEE_BY_NAME";
    public static readonly String DELETE_EMPLOYEE_DOCUMENT = "DELETE_EMPLOYEE_DOCUMENT";
    public static readonly String EMPLOYEE_EMPNO_DETAILS = "EMPLOYEE_EMPNO_DETAILS";
    public static readonly String CALCULATE_CTC_DETAILS = "CALCULATE_CTC_DETAILS";
    
    
    
    #endregion    

    #region Employee Emergency Contact
    public static readonly String EMP_EMERGECNY_DETAILS = "EMP_EMERGECNY_DETAILS";
    public static readonly String UPDATE_EMP_EMERGENCYCONTACT = "UPDATE_EMP_EMERGENCYCONTACT";

    #endregion

    #region Employee Bank details
    public static readonly String EMP_BABK_DETAILS = "EMP_BABK_DETAILS";
    public static readonly String UPDATE_EMP_BANKDETAILS = "UPDATE_EMP_BANKDETAILS";

    #endregion

    #region Employee Trainer details
    public static readonly String ALL_EMPLOYEES_FOR_TRAINER = "ALL_EMPLOYEES_FOR_TRAINER";

    #endregion

    
   
}