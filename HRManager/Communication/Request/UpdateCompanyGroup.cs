using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request

{
    public class UpdateCompany
    {
        public int ID;
        public String CompanyName;
        public String Companycode;
        public String CompanyShortName;
        public String Address;
        public String Pan;
        public String Tin;
        public String registrationno;
        public String pfno;
        public String phone;
        public DateTime financialyearstart;
        public DateTime financialyearend;
        public String financialyearname;
        public DateTime voucherstartdate;
        public DateTime voucherenddate;
        public int investmentgroup;
        public String tan;
        public String servicetaxregno;
        public String website;
        public String email;
        public String shopsno;
        public String esino;
        public bool IsActive;
        public int UpdateBy;
    }
}
