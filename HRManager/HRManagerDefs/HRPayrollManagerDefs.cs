using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager
{
  public  class HRPayrollManagerDefs
    { 
        #region GardeSalary
      public class GardeSalaryMessges
      {
        
          public static readonly String GRADESALARY_UPDATE_SUCCESS = "Assign Grade Salary details updated successfully";
          public static readonly String GRADESALARY_ADDED_SUCCESS = "Assign Grade Salary details added successfully";
          public static readonly String GRADESALARY_UPDATE_FAILURE = "Error on updating the Assign Grade Salary info";

          public static readonly String DEACTIVATE_SUCCESS = "Grade Salary deactivated successfully";
          public static readonly String ACTIVATE_SUCCESS = "Grade Salary activated successfully";
          public static readonly String SALARYGRADE_EXISTS = "The selected Grade salary already exists";

        
      }
  #endregion

        #region SalaryAllowance
      public class SalaryAllowanceMessages
      {
          
          public static readonly String EMPTY_ALLOWANCE = "Allowance name cannot be empty";
          public static readonly String ALLOWANCE_EXISTS = "The Allowance Name already exists";

          public static readonly String ALLOWANCE_UPDATE_SUCCESS = "Salary Allowance updated successfully";
          public static readonly String ALLOWANCE_ADDED_SUCCESS = "Salary Allowance added successfully";
          public static readonly String ALLOWANCE_UPDATE_FAILURE = "Error on updating the Salary Allowance ";

          public static readonly String DEACTIVATE_SUCCESS = "Salary Allowance deactivated successfully";
          public static readonly String ACTIVATE_SUCCESS = "Salary Allowance activated successfully";
          public static readonly String ALLOWANCE_REFERED = "The selected Salary Allowance already referred";
          public static readonly String ALLOWANCE_NOTEXISTS = "No Allowances esits ";

          

      }
#endregion

        #region SalaryDeductions
      public class SalaryDeductionMessges
      {
         
          public static readonly String SALARYDEDUCTION_UPDATE_SUCCESS = "Salary deduction details updated successfully";
          public static readonly String SALARYDEDUCTION_ADDED_SUCCESS = "Salary deduction details added successfully";
          public static readonly String SALARYDEDUCTION_UPDATE_FAILURE = "Error on updating the Salary deduction info";

          public static readonly String DEACTIVATE_SUCCESS = "Salary deduction deactivated successfully";
          public static readonly String ACTIVATE_SUCCESS = "Salary deduction activated successfully";
          public static readonly String SALARYDEDUCTION_EXISTS = "Salary deduction already exists";
          public static readonly String DEDUCTIONS_NOTEXISTS = "No Deduction ";       
      } 
 #endregion

        #region PayrollAnnualAdditions
      public class PayrollAnnualAdditionsMessage
      {
        
          public static readonly String EMPTY_NAME = "Name cannot be empty";
          public static readonly String NAME_EXISTS = "The Name exists already";

          public static readonly String ADDITION_UPDATE_SUCCESS = "Salary Annual Addition updated successfully";
          public static readonly String ADDITION_ADDED_SUCCESS = "Salary Annual Addition added successfully";
          public static readonly String ADDITION_UPDATE_FAILURE = "Error on updating the AnnualAddition";

          public static readonly String DEACTIVATE_SUCCESS = "Annual Addition deactivated successfully";
          public static readonly String ACTIVATE_SUCCESS = "Annual Addition activated successfully";
          public static readonly String ADDITION_REFERED = "The selected Annual Addition already referred";

        

      }
  #endregion

        #region GradeAllowances
      public class GardeAllowanceMessges
      {

          public static readonly String GRADEALLOWANCES_UPDATE_SUCCESS = "Assign Grade Allowances details updated successfully";
          public static readonly String GRADEALLOWANCES_ADDED_SUCCESS = "Assign Grade Allowances details added successfully";
          public static readonly String GRADEALLOWANCES_UPDATE_FAILURE = "Error on updating the Assign Grade Allowances info";

          public static readonly String DEACTIVATE_SUCCESS = "Grade Allowances deactivated successfully";
          public static readonly String ACTIVATE_SUCCESS = "Grade Allowances  activated successfully";
          public static readonly String GRADEALLOWANCES_EXISTS = "The selected Grade Allowance already exists";


      }
      #endregion

        #region Tax Exemption Group
      public class TaxExcemptionGroupMessages
      {

          public static readonly String EMPTY_NAME = "Name cannot be empty";
          public static readonly String NAME_EXISTS = "The Name exists already";

          public static readonly String TAXEGROUP_UPDATE_SUCCESS = "Tax Exemption Group updated successfully";
          public static readonly String TAXEGROUP_ADDED_SUCCESS = "Tax Exemption Group added successfully";
          public static readonly String TAXEGROUP_UPDATE_FAILURE = "Error on updating the Tax Exemption Group";

          public static readonly String DEACTIVATE_SUCCESS = "Tax Exemption Group deactivated successfully";
          public static readonly String ACTIVATE_SUCCESS = "Tax Exemption Group activated successfully";
          public static readonly String TAXEGROUP_REFERED = "The selected Tax Exemption Group already referred";



      }
      #endregion

        #region Tax Exemption
      public class TaxExemptionMessages
      {

          public static readonly String EMPTY_NAME = "Name cannot be empty";
          public static readonly String NAME_EXISTS = "The Name exists already";

          public static readonly String TAXEXEMPTION_UPDATE_SUCCESS = "Tax Exemption updated successfully";
          public static readonly String TAXEXEMPTION_ADDED_SUCCESS = "Tax Exemption added successfully";
          public static readonly String TAXEXEMPTION_UPDATE_FAILURE = "Error on updating the Tax Exemption";

          public static readonly String DEACTIVATE_SUCCESS = "Tax Exemption deactivated successfully";
          public static readonly String ACTIVATE_SUCCESS = "Tax Exemption activated successfully";
          public static readonly String TAXEXEMPTION_REFERED = "The selected Tax Exemption already referred";



      }
      #endregion

        #region SalaryStructure
      public class SalaryStructureMessges
      {

          public static readonly String DEDUCTIONS_UPDATE_SUCCESS = "Assign Grade Allowances details updated successfully";
          public static readonly String DEDUCTIONS_ADDED_SUCCESS = "Assign Grade Allowances details added successfully";
          public static readonly String DEDUCTIONS_UPDATE_FAILURE = "Error on updating the Assign Grade Allowances info";

          public static readonly String SALARYSTRUCTURE_UPDATE_SUCCESS = "Assign Grade Allowances details updated successfully";
          public static readonly String SALARYSTRUCTURE_ADDED_SUCCESS = "Assign Grade Allowances details added successfully";
          public static readonly String SALARYSTRUCTURE_UPDATE_FAILURE = "Error on updating the Assign Grade Allowances info";
          public static readonly String DEDUCTIONS_EXISTS = "The selected Deduction already exists";
          public static readonly String NEG_SPL_ALLOWANCE = "Total salary should not exceeds CTC";
          public static readonly String EMPDEDUCTION_DELETED_SUCCESS = "Deduction deleted successfully";

      }
      #endregion
  
        #region Employee Declaration
      public class EmployeeDeclarationMessages
      {

          public static readonly String NAME_EXISTS = "The Name exists already";

          public static readonly String EMPLOYEEDECLARATION_UPDATE_SUCCESS = "Employee Declaration updated successfully";
          public static readonly String EMPLOYEEDECLARATION_ADDED_SUCCESS = "Employee Declaration added successfully";
          public static readonly String EMPLOYEEDECLARATION_DELETE_SUCCESS = "Employee Declaration deleted successfully";
          public static readonly String EMPLOYEEDECLARATION_UPDATE_FAILURE = "Error on updating the Employee Declaration ";
          public static readonly String EMPLOYEEDECLARATION_DELETE_FAILURE = "Error on Deleting the Employee Declaration ";
          public static readonly String EMPLOYEEDECLARATION_REFERED = "The selected Tax Exemption already referred";

      }
      #endregion

        #region Tax
      public class TaxMessges
      {

          public static readonly String TAX_UPDATE_SUCCESS = "Taxdetails updated successfully";
          public static readonly String TAX_ADDED_SUCCESS = "Tax details added successfully";
          public static readonly String TAX_UPDATE_FAILURE = "Error on updating the Tax info";

          public static readonly String DEACTIVATE_SUCCESS = "Tax deactivated successfully";
          public static readonly String ACTIVATE_SUCCESS = "Tax activated successfully";
          public static readonly String TAX_EXISTS = "Tax already exists";


      }
      #endregion

        #region PayRoll
      public class Payroll
      {
          public static readonly String PAYROLL_UPDATE_SUCCESS = "Payroll updated successfully";
      }

        #endregion

        #region TDS
      public class TDS
      {
          public static readonly String EMPTY_EMPLOYEE = "Employee ID can not be empty";
          public static readonly String EMPTY_FINANCIALYEAR = "Financial Year can not be empty";
          public static readonly String ERROR_CALCULATING = "Calculation error";
          public static readonly String TDS_UPDATE_SUCCESS = "TDS calculated and updated successfully";
          public static readonly String TDS_UPDATE_FAILURE = "Error on updating TDS";
      }
      #endregion

        #region Income From other source
      public class OtherSourceMessages
      {
          public static readonly String OTHERSOURCE_UPDATE_SUCCESS = "Income's Other source Details updated successfully";
          public static readonly String OTHERSOURCE_ADDED_SUCCESS = "Income's Other source Details added successfully";
          public static readonly String OTHERSOURCE_DELETE_SUCCESS = "Income's Other source Details deleted successfully";
          public static readonly String OTHERSOURCE_UPDATE_FAILURE = "Error on updating the Income's Other source Details ";
          public static readonly String OTHERSOURCE_DELETE_FAILURE = "Error on Deleting the Income's Other source Details ";
          public static readonly String OTHERSOURCE_REFERED = "The selected Income's Other source Details already referred";
      }
        #endregion

        #region Payroll Annual Configuration
      public class PayrollAnnualConfigurationMessages
      {
          public static readonly String PAYANNUCONFIG_UPDATE_SUCCESS = "Payroll Annual Configuration Details updated successfully";
          public static readonly String PAYANNUCONFIG_ADDED_SUCCESS = "Payroll Annual Configuration Details added successfully";
          public static readonly String PAYANNUCONFIG_UPDATE_FAILURE = "Error on updating the Payroll Annual Configuration Details ";
          public static readonly String PAYANNUCONFIG_REFERED = "The selected Income's Other source Details already referred";
          public static readonly String PAYANNUCONFIG_LEAVEENCASH_GREATER = "Leave for Encashment must not be greater than from Assign Encash Leave";
      }
      #endregion

        #region Employee Allowance 
      public class EmployeeAllowanceMessages
      {
          public static readonly String EMPALLOWANCE_UPDATE_SUCCESS = "Employee Allowance Details updated successfully";
          public static readonly String EMPALLOWANCE_ADDED_SUCCESS = "Employee Allowance Details added successfully";
          public static readonly String EMPALLOWANCE_UPDATE_FAILURE = "Error on updating the Employee Allowance Details ";
          public static readonly String EMPALLOWANCE_EXISTS = "Allowance already exists";
          public static readonly String EMPALLOWANCE_DELETED_SUCCESS = "Allowance deleted successfully";
          public static readonly String EMPALLOWANCE_DELETE_FAILURE = "Error on deleting Allowance";
          public static readonly String EMPALLOWANCE_NOT_OPTIONAL = "Selected Allowance is mandatory";
                    
      }
      #endregion

        #region Gratuity Calcultion
      public class GRATUITY
      {
          public static readonly String GRATUITY_EMPLOYEE_EXISTS = "Gratuity already exists for the Employee";
          public static readonly String GRATUITY_UPDATE_SUCCESS = "Gratuity calculated and updated successfully";
          public static readonly String GRATUITY_UPDATE_FAILURE = "Error on updating Gratuity calculation";
      }
      #endregion

        #region Overtime
      public class EmployeeOvertimeMessages
      {
          public static readonly String PAYROLL_ADDED = "Employee payroll is already added for the month and year";
          public static readonly String EMPOVERTIME_UPDATE_SUCCESS = "Employee Overtime Details updated successfully";
          public static readonly String EMPOVERTIME_ADDED_SUCCESS = "Employee Overtime Details added successfully";
          public static readonly String EMPOVERTIME_UPDATE_FAILURE = "Error on updating the Employee Overtime Details ";
          public static readonly String EMPOVERTIME_EXISTS = "Overtime Details already exists";
          public static readonly String EMPOVERTIME_DELETED_SUCCESS = "Overtime Details deleted successfully";
          public static readonly String EMPOVERTIME_DELETE_FAILURE = "Error on deleting Overtime Details";
          public static readonly String EMPOVERTIME_NOT_OPTIONAL = "Enter Overtime Hours";

      }
      #endregion
    }
}
