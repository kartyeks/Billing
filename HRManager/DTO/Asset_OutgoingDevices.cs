using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Asset_OutgoingDevices : TableMetadata
		{

                   public enum Asset_OutgoingDevicesFields
                   {
                      ID,
                      AssetID,
                      OutgoingDate,
                      ReturningDate,
                      Reason,
                      CreatedBy,
                      CreatedDate,
                      ModifiedBy,
                      ModifiedDate,
                      IsReturned
                  }


			    private DatabaseField[] _fields;

		    	public Asset_OutgoingDevices()
			    {
					    _fields = new DatabaseField[10];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"AssetID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.DateTime,"OutgoingDate",false,false,null);
                    _fields[3] = new DatabaseField(DbType.DateTime,"ReturningDate",false,false,null);
                    _fields[4] = new DatabaseField(DbType.String,"Reason",false,false,null);
                    _fields[5] = new DatabaseField(DbType.Int32,"CreatedBy",false,false,null);
                    _fields[6] = new DatabaseField(DbType.DateTime,"CreatedDate",false,false,null);
                    _fields[7] = new DatabaseField(DbType.Int32,"ModifiedBy",false,false,null);
                    _fields[8] = new DatabaseField(DbType.DateTime,"ModifiedDate",false,false,null);
                    _fields[9] = new DatabaseField(DbType.Boolean, "IsReturned", false, false, null);
 
                        this.currentTableName = "Asset_OutgoingDevices";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Asset_OutgoingDevices Clone()
          {
                 return this.Clone<Asset_OutgoingDevices>();
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


public System.Int32 AssetID
{
    get
    {
        return (System.Int32) this.GetField("AssetID").fieldValue; 
    }

    set
    {
          this.SetFieldValue("AssetID", value);
    }
}


public System.DateTime OutgoingDate
{
    get
    {
        return (System.DateTime) this.GetField("OutgoingDate").fieldValue; 
    }

    set
    {
          this.SetFieldValue("OutgoingDate", value);
    }
}


public System.DateTime ReturningDate
{
    get
    {
         object result = this.GetField("ReturningDate").fieldValue; 
 return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime) result;
    }

    set
    {
          this.SetFieldValue("ReturningDate", value);
    }
}


public System.String Reason
{
    get
    {
         object result = this.GetField("Reason").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Reason", value);
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

public System.Boolean IsReturned
{
    get
    {
        return (System.Boolean)this.GetField("IsReturned").fieldValue;
    }

    set
    {
        this.SetFieldValue("IsReturned", value);
    }
}
}
}
