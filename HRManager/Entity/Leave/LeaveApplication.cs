using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;
using IRCAKernel;
using HRManager.BusinessObjects;
using IS91.Services.DataBlock;
using HRManager.Entity.LeaveApp;

namespace HRManager.Entity.LeaveApp
{
    public class LeaveApplication
    {

        private String _EmployeeName;
        private int _EmployeeID;
        private DateTime _DateOfJoining;
        private String _Sex;
        private double _TotalLeave;
        private double _LeaveCount;
        private double _BlockedLeaves;
        private double _BalanceLeave;
        private bool _IsConfirmed;
        private DateTime _LastAppliedDate;


        private string _LeaveType;
        private int _EmploymentType;
        private double _ApprovedCount;
        private double _MinDaysToApply;
        private double _MaxDaysToApply;
        private int _EligibleAfter_InDays;
        private String _LeaveCreditedPeriod;
        private int _MaxApprovedLimit;
        private bool _CanCarryForward;
        private double _CarryForwardCount;
        private bool _IsDocumentRequired;
        private int _DocumentRequiredPeriod;
        private bool _PostSubmissionIsAllowed;
        private bool _IncludeWeekEnds;
        private bool _IsContactAddressRequired;
        private bool _CanBeEncashed;
        private int _MinDaysToEncash;
        private double _MandatoryLeaveDays;
        private bool _IsEligibleForFemale;
        private int _LeaveGap;
        private int _LeaveAllowedForEvery;
        private double _TotalRequestLeaves;


        private int _ID;
        private bool _IsHalfDay;
        private DateTime _FromDate;
        private DateTime _ToDate;
        private double _NoOfDays;
        private String _Reason;
        private String _CCMailID;
        private String _ContactAddress;
        private String _PhoneNumber;
        private int _AppliedTo;
        private DateTime _AppliedDate;
        private string _ManagerRemarks;
        private int _UpdateBy;
        private int _LeaveTypeID;
        private double _LeaveBalForLOP;
        private bool _IsNew;

        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        //private void Update(Settings_Leave_Employee_TypeDetailed DTO)
        //{
        //    _LeaveType = DTO.LeaveType;
        //    _EmployeeName = DTO.EmployeeName;
        //    _EmployeeID = DTO.EmployeeID;
        //    _EmploymentType = DTO.EmploymentType;
        //    _DateOfJoining = DTO.DateOfJoining;
        //    _Sex = DTO.Sex;
        //    _ApprovedCount = DTO.ApprovedCount;
        //    _TotalLeave = DTO.TotalLeave;
        //    _LeaveCount = DTO.LeaveCount;
        //    _MinDaysToApply = DTO.MinDaysToApply;
        //    _MaxDaysToApply = DTO.MaxDaysToApply;
        //    _EligibleAfter_InDays = DTO.EligibleAfter_InDays;
        //    _LeaveCreditedPeriod = DTO.LeaveCreditedPeriod;
        //    _MaxApprovedLimit = DTO.MaxApprovedLimit;
        //    _CanCarryForward = DTO.CanCarryForward;
        //    _CarryForwardCount = DTO.CarryForwardCount;
        //    _IsDocumentRequired = DTO.IsDocumentRequired;
        //    _DocumentRequiredPeriod = DTO.DocumentRequiredPeriod;
        //    _PostSubmissionIsAllowed = DTO.PostSubmissionIsAllowed;
        //    _IncludeWeekEnds = DTO.IncludeWeekEnds;
        //    _IsContactAddressRequired = DTO.IsContactAddressRequired;
        //    _CanBeEncashed = DTO.CanBeEncashed;
        //    _MinDaysToEncash = DTO.MinDaysToEncash;
        //    _MandatoryLeaveDays = DTO.MandatoryLeaveDays;
        //    _IsEligibleForFemale = DTO.IsEligibleForFemale;
        //    _BlockedLeaves = DTO.BlockedLeaves;
        //    _BalanceLeave = DTO.BalanceLeave;
        //    _IsConfirmed = DTO.IsConfirmed;
        //    _LeaveGap = DTO.LeaveGap;
        //    _LastAppliedDate = DTO.LastAppliedDate;
        //    _TotalRequestLeaves = DTO.TotalRequestLeaves;
        //}

