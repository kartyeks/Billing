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
    public class Master_MaritialStatus : JGridDataObject
    {
        private int _ID;
        private String _MaritalStatus;
        private bool _IsActive;

        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;

        public int ID { get { return _ID; } set { _ID = value; } }
        public String MaritalStatus { get { return _MaritalStatus; } set { _MaritalStatus = value; } }
        
        public bool IsActive { get { return _IsActive; } set { _IsActive = value; } }

        public int CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }
        public DateTime CreatedDate { get { return _CreatedDate; } set { _CreatedDate = value; } }
        public int ModifiedBy { get { return _ModifiedBy; } set { _ModifiedBy = value; } }
        public DateTime ModifiedDate { get { return _ModifiedDate; } set { _ModifiedDate = value; } }
        public bool Status { get { return _IsActive; } set { _IsActive = value; } }

         public Master_MaritialStatus()
        {
        }
         public Master_MaritialStatus(int ID)
        {
            Update(new Master_MaritalStatusBusinessObject().GetMaster_MaritalStatus(ID));
        }
         public void Update(Master_Marital_Status DTO)
         {
             if (DTO != null)
             {
                 _ID = DTO.ID;
                 _MaritalStatus = DTO.MaritalStatus;
                 _IsActive = DTO.IsActive;
                 _ModifiedBy = DTO.ModifiedBy;
                 _ModifiedDate = DTO.ModifiedDate;
                 _CreatedBy = DTO.CreatedBy;
                 _CreatedDate = DTO.CreatedDate;
             }
         }
         private Master_Marital_Status GetDTO()
         {
             Master_Marital_Status DTO = new Master_Marital_Status();
             DTO.ID = _ID;
             DTO.MaritalStatus = _MaritalStatus;
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
             Master_MaritalStatusBusinessObject BO = new Master_MaritalStatusBusinessObject();

             if (BO.IMaritalstatusReferedinEmployee(_ID))
             {
                 return "Already Referred";
             }
            
             return String.Empty;
         }
         public String Validate()
         {
             Master_MaritalStatusBusinessObject BO = new Master_MaritalStatusBusinessObject();

             if (BO.IsMaritialStatusExists(_MaritalStatus, _ID))
             {
                 return "Marital Status already exists";
             }
             //if (_ID != 0)
             //{
             //    return CheckReference();
             //}
             else if (CheckReference() != String.Empty)
             {
                 if (!_IsActive)
                 {
                     return CheckReference();
                 }
             }
                
             return String.Empty;


            // return String.Empty;
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
                 Master_MaritalStatusBusinessObject BO = new Master_MaritalStatusBusinessObject();
                 Master_Marital_Status DTO = GetDTO();

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
         public static Master_MaritialStatus[] GetMaritalStatus()
         {
             Master_Marital_Status[] RolesDT = new Master_MaritalStatusBusinessObject().GetMaritialStatusMaster("IsActive = 1");

             Master_MaritialStatus[] Roles = new Master_MaritialStatus[RolesDT.Length];

             for (int i = 0; i < Roles.Length; i++)
             {
                 Roles[i] = new Master_MaritialStatus();

                 Roles[i].Update(RolesDT[i]);
             }

             return Roles;
         }
         public static Master_MaritialStatus[] GetInActiveMaritalStatus()
         {
             Master_Marital_Status[] RolesDT = new Master_MaritalStatusBusinessObject().GetMaritialStatusMaster("IsActive = 0");

             Master_MaritialStatus[] Roles = new Master_MaritialStatus[RolesDT.Length];

             for (int i = 0; i < Roles.Length; i++)
             {
                 Roles[i] = new Master_MaritialStatus();

                 Roles[i].Update(RolesDT[i]);
             }

             return Roles;
         }
         public static Master_MaritialStatus[] GetAllMaritalStatus()
         {
             Master_Marital_Status[] CountryDT = new Master_MaritalStatusBusinessObject().GetMaster_MaritalStatus();
             Master_MaritialStatus[] Country = new Master_MaritialStatus[CountryDT.Length];

             for (int i = 0; i < Country.Length; i++)
             {
                 Country[i] = new Master_MaritialStatus();

                 Country[i].Update(CountryDT[i]);
             }

             return Country;
         }
    }
}
