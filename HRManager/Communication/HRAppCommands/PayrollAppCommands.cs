using System;

public class PayrollAppCommands : WebAppCommands
{
    #region Assign Grade Salary

    public static readonly String GRADESALRY_DETAILS = "GRADESALRY_DETAILS";
    public static readonly String UPDATE_GRADESALRY = "UPDATE_GRADESALRY";
    public static readonly String ACTIVATE_GRADESALRY = "ACTIVATE_GRADESALRY";
    public static readonly String DEACTIVATE_GRADESALRY = "DEACTIVATE_GRADESALRY";
    public static readonly String INACTIVE_GRADESALRY = "INACTIVE_GRADESALRY";
    public static readonly String GRADESALARY_BASIC_DETAILS = "GRADESALARY_BASIC_DETAILS";


    #endregion


    #region Salary Allowance
    public static readonly String SALARY_ALLOWANCES = "SALARY_ALLOWANCES";
    public static readonly String INACTIVE_SALARYALLOWANCES = "INACTIVE_SALARYALLOWANCES";
    public static readonly String UPDATE_SALARYALLOWANCE = "UPDATE_SALARYALLOWANCE";
    public static readonly String ACTIVATE_SALARYALLOWANCE = "ACTIVATE_SALARYALLOWANCE";
    public static readonly String DEACTIVATE_SALARYALLOWANCE = "DEACTIVATE_SALARYALLOWANCE";
    public static readonly String ALLOWANCE_MONTHLY = "MON";
    public static readonly String ALLOWANCE_YEARLY = "YRL";

    public static readonly String COMBOALLOWANCES_DETAILS = "COMBOALLOWANCES_DETAILS";
    public static readonly String GET_EMPLOYEE_ALLOWANCE = "GET_EMPLOYEE_ALLOWANCE";
    public static readonly String GET_ALLOWANCE_LIMIT = "GET_ALLOWANCE_LIMIT";
    public static readonly String UPDATE_EMPLOYEE_ALLOWANCE = "UPDATE_EMPLOYEE_ALLOWANCE";
    public static readonly String DELETE_EMPLOYEE_ALLOWANCE = "DELETE_EMPLOYEE_ALLOWANCE";
    public static readonly String COMBO_OPTIONAL_ALLOWANCES_DETAILS = "COMBO_OPTIONAL_ALLOWANCES_DETAILS";
    public static readonly String CALCULATE_EMP_SPL_ALLOWANCE = "CALCULATE_EMP_SPL_ALLOWANCE";


    #endregion

    #region Salary deductions

    public static readonly String SALRYDEDUCTION_DETAILS = "SALRYDEDUCTION_DETAILS";
    public static readonly String UPDATE_SALRYDEDUCTION = "UPDATE_SALRYDEDUCTION";
    public static readonly String ACTIVATE_SALRYDEDUCTION = "ACTIVATE_SALRYDEDUCTION";
    public static readonly String DEACTIVATE_SALRYDEDUCTION = "DEACTIVATE_SALRYDEDUCTION";
    public static readonly String INACTIVE_SALRYDEDUCTION = "INACTIVE_SALRYDEDUCTION";
    public static readonly String COMBODEDUCTIONS_DETAILS = "COMBODEDUCTIONS_DETAILS";
    public static readonly String GET_DEDUCTION_LIMIT = "GET_DEDUCTION_LIMIT";

    public static readonly String DEDUCTION_MONTHLY = "MON";
    public static readonly String DEDUCTION_YEARLY = "YRL";
    #endregion

    #region Payroll Annual Additions

    public static readonly String ANNUALADDITION_DETAILS = "ANNUALADDITION_DETAILS";
    public static readonly String INACTIVE_ANNUALADDITIONS = "INACTIVE_ANNUALADDITIONS";
    public static readonly String UPDATE_ANNUALADDITION = "UPDATE_ANNUALADDITION";
    public static readonly String ACTIVATE_ANNUALADDITION = "ACTIVATE_ANNUALADDITION";
    public static readonly String DEACTIVATE_ANNUALADDITION = "DEACTIVATE_ANNUALADDITION";


