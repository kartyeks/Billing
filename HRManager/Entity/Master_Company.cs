using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IRCA.Communication;

namespace HRManager.Entity
{
    public class Master_Company : JGridDataObject
    {
        public int _ID;
        public String _CompanyCode;
        public String _CompanyName;
        public String _CompanyShortName;
        public String _Address;
        public String _PanNumber;
        public String _TinNumber;
        public String _RegistrationNumber;
        public String _PFNumber;
        public String _PhoneNumber;
        public DateTime _FinancialStartDate;
        public DateTime _FinancialEndDate;
        public String _FinancialName;
        public DateTime _VoucherStartDate;
        public DateTime _VoucherEndDate;
        public int _InvestmentGroupID;
        public String _TANNumber;
        public String _ServiceTaxRegistrationNumber;
        public String _Website;
        public String _Email;
        public String _ShopEstablishmentNumber;
        public String _ESINumber;
        public bool _IsActive;
        public int _UpdateBy;
        public int _CreatedBy;
        public DateTime _CreatedDate;
        public int _ModifiedBy;
        public DateTime _ModifiedDate;
        public bool _IsNew;



        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
        public String CompanyCode
        {
            get
            {
                return _CompanyCode;
            }
            set
            {
                _CompanyCode = value;
            }
        }
        public String CompanyName
        {
            get
            {
                return _CompanyName;
            }
            set
            {
                _CompanyName = value;
            }
        }
        public String CompanyShortName
        {
            get
            {
                return _CompanyShortName;
            }
            set
            {
                _CompanyShortName = value;
            }
        }
        public String Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }
        public String PanNumber
        {
            get
            {
                return _PanNumber;
            }
            set
            {
                _PanNumber = value;
            }
        }
        public String TinNumber
        {
            get
            {
                return _TinNumber;
            }
            set
            {
                _TinNumber = value;
            }
        }
        public String RegistrationNumber
        {
            get
            {
                return _RegistrationNumber;
            }
            set
            {
                _RegistrationNumber = value;
            }
        }
        public String PFNumber
        {
            get
            {
                return _PFNumber;
            }
            set
            {
                _PFNumber = value;
            }
        }
        public String PhoneNumber
        {
            get
            {
                return _PhoneNumber;
            }
            set
            {
                _PhoneNumber = value;
            }
        }
        public DateTime FinancialStartDate
        {
            get
            {
                return _FinancialStartDate;
            }
            set
            {
                _FinancialStartDate = value;
            }
        }
        public DateTime FinancialEndDate
        {
            get
            {
                return _FinancialEndDate;
            }
            set
            {
                _FinancialEndDate = value;
            }
        }
        public String FinancialName
        {
            get
            {
                return _FinancialName;
            }
            set
            {
                _FinancialName = value;
            }
        }
        public DateTime VoucherStartDate
        {
            get
            {
                return _VoucherStartDate;
            }
            set
            {
                _VoucherStartDate = value;
            }
        }
        public DateTime VoucherEndDate
        {
            get
            {
                return _VoucherEndDate;
            }
            set
            {
                _VoucherEndDate = value;
            }
        }
        public int InvestmentGroupID
        {
            get
            {
                return _InvestmentGroupID;
            }
            set
            {
                _InvestmentGroupID = value;
            }
        }
        public String TANNumber
        {
            get
            {
                return _TANNumber;
            }
            set
            {
                _TANNumber = value;
            }
        }
        public String ServiceTaxRegistrationNumber
        {
            get
            {
                return _ServiceTaxRegistrationNumber;
            }
            set
            {
                _ServiceTaxRegistrationNumber = value;
            }
        }
        public String Website
        {
            get
            {
                return _Website;
            }
            set
            {
                _Website = value;
            }
        }


