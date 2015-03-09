using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
  public  class UpdateEmployeeTypeRequest
    {
        public int ID;
        public String Name;
        public String MinDurationMonth;
        public bool IsActive;
        public bool IsService;
        public bool IsPermanent;
        public int UpdateBy;
    }
}
