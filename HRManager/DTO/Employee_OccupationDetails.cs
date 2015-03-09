using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Employee_OccupationDetails : TableMetadata
		{

                   public enum Employee_OccupationDetailsFields
                   {
                      ID,
                      EmployeeID,
                       CountryID,
                      LocationID,
                      JoiningDate,
                      ExitDate,
                      TypeOfExitID,
                      LeavesCount,
                      TeamID,
                      DesignationID,
                       EmailID,
                      IsActive,
                      ActivatedBy,
                      ActivatedDate,
                      FinancialMonth,
                      FinancialYear,
                      ProjectId
                     
                  }


			    private DatabaseField[] _fields;

		    	public Employee_OccupationDetails()
			    {
					    _fields = new DatabaseField[17];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"EmployeeID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.Int32, "CountryID", false, false, null);
                    _fields[3] = new DatabaseField(DbType.Int32,"LocationID",false,false,null);
                    _fields[4] = new DatabaseField(DbType.DateTime,"JoiningDate",false,false,null);
                    _fields[5] = new DatabaseField(DbType.DateTime,"ExitDate",false,false,null);
                    _fields[6] = new DatabaseField(DbType.Int32,"TypeOfExitID",false,false,null);
                    _fields[7] = new DatabaseField(DbType.Double,"LeavesCount",false,false,null);
                    _fields[8] = new DatabaseField(DbType.Int32,"TeamID",false,false,null);
                    _fields[9] = new DatabaseField(DbType.Int32,"DesignationID",false,false,null);
                    _fields[10] = new DatabaseField(DbType.String, "EmailID", false, false, null);
                    _fields[11] = new DatabaseField(DbType.Boolean,"IsActive",false,false,null);
                    _fields[12] = new DatabaseField(DbType.Int32, "ActivatedBy", false, false, null);
                    _fields[13] = new DatabaseField(DbType.DateTime, "ActivatedDate", false, false, null);
                    _fields[14] = new DatabaseField(DbType.Int32, "FinancialMonth", false, false, null);
                    _fields[15] = new DatabaseField(DbType.Int32, "FinancialYear", false, false, null);
                    _fields[16] = new DatabaseField(DbType.Int32, "ProjectId", false, false, null);
 
                        this.currentTableName = "Employee_OccupationDetails";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Employee_OccupationDetails Clone()
          {
                 return this.Clone<Employee_OccupationDetails>();
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


public System.DateTime JoiningDate
{
    get
    {
        return (System.DateTime) this.GetField("JoiningDate").fieldValue; 
    }

    set
    {
          this.SetFieldValue("JoiningDate", value);
    }
}


public System.DateTime ExitDate
{
    get
    {
         object result = this.GetField("ExitDate").fieldValue; 
 return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime) result;
    }

    set
    {
          this.SetFieldValue("ExitDate", value);
    }
}


public System.Int32 TypeOfExitID
{
    get
    {
         object result = this.GetField("TypeOfExitID").fieldValue; 
 return (result == null || result == DBNull.Value) ? Int32.MinValue : (System.Int32) result;
    }

    set
    {
          this.SetFieldValue("TypeOfExitID", value);
    }
}


public System.Double LeavesCount
{
    get
    {
         object result = this.GetField("LeavesCount").fieldValue; 
 return (result == null || result == DBNull.Value) ? Double.MinValue : (System.Double) result;
    }

    set
    {
          this.SetFieldValue("LeavesCount", value);
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


public System.Int32 DesignationID
{
    get
    {
        return (System.Int32) this.GetField("DesignationID").fieldValue; 
    }

    set
    {
          this.SetFieldValue("DesignationID", value);
    }
}
public System.String EmailID
{
    get
    {
        object result = this.GetField("EmailID").fieldValue;
        return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
        this.SetFieldValue("EmailID", value);
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


public System.Int32 ActivatedBy
{
    get
    {
        return (System.Int32)this.GetField("ActivatedBy").fieldValue; 
    }

    set
    {
        this.SetFieldValue("ActivatedBy", value);
    }
}


public System.DateTime ActivatedDate
{
    get
    {
        return (System.DateTime)this.GetField("ActivatedDate").fieldValue; 
    }

    set
    {
        this.SetFieldValue("ActivatedDate", value);
    }
}

public System.Int32 CountryID
{
    get
    {
        return (System.Int32)this.GetField("CountryID").fieldValue;
    }

    set
    {
        this.SetFieldValue("CountryID", value);
    }
}


public System.Int32 FinancialMonth
{
    get
    {
        return (System.Int32)this.GetField("FinancialMonth").fieldValue;
    }

    set
    {
        this.SetFieldValue("FinancialMonth", value);
    }
}
public System.Int32 FinancialYear
{
    get
    {
        return (System.Int32)this.GetField("FinancialYear").fieldValue;
    }

    set
    {
        this.SetFieldValue("FinancialYear", value);
    }
}

public System.Int32 ProjectId
{
    get
    {
        return (System.Int32)this.GetField("ProjectId").fieldValue;
    }

    set
    {
        this.SetFieldValue("ProjectId", value);
    }
}


}
}
