using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Assign_Assetes : TableMetadata
		{

                   public enum Assign_AssetesFields
                   {
                      ID,
                      AssetID,
                      IsTeamAssigned,
                      TeamID,
                      EmployeeID,
                      IssuedDate,
                      Reason,
                      IsReturned,
                      ReturnedDate,
                      Comments,
                      LocationOfAsset,
                      CreatedBy,
                      CreatedDate,
                      ModifiedBy,
                      ModifiedDate
                  }


			    private DatabaseField[] _fields;

		    	public Assign_Assetes()
			    {
					    _fields = new DatabaseField[15];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"AssetID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.Boolean,"IsTeamAssigned",false,false,null);
                    _fields[3] = new DatabaseField(DbType.Int32,"TeamID",false,false,null);
                    _fields[4] = new DatabaseField(DbType.Int32,"EmployeeID",false,false,null);
                    _fields[5] = new DatabaseField(DbType.DateTime,"IssuedDate",false,false,null);
                    _fields[6] = new DatabaseField(DbType.String,"Reason",false,false,null);
                    _fields[7] = new DatabaseField(DbType.Boolean,"IsReturned",false,false,null);
                    _fields[8] = new DatabaseField(DbType.DateTime,"ReturnedDate",false,false,null);
                    _fields[9] = new DatabaseField(DbType.String,"Comments",false,false,null);
                    _fields[10] = new DatabaseField(DbType.String,"LocationOfAsset",false,false,null);
                    _fields[11] = new DatabaseField(DbType.Int32,"CreatedBy",false,false,null);
                    _fields[12] = new DatabaseField(DbType.DateTime,"CreatedDate",false,false,null);
                    _fields[13] = new DatabaseField(DbType.Int32,"ModifiedBy",false,false,null);
                    _fields[14] = new DatabaseField(DbType.DateTime,"ModifiedDate",false,false,null);
 
                        this.currentTableName = "Assign_Assetes";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Assign_Assetes Clone()
          {
                 return this.Clone<Assign_Assetes>();
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


public System.Boolean IsTeamAssigned
{
    get
    {
        return (System.Boolean) this.GetField("IsTeamAssigned").fieldValue; 
    }

    set
    {
          this.SetFieldValue("IsTeamAssigned", value);
    }
}


public System.Int32 TeamID
{
    get
    {
        return (System.Int32) this.GetField("TeamID").fieldValue; 
    }

    set
    {
          this.SetFieldValue("TeamID", value);
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


public System.DateTime IssuedDate
{
    get
    {
        return (System.DateTime) this.GetField("IssuedDate").fieldValue; 
    }

    set
    {
          this.SetFieldValue("IssuedDate", value);
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


public System.Boolean IsReturned
{
    get
    {
        return (System.Boolean) this.GetField("IsReturned").fieldValue; 
    }

    set
    {
          this.SetFieldValue("IsReturned", value);
    }
}


public System.DateTime ReturnedDate
{
    get
    {
         object result = this.GetField("ReturnedDate").fieldValue; 
 return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime) result;
    }

    set
    {
          this.SetFieldValue("ReturnedDate", value);
    }
}


public System.String Comments
{
    get
    {
         object result = this.GetField("Comments").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Comments", value);
    }
}


public System.String LocationOfAsset
{
    get
    {
         object result = this.GetField("LocationOfAsset").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("LocationOfAsset", value);
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
