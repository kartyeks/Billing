using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using CommonManager.DTO;
namespace CommonManager.BusinessObjects
{
public partial class Common_StateBusinessObject
{ 

       private Common_State mapped = new Common_State();
       private PersistentObject persistent = null; 


      #region Constructors
      public Common_StateBusinessObject(DatabaseServer database, string connectionString) 
      {
           persistent = new PersistentObject(database, connectionString, mapped);
      }

      
      public Common_StateBusinessObject(Session session)
      {
           persistent = new PersistentObject(session, mapped);
      }

      public Common_StateBusinessObject()
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


   public Common_State[] GetCommon_State()
	 {
        	 return (Common_State[])persistent.GetTableMetadata();
	 }


   public Common_State GetCommon_State(object primaryKeyValue)
   {
      	return(Common_State)persistent.GetTableMetadata(primaryKeyValue);
   }


   public  Array GetCommon_State(string relatedTableName, Type classType, object foreignKeyValue)
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


	public int Create(Common_State mappedObject)
	{
		return persistent.Create(mappedObject);
	}


	public int Update(Common_State mappedObject)
	{
		return persistent.Update(mappedObject);
	}


	public int Update(QueryCriteria criteria)
	{
		return persistent.Update(criteria);
	}


	public int Delete(Common_State mappedObject)
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
