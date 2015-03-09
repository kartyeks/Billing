using System;
using System.Data;
using IS91.Services.DataBlock;
using System.Collections;
using HRManager.DTO;
namespace HRManager.BusinessObjects
{
public partial class Employee_Payroll_DeductionsBusinessObject
{ 

       private Employee_Payroll_Deductions mapped = new Employee_Payroll_Deductions();
       private PersistentObject persistent = null; 


      #region Constructors
      public Employee_Payroll_DeductionsBusinessObject(DatabaseServer database, string connectionString) 
      {
           persistent = new PersistentObject(database, connectionString, mapped);
      }

      
      public Employee_Payroll_DeductionsBusinessObject(Session session)
      {
           persistent = new PersistentObject(session, mapped);
      }

      public Employee_Payroll_DeductionsBusinessObject()
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


   public Employee_Payroll_Deductions[] GetEmployee_Payroll_Deductions()
	 {
        	 return (Employee_Payroll_Deductions[])persistent.GetTableMetadata();
	 }


   public Employee_Payroll_Deductions GetEmployee_Payroll_Deductions(object primaryKeyValue)
   {
      	return(Employee_Payroll_Deductions)persistent.GetTableMetadata(primaryKeyValue);
   }


   public Employee_Payroll_Deductions[] GetEmployee_Payroll_Deductions(QueryCriteria qc)
   {
      	return(Employee_Payroll_Deductions[])persistent.GetTableMetadata(qc);
   }


   public  Array GetEmployee_Payroll_Deductions(string relatedTableName, Type classType, object foreignKeyValue)
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


	public int Create(Employee_Payroll_Deductions mappedObject)
	{
		return persistent.Create(mappedObject);
	}


	public int Update(Employee_Payroll_Deductions mappedObject)
	{
		return persistent.Update(mappedObject);
	}


	public int Update(QueryCriteria criteria)
	{
		return persistent.Update(criteria);
	}


	public int Delete(Employee_Payroll_Deductions mappedObject)
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
