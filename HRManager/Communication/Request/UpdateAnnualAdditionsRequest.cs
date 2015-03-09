using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
   public class UpdateAnnualAdditionsRequest
    {
        public int ID;
        public string Name;
        public double Limit;
        public bool IsPercentage;
        public bool IsActive;
        public int UpdateBy;
        public string AnnualCode;
        public int EmployeeID;
        public int Month;
        public int Year;
    }
}
