using System;
using System.Data;
using IS91.Services.DataBlock;

namespace HRManager.DTO
{

      [Serializable()]
		public class Candidate_Current_Employer : TableMetadata
		{

                   public enum Candidate_Current_EmployerFields
                   {
                      ID,
                      CandidateID,
                      EmployerName,
                      Address,
                      BusinessNature,
                      NoOfEmployess,
                      AnnualSalesTurnOver,
                      JoinDesignation,
                      JoinDate,
                      CurrentDesignation,
                      DesignationEffectFrom,
                      ReportingOfficer,
                      ReportingOfficerDesignation,
                      ReportingOfficerMobileNo,
                      ReportingOfficerTeleNo,
                      Responsible,
                      Remarks,
                      Joining_Basic,
                      Joining_DA,
                      Joining_HRA,
                      Joining_Conveyance,
                      Joining_OtherAllowance,
                      Joining_GrossSalary,
                      Joining_LTA,
                      Joining_Medical,
                      Joining_AnnualBonus,
                      Joining_ClubMembership,
                      Joining_Others,
                      Joining_MonthlyCTC,
                      Current_Basic,
                      Current_DA,
                      Current_HRA,
                      Current_Conveyance,
                      Current_OtherAllowance,
                      Current_GrossSalary,
                      Current_LTA,
                      Current_Medical,
                      Current_AnnualBonus,
                      Current_ClubMembership,
                      Current_Others,
                      Current_MonthlyCTC,
                      IsPF,
                      IsGratuity,
                      IsSuperAnnuation,
                      Others,
                      WeeklyOff,
                      JobResponsibilities,
                      ReportingOfficerEmailID
                  }


			    private DatabaseField[] _fields;

