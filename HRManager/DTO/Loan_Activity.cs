using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Loan_Activity : TableMetadata
		{

                   public enum Loan_ActivityFields
                   {
                      ID,
                      LoanRequestID,
                      Initiator,
                      Receiver,
                      Status,
                      ActivityBy,
                      ActivityDate,
                      InitiatorRemark
                  }


			    private DatabaseField[] _fields;

		    	public Loan_Activity()
			    {
					    _fields = new DatabaseField[8];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"LoanRequestID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.Int32,"Initiator",false,false,null);
                    _fields[3] = new DatabaseField(DbType.Int32,"Receiver",false,false,null);
                    _fields[4] = new DatabaseField(DbType.String,"Status",false,false,null);
                    _fields[5] = new DatabaseField(DbType.Int32,"ActivityBy",false,false,null);
                    _fields[6] = new DatabaseField(DbType.DateTime,"ActivityDate",false,false,null);
                    _fields[7] = new DatabaseField(DbType.String, "InitiatorRemark", false, false, null);
 
                        this.currentTableName = "Loan_Activity";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Loan_Activity Clone()
          {
                 return this.Clone<Loan_Activity>();
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
public System.String InitiatorRemark
{
    get
    {
        object result = this.GetField("InitiatorRemark").fieldValue;
        return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
        this.SetFieldValue("InitiatorRemark", value);
    }
}


public System.Int32 LoanRequestID
{
    get
    {
        return (System.Int32) this.GetField("LoanRequestID").fieldValue; 
    }

    set
    {
          this.SetFieldValue("LoanRequestID", value);
    }
}


public System.Int32 Initiator
{
    get
    {
        return (System.Int32) this.GetField("Initiator").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Initiator", value);
    }
}


public System.Int32 Receiver
{
    get
    {
        return (System.Int32) this.GetField("Receiver").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Receiver", value);
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


public System.Int32 ActivityBy
{
    get
    {
        return (System.Int32) this.GetField("ActivityBy").fieldValue; 
    }

    set
    {
          this.SetFieldValue("ActivityBy", value);
    }
}


public System.DateTime ActivityDate
{
    get
    {
        return (System.DateTime) this.GetField("ActivityDate").fieldValue; 
    }

    set
    {
          this.SetFieldValue("ActivityDate", value);
    }
}

}
}
