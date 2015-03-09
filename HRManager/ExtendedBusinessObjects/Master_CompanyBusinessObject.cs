using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
using HRManager.DTO;

namespace HRManager.BusinessObjects
{
    public partial class Master_CompanyBusinessObject
    {
        public Master_Companys[] GetAllInActiveCompany()
        {
            const String Qry = "SELECT * FROM Master_Company WHERE IsActive=0 ORDER BY CompanyName";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_Companys[] CompanyDetails = new Master_Companys[dt.Rows.Count];

            for (int i = 0; i < CompanyDetails.Length; i++)
            {
                CompanyDetails[i] = new Master_Companys();
                CompanyDetails[i].ID = (int)dt.Rows[i]["ID"];
                CompanyDetails[i].CompanyCode = (String)dt.Rows[i]["CompanyCode"];
                CompanyDetails[i].CompanyName = (String)dt.Rows[i]["CompanyName"];
                CompanyDetails[i].CompanyShortName = (String)dt.Rows[i]["CompanyShortName"];
                CompanyDetails[i].Address = (String)dt.Rows[i]["Address"];
                CompanyDetails[i].PANNumber = (String)dt.Rows[i]["PANNumber"];
                CompanyDetails[i].TINNumber = (String)dt.Rows[i]["TINNumber"];
                CompanyDetails[i].RegistrationNumber = (String)dt.Rows[i]["RegistrationNumber"];
                CompanyDetails[i].PFNumber = (String)dt.Rows[i]["PFNumber"];
                CompanyDetails[i].PhoneNumber = (String)dt.Rows[i]["PhoneNumber"];
                CompanyDetails[i].FinancialStartDate = (DateTime)dt.Rows[i]["FinancialStartDate"];
                CompanyDetails[i].FinancialEndDate = (DateTime)dt.Rows[i]["FinancialEndDate"];
                CompanyDetails[i].FinancialName = (String)dt.Rows[i]["FinancialName"];
                CompanyDetails[i].VoucherStartDate = (DateTime)dt.Rows[i]["VoucherStartDate"];
                CompanyDetails[i].VoucherEndDate = (DateTime)dt.Rows[i]["VoucherEndDate"];
                CompanyDetails[i].InvestmentGroupID = (int)dt.Rows[i]["InvestmentGroupID"];
                CompanyDetails[i].TANNumber = (String)dt.Rows[i]["TANNumber"];
                CompanyDetails[i].ServiceTaxRegistrationNumber = (String)dt.Rows[i]["ServiceTaxRegistrationNumber"];
                CompanyDetails[i].Website = (String)dt.Rows[i]["Website"];
                CompanyDetails[i].Email = (String)dt.Rows[i]["Email"];
                CompanyDetails[i].ShopEstablishmentNumber = (String)dt.Rows[i]["ShopEstablishmentNumber"];
                CompanyDetails[i].ESINumber = (String)dt.Rows[i]["ESINumber"];
                CompanyDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
            }

            return CompanyDetails;
        }
        public Master_Companys[] GetAllInActiveCompanyOrderByCompany()
        {
            Master_Companys[] Company = GetAllInActiveCompany();

            if (Company != null && Company.Length >= 0)
            {
                return Company;
            }
            else
            {
                return null;
            }
        }
        public Master_Companys[] GetAllActiveCompany()
        {
            const String Qry = "SELECT * FROM Master_Company WHERE IsActive=1 ORDER BY CompanyName";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_Companys[] CompanyDetails = new Master_Companys[dt.Rows.Count];

            for (int i = 0; i < CompanyDetails.Length; i++)
            {
                CompanyDetails[i] = new Master_Companys();
                CompanyDetails[i].ID = (int)dt.Rows[i]["ID"];
                CompanyDetails[i].CompanyCode = (String)dt.Rows[i]["CompanyCode"];
                CompanyDetails[i].CompanyName = (String)dt.Rows[i]["CompanyName"];
                CompanyDetails[i].CompanyShortName = (String)dt.Rows[i]["CompanyShortName"];
                CompanyDetails[i].Address = (String)dt.Rows[i]["Address"];
                CompanyDetails[i].PANNumber = (String)dt.Rows[i]["PANNumber"];
                CompanyDetails[i].TINNumber = (String)dt.Rows[i]["TINNumber"];
                CompanyDetails[i].RegistrationNumber = (String)dt.Rows[i]["RegistrationNumber"];
                CompanyDetails[i].PFNumber = (String)dt.Rows[i]["PFNumber"];
                CompanyDetails[i].PhoneNumber = (String)dt.Rows[i]["PhoneNumber"];
                CompanyDetails[i].FinancialStartDate = (DateTime)dt.Rows[i]["FinancialStartDate"];
                CompanyDetails[i].FinancialEndDate = (DateTime)dt.Rows[i]["FinancialEndDate"];
                CompanyDetails[i].FinancialName = (String)dt.Rows[i]["FinancialName"];
                CompanyDetails[i].VoucherStartDate = (DateTime)dt.Rows[i]["VoucherStartDate"];
                CompanyDetails[i].VoucherEndDate = (DateTime)dt.Rows[i]["VoucherEndDate"];
                CompanyDetails[i].InvestmentGroupID = (int)dt.Rows[i]["InvestmentGroupID"];
                CompanyDetails[i].TANNumber = (String)dt.Rows[i]["TANNumber"];
                CompanyDetails[i].ServiceTaxRegistrationNumber = (String)dt.Rows[i]["ServiceTaxRegistrationNumber"];
                CompanyDetails[i].Website = (String)dt.Rows[i]["Website"];
                CompanyDetails[i].Email = (String)dt.Rows[i]["Email"];
                CompanyDetails[i].ShopEstablishmentNumber = (String)dt.Rows[i]["ShopEstablishmentNumber"];
                CompanyDetails[i].ESINumber = (String)dt.Rows[i]["ESINumber"];
                CompanyDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
            }

            return CompanyDetails;
        }

