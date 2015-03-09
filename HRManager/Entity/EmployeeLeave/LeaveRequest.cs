using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRCA.Communication;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using HRManager.DTOEXT;
using HRManager.Entity.LeaveApp;
namespace HRManager.Entity.EmployeeLeave
{
    public class LeaveRequest : JGridDataObject
    {
        private int _ID;
        private int _EmpID;
        private int _LeaveID;
        private int _ManagerID;
        private int _AppliedTo;
        private double _DaysCount;
        private DateTime _FromDate; 
        private DateTime _ToDate;
        private DateTime _AppliedDateTime;
        private String _Reason;
        private String _ManagerStatus;
        private String _Status;
        private bool _IsActive;
        private int _UpdateBy;
        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;
        private bool _IsNew;
        private String _LeaveType;
        private DateTime _HolidayDate;
        private String _Title;
        private int _TeamID;
        private String _EmployeeName;
        private String _ManagerName;
        private String _ManagerComments;
        private bool _FromDateHalfDay;
        private bool _ToDateHalfDay;

        public int ID { get { return _ID; } set { _ID = value; } }
        public int EmpID { get { return _EmpID; } set { _EmpID = value; } }
        public int LeaveID { get { return _LeaveID; } set { _LeaveID = value; } }
        public int ManagerID { get { return _ManagerID; } set { _ManagerID = value; } }
        public int AppliedTo { get { return _AppliedTo; } set { _AppliedTo = value; } }
        public double DaysCount { get { return _DaysCount; } set { _DaysCount = value; } }
        public DateTime FromDate { get { return _FromDate; } set { _FromDate = value; } }
        public DateTime ToDate { get { return _ToDate; } set { _ToDate = value; } }
        public DateTime AppliedDateTime { get { return _AppliedDateTime; } set { _AppliedDateTime = value; } }
        public String Reason { get { return _Reason; } set { _Reason = value; } }
        public String Status { get { return _Status; } set { _Status = value; } }
        public String ManagerStatus { get { return _ManagerStatus; } set { _ManagerStatus = value; } }
        public int TeamID { get { return _TeamID; } set { _TeamID = value; } }
        public String EmployeeName { get { return _EmployeeName; } set { _EmployeeName = value; } }
        public String ManagerName { get { return _ManagerName; } set { _ManagerName = value; } }
        public String ManagerComments { get { return _ManagerComments; } set { _ManagerComments = value; } }
        public bool FromDateHalfDay { get { return _FromDateHalfDay; } set { _FromDateHalfDay = value; } }
        public bool ToDateHalfDay { get { return _ToDateHalfDay; } set { _ToDateHalfDay = value; } }


        public String LeaveType { get { return _LeaveType; } set { _LeaveType = value; } }
        public DateTime HolidayDate { get { return _HolidayDate; } set { _HolidayDate = value; } }
        public String Title { get { return _Title; } set { _Title = value; } }
        public bool IsActive { get { return _IsActive; } set { _IsActive = value; } }
        public int UpdatedBy { get { return _UpdateBy; } set { _UpdateBy = value; } }

        private void Update(Leave_Request DTO)
        {
            if (DTO != null)
            {
                _ID = DTO.ID;
                _EmpID = DTO.EmpID;
                _LeaveID = DTO.LeaveID;
                _ManagerID = DTO.ManagerID;
                _DaysCount = DTO.DaysCount;
                _FromDate = DTO.FromDate;
                _ToDate = DTO.ToDate;
                _AppliedDateTime = DTO.AppliedDateTime;
                _Reason = DTO.Reason;
                _Status = DTO.Status;
                _ManagerComments = DTO.ManagerComments;
                _CreatedBy = DTO.CreatedBy;
                _ModifiedBy = DTO.ModifiedBy;
                _CreatedDate = DTO.CreatedDate;
                _ModifiedDate = DTO.ModifiedDate;
                _FromDateHalfDay = DTO.FromDateHalfDay;
                _ToDateHalfDay = DTO.ToDateHalfDay;
                _IsNew = false;
                if (DTO is Leave_RequestEXT)
                {
                    _Title = ((Leave_RequestEXT)DTO).Title;
                    _EmployeeName = ((Leave_RequestEXT)DTO).EmployeeName;
                    _ManagerName = ((Leave_RequestEXT)DTO).ManagerName;
                }

            }
            else
            {
                _IsNew = true;
            }
        }

        public LeaveRequest(int ID)
        {
            Update(new Leave_RequestBusinessObject().GetLeave_Request(ID));
        }

        public LeaveRequest(Leave_RequestEXT DTO)
        {
            Update(DTO);
        }


        //public LeaveRequest(int ID)
        //{
        //    Leave_Request DTO = new Leave_RequestBusinessObject().GetLeave_Request(ID);

        //    if (DTO == null && ID > 0)
        //    {
        //        throw new IRCAException("Invalid Leave", ID.ToString());
        //    }

