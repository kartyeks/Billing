
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
    /// Represents Location fields and methods.
    /// </summary>
    public class Location : JGridDataObject
    {
        private int _ID;
        private String _LocationName;
        private int _CountryID;
        private bool _IsActive;       
        private int _UpdateBy;
        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;
        private bool _IsNew;
        private String _CountryName;
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

        public String LocationName
        {
            get
            {
                return _LocationName;
            }
            set
            {
                _LocationName = value;
            }
        }
        public String CountryName
        {
            get
            {
                return _CountryName;
            }
            set
            {
                _CountryName = value;
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
       
        public int CountryID
        {
            get
            {
                return _CountryID;
            }
            set
            {
                 _CountryID = value;
            }
        }        

        public int UpdatedBy
        {
            get { return _UpdateBy; }
            set { _UpdateBy = value; }
        }
        public bool Status { get { return _IsActive; } set { _IsActive = value; } }
       
        private void Update(Master_Location Location)
        {
            if (Location != null)
            {
                _ID = Location.ID;
                _LocationName = Location.LocationName;
                _CountryID = Location.CountryID;
                _CreatedBy = Location.CreatedBy;
                _ModifiedBy = Location.ModifiedBy;
                _CreatedDate = Location.CreatedDate;
                _ModifiedDate = Location.ModifiedDate;
                _IsActive = Location.IsActive;         
                _IsNew = false;

            }
            else
            {
                _IsNew = true;
            }
        }

     
        public Location(Master_Location Location)
        {
            Update(Location);
        }
        
        public Location(String Location)
        {
            Update(new Master_LocationBusinessObject().GetLocationByLocation(Location));
        }
     
        public Location(int ID)
        {
            Master_Location Location = new Master_LocationBusinessObject().GetMaster_Location(ID);

            if (Location == null && ID > 0)
            {
                throw new IRCAException("Invalid Location", ID.ToString());
            }

            Update(Location);
        }

        
        public Location()
        {
            _ID = 0;
            _IsNew = true;
        }

        private String SaveLocation()
        {

            Master_Location Location = new Master_Location();
            Location.ID = _ID;
            Location.LocationName = _LocationName;
            Location.CountryID = _CountryID;
            Location.CreatedBy = _CreatedBy;
            Location.CreatedDate = _CreatedDate;
            Location.ModifiedBy = _ModifiedBy;
            Location.ModifiedDate = DateTime.Now;         
            Location.IsActive = _IsActive;

            if (_IsNew)
            {
                Location.CreatedBy = _UpdateBy;
                Location.CreatedDate = DateTime.Now;
                Location.ID = new Master_LocationBusinessObject().Create(Location);
            }
            else
            {
                Location.ModifiedBy = _UpdateBy;
                Location.ModifiedDate = DateTime.Now;
                Location.ID = _ID;
                new Master_LocationBusinessObject().Update(Location);
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

            return SaveLocation();
        }
        private String CheckReference()
        {
            Master_LocationBusinessObject LocationBO = new Master_LocationBusinessObject();

            if (LocationBO.IsLocationRefered(_ID))
            {
                return HRManagerDefs.LocationMessages.LOCATION_REFERED;
            }
            return String.Empty;
        }
        private String Validate()
        {
            Master_LocationBusinessObject RoleBO = new Master_LocationBusinessObject();

            if (_LocationName == String.Empty)
            {
                return HRManagerDefs.LocationMessages.EMPTY_LocationName;
            }
            else if (RoleBO.IsLocationExists(_LocationName, _CountryID ,_ID))
            {
                return HRManagerDefs.LocationMessages.LOCATION_EXISTS;
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
       
        public String Activate(int ActivatedBy)
        {
            _UpdateBy = ActivatedBy;

            _IsActive = true;

            return SaveLocation();
        }
            
        public String DeActivate(int DeActivatedBy)
        {            
            String Status = CheckReference();
            _UpdateBy = DeActivatedBy;
            if (Status != String.Empty)
            {
                return Status;
            }
            else
            {
                _IsActive = false;

                return SaveLocation();
            }
        }

        public static Location[] GetCountryLocations(int countryid)
        {
            Master_Location[] LocationDT = new Master_LocationBusinessObject().GetAllLocationsForCountry(countryid);

            Location[] Location = new Location[LocationDT.Length];

            for (int i = 0; i < Location.Length; i++)
            {
                Location[i] = new Location(LocationDT[i]);
            }

            return Location;
        }
        public static Location[] GetAllLocation()
        {
            Master_Location[] LocationDT = new Master_LocationBusinessObject().GetAllLocations();

            Location[] Location = new Location[LocationDT.Length];

            for (int i = 0; i < Location.Length; i++)
            {
                Location[i] = new Location(LocationDT[i]);
            }

            return Location;
        }

       

        public static Location[] GetAllInActiveLocations()
        {
            Master_Location[] LocationsDT = new Master_LocationBusinessObject().GetAllInActiveLocationsOrderByLocation();
            Location[] Locations = new Location[LocationsDT.Length];

            for (int i = 0; i < Locations.Length; i++)
            {
                Locations[i] = new Location(LocationsDT[i]);
            }

            return Locations;
        }

        #region JGridDataObject Members

        public object GetGridData()
        {
            LocationDisplayDetails Location = new LocationDisplayDetails();

            Location.LocationID = _ID;
            Location.LocationName = _LocationName;         
            Location.CountryID = _CountryID;
            Location.Country = new Country(_CountryID).CountryName;           
            Location.IsActive = _IsActive;
            Location.Status = _IsActive;
            return Location;
        }

        #endregion
    }
    public class LocationDisplayDetails
    {
        public int LocationID;
        public String LocationName;    
        public int CountryID;
        public String Country;
        public bool IsActive;
        public bool Status;   
    }
}
