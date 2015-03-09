using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.Entity;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IS91.Services;
//using HRManager.Entity.LeaveApp;
using IS91.Services.DataBlock;


namespace HRManager
{
    public class HRLeaveManager
    {
    //    public static AssignEmpLeave[] GetAssign_Emp_Leave()
    //    {
    //        Assign_Emp_LeaveBusinessObject objEmpLeaveBO = new Assign_Emp_LeaveBusinessObject();
    //        return objEmpLeaveBO.GetAllAssignEmpLeaves();
    //    }
        public static Leave[] GetActiveLeaves()
        {
            return Leave.GetActiveLeaves();

        }
    //    public static LeaveCalender[] GetActiveLeaveCalender(int EmployeeId)
    //    {
    //        return Leave.GetActiveLeaveCalender(EmployeeId);

    //    }
    //    public static LeaveCalenderDetails GetActiveLeaveCalenderDetails(int EmployeeId)
    //    {
    //        return Leave.GetActiveLeaveCalenderDetails(EmployeeId);

    //    }
    //    public static LeaveRequest[] GetLeaveRequests(int ManagerId)
    //    {
    //        Leave_RequestBusinessObject objLeaveRequestBO = new Leave_RequestBusinessObject();
    //        return objLeaveRequestBO.GetAllLeaveRequests(ManagerId);

    //    }

    //    public static LeaveRequest[] GetAllLeaveRequestsByEmp(int EmployeeID)
    //    {
    //        Leave_RequestBusinessObject objLeaveRequestBO = new Leave_RequestBusinessObject();
    //        return objLeaveRequestBO.GetAllLeaveRequestsByEmpID(EmployeeID);
    //    }


    //    /// <summary>
    //    /// Update Role of given ID
    //    /// </summary>
    //    /// <param name="ID">field contain Role ID</param>
    //    /// <param name="ZoneName">field contain Role Name</param>
    //    /// <param name="Description">field contain Role Description</param>
    //    /// <param name="IsActive">field contaions Active status.</param>
    //    /// <param name="UpdatedBy">field contain the user id who update Role</param>
    //    /// <returns>empty string for success and error message for failure</returns>
    //    public static String UpdateLeaveRequest(int ID, int EmpID, int LeaveID, DateTime FromDate,
    //        DateTime ToDate, Boolean IsHalfDay, String Reason, DateTime AppliedDate, int AppliedTo,
    //        string CCMailID, string ManagerRemarks, Double DayCount, int UpdateBy, string ContactAddress, string PhoneNumber)
    //    {

    //        try
    //        {
    //            LeaveRequest LeaveRequest = new LeaveRequest(ID);
    //            LeaveRequest.EmpID = EmpID;
    //            LeaveRequest.LeaveID = LeaveID;
    //            LeaveRequest.FromDate = FromDate;
    //            LeaveRequest.ToDate = ToDate;
    //            LeaveRequest.IsHalfDay = IsHalfDay;
    //            LeaveRequest.Reason = Reason;
    //            LeaveRequest.AppliedDate = AppliedDate;

    //            LeaveRequest.CCMailID = CCMailID;
    //            LeaveRequest.ManagerRemarks = ManagerRemarks;
    //            string Status = LeaveAppCommands.LEAVE_REQ_STATUS_REQUEST;
    //            LeaveRequest.Status = Status;
    //            LeaveRequest.ReprotingMgrStatus = Status;
    //            LeaveRequest.FunctionalMgrStatus = Status;
    //            LeaveRequest.DayCount = DayCount;
    //            LeaveRequest.RepliedDateTime = Convert.ToDateTime("1/2/1753");
    //            LeaveRequest.UpdatedBy = UpdateBy;
    //            LeaveRequest.ContactAddress = ContactAddress;
    //            LeaveRequest.PhoneNumber = PhoneNumber;
    //            //fill AppliedTo for new requests
    //            if (ID == 0)
    //            {
    //                //get ReprotingMgrID from assign_emp_ReportingTo
    //                // AssignEmpDesignation empDesig = new AssignEmpDesignation(0, EmpID);
    //                AssignEmpReportingTo empReop = new AssignEmpReportingTo(0, EmpID);
    //                int repMgrId = 0;
    //                int fnMgrId = 0;
    //                if (empReop != null)
    //                {
    //                    repMgrId = empReop.ReprotingMgrID;
    //                    fnMgrId = empReop.FunctionalReportingTo;
    //                }
    //                if (repMgrId > 0)
    //                {
    //                    //get LeaveAppliedTo from this AssignEmpReportingTo object
    //                    LeaveRequest.AppliedTo = repMgrId;
    //                    LeaveRequest.ReprotingMgr = repMgrId;
    //                    LeaveRequest.FunctionalMgr = fnMgrId;
    //                    //get LeaveAppliedTo for this designation
    //                    //Designation masterDesig = new Designation(empDesig.DesignationID);
    //                    //if (masterDesig != null)
    //                    //{
    //                    //    leaveRepMgr = masterDesig.LeaveAppliedTo;
    //                    //    LeaveRequest.AppliedTo = leaveRepMgr;
    //                    //}
    //                    //else
    //                    //{
    //                    //    return "Cannot get Leave-Applied_To manager details";
    //                    //}
    //                }
    //                else
    //                {
    //                    return "Cannot get Leave Applied_To Manager details. Please verify the setup for Employee reporting to Manager";
    //                }
    //            }
    //            String State = LeaveRequest.Save(LeaveAppCommands.LEAVE_REQ_STATUS_REQUEST);

    //            return State;
    //        }
    //        catch (Exception ex)
    //        {

    //            IRCAExceptionHandler.HandleException(new IRCAException(ex, HRManagerDefs.LeaveMessages.LEAVE_UPDATE_FAILURE, ID.ToString()));
    //            return HRManagerDefs.LeaveMessages.LEAVE_UPDATE_FAILURE;
    //        }
    //    }

    //    /// <summary>
    //    /// Update Role of given ID
    //    /// </summary>
    //    /// <param name="ID">field contain Role ID</param>
    //    /// <param name="ZoneName">field contain Role Name</param>
    //    /// <param name="Description">field contain Role Description</param>
    //    /// <param name="IsActive">field contaions Active status.</param>
    //    /// <param name="UpdatedBy">field contain the user id who update Role</param>
    //    /// <returns>empty string for success and error message for failure</returns>
    //    public static String UpdateLeaveApprove(int ID, int UpdateBy)
    //    {
    //        String State = String.Empty;

