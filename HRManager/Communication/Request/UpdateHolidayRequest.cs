using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
    public class UpdateHolidayRequest
    {
        public int ID;
        public int LocationID;
        public String HolidayName;
        public DateTime HolidayDate;
        public String Description;
        public String Status;
        public int RequestingTo;
        public int ModifiedBy;
        public DateTime CreatedDate;
        public bool IsActive;
    }
}
