using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IS91.Services.DataBlock;
using IRCA.Communication;

namespace HRManager.Entity
{
    public class SalaryDeductions : JGridDataObject
    {
        private int _ID;
        private String _Name;
        private String _Period;
        private Double _Limit;
        private bool _IsEmployee;
        private bool _IsPercentage;
        private bool _IsActive;
        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;
        private int _UpdateBy;
        private bool _IsTaxExempted;
        private String _Code;

        public static readonly string ESI = "ESI";
        public static readonly string PF = "PF";

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
        public String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        public String Code
        {
            get
            {
                return _Code;
            }
            set
            {
                _Code = value;
            }
        }
        public String Period
        {
            get
            {
                return _Period;
            }
            set
            {
                _Period = value;
            }
        }
        public double Limit
        {
            get
            {
                return _Limit;
            }
            set
            {
                _Limit = value;
            }
        }
        public bool IsEmployee
        {
            get
            {
                return _IsEmployee;
            }
            set
            {
                _IsEmployee = value;
            }
        }
        public bool IsPercentage
        {
            get
            {
                return _IsPercentage;
            }
            set
            {
                _IsPercentage = value;
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


        public bool IsTaxExempted
        {
            get
            {
                return _IsTaxExempted;
            }
            set
            {
                _IsTaxExempted = value;
            }
        }

        public int UpdatedBy
        {
            get { return _UpdateBy; }
            set { _UpdateBy = value; }
        }
        public int CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }
        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }
        public int ModifiedBy
        {
            get { return _ModifiedBy; }
            set { _ModifiedBy = value; }
        }
        public DateTime ModifiedDate
        {
            get { return _ModifiedDate; }
            set { _ModifiedDate = value; }
        }
        private bool _IsNew;

        /// <summary>
        /// Update the SalaryDeductions field using Master_Salary_Deductions.
        /// </summary>
        /// <param name="Policy">Object of Master_Salary_Deductions class</param>
        private void Update(Master_Salary_Deductions SalaryDedust)
        {
            if (SalaryDedust != null)
            {
                _ID = SalaryDedust.ID;
                _Name = SalaryDedust.Name;
                _Period = SalaryDedust.DeductionPeriod;
                _Limit = SalaryDedust.Limit;
                _IsPercentage = SalaryDedust.IsPercentage;
                _IsEmployee = SalaryDedust.IsEmployeeLevel;
                _Code = SalaryDedust.DeductionCode;
                _IsActive = SalaryDedust.IsActive;
                _IsTaxExempted = SalaryDedust.IsTaxExempted;
                _IsNew = false;
                _CreatedBy = SalaryDedust.CreatedBy;
                _ModifiedBy = SalaryDedust.ModifiedBy;
                _CreatedDate = SalaryDedust.CreatedDate;
                _ModifiedDate = SalaryDedust.ModifiedDate;
            }
            else
            {
                _IsNew = true;
            }
        }
        /// <summary>
        /// Consturctor of SalaryDeductions class.
        /// Update SalaryDeductions fields using Master_Salary_Deductions.
        /// </summary>
        /// <param name="Policy">Object of Master_Policy class</param>
        public SalaryDeductions(Master_Salary_Deductions SalaryDedust)
        {
            Update(SalaryDedust);
        }
         /// <summary>
        /// Consturctor of SalaryDeductions class.
        /// Update SalaryDeductions fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains SalaryDeductions ID</param>
        public SalaryDeductions(int ID)
        {
            Master_Salary_Deductions SalaryDedust = new Master_Salary_DeductionsBusinessObject().GetMaster_Salary_Deductions(ID);

            if (SalaryDedust == null && ID > 0)
            {
                throw new IRCAException("Invalid Salary Deduction", ID.ToString());
            }

            Update(SalaryDedust);
        }
        /// <summary>
        /// Consturctor of SalaryDeductions class.
        /// Set variables for new SalaryDeductions.  
        /// </summary>
        public SalaryDeductions()
        {
            _ID = 0;
            _IsNew = true;
        }
        /// <summary>
        /// Save SalaryDeductions.If new SalaryDeductions it add and in case of edit it update the SalaryDeductions.
        /// </summary>
        /// <returns>empty string</returns>
        private String SaveSalaryDeduction()
        {

            Master_Salary_Deductions SalaryDedust = new Master_Salary_Deductions();
            SalaryDedust.ID = _ID;
            SalaryDedust.DeductionPeriod=_Period;
            SalaryDedust.Name = _Name;
            SalaryDedust.DeductionCode = _Code;
            SalaryDedust.IsTaxExempted= _IsTaxExempted;
            SalaryDedust.IsEmployeeLevel = _IsEmployee;
            SalaryDedust.IsPercentage = _IsPercentage;
            SalaryDedust.Limit = _Limit;
            SalaryDedust.IsActive = _IsActive;
            SalaryDedust.ModifiedBy = _ModifiedBy;
            SalaryDedust.ModifiedDate = DateTime.Now;
            SalaryDedust.CreatedBy = _CreatedBy;
            SalaryDedust.CreatedDate = _CreatedDate;

            if (_IsNew)
            {
                SalaryDedust.CreatedBy = _UpdateBy;
                SalaryDedust.CreatedDate = DateTime.Now;
                SalaryDedust.ID = new Master_Salary_DeductionsBusinessObject().Create(SalaryDedust);
            }
            else
            {
                SalaryDedust.ModifiedBy = _UpdateBy;
                SalaryDedust.ModifiedDate = DateTime.Now;
                SalaryDedust.ID = _ID;
                new Master_Salary_DeductionsBusinessObject().Update(SalaryDedust);
            }

            return String.Empty;
        }

