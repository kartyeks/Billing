using System;
using System.Data;
using IS91.Services.DataBlock;
using System.Collections;
using HRManager.DTO;
namespace HRManager.BusinessObjects
{
public partial class Payroll_AnnualConfigurationBusinessObject
{ 

       private Payroll_AnnualConfiguration mapped = new Payroll_AnnualConfiguration();
       private PersistentObject persistent = null; 


      #region Constructors
      public Payroll_AnnualConfigurationBusinessObject(DatabaseServer database, string connectionString) 
      {
           persistent = new PersistentObject(database, connectionString, mapped);
      }

      
      public Payroll_AnnualConfigurationBusinessObject(Session session)
      {
           persistent = new PersistentObject(session, mapped);
      }

      public Payroll_AnnualConfigurationBusinessObject()
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


   public Payroll_AnnualConfiguration[] GetPayroll_AnnualConfiguration()
	 {
        	 return (Payroll_AnnualConfiguration[])persistent.GetTableMetadata();
	 }


   public Payroll_AnnualConfiguration GetPayroll_AnnualConfiguration(object primaryKeyValue)
   {
      	return(Payroll_AnnualConfiguration)persistent.GetTableMetadata(primaryKeyValue);
   }


   public Payroll_AnnualConfiguration[] GetPayroll_AnnualConfiguration(QueryCriteria qc)
   {
      	return(Payroll_AnnualConfiguration[])persistent.GetTableMetadata(qc);
   }


   public  Array GetPayroll_AnnualConfiguration(string relatedTableName, Type classType, object foreignKeyValue)
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


	public int Create(Payroll_AnnualConfiguration mappedObject)
	{
		return persistent.Create(mappedObject);
	}


	public int Update(Payroll_AnnualConfiguration mappedObject)
	{
		return persistent.Update(mappedObject);
	}


	public int Update(QueryCriteria criteria)
	{
		return persistent.Update(criteria);
	}


	public int Delete(Payroll_AnnualConfiguration mappedObject)
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
