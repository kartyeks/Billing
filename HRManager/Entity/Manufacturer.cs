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
    public class Manufacturer : JGridDataObject
    {
         private int _ID;
        private String _ManufacturerName;
        private String _Description;
       
        private bool _IsActive;

        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;


        public int ID { get { return _ID; } set { _ID = value; } }
        public String ManufacturerName { get { return _ManufacturerName; } set { _ManufacturerName = value; } }
        public String Description { get { return _Description; } set { _Description = value; } }
        
        public bool IsActive { get { return _IsActive; } set { _IsActive = value; } }

        public int CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }
        public DateTime CreatedDate { get { return _CreatedDate; } set { _CreatedDate = value; } }
        public int ModifiedBy { get { return _ModifiedBy; } set { _ModifiedBy = value; } }
        public DateTime ModifiedDate { get { return _ModifiedDate; } set { _ModifiedDate = value; } }
        public bool Status { get { return _IsActive; } set { _IsActive = value; } }

         public Manufacturer()
        {
        }
         public Manufacturer(int ID)
        {
            Update(new Master_ManufacturerBusinessObject().GetMaster_Manufacturer(ID));
        }
         public void Update(Master_Manufacturer DTO)
         {
             if (DTO != null)
             {
                 _ID = DTO.ID;
                 _ManufacturerName = DTO.ManufacturerName;
                 _Description = DTO.Description;
                 _IsActive = DTO.IsActive;
                 _ModifiedBy = DTO.ModifiedBy;
                 _ModifiedDate = DTO.ModifiedDate;
                 _CreatedBy = DTO.CreatedBy;
                 _CreatedDate = DTO.CreatedDate;
             }
         }
         private Master_Manufacturer GetDTO()
         {
             Master_Manufacturer DTO = new Master_Manufacturer();
             DTO.ID = _ID;
             DTO.ManufacturerName = _ManufacturerName;
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
             Master_ManufacturerBusinessObject BO = new Master_ManufacturerBusinessObject();

             if (BO.ImanufacturerRefered(_ID))
             {
                 return "Already Referred";
             }

             return String.Empty;
         }
         public String Validate()
         {
             Master_ManufacturerBusinessObject BO = new Master_ManufacturerBusinessObject();

             if (BO.IsManufacturerExists(_ManufacturerName, _ID))
             {
                 return "Manufacturer Name already exists";
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
                 Master_ManufacturerBusinessObject BO = new Master_ManufacturerBusinessObject();
                 Master_Manufacturer DTO = GetDTO();

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
         public static Manufacturer[] GetManufacturers()
         {
             Master_Manufacturer[] RolesDT = new Master_ManufacturerBusinessObject().GetManufacturerMaster("IsActive = 1");

             Manufacturer[] Roles = new Manufacturer[RolesDT.Length];

             for (int i = 0; i < Roles.Length; i++)
             {
                 Roles[i] = new Manufacturer();

                 Roles[i].Update(RolesDT[i]);
             }

             return Roles;
         }
         public static Manufacturer[] GetInActiveManufacturers()
         {
             Master_Manufacturer[] RolesDT = new Master_ManufacturerBusinessObject().GetManufacturerMaster("IsActive = 0");

             Manufacturer[] Roles = new Manufacturer[RolesDT.Length];

             for (int i = 0; i < Roles.Length; i++)
             {
                 Roles[i] = new Manufacturer();

                 Roles[i].Update(RolesDT[i]);
             }

             return Roles;
         }
         public static Manufacturer[] GetAllManufacturerDetails()
         {
             Master_Manufacturer[] CountryDT = new Master_ManufacturerBusinessObject().GetMaster_Manufacturer();
             Manufacturer[] Country = new Manufacturer[CountryDT.Length];

             for (int i = 0; i < Country.Length; i++)
             {
                 Country[i] = new Manufacturer();

                 Country[i].Update(CountryDT[i]);
             }

             return Country;
         }
    }
}
