using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Manage_Assets : TableMetadata
		{

                   public enum Manage_AssetsFields
                   {
                      ID,
                      UniqueNumber,
                      AssetName,
                      AssetCategoryID,
                      AssetSubCategoryID,
                      ManufacturerID,
                      ManufacturerDate,
                      WarrantyDate,
                      AssetCost,
                      VendorDetails,
                      BarCode,
                      IsActive,
                      CreatedBy,
                      CreatedDate,
                      ModifiedBy,
                      ModifiedDate
                  }


			    private DatabaseField[] _fields;

		    	public Manage_Assets()
			    {
					    _fields = new DatabaseField[16];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.String, "UniqueNumber", false, false, null);
                    _fields[2] = new DatabaseField(DbType.String,"AssetName",false,false,null);
                    _fields[3] = new DatabaseField(DbType.Int32,"AssetCategoryID",false,false,null);
                    _fields[4] = new DatabaseField(DbType.Int32,"AssetSubCategoryID",false,false,null);
                    _fields[5] = new DatabaseField(DbType.Int32,"ManufacturerID",false,false,null);
                    _fields[6] = new DatabaseField(DbType.DateTime,"ManufacturerDate",false,false,null);
                    _fields[7] = new DatabaseField(DbType.DateTime,"WarrantyDate",false,false,null);
                    _fields[8] = new DatabaseField(DbType.String,"AssetCost",false,false,null);
                    _fields[9] = new DatabaseField(DbType.String,"VendorDetails",false,false,null);
                    _fields[10] = new DatabaseField(DbType.Binary, "BarCode", false, false, null);
                    _fields[11] = new DatabaseField(DbType.Boolean,"IsActive",false,false,null);
                    _fields[12] = new DatabaseField(DbType.Int32,"CreatedBy",false,false,null);
                    _fields[13] = new DatabaseField(DbType.DateTime,"CreatedDate",false,false,null);
                    _fields[14] = new DatabaseField(DbType.Int32,"ModifiedBy",false,false,null);
                    _fields[15] = new DatabaseField(DbType.DateTime,"ModifiedDate",false,false,null);
 
                        this.currentTableName = "Manage_Assets";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Manage_Assets Clone()
          {
                 return this.Clone<Manage_Assets>();
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
public System.Byte[] BarCode
{
    get
    {
        object result = (this.GetField("BarCode")).fieldValue;
        if (result == null || string.Concat(result) == "0")
        {
            return new System.Byte[0];
        }

        return (System.Byte[])result;
    }

    set
    {
        this.SetFieldValue("BarCode", value);
    }

}

public System.String UniqueNumber
{
    get
    {
        object result = this.GetField("UniqueNumber").fieldValue;
        return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
        this.SetFieldValue("UniqueNumber", value);
    }
}

public System.String AssetName
{
    get
    {
         object result = this.GetField("AssetName").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("AssetName", value);
    }
}


public System.Int32 AssetCategoryID
{
    get
    {
        return (System.Int32) this.GetField("AssetCategoryID").fieldValue; 
    }

    set
    {
          this.SetFieldValue("AssetCategoryID", value);
    }
}


public System.Int32 AssetSubCategoryID
{
    get
    {
        return (System.Int32) this.GetField("AssetSubCategoryID").fieldValue; 
    }

    set
    {
          this.SetFieldValue("AssetSubCategoryID", value);
    }
}


public System.Int32 ManufacturerID
{
    get
    {
        return (System.Int32) this.GetField("ManufacturerID").fieldValue; 
    }

    set
    {
          this.SetFieldValue("ManufacturerID", value);
    }
}


public System.DateTime ManufacturerDate
{
    get
    {
        return (System.DateTime) this.GetField("ManufacturerDate").fieldValue; 
    }

    set
    {
          this.SetFieldValue("ManufacturerDate", value);
    }
}


public System.DateTime WarrantyDate
{
    get
    {
        return (System.DateTime) this.GetField("WarrantyDate").fieldValue; 
    }

    set
    {
          this.SetFieldValue("WarrantyDate", value);
    }
}


public System.String AssetCost
{
    get
    {
         object result = this.GetField("AssetCost").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("AssetCost", value);
    }
}


public System.String VendorDetails
{
    get
    {
         object result = this.GetField("VendorDetails").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("VendorDetails", value);
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
