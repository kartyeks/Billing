using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request.Inventory
{
    public class AssignAssetRequest
    {
        public int ID;
        public int AssetID;
        public bool IsTeamAssigned;
        public int TeamID;
        public int EmployeeID;
        public DateTime dtIssuedDate;
        public DateTime ReturnedDate;
        public String Reason;
        public String LocationOfAsset;
        public bool IsReturned;
        public String Comments;
        public int UpdatedBy;
    }
}
