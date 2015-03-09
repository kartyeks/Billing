using System;
using System.Data;

using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Master_Candidate : TableMetadata
		{

                   public enum Master_CandidateFields
                   {
                      ID,
                      FirstName,
                      LastName,
                      Sex,
                      MaritialStatus,
                      Per_Addess,
                      Per_Street,
                      Per_StateID,
                      Per_City,
                      Per_ZipCode,
                      Per_PhoneNo,
                      Per_MobileNumber,
                      Temp_Street,
                      Temp_StateID,
                      Temp_City,
                      Temp_Addess,
                      Temp_ZipCode,
                      Temp_MobileNumber,
                      TelephoneNoRes,
                      TelephoneNoOff,
                      DOB,
                      IsPhysicalDisability,
                      PhysicalDisability,
                      EMailID,
                      IsActive,
                      IsFresher,
                      FatherName,
                      IsTechnical,
                      Graduate,
                      Degree,
                      Title
                  }


			    private DatabaseField[] _fields;

		    	public Master_Candidate()
			    {
					    _fields = new DatabaseField[31];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.String,"FirstName",false,false,null);
                    _fields[2] = new DatabaseField(DbType.String,"LastName",false,false,null);
                    _fields[3] = new DatabaseField(DbType.String,"Sex",false,false,null);
                    _fields[4] = new DatabaseField(DbType.String,"MaritialStatus",false,false,null);
                    _fields[5] = new DatabaseField(DbType.String,"Per_Addess",false,false,null);
                    _fields[6] = new DatabaseField(DbType.String,"Per_Street",false,false,null);
                    _fields[7] = new DatabaseField(DbType.Int32, "Per_StateID", false, false, null);
                    _fields[8] = new DatabaseField(DbType.String,"Per_City",false,false,null);
                    _fields[9] = new DatabaseField(DbType.String,"Per_ZipCode",false,false,null);
                    _fields[10] = new DatabaseField(DbType.String,"Per_PhoneNo",false,false,null);
                    _fields[11] = new DatabaseField(DbType.String,"Per_MobileNumber",false,false,null);
                    _fields[12] = new DatabaseField(DbType.String,"Temp_Street",false,false,null);
                    _fields[13] = new DatabaseField(DbType.Int32, "Temp_StateID", false, false, null);
                    _fields[14] = new DatabaseField(DbType.String,"Temp_City",false,false,null);
                    _fields[15] = new DatabaseField(DbType.String,"Temp_Addess",false,false,null);
                    _fields[16] = new DatabaseField(DbType.String, "Temp_ZipCode", false, false, null);
                    _fields[17] = new DatabaseField(DbType.String,"Temp_MobileNumber",false,false,null);
                    _fields[18] = new DatabaseField(DbType.String,"TelephoneNoRes",false,false,null);
                    _fields[19] = new DatabaseField(DbType.String,"TelephoneNoOff",false,false,null);
                    _fields[20] = new DatabaseField(DbType.DateTime,"DOB",false,false,null);
                    _fields[21] = new DatabaseField(DbType.Boolean,"IsPhysicalDisability",false,false,null);
                    _fields[22] = new DatabaseField(DbType.String,"PhysicalDisability",false,false,null);
                    _fields[23] = new DatabaseField(DbType.String,"EMailID",false,false,null);
                    _fields[24] = new DatabaseField(DbType.Boolean, "IsActive", false, false, null);
                    _fields[25] = new DatabaseField(DbType.Boolean, "IsFresher", false, false, null);
                    _fields[26] = new DatabaseField(DbType.String, "FatherName", false, false, null);
                    _fields[27] = new DatabaseField(DbType.Boolean, "IsTechnical", false, false, null);
                    _fields[28] = new DatabaseField(DbType.String, "Graduate", false, false, null);
                    _fields[29] = new DatabaseField(DbType.String, "Degree", false, false, null);
                    _fields[30] = new DatabaseField(DbType.String, "Title", false, false, null);

                        this.currentTableName = "Master_Candidate";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Master_Candidate Clone()
          {
                 return this.Clone<Master_Candidate>();
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


public System.String FirstName
{
    get
    {
         object result = this.GetField("FirstName").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("FirstName", value);
    }
}


public System.String LastName
{
    get
    {
         object result = this.GetField("LastName").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("LastName", value);
    }
}


public System.String Sex
{
    get
    {
         object result = this.GetField("Sex").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Sex", value);
    }
}


public System.String MaritialStatus
{
    get
    {
         object result = this.GetField("MaritialStatus").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("MaritialStatus", value);
    }
}


public System.String Per_Addess
{
    get
    {
         object result = this.GetField("Per_Addess").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Per_Addess", value);
    }
}


public System.String Per_Street
{
    get
    {
         object result = this.GetField("Per_Street").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Per_Street", value);
    }
}
public System.Int32 Per_StateID
{
    get
    {
        return (System.Int32)this.GetField("Per_StateID").fieldValue;
    }

    set
    {
        this.SetFieldValue("Per_StateID", value);
    }
}



public System.String Per_City
{
    get
    {
         object result = this.GetField("Per_City").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Per_City", value);
    }
}


public System.String Per_ZipCode
{
    get
    {
         object result = this.GetField("Per_ZipCode").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Per_ZipCode", value);
    }
}


public System.String Per_PhoneNo
{
    get
    {
         object result = this.GetField("Per_PhoneNo").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Per_PhoneNo", value);
    }
}


public System.String Per_MobileNumber
{
    get
    {
         object result = this.GetField("Per_MobileNumber").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Per_MobileNumber", value);
    }
}


public System.String Temp_Street
{
    get
    {
         object result = this.GetField("Temp_Street").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Temp_Street", value);
    }
}

public System.Int32 Temp_StateID
{
    get
    {
        return (System.Int32)this.GetField("Temp_StateID").fieldValue;
    }

    set
    {
        this.SetFieldValue("Temp_StateID", value);
    }
}




public System.String Temp_City
{
    get
    {
         object result = this.GetField("Temp_City").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Temp_City", value);
    }
}


public System.String Temp_Addess
{
    get
    {
         object result = this.GetField("Temp_Addess").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Temp_Addess", value);
    }
}


public System.String Temp_ZipCode
{
    get
    {
        object result = this.GetField("Temp_ZipCode").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
        this.SetFieldValue("Temp_ZipCode", value);
    }
}


public System.String Temp_MobileNumber
{
    get
    {
         object result = this.GetField("Temp_MobileNumber").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Temp_MobileNumber", value);
    }
}


public System.String TelephoneNoRes
{
    get
    {
         object result = this.GetField("TelephoneNoRes").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("TelephoneNoRes", value);
    }
}


public System.String TelephoneNoOff
{
    get
    {
         object result = this.GetField("TelephoneNoOff").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("TelephoneNoOff", value);
    }
}


public System.DateTime DOB
{
    get
    {
        return (System.DateTime) this.GetField("DOB").fieldValue; 
    }

    set
    {
          this.SetFieldValue("DOB", value);
    }
}


public System.Boolean IsPhysicalDisability
{
    get
    {
        return (System.Boolean) this.GetField("IsPhysicalDisability").fieldValue; 
    }

    set
    {
          this.SetFieldValue("IsPhysicalDisability", value);
    }
}


public System.String PhysicalDisability
{
    get
    {
         object result = this.GetField("PhysicalDisability").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("PhysicalDisability", value);
    }
}


public System.String EMailID
{
    get
    {
         object result = this.GetField("EMailID").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("EMailID", value);
    }
}

public System.Boolean IsActive
{
    get
    {
        return (System.Boolean)this.GetField("IsActive").fieldValue;
    }

    set
    {
        this.SetFieldValue("IsActive", value);
    }
}
public System.Boolean IsFresher
{
    get
    {
        return (System.Boolean)this.GetField("IsFresher").fieldValue;
    }

    set
    {
        this.SetFieldValue("IsFresher", value);
    }
}
public System.String FatherName
{
    get
    {
        object result = this.GetField("FatherName").fieldValue;
        return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
        this.SetFieldValue("FatherName", value);
    }
}

public System.Boolean IsTechnical
{
    get
    {
        return (System.Boolean)this.GetField("IsTechnical").fieldValue;
    }

    set
    {
        this.SetFieldValue("IsTechnical", value);
    }
}
public System.String Graduate
{
    get
    {
        object result = this.GetField("Graduate").fieldValue;
        return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
        this.SetFieldValue("Graduate", value);
    }
}
public System.String Degree
{
    get
    {
        object result = this.GetField("Degree").fieldValue;
        return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
        this.SetFieldValue("Degree", value);
    }
}
public System.String Title
{
    get
    {
        object result = this.GetField("Title").fieldValue;
        return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
        this.SetFieldValue("Title", value);
    }
}
}
}
