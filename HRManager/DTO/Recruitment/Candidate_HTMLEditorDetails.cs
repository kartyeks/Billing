using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

    [Serializable()]
    public class Candidate_HTMLEditorDetails : TableMetadata
    {

        public enum Candidate_HTMLEditorDetailsFields
        {
            ID,
            CandidateID,
            HTMLContent,
            EditedByUser,
            EditedDateTime,
            HTMLFileName
        }


        private DatabaseField[] _fields;

        public Candidate_HTMLEditorDetails()
        {
            _fields = new DatabaseField[6];
            _fields[0] = new DatabaseField(DbType.Int32, "ID", true, true, null);
            _fields[1] = new DatabaseField(DbType.Int32, "CandidateID", false, false, null);
            _fields[2] = new DatabaseField(DbType.String, "HTMLContent", false, false, null);
            _fields[3] = new DatabaseField(DbType.Int32, "EditedByUser", false, false, null);
            _fields[4] = new DatabaseField(DbType.DateTime, "EditedDateTime", false, false, null);
            _fields[5] = new DatabaseField(DbType.String, "HTMLFileName", false, false, null);

            this.currentTableName = "Candidate_HTMLEditorDetails";


        }


        public override DatabaseField[] TableFields
        {
            get { return _fields; }
            set { _fields = value; }
        }
        public Candidate_HTMLEditorDetails Clone()
        {
            return this.Clone<Candidate_HTMLEditorDetails>();
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


        public System.Int32 CandidateID
        {
            get
            {
                return (System.Int32)this.GetField("CandidateID").fieldValue;
            }

            set
            {
                this.SetFieldValue("CandidateID", value);
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
