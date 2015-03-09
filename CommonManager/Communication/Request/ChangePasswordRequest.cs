using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonManager.Communication.Request
{
    /// <summary>
    /// Request to be sent for change the password
    /// </summary>
    public class ChangePasswordRequest
    {
        public int UserID;
        public String NewPassword;
    }
}
