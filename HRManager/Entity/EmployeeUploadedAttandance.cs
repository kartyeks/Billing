using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using HRManager.DTOEXT;
using IRCA.Communication;

namespace HRManager.Entity
{
    public class EmployeeUploadedAttandance : JGridDataObject
    {
        private int _ID;
        private int _EmployeeID;
        private DateTime _LeaveDate;
        private String _LeaveType;
        private String _EmpCode;
        private String _EmpName;
        private String _Team;
        private int _TotalDays;
        private int _LeaveCount;
        private int _DaysWorked;
        private String _CurrentMonth;
        private int _CurentYear;

        public int ID { get { return _ID; } set { _ID = value; } }
        public int EmployeeID { get { return _EmployeeID; } set { _EmployeeID = value; } }
        public DateTime LeaveDate { get { return _LeaveDate; } set { _LeaveDate = value; } }
        public String LeaveType { get { return _LeaveType; } set { _LeaveType = value; } }
        public String EmpCode { get { return _EmpCode; } set { _EmpCode = value; } }
        public String EmpName { get { return _EmpName; } set { _EmpName = value; } }
        public String Team { get { return _Team; } set { _Team = value; } }
        public int TotalDays { get { return _TotalDays; } set { _TotalDays = value; } }
        public int LeaveCount { get { return _LeaveCount; } set { _LeaveCount = value; } }
        public int DaysWorked { get { return _DaysWorked; } set { _DaysWorked = value; } }
        public String CurrentMonth { get { return _CurrentMonth; } set { _CurrentMonth = value; } }
        public int CurentYear { get { return _CurentYear; } set { _CurentYear = value; } }


        public EmployeeUploadedAttandance()
        {
        }
        public EmployeeUploadedAttandance(int ID)
        {
            Update(new Employee_Uploaded_AttandanceBusinessObject().GetEmployee_Uploaded_Attandance(ID));
        }
        
        public void Update(Employee_Uploaded_Attandance DTO)
        {
            if (DTO != null)
            {
                _ID = DTO.ID;
                _EmployeeID = DTO.EmployeeID;
                _LeaveDate = DTO.LeaveDate;
                _LeaveType = DTO.LeaveType;

                if (DTO is Employee_Uploaded_AttandanceEXT)
                {
                    _EmpCode = ((Employee_Uploaded_AttandanceEXT)DTO).EmpCode;
                    _EmpName = ((Employee_Uploaded_AttandanceEXT)DTO).EmpName;
                    _Team = ((Employee_Uploaded_AttandanceEXT)DTO).Team;
                    _TotalDays = ((Employee_Uploaded_AttandanceEXT)DTO).TotalDays;
                    _LeaveCount = ((Employee_Uploaded_AttandanceEXT)DTO).LeaveCount;
                    _DaysWorked = ((Employee_Uploaded_AttandanceEXT)DTO).DaysWorked;
                    _CurrentMonth = ((Employee_Uploaded_AttandanceEXT)DTO).CurrentMonth;
                    _CurentYear = ((Employee_Uploaded_AttandanceEXT)DTO).CurrentYear;
                }
            }
        }

        private Employee_Uploaded_Attandance GetDTO()
        {
            Employee_Uploaded_Attandance DTO = new Employee_Uploaded_Attandance();

            DTO.ID = _ID;
            DTO.EmployeeID = _EmployeeID;
            DTO.LeaveDate = _LeaveDate;
            DTO.LeaveType = _LeaveType;
            
            return DTO;
        }

        public String Save()
        {           
            try
            {
                Employee_Uploaded_AttandanceBusinessObject BO = new Employee_Uploaded_AttandanceBusinessObject();
                Employee_Uploaded_Attandance DTO = GetDTO();

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

        public static EmployeeUploadedAttandance[] GetUploadedEmployeeAttendance(int Month, int Year)
        {
            Employee_Uploaded_AttandanceEXT[] DTO = new Employee_Uploaded_AttandanceBusinessObject().GetUploadedAttendanceAndEmpData(Month, Year);

            EmployeeUploadedAttandance[] data = new EmployeeUploadedAttandance[DTO.Length];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = new EmployeeUploadedAttandance();
                data[i].Update(DTO[i]);
            }

            return data;
        }

        #region JGridDataObject Members

        public object GetGridData()
        {
            EmployeeUploadedAttendanceDisplay dis = new EmployeeUploadedAttendanceDisplay();

            dis.ID = _ID;
            dis.EmployeeID = _EmployeeID;
            dis.EmployeeCode = _EmpCode;
            dis.EmployeeName = _EmpName;
            dis.LeaveDate = _LeaveDate.ToString("dd/MM/yyyy");
            dis.LeaveType = _LeaveType;
            dis.TeamName = _Team;
            dis.DaysInMonth = _TotalDays;
            dis.LeaveCount = _LeaveCount;
            dis.DaysWorked = _DaysWorked;
            dis.Month = _CurrentMonth;
            dis.Year = _CurentYear;

            return dis;
        }

        #endregion
    }

    public class EmployeeUploadedAttendanceDisplay
    {
        public int ID;
        public int EmployeeID;
        public String EmployeeCode;
        public String EmployeeName;
        public String TeamName;
        public String Month;
        public int Year;
        public String LeaveDate;
        public String LeaveType;
        public int DaysInMonth;
        public int LeaveCount;
        public int DaysWorked;
    }
}
