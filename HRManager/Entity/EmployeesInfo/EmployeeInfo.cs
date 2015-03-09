using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRCA.Communication;

namespace HRManager.Entity.EmployeesInfo
{
    public interface EmployeeInfo : JGridDataObject
    {
        String Save();
    }
}
