using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Master_Holidays : TableMetadata
		{

                   public enum Master_HolidaysFields
                   {
                      ID,
                      LocationID,
                      HolidayName,
                      HolidayDate,
                      Description,
                      Status,
                      RequestingTo,
                      IsActive,
                      CreatedBy,
                      CreatedDate,
                      ModifiedBy,
                      ModifiedDate
                  }


			    private DatabaseField[] _fields;

		    	public Master_Holidays()
			    {
					    _fields = new DatabaseField[12];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"LocationID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.String,"HolidayName",false,false,null);
                    _fields[3] = new DatabaseField(DbType.DateTime,"HolidayDate",false,false,null);
                    _fields[4] = new DatabaseField(DbType.String,"Description",false,false,null);
                    _fields[5] = new DatabaseField(DbType.String,"Status",false,false,null);
                    _fields[6] = new DatabaseField(DbType.Int32,"RequestingTo",false,false,null);
                    _fields[7] = new DatabaseField(DbType.Boolean,"IsActive",false,false,null);
                    _fields[8] = new DatabaseField(DbType.Int32,"CreatedBy",false,false,null);
                    _fields[9] = new DatabaseField(DbType.DateTime,"CreatedDate",false,false,null);
                    _fields[10] = new DatabaseField(DbType.Int32,"ModifiedBy",false,false,null);
                    _fields[11] = new DatabaseField(DbType.DateTime,"ModifiedDate",false,false,null);
 
                        this.currentTableName = "Master_Holidays";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Master_Holidays Clone()
          {
                 return this.Clone<Master_Holidays>();
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


public System.Int32 LocationID
{
    get
    {
        return (System.Int32) this.GetField("LocationID").fieldValue; 
    }

    set
    {
          this.SetFieldValue("LocationID", value);
    }
}


public System.String HolidayName
{
    get
    {
         object result = this.GetField("HolidayName").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("HolidayName", value);
    }
}


public System.DateTime HolidayDate
{
    get
    {
        return (System.DateTime) this.GetField("HolidayDate").fieldValue; 
    }

    set
    {
          this.SetFieldValue("HolidayDate", value);
    }
}


public System.String Description
{
    get
    {
         object result = this.GetField("Description").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Description", value);
    }
}


public System.String Status
{
    get
    {
         object result = this.GetField("Status").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Status", value);
    }
}


public System.Int32 RequestingTo
{
    get
    {
         object result = this.GetField("RequestingTo").fieldValue; 
 return (result == null || result == DBNull.Value) ? Int32.MinValue : (System.Int32) result;
    }

    set
    {
          this.SetFieldValue("RequestingTo", value);
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