    //        try
    //        {
    //            LeaveRequest LeaveRequest = new LeaveRequest(ID);
    //            string Status = LeaveAppCommands.LEAVE_REQ_STATUS_APPROVE;
    //            LeaveRequest.Status = LeaveAppCommands.LEAVE_REQ_STATUS_REQUEST;
    //            Leave_Request empLeaveRequest = new Leave_RequestBusinessObject().GetLeaveRequestsByID(ID);
    //            LeaveRequest.ReprotingMgr = empLeaveRequest.ReprotingMgr;
    //            LeaveRequest.ReprotingMgrStatus = empLeaveRequest.ReprotingMgrStatus;
    //            LeaveRequest.FunctionalMgr = empLeaveRequest.FunctionalMgr;
    //            LeaveRequest.FunctionalMgrStatus = empLeaveRequest.FunctionalMgrStatus;

    //            if (empLeaveRequest.ReprotingMgr == UpdateBy && empLeaveRequest.FunctionalMgr == UpdateBy)
    //            {
    //                LeaveRequest.ReprotingMgrStatus = Status;
    //                LeaveRequest.FunctionalMgrStatus = Status;
    //                LeaveRequest.Status = Status;
    //                empLeaveRequest.ReprotingMgrStatus = Status;
    //                empLeaveRequest.FunctionalMgrStatus = Status;
    //                new Leave_RequestBusinessObject().Update(empLeaveRequest);
    //            }
    //            else if (empLeaveRequest.ReprotingMgr == UpdateBy)
    //            {
    //                LeaveRequest.ReprotingMgrStatus = Status;
    //                empLeaveRequest.ReprotingMgrStatus = Status;
    //                new Leave_RequestBusinessObject().Update(empLeaveRequest);

    //            }
    //            else
    //            {
    //                LeaveRequest.FunctionalMgrStatus = Status;
    //                empLeaveRequest.FunctionalMgrStatus = Status;
    //                new Leave_RequestBusinessObject().Update(empLeaveRequest);
    //            }

    //            //if (empLeaveRequest.ReprotingMgr == UpdateBy)
    //            //    LeaveRequest.ReprotingMgrStatus = Status;
    //            //else
    //            //    LeaveRequest.FunctionalMgrStatus = Status;
    //            if (LeaveRequest.FunctionalMgrStatus == LeaveRequest.ReprotingMgrStatus)
    //            {
    //                if (LeaveRequest.FunctionalMgrStatus == Status)
    //                    LeaveRequest.Status = Status;

    //                State = LeaveRequest.SaveAction(LeaveAppCommands.LEAVE_REQ_STATUS_APPROVE);

    //            }
    //            //set RepliedDateTime 
    //            LeaveRequest.RepliedDateTime = DateTime.Now;

    //            //State = LeaveRequest.SaveAction(LeaveAppCommands.LEAVE_REQ_STATUS_APPROVE);

    //            //Once leave is approved, update assign_emp_leave table , leave 'Used' count
    //            //getting an array AssignEmpLeave, but always only one row will be returned.
    //            //BUT, do this only for leave req in current year. because ael table row is for current year.
    //            //Assign_Emp_Leave[] AssignEmpLeaveDT = new Assign_Emp_LeaveBusinessObject().GetAssignEmpLeavesByLeaveAndEmpId(LeaveRequest.LeaveID, LeaveRequest.EmpID);

    //            //if (AssignEmpLeaveDT.Length > 0)   // = 0 should never happen
    //            //{
    //            //    if (IsLeaveReqUnderCurrentLeaveYear(LeaveRequest))
    //            //    {
    //            //        double currentUsedCount = AssignEmpLeaveDT[0].UsedLeaves;
    //            //        currentUsedCount = currentUsedCount + LeaveRequest.DayCount;

    //            //        double currentBalanceCount = AssignEmpLeaveDT[0].BalanceLeave;

    //            //        currentBalanceCount = currentBalanceCount - LeaveRequest.DayCount;

    //            //        AssignEmpLeave objAssignEmpLeave = new AssignEmpLeave(AssignEmpLeaveDT[0]);
    //            //        objAssignEmpLeave.UsedLeaves = currentUsedCount;
    //            //        objAssignEmpLeave.BalanceLeave = currentBalanceCount;
    //            //        //save
    //            //        objAssignEmpLeave.Save();
    //            //    }
    //            //}

    //            return State;
    //        }
    //        catch (Exception ex)
    //        {
    //            IRCAExceptionHandler.HandleException(
    //                new IRCAException(ex, HRManagerDefs.LeaveMessages.LEAVE_UPDATE_FAILURE, ID.ToString())
    //                );
    //            return HRManagerDefs.LeaveMessages.LEAVE_UPDATE_FAILURE;
    //        }
    //    }

    //    public static bool IsLeaveReqUnderCurrentLeaveYear(LeaveRequest inLR)
    //    {
    //        //hardcode end of leave year as dec 31 for now.
    //        if (inLR.FromDate.Year != System.DateTime.Now.Year)
    //            return false;
    //        else
    //            return true;
    //    }


    //    /// <summary>
    //    /// Update Role of given ID
    //    /// </summary>
    //    /// <param name="ID">field contain Role ID</param>
    //    /// <param name="ZoneName">field contain Role Name</param>
    //    /// <param name="Description">field contain Role Description</param>
    //    /// <param name="IsActive">field contaions Active status.</param>
    //    /// <param name="UpdatedBy">field contain the user id who update Role</param>
    //    /// <returns>empty string for success and error message for failure</returns>
    //    public static String UpdateLeaveReject(int ID)
    //    {
    //        try
    //        {
    //            LeaveRequest LeaveRequest = new LeaveRequest(ID);
    //            string Status = LeaveAppCommands.LEAVE_REQ_STATUS_REJECT;
    //            LeaveRequest.Status = Status;
    //            //set RepliedDateTime 
    //            LeaveRequest.RepliedDateTime = DateTime.Now;

    //            String State = LeaveRequest.SaveAction(LeaveAppCommands.LEAVE_REQ_STATUS_REJECT);

