using System;

public class LeaveAppCommands : WebAppCommands
{
    #region Leave
    public static readonly String LEAVE_DETAILS = "LEAVE_DETAILS";
    public static readonly String DEACTIVATE_LEAVE = "DEACTIVATE_LEAVE";
    public static readonly String ACTIVATE_LEAVE = "ACTIVATE_LEAVE";
    public static readonly String UPDATE_LEAVE = "UPDATE_LEAVE";
    public static readonly String INACTIVE_LEAVE = "INACTIVE_LEAVE";
    public static readonly String LEAVETYPE_DETAILS = "LEAVETYPE_DETAILS";
    public static readonly String EMPLOYEE_LEAVE_TYPES = "EMPLOYEE_LEAVE_TYPES";
    public static readonly String LEAVE_REQUEST_DETAILS_BY_MGRID = "LEAVE_REQUEST_DETAILS_BY_MGRID";

    public static readonly String SETTING_LEAVE_EMPTYPE_DETAILS = "SETTING_LEAVE_EMPTYPE_DETAILS";
    public static readonly String UPDATE_SETTING_LEAVE_EMPTYPE = "UPDATE_SETTING_LEAVE_EMPTYPE";
    public static readonly String DEACTIVATE_SETTING_LEAVE_EMPTYPE = "DEACTIVATE_SETTING_LEAVE_EMPTYPE";
    public static readonly String ACTIVATE_SETTING_LEAVE_EMPTYPE = "ACTIVATE_SETTING_LEAVE_EMPTYPE";
    public static readonly String INACTIVE_SETTING_LEAVE_EMPTYPE = "INACTIVE_SETTING_LEAVE_EMPTYPE";    

   
    public static readonly String LEAVE_REQUEST_BY_EMP_DETAILS = "LEAVE_REQUEST_BY_EMP_DETAILS";
    public static readonly String EMP_LEAVE_OVERVIEW_DETAILS = "EMP_LEAVE_OVERVIEW_DETAILS";

    public static readonly String LEAVE_REQ_STATUS_APPROVE = "APP";
    public static readonly String LEAVE_REQ_STATUS_REJECT = "REJ";
    public static readonly String LEAVE_REQ_STATUS_REQUEST = "REQ";
    public static readonly String LEAVE_REQ_STATUS_CANCEL = "CNL";
    public static readonly String LEAVE_REQ_STATUS_FORLOP = "LOP";

   
    #endregion 
    
    
    #region LeaveEmpType
    public static readonly String LEAVE_EMPTYPE_DETAILS = "LEAVE_EMPTYPE_DETAILS";
    public static readonly String UPDATE_LEAVE_EMPTYPE = "UPDATE_LEAVE_EMPTYPE";

    public static readonly String INACTIVE_LEAVE_GRADE = "INACTIVE_LEAVE_GRADE";    
    public static readonly String DEACTIVATE_LEAVE_GRADE = "DEACTIVATE_LEAVE_GRADE";
    public static readonly String ACTIVATE_LEAVE_GRADE = "ACTIVATE_LEAVE_GRADE";
        
    public static readonly String COMBOLEAVE_DETAILS = "COMBOLEAVE_DETAILS";
    public static readonly String COMBOGRADE_DETAILS = "COMBOGRADE_DETAILS";
    #endregion

    #region Assignempleave
    public static readonly String EMPID_ASSIGN_EMP_LEAVE_DETAILS = "EMPID_ASSIGN_EMP_LEAVE_DETAILS";
    public static readonly String EMPID_ASSIGN_EMP_LEAVE_DETAILS_COMBO = "EMPID_ASSIGN_EMP_LEAVE_DETAILS_COMBO";
    public static readonly String EMPID_ASSIGN_EMP_ENCASH_COMBO = "EMPID_ASSIGN_EMP_ENCASH_COMBO";   
    
    #endregion

