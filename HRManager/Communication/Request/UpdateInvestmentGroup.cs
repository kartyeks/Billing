using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request

{
    public class UpdateInvestmentGroup
    {
        public int ID;
        public String GroupName;
        public bool IsActive;
        public int UpdateBy;
    }
}