		    	public Candidate_Current_Employer()
			    {
					    _fields = new DatabaseField[48];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.Int32,"CandidateID",false,false,null);
                    _fields[2] = new DatabaseField(DbType.String,"EmployerName",false,false,null);
                    _fields[3] = new DatabaseField(DbType.String,"Address",false,false,null);
                    _fields[4] = new DatabaseField(DbType.String,"BusinessNature",false,false,null);
                    _fields[5] = new DatabaseField(DbType.Int32,"NoOfEmployess",false,false,null);
                    _fields[6] = new DatabaseField(DbType.String,"AnnualSalesTurnOver",false,false,null);
                    _fields[7] = new DatabaseField(DbType.String,"JoinDesignation",false,false,null);
                    _fields[8] = new DatabaseField(DbType.DateTime,"JoinDate",false,false,null);
                    _fields[9] = new DatabaseField(DbType.String,"CurrentDesignation",false,false,null);
                    _fields[10] = new DatabaseField(DbType.DateTime,"DesignationEffectFrom",false,false,null);
                    _fields[11] = new DatabaseField(DbType.String,"ReportingOfficer",false,false,null);
                    _fields[12] = new DatabaseField(DbType.String,"ReportingOfficerDesignation",false,false,null);
                    _fields[13] = new DatabaseField(DbType.String,"ReportingOfficerMobileNo",false,false,null);
                    _fields[14] = new DatabaseField(DbType.String,"ReportingOfficerTeleNo",false,false,null);
                    _fields[15] = new DatabaseField(DbType.String,"Responsible",false,false,null);
                    _fields[16] = new DatabaseField(DbType.String,"Remarks",false,false,null);
                    _fields[17] = new DatabaseField(DbType.Double,"Joining_Basic",false,false,null);
                    _fields[18] = new DatabaseField(DbType.Double,"Joining_DA",false,false,null);
                    _fields[19] = new DatabaseField(DbType.Double,"Joining_HRA",false,false,null);
                    _fields[20] = new DatabaseField(DbType.Double,"Joining_Conveyance",false,false,null);
                    _fields[21] = new DatabaseField(DbType.Double,"Joining_OtherAllowance",false,false,null);
                    _fields[22] = new DatabaseField(DbType.Double,"Joining_GrossSalary",false,false,null);
                    _fields[23] = new DatabaseField(DbType.Double,"Joining_LTA",false,false,null);
                    _fields[24] = new DatabaseField(DbType.Double,"Joining_Medical",false,false,null);
                    _fields[25] = new DatabaseField(DbType.Double,"Joining_AnnualBonus",false,false,null);
                    _fields[26] = new DatabaseField(DbType.Double,"Joining_ClubMembership",false,false,null);
                    _fields[27] = new DatabaseField(DbType.Double,"Joining_Others",false,false,null);
                    _fields[28] = new DatabaseField(DbType.Double,"Joining_MonthlyCTC",false,false,null);
                    _fields[29] = new DatabaseField(DbType.Double,"Current_Basic",false,false,null);
                    _fields[30] = new DatabaseField(DbType.Double,"Current_DA",false,false,null);
                    _fields[31] = new DatabaseField(DbType.Double,"Current_HRA",false,false,null);
                    _fields[32] = new DatabaseField(DbType.Double,"Current_Conveyance",false,false,null);
                    _fields[33] = new DatabaseField(DbType.Double,"Current_OtherAllowance",false,false,null);
                    _fields[34] = new DatabaseField(DbType.Double,"Current_GrossSalary",false,false,null);
                    _fields[35] = new DatabaseField(DbType.Double,"Current_LTA",false,false,null);
                    _fields[36] = new DatabaseField(DbType.Double,"Current_Medical",false,false,null);
                    _fields[37] = new DatabaseField(DbType.Double,"Current_AnnualBonus",false,false,null);
                    _fields[38] = new DatabaseField(DbType.Double,"Current_ClubMembership",false,false,null);
                    _fields[39] = new DatabaseField(DbType.Double,"Current_Others",false,false,null);
                    _fields[40] = new DatabaseField(DbType.Double,"Current_MonthlyCTC",false,false,null);
                    _fields[41] = new DatabaseField(DbType.Boolean,"IsPF",false,false,null);
                    _fields[42] = new DatabaseField(DbType.Boolean,"IsGratuity",false,false,null);
                    _fields[43] = new DatabaseField(DbType.Boolean,"IsSuperAnnuation",false,false,null);
                    _fields[44] = new DatabaseField(DbType.String,"Others",false,false,null);
                    _fields[45] = new DatabaseField(DbType.String,"WeeklyOff",false,false,null);
                    _fields[46] = new DatabaseField(DbType.String, "JobResponsibilities", false, false, null);
                    _fields[47] = new DatabaseField(DbType.String, "ReportingOfficerEmailID", false, false, null);
                    
 
                        this.currentTableName = "Candidate_Current_Employer";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Candidate_Current_Employer Clone()
          {
                 return this.Clone<Candidate_Current_Employer>();
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


public System.Int32 CandidateID
{
    get
    {
        return (System.Int32) this.GetField("CandidateID").fieldValue; 
    }

    set
    {
          this.SetFieldValue("CandidateID", value);
    }
}


public System.String EmployerName
{
    get
    {
         object result = this.GetField("EmployerName").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("EmployerName", value);
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


public System.String BusinessNature
{
    get
    {
         object result = this.GetField("BusinessNature").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("BusinessNature", value);
    }
}


public System.Int32 NoOfEmployess
{
    get
    {
        return (System.Int32) this.GetField("NoOfEmployess").fieldValue; 
    }

    set
    {
          this.SetFieldValue("NoOfEmployess", value);
    }
}


public System.String AnnualSalesTurnOver
{
    get
    {
         object result = this.GetField("AnnualSalesTurnOver").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("AnnualSalesTurnOver", value);
    }
}


public System.String JoinDesignation
{
    get
    {
         object result = this.GetField("JoinDesignation").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("JoinDesignation", value);
    }
}


public System.DateTime JoinDate
{
    get
    {
        return (System.DateTime) this.GetField("JoinDate").fieldValue; 
    }

    set
    {
          this.SetFieldValue("JoinDate", value);
    }
}


public System.String CurrentDesignation
{
    get
    {
         object result = this.GetField("CurrentDesignation").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("CurrentDesignation", value);
    }
}


public System.DateTime DesignationEffectFrom
{
    get
    {
        return (System.DateTime) this.GetField("DesignationEffectFrom").fieldValue; 
    }

    set
    {
          this.SetFieldValue("DesignationEffectFrom", value);
    }
}


public System.String ReportingOfficer
{
    get
    {
         object result = this.GetField("ReportingOfficer").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("ReportingOfficer", value);
    }
}


public System.String ReportingOfficerDesignation
{
    get
    {
         object result = this.GetField("ReportingOfficerDesignation").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("ReportingOfficerDesignation", value);
    }
}


public System.String ReportingOfficerMobileNo
{
    get
    {
         object result = this.GetField("ReportingOfficerMobileNo").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("ReportingOfficerMobileNo", value);
    }
}


public System.String ReportingOfficerTeleNo
{
    get
    {
         object result = this.GetField("ReportingOfficerTeleNo").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("ReportingOfficerTeleNo", value);
    }
}


public System.String Responsible
{
    get
    {
         object result = this.GetField("Responsible").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Responsible", value);
    }
}


public System.String Remarks
{
    get
    {
         object result = this.GetField("Remarks").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Remarks", value);
    }
}


public System.Double Joining_Basic
{
    get
    {
        return (System.Double) this.GetField("Joining_Basic").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Joining_Basic", value);
    }
}


public System.Double Joining_DA
{
    get
    {
        return (System.Double) this.GetField("Joining_DA").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Joining_DA", value);
    }
}


public System.Double Joining_HRA
{
    get
    {
        return (System.Double) this.GetField("Joining_HRA").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Joining_HRA", value);
    }
}


public System.Double Joining_Conveyance
{
    get
    {
        return (System.Double) this.GetField("Joining_Conveyance").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Joining_Conveyance", value);
    }
}


public System.Double Joining_OtherAllowance
{
    get
    {
        return (System.Double) this.GetField("Joining_OtherAllowance").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Joining_OtherAllowance", value);
    }
}


public System.Double Joining_GrossSalary
{
    get
    {
        return (System.Double) this.GetField("Joining_GrossSalary").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Joining_GrossSalary", value);
    }
}


public System.Double Joining_LTA
{
    get
    {
        return (System.Double) this.GetField("Joining_LTA").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Joining_LTA", value);
    }
}


public System.Double Joining_Medical
{
    get
    {
        return (System.Double) this.GetField("Joining_Medical").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Joining_Medical", value);
    }
}


public System.Double Joining_AnnualBonus
{
    get
    {
        return (System.Double) this.GetField("Joining_AnnualBonus").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Joining_AnnualBonus", value);
    }
}


public System.Double Joining_ClubMembership
{
    get
    {
        return (System.Double) this.GetField("Joining_ClubMembership").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Joining_ClubMembership", value);
    }
}


public System.Double Joining_Others
{
    get
    {
        return (System.Double) this.GetField("Joining_Others").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Joining_Others", value);
    }
}


public System.Double Joining_MonthlyCTC
{
    get
    {
        return (System.Double) this.GetField("Joining_MonthlyCTC").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Joining_MonthlyCTC", value);
    }
}


public System.Double Current_Basic
{
    get
    {
        return (System.Double) this.GetField("Current_Basic").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Current_Basic", value);
    }
}


public System.Double Current_DA
{
    get
    {
        return (System.Double) this.GetField("Current_DA").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Current_DA", value);
    }
}


public System.Double Current_HRA
{
    get
    {
        return (System.Double) this.GetField("Current_HRA").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Current_HRA", value);
    }
}


public System.Double Current_Conveyance
{
    get
    {
        return (System.Double) this.GetField("Current_Conveyance").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Current_Conveyance", value);
    }
}


public System.Double Current_OtherAllowance
{
    get
    {
        return (System.Double) this.GetField("Current_OtherAllowance").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Current_OtherAllowance", value);
    }
}


public System.Double Current_GrossSalary
{
    get
    {
        return (System.Double) this.GetField("Current_GrossSalary").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Current_GrossSalary", value);
    }
}


public System.Double Current_LTA
{
    get
    {
        return (System.Double) this.GetField("Current_LTA").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Current_LTA", value);
    }
}


public System.Double Current_Medical
{
    get
    {
        return (System.Double) this.GetField("Current_Medical").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Current_Medical", value);
    }
}


public System.Double Current_AnnualBonus
{
    get
    {
        return (System.Double) this.GetField("Current_AnnualBonus").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Current_AnnualBonus", value);
    }
}


public System.Double Current_ClubMembership
{
    get
    {
        return (System.Double) this.GetField("Current_ClubMembership").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Current_ClubMembership", value);
    }
}


public System.Double Current_Others
{
    get
    {
        return (System.Double) this.GetField("Current_Others").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Current_Others", value);
    }
}


public System.Double Current_MonthlyCTC
{
    get
    {
        return (System.Double) this.GetField("Current_MonthlyCTC").fieldValue; 
    }

    set
    {
          this.SetFieldValue("Current_MonthlyCTC", value);
    }
}


public System.Boolean IsPF
{
    get
    {
        return (System.Boolean) this.GetField("IsPF").fieldValue; 
    }

    set
    {
          this.SetFieldValue("IsPF", value);
    }
}


public System.Boolean IsGratuity
{
    get
    {
        return (System.Boolean) this.GetField("IsGratuity").fieldValue; 
    }

    set
    {
          this.SetFieldValue("IsGratuity", value);
    }
}


public System.Boolean IsSuperAnnuation
{
    get
    {
        return (System.Boolean) this.GetField("IsSuperAnnuation").fieldValue; 
    }

    set
    {
          this.SetFieldValue("IsSuperAnnuation", value);
    }
}


public System.String Others
{
    get
    {
         object result = this.GetField("Others").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Others", value);
    }
}


public System.String WeeklyOff
{
    get
    {
         object result = this.GetField("WeeklyOff").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("WeeklyOff", value);
    }
}
public System.String JobResponsibilities
{
    get
    {
        object result = this.GetField("JobResponsibilities").fieldValue;
        return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
        this.SetFieldValue("JobResponsibilities", value);
    }
}
public System.String ReportingOfficerEmailID
{
    get
    {
        object result = this.GetField("ReportingOfficerEmailID").fieldValue;
        return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
        this.SetFieldValue("ReportingOfficerEmailID", value);
    }
}

}
}
