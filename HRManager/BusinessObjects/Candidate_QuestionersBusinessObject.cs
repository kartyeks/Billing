using System;
using System.Data;
using IS91.Services.DataBlock;
using System.Collections;
using HRManager.DTO;
namespace HRManager.BusinessObjects
{
public partial class Candidate_QuestionersBusinessObject
{ 

       private Candidate_Questioners mapped = new Candidate_Questioners();
       private PersistentObject persistent = null; 


      #region Constructors
      public Candidate_QuestionersBusinessObject(DatabaseServer database, string connectionString) 
      {
           persistent = new PersistentObject(database, connectionString, mapped);
      }

      
      public Candidate_QuestionersBusinessObject(Session session)
      {
           persistent = new PersistentObject(session, mapped);
      }

      public Candidate_QuestionersBusinessObject()
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


   public Candidate_Questioners[] GetCandidate_Questioners()
	 {
        	 return (Candidate_Questioners[])persistent.GetTableMetadata();
	 }


   public Candidate_Questioners GetCandidate_Questioners(object primaryKeyValue)
   {
      	return(Candidate_Questioners)persistent.GetTableMetadata(primaryKeyValue);
   }


   public Candidate_Questioners[] GetCandidate_Questioners(QueryCriteria qc)
   {
      	return(Candidate_Questioners[])persistent.GetTableMetadata(qc);
   }


   public  Array GetCandidate_Questioners(string relatedTableName, Type classType, object foreignKeyValue)
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


	public int Create(Candidate_Questioners mappedObject)
	{
		return persistent.Create(mappedObject);
	}


	public int Update(Candidate_Questioners mappedObject)
	{
		return persistent.Update(mappedObject);
	}


	public int Update(QueryCriteria criteria)
	{
		return persistent.Update(criteria);
	}


	public int Delete(Candidate_Questioners mappedObject)
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
