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
    public class Permission : JGridDataObject
    {
        private int _FunctionID;
        private int _RoleID;
        private String _Category;
        private String _Title;

        private bool _Apply;
        private bool _Approvals;
        private bool _ViewMode;
        private bool _IsNew;
        private int _UpdateBy;
        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;
        private String _FunctionName;

        public int FunctionID
        {
            get
            {
                return _FunctionID;
            }
            set
            {
                _FunctionID = value;
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
        public String FunctionName
        {
            get
            {
                return _FunctionName;
            }
            set
            {
                _FunctionName = value;
            }
        }
        public String Category
        {
            get
            {
                return _Category;
            }
            set
            {
                _Category = value;
            }
        }
        public String Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
            }
        }

        public bool Apply
        {
            get
            {
                return _Apply;
            }
            set
            {
                _Apply = value;
            }
        }
        public bool Approvals
        {
            get
            {
                return _Approvals;
            }
            set
            {
                _Approvals = value;
            }
        }
        public bool ViewMode
        {
            get
            {
                return _ViewMode;
            }
            set
            {
                _ViewMode = value;
            }
        }

        public int UpdatedBy
        {
            get { return _UpdateBy; }
            set { _UpdateBy = value; }
        }
        public int CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }
        public int ModifiedBy
        {
            get { return _ModifiedBy; }
            set { _ModifiedBy = value; }
        }

        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }
        public DateTime ModifiedDate
        {
            get { return _ModifiedDate; }
            set { _ModifiedDate = value; }
        }

        /// <summary>
        /// Update the Grade field using Hr_Grade.
        /// </summary>
        /// <param name="Grade">Object of Hr_Grade class</param>
        private void Update(Permission Permiss)
        {
            if (Permiss != null)
            {
                _FunctionID = Permiss.FunctionID;
                _RoleID = Permiss.RoleID;
                _FunctionName = Permiss.FunctionName;
                _Category = Permiss.Category;
                _Title = Permiss.Title;
                _Apply = Permiss.Apply;
                _Approvals = Permiss.Approvals;
                _ViewMode = Permiss.ViewMode;
                _CreatedBy = Permiss.CreatedBy;
                _ModifiedBy = Permiss.ModifiedBy;
                _CreatedDate = Permiss.CreatedDate;
                _ModifiedDate = Permiss.ModifiedDate;
                _IsNew = false;
            }
            else
            {
                _IsNew = true;
            }
        }
        /// <summary>
        /// Consturctor of Grade class.
        /// Update Grade fields using Hr_Grade.
        /// </summary>
        /// <param name="Grade">Object of Hr_Grade class</param>
        public Permission(Permission Permis)
        {
            Update(Permis);
        }
        /// <summary>
        /// Consturctor of Grade class.
        /// Set variables for new Grade.  
        /// </summary>
        public Permission()
        {
            _FunctionID = 0;
            _IsNew = true;
        }
        /// <summary>
        /// Save Grade.If new Grade it add and in case of edit it update the Grade.
        /// </summary>
        /// <returns>empty string</returns>
        private String SavePermission()
        {

            Permissions Permiss = new Permissions();
            Permiss.FunctionID = _FunctionID;
            Permiss.RoleID = _RoleID;
            Permiss.Apply = _Apply;
            Permiss.Approvals = _Approvals;
            Permiss.ViewMode = _ViewMode;
            Permiss.CreatedBy = _CreatedBy;
            Permiss.CreatedDate = _CreatedDate;
            Permiss.ModifiedBy = _ModifiedBy;
            Permiss.ModifiedDate = DateTime.Now;

            if (_IsNew)
            {
                Permiss.CreatedBy = _UpdateBy;
                Permiss.CreatedDate = DateTime.Now;

                new PermissionsBusinessObject().Create(Permiss);
            }
            else
            {
                Permiss.ModifiedBy = _UpdateBy;
                Permiss.ModifiedDate = DateTime.Now;

                new PermissionsBusinessObject().Update(Permiss);
            }

            return String.Empty;
        }
        /// <summary>
        ///Validate Grade for empty and already exist status and then save Grade.
        /// </summary>
        /// <returns>String return from the SaveGrade method</returns> 
        public String Save()
        {
            return SavePermission();
        }
        /// <summary>
        /// Return all Location
        /// </summary>
        /// <returns>Array of the object of Location class</returns>
        public static Permission[] GetAllPermissions(int RoleID)
        {
            Permission[] PermissionDT = new Master_RoleBusinessObject().GetAllPermissions(RoleID);

            Permission[] Permiss = new Permission[PermissionDT.Length];

            for (int i = 0; i < Permiss.Length; i++)
            {
                Permiss[i] = new Permission(PermissionDT[i]);
            }

            return Permiss;
        }

        /// <summary>
        /// Return all Location
        /// </summary>
        /// <returns>Array of the object of Location class</returns>
        /// <summary>
        /// Return all Location
        /// </summary>
        /// <returns>Array of the object of Location class</returns>
        public static Permission[] GetRoleWisePermissionInfo(int RoleID)
        {
            Permission[] Permiss = new Master_RoleBusinessObject().GetRoleWisePermissionInfo(RoleID);

            return Permiss;
        }
        /// <summary>
        /// Return all Location
        /// </summary>
        /// <returns>Array of the object of Location class</returns>
        /// <summary>
        /// Return all Location
        /// </summary>
        /// <returns>Array of the object of Location class</returns>
        public static Permission GetAssignedPermissions(string FunctionName, int EmployeeID)
        {
            int functionID = 0;
            functionID = new Master_RoleBusinessObject().GetFunctionIdByModuleName(FunctionName);
            int roleid = 0;
            roleid = new Master_RoleBusinessObject().GetRoleID(EmployeeID);
            //roleid = objCurrUser.GroupName;
            Permission Permiss = new Master_RoleBusinessObject().GetAssignedPermissions(functionID, roleid);

            return Permiss;
        }
        #region JGridDataObject Members

        public object GetGridData()
        {
            PermisDetails Permiss = new PermisDetails();

            Permiss.FunctionID = _FunctionID;
            Permiss.FuncationName = _FunctionName;
            Permiss.Category = _Category;
            Permiss.Title = _Title;
            Permiss.Apply = _Apply;
            Permiss.Approvals = _Approvals;
            Permiss.ViewMode = _ViewMode;
            return Permiss;
        }

        #endregion
    }
    public class PermisDetails
    {
        public int FunctionID;
        public String FuncationName;
        public String Category;
        public String Title;
        public bool Apply;
        public bool Approvals;
        public bool ViewMode;

    }
}
