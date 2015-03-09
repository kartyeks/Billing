using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class RecruitmentAppCommands : WebAppCommands
{
    #region Candidate Education

    public static readonly String GET_CANDIDATE_EDUCATION = "GET_CANDIDATE_EDUCATION";
    public static readonly String DELETE_CANDIDATE_EDUCATION = "DELETE_CANDIDATE_EDUCATION";
    
    #endregion

    #region Candidate Dashboard

    public static readonly String GET_CANDIDATE_DETAILS = "GET_CANDIDATE_DETAILS";
    public static readonly String GET_CANDIDATE_DETAILS_BY_ID = "GET_CANDIDATE_DETAILS_BY_ID";
    public static readonly String CHECK_LOGGED_EMP_ISCANDIDATE_MANAGER = "CHECK_LOGGED_EMP_ISCANDIDATE_MANAGER";
    public static readonly String DELETE_CANDIDATE = "DELETE_CANDIDATE";
    
    #endregion

    #region Candidate Inteview Status

    public static readonly String GET_INTERVIEW_STATUS_GRID = "GET_INTERVIEW_STATUS_GRID";
    public static readonly String UPDATE_INTERVIEW_STATUS = "UPDATE_INTERVIEW_STATUS";
    public static readonly String INTERVIEW_STATUS_DET_WITH_TECHNICAL_PANEL = "INTERVIEW_STATUS_DET_WITH_TECHNICAL_PANEL";
    public static readonly String CHECK_LOGGED_EMP_IN_TECHNICAL_PANEL = "CHECK_LOGGED_EMP_IN_TECHNICAL_PANEL";
    public static readonly String UPDATE_INTERVIEW_SCHEDULED_STATUS = "UPDATE_INTERVIEW_SCHEDULED_STATUS";
    public static readonly String UPDATE_AVAILABILITY_STATUS = "UPDATE_AVAILABILITY_STATUS";
    public static readonly String TECH_PANEL_BY_INTERVIEWTYPE = "TECH_PANEL_BY_INTERVIEWTYPE";
    public static readonly String INTERVIEWTYPE_COMBO_BY_STATUSID = "INTERVIEWTYPE_COMBO_BY_STATUSID";
    
    #endregion

    #region Candidate Interview Result

    public static readonly String GET_INTERVIEW_RESULT_GRID = "GET_INTERVIEW_RESULT_GRID";
    public static readonly String GET_INTERVIEW_COMBO_FOR_CANDIDATE = "GET_INTERVIEW_COMBO_FOR_CANDIDATE";
    public static readonly String GET_HR_COMBO = "GET_HR_COMBO";
    public static readonly String UPDATE_INTERVIEW_RESULT = "UPDATE_INTERVIEW_RESULT";
    
    #endregion

    #region Issue Offer

    public static readonly String GET_HIRED_CANDIDATE_GRID = "GET_HIRED_CANDIDATE_GRID";
    public static readonly String UPDATE_CANDIDATE_SALARY = "UPDATE_CANDIDATE_SALARY";
    public static readonly String INTERVIEW_DATE_VALIDATE = "INTERVIEW_DATE_VALIDATE";
    
    #endregion

    #region Notification

    public static readonly String NOTIFY_MANAGER_APP_REJ = "NOTIFY_MANAGER_APP_REJ";
    public static readonly String NOTIFY_PREFFERED_DATETIME = "NOTIFY_PREFFERED_DATETIME";
    public static readonly String NOTIFY_CANDIDATE_AVAILABILITY = "NOTIFY_CANDIDATE_AVAILABILITY";
    public static readonly String NOTIFY_INTERVIEW_RESULT = "NOTIFY_INTERVIEW_RESULT";
    
    #endregion
}
