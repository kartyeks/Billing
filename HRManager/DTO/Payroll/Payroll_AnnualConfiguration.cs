using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Payroll_AnnualConfiguration : TableMetadata
		{

                   public enum Payroll_AnnualConfigurationFields
                   {
                      ID,
                      EmployeeID,
                      FinancialYear,
                      RentPaid,
                      TDS,
                      LeaveEncashDays,
                      ActivatedDate
                  }


			    private DatabaseField[] _fields;

		    	public Payroll_AnnualConfiguration()
			    {
					    _fields = new DatabaseField[7];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"EmployeeID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.Int32,"FinancialYear",false,false,null);
                    _fields[3] = new DatabaseField(DbType.Double,"RentPaid",false,false,null);
                    _fields[4] = new DatabaseField(DbType.Double,"TDS",false,false,null);
                    _fields[5] = new DatabaseField(DbType.Double,"LeaveEncashDays",false,false,null);
                    _fields[6] = new DatabaseField(DbType.DateTime, "ActivatedDate", false, false, null);
 
                        this.currentTableName = "Payroll_AnnualConfiguration";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Payroll_AnnualConfiguration Clone()
          {
                 return this.Clone<Payroll_AnnualConfiguration>();
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


public System.Int32 EmployeeID
{
    get
    {
        return (System.Int32) this.GetField("EmployeeID").fieldValue; 
    }

    set
    {
          this.SetFieldValue("EmployeeID", value);
    }
}


public System.Int32 FinancialYear
{
    get
    {
        return (System.Int32) this.GetField("FinancialYear").fieldValue; 
    }

    set
    {
          this.SetFieldValue("FinancialYear", value);
    }
}


public System.Double RentPaid
{
    get
    {
         object result = this.GetField("RentPaid").fieldValue; 
 return (result == null || result == DBNull.Value) ? Double.MinValue : (System.Double) result;
    }

    set
    {
          this.SetFieldValue("RentPaid", value);
    }
}


public System.Double TDS
{
    get
    {
         object result = this.GetField("TDS").fieldValue; 
 return (result == null || result == DBNull.Value) ? Double.MinValue : (System.Double) result;
    }

    set
    {
          this.SetFieldValue("TDS", value);
    }
}


public System.Double LeaveEncashDays
{
    get
    {
         object result = this.GetField("LeaveEncashDays").fieldValue; 
 return (result == null || result == DBNull.Value) ? Double.MinValue : (System.Double) result;
    }

    set
    {
          this.SetFieldValue("LeaveEncashDays", value);
    }
}
public System.DateTime ActivatedDate
{
    get
    {
        return (System.DateTime)this.GetField("ActivatedDate").fieldValue;
    }

    set
    {
        this.SetFieldValue("ActivatedDate", value);
    }
}

}
}
