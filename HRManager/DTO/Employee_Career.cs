using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Employee_Career : TableMetadata
		{

                   public enum Employee_CareerFields
                   {
                      ID,
                      EmployeeID,
                      CompanyName,
                      StartDate,
                      EndDate,
                      IsFresher,
                      CreatedBy,
                      CreatedDate,
                      ModifiedBy,
                      ModifiedDate
                  }


			    private DatabaseField[] _fields;

		    	public Employee_Career()
			    {
					    _fields = new DatabaseField[10];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"EmployeeID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.String,"CompanyName",false,false,null);
                    _fields[3] = new DatabaseField(DbType.DateTime,"StartDate",false,false,null);
                    _fields[4] = new DatabaseField(DbType.DateTime,"EndDate",false,false,null);
                    _fields[5] = new DatabaseField(DbType.Boolean,"IsFresher",false,false,null);
                    _fields[6] = new DatabaseField(DbType.Int32,"CreatedBy",false,false,null);
                    _fields[7] = new DatabaseField(DbType.DateTime,"CreatedDate",false,false,null);
                    _fields[8] = new DatabaseField(DbType.Int32,"ModifiedBy",false,false,null);
                    _fields[9] = new DatabaseField(DbType.DateTime,"ModifiedDate",false,false,null);
 
                        this.currentTableName = "Employee_Career";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Employee_Career Clone()
          {
                 return this.Clone<Employee_Career>();
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


public System.String CompanyName
{
    get
    {
         object result = this.GetField("CompanyName").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("CompanyName", value);
    }
}


public System.DateTime StartDate
{
    get
    {
        return (System.DateTime) this.GetField("StartDate").fieldValue; 
    }

    set
    {
          this.SetFieldValue("StartDate", value);
    }
}


public System.DateTime EndDate
{
    get
    {
        return (System.DateTime) this.GetField("EndDate").fieldValue; 
    }

    set
    {
          this.SetFieldValue("EndDate", value);
    }
}


public System.Boolean IsFresher
{
    get
    {
        return (System.Boolean) this.GetField("IsFresher").fieldValue; 
    }

    set
    {
          this.SetFieldValue("IsFresher", value);
    }
}


public System.Int32 CreatedBy
{
    get
    {
         object result = this.GetField("CreatedBy").fieldValue; 
 return (result == null || result == DBNull.Value) ? Int32.MinValue : (System.Int32) result;
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
         object result = this.GetField("CreatedDate").fieldValue; 
 return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime) result;
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
