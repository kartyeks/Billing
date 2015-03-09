using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS91.Services;

namespace HRManager
{
    public class HRLeaveManagerDefs
    {
        public class Leave
        {
            #region Leave
            public static readonly String LEAVE_UPDATE_SUCCESS = "Leave details updated successfully";
            public static readonly String LEAVE_UPDATE_FAILURE = "Error on updating the Leave info";
            public static readonly String LEAVE_REFERED = "The selected Leave is referred";
            public static readonly String ERROR_LEAVE_CREDIT = "Error on saving leave details";

            #endregion
        }

        public class Holidays
        {
            #region Holidays
            public static readonly String HOLIDAY_UPDATE_SUCCESS = "Holiday details updated successfully";
            public static readonly String HOLIDAY_UPDATE_FAILURE = "Error on updating Holiday details";
            public static readonly String DEACTIVATE_SUCCESS = "Holiday deactivated successfully";
            public static readonly String ACTIVATE_SUCCESS = "Holiday activated successfully";
            public static readonly String EMPTY_HOLIDAYNAME = "Holiday name cannot be left blank";
            public static readonly String HOLIDAY_ADDED_SUCCESS = "Holiday details added successfully";
            public static readonly String HOLIDAY_APPROVE_SUCCESS = "Holiday approved";
            public static readonly String HOLIDAY_APPROVE_FAILURE = "Error on Holiday approval";
            public static readonly String DISALLOW_APPROVED_HOLIDAY_UPDATE = "Already approved Holiday cannot be updated";
            public static readonly String HOLIDAY_REJECT_SUCCESS = "Holiday rejected";
            public static readonly String HOLIDAY_REJECT_FAILURE = "Error on Holiday rejection";
            public static readonly String HOLIDAY_REQ_APPROVAL_SUCCESS = "Holiday approval requested";
            public static readonly String HOLIDAY_REQ_APPROVAL_FAILURE = "Holiday approval request FAILED";
            public static readonly String HOLIDAY_ALREADY_EXISTS = "The Holiday already exists";
            #endregion
        }

        public class Weekends
        {
            #region Weekends
            public static readonly String WEEKENDS_UPDATE_SUCCESS = "Weekend details updated successfully";
            public static readonly String WEEKENDS_UPDATE_FAILURE = "Error on updating Weekend details";
            public static readonly String WEEKENDS_ADDED_SUCCESS = "Weekend details added successfully";
            public static readonly String WEEKENDS_APPROVE_SUCCESS = "Weekend approved";
            public static readonly String WEEKENDS_APPROVE_FAILURE = "Error on Weekend approval";
            public static readonly String WEEKENDS_STATUS_UPDATE_FAILURE = "Error on updating Weekend status";
            public static readonly String WEEKENDS_STATUS_UPDATE_SUCCESS = "Weekend status updated successfully";
            public static readonly String DISALLOW_APPROVED_WEEKENDS_UPDATE = "Already approved Weekend cannot be updated";
            public static readonly String WEEKENDS_REJECT_SUCCESS = "Weekend rejected";
            public static readonly String WEEKENDS_REJECT_FAILURE = "Error on Weekend rejection";
            public static readonly String WEEKENDS_REQ_APPROVAL_SUCCESS = "Weekend approval requested";
            public static readonly String WEEKENDS_REQ_APPROVAL_FAILURE = "Weekend approval request FAILED";
            public static readonly String WEEKEND_ALREADY_EXISTS = "The weekend defined already exists";
            #endregion
        }

        public class Encash
        {
            #region Encash
            public static readonly String ENCASH_UPDATE_SUCCESS = "Leave Encashment details updated successfully";
            public static readonly String ENCASH_UPDATE_FAILURE = "Error on updating the Leave Encashment info";
            public static readonly String ENCASH_COUNT_UPDATE_FAILURE = "Error on updating the Leave Encashment info";
            public static readonly String ENCASH_ADDED_SUCCESS = "Encashment details added successfully";
            public static readonly String ENCASH_FORM_DETAILS_FAILURE = "Error in getting Employee Leave Encashment info";
            public static readonly String ENCASH_REQ_FOR_LEAVETYPE_EXISTS = "An open Encashment request for this leavetype already exists. Please edit the existing request instead of adding a new request.";
            public static readonly String MAX_ENCASHMENT_REQ_COUNT_PER_YEAR_REACHED = "Encashment request exceeds the maximum number of leaves that can be encashed in a year by ";
            #endregion
        }

        public class LeaveEmployeeTypeMessages
        {
            #region LeaveEmployeeType
            //public static readonly String EMPTY_BONUS = "Bonus name cannot be empty";
            //public static readonly String BONUS_EXISTS = "The given Bonus already exists ";

            public static readonly String LEAVE_EMPTYPE_UPDATE_SUCCESS = "Leave Employee Type details updated successfully";
            public static readonly String LEAVE_EMPTYPE_ADDED_SUCCESS = "Leave Employee Type details added successfully";
            public static readonly String UPDATE_SETTING_LEAVE_EMPTYPE_FAILURE = "Error on updating the Leave Employee Type ";
            public static readonly String LEAVE_EMPTYPE_DEACTIVATE_SUCCESS = "Leave Employee Type deactivated successfully";
            public static readonly String LEAVE_EMPTYPE_ACTIVATE_SUCCESS = "Leave Employee Type activated successfully";
            public static readonly String LEAVEEMPTYPE_EXISTS = "The given Leave Employee Type already exists";
            #endregion
        }


    }
}
