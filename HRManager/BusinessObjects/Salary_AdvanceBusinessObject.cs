using System;
using System.Data;
using IS91.Services.DataBlock;
using System.Collections;
using HRManager.DTO;
namespace HRManager.BusinessObjects
{
public partial class Salary_AdvanceBusinessObject
{ 

       private Salary_Advance mapped = new Salary_Advance();
       private PersistentObject persistent = null; 


      #region Constructors
      public Salary_AdvanceBusinessObject(DatabaseServer database, string connectionString) 
      {
           persistent = new PersistentObject(database, connectionString, mapped);
      }

      
      public Salary_AdvanceBusinessObject(Session session)
      {
           persistent = new PersistentObject(session, mapped);
      }

      public Salary_AdvanceBusinessObject()
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


   public Salary_Advance[] GetSalary_Advance()
	 {
        	 return (Salary_Advance[])persistent.GetTableMetadata();
	 }


   public Salary_Advance GetSalary_Advance(object primaryKeyValue)
   {
      	return(Salary_Advance)persistent.GetTableMetadata(primaryKeyValue);
   }


   public Salary_Advance[] GetSalary_Advance(QueryCriteria qc)
   {
      	return(Salary_Advance[])persistent.GetTableMetadata(qc);
   }


   public  Array GetSalary_Advance(string relatedTableName, Type classType, object foreignKeyValue)
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


	public int Create(Salary_Advance mappedObject)
	{
		return persistent.Create(mappedObject);
	}


	public int Update(Salary_Advance mappedObject)
	{
		return persistent.Update(mappedObject);
	}


	public int Update(QueryCriteria criteria)
	{
		return persistent.Update(criteria);
	}


	public int Delete(Salary_Advance mappedObject)
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
