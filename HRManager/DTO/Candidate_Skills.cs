using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Candidate_Skills : TableMetadata
		{

                   public enum Candidate_SkillsFields
                   {
                      ID,
                      CandidateID,
                      SkillSet,
                      NoOfMonths,
                      LastApplied
                  }


			    private DatabaseField[] _fields;

		    	public Candidate_Skills()
			    {
					    _fields = new DatabaseField[5];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"CandidateID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.String,"SkillSet",false,false,null);
                    _fields[3] = new DatabaseField(DbType.Int16,"NoOfMonths",false,false,null);
                    _fields[4] = new DatabaseField(DbType.String,"LastApplied",false,false,null);
 
                        this.currentTableName = "Candidate_Skills";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Candidate_Skills Clone()
          {
                 return this.Clone<Candidate_Skills>();
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


public System.String SkillSet
{
    get
    {
         object result = this.GetField("SkillSet").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("SkillSet", value);
    }
}


public System.Int16 NoOfMonths
{
    get
    {
        return (System.Int16) this.GetField("NoOfMonths").fieldValue; 
    }

    set
    {
          this.SetFieldValue("NoOfMonths", value);
    }
}


public System.String LastApplied
{
    get
    {
         object result = this.GetField("LastApplied").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("LastApplied", value);
    }
}

}
}
