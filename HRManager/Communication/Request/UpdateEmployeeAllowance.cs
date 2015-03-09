using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
    public class UpdateEmployeeAllowance
    {
        public int ID;
        public int EmpID;
        public int AllowanceID;
        public int UpdatedBy;
        public Double Amount;
    }
}
