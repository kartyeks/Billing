using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;


namespace HRManager.BusinessObjects
{
    public partial class Master_EmployeeTypeBusinessObject
    {
        /// <summary>
        /// Get EmployeeType By EmployeeType Name
        /// </summary>
        /// <param name="EmployeeTypeName">field contaions EmployeeType Name</param>
        /// <returns>data related given Designation Name in case of success otherwise it return null</returns>
        public Master_EmployeeType GetEmployeeTypeByEmployeeType(String EmployeeType)
        {
            Master_EmployeeType[] Name = GetEmployeeTypes("Name = '" + EmployeeType + "'");

            if (Name != null && Name.Length > 0)
            {
                return Name[0];
            }
            else
            {
                return null;
            }
        }

        public Master_EmployeeType[] GetAllInActiveEmployeeTypesOrderByEmployeeTypes()
        {
            Master_EmployeeType[] EmployeeType = GetAllInActiveEmployeeType();

            if (EmployeeType != null && EmployeeType.Length >= 0)
            {
                return EmployeeType;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// Get LocationTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        public String GetEmployeeTypeForSearch()
        {
            const String Qry = " SELECT distinct met.Name as EmployeeType FROM Master_EmployeeType me" +
                               " inner join master_employeetype met on (me.id=met.id)";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);
            String EmployeeType = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmployeeType = EmployeeType + ";" + (String)dt.Rows[i]["EmployeeType"] + ":" + (String)dt.Rows[i]["EmployeeType"];
             
            }

            return EmployeeType;
        }



        public Master_EmployeeType[] GetAllInActiveEmployeeType()
        {
            const String Qry = "SELECT * FROM Master_EmployeeType WHERE IsActive=0";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);
            Master_EmployeeType[] EmployeeTypeDetails = new Master_EmployeeType[dt.Rows.Count];
            for (int i = 0; i < EmployeeTypeDetails.Length; i++)
            {
                EmployeeTypeDetails[i] = new Master_EmployeeType();
                EmployeeTypeDetails[i].ID = (int)dt.Rows[i]["ID"];
                EmployeeTypeDetails[i].Name = (String)dt.Rows[i]["Name"];
                EmployeeTypeDetails[i].MinDurationMonth = (String)dt.Rows[i]["MinDurationMonth"];
                EmployeeTypeDetails[i].IsService = (bool)dt.Rows[i]["IsService"];
                EmployeeTypeDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                EmployeeTypeDetails[i].IsPermanent = (bool)dt.Rows[i]["IsPermanent"];
            }

            return EmployeeTypeDetails;
        }
        public Master_EmployeeType[] GetAllActiveEmployeeType()
        {
            const String Qry = "SELECT * FROM Master_EmployeeType WHERE IsActive=1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);
            Master_EmployeeType[] EmployeeTypeDetails = new Master_EmployeeType[dt.Rows.Count];
            for (int i = 0; i < EmployeeTypeDetails.Length; i++)
            {
                EmployeeTypeDetails[i] = new Master_EmployeeType();
                EmployeeTypeDetails[i].ID = (int)dt.Rows[i]["ID"];
                EmployeeTypeDetails[i].Name = (String)dt.Rows[i]["Name"];
                EmployeeTypeDetails[i].MinDurationMonth = (String)dt.Rows[i]["MinDurationMonth"];
                EmployeeTypeDetails[i].IsService = (bool)dt.Rows[i]["IsService"];
                EmployeeTypeDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                EmployeeTypeDetails[i].IsPermanent = (bool)dt.Rows[i]["IsPermanent"];
            }

            return EmployeeTypeDetails;
        }
        /// <summary>
        /// Get LocationTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        public Master_EmployeeType[] GetAllEmployeeTypes()
        {
            const String Qry = " SELECT * FROM Master_EmployeeType WHERE IsActive=1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_EmployeeType[] EmployeeTypeDetails = new Master_EmployeeType[dt.Rows.Count];

            for (int i = 0; i < EmployeeTypeDetails.Length; i++)
            {
                EmployeeTypeDetails[i] = new Master_EmployeeType();
                EmployeeTypeDetails[i].ID = (int)dt.Rows[i]["ID"];
                EmployeeTypeDetails[i].Name = (String)dt.Rows[i]["Name"];
                EmployeeTypeDetails[i].MinDurationMonth = (String)dt.Rows[i]["MinDurationMonth"];
                EmployeeTypeDetails[i].IsService = (bool)dt.Rows[i]["IsService"];
                EmployeeTypeDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                EmployeeTypeDetails[i].IsPermanent = (bool)dt.Rows[i]["IsPermanent"];
            }

            return EmployeeTypeDetails;
        }
        /// <summary>
        /// Get Designations data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_EmployeeType object</returns>
        public Master_EmployeeType[] GetEmployeeTypes(String Filter)
        {
            const String Qry = " SELECT * FROM Master_EmployeeType";

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

            Master_EmployeeType[] EmployeeTypeDetails = new Master_EmployeeType[dt.Rows.Count];

            for (int i = 0; i < EmployeeTypeDetails.Length; i++)
            {
                EmployeeTypeDetails[i] = new Master_EmployeeType();
                EmployeeTypeDetails[i].ID = (int)dt.Rows[i]["ID"];
                EmployeeTypeDetails[i].Name = (String)dt.Rows[i]["Name"];
                EmployeeTypeDetails[i].MinDurationMonth = (String)dt.Rows[i]["MinDurationMonth"];
                EmployeeTypeDetails[i].IsService = (bool)dt.Rows[i]["IsService"];
                EmployeeTypeDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                EmployeeTypeDetails[i].IsPermanent = (bool)dt.Rows[i]["IsPermanent"];
            }

            return EmployeeTypeDetails;
        }
        /// <summary>
        /// check EmployeeType Existance in the database.
        /// </summary>
        /// <param name="EmployeeType">field contains EmployeeType name</param>
        /// <param name="ID">field contains EmployeeType ID</param>
        /// <returns>True for Exist and false for not exist</returns>
        public bool IsEmployeeTypeExists(String Name, int ID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Master_EmployeeType WHERE Name = '{0}' AND ID<>{1})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, Name, ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }

        public bool IsEmployeeTypeRefered(int ID)
        {
            const String Qry = " IF EXISTS (( select ID from Master_Employee_History where EmploymentTypeID = '{0}')) "
                // + " Union (SELECT ID FROM Assign_Emp_Loan WHERE LoanID = '{0}' ) "
                                //+ " Union (SELECT ID FROM Loan_Request WHERE LoanID = '{0}' ) )"
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
