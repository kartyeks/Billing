using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Employee_Salary : TableMetadata
		{

                   public enum Employee_SalaryFields
                   {
                      ID,
                      EmployeeID,
                      CTC,
                      ESOP,
                       Basic,
                       IsActive,
                       EffectedDate
                  }


			    private DatabaseField[] _fields;

		    	public Employee_Salary()
			    {
					    _fields = new DatabaseField[7];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"EmployeeID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.Double,"CTC",false,false,null);
                    _fields[3] = new DatabaseField(DbType.Int32,"ESOP",false,false,null);
                    _fields[4] = new DatabaseField(DbType.Double, "Basic", false, false, null);
                    _fields[5] = new DatabaseField(DbType.Boolean, "IsActive", false, false, null);
                    _fields[6] = new DatabaseField(DbType.DateTime, "EffectedDate", false, false, null);
 
                        this.currentTableName = "Employee_Salary";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Employee_Salary Clone()
          {
                 return this.Clone<Employee_Salary>();
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


public System.Double CTC
{
    get
    {
        return (System.Double) this.GetField("CTC").fieldValue; 
    }

    set
    {
          this.SetFieldValue("CTC", value);
    }
}


public System.Int32 ESOP
{
    get
    {
        return (System.Int32) this.GetField("ESOP").fieldValue; 
    }

    set
    {
          this.SetFieldValue("ESOP", value);
    }
}
public System.Double Basic
{
    get
    {
        return (System.Double)this.GetField("Basic").fieldValue;
    }

    set
    {
        this.SetFieldValue("Basic", value);
    }
}
public System.Boolean IsActive
{
    get
    {
        return (System.Boolean)this.GetField("IsActive").fieldValue;
    }

    set
    {
        this.SetFieldValue("IsActive", value);
    }
}
public System.DateTime EffectedDate
{
    get
    {
        return (System.DateTime)this.GetField("EffectedDate").fieldValue;
    }

    set
    {
        this.SetFieldValue("EffectedDate", value);
    }
}
}
}
