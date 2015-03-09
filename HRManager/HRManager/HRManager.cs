using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.Entity;
using IRCAKernel;
using IS91.Services;
using IS91.Services.DataBlock;
using System.IO;
using System.Web;
using HRManager.Communication.Response;
using HRManager.Entity.EmployeeLeave;
using HRManager.DTOEXT;
using HRManager.Entity.Recruitment;
using HRManager.DTO;
using HRManager.BusinessObjects;

namespace HRManager
{
    public class HRManager
    {

        #region Menu
        public static String GetMenuString(string rolename)
        {
            return HRMenu.GetMenuString(rolename);
        }
        #endregion

        #region SettingConfiguration
        /// <summary>
        /// Get All SettingConfiguration
        /// </summary>
        /// <returns>Array of the object of SettingConfiguration class</returns>
        public static Setting_Configuration[] GetSettingConfigurations()
        {
            return Setting_Configuration.GetSettingConfiguration();
        }
        public static String UpdateSettingConfigurations(int ID, String ConfigValue, int ModifiedBy)
        {
            try
            {
                Setting_Configuration SettingConfiguration = new Setting_Configuration(ID);

                SettingConfiguration.ID = ID;
                //SettingConfiguration.Name = Name;
                SettingConfiguration.Value = ConfigValue;
                SettingConfiguration.ModifiedBy = ModifiedBy;
                //SettingConfiguration.CreatedDate = CreatedDate;
               // SettingConfiguration.UpdatedBy = UpdatedBy;

                String Status = SettingConfiguration.Save();

                return Status;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.SettingConfigurationMessages.SETTING_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.SettingConfigurationMessages.SETTING_UPDATE_FAILURE;
            }
        }
        #endregion

        #region Designation
        /// <summary>
        /// Return all Designation
        /// </summary>
        /// <returns>Array of the object of Designation class</returns>
        /// 
        
      
        public static Designation[] GetDesignations()
        {
            return Designation.GetAllDesignations();
        }
        public static Designation[] GetAllDesignationForHigher(int ID)
        {
            return Designation.GetAllDesignationForHigher(ID);
        }
        public static Designation GetDesignationInfo(int DesignationID)
        {
            return Designation.GetDesignationInfo(DesignationID);
        }
        /// <summary>
        /// Return all Designation
        /// </summary>
        /// <returns>Array of the object of Designation class</returns>
        public static Designation[] GetInActiveDesignations()
        {
            return Designation.GetAllInActiveDesignations();
        }


        /// <summary>
        /// Return all Designation
        /// </summary>
        /// <returns>Array of the object of Designation class</returns>
        public static Designation[] GetActiveDesignations()
        {
            return Designation.GetActiveDesignations();
        }
        public static Designation[] GetAllActiveDesignationsDetails()
        {
            return Designation.GetAllActiveDesignationsDetails();
        }
        
        /// <summary>
        /// Update Designation
        /// </summary>
        /// <param name="ID">Designation ID</param>
        /// <param name="DesignationName">field contaions Designation Name</param>
        /// <param name="Description">field contaions Description</param>
        /// <param name="IsActive">field contaions Active status.</param>
        /// <param name="UpdatedBy">field contain the user id who update Designation</param>
        /// <returns>empty string for success and error message for failure</returns>
        public static String UpdateDesignation(int ID, String DesignationName,bool IsActive, int UpdatedBy, int RoleID)
        {
            try
            {

                Designation Designation = new Designation(ID);
                Designation.DesignationName = DesignationName;
                
                
                Designation.RoleID = RoleID;
                
                Designation.UpdatedBy = UpdatedBy;
                Designation.IsActive = IsActive;
                String Status = Designation.Save();
                return Status;

            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.DesignationMessages.DESIGNATION_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.DesignationMessages.DESIGNATION_UPDATE_FAILURE;
            }
        }
        /// <summary>
        /// Activate Designation by ID
        /// </summary>
        /// <param name="ID">field contain Designation ID</param>
        /// <param name="ActivatedBy">field contain the user id who Activate Designation</param>
        /// <returns>empty string for success and error message for failure</returns>

        public static String UpdateAcDCDesignation(int ID, bool IsActive)
        {
            try
            {
                Designation hlid = new Designation(ID);
                hlid.ID = ID;
                hlid.IsActive = IsActive;
                String savehlid = hlid.Save();
                return savehlid;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.DesignationMessages.DESIGNATION_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.DesignationMessages.DESIGNATION_UPDATE_FAILURE;
            }
        }
        #endregion

        #region Department
        /// <summary>
        /// Get All Departments
        /// </summary>
        /// <returns>Array of the object of Department class</returns>
        public static Department[] GetDepartments()
        {
            return Department.GetAllDepartments();
        }
        /// <summary>
        /// Get All Departments
        /// </summary>
        /// <returns>Array of the object of Department class</returns>
        public static Department[] GetBranchDepartments(int BranchID)
        {
            return Department.GetAllBranchDepartments(BranchID);
        }

        /// <summary>
        /// Update Department of given ID
        /// </summary>
        /// <param name="ID">field contain Department ID</param>
        /// <param name="DepartmentName">field contain Department Name</param>
        /// <param name="Description">field contain Department Description</param>
        /// <param name="IsActive">field contaions Active status.</param>
        /// <param name="UpdatedBy">field contain the user id who update Department</param>
        /// <returns>empty string for success and error message for failure</returns>
        public static String UpdateDepartment(int ID, String DepartmentName, int UpdatedBy, int ParentID, int HOD, bool IsHR, bool IsFinance)
        {
            try
            {
                Department Department = new Department(ID - 1);
                Department.DepartmentName = DepartmentName;
                Department.UpdatedBy = UpdatedBy;
                Department.HOD = HOD;
                Department.IsHR = IsHR;
                Department.IsFinance = IsFinance;
                if (ID != ParentID + 1) { Department.ParentID = ParentID; }
                String Status = Department.Save();

                return Status;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.DepartmentMessages.DEPARTMENT_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.DepartmentMessages.DEPARTMENT_UPDATE_FAILURE;
            }
        }


        #endregion

        #region EMPLOYEE TYPE

