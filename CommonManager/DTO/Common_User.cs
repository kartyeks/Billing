using System;
using System.Data;

using System.Collections;
using IS91.Services.DataBlock;

namespace CommonManager.DTO
{
    [Serializable()]
    public class Common_User : TableMetadata
    {

        public enum Common_UserFields
        {
            ID,
            EmployeeID,
            LoginName,
            Password,
            IsActive,
            IsChangePassword,
            InvalidLoginCount,
            IsLocked,
            LastLoginTime,
            CreatedBy,
            CreatedDate,
            ModifiedBy,
            ModifiedDate,
            IsDefaultUser,
            LoginType
        }


        private DatabaseField[] _fields;

        public Common_User()
        {
            _fields = new DatabaseField[15];
            _fields[0] = new DatabaseField(DbType.Int32, "ID", true, true, null);
            _fields[1] = new DatabaseField(DbType.Int32, "EmployeeID", false, false, null);
            _fields[2] = new DatabaseField(DbType.String, "LoginName", false, false, null);
            _fields[3] = new DatabaseField(DbType.String, "Password", false, false, null);
            _fields[4] = new DatabaseField(DbType.Boolean, "IsActive", false, false, null);
            _fields[5] = new DatabaseField(DbType.Boolean, "IsChangePassword", false, false, null);
            _fields[6] = new DatabaseField(DbType.Int16, "InvalidLoginCount", false, false, null);
            _fields[7] = new DatabaseField(DbType.Boolean, "IsLocked", false, false, null);
            _fields[8] = new DatabaseField(DbType.DateTime, "LastLoginTime", false, false, null);
            _fields[9] = new DatabaseField(DbType.Int32, "CreatedBy", false, false, null);
            _fields[10] = new DatabaseField(DbType.DateTime, "CreatedDate", false, false, null);
            _fields[11] = new DatabaseField(DbType.Int32, "ModifiedBy", false, false, null);
            _fields[12] = new DatabaseField(DbType.DateTime, "ModifiedDate", false, false, null);
            _fields[13] = new DatabaseField(DbType.Boolean, "IsDefaultUser", false, false, null);
            _fields[14] = new DatabaseField(DbType.String, "LoginType", false, false, null);

            this.currentTableName = "Common_User";


        }


        public override DatabaseField[] TableFields
        {
            get { return _fields; }
            set { _fields = value; }
        }
        public Common_User Clone()
        {
            return this.Clone<Common_User>();
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

        public System.Int32 EmployeeID
        {
            get
            {
                return (System.Int32)this.GetField("EmployeeID").fieldValue;
            }

            set
            {
                this.SetFieldValue("EmployeeID", value);
            }
        }

        public System.String LoginName
        {
            get
            {
                object result = this.GetField("LoginName").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("LoginName", value);
            }
        }

       public System.String Password
        {
            get
            {
                object result = this.GetField("Password").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("Password", value);
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


        public System.Boolean IsChangePassword
        {
            get
            {
                return (System.Boolean)this.GetField("IsChangePassword").fieldValue;
            }

            set
            {
                this.SetFieldValue("IsChangePassword", value);
            }
        }


        public System.Int16 InvalidLoginCount
        {
            get
            {
                return (System.Int16)this.GetField("InvalidLoginCount").fieldValue;
            }

            set
            {
                this.SetFieldValue("InvalidLoginCount", value);
            }
        }


        public System.Boolean IsLocked
        {
            get
            {
                return (System.Boolean)this.GetField("IsLocked").fieldValue;
            }

            set
            {
                this.SetFieldValue("IsLocked", value);
            }
        }


        public System.DateTime LastLoginTime
        {
            get
            {
                return (System.DateTime)this.GetField("LastLoginTime").fieldValue;
            }

            set
            {
                this.SetFieldValue("LastLoginTime", value);
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


        public System.Boolean IsDefaultUser
        {
            get
            {
                return (System.Boolean)this.GetField("IsDefaultUser").fieldValue;
            }

            set
            {
                this.SetFieldValue("IsDefaultUser", value);
            }
        }

        public System.String LoginType
        {
            get
            {
                object result = this.GetField("LoginType").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("LoginType", value);
            }
        }

    }
}
