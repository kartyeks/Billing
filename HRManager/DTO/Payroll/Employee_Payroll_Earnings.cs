using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Employee_Payroll_Earnings : TableMetadata
		{

                   public enum Employee_Payroll_EarningsFields
                   {
                      ID,
                      PayrollID,
                      AllowanceID,
                      Amount
                  }


			    private DatabaseField[] _fields;

		    	public Employee_Payroll_Earnings()
			    {
					    _fields = new DatabaseField[4];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"PayrollID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.Int32,"AllowanceID",false,false,null);
                    _fields[3] = new DatabaseField(DbType.Double,"Amount",false,false,null);
 
                        this.currentTableName = "Employee_Payroll_Earnings";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Employee_Payroll_Earnings Clone()
          {
                 return this.Clone<Employee_Payroll_Earnings>();
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


public System.Int32 PayrollID
{
    get
    {
        return (System.Int32) this.GetField("PayrollID").fieldValue; 
    }

    set
    {
          this.SetFieldValue("PayrollID", value);
    }
}


public System.Int32 AllowanceID
{
    get
    {
        return (System.Int32) this.GetField("AllowanceID").fieldValue; 
    }

    set
    {
          this.SetFieldValue("AllowanceID", value);
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

}
}
