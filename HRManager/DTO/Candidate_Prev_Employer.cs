using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Candidate_Prev_Employer : TableMetadata
		{

                   public enum Candidate_Prev_EmployerFields
                   {
                      ID,
                      CandidateID,
                      EmployerName,
                      Designation,
                      Responsibilities,
                      ResonForLeaving,
                      StartDate,
                      EndDate,
                      CTC,
                      TakeHome
                  }


			    private DatabaseField[] _fields;

		    	public Candidate_Prev_Employer()
			    {
					    _fields = new DatabaseField[10];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"CandidateID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.String,"EmployerName",false,false,null);
                    _fields[3] = new DatabaseField(DbType.String,"Designation",false,false,null);
                    _fields[4] = new DatabaseField(DbType.String,"Responsibilities",false,false,null);
                    _fields[5] = new DatabaseField(DbType.String,"ResonForLeaving",false,false,null);
                    _fields[6] = new DatabaseField(DbType.DateTime,"StartDate",false,false,null);
                    _fields[7] = new DatabaseField(DbType.DateTime,"EndDate",false,false,null);
                    _fields[8] = new DatabaseField(DbType.Double,"CTC",false,false,null);
                    _fields[9] = new DatabaseField(DbType.Double,"TakeHome",false,false,null);
 
                        this.currentTableName = "Candidate_Prev_Employer";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Candidate_Prev_Employer Clone()
          {
                 return this.Clone<Candidate_Prev_Employer>();
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


public System.String EmployerName
{
    get
    {
         object result = this.GetField("EmployerName").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("EmployerName", value);
    }
}


public System.String Designation
{
    get
    {
         object result = this.GetField("Designation").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Designation", value);
    }
}


public System.String Responsibilities
{
    get
    {
         object result = this.GetField("Responsibilities").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Responsibilities", value);
    }
}


public System.String ResonForLeaving
{
    get
    {
         object result = this.GetField("ResonForLeaving").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("ResonForLeaving", value);
    }
}


public System.DateTime StartDate
{
    get
    {
        return (System.DateTime) this.GetField("StartDate").fieldValue; 
    }

    set
    {
          this.SetFieldValue("StartDate", value);
    }
}


public System.DateTime EndDate
{
    get
    {
        return (System.DateTime) this.GetField("EndDate").fieldValue; 
    }

    set
    {
          this.SetFieldValue("EndDate", value);
    }
}


public System.Double CTC
{
    get
    {
        return (System.Double) this.GetField("CTC").fieldValue; 
    }

    set
    {
          this.SetFieldValue("CTC", value);
    }
}


public System.Double TakeHome
{
    get
    {
        return (System.Double) this.GetField("TakeHome").fieldValue; 
    }

    set
    {
          this.SetFieldValue("TakeHome", value);
    }
}

}
}
