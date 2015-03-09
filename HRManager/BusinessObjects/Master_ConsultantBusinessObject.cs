using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;
namespace HRManager.BusinessObjects
{
public partial class Master_ConsultantBusinessObject
{ 

       private Master_Consultant mapped = new Master_Consultant();
       private PersistentObject persistent = null; 


      #region Constructors
      public Master_ConsultantBusinessObject(DatabaseServer database, string connectionString) 
      {
           persistent = new PersistentObject(database, connectionString, mapped);
      }

      
      public Master_ConsultantBusinessObject(Session session)
      {
           persistent = new PersistentObject(session, mapped);
      }

      public Master_ConsultantBusinessObject()
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


   public Master_Consultant[] GetMaster_Consultant()
	 {
        	 return (Master_Consultant[])persistent.GetTableMetadata();
	 }


   public Master_Consultant GetMaster_Consultant(object primaryKeyValue)
   {
      	return(Master_Consultant)persistent.GetTableMetadata(primaryKeyValue);
   }


   public  Array GetMaster_Consultant(string relatedTableName, Type classType, object foreignKeyValue)
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


	public int Create(Master_Consultant mappedObject)
	{
		return persistent.Create(mappedObject);
	}


	public int Update(Master_Consultant mappedObject)
	{
		return persistent.Update(mappedObject);
	}


	public int Update(QueryCriteria criteria)
	{
		return persistent.Update(criteria);
	}


	public int Delete(Master_Consultant mappedObject)
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
