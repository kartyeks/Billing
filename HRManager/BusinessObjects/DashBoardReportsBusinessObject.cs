using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;
namespace HRManager.BusinessObjects
{
public class DashBoardReportsBusinessObject
{ 

       private DashBoardReports mapped = new DashBoardReports();
       private PersistentObject persistent = null; 


      #region Constructors
      public DashBoardReportsBusinessObject(DatabaseServer database, string connectionString) 
      {
           persistent = new PersistentObject(database, connectionString, mapped);
      }

      
      public DashBoardReportsBusinessObject(Session session)
      {
           persistent = new PersistentObject(session, mapped);
      }

      public DashBoardReportsBusinessObject()
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


   public DashBoardReports[] GetDashBoardReports()
	 {
        	 return (DashBoardReports[])persistent.GetTableMetadata();
	 }


   public DashBoardReports GetDashBoardReports(object primaryKeyValue)
   {
      	return(DashBoardReports)persistent.GetTableMetadata(primaryKeyValue);
   }


   public  Array GetDashBoardReports(string relatedTableName, Type classType, object foreignKeyValue)
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


	public int Create(DashBoardReports mappedObject)
	{
		return persistent.Create(mappedObject);
	}


	public int Update(DashBoardReports mappedObject)
	{
		return persistent.Update(mappedObject);
	}


	public int Update(QueryCriteria criteria)
	{
		return persistent.Update(criteria);
	}


	public int Delete(DashBoardReports mappedObject)
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
