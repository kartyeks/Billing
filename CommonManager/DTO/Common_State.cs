using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
namespace CommonManager.DTO
{
      [Serializable()]
		public class Common_State : TableMetadata
		{

                   public enum Common_StateFields
                   {
                      ID,
                      CountryID,
                      RegionID,
                      StateName,
                      IsActive,
                      CreatedBy,
                      CreatedDate,
                      ModifiedBy,
                      ModifiedDate
                  }


			    private DatabaseField[] _fields;

		    	public Common_State()
			    {
					    _fields = new DatabaseField[9];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"CountryID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.Int32,"RegionID",false,false,null);
                    _fields[3] = new DatabaseField(DbType.String,"StateName",false,false,null);
                    _fields[4] = new DatabaseField(DbType.Boolean,"IsActive",false,false,null);
                    _fields[5] = new DatabaseField(DbType.Int32,"CreatedBy",false,false,null);
                    _fields[6] = new DatabaseField(DbType.DateTime,"CreatedDate",false,false,null);
                    _fields[7] = new DatabaseField(DbType.Int32,"ModifiedBy",false,false,null);
                    _fields[8] = new DatabaseField(DbType.DateTime,"ModifiedDate",false,false,null);
 
                        this.currentTableName = "Common_State";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Common_State Clone()
          {
                 return this.Clone<Common_State>();
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


public System.Int32 CountryID
{
    get
    {
          return (System.Int32 ) (this.GetField("CountryID")).fieldValue;
    }

    set
    {
          this.SetFieldValue("CountryID", value);
    }
}


public System.Int32 RegionID
{
    get
    {
          return (System.Int32 ) (this.GetField("RegionID")).fieldValue;
    }

    set
    {
          this.SetFieldValue("RegionID", value);
    }
}


public System.String StateName
{
    get
    {
          object result = this.GetField("StateName").fieldValue;
          return (result != null) ? result.ToString() : null;
    }

    set
    {
          this.SetFieldValue("StateName", value);
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

}
}
