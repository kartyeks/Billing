using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Employee_Education_Details : TableMetadata
		{

                   public enum Employee_Education_DetailsFields
                   {
                      ID,
                      EmployeeID,
                      Education,
                      Stream,
                      University,
                      Year,
                      Percentage,
                      CreatedBy,
                      CreatedDate,
                      ModifiedBy,
                      ModifiedDate
                  }


			    private DatabaseField[] _fields;

		    	public Employee_Education_Details()
			    {
					    _fields = new DatabaseField[11];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"EmployeeID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.String,"Education",false,false,null);
                    _fields[3] = new DatabaseField(DbType.String,"Stream",false,false,null);
                    _fields[4] = new DatabaseField(DbType.String,"University",false,false,null);
                    _fields[5] = new DatabaseField(DbType.Int32,"Year",false,false,null);
                    _fields[6] = new DatabaseField(DbType.Double,"Percentage",false,false,null);
                    _fields[7] = new DatabaseField(DbType.Int32,"CreatedBy",false,false,null);
                    _fields[8] = new DatabaseField(DbType.DateTime,"CreatedDate",false,false,null);
                    _fields[9] = new DatabaseField(DbType.Int32,"ModifiedBy",false,false,null);
                    _fields[10] = new DatabaseField(DbType.DateTime,"ModifiedDate",false,false,null);
 
                        this.currentTableName = "Employee_Education_Details";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Employee_Education_Details Clone()
          {
                 return this.Clone<Employee_Education_Details>();
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


public System.String Education
{
    get
    {
         object result = this.GetField("Education").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Education", value);
    }
}


public System.String Stream
{
    get
    {
         object result = this.GetField("Stream").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Stream", value);
    }
}


public System.String University
{
    get
    {
         object result = this.GetField("University").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("University", value);
    }
}


public System.Int32 Year
{
    get
    {
        return (System.Int32) this.GetField("Year").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Year", value);
    }
}


public System.Double Percentage
{
    get
    {
        return (System.Double) this.GetField("Percentage").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Percentage", value);
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
