using System;
using System.Data;
using IS91.Services.DataBlock;
using System.Collections;
using HRManager.DTO;
namespace HRManager.BusinessObjects
{
public partial class Candidate_EducationBusinessObject
{ 

       private Candidate_Education mapped = new Candidate_Education();
       private PersistentObject persistent = null; 


      #region Constructors
      public Candidate_EducationBusinessObject(DatabaseServer database, string connectionString) 
      {
           persistent = new PersistentObject(database, connectionString, mapped);
      }

      
      public Candidate_EducationBusinessObject(Session session)
      {
           persistent = new PersistentObject(session, mapped);
      }

      public Candidate_EducationBusinessObject()
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


   public Candidate_Education[] GetCandidate_Education()
	 {
        	 return (Candidate_Education[])persistent.GetTableMetadata();
	 }


   public Candidate_Education GetCandidate_Education(object primaryKeyValue)
   {
      	return(Candidate_Education)persistent.GetTableMetadata(primaryKeyValue);
   }


   public Candidate_Education[] GetCandidate_Education(QueryCriteria qc)
   {
      	return(Candidate_Education[])persistent.GetTableMetadata(qc);
   }


   public  Array GetCandidate_Education(string relatedTableName, Type classType, object foreignKeyValue)
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


	public int Create(Candidate_Education mappedObject)
	{
		return persistent.Create(mappedObject);
	}


	public int Update(Candidate_Education mappedObject)
	{
		return persistent.Update(mappedObject);
	}


	public int Update(QueryCriteria criteria)
	{
		return persistent.Update(criteria);
	}


	public int Delete(Candidate_Education mappedObject)
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
