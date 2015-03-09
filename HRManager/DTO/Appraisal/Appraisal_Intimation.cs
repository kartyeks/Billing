using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Appraisal_Intimation : TableMetadata
		{

                   public enum Appraisal_IntimationFields
                   {
                      ID,
                      GoalIntimationDate,
                      AppraisalIntimationDate,
                      IntimateBy,
                      DocumentName
                  }


			    private DatabaseField[] _fields;

		    	public Appraisal_Intimation()
			    {
					    _fields = new DatabaseField[5];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.DateTime,"GoalIntimationDate",false,false,null);
                    _fields[2] = new DatabaseField(DbType.DateTime,"AppraisalIntimationDate",false,false,null);
                    _fields[3] = new DatabaseField(DbType.Int32,"IntimateBy",false,false,null);
                    _fields[4] = new DatabaseField(DbType.String, "DocumentName", false, false, null);                    
 
                        this.currentTableName = "Appraisal_Intimation";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Appraisal_Intimation Clone()
          {
                 return this.Clone<Appraisal_Intimation>();
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


public System.DateTime GoalIntimationDate
{
    get
    {
         object result = this.GetField("GoalIntimationDate").fieldValue; 
 return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime) result;
    }

    set
    {
          this.SetFieldValue("GoalIntimationDate", value);
    }
}


public System.DateTime AppraisalIntimationDate
{
    get
    {
         object result = this.GetField("AppraisalIntimationDate").fieldValue; 
 return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime) result;
    }

    set
    {
          this.SetFieldValue("AppraisalIntimationDate", value);
    }
}


public System.Int32 IntimateBy
{
    get
    {
         object result = this.GetField("IntimateBy").fieldValue; 
 return (result == null || result == DBNull.Value) ? Int32.MinValue : (System.Int32) result;
    }

    set
    {
          this.SetFieldValue("IntimateBy", value);
    }
}

public System.String DocumentName
{
    get
    {
        object result = this.GetField("DocumentName").fieldValue;
        return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
        this.SetFieldValue("DocumentName", value);
    }
}

}
}
