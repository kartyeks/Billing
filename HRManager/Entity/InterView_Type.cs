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
    public class InterView_Type : JGridDataObject
    {
        private int _ID;
        private String _InterviewType;
        private String _Description;
       
        private bool _IsActive;

        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;


        public int ID { get { return _ID; } set { _ID = value; } }
        public String InterviewType { get { return _InterviewType; } set { _InterviewType = value; } }
        public String Description { get { return _Description; } set { _Description = value; } }
        
        public bool IsActive { get { return _IsActive; } set { _IsActive = value; } }

        public int CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }
        public DateTime CreatedDate { get { return _CreatedDate; } set { _CreatedDate = value; } }
        public int ModifiedBy { get { return _ModifiedBy; } set { _ModifiedBy = value; } }
        public DateTime ModifiedDate { get { return _ModifiedDate; } set { _ModifiedDate = value; } }
        public bool Status { get { return _IsActive; } set { _IsActive = value; } }

         public InterView_Type()
        {
        }
         public InterView_Type(int ID)
        {
            Update(new Master_Interview_TypeBusinessObject().GetMaster_Interview_Type(ID));
        }
         public void Update(Master_Interview_Type DTO)
         {
             if (DTO != null)
             {
                 _ID = DTO.ID;
                 _InterviewType = DTO.InterviewType;
                 _Description = DTO.Description;
                 _IsActive = DTO.IsActive;
                 _ModifiedBy = DTO.ModifiedBy;
                 _ModifiedDate = DTO.ModifiedDate;
                 _CreatedBy = DTO.CreatedBy;
                 _CreatedDate = DTO.CreatedDate;
             }
         }
         private Master_Interview_Type GetDTO()
         {
             Master_Interview_Type DTO = new Master_Interview_Type();
             DTO.ID = _ID;
             DTO.InterviewType = _InterviewType;
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
         public String Validate()
         {
             Master_Interview_TypeBusinessObject BO = new Master_Interview_TypeBusinessObject();

             if (BO.IsInterviewtypeExists(_InterviewType, _ID))
             {
                 return "Interview Type already exists";
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
                 Master_Interview_TypeBusinessObject BO = new Master_Interview_TypeBusinessObject();
                 Master_Interview_Type DTO = GetDTO();

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
         public static InterView_Type[] GetInterviewTypes()
         {
             Master_Interview_Type[] RolesDT = new Master_Interview_TypeBusinessObject().GetInterviewTypeMaster("IsActive = 1");

             InterView_Type[] Roles = new InterView_Type[RolesDT.Length];

             for (int i = 0; i < Roles.Length; i++)
             {
                 Roles[i] = new InterView_Type();

                 Roles[i].Update(RolesDT[i]);
             }

             return Roles;
         }

         public static InterView_Type[] GetAllInterviewTypes()
         {
             Master_Interview_Type[] CountryDT = new Master_Interview_TypeBusinessObject().GetMaster_Interview_Type();
             InterView_Type[] Country = new InterView_Type[CountryDT.Length];

             for (int i = 0; i < Country.Length; i++)
             {
                 Country[i] = new InterView_Type();

                 Country[i].Update(CountryDT[i]);
             }

             return Country;
         }
         public static InterView_Type[] GetInActiveInterviewTypes()
         {
             Master_Interview_Type[] RolesDT = new Master_Interview_TypeBusinessObject().GetInterviewTypeMaster("IsActive = 0");

             InterView_Type[] Roles = new InterView_Type[RolesDT.Length];

             for (int i = 0; i < Roles.Length; i++)
             {
                 Roles[i] = new InterView_Type();

                 Roles[i].Update(RolesDT[i]);
             }

             return Roles;
         }
    }
    }

