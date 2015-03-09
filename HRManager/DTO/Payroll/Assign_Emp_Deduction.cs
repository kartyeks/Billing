using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Assign_Emp_Deduction : TableMetadata
		{

                   public enum Assign_Emp_DeductionFields
                   {
                      ID,
                      EmployeeSalaryID,
                      DeductionID,
                      Value
                  }


			    private DatabaseField[] _fields;

		    	public Assign_Emp_Deduction()
			    {
					    _fields = new DatabaseField[4];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32, "EmployeeSalaryID", false, false, null);
                    _fields[2] = new DatabaseField(DbType.Int32,"DeductionID",false,false,null);
                    _fields[3] = new DatabaseField(DbType.Double,"Value",false,false,null);
 
                        this.currentTableName = "Assign_Emp_Deduction";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Assign_Emp_Deduction Clone()
          {
                 return this.Clone<Assign_Emp_Deduction>();
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


public System.Int32 EmployeeSalaryID
{
    get
    {
        object result = this.GetField("EmployeeSalaryID").fieldValue; 
 return (result == null || result == DBNull.Value) ? Int32.MinValue : (System.Int32) result;
    }

    set
    {
        this.SetFieldValue("EmployeeSalaryID", value);
    }
}


public System.Int32 DeductionID
{
    get
    {
         object result = this.GetField("DeductionID").fieldValue; 
 return (result == null || result == DBNull.Value) ? Int32.MinValue : (System.Int32) result;
    }

    set
    {
          this.SetFieldValue("DeductionID", value);
    }
}


public System.Double Value
{
    get
    {
         object result = this.GetField("Value").fieldValue; 
 return (result == null || result == DBNull.Value) ? Double.MinValue : (System.Double) result;
    }

    set
    {
          this.SetFieldValue("Value", value);
    }
}

}
}
