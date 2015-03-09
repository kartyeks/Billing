using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;
namespace HRManager.BusinessObjects
{
public partial class Hr_DesignationBusinessObject
{ 

       private Hr_Designation mapped = new Hr_Designation();
       private PersistentObject persistent = null; 


      #region Constructors
      public Hr_DesignationBusinessObject(DatabaseServer database, string connectionString) 
      {
           persistent = new PersistentObject(database, connectionString, mapped);
      }

      
      public Hr_DesignationBusinessObject(Session session)
      {
           persistent = new PersistentObject(session, mapped);
      }

      public Hr_DesignationBusinessObject()
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


   public Hr_Designation[] GetHr_Designation()
	 {
        	 return (Hr_Designation[])persistent.GetTableMetadata();
	 }


   public Hr_Designation GetHr_Designation(object primaryKeyValue)
   {
      	return(Hr_Designation)persistent.GetTableMetadata(primaryKeyValue);
   }


   public Hr_Designation[] GetHr_Designation(QueryCriteria qc)
   {
      	return(Hr_Designation[])persistent.GetTableMetadata(qc);
   }


   public  Array GetHr_Designation(string relatedTableName, Type classType, object foreignKeyValue)
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


	public int Create(Hr_Designation mappedObject)
	{
		return persistent.Create(mappedObject);
	}


	public int Update(Hr_Designation mappedObject)
	{
		return persistent.Update(mappedObject);
	}


	public int Update(QueryCriteria criteria)
	{
		return persistent.Update(criteria);
	}


	public int Delete(Hr_Designation mappedObject)
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