        /// <summary>
        ///Validate SalaryDeductions for empty and already exist status and then save SalaryDeductions.
        /// </summary>
        /// <returns>String return from the SaveSalaryDeduction method</returns> 
        public String Save()
        {
            String Status = Validate();

            if (Status != String.Empty)
            {
                return Status;
            }

            return SaveSalaryDeduction();
        }
        /// <summary>
        /// Validate Name for empty and already exist status.
        /// </summary>
        /// <returns>empty string</returns>
        private String Validate()
        {
            Master_Salary_DeductionsBusinessObject SalaryDeductBO = new Master_Salary_DeductionsBusinessObject();
            if (SalaryDeductBO.IsDeductionExists(_Name,_ID))
            {
                return HRPayrollManagerDefs.SalaryDeductionMessges.SALARYDEDUCTION_EXISTS;
            }
            return String.Empty;
        }
        /// <summary>
        /// Activate the SalaryDeductions
        /// </summary>
        /// <param name="ActivatedBy">id of user who want to activate SalaryDeductions</param>
        /// <returns>String return from the SaveSalaryDeduction method</returns>
        public String Activate(int ActivatedBy)
        {
            _UpdateBy = ActivatedBy;
            _IsActive = true;

            return SaveSalaryDeduction();
        }
        /// <summary>
        /// Deactivate the SalaryDeductions
        /// </summary>
        /// <param name="DeActivatedBy">id of user who want to DeActivate SalaryDeductions</param>
        /// <returns>String return from the SaveSalaryDeduction method</returns>
        public String DeActivate(int DeActivatedBy)
        {
            _UpdateBy = DeActivatedBy;
            _IsActive = false;

            return SaveSalaryDeduction();
        }
        /// <summary>
        /// Return all inactive SalaryDeductions
        /// </summary>
        /// <returns>Array of the object of SalaryDeductions class</returns>
        public static SalaryDeductions[] GetAllInactiveSalaryDeductions()
        {
            Master_Salary_Deductions[] SalaryDeductDT = new Master_Salary_DeductionsBusinessObject().GetAllInactiveSalaryDeductions();

            SalaryDeductions[] SalaryDeduct = new SalaryDeductions[SalaryDeductDT.Length];

            for (int i = 0; i < SalaryDeduct.Length; i++)
            {
                SalaryDeduct[i] = new SalaryDeductions(SalaryDeductDT[i]);
            }

            return SalaryDeduct;
        }
        /// <summary>
        /// Return all SalaryDeductions
        /// </summary>
        /// <returns>Array of the object of SalaryDeductions class</returns>
        public static SalaryDeductions[] GetAllSalaryDeductions()
        {
            Master_Salary_Deductions[] SalaryDeductDT = new Master_Salary_DeductionsBusinessObject().GetAllSalaryDeductions();

            SalaryDeductions[] SalaryDeduct = new SalaryDeductions[SalaryDeductDT.Length];

            for (int i = 0; i < SalaryDeduct.Length; i++)
            {
                SalaryDeduct[i] = new SalaryDeductions(SalaryDeductDT[i]);
            }

            return SalaryDeduct;
        }
        /// <summary>
        /// Return all Employe SalaryDeductions
        /// </summary>
        /// <returns>Array of the object of Employee SalaryDeductions class</returns>
        public static SalaryDeductions[] GetAllEmployeeSalaryDeductions()
        {
            Master_Salary_Deductions[] SalaryDeductDT = new Master_Salary_DeductionsBusinessObject().GetAllEmployeeSalaryDeductions();

            SalaryDeductions[] SalaryDeduct = new SalaryDeductions[SalaryDeductDT.Length];

            for (int i = 0; i < SalaryDeduct.Length; i++)
            {
                SalaryDeduct[i] = new SalaryDeductions(SalaryDeductDT[i]);
            }

            return SalaryDeduct;
        }
        #region JGridDataObject Members

        public object GetGridData()
        {
            SalaryDeductionDetails SalaryDeduct = new SalaryDeductionDetails();

            SalaryDeduct.ID = _ID;
            SalaryDeduct.Name = _Name;
            SalaryDeduct.Period = _Period;
            SalaryDeduct.Limit = _Limit;
            SalaryDeduct.IsEmployeeLevel = _IsEmployee;
            SalaryDeduct.IsPercentage = _IsPercentage;
            SalaryDeduct.Code = _Code;
            SalaryDeduct.IsTaxExempted = _IsTaxExempted;
            SalaryDeduct.IsActive = _IsActive;
            return SalaryDeduct;
        }

        #endregion

    }
   public class SalaryDeductionDetails
   {
       public int ID;
       public String Name;
       public String Code;
       public String Period;
       public double Limit;
       public bool IsEmployeeLevel;
       public bool IsPercentage;
       public bool IsTaxExempted;
       public bool IsActive;
   }

   public class EmpDeduction
   {
       public int ID;
       public String Name;
       public String DeductionType;
       public String Period;
       public double Limit;
       public bool IsEmployeeLevel;
       public bool IsPercentage;
       public String Code;
       public bool IsTaxExempted;
       public bool IsActive;

       public static EmpDeduction[] GetEmployeeDeductions()
       {
           EmpDeduction[] empDed= new Master_Salary_DeductionsBusinessObject().GetAllEmployeeDeductions();

           return empDed;
       }
   }
}
