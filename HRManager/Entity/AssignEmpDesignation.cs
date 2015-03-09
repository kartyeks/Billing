using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;

using IS91.Services.DataBlock;
using IRCA.Communication;
using HRManager.Entity.EmployeesInfo;

namespace HRManager.Entity
{
    /// <summary>
    /// Represents Designation fields and methods.
    /// </summary>
    public class AssignEmpDesignation : JGridDataObject
    {
        private int _ID;
        private int _EmpID;
        private int _DesignationID;
        private bool _IsActive;
        private DateTime _ActivatedDate;
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

        public int EmpID
        {
            get
            {
                return _EmpID;
            }
            set
            {
                _EmpID = value;
            }
        }

        public int DesignationID
        {
            get
            {
                return _DesignationID;
            }
            set
            {
                _DesignationID = value;
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

        public DateTime ActivatedDate
        {
            get
            {
                return _ActivatedDate;
            }
            set
            {
                _ActivatedDate = value;
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
        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }
        public int ModifiedBy
        {
            get { return _ModifiedBy; }
            set { _ModifiedBy = value; }
        }
        public DateTime ModifiedDate
        {
            get { return _ModifiedDate; }
            set { _ModifiedDate = value; }
        }

        /// <summary>
        /// Update the Designation field using Hr_Designation.
        /// </summary>
        /// <param name="Designation">Object of Hr_Designation class</param>
        private void Update(Assign_Emp_Designation AssignEmpDesignation)
        {
            if (AssignEmpDesignation != null)
            {
                _ID = AssignEmpDesignation.ID;
                _EmpID = AssignEmpDesignation.EmpID;
                _DesignationID = AssignEmpDesignation.DesignationID;
                _IsActive = AssignEmpDesignation.IsActive;
                _ActivatedDate = AssignEmpDesignation.ActivatedDate;
                _IsNew = false;
                _CreatedBy = AssignEmpDesignation.CreatedBy;
                _ModifiedBy = AssignEmpDesignation.ModifiedBy;
                _CreatedDate = AssignEmpDesignation.CreatedDate;
                _ModifiedDate = AssignEmpDesignation.ModifiedDate;
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
        public AssignEmpDesignation(Assign_Emp_Designation AssignEmpDesignation)
        {
            Update(AssignEmpDesignation);
        }

        /// <summary>
        /// Consturctor of Designation class.
        /// Update Designation fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains Designation ID</param>
        public AssignEmpDesignation(int ID)
        {
            Assign_Emp_Designation EmpDesignation = new Assign_Emp_DesignationBusinessObject().GetAssign_Emp_Designation(ID);

            if (EmpDesignation == null && ID > 0)
            {
                throw new IRCAException("Invalid Designation", ID.ToString());
            }

            Update(EmpDesignation);
        }

        
        /// <summary>
        /// Consturctor of Location class.
        /// Update Location fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains Location ID</param>
        public AssignEmpDesignation(int ID,int empID)
        {
            EmployeeOccupationDetails Employees = new Master_EmployeesBusinessObject().GetDesignationEmployees(empID);

            if (Employees == null && ID > 0)
            {
                throw new IRCAException("Invalid Employee", empID.ToString());
            }

         //   Update(Employee);
        }

        /// <summary>
        /// Update the Location field using Master_LocationName.
        /// </summary>
        /// <param name="Location">Object of Master_LocationName class</param>
        private void Update(AssignEmpDesignation Employees)
        {
            if (Employees != null)
            {
                _ID = Employees.ID;
                _DesignationID = Employees.DesignationID;
                _EmpID = Employees.EmpID;
                _IsActive = Employees.IsActive;
                _ActivatedDate = Employees.ActivatedDate;
                _IsNew = false;
                _CreatedBy = Employees.CreatedBy;
                _ModifiedBy = Employees.ModifiedBy;
                _CreatedDate = Employees.CreatedDate;
                _ModifiedDate = Employees.ModifiedDate;

            }
            else
            {
                _IsNew = true;
            }
        }

        /// <summary>
        /// Consturctor of Designation class.
        /// Set variables for new Designation.  
        /// </summary>
        public AssignEmpDesignation()
        {
            _ID = 0;
            _IsNew = true;
        }
        /// <summary>
        /// Save Designation.If new Designation it add and in case of edit it update the Designation.
        /// </summary>
        /// <returns>empty string</returns>
        private String SaveAssignEmpDesignation(Session DBSession)
        {
             bool IsLocalSession = false;

            if (DBSession == null)
            {
                IsLocalSession = true;

                DBSession = Session.CreateNewSession();

                DBSession.BeginTransaction();
            }
            try
            {
            Master_EmployeesBusinessObject EmpBO = new Master_EmployeesBusinessObject();
            if (EmpBO.SetDesignationIsActiveFalse(_EmpID) || _ID==0)
            {
                Assign_Emp_Designation EmpDesignation = new Assign_Emp_Designation();
                EmpDesignation.ID = _ID;
                EmpDesignation.EmpID = _EmpID;
                EmpDesignation.DesignationID = _DesignationID;
                EmpDesignation.IsActive = _IsActive;
                EmpDesignation.ActivatedDate = _ActivatedDate;
                EmpDesignation.ModifiedBy = _ModifiedBy;
                EmpDesignation.ModifiedDate = DateTime.Now;
                EmpDesignation.CreatedBy = _CreatedBy;
                EmpDesignation.CreatedDate = _CreatedDate;

                if (_IsNew)
                {
                    EmpDesignation.CreatedBy = _UpdateBy;
                    EmpDesignation.CreatedDate = DateTime.Now;
                    EmpDesignation.ID = new Assign_Emp_DesignationBusinessObject(DBSession).Create(EmpDesignation);
                }
                else
                {
                    EmpDesignation.ModifiedBy = _UpdateBy;
                    EmpDesignation.ModifiedDate = DateTime.Now;
                    EmpDesignation.ID = _ID;
                    new Assign_Emp_DesignationBusinessObject(DBSession).Update(EmpDesignation);
                }
            }
            else 
            {
                return "Error Update IsActive";
            }
            if (IsLocalSession)
            {
                DBSession.Commit();
            }
            }
            catch (Exception e)
            {
                if (IsLocalSession)
                {
                    DBSession.Rollback();
                }

                throw e;
            }
            finally
            {
                if (IsLocalSession)
                {
                    DBSession.Dispose();
                }
            }
            return String.Empty;
        }
        /// <summary>
        /// Validate Designation for empty and already exist status and then save Designation.
        /// </summary>
        /// <returns>String return from the SaveDesignation method</returns> 

        public String Save(Session DBSession)
        {
            String Status = Validate();

            if (Status != String.Empty)
            {
                return Status;
            }

            return SaveAssignEmpDesignation(DBSession);
        }
        /// <summary>
        /// Validate DesignationName for empty and already exist status.
        /// </summary>
        /// <returns>empty string</returns>
        private String Validate()
        {
            return String.Empty;
        }

        /// <summary>
        /// Return all Designations
        /// </summary>
        /// <returns>Array of the object of Designation class</returns>
        public static AssignEmpDesignation[] GetAllAssignEmpDesignation()
        {
            Assign_Emp_Designation[] AssignEmpDesignationDT = new Assign_Emp_DesignationBusinessObject().GetAssign_Emp_Designation();

            AssignEmpDesignation[] AssignEmpDesignation = new AssignEmpDesignation[AssignEmpDesignationDT.Length];

            for (int i = 0; i < AssignEmpDesignation.Length; i++)
            {
                AssignEmpDesignation[i] = new AssignEmpDesignation(AssignEmpDesignationDT[i]);
            }

            return AssignEmpDesignation;
        }
        public String Save()
        {
            try
            {
                Assign_Emp_DesignationBusinessObject BO = new Assign_Emp_DesignationBusinessObject();
                Assign_Emp_Designation DTO = GetDTO();

                if (_ID != 0)
                {
                    BO.Update(DTO);
                }
                else
                {
                    _ID = BO.Create(DTO);
                }

                return String.Empty;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(ex);
                return ex.Message;
            }
        }
        private Assign_Emp_Designation GetDTO()
        {
            Assign_Emp_Designation DTO = new Assign_Emp_Designation();
            DTO.ID = _ID;
            DTO.EmpID = _EmpID;
            DTO.DesignationID = _DesignationID;
            DTO.IsActive = _IsActive;
            DTO.ActivatedDate = _ActivatedDate;
            DTO.ModifiedBy = _ModifiedBy;
            DTO.ModifiedDate = DateTime.Now;
            DTO.CreatedBy = _CreatedBy;
            DTO.CreatedDate = _CreatedDate;
            if (_ID == 0)
            {
                DTO.CreatedBy = _CreatedBy;
                DTO.CreatedDate = DateTime.Now;
            }
            DTO.ModifiedBy = _ModifiedBy;
            DTO.ModifiedDate = DateTime.Now;

            return DTO;
        }

        #region JGridDataObject Members

        public object GetGridData()
        {
            AssignEmpDesignationDetails EmpDesignation = new AssignEmpDesignationDetails();

            EmpDesignation.ID = _ID;
            EmpDesignation.EmpID = _EmpID;
            EmpDesignation.DesignationID = _DesignationID;
            EmpDesignation.IsActive = _IsActive;
            EmpDesignation.ActivatedDate = _ActivatedDate;

            return EmpDesignation;
        }

        #endregion

    }
    public class AssignEmpDesignationDetails
    {
        public int ID;
        public int EmpID;
        public int DesignationID;
        public DateTime ActivatedDate;
        public bool IsActive;
    }
}
