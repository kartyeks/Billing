using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

    [Serializable()]
    public class Candidate_Interview_Status : TableMetadata
    {

        public enum Candidate_Interview_StatusFields
        {
            ID,
            CandidateID,
            TeamID,
            CandidateStatus,
            Date1Time1,
            Date2Time2,
            UpdatedBy,
            UpdatedDateTime,
            IsCandidateAvailable,
            RejectionRemarks
        }


        private DatabaseField[] _fields;

        public Candidate_Interview_Status()
        {
            _fields = new DatabaseField[10];
            _fields[0] = new DatabaseField(DbType.Int32, "ID", true, true, null);
            _fields[1] = new DatabaseField(DbType.Int32, "CandidateID", false, false, null);
            _fields[2] = new DatabaseField(DbType.Int32, "TeamID", false, false, null);
            _fields[3] = new DatabaseField(DbType.String, "CandidateStatus", false, false, null);
            _fields[4] = new DatabaseField(DbType.DateTime, "Date1Time1", false, false, null);
            _fields[5] = new DatabaseField(DbType.DateTime, "Date2Time2", false, false, null);
            _fields[6] = new DatabaseField(DbType.Int32, "UpdatedBy", false, false, null);
            _fields[7] = new DatabaseField(DbType.DateTime, "UpdatedDateTime", false, false, null);
            _fields[8] = new DatabaseField(DbType.Boolean, "IsCandidateAvailable", false, false, null);
            _fields[9] = new DatabaseField(DbType.String, "RejectionRemarks", false, false, null);

            this.currentTableName = "Candidate_Interview_Status";


        }


        public override DatabaseField[] TableFields
        {
            get { return _fields; }
            set { _fields = value; }
        }
        public Candidate_Interview_Status Clone()
        {
            return this.Clone<Candidate_Interview_Status>();
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
                object result = this.GetField("CandidateID").fieldValue;
                return (result == null || result == DBNull.Value) ? Int32.MinValue : (System.Int32)result;
            }

            set
            {
                this.SetFieldValue("CandidateID", value);
            }
        }


        public System.Int32 TeamID
        {
            get
            {
                object result = this.GetField("TeamID").fieldValue;
                return (result == null || result == DBNull.Value) ? Int32.MinValue : (System.Int32)result;
            }

            set
            {
                this.SetFieldValue("TeamID", value);
            }
        }


        public System.String CandidateStatus
        {
            get
            {
                object result = this.GetField("CandidateStatus").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("CandidateStatus", value);
            }
        }

        public System.DateTime Date1Time1
        {
            get
            {
                object result = this.GetField("Date1Time1").fieldValue;
                return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime)result;
            }

            set
            {
                this.SetFieldValue("Date1Time1", value);
            }
        }


        public System.DateTime Date2Time2
        {
            get
            {
                object result = this.GetField("Date2Time2").fieldValue;
                return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime)result;
            }

            set
            {
                this.SetFieldValue("Date2Time2", value);
            }
        }


        public System.Int32 UpdatedBy
        {
            get
            {
                object result = this.GetField("UpdatedBy").fieldValue;
                return (result == null || result == DBNull.Value) ? Int32.MinValue : (System.Int32)result;
            }

            set
            {
                this.SetFieldValue("UpdatedBy", value);
            }
        }


        public System.DateTime UpdatedDateTime
        {
            get
            {
                object result = this.GetField("UpdatedDateTime").fieldValue;
                return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime)result;
            }

            set
            {
                this.SetFieldValue("UpdatedDateTime", value);
            }
        }


        public System.Boolean IsCandidateAvailable
        {
            get
            {
                object result = this.GetField("IsCandidateAvailable").fieldValue;
                return (result == null || result == DBNull.Value) ? false : (System.Boolean)result;
            }

            set
            {
                this.SetFieldValue("IsCandidateAvailable", value);
            }
        }


        public System.String RejectionRemarks
        {
            get
            {
                object result = this.GetField("RejectionRemarks").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("RejectionRemarks", value);
            }
        }

    }
}
