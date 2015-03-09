using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Communication.Request

{
    public class UpdateProjectInfo
    {
        public int ID;
        public int Companyid;
        public String ProjectGroup;
        public String Projecttype;
        public String projectcode;
        public String ProjectName;
        public String Address;
        public String contractown;
        public bool IsActive;
        public int UpdateBy;
    }
}
