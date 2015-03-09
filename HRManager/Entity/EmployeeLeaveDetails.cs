using System;
using System.Collections.Generic;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IRCA.Communication;

namespace HRManager.Entity
{
    /// <summary>
    /// Represents Attendance fields and methods.
    /// </summary>
    public class EmployeeLeaveDetails : JGridDataObject
    {
        private int _EmployeeId;
        private int _LeaveTypeID;
        private String _LeaveType;
        private String _LeaveStatus;
        private Double _NoOfLeaveTaken;
        private Double _YearlyLeave;
        private Double _BalLeave;

        public int EmployeeId
        {
            get
            {
                return _EmployeeId;
            }
            set
            {
                _EmployeeId = value;
            }
        }

        public int LeaveTypeID
        {
            get
            {
                return _LeaveTypeID;
            }
            set
            {
                _LeaveTypeID = value;
            }
        }

        public string LeaveType
        {
            get
            {
                return _LeaveType;
            }
            set
            {
                _LeaveType = value;
            }
        }

        public string LeaveStatus
        {
            get
            {
                return _LeaveStatus;
            }
            set
            {
                _LeaveStatus = value;
            }
        }


        public Double NoOfLeaveTaken
        {
            get
            {
                return _NoOfLeaveTaken;
            }
            set
            {
                _NoOfLeaveTaken = value;
            }
        }
        public Double YearlyLeave
        {
            get
            {
                return _YearlyLeave;
            }
            set
            {
                _YearlyLeave = value;
            }
        }
        public Double BalLeave
        {
            get
            {
                return _BalLeave;
            }
            set
            {
                _BalLeave = value;
            }
        }
        /*  // Old code not required here. 
        
                /// <summary>
                /// Update the Attendance field using Hr_Attendance.
                /// </summary>
                /// <param name="Attendance">Object of Hr_Attendance class</param>
                private void Update(Master_Attendance Attendance)
                {
                    if (Attendance != null)
                    {
                        _CandidateID = Attendance._CandidateID;
                        _EmployeeID = Attendance._EmployeeID;
                        _EmployeeName = Attendance._EmployeeName;
                        _DesignationID = Attendance._DesignationID;
                        _DesignationName = Attendance._DesignationName;
                        //_GradeID = Attendance._GradeID;
                        //_GradeName = Attendance._GradeName;
                        _DepartmentID = Attendance._DepartmentID;
                        _DepartmentName = Attendance._DepartmentName;

                        _WorkingDays = Attendance._WorkingDays;
                        _PresentDays = Attendance._PresentDays;
                        _WeekendDays = Attendance._WeekendDays;
                        _HolidayCount = Attendance._HolidayCount;
                        _PunchedDays = Attendance._PunchedDays;

                        _IsNew = false;
                    }
                    else
                    {
                        _IsNew = true;
                    }
                }
        
                /// <summary>
                /// Consturctor of Attendance class.
                /// Update Attendance fields using Hr_Attendance.
                /// </summary>
                /// <param name="Attendance">Object of Hr_Attendance class</param>
                public Attendance(Master_Attendance Attendance)
                {
                    Update(Attendance);
                }
        
                public static Attendance[] GetAllInActiveAttendances()
                {
                    EmployeeAttendance[] AttendancesDT = new EmployeeAttendanceBusinessObject().GetAllInActiveAttendancesOrderByAttendance();

                    Attendance[] Attendances = new Attendance[AttendancesDT.Length];

                    for (int i = 0; i < Attendances.Length; i++)
                    {
                        Attendances[i] = new Attendance(AttendancesDT[i]);
                    }

                    return Attendances;
                }

                /// <summary>
                /// Consturctor of Attendance class.
                /// Update Attendance for given AttendanceName field.
                /// </summary>
                /// <param name="AttendanceName">field contains Attendance Name</param>
                public Attendance(String Attendance)
                {
                    Update(new EmployeeAttendanceBusinessObject().GetAttendanceByAttendance(Attendance));                        
                }
                /// <summary>
                /// Consturctor of Attendance class.
                /// Update Attendance fields for given ID field.
                /// </summary>
                /// <param name="ID">field contains Designation ID</param>
                public Attendance(int ID)
                {
                    EmployeeAttendance Attendance = new EmployeeAttendanceBusinessObject().GetMaster_Attendance(ID);

                    if (Attendance == null && ID > 0)
                    {
                        throw new IRCAException("Invalid Attendance", ID.ToString());
                    }

                    Update(Attendance);
                }
                /// <summary>
                /// Consturctor of Attendance class.
                /// Set variables for new Attendance.  
                /// </summary>
                public Attendance()
                {
                    _ID = 0;
                    _IsNew = true;
                }
                /// <summary>
                /// Save Attendance.If new Attendance it add and in case of edit it update the Attendance.
                /// </summary>
                /// <returns>empty string</returns>
                private String SaveAttendance()
                {

                    EmployeeAttendance Attendance = new EmployeeAttendance();
                    Attendance.ID = _ID;
                    Attendance.AttendanceName= _AttendanceName;
                    Attendance.MaxAmount = _MaxAmount;
                    Attendance.IsActive = _IsActive;

                    if (_IsNew)
                    {
                        Attendance.ID = new EmployeeAttendanceBusinessObject().Create(Attendance);
                    }
                    else
                    {
                        Attendance.ID = _ID;
                        new EmployeeAttendanceBusinessObject().Update(Attendance);
                    }

                    return String.Empty;
                }
                /// <summary>
                ///Validate Attendance for empty and already exist status and then save Attendance.
                /// </summary>
                /// <returns>String return from the SaveAttendance method</returns> 
                public String Save()
                {
                    String Status = Validate();

                    if (Status != String.Empty)
                    {
                        return Status;
                    }

                    return SaveAttendance();
                }
                /// <summary>
                /// Validate AttendanceName for empty and already exist status.
                /// </summary>
                /// <returns>empty string</returns>
                private String Validate()
                {
                    EmployeeAttendanceBusinessObject AttendanceBO = new EmployeeAttendanceBusinessObject();

                    if (_AttendanceName == String.Empty)
                    {
                        return HRManagerDefs.AttendanceMessages.EMPTY_REIMBURSEMENTTYPE;
                    }
                    else if (AttendanceBO.IsAttendanceExists(_AttendanceName, _ID))
                    {
                        return HRManagerDefs.AttendanceMessages.REIMBURSEMENTTYPE_EXISTS;
                    }
                    return String.Empty;
                }

                /// <summary>
                /// Activate the Attendance
                /// </summary>
                /// <param name="ActivatedBy">id of user who want to activate Attendance</param>
                /// <returns>String return from the SaveAttendance method</returns>
                public String Activate()
                {
                    _IsActive = true;

                    return SaveAttendance();
                }
                /// <summary>
                /// Deactivate the Attendance
                /// </summary>
                /// <param name="DeActivatedBy">id of user who want to DeActivate Attendance</param>
                /// <returns>String return from the SaveAttendance method</returns>
                public String DeActivate()
                {
                    _IsActive = false;

                    return SaveAttendance();
                }
                /// <summary>
                /// Return all Attendances
                /// </summary>
                /// <returns>Array of the object of Attendance class</returns>
                public static Attendance[] GetAllAttendance()
                {
                    Attendance[] AttendancesDT = new EmployeeAttendanceBusinessObject().GetAllAttendances();

                    Attendance[] Attendances = new Attendance[AttendancesDT.Length];

                    for (int i = 0; i < Attendances.Length; i++)
                    {
                        Attendances[i] = new Attendance(AttendancesDT[i]);
                    }

                    return Attendances;
                }
                /// <summary>
                /// Return all active Attendances
                /// </summary>
                /// <returns>Array of the object of Attendances class</returns>
                public static Attendance[] GetAllActiveAttendanceDetails()
                {
                    EmployeeAttendance[] AttendanceDT = new EmployeeAttendanceBusinessObject().GetAllActiveAttendance();

                    Attendance[] Attendance = new Attendance[AttendanceDT.Length];

                    for (int i = 0; i < Attendance.Length; i++)
                    {
                        Attendance[i] = new Attendance(AttendanceDT[i]);
                    }

                    return Attendance;
                }
        
                    /// <summary>
                /// Return all Attendances
                /// </summary>
                /// <returns>Array of the object of Attendances class</returns>
                public static String GetAttendanceForSearch()
                {
                    String AttendanceDT = new EmployeeAttendanceBusinessObject().GetAttendanceForSearch();

                    return AttendanceDT;
                }
                */
        #region JGridDataObject Members

