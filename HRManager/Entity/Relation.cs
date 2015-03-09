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
    /// Entity class for Relation. This will manage create / modify entities
    /// </summary>
    public class Relation : JGridDataObject
    {
        private int _ID;
        private String _RelationName;
        private bool _IsActive;
        private int _UpdateBy;
        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;
        private bool _IsNew;

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

        public String RelationName
        {
            get
            {
                return _RelationName;
            }
            set
            {
                _RelationName = value;
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
        public bool Status { get { return _IsActive; } set { _IsActive = value; } }

        /// <summary>
        /// Update the entity based on the DTO object.
        /// </summary>
        /// <param name="Relation">DTO object</param>
        private void Update(Master_Relation Relation)
        {
            if (Relation != null)
            {
                _ID = Relation.ID;
                _RelationName = Relation.RelationName;
                _IsActive = Relation.IsActive;
                _CreatedBy = Relation.CreatedBy;
                _ModifiedBy = Relation.ModifiedBy;
                _CreatedDate = Relation.CreatedDate;
                _ModifiedDate = Relation.ModifiedDate;

                _IsNew = false;

            }
            else
            {
                _IsNew = true;
            }
        }

        /// <summary>
        /// Save Relation.If new Relation it add and in case of edit it update the Relation.
        /// </summary>
        /// <returns>empty string</returns>
        private String SaveRelation()
        {

            Master_Relation Relation = new Master_Relation();
            Relation.ID = _ID;
            Relation.RelationName = _RelationName;
            Relation.IsActive = _IsActive;
            Relation.ModifiedBy = _ModifiedBy;
            Relation.ModifiedDate = DateTime.Now;
            Relation.CreatedBy = _CreatedBy;
            Relation.CreatedDate = _CreatedDate;

            if (_IsNew)
            {
                Relation.CreatedBy = _UpdateBy;
                Relation.CreatedDate = DateTime.Now;
                Relation.ID = new Master_RelationBusinessObject().Create(Relation);
            }
            else
            {
                Relation.ModifiedBy = _UpdateBy;
                Relation.ModifiedDate = DateTime.Now;
                Relation.ID = _ID;
                new Master_RelationBusinessObject().Update(Relation);
            }

            return String.Empty;
        }


        // <summary>
        ///Validate Relation for empty and already exist status and then save Relation.
        /// </summary>
        /// <returns>String return from the SaveRelation method</returns> 
        public String Save()
        {
            String Status = Validate();

            if (Status != String.Empty)
            {
                return Status;
            }

            return SaveRelation();
        }
        /// <summary>
        /// Validate RelationName for empty and already exist status.
        /// </summary>
        /// <returns>empty string</returns>

        private String Validate()
        {
            Master_RelationBusinessObject RelationBO = new Master_RelationBusinessObject();

            if (_RelationName == String.Empty)
            {
                return HRManagerDefs.RelationMessages.EMPTY_Relation;
            }
            else if (RelationBO.IsRelationExists(_RelationName, _ID))
            {
                return HRManagerDefs.RelationMessages.Relation_EXISTS;
            }
            return String.Empty;
        }

        /// <summary>
        /// Construct the object based on DTO
        /// </summary>
        /// <param name="Relation">DTO object</param>        
        public Relation(Master_Relation RelationName)
        {
            Update(RelationName);
        }

        /// <summary>
        /// Construct the object by the ID.
        /// </summary>
        /// <param name="ID">Relation ID</param>
        public Relation(int ID)
        {
            Master_Relation Relation = new Master_RelationBusinessObject().GetMaster_Relation(ID);
            Update(Relation);
        }

        /// <summary>
        /// Deactivate the Relation
        /// </summary>
        /// <param name="DeActivatedBy">id of user who want to DeActivate Relation</param>
        /// <returns>String return from the SaveRelation method</returns>
        public String DeActivate(int DeActivatedBy)
        {
            _IsActive = false;
            _UpdateBy = DeActivatedBy;
            return SaveRelation();
        }

        /// <summary>
        /// Activate the Relation
        /// </summary>
        /// <param name="DeActivatedBy">id of user who want to DeActivate Relation</param>
        /// <returns>String return from the SaveRelation method</returns>
        public String Activate(int ActivatedBy)
        {
            _IsActive = true;
            _UpdateBy = ActivatedBy;
            return SaveRelation();
        }

        /// <summary>
        /// This will be used when the entity passed directly to any method
        /// </summary>
        /// <returns>Name Of the The Relation</returns>
        public override string ToString()
        {
            return _RelationName;
        }

        /// <summary>
        /// Get all the countries
        /// </summary>
        /// <returns>Arry Of Relation objects</returns>
        public static Relation[] GetAllActiveRelation()
        {
            Master_Relation[] RelationDT = new Master_RelationBusinessObject().GetAllActiveRelation();
            Relation[] Relation = new Relation[RelationDT.Length];

            for (int i = 0; i < Relation.Length; i++)
            {
                Relation[i] = new Relation(RelationDT[i]);
            }

            return Relation;
        }
        public static Relation[] GetAllRelationDetails()
        {
            Master_Relation[] RelationDT = new Master_RelationBusinessObject().GetAllRelationDetails();
            Relation[] Relation = new Relation[RelationDT.Length];

            for (int i = 0; i < Relation.Length; i++)
            {
                Relation[i] = new Relation(RelationDT[i]);
            }

            return Relation;
        }
        
        /// <summary>
        /// Return all inactive Relation
        /// </summary>
        /// <returns>Array of the object of Designation class</returns>
        public static Relation[] GetAllInActiveRelation()
        {
            Master_Relation[] RelationDT = new Master_RelationBusinessObject().GetAllInActiveRelationOrderByRelation();

            Relation[] Relation = new Relation[RelationDT.Length];

            for (int i = 0; i < Relation.Length; i++)
            {
                Relation[i] = new Relation(RelationDT[i]);
            }

            return Relation;
        }


        #region JGridDataObject Members

        public object GetGridData()
        {
            RelationDetails Relation = new RelationDetails();

            Relation.ID = _ID;
            Relation.RelationName = _RelationName;
            Relation.Status = _IsActive;
            Relation.IsActive = _IsActive;

            return Relation;
        }

        #endregion
    }
    public class RelationDetails
    {
        public int ID;
        public String RelationName;
        public bool IsActive;
        public bool Status;

    }
}
