using System;
using System.Data;
using IS91.Services.DataBlock;
using System.Collections;
using HRManager.DTO;
namespace HRManager.BusinessObjects
{
public partial class Assign_Emp_AllowanceBusinessObject
{ 

       private Assign_Emp_Allowance mapped = new Assign_Emp_Allowance();
       private PersistentObject persistent = null; 


      #region Constructors
      public Assign_Emp_AllowanceBusinessObject(DatabaseServer database, string connectionString) 
      {
           persistent = new PersistentObject(database, connectionString, mapped);
      }

      
      public Assign_Emp_AllowanceBusinessObject(Session session)
      {
           persistent = new PersistentObject(session, mapped);
      }

      public Assign_Emp_AllowanceBusinessObject()
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


   public Assign_Emp_Allowance[] GetAssign_Emp_Allowance()
	 {
        	 return (Assign_Emp_Allowance[])persistent.GetTableMetadata();
	 }


   public Assign_Emp_Allowance GetAssign_Emp_Allowance(object primaryKeyValue)
   {
      	return(Assign_Emp_Allowance)persistent.GetTableMetadata(primaryKeyValue);
   }


   public Assign_Emp_Allowance[] GetAssign_Emp_Allowance(QueryCriteria qc)
   {
      	return(Assign_Emp_Allowance[])persistent.GetTableMetadata(qc);
   }


   public  Array GetAssign_Emp_Allowance(string relatedTableName, Type classType, object foreignKeyValue)
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


	public int Create(Assign_Emp_Allowance mappedObject)
	{
		return persistent.Create(mappedObject);
	}


	public int Update(Assign_Emp_Allowance mappedObject)
	{
		return persistent.Update(mappedObject);
	}


	public int Update(QueryCriteria criteria)
	{
		return persistent.Update(criteria);
	}


	public int Delete(Assign_Emp_Allowance mappedObject)
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
