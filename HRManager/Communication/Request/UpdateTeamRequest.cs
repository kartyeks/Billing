using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
    public class UpdateTeamRequest
    {
        public int ID;
        public int TeamID;
        public String TeamName;
        public bool IsActive;
        public int ManagerID;
        public int UpdateBy;
    }
}
