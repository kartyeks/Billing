using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRCA.Communication;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using HRManager.DTOEXT;
namespace HRManager.Entity.EmployeeLeave
{  
    public class LeaveOverview : JGridDataObject
    {
        private int _ID;
        private int _EmpID;
        private Double _TotalLeave;
        private double _UsedLeave;
        private Double _BalanceLeave;      
        private String _LeaveType;
        private Double _LeaveRequested;
        private String _EmployeeName;
        private int _LeaveID;

        public int ID {get {return _ID;}  set { _ID = value; }}
        public int EmpID {get {return _EmpID;}  set { _EmpID = value; }}
        public Double TotalLeave {get {return _TotalLeave;}  set { _TotalLeave = value; }}
        public double UsedLeave {get {return _UsedLeave;}  set { _UsedLeave = value; }}
        public Double BalanceLeave {get {return _BalanceLeave;}  set { _BalanceLeave = value; }}
        public Double LeaveRequested { get { return _LeaveRequested; } set { _LeaveRequested = value; } }
        public String LeaveType { get { return _LeaveType; } set { _LeaveType = value; } }
        public String EmployeeName { get { return _EmployeeName; } set { _EmployeeName = value; } }
        public int LeaveID { get { return _LeaveID; } set { _LeaveID = value; } }


        private void Update(LeaveOverViewEXT DTO)
        {
            if (DTO != null)
            {              
                //_EmpID = DTO.EmpID;               
                if (DTO is LeaveOverViewEXT)
                {
                    _ID = ((LeaveOverViewEXT)DTO).ID;
                    _TotalLeave = ((LeaveOverViewEXT)DTO).TotalLeave;
                    _UsedLeave = ((LeaveOverViewEXT)DTO).UsedLeave;
                    _BalanceLeave = ((LeaveOverViewEXT)DTO).BalanceLeave;
                    _LeaveType = ((LeaveOverViewEXT)DTO).LeaveType;
                    _LeaveRequested = ((LeaveOverViewEXT)DTO).LeaveRequested;
                    _EmployeeName = ((LeaveOverViewEXT)DTO).EmployeeName;
                    _LeaveID = ((LeaveOverViewEXT)DTO).LeaveID;
                }
            }
           
        }

        public LeaveOverview[] GetLeaveOverview(int EmployeeID)
        {
            return LoadGrid(new Leave_RequestBusinessObject().GetLeaveOverview(EmployeeID));            
        }
        private LeaveOverview[] LoadGrid(LeaveOverViewEXT[] arr)
        {
            LeaveOverview[] LeavesCal = new LeaveOverview[arr.Length];

            for (int h = 0; h < arr.Length; h++)
            {
                LeaveOverview ur = new LeaveOverview();
                ur.Update(arr[h]);
                LeavesCal[h] = ur;
            }
            return LeavesCal;
        }
       
        #region JGridDataObject Members

        public object GetGridData()
        {
            LeaveOverViewDetails DT = new LeaveOverViewDetails();
            DT.EmpID = _ID;
            DT.LeaveType = _LeaveType;
            DT.TotalLeave = _TotalLeave;
            DT.UsedLeave = _UsedLeave;
            DT.BalanceLeave = _BalanceLeave;
            DT.LeaveRequested = _LeaveRequested;
            DT.EmployeeName = _EmployeeName;
            DT.LeaveID = _LeaveID;
            return DT;
        }

        #endregion
    }
    public class LeaveOverViewDetails
    {
        public int ID;
        public int EmpID;
        public String EmployeeName;
        public String LeaveType;
        public Double TotalLeave;
        public Double LeaveRequested;
        public double UsedLeave;
        public Double BalanceLeave;
        public int LeaveID;
    }
}
