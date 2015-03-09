using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{
      [Serializable()]
		public class Employee_Uploaded_Attandance : TableMetadata
		{

                   public enum Employee_Uploaded_AttandanceFields
                   {
                      ID,
                      EmployeeID,
                      LeaveDate,
                      LeaveType
                  }


			    private DatabaseField[] _fields;

		    	public Employee_Uploaded_Attandance()
			    {
					    _fields = new DatabaseField[4];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"EmployeeID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.DateTime,"LeaveDate",false,false,null);
                    _fields[3] = new DatabaseField(DbType.String,"LeaveType",false,false,null);
 
                        this.currentTableName = "Employee_Uploaded_Attandance";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Employee_Uploaded_Attandance Clone()
          {
                 return this.Clone<Employee_Uploaded_Attandance>();
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
         object result = this.GetField("EmployeeID").fieldValue; 
 return (result == null || result == DBNull.Value) ? Int32.MinValue : (System.Int32) result;
    }

    set
    {
          this.SetFieldValue("EmployeeID", value);
    }
}


public System.DateTime LeaveDate
{
    get
    {
         object result = this.GetField("LeaveDate").fieldValue; 
 return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime) result;
    }

    set
    {
          this.SetFieldValue("LeaveDate", value);
    }
}


public System.String LeaveType
{
    get
    {
         object result = this.GetField("LeaveType").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("LeaveType", value);
    }
}

}
}
