using System;
using System.Data;
using IS91.Services.DataBlock;
using System.Collections;
using HRManager.DTO;
namespace HRManager.BusinessObjects
{
public partial class Master_AssetCategoryBusinessObject
{ 

       private Master_AssetCategory mapped = new Master_AssetCategory();
       private PersistentObject persistent = null; 


      #region Constructors
      public Master_AssetCategoryBusinessObject(DatabaseServer database, string connectionString) 
      {
           persistent = new PersistentObject(database, connectionString, mapped);
      }

      
      public Master_AssetCategoryBusinessObject(Session session)
      {
           persistent = new PersistentObject(session, mapped);
      }

      public Master_AssetCategoryBusinessObject()
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


   public Master_AssetCategory[] GetMaster_AssetCategory()
	 {
        	 return (Master_AssetCategory[])persistent.GetTableMetadata();
	 }


   public Master_AssetCategory GetMaster_AssetCategory(object primaryKeyValue)
   {
      	return(Master_AssetCategory)persistent.GetTableMetadata(primaryKeyValue);
   }


   public Master_AssetCategory[] GetMaster_AssetCategory(QueryCriteria qc)
   {
      	return(Master_AssetCategory[])persistent.GetTableMetadata(qc);
   }


   public  Array GetMaster_AssetCategory(string relatedTableName, Type classType, object foreignKeyValue)
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


	public int Create(Master_AssetCategory mappedObject)
	{
		return persistent.Create(mappedObject);
	}


	public int Update(Master_AssetCategory mappedObject)
	{
		return persistent.Update(mappedObject);
	}


	public int Update(QueryCriteria criteria)
	{
		return persistent.Update(criteria);
	}


	public int Delete(Master_AssetCategory mappedObject)
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
