using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

    [Serializable()]
    public class Candidate_Questioners : TableMetadata
    {

        public enum Candidate_QuestionersFields
        {
            ID,
            CandidateID,
            Achievements,
            Challenges,
            Goals,
            EmployeerRemarks,
            CommitmentYears,
            ExpectedMonthlyGross,
            ExpectedMonthlyTakeHome,
            ExpectedYearlyCTC,
            NoticePeriod,
            WillingToRelocate,
            InBond,
            SelfDetails,
            WhyISutie,
            FunctionalArea,
            PlaningForStudies,
            AlreadyInterviewed,
            InterviewedPosistion,
            Ref1_Name,
            Ref1_Address,
            Ref1_PhoneNumber,
            Ref1_MobileNumber,
            Ref2_Name,
            Ref2_Address,
            Ref2_PhoneNumber,
            Ref2_MobileNumber,
            PlaningForStudydetails,
            RelocatePlace,
            BondDetails,
            Ref1_Remarks,
            Ref2_Remarks,
            Ref_Remarks,
            Status,
            ReferenceCheckerID
        }


        private DatabaseField[] _fields;

        public Candidate_Questioners()
        {
            _fields = new DatabaseField[35];
            _fields[0] = new DatabaseField(DbType.Int32, "ID", true, true, null);
            _fields[1] = new DatabaseField(DbType.Int32, "CandidateID", false, false, null);
            _fields[2] = new DatabaseField(DbType.String, "Achievements", false, false, null);
            _fields[3] = new DatabaseField(DbType.String, "Challenges", false, false, null);
            _fields[4] = new DatabaseField(DbType.String, "Goals", false, false, null);
            _fields[5] = new DatabaseField(DbType.String, "EmployeerRemarks", false, false, null);
            _fields[6] = new DatabaseField(DbType.Int16, "CommitmentYears", false, false, null);
            _fields[7] = new DatabaseField(DbType.Double, "ExpectedMonthlyGross", false, false, null);
            _fields[8] = new DatabaseField(DbType.Double, "ExpectedMonthlyTakeHome", false, false, null);
            _fields[9] = new DatabaseField(DbType.Double, "ExpectedYearlyCTC", false, false, null);
            _fields[10] = new DatabaseField(DbType.Int16, "NoticePeriod", false, false, null);
            _fields[11] = new DatabaseField(DbType.Boolean, "WillingToRelocate", false, false, null);
            _fields[12] = new DatabaseField(DbType.Boolean, "InBond", false, false, null);
            _fields[13] = new DatabaseField(DbType.String, "SelfDetails", false, false, null);
            _fields[14] = new DatabaseField(DbType.String, "WhyISutie", false, false, null);
            _fields[15] = new DatabaseField(DbType.String, "FunctionalArea", false, false, null);
            _fields[16] = new DatabaseField(DbType.Boolean, "PlaningForStudies", false, false, null);
            _fields[17] = new DatabaseField(DbType.Boolean, "AlreadyInterviewed", false, false, null);
            _fields[18] = new DatabaseField(DbType.String, "InterviewedPosistion", false, false, null);
            _fields[19] = new DatabaseField(DbType.String, "Ref1_Name", false, false, null);
            _fields[20] = new DatabaseField(DbType.String, "Ref1_Address", false, false, null);
            _fields[21] = new DatabaseField(DbType.String, "Ref1_PhoneNumber", false, false, null);
            _fields[22] = new DatabaseField(DbType.String, "Ref1_MobileNumber", false, false, null);
            _fields[23] = new DatabaseField(DbType.String, "Ref2_Name", false, false, null);
            _fields[24] = new DatabaseField(DbType.String, "Ref2_Address", false, false, null);
            _fields[25] = new DatabaseField(DbType.String, "Ref2_PhoneNumber", false, false, null);
            _fields[26] = new DatabaseField(DbType.String, "Ref2_MobileNumber", false, false, null);
            _fields[27] = new DatabaseField(DbType.String, "PlaningForStudydetails", false, false, null);
            _fields[28] = new DatabaseField(DbType.String, "RelocatePlace", false, false, null);
            _fields[29] = new DatabaseField(DbType.String, "BondDetails", false, false, null);
            _fields[30] = new DatabaseField(DbType.String, "Ref1_Remarks", false, false, null);
            _fields[31] = new DatabaseField(DbType.String, "Ref2_Remarks", false, false, null);
            _fields[32] = new DatabaseField(DbType.String, "Ref_Remarks", false, false, null);
            _fields[33] = new DatabaseField(DbType.Boolean, "Status", false, false, null);
            _fields[34] = new DatabaseField(DbType.Int32, "ReferenceCheckerID", false, false, null);

            this.currentTableName = "Candidate_Questioners";


        }


        public override DatabaseField[] TableFields
        {
            get { return _fields; }
            set { _fields = value; }
        }
        public Candidate_Questioners Clone()
        {
            return this.Clone<Candidate_Questioners>();
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


        public System.String Achievements
        {
            get
            {
                object result = this.GetField("Achievements").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("Achievements", value);
            }
        }


        public System.String Challenges
        {
            get
            {
                object result = this.GetField("Challenges").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("Challenges", value);
            }
        }


        public System.String Goals
        {
            get
            {
                object result = this.GetField("Goals").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("Goals", value);
            }
        }


        public System.String EmployeerRemarks
        {
            get
            {
                object result = this.GetField("EmployeerRemarks").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("EmployeerRemarks", value);
            }
        }


        public System.Int16 CommitmentYears
        {
            get
            {
                return (System.Int16)this.GetField("CommitmentYears").fieldValue;
            }

            set
            {
                this.SetFieldValue("CommitmentYears", value);
            }
        }


        public System.Double ExpectedMonthlyGross
        {
            get
            {
                object result = this.GetField("ExpectedMonthlyGross").fieldValue;
                return (result == null || result == DBNull.Value) ? Double.MinValue : (System.Double)result;
            }

            set
            {
                this.SetFieldValue("ExpectedMonthlyGross", value);
            }
        }


        public System.Double ExpectedMonthlyTakeHome
        {
            get
            {
                object result = this.GetField("ExpectedMonthlyTakeHome").fieldValue;
                return (result == null || result == DBNull.Value) ? Double.MinValue : (System.Double)result;
            }

            set
            {
                this.SetFieldValue("ExpectedMonthlyTakeHome", value);
            }
        }


        public System.Double ExpectedYearlyCTC
        {
            get
            {
                object result = this.GetField("ExpectedYearlyCTC").fieldValue;
                return (result == null || result == DBNull.Value) ? Double.MinValue : (System.Double)result;
            }

            set
            {
                this.SetFieldValue("ExpectedYearlyCTC", value);
            }
        }


        public System.Int16 NoticePeriod
        {
            get
            {
                return (System.Int16)this.GetField("NoticePeriod").fieldValue;
            }

            set
            {
                this.SetFieldValue("NoticePeriod", value);
            }
        }


        public System.Boolean WillingToRelocate
        {
            get
            {
                return (System.Boolean)this.GetField("WillingToRelocate").fieldValue;
            }

            set
            {
                this.SetFieldValue("WillingToRelocate", value);
            }
        }


        public System.Boolean InBond
        {
            get
            {
                return (System.Boolean)this.GetField("InBond").fieldValue;
            }

            set
            {
                this.SetFieldValue("InBond", value);
            }
        }


        public System.String SelfDetails
        {
            get
            {
                object result = this.GetField("SelfDetails").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("SelfDetails", value);
            }
        }


        public System.String WhyISutie
        {
            get
            {
                object result = this.GetField("WhyISutie").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("WhyISutie", value);
            }
        }


        public System.String FunctionalArea
        {
            get
            {
                object result = this.GetField("FunctionalArea").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("FunctionalArea", value);
            }
        }


        public System.Boolean PlaningForStudies
        {
            get
            {
                return (System.Boolean)this.GetField("PlaningForStudies").fieldValue;
            }

            set
            {
                this.SetFieldValue("PlaningForStudies", value);
            }
        }


        public System.Boolean AlreadyInterviewed
        {
            get
            {
                return (System.Boolean)this.GetField("AlreadyInterviewed").fieldValue;
            }

            set
            {
                this.SetFieldValue("AlreadyInterviewed", value);
            }
        }


        public System.String InterviewedPosistion
        {
            get
            {
                object result = this.GetField("InterviewedPosistion").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("InterviewedPosistion", value);
            }
        }


        public System.String Ref1_Name
        {
            get
            {
                object result = this.GetField("Ref1_Name").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("Ref1_Name", value);
            }
        }


        public System.String Ref1_Address
        {
            get
            {
                object result = this.GetField("Ref1_Address").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("Ref1_Address", value);
            }
        }


        public System.String Ref1_PhoneNumber
        {
            get
            {
                object result = this.GetField("Ref1_PhoneNumber").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("Ref1_PhoneNumber", value);
            }
        }


        public System.String Ref1_MobileNumber
        {
            get
            {
                object result = this.GetField("Ref1_MobileNumber").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("Ref1_MobileNumber", value);
            }
        }


        public System.String Ref2_Name
        {
            get
            {
                object result = this.GetField("Ref2_Name").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("Ref2_Name", value);
            }
        }


        public System.String Ref2_Address
        {
            get
            {
                object result = this.GetField("Ref2_Address").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("Ref2_Address", value);
            }
        }


        public System.String Ref2_PhoneNumber
        {
            get
            {
                object result = this.GetField("Ref2_PhoneNumber").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("Ref2_PhoneNumber", value);
            }
        }


        public System.String Ref2_MobileNumber
        {
            get
            {
                object result = this.GetField("Ref2_MobileNumber").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("Ref2_MobileNumber", value);
            }
        }


        public System.String PlaningForStudydetails
        {
            get
            {
                object result = this.GetField("PlaningForStudydetails").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("PlaningForStudydetails", value);
            }
        }


        public System.String RelocatePlace
        {
            get
            {
                object result = this.GetField("RelocatePlace").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("RelocatePlace", value);
            }
        }


        public System.String BondDetails
        {
            get
            {
                object result = this.GetField("BondDetails").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("BondDetails", value);
            }
        }


        public System.String Ref1_Remarks
        {
            get
            {
                object result = this.GetField("Ref1_Remarks").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("Ref1_Remarks", value);
            }
        }


        public System.String Ref2_Remarks
        {
            get
            {
                object result = this.GetField("Ref2_Remarks").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("Ref2_Remarks", value);
            }
        }


        public System.String Ref_Remarks
        {
            get
            {
                object result = this.GetField("Ref_Remarks").fieldValue;
                return (result != null) ? result.ToString() : String.Empty;
            }

            set
            {
                this.SetFieldValue("Ref_Remarks", value);
            }
        }


        public System.Boolean Status
        {
            get
            {
                object result = this.GetField("Status").fieldValue;
                return (result == null || result == DBNull.Value) ? false : (System.Boolean)result;
            }

            set
            {
                this.SetFieldValue("Status", value);
            }
        }


        public System.Int32 ReferenceCheckerID
        {
            get
            {
                object result = this.GetField("ReferenceCheckerID").fieldValue;
                return (result == null || result == DBNull.Value) ? Int32.MinValue : (System.Int32)result;
            }

            set
            {
                this.SetFieldValue("ReferenceCheckerID", value);
            }
        }

    }
}
