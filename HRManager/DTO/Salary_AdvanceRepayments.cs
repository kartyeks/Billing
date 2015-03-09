using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Salary_AdvanceRepayments : TableMetadata
		{

                   public enum Salary_AdvanceRepaymentsFields
                   {
                      ID,
                      EmpID,
                      AdvanceID,
                      Amount,
                      RepaymentDate,
                      CreatedBy,
                      CreatedDate,
                      ModifiedBy,
                      ModifiedDate
                  }


			    private DatabaseField[] _fields;

		    	public Salary_AdvanceRepayments()
			    {
					    _fields = new DatabaseField[9];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"EmpID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.Int32,"AdvanceID",false,false,null);
                    _fields[3] = new DatabaseField(DbType.Double,"Amount",false,false,null);
                    _fields[4] = new DatabaseField(DbType.DateTime,"RepaymentDate",false,false,null);
                    _fields[5] = new DatabaseField(DbType.Int32,"CreatedBy",false,false,null);
                    _fields[6] = new DatabaseField(DbType.DateTime,"CreatedDate",false,false,null);
                    _fields[7] = new DatabaseField(DbType.Int32,"ModifiedBy",false,false,null);
                    _fields[8] = new DatabaseField(DbType.DateTime,"ModifiedDate",false,false,null);
 
                        this.currentTableName = "Salary_AdvanceRepayments";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Salary_AdvanceRepayments Clone()
          {
                 return this.Clone<Salary_AdvanceRepayments>();
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


public System.Int32 AdvanceID
{
    get
    {
        return (System.Int32) this.GetField("AdvanceID").fieldValue; 
    }

    set
    {
          this.SetFieldValue("AdvanceID", value);
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
