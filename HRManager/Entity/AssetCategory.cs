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
    public class AssetCategory : JGridDataObject
    {
        private int _ID;
        private String _AssetCategories;
        private String _Description;
       
        private bool _IsActive;

        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;


        public int ID { get { return _ID; } set { _ID = value; } }
        public String AssetCategories { get { return _AssetCategories; } set { _AssetCategories = value; } }
        public String Description { get { return _Description; } set { _Description = value; } }
        
        public bool IsActive { get { return _IsActive; } set { _IsActive = value; } }

        public int CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }
        public DateTime CreatedDate { get { return _CreatedDate; } set { _CreatedDate = value; } }
        public int ModifiedBy { get { return _ModifiedBy; } set { _ModifiedBy = value; } }
        public DateTime ModifiedDate { get { return _ModifiedDate; } set { _ModifiedDate = value; } }
        public bool Status { get { return _IsActive; } set { _IsActive = value; } }

         public AssetCategory()
        {
        }
         public AssetCategory(int ID)
        {
            Update(new Master_AssetCategoryBusinessObject().GetMaster_AssetCategory(ID));
        }
         public void Update(Master_AssetCategory DTO)
         {
             if (DTO != null)
             {
                 _ID = DTO.ID;
                 _AssetCategories = DTO.AssetCategory;
                 _Description = DTO.Description;
                 _IsActive = DTO.IsActive;
                 _ModifiedBy = DTO.ModifiedBy;
                 _ModifiedDate = DTO.ModifiedDate;
                 _CreatedBy = DTO.CreatedBy;
                 _CreatedDate = DTO.CreatedDate;
             }
         }
         private Master_AssetCategory GetDTO()
         {
             Master_AssetCategory DTO = new Master_AssetCategory();
             DTO.ID = _ID;
             DTO.AssetCategory = _AssetCategories;
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
             Master_AssetCategoryBusinessObject BO = new Master_AssetCategoryBusinessObject();

             if (BO.IAssetRefered(_ID))
             {
                 return "Already Referred";
             }
             
             return String.Empty;
         }
         public String Validate()
         {
             Master_AssetCategoryBusinessObject BO = new Master_AssetCategoryBusinessObject();

             if (BO.IsAssetCategoryExists(_AssetCategories, _ID))
             {
                 return "AssetCategory already exists";
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
                 Master_AssetCategoryBusinessObject BO = new Master_AssetCategoryBusinessObject();
                 Master_AssetCategory DTO = GetDTO();

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
         public static AssetCategory[] GetAssetCategory()
         {
             Master_AssetCategory[] RolesDT = new Master_AssetCategoryBusinessObject().GetAssetCategoriesMaster("IsActive = 1");

             AssetCategory[] Roles = new AssetCategory[RolesDT.Length];

             for (int i = 0; i < Roles.Length; i++)
             {
                 Roles[i] = new AssetCategory();

                 Roles[i].Update(RolesDT[i]);
             }

             return Roles;
         }
         public static AssetCategory[] GetInActiveAssetCategory()
         {
             Master_AssetCategory[] RolesDT = new Master_AssetCategoryBusinessObject().GetAssetCategoriesMaster("IsActive = 0");

             AssetCategory[] Roles = new AssetCategory[RolesDT.Length];

             for (int i = 0; i < Roles.Length; i++)
             {
                 Roles[i] = new AssetCategory();

                 Roles[i].Update(RolesDT[i]);
             }

             return Roles;
         }
         public static AssetCategory[] GetAllAssetDetails()
         {
             Master_AssetCategory[] CountryDT = new Master_AssetCategoryBusinessObject().GetMaster_AssetCategory();
             AssetCategory[] Country = new AssetCategory[CountryDT.Length];

             for (int i = 0; i < Country.Length; i++)
             {
                 Country[i] = new AssetCategory();

                 Country[i].Update(CountryDT[i]);
             }

             return Country;
         }
    }
}
