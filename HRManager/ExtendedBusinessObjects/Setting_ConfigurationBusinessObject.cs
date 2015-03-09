using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.Entity;
using IS91.Services.DataBlock;
using System.Data;
using HRManager.DTO;

namespace HRManager.BusinessObjects
{
    public partial class Setting_ConfigurationBusinessObject
    {
        public Setting_Configurations[] GetSettingConfigurationsdetails(string Filter)
        {
            String Query = "SELECT * FROM Setting_Configuration";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            if (Filter == "")
                exQry.Query = Query;
            else
                exQry.Query = string.Format(Query) + " WHERE " + Filter;


            DataTable dt = EE.ExecuteDataTable(exQry);
            Setting_Configurations[] SettingConfigurationDetails = new Setting_Configurations[dt.Rows.Count];

            for (int i = 0; i < SettingConfigurationDetails.Length; i++)
            {
                SettingConfigurationDetails[i] = new Setting_Configurations();
                SettingConfigurationDetails[i].ID = (int)dt.Rows[i]["ID"];
                SettingConfigurationDetails[i].Name = (string)dt.Rows[i]["Name"];
                SettingConfigurationDetails[i].Value = (string)dt.Rows[i]["Value"];

            }

            return SettingConfigurationDetails;
        }
        public Setting_Configurations[] GetAllActiveSettingConfiguration()
        {
            return GetSettingConfigurationsdetails(String.Empty);
        }

        public Setting_Configurations GetSettingConfigurationBySettingConfiguration(String Name)
        {
            Setting_Configurations[] SettingConfigurations = GetSettingConfigurationsdetails(" Name = '" + Name + "'");

            if (SettingConfigurations.Length > 0)
            {
                return SettingConfigurations[0];
            }
            else
            {
                return null;
            }
        }





        public bool IsSettingConfigurationExists(String Name, int ID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Setting_Configuration WHERE Name = '{0}' AND ID <> {1})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, Name, ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }

        public string GetEmployeeTypeID(String Name)
        {
            const String Qry = "Select ID FROM Master_EmployeeType WHERE Name = '{0}' ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, Name);
            object ret = EE.ExecuteScalar(exQry);
            return string.Concat(ret, string.Empty);
        }
        public string GetMaritalStatusID(String MaritalStatus)
        {
            const String Qry = "Select ID FROM Master_MaritalStatus WHERE MaritalStatus = '{0}' ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, MaritalStatus);
            object ret = EE.ExecuteScalar(exQry);
            return string.Concat(ret, string.Empty);
        }
        public string GetCountryID(String CountryName)
        {
            const String Qry = "Select ID FROM Master_Country WHERE CountryName = '{0}' ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, CountryName);
            object ret = EE.ExecuteScalar(exQry);
            return string.Concat(ret, string.Empty);
        }
        public string GetLocationID(String LocationName)
        {
            const String Qry = "Select ID FROM Master_Location WHERE LocationName = '{0}' ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, LocationName);
            object ret = EE.ExecuteScalar(exQry);
            return string.Concat(ret, string.Empty);
        }
        public string GetTeamID(String TeamName)
        {
            const String Qry = "Select ID FROM Master_Team WHERE TeamName = '{0}' ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, TeamName);
            object ret = EE.ExecuteScalar(exQry);
            return string.Concat(ret, string.Empty);
        }
        public string GetDesignationID(String Designation)
        {
            const String Qry = "Select ID FROM Hr_Designation WHERE Designation = '{0}' ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, Designation);
            object ret = EE.ExecuteScalar(exQry);
            return string.Concat(ret, string.Empty);
        }
        public string GetExitTypeID(String exitType)
        {
            const String Qry = "Select ID FROM Master_TypeOfExit WHERE TypeOfExit = '{0}' ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, exitType);
            object ret = EE.ExecuteScalar(exQry);
            return string.Concat(ret, string.Empty);
        }
    }
}
