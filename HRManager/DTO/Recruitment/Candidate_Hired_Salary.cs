using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Candidate_Hired_Salary : TableMetadata
		{

                   public enum Candidate_Hired_SalaryFields
                   {
                      ID,
                      CandidateID,
                      JoiningDate,
                      CTC,
                      ESOP
                  }


			    private DatabaseField[] _fields;

		    	public Candidate_Hired_Salary()
			    {
					    _fields = new DatabaseField[5];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"CandidateID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.DateTime,"JoiningDate",false,false,null);
                    _fields[3] = new DatabaseField(DbType.Double,"CTC",false,false,null);
                    _fields[4] = new DatabaseField(DbType.Int32,"ESOP",false,false,null);
 
                        this.currentTableName = "Candidate_Hired_Salary";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Candidate_Hired_Salary Clone()
          {
                 return this.Clone<Candidate_Hired_Salary>();
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
         object result = this.GetField("CandidateID").fieldValue; 
 return (result == null || result == DBNull.Value) ? Int32.MinValue : (System.Int32) result;
    }

    set
    {
          this.SetFieldValue("CandidateID", value);
    }
}


public System.DateTime JoiningDate
{
    get
    {
         object result = this.GetField("JoiningDate").fieldValue; 
 return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime) result;
    }

    set
    {
          this.SetFieldValue("JoiningDate", value);
    }
}


public System.Double CTC
{
    get
    {
         object result = this.GetField("CTC").fieldValue; 
 return (result == null || result == DBNull.Value) ? Double.MinValue : (System.Double) result;
    }

    set
    {
          this.SetFieldValue("CTC", value);
    }
}


public System.Int32 ESOP
{
    get
    {
         object result = this.GetField("ESOP").fieldValue; 
 return (result == null || result == DBNull.Value) ? Int32.MinValue : (System.Int32) result;
    }

    set
    {
          this.SetFieldValue("ESOP", value);
    }
}

}
}
