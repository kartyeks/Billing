using System;
using System.Data;

using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Assign_Candidate_Language : TableMetadata
		{

                   public enum Assign_Candidate_LanguageFields
                   {
                      ID,
                      CandidateID,
                      CLanguage,
                      CWrite,
                      CRead,
                      CSpeak,
                      CMotherTongue
                  }


			    private DatabaseField[] _fields;

		    	public Assign_Candidate_Language()
			    {
					    _fields = new DatabaseField[7];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"CandidateID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.String,"CLanguage",false,false,null);
                    _fields[3] = new DatabaseField(DbType.Boolean, "CWrite", false, false, null);
                    _fields[4] = new DatabaseField(DbType.Boolean, "CRead", false, false, null);
                    _fields[5] = new DatabaseField(DbType.Boolean, "CSpeak", false, false, null);
                    _fields[6] = new DatabaseField(DbType.Boolean, "CMotherTongue", false, false, null);
 
                        this.currentTableName = "Assign_Candidate_Language";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Assign_Candidate_Language Clone()
          {
                 return this.Clone<Assign_Candidate_Language>();
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


public System.String CLanguage
{
    get
    {
         object result = this.GetField("CLanguage").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("CLanguage", value);
    }
}

public System.Boolean CWrite
{
    get
    {
        return (System.Boolean)this.GetField("CWrite").fieldValue;
    }

    set
    {
        this.SetFieldValue("CWrite", value);
    }
}

public System.Boolean CRead
{
    get
    {
        return (System.Boolean)this.GetField("CRead").fieldValue;
    }

    set
    {
        this.SetFieldValue("CRead", value);
    }
}


public System.Boolean CSpeak
{
    get
    {
        return (System.Boolean)this.GetField("CSpeak").fieldValue;
    }

    set
    {
        this.SetFieldValue("CSpeak", value);
    }
}


public System.Boolean CMotherTongue
{
    get
    {
        return (System.Boolean)this.GetField("CMotherTongue").fieldValue;
    }

    set
    {
        this.SetFieldValue("CMotherTongue", value);
    }
}


}
}