    //            return State;
    //        }
    //        catch (Exception ex)
    //        {
    //            IRCAExceptionHandler.HandleException(
    //                new IRCAException(ex, HRManagerDefs.LeaveMessages.LEAVE_UPDATE_FAILURE, ID.ToString())
    //                );
    //            return HRManagerDefs.LeaveMessages.LEAVE_UPDATE_FAILURE;
    //        }
    //    }

    //    //public static EmployeeLeaveOverview[] EmployeeLeaveOverviewByEmpID(int EmployeeId)
    //    //{
    //    //    return EmployeeLeaveOverview.EmployeeLeaveOverviewByEmpID(EmployeeId);

    //    //}

    //    public static EmployeeLeave[] EmployeeLeaveOverviewByEmpID(int EmployeeId)
    //    {
    //        return EmployeeLeave.GetEmployeeLeave(EmployeeId);
    //    }

    //    public static SettingLeaveEmployeeType[] GetSettingLeaveEmpTypeDetails()
    //    {
    //        return SettingLeaveEmployeeType.GetSettingLeaveEmpTypeDetails();

    //    }

    //    public static string UpdateSettingLeaveEmpType(
    //        int ID,
    //        int EmployeeTypeID,
    //        int LeaveID,
    //        double LeaveCount,
    //        double MinDaysToApply,
    //        double MaxDaysToApply,
    //        int EligibleAfter_InDays,
    //        string LeaveCreditedPeriod,
    //        int MaxApprovedLimit,
    //        bool CanCarryForward,
    //        double CarryForwardCount,
    //        bool IsDocumentRequired,
    //        int DocumentRequiredPeriod,
    //        bool PostSubmissionIsAllowed,
    //        bool IncludeWeekEnds,
    //        bool IsContactAddressRequired,
    //        bool CanBeEncashed,
    //        int MinDaysToEncash,
    //        double MandatoryLeaveDays,
    //        bool CreditOnCompletePeriod,
    //        bool IsEligibleForFemale,
    //        int LeaveGap,
    //        bool IsActive,
    //        bool IsApplicableForEncash,
    //        double MinBalLeaveToEncash,
    //        int UpdateBy)
    //    {
    //        try
    //        {
    //            SettingLeaveEmployeeType LeaveEmployeeType = new SettingLeaveEmployeeType(ID);
    //            LeaveEmployeeType.ID = ID;
    //            LeaveEmployeeType.EmployeeTypeID = EmployeeTypeID;
    //            LeaveEmployeeType.LeaveID = LeaveID;
    //            //LeaveEmployeeType.EmployeeTypeName = EmployeeType;
    //            //LeaveEmployeeType.LeaveType = Leave;
    //            LeaveEmployeeType.LeaveCount = LeaveCount;
    //            LeaveEmployeeType.MinDaysToApply = MinDaysToApply;
    //            LeaveEmployeeType.MaxDaysToApply = MaxDaysToApply;
    //            LeaveEmployeeType.EligibleAfter_InDays = EligibleAfter_InDays;
    //            LeaveEmployeeType.LeaveCreditedPeriod = LeaveCreditedPeriod;
    //            LeaveEmployeeType.MaxApprovedLimit = MaxApprovedLimit;
    //            LeaveEmployeeType.CanCarryForward = CanCarryForward;
    //            LeaveEmployeeType.CarryForwardCount = CarryForwardCount;
    //            LeaveEmployeeType.IsDocumentRequired = IsDocumentRequired;
    //            LeaveEmployeeType.DocumentRequiredPeriod = DocumentRequiredPeriod;
    //            LeaveEmployeeType.PostSubmissionIsAllowed = PostSubmissionIsAllowed;
    //            LeaveEmployeeType.IncludeWeekEnds = IncludeWeekEnds;
    //            LeaveEmployeeType.IsContactAddressRequired = IsContactAddressRequired;
    //            LeaveEmployeeType.CanBeEncashed = CanBeEncashed;
    //            LeaveEmployeeType.MinDaysToEncash = MinDaysToEncash;
    //            LeaveEmployeeType.MandatoryLeaveDays = MandatoryLeaveDays;
    //            LeaveEmployeeType.CreditOnCompletePeriod = CreditOnCompletePeriod;
    //            LeaveEmployeeType.IsEligibleForFemale = IsEligibleForFemale;
    //            LeaveEmployeeType.LeaveGap = LeaveGap;
    //            LeaveEmployeeType.IsApplicableForEncash = IsApplicableForEncash;
    //            LeaveEmployeeType.MinBalanceLeaveForEncash = MinBalLeaveToEncash;
    //            LeaveEmployeeType.IsActive = IsActive;

    //            String State = LeaveEmployeeType.Save();

    //            return State;
    //        }
    //        catch (Exception ex)
    //        {
    //            IRCAExceptionHandler.HandleException(
    //                new IRCAException(ex, HRLeaveManagerDefs.LeaveEmployeeTypeMessages.UPDATE_SETTING_LEAVE_EMPTYPE_FAILURE, ID.ToString())
    //                );
    //            return HRLeaveManagerDefs.LeaveEmployeeTypeMessages.UPDATE_SETTING_LEAVE_EMPTYPE_FAILURE;
    //        }
    //    }

    //    public static SettingLeaveEmployeeType[] GetInActiveSettingLeaveEmpType()
    //    {
    //        return SettingLeaveEmployeeType.GetInActiveSettingLeaveEmpType();
    //    }

    //    public static String ActivateSettingLeaveEmpType(int ID, int ActivatedBy)
    //    {
    //        try
    //        {
    //            return new SettingLeaveEmployeeType(ID).Activate(ActivatedBy);
    //        }
    //        catch (Exception ex)
    //        {
    //            IRCAExceptionHandler.HandleException(
    //                new IRCAException(ex, HRLeaveManagerDefs.LeaveEmployeeTypeMessages.UPDATE_SETTING_LEAVE_EMPTYPE_FAILURE, ID.ToString())
    //                );
    //            return HRLeaveManagerDefs.LeaveEmployeeTypeMessages.UPDATE_SETTING_LEAVE_EMPTYPE_FAILURE;
    //        }
    //    }

    //    public static String DeActivateSettingLeaveEmpType(int ID, int DeactivatedBy)
    //    {
    //        try
    //        {
    //            return new SettingLeaveEmployeeType(ID).DeActivate(DeactivatedBy);
    //        }
    //        catch (Exception ex)
    //        {
    //            IRCAExceptionHandler.HandleException(
    //                new IRCAException(ex, HRLeaveManagerDefs.LeaveEmployeeTypeMessages.UPDATE_SETTING_LEAVE_EMPTYPE_FAILURE, ID.ToString())
    //                );
    //            return HRLeaveManagerDefs.LeaveEmployeeTypeMessages.UPDATE_SETTING_LEAVE_EMPTYPE_FAILURE;
    //        }
    //    }

