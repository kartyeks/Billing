using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;

namespace HRManager.DTOEXT
{
    public class Exit_ManagementEXT : Exit_Management
    {
       public String EmployeeName;
       public String ExitType;
       public String EmployeeCode;
       public int EmpExitID;
    }

    public class UploadExitManagementEXT 
    {
        public int ID;
        public int EmployeeID;
        public int EmpExitID;
        public int ExitTypeID;
        public DateTime ExitDate;
        public String DocumentName;       
    }
}
