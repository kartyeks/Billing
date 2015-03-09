using System;
using System.Collections.Generic;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IRCA.Communication;

namespace HRManager.Entity
{
    /// <summary>
    /// Represents  EmployeeType fields and methods.
    /// </summary>
    public class  EmployeeType : JGridDataObject
    {
        private int _ID;
        private String _Name;
        private String _MinDurationMonth;
        private bool _IsActive;
        private bool _IsNew;
        private int _UpdateBy;
        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;
        private bool _IsService;
        private bool _IsPermanent;

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

        public String  Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        public String MinDurationMonth
        {
            get
            {
                return _MinDurationMonth;
            }
            set
            {
                _MinDurationMonth = value;
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
        public bool IsService
        {
            get
            {
                return _IsService;
            }
            set
            {
                _IsService = value;
            }
        }
        public bool IsPermanent
        {
            get
            {
                return _IsPermanent;
            }
            set
            {
                _IsPermanent = value;
            }
        }
        
        public int UpdatedBy
        {
            get { return _UpdateBy; }
            set { _UpdateBy = value; }
        }
        /// <summary>
        /// Update the  EmployeeType field using Master_EmployeeType.
        /// </summary>
        /// <param name=" EmployeeType">Object of Master_EmployeeType class</param>
        private void Update(Master_EmployeeType  EmployeeType)
        {
            if ( EmployeeType != null)
            {
                _ID =  EmployeeType.ID;
                _Name =  EmployeeType.Name;
                _MinDurationMonth =  EmployeeType.MinDurationMonth;
                _IsActive =  EmployeeType.IsActive;
                _IsNew = false;
                _CreatedBy =  EmployeeType.CreatedBy;
                _ModifiedBy =  EmployeeType.ModifiedBy;
                _CreatedDate =  EmployeeType.CreatedDate;
                _ModifiedDate =  EmployeeType.ModifiedDate;
                _IsService = EmployeeType.IsService;
                _IsPermanent = EmployeeType.IsPermanent;
            }
            else
            {
                _IsNew = true;
            }
        }
        /// <summary>
        /// Consturctor of  EmployeeType class.
        /// Update  EmployeeType fields using Master_ EmployeeType.
        /// </summary>
        /// <param name=" EmployeeType">Object of Master_ EmployeeType class</param>
        public  EmployeeType(Master_EmployeeType  EmployeeType)
        {
            Update(EmployeeType);
        }


        public static String GetEmployeeTypeForSearch()
        {
            String EmployeeTypeDT = new Master_EmployeeTypeBusinessObject().GetEmployeeTypeForSearch();

            return EmployeeTypeDT;
        }

        /// <summary>
        /// Consturctor of  EmployeeType class.
        /// Update  EmployeeType for given  EmployeeTypeName field.
        /// </summary>
        /// <param name=" EmployeeTypeName">field contains  EmployeeType Name</param>
        public  EmployeeType(String  EmployeeType)
        {
            Update(new Master_EmployeeTypeBusinessObject().GetEmployeeTypeByEmployeeType(EmployeeType));                        
        }
        /// <summary>
        /// Consturctor of  EmployeeType class.
        /// Update  EmployeeType fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains Designation ID</param>
        public  EmployeeType(int ID)
        {
            Master_EmployeeType  EmployeeType = new Master_EmployeeTypeBusinessObject().GetMaster_EmployeeType(ID);

            if (EmployeeType == null && ID > 0)
            {
                throw new IRCAException("Invalid  EmployeeType", ID.ToString());
            }

            Update( EmployeeType);
        }
        /// <summary>
        /// Consturctor of  EmployeeType class.
        /// Set variables for new  EmployeeType.  
        /// </summary>
        public  EmployeeType()
        {
            _ID = 0;
            _IsNew = true;
        }
        /// <summary>
        /// Save  EmployeeType.If new  EmployeeType it add and in case of edit it update the  EmployeeType.
        /// </summary>
        /// <returns>empty string</returns>
        private String SaveEmployeeType()
        {

            Master_EmployeeType  EmployeeType = new Master_EmployeeType();
             EmployeeType.ID = _ID;
             EmployeeType.Name = _Name;
             //EmployeeType.MinDurationMonth = _MinDurationMonth;
             EmployeeType.IsActive = _IsActive;
             //EmployeeType.IsService = _IsService;
             //EmployeeType.IsPermanent = _IsPermanent;
             EmployeeType.CreatedBy = _CreatedBy;
             EmployeeType.CreatedDate = _CreatedDate;
             EmployeeType.ModifiedBy = _ModifiedBy;
             EmployeeType.ModifiedDate = DateTime.Now;

            if (_IsNew)
            {
                 EmployeeType.CreatedBy = _UpdateBy;
                 EmployeeType.CreatedDate = DateTime.Now;
                 EmployeeType.ID = new Master_EmployeeTypeBusinessObject().Create( EmployeeType);
            }
            else
            {
                 EmployeeType.ModifiedBy = _UpdateBy;
                 EmployeeType.ModifiedDate = DateTime.Now;
                 EmployeeType.ID = _ID;
                new Master_EmployeeTypeBusinessObject().Update(EmployeeType);
            }

            return String.Empty;
        }
        /// <summary>
        ///Validate  EmployeeType for empty and already exist status and then save  EmployeeType.
        /// </summary>
        /// <returns>String return from the Save EmployeeType method</returns> 
        public String Save()
        {
            String Status = Validate();

            if (Status != String.Empty)
            {
                return Status;
            }

            return SaveEmployeeType();
        }
        /// <summary>
        /// Validate  EmployeeTypeName for empty and already exist status.
        /// </summary>
        /// <returns>empty string</returns>
        private String Validate()
        {
            Master_EmployeeTypeBusinessObject  EmployeeTypeBO = new Master_EmployeeTypeBusinessObject();

            if (_Name == String.Empty)
            {
                return HRManagerDefs. EmployeeTypeMessages.EMPTY_EMPLOYEETYPE;
            }
            else if ( EmployeeTypeBO.IsEmployeeTypeExists(_Name, _ID))
            {
                return HRManagerDefs.EmployeeTypeMessages.EMPLOYEETYPE_EXISTS;
            }
            return String.Empty;
        }

        public static  EmployeeType[] GetAllInActiveEmployeeType()
        {
            Master_EmployeeType[]  EmployeeTypesDT = new Master_EmployeeTypeBusinessObject().GetAllInActiveEmployeeTypesOrderByEmployeeTypes();

             EmployeeType[]  EmployeeTypes = new  EmployeeType[ EmployeeTypesDT.Length];

            for (int i = 0; i <  EmployeeTypes.Length; i++)
            {
                 EmployeeTypes[i] = new  EmployeeType( EmployeeTypesDT[i]);
            }

            return  EmployeeTypes;
        }


        /// <summary>
        /// Activate the  EmployeeType
        /// </summary>
        /// <param name="ActivatedBy">id of user who want to activate  EmployeeType</param>
        /// <returns>String return from the Save EmployeeType method</returns>
        public String Activate(int ActivatedBy)
        {
            _UpdateBy = ActivatedBy;
            _IsActive = true;

            return SaveEmployeeType();
        }
        /// <summary>
        /// Deactivate the  EmployeeType
        /// </summary>
        /// <param name="DeActivatedBy">id of user who want to DeActivate  EmployeeType</param>
        /// <returns>String return from the Save EmployeeType method</returns>
        public String DeActivate(int DeActivatedBy)
        {
            //String Status = CheckReference();
            _UpdateBy = DeActivatedBy;
            //if (Status != String.Empty)
            //{
            //    return Status;
            //}
            //else
            //{
                _IsActive = false;

                return SaveEmployeeType();
            //}

        }
     
        /// <summary>
        /// Return all  EmployeeTypes
        /// </summary>
        /// <returns>Array of the object of  EmployeeType class</returns>
        public static  EmployeeType[] GetAllEmployeeTypes()
        {
            Master_EmployeeType[]  EmployeeTypesDT = new Master_EmployeeTypeBusinessObject().GetAllActiveEmployeeType();

             EmployeeType[]  EmployeeTypes = new  EmployeeType[ EmployeeTypesDT.Length];

            for (int i = 0; i <  EmployeeTypes.Length; i++)
            {
                 EmployeeTypes[i] = new  EmployeeType( EmployeeTypesDT[i]);
            }

            return  EmployeeTypes;
        }
        private String CheckReference()
        {
            Master_EmployeeTypeBusinessObject  EmployeeTypeBO = new Master_EmployeeTypeBusinessObject();

            if (EmployeeTypeBO.IsEmployeeTypeRefered(_ID))
            {
                return HRManagerDefs.EmployeeTypeMessages.EMPLOYEETYPE_REFERED;
            }
            return String.Empty;
        }

        /// <summary>
        /// Return all LocationTypes
        /// </summary>
        /// <returns>Array of the object of LocationTypes class</returns>
        public static  EmployeeType[] GetAllEmployeeTypeforCombo()
        {
            Master_EmployeeType[]  EmployeeTypeDT = new Master_EmployeeTypeBusinessObject().GetAllEmployeeTypes();

             EmployeeType[]  EmployeeType = new  EmployeeType[ EmployeeTypeDT.Length];

            for (int i = 0; i <  EmployeeType.Length; i++)
            {
                 EmployeeType[i] = new  EmployeeType( EmployeeTypeDT[i]);
            }

            return  EmployeeType;
        }
        #region JGridDataObject Members

        public object GetGridData()
        {
             EmployeeTypeDetails  EmployeeType = new  EmployeeTypeDetails();

             EmployeeType.ID = _ID;
             EmployeeType.Name = _Name;
             EmployeeType.MinDurationMonth = _MinDurationMonth;
             EmployeeType.IsService = _IsService;
             EmployeeType.IsActive = _IsActive;
             EmployeeType.IsPermanent = _IsPermanent;


            return  EmployeeType;
        }

        #endregion
    }
    public class  EmployeeTypeDetails
    {
        public int ID;
        public String  Name;
        public String MinDurationMonth;
        public bool IsService;
        public bool IsActive;
        public bool IsPermanent;
    }
}
