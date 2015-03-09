using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{
      [Serializable()]
		public class Leave_Status_History : TableMetadata
		{

                   public enum Leave_Status_HistoryFields
                   {
                      ID,
                      LeaveRequestID,
                      ProcessedBy,
                      ProcessDate,
                      Status,
                      Comments
                  }


			    private DatabaseField[] _fields;

		    	public Leave_Status_History()
			    {
					    _fields = new DatabaseField[6];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"LeaveRequestID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.Int32,"ProcessedBy",false,false,null);
                    _fields[3] = new DatabaseField(DbType.DateTime,"ProcessDate",false,false,null);
                    _fields[4] = new DatabaseField(DbType.String,"Status",false,false,null);
                    _fields[5] = new DatabaseField(DbType.String,"Comments",false,false,null);
 
                        this.currentTableName = "Leave_Status_History";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Leave_Status_History Clone()
          {
                 return this.Clone<Leave_Status_History>();
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


public System.Int32 LeaveRequestID
{
    get
    {
          return (System.Int32 ) (this.GetField("LeaveRequestID")).fieldValue;
    }

    set
    {
          this.SetFieldValue("LeaveRequestID", value);
    }
}


public System.Int32 ProcessedBy
{
    get
    {
          return (System.Int32 ) (this.GetField("ProcessedBy")).fieldValue;
    }

    set
    {
          this.SetFieldValue("ProcessedBy", value);
    }
}


public System.DateTime ProcessDate
{
    get
    {
          return (System.DateTime ) (this.GetField("ProcessDate")).fieldValue;
    }

    set
    {
          this.SetFieldValue("ProcessDate", value);
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


public System.String Comments
{
    get
    {
          object result = this.GetField("Comments").fieldValue;
          return (result != null) ? result.ToString() : null;
    }

    set
    {
          this.SetFieldValue("Comments", value);
    }
}

}
}
