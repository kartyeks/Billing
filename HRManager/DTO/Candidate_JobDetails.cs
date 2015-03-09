using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Candidate_JobDetails : TableMetadata
		{

                   public enum Candidate_JobDetailsFields
                   {
                      ID,
                      CandidateID,
                      JobID,
                      AppliedDate,
                      Status
                  }


			    private DatabaseField[] _fields;

		    	public Candidate_JobDetails()
			    {
					    _fields = new DatabaseField[5];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"CandidateID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.Int32,"JobID",false,false,null);
                    _fields[3] = new DatabaseField(DbType.DateTime,"AppliedDate",false,false,null);
                    _fields[4] = new DatabaseField(DbType.String,"Status",false,false,null);
 
                        this.currentTableName = "Candidate_JobDetails";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Candidate_JobDetails Clone()
          {
                 return this.Clone<Candidate_JobDetails>();
          }

public System.Int32 ID
{
    get
    {
        return (System.Int32) this.GetField("ID").fieldValue; 
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
        return (System.Int32) this.GetField("CandidateID").fieldValue; 
    }

    set
    {
          this.SetFieldValue("CandidateID", value);
    }
}


public System.Int32 JobID
{
    get
    {
        return (System.Int32) this.GetField("JobID").fieldValue; 
    }

    set
    {
          this.SetFieldValue("JobID", value);
    }
}


public System.DateTime AppliedDate
{
    get
    {
        return (System.DateTime) this.GetField("AppliedDate").fieldValue; 
    }

    set
    {
          this.SetFieldValue("AppliedDate", value);
    }
}


public System.String Status
{
    get
    {
         object result = this.GetField("Status").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Status", value);
    }
}

}
}
