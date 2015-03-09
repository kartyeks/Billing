using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
    public class Permissions : TableMetadata
    {

        public enum PermissionsFields
        {
            RoleID,
            FunctionID,
            Apply,
            Approvals,
            ViewMode,
            CreatedBy,
            CreatedDate,
            ModifiedBy,
            ModifiedDate
        }


        private DatabaseField[] _fields;

        public Permissions()
        {
            _fields = new DatabaseField[9];
            _fields[0] = new DatabaseField(DbType.Int32, "RoleID", true, false, null);
            _fields[1] = new DatabaseField(DbType.Int32, "FunctionID", true, false, null);
            _fields[2] = new DatabaseField(DbType.Boolean, "Apply", false, false, null);
            _fields[3] = new DatabaseField(DbType.Boolean, "Approvals", false, false, null);
            _fields[4] = new DatabaseField(DbType.Boolean, "ViewMode", false, false, null);
            _fields[5] = new DatabaseField(DbType.Int32, "CreatedBy", false, false, null);
            _fields[6] = new DatabaseField(DbType.DateTime, "CreatedDate", false, false, null);
            _fields[7] = new DatabaseField(DbType.Int32, "ModifiedBy", false, false, null);
            _fields[8] = new DatabaseField(DbType.DateTime, "ModifiedDate", false, false, null);

            this.currentTableName = "Permissions";


        }


        public override DatabaseField[] TableFields
        {
            get { return _fields; }
            set { _fields = value; }
        }
        public Permissions Clone()
        {
            return this.Clone<Permissions>();
        }

        public System.Int32 RoleID
        {
            get
            {
                return (System.Int32)this.GetField("RoleID").fieldValue;
            }

            set
            {
                this.SetFieldValue("RoleID", value);
            }
        }


        public System.Int32 FunctionID
        {
            get
            {
                return (System.Int32)this.GetField("FunctionID").fieldValue;
            }

            set
            {
                this.SetFieldValue("FunctionID", value);
            }
        }


        public System.Boolean Apply
        {
            get
            {
                return (System.Boolean)this.GetField("Apply").fieldValue;
            }

            set
            {
                this.SetFieldValue("Apply", value);
            }
        }


        public System.Boolean Approvals
        {
            get
            {
                return (System.Boolean)this.GetField("Approvals").fieldValue;
            }

            set
            {
                this.SetFieldValue("Approvals", value);
            }
        }


        public System.Boolean ViewMode
        {
            get
            {
                return (System.Boolean)this.GetField("ViewMode").fieldValue;
            }

            set
            {
                this.SetFieldValue("ViewMode", value);
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
