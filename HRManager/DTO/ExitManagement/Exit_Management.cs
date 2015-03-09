using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Exit_Management : TableMetadata
		{

                   public enum Exit_ManagementFields
                   {
                      ID,
                      EmployeeID,
                      ExitTypeID,
                      ExitDate,
                      DocumentName,
                      IsActive
                  }


			    private DatabaseField[] _fields;

		    	public Exit_Management()
			    {
					    _fields = new DatabaseField[6];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"EmployeeID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.Int32,"ExitTypeID",false,false,null);
                    _fields[3] = new DatabaseField(DbType.DateTime,"ExitDate",false,false,null);
                    _fields[4] = new DatabaseField(DbType.String,"DocumentName",false,false,null);
                    _fields[5] = new DatabaseField(DbType.Boolean,"IsActive",false,false,null);
 
                        this.currentTableName = "Exit_Management";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Exit_Management Clone()
          {
                 return this.Clone<Exit_Management>();
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


public System.Int32 EmployeeID
{
    get
    {
          return (System.Int32 ) (this.GetField("EmployeeID")).fieldValue;
    }

    set
    {
          this.SetFieldValue("EmployeeID", value);
    }
}


public System.Int32 ExitTypeID
{
    get
    {
          return (System.Int32 ) (this.GetField("ExitTypeID")).fieldValue;
    }

    set
    {
          this.SetFieldValue("ExitTypeID", value);
    }
}


public System.DateTime ExitDate
{
    get
    {
          return (System.DateTime ) (this.GetField("ExitDate")).fieldValue;
    }

    set
    {
          this.SetFieldValue("ExitDate", value);
    }
}


public System.String DocumentName
{
    get
    {
          object result = this.GetField("DocumentName").fieldValue;
          return (result != null) ? result.ToString() : null;
    }

    set
    {
          this.SetFieldValue("DocumentName", value);
    }
}


public System.Boolean IsActive
{
    get
    {
          return (System.Boolean ) (this.GetField("IsActive")).fieldValue;
    }

    set
    {
          this.SetFieldValue("IsActive", value);
    }
}

}
}
