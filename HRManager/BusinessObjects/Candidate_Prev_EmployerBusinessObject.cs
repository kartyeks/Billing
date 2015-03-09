using System;
using System.Data;
using IS91.Services.DataBlock;
using System.Collections;
using HRManager.DTO;
namespace HRManager.BusinessObjects
{
public partial class Candidate_Prev_EmployerBusinessObject
{ 

       private Candidate_Prev_Employer mapped = new Candidate_Prev_Employer();
       private PersistentObject persistent = null; 


      #region Constructors
      public Candidate_Prev_EmployerBusinessObject(DatabaseServer database, string connectionString) 
      {
           persistent = new PersistentObject(database, connectionString, mapped);
      }

      
      public Candidate_Prev_EmployerBusinessObject(Session session)
      {
           persistent = new PersistentObject(session, mapped);
      }

      public Candidate_Prev_EmployerBusinessObject()
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


   public Candidate_Prev_Employer[] GetCandidate_Prev_Employer()
	 {
        	 return (Candidate_Prev_Employer[])persistent.GetTableMetadata();
	 }


   public Candidate_Prev_Employer GetCandidate_Prev_Employer(object primaryKeyValue)
   {
      	return(Candidate_Prev_Employer)persistent.GetTableMetadata(primaryKeyValue);
   }


   public Candidate_Prev_Employer[] GetCandidate_Prev_Employer(QueryCriteria qc)
   {
      	return(Candidate_Prev_Employer[])persistent.GetTableMetadata(qc);
   }


   public  Array GetCandidate_Prev_Employer(string relatedTableName, Type classType, object foreignKeyValue)
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


	public int Create(Candidate_Prev_Employer mappedObject)
	{
		return persistent.Create(mappedObject);
	}


	public int Update(Candidate_Prev_Employer mappedObject)
	{
		return persistent.Update(mappedObject);
	}


	public int Update(QueryCriteria criteria)
	{
		return persistent.Update(criteria);
	}


	public int Delete(Candidate_Prev_Employer mappedObject)
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
