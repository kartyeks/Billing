using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

    [Serializable()]
    public class Master_Loan : TableMetadata
    {

        public enum Master_LoanFields
        {
            ID,
            LoanName,
            MaxAmount,
            Interest,
            IsActive,
            CreatedBy,
            CreatedDate,
            ModifiedBy,
            ModifiedDate,
            MaxBasicPercentage,
            MinServicePeriod,
            MinLeaveBalance,
            RemainingService,
            Installment
        }


        private DatabaseField[] _fields;

        public Master_Loan()
        {
            _fields = new DatabaseField[14];
            _fields[0] = new DatabaseField(DbType.Int32, "ID", true, true, null);
            _fields[1] = new DatabaseField(DbType.String, "LoanName", false, false, null);
            _fields[2] = new DatabaseField(DbType.Double, "MaxAmount", false, false, null);
            _fields[3] = new DatabaseField(DbType.Double, "Interest", false, false, null);
            _fields[4] = new DatabaseField(DbType.Boolean, "IsActive", false, false, null);
            _fields[5] = new DatabaseField(DbType.Int32, "CreatedBy", false, false, null);
            _fields[6] = new DatabaseField(DbType.DateTime, "CreatedDate", false, false, null);
            _fields[7] = new DatabaseField(DbType.Int32, "ModifiedBy", false, false, null);
            _fields[8] = new DatabaseField(DbType.DateTime, "ModifiedDate", false, false, null);
            _fields[9] = new DatabaseField(DbType.Double, "MaxBasicPercentage", false, false, null);
            _fields[10] = new DatabaseField(DbType.Int32, "MinServicePeriod", false, false, null);
            _fields[11] = new DatabaseField(DbType.Int32, "MinLeaveBalance", false, false, null);
            _fields[12] = new DatabaseField(DbType.Int32, "RemainingService", false, false, null);
            _fields[13] = new DatabaseField(DbType.String, "Installment", false, false, null);

            this.currentTableName = "Master_Loan";


        }

        
        public override DatabaseField[] TableFields
        {
            get { return _fields; }
            set { _fields = value; }
        }
        public Master_Loan Clone()
        {
            return this.Clone<Master_Loan>();
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


        public System.String LoanName
        {
            get
            {
                object result = this.GetField("LoanName").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("LoanName", value);
            }
        }


        public System.Double MaxAmount
        {
            get
            {
                //return (System.Double)this.GetField("MaxAmount").fieldValue;
                object result = this.GetField("MaxAmount").fieldValue;
                return (result == null || result == DBNull.Value) ? Double.MinValue : (System.Double)result;
            }

            set
            {
                this.SetFieldValue("MaxAmount", value);
            }
        }


        public System.Double Interest
        {
            get
            {
                //return (System.Double)this.GetField("Interest").fieldValue;
                object result = this.GetField("Interest").fieldValue;
                return (result == null || result == DBNull.Value) ? Double.MinValue : (System.Double)result;
            }

            set
            {
                this.SetFieldValue("Interest", value);
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
        public System.Double MaxBasicPercentage
        {
            get
            {
                object result = this.GetField("MaxBasicPercentage").fieldValue;
                return (result == null || result == DBNull.Value) ? Double.MinValue : (System.Double)result;
            }

            set
            {
                this.SetFieldValue("MaxBasicPercentage", value);
            }
        }
        public System.Int32 MinServicePeriod
        {
            get
            {
                return (System.Int32)this.GetField("MinServicePeriod").fieldValue;
            }

            set
            {
                this.SetFieldValue("MinServicePeriod", value);
            }
        }
        public System.Int32 MinLeaveBalance
        {
            get
            {
                return (System.Int32)this.GetField("MinLeaveBalance").fieldValue;
            }

            set
            {
                this.SetFieldValue("MinLeaveBalance", value);
            }
        }
        public System.Int32 RemainingService
        {
            get
            {
                return (System.Int32)this.GetField("RemainingService").fieldValue;
            }

            set
            {
                this.SetFieldValue("RemainingService", value);
            }
        }
        public System.String Installment
        {
            get
            {
                object result = this.GetField("Installment").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("Installment", value);
            }
        }


    }
}
