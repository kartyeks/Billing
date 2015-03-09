using System;
using System.Data;
using IS91.Services.DataBlock;
using System.Collections;
using HRManager.DTO;
namespace HRManager.BusinessObjects
{
public partial class Master_HolidaysBusinessObject
{ 

       private Master_Holidays mapped = new Master_Holidays();
       private PersistentObject persistent = null; 


      #region Constructors
      public Master_HolidaysBusinessObject(DatabaseServer database, string connectionString) 
      {
           persistent = new PersistentObject(database, connectionString, mapped);
      }

      
      public Master_HolidaysBusinessObject(Session session)
      {
           persistent = new PersistentObject(session, mapped);
      }

      public Master_HolidaysBusinessObject()
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


   public Master_Holidays[] GetMaster_Holidays()
	 {
        	 return (Master_Holidays[])persistent.GetTableMetadata();
	 }


   public Master_Holidays GetMaster_Holidays(object primaryKeyValue)
   {
      	return(Master_Holidays)persistent.GetTableMetadata(primaryKeyValue);
   }


   public Master_Holidays[] GetMaster_Holidays(QueryCriteria qc)
   {
      	return(Master_Holidays[])persistent.GetTableMetadata(qc);
   }


   public  Array GetMaster_Holidays(string relatedTableName, Type classType, object foreignKeyValue)
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


	public int Create(Master_Holidays mappedObject)
	{
		return persistent.Create(mappedObject);
	}


	public int Update(Master_Holidays mappedObject)
	{
		return persistent.Update(mappedObject);
	}


	public int Update(QueryCriteria criteria)
	{
		return persistent.Update(criteria);
	}


	public int Delete(Master_Holidays mappedObject)
	{
		return persistent.Delete(mappedObject);
	}


	public int Delete(QueryCriteria criteria)
	{
		return persistent.Delete(criteria);
	}


	public int Delete(object id)
	{
		return persistent.Delete(id);
	}


       #endregion
 
   }
}
