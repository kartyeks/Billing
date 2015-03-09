using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Loan_Request : TableMetadata
		{

                   public enum Loan_RequestFields
                   {
                      ID,
                      EmpID,
                      LoanID,
                      LoanAmount,
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
                      ModifiedDate,
                      MaxAmount,
                      Interest,
                      ActualRepaymentMonth
                  }


			    private DatabaseField[] _fields;

		    	public Loan_Request()
			    {
					    _fields = new DatabaseField[20];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"EmpID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.Int32,"LoanID",false,false,null);
                    _fields[3] = new DatabaseField(DbType.Double,"LoanAmount",false,false,null);
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
                    _fields[16] = new DatabaseField(DbType.Double,"MaxAmount",false,false,null);
                    _fields[17] = new DatabaseField(DbType.Double,"Interest",false,false,null);
                    _fields[18] = new DatabaseField(DbType.Double,"ActualRepaymentMonth",false,false,null);
                    _fields[19] = new DatabaseField(DbType.DateTime, "StartDate", false, false, null);
 
                        this.currentTableName = "Loan_Request";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Loan_Request Clone()
          {
                 return this.Clone<Loan_Request>();
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


public System.Int32 LoanID
{
    get
    {
        return (System.Int32) this.GetField("LoanID").fieldValue; 
    }

    set
    {
          this.SetFieldValue("LoanID", value);
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


public System.Double MaxAmount
{
    get
    {
         object result = this.GetField("MaxAmount").fieldValue; 
 return (result == null || result == DBNull.Value) ? Double.MinValue : (System.Double) result;
    }

    set
    {
          this.SetFieldValue("MaxAmount", value);
    }
}


public System.Double Interest
{
    get
    {
         object result = this.GetField("Interest").fieldValue; 
 return (result == null || result == DBNull.Value) ? Double.MinValue : (System.Double) result;
    }

    set
    {
          this.SetFieldValue("Interest", value);
    }
}


public System.Double ActualRepaymentMonth
{
    get
    {
         object result = this.GetField("ActualRepaymentMonth").fieldValue; 
 return (result == null || result == DBNull.Value) ? Double.MinValue : (System.Double) result;
    }

    set
    {
          this.SetFieldValue("ActualRepaymentMonth", value);
    }
}

public System.DateTime StartDate
{
    get
    {
        return (System.DateTime)this.GetField("StartDate").fieldValue;
    }

    set
    {
        this.SetFieldValue("StartDate", value);
    }
}

}
}
