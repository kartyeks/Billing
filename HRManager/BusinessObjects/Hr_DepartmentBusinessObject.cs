using System;
using System.Data;

using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;
namespace HRManager.BusinessObjects
{
    public partial class Hr_DepartmentBusinessObject
    {

        private Hr_Department mapped = new Hr_Department();
        private PersistentObject persistent = null;


        #region Constructors
        public Hr_DepartmentBusinessObject(DatabaseServer database, string connectionString)
        {
            persistent = new PersistentObject(database, connectionString, mapped);
        }


        public Hr_DepartmentBusinessObject(Session session)
        {
            persistent = new PersistentObject(session, mapped);
        }

        public Hr_DepartmentBusinessObject()
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


        public Hr_Department[] GetHr_Department()
        {
            return (Hr_Department[])persistent.GetTableMetadata();
        }


        public Hr_Department GetHr_Department(object primaryKeyValue)
        {
            return (Hr_Department)persistent.GetTableMetadata(primaryKeyValue);
        }


        public Hr_Department[] GetHr_Department(QueryCriteria qc)
        {
            return (Hr_Department[])persistent.GetTableMetadata(qc);
        }


        public Array GetHr_Department(string relatedTableName, Type classType, object foreignKeyValue)
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


        public int Create(Hr_Department mappedObject)
        {
            return persistent.Create(mappedObject);
        }


        public int Update(Hr_Department mappedObject)
        {
            return persistent.Update(mappedObject);
        }


        public int Update(QueryCriteria criteria)
        {
            return persistent.Update(criteria);
        }


        public int Delete(Hr_Department mappedObject)
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