        //public String UpdateManualLeave(int ID, int EmployeeID, int LeaveTypeID, DateTime FromDate, DateTime ToDate, bool IsHalfDay, String Reason,
        //            DateTime AppliedDate, int AppliedTo, int UpdateBy, double DayCount)
        //{
        //    string result = string.Empty;
        //    try
        //    {
        //        Leave_Request Req = new Leave_Request();
        //        Req.EmpID = EmployeeID;
        //        Req.LeaveID = LeaveTypeID;
        //        Req.FromDate = FromDate;
        //        Req.ToDate = ToDate;
        //        Req.IsHalfDay = IsHalfDay;
        //        Req.Reason = Reason;
        //        Req.AppliedDateTime = DateTime.Today;
        //        Req.DayCount = DayCount;
        //        string Status = LeaveAppCommands.LEAVE_REQ_STATUS_APPROVE;
        //        Req.Status = Status;
        //        Req.CreatedBy = _UpdateBy;
        //        Req.CreatedDate = DateTime.Now;
        //        Req.ID = new Leave_RequestBusinessObject().Create(Req);
        //    }
        //    catch (Exception ex)
        //    {
        //        result = "Error on applying manual leave ";
        //    }
        //    return result;

        //}

        //public String UpdateLeaveApplication(int ID, int EmployeeID, int LeaveTypeID,
        //    DateTime FromDate, DateTime ToDate, bool IsHalfDay, String Reason,
        //    DateTime AppliedDate, int AppliedTo, String CCMailID, string ManagerRemarks, Double DayCount,
        //    int UpdateBy, string ContactAddress, string PhoneNumber)
        //{
        //    Settings_Leave_Employee_TypeDetailed DTO = new Settings_Leave_Employee_TypeBusinessObject().GetEmployeeLeaveSettings(EmployeeID, LeaveTypeID);

        //    if (DTO != null)
        //    {
        //        Update(DTO);

        //        _ID = ID;
        //        _LeaveTypeID = LeaveTypeID;
        //        _NoOfDays = DayCount;
        //        _AppliedDate = AppliedDate;
        //        _AppliedTo = AppliedTo;
        //        _ManagerRemarks = ManagerRemarks;
        //        _IsHalfDay = IsHalfDay;
        //        _FromDate = FromDate;
        //        _ToDate = ToDate;
        //        _NoOfDays = DayCount;
        //        _Reason = Reason;
        //        _CCMailID = CCMailID;
        //        _ContactAddress = ContactAddress;
        //        _PhoneNumber = PhoneNumber;
        //        _UpdateBy = UpdateBy;

        //        String Res = Save();

        //        return Res;
        //    }
        //    else
        //    {
        //        throw new InvalidRequestException(EmployeeID, LeaveTypeID);
        //    }
        //}

        //private String Validate()
        //{

        //    String Result = String.Empty;

        //    double CountVal = CheckLeaveCount();

        //    bool val = new Assign_Emp_LeaveBusinessObject().IsBalExists(_EmployeeID, _LeaveTypeID);
        //    if (val)
        //    {
        //        _LeaveBalForLOP = CountVal;
        //        _IsNew = true;
        //    }
        //    else
        //    {
        //        _LeaveBalForLOP = _BalanceLeave;
        //    }

        //    if (_NoOfDays > CountVal && CountVal != 0)
        //    {
        //        Result = HRManagerDefs.LeaveMessages.LEAVE_MORETHAN_AVAIL;
        //    }

        //    //if (_TotalRequestLeaves > _BalanceLeave && _ID == 0)
        //    //{
        //    //    Result = HRManagerDefs.LeaveMessages.LEAVE_MORETHAN_AVAIL;
        //    //}

        //    if (_ID != 0)
        //    {
        //        double RequestCount = new Leave_RequestBusinessObject().GetLeave_Request(_ID).DayCount;

        //        if (_NoOfDays > (_BalanceLeave + RequestCount))
        //        {
        //            Result = HRManagerDefs.LeaveMessages.LEAVE_MORETHAN_AVAIL;
        //        }
        //    }

        //    //Check Leave for Define Period
        //    if ((DateTime.Now - _LastAppliedDate).Days < _LeaveAllowedForEvery)
        //    {
        //        Result = HRManagerDefs.LeaveMessages.CANNOT_TAKE_LEAVE;
        //    }

        //    //Total Leaves Per Year
        //    //else if (_NoOfDays > _BalanceLeave && _ID == 0)
        //    //{
        //    //    Result = HRManagerDefs.LeaveMessages.LEAVE_MORETHAN_AVAIL;
        //    //}
        //    //if (_TotalLeave >= _LeaveCount)
        //    //{
        //    //    Result = HRManagerDefs.LeaveMessages.LEAVE_MORETHAN_AVAIL;
        //    //}

        //    //Check With DateOfJoining
        //    if (_EligibleAfter_InDays != -1)
        //    {
        //        if (_EligibleAfter_InDays > DateTime.Now.Subtract(_DateOfJoining).Days)
        //        {
        //            Result = HRManagerDefs.LeaveMessages.NOT_ELIGBLE;
        //        }
        //    }

