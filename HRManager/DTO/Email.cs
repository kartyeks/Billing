using System;
using System.Data;

using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Email : TableMetadata
		{

                   public enum EmailFields
                   {
                      ID,
                      ToAddress,
                      FromAddress,
                      CcList,
                      BccList,
                      EmailSubject,
                      EmailBody,
                      Attachment,
                      SendStatus,
                      RetryCount,
                      FirstSendAttempt,
                      LastSendAttempt,
                      ErrorMsgOnSendFail
                  }


			    private DatabaseField[] _fields;

		    	public Email()
			    {
					    _fields = new DatabaseField[13];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.String,"ToAddress",false,false,null);
                    _fields[2] = new DatabaseField(DbType.String,"FromAddress",false,false,null);
                    _fields[3] = new DatabaseField(DbType.String,"CcList",false,false,null);
                    _fields[4] = new DatabaseField(DbType.String,"BccList",false,false,null);
                    _fields[5] = new DatabaseField(DbType.String,"EmailSubject",false,false,null);
                    _fields[6] = new DatabaseField(DbType.String,"EmailBody",false,false,null);
                    _fields[7] = new DatabaseField(DbType.String,"Attachment",false,false,null);
                    _fields[8] = new DatabaseField(DbType.String,"SendStatus",false,false,null);
                    _fields[9] = new DatabaseField(DbType.Int32,"RetryCount",false,false,null);
                    _fields[10] = new DatabaseField(DbType.DateTime,"FirstSendAttempt",false,false,null);
                    _fields[11] = new DatabaseField(DbType.DateTime,"LastSendAttempt",false,false,null);
                    _fields[12] = new DatabaseField(DbType.String,"ErrorMsgOnSendFail",false,false,null);
 
                        this.currentTableName = "Email";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Email Clone()
          {
                 return this.Clone<Email>();
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


public System.String ToAddress
{
    get
    {
         object result = this.GetField("ToAddress").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("ToAddress", value);
    }
}


public System.String FromAddress
{
    get
    {
         object result = this.GetField("FromAddress").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("FromAddress", value);
    }
}


public System.String CcList
{
    get
    {
         object result = this.GetField("CcList").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("CcList", value);
    }
}


public System.String BccList
{
    get
    {
         object result = this.GetField("BccList").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("BccList", value);
    }
}


public System.String EmailSubject
{
    get
    {
         object result = this.GetField("EmailSubject").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("EmailSubject", value);
    }
}


public System.String EmailBody
{
    get
    {
         object result = this.GetField("EmailBody").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("EmailBody", value);
    }
}


public System.String Attachment
{
    get
    {
         object result = this.GetField("Attachment").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Attachment", value);
    }
}


public System.String SendStatus
{
    get
    {
         object result = this.GetField("SendStatus").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("SendStatus", value);
    }
}


public System.Int32 RetryCount
{
    get
    {
         object result = this.GetField("RetryCount").fieldValue; 
 return (result == null || result == DBNull.Value) ? Int32.MinValue : (System.Int32) result;
    }

    set
    {
          this.SetFieldValue("RetryCount", value);
    }
}


public System.DateTime FirstSendAttempt
{
    get
    {
         object result = this.GetField("FirstSendAttempt").fieldValue; 
 return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime) result;
    }

    set
    {
          this.SetFieldValue("FirstSendAttempt", value);
    }
}


public System.DateTime LastSendAttempt
{
    get
    {
         object result = this.GetField("LastSendAttempt").fieldValue; 
 return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime) result;
    }

    set
    {
          this.SetFieldValue("LastSendAttempt", value);
    }
}


public System.String ErrorMsgOnSendFail
{
    get
    {
         object result = this.GetField("ErrorMsgOnSendFail").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("ErrorMsgOnSendFail", value);
    }
}

}
}
