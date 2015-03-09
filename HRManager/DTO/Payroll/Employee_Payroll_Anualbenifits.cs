using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Employee_Payroll_Anualbenifits : TableMetadata
		{

                   public enum Employee_Payroll_AnualbenifitsFields
                   {
                      ID,
                      PayrollID,
                      AllowanceID,
                      AllowanceType,
                      Amount,
                      FinancialYear
                  }


			    private DatabaseField[] _fields;

		    	public Employee_Payroll_Anualbenifits()
			    {
					    _fields = new DatabaseField[6];
                        _fields[0] = new DatabaseField(DbType.Int32, "ID", true, true, null);
                    _fields[1] = new DatabaseField(DbType.Int32,"PayrollID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.Int32,"AllowanceID",false,false,null);
                    _fields[3] = new DatabaseField(DbType.String,"AllowanceType",false,false,null);
                    _fields[4] = new DatabaseField(DbType.Double,"Amount",false,false,null);
                    _fields[5] = new DatabaseField(DbType.Int32, "FinancialYear", false, false, null);
 
                        this.currentTableName = "Employee_Payroll_Anualbenifits";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Employee_Payroll_Anualbenifits Clone()
          {
                 return this.Clone<Employee_Payroll_Anualbenifits>();
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


public System.String AllowanceType
{
    get
    {
         object result = this.GetField("AllowanceType").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("AllowanceType", value);
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
public System.Int32 FinancialYear
{
    get
    {
        return (System.Int32)this.GetField("FinancialYear").fieldValue;
    }

    set
    {
        this.SetFieldValue("FinancialYear", value);
    }
}

}
}
