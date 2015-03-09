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
    /// Represents Loan fields and methods.
    /// </summary>
    public class MasterAdvanceType : JGridDataObject
    {
        private int _ID;
        private String _AdvanceType;        
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
        public String AdvanceType
        {
            get
            {
                return _AdvanceType;
            }
            set
            {
                _AdvanceType = value;
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

        
        private void Update(Master_AdvanceType AdvanceType)
        {
            if (AdvanceType != null)
            {
                _ID = AdvanceType.ID;
                _AdvanceType = AdvanceType.AdvanceType;                
                _IsActive = AdvanceType.IsActive;
                _IsNew = false;
                _CreatedBy = AdvanceType.CreatedBy;
                _ModifiedBy = AdvanceType.ModifiedBy;
                _CreatedDate = AdvanceType.CreatedDate;
                _ModifiedDate = AdvanceType.ModifiedDate;
                
            }
            else
            {
                _IsNew = true;
            }
        }
       
        public MasterAdvanceType(Master_AdvanceType AdvanceType)
        {
            Update(AdvanceType);
        }


        public MasterAdvanceType(int ID)
        {
            Master_AdvanceType AdvanceType = new Master_AdvanceTypeBusinessObject().GetMaster_AdvanceType(ID);

            if (AdvanceType == null && ID > 0)
            {
                throw new IRCAException("Invalid AdvanceType", ID.ToString());
            }

            Update(AdvanceType);
        }




        public MasterAdvanceType(String AdvanceType)
        {
            Update(new Master_AdvanceTypeBusinessObject().GetAdvanceTypeByAdvanceType(AdvanceType));
        }
        
        public MasterAdvanceType()
        {
            _ID = 0;
            _IsNew = true;
        }
       
        private String SaveMasterAdvanceType()
        {

            Master_AdvanceType AdvanceType = new Master_AdvanceType();
            AdvanceType.ID = _ID;
            AdvanceType.AdvanceType = _AdvanceType;
            AdvanceType.IsActive = _IsActive;
            AdvanceType.ModifiedBy = _ModifiedBy;
            AdvanceType.ModifiedDate = DateTime.Now;
            AdvanceType.CreatedBy = _CreatedBy;
            AdvanceType.CreatedDate = _CreatedDate;
           
            if (_IsNew)
            {
                AdvanceType.CreatedBy = _UpdateBy;
                AdvanceType.CreatedDate = DateTime.Now;
                AdvanceType.ID = new Master_AdvanceTypeBusinessObject().Create(AdvanceType);
            }
            else
            {

                AdvanceType.ModifiedBy = _UpdateBy;
                AdvanceType.ModifiedDate = DateTime.Now;
                AdvanceType.ID = _ID;
                new Master_AdvanceTypeBusinessObject().Update(AdvanceType);
            }

           return String.Empty;
      }
        public String Save()
        {
            String Status = Validate();
            
            if (Status != String.Empty)
            {
                return Status;
            }

            return SaveMasterAdvanceType();
        }

        private String Validate()
        {
            Master_AdvanceTypeBusinessObject AdvanceTypeBo = new Master_AdvanceTypeBusinessObject();

            if (_AdvanceType == String.Empty)
            {
                return HRLoanManagerDefs.AdvanceType.EMPTY_ADVANCETYPE;
            }
            else if (AdvanceTypeBo.IsAdvanceTypeExists(_AdvanceType, _ID))
            {
                return HRLoanManagerDefs.AdvanceType.ADVANCETYPE_EXISTS;
            }
            return String.Empty;
        }


       

        public static MasterAdvanceType[] GetAllActiveAdvanceType()
        {
            Master_AdvanceType[] AdvanceTypesDT = new Master_AdvanceTypeBusinessObject().GetAllActiveAdvanceType();

            MasterAdvanceType[] AdvanceTypes = new MasterAdvanceType[AdvanceTypesDT.Length];

            for (int i = 0; i < AdvanceTypes.Length; i++)
            {
                AdvanceTypes[i] = new MasterAdvanceType(AdvanceTypesDT[i]);
            }

            return AdvanceTypes;
        }

        public String Activate(int ActivatedBy)
        {
            _UpdateBy = ActivatedBy;
            _IsActive = true;

            return SaveMasterAdvanceType();
        }

        public static MasterAdvanceType[] GetAllAdvanceType()
        {
            Master_AdvanceType[] AdvanceTypesDT = new Master_AdvanceTypeBusinessObject().GetAllAdvanceTypes();

            MasterAdvanceType[] AdvanceTypes = new MasterAdvanceType[AdvanceTypesDT.Length];

            for (int i = 0; i < AdvanceTypes.Length; i++)
            {
                AdvanceTypes[i] = new MasterAdvanceType(AdvanceTypesDT[i]);
            }

            return AdvanceTypes;
        }


        public static MasterAdvanceType[] GetInActiveAdvanceType()
        {
            Master_AdvanceType[] AdvanceTypesDT = new Master_AdvanceTypeBusinessObject().GetAllInActiveAdvanceTypesOrderByAdvanceType();

            MasterAdvanceType[] AdvanceTypes = new MasterAdvanceType[AdvanceTypesDT.Length];

            for (int i = 0; i < AdvanceTypes.Length; i++)
            {
                AdvanceTypes[i] = new MasterAdvanceType(AdvanceTypesDT[i]);
            }

            return AdvanceTypes;
        }

        public static MasterAdvanceType[] GetAdvanceTypeForCombo()
        {
            Master_AdvanceType[] LocationTypeDT = new Master_AdvanceTypeBusinessObject().GetAllAdvanceTypes();

            MasterAdvanceType[] MasterAdvanceType = new MasterAdvanceType[LocationTypeDT.Length];

            for (int i = 0; i < MasterAdvanceType.Length; i++)
            {
                MasterAdvanceType[i] = new MasterAdvanceType(LocationTypeDT[i]);
            }

            return MasterAdvanceType;
        }


        public String DeActivate(int DeActivateBy)
        {
            String Status = CheckReference();
            _UpdateBy = DeActivateBy;
            if (Status != String.Empty)
            {
                return Status;
            }
            else
            {
                _IsActive = false;

                return SaveMasterAdvanceType();
            }
            
                //_UpdateBy = DeActivateBy;
                //_IsActive = false;

                //return SaveMasterAdvanceType();
        }
        /// <summary>
        /// Validate PolicyTypeName for empty and already exist status.
        /// </summary>
        /// <returns>empty string</returns>
        private String CheckReference()
        {
            Master_AdvanceTypeBusinessObject Master_AdvanceTypeBO = new Master_AdvanceTypeBusinessObject();
//kartyek 7.2.2015 commented for future purpose to add reference related to salary advance
            //if (Master_AdvanceTypeBO.IsAdvanceTypeRefered(_ID))
            //{
            //    return HRLoanManagerDefs.AdvanceType.ADVANCETYPE_REFERED;
            //}
            return String.Empty;
        }
        


        #region JGridDataObject Members

        public object GetGridData()
        {
            AdvanceTypeDetails AdvanceType = new AdvanceTypeDetails();

            AdvanceType.AdvanceTypeID = _ID;
            AdvanceType.AdvanceType = _AdvanceType;            
            AdvanceType.IsActive = _IsActive;


            return AdvanceType;
        }

        
        #endregion
    }
    public class AdvanceTypeDetails
    {
        public int AdvanceTypeID;
        public String AdvanceType;        
        public bool IsActive;
       
    }
}


 