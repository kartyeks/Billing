using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Employee_LOPDetails : TableMetadata
		{

                   public enum Employee_LOPDetailsFields
                   {
                      ID,
                      EmployeeID,
                      FromDate,
                      ToDate,
                      LOPDays,
                      UploadedDate,
                      UploadedBy,
                      IsUsed,
                      Month,
                      Year
                  }


			    private DatabaseField[] _fields;

		    	public Employee_LOPDetails()
			    {
					    _fields = new DatabaseField[10];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"EmployeeID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.DateTime,"FromDate",false,false,null);
                    _fields[3] = new DatabaseField(DbType.DateTime,"ToDate",false,false,null);
                    _fields[4] = new DatabaseField(DbType.Double,"LOPDays",false,false,null);
                    _fields[5] = new DatabaseField(DbType.DateTime,"UploadedDate",false,false,null);
                    _fields[6] = new DatabaseField(DbType.Int32,"UploadedBy",false,false,null);
                    _fields[7] = new DatabaseField(DbType.Boolean,"IsUsed",false,false,null);
                    _fields[8] = new DatabaseField(DbType.Int32,"Month",false,false,null);
                    _fields[9] = new DatabaseField(DbType.Int32,"Year",false,false,null);
 
                        this.currentTableName = "Employee_LOPDetails";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Employee_LOPDetails Clone()
          {
                 return this.Clone<Employee_LOPDetails>();
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


public System.DateTime FromDate
{
    get
    {
        return (System.DateTime) this.GetField("FromDate").fieldValue; 
    }

    set
    {
          this.SetFieldValue("FromDate", value);
    }
}


public System.DateTime ToDate
{
    get
    {
        return (System.DateTime) this.GetField("ToDate").fieldValue; 
    }

    set
    {
          this.SetFieldValue("ToDate", value);
    }
}


public System.Double LOPDays
{
    get
    {
        return (System.Double) this.GetField("LOPDays").fieldValue; 
    }

    set
    {
          this.SetFieldValue("LOPDays", value);
    }
}


public System.DateTime UploadedDate
{
    get
    {
        return (System.DateTime) this.GetField("UploadedDate").fieldValue; 
    }

    set
    {
          this.SetFieldValue("UploadedDate", value);
    }
}


public System.Int32 UploadedBy
{
    get
    {
        return (System.Int32) this.GetField("UploadedBy").fieldValue; 
    }

    set
    {
          this.SetFieldValue("UploadedBy", value);
    }
}


public System.Boolean IsUsed
{
    get
    {
        return (System.Boolean) this.GetField("IsUsed").fieldValue; 
    }

    set
    {
          this.SetFieldValue("IsUsed", value);
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

}
}
