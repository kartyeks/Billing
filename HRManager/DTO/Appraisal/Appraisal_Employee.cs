using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Appraisal_Employee : TableMetadata
		{

                   public enum Appraisal_EmployeeFields
                   {
                      ID,
                      IntimationID,
                      EmployeeID,
                      Goals,
                      Grade,
                      GoalOn,
                      GradeOn,
                      GoalBy,
                      GradeBy,
                      PromotionOn,
                      PromotionBy,
                      PromotionTo,
                      SalaryHikeOn,
                      SalaryHikeBy,
                      SalaryHikeAmount,
                      HikePer,
                      Status,
                      OldDesignation,
                      OldSalary
                  }


			    private DatabaseField[] _fields;

		    	public Appraisal_Employee()
			    {
					    _fields = new DatabaseField[19];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"IntimationID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.Int32,"EmployeeID",false,false,null);
                    _fields[3] = new DatabaseField(DbType.String,"Goals",false,false,null);
                    _fields[4] = new DatabaseField(DbType.String,"Grade",false,false,null);
                    _fields[5] = new DatabaseField(DbType.DateTime,"GoalOn",false,false,null);
                    _fields[6] = new DatabaseField(DbType.DateTime,"GradeOn",false,false,null);
                    _fields[7] = new DatabaseField(DbType.Int32,"GoalBy",false,false,null);
                    _fields[8] = new DatabaseField(DbType.Int32,"GradeBy",false,false,null);
                    _fields[9] = new DatabaseField(DbType.DateTime,"PromotionOn",false,false,null);
                    _fields[10] = new DatabaseField(DbType.Int32,"PromotionBy",false,false,null);
                    _fields[11] = new DatabaseField(DbType.Int32,"PromotionTo",false,false,null);
                    _fields[12] = new DatabaseField(DbType.DateTime,"SalaryHikeOn",false,false,null);
                    _fields[13] = new DatabaseField(DbType.Int32,"SalaryHikeBy",false,false,null);
                    _fields[14] = new DatabaseField(DbType.String,"SalaryHikeAmount",false,false,null);
                    _fields[15] = new DatabaseField(DbType.Double, "HikePer", false, false, null);
                    _fields[16] = new DatabaseField(DbType.String, "Status", false, false, null);
                    _fields[17] = new DatabaseField(DbType.String, "OldDesignation", false, false, null);
                    _fields[18] = new DatabaseField(DbType.String, "OldSalary", false, false, null);
 
                        this.currentTableName = "Appraisal_Employee";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Appraisal_Employee Clone()
          {
                 return this.Clone<Appraisal_Employee>();
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


public System.Int32 IntimationID
{
    get
    {
        return (System.Int32) this.GetField("IntimationID").fieldValue; 
    }

    set
    {
          this.SetFieldValue("IntimationID", value);
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


public System.String Goals
{
    get
    {
         object result = this.GetField("Goals").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Goals", value);
    }
}


public System.String Grade
{
    get
    {
         object result = this.GetField("Grade").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Grade", value);
    }
}


public System.DateTime GoalOn
{
    get
    {
         object result = this.GetField("GoalOn").fieldValue; 
 return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime) result;
    }

    set
    {
          this.SetFieldValue("GoalOn", value);
    }
}


public System.DateTime GradeOn
{
    get
    {
         object result = this.GetField("GradeOn").fieldValue; 
 return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime) result;
    }

    set
    {
          this.SetFieldValue("GradeOn", value);
    }
}


public System.Int32 GoalBy
{
    get
    {
         object result = this.GetField("GoalBy").fieldValue; 
 return (result == null || result == DBNull.Value) ? Int32.MinValue : (System.Int32) result;
    }

    set
    {
          this.SetFieldValue("GoalBy", value);
    }
}


public System.Int32 GradeBy
{
    get
    {
         object result = this.GetField("GradeBy").fieldValue; 
 return (result == null || result == DBNull.Value) ? Int32.MinValue : (System.Int32) result;
    }

    set
    {
          this.SetFieldValue("GradeBy", value);
    }
}


public System.DateTime PromotionOn
{
    get
    {
         object result = this.GetField("PromotionOn").fieldValue; 
 return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime) result;
    }

    set
    {
          this.SetFieldValue("PromotionOn", value);
    }
}


public System.Int32 PromotionBy
{
    get
    {
         object result = this.GetField("PromotionBy").fieldValue; 
 return (result == null || result == DBNull.Value) ? Int32.MinValue : (System.Int32) result;
    }

    set
    {
          this.SetFieldValue("PromotionBy", value);
    }
}


public System.Int32 PromotionTo
{
    get
    {
         object result = this.GetField("PromotionTo").fieldValue; 
 return (result == null || result == DBNull.Value) ? Int32.MinValue : (System.Int32) result;
    }

    set
    {
          this.SetFieldValue("PromotionTo", value);
    }
}


public System.DateTime SalaryHikeOn
{
    get
    {
         object result = this.GetField("SalaryHikeOn").fieldValue; 
 return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime) result;
    }

    set
    {
          this.SetFieldValue("SalaryHikeOn", value);
    }
}


public System.Int32 SalaryHikeBy
{
    get
    {
         object result = this.GetField("SalaryHikeBy").fieldValue; 
 return (result == null || result == DBNull.Value) ? Int32.MinValue : (System.Int32) result;
    }

    set
    {
          this.SetFieldValue("SalaryHikeBy", value);
    }
}


public System.String SalaryHikeAmount
{
    get
    {
         object result = this.GetField("SalaryHikeAmount").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("SalaryHikeAmount", value);
    }
}

public System.String Status
{
    get
    {
        object result = this.GetField("Status").fieldValue;
        return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
        this.SetFieldValue("Status", value);
    }
}

public System.Double HikePer
{
    get
    {
        return (System.Double)this.GetField("HikePer").fieldValue;
    }

    set
    {
        this.SetFieldValue("HikePer", value);
    }
}

public System.String OldDesignation
{
    get
    {
        return (System.String)this.GetField("OldDesignation").fieldValue;
    }

    set
    {
        this.SetFieldValue("OldDesignation", value);
    }
}

public System.String OldSalary
{
    get
    {
        return (System.String)this.GetField("OldSalary").fieldValue;
    }

    set
    {
        this.SetFieldValue("OldSalary", value);
    }
}
}
}