        //    Update(DTO);
        //}


        public LeaveRequest()
        {
            _ID = 0;
            _IsNew = true;
        }
        private Leave_Request GetDTO()
        {
            Leave_Request DTO = new Leave_Request();
            DTO.ID = _ID;
            DTO.EmpID = _EmpID;
            DTO.LeaveID = _LeaveID;
            DTO.ManagerID = _ManagerID;
            DTO.DaysCount = _DaysCount;
            DTO.FromDate = _FromDate;
            DTO.ToDate = _ToDate;
            DTO.AppliedDateTime = DateTime.Now;
            DTO.Reason = _Reason;
            DTO.Status = _Status;
            DTO.ManagerComments = _ManagerComments;
            DTO.CreatedBy = _CreatedBy;
            DTO.CreatedDate = _CreatedDate;
            DTO.ModifiedBy = _ModifiedBy;
            DTO.ModifiedDate = DateTime.Now;
            DTO.FromDateHalfDay = _FromDateHalfDay;
            DTO.ToDateHalfDay = _ToDateHalfDay;

            if (_ID == 0)
            {
                DTO.CreatedBy = _UpdateBy;
                DTO.CreatedDate = DateTime.Now;
            }
            else
            {
                DTO.CreatedBy = _CreatedBy;
                Leave_Request Value = new Leave_RequestBusinessObject().GetLeave_Request(_ID);
                DTO.CreatedDate = Value.CreatedDate;
            }
            DTO.ModifiedBy = _UpdateBy;
            DTO.ModifiedDate = DateTime.Now;

            return DTO;
        }

        public String SaveLeave()
        {
            try
            {
                Leave_RequestBusinessObject BO = new Leave_RequestBusinessObject();
                Leave_Request DTO = GetDTO();

                if (_ID != 0)
                {
                    BO.Update(DTO);
                }
                else
                {
                    _ID = BO.Create(DTO);
                }

                return String.Empty;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(ex);
                return ex.Message;
            }
        }

        public String Save()
        {
            String Status = "";

            if (Status != String.Empty)
            {
                return Status;
            }

            return SaveLeave();
        }

        public LeaveRequest[] GetLeaveRequest(int EmployeeID)
        {
            return LeGrid(new Leave_RequestBusinessObject().GetLeaveRequest(EmployeeID));
        }
        private LeaveRequest[] LeGrid(Leave_RequestEXT[] arr)
        {
            LeaveRequest[] LeavesCal = new LeaveRequest[arr.Length];

            for (int h = 0; h < arr.Length; h++)
            {
                LeaveRequest ur = new LeaveRequest();
                ur.Update(arr[h]);
                LeavesCal[h] = ur;
            }
            return LeavesCal;
        }
        public LeaveRequest[] GetLeaveRequestApp(int EmployeeID)
        {
            return LeGridAPP(new Leave_RequestBusinessObject().GetLeaveRequestApp(EmployeeID));
        }
        private LeaveRequest[] LeGridAPP(Leave_RequestEXT[] arr)
        {
            LeaveRequest[] LeavesCal = new LeaveRequest[arr.Length];

            for (int h = 0; h < arr.Length; h++)
            {
                LeaveRequest ur = new LeaveRequest();
                ur.Update(arr[h]);
                LeavesCal[h] = ur;
            }
            return LeavesCal;
        }

        public static LeaveRequest[] GetLeaveTypeCombo()
        {
            Master_Leave[] LeaveDT = new Master_LeaveBusinessObject().GetAllActiveLeave();
            LeaveRequest[] Leave = new LeaveRequest[LeaveDT.Length];

            for (int i = 0; i < Leave.Length; i++)
            {
                Leave[i] = new LeaveRequest();
                Leave[i].ID = LeaveDT[i].ID;
                Leave[i].LeaveType = LeaveDT[i].LeaveType;
            }
            return Leave;
        }
        public LeaveRequestCalenderEXT[] GetAllActiveLeaveCalender(int EmployeeID)
        {
            LeaveRequestCalenderEXT[] Leave = new Leave_RequestBusinessObject().GetAllActiveLeaveCalender(EmployeeID);
            return Leave;
        }
        public static LeaveRequest[] GetHolidayDate()
        {
            Master_Holidays[] LeaveDT = new Master_HolidaysBusinessObject().GetAllActiveLeave();
            LeaveRequest[] Leave = new LeaveRequest[LeaveDT.Length];

            for (int i = 0; i < Leave.Length; i++)
            {
                Leave[i] = new LeaveRequest();
                Leave[i].ID = LeaveDT[i].ID;
                Leave[i].HolidayDate = LeaveDT[i].HolidayDate;
            }
            return Leave;
        }

