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
    public class Country : JGridDataObject
    {
        private int _ID;
        private String _CountryName;
        private String _CountryCode;
        private bool _IsActive;
        
        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;
       

        public int ID{ get{ return _ID;}set{_ID = value; }}
        public String CountryCode { get { return _CountryCode; } set { _CountryCode = value; } }
        public String CountryName { get { return _CountryName; } set { _CountryName = value; } }
        public bool IsActive{get{ return _IsActive;} set{_IsActive = value; }}
       
        public int CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }
        public DateTime CreatedDate { get { return _CreatedDate; } set { _CreatedDate = value; } }
        public int ModifiedBy { get { return _ModifiedBy; } set { _ModifiedBy = value; } }
        public DateTime ModifiedDate { get { return _ModifiedDate; } set { _ModifiedDate = value; } }
        public bool Status { get { return _IsActive; } set { _IsActive = value; } }

        public Country()
        {
        }
        public Country(int ID)
        {
            Update(new Master_CountryBusinessObject().GetMaster_Country(ID));
        }

        public void Update(Master_Country DTO)
        {
            if (DTO != null)
            {
                _ID = DTO.ID;
                _CountryCode = DTO.CountryCode;
                _CountryName = DTO.CountryName;
                _IsActive = DTO.IsActive;
                _ModifiedBy = DTO.ModifiedBy;
                _ModifiedDate = DTO.ModifiedDate;
                _CreatedBy = DTO.CreatedBy;
                _CreatedDate = DTO.CreatedDate;
            }
        }
        private Master_Country GetDTO()
        {
            Master_Country DTO = new Master_Country();
            DTO.ID = _ID;
            DTO.CountryCode = _CountryCode;
            DTO.CountryName = _CountryName;
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
            Master_CountryBusinessObject BO = new Master_CountryBusinessObject();

            if (BO.ICountryRefered(_ID))
            {
                return HRManagerDefs.CountrytMessages.COUNTRY_REFERED;
            }
            if(BO.ICountryReferedinLocation(_ID))
            {
                return "Already Referred";
            }
            return String.Empty;
        }

        public String Validate()
        {
            Master_CountryBusinessObject BO = new Master_CountryBusinessObject();
            Master_Country DTO = GetDTO();

            if (BO.IsCountryCodeExists(_CountryCode, _ID))
            {
                return "Country Code already exists";
            }
            else if (BO.IsCountryNameExists(_CountryName, _ID))
            {
                return "Country Name already exists";
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
                Master_CountryBusinessObject BO = new Master_CountryBusinessObject();
                Master_Country DTO = GetDTO();

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
         
     
        public static Country[] Getcountries()
        {
            Master_Country[] RolesDT = new Master_CountryBusinessObject().GetCountryMaster("IsActive = 1");

            Country[] Roles = new Country[RolesDT.Length];

            for (int i = 0; i < Roles.Length; i++)
            {
                Roles[i] = new Country();
                
                Roles[i].Update(RolesDT[i]);
            }

            return Roles;
        }
        public static Country[] GetInActivecountries()
        {
            Master_Country[] RolesDT = new Master_CountryBusinessObject().GetCountryMaster("IsActive = 0");

            Country[] Roles = new Country[RolesDT.Length];

            for (int i = 0; i < Roles.Length; i++)
            {
                Roles[i] = new Country();

                Roles[i].Update(RolesDT[i]);
            }

            return Roles;
        }

        public static Country[] GetAllCountry()
        {
            Master_Country[] CountryDT = new Master_CountryBusinessObject().GetMaster_Country();
            Country[] Country = new Country[CountryDT.Length];

            for (int i = 0; i < Country.Length; i++)
            {
                Country[i] = new Country();

                Country[i].Update(CountryDT[i]);
            }

            return Country;
        }

    }
}
