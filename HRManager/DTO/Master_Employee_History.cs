using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Master_Employee_History : TableMetadata
		{

                   public enum Master_Employee_HistoryFields
                   {
                      ID,
                      EmpID,
                      EmpCode,
                      EmployeeTypeID,
                      IsActive,
                      ActivatedBy,
                      ActivatedDate
                  }


			    private DatabaseField[] _fields;

		    	public Master_Employee_History()
			    {
					    _fields = new DatabaseField[7];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"EmpID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.String,"EmpCode",false,false,null);
                    _fields[3] = new DatabaseField(DbType.Int32,"EmployeeTypeID",false,false,null);
                    _fields[4] = new DatabaseField(DbType.Boolean,"IsActive",false,false,null);
                    _fields[5] = new DatabaseField(DbType.Int32,"ActivatedBy",false,false,null);
                    _fields[6] = new DatabaseField(DbType.DateTime,"ActivatedDate",false,false,null);
 
                        this.currentTableName = "Master_Employee_History";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Master_Employee_History Clone()
          {
                 return this.Clone<Master_Employee_History>();
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


public System.Int32 EmpID
{
    get
    {
        return (System.Int32) this.GetField("EmpID").fieldValue; 
    }

    set
    {
          this.SetFieldValue("EmpID", value);
    }
}


public System.String EmpCode
{
    get
    {
         object result = this.GetField("EmpCode").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("EmpCode", value);
    }
}


public System.Int32 EmployeeTypeID
{
    get
    {
        return (System.Int32) this.GetField("EmployeeTypeID").fieldValue; 
    }

    set
    {
          this.SetFieldValue("EmployeeTypeID", value);
    }
}


public System.Boolean IsActive
{
    get
    {
        return (System.Boolean) this.GetField("IsActive").fieldValue; 
    }

    set
    {
          this.SetFieldValue("IsActive", value);
    }
}


public System.Int32 ActivatedBy
{
    get
    {
        return (System.Int32) this.GetField("ActivatedBy").fieldValue; 
    }

    set
    {
          this.SetFieldValue("ActivatedBy", value);
    }
}


public System.DateTime ActivatedDate
{
    get
    {
        return (System.DateTime) this.GetField("ActivatedDate").fieldValue; 
    }

    set
    {
          this.SetFieldValue("ActivatedDate", value);
    }
}

}
}
