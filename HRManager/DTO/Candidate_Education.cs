using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Candidate_Education : TableMetadata
		{

                   public enum Candidate_EducationFields
                   {
                      ID,
                      CandidateID,
                      Title,
                      Subject,
                      Institute,
                      Percentage,
                      Grade,
                      FromDate,
                      ToDate
                  }


			    private DatabaseField[] _fields;

		    	public Candidate_Education()
			    {
					    _fields = new DatabaseField[9];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"CandidateID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.String,"Title",false,false,null);
                    _fields[3] = new DatabaseField(DbType.String,"Subject",false,false,null);
                    _fields[4] = new DatabaseField(DbType.String,"Institute",false,false,null);
                    _fields[5] = new DatabaseField(DbType.Double,"Percentage",false,false,null);
                    _fields[6] = new DatabaseField(DbType.String,"Grade",false,false,null);
                    _fields[7] = new DatabaseField(DbType.DateTime,"FromDate",false,false,null);
                    _fields[8] = new DatabaseField(DbType.DateTime,"ToDate",false,false,null);
 
                        this.currentTableName = "Candidate_Education";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Candidate_Education Clone()
          {
                 return this.Clone<Candidate_Education>();
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


public System.String Title
{
    get
    {
         object result = this.GetField("Title").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Title", value);
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


public System.String Institute
{
    get
    {
         object result = this.GetField("Institute").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Institute", value);
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


public System.String Grade
{
    get
    {
         object result = this.GetField("Grade").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Grade", value);
    }
}


public System.DateTime FromDate
{
    get
    {
        return (System.DateTime) this.GetField("FromDate").fieldValue; 
    }

    set
    {
          this.SetFieldValue("FromDate", value);
    }
}


public System.DateTime ToDate
{
    get
    {
        return (System.DateTime) this.GetField("ToDate").fieldValue; 
    }

    set
    {
          this.SetFieldValue("ToDate", value);
    }
}

}
}
