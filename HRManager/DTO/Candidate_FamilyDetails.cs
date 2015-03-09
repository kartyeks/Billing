using System;
using System.Data;

using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Candidate_FamilyDetails : TableMetadata
		{

          public enum Candidate_FamilyDetailsFields
                   {
                      ID,
                      CandidateID,
                      RelationID,
                      Name,
                      DateOfBirth,
                      Occupation,
                      AnnualIncome,
                      IsActive
                  }


			    private DatabaseField[] _fields;

		    	public Candidate_FamilyDetails()
			    {
					    _fields = new DatabaseField[8];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32, "RelationID", false, false, null);
                    _fields[2] = new DatabaseField(DbType.Int32, "CandidateID", false, false, null);
                    _fields[3] = new DatabaseField(DbType.String,"Name",false,false,null);
                    _fields[4] = new DatabaseField(DbType.DateTime,"DateOfBirth",false,false,null);
                    _fields[5] = new DatabaseField(DbType.String,"Occupation",false,false,null);
                    _fields[6] = new DatabaseField(DbType.String,"AnnualIncome",false,false,null);
                    _fields[7] = new DatabaseField(DbType.Boolean, "IsActive", false, false, null);

                    this.currentTableName = "Candidate_FamilyDetails";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Candidate_FamilyDetails Clone()
          {
                 return this.Clone<Candidate_FamilyDetails>();
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
        return (System.Int32)this.GetField("CandidateID").fieldValue;
    }

    set
    {
        this.SetFieldValue("CandidateID", value);
    }
}

public System.Int32 RelationID
{
    get
    {
        return (System.Int32) this.GetField("RelationID").fieldValue; 
    }

    set
    {
          this.SetFieldValue("RelationID", value);
    }
}


public System.String Name
{
    get
    {
         object result = this.GetField("Name").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Name", value);
    }
}


public System.DateTime DateOfBirth
{
    get
    {
        return (System.DateTime) this.GetField("DateOfBirth").fieldValue; 
    }

    set
    {
          this.SetFieldValue("DateOfBirth", value);
    }
}


public System.String Occupation
{
    get
    {
         object result = this.GetField("Occupation").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Occupation", value);
    }
}


public System.String AnnualIncome
{
    get
    {
         object result = this.GetField("AnnualIncome").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("AnnualIncome", value);
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

}
}
