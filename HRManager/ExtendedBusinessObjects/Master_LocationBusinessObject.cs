using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.BusinessObjects;
using HRManager.DTO;
using System.Data;
using HRManager.Entity;

namespace HRManager.BusinessObjects
{
    public partial class Master_LocationBusinessObject
    {
    
        public Master_Location GetLocationByLocation(String Location)
        {
            Master_Location[] Locations = GetLocation(" Location = '" + Location + "'");

            if (Locations != null && Locations.Length > 0)
            {
                return Locations[0];
            }
            else
            {
                return null;
            }
        }
        
        public Master_Location[] GetLocation(String Filter)
        {
            const String Qry = " SELECT * FROM Master_Location";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            if (Filter == String.Empty)
            {
                exQry.Query = string.Format(Qry);
            }
            else
            {
                exQry.Query = string.Format(Qry) + " WHERE " + Filter;
            }

            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_Location[] LocationDetails = new Master_Location[dt.Rows.Count];

            for (int i = 0; i < LocationDetails.Length; i++)
            {
                LocationDetails[i] = new Master_Location();
                LocationDetails[i].ID = (int)dt.Rows[i]["ID"];
                LocationDetails[i].LocationName = (String)dt.Rows[i]["LocationName"];
                LocationDetails[i].CountryID = (int)dt.Rows[i]["CountryID"];     
                LocationDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
            }

            return LocationDetails;
        }
        public Master_Location[] GetAllInActiveLocation()
        {
            const String Qry = "SELECT * FROM Master_Location WHERE IsActive=0";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_Location[] LocationDetails = new Master_Location[dt.Rows.Count];

            for (int i = 0; i < LocationDetails.Length; i++)
            {
                LocationDetails[i] = new Master_Location();
                LocationDetails[i].ID = (int)dt.Rows[i]["ID"];
                LocationDetails[i].LocationName = (String)dt.Rows[i]["LocationName"];
                LocationDetails[i].CountryID = (int)dt.Rows[i]["CountryID"];  
                LocationDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
            
            }

            return LocationDetails;
        }

        public Master_Location[] GetAllLocationsForCountry(int CountryID)
        {
            const String Qry = " SELECT * FROM Master_Location WHERE IsActive=1 and CountryID={0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, CountryID);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_Location[] LocationDetails = new Master_Location[dt.Rows.Count];

            for (int i = 0; i < LocationDetails.Length; i++)
            {
                LocationDetails[i] = new Master_Location();
                LocationDetails[i].ID = (int)dt.Rows[i]["ID"];
                LocationDetails[i].LocationName = (String)dt.Rows[i]["LocationName"];
                LocationDetails[i].CountryID = (int)dt.Rows[i]["CountryID"];
                LocationDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
            }

            return LocationDetails;
        }  

        public Master_Location[] GetAllLocations()
        {
            //const String Qry = " SELECT * FROM Master_Location WHERE IsActive=1";
            const String Qry = " SELECT * FROM Master_Location ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_Location[] LocationDetails = new Master_Location[dt.Rows.Count];

            for (int i = 0; i < LocationDetails.Length; i++)
            {
                LocationDetails[i] = new Master_Location();
                LocationDetails[i].ID = (int)dt.Rows[i]["ID"];
                LocationDetails[i].LocationName = (String)dt.Rows[i]["LocationName"];
                LocationDetails[i].CountryID = (int)dt.Rows[i]["CountryID"];  
                LocationDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];                
            }

            return LocationDetails;
        }  

        public Master_Location[] GetAllInActiveLocationsOrderByLocation()
        {
            Master_Location[] Location = GetAllInActiveLocation();

            if (Location != null && Location.Length >= 0)
            {
                return Location;
            }
            else
            {
                return null;
            }
        }      
       
        public bool IsLocationExists(String LocationName,int CountryID, int ID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Master_Location WHERE LocationName = '{0}' AND CountryID = {1} AND ID<>{2})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, LocationName,CountryID.ToString(), ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }

        public bool IsLocationRefered(int ID)
        {
            const String Qry = " IF EXISTS ( SELECT ID FROM Master_Holidays WHERE LocationID = '{0}' "
                                + " Union SELECT ID FROM Employee_OccupationDetails WHERE LocationID = '{0}')" 
                //+ " Union SELECT ID FROM Loan_Request WHERE LoanID = '{0}' ) "
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }

    }
}
