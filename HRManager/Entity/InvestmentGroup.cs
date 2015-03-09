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
    public class InvestmentGroup : JGridDataObject
    {
        private int _ID;
        private String _InvestmentGroupName;
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

        public String InvestmentGroupName
        {
            get
            {
                return _InvestmentGroupName;
            }
            set
            {
                _InvestmentGroupName = value;
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



        private void Update(Master_InvestmentGroup Investment)
        {
            if (Investment != null)
            {
                _ID = Investment.ID;
                _InvestmentGroupName = Investment.InvestmentGroupName;
                _IsActive = Investment.IsActive;
                _CreatedBy = Investment.CreatedBy;
                _ModifiedBy = Investment.ModifiedBy;
                _CreatedDate = Investment.CreatedDate;
                _ModifiedDate = Investment.ModifiedDate;

                _IsNew = false;

            }
            else
            {
                _IsNew = true;
            }
        }


        private String SaveInvestment()
        {

            Master_InvestmentGroup Investment = new Master_InvestmentGroup();
            Investment.ID = _ID;
            Investment.InvestmentGroupName = _InvestmentGroupName;
            Investment.IsActive = _IsActive;
            Investment.ModifiedBy = _ModifiedBy;
            Investment.ModifiedDate = DateTime.Now;
            Investment.CreatedBy = _CreatedBy;
            Investment.CreatedDate = _CreatedDate;

            if (_IsNew)
            {
                Investment.CreatedBy = _UpdateBy;
                Investment.CreatedDate = DateTime.Now;
                Investment.ID = new Master_InvestmentGroupBusinessObject().Create(Investment);
            }
            else
            {
                Investment.ModifiedBy = _UpdateBy;
                Investment.ModifiedDate = DateTime.Now;
                Investment.ID = _ID;
                new Master_InvestmentGroupBusinessObject().Update(Investment);
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

            return SaveInvestment();
        }


        private String Validate()
        {
            Master_InvestmentGroupBusinessObject RelationBO = new Master_InvestmentGroupBusinessObject();

            //if (_RelationName == String.Empty)
            //{
            //    return HRManagerDefs.RelationMessages.EMPTY_Relation;
            //}
            //else if (RelationBO.IsRelationExists(_RelationName, _ID))
            //{
            //    return HRManagerDefs.RelationMessages.Relation_EXISTS;
            //}
            return String.Empty;
        }

        public InvestmentGroup(Master_InvestmentGroup RelationName)
        {
            Update(RelationName);
        }
        public InvestmentGroup(int ID)
        {
            Master_InvestmentGroup Investment = new Master_InvestmentGroupBusinessObject().GetMaster_InvestmentGroup(ID);
            Update(Investment);
        }

        public String DeActivate(int DeActivatedBy)
        {
            _IsActive = false;
            _UpdateBy = DeActivatedBy;
            return SaveInvestment();
        }

        public String Activate(int ActivatedBy)
        {
            _IsActive = true;
            _UpdateBy = ActivatedBy;
            return SaveInvestment();
        }

        public override string ToString()
        {
            return _InvestmentGroupName;
        }


        public static InvestmentGroup[] GetAllActiveInvestmentGroup()
        {
            Master_InvestmentGroup[] InvestmentGroupDT = new Master_InvestmentGroupBusinessObject().GetAllActiveInvestment();
            InvestmentGroup[] InvestmentGroup = new InvestmentGroup[InvestmentGroupDT.Length];

            for (int i = 0; i < InvestmentGroup.Length; i++)
            {
                InvestmentGroup[i] = new InvestmentGroup(InvestmentGroupDT[i]);
            }

            return InvestmentGroup;
        }
        public static InvestmentGroup[] GetAllInvestmentGroupDetails()
        {
            Master_InvestmentGroup[] InvestmentGroupDT = new Master_InvestmentGroupBusinessObject().GetAllInvestmentGroupDetails();
            InvestmentGroup[] InvestmentGroup = new InvestmentGroup[InvestmentGroupDT.Length];

            for (int i = 0; i < InvestmentGroup.Length; i++)
            {
                InvestmentGroup[i] = new InvestmentGroup(InvestmentGroupDT[i]);
            }

            return InvestmentGroup;
        }

        /// <summary>
        /// Return all inactive Relation
        /// </summary>
        /// <returns>Array of the object of Designation class</returns>
        public static InvestmentGroup[] GetAllInActiveGroups()
        {
            Master_InvestmentGroup[] InvestmentGroupDT = new Master_InvestmentGroupBusinessObject().GetAllInActiveInvestmentOrderByInvestment();

            InvestmentGroup[] InvestmentGroup = new InvestmentGroup[InvestmentGroupDT.Length];

            for (int i = 0; i < InvestmentGroup.Length; i++)
            {
                InvestmentGroup[i] = new InvestmentGroup(InvestmentGroupDT[i]);
            }

            return InvestmentGroup;
        }
        #region JGridDataObject Members

        public object GetGridData()
        {
            InvestmentGroupDetails InvestmentGroup = new InvestmentGroupDetails();

            InvestmentGroup.ID = _ID;
            InvestmentGroup.InvestmentGroupName = _InvestmentGroupName;
            InvestmentGroup.Status = _IsActive;
            InvestmentGroup.IsActive = _IsActive;

            return InvestmentGroup;
        }

        #endregion


    }
    public class InvestmentGroupDetails
    {
        public int ID;
        public String InvestmentGroupName;
        public bool IsActive;
        public bool Status;

    }
}