    //    #region Holidays
    //    /// <summary>
    //    /// Return all Holidays
    //    /// </summary>
    //    /// <returns>Array of the object of Holidays class</returns>
    //    public static Holidays[] GetHolidays()
    //    {
    //        return Holidays.GetAllHolidays();
    //    }

    //    public static Holidays[] GetInActiveHolidays()
    //    {
    //        return Holidays.GetAllInActiveHolidays();
    //    }
    //    /// <summary>
    //    /// Update Holidays of given ID
    //    /// <returns>empty string for success and error message for failure</returns>
    //    /// </summary>
    //    public static String UpdateHolidays(int ID, String HolidayName, DateTime HolidayDate, int LocationID, String Description, bool IsActive, string Status, int RequestingTo, int UpdatedBy)
    //    {
    //        Holidays objHolidays = null;
    //        String retStatus;
    //        try
    //        {
    //            if (ID == 0)
    //            {
    //                objHolidays = new Holidays();
    //            }
    //            else
    //            {
    //                objHolidays = new Holidays(ID);
    //            }

    //            if (objHolidays.Status == LeaveAppCommands.HOLIDAY_STATUS_APPROVE)
    //            {
    //                //should not be able to updated holoday detials after approval has been done
    //                retStatus = HRLeaveManagerDefs.Holidays.DISALLOW_APPROVED_HOLIDAY_UPDATE;
    //            }
    //            else
    //            {
    //                objHolidays.HolidayName = HolidayName;
    //                objHolidays.HolidayDate = HolidayDate;
    //                objHolidays.LocationID = LocationID;
    //                objHolidays.Description = Description;
    //                objHolidays.IsActive = IsActive;
    //                objHolidays.Status = Status;
    //                objHolidays.RequestingTo = RequestingTo;
    //                objHolidays.UpdatedBy = UpdatedBy;
    //                retStatus = objHolidays.Save();
    //            }
    //            return retStatus;
    //        }
    //        catch (Exception ex)
    //        {
    //            IRCAExceptionHandler.HandleException(
    //                new IRCAException(ex, HRLeaveManagerDefs.Holidays.HOLIDAY_UPDATE_FAILURE, ID.ToString())
    //                );
    //            return HRLeaveManagerDefs.Holidays.HOLIDAY_UPDATE_FAILURE;
    //        }
    //    }


    //    /// <summary>
    //    /// Activate Holidays by ID
    //    /// </summary>
    //    /// <param name="ID">field contain Holidays ID</param>
    //    /// <param name="ActivatedBy">field contain the user id who Activate Holidays</param>
    //    /// <returns>empty string for success and error message for failure</returns>
    //    public static String ActivateHoliday(int ID, int ActivateBy)
    //    {
    //        try
    //        {
    //            return new Holidays(ID).Activate(ActivateBy);
    //        }
    //        catch (Exception ex)
    //        {
    //            IRCAExceptionHandler.HandleException(
    //                new IRCAException(ex, HRLeaveManagerDefs.Holidays.HOLIDAY_UPDATE_FAILURE, ID.ToString()));
    //            return HRLeaveManagerDefs.Holidays.HOLIDAY_UPDATE_FAILURE;
    //        }
    //    }

    //    public static String DeActivateHoliday(int ID, int DeActivateBy)
    //    {
    //        try
    //        {
    //            return new Holidays(ID).DeActivate(DeActivateBy);
    //        }
    //        catch (Exception ex)
    //        {
    //            IRCAExceptionHandler.HandleException(
    //                new IRCAException(ex, HRLeaveManagerDefs.Holidays.HOLIDAY_UPDATE_FAILURE, ID.ToString())
    //                );
    //            return HRLeaveManagerDefs.Holidays.HOLIDAY_UPDATE_FAILURE;
    //        }
    //    }

    //    public static String RequestHolidayApproval(int ID, int ReqToEmpId)
    //    {
    //        try
    //        {
    //            Holidays objHolidays = new Holidays(ID);

    //            objHolidays.Status = LeaveAppCommands.HOLIDAY_STATUS_REQUEST;
    //            objHolidays.RequestingTo = ReqToEmpId;

    //            String retStatus = objHolidays.Save();

    //            return retStatus;
    //        }
    //        catch (Exception ex)
    //        {
    //            IRCAExceptionHandler.HandleException(
    //                new IRCAException(ex, HRLeaveManagerDefs.Holidays.HOLIDAY_APPROVE_FAILURE, ID.ToString())
    //                );
    //            return HRLeaveManagerDefs.Holidays.HOLIDAY_APPROVE_FAILURE;
    //        }
    //    }

    //    public static String ApproveHoliday(int ID, int UpdatedBy)
    //    {
    //        try
    //        {
    //            Holidays objHolidays = new Holidays(ID);

    //            objHolidays.Status = LeaveAppCommands.HOLIDAY_STATUS_APPROVE;
    //            objHolidays.UpdatedBy = UpdatedBy;
    //            String retStatus = objHolidays.Save();

    //            return retStatus;
    //        }
    //        catch (Exception ex)
    //        {
    //            IRCAExceptionHandler.HandleException(
    //                new IRCAException(ex, HRLeaveManagerDefs.Holidays.HOLIDAY_APPROVE_FAILURE, ID.ToString())
    //                );
    //            return HRLeaveManagerDefs.Holidays.HOLIDAY_APPROVE_FAILURE;
    //        }
    //    }

    //    public static String RejectHoliday(int ID, int UpdatedBy)
    //    {
    //        try
    //        {
    //            Holidays objHolidays = new Holidays(ID);

    //            objHolidays.Status = LeaveAppCommands.HOLIDAY_STATUS_REJECT;
    //            objHolidays.UpdatedBy = UpdatedBy;
    //            String retStatus = objHolidays.Save();

    //            return retStatus;
    //        }
    //        catch (Exception ex)
    //        {
    //            IRCAExceptionHandler.HandleException(
    //                new IRCAException(ex, HRLeaveManagerDefs.Holidays.HOLIDAY_APPROVE_FAILURE, ID.ToString())
    //                );
    //            return HRLeaveManagerDefs.Holidays.HOLIDAY_APPROVE_FAILURE;
    //        }
    //    }

