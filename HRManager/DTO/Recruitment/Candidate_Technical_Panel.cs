using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Candidate_Technical_Panel : TableMetadata
		{

                   public enum Candidate_Technical_PanelFields
                   {
                        ID,
                        CandidateInterviewStatusID,
                        TechnicalPanelID,
                        InterviewTypeID
                  }


			    private DatabaseField[] _fields;

		    	public Candidate_Technical_Panel()
			    {
					    _fields = new DatabaseField[4];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32, "CandidateInterviewStatusID", false, false, null);
                    _fields[2] = new DatabaseField(DbType.Int32,"TechnicalPanelID",false,false,null);
                    _fields[3] = new DatabaseField(DbType.Int32, "InterviewTypeID", false, false, null);
 
                        this.currentTableName = "Candidate_Technical_Panel";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Candidate_Technical_Panel Clone()
          {
                 return this.Clone<Candidate_Technical_Panel>();
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

        public System.Int32 CandidateInterviewStatusID
        {
            get
            {
                return (System.Int32)this.GetField("CandidateInterviewStatusID").fieldValue;
            }

            set
            {
                this.SetFieldValue("CandidateInterviewStatusID", value);
            }
        }

        public System.Int32 TechnicalPanelID
        {
            get
            {
                 object result = this.GetField("TechnicalPanelID").fieldValue; 
         return (result == null || result == DBNull.Value) ? Int32.MinValue : (System.Int32) result;
            }

            set
            {
                  this.SetFieldValue("TechnicalPanelID", value);
            }
        }

        public System.Int32 InterviewTypeID
        {
            get
            {
                object result = this.GetField("InterviewTypeID").fieldValue;
                return (result == null || result == DBNull.Value) ? Int32.MinValue : (System.Int32)result;
            }

            set
            {
                this.SetFieldValue("InterviewTypeID", value);
            }
        }
    }
}