        /// <summary>
        /// Get All EmployeeTypes
        /// </summary>
        /// <returns>Array of the object of EmployeeType class</returns>
        public static EmployeeType[] GetEmployeeTypes()
        {
            return EmployeeType.GetAllEmployeeTypes();
        }
        /// <summary>
        /// Deactivate EmployeeType by ID
        /// </summary>
        /// <param name="ID">integer type</param>
        /// <param name="DeactivatedBy">field contain the user id who deactivated EmployeeType</param>
        /// <returns>empty string for success and error message for failure</returns>
        public static String DeActivateEmployeeType(int ID, int DeactivatedBy)
        {
            try
            {
                return new EmployeeType(ID).DeActivate(DeactivatedBy);
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.EmployeeTypeMessages.EMPLOYEETYPE_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.EmployeeTypeMessages.EMPLOYEETYPE_UPDATE_FAILURE;
            }
        }

        /// <summary>
        /// Activate EmployeeType by ID
        /// </summary>
        /// <param name="ID">field contain EmployeeType ID</param>
        /// <param name="ActivatedBy">field contain the user id who activated EmployeeType</param>
        /// <returns>empty string for success and error message for failure</returns>
        public static String ActivateEmployeeType(int ID, int ActivatedBy)
        {
            try
            {
                return new EmployeeType(ID).Activate(ActivatedBy);
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.EmployeeTypeMessages.EMPLOYEETYPE_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.EmployeeTypeMessages.EMPLOYEETYPE_UPDATE_FAILURE;
            }
        }
        public static EmployeeType[] GetInActiveEmployeeType()
        {
            return EmployeeType.GetAllInActiveEmployeeType();
        }
        /// <summary>
        /// Update EmployeeType of given ID
        /// </summary>
        /// <param name="ID">field contain EmployeeType ID</param>
        /// <param name="EmployeeTypeName">field contain EmployeeType Name</param>
        /// <param name="Description">field contain EmployeeType Description</param>
        /// <param name="IsActive">field contaions Active status.</param>
        /// <param name="UpdatedBy">field contain the user id who update EmployeeType</param>
        /// <returns>empty string for success and error message for failure</returns>
        //public static String UpdateEmployeeType(int ID, String Name, String MinDurationMonth, bool IsActive, bool IsService, bool IsPermanent, int UpdatedBy)
         public static String UpdateEmployeeType(int ID, String Name,bool IsActive,int UpdatedBy)
        {
            try
            {
                EmployeeType EmployeeType = new EmployeeType(ID);

                EmployeeType.Name = Name;
                //EmployeeType.MinDurationMonth = MinDurationMonth;
                EmployeeType.UpdatedBy = UpdatedBy;
                //EmployeeType.IsService = IsService;
                EmployeeType.IsActive = IsActive;
                //EmployeeType.IsPermanent = IsPermanent;

                String Status = EmployeeType.Save();

                return Status;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.EmployeeTypeMessages.EMPLOYEETYPE_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.EmployeeTypeMessages.EMPLOYEETYPE_UPDATE_FAILURE;
            }
        }
        #endregion

        # region Relation
        /// <summary>
        /// Get All Relations
        /// </summary>
        /// <returns>Array of the object of Relation class</returns>
        public static Relation[] GetRelationDetails()
        {
            return Relation.GetAllActiveRelation();
        }

        public static String ActivateRelation(int ID, int ActivatedBy)
        {
            try
            {
                return new Relation(ID).Activate(ActivatedBy);
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.RelationMessages.Relation_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.RelationMessages.Relation_UPDATE_FAILURE;
            }
        }

        public static String DeActivateRelation(int ID, int DeactivatedBy)
        {
            try
            {
                return new Relation(ID).DeActivate(DeactivatedBy);
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.RelationMessages.Relation_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.RelationMessages.Relation_UPDATE_FAILURE;
            }
        }

        public static String UpdateRelation(int ID, String RelationName, bool IsActive, int UpdatedBy)
        {
            try
            {
                Relation Relation = new Relation(ID);

                Relation.RelationName = RelationName;
                Relation.IsActive = IsActive;
                Relation.UpdatedBy = UpdatedBy;
                String Status = Relation.Save();

                return Status;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.RelationMessages.Relation_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.RelationMessages.Relation_UPDATE_FAILURE;
            }
        }

        #endregion
        //kartyek 14.02.2015 Company details
        #region Company
        public static Master_Company[] GetAllCompanyDetails()
        {
            return Master_Company.GetAllCompanyDetails();

        }
        public static Master_Company[] GetCompanyDetails()
        {
            return Master_Company.GetAllActiveCompany();
        }
        public static String ActivateCompany(int ID, int ActivatedBy)
        {
            try
            {
                return new Master_Company(ID).Activate(ActivatedBy);
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.CompanyMessages.COMPANY_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.CompanyMessages.COMPANY_UPDATE_FAILURE;
            }
        }

        public static String DeActivateCompany(int ID, int DeactivatedBy)
        {
            try
            {
                return new Master_Company(ID).DeActivate(DeactivatedBy);
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.CompanyMessages.COMPANY_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.CompanyMessages.COMPANY_UPDATE_FAILURE;
            }
        }



        public static String UpdateCompany(int ID, String CompanyCode, String CompanyName, String CompanyShortName, String Address, String PANNumber, String TINNumber, String RegistrationNumber, String PFNumber, String PhoneNumber, DateTime FinancialStartDate, DateTime FinancialEndDate, String FinancialName, DateTime VoucherStartDate, DateTime VoucherEndDate, int InvestmentGroupID, String TANNumber, String ServiceTaxRegistrationNumber, String Website, String Email, String ShopEstablishmentNumber, String ESINumber, bool IsActive, int UpdatedBy)
        {
            try
            {
                Master_Company Company = new Master_Company(ID);

                Company.CompanyCode = CompanyCode;
                Company.CompanyName = CompanyName;
                Company.CompanyShortName = CompanyShortName;
                Company.Address = Address;
                Company.PanNumber = PANNumber;
                Company.TinNumber = TINNumber;
                Company.RegistrationNumber = RegistrationNumber;
                Company.PFNumber = PFNumber;
                Company.PhoneNumber = PhoneNumber;
                Company.FinancialStartDate = FinancialStartDate;
                Company.FinancialEndDate = FinancialEndDate;
                Company.FinancialName = FinancialName;
                Company.VoucherStartDate = VoucherStartDate;
                Company.VoucherEndDate = VoucherEndDate;
                Company.InvestmentGroupID = InvestmentGroupID;
                Company.TANNumber = TANNumber;
                Company.ServiceTaxRegistrationNumber = ServiceTaxRegistrationNumber;
                Company.Website = Website;
                Company.Email = Email;
                Company.ShopEstablishmentNumber = ShopEstablishmentNumber;
                Company.ESINumber = ESINumber;
                Company.IsActive = IsActive;
                Company.UpdatedBy = UpdatedBy;
                String Status = Company.Save();

                return Status;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.RelationMessages.Relation_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.InvestmentMessages.INVESTMENT_UPDATE_FAILURE;
            }
        }
        #endregion
        //kartyek 13.02.2015 InvestmentGroup
        # region Investment
        
