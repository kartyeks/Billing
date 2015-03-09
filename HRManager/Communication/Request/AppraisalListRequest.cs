using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
    public class AppraisalListRequest
    {
        public int ID;
        public int ManagerID;
        public String Grade;
    }
    public class AppraisalRequest
    {
        public int ID;
        public int EmployeeID;
        public int IntimationID;
        public int DesignationID;
        public int TeamID;
        public String Salary;
        public String OldDesignation;
        public String OldSalary;
        public Double HikePer;
        public String Type;
        public String Basic;
    }
}
