using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Master_Salary_Allowance : TableMetadata
		{

                   public enum Master_Salary_AllowanceFields
                   {
                      ID,
                      AllowanceName,
                      AllowancePeriod,
                      IsPercentage,
                      IsActive,
                      IsTaxExempted,
                      AllowanceCode,
                      CreatedBy,
                      CreatedDate,
                      ModifiedBy,
                      ModifiedDate,
                      DisplayOrder,
                      IsOneMonthBasic,
                      Value
                  }


			    private DatabaseField[] _fields;

		    	public Master_Salary_Allowance()
			    {
					    _fields = new DatabaseField[14];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.String,"AllowanceName",false,false,null);
                    _fields[2] = new DatabaseField(DbType.String,"AllowancePeriod",false,false,null);
                    _fields[3] = new DatabaseField(DbType.Boolean,"IsPercentage",false,false,null);
                    _fields[4] = new DatabaseField(DbType.Boolean,"IsActive",false,false,null);
                    _fields[5] = new DatabaseField(DbType.Boolean,"IsTaxExempted",false,false,null);
                    _fields[6] = new DatabaseField(DbType.String,"AllowanceCode",false,false,null);
                    _fields[7] = new DatabaseField(DbType.Int32,"CreatedBy",false,false,null);
                    _fields[8] = new DatabaseField(DbType.DateTime,"CreatedDate",false,false,null);
                    _fields[9] = new DatabaseField(DbType.Int32,"ModifiedBy",false,false,null);
                    _fields[10] = new DatabaseField(DbType.DateTime,"ModifiedDate",false,false,null);
                    _fields[11] = new DatabaseField(DbType.Int32,"DisplayOrder",false,false,null);
                    _fields[12] = new DatabaseField(DbType.Boolean,"IsOneMonthBasic",false,false,null);
                    _fields[13] = new DatabaseField(DbType.Double,"Value",false,false,null);
 
                        this.currentTableName = "Master_Salary_Allowance";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Master_Salary_Allowance Clone()
          {
                 return this.Clone<Master_Salary_Allowance>();
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


public System.String AllowanceName
{
    get
    {
         object result = this.GetField("AllowanceName").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("AllowanceName", value);
    }
}


public System.String AllowancePeriod
{
    get
    {
         object result = this.GetField("AllowancePeriod").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("AllowancePeriod", value);
    }
}


public System.Boolean IsPercentage
{
    get
    {
        return (System.Boolean) this.GetField("IsPercentage").fieldValue; 
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
        return (System.Boolean) this.GetField("IsTaxExempted").fieldValue; 
    }

    set
    {
          this.SetFieldValue("IsTaxExempted", value);
    }
}


public System.String AllowanceCode
{
    get
    {
         object result = this.GetField("AllowanceCode").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("AllowanceCode", value);
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


public System.Boolean IsOneMonthBasic
{
    get
    {
        return (System.Boolean) this.GetField("IsOneMonthBasic").fieldValue; 
    }

    set
    {
          this.SetFieldValue("IsOneMonthBasic", value);
    }
}


public System.Double Value
{
    get
    {
        return (System.Double) this.GetField("Value").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Value", value);
    }
}

}
}
