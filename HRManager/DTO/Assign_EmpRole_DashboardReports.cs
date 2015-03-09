using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{


      [Serializable()]
		public class Assign_EmpRole_DashboardReports : TableMetadata
		{

                   public enum Assign_EmpRole_DashboardReportsFields
                   {
                      ID,
                      RoleID,
                      ReportID,
                      CreatedBy,
                      CreatedDate,
                      ModifiedBy,
                      ModifiedDate
                  }


			    private DatabaseField[] _fields;

		    	public Assign_EmpRole_DashboardReports()
			    {
					    _fields = new DatabaseField[7];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"RoleID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.Int32,"ReportID",false,false,null);
                    _fields[3] = new DatabaseField(DbType.Int32,"CreatedBy",false,false,null);
                    _fields[4] = new DatabaseField(DbType.DateTime,"CreatedDate",false,false,null);
                    _fields[5] = new DatabaseField(DbType.Int32,"ModifiedBy",false,false,null);
                    _fields[6] = new DatabaseField(DbType.DateTime,"ModifiedDate",false,false,null);
 
                        this.currentTableName = "Assign_EmpRole_DashboardReports";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Assign_EmpRole_DashboardReports Clone()
          {
                 return this.Clone<Assign_EmpRole_DashboardReports>();
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


public System.Int32 RoleID
{
    get
    {
          return (System.Int32 ) (this.GetField("RoleID")).fieldValue;
    }

    set
    {
          this.SetFieldValue("RoleID", value);
    }
}


public System.Int32 ReportID
{
    get
    {
          return (System.Int32 ) (this.GetField("ReportID")).fieldValue;
    }

    set
    {
          this.SetFieldValue("ReportID", value);
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
