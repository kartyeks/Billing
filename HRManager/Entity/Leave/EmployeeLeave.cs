using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IRCA.Communication;
using IS91.Services.DataBlock;

namespace HRManager.Entity.LeaveApp
{


    //public class EmployeeLeave : JGridDataObject
    //{
        //private int _ID;
        //private int _EmpID;
        //private int _EmployeeTypeID;
        //private DateTime _DataOfJoin;
        //private String _EmployeeName;
        //private int _LeaveID;
        //private String _LeaveType;
        //private double _BalanceLeave;
        //private double _UsedLeaves;
        //private double _BlockedLeaves;
        //private double _EncashedLeaves;
        //private double _LeavesCanBeEncashed;
        //private DateTime _EndOfYearDate;
        //private bool _IsActive;
        //private int _CreatedBy;
        //private DateTime _CreatedDate;
        //private int _ModifiedBy;
        //private DateTime _ModifiedDate;
        //private DateTime _LastLeaveCreditDate;
        //private Session _SessionVariable;



        //public int ID { get { return _ID; } set { _ID = value; } }
        //public int EmpID { get { return _EmpID; } set { _EmpID = value; } }
        //public int LeaveID { get { return _LeaveID; } set { _LeaveID = value; } }
        //public double BalanceLeave { get { return _BalanceLeave; } set { _BalanceLeave = value; } }
        //public double UsedLeaves { get { return _UsedLeaves; } set { _UsedLeaves = value; } }
        //public double BlockedLeaves { get { return _BlockedLeaves; } set { _BlockedLeaves = value; } }
        //public double EncashedLeaves { get { return _EncashedLeaves; } set { _EncashedLeaves = value; } }
        //public double LeavesCanBeEncashed { get { return _LeavesCanBeEncashed; } set { _LeavesCanBeEncashed = value; } }
        //public DateTime EndOfYearDate { get { return _EndOfYearDate; } set { _EndOfYearDate = value; } }
        //public bool IsActive { get { return _IsActive; } set { _IsActive = value; } }
        //public int CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }
        //public DateTime CreatedDate { get { return _CreatedDate; } set { _CreatedDate = value; } }
        //public int ModifiedBy { get { return _ModifiedBy; } set { _ModifiedBy = value; } }
        //public DateTime ModifiedDate { get { return _ModifiedDate; } set { _ModifiedDate = value; } }
        //public DateTime LastLeaveCreditDate { get { return _LastLeaveCreditDate; } set { _LastLeaveCreditDate = value; } }

//        //private void Update(Assign_Emp_Leave DTO)
//        //{
//        //    _ID = DTO.ID;
//        //    _EmpID = DTO.EmpID;
//        //    _LeaveID = DTO.LeaveID;
//        //    _BalanceLeave = DTO.BalanceLeave;
//        //    _UsedLeaves = DTO.UsedLeaves;
//        //    _BlockedLeaves = DTO.BlockedLeaves;
//        //    _EncashedLeaves = DTO.EncashedLeaves;
//        //    _LeavesCanBeEncashed = DTO.LeavesCanBeEncashed;
//        //    _EndOfYearDate = DTO.EndOfYearDate;
//        //    _IsActive = DTO.IsActive;
//        //    _CreatedBy = DTO.CreatedBy;
//        //    _CreatedDate = DTO.CreatedDate;
//        //    _ModifiedBy = DTO.ModifiedBy;
//        //    _ModifiedDate = DTO.ModifiedDate;
//        //    _LastLeaveCreditDate = DTO.LastLeaveCreditDate;

//        //    //if (DTO is Assign_Emp_LeaveExtended)
//        //    //{
//        //    //    _EmployeeName = ((Assign_Emp_LeaveExtended)DTO).EmployeeName;
//        //    //    _LeaveType = ((Assign_Emp_LeaveExtended)DTO).LeaveType;
//        //    //    _EmployeeTypeID = ((Assign_Emp_LeaveExtended)DTO).EmployeTypeID;
//        //    //    _DataOfJoin = ((Assign_Emp_LeaveExtended)DTO).DateOfJoin;
//        //    //}
//        //}

//        //private Assign_Emp_Leave GetDTO()
//        //{
//        //    Assign_Emp_Leave DTO = new Assign_Emp_Leave();

//        //    DTO.ID = _ID;
//        //    DTO.EmpID = _EmpID;
//        //    DTO.LeaveID = _LeaveID;
//        //    DTO.BalanceLeave = _BalanceLeave;
//        //    DTO.UsedLeaves = _UsedLeaves;
//        //    DTO.BlockedLeaves = _BlockedLeaves;
//        //    DTO.EncashedLeaves = _EncashedLeaves;
//        //    DTO.LeavesCanBeEncashed = _LeavesCanBeEncashed;
//        //    DTO.EndOfYearDate = _EndOfYearDate;
//        //    DTO.IsActive = _IsActive;
//        //    DTO.CreatedBy = _CreatedBy;
//        //    DTO.CreatedDate = _CreatedDate;
//        //    DTO.ModifiedBy = _ModifiedBy;
//        //    DTO.ModifiedDate = _ModifiedDate;
//        //    DTO.LastLeaveCreditDate = _LastLeaveCreditDate;

//        //    return DTO;
//        //}

//        private String Save()
//        {
//            String Result = String.Empty;

//            bool IsNewSession = false;

//            try
//            {
//                if (_SessionVariable == null)
//                {
//                    _SessionVariable = Session.CreateNewSession();
//                    _SessionVariable.BeginTransaction();
//                    IsNewSession = true;
//                }

//                //Assign_Emp_LeaveBusinessObject BO = new Assign_Emp_LeaveBusinessObject(_SessionVariable);
//                //Assign_Emp_Leave DTO = GetDTO();

//                //DTO.ModifiedBy = 1;
//                //DTO.ModifiedDate = DateTime.Now;


//                if (_ID > 0)
//                {
//                    BO.Update(DTO);
//                }
//                else
//                {
//                    DTO.CreatedBy = 1;
//                    DTO.ModifiedDate = DateTime.Now;

//                    _ID = BO.Create(DTO);
//                }

//                if (IsNewSession)
//                {
//                    _SessionVariable.Commit();
//                }
//            }
//            catch (Exception ex)
//            {
//                IRCAExceptionHandler.HandleException(ex);

//                if (IsNewSession)
//                {
//                    _SessionVariable.Rollback();
//                }

//                Result = HRLeaveManagerDefs.Leave.ERROR_LEAVE_CREDIT;
//            }

//            return Result;
//        }

//        private void UpdateLeave()
//        {
//            Settings_Leave_Employee_Type Settings = new Settings_Leave_Employee_TypeBusinessObject().GetEmpLeaveSettings(_EmpID, _LeaveID);

//            int CurrentYear = DateTime.Now.Year;
//            int CurrentMonth = DateTime.Now.Month;

//            if (Settings.LeaveCreditedPeriod == SettingLeaveEmployeeType.LeaveCreditPeriods.Year)
//            {
//                if (CurrentYear != _LastLeaveCreditDate.Year)
//                {
//                    if (DateTime.Now.Year == _DataOfJoin.Year)
//                    {
//                        if (!Settings.CreditOnCompletePeriod)
//                        {
//                            int RemainingMonths = 12 - CurrentMonth + 1;

//                            _BalanceLeave = Math.Ceiling((Settings.LeaveCount / 12) * RemainingMonths);
//                        }
//                    }
//                    else
//                    {
//                        if (Settings.CreditOnCompletePeriod)
//                        {
//                            int WorkingMonths = (_DataOfJoin >= new DateTime(CurrentYear, 01, 01)
//                                                                    ? 0
//                                                                    : (_DataOfJoin < new DateTime(CurrentYear - 1, 01, 01)
//                                                                            ? 12 - _DataOfJoin.Month
//                                                                            : 12
//                                                                      )
//                                                );

//                            _BalanceLeave = Math.Ceiling((Settings.LeaveCount / 12) * WorkingMonths);
//                        }
//                        else
//                        {
//                            if (_BalanceLeave > Settings.CarryForwardCount)
//                            {
//                                _BalanceLeave = Settings.CarryForwardCount;
//                            }

//                            _BalanceLeave += Settings.LeaveCount;
//                        }
//                    }

//                    _LastLeaveCreditDate = DateTime.Now;

//                    Save();
//                }
//            }
//            else
//            {
//                if (_LastLeaveCreditDate.Year == 1900 || CurrentMonth > _LastLeaveCreditDate.Month)
//                {
//                    if (DateTime.Now.Year == _DataOfJoin.Year)
//                    {
//                        if (Settings.CreditOnCompletePeriod)
//                        {
//                            int WorkingMonths = CurrentMonth - _DataOfJoin.Month;

//                            _BalanceLeave = (Settings.LeaveCount / 12) * WorkingMonths;
//                        }
//                        else
//                        {
//                            int RemainingMonths = 12 - CurrentMonth;

//                            _BalanceLeave = (Settings.LeaveCount / 12) * RemainingMonths;
//                        }
//                    }
//                    else
//                    {
//                        if (_BalanceLeave > Settings.CarryForwardCount)
//                        {
//                            _BalanceLeave = Settings.CarryForwardCount;
//                        }

//                        _BalanceLeave += Settings.LeaveCount;
//                    }

//                    _LastLeaveCreditDate = DateTime.Now;
//                    Save();
//                }
//            }
//        }

//        private void GetLeaveCount()
//        {
//            Settings_Leave_Employee_Type Settings = new Settings_Leave_Employee_TypeBusinessObject().GetEmpLeaveSettings(_EmpID, _LeaveID);

//            int CurrentYear = DateTime.Now.Year;
//            int CurrentMonth = DateTime.Now.Month;

//            if (Settings.LeaveCreditedPeriod == SettingLeaveEmployeeType.LeaveCreditPeriods.Year)
//            {
//                if (CurrentYear != _LastLeaveCreditDate.Year)
//                {
//                    if (DateTime.Now.Year == _DataOfJoin.Year)
//                    {
//                        if (!Settings.CreditOnCompletePeriod)
//                        {
//                            int RemainingMonths = 12 - CurrentMonth + 1;

//                            _BalanceLeave = Math.Ceiling((Settings.LeaveCount / 12) * RemainingMonths);
//                        }
//                    }
//                    else
//                    {
//                        if (Settings.CreditOnCompletePeriod)
//                        {
//                            int WorkingMonths = (_DataOfJoin >= new DateTime(CurrentYear, 01, 01)
//                                                                    ? 0
//                                                                    : (_DataOfJoin < new DateTime(CurrentYear - 1, 01, 01)
//                                                                            ? 12 - _DataOfJoin.Month
//                                                                            : 12
//                                                                      )
//                                                );

//                            _BalanceLeave = Math.Ceiling((Settings.LeaveCount / 12) * WorkingMonths);
//                        }
//                        else
//                        {
//                            if (_BalanceLeave > Settings.CarryForwardCount)
//                            {
//                                _BalanceLeave = Settings.CarryForwardCount;
//                            }

//                            _BalanceLeave += Settings.LeaveCount;
//                        }
//                    }

//                    _LastLeaveCreditDate = DateTime.Now;

//                }
//            }
//            else
//            {
//                if (_LastLeaveCreditDate.Year == 1900 || CurrentMonth > _LastLeaveCreditDate.Month)
//                {
//                    if (DateTime.Now.Year == _DataOfJoin.Year)
//                    {
//                        if (Settings.CreditOnCompletePeriod)
//                        {
//                            int WorkingMonths = CurrentMonth - _DataOfJoin.Month;

//                            _BalanceLeave = (Settings.LeaveCount / 12) * WorkingMonths;
//                        }
//                        else
//                        {
//                            int RemainingMonths = 12 - CurrentMonth;

//                            _BalanceLeave = (Settings.LeaveCount / 12) * RemainingMonths;
//                        }
//                    }
//                    else
//                    {
//                        if (_BalanceLeave > Settings.CarryForwardCount)
//                        {
//                            _BalanceLeave = Settings.CarryForwardCount;
//                        }

//                        _BalanceLeave += Settings.LeaveCount;
//                    }

//                    _LastLeaveCreditDate = DateTime.Now;
//                }
//            }
//        }

//        public EmployeeLeave(int EmpID, int LeaveID, Session ss)
//        {
//            Assign_Emp_LeaveExtended[] DTO = new Assign_Emp_LeaveBusinessObject().GetEmployeeLeaves(EmpID, LeaveID);

//            if (DTO.Length > 0)
//            {
//                Update(DTO[0]);
//            }

//            _SessionVariable = ss;

//            if (ss != null)
//            {
//                UpdateLeave();
//            }

//        }

//        public EmployeeLeave()
//        {

//        }

//        public String ApplyLeave(double NoOfDays, bool _IsNew, double DayCount)
//        {
//            if (!_IsNew)
//            {
//                _BalanceLeave += DayCount;
//                _BlockedLeaves -= DayCount;
//            }

//            _BalanceLeave -= NoOfDays;
//            _BlockedLeaves += NoOfDays;

//            return Save();
//        }

//        public String CancelAppliedLeave(double NoOfDays)
//        {
//            _BalanceLeave += NoOfDays;
//            _BlockedLeaves -= NoOfDays;

//            return Save();
//        }

//        public String ApproveLeave(double NoOfDays)
//        {
//            _UsedLeaves += NoOfDays;
//            _BlockedLeaves -= NoOfDays;

//            return Save();
//        }

//        public String CancelApproveLeave(double NoOfDays)
//        {
//            _UsedLeaves -= NoOfDays;
//            _BalanceLeave += NoOfDays;

//            return Save();
//        }

//        public static EmployeeLeave[] GetEmployeeLeave(int EmpID)
//        {
//            Assign_Emp_LeaveExtended[] DTO = new Assign_Emp_LeaveBusinessObject().GetEmployeeLeaves(EmpID);

//            EmployeeLeave[] EmpLeave = new EmployeeLeave[DTO.Length];

//            for (int i = 0; i < DTO.Length; i++)
//            {
//                EmpLeave[i] = new EmployeeLeave();

//                EmpLeave[i].Update(DTO[i]);
//            }

//            return EmpLeave;
//        }

