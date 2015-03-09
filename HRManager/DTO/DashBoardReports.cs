using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class DashBoardReports : TableMetadata
		{

                   public enum DashBoardReportsFields
                   {
                      ID,
                      ReportName,
                      Value
                  }


			    private DatabaseField[] _fields;

		    	public DashBoardReports()
			    {
					    _fields = new DatabaseField[3];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.String,"ReportName",false,false,null);
                    _fields[2] = new DatabaseField(DbType.String,"Value",false,false,null);
 
                        this.currentTableName = "DashBoardReports";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public DashBoardReports Clone()
          {
                 return this.Clone<DashBoardReports>();
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


public System.String ReportName
{
    get
    {
          object result = this.GetField("ReportName").fieldValue;
          return (result != null) ? result.ToString() : null;
    }

    set
    {
          this.SetFieldValue("ReportName", value);
    }
}


public System.String Value
{
    get
    {
          object result = this.GetField("Value").fieldValue;
          return (result != null) ? result.ToString() : null;
    }

    set
    {
          this.SetFieldValue("Value", value);
    }
}

}
}
