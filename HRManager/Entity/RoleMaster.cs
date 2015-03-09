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
    public class RoleMaster : JGridDataObject
    {
        private int _ID;
        private String _RoleName;
        private String _Description;
        private bool _IsActive;
        private bool _IsNew;
        private int _UpdateBy;
        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;
        private String _Menu;

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
        public String RoleName { get { return _RoleName; } set { _RoleName = value; } }
        public String Menu { get { return _Menu; } set { _Menu = value; } }
        public String Description { get { return _Description; } set { _Description = value; } }
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
        public bool Status { get { return _IsActive; } set { _IsActive = value; } }

        /// <summary>
        /// Update the Role field using Master_Role.
        /// </summary>
        /// <param name="Role">Object of Master_Role class</param>
        private void Update(Master_Role Role)
        {
            if (Role != null)
            {
                _ID = Role.ID;
                _RoleName = Role.Role;
                _Description = Role.Description;
                _IsActive = Role.IsActive;
                _IsNew = false;
                _CreatedBy = Role.CreatedBy;
                _ModifiedBy = Role.ModifiedBy;
                _CreatedDate = Role.CreatedDate;
                //_ModifiedDate = Role.ModifiedDate;
                _Menu = Role.Menu;
            }
            else
            {
                _IsNew = true;
            }
        }

        /// <summary>
        /// Consturctor of Role class.
        /// Update Role fields using Master_Role.
        /// </summary>
        /// <param name="Role">Object of Master_Role class</param>
        public RoleMaster(Master_Role Role)
        {
            Update(Role);
        }
        /// <summary>
        /// Consturctor of Role class.
        /// Update Role for given Role field.
        /// </summary>
        /// <param name="RoleName">field contains Role Name</param>
        //public RoleMaster(String Rolename)
        //{
        //    Update(new Master_RoleBusinessObject().GetMasterDetailsByName(Rolename));
        //}
        /// <summary>
        /// Consturctor of Role class.
        /// Update Role fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains Role ID</param>
        public RoleMaster(int ID)
        {
            Master_Role Role = new Master_RoleBusinessObject().GetMaster_Role(ID);

            if (Role == null && ID > 0)
            {
                throw new IRCAException("Invalid Role", ID.ToString());
            }

            Update(Role);
        }
        //kartyek 11.02.2015 for checking Role of HR 

        //public RoleMaster(bool CheckBool, String ColName)
        //{
        //    if(ColName=="HR")
        //        Update(new Master_RoleBusinessObject().GetDesignationByIsHR(CheckBool));
        //    if (ColName == "Finance")
        //        Update(new Master_RoleBusinessObject().GetDesignationByIsFinance(CheckBool));
        //}
        /// <summary>
        /// Consturctor of Role class.
        /// Set variables for new Role.  
        /// </summary>
        public RoleMaster()
        {
            _ID = 0;
            _IsNew = true;
        }
        /// <summary>
        /// Save Role.If new Role it add and in case of edit it update the Role.
        /// </summary>
        /// <returns>empty string</returns>
        private String SaveRole(string Reports, string Permissions)
        {
            Session ss = Session.CreateNewSession();

            try
            {
                ss.BeginTransaction();
                Master_Role Role = new Master_Role();
                Role.ID = _ID;
                Role.Role = _RoleName;
                Role.Description = _Description;
                Role.IsActive = _IsActive;
                Role.ModifiedBy = _ModifiedBy;
                Role.ModifiedDate = DateTime.Now;
                Role.CreatedBy = _CreatedBy;
                Role.CreatedDate = _CreatedDate;
                Role.Menu = _Menu;
                if (_IsNew)
                {
                    Role.CreatedBy = _UpdateBy;
                    Role.CreatedDate = DateTime.Now;
                    Role.ID = new Master_RoleBusinessObject(ss).Create(Role);
                }
                else
                {
                    Role.ID = _ID;
                    new Master_RoleBusinessObject(ss).Update(Role);
                }
                //if (Reports != string.Empty)
                //{
                //if (_ID != 0)
                //{
                //    new Master_RoleBusinessObject().DeleteReports(_ID, ss);
                //}
                string[] ski = Reports.Split('?');
                foreach (string s in ski)
                {
                    string[] words = s.Split(',');
                    if (words[0] != string.Empty)
                    {
                        Assign_EmpRole_DashboardReports objEmp = new Assign_EmpRole_DashboardReports();
                        objEmp.RoleID = Role.ID;
                        objEmp.ReportID = Convert.ToInt32(words[0]);
                        objEmp.CreatedBy = _UpdateBy;
                        objEmp.CreatedDate = DateTime.Now;
                        objEmp.ModifiedDate = DateTime.Now;
                        new Assign_EmpRole_DashboardReportsBusinessObject(ss).Create(objEmp);
                    }
                }
                //}
                ArrayList arrPermitResult;
                if (Permissions != string.Empty)
                {

                    string[] tmpSplitR = { "?" };//Row Splitter
                    string[] tmpSplitC = { "," };//column splitter
                    string[] strRowVals = Permissions.Split(tmpSplitR, StringSplitOptions.RemoveEmptyEntries);
                    arrPermitResult = new ArrayList();
                    if (strRowVals.Length > 0)
                    {
                        string[] strClsVals = null;
                        for (int k = 0; k < strRowVals.Length; k++)
                        {
                            strClsVals = strRowVals[k].Split(tmpSplitC, StringSplitOptions.RemoveEmptyEntries);
                            if (strClsVals != null)
                            {
                                Permissions objPerm;
                                objPerm = new Permissions();
                                objPerm.RoleID = Role.ID;
                                objPerm.FunctionID = int.Parse(strClsVals[0].ToString());
                                objPerm.Apply = bool.Parse(strClsVals[1].ToString() == "No" ? "false" : "true");
                                objPerm.Approvals = bool.Parse(strClsVals[2].ToString() == "No" ? "false" : "true");
                                objPerm.ViewMode = bool.Parse(strClsVals[3].ToString() == "No" ? "false" : "true");
                                objPerm.CreatedBy = _UpdateBy;
                                objPerm.CreatedDate = DateTime.Now;
                                objPerm.ModifiedDate = DateTime.Now;
                                arrPermitResult.Add(objPerm);
                            }
                        }
                        if (arrPermitResult != null)
                        {
                            if (arrPermitResult.Count > 0)
                            {
                                new Master_RoleBusinessObject().AddPermissions(Role.ID, arrPermitResult, ss);
                            }
                        }
                    }
                }
                ss.Commit();
                //if(File.Exists(String.Concat(AppDomain.CurrentDomain.BaseDirectory,"htm\\menu_",Role.ID)))

                DataTable dtFns = new Master_RoleBusinessObject().GetApplicableMenueItems(Role.ID);
                DataRow[] drs = dtFns.Select();

                String[] ModuleNames = new String[drs.Length];
                String[] MenuTitles = new String[drs.Length];
                String[] LinkRefs = new String[drs.Length];

                for (int i = 0; i < drs.Length; i++)
                {
                    ModuleNames[i] = String.Concat(drs[i]["Modulename"]);
                    MenuTitles[i] = String.Concat(drs[i]["Title"]);
                    //LinkRefs[i] = String.Concat("javascript:Menu_onClick(\"", drs[i]["Modulename"], "\",\"", drs[i]["Modulename"], "\")");
                    LinkRefs[i] = String.Concat("Menu_onClick(\"", drs[i]["Modulename"], "\",\"", drs[i]["Modulename"], "\")");

                }

                String menu = IRCAKernel.Menu.ConstructMenu(ModuleNames, MenuTitles, LinkRefs);


                Master_Role Role1 = new Master_RoleBusinessObject().GetMaster_Role(Role.ID);
                if (Role1 != null)
                {
                    Role1.Menu = menu;
                    new Master_RoleBusinessObject().Update(Role1);
                    HRMenu.Instance.SetMenu(Role1.Role, menu);
                }
            }
            catch (Exception ex)
            {
                ss.Rollback();
                //IRCAExceptionHandler.HandleException(
                //    new IRCAException(ex, TitanMasterDef.RoleMessage.ROLE_UPDATE_FAILURE, ID.ToString())
                //    );
                //return TitanMasterDef.RoleMessage.ROLE_UPDATE_FAILURE;
            }
            finally
            {
                ss.Dispose();
            }
            return String.Empty;
        }

        /// <summary>
        /// Save Role.If new Role it add and in case of edit it update the Role.
        /// </summary>
        /// <returns>empty string</returns>
        private String SaveRole(string Reports)
        {
            Session ss = Session.CreateNewSession();

            try
            {
                ss.BeginTransaction();
                Master_Role Role = new Master_Role();
                Role.ID = _ID;
                Role.Role = _RoleName;
                Role.Description = _Description;
                Role.IsActive = _IsActive;
                Role.ModifiedBy = _ModifiedBy;
                Role.ModifiedDate = DateTime.Now;
                Role.CreatedBy = _CreatedBy;
                Role.CreatedDate = _CreatedDate;

                if (_IsNew)
                {
                    Role.CreatedBy = _UpdateBy;
                    Role.CreatedDate = DateTime.Now;
                    Role.ID = new Master_RoleBusinessObject(ss).Create(Role);
                }
                else
                {
                    Role.ModifiedBy = _UpdateBy;
                    Role.ModifiedDate = DateTime.Now;
                    Role.ID = _ID;
                    new Master_RoleBusinessObject(ss).Update(Role);
                }

                ss.Commit();
            }
            catch (Exception ex)
            {
                ss.Rollback();
                //IRCAExceptionHandler.HandleException(
                //    new IRCAException(ex, TitanMasterDef.RoleMessage.ROLE_UPDATE_FAILURE, ID.ToString())
                //    );
                //return TitanMasterDef.RoleMessage.ROLE_UPDATE_FAILURE;
            }
            finally
            {
                ss.Dispose();
            }
            return String.Empty;
        }
        // <summary>
        ///Validate Role for empty and already exist status and then save Role.
        /// </summary>
        /// <returns>String return from the SaveRole method</returns> 
        public String Save(string Reports, string Permissions)
        {
            String Status = Validate();

            if (Status != String.Empty)
            {
                return Status;
            }

            return SaveRole(Reports, Permissions);
        }

        /// <summary>
        /// Validate RoleName for empty and already exist status.
        /// </summary>
        /// <returns>empty string</returns>
        /// 

        private String CheckReference()
        {
            Master_RoleBusinessObject BO = new Master_RoleBusinessObject();

            if (BO.IsRoleReferenced(_ID))
            {
                return HRManagerDefs.RoleMessages.ROLE_REFERED;
            }
            return String.Empty;
        }
        private String Validate()
        {
            Master_RoleBusinessObject RoleBO = new Master_RoleBusinessObject();

            if (_RoleName == String.Empty)
            {
                return HRManagerDefs.RoleMessages.EMPTY_ROLE;
            }
            else if (RoleBO.IsRoleExists(_RoleName, _ID))
            {
                return HRManagerDefs.RoleMessages.ROLE_EXISTS;
            }

            else if (CheckReference() != String.Empty)
            {
                if (!_IsActive)
                {
                    return CheckReference();
                }
            }
            //else if (RoleBO.IsRoleReferenced(ID))
            //{
            //    return string.Format(HRManagerDefs.RoleMessages.ROLE_REFERED);
            //}
            return String.Empty;
        }
        /// <summary>
        /// Activate the Role
        /// </summary>
        /// <param name="ActivatedBy">id of user who want to activate Role</param>
        /// <returns>String return from the SaveRole method</returns>
        public String Activate(int ActivatedBy)
        {
            _UpdateBy = ActivatedBy;
            _IsActive = true;

            return SaveRole(string.Empty);
        }
        /// <summary>
        /// Deactivate the Role
        /// </summary>
        /// <param name="DeActivatedBy">id of user who want to DeActivate Role</param>
        /// <returns>String return from the SaveRole method</returns>
        public String DeActivate(int DeActivatedBy)
        {
            String Status = CheckReference();
            _ModifiedBy = DeActivatedBy;
            if (Status != String.Empty)
            {
                if (new Master_RoleBusinessObject().IsRoleReferenced(ID))
                {
                    return string.Format(HRManagerDefs.RoleMessages.ROLE_REFERED);
                }
                return Status;
            }
            else
            {
                _UpdateBy = DeActivatedBy;
                _IsActive = false;
                return SaveRole(string.Empty);
            }
        }
        /// <summary>
        /// Return all Roles
        /// </summary>
        /// <returns>Array of the object of Role class</returns>
        public static RoleMaster[] GetAllRoles()
        {
            Master_Role[] RolesDT = (Master_Role[])new Master_RoleBusinessObject().GetActiveMasters();

            RoleMaster[] Roles = new RoleMaster[RolesDT.Length];

            for (int i = 0; i < Roles.Length; i++)
            {
                Roles[i] = new RoleMaster(RolesDT[i]);
            }

            return Roles;
        }
        public static RoleMaster[] GetAllRolesDetails()
        {
            Master_Role[] RolesDT = (Master_Role[])new Master_RoleBusinessObject().GetMasterDetails("");

            RoleMaster[] Roles = new RoleMaster[RolesDT.Length];

            for (int i = 0; i < Roles.Length; i++)
            {
                Roles[i] = new RoleMaster(RolesDT[i]);
            }

            return Roles;
        }

        #region JGridDataObject Members

        public object GetGridData()
        {
            RoleDisplayDetails Role = new RoleDisplayDetails();

            Role.ID = _ID;
            Role.Role = _RoleName;
            Role.Description = _Description;
            Role.Status = _IsActive;
            Role.IsActive = _IsActive;

            return Role;
        }

        #endregion

        #region MasterInf Members


        public void Update(object DTO)
        {
            if (DTO != null)
            {
                Master_Role TmpDTO = (Master_Role)DTO;

                _ID = TmpDTO.ID;
                _RoleName = TmpDTO.Role;
                _Description = TmpDTO.Description;
                _IsActive = TmpDTO.IsActive;
                _CreatedBy = TmpDTO.CreatedBy;
                _CreatedDate = TmpDTO.CreatedDate;
            }
        }

        public string Save()
        {
            throw new NotImplementedException();
        }
        //public override ComboBoxValues GetComboBox()
        //{
        //    return new ComboBoxValues()
        //    {
        //        ID = _ID,
        //        Value = _RoleName
        //    };
        //}
        #endregion
        
        internal static RoleMaster[] GetAllInActiveRoles()
        {
            Master_Role[] RolesDT = (Master_Role[])new Master_RoleBusinessObject().GetInActiveMasters();

            RoleMaster[] Roles = new RoleMaster[RolesDT.Length];

            for (int i = 0; i < Roles.Length; i++)
            {
                Roles[i] = new RoleMaster(RolesDT[i]);
            }

            return Roles;
        }
    }
    public class RoleDisplayDetails
    {
        public int ID;
        public String Role;
        public String Description;
        public bool IsActive;
        public bool Status;        
    }
      //public RoleDisplayDetails(int ID)
      //  {
      //      Employees Employees = new Master_EmployeesBusinessObject().GetEmployees(ID);

      //      if (Employees == null && ID > 0)
      //      {
      //          throw new IRCAException("Invalid Employee", ID.ToString());
      //      }

      //      Update(Employees);
      //  }
}
