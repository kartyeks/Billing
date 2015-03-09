using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class EmployeeAttendance_LeaveDetails : TableMetadata
		{

                   public enum EmployeeAttendance_LeaveDetailsFields
                   {
                      ID,
                      AttendanceID,
                      LeaveID,
                      NoOfLeaveCount
                  }


			    private DatabaseField[] _fields;

		    	public EmployeeAttendance_LeaveDetails()
			    {
					    _fields = new DatabaseField[4];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"AttendanceID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.Int32,"LeaveID",false,false,null);
                    _fields[3] = new DatabaseField(DbType.Double,"NoOfLeaveCount",false,false,null);
 
                        this.currentTableName = "EmployeeAttendance_LeaveDetails";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public EmployeeAttendance_LeaveDetails Clone()
          {
                 return this.Clone<EmployeeAttendance_LeaveDetails>();
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


public System.Int32 AttendanceID
{
    get
    {
        return (System.Int32) this.GetField("AttendanceID").fieldValue; 
    }

    set
    {
          this.SetFieldValue("AttendanceID", value);
    }
}


public System.Int32 LeaveID
{
    get
    {
        return (System.Int32) this.GetField("LeaveID").fieldValue; 
    }

    set
    {
          this.SetFieldValue("LeaveID", value);
    }
}


public System.Double NoOfLeaveCount
{
    get
    {
        return (System.Double)this.GetField("NoOfLeaveCount").fieldValue; 
    }

    set
    {
          this.SetFieldValue("NoOfLeaveCount", value);
    }
}

}
}
