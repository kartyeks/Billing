using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Candidate_Education_Details : TableMetadata
		{

                   public enum Candidate_Education_DetailsFields
                   {
                      ID,
                      CandidateID,
                      Education,
                      Stream,
                      University,
                      Year,
                      Percentage
                  }


			    private DatabaseField[] _fields;

		    	public Candidate_Education_Details()
			    {
					    _fields = new DatabaseField[7];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"CandidateID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.String,"Education",false,false,null);
                    _fields[3] = new DatabaseField(DbType.String,"Stream",false,false,null);
                    _fields[4] = new DatabaseField(DbType.String,"University",false,false,null);
                    _fields[5] = new DatabaseField(DbType.Int32,"Year",false,false,null);
                    _fields[6] = new DatabaseField(DbType.Double,"Percentage",false,false,null);
 
                        this.currentTableName = "Candidate_Education_Details";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Candidate_Education_Details Clone()
          {
                 return this.Clone<Candidate_Education_Details>();
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


public System.String Education
{
    get
    {
         object result = this.GetField("Education").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Education", value);
    }
}


public System.String Stream
{
    get
    {
         object result = this.GetField("Stream").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Stream", value);
    }
}


public System.String University
{
    get
    {
         object result = this.GetField("University").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("University", value);
    }
}


public System.Int32 Year
{
    get
    {
        return (System.Int32) this.GetField("Year").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Year", value);
    }
}


public System.Double Percentage
{
    get
    {
        return (System.Double) this.GetField("Percentage").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Percentage", value);
    }
}

}
}
