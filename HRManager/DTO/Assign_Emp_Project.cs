using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Assign_Emp_Project : TableMetadata
		{

                   public enum Assign_Emp_ProjectFields
                   {
                      ID,
                      EmpID,
                      ProjectID,
                      IsActive,
                      ActivatedDate,
                      CreatedBy,
                      CreatedDate,
                      ModifiedBy,
                      ModifiedDate
                  }


			    private DatabaseField[] _fields;

                public Assign_Emp_Project()
			    {
					    _fields = new DatabaseField[9];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"EmpID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.Int32, "ProjectID", false, false, null);
                    _fields[3] = new DatabaseField(DbType.Boolean,"IsActive",false,false,null);
                    _fields[4] = new DatabaseField(DbType.DateTime,"ActivatedDate",false,false,null);
                    _fields[5] = new DatabaseField(DbType.Int32, "CreatedBy", false, false, null);
                    _fields[6] = new DatabaseField(DbType.DateTime, "CreatedDate", false, false, null);
                    _fields[7] = new DatabaseField(DbType.Int32, "ModifiedBy", false, false, null);
                    _fields[8] = new DatabaseField(DbType.DateTime, "ModifiedDate", false, false, null);

                    this.currentTableName = "Assign_Emp_Project";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
            public Assign_Emp_Project Clone()
          {
              return this.Clone<Assign_Emp_Project>();
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


public System.Int32 EmpID
{
    get
    {
        return (System.Int32) this.GetField("EmpID").fieldValue; 
    }

    set
    {
          this.SetFieldValue("EmpID", value);
    }
}


public System.Int32 ProjectID
{
    get
    {
        return (System.Int32) this.GetField("ProjectID").fieldValue; 
    }

    set
    {
        this.SetFieldValue("ProjectID", value);
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


public System.DateTime ActivatedDate
{
    get
    {
        return (System.DateTime) this.GetField("ActivatedDate").fieldValue; 
    }

    set
    {
          this.SetFieldValue("ActivatedDate", value);
    }
}
public System.Int32 CreatedBy
{
    get
    {
        return (System.Int32)this.GetField("CreatedBy").fieldValue;
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
        object result = this.GetField("CreatedDate").fieldValue;
        return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime)result;
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
        return (System.Int32)this.GetField("ModifiedBy").fieldValue;
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
        return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime)result;
    }

    set
    {
        this.SetFieldValue("ModifiedDate", value);
    }
}


}
}
