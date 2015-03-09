using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonManager.DTO;
using CommonManager.BusinessObjects;

namespace CommonManager.Entity
{
    /// <summary>
    /// Entity class for country. This will manage create / modify entities
    /// </summary>
    public class Country
    {
        private int _ID;
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

        /// <summary>
        /// Update the entity based on the DTO object.
        /// </summary>
        /// <param name="Country">DTO object</param>
        private void Update(Common_Country Country)
        {
            _ID = Country.ID;
            _CountryName = Country.Country;
        }

        /// <summary>
        /// Construct the object based on DTO
        /// </summary>
        /// <param name="Country">DTO object</param>        
        public Country(Common_Country Country)
        {
            Update(Country);
        }

        /// <summary>
        /// Construct the object by the ID.
        /// </summary>
        /// <param name="ID">Country ID</param>
        public Country(int ID)
        {
            Common_Country Country = new Common_CountryBusinessObject().GetCommon_Country(ID);
            Update(Country);
        }

        /// <summary>
        /// This will be used when the entity passed directly to any method
        /// </summary>
        /// <returns>Name Of the The country</returns>
        public override string ToString()
        {
            return _CountryName;
        }

        /// <summary>
        /// Get all the countries
        /// </summary>
        /// <returns>Arry Of Country objects</returns>
        public static Country[] GetAllCountry()
        {
            Common_Country[] CountryDT = new Common_CountryBusinessObject().GetCommon_Country();
            Country[] Country = new Country[CountryDT.Length];

            for (int i = 0; i < Country.Length; i++)
            {
                Country[i] = new Country(CountryDT[i]);
            }

            return Country;
        }

        public static Country[] GetCountryCombo()
        {
            Common_Country[] CountryDT = new Common_CountryBusinessObject().GetCommon_Country();

            Country[] Country = new Country[CountryDT.Length];

            for (int i = 0; i < Country.Length; i++)
            {
                Country[i] = new Country(CountryDT[i]);
            }
            return Country;
        }
    }
}
