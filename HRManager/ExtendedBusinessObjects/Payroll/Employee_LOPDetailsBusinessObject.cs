using System;
using System.Data;
using IS91.Services.DataBlock;
using System.Collections;
using HRManager.DTO;
using HRManager.Entity;
namespace HRManager.BusinessObjects
{
public partial class Employee_LOPDetailsBusinessObject
{

        public Employee_LOPDetailsBusinessObject(bool noLock)
        {
            persistent = new PersistentObject(mapped);
            persistent.ExecuteWithNoLocks = noLock;
        }

         public void DeleteDuplicateLOP(string EmployeeID, string frmDate,string toDate)
        {
            //const String QryInv = " DELETE FROM Employee_LOPDetails Where EmployeeID = "
             //+ " (SELECT ID FROM  Master_Employees WHERE EmpCode='{0}') AND FromDate = '{1}' AND FromDate = '{2}' ";
            const String QryInv = " DELETE FROM Employee_LOPDetails Where EmployeeID ={0} "
                                + " AND FromDate = '{1}' AND ToDate = '{2}' AND IsUsed=0 ";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(QryInv, EmployeeID, frmDate,toDate);
            EE.ExecuteNonQuery(exQry);
        }
         public bool IsLOPDetailsUsed(string EmployeeID, string frmDate, string toDate)
         {
             const String QryInv = " SELECT ID FROM Employee_LOPDetails Where EmployeeID ={0} "
                                 + " AND FromDate = '{1}' AND ToDate = '{2}' AND IsUsed=1 ";

             ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
             ExecutionQuery exQry = new ExecutionQuery();
             exQry.Query = string.Format(QryInv, EmployeeID, frmDate, toDate);
             int id = 0;
             int.TryParse(string.Concat(EE.ExecuteScalar(exQry)), out id);
             return id!=0;
         }
         public int GetLOPDetailsID(string EmployeeID, string frmDate, string toDate)
         {
             const String QryInv = " SELECT ID FROM Employee_LOPDetails Where EmployeeID ={0} "
                                 + " AND FromDate = '{1}' AND ToDate = '{2}' AND IsUsed=0 ";

             ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
             ExecutionQuery exQry = new ExecutionQuery();
             exQry.Query = string.Format(QryInv, EmployeeID, frmDate, toDate);
             int id = 0;
             int.TryParse(string.Concat(EE.ExecuteScalar(exQry)),out id);
             return id;
         }
         public EmployeeLOP[] GetLOPForEmployee(string pDate,int empId)
         {
             const String QryInv = " SELECT * FROM Employee_LOPDetails Where EmployeeID = '{0}' AND ToDate < '{1}' AND IsUsed=0 ";

             ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
             ExecutionQuery exQry = new ExecutionQuery();
             exQry.Query = string.Format(QryInv, empId, pDate);
             DataTable dtLOP= EE.ExecuteDataTable(exQry);
             if (dtLOP != null)
             {
                 int k=0;
                 EmployeeLOP[] empLOP = new EmployeeLOP[dtLOP.Rows.Count];
                 foreach(DataRow dr in dtLOP.Rows )
                 {
                     empLOP[k] = new EmployeeLOP();
                     empLOP[k].ID = (int)dr["ID"];
                     empLOP[k].EmployeeID = empId;
                     empLOP[k].FromDate = (DateTime)dr["FromDate"];
                     empLOP[k].ToDate = (DateTime)dr["ToDate"];
                     empLOP[k].LOPDays = (Double)dr["LOPDays"];
                     k++;
                 }
                 return empLOP;
             }
             return null;
         }
   }
}
