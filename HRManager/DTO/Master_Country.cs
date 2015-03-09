using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Master_Country : TableMetadata
		{

                   public enum Master_CountryFields
                   {
                      ID,
                      CountryName,
                      IsActive,
                      CreatedBy,
                      CreatedDate,
                      ModifiedBy,
                      ModifiedDate
                  }


			    private DatabaseField[] _fields;

		    	public Master_Country()
			    {
					    _fields = new DatabaseField[8];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.String,"CountryName",false,false,null);
                    _fields[2] = new DatabaseField(DbType.Boolean,"IsActive",false,false,null);
                    _fields[3] = new DatabaseField(DbType.Int32,"CreatedBy",false,false,null);
                    _fields[4] = new DatabaseField(DbType.DateTime,"CreatedDate",false,false,null);
                    _fields[5] = new DatabaseField(DbType.Int32,"ModifiedBy",false,false,null);
                    _fields[6] = new DatabaseField(DbType.DateTime,"ModifiedDate",false,false,null);
                    _fields[7] = new DatabaseField(DbType.String, "CountryCode", false, false, null);
 
                        this.currentTableName = "Master_Country";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Master_Country Clone()
          {
                 return this.Clone<Master_Country>();
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

public System.String CountryCode
{
    get
    {
        object result = this.GetField("CountryCode").fieldValue;
        return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
        this.SetFieldValue("CountryCode", value);
    }
}
public System.String CountryName
{
    get
    {
         object result = this.GetField("CountryName").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("CountryName", value);
    }
}


public System.Boolean IsActive
{
    get
    {
         object result = this.GetField("IsActive").fieldValue; 
 return (result == null || result == DBNull.Value) ? false : (System.Boolean) result;
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
