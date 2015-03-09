using System;
using System.Data;
using IS91.Services.DataBlock;
using System.Collections;
using HRManager.DTO;

namespace HRManager.BusinessObjects
{
public partial class EmployeeAttendanceBusinessObject
{ 

       private EmployeeAttendance  mapped = new EmployeeAttendance();
       private PersistentObject persistent = null; 


      #region Constructors
      public EmployeeAttendanceBusinessObject(DatabaseServer database, string connectionString) 
      {
           persistent = new PersistentObject(database, connectionString, mapped);
      }

      
      public EmployeeAttendanceBusinessObject(Session session)
      {
           persistent = new PersistentObject(session, mapped);
      }

      public EmployeeAttendanceBusinessObject()
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


   public EmployeeAttendance[] GetEmployeeAttendance()
	 {
        	 return (EmployeeAttendance[])persistent.GetTableMetadata();
	 }


   public EmployeeAttendance GetEmployeeAttendance(object primaryKeyValue)
   {
      	return(EmployeeAttendance)persistent.GetTableMetadata(primaryKeyValue);
   }


   public EmployeeAttendance[] GetEmployeeAttendance(QueryCriteria qc)
   {
      	return(EmployeeAttendance[])persistent.GetTableMetadata(qc);
   }


   public  Array GetEmployeeAttendance(string relatedTableName, Type classType, object foreignKeyValue)
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


	public int Create(EmployeeAttendance mappedObject)
	{
		return persistent.Create(mappedObject);
	}


	public int Update(EmployeeAttendance mappedObject)
	{
		return persistent.Update(mappedObject);
	}


	public int Update(QueryCriteria criteria)
	{
		return persistent.Update(criteria);
	}


	public int Delete(EmployeeAttendance mappedObject)
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