        public String Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }
       
        public String ShopEstablishmentNumber
        {
            get
            {
                return _ShopEstablishmentNumber;
            }
            set
            {
                _ShopEstablishmentNumber = value;
            }
        }

        public String ESINumber
        {
            get
            {
                return _ESINumber;
            }
            set
            {
                _ESINumber = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                _IsActive = value;
            }
        }
        public int UpdatedBy
        {
            get { return _UpdateBy; }
            set { _UpdateBy = value; }
        }
        public bool Status { get { return _IsActive; } set { _IsActive = value; } }

        private void Update(Master_Companys Company)
        {
            if (Company != null)
            {
                _ID = Company.ID;
                _CompanyCode = Company.CompanyCode;
                _CompanyName = Company.CompanyName;
                _CompanyShortName = Company.CompanyShortName;
                _Address = Company.Address;
                _PanNumber = Company.PANNumber;
                _TinNumber = Company.TINNumber;
                _RegistrationNumber = Company.RegistrationNumber;
                _PFNumber = Company.PFNumber;
                _PhoneNumber = Company.PhoneNumber;
                _FinancialStartDate = Company.FinancialStartDate;
                _FinancialEndDate = Company.FinancialEndDate;
                _FinancialName = Company.FinancialName;
                _VoucherStartDate = Company.VoucherStartDate;
                _VoucherEndDate = Company.VoucherEndDate;
                _InvestmentGroupID = Company.InvestmentGroupID;
                _TANNumber = Company.TANNumber;
                _ServiceTaxRegistrationNumber = Company.ServiceTaxRegistrationNumber;
                _Website = Company.Website;
                _Email = Company.Email;
                _ShopEstablishmentNumber = Company.ShopEstablishmentNumber;
                _ESINumber = Company.ESINumber;
                _IsActive = Company.IsActive;
                _CreatedBy = Company.CreatedBy;
                _ModifiedBy = Company.ModifiedBy;
                _CreatedDate = Company.CreatedDate;
                _ModifiedDate = Company.ModifiedDate;
                _IsNew = false;

            }
            else
            {
                _IsNew = true;
            }
        }


        private String SaveCompany()
        {

            Master_Companys Company = new Master_Companys();
            Company.ID = _ID;
            Company.CompanyCode = _CompanyCode;
            Company.CompanyName =_CompanyName;
            Company.CompanyShortName = _CompanyShortName;
            Company.Address = _Address;
            Company.PANNumber = _PanNumber;
            Company.TINNumber = _TinNumber;
            Company.RegistrationNumber =_RegistrationNumber;
            Company.PFNumber =_PFNumber;
            Company.PhoneNumber =_PhoneNumber;
            Company.FinancialStartDate =_FinancialStartDate;
            Company.FinancialEndDate =_FinancialEndDate;
            Company.FinancialName =_FinancialName;
            Company.VoucherStartDate =_VoucherStartDate;
            Company.VoucherEndDate =_VoucherEndDate;
            Company.InvestmentGroupID =_InvestmentGroupID;
            Company.TANNumber =_TANNumber;
            Company.ServiceTaxRegistrationNumber =_ServiceTaxRegistrationNumber;
            Company.Website = _Website;
            Company.Email =_Email;
            Company.ShopEstablishmentNumber =_ShopEstablishmentNumber;
            Company.ESINumber =_ESINumber;
            Company.IsActive = _IsActive;
            Company.ModifiedBy = _ModifiedBy;
            Company.ModifiedDate = DateTime.Now;
            Company.CreatedBy = _CreatedBy;
            Company.CreatedDate = _CreatedDate;

            if (_IsNew)
            {
                Company.CreatedBy = _UpdateBy;
                Company.CreatedDate = DateTime.Now;
                Company.ID = new Master_CompanyBusinessObject().Create(Company);
            }
            else
            {
                Company.ModifiedBy = _UpdateBy;
                Company.ModifiedDate = DateTime.Now;
                Company.ID = _ID;
                new Master_CompanyBusinessObject().Update(Company);
            }

            return String.Empty;
        }

        public String Save()
        {
            String Status = Validate();

            if (Status != String.Empty)
            {
                return Status;
            }

            return SaveCompany();
        }
        private String Validate()
        {
            Master_RelationBusinessObject RelationBO = new Master_RelationBusinessObject();

            //if (_RelationName == String.Empty)
            //{
            //    return HRManagerDefs.RelationMessages.EMPTY_Relation;
            //}
            //else if (RelationBO.IsRelationExists(_RelationName, _ID))
            //{
            //    return HRManagerDefs.RelationMessages.Relation_EXISTS;
            //}
            return String.Empty;
        }


        public Master_Company(int ID)
        {
            Master_Companys Company = new Master_CompanyBusinessObject().GetMaster_Company(ID);
            Update(Company);
        }
        public String DeActivate(int DeActivatedBy)
        {
            _IsActive = false;
            _UpdateBy = DeActivatedBy;
            return SaveCompany();
        }

        public String Activate(int ActivatedBy)
        {
            _IsActive = true;
            _UpdateBy = ActivatedBy;
            return SaveCompany();
        }
        public Master_Company(Master_Companys CompanyName)
        {
            Update(CompanyName);
        }
        public static Master_Company[] GetAllActiveCompany()
        {
            Master_Companys[] CompanyDT = new Master_CompanyBusinessObject().GetAllActiveCompany();
            Master_Company[] Company = new Master_Company[CompanyDT.Length];

            for (int i = 0; i < Company.Length; i++)
            {
                Company[i] = new Master_Company(CompanyDT[i]);
            }

            return Company;
        }
        
        public static Master_Company[] GetAllCompanyDetails()
        {
            Master_Companys[] CompanyDT = new Master_CompanyBusinessObject().GetAllCompanyDetails();
            Master_Company[] Company = new Master_Company[CompanyDT.Length];

            for (int i = 0; i < Company.Length; i++)
            {
                Company[i] = new Master_Company(CompanyDT[i]);
            }

            return Company;
        }

        public static Master_Company[] GetAllInActiveCompany()
        {
            Master_Companys[] CompanyDT = new Master_CompanyBusinessObject().GetAllInActiveCompanyOrderByCompany();

            Master_Company[] Company = new Master_Company[CompanyDT.Length];

            for (int i = 0; i < Company.Length; i++)
            {
                Company[i] = new Master_Company(CompanyDT[i]);
            }

            return Company;
        }


        #region JGridDataObject Members

        public object GetGridData()
        {
            CompanyDetails Companys = new CompanyDetails();

            Companys.ID = _ID;
            Companys.CompanyCode = _CompanyCode;
            Companys.CompanyName = _CompanyName;
            Companys.FinancialYearName = _FinancialName;
            Companys.PAN = _PanNumber;
            Companys.Email = _Email;
            Companys.Status = _IsActive;
            Companys.IsActive = _IsActive;

            return Companys;
        }

        #endregion


      
    }
    public class CompanyDetails
    {
        public int ID;
        public String CompanyName;
        public String CompanyCode;
        public String FinancialYearName;
        public String PAN;
        public String Email;
        public bool IsActive;
        public bool Status;

    }
}
