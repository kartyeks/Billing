using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonManager.Communication.Request
{
    /// <summary>
    /// Request to be sent for Create / Update new user
    /// </summary>
    public class UpdateTaxExemptionTypeRequest
    {
        public int ID;
        public String Name;
        public Double MaxLimit;
        public bool IsPercentage;
        public bool IsActive;
        public int UpdateBy;
    }
}
