using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS91.Services.DataBlock;
using System.Data;
using HRManager.DTO;
using IRCAKernel;
using HRManager.Entity.ExitManagement;
using HRManager.DTOEXT;
 
namespace HRManager.BusinessObjects
{
    public partial class HTMLEditorDetailsBusinessObject
    {
        public bool IsEmployeeLetterExists(int EmployeeID, string fileName)
        {
            const String Qry = " IF EXISTS (SELECT EMPID FROM HTMLEditorDetails WHERE EMPID = {0} AND HTMLFileName = '{1}')"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmployeeID, fileName);
            return string.Concat(EE.ExecuteScalar(exQry)) == "0";
        }
        public DataTable getEmpLetter(int EmployeeID, string fileName)
        {
            const String Qry = "SELECT "  
                                  + " 	TA.EMPID"  
                                  + " 	,HTMLContent"  
                                  + " 	,EmailID "  
                                  + " FROM "  
                                  + " 	HTMLEditorDetails TA  "  
                                  + " INNER JOIN "  
                                  + " 	Employee_OccupationDetails EO "  
                                  + " ON "  
                                  + " 	EO.EmployeeID=TA.EMPID "  
                                  + " WHERE "  
                                  + " 	EMPID = '{0}'"  
                                  + " AND "  
                                  + " 	EO.IsActive=1"  
                                  + " AND "  
                                  + " 	HTMLFileName = '{1}' "  
                                  + " AND "  
                                  + " 	TA.EditedDateTime = "  
                                  + " ("  
                                  + " 	SELECT "  
                                  + " 		MAX(EditedDateTime) "  
                                  + " 	FROM  "  
                                  + " 		HTMLEditorDetails TAL "  
                                  + " 	WHERE "  
                                  + " 		TAL.EMPID = EO.EmployeeID "  
                                  + " 	AND "  
                                  + " 		HTMLFileName = '{1}' "  
                                  + " ) ";
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, EmployeeID, fileName);
            return EE.ExecuteDataTable(exQry);

        }
    }
}
