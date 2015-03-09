using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;

namespace HRManager.BusinessObjects
{
    public partial class Hr_DepartmentBusinessObject
    {
        /// <summary>
        /// Get Department By Department Name
        /// </summary>
        /// <param name="DepartmentName">field contaions Department Name</param>
        /// <returns>data related given Department Name in case of success otherwise it return null</returns>
        public Hr_Department GetDepartmentByDepartment(String DepartmentName)
        {
            Hr_Department[] Department = GetDepartments(" DepartmentName = '" + DepartmentName + "'");

            if (Department != null && Department.Length > 0)
            {
                return Department[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Get Department By Department Name
        /// </summary>
        /// <param name="DepartmentName">field contaions Department Name</param>
        /// <returns>data related given Department Name in case of success otherwise it return null</returns>
        public Hr_Department GetDepartmentByIsHR(bool IsHR)
        {
            Hr_Department[] Department = GetDepartments(" IsHR = '" + IsHR + "'");

            if (Department != null && Department.Length > 0)
            {
                return Department[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Get Department By Department Name
        /// </summary>
        /// <param name="DepartmentName">field contaions Department Name</param>
        /// <returns>data related given Department Name in case of success otherwise it return null</returns>
        public Hr_Department GetDepartmentByIsFinance(bool IsFinance)
        {
            Hr_Department[] Department = GetDepartments(" IsFinance = '" + IsFinance + "'");

            if (Department != null && Department.Length > 0)
            {
                return Department[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Get Departments data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Hr_Department object</returns>
        public Hr_Department[] GetDepartments(String Filter)
        {
            const String Qry = " SELECT * FROM Hr_Department";

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

            Hr_Department[] DepartmentDetails = new Hr_Department[dt.Rows.Count];

            for (int i = 0; i < DepartmentDetails.Length; i++)
            {
                DepartmentDetails[i] = new Hr_Department();
                DepartmentDetails[i].ID = (int)dt.Rows[i]["ID"];
                DepartmentDetails[i].DepartmentName = (String)dt.Rows[i]["DepartmentName"];
                DepartmentDetails[i].ParentID = (int)dt.Rows[i]["ParentID"];
                DepartmentDetails[i].Description = (String)dt.Rows[i]["Description"];
                DepartmentDetails[i].IsDepartment = (bool)dt.Rows[i]["IsDepartment"];
                DepartmentDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                if (dt.Rows[i]["HOD"].ToString() != string.Empty)
                    DepartmentDetails[i].HOD = (int)dt.Rows[i]["HOD"];
                else
                    DepartmentDetails[i].HOD = 0;
            }

            return DepartmentDetails;
        }
        /// <summary>
        /// Get Departments data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Hr_Department object</returns>
        public Hr_Department[] GetHr_DepartmentAsec()
        {
            const String Qry = " select * from hr_department order by parentid,departmentname ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = string.Format(Qry);

            DataTable dt = EE.ExecuteDataTable(exQry);

            Hr_Department[] DepartmentDetails = new Hr_Department[dt.Rows.Count];

            for (int i = 0; i < DepartmentDetails.Length; i++)
            {
                DepartmentDetails[i] = new Hr_Department();
                DepartmentDetails[i].ID = (int)dt.Rows[i]["ID"];
                DepartmentDetails[i].DepartmentName = (String)dt.Rows[i]["DepartmentName"];
                DepartmentDetails[i].ParentID = (int)dt.Rows[i]["ParentID"];
                DepartmentDetails[i].Description = (String)dt.Rows[i]["Description"];
                DepartmentDetails[i].IsDepartment = (bool)dt.Rows[i]["IsDepartment"];
                DepartmentDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                if (dt.Rows[i]["HOD"].ToString() != string.Empty)
                    DepartmentDetails[i].HOD = (int)dt.Rows[i]["HOD"];
                else
                    DepartmentDetails[i].HOD = 0;
            }

            return DepartmentDetails;
        }

        /// <summary>
        /// Get Departments data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Hr_Department object</returns>
        public Hr_Department[] GetHr_DepartmentAsecBranchWise(int BranchID)
        {
            const String Qry = " SELECT DISTINCT HD.* FROM Hr_Department HD " +
                               " INNER JOIN Assign_Emp_Department D ON HD.ID=D.DepartmentID " +
                               " INNER JOIN Assign_Emp_Branch B ON B.EMPID=D.EMPID " +
                               " WHERE BranchID={0} AND D.IsActive=1 AND B.IsActive=1 order by ParentID,DepartmentName ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = string.Format(Qry, BranchID);

            DataTable dt = EE.ExecuteDataTable(exQry);

            Hr_Department[] DepartmentDetails = new Hr_Department[dt.Rows.Count];

            for (int i = 0; i < DepartmentDetails.Length; i++)
            {
                DepartmentDetails[i] = new Hr_Department();
                DepartmentDetails[i].ID = (int)dt.Rows[i]["ID"];
                DepartmentDetails[i].DepartmentName = (String)dt.Rows[i]["DepartmentName"];
                DepartmentDetails[i].ParentID = (int)dt.Rows[i]["ParentID"];
                DepartmentDetails[i].Description = (String)dt.Rows[i]["Description"];
                DepartmentDetails[i].IsDepartment = (bool)dt.Rows[i]["IsDepartment"];
                DepartmentDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
                if (dt.Rows[i]["HOD"].ToString() != string.Empty)
                    DepartmentDetails[i].HOD = (int)dt.Rows[i]["HOD"];
                else
                    DepartmentDetails[i].HOD = 0;
            }

            return DepartmentDetails;
        }
        /// <summary>
        /// Get LocationTypes data from the database
        /// </summary>
        /// <param name="Filter">Refine the query as per requirment</param>
        /// <returns>Array of Master_LocationType object</returns>
        public int GetAllActiveDepartmentChildCount(int ParentID)
        {
            const String Qry = "SELECT isnull(count(*),0) childCount FROM Hr_Department WHERE IsActive=1 and ParentID={0}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, ParentID);
            DataTable dt = EE.ExecuteDataTable(exQry);

            return (int)dt.Rows[0]["childCount"];
        }
        /// <summary>
        /// check Department Existance in the database.
        /// </summary>
        /// <param name="Department">field contains Department name</param>
        /// <param name="ID">field contains Department ID</param>
        /// <returns>True for Exist and false for not exist</returns>
        public bool IsDepartmentExists(String Department, int ID)
        {
            const String Qry = " IF EXISTS (SELECT ID FROM Hr_Department WHERE DepartmentName = '{0}' AND ID<>{1})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, Department, ID.ToString());
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }

    }
}
