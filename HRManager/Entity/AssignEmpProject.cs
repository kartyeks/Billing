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
    /// Represents Project fields and methods.
    /// </summary>
    public class AssignEmpProject : JGridDataObject
    {
        private int _ID;
        private int _EmpID;
        private int _ProjectID;
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

        public int ProjectID
        {
            get
            {
                return _ProjectID;
            }
            set
            {
                _ProjectID = value;
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
        private void Update(Assign_Emp_Project AssignEmpProject)
        {
            if (AssignEmpProject != null)
            {
                _ID = AssignEmpProject.ID;
                _EmpID = AssignEmpProject.EmpID;
                _ProjectID = AssignEmpProject.ProjectID;
                _IsActive = AssignEmpProject.IsActive;
                _ActivatedDate = AssignEmpProject.ActivatedDate;
                _IsNew = false;
                _CreatedBy = AssignEmpProject.CreatedBy;
                _ModifiedBy = AssignEmpProject.ModifiedBy;
                _CreatedDate = AssignEmpProject.CreatedDate;
                _ModifiedDate = AssignEmpProject.ModifiedDate;
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
        public AssignEmpProject(Assign_Emp_Project AssignEmpProject)
        {
            Update(AssignEmpProject);
        }

        /// <summary>
        /// Consturctor of Designation class.
        /// Update Designation fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains Project ID</param>
        public AssignEmpProject(int ID)
        {
            Assign_Emp_Project EmpProject = new Assign_Emp_ProjectBusinessObject().GetAssign_Emp_Project(ID);

            if (EmpProject == null && ID > 0)
            {
                throw new IRCAException("Invalid Project", ID.ToString());
            }

            Update(EmpProject);
        }

        
        /// <summary>
        /// Consturctor of Location class.
        /// Update Location fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains project ID</param>
        public AssignEmpProject(int ID,int empID)
        {
            EmployeeOccupationDetails Employees = new Master_EmployeesBusinessObject().GetProjectEmployees(empID);

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
        private void Update(AssignEmpProject Employees)
        {
            if (Employees != null)
            {
                _ID = Employees.ID;
                _ProjectID = Employees.ProjectID;
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
        public AssignEmpProject()
        {
            _ID = 0;
            _IsNew = true;
        }
        /// <summary>
        /// Save Designation.If new Designation it add and in case of edit it update the Designation.
        /// </summary>
        /// <returns>empty string</returns>
        private String SaveAssignEmpProject(Session DBSession)
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
            if (EmpBO.SetProjectIsActiveFalse(_EmpID) || _ID == 0)
            {
                Assign_Emp_Project EmpProject = new Assign_Emp_Project();
                EmpProject.ID = _ID;
                EmpProject.EmpID = _EmpID;
                EmpProject.ProjectID = _ProjectID;
                EmpProject.IsActive = _IsActive;
                EmpProject.ActivatedDate = _ActivatedDate;
                EmpProject.ModifiedBy = _ModifiedBy;
                EmpProject.ModifiedDate = DateTime.Now;
                EmpProject.CreatedBy = _CreatedBy;
                EmpProject.CreatedDate = _CreatedDate;

                if (_IsNew)
                {
                    EmpProject.CreatedBy = _UpdateBy;
                    EmpProject.CreatedDate = DateTime.Now;
                    EmpProject.ID = new Assign_Emp_ProjectBusinessObject(DBSession).Create(EmpProject);
                }
                else
                {
                    EmpProject.ModifiedBy = _UpdateBy;
                    EmpProject.ModifiedDate = DateTime.Now;
                    EmpProject.ID = _ID;
                    new Assign_Emp_ProjectBusinessObject(DBSession).Update(EmpProject);
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

            return SaveAssignEmpProject(DBSession);
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
        public static AssignEmpProject[] GetAllAssignEmpProject()
        {
            Assign_Emp_Project[] AssignEmpProjectDT = new Assign_Emp_ProjectBusinessObject().GetAssign_Emp_Project();

            AssignEmpProject[] AssignEmpProject = new AssignEmpProject[AssignEmpProjectDT.Length];

            for (int i = 0; i < AssignEmpProject.Length; i++)
            {
                AssignEmpProject[i] = new AssignEmpProject(AssignEmpProjectDT[i]);
            }

            return AssignEmpProject;
        }
        public String Save()
        {
            try
            {
                Assign_Emp_ProjectBusinessObject BO = new Assign_Emp_ProjectBusinessObject();
                Assign_Emp_Project DTO = GetDTO();

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
        private Assign_Emp_Project GetDTO()
        {
            Assign_Emp_Project DTO = new Assign_Emp_Project();
            DTO.ID = _ID;
            DTO.EmpID = _EmpID;
            DTO.ProjectID = _ProjectID;
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
            AssignEmpProjectDetails EmpProject = new AssignEmpProjectDetails();

            EmpProject.ID = _ID;
            EmpProject.EmpID = _EmpID;
            EmpProject.ProjectID = _ProjectID;
            EmpProject.IsActive = _IsActive;
            EmpProject.ActivatedDate = _ActivatedDate;

            return EmpProject;
        }

        #endregion

    }
    public class AssignEmpProjectDetails
    {
        public int ID;
        public int EmpID;
        public int ProjectID;
        public DateTime ActivatedDate;
        public bool IsActive;
    }
}
