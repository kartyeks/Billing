using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Master_Consultant : TableMetadata
		{

                   public enum Master_ConsultantFields
                   {
                      ID,
                      ConsultantName,
                      ContactPerson,
                      TelephoneNo,
                      EmailID,
                      Address,
                      IsActive,
                      CreatedBy,
                      CreatedDate,
                      ModifiedBy,
                      ModifiedDate,
                      DesignationID
                  }


			    private DatabaseField[] _fields;

		    	public Master_Consultant()
			    {
					    _fields = new DatabaseField[12];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.String,"ConsultantName",false,false,null);
                    _fields[2] = new DatabaseField(DbType.String,"ContactPerson",false,false,null);
                    _fields[3] = new DatabaseField(DbType.String,"TelephoneNo",false,false,null);
                    _fields[4] = new DatabaseField(DbType.String,"EmailID",false,false,null);
                    _fields[5] = new DatabaseField(DbType.String,"Address",false,false,null);
                    _fields[6] = new DatabaseField(DbType.Boolean,"IsActive",false,false,null);
                    _fields[7] = new DatabaseField(DbType.Int32,"CreatedBy",false,false,null);
                    _fields[8] = new DatabaseField(DbType.DateTime,"CreatedDate",false,false,null);
                    _fields[9] = new DatabaseField(DbType.Int32,"ModifiedBy",false,false,null);
                    _fields[10] = new DatabaseField(DbType.DateTime,"ModifiedDate",false,false,null);
                    _fields[11] = new DatabaseField(DbType.Int32, "DesignationID", false, false, null);
 
                        this.currentTableName = "Master_Consultant";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Master_Consultant Clone()
          {
                 return this.Clone<Master_Consultant>();
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
public System.Int32 DesignationID
{
    get
    {
        return (System.Int32)this.GetField("DesignationID").fieldValue;
    }

    set
    {
        this.SetFieldValue("DesignationID", value);
    }
}

public System.String ConsultantName
{
    get
    {
          object result = this.GetField("ConsultantName").fieldValue;
          return (result != null) ? result.ToString() : null;
    }

    set
    {
          this.SetFieldValue("ConsultantName", value);
    }
}


public System.String ContactPerson
{
    get
    {
          object result = this.GetField("ContactPerson").fieldValue;
          return (result != null) ? result.ToString() : null;
    }

    set
    {
          this.SetFieldValue("ContactPerson", value);
    }
}


public System.String TelephoneNo
{
    get
    {
          object result = this.GetField("TelephoneNo").fieldValue;
          return (result != null) ? result.ToString() : null;
    }

    set
    {
          this.SetFieldValue("TelephoneNo", value);
    }
}


public System.String EmailID
{
    get
    {
          object result = this.GetField("EmailID").fieldValue;
          return (result != null) ? result.ToString() : null;
    }

    set
    {
          this.SetFieldValue("EmailID", value);
    }
}


public System.String Address
{
    get
    {
          object result = this.GetField("Address").fieldValue;
          return (result != null) ? result.ToString() : null;
    }

    set
    {
          this.SetFieldValue("Address", value);
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
