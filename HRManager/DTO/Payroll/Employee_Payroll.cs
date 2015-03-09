using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Employee_Payroll : TableMetadata
		{

                   public enum Employee_PayrollFields
                   {
                      ID,
                      EmployeeID,
                      Month,
                      Year,
                      PresentDays,
                      LOP,
                      Basic,
                      Special,
                      Others,
                      BasicArrears,
                      OtherArrears,
                      IsAnualbenifitsincluded,
                      GrossSalary,
                      NetSalary,
                      CreatedBy,
                      CreatedDate,
                      ModifiedBy,
                      ModifiedDate
                  }


			    private DatabaseField[] _fields;

		    	public Employee_Payroll()
			    {
					    _fields = new DatabaseField[18];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"EmployeeID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.Int32,"Month",false,false,null);
                    _fields[3] = new DatabaseField(DbType.Int32,"Year",false,false,null);
                    _fields[4] = new DatabaseField(DbType.Double,"PresentDays",false,false,null);
                    _fields[5] = new DatabaseField(DbType.Double,"LOP",false,false,null);
                    _fields[6] = new DatabaseField(DbType.Double,"Basic",false,false,null);
                    _fields[7] = new DatabaseField(DbType.Double,"Special",false,false,null);
                    _fields[8] = new DatabaseField(DbType.Double,"Others",false,false,null);
                    _fields[9] = new DatabaseField(DbType.Double,"BasicArrears",false,false,null);
                    _fields[10] = new DatabaseField(DbType.Double,"OtherArrears",false,false,null);
                    _fields[11] = new DatabaseField(DbType.Boolean,"IsAnualbenifitsincluded",false,false,null);
                    _fields[12] = new DatabaseField(DbType.Double,"GrossSalary",false,false,null);
                    _fields[13] = new DatabaseField(DbType.Double,"NetSalary",false,false,null);
                    _fields[14] = new DatabaseField(DbType.Int32,"CreatedBy",false,false,null);
                    _fields[15] = new DatabaseField(DbType.DateTime,"CreatedDate",false,false,null);
                    _fields[16] = new DatabaseField(DbType.Int32,"ModifiedBy",false,false,null);
                    _fields[17] = new DatabaseField(DbType.DateTime,"ModifiedDate",false,false,null);
 
                        this.currentTableName = "Employee_Payroll";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Employee_Payroll Clone()
          {
                 return this.Clone<Employee_Payroll>();
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


public System.Int32 Month
{
    get
    {
        return (System.Int32) this.GetField("Month").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Month", value);
    }
}


public System.Int32 Year
{
    get
    {
        return (System.Int32) this.GetField("Year").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Year", value);
    }
}


public System.Double PresentDays
{
    get
    {
        return (System.Double) this.GetField("PresentDays").fieldValue; 
    }

    set
    {
          this.SetFieldValue("PresentDays", value);
    }
}


public System.Double LOP
{
    get
    {
        return (System.Double) this.GetField("LOP").fieldValue; 
    }

    set
    {
          this.SetFieldValue("LOP", value);
    }
}


public System.Double Basic
{
    get
    {
        return (System.Double) this.GetField("Basic").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Basic", value);
    }
}


public System.Double Special
{
    get
    {
        return (System.Double) this.GetField("Special").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Special", value);
    }
}


public System.Double Others
{
    get
    {
        return (System.Double) this.GetField("Others").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Others", value);
    }
}


public System.Double BasicArrears
{
    get
    {
         object result = this.GetField("BasicArrears").fieldValue; 
 return (result == null || result == DBNull.Value) ? Double.MinValue : (System.Double) result;
    }

    set
    {
          this.SetFieldValue("BasicArrears", value);
    }
}


public System.Double OtherArrears
{
    get
    {
         object result = this.GetField("OtherArrears").fieldValue; 
 return (result == null || result == DBNull.Value) ? Double.MinValue : (System.Double) result;
    }

    set
    {
          this.SetFieldValue("OtherArrears", value);
    }
}


public System.Boolean IsAnualbenifitsincluded
{
    get
    {
         object result = this.GetField("IsAnualbenifitsincluded").fieldValue; 
 return (result == null || result == DBNull.Value) ? false : (System.Boolean) result;
    }

    set
    {
          this.SetFieldValue("IsAnualbenifitsincluded", value);
    }
}


public System.Double GrossSalary
{
    get
    {
        return (System.Double) this.GetField("GrossSalary").fieldValue; 
    }

    set
    {
          this.SetFieldValue("GrossSalary", value);
    }
}


public System.Double NetSalary
{
    get
    {
        return (System.Double) this.GetField("NetSalary").fieldValue; 
    }

    set
    {
          this.SetFieldValue("NetSalary", value);
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
         object result = this.GetField("ModifiedBy").fieldValue; 
 return (result == null || result == DBNull.Value) ? Int32.MinValue : (System.Int32) result;
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
 return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime) result;
    }

    set
    {
          this.SetFieldValue("ModifiedDate", value);
    }
}

}
}