        public static InvestmentGroup[] GetAllInvestmentGroupDetails()
        {
            return InvestmentGroup.GetAllInvestmentGroupDetails();

        }
        public static InvestmentGroup[] GetInvestmentDetails()
        {
            return InvestmentGroup.GetAllActiveInvestmentGroup();
        }

        public static String ActivateInvestment(int ID, int ActivatedBy)
        {
            try
            {
                return new InvestmentGroup(ID).Activate(ActivatedBy);
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.InvestmentMessages.INVESTMENT_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.InvestmentMessages.INVESTMENT_UPDATE_FAILURE;
            }
        }

        public static String DeActivateInvestment(int ID, int DeactivatedBy)
        {
            try
            {
                return new InvestmentGroup(ID).DeActivate(DeactivatedBy);
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.RelationMessages.Relation_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.InvestmentMessages.INVESTMENT_UPDATE_FAILURE;
            }
        }

        public static String UpdateInvestment(int ID, String InvestmentGroupName, bool IsActive, int UpdatedBy)
        {
            try
            {
                InvestmentGroup Investment = new InvestmentGroup(ID);

                Investment.InvestmentGroupName = InvestmentGroupName;
                Investment.IsActive = IsActive;
                Investment.UpdatedBy = UpdatedBy;
                String Status = Investment.Save();

                return Status;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.RelationMessages.Relation_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.InvestmentMessages.INVESTMENT_UPDATE_FAILURE;
            }
        }
        #endregion



        //kartyek 17.02.2015 ProjectInfo/Details


        //kartyek 14.02.2015 Project details
        #region ProjectDetails
        public static ProjectInfo[] GetAllProjectDetails()
        {
            return ProjectInfo.GetAllProjectDetails();

        }
        public static ProjectInfo[] GetProjectDetails()
        {
            return ProjectInfo.GetAllActiveProject();
        }
        public static String ActivateProjectInfo(int ID, int ActivatedBy)
        {
            try
            {
                return new ProjectInfo(ID).Activate(ActivatedBy);
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.ProjectInfoMessages.PROJECTINFO_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.ProjectInfoMessages.PROJECTINFO_UPDATE_FAILURE;
            }
        }

        public static String DeActivateProjectInfo(int ID, int DeactivatedBy)
        {
            try
            {
                return new ProjectInfo(ID).DeActivate(DeactivatedBy);
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.ProjectInfoMessages.PROJECTINFO_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.ProjectInfoMessages.PROJECTINFO_UPDATE_FAILURE;
            }
        }



        public static String UpdateProjectInfo(int ID, int CompanyID, String ProjectGroup, String Projecttype, String Address, String Projectcode, String ProjectName, String contractown, bool IsActive, int UpdatedBy)
        {
            try
            {
                ProjectInfo ProjectInfo = new ProjectInfo(ID);

                ProjectInfo.CompanyID = CompanyID;
                ProjectInfo.ProjectCode = Projectcode;
                ProjectInfo.ProjectGroup = ProjectGroup;
                ProjectInfo.ProjectType = Projecttype;
                ProjectInfo.Address = Address;
                ProjectInfo.Contractown = contractown;
                ProjectInfo.IsActive = IsActive;
                ProjectInfo.UpdatedBy = UpdatedBy;
                String Status = ProjectInfo.Save();

                return Status;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.ProjectInfoMessages.PROJECTINFO_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.ProjectInfoMessages.PROJECTINFO_UPDATE_FAILURE;
            }
        }
        #endregion




        #region Role Master
        public static RoleMaster[] GetRoles()
        {
            return RoleMaster.GetAllRoles();

        }
        public static RoleMaster[] GetAllTypeRoles()
        {
            return RoleMaster.GetAllRolesDetails();

        }
        public static String ActivateRole(int ID, int ActivatedBy)
        {
            try
            {
                return new RoleMaster(ID).Activate(ActivatedBy);
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.RoleMessages.ROLE_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.RoleMessages.ROLE_UPDATE_FAILURE;
            }
        }
        public static String DeActivateRole(int ID, int DeActivatedBy)
        {
            try
            {
                return new RoleMaster(ID).DeActivate(DeActivatedBy);
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.DesignationMessages.DESIGNATION_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.DesignationMessages.DESIGNATION_UPDATE_FAILURE;
            }
        }


        public static String GetInActiveRole(int ID, int DeactivatedBy)
        {
            try
            {
                return new RoleMaster(ID).DeActivate(DeactivatedBy);
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.DesignationMessages.DESIGNATION_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.DesignationMessages.DESIGNATION_UPDATE_FAILURE;
            }
        }
        public static RoleMaster[] GetInActiveRoles()
        {
            return RoleMaster.GetAllInActiveRoles();
        }
        public static String UpdateRole(int ID, String RoleName, String Description, bool IsActive, int UpdatedBy, string Reports, string Permissions)
        {
            try
            {
                RoleMaster Role = new RoleMaster(ID);

                Role.RoleName = RoleName;
                Role.Description = Description;
                Role.IsActive = IsActive;
                Role.UpdatedBy = UpdatedBy;

                String Status = Role.Save(Reports, Permissions);

                return Status;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.RoleMessages.ROLE_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.RoleMessages.ROLE_UPDATE_FAILURE;
            }
        }

        public static EmpRoleDashboardReports[] GetRoleWiseDashboardReports(int RoleID)
        {
            return EmpRoleDashboardReports.GetRoleWiseDashboardReports(RoleID);
        }
        public static Permission[] GetAllPermissions(int RoleID)
        {
            return Permission.GetAllPermissions(RoleID);
        }
        public static DashBoardReport[] GetAllDashBoardReports()
        {
            return DashBoardReport.GetAllDashBoardReports();
        }

        #endregion

        #region Holiday Master

        public static Holidays[] GetAllHolidayDetails()
        {
            return Holidays.GetAllHolidayDetails();
        }

