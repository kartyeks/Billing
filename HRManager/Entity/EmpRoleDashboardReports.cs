using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IRCA.Communication;
using IS91.Services.DataBlock;
using System.Collections;
using System.Data;

namespace HRManager.Entity
{
    public class EmpRoleDashboardReports
    {
        private int _ID;
        private int _RoleID;
        private int _ReportID;

        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
        public int RoleID
        {
            get
            {
                return _RoleID;
            }
            set
            {
                _RoleID = value;
            }
        }
        public int ReportID
        {
            get
            {
                return _ReportID;
            }
            set
            {
                _ReportID = value;
            }
        }

        /// <summary>
        /// To get Dashboard reports assigned for a particular Role
        /// </summary>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public static EmpRoleDashboardReports[] GetRoleWiseDashboardReports(int RoleID)
        {
            EmpRoleDashboardReports[] ReportsInfo = new Master_RoleBusinessObject().GetRoleWiseDashboardReports(RoleID);
            return ReportsInfo;
        }
    }
}