        public Master_Companys[] GetAllCompanyDetails()
        {
            const String Qry = "SELECT * FROM Master_Company ORDER BY CompanyName";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry);
            DataTable dt = EE.ExecuteDataTable(exQry);

            Master_Companys[] CompanyDetails = new Master_Companys[dt.Rows.Count];

            for (int i = 0; i < CompanyDetails.Length; i++)
            {
                CompanyDetails[i] = new Master_Companys();
                CompanyDetails[i].ID = (int)dt.Rows[i]["ID"];
                CompanyDetails[i].CompanyCode = (String)dt.Rows[i]["CompanyCode"];
                CompanyDetails[i].CompanyName = (String)dt.Rows[i]["CompanyName"];
                CompanyDetails[i].CompanyShortName = (String)dt.Rows[i]["CompanyShortName"];
                CompanyDetails[i].Address = (String)dt.Rows[i]["Address"];
                CompanyDetails[i].PANNumber = (String)dt.Rows[i]["PANNumber"];
                CompanyDetails[i].TINNumber = (String)dt.Rows[i]["TINNumber"];
                CompanyDetails[i].RegistrationNumber = (String)dt.Rows[i]["RegistrationNumber"];
                CompanyDetails[i].PFNumber = (String)dt.Rows[i]["PFNumber"];
                CompanyDetails[i].PhoneNumber = (String)dt.Rows[i]["PhoneNumber"];
                CompanyDetails[i].FinancialStartDate = (DateTime)dt.Rows[i]["FinancialStartDate"];
                CompanyDetails[i].FinancialEndDate = (DateTime)dt.Rows[i]["FinancialEndDate"];
                CompanyDetails[i].FinancialName = (String)dt.Rows[i]["FinancialName"];
                CompanyDetails[i].VoucherStartDate = (DateTime)dt.Rows[i]["VoucherStartDate"];
                CompanyDetails[i].VoucherEndDate = (DateTime)dt.Rows[i]["VoucherEndDate"];
                CompanyDetails[i].InvestmentGroupID = (int)dt.Rows[i]["InvestmentGroupID"];
                CompanyDetails[i].TANNumber = (String)dt.Rows[i]["TANNumber"];
                CompanyDetails[i].ServiceTaxRegistrationNumber = (String)dt.Rows[i]["ServiceTaxRegistrationNumber"];
                CompanyDetails[i].Website = (String)dt.Rows[i]["Website"];
                CompanyDetails[i].Email = (String)dt.Rows[i]["Email"];
                CompanyDetails[i].ShopEstablishmentNumber = (String)dt.Rows[i]["ShopEstablishmentNumber"];
                CompanyDetails[i].ESINumber = (String)dt.Rows[i]["ESINumber"];
                CompanyDetails[i].IsActive = (bool)dt.Rows[i]["IsActive"];
            }

            return CompanyDetails;
        }

    }
}
