using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;
namespace HRManager.BusinessObjects
{
public partial class Leave_Status_HistoryBusinessObject
{ 

       private Leave_Status_History mapped = new Leave_Status_History();
       private PersistentObject persistent = null; 


      #region Constructors
      public Leave_Status_HistoryBusinessObject(DatabaseServer database, string connectionString) 
      {
           persistent = new PersistentObject(database, connectionString, mapped);
      }

      
      public Leave_Status_HistoryBusinessObject(Session session)
      {
           persistent = new PersistentObject(session, mapped);
      }

      public Leave_Status_HistoryBusinessObject()
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


   public Leave_Status_History[] GetLeave_Status_History()
	 {
        	 return (Leave_Status_History[])persistent.GetTableMetadata();
	 }


   public Leave_Status_History GetLeave_Status_History(object primaryKeyValue)
   {
      	return(Leave_Status_History)persistent.GetTableMetadata(primaryKeyValue);
   }


   public  Array GetLeave_Status_History(string relatedTableName, Type classType, object foreignKeyValue)
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


	public int Create(Leave_Status_History mappedObject)
	{
		return persistent.Create(mappedObject);
	}


	public int Update(Leave_Status_History mappedObject)
	{
		return persistent.Update(mappedObject);
	}


	public int Update(QueryCriteria criteria)
	{
		return persistent.Update(criteria);
	}


	public int Delete(Leave_Status_History mappedObject)
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
