using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
    public class UpdateCountryRequest
    {
        public int ID;
        public String CountryID;
        public String CountryName;
        public int ModifiedBy;
        public DateTime CreatedDate;
        public bool IsActive;
        //public int CreatedBy;
    }
}
