using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Salary_Advance : TableMetadata
		{

                   public enum Salary_AdvanceFields
                   {
                      ID,
                      AdvanceID,
                      EmpID,
                      AdvanceAmount,
                      RepaymentMonths,
                      MonthlyAmount,
                      Reason,
                      AppliedDateTime,
                      AppliedTo,
                      HRRemarks,
                      Status,
                      RepliedDateTime,
                      CreatedBy,
                      CreatedDate,
                      ModifiedBy,
                      ModifiedDate
                  }


			    private DatabaseField[] _fields;

		    	public Salary_Advance()
			    {
					    _fields = new DatabaseField[16];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32, "AdvanceID", false, false, null);
                    _fields[2] = new DatabaseField(DbType.Int32,"EmpID",false,false,null);
                    _fields[3] = new DatabaseField(DbType.Double, "AdvanceAmount", false, false, null);
                    _fields[4] = new DatabaseField(DbType.Int16,"RepaymentMonths",false,false,null);
                    _fields[5] = new DatabaseField(DbType.Double,"MonthlyAmount",false,false,null);
                    _fields[6] = new DatabaseField(DbType.String,"Reason",false,false,null);
                    _fields[7] = new DatabaseField(DbType.DateTime,"AppliedDateTime",false,false,null);
                    _fields[8] = new DatabaseField(DbType.Int32,"AppliedTo",false,false,null);
                    _fields[9] = new DatabaseField(DbType.String,"HRRemarks",false,false,null);
                    _fields[10] = new DatabaseField(DbType.String,"Status",false,false,null);
                    _fields[11] = new DatabaseField(DbType.DateTime,"RepliedDateTime",false,false,null);
                    _fields[12] = new DatabaseField(DbType.Int32,"CreatedBy",false,false,null);
                    _fields[13] = new DatabaseField(DbType.DateTime,"CreatedDate",false,false,null);
                    _fields[14] = new DatabaseField(DbType.Int32,"ModifiedBy",false,false,null);
                    _fields[15] = new DatabaseField(DbType.DateTime,"ModifiedDate",false,false,null);
 
                        this.currentTableName = "Salary_Advance";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Salary_Advance Clone()
          {
                 return this.Clone<Salary_Advance>();
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

public System.Int32 AdvanceID
{
    get
    {
        return (System.Int32)this.GetField("AdvanceID").fieldValue;
    }

    set
    {
        this.SetFieldValue("AdvanceID", value);
    }
}


public System.Int32 EmpID
{
    get
    {
        return (System.Int32) this.GetField("EmpID").fieldValue; 
    }

    set
    {
          this.SetFieldValue("EmpID", value);
    }
}


public System.Double AdvanceAmount
{
    get
    {
        return (System.Double)this.GetField("AdvanceAmount").fieldValue; 
    }

    set
    {
        this.SetFieldValue("AdvanceAmount", value);
    }
}


public System.Int16 RepaymentMonths
{
    get
    {
        return (System.Int16) this.GetField("RepaymentMonths").fieldValue; 
    }

    set
    {
          this.SetFieldValue("RepaymentMonths", value);
    }
}


public System.Double MonthlyAmount
{
    get
    {
        return (System.Double) this.GetField("MonthlyAmount").fieldValue; 
    }

    set
    {
          this.SetFieldValue("MonthlyAmount", value);
    }
}


public System.String Reason
{
    get
    {
         object result = this.GetField("Reason").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Reason", value);
    }
}


public System.DateTime AppliedDateTime
{
    get
    {
        return (System.DateTime) this.GetField("AppliedDateTime").fieldValue; 
    }

    set
    {
          this.SetFieldValue("AppliedDateTime", value);
    }
}


public System.Int32 AppliedTo
{
    get
    {
        return (System.Int32) this.GetField("AppliedTo").fieldValue; 
    }

    set
    {
          this.SetFieldValue("AppliedTo", value);
    }
}


public System.String HRRemarks
{
    get
    {
         object result = this.GetField("HRRemarks").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("HRRemarks", value);
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


public System.DateTime RepliedDateTime
{
    get
    {
         object result = this.GetField("RepliedDateTime").fieldValue; 
 return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime) result;
    }

    set
    {
          this.SetFieldValue("RepliedDateTime", value);
    }
}


public System.Int32 CreatedBy
{
    get
    {
        return (System.Int32) this.GetField("CreatedBy").fieldValue; 
    }

    set
    {
          this.SetFieldValue("CreatedBy", value);
    }
}


public System.DateTime CreatedDate
{
    get
    {
        return (System.DateTime) this.GetField("CreatedDate").fieldValue; 
    }

    set
    {
          this.SetFieldValue("CreatedDate", value);
    }
}


public System.Int32 ModifiedBy
{
    get
    {
        return (System.Int32) this.GetField("ModifiedBy").fieldValue; 
    }

    set
    {
          this.SetFieldValue("ModifiedBy", value);
    }
}


public System.DateTime ModifiedDate
{
    get
    {
        return (System.DateTime) this.GetField("ModifiedDate").fieldValue; 
    }

    set
    {
          this.SetFieldValue("ModifiedDate", value);
    }
}

}
}
