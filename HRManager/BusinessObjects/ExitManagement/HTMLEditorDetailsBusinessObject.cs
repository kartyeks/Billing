using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;
namespace HRManager.BusinessObjects
{
    public partial class HTMLEditorDetailsBusinessObject
    {

        private HTMLEditorDetails mapped = new HTMLEditorDetails();
        private PersistentObject persistent = null;


        #region Constructors
        public HTMLEditorDetailsBusinessObject(DatabaseServer database, string connectionString)
        {
            persistent = new PersistentObject(database, connectionString, mapped);
        }


        public HTMLEditorDetailsBusinessObject(Session session)
        {
            persistent = new PersistentObject(session, mapped);
        }

        public HTMLEditorDetailsBusinessObject()
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


        public HTMLEditorDetails[] GetHTMLEditorDetails()
        {
            return (HTMLEditorDetails[])persistent.GetTableMetadata();
        }


        public HTMLEditorDetails GetHTMLEditorDetails(object primaryKeyValue)
        {
            return (HTMLEditorDetails)persistent.GetTableMetadata(primaryKeyValue);
        }


        public HTMLEditorDetails[] GetHTMLEditorDetails(QueryCriteria qc)
        {
            return (HTMLEditorDetails[])persistent.GetTableMetadata(qc);
        }


        public Array GetHTMLEditorDetails(string relatedTableName, Type classType, object foreignKeyValue)
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


        public object GetValue(QueryCriteria criteria)
        {
            return persistent.GetValue(criteria);
        }


        public bool IsUnique(DatabaseField field, object value)
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


        public int Create(HTMLEditorDetails mappedObject)
        {
            return persistent.Create(mappedObject);
        }


        public int Update(HTMLEditorDetails mappedObject)
        {
            return persistent.Update(mappedObject);
        }


        public int Update(QueryCriteria criteria)
        {
            return persistent.Update(criteria);
        }


        public int Delete(HTMLEditorDetails mappedObject)
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