        #region JGridDataObject Members

        //public object GetGridData()
        //{
//            EmpLeaveOverviewDisplay LeaveOverview = new EmpLeaveOverviewDisplay();

//            LeaveOverview.ID = _ID;
//            LeaveOverview.LeaveType = _LeaveType;

//            bool Value = new Assign_Emp_LeaveBusinessObject().CheckLeaveCount(_EmpID, _LeaveID);

//            if (Value)
//            {
//                GetLeaveCount();
//            }

//            //if (_BalanceLeave == 0)
//            //{
//            //    _BalanceLeave = new Assign_Emp_LeaveBusinessObject().GetLeaveCount(_EmployeeTypeID, _LeaveID);
//            //}

//            LeaveOverview.TotalLeaves = _BlockedLeaves + _UsedLeaves + _BalanceLeave;
//            LeaveOverview.UsedLeaves = _UsedLeaves;
//            LeaveOverview.RequestedLeaves = _BlockedLeaves;
//            LeaveOverview.BalanceAvailableLeaves = _BalanceLeave;
//            return LeaveOverview;
    //   }

        #endregion
//   }

//    public class EmpLeaveOverviewDisplay
//    {
//        public int ID;
//        public String LeaveType;
//        public double TotalLeaves;
//        public double UsedLeaves;
//        public double RequestedLeaves;
//        public double RequestPendingLeaves;
//        public double BalanceAvailableLeaves;
//    }

}
