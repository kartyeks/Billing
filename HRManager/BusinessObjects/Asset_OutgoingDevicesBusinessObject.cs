using System;
using System.Data;
using IS91.Services.DataBlock;
using System.Collections;
using HRManager.DTO;
namespace HRManager.BusinessObjects
{
public partial class Asset_OutgoingDevicesBusinessObject
{ 

       private Asset_OutgoingDevices mapped = new Asset_OutgoingDevices();
       private PersistentObject persistent = null; 


      #region Constructors
      public Asset_OutgoingDevicesBusinessObject(DatabaseServer database, string connectionString) 
      {
           persistent = new PersistentObject(database, connectionString, mapped);
      }

      
      public Asset_OutgoingDevicesBusinessObject(Session session)
      {
           persistent = new PersistentObject(session, mapped);
      }

      public Asset_OutgoingDevicesBusinessObject()
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


   public Asset_OutgoingDevices[] GetAsset_OutgoingDevices()
	 {
        	 return (Asset_OutgoingDevices[])persistent.GetTableMetadata();
	 }


   public Asset_OutgoingDevices GetAsset_OutgoingDevices(object primaryKeyValue)
   {
      	return(Asset_OutgoingDevices)persistent.GetTableMetadata(primaryKeyValue);
   }


   public Asset_OutgoingDevices[] GetAsset_OutgoingDevices(QueryCriteria qc)
   {
      	return(Asset_OutgoingDevices[])persistent.GetTableMetadata(qc);
   }


   public  Array GetAsset_OutgoingDevices(string relatedTableName, Type classType, object foreignKeyValue)
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


	public int Create(Asset_OutgoingDevices mappedObject)
	{
		return persistent.Create(mappedObject);
	}


	public int Update(Asset_OutgoingDevices mappedObject)
	{
		return persistent.Update(mappedObject);
	}


	public int Update(QueryCriteria criteria)
	{
		return persistent.Update(criteria);
	}


	public int Delete(Asset_OutgoingDevices mappedObject)
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
