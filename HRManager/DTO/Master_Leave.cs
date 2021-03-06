﻿using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

    [Serializable()]
    public class Master_Leave : TableMetadata
    {

        public enum Master_LeaveFields
        {
            ID,
            LeaveType,
            IsActive,
            CreatedBy,
            CreatedDate,
            ModifiedBy,
            ModifiedDate
        }


        private DatabaseField[] _fields;

        public Master_Leave()
        {
            _fields = new DatabaseField[7];
            _fields[0] = new DatabaseField(DbType.Int32, "ID", true, true, null);
            _fields[1] = new DatabaseField(DbType.String, "LeaveType", false, false, null);
            _fields[2] = new DatabaseField(DbType.Boolean, "IsActive", false, false, null);
            _fields[3] = new DatabaseField(DbType.Int32, "CreatedBy", false, false, null);
            _fields[4] = new DatabaseField(DbType.DateTime, "CreatedDate", false, false, null);
            _fields[5] = new DatabaseField(DbType.Int32, "ModifiedBy", false, false, null);
            _fields[6] = new DatabaseField(DbType.DateTime, "ModifiedDate", false, false, null);

            this.currentTableName = "Master_Leave";


        }


        public override DatabaseField[] TableFields
        {
            get { return _fields; }
            set { _fields = value; }
        }
        public Master_Leave Clone()
        {
            return this.Clone<Master_Leave>();
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


        public System.String LeaveType
        {
            get
            {
                object result = this.GetField("LeaveType").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("LeaveType", value);
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
                object result = this.GetField("CreatedDate").fieldValue;
                return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime)result;
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
                object result = this.GetField("ModifiedDate").fieldValue;
                return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime)result;
            }

            set
            {
                this.SetFieldValue("ModifiedDate", value);
            }
        }

    }
}
