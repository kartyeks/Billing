using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Master_Salary_Deductions : TableMetadata
		{

                   public enum Master_Salary_DeductionsFields
                   {
                      ID,
                      Name,
                      DeductionPeriod,
                      IsEmployeeLevel,
                      Limit,
                      IsPercentage,
                      IsActive,
                      IsTaxExempted,
                      CreatedBy,
                      CreatedDate,
                      ModifiedBy,
                      ModifiedDate,
                      DeductionCode,
                      DisplayOrder
                  }


			    private DatabaseField[] _fields;

		    	public Master_Salary_Deductions()
			    {
					    _fields = new DatabaseField[14];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.String,"Name",false,false,null);
                    _fields[2] = new DatabaseField(DbType.String,"DeductionPeriod",false,false,null);
                    _fields[3] = new DatabaseField(DbType.Boolean,"IsEmployeeLevel",false,false,null);
                    _fields[4] = new DatabaseField(DbType.Double,"Limit",false,false,null);
                    _fields[5] = new DatabaseField(DbType.Boolean,"IsPercentage",false,false,null);
                    _fields[6] = new DatabaseField(DbType.Boolean,"IsActive",false,false,null);
                    _fields[7] = new DatabaseField(DbType.Boolean,"IsTaxExempted",false,false,null);
                    _fields[8] = new DatabaseField(DbType.Int32,"CreatedBy",false,false,null);
                    _fields[9] = new DatabaseField(DbType.DateTime,"CreatedDate",false,false,null);
                    _fields[10] = new DatabaseField(DbType.Int32,"ModifiedBy",false,false,null);
                    _fields[11] = new DatabaseField(DbType.DateTime,"ModifiedDate",false,false,null);
                    _fields[12] = new DatabaseField(DbType.String,"DeductionCode",false,false,null);
                    _fields[13] = new DatabaseField(DbType.Int32,"DisplayOrder",false,false,null);
 
                        this.currentTableName = "Master_Salary_Deductions";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Master_Salary_Deductions Clone()
          {
                 return this.Clone<Master_Salary_Deductions>();
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


public System.String DeductionPeriod
{
    get
    {
         object result = this.GetField("DeductionPeriod").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("DeductionPeriod", value);
    }
}


public System.Boolean IsEmployeeLevel
{
    get
    {
        return (System.Boolean) this.GetField("IsEmployeeLevel").fieldValue; 
    }

    set
    {
          this.SetFieldValue("IsEmployeeLevel", value);
    }
}


public System.Double Limit
{
    get
    {
         object result = this.GetField("Limit").fieldValue; 
 return (result == null || result == DBNull.Value) ? Double.MinValue : (System.Double) result;
    }

    set
    {
          this.SetFieldValue("Limit", value);
    }
}


public System.Boolean IsPercentage
{
    get
    {
         object result = this.GetField("IsPercentage").fieldValue; 
 return (result == null || result == DBNull.Value) ? false : (System.Boolean) result;
    }

    set
    {
          this.SetFieldValue("IsPercentage", value);
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


public System.Boolean IsTaxExempted
{
    get
    {
         object result = this.GetField("IsTaxExempted").fieldValue; 
 return (result == null || result == DBNull.Value) ? false : (System.Boolean) result;
    }

    set
    {
          this.SetFieldValue("IsTaxExempted", value);
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


public System.String DeductionCode
{
    get
    {
         object result = this.GetField("DeductionCode").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("DeductionCode", value);
    }
}


public System.Int32 DisplayOrder
{
    get
    {
         object result = this.GetField("DisplayOrder").fieldValue; 
 return (result == null || result == DBNull.Value) ? Int32.MinValue : (System.Int32) result;
    }

    set
    {
          this.SetFieldValue("DisplayOrder", value);
    }
}

}
}