    //    public static Holidays[] GetHolidaysByLocation(int LocationId)
    //    {
    //        return Holidays.GetHolidaysByLocation(LocationId);
    //    }

    //    public static Holidays[] GetHolidaysByEmpId(int EmployeeId)
    //    {
    //        return Holidays.GetHolidaysByEmpId(EmployeeId);
    //    }

    //    #endregion


    //    #region Weekends
    //    /// <summary>
    //    /// Return all Weekends
    //    /// </summary>
    //    /// <returns>Array of the object of Weekends class</returns>
    //    public static Weekends[] GetAllWeekends()
    //    {
    //        return Weekends.GetAllWeekends();
    //    }

    //    /// <summary>
    //    /// Update Weekends of given ID
    //    /// <returns>empty string for success and error message for failure</returns>
    //    /// </summary>
    //    public static String UpdateWeekends(int ID, int LocationID, Double Mon, Double Tue, Double Wed, Double Thu, Double Fri, Double Sat, Double Sun, String Remarks, string Status, int RequestingTo, DateTime ActivatedDate, int UpdatedBy)
    //    {
    //        Weekends objWeekends = null;
    //        String retStatus;
    //        try
    //        {
    //            if (ID == 0)
    //            {
    //                objWeekends = new Weekends();
    //                objWeekends.Status = LeaveAppCommands.WEEKENDS_STATUS_NEW;
    //            }
    //            else
    //            {
    //                objWeekends = new Weekends(ID);
    //            }

    //            if (objWeekends.Status == LeaveAppCommands.WEEKENDS_STATUS_APPROVE)
    //            {
    //                //should not be able to updated holoday detials after approval has been done
    //                retStatus = HRLeaveManagerDefs.Weekends.DISALLOW_APPROVED_WEEKENDS_UPDATE;
    //            }
    //            else
    //            {
    //                objWeekends.Mon = Mon;
    //                objWeekends.Tue = Tue;
    //                objWeekends.Wed = Wed;
    //                objWeekends.Thu = Thu;
    //                objWeekends.Fri = Fri;
    //                objWeekends.Sat = Sat;
    //                objWeekends.Sun = Sun;

    //                objWeekends.ActivatedDate = ActivatedDate;
    //                objWeekends.LocationID = LocationID;
    //                objWeekends.Status = LeaveAppCommands.WEEKENDS_STATUS_NEW;
    //                objWeekends.Remarks = Remarks;
    //                objWeekends.RequestingTo = RequestingTo;
    //                objWeekends.UpdatedBy = UpdatedBy;
    //                retStatus = objWeekends.Save();
    //            }
    //            return retStatus;
    //        }
    //        catch (Exception ex)
    //        {
    //            IRCAExceptionHandler.HandleException(
    //                new IRCAException(ex, HRLeaveManagerDefs.Weekends.WEEKENDS_UPDATE_FAILURE, ID.ToString())
    //                );
    //            return HRLeaveManagerDefs.Weekends.WEEKENDS_UPDATE_FAILURE;
    //        }
    //    }

    //    public static String UpdateWeekendStatus(int ID, String status, int ReqToEmpId, int UpdatedBy)
    //    {
    //        try
    //        {
    //            Weekends objWeekends = new Weekends(ID);

    //            objWeekends.Status = status;
    //            objWeekends.UpdatedBy = UpdatedBy;

    //            //if request for approva, add the req-to id also.
    //            if (status == LeaveAppCommands.WEEKENDS_STATUS_REQUEST)
    //            {
    //                objWeekends.RequestingTo = ReqToEmpId;
    //            }

    //            String retStatus = objWeekends.Save();

    //            return retStatus;
    //        }
    //        catch (Exception ex)
    //        {
    //            IRCAExceptionHandler.HandleException(
    //                new IRCAException(ex, HRLeaveManagerDefs.Weekends.WEEKENDS_STATUS_UPDATE_FAILURE, ID.ToString())
    //                );
    //            return HRLeaveManagerDefs.Weekends.WEEKENDS_STATUS_UPDATE_FAILURE;
    //        }
    //    }

    //    public static Weekends[] GetWeekendsByLocation(int LocationId)
    //    {
    //        return Weekends.GetWeekendsByLocation(LocationId);
    //    }

    //    public static Weekends[] GetWeekendsByEmp(int EmployeeId)
    //    {
    //        return Weekends.GetWeekendsByEmpId(EmployeeId);
    //    }
    //    #endregion

    //    #region LeaveGrade
    //    /// <summary>
    //    /// Activate Designation by ID
    //    /// </summary>
    //    /// <param name="ID">field contain Designation ID</param>
    //    /// <param name="ActivatedBy">field contain the user id who Activate Designation</param>
    //    /// <returns>empty string for success and error message for failure</returns>
    //    public static String ActivateLeaveGrade(int ID, int ActivatedBy)
    //    {
    //        //try
    //        //{
    //        //    LeaveEmployeeType objLeaveGrade = new LeaveEmployeeType(ID);
    //        //    string status = objLeaveGrade.Activate(ActivatedBy);
    //        //    if (status == string.Empty)
    //        //    {
    //        //        //Leave grade may have been added as isactive=0 & then changed to 1. add table entries for assign_emp_leave
    //        //        HRManager.AddAssignEmpLeaveForNewLeaveGrade(objLeaveGrade);
    //        //    }
    //        //    return status;
    //        //}
    //        try
    //        {
    //            LeaveEmployeeType objLeaveGrade = new LeaveEmployeeType(ID);
    //            string status = objLeaveGrade.Activate(ActivatedBy);
    //            if (status == string.Empty)
    //            {
    //                //Leave grade may have been added as isactive=0 & then changed to 1. add table entries for assign_emp_leave
    //                HRManager.AddAssignEmpLeaveForNewLeaveGrade(objLeaveGrade);
    //            }
    //            return status;
    //        }
    //        catch (Exception ex)
    //        {
    //            IRCAExceptionHandler.HandleException(
    //                new IRCAException(ex, HRManagerDefs.LeaveMessages.LEAVE_UPDATE_FAILURE, ID.ToString()));
    //            return HRManagerDefs.LeaveMessages.LEAVE_UPDATE_FAILURE;
    //        }
    //    }


