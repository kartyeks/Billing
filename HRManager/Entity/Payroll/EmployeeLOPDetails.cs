using System;
using System.Collections.Generic;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;

namespace HRManager.Entity
{
    /// <summary>
    /// Represents Attendance fields and methods.
    /// </summary>
    public class EmployeeLOP 
    {

        private int _ID;
        private int _EmployeeID;
        private DateTime _FromDate;
        private DateTime _ToDate;
        private Double _LOPDays;
        private int UploadedBy;
        private bool IsUserd;
        private int Month;
        private int Year;

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


        public DateTime FromDate
        {
            get
            {
                return _FromDate;
            }
            set
            {
                _FromDate = value;
            }
        }

        public DateTime ToDate
        {
            get
            {
                return _ToDate;
            }
            set
            {
                _ToDate = value;
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
                _LOPDays= value;
            }
        }
        public static EmployeeLOP[] GetLOPForEmployee(string pdate, int employeeId)
        {
           EmployeeLOP[] eLops = new Employee_LOPDetailsBusinessObject().GetLOPForEmployee(pdate,employeeId);
           return eLops;
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
        public EmployeeLOP(int EmployeeId, int Month, int Year)
        {
           /* DateTime lDate = new DateTime(Year, Month, 1);
            Employee_LOPDetails empLOPDet = new Employee_LOPDetailsBusinessObject().GetLOPForEmployee(lDate.ToString("yyyy-MM-dd"),EmployeeID); ;

            if (empLOPDet == null)
            {
                throw new IRCAException("Invalid Attendance Details", EmployeeId.ToString());
            }

            Update(empLOPDet);*/
        }
        /// <summary>
        /// Constructor for getting employee details
        /// </summary>
        /// <param name="Month">Selected Month</param>
        /// <param name="Year">Selected Year</param>
        /// <param name="BranchID">Branch id for selected Employee</param>
        /// <param name="LoacationID">Location  id for selected Employee</param>
        public EmployeeLOP(int Month, int Year, int BranchID, int LoacationID)
        {

            Employee_LOPDetails empLOPDet = null;// new EmployeeAttendanceBusinessObject().GetMonthlyPreEmployeeAttendnceDetails(Month, Year, BranchID, LoacationID);

            if (empLOPDet == null)
            {
                throw new IRCAException("Invalid Attendance Details", BranchID.ToString());
            }

            Update(empLOPDet);
        }
       
        /// <summary>
        /// Constructor 
        /// </summary>
        public EmployeeLOP()
        {
            _EmployeeID = 0;
            
        }
        /// <summary>
        /// Method for Updating Entity data to the instance variables
        /// </summary>
        /// <param name="EmployeeMonthAttendance"></param>
        private void Update(Employee_LOPDetails EmpLOPDet)
        {
            if (EmpLOPDet != null)
            {
                _EmployeeID =EmpLOPDet.EmployeeID;
                _FromDate= EmpLOPDet.FromDate;
                _ToDate= EmpLOPDet.ToDate;
            }
            
        }

        
        

    }
    
}
