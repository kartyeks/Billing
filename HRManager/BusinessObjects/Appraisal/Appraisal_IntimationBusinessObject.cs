using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;
namespace HRManager.BusinessObjects
{
public partial class Appraisal_IntimationBusinessObject
{ 

       private Appraisal_Intimation mapped = new Appraisal_Intimation();
       private PersistentObject persistent = null; 


      #region Constructors
      public Appraisal_IntimationBusinessObject(DatabaseServer database, string connectionString) 
      {
           persistent = new PersistentObject(database, connectionString, mapped);
      }

      
      public Appraisal_IntimationBusinessObject(Session session)
      {
           persistent = new PersistentObject(session, mapped);
      }

      public Appraisal_IntimationBusinessObject()
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


   public Appraisal_Intimation[] GetAppraisal_Intimation()
	 {
        	 return (Appraisal_Intimation[])persistent.GetTableMetadata();
	 }


   public Appraisal_Intimation GetAppraisal_Intimation(object primaryKeyValue)
   {
      	return(Appraisal_Intimation)persistent.GetTableMetadata(primaryKeyValue);
   }


   public Appraisal_Intimation[] GetAppraisal_Intimation(QueryCriteria qc)
   {
      	return(Appraisal_Intimation[])persistent.GetTableMetadata(qc);
   }


   public  Array GetAppraisal_Intimation(string relatedTableName, Type classType, object foreignKeyValue)
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


	public int Create(Appraisal_Intimation mappedObject)
	{
		return persistent.Create(mappedObject);
	}


	public int Update(Appraisal_Intimation mappedObject)
	{
		return persistent.Update(mappedObject);
	}


	public int Update(QueryCriteria criteria)
	{
		return persistent.Update(criteria);
	}


	public int Delete(Appraisal_Intimation mappedObject)
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
