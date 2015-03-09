using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonManager.DTO;

namespace CommonManager.DTOEXT
{
    public class Common_StateEXT : Common_State
    {
        public String RegionName;
        public String CountryName;
    }

    public class Common_StateComboEXT
    {
        public int ID;
        public String StateName;
    }
}
