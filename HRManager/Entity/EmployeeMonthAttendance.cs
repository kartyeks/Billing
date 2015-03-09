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
    public class EmployeeMonthAttendance 
    {
      
        private Double _NoOfWeeklyOff;
        private Double _NoOfHilodays;
        private Double _NoOfPunchedDays;

        public Double NoOfWeeklyOff
        {
            get
            {
                return _NoOfWeeklyOff;
            }
            set
            {
                _NoOfWeeklyOff = value;
            }
        }


        public Double NoOfHilodays
        {
            get
            {
                return _NoOfHilodays;
            }
            set
            {
                _NoOfHilodays = value;
            }
        }

        public Double NoOfPunchedDays
        {
            get
            {
                return _NoOfPunchedDays;
            }
            set
            {
                _NoOfPunchedDays = value;
            }
        }
        public static String GetEmployeeDaysWorked(string month, string year, string employeeid, string locationid)
        {
            int Count = new EmployeeAttendanceBusinessObject().GetEmployeeDaysWorked(month, year, employeeid, locationid);
           
            return Count.ToString();
        }
        /// <summary>
        /// Constructor for getting employee details
        /// </summary>
        /// <param name="EmployeeId">Id of the employee</param>
        /// <param name="Month">Selected Month</param>
        /// <param name="Year">Selected Year</param>
        public EmployeeMonthAttendance(int EmployeeId, int Month, int Year)
        {
            EmployeeMonthAttendance EmployeeMonthAttendance = new EmployeeAttendanceBusinessObject().GetMonthlyEmployeeAttendnceDetails(EmployeeId, Month, Year);

            if (EmployeeMonthAttendance == null)
            {
                throw new IRCAException("Invalid Attendance Details", EmployeeId.ToString());
            }

            Update(EmployeeMonthAttendance);
        }
        /// <summary>
        /// Constructor for getting employee details
        /// </summary>
        /// <param name="Month">Selected Month</param>
        /// <param name="Year">Selected Year</param>
        /// <param name="BranchID">Branch id for selected Employee</param>
        /// <param name="LoacationID">Location  id for selected Employee</param>
        public EmployeeMonthAttendance(int Month, int Year, int BranchID, int LoacationID)
        {

            EmployeeMonthAttendance EmployeeMonthAttendance = new EmployeeAttendanceBusinessObject().GetMonthlyPreEmployeeAttendnceDetails(Month, Year, BranchID, LoacationID);

            if (EmployeeMonthAttendance == null)
            {
                throw new IRCAException("Invalid Attendance Details", BranchID.ToString());
            }

            Update(EmployeeMonthAttendance);
        }
        /// <summary>
        /// Constructor for getting employee details
        /// </summary>
        /// <param name="Month">Selected Month</param>
        /// <param name="Year">Selected Year</param>
        /// <param name="BranchID">Branch id for selected Employee</param>
        /// <param name="LoacationID">Location  id for selected Employee</param>
        public EmployeeMonthAttendance(int Month, int Year, int BranchID, int LoacationID,int Day)
        {

            EmployeeMonthAttendance EmployeeMonthAttendance = new EmployeeAttendanceBusinessObject().GetMonthlyPreEmployeeAttendnceDetailsForJoining(Month, Year, BranchID, LoacationID,Day);

            if (EmployeeMonthAttendance == null)
            {
                throw new IRCAException("Invalid Attendance Details", BranchID.ToString());
            }

            Update(EmployeeMonthAttendance);
        }
        /// <summary>
        /// Constructor 
        /// </summary>
        public EmployeeMonthAttendance()
        {
            _NoOfWeeklyOff = 0;
            _NoOfHilodays = 0;
            _NoOfPunchedDays = 0;
        }
        /// <summary>
        /// Method for Updating Entity data to the instance variables
        /// </summary>
        /// <param name="EmployeeMonthAttendance"></param>
        private void Update(EmployeeMonthAttendance EmployeeMonthAttendance)
        {
            if (EmployeeMonthAttendance != null)
            {
                _NoOfPunchedDays = EmployeeMonthAttendance.NoOfPunchedDays;
                _NoOfWeeklyOff = EmployeeMonthAttendance.NoOfWeeklyOff;
                _NoOfHilodays = EmployeeMonthAttendance.NoOfHilodays;
            }
            
        }
        

    }
    
}