        public String UpdateLeaveApplication(int ID, int EmployeeID, int LeaveID, DateTime FromDate, DateTime ToDate, String Reason, DateTime AppliedDateTime, String Status, double DaysCount, int UpdateBy, bool FromDateHalfDay, bool ToDateHalfDay)
        {
            String Res = "";
            Leave_RequestEXT DTO = new Leave_RequestEXT();
            _ID = ID;
            _LeaveID = LeaveID;
            _EmpID = EmployeeID;
            _AppliedTo = AppliedTo;
            _FromDate = FromDate;
            _ToDate = ToDate;
            _DaysCount = DaysCount;
            _Reason = Reason;
            _Status = Status;
            _FromDateHalfDay = FromDateHalfDay;
            _ToDateHalfDay = ToDateHalfDay;
            Res = Save();
            LeaveRequest LR = new Leave_RequestBusinessObject().GetTeamManagerID(EmployeeID);
            _ManagerID = LR.ManagerID;
            Res = Save();

            LeaveStatusHistry LSH = new LeaveStatusHistry(ID);
            LSH.ID = ID;
            LSH.LeaveRequestID = _ID;
            LSH.ProcessedBy = EmployeeID;
            LSH.Status = Status;
            LSH.Comments = Reason;
            LSH.Save();
            LeaveRequestNotification Notification = new LeaveRequestNotification();
            Notification.LeaveReqNotification(EmployeeID, FromDate, ToDate, LR.ManagerID, Reason, DaysCount, LR.TeamID);
            return Res;

        }
        public String DeleteEmployeeLeave(int ID)
        {
            String Result = String.Empty;

            try
            {
                if (Result == String.Empty)
                {
                    new Leave_RequestBusinessObject().DeleteLeaveRequest(ID);
                }
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(ex);
                Result = String.Format(HRManagerDefs.LeaveMessages.DELETE_FAILURE);
            }

            return Result;
        }
        public String ResetDateLeaveRequest(int ID)
        {
            String Result = String.Empty;

            try
            {
                if (Result == String.Empty)
                {
                    new Leave_RequestBusinessObject().ResetDateLeaveRequest(ID);
                }
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(ex);
                Result = String.Format(HRManagerDefs.LeaveMessages.DELETE_FAILURE);
            }

            return Result;
        }
        #region JGridDataObject Members

        public object GetGridData()
        {
            LeaveRequestDetails DT = new LeaveRequestDetails();
            DT.ID = _ID;
            DT.EmpID = _EmpID;
            DT.LeaveID = _LeaveID;
            DT.ManagerID = _ManagerID;
            DT.LeaveCount = _DaysCount;
            if (_FromDate.ToString("dd/MM/yyyy") == "01/01/1900")
            {
                DT.FromDate = "";
            }
            else 
            {
                DT.FromDate = _FromDate.ToString("dd/MM/yyyy");
            }
            if (_ToDate.ToString("dd/MM/yyyy")== "01/01/1900")
            {
                DT.ToDate = "";
            }
            else
            {
                DT.ToDate = _ToDate.ToString("dd/MM/yyyy");
            }
            
            DT.AppliedDateTime = _AppliedDateTime.ToString("dd/MM/yyyy"); ;
            DT.Reson = _Reason;
            if (_Status == "REQ")
            {
                DT.Status = "Requested";
                //DT.Title = "Leave Request";
            }
            else if (_Status == "APP")
            {
                DT.Status = "Approved";
                //DT.Title = "Leave Approved";
            }
            else if (_Status == "REJ")
            {
                DT.Status = "Rejected";
               // DT.Title = "Leave Rejected";
            }
            DT.IsActive = _IsActive;
            //DT.LeaveType = new Leave(_LeaveID).LeaveType;
            if (_LeaveID == 1)
            {
                DT.LeaveType = "Annual leave";
            }
            else if (_LeaveID == 2)
            {
                DT.LeaveType = "Work from home";
            }           
            DT.Title = "Leave Request";
            DT.RequestedTo = _ManagerName;
            DT.RequestedBy = _EmployeeName;
            DT.ManagerComments = _ManagerComments;
            DT.FromDateHalfDay = _FromDateHalfDay;
            DT.ToDateHalfDay = _ToDateHalfDay;
            return DT;
        }

        #endregion
    }
    public class LeaveRequestDetails
    {
        public int ID;
        public int EmpID;
        public int LeaveID;
        public int ManagerID;
        public String RequestedTo;
        public String RequestedBy;
        public String LeaveType;
        public String FromDate;
        public String ToDate;
        public Double LeaveCount;
        public String AppliedDateTime;
        public String Reson;
        public String Status;
        public bool IsActive;
        public String Title;
        public String ManagerComments;
        public bool FromDateHalfDay;
        public bool ToDateHalfDay;
    }
    public class LeaveCalenderDisplay
    {
        public int ID;
        public int EmpID;
        public string Title;
        public DateTime FromDate;
        public DateTime ToDate;
    }

}