    #endregion

    #region Assign Grade Allowances

    public static readonly String GRADEALLOWANCES_DETAILS = "GRADEALLOWANCES_DETAILS";
    public static readonly String UPDATE_GRADEALLOWANCES = "UPDATE_GRADEALLOWANCES";
    public static readonly String ACTIVATE_GRADEALLOWANCES = "ACTIVATE_GRADEALLOWANCES";
    public static readonly String DEACTIVATE_GRADEALLOWANCES = "DEACTIVATE_GRADEALLOWANCES";
    public static readonly String INACTIVE_GRADEALLOWANCES = "INACTIVE_GRADEALLOWANCES";


    #endregion

    #region Tax Excemption Group

    public static readonly String TAXEXCEMPTIONGROUP_DETAILS = "TAXEXCEMPTIONGROUP_DETAILS";
    public static readonly String UPDATE_TAXEXCEMPTIONGROUP = "UPDATE_TAXEXCEMPTIONGROUP";
    public static readonly String ACTIVATE_TAXEXCEMPTIONGROUP = "ACTIVATE_TAXEXCEMPTIONGROUP";
    public static readonly String DEACTIVATE_TAXEXCEMPTIONGROUP = "DEACTIVATE_TAXEXCEMPTIONGROUP";
    public static readonly String INACTIVE_TAXEXCEMPTIONGROUP_DETAILS = "INACTIVE_TAXEXCEMPTIONGROUP_DETAILS";


    #endregion

    #region Tax Excemptions

    public static readonly String TAXEXEMPTIONGROUP_DETAILS_FORCOMBO = "TAXEXEMPTIONGROUP_DETAILS_FORCOMBO";
    public static readonly String TAXEXEMPTION_DETAILS = "TAXEXEMPTION_DETAILS";
    public static readonly String UPDATE_TAXEXEMPTION = "UPDATE_TAXEXEMPTION";
    public static readonly String ACTIVATE_TAXEXEMPTION = "ACTIVATE_TAXEXEMPTION";
    public static readonly String DEACTIVATE_TAXEXEMPTION = "DEACTIVATE_TAXEXEMPTION";
    public static readonly String INACTIVE_TAXEXEMPTION_DETAILS = "INACTIVE_TAXEXEMPTION_DETAILS";

    #endregion

    #region Employee For Payroll
    public static readonly String GET_EMPLOYEE_DEDUCTIONS = "GET_EMPLOYEE_DEDUCTIONS";
    public static readonly String UPDATE_EMPLOYEE_DEDUCTIONS = "UPDATE_EMPLOYEE_DEDUCTIONS";
    public static readonly String GET_EMPLOYEE_SALARY = "GET_EMPLOYEE_SALARY";
    public static readonly String UPDATE_EMPLOYEE_SALARY = "UPDATE_EMPLOYEE_SALARY";
    public static readonly String DELETE_EMPLOYEE_DEDUCTIONS = "DELETE_EMPLOYEE_DEDUCTIONS";

    #endregion

    #region Employee Declaration
    public static readonly String GET_FINANCIALYEARS = "GET_FINANCIALYEARS";
    public static readonly String GET_TAXNAMES = "GET_TAXNAMES";
    public static readonly String EMPLOYEE_PROJECTION_DETAILS = "EMPLOYEE_PROJECTION_DETAILS";
    public static readonly String EMPLOYEE_ACTUAL_DETAILS = "EMPLOYEE_ACTUAL_DETAILS";
    public static readonly String UPDATE_EMPLOYEE_DECLARATION = "UPDATE_EMPLOYEE_DECLARATION";
    public static readonly String DELETE_DECLARATION = "DELETE_DECLARATION";
    public static readonly String EMPLOYEE_OTHER_INCOME_SOURCE_DETAILS = "EMPLOYEE_OTHER_INCOME_SOURCE_DETAILS";
    public static readonly String UPDATE_EMPLOYEE_OTHER_INCOME_SOURCE = "UPDATE_EMPLOYEE_OTHER_INCOME_SOURCE";
    public static readonly String DELETE_OTHER_INCOME_SOURCE = "DELETE_OTHER_INCOME_SOURCE";

