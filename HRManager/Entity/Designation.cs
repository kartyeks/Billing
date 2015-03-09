
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IRCA.Communication;
using HRManager.DTOEXT;

namespace HRManager.Entity
{
    /// <summary>
    /// Represents Designation fields and methods.
    /// </summary>
    public class Designation : JGridDataObject
    {
        private int _ID;
        
        private int _RoleID;
        private String _DesignationName;
        
        private bool _IsActive;
        private bool _IsNew;
        private int _UpdateBy;
        //private int _CreatedBy;
        //private DateTime _CreatedDate;
        //private int _ModifiedBy;
        //private DateTime _ModifiedDate;
        private String _Role;

        
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
        public String DesignationName
        {
            get
            {
                return _DesignationName;
            }
            set
            {
                _DesignationName = value;
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
        public String Role
        {
            get { return _Role; }
            set { _Role = value; }
        }

        public bool Status
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

        /// <summary>
        /// Update the Designation field using Hr_Designation.
        /// </summary>
        /// <param name="Designation">Object of Hr_Designation class</param>
        private void Update(Hr_Designation Designation)
        {
            if (Designation != null)
            {
                _ID = Designation.ID;
                _RoleID = Designation.RoleID;
                _DesignationName = Designation.Designation;
                _IsActive = Designation.IsActive;
                _IsNew = false;
                //_CreatedBy = Designation.CreatedBy;
                //_ModifiedBy = Designation.ModifiedBy;
                //_CreatedDate = Designation.CreatedDate;
                //_ModifiedDate = Designation.ModifiedDate;

                if (Designation is Master_DesignationEXT)
                {
                    _Role = ((Master_DesignationEXT)Designation).Role;
                }
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
        public Designation(Hr_Designation Designation)
        {
            Update(Designation);
        }


        public Designation(bool CheckBool, String ColName)
        {
            if (ColName == "HR")
                Update(new Hr_DesignationBusinessObject().GetDesignationByIsHR(CheckBool));
            if (ColName == "Finance")
                Update(new Hr_DesignationBusinessObject().GetDesignationByIsFinance(CheckBool));
        }




        /// <summary>
        /// Consturctor of Designation class.
        /// Update Designation for given DesignationName field.
        /// </summary>
        /// <param name="DesignationName">field contains Designation Name</param>
        public Designation(String DesignationName)
        {
            Update(new Hr_DesignationBusinessObject().GetDesignationByDeignation(DesignationName));
        }
        /// <summary>
        /// Consturctor of Designation class.
        /// Update Designation fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains Designation ID</param>
        public Designation(int ID)
        {
            Hr_Designation Designation = new Hr_DesignationBusinessObject().GetHr_Designation(ID);

            if (Designation == null && ID > 0)
            {
                throw new IRCAException("Invalid Designation", ID.ToString());
            }

            Update(Designation);
        }
        /// <summary>
        /// Consturctor of Designation class.
        /// Set variables for new Designation.  
        /// </summary>
        public Designation()
        {
            _ID = 0;
            _IsNew = true;
        }
        /// <summary>
        /// Save Designation.If new Designation it add and in case of edit it update the Designation.
        /// </summary>
        /// <returns>empty string</returns>
        private String SaveDesignation()
        {

            Hr_Designation Designation = new Hr_Designation();
            Designation.ID = _ID;
            Designation.RoleID = _RoleID;
            Designation.Designation = _DesignationName;
            Designation.IsActive = _IsActive;
            //Designation.ModifiedBy = _ModifiedBy;
            //Designation.ModifiedDate = DateTime.Now;
            //Designation.CreatedBy = _CreatedBy;
            //Designation.CreatedDate = _CreatedDate;

            if (_IsNew)
            {
                Designation.CreatedBy = _UpdateBy;
                Designation.CreatedDate = DateTime.Now;
                Designation.ID = new Hr_DesignationBusinessObject().Create(Designation);
            }
            else
            {
                Designation.ModifiedBy = _UpdateBy;
                Designation.ModifiedDate = DateTime.Now;
                Designation.ID = _ID;
                new Hr_DesignationBusinessObject().Update(Designation);
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

            return SaveDesignation();
        }
        /// <summary>
        /// Validate DesignationName for empty and already exist status.
        /// </summary>
        /// <returns>empty string</returns>
        private String Validate()
        {
            Hr_DesignationBusinessObject DesignationBO = new Hr_DesignationBusinessObject(); 
                if (_DesignationName == String.Empty)
                {
                    return HRManagerDefs.DesignationMessages.EMPTY_DESIGNATION;
                }
                else if (DesignationBO.IsDeignationExists(_DesignationName, _ID))
                {
                    return HRManagerDefs.DesignationMessages.DESIGNATION_EXISTS;
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
        public String Activate(int ActivatedBy, int ReportingMgr)
        {
            _UpdateBy = ActivatedBy;
            _IsActive = true;

            return SaveDesignation();
        }
        /// <summary>
        /// Deactivate the Designation
        /// </summary>
        /// <param name="DeActivatedBy">id of user who want to DeActivate designation</param>
        /// <returns>Array of the object of Designation class</returns>
        //public String DeActivate(int DeActivatedBy)
        //{

        //    _UpdateBy = DeActivatedBy;
        //    _IsActive = false;

        //    return SaveDesignation();
        //    //String Status = CheckReference();
        //    //if (Status != String.Empty)
        //    //{
        //    //    return Status;
        //    //}
        //    //else
        //    //{
        //    //    _IsActive = false;
        //    //    _UpdateBy = DeActivatedBy;
        //    //    return SaveDesignation();
        //    //}
        //}
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

                return SaveDesignation();
            }
        }
        private String CheckReference()
        {
            Hr_DesignationBusinessObject DesignationBO = new Hr_DesignationBusinessObject();

            if (DesignationBO.IsDesignationRefered(_ID))
            {
                return HRManagerDefs.DesignationMessages.DESIGNATION_REFERRED;
            }
            return String.Empty;
        }
        /// <summary>
        /// Return all Designations
        /// </summary>
        /// <returns>Array of the object of Designation class</returns>
        public static Designation[] GetAllDesignations()
        {
            Hr_Designation[] DesignationsDT = new Hr_DesignationBusinessObject().GetDesignationOrderByDeignation();

            Designation[] Designations = new Designation[DesignationsDT.Length];

            for (int i = 0; i < Designations.Length; i++)
            {
                Designations[i] = new Designation(DesignationsDT[i]);
            }

            return Designations;
        }
        
           
        /// <summary>
        /// Return all Designations
        /// </summary>
        /// <returns>Array of the object of Designation class</returns>
        public static Designation[] GetAllDesignationForHigher(int ID)
        {
            Hr_Designation[] DesignationsDT = new Hr_DesignationBusinessObject().GetDesignationForHigher(ID);

            Designation[] Designations = new Designation[DesignationsDT.Length];

            for (int i = 0; i < Designations.Length; i++)
            {
                Designations[i] = new Designation(DesignationsDT[i]);
            }

            return Designations;
        }
        public static Designation GetDesignationInfo(int DesgnationID)
        {
            Designation desg = new Hr_DesignationBusinessObject().GetDesignationbyID(DesgnationID);

            return desg;
        }
        /// <summary>
        /// Return all Designations
        /// </summary>
        /// <returns>Array of the object of Designation class</returns>
        public static Designation[] GetAllInActiveDesignations()
        {
            Hr_Designation[] DesignationsDT = new Hr_DesignationBusinessObject().GetAllInActiveDesignations();

            Designation[] Designations = new Designation[DesignationsDT.Length];

            for (int i = 0; i < Designations.Length; i++)
            {
                Designations[i] = new Designation(DesignationsDT[i]);
            }

            return Designations;
        }

        /// <summary>
        /// Return all Designations
        /// </summary>
        /// <returns>Array of the object of Designation class</returns>
        /// 



        public static Designation[] GetAllActiveDesignationsDetails()
        {
            Hr_Designation[] DesignationsDT = new Hr_DesignationBusinessObject().GetAllActiveDesignationsDetails();

            Designation[] Designations = new Designation[DesignationsDT.Length];

            for (int i = 0; i < Designations.Length; i++)
            {
                Designations[i] = new Designation(DesignationsDT[i]);
            }

            return Designations;
        }
        public static Designation[] GetActiveDesignations()
        {
            Hr_Designation[] DesignationsDT = new Hr_DesignationBusinessObject().GetAllActiveDesignations();

            Designation[] Designations = new Designation[DesignationsDT.Length];

            for (int i = 0; i < Designations.Length; i++)
            {
                Designations[i] = new Designation(DesignationsDT[i]);
            }

            return Designations;
        }
        public static int getChildCount(int ParentID)
        {
            return new Hr_DesignationBusinessObject().GetAllActiveDesignationChildCount(ParentID);
        }

        #region JGridDataObject Members

        public object GetGridData()
        {
            return this;
        }

        #endregion
        

    }
    public class DesignationDetails
    {
        public int _ID;
        public int _RoleID;
        public String _DesignationName;
        public bool _IsActive;
        public bool _IsNew;
        public int _UpdateBy;
        public String Role;
    }
}