        public object GetGridData()
        {
            EmployeeLeaveDatailsClass EmployeeLeaveDatailsCls = new EmployeeLeaveDatailsClass();

            EmployeeLeaveDatailsCls.LeaveType = _LeaveType;
            EmployeeLeaveDatailsCls.LeaveTypeID = _LeaveTypeID;
            EmployeeLeaveDatailsCls.YearlyLeave = _YearlyLeave;
            EmployeeLeaveDatailsCls.BalLeave = _BalLeave;
            EmployeeLeaveDatailsCls.NoOfLeaveTaken = _NoOfLeaveTaken;

            return EmployeeLeaveDatailsCls;
        }

        /// <summary>
        /// Return all Designations
        /// </summary>
        /// <returns>Array of the object of Designation class</returns>
        //public static EmployeeLeaveDetails[] GetEmploLeaveDetails(int EmployeeId, int Month, int Year)
        //{
        //    EmployeeLeaveDetails[] EmployeeLeaveDetailsDT = new EmployeeAttendanceBusinessObject().GetEmploLeaveDetails(EmployeeId, Month, Year);

        //    return EmployeeLeaveDetailsDT;
        //}

        /// <summary>
        /// Return all Designations
        /// </summary>
        /// <returns>Array of the object of Designation class</returns>
        //public static EmployeeLeaveDetails[] GetShowEmploLeaveDetails(int EmployeeId, int Month, int Year)
        //{
        //    EmployeeLeaveDetails[] EmployeeLeaveDetailsDT = new EmployeeAttendanceBusinessObject().GetShowEmploLeaveDetails(EmployeeId, Month, Year);

        //    return EmployeeLeaveDetailsDT;
        //}
        #endregion
    }
    public class EmployeeLeaveDatailsClass
    {
        public int LeaveTypeID;
        public String LeaveType;
        public Double YearlyLeave;
        public Double BalLeave;
        public Double NoOfLeaveTaken;

    }
}