    #endregion

    #region Tax

    public static readonly String TAX_DETAILS = "TAX_DETAILS";
    public static readonly String TAX_SLABDETAILS = "TAX_SLABDETAILS";
    public static readonly String UPDATE_TAX = "UPDATE_TAX";
    public static readonly String ACTIVATE_TAX = "ACTIVATE_TAX";
    public static readonly String DEACTIVATE_TAX = "DEACTIVATE_TAX";
    public static readonly String INACTIVE_TAX = "INACTIVE_TAX";


    #endregion

    #region Payroll
    public static readonly String GETPAYROLL_DETAILS = "GETPAYROLL_DETAILS";
    public static readonly String UPDATEPAYROLL_DETAILS = "UPDATEPAYROLL_DETAILS";
    public static readonly String GETANNUL_BENIFITS = "GETANNUL_BENIFITS";
    public static readonly String UPDATE_GRATUITY = "UPDATE_GRATUITY";
    public static readonly String EMPLOYEE_GRATUITY_DETAILS = "EMPLOYEE_GRATUITY_DETAILS";
    public static readonly String CHECK_PAYROLL_GENERATED = "CHECK_PAYROLL_GENERATED";

    #endregion

    #region Income Tax
    public static readonly String CALCULATE_EMPLOYEE_TDS = "CALCULATE_EMPLOYEE_TDS";
    public static readonly String UPDATE_EMPLOYEE_TDS = "UPDATE_EMPLOYEE_TDS";
    public static readonly String GET_EMPLOYEE_TDS = "GET_EMPLOYEE_TDS";
    #endregion

    #region Payroll Annual Config
    public static readonly String PAYROLL_ANNUALCONFIG_DETAILS = "PAYROLL_ANNUALCONFIG_DETAILS";
    public static readonly String UPDATE_PAYROLL_ANNUALCONFIGURATION = "UPDATE_PAYROLL_ANNUALCONFIGURATION";

    #endregion

    #region Payroll Constants
    public static readonly String PF = "PF";
    public static readonly String ESI = "ESI";
    public static readonly String LOAN = "LON";
    public static readonly String ADVANCE = "ADV";
    public static readonly String TDS = "TDS";
    public static readonly String FCP = "FCP";
    public static readonly String HRA = "HRA";
    public static readonly String Conveyance = "CON";
    public static readonly String MCL = "MCL"; // Medical Claim
    public static readonly String TAX = "TAX";
    public static readonly String DED = "DED";
    public static readonly String EDN= "EDN";

    #endregion

    #region Annual Constants
    public static readonly String LTA = "LTA";
    public static readonly String SUPERANNUATION = "SPA";
    public static readonly String GRATUITY = "GRT";
    public static readonly String BONUS_GRATIA = "BNS";
    public static readonly String LEAVE_ENCASHMENT = "LVE";
    public static readonly String MEDICAL_REIMBURSEMENT = "MDR";
    public static readonly String MEDICLAIM_BENEFITS = "MDB";
    public static readonly String CAR_MAINTENANCE = "CAR";
    
    #endregion


    #region Overtime
    public static readonly String GET_EMPLOYEE_OVERTIMELIST = "GET_EMPLOYEE_OVERTIMELIST";
    public static readonly String GET_EMPLOYEE_OVERTIME = "GET_EMPLOYEE_OVERTIME";
    public static readonly String UPDATE_EMPLOYEE_OVERTIME = "UPDATE_EMPLOYEE_OVERTIME";
    public static readonly String GET_OTDEPARTMENT_DETAILS = "GET_OTDEPARTMENT_DETAILS";
    public static readonly String DELETE_EMPLOYEE_OVERTIME = "DELETE_EMPLOYEE_OVERTIME";
    

    
    #endregion


}

