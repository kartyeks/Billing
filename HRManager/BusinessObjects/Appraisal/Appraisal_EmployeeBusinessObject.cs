using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;
namespace HRManager.BusinessObjects
{
public partial class Appraisal_EmployeeBusinessObject
{ 

       private Appraisal_Employee mapped = new Appraisal_Employee();
       private PersistentObject persistent = null; 


      #region Constructors
      public Appraisal_EmployeeBusinessObject(DatabaseServer database, string connectionString) 
      {
           persistent = new PersistentObject(database, connectionString, mapped);
      }

      
      public Appraisal_EmployeeBusinessObject(Session session)
      {
           persistent = new PersistentObject(session, mapped);
      }

      public Appraisal_EmployeeBusinessObject()
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


   public Appraisal_Employee[] GetAppraisal_Employee()
	 {
        	 return (Appraisal_Employee[])persistent.GetTableMetadata();
	 }


   public Appraisal_Employee GetAppraisal_Employee(object primaryKeyValue)
   {
      	return(Appraisal_Employee)persistent.GetTableMetadata(primaryKeyValue);
   }


   public Appraisal_Employee[] GetAppraisal_Employee(QueryCriteria qc)
   {
      	return(Appraisal_Employee[])persistent.GetTableMetadata(qc);
   }


   public  Array GetAppraisal_Employee(string relatedTableName, Type classType, object foreignKeyValue)
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


	public int Create(Appraisal_Employee mappedObject)
	{
		return persistent.Create(mappedObject);
	}


	public int Update(Appraisal_Employee mappedObject)
	{
		return persistent.Update(mappedObject);
	}


	public int Update(QueryCriteria criteria)
	{
		return persistent.Update(criteria);
	}


	public int Delete(Appraisal_Employee mappedObject)
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
