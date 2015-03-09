using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Master_Companys : TableMetadata
		{

                   public enum Master_CompanyFields
                   {
                      ID,
                      CompanyCode,
                      CompanyName,
                      CompanyShortName,
                      Address,
                      PANNumber,
                      TINNumber,
                      RegistrationNumber,
                      PFNumber,
                      PhoneNumber,
                      FinancialStartDate,
                      FinancialEndDate,
                      FinancialName,
                      VoucherStartDate,
                      VoucherEndDate,
                      InvestmentGroupID,
                      TANNumber,
                      ServiceTaxRegistrationNumber,
                      Website,
                      Email,
                      ShopEstablishmentNumber,
                      ESINumber,
                      IsActive,
                      CreatedBy,
                      CreatedDate,
                      ModifiedBy,
                      ModifiedDate
                  }


			    private DatabaseField[] _fields;

		    	public Master_Companys()
			    {
					    _fields = new DatabaseField[27];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.String,"CompanyCode",false,false,null);
                    _fields[2] = new DatabaseField(DbType.String,"CompanyName",false,false,null);
                    _fields[3] = new DatabaseField(DbType.String,"CompanyShortName",false,false,null);
                    _fields[4] = new DatabaseField(DbType.String,"Address",false,false,null);
                    _fields[5] = new DatabaseField(DbType.String,"PANNumber",false,false,null);
                    _fields[6] = new DatabaseField(DbType.String,"TINNumber",false,false,null);
                    _fields[7] = new DatabaseField(DbType.String,"RegistrationNumber",false,false,null);
                    _fields[8] = new DatabaseField(DbType.String,"PFNumber",false,false,null);
                    _fields[9] = new DatabaseField(DbType.String,"PhoneNumber",false,false,null);
                    _fields[10] = new DatabaseField(DbType.DateTime,"FinancialStartDate",false,false,null);
                    _fields[11] = new DatabaseField(DbType.DateTime,"FinancialEndDate",false,false,null);
                    _fields[12] = new DatabaseField(DbType.String,"FinancialName",false,false,null);
                    _fields[13] = new DatabaseField(DbType.DateTime,"VoucherStartDate",false,false,null);
                    _fields[14] = new DatabaseField(DbType.DateTime,"VoucherEndDate",false,false,null);
                    _fields[15] = new DatabaseField(DbType.Int32,"InvestmentGroupID",false,false,null);
                    _fields[16] = new DatabaseField(DbType.String,"TANNumber",false,false,null);
                    _fields[17] = new DatabaseField(DbType.String,"ServiceTaxRegistrationNumber",false,false,null);
                    _fields[18] = new DatabaseField(DbType.String,"Website",false,false,null);
                    _fields[19] = new DatabaseField(DbType.String,"Email",false,false,null);
                    _fields[20] = new DatabaseField(DbType.String,"ShopEstablishmentNumber",false,false,null);
                    _fields[21] = new DatabaseField(DbType.String,"ESINumber",false,false,null);
                    _fields[22] = new DatabaseField(DbType.Boolean,"IsActive",false,false,null);
                    _fields[23] = new DatabaseField(DbType.Int32,"CreatedBy",false,false,null);
                    _fields[24] = new DatabaseField(DbType.DateTime,"CreatedDate",false,false,null);
                    _fields[25] = new DatabaseField(DbType.Int32,"ModifiedBy",false,false,null);
                    _fields[26] = new DatabaseField(DbType.DateTime,"ModifiedDate",false,false,null);
 
                        this.currentTableName = "Master_Company";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Master_Companys Clone()
          {
                 return this.Clone<Master_Companys>();
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


public System.String CompanyCode
{
    get
    {
         object result = this.GetField("CompanyCode").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("CompanyCode", value);
    }
}


public System.String CompanyName
{
    get
    {
         object result = this.GetField("CompanyName").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("CompanyName", value);
    }
}


public System.String CompanyShortName
{
    get
    {
         object result = this.GetField("CompanyShortName").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("CompanyShortName", value);
    }
}


public System.String Address
{
    get
    {
         object result = this.GetField("Address").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Address", value);
    }
}


public System.String PANNumber
{
    get
    {
         object result = this.GetField("PANNumber").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("PANNumber", value);
    }
}


public System.String TINNumber
{
    get
    {
         object result = this.GetField("TINNumber").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("TINNumber", value);
    }
}


public System.String RegistrationNumber
{
    get
    {
         object result = this.GetField("RegistrationNumber").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("RegistrationNumber", value);
    }
}


public System.String PFNumber
{
    get
    {
         object result = this.GetField("PFNumber").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("PFNumber", value);
    }
}


public System.String PhoneNumber
{
    get
    {
         object result = this.GetField("PhoneNumber").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("PhoneNumber", value);
    }
}


public System.DateTime FinancialStartDate
{
    get
    {
         object result = this.GetField("FinancialStartDate").fieldValue; 
 return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime) result;
    }

    set
    {
          this.SetFieldValue("FinancialStartDate", value);
    }
}


public System.DateTime FinancialEndDate
{
    get
    {
         object result = this.GetField("FinancialEndDate").fieldValue; 
 return (result == null || result == DBNull.Value) ? DateTime.MinValue : (System.DateTime) result;
    }

    set
    {
          this.SetFieldValue("FinancialEndDate", value);
    }
}


public System.String FinancialName
{
    get
    {
         object result = this.GetField("FinancialName").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("FinancialName", value);
    }
}


public System.DateTime VoucherStartDate
{
    get
    {
        return (System.DateTime) this.GetField("VoucherStartDate").fieldValue; 
    }

    set
    {
          this.SetFieldValue("VoucherStartDate", value);
    }
}


public System.DateTime VoucherEndDate
{
    get
    {
        return (System.DateTime) this.GetField("VoucherEndDate").fieldValue; 
    }

    set
    {
          this.SetFieldValue("VoucherEndDate", value);
    }
}


public System.Int32 InvestmentGroupID
{
    get
    {
         object result = this.GetField("InvestmentGroupID").fieldValue; 
 return (result == null || result == DBNull.Value) ? Int32.MinValue : (System.Int32) result;
    }

    set
    {
          this.SetFieldValue("InvestmentGroupID", value);
    }
}


public System.String TANNumber
{
    get
    {
         object result = this.GetField("TANNumber").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("TANNumber", value);
    }
}


public System.String ServiceTaxRegistrationNumber
{
    get
    {
         object result = this.GetField("ServiceTaxRegistrationNumber").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("ServiceTaxRegistrationNumber", value);
    }
}


public System.String Website
{
    get
    {
         object result = this.GetField("Website").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Website", value);
    }
}


public System.String Email
{
    get
    {
         object result = this.GetField("Email").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Email", value);
    }
}


public System.String ShopEstablishmentNumber
{
    get
    {
         object result = this.GetField("ShopEstablishmentNumber").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("ShopEstablishmentNumber", value);
    }
}


public System.String ESINumber
{
    get
    {
         object result = this.GetField("ESINumber").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("ESINumber", value);
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
