using System;
using System.Data;
using IS91.Services.DataBlock;
using System.Collections;
using HRManager.DTO;
namespace HRManager.BusinessObjects
{
public partial class Employee_LOPDetailsBusinessObject
{ 

       private Employee_LOPDetails mapped = new Employee_LOPDetails();
       private PersistentObject persistent = null; 


      #region Constructors
      public Employee_LOPDetailsBusinessObject(DatabaseServer database, string connectionString) 
      {
           persistent = new PersistentObject(database, connectionString, mapped);
      }

      
      public Employee_LOPDetailsBusinessObject(Session session)
      {
           persistent = new PersistentObject(session, mapped);
      }

      public Employee_LOPDetailsBusinessObject()
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


   public Employee_LOPDetails[] GetEmployee_LOPDetails()
	 {
        	 return (Employee_LOPDetails[])persistent.GetTableMetadata();
	 }


   public Employee_LOPDetails GetEmployee_LOPDetails(object primaryKeyValue)
   {
      	return(Employee_LOPDetails)persistent.GetTableMetadata(primaryKeyValue);
   }


   public Employee_LOPDetails[] GetEmployee_LOPDetails(QueryCriteria qc)
   {
      	return(Employee_LOPDetails[])persistent.GetTableMetadata(qc);
   }


   public  Array GetEmployee_LOPDetails(string relatedTableName, Type classType, object foreignKeyValue)
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


	public int Create(Employee_LOPDetails mappedObject)
	{
		return persistent.Create(mappedObject);
	}


	public int Update(Employee_LOPDetails mappedObject)
	{
		return persistent.Update(mappedObject);
	}


	public int Update(QueryCriteria criteria)
	{
		return persistent.Update(criteria);
	}


	public int Delete(Employee_LOPDetails mappedObject)
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