        //    //Check for Confirmation
        //    //else if (!_IsConfirmed)
        //    //{
        //    //    Result = HRManagerDefs.LeaveMessages.NOT_CONFIRMED;
        //    //}
        //    //Maximum and Minimum No. of Leaves per instance
        //    if (_NoOfDays < _MinDaysToApply || _NoOfDays > _MaxDaysToApply)
        //    {
        //        Result = String.Format(HRManagerDefs.LeaveMessages.INVALID_LEAVE_REQUEST,
        //                                        _LeaveType
        //                                        , _MaxDaysToApply
        //                                        , _MinDaysToApply);
        //    }

        //    if (!_PostSubmissionIsAllowed && (_FromDate < DateTime.Now || _ToDate < DateTime.Now))
        //    {
        //        Result = String.Format(HRManagerDefs.LeaveMessages.INVALID_POST_SUBMITION, _LeaveType);
        //    }

        //    //Check for Address and PhoneNumber

        //    if (_IsContactAddressRequired)
        //    {
        //        if (_ContactAddress == "")
        //            Result = HRManagerDefs.LeaveMessages.PROVIDE_ADDRESS;
        //        if (_PhoneNumber == "")
        //            Result = HRManagerDefs.LeaveMessages.PROVIDE_PHONE;
        //    }
        //    //Check for Document Uplaod
        //    if (_IsDocumentRequired)
        //    {
        //        if (_NoOfDays >= _MaxApprovedLimit)
        //        {
        //            Result = HRManagerDefs.LeaveMessages.UPLOAD_DOCUMENT;
        //        }
        //    }

        //    // Check for Maternity Leave
        //    if (_IsEligibleForFemale && _Sex == "M")
        //    {
        //        Result = HRManagerDefs.LeaveMessages.ONLY_FEMALE;
        //    }
        //    //Check for Year gap and No of Times Leave taken  
        //    if (_IsEligibleForFemale)
        //    {
        //        if (_NoOfDays > _MaxDaysToApply)
        //        {
        //            Result = HRManagerDefs.LeaveMessages.MATERNITY_LEAVE_COUNT;
        //        }
        //    }
        //    //Check for Including Sunday as a Leave
        //    //else if (!_IncludeWeekEnds)
        //    //{
        //    //    List<DateTime> Date = GetAllDates();

        //    //    foreach (DateTime D in Date)
        //    //    {
        //    //        if (D.DayOfWeek == DayOfWeek.Sunday)
        //    //        {
        //    //            _NoOfDays = _NoOfDays - 1;
        //    //        }
        //    //    }
        //    //}

        //    return Result;
        //}

        //private List<DateTime> GetAllDates()
        //{
        //    List<DateTime> allDates = new List<DateTime>();

        //    int start = _FromDate.Day;
        //    int end = _ToDate.Day;

        //    for (int i = start; i <= end; i++)
        //    {
        //        allDates.Add(new DateTime(_FromDate.Year,_FromDate.Month,i));
        //    }

        //    return allDates;
        //}

        //private bool GetMaternityCount()
        //{

        //    int Count = new Leave_RequestBusinessObject().GetMaternityCount(_EmployeeID);

        //    if (Count > 2)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        //private bool GetMaternityLeaveCountinYears()
        //{
        //    int count = new Leave_RequestBusinessObject().GetMaternityCountYears(_EmployeeID);

        //    if (count > _LeaveGap)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        //private bool LeaveAllowedCount()
        //{
        //    int Cnt = new Leave_RequestBusinessObject().GetLeaveCount(_EmployeeID);

        //    if (Cnt > _LeaveAllowedForEvery)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //private double CheckLeaveCount()
        //{
        //    double ValidDays = 0;

        //    EmployeeLeave Emp = new EmployeeLeave(_EmployeeID, _LeaveTypeID, null);

        //    Settings_Leave_Employee_Type Settings1 = new Settings_Leave_Employee_TypeBusinessObject().GetEmpLeaveSettings(_EmployeeID, _LeaveTypeID);

        //    int CurrentYear = DateTime.Now.Year;
        //    int CurrentMonth = DateTime.Now.Month;

        //    if (Settings1.LeaveCreditedPeriod == SettingLeaveEmployeeType.LeaveCreditPeriods.Year)
        //    {
        //        if (CurrentYear != Emp.LastLeaveCreditDate.Year)
        //        {
        //            if (DateTime.Now.Year == _DateOfJoining.Year)
        //            {
        //                if (!Settings1.CreditOnCompletePeriod)
        //                {
        //                    int RemainingMonths = 12 - CurrentMonth + 1;

