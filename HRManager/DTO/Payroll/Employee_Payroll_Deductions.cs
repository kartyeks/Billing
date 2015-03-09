using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Employee_Payroll_Deductions : TableMetadata
		{

                   public enum Employee_Payroll_DeductionsFields
                   {
                      ID,
                      PayrollID,
                      DeductionID,
                      Amount,
                      DeductionType
                  }


			    private DatabaseField[] _fields;

		    	public Employee_Payroll_Deductions()
			    {
					    _fields = new DatabaseField[5];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"PayrollID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.Int32,"DeductionID",false,false,null);
                    _fields[3] = new DatabaseField(DbType.Double,"Amount",false,false,null);
                    _fields[4] = new DatabaseField(DbType.String,"DeductionType",false,false,null);
 
                        this.currentTableName = "Employee_Payroll_Deductions";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Employee_Payroll_Deductions Clone()
          {
                 return this.Clone<Employee_Payroll_Deductions>();
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


public System.Int32 DeductionID
{
    get
    {
        return (System.Int32) this.GetField("DeductionID").fieldValue; 
    }

    set
    {
          this.SetFieldValue("DeductionID", value);
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


public System.String DeductionType
{
    get
    {
         object result = this.GetField("DeductionType").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("DeductionType", value);
    }
}

}
}
