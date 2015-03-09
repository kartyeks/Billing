using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class EmployeeAttendance : TableMetadata
		{

                   public enum EmployeeAttendanceFields
                   {
                      ID,
                      EmployeeID,
                      Month,
                      Year,
                      WorkingDays,
                      PresentDays,
                      WEndDaysCount,
                      HoliDaysCount,
                      PunchedDays,
                      NotPunchedDays,
                      ReasonForNotPunched,
                      LOPDays,
                      CreatedBy,
                      CreatedDate,
                      ModifiedBy,
                      ModifiedDate
                  }


			    private DatabaseField[] _fields;

		    	public EmployeeAttendance()
			    {
					    _fields = new DatabaseField[16];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"EmployeeID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.Int32,"Month",false,false,null);
                    _fields[3] = new DatabaseField(DbType.Int32,"Year",false,false,null);
                    _fields[4] = new DatabaseField(DbType.Double,"WorkingDays",false,false,null);
                    _fields[5] = new DatabaseField(DbType.Double,"PresentDays",false,false,null);
                    _fields[6] = new DatabaseField(DbType.Double,"WEndDaysCount",false,false,null);
                    _fields[7] = new DatabaseField(DbType.Double,"HoliDaysCount",false,false,null);
                    _fields[8] = new DatabaseField(DbType.Double,"PunchedDays",false,false,null);
                    _fields[9] = new DatabaseField(DbType.Double,"NotPunchedDays",false,false,null);
                    _fields[10] = new DatabaseField(DbType.String,"ReasonForNotPunched",false,false,null);
                    _fields[11] = new DatabaseField(DbType.Double, "LOPDays", false, false, null);
                    _fields[12] = new DatabaseField(DbType.Int32, "CreatedBy", false, false, null);
                    _fields[13] = new DatabaseField(DbType.DateTime,"CreatedDate",false,false,null);
                    _fields[14] = new DatabaseField(DbType.Int32, "ModifiedBy", false, false, null);
                    _fields[15] = new DatabaseField(DbType.DateTime,"ModifiedDate",false,false,null);
 
                        this.currentTableName = "EmployeeAttendance";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public EmployeeAttendance Clone()
          {
                 return this.Clone<EmployeeAttendance>();
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


public System.Double WorkingDays
{
    get
    {
        return (System.Double) this.GetField("WorkingDays").fieldValue; 
    }

    set
    {
          this.SetFieldValue("WorkingDays", value);
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


public System.Double WEndDaysCount
{
    get
    {
        return (System.Double) this.GetField("WEndDaysCount").fieldValue; 
    }

    set
    {
          this.SetFieldValue("WEndDaysCount", value);
    }
}


public System.Double HoliDaysCount
{
    get
    {
        return (System.Double) this.GetField("HoliDaysCount").fieldValue; 
    }

    set
    {
          this.SetFieldValue("HoliDaysCount", value);
    }
}


public System.Double PunchedDays
{
    get
    {
        return (System.Double) this.GetField("PunchedDays").fieldValue; 
    }

    set
    {
          this.SetFieldValue("PunchedDays", value);
    }
}


public System.Double NotPunchedDays
{
    get
    {
         object result = this.GetField("NotPunchedDays").fieldValue; 
 return (result == null || result == DBNull.Value) ? Double.MinValue : (System.Double) result;
    }

    set
    {
          this.SetFieldValue("NotPunchedDays", value);
    }
}


public System.String ReasonForNotPunched
{
    get
    {
         object result = this.GetField("ReasonForNotPunched").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("ReasonForNotPunched", value);
    }
}
public System.Double LOPDays
{
    get
    {
        return (System.Double)this.GetField("LOPDays").fieldValue;
    }

    set
    {
        this.SetFieldValue("LOPDays", value);
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
 return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime) result;
    }

    set
    {
          this.SetFieldValue("ModifiedDate", value);
    }
}

}
}
