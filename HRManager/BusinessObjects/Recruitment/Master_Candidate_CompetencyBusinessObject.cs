using System;
using System.Data;
using IS91.Services.DataBlock;
using System.Collections;
using HRManager.DTO;

namespace HRManager.BusinessObjects
{
public partial class Master_Candidate_CompetencyBusinessObject
{ 

       private Master_Candidate_Competency mapped = new Master_Candidate_Competency();
       private PersistentObject persistent = null; 


      #region Constructors
      public Master_Candidate_CompetencyBusinessObject(DatabaseServer database, string connectionString) 
      {
           persistent = new PersistentObject(database, connectionString, mapped);
      }

      
      public Master_Candidate_CompetencyBusinessObject(Session session)
      {
           persistent = new PersistentObject(session, mapped);
      }

      public Master_Candidate_CompetencyBusinessObject()
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


   public Master_Candidate_Competency[] GetMaster_Candidate_Competency()
	 {
        	 return (Master_Candidate_Competency[])persistent.GetTableMetadata();
	 }


   public Master_Candidate_Competency GetMaster_Candidate_Competency(object primaryKeyValue)
   {
      	return(Master_Candidate_Competency)persistent.GetTableMetadata(primaryKeyValue);
   }


   public Master_Candidate_Competency[] GetMaster_Candidate_Competency(QueryCriteria qc)
   {
      	return(Master_Candidate_Competency[])persistent.GetTableMetadata(qc);
   }


   public  Array GetMaster_Candidate_Competency(string relatedTableName, Type classType, object foreignKeyValue)
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


	public int Create(Master_Candidate_Competency mappedObject)
	{
		return persistent.Create(mappedObject);
	}


	public int Update(Master_Candidate_Competency mappedObject)
	{
		return persistent.Update(mappedObject);
	}


	public int Update(QueryCriteria criteria)
	{
		return persistent.Update(criteria);
	}


	public int Delete(Master_Candidate_Competency mappedObject)
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
