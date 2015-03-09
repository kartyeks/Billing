using System.Globalization;
using HRManager.BusinessObjects;
using HRManager.DTO;
using IRCAKernel;
using System;
using System.Reflection;

namespace HRManager.Entity.EmployeesInfo
{
    public class EmployeeSalaryDetails : EmployeeInfo
    {
        private int _id;
        private int _employeeId;
        private Double _ctc;
        private int _esop;
        private Double _basic;
        private bool _isActive;
        private DateTime _effectedDate;

        public int Id { get { return _id; } set { _id = value; } }
        public int EmployeeId { get { return _employeeId; } set { _employeeId = value; } }
        public Double Ctc { get { return _ctc; } set { _ctc = value; } }
        public int Esop { get { return _esop; } set { _esop = value; } }
        public Double Basic { get { return _basic; } set { _basic = value; } }
        public bool IsActive { get { return _isActive; } set { _isActive = value; } }
        public DateTime EffectedDate { get { return _effectedDate; } set { _effectedDate = value; } }

          public EmployeeSalaryDetails()
        {

        }

          public EmployeeSalaryDetails(int employeeId)
        {
            Update(new Employee_SalaryBusinessObject().GetSalaryDetails(employeeId));
        }

          public void Update(Employee_Salary dto)
          {
              
              if (dto != null)
              {
                  
                  _id = dto.ID;
                  _employeeId = dto.EmployeeID;
                  _ctc = dto.CTC;
                  _esop = dto.ESOP;
                  _basic = dto.Basic;
                  _isActive = IsActive;
                  _effectedDate = DateTime.Now;
              }
          }
          private Employee_Salary GetDto()
          {
              Employee_Salary dto = new Employee_Salary();
              dto.ID = 0;
              dto.EmployeeID = _employeeId;
              dto.CTC = _ctc;
              dto.ESOP = _esop;
              dto.Basic = _basic;
              dto.IsActive = true;
              dto.EffectedDate = DateTime.Now;
              return dto;
          }
          public String Save()
          {
              try
              {
                  Employee_SalaryBusinessObject bo = new Employee_SalaryBusinessObject();
                  Employee_Salary dto = GetDto();
                  if (dto.ID != 0)
                  {
                      bo.Update(dto);
                  }
                  else
                  {
                      new Employee_SalaryBusinessObject().DeactivePreRecords(dto.EmployeeID);
                      _id = bo.Create(dto);
                  }
                  AddEmployeeAllowanceAndDeductions();
                  return _id.ToString(CultureInfo.InvariantCulture);
              }
              catch (Exception ex)
              {
                  IRCAExceptionHandler.HandleException(ex);
                  return ex.Message;
              }
          }

          private void AddEmployeeAllowanceAndDeductions()
        {
            CTCDetails c = HREmployeeManager.CalculateCTCDetails(_ctc);
            Type t = typeof(CTCDetails);
            foreach (FieldInfo field in t.GetFields())
            {

              if (field.Name != "PF")
              {
                Assign_Emp_Allowance a = new Assign_Emp_Allowance();
                a.ID = 0;
                a.EmployeeSalaryID = _id;
                a.AllowanceID = new Master_Salary_AllowanceBusinessObject().GetAllowanceIdFromCode(field.Name);
                a.Value = Convert.ToDouble(c.GetValue(field.Name));
                  new Assign_Emp_AllowanceBusinessObject().Create(a);
              }
              else
              {
                  Assign_Emp_Deduction d = new Assign_Emp_Deduction();
                  d.ID = 0;
                  d.EmployeeSalaryID = _id;
                  d.DeductionID = new Master_Salary_DeductionsBusinessObject().GetDeductionsIdFromCode(field.Name);
                  d.Value = Convert.ToDouble(c.GetValue(field.Name));
                  new Assign_Emp_DeductionBusinessObject().Create(d);
              }

            }
            
        }
        #region JGridDataObject Members

        public object GetGridData()
        {
            return this;
        }

        #endregion
    }
}
