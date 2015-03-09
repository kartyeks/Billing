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
    public class DashBoardReport : JGridDataObject
    {
        private int _ID;
        private String _ReportName;
        private String _Value;

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

        public String ReportName
        {
            get
            {
                return _ReportName;
            }
            set
            {
                _ReportName = value;
            }
        }
        public String Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
            }
        }
        public DashBoardReport(DashBoardReports Reports)
        {
            Update(Reports);
        }
        /// <summary>
        /// Update the Grade field using Hr_Grade.
        /// </summary>
        /// <param name="Grade">Object of Hr_Grade class</param>
        private void Update(DashBoardReports Reports)
        {
            if (Reports != null)
            {
                _ID = Reports.ID;
                _ReportName = Reports.ReportName;
                _Value = Reports.Value;

            }

        }
        /// <summary>
        /// Return all Location
        /// </summary>
        /// <returns>Array of the object of Location class</returns>
        public static DashBoardReport[] GetAllDashBoardReports()
        {
            DashBoardReports[] RerportsDt = new DashBoardReportsBusinessObject().GetDashBoardReports();
            DashBoardReport[] Reports = new DashBoardReport[RerportsDt.Length];

            for (int i = 0; i < Reports.Length; i++)
            {
                Reports[i] = new DashBoardReport(RerportsDt[i]);
            }

            return Reports;
        }
        #region JGridDataObject Members

        public object GetGridData()
        {
            ReportDetails Reports = new ReportDetails();

            Reports.ReportID = _ID;
            Reports.ReportName = _ReportName;


            return Reports;
        }

        #endregion
    }
    public class ReportDetails
    {
        public int ReportID;
        public String ReportName;

    }
}