    //    /// <summary>
    //    /// DeActivate Designation by ID
    //    /// </summary>
    //    /// <param name="ID">field contain Designation ID</param>
    //    /// <param name="DeactivatedBy">field contain the user id who Deactivated Designation</param>
    //    /// <returns>empty string for success and error message for failure</returns>
    //    public static String DeActivateLeaveGrade(int ID, int DeactivatedBy)
    //    {
    //        //try
    //        //{
    //        //    string retVal = string.Empty;
    //        //    bool activeLeaveReqExistsForLeaveId = false;
    //        //    LeaveEmployeeType objLG = new LeaveEmployeeType(ID);
    //        //    //when leave grade is deactivated, get all entries in assign_emp_leave and deactivate them also.
    //        //    //but first check if any leave requests exists for that leaveid. if yes, we cannot deactivate
    //        //    if (objLG != null)
    //        //    {
    //        //        activeLeaveReqExistsForLeaveId = new Leave_RequestBusinessObject().LeaveRequestExistsForLeaveGrade(objLG.LeaveID, objLG.EmpTypeID);
    //        //        if (activeLeaveReqExistsForLeaveId)
    //        //        {
    //        //            retVal = HRManagerDefs.LeaveEmpTypeMessages.LEAVEEMPTYPE_DEACTIVATE_ERROR_REASON1;
    //        //        }
    //        //        else
    //        //        {
    //        //            // get all entries in assign_emp_leave and deactivate them
    //        //            AssignEmpLeave[] arrAEL = AssignEmpLeave.GetAssignEmpLeavesByLeaveAndGrade(objLG.LeaveID, objLG.EmpTypeID);
    //        //            if (arrAEL != null)
    //        //            {
    //        //                for (int i = 0; i < arrAEL.Length; i++)
    //        //                {
    //        //                    arrAEL[i].IsActive = false;
    //        //                    arrAEL[i].Save();
    //        //                }
    //        //            }

    //        //            //finally deactivate the leave grade entry
    //        //            retVal = objLG.DeActivate(DeactivatedBy);
    //        //        }
    //        //    }
    //        //    else
    //        //    {
    //        //        retVal = "Error in getting LeaveGrade object";
    //        //    }
    //        //    return retVal;
    //        //}
    //        try
    //        {
    //            string retVal = string.Empty;
    //            bool activeLeaveReqExistsForLeaveId = false;
    //            LeaveEmployeeType objLG = new LeaveEmployeeType(ID);
    //            //when leave grade is deactivated, get all entries in assign_emp_leave and deactivate them also.
    //            //but first check if any leave requests exists for that leaveid. if yes, we cannot deactivate
    //            if (objLG != null)
    //            {
    //                activeLeaveReqExistsForLeaveId = new Leave_RequestBusinessObject().LeaveRequestExistsForLeaveGrade(objLG.LeaveID, objLG.EmpTypeID);
    //                if (activeLeaveReqExistsForLeaveId)
    //                {
    //                    retVal = HRManagerDefs.LeaveEmpTypeMessages.LEAVEEMPTYPE_DEACTIVATE_ERROR_REASON1;
    //                }
    //                else
    //                {
    //                    // get all entries in assign_emp_leave and deactivate them
    //                    AssignEmpLeave[] arrAEL = AssignEmpLeave.GetAssignEmpLeavesByLeaveAndGrade(objLG.LeaveID, objLG.EmpTypeID);
    //                    if (arrAEL != null)
    //                    {
    //                        for (int i = 0; i < arrAEL.Length; i++)
    //                        {
    //                            arrAEL[i].IsActive = false;
    //                            arrAEL[i].Save();
    //                        }
    //                    }

    //                    //finally deactivate the leave grade entry
    //                    retVal = objLG.DeActivate(DeactivatedBy);
    //                }
    //            }
    //            else
    //            {
    //                retVal = "Error in getting Assign Leave object";
    //            }
    //            return retVal;
    //        }
    //        catch (Exception ex)
    //        {
    //            IRCAExceptionHandler.HandleException(
    //                new IRCAException(ex, HRManagerDefs.LeaveEmpTypeMessages.LEAVEEMPTYPE_DEACTIVATE_ERROR, ID.ToString())
    //                );
    //            return HRManagerDefs.LeaveEmpTypeMessages.LEAVEEMPTYPE_DEACTIVATE_ERROR;
    //        }
    //    }

    //    /// <summary>
    //    /// Return all Designation
    //    /// </summary>
    //    /// <returns>Array of the object of Designation class</returns>
    //    public static LeaveEmployeeType[] GetInActiveLeaveEmployeeTypes()
    //    {
    //        return LeaveEmployeeType.GetAllInActiveLeaveEmployeeTypes();
    //    }
    //    #endregion

    //    #region assign_emp_leave
    //    //public static AssignEmpLeave[] GetAssignEmpLeavesByEmpID(int EmployeeID)
    //    //{
    //    //    return AssignEmpLeave.GetAssignEmpLeavesByEmpID(EmployeeID);

    //    //}

    //    /// <summary>
    //    /// Leave Assining To Every Employee
    //    /// This function should excuted at least once in a Month
    //    /// So that each and every employee will get creadited the leave.
    //    /// </summary>
    //    public static bool AssignEmployeeLeaveForTheCurrentMonth()
    //    {
    //        Master_Employees MasterEmployees = new Master_Employees();
    //        Master_Leave_Employee_Type MasterLeaveEmployeeType = new Master_Leave_Employee_Type();

    //        return true;

    //    }
    //    public static DateTime GetLeaveEndOfYear()
    //    {
    //        //Hardcode December 31 for now.
    //        //Can be changed into an application preference later, because different customers may have diff end of year choices.

    //        DateTime endofyear = new DateTime(System.DateTime.Now.Year, 12, 31);
    //        return endofyear;
    //    }
    //    public static DateTime GetLeaveEndOfYear(int year)
    //    {
    //        //Hardcode December 31 for now.
    //        //Can be changed into an application preference later, because different customers may have diff end of year choices.

    //        DateTime endofyear = new DateTime(year, 12, 31);
    //        return endofyear;
    //    }


