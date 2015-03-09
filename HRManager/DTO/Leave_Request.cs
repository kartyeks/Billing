using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Leave_Request : TableMetadata
		{

                   public enum Leave_RequestFields
                   {
                      ID,
                      EmpID,
                      LeaveID,
                      FromDate,
                      ToDate,
                      Reason,
                      AppliedDateTime,
                      DaysCount, 
                      Status,
                      ManagerID,
                      ManagerComments,
                      CreatedBy,
                      CreatedDate,
                      ModifiedBy,
                      ModifiedDate,
                      FromDateHalfDay,
                      ToDateHalfDay
                  }


			    private DatabaseField[] _fields;

		    	public Leave_Request()
			    {
					    _fields = new DatabaseField[17];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"EmpID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.Int32,"LeaveID",false,false,null);
                    _fields[3] = new DatabaseField(DbType.DateTime,"FromDate",false,false,null);
                    _fields[4] = new DatabaseField(DbType.DateTime,"ToDate",false,false,null);
                    _fields[5] = new DatabaseField(DbType.String,"Reason",false,false,null);
                    _fields[6] = new DatabaseField(DbType.DateTime,"AppliedDateTime",false,false,null);
                    _fields[7] = new DatabaseField(DbType.Double, "DaysCount", false, false, null);                   
                    _fields[8] = new DatabaseField(DbType.String,"Status",false,false,null);
                    _fields[9] = new DatabaseField(DbType.Int32,"ManagerID",false,false,null);
                    _fields[10] = new DatabaseField(DbType.String,"ManagerComments",false,false,null);
                    _fields[11] = new DatabaseField(DbType.Int32,"CreatedBy",false,false,null);
                    _fields[12] = new DatabaseField(DbType.DateTime,"CreatedDate",false,false,null);
                    _fields[13] = new DatabaseField(DbType.Int32,"ModifiedBy",false,false,null);
                    _fields[14] = new DatabaseField(DbType.DateTime,"ModifiedDate",false,false,null);
                    _fields[15] = new DatabaseField(DbType.Boolean, "FromDateHalfDay", false, false, null);
                    _fields[16] = new DatabaseField(DbType.Boolean, "ToDateHalfDay", false, false, null);
 
                        this.currentTableName = "Leave_Request";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Leave_Request Clone()
          {
                 return this.Clone<Leave_Request>();
          }

public System.Int32 ID
{
    get
    {
          return (System.Int32 ) (this.GetField("ID")).fieldValue;
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
          return (System.Int32 ) (this.GetField("EmpID")).fieldValue;
    }

    set
    {
          this.SetFieldValue("EmpID", value);
    }
}


public System.Int32 LeaveID
{
    get
    {
          return (System.Int32 ) (this.GetField("LeaveID")).fieldValue;
    }

    set
    {
          this.SetFieldValue("LeaveID", value);
    }
}


public System.DateTime FromDate
{
    get
    {
          return (System.DateTime ) (this.GetField("FromDate")).fieldValue;
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
          return (System.DateTime ) (this.GetField("ToDate")).fieldValue;
    }

    set
    {
          this.SetFieldValue("ToDate", value);
    }
}


public System.String Reason
{
    get
    {
          object result = this.GetField("Reason").fieldValue;
          return (result != null) ? result.ToString() : null;
    }

    set
    {
          this.SetFieldValue("Reason", value);
    }
}


public System.DateTime AppliedDateTime
{
    get
    {
          return (System.DateTime ) (this.GetField("AppliedDateTime")).fieldValue;
    }

    set
    {
          this.SetFieldValue("AppliedDateTime", value);
    }
}
public System.Double DaysCount
{
    get
    {
        object result = this.GetField("DaysCount").fieldValue;
        return (result == null || result == DBNull.Value) ? Double.MinValue : (System.Double)result;
    }

    set
    {
        this.SetFieldValue("DaysCount", value);
    }
}

public System.String Status
{
    get
    {
          object result = this.GetField("Status").fieldValue;
          return (result != null) ? result.ToString() : null;
    }

    set
    {
          this.SetFieldValue("Status", value);
    }
}


public System.Int32 ManagerID
{
    get
    {
          return (System.Int32 ) (this.GetField("ManagerID")).fieldValue;
    }

    set
    {
          this.SetFieldValue("ManagerID", value);
    }
}


public System.String ManagerComments
{
    get
    {
          object result = this.GetField("ManagerComments").fieldValue;
          return (result != null) ? result.ToString() : null;
    }

    set
    {
          this.SetFieldValue("ManagerComments", value);
    }
}


public System.Int32 CreatedBy
{
    get
    {
          return (System.Int32 ) (this.GetField("CreatedBy")).fieldValue;
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
          return (System.DateTime ) (this.GetField("CreatedDate")).fieldValue;
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
          return (System.Int32 ) (this.GetField("ModifiedBy")).fieldValue;
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
          return (System.DateTime ) (this.GetField("ModifiedDate")).fieldValue;
    }

    set
    {
          this.SetFieldValue("ModifiedDate", value);
    }
}
public System.Boolean FromDateHalfDay
{
    get
    {
        return (System.Boolean)this.GetField("FromDateHalfDay").fieldValue;
    }

    set
    {
        this.SetFieldValue("FromDateHalfDay", value);
    }
}
public System.Boolean ToDateHalfDay
{
    get
    {
        return (System.Boolean)this.GetField("ToDateHalfDay").fieldValue;
    }

    set
    {
        this.SetFieldValue("ToDateHalfDay", value);
    }
}

}
}