        public static Holidays[] GetHoliday()
        {
            return Holidays.GetHolidays();

        }
        public static Holidays[] GetInactiveholidays()
        {
            return Holidays.GetInActiveHolidays();

        }
        public static String UpdateHoliday(int ID, int LocationID, String HolidayName, DateTime HolidayDate, String Description, String Status, int RequestingTo,int ModifiedBy, DateTime CreatedDate, bool IsActive)
        {
            try
            {

                Holidays hlid = new Holidays(ID);
                hlid.LocationID  = LocationID;
                hlid.HolidayName = HolidayName;
                hlid.HolidayDate = HolidayDate;
                hlid.Description = Description;
                hlid.Status = Status;
                hlid.RequestingTo = RequestingTo;
                hlid.ModifiedBy = ModifiedBy;
                hlid.CreatedDate = CreatedDate;
                hlid.IsActive = IsActive;
                String result = hlid.Save();
                return result;

            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.HolidaysMessages.HOLIDAY_UPDATE_SUCCESS, ID.ToString())
                    );
                return HRManagerDefs.HolidaysMessages.HOLIDAY_UPDATE_FAILURE;
            }
        }
        public static String UpdateAcDCholiday(int ID, bool IsActive)
        {
            try
            {
                Holidays hlid = new Holidays(ID);
                hlid.ID = ID;
                hlid.IsActive = IsActive;
                String savehlid = hlid.Save();
                return savehlid;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.HolidaysMessages.HOLIDAY_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.HolidaysMessages.HOLIDAY_UPDATE_FAILURE;
            }
        }
        #endregion

        #region Manufacturer
        public static Manufacturer[] GetAllManufacturerDetails()
        {
            return Manufacturer.GetAllManufacturerDetails();
        }
        public static Manufacturer[] Getallmanufacturer()
        {
            return Manufacturer.GetManufacturers();

        }
        public static Manufacturer[] GetInactivemanufacturer()
        {
            return Manufacturer.GetInActiveManufacturers();

        }
        public static String UpdateaManufacturer(int ID, String ManufacturerName, String Description, int ModifiedBy, DateTime CreatedDate, bool IsActive)
        {
            try
            {

                Manufacturer IVT = new Manufacturer(ID);
                IVT.ManufacturerName = ManufacturerName;
                IVT.Description = Description;
                IVT.ModifiedBy = ModifiedBy;
                IVT.CreatedDate = CreatedDate;
                IVT.IsActive = IsActive;
                String Status = IVT.Save();
                return Status;

            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.ManufacturerMessages.MANUFACTURER_UPDATE_SUCCESS, ID.ToString())
                    );
                return HRManagerDefs.ManufacturerMessages.MANUFACTURER_UPDATE_FAILURE;
            }
        }
        public static String UpdateAcDCManufacturer(int ID, bool IsActive, int EmpID)
        {
             try
            {
                Manufacturer manu = new Manufacturer(ID);
               
                String manufacturer ;
                
                if (IsActive)
                {
                    manufacturer = manu.Activate(EmpID);
                }
                else
                {
                    manufacturer = manu.DeActivate(EmpID);
                }
                return manufacturer;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.ManufacturerMessages.MANUFACTURER_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.ManufacturerMessages.MANUFACTURER_UPDATE_FAILURE;
            }
        }

        #endregion

        #region Candidatecompetency
        public static Candidate_Competency[] GetAllCandidatecompetencyDetails()
        {
            return Candidate_Competency.GetAllCandidatecompetencyDetails();
        }
        public static Candidate_Competency[] GetAllCandidatecompetency()
        {
            return Candidate_Competency.GetCandidate_Competency();

        }
        public static Candidate_Competency[] GetInactiveCandidatecompetency()
        {
            return Candidate_Competency.GetInActiveCandidate_Competency();

        }
        public static String UpdateCandidate_Competency(int ID, String Candidatecompetency, String Description, int ModifiedBy, DateTime CreatedDate, bool IsActive)
        {
            try
            {

                Candidate_Competency IVT = new Candidate_Competency(ID);
                IVT.CompetencyName = Candidatecompetency;
                IVT.Description = Description;
                IVT.ModifiedBy = ModifiedBy;
                IVT.CreatedDate = CreatedDate;
                IVT.IsActive = IsActive;
                String Status = IVT.Save();
                return Status;

            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.candidatecompetencyMessages.CANDIDATECOMPETANCY_UPDATE_SUCCESS, ID.ToString())
                    );
                return HRManagerDefs.candidatecompetencyMessages.CANDIDATECOMPETANCY_UPDATE_FAILURE;
            }
        }
        public static String UpdateAcDCCandidate_Competency(int ID, bool IsActive)
        {
            try
            {
                Candidate_Competency IVT = new Candidate_Competency(ID);
                IVT.ID = ID;
                IVT.IsActive = IsActive;
                if (IVT.CheckReference() == String.Empty)
                {
                    String saveivt = IVT.Save();
                    return saveivt;
                }
                else
                    return IVT.CheckReference();
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.candidatecompetencyMessages.CANDIDATECOMPETANCY_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.candidatecompetencyMessages.CANDIDATECOMPETANCY_UPDATE_FAILURE;
            }
        }

        #endregion

        #region AssetCategory
        public static AssetCategory[] GetAllAssetDetails()
        {
            return AssetCategory.GetAllAssetDetails();
        }
        public static AssetCategory[] GetAllAssetCategory()
        {
            return AssetCategory.GetAssetCategory();

        }
        public static AssetCategory[] GetInactiveAssetCategory()
        {
            return AssetCategory.GetInActiveAssetCategory();

        }
        public static String UpdateAssetCategory(int ID, String AssetCategories, String Description, int ModifiedBy, DateTime CreatedDate, bool IsActive)
        {
            try
            {

                AssetCategory IVT = new AssetCategory(ID);
                IVT.AssetCategories = AssetCategories;
                IVT.Description = Description;
                IVT.ModifiedBy = ModifiedBy;
                IVT.CreatedDate = CreatedDate;
                IVT.IsActive = IsActive;
                String Status = IVT.Save();
                return Status;

            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.AssetCategoryMessages.ASSET_CATEGORY_UPDATE_SUCCESS, ID.ToString())
                    );
                return HRManagerDefs.AssetCategoryMessages.ASSET_CATEGORY_UPDATE_FAILURE;
            }
        }
        public static String UpdateAcDCAssetCategory(int ID, bool IsActive, int EmpID)
        {
             try
            {
                AssetCategory asset = new AssetCategory(ID);
               
                String saveasset ;
                
                if (IsActive)
                {
                    saveasset = asset.Activate(EmpID);
                }
                else
                {
                    saveasset = asset.DeActivate(EmpID);
                }
                return saveasset;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.AssetCategoryMessages.ASSET_CATEGORY_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.AssetCategoryMessages.ASSET_CATEGORY_UPDATE_FAILURE;
            }
        }

        #endregion

        #region AssetSubCategory
        public static AssetSubCategory[] GetAllAssetSubDetails()
        {
            return AssetSubCategory.GetAllAssetSubDetails();
        }
        public static AssetSubCategory[] GetAllAssetSubCategory()
        {
            return AssetSubCategory.GetAssetSubCategory();

        }
        public static AssetSubCategory[] GetInactiveAssetSubCategory()
        {
            return AssetSubCategory.GetInActiveAssetSubCategory();

        }
        public static String UpdateAssetSubCategory(int ID, String AssetSubCategory, String Description, int ModifiedBy, DateTime CreatedDate, bool IsActive)
        {
            try
            {

                AssetSubCategory IVT = new AssetSubCategory(ID);
                IVT.AssetSubCategories = AssetSubCategory;
                IVT.Description = Description;
                IVT.ModifiedBy = ModifiedBy;
                IVT.CreatedDate = CreatedDate;
                IVT.IsActive = IsActive;
                String Status = IVT.Save();
                return Status;

            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.AssetSubCategoryMessages.ASSET_SUB_CATEGORY_UPDATE_SUCCESS, ID.ToString())
                    );
                return HRManagerDefs.AssetSubCategoryMessages.ASSET_SUB_CATEGORY_UPDATE_FAILURE;
            }
        }
        public static String UpdateAcDCAssetSubCategory(int ID, bool IsActive, int EmpID)
        {
             try
            {
                AssetSubCategory assetsub = new AssetSubCategory(ID);
               
                String assetsubcat ;
                
                if (IsActive)
                {
                    assetsubcat = assetsub.Activate(EmpID);
                }
                else
                {
                    assetsubcat = assetsub.DeActivate(EmpID);
                }
                return assetsubcat;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.AssetSubCategoryMessages.ASSET_SUB_CATEGORY_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.AssetSubCategoryMessages.ASSET_SUB_CATEGORY_UPDATE_FAILURE;
            }
        }

        #endregion

        #region InterViewType
        public static InterView_Type[] GetInterviweTypeDetails()
        {
            return InterView_Type.GetAllInterviewTypes();
        }
        public static InterView_Type[] GetInterviewtype()
        {
            return InterView_Type.GetInterviewTypes();

        }
        public static InterView_Type[] GetInactiveInterviewtype()
        {
            return InterView_Type.GetInActiveInterviewTypes();

        }
        public static String UpdateInterViewType(int ID, String InterviewType, String Description, int ModifiedBy, DateTime CreatedDate, bool IsActive)
        {
            try
            {

                InterView_Type IVT = new InterView_Type(ID);
                IVT.InterviewType = InterviewType;
                IVT.Description = Description;
                IVT.ModifiedBy = ModifiedBy;
                IVT.CreatedDate = CreatedDate;
                IVT.IsActive = IsActive;
                String Status = IVT.Save();
                return Status;

            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.InterviewTypesMessages.INTERVIEWTYPE_UPDATE_SUCCESS, ID.ToString())
                    );
                return HRManagerDefs.InterviewTypesMessages.INTERVIEWTYPE_UPDATE_FAILURE;
            }
        }
        public static String UpdateAcDCInterviewType(int ID, bool IsActive)
        {
            try
            {
                InterView_Type IVT = new InterView_Type(ID);
                IVT.ID = ID;
                IVT.IsActive = IsActive;
                String saveivt = IVT.Save();
                return saveivt;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.InterviewTypesMessages.INTERVIEWTYPE_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.InterviewTypesMessages.INTERVIEWTYPE_UPDATE_FAILURE;
            }
        }

        #endregion

        #region MaritalStatus
        public static Master_MaritialStatus[] GetMaritalDetails()
        {
            return Master_MaritialStatus.GetAllMaritalStatus();
        }
        public static Master_MaritialStatus[] GetMaritalStatus()
        {
            return Master_MaritialStatus.GetMaritalStatus();

        }
        public static Master_MaritialStatus[] GetInactiveMaritalStatus()
        {
            return Master_MaritialStatus.GetInActiveMaritalStatus();

        }
        public static String UpdateMaritialStatus(int ID, String MaritalStatus, int ModifiedBy, DateTime CreatedDate, bool IsActive)
        {
            try
            {

                Master_MaritialStatus IVT = new Master_MaritialStatus(ID);
                IVT.MaritalStatus = MaritalStatus;
                IVT.ModifiedBy = ModifiedBy;
                IVT.CreatedDate = CreatedDate;
                IVT.IsActive = IsActive;
                String Status = IVT.Save();
                return Status;

            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.MaritalStatusMessages.MARITALSTATUS_UPDATE_SUCCESS, ID.ToString())
                    );
                return HRManagerDefs.MaritalStatusMessages.MARITALSTATUS_UPDATE_FAILURE;
            }
        }
        public static String UpdateAcDCMaritalStatus(int ID, bool IsActive,int EmpID)
        {
            try
            {
               
                Master_MaritialStatus IVT = new Master_MaritialStatus(ID);
                String savemaritalstatus;

                if (IsActive)
                {
                    savemaritalstatus = IVT.Activate(EmpID);
                }
                else
                {
                    savemaritalstatus = IVT.DeActivate(EmpID);
                }
                return savemaritalstatus;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.MaritalStatusMessages.MARITALSTATUS_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.MaritalStatusMessages.MARITALSTATUS_UPDATE_FAILURE;
            }
        }

        #endregion

        #region country Master
        public static Country[] Getcountry()
        {
            return Country.Getcountries();

        }
        public static Country[] GetInactivecountry()
        {
            return Country.GetInActivecountries();

        }
        public static String UpdateCountry(int ID, String CountryCode, String CountryName, int ModifiedBy, DateTime CreatedDate, bool IsActive)
        {
            try
            {

                Country ctry = new Country(ID);
                ctry.CountryCode = CountryCode;
                ctry.CountryName = CountryName;
                ctry.ModifiedBy = ModifiedBy;
                ctry.CreatedDate = CreatedDate;
                ctry.IsActive = IsActive;
                String Status = ctry.Save();
                return Status;

            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.CountrytMessages.COUNTRY_UPDATE_SUCCESS, ID.ToString())
                    );
                return HRManagerDefs.CountrytMessages.COUNTRY_UPDATE_FAILURE;
            }
        }

        public static String UpdateAcDCcountry(int ID, bool IsActive,int EmpID)
        {
            try
            {
                Country ctry = new Country(ID);
               
                String savectry ;
                
                if (IsActive)
                {
                    savectry=ctry.Activate(EmpID);
                }
                else
                {
                    savectry=ctry.DeActivate(EmpID);
                }
                return savectry;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.CountrytMessages.COUNTRY_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.CountrytMessages.COUNTRY_UPDATE_FAILURE;
            }
        }

        #endregion

        # region Relation
        /// <summary>
        /// Get All Relation
        /// </summary>
        /// <returns>Array of the object of Relation class</returns>
        public static Relation[] GetRelations()
        {
            return Relation.GetAllActiveRelation();

        }
        public static Relation[] GetAllRelationDetails()
        {
            return Relation.GetAllRelationDetails();

        }
      
        public static Relation[] GetInActiveRelation()
        {
            return Relation.GetAllInActiveRelation();
        }
        ///// <summary>
        ///// Update Role of given ID
        ///// </summary>
        ///// <param name="ID">field contain Role ID</param>
        ///// <param name="ZoneName">field contain Role Name</param>
        ///// <param name="Description">field contain Role Description</param>
        ///// <param name="IsActive">field contaions Active status.</param>
        ///// <param name="UpdatedBy">field contain the user id who update Role</param>
        ///// <returns>empty string for success and error message for failure</returns>
        //public static String UpdateRole(int ID, String RoleName, String Description, bool IsActive)
        //{
        //    try
        //    {
        //        Role Role = new Role(ID);

        //        Role.RoleName = RoleName;
        //        Role.Description = Description;
        //        Role.IsActive = IsActive;

        //        String Status = Role.Save();

        //        return Status;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRManagerDefs.RoleMessages.Role_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRManagerDefs.RoleMessages.Role_UPDATE_FAILURE;
        //    }
        //}

        ///// <summary>
        ///// Activate Role by ID
        ///// </summary>
        ///// <param name="ID">field contain Role ID</param>
        ///// <param name="ActivatedBy">field contain the user id who activated Role</param>
        ///// <returns>empty string for success and error message for failure</returns>
        //public static String ActivateRole(int ID, int ActivatedBy)
        //{
        //    try
        //    {
        //        return new Role(ID).Activate(ActivatedBy);
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRManagerDefs.RoleMessages.Role_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRManagerDefs.RoleMessages.Role_UPDATE_FAILURE;
        //    }
        //}
        ///// <summary>
        ///// Deactivate Role by ID
        ///// </summary>
        ///// <param name="ID">integer type</param>
        ///// <param name="DeactivatedBy">field contain the user id who deactivated Role</param>
        ///// <returns>empty string for success and error message for failure</returns>
        //public static String DeActivateRole(int ID, int DeactivatedBy)
        //{
        //    try
        //    {
        //        return new Role(ID).DeActivate(DeactivatedBy);
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRManagerDefs.RoleMessages.Role_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRManagerDefs.RoleMessages.Role_UPDATE_FAILURE;
        //    }
        //}

        //public static Role[] GetAllRoleNamesDetails()
        //{
        //    return Role.GetAllRoles();
        //}


        #endregion

        #region Leave
        ///// <summary>
        ///// Return all Designation
        ///// </summary>
        ///// <returns>Array of the object of Designation class</returns>
        public static Leave[] GetLeaves()
        {
            return Leave.GetAllLeaves();
        }

        ///// <summary>
        ///// Return all Designation
        ///// </summary>
        ///// <returns>Array of the object of Designation class</returns>
        public static Leave[] GetInActiveLeaves()
        {
            return Leave.GetAllInActiveLeaves();
        }
        /// <summary>
        /// Return all Designation
        /// </summary>
        /// <returns>Array of the object of Designation class</returns>
        public static Leave[] GetActiveLeaves()
        {
            return Leave.GetActiveLeaves();
        }
        /// <summary>
        /// Update Leaves
        /// </summary>
        /// <param name="ID">Designation ID</param>
        /// <param name="DesignationName">field contaions Designation Name</param>
        /// <param name="Description">field contaions Description</param>
        /// <param name="IsActive">field contaions Active status.</param>
        /// <param name="UpdatedBy">field contain the user id who update Designation</param>
        /// <returns>empty string for success and error message for failure</returns>
        public static String UpdateLeave(int ID, string LeaveType, bool IsActive, int UpdatedBy)
        {
            try
            {
                Leave Leave = new Leave(ID);

                Leave.LeaveType = LeaveType;
                Leave.UpdatedBy = UpdatedBy;
                Leave.IsActive = IsActive;

                String Status = Leave.Save();

                return Status;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.LeaveMessages.LEAVE_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.LeaveMessages.LEAVE_UPDATE_FAILURE;
            }
        }

        ///// <summary>
        ///// Return all Designation
        ///// </summary>
        ///// <returns>Array of the object of Designation class</returns>
        //public static Leave[] GetActiveLeaves()
        //{
        //    return Leave.GetActiveLeaves();
        //}
        ///// <summary>
        ///// Update Designation
        ///// </summary>
        ///// <param name="ID">Designation ID</param>
        ///// <param name="DesignationName">field contaions Designation Name</param>
        ///// <param name="Description">field contaions Description</param>
        ///// <param name="IsActive">field contaions Active status.</param>
        ///// <param name="UpdatedBy">field contain the user id who update Designation</param>
        ///// <returns>empty string for success and error message for failure</returns>
        //public static String UpdateLeave(int ID, string LeaveType, bool IsActive, int UpdatedBy)
        //{
        //    try
        //    {
        //        Leave Leave = new Leave(ID);

        //        Leave.LeaveType = LeaveType;
        //        Leave.UpdatedBy = UpdatedBy;
        //        Leave.IsActive = IsActive;

        //        String Status = Leave.Save();

        //        return Status;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRManagerDefs.LeaveMessages.LEAVE_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRManagerDefs.LeaveMessages.LEAVE_UPDATE_FAILURE;
        //    }
        //}
        ///// <summary>
        ///// Activate Designation by ID
        ///// </summary>
        ///// <param name="ID">field contain Designation ID</param>
        ///// <param name="ActivatedBy">field contain the user id who Activate Designation</param>
        ///// <returns>empty string for success and error message for failure</returns>
        public static String ActivateLeave(int ID)
        {
            try
            {
                return new Leave(ID).Activate(ID);
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.LeaveMessages.LEAVE_UPDATE_FAILURE, ID.ToString()));
                return HRManagerDefs.LeaveMessages.LEAVE_UPDATE_FAILURE;
            }
        }
        ///// <summary>
        ///// DeActivate Designation by ID
        ///// </summary>
        ///// <param name="ID">field contain Designation ID</param>
        ///// <param name="DeactivatedBy">field contain the user id who Deactivated Designation</param>
        ///// <returns>empty string for success and error message for failure</returns>
        public static String DeActivateLeave(int ID)
        {
            try
            {
                bool leaveGradeExists = false;
                string retStatus;

        //        //check if the ID is referenced in LEave_grade.                
                //leaveGradeExists = LeaveEmployeeType.LeaveEmployeeTypeExistsForLeaveId(ID);

                if (!leaveGradeExists)
                {
                    //return new Leave(ID).DeActivate(ID);
                    Leave entityLeave = new Leave(ID);
                    retStatus = entityLeave.DeActivate(ID);
                }
                else
                {
                    retStatus = "Cannot deactivate Leave. Active LeaveGrades still exist for this Leave type.";

                    //retStatus = "The selected Loan already referred,you cannot deactivated";
                }

                return retStatus;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.LeaveMessages.LEAVE_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.LeaveMessages.LEAVE_UPDATE_FAILURE;
            }
        }

        #endregion

        # region Location
        public static Location[] GetCountryLocation(int countryId)
        {
            return Location.GetCountryLocations(countryId);
        }

        public static Location[] GetLocation()
        {
            return Location.GetAllLocation();
        }

        public static Location[] GetInActiveLocation()
        {
            return Location.GetAllInActiveLocations();
        }
        
        public static String UpdateLocation(int ID, String LocationName, int CountryID, int UpdatedBy, bool IsActive)
        {
            try
            {
                Location Location = new Location(ID);
                Location.LocationName = LocationName;              
                Location.CountryID = CountryID;
                Location.UpdatedBy = UpdatedBy;
                Location.IsActive = IsActive;
                String Status = Location.Save();

                return Status;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.LocationMessages.LOCATION_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.LocationMessages.LOCATION_UPDATE_FAILURE;
            }
        }

        public static String UpdateAcDCLocation(int ID, bool IsActive)
        {
            try
            {
                Location hlid = new Location(ID);
                hlid.ID = ID;
                hlid.IsActive = IsActive;
                String savehlid = hlid.Save();
                return savehlid;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.LocationMessages.LOCATION_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.LocationMessages.LOCATION_UPDATE_FAILURE;
            }
        }
        #endregion

        public static Country[] GetCountryDetails()
        {
            return Country.GetAllCountry();
        }

        #region Consultant   

        public static ConsultantEntity[] GetAllConsultantsDetails()
        {
            return ConsultantEntity.GetAllConsultantsDetails();
        }
        public static ConsultantEntity[] GetConsultantDetails()
        {
            return ConsultantEntity.GetAllConsultants();
        }

        public static ConsultantEntity[] GetInActiveConsultant()
        {
            return ConsultantEntity.GetAllInActiveConsultants();
        }

        public static String UpdateConsultant(int ID, String ConsultantName, String ContactPerson, String TelephoneNo, String EmailID, String Address, int UpdatedBy, bool IsActive, int DesignationID)
        {
            try
            {
                ConsultantEntity Consultant = new ConsultantEntity(ID);
                Consultant.DesignationID = DesignationID;
                Consultant.ConsultantName = ConsultantName;
                Consultant.ContactPerson = ContactPerson;
                Consultant.TelephoneNo = TelephoneNo;
                Consultant.EmailID = EmailID;
                Consultant.Address = Address;                
                Consultant.UpdatedBy = UpdatedBy;
                Consultant.IsActive = IsActive;
                String Status = Consultant.Save();

                return Status;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.ConsultantMessages.CONSULTANT_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.ConsultantMessages.CONSULTANT_UPDATE_FAILURE;
            }
        }

        public static String ActivateConsultant(int ID, int ActivatedBy)
        {
            try
            {
                return new ConsultantEntity(ID).Activate(ActivatedBy);
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.ConsultantMessages.CONSULTANT_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.ConsultantMessages.CONSULTANT_UPDATE_FAILURE;
            }
        }

        public static String DeActivateConsultant(int ID, int DeactivatedBy)
        {
            try
            {
                return new ConsultantEntity(ID).DeActivate(DeactivatedBy);
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.ConsultantMessages.CONSULTANT_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.ConsultantMessages.CONSULTANT_UPDATE_FAILURE;
            }
        }

       
        #endregion

        #region Leave
       
        public static String DeleteLeaveRequset(int ID)
        {
            LeaveRequest EmployeeLeave = new LeaveRequest();
            String Status = EmployeeLeave.DeleteEmployeeLeave(ID);
            return Status;

        }
        public static String ResetDateLeaveRequest(int ID)
        {
            LeaveRequest EmployeeLeave = new LeaveRequest();
            String Status = EmployeeLeave.ResetDateLeaveRequest(ID);
            return Status;

        }
        
        #endregion

        #region Team

        public static TeamMaster[] GetAllTeamDetailsByID(int ID)
        {
            return TeamMaster.GeTeamDetailsByID(ID);
        }
        
         /// <summaryg>
        /// Get All Teams
        /// </summary>
        /// <returns>Array of the object of Department class</returns>
        public static TeamDetail[] GetTeams()
        {
            return TeamDetail.GetAllTeams();
        }
        public static TeamDetail[] GetAllTeamDetails()
        {
            return TeamDetail.GetAllTeamDetails();
        }
        

        //public static String UpdateTeam(int ID, String TeamName, int TeamID, int UpdatedBy, bool IsActive)
        //{
        //    try
        //    {
        //        TeamDetail Team = new TeamDetail(ID);
        //        Team.TeamName = TeamName;
        //        Team.ID = TeamID;
        //        //Location.UpdatedBy = UpdatedBy;
        //        Team.IsActive = IsActive;
        //        String Status = Team.Save();

        //        return Status;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRManagerDefs.TeamMessages.TEAM_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRManagerDefs.TeamMessages.TEAM_UPDATE_FAILURE;
        //    }
        //}

        public static String UpdateTeam(int ID, String TeamName, int ManagerID, int UpdatedBy, bool IsActive)
        {
            try
            {
                TeamDetail Team = new TeamDetail(ID);
                Team.ID = ID;
                Team.TeamName = TeamName;
                Team.ManagerID = ManagerID;
                Team.UpdatedBy = UpdatedBy;
                Team.IsActive = IsActive;
                String Status = Team.Save();

                return Status;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.TeamMessages.TEAM_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.TeamMessages.TEAM_UPDATE_FAILURE;
            }
        }
        public static String ActivateTeam(int ID, int ActivatedBy)
        {
            try
            {
                return new TeamDetail(ID).Activate(ActivatedBy);
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.TeamMessages.TEAM_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.TeamMessages.TEAM_UPDATE_FAILURE;
            }
        }
        public static String DeActivateTeam(int ID, int DeactivatedBy)
        {
            try
            {
                //TeamDetail team = new TeamDetail(ID);
                //team.ID = ID;
                //team.IsActive = IsActive;
                //String saveteam = team.Save();
                //return saveteam;
                return new TeamDetail(ID).DeActivate(DeactivatedBy);
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.TeamMessages.TEAM_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.TeamMessages.TEAM_UPDATE_FAILURE;
            }
        }
        public static TeamDetail[] GetInactiveTeam()
        {
            return TeamDetail.GetInActiveTeams();

        }

        #endregion

        #region Employee Uploaded Attendance

        public static EmployeeUploadedAttandance[] GetUploadedEmpAttendanceGrid(int Month, int Year)
        {
            return EmployeeUploadedAttandance.GetUploadedEmployeeAttendance(Month, Year);
        }
        
        #endregion


        //kartyek 5.2.2015 Loan Management Request based response from Entity

        #region Loan
        ///<summary>
        ///Get All Loans
        /// </summary>
        ///<returns>Array of the object of Loan class</returns>
        public static Master_LoansDetails[] GetLoans()
        {
            return Master_LoansDetails.GetAllLoan();
        }
        ///<summary>
        ///Get All Loans
        /// </summary>
        ///<returns>Array of the object of Loan class</returns>
        public static Master_LoansDetails[] GetLoansForTxt(int LoanID)
        {
            return Master_LoansDetails.GetLoansForTxt(LoanID);
        }
        ///<summary>
        ///Get All Loans
        /// </summary>
        ///<returns>Array of the object of Loan class</returns>
        public static String GetLoanAmountByLoanId(int LoanId, int EmpID)
        {
            return Master_LoansDetails.GetLoanAmountByLoanId(LoanId, EmpID);
        }
        ///<summary>
        ///Get All Loans
        /// </summary>
        ///<returns>Array of the object of Loan class</returns>
        public static Master_LoansDetails[] GetActiveLoans()
        {
            return Master_LoansDetails.GetAllActiveLoan();
        }
        ///<summary>
        ///Update Grade of given ID
        ///</summary>
        ///<param name="ID">field contain Grade ID</param>
        ///<param name="GradeName">field contain Grade Name</param>
        ///<param name="Description">field contain Grade Description</param>
        ///<param name="IsActive">field contaions Active status.</param>
        ///<param name="UpdatedBy">field contain the user id who update Grade</param>
        ///<returns>empty string for success and error message for failure</returns>
        public static String UpdateLoan(int ID, String LoanName, double MaxAmount, double Interest, bool IsActive, int UpdatedBy, double MaxBasicPercentage, int MinServicePeriod, int MinLeaveBalance, int RemainingService, string Installment)
        {
            try
            {
                Master_LoansDetails Loan = new Master_LoansDetails(ID);


                Loan.LoanName = LoanName;
                Loan.MaxAmount = MaxAmount;
                Loan.Interest = Interest;
                //Loan.RepaymentMonth = RepaymentMonth;
                Loan.IsActive = IsActive;
                Loan.UpdatedBy = UpdatedBy;
                Loan.MaxBasicPercentage = MaxBasicPercentage;
                Loan.MinServicePeriod = MinServicePeriod;
                Loan.MinLeaveBalance = MinLeaveBalance;
                Loan.RemainingService = RemainingService;
                Loan.Installment = Installment;

                String Status = Loan.Save();

                return Status;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.LoanMessages.LOAN_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.LoanMessages.LOAN_UPDATE_FAILURE;
            }
        }
        /// <summary>
        /// Return all Designation
        /// </summary>
        /// <returns>Array of the object of Designation class</returns>
        public static Master_LoansDetails[] GetInActiveLoans()
        {
            return Master_LoansDetails.GetAllInActiveLoans();
        }


        ///// <summary>
        ///// Return all Designation
        ///// </summary>
        ///// <returns>Array of the object of Designation class</returns>
        //public static Loan[] GetActiveLoans()
        //{
        //    return Loan.GetActiveLoans();
        //}

        /// <summary>
        /// Activate Grade by ID
        /// </summary>
        /// <param name="ID">field contain Grade ID</param>
        /// <param name="ActivatedBy">field contain the user id who activated Grade</param>
        /// <returns>empty string for success and error message for failure</returns>
        public static String ActivateLoan(int ID, int ActivateBy)
        {
            try
            {
                return new Master_LoansDetails(ID).Activate(ActivateBy);
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.LoanMessages.LOAN_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.LoanMessages.LOAN_UPDATE_FAILURE;
            }
        }
        /// <summary>
        /// Deactivate Grade by ID
        /// </summary>
        /// <param name="ID">integer type</param>
        /// <param name="DeactivatedBy">field contain the user id who deactivated Grade</param>
        /// <returns>empty string for success and error message for failure</returns>
        public static String DeActivateLoan(int ID, int DeActivateBy)
        {
            try
            {
                return new Master_LoansDetails(ID).DeActivate(DeActivateBy);
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.LoanMessages.LOAN_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.LoanMessages.LOAN_UPDATE_FAILURE;
            }
        }
        /// <summary>
        /// Deactivate Grade by ID
        /// </summary>
        /// <param name="ID">integer type</param>
        /// <param name="DeactivatedBy">field contain the user id who deactivated Grade</param>
        /// <returns>empty string for success and error message for failure</returns>
        public static Master_LoansDetails[] GetLoanDetailforCombo(int EmpID)
        {
            Master_Loan[] LoansDT = new Master_LoanBusinessObject().GetAllActiveLoan();
            String Status = String.Empty;
            String LoanIDs = String.Empty;
            for (int i = 0; i < LoansDT.Length; i++)
            {
                Status = LoanRequest.CheckEgibility(EmpID, LoansDT[i].ID);
                if (Status == String.Empty)
                {
                    if (LoanIDs == String.Empty)
                        LoanIDs = LoanIDs + LoansDT[i].ID;
                    else
                        LoanIDs = LoanIDs + "," + LoansDT[i].ID;
                }
            }
            return Master_LoansDetails.GetAllLoanforCombo(LoanIDs);
        }

        /// <summary>
        /// Deactivate Grade by ID
        /// </summary>
        /// <param name="ID">integer type</param>
        /// <param name="DeactivatedBy">field contain the user id who deactivated Grade</param>
        /// <returns>empty string for success and error message for failure</returns>
        public static Master_LoansDetails[] GetLoanDetailforComboByGrade(int GradeId)
        {
            return Master_LoansDetails.GetAllLoanforComboByGrade(GradeId);
        }
        #endregion
    }
}
