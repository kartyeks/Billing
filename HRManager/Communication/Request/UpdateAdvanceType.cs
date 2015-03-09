using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
    public class UpdateAdvanceTypeRequest
    {
        public int ID;
        public String AdvanceType;        
        public bool IsActive;
        //public int EmpID;
        //public int LoanID;
        //public int GradeID;
        public int UpdateBy;
    }
}


