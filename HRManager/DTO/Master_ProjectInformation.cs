using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Master_ProjectInformation : TableMetadata
		{

                   public enum Master_ProjectInformationFields
                   {
                      ID,
                      CompanyID,
                      ProjectGroup,
                      ProjectType,
                      ProjectCode,
                      Address,
                      checkcontractown,
                      ProjectName,
                      IsActive,
                      CreatedBy,
                      CreatedDate,
                      ModifiedBy,
                      ModifiedDate
                  }


			    private DatabaseField[] _fields;

		    	public Master_ProjectInformation()
			    {
					    _fields = new DatabaseField[13];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"CompanyID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.String,"ProjectGroup",false,false,null);
                    _fields[3] = new DatabaseField(DbType.String,"ProjectType",false,false,null);
                    _fields[4] = new DatabaseField(DbType.String,"ProjectCode",false,false,null);
                    _fields[5] = new DatabaseField(DbType.String,"Address",false,false,null);
                    _fields[6] = new DatabaseField(DbType.String, "checkcontractown", false, false, null);
                    _fields[7] = new DatabaseField(DbType.String,"ProjectName",false,false,null);
                    _fields[8] = new DatabaseField(DbType.Boolean,"IsActive",false,false,null);
                    _fields[9] = new DatabaseField(DbType.Int32,"CreatedBy",false,false,null);
                    _fields[10] = new DatabaseField(DbType.DateTime,"CreatedDate",false,false,null);
                    _fields[11] = new DatabaseField(DbType.Int32,"ModifiedBy",false,false,null);
                    _fields[12] = new DatabaseField(DbType.DateTime,"ModifiedDate",false,false,null);
 
                        this.currentTableName = "Master_ProjectInformation";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Master_ProjectInformation Clone()
          {
                 return this.Clone<Master_ProjectInformation>();
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


public System.Int32 CompanyID
{
    get
    {
         object result = this.GetField("CompanyID").fieldValue; 
 return (result == null || result == DBNull.Value) ? Int32.MinValue : (System.Int32) result;
    }

    set
    {
          this.SetFieldValue("CompanyID", value);
    }
}


public System.String ProjectGroup
{
    get
    {
         object result = this.GetField("ProjectGroup").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("ProjectGroup", value);
    }
}


public System.String ProjectType
{
    get
    {
         object result = this.GetField("ProjectType").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("ProjectType", value);
    }
}


public System.String ProjectCode
{
    get
    {
         object result = this.GetField("ProjectCode").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("ProjectCode", value);
    }
}


public System.String Address
{
    get
    {
         object result = this.GetField("Address").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Address", value);
    }
}


public System.String checkcontractown
{
    get
    {
        object result = this.GetField("checkcontractown").fieldValue;
        return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
        this.SetFieldValue("checkcontractown", value);
    }
}



public System.String ProjectName
{
    get
    {
         object result = this.GetField("ProjectName").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("ProjectName", value);
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