    //    ///// <summary>
    //    ///// Execute Leave CarryForward Updates for the year that just ended.
    //    ///// </summary>
    //    ///// <param name="ID">field contain year. Calling function should ensure to send the yrea that just ended</param>
    //    ///// <returns>empty string for success and error message for failure</returns>
    //    //public static string ExecuteLeaveCarryForwardUpdates(DateTime oldLeaveyear)
    //    //{
    //    //    //get all entries from assign-emp-leave
    //    //    //for each entry, chk leave remaining, compare with leave-grade & decide carry forward count
    //    //    //with this data, add a new row to assign-emp-leave, corresponding to each entry

    //    //    int empId=-1;
    //    //    int empGradeId = -1;
    //    //    int leaveTypeId = -1;
    //    //    int useRowLeaveGradeMaster=-1;

    //    //    Assign_Emp_Leave[] empLeavesForOldLeaveyear = AssignEmpLeave.GetAssignEmpLeavesByYear(oldLeaveyear);

    //    //    //get all data from mater_leave_grade
    //    //    LeaveGrade[] leaveGradeMasterData = LeaveGrade.GetActiveLeaveGrade();

    //    //    AssignEmpGrade[] empGradeMasterData = AssignEmpGrade.GetAllAssignEmpGrade();

    //    //    if (empLeavesForOldLeaveyear != null && leaveGradeMasterData != null && empGradeMasterData !=null)
    //    //    {             

    //    //        for (int empLeaveRow = 0; empLeaveRow < empLeavesForOldLeaveyear.Length; empLeaveRow++)
    //    //        {
    //    //            //reset vars
    //    //            empId = empLeavesForOldLeaveyear[empLeaveRow].EmpID;
    //    //            empGradeId = -1;
    //    //            leaveTypeId = empLeavesForOldLeaveyear[empLeaveRow].LeaveID;
    //    //            AssignEmpLeave newRowAssignEmpLeave = new AssignEmpLeave();

    //    //            //get grade
    //    //            for (int iterEmpGradeMaster = 0; iterEmpGradeMaster < empGradeMasterData.Length; iterEmpGradeMaster++)
    //    //            {
    //    //                if (empGradeMasterData[iterEmpGradeMaster].EmpID == empLeavesForOldLeaveyear[empLeaveRow].EmpID)
    //    //                {
    //    //                    //found row. get employee gradeId
    //    //                    empGradeId = empGradeMasterData[iterEmpGradeMaster].GradeID;
    //    //                    break;
    //    //                }
    //    //            }

    //    //            if (empGradeId != -1)
    //    //            {
    //    //                useRowLeaveGradeMaster=-1;
    //    //                //get row with this empGrade & leavetypeId
    //    //                for (int iterLeaveGradeMaster = 0; iterLeaveGradeMaster < leaveGradeMasterData.Length; iterLeaveGradeMaster++)
    //    //                {
    //    //                    if (leaveGradeMasterData[iterLeaveGradeMaster].GradeID == empGradeId && leaveGradeMasterData[iterLeaveGradeMaster].LeaveID == leaveTypeId)
    //    //                    {
    //    //                        //GET MASTER LEAVE COUNTS
    //    //                        useRowLeaveGradeMaster=iterLeaveGradeMaster;
    //    //                        break;
    //    //                    } 
    //    //                }

    //    //                 if (useRowLeaveGradeMaster!=-1)
    //    //                {
    //    //                     //start filling data 
    //    //                    newRowAssignEmpLeave.EmpID = empId;
    //    //                    newRowAssignEmpLeave.LeaveID = leaveTypeId;
    //    //                    newRowAssignEmpLeave.UsedLeaves = 0;
    //    //                    newRowAssignEmpLeave.BlockedLeaves = 0;
    //    //                    newRowAssignEmpLeave.EncashedLeaves = 0;
    //    //                    newRowAssignEmpLeave.LeavesCanBeEncashed = false; //UNUSED COL. CONSIDER REMOVING FROM DB
    //    //                    newRowAssignEmpLeave.EndOfYearDate = GetLeaveEndOfYear(oldLeaveyear.Year + 1);
    //    //                    //chk if carry forward is allowed
    //    //                    if (leaveGradeMasterData[useRowLeaveGradeMaster].CanCarryForward == true)
    //    //                    {
    //    //                        //CHK IF (BALANCELEAVE - ENCASHEDLEAVE) is more than carryforwardcount
    //    //                        if ((empLeavesForOldLeaveyear[empLeaveRow].BalanceLeave -
    //    //                             empLeavesForOldLeaveyear[empLeaveRow].EncashedLeaves)
    //    //                            >= leaveGradeMasterData[useRowLeaveGradeMaster].CarryForwardCount)
    //    //                        {
    //    //                            //add carry forward to balanceleaves
    //    //                            newRowAssignEmpLeave.BalanceLeave = leaveGradeMasterData[useRowLeaveGradeMaster].CarryForwardCount
    //    //                                                                + leaveGradeMasterData[useRowLeaveGradeMaster].LeavesPerYear;
    //    //                        }
    //    //                        else
    //    //                        {
    //    //                            newRowAssignEmpLeave.BalanceLeave = leaveGradeMasterData[useRowLeaveGradeMaster].LeavesPerYear;
    //    //                        }
    //    //                    }
    //    //                    else    //no carry forward for this type. just add new counts from master
    //    //                    {
    //    //                        newRowAssignEmpLeave.BalanceLeave = leaveGradeMasterData[useRowLeaveGradeMaster].LeavesPerYear;
    //    //                    }
    //    //                     //save new row to db
    //    //                    newRowAssignEmpLeave.Save();

    //    //                }	//if (useRowLeaveGradeMaster!=-1)


    //    //            }	//(empGradeId != 0)


    //    //        }	//for (int empLeaveRow 
    //    //        //if required later add code to shift all rows from last year to a history table or history log.
    //    //    }


    //    //    return String.Empty;
    //    //}
    //    #endregion

    //    #region Leave Encashment
    //    public static LeaveEncashment[] GetAllLeaveEncashRequests()
    //    {
    //        return LeaveEncashment.GetAllLeaveEncashRequests();
    //    }

    //    public static LeaveEncashment[] GetLeaveEncashRequestsByEmpId(int employeeId)
    //    {
    //        return LeaveEncashment.GetLeaveEncashRequestsByEmpId(employeeId);
    //    }

