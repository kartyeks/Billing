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
    /// Represents Department fields and methods.
    /// </summary>
    public class Department : JTreeDataObject
    {
        private int _ID;
        private String _DepartmentName;
        private int _ParentID;
        private String _Description;
        private bool _IsDepartment;
        private bool _IsActive;
        private bool _IsNew;
        private int _UpdateBy;
        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;
        private int _HOD;
        private bool _IsHR;
        private bool _IsFinance;


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
        public int HOD
        {
            get
            {
                return _HOD;
            }
            set
            {
                _HOD = value;
            }
        }

        public String DepartmentName
        {
            get
            {
                return _DepartmentName;
            }
            set
            {
                _DepartmentName = value;
            }
        }

        public int ParentID
        {
            get
            {
                return _ParentID;
            }
            set
            {
                _ParentID = value;
            }
        }

        public String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        public bool IsDepartment
        {
            get
            {
                return _IsDepartment;
            }
            set
            {
                _IsDepartment = value;
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
        public bool IsHR
        {
            get
            {
                return _IsHR;
            }
            set
            {
                _IsHR = value;
            }
        }
        public bool IsFinance
        {
            get
            {
                return _IsFinance;
            }
            set
            {
                _IsFinance = value;
            }
        }
        public int UpdatedBy
        {
            get { return _UpdateBy; }
            set { _UpdateBy = value; }
        }
        /// <summary>
        /// Update the Department field using Hr_Department.
        /// </summary>
        /// <param name="Department">Object of Hr_Department class</param>
        private void Update(Hr_Department Department)
        {
            if (Department != null)
            {
                _ID = Department.ID;
                _DepartmentName = Department.DepartmentName;
                _ParentID = Department.ParentID;
                _Description = Department.Description;
                _IsDepartment = Department.IsDepartment;
                _IsActive = Department.IsActive;
                _IsNew = false;
                _CreatedBy = Department.CreatedBy;
                _ModifiedBy = Department.ModifiedBy;
                _CreatedDate = Department.CreatedDate;
                _ModifiedDate = Department.ModifiedDate;
                _HOD = Department.HOD;
                _IsHR = Department.IsHR;
                _IsFinance = Department.IsFinance;
            }
            else
            {
                _IsNew = true;
            }
        }
        /// <summary>
        /// Consturctor of Department class.
        /// Update Department fields using Hr_Department.
        /// </summary>
        /// <param name="Department">Object of Hr_Department class</param>
        public Department(Hr_Department Department)
        {
            Update(Department);
        }

        /// <summary>
        /// Consturctor of Department class.
        /// Update Department for given DepartmentName field.
        /// </summary>
        /// <param name="DepartmentName">field contains Department Name</param>
        public Department(String DepartmentName)
        {
            Update(new Hr_DepartmentBusinessObject().GetDepartmentByDepartment(DepartmentName));
        }
        public Department(bool CheckBool, String ColName)
        {
            if (ColName == "HR")
                Update(new Hr_DepartmentBusinessObject().GetDepartmentByIsHR(CheckBool));
            if (ColName == "Finance")
                Update(new Hr_DepartmentBusinessObject().GetDepartmentByIsFinance(CheckBool));
        }
        /// <summary>
        /// Consturctor of Department class.
        /// Update Department fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains Department ID</param>
        public Department(int ID)
        {
            Hr_Department Department = new Hr_DepartmentBusinessObject().GetHr_Department(ID);

            if (Department == null && ID > 0)
            {
                throw new IRCAException("Invalid Department", ID.ToString());
            }

            Update(Department);
        }
        /// <summary>
        /// Consturctor of Department class.
        /// Set variables for new Department.  
        /// </summary>
        public Department()
        {
            _ID = 0;
            _IsNew = true;
        }
        /// <summary>
        /// Save Department.If new Department it add and in case of edit it update the Department.
        /// </summary>
        /// <returns>empty string</returns>
        private String SaveDepartment()
        {

            Hr_Department Department = new Hr_Department();
            Department.ID = _ID;
            Department.DepartmentName = _DepartmentName;
            Department.Description = null;
            Department.ParentID = _ParentID;
            Department.IsActive = true;
            Department.IsDepartment = true;
            Department.CreatedBy = _CreatedBy;
            Department.CreatedDate = _CreatedDate;
            Department.ModifiedBy = _ModifiedBy;
            Department.ModifiedDate = DateTime.Now;
            Department.HOD = _HOD;
            Department.IsHR = _IsHR;
            Department.IsFinance = _IsFinance;

            if (_IsNew)
            {
                Department.CreatedBy = _UpdateBy;
                Department.CreatedDate = DateTime.Now;
                Department.ID = new Hr_DepartmentBusinessObject().Create(Department);
            }
            else
            {
                Department.ModifiedBy = _UpdateBy;
                Department.ModifiedDate = DateTime.Now;
                Department.ID = _ID;
                new Hr_DepartmentBusinessObject().Update(Department);
            }

            return String.Empty;
        }
        /// <summary>
        /// Validate Department for empty and already exist status and then save Department.
        /// </summary>
        /// <returns>String return from the SaveDepartment method</returns> 

        public String Save()
        {
            String Status = Validate();

            if (Status != String.Empty)
            {
                return Status;
            }

            return SaveDepartment();
        }
        /// <summary>
        /// Validate DepartmentName for empty and already exist status.
        /// </summary>
        /// <returns>empty string</returns>
        private String Validate()
        {
            Hr_DepartmentBusinessObject DepartmentBO = new Hr_DepartmentBusinessObject();

            //if (_DepartmentName!= 'Kurlon')
            if (string.Equals(_DepartmentName, "Kurlon", StringComparison.OrdinalIgnoreCase))
            {
                return HRManagerDefs.DepartmentMessages.ROOT_DEPARTMENT_NOT_ALLOWED;
            }
            else
            {
                if (_DepartmentName == String.Empty)
                {
                    return HRManagerDefs.DepartmentMessages.EMPTY_DEPARTMENT;
                }
                else if (DepartmentBO.IsDepartmentExists(_DepartmentName, _ID))
                {
                    return HRManagerDefs.DepartmentMessages.DEPARTMENT_EXISTS;
                }
            }
            return String.Empty;
        }

        /// <summary>
        /// Activate the Department
        /// </summary>
        /// <param name="ActivatedBy">id of user who want to activate Department</param>
        /// <returns>String return from the SaveDepartment method</returns>
        public String Activate(int ActivatedBy)
        {
            _UpdateBy = ActivatedBy;
            _IsActive = true;

            return SaveDepartment();
        }
        /// <summary>
        /// Deactivate the Department
        /// </summary>
        /// <param name="DeActivatedBy">id of user who want to DeActivate Department</param>
        /// <returns>Array of the object of Department class</returns>
        public String DeActivate(int DeActivatedBy)
        {
            _UpdateBy = DeActivatedBy;
            _IsActive = false;

            return SaveDepartment();
        }
        /// <summary>
        /// Return all Departments
        /// </summary>
        /// <returns>Array of the object of Department class</returns>
        public static Department[] GetAllDepartments()
        {
            Hr_Department[] DepartmentsDT = new Hr_DepartmentBusinessObject().GetHr_DepartmentAsec();

            Department[] Departments = new Department[DepartmentsDT.Length];

            for (int i = 0; i < Departments.Length; i++)
            {
                Departments[i] = new Department(DepartmentsDT[i]);
            }

            return Departments;
        }
        /// <summary>
        /// Return all Departments
        /// </summary>
        /// <returns>Array of the object of Department class</returns>
        public static Department[] GetAllBranchDepartments(int BranchID)
        {
            Hr_Department[] DepartmentsDT = new Hr_DepartmentBusinessObject().GetHr_DepartmentAsecBranchWise(BranchID);

            Department[] Departments = new Department[DepartmentsDT.Length];

            for (int i = 0; i < Departments.Length; i++)
            {
                Departments[i] = new Department(DepartmentsDT[i]);
            }

            return Departments;
        }
        public static int getChildCount(int ParentID)
        {
            return new Hr_DepartmentBusinessObject().GetAllActiveDepartmentChildCount(ParentID);
        }

        #region JTreeDataObject Members

        public int GetID()
        {
            return _ID + 1;
        }

        public int GetParentID()
        {
            if (_ParentID != 0)
                return _ParentID + 1;
            else return _ParentID;
        }

        public string GetName()
        {
            return _DepartmentName;
        }

        public bool GetLeaf()
        {
            int childCount = getChildCount(_ID);
            if (childCount == 0)
                return true;
            else
                return false;
        }

        #endregion

    }
}
