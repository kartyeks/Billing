using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Candidate_TrainingDetails : TableMetadata
		{

                   public enum Candidate_TrainingDetailsFields
                   {
                      ID,
                      CandidateID,
                      OrganizedBy,
                      Date,
                      Subject,
                      Certificate
                  }


			    private DatabaseField[] _fields;

		    	public Candidate_TrainingDetails()
			    {
					    _fields = new DatabaseField[6];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"CandidateID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.String,"OrganizedBy",false,false,null);
                    _fields[3] = new DatabaseField(DbType.String, "Duration", false, false, null);
                    _fields[4] = new DatabaseField(DbType.String,"Subject",false,false,null);
                    _fields[5] = new DatabaseField(DbType.String,"Certificate",false,false,null);
 
                        this.currentTableName = "Candidate_TrainingDetails";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Candidate_TrainingDetails Clone()
          {
                 return this.Clone<Candidate_TrainingDetails>();
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


public System.String OrganizedBy
{
    get
    {
         object result = this.GetField("OrganizedBy").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("OrganizedBy", value);
    }
}


public System.String Duration
{
    get
    {
        object result = this.GetField("Duration").fieldValue;
        return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
        this.SetFieldValue("Duration", value);
    }
}


public System.String Subject
{
    get
    {
         object result = this.GetField("Subject").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Subject", value);
    }
}


public System.String Certificate
{
    get
    {
         object result = this.GetField("Certificate").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Certificate", value);
    }
}

}
}
