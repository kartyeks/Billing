using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{
    [Serializable()]
    public class Candidate_Interview_Result : TableMetadata
    {

        public enum Candidate_Interview_ResultFields
        {
            Id,
            CandidateID,
            JobTitle,
            InterviewerID,
            InterviewDate,
            CompetencyID,
            CompetencyValue,
            StrengthandWeakness,
            Recommendation,
            UpdatedBy,
            UpdatedDateTime
        }


        private DatabaseField[] _fields;

        public Candidate_Interview_Result()
        {
            _fields = new DatabaseField[11];
            _fields[0] = new DatabaseField(DbType.Int32, "Id", true, true, null);
            _fields[1] = new DatabaseField(DbType.Int32, "CandidateID", false, false, null);
            _fields[2] = new DatabaseField(DbType.String, "JobTitle", false, false, null);
            _fields[3] = new DatabaseField(DbType.Int32, "InterviewerID", false, false, null);
            _fields[4] = new DatabaseField(DbType.DateTime, "InterviewDate", false, false, null);
            _fields[5] = new DatabaseField(DbType.Int32, "CompetencyID", false, false, null);
            _fields[6] = new DatabaseField(DbType.Int32, "CompetencyValue", false, false, null);
            _fields[7] = new DatabaseField(DbType.String, "StrengthandWeakness", false, false, null);
            _fields[8] = new DatabaseField(DbType.String, "Recommendation", false, false, null);
            _fields[9] = new DatabaseField(DbType.Int32, "UpdatedBy", false, false, null);
            _fields[10] = new DatabaseField(DbType.DateTime, "UpdatedDateTime", false, false, null);

            this.currentTableName = "Candidate_Interview_Result";


        }


        public override DatabaseField[] TableFields
        {
            get { return _fields; }
            set { _fields = value; }
        }
        public Candidate_Interview_Result Clone()
        {
            return this.Clone<Candidate_Interview_Result>();
        }

        public System.Int32 Id
        {
            get
            {
                return (System.Int32)this.GetField("Id").fieldValue;
            }

            set
            {
                this.SetFieldValue("Id", value);
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


        public System.String JobTitle
        {
            get
            {
                object result = this.GetField("JobTitle").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("JobTitle", value);
            }
        }


        public System.Int32 InterviewerID
        {
            get
            {
                object result = this.GetField("InterviewerID").fieldValue;
                return (result == null || result == DBNull.Value) ? Int32.MinValue : (System.Int32)result;
            }

            set
            {
                this.SetFieldValue("InterviewerID", value);
            }
        }


        public System.DateTime InterviewDate
        {
            get
            {
                object result = this.GetField("InterviewDate").fieldValue;
                return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime)result;
            }

            set
            {
                this.SetFieldValue("InterviewDate", value);
            }
        }


        public System.Int32 CompetencyID
        {
            get
            {
                object result = this.GetField("CompetencyID").fieldValue;
                return (result == null || result == DBNull.Value) ? Int32.MinValue : (System.Int32)result;
            }

            set
            {
                this.SetFieldValue("CompetencyID", value);
            }
        }


        public System.Int32 CompetencyValue
        {
            get
            {
                object result = this.GetField("CompetencyValue").fieldValue;
                return (result == null || result == DBNull.Value) ? Int32.MinValue : (System.Int32)result;
            }

            set
            {
                this.SetFieldValue("CompetencyValue", value);
            }
        }


        public System.String StrengthandWeakness
        {
            get
            {
                object result = this.GetField("StrengthandWeakness").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("StrengthandWeakness", value);
            }
        }


        public System.String Recommendation
        {
            get
            {
                object result = this.GetField("Recommendation").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("Recommendation", value);
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

    }
}