    //#region Holiday
    //public static readonly String HOLIDAYS_DETAILS = "HOLIDAYS_DETAILS";
    //public static readonly String HOLIDAYS_BY_LOC_DETAILS = "HOLIDAYS_BY_LOC_DETAILS";   
    //public static readonly String HOLIDAY_CALENDAR_OF_EMP = "HOLIDAY_CALENDAR_OF_EMP";
    //public static readonly String DEACTIVATE_HOLIDAYS = "DEACTIVATE_HOLIDAYS";
    //public static readonly String ACTIVATE_HOLIDAYS = "ACTIVATE_HOLIDAYS";
    //public static readonly String INACTIVE_HOLIDAYS = "INACTIVE_HOLIDAYS";
    //public static readonly String UPDATE_HOLIDAYS = "UPDATE_HOLIDAYS";
    //public static readonly String HOLIDAYS_APPROVAL_REQ = "HOLIDAYS_APPROVAL_REQ";
    //public static readonly String HOLIDAYS_APPROVE = "HOLIDAYS_APPROVE";
    //public static readonly String HOLIDAYS_REJECT = "HOLIDAYS_REJECT";
    //public static readonly String HOLIDAY_STATUS_APPROVE = "APP";
    //public static readonly String HOLIDAY_STATUS_REJECT = "REJ";
    //public static readonly String HOLIDAY_STATUS_REQUEST = "REQ";
    //public static readonly String HOLIDAY_STATUS_NEW = "NEW";
    //#endregion

    #region Weekends
    public static readonly String WEEKENDS_DETAILS = "WEEKENDS_DETAILS"; 
    public static readonly String WEEKENDS_BY_LOC_DETAILS = "WEEKENDS_BY_LOC_DETAILS";
    public static readonly String WEEKENDS_BY_EMPID_DETAILS = "WEEKENDS_BY_EMPID_DETAILS";
    public static readonly String UPDATE_WEEKENDS = "UPDATE_WEEKENDS";
    public static readonly String WEEKENDS_APPROVAL_REQ = "WEEKENDS_APPROVAL_REQ";
    public static readonly String WEEKENDS_APPROVE = "WEEKENDS_APPROVE";
    public static readonly String WEEKENDS_REJECT = "WEEKENDS_REJECT";
    public static readonly String WEEKENDS_STATUS_APPROVE = "APP";
    public static readonly String WEEKENDS_STATUS_REJECT = "REJ";
    public static readonly String WEEKENDS_STATUS_REQUEST = "REQ";
    public static readonly String WEEKENDS_STATUS_NEW = "NEW";
    #endregion

    #region  Encashment
    public static readonly String EMP_LEAVE_ENCASHMENT_DETAILS = "EMP_LEAVE_ENCASHMENT_DETAILS";
    public static readonly String LEAVE_ENCASHMENT_DETAILS = "LEAVE_ENCASHMENT_DETAILS";
    public static readonly String UPDATE_LEAVE_ENCASH_REQUEST = "UPDATE_LEAVE_ENCASH_REQUEST";
    public static readonly String APPROVE_ENCASH_REQUEST = "APPROVE_ENCASH_REQUEST";
    public static readonly String REJECT_ENCASH_REQUEST = "REJECT_ENCASH_REQUEST";

    public static readonly String EMP_LEAVE_ENCASHMENT_FORM_DETAILS = "EMP_LEAVE_ENCASHMENT_FORM_DETAILS";

    public static readonly String ENCASH_REQ_STATUS_APPROVE = "APP";
    public static readonly String ENCASH_REQ_STATUS_REJECT = "REJ";
    public static readonly String ENCASH_REQ_STATUS_REQUEST = "REQ";
    public static readonly String ENCASH_REQ_STATUS_CANCEL = "CNL";
    /// <summary>
    /// /NOTE: read the max value from appsetting or something. hardcoded for now
    /// </summary>
    public static readonly int MAX_ENCASHMENT_ALLOWED_PER_YEAR_COUNT = 20;

    #endregion

    public static readonly String CALENDER_LEAVE_DETAIL = "CALENDER_LEAVE_DETAIL";
    public static readonly String UPDATE_MANUAL_LEAVE = "UPDATE_MANUAL_LEAVE";

    

}