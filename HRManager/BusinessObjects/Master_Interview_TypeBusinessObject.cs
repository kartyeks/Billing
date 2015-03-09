using System;
using System.Data;
using IS91.Services.DataBlock;
using System.Collections;
using HRManager.DTO;
namespace HRManager.BusinessObjects
{
public partial class Master_Interview_TypeBusinessObject
{ 

       private Master_Interview_Type mapped = new Master_Interview_Type();
       private PersistentObject persistent = null; 


      #region Constructors
      public Master_Interview_TypeBusinessObject(DatabaseServer database, string connectionString) 
      {
           persistent = new PersistentObject(database, connectionString, mapped);
      }

      
      public Master_Interview_TypeBusinessObject(Session session)
      {
           persistent = new PersistentObject(session, mapped);
      }

      public Master_Interview_TypeBusinessObject()
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


   public Master_Interview_Type[] GetMaster_Interview_Type()
	 {
        	 return (Master_Interview_Type[])persistent.GetTableMetadata();
	 }


   public Master_Interview_Type GetMaster_Interview_Type(object primaryKeyValue)
   {
      	return(Master_Interview_Type)persistent.GetTableMetadata(primaryKeyValue);
   }


   public Master_Interview_Type[] GetMaster_Interview_Type(QueryCriteria qc)
   {
      	return(Master_Interview_Type[])persistent.GetTableMetadata(qc);
   }


   public  Array GetMaster_Interview_Type(string relatedTableName, Type classType, object foreignKeyValue)
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


	public int Create(Master_Interview_Type mappedObject)
	{
		return persistent.Create(mappedObject);
	}


	public int Update(Master_Interview_Type mappedObject)
	{
		return persistent.Update(mappedObject);
	}


	public int Update(QueryCriteria criteria)
	{
		return persistent.Update(criteria);
	}


	public int Delete(Master_Interview_Type mappedObject)
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
