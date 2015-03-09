using System;
using System.Collections.Generic;
using System.Text;
using HRManager.Entity;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IS91.Services.DataBlock;
using System.Data;

namespace HRManager
{
    public class HRPayrollManager
    {
        #region SalaryAllowance
        
        public static SalaryAllowance[] GetSalaryAllowances()
        {
            return SalaryAllowance.GetSalaryAllowances(1);
        }

        public static SalaryAllowance[] GetOptionalSalaryAllowances(int EmpID)
        {
            return SalaryAllowance.GetOptionalSalaryAllowances(EmpID);
        }
        public static SalaryAllowance[] GetInactiveSalaryAllowances()
        {
            return SalaryAllowance.GetSalaryAllowances(0);
        }
        public static String ActivateSalaryAllowance(int ID, int ActivateBy)
        {
            try
            {
                return new SalaryAllowance(ID).Activate(ActivateBy);
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                   new IRCAException(ex, HRPayrollManagerDefs.SalaryAllowanceMessages.ALLOWANCE_UPDATE_FAILURE, ID.ToString())
                   );
                return HRPayrollManagerDefs.SalaryAllowanceMessages.ALLOWANCE_UPDATE_FAILURE;
            }
        }

        public static String DeActivateSalaryAllowance(int ID, int DeActivateBy)
        {
            try
            {
                return new SalaryAllowance(ID).DeActivate(DeActivateBy);
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRPayrollManagerDefs.SalaryAllowanceMessages.ALLOWANCE_UPDATE_FAILURE, ID.ToString())
                    );
                return HRPayrollManagerDefs.SalaryAllowanceMessages.ALLOWANCE_UPDATE_FAILURE;
            }
        }

        public static String UpdateSalaryAllowance(int ID, string AllowanceName, string AllowancePeriod, bool IsPercentage, bool IsActive, bool IsTaxExempted, int UpdatedBy, bool IsOptional, bool IsAllowance, int DisplayOrder, bool IsOneMonthBasic, double Value, String AllowanceCode)
        {
            try
            {
                SalaryAllowance SAllow = new SalaryAllowance(ID);


                SAllow.ID = ID;
                SAllow.AllowanceName = AllowanceName;
                SAllow.AllowanceCode = AllowanceCode;
                SAllow.AllowancePeriod = AllowancePeriod;
                SAllow.IsPercentage = IsPercentage;
                SAllow.IsActive = IsActive;
                SAllow.IsTaxExempted = IsTaxExempted;
                SAllow.IsOptional = IsOptional;
                SAllow.UpdatedBy = UpdatedBy;
                SAllow.IsAllowance = IsAllowance;
                SAllow.DisplayOrder = DisplayOrder;
                SAllow.IsOneMonthBasic = IsOneMonthBasic;
                SAllow.Value = Value;

                String Status = SAllow.Save();

                return Status;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRPayrollManagerDefs.SalaryAllowanceMessages.ALLOWANCE_UPDATE_FAILURE, ID.ToString())
                    );
                return HRPayrollManagerDefs.SalaryAllowanceMessages.ALLOWANCE_UPDATE_FAILURE;
            }
        }

        public static double GetAllowanceLimit(int AllowanceID,int EmpID)
        {
            return SalaryAllowance.GetAllowanceLimit(AllowanceID,EmpID);
        }

        //public static double CalculateEmpSplAllowance(int EmpID)
        //{
        //    return AssignEmpAllowance.CalculateEmpSplAllowance(EmpID);
        //}

        //public static String UpdateEmployeeAllowance(int ID, int EmpID, int AllowanceID, double Amount, int UpdatedBy)
        //{
        //    try
        //    {
        //        AssignEmpAllowance EmpAllowance = new AssignEmpAllowance(ID);

        //        EmpAllowance.ID = ID;
        //        EmpAllowance.EmpID = EmpID;
        //        EmpAllowance.AllowanceID = AllowanceID;
        //        EmpAllowance.Amount = Amount;
        //        EmpAllowance.UpdatedBy = UpdatedBy;

        //        String Status = EmpAllowance.Save();

        //        return Status;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.EmployeeAllowanceMessages.EMPALLOWANCE_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRPayrollManagerDefs.EmployeeAllowanceMessages.EMPALLOWANCE_UPDATE_FAILURE;
        //    }
        //}


        //public static String DeleteEmployeeAllowance(int ID)
        //{
        //    try
        //    {
        //        AssignEmpAllowance EmpAllowance = new AssignEmpAllowance();

        //        String Status = EmpAllowance.DeleteEmpAllowance(ID);

        //        return Status;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.EmployeeAllowanceMessages.EMPALLOWANCE_DELETED_SUCCESS, ID.ToString())
        //            );
        //        return HRPayrollManagerDefs.EmployeeAllowanceMessages.EMPALLOWANCE_DELETED_SUCCESS;
        //    }
        //}
        

        #endregion

        #region Assign Grade Salry
        
        ///<summary>
        ///Get All GradeSalary
        /// </summary>
        ///<returns>Array of the object of GradeSalary class</returns>
        //public static string[] GetBasicGradeSalaryDetails(int EmpID)
        //{
        //    //return AssignGradeSalary.GetBacisForGradeSalry();
        //    AssignGradeSalary AssignGradeSalary1  = new AssignGradeSalary(EmpID, "EmpID");
        //    return AssignGradeSalary1.GetBacisForGradeSalry();
        //}
        /////<summary>
        /////Get All GradeSalary
        ///// </summary>
        /////<returns>Array of the object of GradeSalary class</returns>
        //public static AssignGradeSalary[] GetAllGradeSalry()
        //{
        //    return AssignGradeSalary.GetAllGradeSalry();
        //}

        ///// <summary>
        ///// Return all GradeSalary
        ///// </summary>
        ///// <returns>Array of the object of GradeSalary class</returns>
        //public static AssignGradeSalary[] GetAllInactiveGradeSalary()
        //{
        //    return AssignGradeSalary.GetAllInActiveGradeSalry();
        //}


        /// <summary>
        /// Activate Grade by ID
        /// </summary>
        /// <param name="ID">field contain Grade ID</param>
        /// <param name="ActivatedBy">field contain the user id who activated Grade</param>
        /// <returns>empty string for success and error message for failure</returns>
        //public static String ActivateGradeSalary(int ID, int ActivateBy)
        //{
        //    try
        //    {
        //        return new AssignGradeSalary(ID).Activate(ActivateBy);
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //           new IRCAException(ex, HRPayrollManagerDefs.GardeSalaryMessges.GRADESALARY_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRPayrollManagerDefs.GardeSalaryMessges.GRADESALARY_UPDATE_FAILURE;
        //    }
        //}
        /// <summary>
        /// Deactivate Grade by ID
        /// </summary>
        /// <param name="ID">integer type</param>
        /// <param name="DeactivatedBy">field contain the user id who deactivated Grade</param>
        /// <returns>empty string for success and error message for failure</returns>
        //public static String DeActivateGradeSalary(int ID, int DeActivateBy)
        //{
        //    try
        //    {
        //        return new AssignGradeSalary(ID).DeActivate(DeActivateBy);
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.GardeSalaryMessges.GRADESALARY_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRPayrollManagerDefs.GardeSalaryMessges.GRADESALARY_UPDATE_FAILURE;
        //    }
        //}



        /////<summary>
        /////Update Grade of given ID
        /////</summary>
        /////<param name="ID">field contain Grade ID</param>
        /////<param name="GradeName">field contain Grade Name</param>
        /////<param name="Description">field contain Grade Description</param>
        /////<param name="IsActive">field contaions Active status.</param>
        /////<param name="UpdatedBy">field contain the user id who update Grade</param>
        /////<returns>empty string for success and error message for failure</returns>
        //public static String UpdateGradeSalary(int ID, int GradeID, double IncrementRate, double BasicMinimum, double BasicMaximum, bool IsIncrementInPercentage, bool IsActive, int UpdatedBy)
        //{
        //    try
        //    {
        //        AssignGradeSalary GradeSalary = new AssignGradeSalary(ID);


        //        GradeSalary.GradeID = GradeID;
        //        GradeSalary.IncrementRate = IncrementRate;
        //        GradeSalary.BasicMaximum = BasicMaximum;
        //        GradeSalary.BasicMinimum = BasicMinimum;
        //        GradeSalary.IsIncrementInPercentage = IsIncrementInPercentage;
        //        GradeSalary.IsActive = IsActive;
        //        GradeSalary.UpdatedBy = UpdatedBy;

        //        String Status = GradeSalary.Save();


        //        return Status;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.GardeSalaryMessges.GRADESALARY_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRPayrollManagerDefs.GardeSalaryMessges.GRADESALARY_UPDATE_FAILURE;
        //    }
        //}
        #endregion

        //#region PayrollAnnualAdditions

        //public static PayrollAnnualAdditions[] GetAnnualAdditions()
        //{
        //    return PayrollAnnualAdditions.GetAnnualAddtions(1);
        //}
        //public static PayrollAnnualAdditions[] GetInactivePayrollAnnualAdditions()
        //{
        //    return PayrollAnnualAdditions.GetAnnualAddtions(0);
        //}
        //public static String ActivatePayrollAnnualAddition(int ID, int ActivateBy)
        //{
        //    try
        //    {
        //        return new PayrollAnnualAdditions(ID).Activate(ActivateBy);
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //           new IRCAException(ex, HRPayrollManagerDefs.PayrollAnnualAdditionsMessage.ADDITION_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRPayrollManagerDefs.PayrollAnnualAdditionsMessage.ADDITION_UPDATE_FAILURE;
        //    }
        //}

        //public static String DeActivatePayrollAnnualAddition(int ID, int DeActivateBy)
        //{
        //    try
        //    {
        //        return new PayrollAnnualAdditions(ID).DeActivate(DeActivateBy);
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.PayrollAnnualAdditionsMessage.ADDITION_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRPayrollManagerDefs.PayrollAnnualAdditionsMessage.ADDITION_UPDATE_FAILURE;
        //    }
        //}

        //public static String UpdatePayrollAnnualAddition(int ID, string Name, double limit, bool IsPercentage, bool IsActive, int UpdatedBy)
        //{
        //    try
        //    {
        //        PayrollAnnualAdditions Addn = new PayrollAnnualAdditions(ID);


        //        Addn.ID = ID;
        //        Addn.Name = Name;
        //        Addn.Limit = limit;
        //        Addn.IsPercentage = IsPercentage;
        //        Addn.IsActive = IsActive;
        //        Addn.UpdatedBy = UpdatedBy;

        //        String Status = Addn.Save();

        //        return Status;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.PayrollAnnualAdditionsMessage.ADDITION_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRPayrollManagerDefs.PayrollAnnualAdditionsMessage.ADDITION_UPDATE_FAILURE;
        //    }
        //}

        //#endregion

        #region Salry Deductions
        ///<summary>
        ///Get All GradeSalary
        /// </summary>
        ///<returns>Array of the object of GradeSalary class</returns>
        public static SalaryDeductions[] GetAllSalaryDeductions()
        {
            return SalaryDeductions.GetAllSalaryDeductions();
        }
        ///<summary>
        ///Get All Employee SalaryDeductions 
        /// </summary>
        ///<returns>Array of the object of Employee SalaryDedusctions class</returns>
        public static SalaryDeductions[] GetAllEmployeeSalaryDeductions()
        {
            return SalaryDeductions.GetAllEmployeeSalaryDeductions();
        }
        public static EmpDeduction[] GetEmployeeDeductions()
        {
            return EmpDeduction.GetEmployeeDeductions();
        }
        /// <summary>
        /// Return all GradeSalary
        /// </summary>
        /// <returns>Array of the object of GradeSalary class</returns>
        public static SalaryDeductions[] GetAllInactiveSalaryDeductions()
        {
            return SalaryDeductions.GetAllInactiveSalaryDeductions();
        }


        /// <summary>
        /// Activate Grade by ID
        /// </summary>
        /// <param name="ID">field contain Grade ID</param>
        /// <param name="ActivatedBy">field contain the user id who activated Grade</param>
        /// <returns>empty string for success and error message for failure</returns>
        public static String ActivateSalaryDeductions(int ID, int ActivateBy)
        {
            try
            {
                return new SalaryDeductions(ID).Activate(ActivateBy);
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                   new IRCAException(ex, HRPayrollManagerDefs.SalaryDeductionMessges.SALARYDEDUCTION_UPDATE_FAILURE, ID.ToString())
                    );
                return HRPayrollManagerDefs.SalaryDeductionMessges.SALARYDEDUCTION_UPDATE_FAILURE;
            }
        }
        /// <summary>
        /// Deactivate Grade by ID
        /// </summary>
        /// <param name="ID">integer type</param>
        /// <param name="DeactivatedBy">field contain the user id who deactivated Grade</param>
        /// <returns>empty string for success and error message for failure</returns>
        public static String DeActivateSalaryDeductions(int ID, int DeActivateBy)
        {
            try
            {
                return new SalaryDeductions(ID).DeActivate(DeActivateBy);
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRPayrollManagerDefs.SalaryDeductionMessges.SALARYDEDUCTION_UPDATE_FAILURE, ID.ToString())
                    );
                return HRPayrollManagerDefs.SalaryDeductionMessges.SALARYDEDUCTION_UPDATE_FAILURE;
            }
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
        public static String UpdateSalaryDeductions(int ID, string Name, string DeductionPeriod, double Limit, bool IsEmployeeLevel, bool IsPercentage,string DeductionCode,bool IsTaxExempted, bool IsActive, int UpdatedBy,String Code)
        {
            try
            {
                SalaryDeductions SalaryDeduts = new SalaryDeductions(ID);


                SalaryDeduts.Name = Name;
                SalaryDeduts.Period = DeductionPeriod;
                SalaryDeduts.Limit = Limit;
                SalaryDeduts.IsEmployee = IsEmployeeLevel;
                SalaryDeduts.IsPercentage = IsPercentage;
                SalaryDeduts.IsActive = IsActive;
                SalaryDeduts.Code = Code;
                SalaryDeduts.IsTaxExempted = IsTaxExempted;
                SalaryDeduts.UpdatedBy = UpdatedBy;
                SalaryDeduts.Code = Code;
                String Status = SalaryDeduts.Save();

                return Status;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRPayrollManagerDefs.SalaryDeductionMessges.SALARYDEDUCTION_UPDATE_FAILURE, ID.ToString())
                    );
                return HRPayrollManagerDefs.SalaryDeductionMessges.SALARYDEDUCTION_UPDATE_FAILURE;
            }
        }
        #endregion

        //#region Tax Excemption Group

        //public static TaxExcemptionGroup[] GetTaxExcemptionGroup()
        //{
        //    return TaxExcemptionGroup.GetTaxExcemptionGroups(1);
        //}
        //public static TaxExcemptionGroup[] GetInactiveTaxExcemptionGroups()
        //{
        //    return TaxExcemptionGroup.GetTaxExcemptionGroups(0);
        //}
        //public static String ActivateTaxExcemptionGroup(int ID, int ActivateBy)
        //{
        //    try
        //    {
        //        return new TaxExcemptionGroup(ID).Activate(ActivateBy);
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //           new IRCAException(ex, HRPayrollManagerDefs.TaxExcemptionGroupMessages.TAXEGROUP_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRPayrollManagerDefs.TaxExcemptionGroupMessages.TAXEGROUP_UPDATE_FAILURE;
        //    }
        //}

        //public static String DeActivateTaxExcemptionGroup(int ID, int DeActivateBy)
        //{
        //    try
        //    {
        //        return new TaxExcemptionGroup(ID).DeActivate(DeActivateBy);
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.TaxExcemptionGroupMessages.TAXEGROUP_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRPayrollManagerDefs.TaxExcemptionGroupMessages.TAXEGROUP_UPDATE_FAILURE;
        //    }
        //}

        //public static String UpdateTaxExcemptionGroup(int ID, string TExecmpName, double MLimit, double FLimit, double SLimit, int FYear, bool IsPercentage, bool IsActive, int UpdatedBy)
        //{
        //    try
        //    {
        //        TaxExcemptionGroup TEGroup = new TaxExcemptionGroup(ID);


        //        TEGroup.ID = ID;
        //        TEGroup.ExemptionName = TExecmpName;
        //        TEGroup.LimitForMen = MLimit;
        //        TEGroup.LimitForWomen = FLimit;
        //        TEGroup.LimitForSrCitizen = SLimit;
        //        TEGroup.FinancialYear = FYear;
        //        TEGroup.IsPercentage = IsPercentage;
        //        TEGroup.IsActive = IsActive;
        //        TEGroup.UpdatedBy = UpdatedBy;

        //        String Status = TEGroup.Save();

        //        return Status;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.TaxExcemptionGroupMessages.TAXEGROUP_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRPayrollManagerDefs.TaxExcemptionGroupMessages.TAXEGROUP_UPDATE_FAILURE;
        //    }
        //}

        //#endregion

        //#region Tax Exemption

        //public static TaxExemption[] GetTaxExemption()
        //{
        //    return TaxExemption.GetTaxExemptions(1);
        //}
        //public static TaxExemption[] GetInactiveTaxExemptions()
        //{
        //    return TaxExemption.GetTaxExemptions(0);
        //}
        //public static String ActivateTaxExemption(int ID, int ActivateBy)
        //{
        //    try
        //    {
        //        return new TaxExemption(ID).Activate(ActivateBy);
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //           new IRCAException(ex, HRPayrollManagerDefs.TaxExemptionMessages.TAXEXEMPTION_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRPayrollManagerDefs.TaxExemptionMessages.TAXEXEMPTION_UPDATE_FAILURE;
        //    }
        //}
        //public static String DeActivateTaxExemption(int ID, int DeActivateBy)
        //{
        //    try
        //    {
        //        return new TaxExemption(ID).DeActivate(DeActivateBy);
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.TaxExemptionMessages.TAXEXEMPTION_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRPayrollManagerDefs.TaxExemptionMessages.TAXEXEMPTION_UPDATE_FAILURE;
        //    }
        //}
        //public static String UpdateTaxExemption(int ID, string Name, int GrpId, bool IsActive, int UpdatedBy)
        //{
        //    try
        //    {
        //        TaxExemption TExemp = new TaxExemption(ID);


        //        TExemp.ID = ID;
        //        TExemp.ExemptionName = Name;
        //        TExemp.GroupID = GrpId;
        //        TExemp.IsActive = IsActive;
        //        TExemp.UpdatedBy = UpdatedBy;

        //        String Status = TExemp.Save();

        //        return Status;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.TaxExemptionMessages.TAXEXEMPTION_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRPayrollManagerDefs.TaxExemptionMessages.TAXEXEMPTION_UPDATE_FAILURE;
        //    }
        //}

        //#endregion

        //#region Assign Grade Salry
        /////<summary>
        /////Get All GradeSalary
        ///// </summary>
        /////<returns>Array of the object of GradeSalary class</returns>
        //public static AssignGradeAllowances[] GetAllGradeAllowances()
        //{
        //    return AssignGradeAllowances.GetAllGradeAllowances();
        //}

        ///// <summary>
        ///// Return all GradeSalary
        ///// </summary>
        ///// <returns>Array of the object of GradeSalary class</returns>
        //public static AssignGradeAllowances[] GetAllInActiveGradeAllowances()
        //{
        //    return AssignGradeAllowances.GetAllInActiveGradeAllowances();
        //}


        ///// <summary>
        ///// Activate Grade by ID
        ///// </summary>
        ///// <param name="ID">field contain Grade ID</param>
        ///// <param name="ActivatedBy">field contain the user id who activated Grade</param>
        ///// <returns>empty string for success and error message for failure</returns>
        //public static String ActivateGradeAllowances(int ID, int ActivateBy)
        //{
        //    try
        //    {
        //        return new AssignGradeAllowances(ID).Activate(ActivateBy);
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //           new IRCAException(ex, HRPayrollManagerDefs.GardeAllowanceMessges.GRADEALLOWANCES_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRPayrollManagerDefs.GardeAllowanceMessges.GRADEALLOWANCES_UPDATE_FAILURE;
        //    }
        //}
        ///// <summary>
        ///// Deactivate Grade by ID
        ///// </summary>
        ///// <param name="ID">integer type</param>
        ///// <param name="DeactivatedBy">field contain the user id who deactivated Grade</param>
        ///// <returns>empty string for success and error message for failure</returns>
        //public static String DeActivateGradeAllowances(int ID, int DeActivateBy)
        //{
        //    try
        //    {
        //        return new AssignGradeAllowances(ID).DeActivate(DeActivateBy);
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.GardeAllowanceMessges.GRADEALLOWANCES_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRPayrollManagerDefs.GardeAllowanceMessges.GRADEALLOWANCES_UPDATE_FAILURE;
        //    }
        //}



        /////<summary>
        /////Update Grade of given ID
        /////</summary>
        /////<param name="ID">field contain Grade ID</param>
        /////<param name="GradeName">field contain Grade Name</param>
        /////<param name="Description">field contain Grade Description</param>
        /////<param name="IsActive">field contaions Active status.</param>
        /////<param name="UpdatedBy">field contain the user id who update Grade</param>
        /////<returns>empty string for success and error message for failure</returns>
        //public static String UpdateGradeAllowances(int ID, int GradeID, int AllowanceID, double Value, bool IsOneMonthSal, bool IsActive, int UpdatedBy)
        //{
        //    try
        //    {
        //        AssignGradeAllowances GradeAllowance = new AssignGradeAllowances(ID);
        //        GradeAllowance.GradeID = GradeID;
        //        GradeAllowance.AllowanceID = AllowanceID;
        //        GradeAllowance.Value = Value;
        //        GradeAllowance.IsOneMonthSalary = IsOneMonthSal;
        //        GradeAllowance.IsActive = IsActive;
        //        GradeAllowance.UpdatedBy = UpdatedBy;

        //        String Status = GradeAllowance.Save();
        //        return Status;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.GardeAllowanceMessges.GRADEALLOWANCES_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRPayrollManagerDefs.GardeAllowanceMessges.GRADEALLOWANCES_UPDATE_FAILURE;
        //    }
        //}
        //#endregion

        //#region EmployeeDeclaration

        //public static String[] GetFinancialYears()
        //{
        //    return EmployeeDeclaration.GetFinancialYears();
        //}
        //public static TaxNames[] GetTaxNames(int year)
        //{
        //    return EmployeeDeclaration.GetTaxNames(year);
        //}
        //public static EmployeeDeclaration[] GetEmployeeDeclaration(int IsProjection, int empId, int year)
        //{
        //    return EmployeeDeclaration.GetEmployeeDeclaration(IsProjection, empId, year);
        //}

        //public static String UpdateEmployeeDeclaration(int ID, int EmpId, int ExemptionId, double amount, bool IsProjection, int UpdatedBy)
        //{
        //    try
        //    {
        //        EmployeeDeclaration EmpDecl = new EmployeeDeclaration(ID);


        //        EmpDecl.ID = ID;
        //        EmpDecl.EmpID = EmpId;
        //        EmpDecl.ExemptionID = ExemptionId;
        //        EmpDecl.Amount = amount;
        //        EmpDecl.IsProjection = IsProjection;
        //        EmpDecl.UpdatedBy = UpdatedBy;

        //        String Status = EmpDecl.Save();

        //        return Status;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.EmployeeDeclarationMessages.EMPLOYEEDECLARATION_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRPayrollManagerDefs.EmployeeDeclarationMessages.EMPLOYEEDECLARATION_UPDATE_FAILURE;
        //    }
        //}

        //public static String DeleteEmployeeDeclaration(int ID)
        //{
        //    try
        //    {
        //        EmployeeDeclaration EmpDecl = new EmployeeDeclaration(ID);

        //        String Status = EmpDecl.Delete();

        //        return Status;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.EmployeeDeclarationMessages.EMPLOYEEDECLARATION_DELETE_FAILURE, ID.ToString())
        //            );
        //        return HRPayrollManagerDefs.EmployeeDeclarationMessages.EMPLOYEEDECLARATION_DELETE_FAILURE;
        //    }
        //}

        //#endregion

        //#region  Salry Structure
        /////<summary>
        /////Get All GradeSalary
        ///// </summary>
        /////<returns>Array of the object of GradeSalary class</returns>
        //public static EmployeeDeductions[] GetAllEmployeeDeductions(int EmpID)
        //{
        //    return EmployeeDeductions.GetAllEmployeeDeductions(EmpID);
        //}

        //public static AssignEmpAllowance[] GetEmployeeAllowances(int EmpID)
        //{
        //    return AssignEmpAllowance.GetEmployeeAllowances(EmpID);
        //}
        //public static String DeleteEmployeeDeduction(int ID)
        //{
        //    try
        //    {
        //        EmployeeDeductions EmpDeduction = new EmployeeDeductions();

        //        String Status = EmpDeduction.DeleteEmpDeduction(ID);

        //        return Status;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.SalaryStructureMessges.EMPDEDUCTION_DELETED_SUCCESS, ID.ToString())
        //            );
        //        return HRPayrollManagerDefs.SalaryStructureMessges.EMPDEDUCTION_DELETED_SUCCESS;
        //    }
        //}

        /////<summary>
        /////Update Grade of given ID
        /////</summary>
        /////<param name="ID">field contain Grade ID</param>
        /////<param name="GradeName">field contain Grade Name</param>
        /////<param name="Description">field contain Grade Description</param>
        /////<param name="IsActive">field contaions Active status.</param>
        /////<param name="UpdatedBy">field contain the user id who update Grade</param>
        /////<returns>empty string for success and error message for failure</returns>
        //public static String UpdateEmployeeDeductions(int ID, int EmpID, int DeductionID, double Deduction,string DeductionType, bool IsActive, int UpdatedBy,String Narration)
        //{
        //    try
        //    {
        //        EmployeeDeductions Deductions = new EmployeeDeductions(ID);
        //        Deductions.EmpID = EmpID;
        //        Deductions.DeductionID = DeductionID;
        //        Deductions.Deduction = Deduction;
        //        Deductions.DeductionType = DeductionType;
        //        Deductions.IsActive = IsActive;
        //        Deductions.UpdatedBy = UpdatedBy;
        //        Deductions.Narration = Narration;
        //        String Status = Deductions.Save();
        //        return Status;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.SalaryStructureMessges.DEDUCTIONS_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRPayrollManagerDefs.SalaryStructureMessges.DEDUCTIONS_UPDATE_FAILURE;
        //    }
        //}

        /////<summary>
        /////Update Grade of given ID
        /////</summary>
        /////<param name="ID">field contain Grade ID</param>
        /////<param name="GradeName">field contain Grade Name</param>
        /////<param name="Description">field contain Grade Description</param>
        /////<param name="IsActive">field contaions Active status.</param>
        /////<param name="UpdatedBy">field contain the user id who update Grade</param>
        /////<returns>empty string for success and error message for failure</returns>
        //public static String UpdateEmployeeSalary(int ID,DateTime ActivatedDate, int EmpID, double Basic, double TDS, double Special, double Others, string PANNo, string PFNo, string ESINo, int UpdatedBy, int BonusType, double CTC, Boolean HasESI)
        //{
        //    try
        //    {
        //        EmployeeSalary EmpSalary = new EmployeeSalary(ID);

        //        if (EmpSalary.Basic != Basic || EmpSalary.Special != Special)
        //        {
        //            EmployeeSalary.DeleteMandatoryAllowance(EmpID);
        //            EmployeeSalary.UpdateNewEmpAllowance(EmpID, Basic);
        //            EmpSalary.Special = Special;
        //            //EmpSalary.Special = (CTC / 12) - (new Assign_emp_AllowanceBusinessObject().SumEmpAllowance(EmpID) + Basic);
        //            //if (EmpSalary.Special < 0)
        //              //  return HRPayrollManagerDefs.SalaryStructureMessges.NEG_SPL_ALLOWANCE;
        //        }
        //        else
        //        {
        //            EmpSalary.Special = Special;
        //        }
        //        EmpSalary.EmpID = EmpID;
        //        EmpSalary.Basic = Basic;
        //        //EmpSalary.TDS = TDS;
        //        EmpSalary.ActivatedDate=ActivatedDate;
        //        EmpSalary.Others = Others;
        //        EmpSalary.PANNo = PANNo;
        //        EmpSalary.PFNo = PFNo;
        //        EmpSalary.ESINo = ESINo;
        //        EmpSalary.UpdatedBy = UpdatedBy;
        //        EmpSalary.BonusId = BonusType;
        //        EmpSalary.CTC = CTC;
        //        EmpSalary.HasESI = HasESI;
                

        //        String Status = EmpSalary.Save();
        //        return Status;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.SalaryStructureMessges.SALARYSTRUCTURE_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRPayrollManagerDefs.SalaryStructureMessges.SALARYSTRUCTURE_UPDATE_FAILURE;
        //    }
        //}
        /////<summary>
        /////Get All GradeSalary
        ///// </summary>
        /////<returns>Array of the object of GradeSalary class</returns>
        //public static EmployeeSalary GetEmployeeSaleryDetails(int empId)
        //{
        //    return EmployeeSalary.GetEmployeeSalaryDetails(empId);
        //}
        //#endregion

        //#region Tax and Slabs

        //public static Tax[] GetAllTaxes()
        //{
        //    return Tax.GetAllTaxes(1);
        //}
        //public static Tax[] GetInactiveTaxes()
        //{
        //    return Tax.GetAllTaxes(0);
        //}
        //public static String ActivateTax(int ID, int ActivateBy)
        //{
        //    try
        //    {
        //        return new Tax(ID).Activate(ActivateBy);
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //           new IRCAException(ex, HRPayrollManagerDefs.TaxMessges.TAX_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRPayrollManagerDefs.TaxMessges.TAX_UPDATE_FAILURE;
        //    }
        //}
        //public static String DeActivateTax(int ID, int DeActivateBy)
        //{
        //    try
        //    {
        //        return new Tax(ID).DeActivate(DeActivateBy);
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.TaxMessges.TAX_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRPayrollManagerDefs.TaxMessges.TAX_UPDATE_FAILURE;
        //    }
        //}

        
        ///// <summary>
        ///// Update Tax
        ///// </summary>
        //public static String UpdateTax(int ID, string TaxName, string TaxCode, bool IsFixed, Double FixedPercentage, bool IsActive, String Slabs, int UpdatedBy)
        //{
        //    Session ss = Session.CreateNewSession();
        //    String Status = null;
        //    int TaxId = 0;
        //    try
        //    {
        //        ss.BeginTransaction();
               
        //        try
        //        {
        //            Tax Taxs = new Tax(ID);
                     

        //            Taxs.ID = ID;
        //           // Taxs.LocationID = LocationID;
        //           // Taxs.FinancialYear = FinancialYear;
        //            Taxs.IsFixed = IsFixed;
        //            Taxs.FixedPercentage = FixedPercentage;
        //            Taxs.TaxName = TaxName;
        //            Taxs.Code = TaxCode;
        //            Taxs.IsActive = IsActive;
        //            Taxs.UpdatedBy = UpdatedBy;
        //            Status = Taxs.Validate();
        //            if (Status == string.Empty)
        //            {
        //                TaxId = Taxs.Save(ss);
                        
        //            }
        //            else
        //            {
        //                ss.Rollback();
        //                ss.Dispose();
        //                return Status;
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            IRCAExceptionHandler.HandleException(
        //                new IRCAException(ex, HRManagerDefs.CandidatePersonalInfoMessages.CANDIDATE_UPDATE_FAILURE, ID.ToString())
        //                );
        //            return HRManagerDefs.CandidatePersonalInfoMessages.CANDIDATE_UPDATE_FAILURE;
        //        }

        //        #region Slabs
        //        int salbid = 0;
        //        int stateid = 0;
        //        int yr= 0;
        //        int stateid1 = 0;
        //        int yr1 = 0;
        //        String type;
        //        double minamount;
        //        double maxamount;
        //        double value;
        //        double addvalue = 0; ;
        //        bool isPercentage;
        //        if (Slabs != string.Empty)
        //        {
        //            if (TaxId != 0)
        //            {
        //                string slbIds = string.Empty;
        //                string[] ski = Slabs.Split('?');
                       
        //                foreach (string s in ski)
        //                {
        //                    string[] words = s.Split(',');
        //                    if(words[0]==string.Empty)words[0]="0";
        //                    salbid = int.Parse(words[0]);
        //                    slbIds = string.Concat(slbIds, "," ,salbid);
        //                    stateid = int.Parse(words[1]);
        //                    if (words[2] == "") words[2] = "0";
        //                    yr= int.Parse(words[2]);
        //                    minamount = double.Parse(words[3]);
        //                    maxamount = double.Parse(words[4]);
        //                    value = double.Parse(words[6]);
        //                    type = words[7].ToString();
        //                    if(words[8].ToString()!=string.Empty)
        //                     addvalue = double.Parse(words[8]);

        //                    isPercentage = bool.Parse(words[5].ToString());
        //                    foreach (string str in ski)
        //                    {
        //                        string[] swords = str.Split(',');
        //                        if (swords[0] == string.Empty) swords[0] = "0";
        //                        salbid = int.Parse(words[0]);
        //                        slbIds = string.Concat(slbIds, ",", salbid);
        //                    }
        //                    try
        //                    {
        //                        if (slbIds.Length > 0)
        //                        {
        //                            if (stateid1 != stateid && yr != yr1)
        //                            {
        //                                slbIds = slbIds.Substring(1);
        //                                new Master_TaxBusinessObject().DeleteTaxSlabs(TaxId, stateid, yr, slbIds, ss);
        //                                stateid1 = stateid;
        //                                yr1 = yr;
        //                            }
        //                        }
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        ss.Rollback();
        //                        IRCAExceptionHandler.HandleException(
        //                            new IRCAException(ex, HRPayrollManagerDefs.TaxMessges.TAX_UPDATE_FAILURE, ID.ToString())
        //                            );
        //                        return HRPayrollManagerDefs.TaxMessges.TAX_UPDATE_FAILURE;
        //                    }
        //                    Status = UpdateTaxSlabs(salbid, TaxId,stateid,yr, minamount, maxamount, isPercentage, value, type, addvalue, ss);
        //                    if (Status != String.Empty)
        //                    {
        //                        ss.Rollback();
        //                        TaxId = 0;
        //                    }
                           

        //                }
                       
        //            }
        //        }
        //        ss.Commit();
        //        #endregion
        //    }
        //    catch (Exception ex)
        //    {
        //        ss.Rollback();
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.TaxMessges.TAX_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRPayrollManagerDefs.TaxMessges.TAX_UPDATE_FAILURE;
        //    }
        //    finally
        //    {
        //        ss.Dispose();
        //    }
        //    return TaxId.ToString();
        //}

        ///// <summary>
        ///// Update Tax Slabs For given TaxID
        ///// </summary>
        //public static String UpdateTaxSlabs(int ID, int TaxID,int stateID,int year, Double MinAmount, Double MaxAmount, bool IsPercentage, Double Value, String Type, double addvalue, Session DBSession)
        //{
        //    bool IsLocalSession = false;
        //    if (DBSession == null)
        //    {
        //        IsLocalSession = true;

        //        DBSession = Session.CreateNewSession();

        //        DBSession.BeginTransaction();
        //    }
        //    try
        //    {
        //        TaxSlab slabs = new TaxSlab(ID);
        //        slabs.TaxID = TaxID;
        //        slabs.MinAmount = MinAmount;
        //        slabs.MaxAmount = MaxAmount;
        //        slabs.IsPercentage = IsPercentage;
        //        slabs.Value = Value;
        //        slabs.AddValue = addvalue;
        //        slabs.Type = Type;
        //        slabs.StateID=stateID;
        //        slabs.FinancialYear = year;

        //        String Status = slabs.Save(DBSession);
        //        if (IsLocalSession)
        //        {
        //            DBSession.Commit();
        //        }
        //        return Status;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRManagerDefs.Family_DetailsMessages.FAMILY_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRManagerDefs.Family_DetailsMessages.FAMILY_UPDATE_FAILURE;
        //    }
        //}



        //public static TaxSlab[] GetAllTaxeslabs(int Taxid)
        //{
        //    return TaxSlab.GetAllTaxeslabs(Taxid);
        //}
        //#endregion
        #region Payroll
        public static String UpdateEmployeePayroll(string sessionId, string uniqueId, bool isAnnualbeniftincluded)
        {
            try
            {
                PayrollSession pSess = PayrollSession.CreatePayrollSession();
                EmployeePayroll[] epays = pSess.GetEmployeePayroll(sessionId, uniqueId);
                if (epays == null) return HRPayrollManagerDefs.SalaryStructureMessges.SALARYSTRUCTURE_UPDATE_FAILURE;

                foreach (EmployeePayroll ep in epays)
                {
                    if (ep == null) continue;
                    if (ep.NetSalary <= 0) continue;
                    ep.IsAnnualBenifitIncluded = isAnnualbeniftincluded;
                    ep.Save(null);
                }
                //pSess.RemovePayrollSession(sessionId,uniqueId);

                return string.Empty;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRPayrollManagerDefs.SalaryStructureMessges.SALARYSTRUCTURE_UPDATE_FAILURE, "")
                    );
                return HRPayrollManagerDefs.SalaryStructureMessges.SALARYSTRUCTURE_UPDATE_FAILURE;
            }
        }
        #endregion

        //#region Payroll
        public static String UpdateEmployeePayroll(string sessionId, string uniqueId, int Month, int Year, bool IsAnualbenifitsincluded)
        {
            try
            {
                PayrollSession pSess = PayrollSession.CreatePayrollSession();
                EmployeePayroll[] epays = pSess.GetEmployeePayroll(sessionId, uniqueId);
                if (epays == null) return HRPayrollManagerDefs.SalaryStructureMessges.SALARYSTRUCTURE_UPDATE_FAILURE;
                new Employee_PayrollBusinessObject().Delete(Month, Year);
                foreach (EmployeePayroll ep in epays)
                {
                    if (ep == null) continue;
                    if (ep.NetSalary <= 0) continue;
                    //if (ep.IsAnnualBenifitIncluded)
                    //{
                    //    if (!IsAnualbenifitsincluded)
                    //    {
                    //        continue;
                    //    }
                    //}
                    ep.IsAnnualBenifitIncluded = IsAnualbenifitsincluded;
                    ep.Month = Month;
                    ep.Year = Year;
                    ep.Save(null);
                }
                pSess.RemovePayrollSession(sessionId, uniqueId);
                return string.Empty;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRPayrollManagerDefs.SalaryStructureMessges.SALARYSTRUCTURE_UPDATE_FAILURE, "")
                    );
                return HRPayrollManagerDefs.SalaryStructureMessges.SALARYSTRUCTURE_UPDATE_FAILURE;
            }
        }

        //public static String SaveEmployeePayrollTemp(string sessionId, string uniqueId)
        //{
        //    try
        //    {
        //        PayrollSession pSess = PayrollSession.CreatePayrollSession();
        //        EmployeePayroll[] epays = pSess.GetEmployeePayroll(sessionId, uniqueId);
        //        if (epays == null) return HRPayrollManagerDefs.SalaryStructureMessges.SALARYSTRUCTURE_UPDATE_FAILURE;

        //        foreach (EmployeePayroll ep in epays)
        //        {
        //            if (ep == null) continue;
        //            if (ep.NetSalary <= 0) continue;
        //            ep.SaveTemp();
        //        }
                
        //        return string.Empty;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.SalaryStructureMessges.SALARYSTRUCTURE_UPDATE_FAILURE, "")
        //            );
        //        return HRPayrollManagerDefs.SalaryStructureMessges.SALARYSTRUCTURE_UPDATE_FAILURE;
        //    }
        //}
        //public static DataTable GetEmployeeEarnings(string sessionId, string uniqueId, int empId,bool isActual)
        //{
        //    try
        //    {
        //        PayrollSession pSess = PayrollSession.CreatePayrollSession();
        //        EmployeePayroll[] epays = pSess.GetEmployeePayroll(sessionId, uniqueId);
        //        if (epays == null) return null;
        //        EmployeePayroll ep = Array.Find<EmployeePayroll>(epays, (x => x.EmployeeId == empId));
        //        DataTable dtPay = new DataTable("Payslip");
        //        dtPay.Columns.Add(new DataColumn("PayrollID", Type.GetType("System.String")));
        //        dtPay.Columns.Add(new DataColumn("AdditionID", Type.GetType("System.String")));
        //        dtPay.Columns.Add(new DataColumn("AdditionName", Type.GetType("System.String")));
        //        dtPay.Columns.Add(new DataColumn("Amount", Type.GetType("System.String")));
        //        if(ep!=null)
        //        {
        //            DataRow dr = null;
        //            if (ep.Earnings != null)
        //            {
        //                dr = dtPay.NewRow();
        //                dr[0] = "0";
        //                dr[1] = "0";
        //                if (ep.Earnings.EmploymentTypeId == 4)
        //                {
        //                    dr[2] = "Consultant fee";
        //                }
        //                else
        //                {
        //                    dr[2] = "Basic Pay";
        //                }
        //                if (isActual)
        //                    dr[3] = ep.Earnings.ActualBasic.ToString();
        //                else
        //                    dr[3] = ep.Earnings.Basic.ToString();
        //                dtPay.Rows.Add(dr);
        //                if (ep.Earnings.BasicArrears != 0)
        //                {
        //                    dr = dtPay.NewRow();
        //                    dr[0] = "0";
        //                    dr[1] = "0";
        //                    dr[2] = "Basic Arrears";
        //                    if (isActual)
        //                        dr[3] = 0;
        //                    else
        //                        dr[3] = ep.Earnings.BasicArrears.ToString();
        //                    dtPay.Rows.Add(dr);
        //                }
        //                if (ep.Earnings.OtherArrears != 0)
        //                {
        //                    dr = dtPay.NewRow();
        //                    dr[0] = "0";
        //                    dr[1] = "0";
        //                    dr[2] = "Other Arrears";
        //                    if (isActual)
        //                        dr[3] = 0;//ep.Earnings.OtherArrears.ToString();
        //                    else
        //                        dr[3] = ep.Earnings.OtherArrears.ToString();
        //                    dtPay.Rows.Add(dr);
        //                }
        //                    if (ep.Earnings.Allowances != null)
        //                {
        //                    foreach (Allowance a in ep.Earnings.Allowances)
        //                    {
        //                        dr = dtPay.NewRow();
        //                        dr[0] = "0";
        //                        dr[1] = "0";
        //                        dr[2] = a.Name;
        //                        if (isActual)
        //                            dr[3] = a.ActualAmount.ToString();
        //                        else
        //                            dr[3] = a.Amount.ToString();
        //                        dtPay.Rows.Add(dr);
        //                    }
        //                }
        //            }
        //            if (ep.ABenifits != null)
        //            {
        //                if (ep.ABenifits.Allowances != null)
        //                {
        //                    foreach (Allowance a in ep.ABenifits.Allowances)
        //                    {
        //                        //if (isActual)
        //                        //{
        //                        //    if (a.ActualAmount != 0)
        //                        //    {
        //                        //        dr = dtPay.NewRow();
        //                        //        dr[0] = "0";
        //                        //        dr[1] = "0";
        //                        //        dr[2] = a.Name;
        //                        //        dr[3] = a.ActualAmount.ToString();
        //                        //        dtPay.Rows.Add(dr);
        //                        //    }
        //                        //}
        //                        //else
        //                        //{
        //                            if (a.Amount != 0)
        //                            {
        //                                dr = dtPay.NewRow();
        //                                dr[0] = "0";
        //                                dr[1] = "0";
        //                                dr[2] = a.Name;
        //                                dr[3] = a.Amount.ToString();
        //                                dtPay.Rows.Add(dr);
        //                            }
        //                        //}
        //                    }
        //                }
        //            }
        //            if (ep.Earnings != null)
        //            {
        //                dr = dtPay.NewRow();
        //                dr[0] = "0";
        //                dr[1] = "0";
        //                dr[2] = "Special Allowance";
        //                if (isActual)
        //                    dr[3] = ep.Earnings.ActualSpecialAllowance.ToString();
        //                else
        //                    dr[3] = ep.Earnings.SpecialAllowance.ToString();
        //                dtPay.Rows.Add(dr);
        //            }
        //        }
        //        //pSess.RemovePayrollSession(sessionId,uniqueId);

        //        return dtPay;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.SalaryStructureMessges.SALARYSTRUCTURE_UPDATE_FAILURE, "")
        //            );
        //        return null;
        //    }
        //}
        //public static DataTable GetEmployeeDeductions(string sessionId, string uniqueId, int empId)
        //{
        //    try
        //    {
        //        PayrollSession pSess = PayrollSession.CreatePayrollSession();
        //        EmployeePayroll[] epays = pSess.GetEmployeePayroll(sessionId, uniqueId);
        //        if (epays == null) return null;
        //        EmployeePayroll ep = Array.Find<EmployeePayroll>(epays, (x => x.EmployeeId == empId));
        //        DataTable dtPay = new DataTable("Payslip");
        //        dtPay.Columns.Add(new DataColumn("PayrollID", Type.GetType("System.String")));
        //        dtPay.Columns.Add(new DataColumn("DeductionID", Type.GetType("System.String")));
        //        dtPay.Columns.Add(new DataColumn("DeductionName", Type.GetType("System.String")));
        //        dtPay.Columns.Add(new DataColumn("Amount", Type.GetType("System.String")));
        //        if (ep != null)
        //        {
        //            if (ep.Deductions != null)
        //            {
        //                DataRow dr = dtPay.NewRow();
        //                dr[0] = "0";
        //                dr[1] = ep.Deductions.PF.DeductionID;
        //                dr[2] = "PF";
        //                //dr[3] = ep.Deductions.PF.Amount.ToString();
        //                dr[3] = Math.Round(ep.Deductions.PF.Amount, 2, MidpointRounding.AwayFromZero).ToString();
        //                dtPay.Rows.Add(dr);
        //                dr = dtPay.NewRow();

        //                dr[0] = "0";
        //                dr[1] = ep.Deductions.ESI.DeductionID.ToString();
        //                dr[2] = "ESI";
        //                dr[3] = Math.Ceiling(ep.Deductions.ESI.Amount).ToString();
        //                dtPay.Rows.Add(dr);
        //                dr = dtPay.NewRow();
        //                dr[0] = "0";
        //                dr[1] = ep.Deductions.TDSID.ToString();
        //                dr[2] = "TDS";
        //                dr[3] = ep.Deductions.TDS.ToString();
        //                dtPay.Rows.Add(dr);
                        
        //                if (ep.Deductions.OtherDeductions != null)
        //                {
        //                    foreach (OtherDeductions o in ep.Deductions.OtherDeductions)
        //                    {
        //                        dr = dtPay.NewRow();
        //                        dr[0] = "0";
        //                        dr[1] = o.DeductionID;
        //                        dr[2] = o.DeductionName;
        //                        dr[3] = o.Deduction.ToString();
        //                        dtPay.Rows.Add(dr);
        //                    }
        //                }
        //                if (ep.Deductions.TaxDeduction != null)
        //                {
        //                    foreach (PayrollTax t in ep.Deductions.TaxDeduction)
        //                    {
        //                        dr = dtPay.NewRow();
        //                        dr[0] = "0";
        //                        dr[1] = t.TaxID;
        //                        dr[2] = t.TaxName;
        //                        dr[3] = t.Amount.ToString();
        //                        dtPay.Rows.Add(dr);
        //                    }
        //                }
        //                if (ep.Deductions.Loan != null)
        //                {
        //                    double dblLoan = 0;
        //                    foreach (Entity.Payroll.Loan l in ep.Deductions.Loan)
        //                    {
        //                        dblLoan = dblLoan + l.Amount;
                               
        //                    }
        //                    dr = dtPay.NewRow();
        //                    dr[0] = "0";
        //                    dr[1] = "0";
        //                    dr[2] = "Loan";
        //                    dr[3] = dblLoan.ToString();
        //                    dtPay.Rows.Add(dr);
        //                }
        //            }
        //        }
        //        //pSess.RemovePayrollSession(sessionId,uniqueId);

        //        return dtPay;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.SalaryStructureMessges.SALARYSTRUCTURE_UPDATE_FAILURE, "")
        //            );
        //        return null;
        //    }
        //}

        //public static DataTable GetEmployeeLoan(string sessionId, string uniqueId, int empId)
        //{
        //    try
        //    {
        //        PayrollSession pSess = PayrollSession.CreatePayrollSession();
        //        EmployeePayroll[] epays = pSess.GetEmployeePayroll(sessionId, uniqueId);
        //        if (epays == null) return null;
        //        EmployeePayroll ep = Array.Find<EmployeePayroll>(epays, (x => x.EmployeeId == empId));
        //        DataTable dtPay = new DataTable("Payslip");
        //        dtPay.Columns.Add(new DataColumn("PayrollID", Type.GetType("System.String")));
        //        dtPay.Columns.Add(new DataColumn("LoanID", Type.GetType("System.String")));
        //        dtPay.Columns.Add(new DataColumn("LoanName", Type.GetType("System.String")));
        //        dtPay.Columns.Add(new DataColumn("Amount", Type.GetType("System.String")));
        //        dtPay.Columns.Add(new DataColumn("AL", Type.GetType("System.String")));
        //        dtPay.Columns.Add(new DataColumn("CL", Type.GetType("System.String")));
        //        dtPay.Columns.Add(new DataColumn("SL", Type.GetType("System.String")));
        //        if (ep != null)
        //        {
        //            Employee_Payroll_DeductionsBusinessObject oDedBO= new Employee_Payroll_DeductionsBusinessObject();
        //            DataRow dr = dtPay.NewRow();
        //            dr = dtPay.NewRow();
        //            dr[0] = "0";
        //            dr[1] = "0";
        //            dr[2] = string.Empty;
        //            dr[3] = "0";
        //            dr[4] = oDedBO.GetBalanceLeave(empId.ToString(), ep.Month.ToString(), ep.Year.ToString(), "Annual Leave");
        //            dr[5] = oDedBO.GetBalanceLeave(empId.ToString(), ep.Month.ToString(), ep.Year.ToString(), "Casual Leave");
        //            dr[6] = oDedBO.GetBalanceLeave(empId.ToString(), ep.Month.ToString(), ep.Year.ToString(), "Sick Leave");
        //            dtPay.Rows.Add(dr);
        //            if (ep.Deductions.Loan != null)
        //            {
        //                foreach (Entity.Payroll.Loan l in ep.Deductions.Loan)
        //                {
        //                    dr = dtPay.NewRow();
        //                    dr[0] = "0";
        //                    dr[1] = l.LoanID;
        //                    dr[2] = l.LoanName;
        //                    dr[3] = (l.BalanceAmount-l.Amount).ToString();
        //                    dr[4] = "0";
        //                    dr[5] = "0";
        //                    dr[6] = "0";
        //                    dtPay.Rows.Add(dr);
        //                }
        //            }
        //        }

        //        return dtPay;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.SalaryStructureMessges.SALARYSTRUCTURE_UPDATE_FAILURE, "")
        //            );
        //        return null;
        //    }
        //}

        //public static DataTable GetPayrollNarration(string sessionId, string uniqueId, int empId)
        //{
        //    try
        //    {
        //        PayrollSession pSess = PayrollSession.CreatePayrollSession();
        //        EmployeePayroll[] epays = pSess.GetEmployeePayroll(sessionId, uniqueId);
        //        if (epays == null) return null;
        //        EmployeePayroll ep = Array.Find<EmployeePayroll>(epays, (x => x.EmployeeId == empId));
        //        DataTable dtPay = new DataTable("Narration");
        //        dtPay.Columns.Add(new DataColumn("PayrollID", Type.GetType("System.String")));
        //        dtPay.Columns.Add(new DataColumn("Narration", Type.GetType("System.String")));
        //        if (ep != null)
        //        {
        //          if (ep.Deductions!= null)
        //            {
        //                if (ep.Deductions.OtherDeductions != null)
        //                {
        //                    DataRow dr = dtPay.NewRow();
        //                    foreach (OtherDeductions d in ep.Deductions.OtherDeductions)
        //                    {
        //                        if (d.Narration != string.Empty)
        //                        {
        //                            dr = dtPay.NewRow();
        //                            dr[0] = ep.ID;
        //                            dr[1] = d.Narration;

        //                            dtPay.Rows.Add(dr);
        //                        }
        //                    }
        //                }
        //            }
        //          if (ep.Earnings.Allowances != null)
        //          {
        //              DataRow dr = dtPay.NewRow();
        //              foreach (Entity.Payroll.Allowance a in ep.Earnings.Allowances)
        //              {
        //                  if (a.Narration != string.Empty)
        //                  {
        //                      dr = dtPay.NewRow();
        //                      dr[0] = ep.ID;
        //                      dr[1] = a.Narration;

        //                      dtPay.Rows.Add(dr);
        //                  }
        //              }
        //          }
        //        }

        //        return dtPay;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.SalaryStructureMessges.SALARYSTRUCTURE_UPDATE_FAILURE, "")
        //            );
        //        return null;
        //    }
        //}

        //public static double GetEmployeeTotalAmount(string sessionId, string uniqueId, int empId,string type)
        //{
        //    try
        //    {
        //        PayrollSession pSess = PayrollSession.CreatePayrollSession();
        //        EmployeePayroll[] epays = pSess.GetEmployeePayroll(sessionId, uniqueId);
        //        if (epays == null) return 0;
        //        EmployeePayroll ep = Array.Find<EmployeePayroll>(epays, (x => x.EmployeeId == empId));
        //        double total = 0;
        //        if (ep != null)
        //        {
        //            if (type == "gross")
        //            {
        //                return ep.Earnings.GrossSalary;
        //                //total = ep.Earnings.ActualBasic + ep.Earnings.ActualSpecialAllowance;
        //                //double tot = 0;
        //                //foreach (Allowance a in ep.Earnings.Allowances)
        //                //{
        //                //    tot = tot + a.ActualAmount;

        //                //}
        //                //total = total + tot;
        //                //return total;
        //            }
        //            else if (type == "earning")
        //            {
        //                return ep.Earnings.TotalEarnings;
        //               /* total = ep.Earnings.Basic + ep.Earnings.SpecialAllowance;
        //                double tot = 0;
        //                foreach (Allowance a in ep.Earnings.Allowances)
        //                {
        //                    tot = tot + a.Amount;

        //                }
        //                total = total + tot;
        //                return total;*/
        //            }
        //            else if (type == "deduction")
        //            {
        //                return ep.Deductions.TotalDeductions;
        //                /*double tot = 0;
        //                total = ep.Deductions.PF.Amount + ep.Deductions.ESI.Amount + ep.Deductions.TDS;
        //                if (ep.Deductions.OtherDeductions != null)
        //                {
        //                    foreach (OtherDeductions o in ep.Deductions.OtherDeductions)
        //                    {
        //                        tot = tot + o.Deduction;
        //                    }
        //                }
        //                if (ep.Deductions.TaxDeduction!= null)
        //                {
        //                    foreach (PayrollTax t in ep.Deductions.TaxDeduction)
        //                    {
        //                        tot = tot + t.Amount;
        //                    }
        //                }
        //                if (ep.Deductions.Loan!= null)
        //                {
        //                    foreach (Entity.Payroll.Loan l in ep.Deductions.Loan)
        //                    {
        //                        tot = tot + l.Amount;
        //                    }
        //                }
        //                total = total + tot;
        //                return total;*/
        //            }
        //            else if (type == "plop")
        //            {
        //                return ep.Earnings.OtherLOP;
        //            }
        //        }
        //        return 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        return 0;
        //    }
        //}
        //public static DateTime GetEmployeeSeparation(string sessionId, string uniqueId, int empId)
        //{
        //    try
        //    {
        //        PayrollSession pSess = PayrollSession.CreatePayrollSession();
        //        EmployeePayroll[] epays = pSess.GetEmployeePayroll(sessionId, uniqueId);
        //        if (epays == null) return new DateTime(1900, 1, 1);
        //        EmployeePayroll ep = Array.Find<EmployeePayroll>(epays, (x => x.EmployeeId == empId));
        //        if (ep != null)
        //        {
        //                return ep.Earnings.LeavingDate;
                
        //        }
        //        return new DateTime(1900,1,1);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new DateTime(1900, 1, 1);
        //    }
        //}

        //#endregion
        //#region TDS
        // public static DataTable GetEmployeeTDS(string sessionId, string uniqueId)
        //{
        //    try
        //    {
        //        PayrollSession pSess = PayrollSession.CreatePayrollSession();
        //        DataTable dtTDS = pSess.GetEmployeeTDS(sessionId, uniqueId);
        //        if (dtTDS == null) return null;
                 
        //        return dtTDS;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.SalaryStructureMessges.SALARYSTRUCTURE_UPDATE_FAILURE, "")
        //            );
        //        return null;
        //    }
        //}
        //#endregion

        //#region Annual Benifits
        public static AnualBenifits GetAnualBenifits(int month, int year, int Empid)
        {
            return AnualBenifits.GetAnualBenifits(month, year, Empid);
        }
        //#endregion

        //#region Income Other Source
        //public static OtherIncomeSource[] GetOtherIncomeSource(int FYear, int Empid)
        //{
        //    return OtherIncomeSource.GetAllOtherIncomeSource(FYear, Empid);
        //}
        //public static String UpdateOtherIncomeSource(int ID, int EmpId, string Name, double amount, int FinancialYear, bool IsActive)
        //{
        //    try
        //    {
        //        OtherIncomeSource OtherIncomeSource = new OtherIncomeSource(ID);

        //        OtherIncomeSource.ID = ID;
        //        OtherIncomeSource.EmployeeID = EmpId;
        //        OtherIncomeSource.Name = Name;
        //        OtherIncomeSource.Amount = amount;
        //        OtherIncomeSource.FinancialYear = FinancialYear;
        //        OtherIncomeSource.IsActive = IsActive;

        //        String Status = OtherIncomeSource.Save();

        //        return Status;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.OtherSourceMessages.OTHERSOURCE_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRPayrollManagerDefs.OtherSourceMessages.OTHERSOURCE_UPDATE_FAILURE;
        //    }
        //}
        //public static String DeleteOtherIncomeSource(int ID)
        //{
        //    try
        //    {
        //        OtherIncomeSource EmpDecl = new OtherIncomeSource(ID);

        //        String Status = EmpDecl.Delete();

        //        return Status;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.OtherSourceMessages.OTHERSOURCE_DELETE_FAILURE, ID.ToString())
        //            );
        //        return HRPayrollManagerDefs.OtherSourceMessages.OTHERSOURCE_DELETE_FAILURE;
        //    }
        //}
        //#endregion 

        //#region Payroll Annual Configuraion
        //public static PayrollAnnualCongiguration GetPayrollAnnualConfig(int FYear, int Empid)
        //{
        //    return PayrollAnnualCongiguration.GetAllPayrollAnnualConfigurations(FYear, Empid);
        //}
        //public static String UpdatePayrollAnnualConfig(int ID, int EmployeeID, int FinancialYear, double RentPaid, double TDS, double LeaveEncashDays)
        //{
        //    try
        //    {
        //        PayrollAnnualCongiguration PayrollAnnualCongiguration = new PayrollAnnualCongiguration(ID);

        //        PayrollAnnualCongiguration.ID = ID;
        //        PayrollAnnualCongiguration.EmployeeID = EmployeeID;
        //        PayrollAnnualCongiguration.FinancialYear = FinancialYear;
        //        PayrollAnnualCongiguration.RentPaid = RentPaid;
        //        PayrollAnnualCongiguration.TDS = TDS;
        //        PayrollAnnualCongiguration.LeaveEncashDays = LeaveEncashDays;

        //        String Status = PayrollAnnualCongiguration.Save();

        //        return Status;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.PayrollAnnualConfigurationMessages.PAYANNUCONFIG_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRPayrollManagerDefs.PayrollAnnualConfigurationMessages.PAYANNUCONFIG_UPDATE_FAILURE;
        //    }
        //}
        //#endregion 
        
        //#region TDS Calculation
        
        //public static String CalculateTDS(int EmployeeID, int FinancialYear, double lvLimit)
        //{
        //    try
        //    {
        //        IncomeTax itax= new IncomeTax(EmployeeID,FinancialYear);

        //        itax.LeaveSalaryLimit = lvLimit;
        //        string maxFCP=IS91.Services.Common.GetAppSetting("MaximumFoodCouponAmount");
        //        if(maxFCP==string.Empty)maxFCP="0";
        //        itax.MaxFoodCouponAmount = double.Parse(maxFCP);
        //        string maxMCL = IS91.Services.Common.GetAppSetting("MaximumMedicalClaim");
        //        if (maxMCL == string.Empty) maxMCL = "0";
        //        itax.MaxMedicalClaim = double.Parse(maxMCL);
        //        string ednCess = IS91.Services.Common.GetAppSetting("EducationCess");
        //        if (ednCess == string.Empty) ednCess = "0";
        //        itax.EducationCess = double.Parse(ednCess);
        //        int chNo = new Employee_PayrollBusinessObject().GetNoOfChildren(EmployeeID);
        //        string ednallwval = "0";
        //        string ednallw = IS91.Services.Common.GetAppSetting("EducationAllowance");
        //        if (ednallw == string.Empty) ednallw = "0";
        //        string[] strEdn = ednallw.Split(",".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
        //        if (strEdn.Length > 0)
        //        {
        //            string chCnt="," + chNo.ToString() + ",";
        //            foreach(string ed in strEdn)
        //            {
        //                string[] ednvals = ed.Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        //                if (ednvals.Length > 0)
        //                {
        //                    if (chCnt.Contains("," + ednvals[0] + ","))
        //                    {
        //                        ednallwval = ednvals[1];
        //                        if (ednallwval == string.Empty) ednallwval = "0";
        //                        break;
        //                    }
        //                }

        //            }
                   
        //        }

        //        itax.MaxEducationAllowance = double.Parse(ednallwval);
                
        //        string otherExemp = IS91.Services.Common.GetAppSetting("MaxOtherExemptions");
        //        if (otherExemp == string.Empty) otherExemp = "0";
        //        itax.MaxOtherExemptions = double.Parse(otherExemp); 
        //        itax.CalculateIncomeTax();
                
              
        //       // String Status = itax.Save();

        //        return itax.TDSAmount.ToString(); //Status;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.TDS.TDS_UPDATE_FAILURE, "")
        //            );
        //        return HRPayrollManagerDefs.TDS.TDS_UPDATE_FAILURE;
        //    }
        //}

        //public static IncomeTax CalculateIncomeTax(int EmployeeID, int FinancialYear, double lvLimit)
        //{
        //    try
        //    {
        //        IncomeTax itax = new IncomeTax(EmployeeID, FinancialYear);

        //        itax.LeaveSalaryLimit = lvLimit;
        //        string maxFCP = IS91.Services.Common.GetAppSetting("MaximumFoodCouponAmount");
        //        if (maxFCP == string.Empty) maxFCP = "0";
        //        itax.MaxFoodCouponAmount = double.Parse(maxFCP);
        //        string maxMCL = IS91.Services.Common.GetAppSetting("MaximumMedicalClaim");
        //        if (maxMCL == string.Empty) maxMCL = "0";
        //        itax.MaxMedicalClaim = double.Parse(maxMCL);
        //        string ednCess = IS91.Services.Common.GetAppSetting("EducationCess");
        //        if (ednCess == string.Empty) ednCess = "0";
        //        itax.EducationCess = double.Parse(ednCess);
        //        int chNo = new Employee_PayrollBusinessObject().GetNoOfChildren(EmployeeID);
        //        string ednallwval = "0";
        //        string ednallw = IS91.Services.Common.GetAppSetting("EducationAllowance");
        //        if (ednallw == string.Empty) ednallw = "0";
        //        string[] strEdn = ednallw.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        //        if (strEdn.Length > 0)
        //        {
        //            string chCnt = "," + chNo.ToString() + ",";
        //            foreach (string ed in strEdn)
        //            {
        //                string[] ednvals = ed.Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        //                if (ednvals.Length > 0)
        //                {
        //                    if (chCnt.Contains("," + ednvals[0] + ","))
        //                    {
        //                        if (ednvals.Length > 1)
        //                        {
        //                            ednallwval = ednvals[1];
        //                        }
        //                        if (ednallwval == string.Empty) ednallwval = "0";
        //                        break;
        //                    }
        //                }

        //            }

        //        }

        //        itax.MaxEducationAllowance = double.Parse(ednallwval);

        //        string otherExemp = IS91.Services.Common.GetAppSetting("MaxOtherExemptions");
        //        if (otherExemp == string.Empty) otherExemp = "0";
        //        itax.MaxOtherExemptions = double.Parse(otherExemp);
        //        itax.CalculateIncomeTax();


        //        // String Status = itax.Save();

        //        return itax; //Status;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.TDS.TDS_UPDATE_FAILURE, "")
        //            );
        //        return null;
        //    }
        //}

        //public static String CalculateUpdateTDS(int EmployeeID, int FinancialYear, double lvLimit)
        //{
        //    try
        //    {
        //        IncomeTax itax = new IncomeTax(EmployeeID, FinancialYear);

        //        itax.LeaveSalaryLimit = lvLimit;
        //        string maxFCP = IS91.Services.Common.GetAppSetting("MaximumFoodCouponAmount");
        //        if (maxFCP == string.Empty) maxFCP = "0";
        //        itax.MaxFoodCouponAmount = double.Parse(maxFCP);
        //        string maxMCL = IS91.Services.Common.GetAppSetting("MaximumMedicalClaim");
        //        if (maxMCL == string.Empty) maxMCL = "0";
        //        itax.MaxMedicalClaim = double.Parse(maxMCL);
        //        string ednCess = IS91.Services.Common.GetAppSetting("EducationCess");
        //        if (ednCess == string.Empty) ednCess = "0";
        //        itax.EducationCess = double.Parse(ednCess);
        //        int chNo = new Employee_PayrollBusinessObject().GetNoOfChildren(EmployeeID);
        //        string ednallwval = "0";
        //        string ednallw = IS91.Services.Common.GetAppSetting("EducationAllowance");
        //        if (ednallw == string.Empty) ednallw = "0";
        //        string[] strEdn = ednallw.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        //        if (strEdn.Length > 0)
        //        {
        //            string chCnt = "," + chNo.ToString() + ",";
        //            foreach (string ed in strEdn)
        //            {
        //                string[] ednvals = ed.Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        //                if (ednvals.Length > 0)
        //                {
        //                    if (chCnt.Contains("," + ednvals[0] + ","))
        //                    {
        //                        ednallwval = ednvals[1];
        //                        if (ednallwval == string.Empty) ednallwval = "0";
        //                        break;
        //                    }
        //                }

        //            }

        //        }

        //        itax.MaxEducationAllowance = double.Parse(ednallwval);

        //        string otherExemp = IS91.Services.Common.GetAppSetting("MaxOtherExemptions");
        //        if (otherExemp == string.Empty) otherExemp = "0";
        //        itax.MaxOtherExemptions = double.Parse(otherExemp);
        //        itax.CalculateIncomeTax();


        //         String Status = itax.Save();

        //        return itax.TDSAmount.ToString(); //Status;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.TDS.TDS_UPDATE_FAILURE, "")
        //            );
        //        return HRPayrollManagerDefs.TDS.TDS_UPDATE_FAILURE;
        //    }
        //}
        //#endregion 

        //#region Gratuity calculation
        //public static Employees GetEmployeeGratuityInfo(string EmpCode)
        //{
        //    return Employees.GetEmployeeDetailsForGratuity(EmpCode);
        //}
        //public static string IsEmployeeCodeExists(string EmpCode)
        //{
        //    return Employees.ValidateEmpCode(EmpCode);
        //}
        //public static String UpdateGratuityCalculation(int ID, int employeeID, double LastdrawnSalary,double GratuityAmount,double intrest,double superannuation, int UpdatedBy)
        //{
        //    try
        //    {
        //        GratuityCalculations Gratuity = new GratuityCalculations(ID);
        //        Gratuity.ID = ID;
        //        Gratuity.EmployeeID = employeeID;
        //        Gratuity.LastdrawnSalary = LastdrawnSalary;
        //        Gratuity.GratuityAmount = GratuityAmount;
        //        Gratuity.Intrest = intrest;
        //        Gratuity.SuperannuationAmount = superannuation;
        //        Gratuity.UpdatedBy = UpdatedBy;

        //        String Status = Gratuity.Save();

        //        return Status;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRPayrollManagerDefs.GRATUITY.GRATUITY_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRPayrollManagerDefs.GRATUITY.GRATUITY_UPDATE_FAILURE;
        //    }
        //}
        //#endregion

        //public static String CheckPayrollGenerated(int EmpID, int Month,int Year)
        //{
        //    return LoanRequest.CheckPayrollGenerated(EmpID, Month, Year);
        //}
        public static String CheckPayrollGenerated(int EmpID, int Month, int Year)
        {
            return EmployeePayroll.CheckPayrollGenerated(EmpID, Month, Year);
        }
    }
}
