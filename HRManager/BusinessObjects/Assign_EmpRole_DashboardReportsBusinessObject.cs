using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;
namespace HRManager.BusinessObjects
{
public class Assign_EmpRole_DashboardReportsBusinessObject
{ 

       private Assign_EmpRole_DashboardReports mapped = new Assign_EmpRole_DashboardReports();
       private PersistentObject persistent = null; 


      #region Constructors
      public Assign_EmpRole_DashboardReportsBusinessObject(DatabaseServer database, string connectionString) 
      {
           persistent = new PersistentObject(database, connectionString, mapped);
      }

      
      public Assign_EmpRole_DashboardReportsBusinessObject(Session session)
      {
           persistent = new PersistentObject(session, mapped);
      }

      public Assign_EmpRole_DashboardReportsBusinessObject()
      {
           persistent = new PersistentObject(mapped);
      }
		#endregion


       #region generated implementation
   public DataTable GetDataTable()
	 {
        return persistent.GetDataTable();
	 }


   public DataTable GetDataTable(QueryCriteria qc)
	 {
        return persistent.GetDataTable(qc);
	 }


   public DataTable GetDataTable(params DatabaseField[] fields)
	 {
        return persistent.GetDataTable(fields);
	 }


   public Assign_EmpRole_DashboardReports[] GetAssign_EmpRole_DashboardReports()
	 {
        	 return (Assign_EmpRole_DashboardReports[])persistent.GetTableMetadata();
	 }


   public Assign_EmpRole_DashboardReports GetAssign_EmpRole_DashboardReports(object primaryKeyValue)
   {
      	return(Assign_EmpRole_DashboardReports)persistent.GetTableMetadata(primaryKeyValue);
   }


   public  Array GetAssign_EmpRole_DashboardReports(string relatedTableName, Type classType, object foreignKeyValue)
   {
     		return persistent.GetTableMetadata(relatedTableName, classType, foreignKeyValue);
	 }


   public ArrayList GetFieldList(QueryCriteria criteria)
	 {
         return persistent.GetFieldList(criteria);
	 }


   public ArrayList GetFieldList(DatabaseField field)
	 {
        	 return persistent.GetFieldList(field);
	 }


   public object GetValue (QueryCriteria criteria)
	 {
         return persistent.GetValue(criteria);
	 }


   public bool IsUnique (DatabaseField field, object value)
	 {
        	 return persistent.IsUnique(field, value);
	 }


	public object GetMax(DatabaseField field)
	{
		return persistent.GetMax(field);
	}


	public object GetMin(DatabaseField field)
	{
		return persistent.GetMin(field);
	}


	public object GetCount()
	{
		return persistent.GetCount();
	}


	public int Create(Assign_EmpRole_DashboardReports mappedObject)
	{
		return persistent.Create(mappedObject);
	}


	public int Update(Assign_EmpRole_DashboardReports mappedObject)
	{
		return persistent.Update(mappedObject);
	}


	public int Update(QueryCriteria criteria)
	{
		return persistent.Update(criteria);
	}


	public int Delete(Assign_EmpRole_DashboardReports mappedObject)
	{
		return persistent.Delete(mappedObject);
	}


	public int Delete(QueryCriteria criteria)
	{
		return persistent.Delete(criteria);
	}


       #endregion
 
   }
}
