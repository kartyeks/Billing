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
    public class AssetSubCategory : JGridDataObject
    {
        private int _ID;
        private String _AssetSubCategories;
        private String _Description;
       
        private bool _IsActive;

        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;


        public int ID { get { return _ID; } set { _ID = value; } }
        public String AssetSubCategories { get { return _AssetSubCategories; } set { _AssetSubCategories = value; } }
        public String Description { get { return _Description; } set { _Description = value; } }
        
        public bool IsActive { get { return _IsActive; } set { _IsActive = value; } }

        public int CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }
        public DateTime CreatedDate { get { return _CreatedDate; } set { _CreatedDate = value; } }
        public int ModifiedBy { get { return _ModifiedBy; } set { _ModifiedBy = value; } }
        public DateTime ModifiedDate { get { return _ModifiedDate; } set { _ModifiedDate = value; } }
        public bool Status { get { return _IsActive; } set { _IsActive = value; } }

         public AssetSubCategory()
        {
        }
         public AssetSubCategory(int ID)
        {
            Update(new Master_AssetSubCategoryBusinessObject().GetMaster_AssetSubCategory(ID));
        }
         public void Update(Master_AssetSubCategory DTO)
         {
             if (DTO != null)
             {
                 _ID = DTO.ID;
                 _AssetSubCategories = DTO.AssetSubCategory;
                 _Description = DTO.Description;
                 _IsActive = DTO.IsActive;
                 _ModifiedBy = DTO.ModifiedBy;
                 _ModifiedDate = DTO.ModifiedDate;
                 _CreatedBy = DTO.CreatedBy;
                 _CreatedDate = DTO.CreatedDate;
             }
         }
         private Master_AssetSubCategory GetDTO()
         {
             Master_AssetSubCategory DTO = new Master_AssetSubCategory();
             DTO.ID = _ID;
             DTO.AssetSubCategory = _AssetSubCategories;
             DTO.Description = _Description;
             DTO.CreatedBy = _CreatedBy;
             DTO.CreatedDate = _CreatedDate;
             DTO.ModifiedBy = _ModifiedBy;
             DTO.ModifiedDate = _ModifiedDate;
             DTO.IsActive = _IsActive;

             if (_ID == 0)
             {
                 DTO.CreatedBy = _CreatedBy;
                 DTO.CreatedDate = DateTime.Now;
             }
             DTO.ModifiedBy = _ModifiedBy;
             DTO.ModifiedDate = DateTime.Now;

             return DTO;
         }
         public String Activate(int ActivatedBy)
         {
             _ModifiedBy = ActivatedBy;
             _IsActive = true;

             return Save();
         }
         public String DeActivate(int DeActivatedBy)
         {
             String Status = CheckReference();
             _ModifiedBy = DeActivatedBy;
             if (Status != String.Empty)
             {
                 return Status;
             }
             else
             {
                 _IsActive = false;

                 return Save();
             }

         }
         private String CheckReference()
         {
             Master_AssetSubCategoryBusinessObject BO = new Master_AssetSubCategoryBusinessObject();

             if (BO.IAssetSubRefered(_ID))
             {
                 return "Already Referred";
             }

             return String.Empty;
         }
         public String Validate()
         {
             Master_AssetSubCategoryBusinessObject BO = new Master_AssetSubCategoryBusinessObject();

             if (BO.IsAssetSubCategoryExists(_AssetSubCategories, _ID))
             {
                 return "AssetSubCategory already exists";
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
         public String Save()
         {
             String Status = Validate();
             if (Status != String.Empty)
             {
                 return Status;
             }
             try
             {
                 Master_AssetSubCategoryBusinessObject BO = new Master_AssetSubCategoryBusinessObject();
                 Master_AssetSubCategory DTO = GetDTO();

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
         public object GetGridData()
         {
             return this;
         }
         public static AssetSubCategory[] GetAssetSubCategory()
         {
             Master_AssetSubCategory[] RolesDT = new Master_AssetSubCategoryBusinessObject().GetAsetSubCategoriesMaster("IsActive = 1");

             AssetSubCategory[] Roles = new AssetSubCategory[RolesDT.Length];

             for (int i = 0; i < Roles.Length; i++)
             {
                 Roles[i] = new AssetSubCategory();

                 Roles[i].Update(RolesDT[i]);
             }

             return Roles;
         }
         public static AssetSubCategory[] GetInActiveAssetSubCategory()
         {
             Master_AssetSubCategory[] RolesDT = new Master_AssetSubCategoryBusinessObject().GetAsetSubCategoriesMaster("IsActive = 0");

             AssetSubCategory[] Roles = new AssetSubCategory[RolesDT.Length];

             for (int i = 0; i < Roles.Length; i++)
             {
                 Roles[i] = new AssetSubCategory();

                 Roles[i].Update(RolesDT[i]);
             }

             return Roles;
         }

         public static AssetSubCategory[] GetAllAssetSubDetails()
         {
             Master_AssetSubCategory[] RolesDT = new Master_AssetSubCategoryBusinessObject().GetMaster_AssetSubCategory();

             AssetSubCategory[] Roles = new AssetSubCategory[RolesDT.Length];

             for (int i = 0; i < Roles.Length; i++)
             {
                 Roles[i] = new AssetSubCategory();

                 Roles[i].Update(RolesDT[i]);
             }

             return Roles;
         }
    }
}
