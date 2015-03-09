using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
    public class UpdateLocationRequest
    {
        public int ID;
        public String LocationName;       
        public int CountryID;
        public int UpdateBy;
        public bool IsActive;
        public int ChangedBy;        
    }

    public class UpdateConsultantRequest
    {
        public int ID;
        public int DesignationID;
        public String ConsultantName;
        public String ContactPerson;
        public String TelephoneNo;
        public String EmailID;
        public String Address;       
        public int UpdateBy;
        public bool IsActive;
        public int ChangedBy;
    }
}
