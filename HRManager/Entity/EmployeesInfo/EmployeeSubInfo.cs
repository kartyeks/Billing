using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Entity.EmployeesInfo
{
    public abstract class EmployeeInfoList : List<EmployeeInfo>
    {
        public EmployeeInfo[] GetEmployeeInfo()
        {
            return ToArray();
        }

        public abstract String Delete(int EmployeeID);
    }
}
