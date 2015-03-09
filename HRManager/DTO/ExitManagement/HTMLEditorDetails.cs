using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
    public class HTMLEditorDetails : TableMetadata
    {

        public enum HTMLEditorDetailsFields
        {
            EMPID,
            HTMLContent,
            EditedByUser,
            EditedDateTime,
            HTMLFileName
        }


        private DatabaseField[] _fields;

        public HTMLEditorDetails()
        {
            _fields = new DatabaseField[5];
            _fields[0] = new DatabaseField(DbType.Int32, "EMPID", true, false, null);
            _fields[1] = new DatabaseField(DbType.String, "HTMLContent", false, false, null);
            _fields[2] = new DatabaseField(DbType.Int32, "EditedByUser", false, false, null);
            _fields[3] = new DatabaseField(DbType.DateTime, "EditedDateTime", false, false, null);
            _fields[4] = new DatabaseField(DbType.String, "HTMLFileName", false, false, null);

            this.currentTableName = "HTMLEditorDetails";


        }


        public override DatabaseField[] TableFields
        {
            get { return _fields; }
            set { _fields = value; }
        }
        public HTMLEditorDetails Clone()
        {
            return this.Clone<HTMLEditorDetails>();
        }

        public System.Int32 EMPID
        {
            get
            {
                return (System.Int32)this.GetField("EMPID").fieldValue;
            }

            set
            {
                this.SetFieldValue("EMPID", value);
            }
        }


        public System.String HTMLContent
        {
            get
            {
                object result = this.GetField("HTMLContent").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("HTMLContent", value);
            }
        }


        public System.Int32 EditedByUser
        {
            get
            {
                return (System.Int32)this.GetField("EditedByUser").fieldValue;
            }

            set
            {
                this.SetFieldValue("EditedByUser", value);
            }
        }


        public System.DateTime EditedDateTime
        {
            get
            {
                return (System.DateTime)this.GetField("EditedDateTime").fieldValue;
            }

            set
            {
                this.SetFieldValue("EditedDateTime", value);
            }
        }


        public System.String HTMLFileName
        {
            get
            {
                object result = this.GetField("HTMLFileName").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("HTMLFileName", value);
            }
        }

    }
}
