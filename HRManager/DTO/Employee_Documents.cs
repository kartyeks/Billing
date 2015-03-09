using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Employee_Documents : TableMetadata
		{

                   public enum Employee_DocumentsFields
                   {
                      ID,
                      EmployeeID,
                      DocumentTitle,
                      DocumentName,
                      CreatedBy,
                      CreatedDate,
                      ModifiedBy,
                      ModifiedDate
                  }


			    private DatabaseField[] _fields;

		    	public Employee_Documents()
			    {
					    _fields = new DatabaseField[8];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"EmployeeID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.String,"DocumentTitle",false,false,null);
                    _fields[3] = new DatabaseField(DbType.String,"DocumentName",false,false,null);
                    _fields[4] = new DatabaseField(DbType.Int32,"CreatedBy",false,false,null);
                    _fields[5] = new DatabaseField(DbType.DateTime,"CreatedDate",false,false,null);
                    _fields[6] = new DatabaseField(DbType.Int32,"ModifiedBy",false,false,null);
                    _fields[7] = new DatabaseField(DbType.DateTime,"ModifiedDate",false,false,null);
 
                        this.currentTableName = "Employee_Documents";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Employee_Documents Clone()
          {
                 return this.Clone<Employee_Documents>();
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


public System.String DocumentTitle
{
    get
    {
         object result = this.GetField("DocumentTitle").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("DocumentTitle", value);
    }
}


public System.String DocumentName
{
    get
    {
         object result = this.GetField("DocumentName").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("DocumentName", value);
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
        return (System.Int32) this.GetField("ModifiedBy").fieldValue; 
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
        return (System.DateTime) this.GetField("ModifiedDate").fieldValue; 
    }

    set
    {
          this.SetFieldValue("ModifiedDate", value);
    }
}

}
}
