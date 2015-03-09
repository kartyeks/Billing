using System;
using System.Data;
using IS91.Services.DataBlock;
using System.Collections;
using HRManager.DTO;
namespace HRManager.BusinessObjects
{
public partial class Salary_AdvanceRepaymentsBusinessObject
{ 

       private Salary_AdvanceRepayments mapped = new Salary_AdvanceRepayments();
       private PersistentObject persistent = null; 


      #region Constructors
      public Salary_AdvanceRepaymentsBusinessObject(DatabaseServer database, string connectionString) 
      {
           persistent = new PersistentObject(database, connectionString, mapped);
      }

      
      public Salary_AdvanceRepaymentsBusinessObject(Session session)
      {
           persistent = new PersistentObject(session, mapped);
      }

      public Salary_AdvanceRepaymentsBusinessObject()
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


   public Salary_AdvanceRepayments[] GetSalary_AdvanceRepayments()
	 {
        	 return (Salary_AdvanceRepayments[])persistent.GetTableMetadata();
	 }


   public Salary_AdvanceRepayments GetSalary_AdvanceRepayments(object primaryKeyValue)
   {
      	return(Salary_AdvanceRepayments)persistent.GetTableMetadata(primaryKeyValue);
   }


   public Salary_AdvanceRepayments[] GetSalary_AdvanceRepayments(QueryCriteria qc)
   {
      	return(Salary_AdvanceRepayments[])persistent.GetTableMetadata(qc);
   }


   public  Array GetSalary_AdvanceRepayments(string relatedTableName, Type classType, object foreignKeyValue)
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


	public int Create(Salary_AdvanceRepayments mappedObject)
	{
		return persistent.Create(mappedObject);
	}


	public int Update(Salary_AdvanceRepayments mappedObject)
	{
		return persistent.Update(mappedObject);
	}


	public int Update(QueryCriteria criteria)
	{
		return persistent.Update(criteria);
	}


	public int Delete(Salary_AdvanceRepayments mappedObject)
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
