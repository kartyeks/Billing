using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Master_EmployeeType : TableMetadata
		{

                   public enum Master_EmployeeTypeFields
                   {
                      ID,
                      Name,
                      MinDurationMonth,
                      CreatedBy,
                      CreatedDate,
                      ModifiedBy,
                      ModifiedDate,
                      IsActive,
                      IsService,
                      IsPermanent
                  }


			    private DatabaseField[] _fields;

		    	public Master_EmployeeType()
			    {
					    _fields = new DatabaseField[10];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.String,"Name",false,false,null);
                    _fields[2] = new DatabaseField(DbType.String, "MinDurationMonth", false, false, null);
                    _fields[3] = new DatabaseField(DbType.Int32,"CreatedBy",false,false,null);
                    _fields[4] = new DatabaseField(DbType.DateTime,"CreatedDate",false,false,null);
                    _fields[5] = new DatabaseField(DbType.Int32,"ModifiedBy",false,false,null);
                    _fields[6] = new DatabaseField(DbType.DateTime,"ModifiedDate",false,false,null);
                    _fields[7] = new DatabaseField(DbType.Boolean,"IsActive",false,false,null);
                    _fields[8] = new DatabaseField(DbType.Boolean, "IsService", false, false, null);
                    _fields[9] = new DatabaseField(DbType.Boolean, "IsPermanent", false, false, null);
 
                        this.currentTableName = "Master_EmployeeType";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Master_EmployeeType Clone()
          {
                 return this.Clone<Master_EmployeeType>();
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


public System.String Name
{
    get
    {
         object result = this.GetField("Name").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Name", value);
    }
}


public System.String MinDurationMonth
{
    get
    {
        object result = this.GetField("MinDurationMonth").fieldValue;
        return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
        this.SetFieldValue("MinDurationMonth", value);
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
public System.Boolean IsService
{
    get
    {
        return (System.Boolean)this.GetField("IsService").fieldValue;
    }

    set
    {
        this.SetFieldValue("IsService", value);
    }
}
public System.Boolean IsPermanent
{
    get
    {
        return (System.Boolean)this.GetField("IsPermanent").fieldValue;
    }

    set
    {
        this.SetFieldValue("IsPermanent", value);
    }
}

}
}
