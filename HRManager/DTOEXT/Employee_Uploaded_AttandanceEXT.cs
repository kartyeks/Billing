using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;

namespace HRManager.DTOEXT
{
    public class Employee_Uploaded_AttandanceEXT : Employee_Uploaded_Attandance
    {
        public String EmpName;
        public String EmpCode;
        public String Team;
        public int TotalDays;
        public int LeaveCount;
        public int DaysWorked;
        public String CurrentMonth;
        public int CurrentYear;
    }
}
