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
using HRManager.DTOEXT;

namespace HRManager.Entity
{
    public class Holidays : JGridDataObject
    {
        private int _ID;
        private int _LocationID;
        private String _HolidayName;
        private DateTime _HolidayDate;
        private String _Description;
        private String _Status;
        private int _RequestingTo;

        private bool _IsActive;

        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;
        private String _HolidayDateName;


        public int ID { get { return _ID; } set { _ID = value; } }
        public int LocationID { get { return _LocationID; } set { _LocationID = value; } }
        public String HolidayName { get { return _HolidayName; } set { _HolidayName = value; } }
        public DateTime HolidayDate { get { return _HolidayDate; } set { _HolidayDate = value; } }
        public String Description { get { return _Description; } set { _Description = value; } }
        public String Status { get { return _Status; } set { _Status = value; } }
        public int RequestingTo { get { return _RequestingTo; } set { _RequestingTo = value; } }
        
        public bool IsActive { get { return _IsActive; } set { _IsActive = value; } }

        public int CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }
        public DateTime CreatedDate { get { return _CreatedDate; } set { _CreatedDate = value; } }
        public int ModifiedBy { get { return _ModifiedBy; } set { _ModifiedBy = value; } }
        public DateTime ModifiedDate { get { return _ModifiedDate; } set { _ModifiedDate = value; } }
        public String HolidayDateName { get { return _HolidayDateName; } set { _HolidayDateName = value; } }

         public Holidays()
        {
        }
         public Holidays(int ID)
        {
            Update(new Master_HolidaysBusinessObject().GetMaster_Holidays(ID));
        }
         public void Update(Master_Holidays DTO)
         {
             if (DTO != null)
             {
                 _ID = DTO.ID;
                 _LocationID = DTO.LocationID;
                 _HolidayName = DTO.HolidayName;
                 _HolidayDate = DTO.HolidayDate;
                 _Description = DTO.Description;
                 _Status = DTO.Status;
                 _RequestingTo = DTO.RequestingTo;
                 _IsActive = DTO.IsActive;
                 _ModifiedBy = DTO.ModifiedBy;
                 _ModifiedDate = DTO.ModifiedDate;
                 _CreatedBy = DTO.CreatedBy;
                 _CreatedDate = DTO.CreatedDate;
                 if (DTO is Master_HolidayEXT)
                 {
                     _HolidayDateName = ((Master_HolidayEXT)DTO).HolidayDateName;
                 }
             }
         }
         private Master_Holidays GetDTO()
         {
             Master_Holidays DTO = new Master_Holidays();
             DTO.ID = _ID;
             DTO.LocationID = _LocationID;
             DTO.HolidayName = _HolidayName;
             DTO.HolidayDate = _HolidayDate;
             DTO.Description = _Description;
             DTO.Status = _Status;
             DTO.RequestingTo = _RequestingTo;
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
             Master_HolidaysBusinessObject BO = new Master_HolidaysBusinessObject();

             if (BO.IsHolidayNameExists(_HolidayName,_LocationID, _ID))
             {
                 return "Holiday Name already exists";
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
                 Master_HolidaysBusinessObject BO = new Master_HolidaysBusinessObject();
                 Master_Holidays DTO = GetDTO();

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
         
         public static Holidays[] GetHolidays()
         {
             Master_Holidays[] RolesDT = new Master_HolidaysBusinessObject().GetHolidayMaster("IsActive = 1");

             Holidays[] Roles = new Holidays[RolesDT.Length];

             for (int i = 0; i < Roles.Length; i++)
             {
                 Roles[i] = new Holidays();

                 Roles[i].Update(RolesDT[i]);
             }

             return Roles;
         }
         public static Holidays[] GetInActiveHolidays()
         {
             Master_Holidays[] RolesDT = new Master_HolidaysBusinessObject().GetHolidayMaster("IsActive = 0");

             Holidays[] Roles = new Holidays[RolesDT.Length];

             for (int i = 0; i < Roles.Length; i++)
             {
                 Roles[i] = new Holidays();

                 Roles[i].Update(RolesDT[i]);
             }

             return Roles;
         }


         public static Holidays[] GetAllHolidayDetails()
         {
             Master_Holidays[] CountryDT = new Master_HolidaysBusinessObject().GetAllHolidayMaster();
             Holidays[] Country = new Holidays[CountryDT.Length];

             for (int i = 0; i < Country.Length; i++)
             {
                 Country[i] = new Holidays();

                 Country[i].Update(CountryDT[i]);
             }

             return Country;
         }
         public object GetGridData()
         {
             HolidayGridDetails Holiday = new HolidayGridDetails();

             Holiday.ID = _ID;
             Holiday.LocationID = _LocationID;
             Holiday.HolidayName = _HolidayName;
             //Holiday.HolidayDate = _HolidayDate;
             Holiday.HolidayDate = _HolidayDateName;
             Holiday.Description = _Description;
             Holiday.RequestingTo = _RequestingTo;
             Holiday.Status = _IsActive;
             Holiday.IsActive = _IsActive;
             Holiday.CreatedBy = _CreatedBy;
             Holiday.CreatedDate = _CreatedDate;
             Holiday.ModifiedBy = _ModifiedBy;
             Holiday.ModifiedDate = _ModifiedDate;

             return Holiday;
         }
    }
    public class HolidayGridDetails
    {
        public int ID;
        public int LocationID;
        public String HolidayName;
        public String HolidayDate;
        public String Description;
        public int RequestingTo;
        public bool IsActive;
        public int CreatedBy;
        public DateTime CreatedDate;
        public int ModifiedBy;
        public DateTime ModifiedDate;
        public bool Status;
    }
}
