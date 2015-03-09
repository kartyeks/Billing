using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{
    [Serializable()]
    public class Master_Candidate : TableMetadata
    {

        public enum Master_CandidateFields
        {
            ID,
            TeamID,
            CandidateType,
            FirstName,
            MiddleName,
            LastName,
            CurrentEmployer,
            CareerStartDate,
            Experience,
            TechnologyExpertise,
            ContactNumber,
            EmailID,
            NoticePeriod,
            CurrentLocation,
            ReasonForChange,
            OffersInHand,
            ResumeFilename,
            RecruitmentType,
            CreatedBy,
            CreatedDate,
            ModifiedBy,
            ModifiedDate,
            IsDeleted
        }


        private DatabaseField[] _fields;

        public Master_Candidate()
        {
            _fields = new DatabaseField[23];
            _fields[0] = new DatabaseField(DbType.Int32, "ID", true, true, null);
            _fields[1] = new DatabaseField(DbType.Int32, "TeamID", false, false, null);
            _fields[2] = new DatabaseField(DbType.String, "CandidateType", false, false, null);
            _fields[3] = new DatabaseField(DbType.String, "FirstName", false, false, null);
            _fields[4] = new DatabaseField(DbType.String, "MiddleName", false, false, null);
            _fields[5] = new DatabaseField(DbType.String, "LastName", false, false, null);
            _fields[6] = new DatabaseField(DbType.String, "CurrentEmployer", false, false, null);
            _fields[7] = new DatabaseField(DbType.DateTime, "CareerStartDate", false, false, null);
            _fields[8] = new DatabaseField(DbType.String, "Experience", false, false, null);
            _fields[9] = new DatabaseField(DbType.String, "TechnologyExpertise", false, false, null);
            _fields[10] = new DatabaseField(DbType.String, "ContactNumber", false, false, null);
            _fields[11] = new DatabaseField(DbType.String, "EmailID", false, false, null);
            _fields[12] = new DatabaseField(DbType.Int32, "NoticePeriod", false, false, null);
            _fields[13] = new DatabaseField(DbType.String, "CurrentLocation", false, false, null);
            _fields[14] = new DatabaseField(DbType.String, "ReasonForChange", false, false, null);
            _fields[15] = new DatabaseField(DbType.String, "OffersInHand", false, false, null);
            _fields[16] = new DatabaseField(DbType.String, "ResumeFilename", false, false, null);
            _fields[17] = new DatabaseField(DbType.String, "RecruitmentType", false, false, null);
            _fields[18] = new DatabaseField(DbType.Int32, "CreatedBy", false, false, null);
            _fields[19] = new DatabaseField(DbType.DateTime, "CreatedDate", false, false, null);
            _fields[20] = new DatabaseField(DbType.Int32, "ModifiedBy", false, false, null);
            _fields[21] = new DatabaseField(DbType.DateTime, "ModifiedDate", false, false, null);
            _fields[22] = new DatabaseField(DbType.Boolean, "IsDeleted", false, false, null);

            this.currentTableName = "Master_Candidate";


        }


        public override DatabaseField[] TableFields
        {
            get { return _fields; }
            set { _fields = value; }
        }
        public Master_Candidate Clone()
        {
            return this.Clone<Master_Candidate>();
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


        public System.Int32 TeamID
        {
            get
            {
                return (System.Int32)this.GetField("TeamID").fieldValue;
            }

            set
            {
                this.SetFieldValue("TeamID", value);
            }
        }


        public System.String CandidateType
        {
            get
            {
                object result = this.GetField("CandidateType").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("CandidateType", value);
            }
        }


        public System.String FirstName
        {
            get
            {
                object result = this.GetField("FirstName").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("FirstName", value);
            }
        }


        public System.String MiddleName
        {
            get
            {
                object result = this.GetField("MiddleName").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("MiddleName", value);
            }
        }


        public System.String LastName
        {
            get
            {
                object result = this.GetField("LastName").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("LastName", value);
            }
        }


        public System.String CurrentEmployer
        {
            get
            {
                object result = this.GetField("CurrentEmployer").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("CurrentEmployer", value);
            }
        }


        public System.DateTime CareerStartDate
        {
            get
            {
                object result = this.GetField("CareerStartDate").fieldValue;
                return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime)result;
            }

            set
            {
                this.SetFieldValue("CareerStartDate", value);
            }
        }


        public System.String Experience
        {
            get
            {
                object result = this.GetField("Experience").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("Experience", value);
            }
        }


        public System.String TechnologyExpertise
        {
            get
            {
                object result = this.GetField("TechnologyExpertise").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("TechnologyExpertise", value);
            }
        }


        public System.String ContactNumber
        {
            get
            {
                object result = this.GetField("ContactNumber").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("ContactNumber", value);
            }
        }


        public System.String EmailID
        {
            get
            {
                object result = this.GetField("EmailID").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("EmailID", value);
            }
        }


        public System.Int32 NoticePeriod
        {
            get
            {
                object result = this.GetField("NoticePeriod").fieldValue;
                return (result == null || result == DBNull.Value) ? Int32.MinValue : (System.Int32)result;
            }

            set
            {
                this.SetFieldValue("NoticePeriod", value);
            }
        }


        public System.String CurrentLocation
        {
            get
            {
                object result = this.GetField("CurrentLocation").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("CurrentLocation", value);
            }
        }


        public System.String ReasonForChange
        {
            get
            {
                object result = this.GetField("ReasonForChange").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("ReasonForChange", value);
            }
        }


        public System.String OffersInHand
        {
            get
            {
                object result = this.GetField("OffersInHand").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("OffersInHand", value);
            }
        }

        public System.String ResumeFilename
        {
            get
            {
                object result = this.GetField("ResumeFilename").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("ResumeFilename", value);
            }
        }

        public System.String RecruitmentType
        {
            get
            {
                object result = this.GetField("RecruitmentType").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("RecruitmentType", value);
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

        public System.Boolean IsDeleted
        {
            get
            {
                object result = this.GetField("IsDeleted").fieldValue;
                return (result == null || result == DBNull.Value) ? false : (System.Boolean)result;
            }

            set
            {
                this.SetFieldValue("IsDeleted", value);
            }
        }

    }
}