    //    public static string UpdateEncashmentRequest(int ID, int EmpID, int LeaveID, Int16 NoOfDays,
    //        int AppliedTo, string Status, int UpdateBy)
    //    {
    //        try
    //        {
    //            LeaveEncashment LeaveEncash = new LeaveEncashment(ID);
    //            LeaveEncash.EmpID = EmpID;
    //            LeaveEncash.LeaveID = LeaveID;
    //            LeaveEncash.NoOfDays = NoOfDays;
    //            LeaveEncash.AppliedDateTime = DateTime.Now;
    //            LeaveEncash.AppliedTo = AppliedTo;
    //            LeaveEncash.Status = Status;
    //            LeaveEncash.UpdatedBy = UpdateBy;

    //            String State = LeaveEncash.Save();

    //            return State;
    //        }
    //        catch (Exception ex)
    //        {
    //            IRCAExceptionHandler.HandleException(
    //                new IRCAException(ex, HRLeaveManagerDefs.Encash.ENCASH_UPDATE_FAILURE, ID.ToString())
    //                );
    //            return HRLeaveManagerDefs.Encash.ENCASH_UPDATE_FAILURE;
    //        }
    //    }

    //    public static String UpdateEncashmentApprove(int EncashReqID)
    //    {
    //        try
    //        {
    //            LeaveEncashment LeaveEncash = new LeaveEncashment(EncashReqID);
    //            string Status = LeaveAppCommands.ENCASH_REQ_STATUS_APPROVE;
    //            LeaveEncash.Status = Status;

    //            String State = LeaveEncash.Save();

    //            //Once encashment is approved, update counts
    //            //GetEmployeeLeaveEncashmentOverview all rows in Assign_Emp_Leave for that empid & leavetypeid
    //            bool encashCountUpdateSuccess = false;
    //            double NoOfEnashDaysInReq = LeaveEncash.NoOfDays;
    //            double LeavesYetToBeEncashed = 0;
    //            AssignEmpLeave[] arrAEL = new Assign_Emp_LeaveBusinessObject().GetAllAssignEmpLeavesByLeaveAndEmpIdOrderByDate(LeaveEncash.LeaveID, LeaveEncash.EmpID);
    //            if (arrAEL != null)
    //            {
    //                for (int iterArrAEL = 0; iterArrAEL < arrAEL.Length; iterArrAEL++)
    //                {
    //                    //for each row, update encashedLeaves col
    //                    //NOTE: table Assign_Emp_Leave has one row for each year (for tht empid & tht leaveid)
    //                    LeavesYetToBeEncashed = arrAEL[iterArrAEL].BalanceLeave - arrAEL[iterArrAEL].EncashedLeaves;
    //                    if (LeavesYetToBeEncashed > 0)
    //                    {
    //                        // is greater than leaves still available for encashment in that year(current row of AEl)
    //                        if (NoOfEnashDaysInReq > LeavesYetToBeEncashed)
    //                        {
    //                            arrAEL[iterArrAEL].EncashedLeaves = arrAEL[iterArrAEL].EncashedLeaves + LeavesYetToBeEncashed;
    //                            NoOfEnashDaysInReq = NoOfEnashDaysInReq - LeavesYetToBeEncashed;
    //                            //continue to next row in AEL
    //                        }
    //                        else if (NoOfEnashDaysInReq <= LeavesYetToBeEncashed)
    //                        {
    //                            arrAEL[iterArrAEL].EncashedLeaves = arrAEL[iterArrAEL].EncashedLeaves + NoOfEnashDaysInReq;
    //                            NoOfEnashDaysInReq = 0;
    //                        }
    //                        //leave counts have changed, save to db
    //                        arrAEL[iterArrAEL].Save();
    //                    }
    //                    if (NoOfEnashDaysInReq == 0)
    //                        break;
    //                }

    //                encashCountUpdateSuccess = true;

    //                if (NoOfEnashDaysInReq > 0)
    //                {
    //                    //should never ever happen. because encash req form accepts only count < what's available.
    //                    //add ALERT into logging file, once logging is added.
    //                    string xx = "error";
    //                }

    //            }

    //            if (!encashCountUpdateSuccess)
    //            {
    //                //count could  not be updated, revert approval.
    //                LeaveEncash.Status = LeaveAppCommands.ENCASH_REQ_STATUS_REQUEST;
    //                LeaveEncash.Save();
    //                return HRLeaveManagerDefs.Encash.ENCASH_COUNT_UPDATE_FAILURE;
    //            }

    //            return State;
    //        }
    //        catch (Exception ex)
    //        {
    //            IRCAExceptionHandler.HandleException(
    //                new IRCAException(ex, HRLeaveManagerDefs.Encash.ENCASH_UPDATE_FAILURE, EncashReqID.ToString())
    //                );
    //            return HRLeaveManagerDefs.Encash.ENCASH_UPDATE_FAILURE;
    //        }
    //    }

    //    public static String UpdateEncashmentReject(int EncashReqID)
    //    {
    //        try
    //        {
    //            LeaveEncashment LeaveEncash = new LeaveEncashment(EncashReqID);
    //            string Status = LeaveAppCommands.ENCASH_REQ_STATUS_REJECT;
    //            LeaveEncash.Status = Status;

    //            String State = LeaveEncash.Save();

    //            return State;
    //        }
    //        catch (Exception ex)
    //        {
    //            IRCAExceptionHandler.HandleException(
    //                new IRCAException(ex, HRLeaveManagerDefs.Encash.ENCASH_UPDATE_FAILURE, EncashReqID.ToString())
    //                );
    //            return HRLeaveManagerDefs.Encash.ENCASH_UPDATE_FAILURE;
    //        }
    //    }

    //    public static EmployeeLeaveEncashmentOverview[] GetEmployeeLeaveEncashmentOverview(int EmployeeId, int LeaveTypeId)
    //    {
    //        return EmployeeLeaveEncashmentOverview.GetEmployeeLeaveEncashmentOverview(EmployeeId, LeaveTypeId);
    //    }

    //    public static AssignEmpLeave[] GetAssignEmpLeavesByEmpIDForEncashCombo(int EmployeeID)
    //    {
    //        //get gradeId of employee            
    //        AssignEmpGrade EmpGrade = new Master_EmployeesBusinessObject().GetGradeEmployees(EmployeeID);

    //        if (EmpGrade != null)
    //            return new Assign_Emp_LeaveBusinessObject().GetAssignEmpLeavesByEmpIDForEncashCombo(EmployeeID, EmpGrade.GradeID);
    //        else
    //            return null;
    //    }
    //    #endregion
    }
}
