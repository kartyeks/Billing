using System;
using System.Data;

using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

    [Serializable()]
    public class Hr_Department : TableMetadata
    {

        public enum Hr_DepartmentFields
        {
            ID,
            DepartmentName,
            ParentID,
            Description,
            IsDepartment,
            IsActive,
            CreatedBy,
            CreatedDate,
            ModifiedBy,
            ModifiedDate,
            HOD,
            IsHR,
            IsFinance
        }


        private DatabaseField[] _fields;

        public Hr_Department()
        {
            _fields = new DatabaseField[13];
            _fields[0] = new DatabaseField(DbType.Int32, "ID", true, true, null);
            _fields[1] = new DatabaseField(DbType.String, "DepartmentName", false, false, null);
            _fields[2] = new DatabaseField(DbType.Int32, "ParentID", false, false, null);
            _fields[3] = new DatabaseField(DbType.String, "Description", false, false, null);
            _fields[4] = new DatabaseField(DbType.Boolean, "IsDepartment", false, false, null);
            _fields[5] = new DatabaseField(DbType.Boolean, "IsActive", false, false, null);
            _fields[6] = new DatabaseField(DbType.Int32, "CreatedBy", false, false, null);
            _fields[7] = new DatabaseField(DbType.DateTime, "CreatedDate", false, false, null);
            _fields[8] = new DatabaseField(DbType.Int32, "ModifiedBy", false, false, null);
            _fields[9] = new DatabaseField(DbType.DateTime, "ModifiedDate", false, false, null);
            _fields[10] = new DatabaseField(DbType.Int32, "HOD", false, false, null);
            _fields[11] = new DatabaseField(DbType.Boolean, "IsHR", false, false, null);
            _fields[12] = new DatabaseField(DbType.Boolean, "IsFinance", false, false, null);

            this.currentTableName = "Hr_Department";


        }


        public override DatabaseField[] TableFields
        {
            get { return _fields; }
            set { _fields = value; }
        }
        public Hr_Department Clone()
        {
            return this.Clone<Hr_Department>();
        }

        public System.Int32 ID
        {
            get
            {
                return (System.Int32)this.GetField("ID").fieldValue;
            }

            set
            {
                this.SetFieldValue("ID", value);
            }
        }
        public System.Int32 HOD
        {
            get
            {
                return (System.Int32)this.GetField("HOD").fieldValue;
            }

            set
            {
                this.SetFieldValue("HOD", value);
            }
        }
        public System.Boolean IsHR
        {
            get
            {
                return (System.Boolean)this.GetField("IsHR").fieldValue;
            }

            set
            {
                this.SetFieldValue("IsHR", value);
            }
        }
        public System.Boolean IsFinance
        {
            get
            {
                return (System.Boolean)this.GetField("IsFinance").fieldValue;
            }

            set
            {
                this.SetFieldValue("IsFinance", value);
            }
        }


        public System.String DepartmentName
        {
            get
            {
                object result = this.GetField("DepartmentName").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("DepartmentName", value);
            }
        }


        public System.Int32 ParentID
        {
            get
            {
                object result = this.GetField("ParentID").fieldValue;
                return (result == null || result == DBNull.Value) ? Int32.MinValue : (System.Int32)result;
            }

            set
            {
                this.SetFieldValue("ParentID", value);
            }
        }


        public System.String Description
        {
            get
            {
                object result = this.GetField("Description").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("Description", value);
            }
        }


        public System.Boolean IsDepartment
        {
            get
            {
                return (System.Boolean)this.GetField("IsDepartment").fieldValue;
            }

            set
            {
                this.SetFieldValue("IsDepartment", value);
            }
        }


        public System.Boolean IsActive
        {
            get
            {
                return (System.Boolean)this.GetField("IsActive").fieldValue;
            }

            set
            {
                this.SetFieldValue("IsActive", value);
            }
        }


        public System.Int32 CreatedBy
        {
            get
            {
                return (System.Int32)this.GetField("CreatedBy").fieldValue;
            }

            set
            {
                this.SetFieldValue("CreatedBy", value);
            }
        }


        public System.DateTime CreatedDate
        {
            get
            {
                return (System.DateTime)this.GetField("CreatedDate").fieldValue;
            }

            set
            {
                this.SetFieldValue("CreatedDate", value);
            }
        }


        public System.Int32 ModifiedBy
        {
            get
            {
                return (System.Int32)this.GetField("ModifiedBy").fieldValue;
            }

            set
            {
                this.SetFieldValue("ModifiedBy", value);
            }
        }


        public System.DateTime ModifiedDate
        {
            get
            {
                return (System.DateTime)this.GetField("ModifiedDate").fieldValue;
            }

            set
            {
                this.SetFieldValue("ModifiedDate", value);
            }
        }

    }
}
