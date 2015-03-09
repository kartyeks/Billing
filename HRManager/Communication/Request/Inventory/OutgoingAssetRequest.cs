using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request.Inventory
{
    public class OutgoingAssetRequest
    {
        public int ID;
        public int AssetID;
        public DateTime OutgoingDate;
        public DateTime ReturningDate;
        public String Reason;
        public int UpdatedBy;
        public bool IsReturned;
    }
}
