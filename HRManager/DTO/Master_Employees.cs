using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Master_Employees : TableMetadata
		{

                   public enum Master_EmployeesFields
                   {
                      ID,
                      EmpCode,
                      EmployeeTypeID,
                      FirstName,
                      LastName,
                      MiddleName,
                      DOB,
                      Gender,
                      MaritalStatusID,
                      PermanentAddress,
                      CurrentAddress,
                      MobileNumber,
                      ResidenceNumber,
                      EmergencyContactNumber,
                      PersonalEmailID,
                      Photo,
                      IsActive,
                      CreatedBy,
                      CreatedDate,
                      ModifiedBy,
                      ModifiedDate,
                      IsDeleted
                  }


			    private DatabaseField[] _fields;

		    	public Master_Employees()
			    {
					    _fields = new DatabaseField[22];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.String,"EmpCode",false,false,null);
                    _fields[2] = new DatabaseField(DbType.Int32,"EmployeeTypeID",false,false,null);
                    _fields[3] = new DatabaseField(DbType.String,"FirstName",false,false,null);
                    _fields[4] = new DatabaseField(DbType.String,"LastName",false,false,null);
                    _fields[5] = new DatabaseField(DbType.String, "MiddleName", false, false, null);
                    _fields[6] = new DatabaseField(DbType.DateTime,"DOB",false,false,null);
                    _fields[7] = new DatabaseField(DbType.String,"Gender",false,false,null);
                    _fields[8] = new DatabaseField(DbType.Int32,"MaritalStatusID",false,false,null);
                    _fields[9] = new DatabaseField(DbType.String,"PermanentAddress",false,false,null);
                    _fields[10] = new DatabaseField(DbType.String,"CurrentAddress",false,false,null);
                    _fields[11] = new DatabaseField(DbType.String,"MobileNumber",false,false,null);
                    _fields[12] = new DatabaseField(DbType.String,"ResidenceNumber",false,false,null);
                    _fields[13] = new DatabaseField(DbType.String,"EmergencyContactNumber",false,false,null);
                    _fields[14] = new DatabaseField(DbType.String,"PersonalEmailID",false,false,null);
                    _fields[15] = new DatabaseField(DbType.Binary,"Photo",false,false,null);
                    _fields[16] = new DatabaseField(DbType.Boolean,"IsActive",false,false,null);
                    _fields[17] = new DatabaseField(DbType.Int32,"CreatedBy",false,false,null);
                    _fields[18] = new DatabaseField(DbType.DateTime,"CreatedDate",false,false,null);
                    _fields[19] = new DatabaseField(DbType.Int32,"ModifiedBy",false,false,null);
                    _fields[20] = new DatabaseField(DbType.DateTime,"ModifiedDate",false,false,null);
                    _fields[21] = new DatabaseField(DbType.Boolean, "IsDeleted", false, false, null);
                        this.currentTableName = "Master_Employees";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Master_Employees Clone()
          {
                 return this.Clone<Master_Employees>();
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


public System.String EmpCode
{
    get
    {
         object result = this.GetField("EmpCode").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("EmpCode", value);
    }
}


public System.Int32 EmployeeTypeID
{
    get
    {
        return (System.Int32) this.GetField("EmployeeTypeID").fieldValue; 
    }

    set
    {
          this.SetFieldValue("EmployeeTypeID", value);
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


public System.String MiddleName
{
    get
    {
        object result = this.GetField("MiddleName").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
        this.SetFieldValue("MiddleName", value);
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


public System.String Gender
{
    get
    {
         object result = this.GetField("Gender").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Gender", value);
    }
}


public System.Int32 MaritalStatusID
{
    get
    {
        return (System.Int32) this.GetField("MaritalStatusID").fieldValue; 
    }

    set
    {
          this.SetFieldValue("MaritalStatusID", value);
    }
}


public System.String PermanentAddress
{
    get
    {
         object result = this.GetField("PermanentAddress").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("PermanentAddress", value);
    }
}


public System.String CurrentAddress
{
    get
    {
         object result = this.GetField("CurrentAddress").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("CurrentAddress", value);
    }
}


public System.String MobileNumber
{
    get
    {
         object result = this.GetField("MobileNumber").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("MobileNumber", value);
    }
}


public System.String ResidenceNumber
{
    get
    {
         object result = this.GetField("ResidenceNumber").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("ResidenceNumber", value);
    }
}


public System.String EmergencyContactNumber
{
    get
    {
         object result = this.GetField("EmergencyContactNumber").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("EmergencyContactNumber", value);
    }
}


public System.String PersonalEmailID
{
    get
    {
         object result = this.GetField("PersonalEmailID").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("PersonalEmailID", value);
    }
}
public System.Byte[] Photo
{
    get
    {
        object result = (this.GetField("Photo")).fieldValue;
        if (result == null || string.Concat(result) == "0")
        {
            return new System.Byte[0];
        }

        return (System.Byte[])result;
    }

    set
    {
        this.SetFieldValue("Photo", value);
    }

}


public System.Boolean IsDeleted
{
    get
    {
        return (System.Boolean)this.GetField("IsDeleted").fieldValue;
    }

    set
    {
        this.SetFieldValue("IsDeleted", value);
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
