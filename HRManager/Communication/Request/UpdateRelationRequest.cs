using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request
{
    public class UpdateRelationRequest
    {
        public int ID;
        public String RelationName;
        public bool IsActive;
        public int UpdateBy;
    }
}
