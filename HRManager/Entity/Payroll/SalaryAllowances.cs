using System;
using System.Collections.Generic;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IRCA.Communication;

namespace HRManager.Entity
{
    /// <summary>
    /// Represents Salary Allowance fields and methods.
    /// </summary>
    public class SalaryAllowance : JGridDataObject
    {
        private int _ID;
        private String _AllowanceName;
        private String _AllowancePeriod;
        private String _AllowanceCode;
        private bool _IsPercentage;
        private bool _IsActive;
        private bool _IsTaxExempted;
        private bool _IsOptional;
        private bool _IsNew;
        private int _UpdateBy;
        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;
        private bool _IsAllowance;
        private int _DisplayOrder;
        private bool _IsOneMonthBasic;
        private double _Value;

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

        public int DisplayOrder
        {
            get
            {
                return _DisplayOrder;
            }
            set
            {
                _DisplayOrder = value;
            }
        }

        public String AllowanceName
        {
            get
            {
                return _AllowanceName;
            }
            set
            {
                _AllowanceName = value;
            }
        }
        public String AllowanceCode
        {
            get
            {
                return _AllowanceCode;
            }
            set
            {
                _AllowanceCode = value;
            }
        }
        public String AllowancePeriod
        {
            get
            {
                return _AllowancePeriod;
            }
            set
            {
                _AllowancePeriod = value;
            }
        }

