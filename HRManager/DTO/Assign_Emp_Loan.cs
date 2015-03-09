using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Assign_Emp_Loan : TableMetadata
		{

                   public enum Assign_Emp_LoanFields
                   {
                      ID,
                      LoanRequestID,
                      LoanAmount,
                      RepaidAmount,
                      DueAmount,
                      LoanTakenOn,
                      LoanClosedOn,
                      CreatedBy,
                      CreatedDate,
                      ModifiedBy,
                      ModifiedDate
                  }


			    private DatabaseField[] _fields;

		    	public Assign_Emp_Loan()
			    {
					    _fields = new DatabaseField[11];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"LoanRequestID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.Double,"LoanAmount",false,false,null);
                    _fields[3] = new DatabaseField(DbType.Double,"RepaidAmount",false,false,null);
                    _fields[4] = new DatabaseField(DbType.Double,"DueAmount",false,false,null);
                    _fields[5] = new DatabaseField(DbType.DateTime,"LoanTakenOn",false,false,null);
                    _fields[6] = new DatabaseField(DbType.DateTime,"LoanClosedOn",false,false,null);
                    _fields[7] = new DatabaseField(DbType.Int32, "CreatedBy", false, false, null);
                    _fields[8] = new DatabaseField(DbType.DateTime, "CreatedDate", false, false, null);
                    _fields[9] = new DatabaseField(DbType.Int32, "ModifiedBy", false, false, null);
                    _fields[10] = new DatabaseField(DbType.DateTime, "ModifiedDate", false, false, null);
 
                        this.currentTableName = "Assign_Emp_Loan";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Assign_Emp_Loan Clone()
          {
                 return this.Clone<Assign_Emp_Loan>();
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


public System.Int32 LoanRequestID
{
    get
    {
        return (System.Int32)this.GetField("LoanRequestID").fieldValue; 
    }

    set
    {
        this.SetFieldValue("LoanRequestID", value);
    }
}


public System.Double LoanAmount
{
    get
    {
        return (System.Double) this.GetField("LoanAmount").fieldValue; 
    }

    set
    {
          this.SetFieldValue("LoanAmount", value);
    }
}


public System.Double RepaidAmount
{
    get
    {
        return (System.Double) this.GetField("RepaidAmount").fieldValue; 
    }

    set
    {
          this.SetFieldValue("RepaidAmount", value);
    }
}


public System.Double DueAmount
{
    get
    {
        return (System.Double) this.GetField("DueAmount").fieldValue; 
    }

    set
    {
          this.SetFieldValue("DueAmount", value);
    }
}


public System.DateTime LoanTakenOn
{
    get
    {
        return (System.DateTime) this.GetField("LoanTakenOn").fieldValue; 
    }

    set
    {
          this.SetFieldValue("LoanTakenOn", value);
    }
}


public System.DateTime LoanClosedOn
{
    get
    {
         object result = this.GetField("LoanClosedOn").fieldValue; 
 return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime) result;
    }

    set
    {
          this.SetFieldValue("LoanClosedOn", value);
    }
}
public System.Int32 CreatedBy
{
    get
    {
        return (System.Int32)this.GetField("CreatedBy").fieldValue;
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
        object result = this.GetField("CreatedDate").fieldValue;
        return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime)result;
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
        return (System.Int32)this.GetField("ModifiedBy").fieldValue;
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
        object result = this.GetField("ModifiedDate").fieldValue;
        return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime)result;
    }

    set
    {
        this.SetFieldValue("ModifiedDate", value);
    }
}

}
}
