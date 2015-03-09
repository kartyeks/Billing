using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Loan_Repayments : TableMetadata
		{

                   public enum Loan_RepaymentsFields
                   {
                      ID,
                      LoanRequestID,
                      Amount,
                      RepaymentDate,
                      CreatedBy,
                      CreatedDate,
                      ModifiedBy,
                      ModifiedDate
                  }


			    private DatabaseField[] _fields;

		    	public Loan_Repayments()
			    {
					    _fields = new DatabaseField[8];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32, "LoanRequestID", false, false, null);
                    _fields[2] = new DatabaseField(DbType.Double,"Amount",false,false,null);
                    _fields[3] = new DatabaseField(DbType.DateTime,"RepaymentDate",false,false,null);
                    _fields[4] = new DatabaseField(DbType.Int32, "CreatedBy", false, false, null);
                    _fields[5] = new DatabaseField(DbType.DateTime, "CreatedDate", false, false, null);
                    _fields[6] = new DatabaseField(DbType.Int32, "ModifiedBy", false, false, null);
                    _fields[7] = new DatabaseField(DbType.DateTime, "ModifiedDate", false, false, null);
 
                        this.currentTableName = "Loan_Repayments";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Loan_Repayments Clone()
          {
                 return this.Clone<Loan_Repayments>();
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


public System.Double Amount
{
    get
    {
        return (System.Double) this.GetField("Amount").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Amount", value);
    }
}


public System.DateTime RepaymentDate
{
    get
    {
        return (System.DateTime) this.GetField("RepaymentDate").fieldValue; 
    }

    set
    {
          this.SetFieldValue("RepaymentDate", value);
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
