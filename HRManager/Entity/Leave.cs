using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IRCA.Communication;

namespace HRManager.Entity
{
    /// <summary>
    /// Represents Designation fields and methods.
    /// </summary>
    public class Leave : JGridDataObject
    {

        private int _ID;
        private string _LeaveType;
        private bool _IsActive;
        private bool _IsNew;
        private int _UpdateBy;
        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;


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

        public String LeaveType
        {
            get
            {
                return _LeaveType;
            }
            set
            {
                _LeaveType = value;
            }
        }


        public bool IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                _IsActive = value;
            }
        }
        public int UpdatedBy
        {
            get { return _UpdateBy; }
            set { _UpdateBy = value; }
        }

        //public int UpdatedBy
        //{
        //    get { return _UpdateBy; }
        //    set { _UpdateBy = value; }
        //}
        /// <summary>
        /// Update the Designation field using Hr_Designation.
        /// </summary>
        /// <param name="Designation">Object of Hr_Designation class</param>
        private void Update(Master_Leave Leave)
        {
            if (Leave != null)
            {
                _ID = Leave.ID;
                _LeaveType = Leave.LeaveType;
                _IsActive = Leave.IsActive;
                _IsNew = false;
                _CreatedBy = Leave.CreatedBy;
                _ModifiedBy = Leave.ModifiedBy;
                _CreatedDate = Leave.CreatedDate;
                _ModifiedDate = Leave.ModifiedDate;
            }
            else
            {
                _IsNew = true;
            }
        }
        /// <summary>
        /// Consturctor of Designation class.
        /// Update Designation fields using Hr_Designation.
        /// </summary>
        /// <param name="Designation">Object of Hr_Designation class</param>
        public Leave(Master_Leave Leave)
        {
            Update(Leave);
        }

        /// <summary>
        /// Consturctor of Designation class.
        /// Update Designation for given DesignationName field.
        /// </summary>
        /// <param name="DesignationName">field contains Designation Name</param>
        public Leave(String LeaveType)
        {
            Update(new Master_LeaveBusinessObject().GetLeaveByLeave(LeaveType));
        }
        /// <summary>
        /// Consturctor of Designation class.
        /// Update Designation fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains Designation ID</param>
        public Leave(int ID)
        {
            Master_Leave Leave = new Master_LeaveBusinessObject().GetMaster_Leave(ID);

            if (Leave == null && ID > 0)
            {
                throw new IRCAException("Invalid Leave", ID.ToString());
            }

            Update(Leave);
        }
        /// <summary>
        /// Consturctor of Designation class.
        /// Set variables for new Designation.  
        /// </summary>
        public Leave()
        {
            _ID = 0;
            _IsNew = true;
        }
        /// <summary>
        /// Save Designation.If new Designation it add and in case of edit it update the Designation.
        /// </summary>
        /// <returns>empty string</returns>
        private String SaveLeave()
        {

            Master_Leave Leave = new Master_Leave();
            Leave.ID = _ID;
            Leave.LeaveType = _LeaveType;
            Leave.IsActive = _IsActive;
            Leave.ModifiedBy = _ModifiedBy;
            Leave.ModifiedDate = DateTime.Now;
            Leave.CreatedBy = _CreatedBy;
            Leave.CreatedDate = _CreatedDate;

            if (_IsNew)
            {
                Leave.CreatedBy = _UpdateBy;
                Leave.CreatedDate = DateTime.Now;
                Leave.ID = new Master_LeaveBusinessObject().Create(Leave);
            }
            else
            {
                Leave.ModifiedBy = _UpdateBy;
                Leave.ModifiedDate = DateTime.Now;
                Leave.ID = _ID;
                new Master_LeaveBusinessObject().Update(Leave);
            }

            return String.Empty;
        }
        /// <summary>
        /// Validate Designation for empty and already exist status and then save Designation.
        /// </summary>
        /// <returns>String return from the SaveDesignation method</returns> 

        public String Save()
        {
            String Status = Validate();

            if (Status != String.Empty)
            {
                return Status;
            }

            return SaveLeave();
        }
        /// <summary>
        /// Validate DesignationName for empty and already exist status.
        /// </summary>
        /// <returns>empty string</returns>
        private String Validate()
        {
            Master_LeaveBusinessObject LeaveBO = new Master_LeaveBusinessObject();

            if (_LeaveType == String.Empty)
            {
                return HRManagerDefs.LeaveMessages.EMPTY_LEAVE;
            }
            else if (LeaveBO.IsLeaveExists(_LeaveType, _ID))
            {
                return HRManagerDefs.LeaveMessages.LEAVE_EXISTS;
            }
            else if (CheckReference() != String.Empty)
            {
                if (!_IsActive)
                {
                    return CheckReference();
                }
            }
            return String.Empty;
        }

        /// <summary>
        /// Activate the Designation
        /// </summary>
        /// <param name="ActivatedBy">id of user who want to activate designation</param>
        /// <returns>String return from the SaveDesignation method</returns>
        public String Activate(int ActivatedBy)
        {
            _UpdateBy = ActivatedBy;
            _IsActive = true;

            return SaveLeave();
        }
        ///// <summary>
        ///// Return all LocationTypes
        ///// </summary>
        ///// <returns>Array of the object of LocationTypes class</returns>
        public static Leave[] GetAllLeaveforCombo()
        {
            Master_Leave[] LeaveDT = new Master_LeaveBusinessObject().GetAllLeaveForCombo();

            Leave[] Leave = new Leave[LeaveDT.Length];

            for (int i = 0; i < Leave.Length; i++)
            {
                Leave[i] = new Leave(LeaveDT[i]);
            }

            return Leave;
        }
        /// <summary>
        /// Deactivate the LeaveType
        /// </summary>
        /// <param name="DeActivatedBy">id of user who want to DeActivate LeaveType</param>
        /// <returns>Array of the object of Designation class</returns>
        public String DeActivate(int DeActivatedBy)
        {
            String Status = CheckReference();
            _UpdateBy = DeActivatedBy;
            if (Status != String.Empty)
            {
                return Status;
            }
            else
            {
                _IsActive = false;

                return Save();
            }
        }
        private String CheckReference()
        {
            Master_LeaveBusinessObject LeaveBO = new Master_LeaveBusinessObject();

            if (LeaveBO.IsLeaveRefered(_ID))
            {
                return HRLeaveManagerDefs.Leave.LEAVE_REFERED;
            }
            return String.Empty;
        }
        /// <summary>
        /// Return all LeaveType
        /// </summary>
        /// <returns>Array of the object of Leave class</returns>
        public static Leave[] GetAllLeaves()
        {
            Master_Leave[] LeavesDT = new Master_LeaveBusinessObject().GetAllLeaves();

            Leave[] Leaves = new Leave[LeavesDT.Length];

            for (int i = 0; i < Leaves.Length; i++)
            {
                Leaves[i] = new Leave(LeavesDT[i]);
            }

            return Leaves;
        }
        /// <summary>
        /// Return all LeaveType
        /// </summary>
        /// <returns>Array of the object of LeaveType class</returns>
        public static Leave[] GetAllInActiveLeaves()
        {
            Master_Leave[] LeavesDT = new Master_LeaveBusinessObject().GetAllInActiveLeavesOrderByLeave();

            Leave[] Leaves = new Leave[LeavesDT.Length];

            for (int i = 0; i < Leaves.Length; i++)
            {
                Leaves[i] = new Leave(LeavesDT[i]);
            }

            return Leaves;
        }

        /// <summary>
        /// Return all LeaveType
        /// </summary>
        /// <returns>Array of the object of LeaveType class</returns>
        public static Leave[] GetActiveLeaves()
        {
            Master_Leave[] LeavesDT = new Master_LeaveBusinessObject().GetAllActiveLeave();

            Leave[] Leaves = new Leave[LeavesDT.Length];

            for (int i = 0; i < Leaves.Length; i++)
            {
                Leaves[i] = new Leave(LeavesDT[i]);
            }

            return Leaves;
        }

        //public static LeaveCalender[] GetActiveLeaveCalender(int EmployeeId)
        //{
        //    LeaveCalender[] LeavesCal = new Master_LeaveBusinessObject().GetAllActiveLeaveCalender(EmployeeId);

        //    return LeavesCal;
        //}
        //public static LeaveCalenderDetails GetActiveLeaveCalenderDetails(int EmployeeId)
        //{
        //    LeaveCalenderDetails LeavesCal = new Master_LeaveBusinessObject().GetActiveLeaveCalenderDetails(EmployeeId);

        //    return LeavesCal;
        //}

        #region JGridDataObject Members

        public object GetGridData()
        {
            LeaveTypeDetails Leave = new LeaveTypeDetails();

            Leave.ID = _ID;
            Leave.LeaveType = _LeaveType;
            Leave.IsActive = _IsActive;

            return Leave;
        }

        #endregion

    }
    public class LeaveTypeDetails
    {
        public int ID;
        public string LeaveType;
        public bool IsActive;
    }
    public class LeaveCalender
    {
        public int id;
        public string title;
        public DateTime start;
        public DateTime end;
        //public string LeaveType;
        //public string Status;
        //public string DayCount;
        //public string AppliedManager;
        //public string Reason;
        //public string managerremarks;
    }
    public class LeaveCalenderDetails
    {
        public string LeaveType;
        public string Status;
        public Double DayCount;
        public string AppliedManager;
        public string Reason;
        public string managerremarks;
        public string FunctionalManagerStatus;
        public string FunctionalManager;
    }
}