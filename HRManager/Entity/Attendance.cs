using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IRCA.Communication;
using IS91.Services.DataBlock;
using System.Collections;
using System.Data;

namespace HRManager.Entity
{
    /// <summary>
    /// Represents Attendance fields and methods.
    /// </summary>
    public class Attendance : JGridDataObject
    {
        private int _ID;
        private int _CandidateID;
        private int _EmployeeID;
        private String _EmployeeName;
        private int _DesignationID;
        private String _DesignationName;
        private String _EmployeeCode;
        private String _EmpLeaveDetails;
        private int _BranchID;
        private int _LocationID;
        
        /*
        private int _GradeID;
        private String _GradeName;
        */
        private int _DepartmentID;
        private String _DepartmentName;
        private Double _WorkingDays;
        private Double _PresentDays;
        private Double _WeekendDays;
        private Double _HolidayCount;
        private Double _PunchedDays;
        private Double _NotPunchedDays;
        private Double _LOPDays;

        private bool _IsNew;

        private int _EmpAttendanceRecordID;
        private int _MonthId;
        private String _MonthName;
        private int _Year; 
        private int _HoliDaysCount;
        private String _ReasonForNotPunched;

        private int _UpdateBy;
        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;
        
        private String _Branch;
        private String _Location;
        private DateTime _DateOfJoining;


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
        public int BranchID
        {
            get
            {
                return _BranchID;
            }
            set
            {
                _BranchID = value;
            }
        }
        public int LocationID
        {
            get
            {
                return _LocationID;
            }
            set
            {
                _LocationID = value;
            }
        }
        public int CandidateID
        {
            get
            {
                return _CandidateID;
            }
            set
            {
                _CandidateID = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return _EmployeeID;
            }
            set
            {
                _EmployeeID = value;
            }
        }

        public int DesignationID
        {
            get
            {
                return _DesignationID;
            }
            set
            {
                _DesignationID = value;
            }
        }

        public Double LOPDays
        {
            get
            {
                return _LOPDays;
            }
            set
            {
                _LOPDays = value;
            }
        }
        
        public Double NotPunchedDays
        {
            get
            {
                return _NotPunchedDays;
            }
            set
            {
                _NotPunchedDays = value;
            }
        }

       
        public int DepartmentID
        {
            get
            {
                return _DepartmentID;
            }
            set
            {
                _DepartmentID = value;
            }
        }


        public string EmployeeName
        {
            get
            {
                return _EmployeeName;
            }
            set
            {
                _EmployeeName = value;
            }
        }

        public string DesignationName
        {
            get
            {
                return _DesignationName;
            }
            set
            {
                _DesignationName = value;
            }
        }

        
             public string EmployeeCode
        {
            get
            {
                return _EmployeeCode;
            }
            set
            {
                _EmployeeCode = value;
            }
        }


        public string DepartmentName
        {
            get
            {
                return _DepartmentName;
            }
            set
            {
                _DepartmentName = value;
            }
        }

        public string ReasonForNotPunched
        {
            get
            {
                return _ReasonForNotPunched;
            }
            set
            {
                _ReasonForNotPunched = value;
            }
        }


        public Double WorkingDays
        {
            get
            {
                return _WorkingDays;
            }
            set
            {
                _WorkingDays = value;
            }
        }

        public Double PresentDays
        {
            get
            {
                return _PresentDays;
            }
            set
            {
                _PresentDays = value;
            }
        }

        public Double WeekendDays
        {
            get
            {
                return _WeekendDays;
            }
            set
            {
                _WeekendDays = value;
            }
        }

        public Double HolidayCount
        {
            get
            {
                return _HolidayCount;
            }
            set
            {
                _HolidayCount = value;
            }
        }

        public Double PunchedDays
        {
            get
            {
                return _PunchedDays;
            }
            set
            {
                _PunchedDays = value;
            }
        }
        public int Year
        {
            get
            {
                return _Year;
            }
            set
            {
                _Year = value;
            }
        }
       