        //                    ValidDays = Math.Ceiling((Settings1.LeaveCount / 12) * RemainingMonths);
        //                }
        //            }
        //            else
        //            {
        //                if (Settings1.CreditOnCompletePeriod)
        //                {
        //                    int WorkingMonths = (_DateOfJoining >= new DateTime(CurrentYear, 01, 01)
        //                                                            ? 0
        //                                                            : (_DateOfJoining < new DateTime(CurrentYear - 1, 01, 01)
        //                                                                    ? 12 - _DateOfJoining.Month
        //                                                                    : 12
        //                                                              )
        //                                        );

        //                    ValidDays = Math.Ceiling((Settings1.LeaveCount / 12) * WorkingMonths);
        //                }
        //                else
        //                {
        //                    if (_BalanceLeave > Settings1.CarryForwardCount)
        //                    {
        //                        ValidDays = Settings1.CarryForwardCount;
        //                    }

        //                    ValidDays += Settings1.LeaveCount;
        //                }
        //            }

        //        }
        //    }
        //    else
        //    {
        //        if (Emp.LastLeaveCreditDate.Year == 1900 || CurrentMonth > Emp.LastLeaveCreditDate.Month)
        //        {
        //            if (DateTime.Now.Year == _DateOfJoining.Year)
        //            {
        //                if (Settings1.CreditOnCompletePeriod)
        //                {
        //                    int WorkingMonths = CurrentMonth - _DateOfJoining.Month;

        //                    ValidDays = (Settings1.LeaveCount / 12) * WorkingMonths;
        //                }
        //                else
        //                {
        //                    int RemainingMonths = 12 - CurrentMonth;

        //                    ValidDays = (Settings1.LeaveCount / 12) * RemainingMonths;
        //                }
        //            }
        //            else
        //            {
        //                if (ValidDays > Settings1.CarryForwardCount)
        //                {
        //                    ValidDays = Settings1.CarryForwardCount;
        //                }

        //                ValidDays += Settings1.LeaveCount;
        //            }
        //        }
        //    }

        //    return ValidDays;
        //}
        //public String Save()
        //{
        //    String Result = Validate();

        //    if (Result == "")
        //    {
        //        LeaveRequest Req = new LeaveRequest(_ID);

        //        Req.EmpID = _EmployeeID;
        //        Req.LeaveID = _LeaveTypeID;
        //        Req.FromDate = _FromDate;
        //        Req.ToDate = _ToDate;
        //        Req.IsHalfDay = _IsHalfDay;
        //        Req.Reason = _Reason;
        //        Req.AppliedDate = _AppliedDate;
        //        Req.CCMailID = _CCMailID;
        //        Req.ManagerRemarks = _ManagerRemarks;
        //        string Status = LeaveAppCommands.LEAVE_REQ_STATUS_REQUEST;
        //        Req.Status = Status;
        //        Req.ReprotingMgrStatus = Status;
        //        Req.FunctionalMgrStatus = Status;
        //        Req.DayCount = _NoOfDays;
        //        Req.RepliedDateTime = Convert.ToDateTime("1/2/1753");
        //        Req.UpdatedBy = _UpdateBy;
        //        Req.ContactAddress = _ContactAddress;
        //        Req.PhoneNumber = _PhoneNumber;

        //        if (_ID == 0)
        //        {
        //            //AssignEmpReportingTo empReop = new AssignEmpReportingTo(0, _EmployeeID);
        //            int repMgrId = new Master_EmployeesBusinessObject().GetAdminReportingToIDEmployeeForResignation(_EmployeeID);
        //            int fnMgrId = new Master_EmployeesBusinessObject().GetReportingToIDEmployeeForResignation(_EmployeeID);

        //            if (repMgrId > 0)
        //            {
        //                //get LeaveAppliedTo from this AssignEmpReportingTo object
        //                Req.AppliedTo = repMgrId;
        //                Req.ReprotingMgr = repMgrId;
        //                Req.FunctionalMgr = fnMgrId;
        //            }
        //            else
        //            {
        //                return "Cannot get Leave Applied_To Manager details. Please verify the setup for Employee reporting to Manager";
        //            }
        //        }

        //        if (_LeaveBalForLOP == 0)
        //        {
        //            Result = Req.Save(LeaveAppCommands.LEAVE_REQ_STATUS_FORLOP);
        //            _ID = Req.ID;
        //        }
        //        else
        //        {
        //            Result = Req.Save(LeaveAppCommands.LEAVE_REQ_STATUS_REQUEST);
        //            _ID = Req.ID;
        //        }


        //    }

        //    if (Result != "")
        //    {
        //        return Result;
        //    }
        //    return Result;

        //}
    }

    public class InvalidRequestException : IRCAException
    {
        public InvalidRequestException(int EmployeeID, int LeaveType)
            : base("Error occured on processing leave requeset", "EmployeeID : " + EmployeeID + ",LeaveType : " + LeaveType)
        {

        }
    }

}
