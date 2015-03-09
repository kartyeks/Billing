using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;

namespace HRManager.DTOEXT
{
    public class Master_TeamEXT : Master_Team
    {
        public String ManagerName;
    }
    public class Master_HolidayEXT : Master_Holidays
    {
        public String HolidayDateName;
    }
    public class Master_ConsultantEXT : Master_Consultant
    {
        public String LoginName;
    }
}