        public String MonthName
        {
            get
            {
                return _MonthName;
            }
            set
            {
                _MonthName = value;
            }
        }
        public int MonthId
        {
            get
            {
                return _MonthId;
            }
            set
            {
                _MonthId = value;
            }
        }
        public int EmpAttendanceRecordID
        {
            get
            {
                return _EmpAttendanceRecordID;
            }
            set
            {
                _EmpAttendanceRecordID = value;
            }
        }
        public String Branch
        {
            get
            {
                return _Branch;
            }
            set
            {
                _Branch = value;
            }
        }
        public String Location
        {
            get
            {
                return _Location;
            }
            set
            {
                _Location = value;
            }
        }
        public String EmpLeaveDetails
        {
            get
            {
                return _EmpLeaveDetails;
            }
            set
            {
                _EmpLeaveDetails = value;
            }
        }

        public DateTime DateOfJoining
        {
            get
            {
                return _DateOfJoining;
            }
            set
            {
                _DateOfJoining = value;
            }
        }
        public int UpdatedBy
        {
            get { return _UpdateBy; }
            set { _UpdateBy = value; }
        }

        /// <summary>
        /// Update the Attendance field using Hr_Attendance.
        /// </summary>
        /// <param name="Attendance">Object of Hr_Attendance class</param>
        private void Update(EmployeeAttendance Attendance)
        {
            if (Attendance != null)
            {
                //_CandidateID = Attendance._CandidateID;
                //_EmployeeID = Attendance._EmployeeID;
                //_EmployeeName = Attendance._EmployeeName;
                //_DesignationID = Attendance._DesignationID;
                //_DesignationName = Attendance._DesignationName;
                ////_GradeID = Attendance._GradeID;
                ////_GradeName = Attendance._GradeName;
                //_DepartmentID = Attendance._DepartmentID;
                //_DepartmentName = Attendance._DepartmentName;

                //_WorkingDays = Attendance._WorkingDays;
                //_PresentDays = Attendance._PresentDays;
                //_WeekendDays = Attendance._WeekendDays;
                //_HolidayCount = Attendance._HolidayCount;
                //_PunchedDays = Attendance._PunchedDays;
                _ID = Attendance.ID;
                _EmployeeID = Attendance.EmployeeID;
                _MonthId = Attendance.Month;
                _Year = Attendance.Year;
                _WorkingDays = Attendance.WorkingDays;
                _PresentDays = Attendance.PresentDays;
                _WeekendDays = Attendance.WEndDaysCount;
                _HolidayCount = Attendance.HoliDaysCount;
                _PunchedDays = Attendance.PunchedDays;
                _NotPunchedDays = Attendance.NotPunchedDays;
                _ReasonForNotPunched = Attendance.ReasonForNotPunched;
                _LOPDays = Attendance.LOPDays;
                _IsNew = false;
                _CreatedBy = Attendance.CreatedBy;
                _ModifiedBy = Attendance.ModifiedBy;
                _CreatedDate = Attendance.CreatedDate;
                _ModifiedDate = Attendance.ModifiedDate;
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
        public Attendance(EmployeeAttendance Attendance)
        {
            Update(Attendance);
        }
        
        //public static Attendance[] GetAllInActiveAttendances()
        //{
        //    EmployeeAttendance[] AttendancesDT = new EmployeeAttendanceBusinessObject().GetAllInActiveAttendancesOrderByAttendance();

        //    Attendance[] Attendances = new Attendance[AttendancesDT.Length];

        //    for (int i = 0; i < Attendances.Length; i++)
        //    {
        //        Attendances[i] = new Attendance(AttendancesDT[i]);
        //    }

        //    return Attendances;
        //}

        ///// <summary>
        ///// Consturctor of Attendance class.
        ///// Update Attendance for given AttendanceName field.
        ///// </summary>
        ///// <param name="AttendanceName">field contains Attendance Name</param>
        //public Attendance(String Attendance)
        //{
        //    Update(new EmployeeAttendanceBusinessObject().GetAttendanceByAttendance(Attendance));                        
        //}
        /// <summary>
        /// Consturctor of Attendance class.
        /// Update Attendance fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains Designation ID</param>
        public Attendance(int ID)
        {
            EmployeeAttendance Attendance = new EmployeeAttendanceBusinessObject().GetEmployeeAttendance(ID);

            if (Attendance == null && ID > 0)
            {
                throw new IRCAException("Invalid Attendance", ID.ToString());
            }

            Update(Attendance);
        }
        ///// <summary>
        ///// Consturctor of Attendance class.
        ///// Set variables for new Attendance.  
        ///// </summary>
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
            Session ss = Session.CreateNewSession();
            ss.BeginTransaction();
            String Status = "";
            bool IsLocalSession = false;
            if (ss == null)
            {
                IsLocalSession = true;

                ss = Session.CreateNewSession();

                ss.BeginTransaction();
            }
            try
            {
                EmployeeAttendance Attendance = new EmployeeAttendance();
                Attendance.ID = _ID;
                Attendance.EmployeeID = _EmployeeID;
                Attendance.Month = _MonthId;
                Attendance.Year = _Year;
                Attendance.WorkingDays = _WorkingDays;
                Attendance.PresentDays = _PresentDays;
                Attendance.WEndDaysCount = _WeekendDays;
                Attendance.HoliDaysCount = _HolidayCount;
                Attendance.PunchedDays = _PunchedDays;
                Attendance.NotPunchedDays = _NotPunchedDays;
                Attendance.ReasonForNotPunched = _ReasonForNotPunched;
                Attendance.LOPDays = _LOPDays;
                Attendance.ModifiedBy = _ModifiedBy;
                Attendance.ModifiedDate = DateTime.Now;
                Attendance.CreatedBy = _CreatedBy;
                Attendance.CreatedDate = _CreatedDate;

                if (_IsNew)
                {
                    Attendance.CreatedBy = _UpdateBy;
                    Attendance.CreatedDate = DateTime.Now;
                    Attendance.ID = new EmployeeAttendanceBusinessObject(ss).Create(Attendance);

                    #region Employee Leave
                    if (_EmpLeaveDetails != String.Empty)
                    {
                        int AttendanceID = Attendance.ID;
                        int LeaveID = 0;
                        Double NoOfLeaveCount = 0;
                        
                        string[] ski = _EmpLeaveDetails.Split('?');
                        foreach (string s in ski)
                        {
                            string[] words = s.Split(',');
                            LeaveID = Convert.ToInt32(words[0]);
                            NoOfLeaveCount = Convert.ToDouble(words[1]);

                            Status = UpdateEmployeeLeave(AttendanceID, LeaveID, NoOfLeaveCount, ss);

                        }
                    }
                    else Status = String.Empty;
                    if (Status == String.Empty) ss.Commit();
                    #endregion
                }
                else
                {
                    Attendance.ModifiedBy = _UpdateBy;
                    Attendance.ModifiedDate = DateTime.Now;
                    Attendance.ID = _ID;
                    new EmployeeAttendanceBusinessObject(ss).Update(Attendance);
                    ss.Commit();
                }

            }
            catch (Exception e)
            {
                if (IsLocalSession)
                {
                    ss.Rollback();
                }

                throw e;
            }
            finally
            {
                if (IsLocalSession)
                {
                    ss.Dispose();
                }
            }
            return String.Empty;
        }

        public String Delete(int ID)
        {
            String Status = Validate();

            if (Status != String.Empty)
            {
                return Status;
            }

           int delStatus = new EmployeeAttendanceBusinessObject().Delete(ID);

           if (delStatus == 0)
           {
               return "Not able to delete";//return HREmployeeManagerDefs.EmployeeAttendance.ATTENDANCE_DELETED_FAILURE; Commented
           }
           else
               return String.Empty;
        }
        /// <summary>
        /// Update Candidate Previous Employer of given ID
        /// </summary>
        public static String UpdateEmployeeLeave(int AttendanceID, int LeaveID, Double NoOfLeaveCount,  Session DBSession)
        {
            bool IsLocalSession = false;

            if (DBSession == null)
            {
                IsLocalSession = true;

                DBSession = Session.CreateNewSession();

                DBSession.BeginTransaction();
            }
            try
            {
                EmployeeAttendance_LeaveDetails EmpLeaveDetails = new EmployeeAttendance_LeaveDetails();

                EmpLeaveDetails.AttendanceID = AttendanceID;
                EmpLeaveDetails.LeaveID = LeaveID;
                EmpLeaveDetails.NoOfLeaveCount = NoOfLeaveCount;

                EmpLeaveDetails.ID = new EmployeeAttendance_LeaveDetailsBusinessObject(DBSession).Create(EmpLeaveDetails);
                if (IsLocalSession)
                {
                    DBSession.Commit();
                }
                return String.Empty;
            }
            catch (Exception e)
            {
                if (IsLocalSession)
                {
                    DBSession.Rollback();
                }

                throw e;
            }
            finally
            {
                if (IsLocalSession)
                {
                    DBSession.Dispose();
                }
            }
            
            
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
        /// Validate Attendance for empty and already exist status.
        /// </summary>
        /// <returns>empty string</returns>
        private String Validate()
        {
            EmployeeAttendanceBusinessObject EmpAttBO = new EmployeeAttendanceBusinessObject();

            if (!EmpAttBO.IsEmpAttendanceAdded(_MonthId, _Year, _EmployeeID))
            {
                return HRManagerDefs.EmployeeAttendanceMessages.PAYROLL_ADDED;
            }
            
            return String.Empty;
        }

        /// <summary>
        /// Return all Designations
        /// </summary>
        /// <returns>Array of the object of Designation class</returns>
        public static Attendance[] GetAllAttendance(int Month, String Year)
        {
            //Attendance[] ReimbursementTypesDT = new EmployeeAttendanceBusinessObject().GetAllEmpAttendance(Month, Year);
            Attendance[] ReimbursementTypesDT = new EmployeeAttendanceBusinessObject().GetAllEmpAttendance(Month, Year);
            return ReimbursementTypesDT;
        }

        public static Attendance GetAttendanceForEmployee(int month, int year,int empId)
        {
            Attendance attd= new EmployeeAttendanceBusinessObject().GetAttendanceForEmployee(month, year,empId);
            return attd;
        }
        
       
        public static Attendance[] GetAllAttendanceDetailsByMonYearLoc(int Month, String Year, int LocationID)
        {
            Attendance[] ReimbursementTypesDT = new EmployeeAttendanceBusinessObject().GetAllAttendanceDetailsByMonYearLoc(Month, Year, LocationID);

            return ReimbursementTypesDT;
        }
        #region JGridDataObject Members

        public object GetGridData()
        {
            AttendanceDetails AttendanceDetails = new AttendanceDetails();

            AttendanceDetails.ID = _ID;
            AttendanceDetails.EmployeeID = _EmployeeID;
            AttendanceDetails.Name = _EmployeeName;
            AttendanceDetails.Code = _EmployeeCode;
            AttendanceDetails.Department = _DepartmentName;
            AttendanceDetails.Designation = _DesignationName;
            AttendanceDetails.Branch = _Branch;
            AttendanceDetails.Location = _Location;
            AttendanceDetails.BranchID = _BranchID;
            AttendanceDetails.LocationID = _LocationID;
            //AttendanceDetails.EmpAttendanceRecordID = _EmpAttendanceRecordID;
            //AttendanceDetails.MonthId = _MonthId;
            //AttendanceDetails.MonthName = _MonthName;
            //AttendanceDetails.Year = _Year;
            AttendanceDetails.Working = _WorkingDays;
            AttendanceDetails.Present = _PresentDays;
            AttendanceDetails.Weekend = _WeekendDays;
            AttendanceDetails.Holiday = _HolidayCount;
            AttendanceDetails.Punched = _PunchedDays;
            AttendanceDetails.ReasonForNotPunched = _ReasonForNotPunched;
            AttendanceDetails.NotPunched = _NotPunchedDays;
            AttendanceDetails.LOP = _LOPDays;
            AttendanceDetails.DateOfJoining = _DateOfJoining;


            return AttendanceDetails;
        }

        
        
        #endregion
    }
    public class AttendanceDetails
    {
        public int ID;
        public int EmployeeID;
        public String Name;
        public String Code;
        public String Designation;
        public String Department;
        public int BranchID;
        public int LocationID;
        public String Branch;
        public String Location;
        public Double Working;
        public Double Present;
        public Double Weekend;
        public Double Holiday;
        public Double Punched;
        public Double NotPunched;
        public Double LOP;
        public String ReasonForNotPunched;
        public DateTime DateOfJoining;
    }
}