        public bool IsAllowance
        {
            get
            {
                return _IsAllowance;
            }
            set
            {
                _IsAllowance = value;
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

        public bool IsOptional
        {
            get
            {
                return _IsOptional;
            }
            set
            {
                _IsOptional = value;
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

        public bool IsOneMonthBasic
        {
            get
            {
                return _IsOneMonthBasic;
            }
            set
            {
                _IsOneMonthBasic = value;
            }
        }

        public Double Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
       
        /// <summary>
        /// Update the Salary Allowance field using Master_SalaryAllowance.
        /// </summary>
        /// <param name="Asset">Object of Master_SalaryAllowance class</param>
        private void Update(Master_Salary_Allowance SAllow)
        {
            if (SAllow!= null)
            {
                _ID = SAllow.ID;
                _AllowanceName= SAllow.AllowanceName;
                _AllowanceCode = SAllow.AllowanceCode;
                _AllowancePeriod= SAllow.AllowancePeriod;
                //_IsAllowance = SAllow.IsAllowance;
                _IsPercentage = SAllow.IsPercentage;
                _IsActive = SAllow.IsActive;
                _IsTaxExempted = SAllow.IsTaxExempted;
                //_IsOptional = SAllow.IsOptional;
                _IsNew = false;
                _CreatedBy = SAllow.CreatedBy;
                _ModifiedBy = SAllow.ModifiedBy;
                _CreatedDate = SAllow.CreatedDate;
                _ModifiedDate = SAllow.ModifiedDate;
                _DisplayOrder = SAllow.DisplayOrder;
                _IsOneMonthBasic = SAllow.IsOneMonthBasic;
                _Value = SAllow.Value;

            }
            else
            {
                _IsNew = true;
            }
        }
         /// <summary>
        /// Consturctor of Salary Allowance Class
        /// Update Salary Allowance fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains Salary Allowance ID</param>
        public SalaryAllowance(int ID)
        {
            Master_Salary_Allowance SAllow = new Master_Salary_AllowanceBusinessObject().GetMaster_Salary_Allowance(ID);

            if (SAllow == null && ID > 0)
            {
                throw new IRCAException("Invalid Allowance", ID.ToString());
            }

            Update(SAllow);
        }
        /// <summary>
        /// Consturctor of Salary Allowance class.
        /// Update Salary Allowance  fields using Master_SalaryAllowance 
        /// </summary>
        /// <param name="Asset">Object of Master_SalaryAllowance  class</param>
        public SalaryAllowance(Master_Salary_Allowance SAllow)
        {
            Update(SAllow);
        }
        

        
        /// <summary>
        /// Consturctor of Salary Allowance class.
        /// Set variables for new Salary Allowance.  
        /// </summary>
        public SalaryAllowance()
        {
            _ID = 0;
            _IsNew = true;
        }
        /// <summary>
        /// Save Salary Allowance.If new Salary Allowance it add and in case of edit it update the Salary Allowance.
        /// </summary>
        /// <returns>empty string</returns>
        private String SaveSalaryAllowance ()
        {

            Master_Salary_Allowance SAllow = new Master_Salary_Allowance();
            SAllow.ID = _ID;
            SAllow.AllowanceName= _AllowanceName;
            SAllow.AllowanceCode = _AllowanceCode;
            SAllow.AllowancePeriod= _AllowancePeriod;
            SAllow.IsPercentage = _IsPercentage;
            //SAllow.IsAllowance = _IsAllowance;
            SAllow.IsActive = _IsActive;
            //SAllow.IsOptional = _IsOptional;
            SAllow.IsTaxExempted = _IsTaxExempted;
            SAllow.CreatedBy = _CreatedBy;
            SAllow.CreatedDate = _CreatedDate;
            SAllow.DisplayOrder = _DisplayOrder;
            SAllow.IsOneMonthBasic = _IsOneMonthBasic;
            SAllow.Value = _Value;
            if (_IsNew)
            {
                SAllow.CreatedBy = _UpdateBy;
                SAllow.CreatedDate = DateTime.Now;
                SAllow.ID = new Master_Salary_AllowanceBusinessObject().Create(SAllow);
            }
            else
            {
                SAllow.ModifiedBy = _UpdateBy;
                SAllow.ModifiedDate = DateTime.Now;
                SAllow.ID = _ID;
                new Master_Salary_AllowanceBusinessObject().Update(SAllow);
            }

            return String.Empty;
        }
        // <summary>
        ///Validate Salary Allowance for empty and already exist status and then save Salary Allowance .
        /// </summary>
        /// <returns>String return from the SaveSalaryAllowance  method</returns> 
        public String Save()
        {
            String Status = Validate();

            if (Status != String.Empty)
            {
                return Status;
            }

            return SaveSalaryAllowance();
        }
        /// <summary>
        /// Validate AssetName for empty and already exist status.
        /// </summary>
        /// <returns>empty string</returns>
        private String Validate()
        {
            Master_Salary_AllowanceBusinessObject SAllowBO = new Master_Salary_AllowanceBusinessObject();

            if (_AllowanceName == String.Empty)
            {
                return HRPayrollManagerDefs.SalaryAllowanceMessages.EMPTY_ALLOWANCE;
            }
            else if (SAllowBO.IsAllowanceExists(_AllowanceName, _ID))
            {
                return HRPayrollManagerDefs.SalaryAllowanceMessages.ALLOWANCE_EXISTS;
            }
            
            return String.Empty;
        }
        /// <summary>
        /// Activate the Asset
        /// </summary>
        /// <param name="ActivatedBy">id of user who want to activate Asset</param>
        /// <returns>String return from the SaveAsset method</returns>
        public String Activate(int ActivatedBy)
        {
            _UpdateBy = ActivatedBy;
            _IsActive = true;

            return SaveSalaryAllowance();
        }
        /// <summary>
        /// Deactivate the Asset
        /// </summary>
        /// <param name="DeActivatedBy">id of user who want to DeActivate Asset</param>
        /// <returns>String return from the SaveAsset method</returns>
        public String DeActivate(int DeActivatedBy)
        {
            String Status = CheckReference();

            _UpdateBy = DeActivatedBy;
            if (Status != String.Empty)
            {
                return Status;
            }
            else
            {
                _IsActive = false;

                return SaveSalaryAllowance ();
            }

        }
        /// <summary>
        /// Return Salary Allowance 
        /// </summary>
        /// <param name="isActive"></param>
        /// <returns>Return Salary Allowance </returns>
        
        public static SalaryAllowance[] GetSalaryAllowances(int isActive)
        {
            Master_Salary_Allowance[] SAllowDT = new Master_Salary_AllowanceBusinessObject().GetSalaryAllowances(isActive);

            SalaryAllowance[] SAllows= new SalaryAllowance[SAllowDT.Length];

            for (int i = 0; i < SAllowDT.Length; i++)
            {
                SAllows[i] = new SalaryAllowance(SAllowDT[i]);
            }

            return SAllows;
        }
        public static SalaryAllowance[] GetOptionalSalaryAllowances(int EmpID)
        {
            Master_Salary_Allowance[] SAllowDT = new Master_Salary_AllowanceBusinessObject().GetOptionalSalaryAllowances(EmpID);

            SalaryAllowance[] SAllows= new SalaryAllowance[SAllowDT.Length];

            for (int i = 0; i < SAllowDT.Length; i++)
            {
                SAllows[i] = new SalaryAllowance(SAllowDT[i]);
            }

            return SAllows;
        }
        public static double GetAllowanceLimit(int AllowanceID,int EmpID)
        {
            //double SAllows=new SalaryAllowance(AllowanceID).

            double SAllowDT = new Master_Salary_AllowanceBusinessObject().GetEmployeeSalaryAllowancesLimit(AllowanceID, EmpID);

            //SalaryAllowance[] SAllows= new SalaryAllowance[SAllowDT.Length];

            //for (int i = 0; i < SAllowDT.Length; i++)
            //{
            //    SAllows[i] = new SalaryAllowance(SAllowDT[i]);
            //}

            return SAllowDT;
        }
        

        private String CheckReference()
        {
            Master_Salary_AllowanceBusinessObject SAllowBO = new Master_Salary_AllowanceBusinessObject();

            if (SAllowBO.IsAllowanceRefered(_ID))
            {
                return HRPayrollManagerDefs.SalaryAllowanceMessages.ALLOWANCE_REFERED;
            }
            return String.Empty;
        }

 
        #region JGridDataObject Members

        public object GetGridData()
        {
            SalaryHeadDisplayDetails SAllow = new SalaryHeadDisplayDetails();

            SAllow.AllowanceID= _ID;
            SAllow.SalaryHead= _AllowanceName;
            SAllow.AllowanceCode = _AllowanceCode;
            SAllow.Period= _AllowancePeriod;
            SAllow.IsPercentage = _IsPercentage;
            SAllow.IsActive = _IsActive;
            SAllow.IsTaxExempted = _IsTaxExempted;
            SAllow.IsOptional = _IsOptional;
            SAllow.IsAllowance = _IsAllowance;
            SAllow.DisplayOrder = _DisplayOrder;
            return SAllow;
        }

       

        /// <summary>
        /// Return all Salary Allowances
        /// </summary>
        /// <returns>Array of the object of SalaryAllowance class</returns>
        public static SalaryAllowance[] GetAllSalaryAllowances()
        {
           return GetSalaryAllowances(1);     
        }
        /// <summary>
        /// Return all Salary Allowance
        /// </summary>
        /// <returns>Array of the object of SalaryAllowance class</returns>
        public static SalaryAllowance[] GetActiveSalaryAllowances()
        {
            return GetSalaryAllowances(1);
        }




        /// <summary>
        /// Return all Salary Allowance
        /// </summary>
        /// <returns>Array of the object of SalaryAllowance class</returns>
        public static SalaryAllowance[] GetAllInActiveSalaryAllowances()
        {
            return GetSalaryAllowances(0);
        }

        #endregion
    }
      
    public class SalaryHeadDisplayDetails
    {
        public int AllowanceID;
        public String SalaryHead;
        public String AllowanceCode;
        public String Period;
        public bool IsPercentage;
        public bool IsActive;
        public bool IsTaxExempted;
        public bool IsOptional;
        public bool IsAllowance;
        public int DisplayOrder;
    }
}
