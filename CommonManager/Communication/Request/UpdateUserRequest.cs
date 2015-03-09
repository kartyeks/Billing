using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonManager.Communication.Request
{
    /// <summary>
    /// Request to be sent for Create / Update new user
    /// </summary>
    public class UpdateUserRequest
    {
        public int UserID;
        public int EmployeeID;
        public String LoginName;
        public String Password;
        public String FirstName;
        public String LastName;
        public String DoorNo;
        public String Street;
        public String Area;
        public int StateID;
        public String City;
        public String Pincode;
        public String EMailID;
        public String MobileNo;
        public int UpdateBy;
        public String LoginType;
        public String Type;
      
    }
}
