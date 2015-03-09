using System;
using System.Collections.Generic;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IRCA.Communication;

namespace HRManager.Entity
{
    public class PayrollAnnualCongiguration : JGridDataObject
    {
        private int _ID;
        private int _EmployeeID;
        private int _FinancialYear;
        private double _RentPaid;
        private double _TDS;
        private double _LeaveEncashDays;
        private DateTime _ActivatedDate;
        private bool _IsNew=true;
        private string _Narration;
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
        public int EmployeeID
        {
            get
            {
                return _EmployeeID;
            }
            set
            {
                _EmployeeID = value;
            }
        }
        public int FinancialYear
        {
            get
            {
                return _FinancialYear;
            }
            set
            {
                _FinancialYear = value;
            }
        }
        public double RentPaid
        {
            get
            {
                return _RentPaid;
            }
            set
            {
                _RentPaid = value;
            }
        }        
        public double TDS
        {
            get
            {
                return _TDS;
            }
            set
            {
                _TDS = value;
            }
        }
        public double LeaveEncashDays
        {
            get
            {
                return _LeaveEncashDays;
            }
            set
            {
                _LeaveEncashDays = value;
            }
        }

        public DateTime ActivatedDate
        {
            get
            {
                return _ActivatedDate;
            }
            set
            {
                _ActivatedDate = value;
            }
        }

        public String Narration
        {
            get
            {
                return _Narration;
            }
            set
            {
                _Narration = value;
            }
        }

        /// <summary>
        /// Update the Asset field using Master_Asset.
        /// </summary>
        /// <param name="Asset">Object of Master_Asset class</param>
        private void Update(Payroll_AnnualConfiguration Payroll_AnnualConfiguration)
        {
            if (Payroll_AnnualConfiguration != null)
            {
                _ID = Payroll_AnnualConfiguration.ID;
                _EmployeeID = Payroll_AnnualConfiguration.EmployeeID;
                _FinancialYear = Payroll_AnnualConfiguration.FinancialYear;
                _RentPaid = Payroll_AnnualConfiguration.RentPaid;
                _TDS = Payroll_AnnualConfiguration.TDS;
                _LeaveEncashDays = Payroll_AnnualConfiguration.LeaveEncashDays;
                _IsNew = false;
                }
            else
            {
                _IsNew = true;
            }
        }
        /// <summary>
        /// Consturctor of Grade class.
        /// Update Grade fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains Designation ID</param>
        public PayrollAnnualCongiguration(int ID)
        {
            Payroll_AnnualConfiguration Payroll_AnnualConfiguration = new Payroll_AnnualConfigurationBusinessObject().GetPayroll_AnnualConfiguration(ID);

            if (Payroll_AnnualConfiguration == null && ID > 0)
            {
                throw new IRCAException("Invalid Payroll Annual Configuration", ID.ToString());
            }

            Update(Payroll_AnnualConfiguration);
        }
        /// <summary>
        /// Consturctor of Asset class.
        /// Update Asset fields using Master_Asset.
        /// </summary>
        /// <param name="Asset">Object of Master_Asset class</param>
        public PayrollAnnualCongiguration(Payroll_AnnualConfiguration Payroll_AnnualConfiguration)
        {
            Update(Payroll_AnnualConfiguration);
        }
        

        /// <summary>
        /// Consturctor of Asset class.
        /// Set variables for new Asset.  
        /// </summary>
        public PayrollAnnualCongiguration()
        {
            _ID = 0;
            _IsNew = true;
        }
        /// <summary>
        /// Save Asset.If new Asset it add and in case of edit it update the Asset.
        /// </summary>
        /// <returns>empty string</returns>
        private String SavePayrollAnnualCongiguration()
        {

            Payroll_AnnualConfiguration Payroll_AnnualConfiguration = new Payroll_AnnualConfiguration();
            Payroll_AnnualConfiguration.ID = _ID;
            Payroll_AnnualConfiguration.EmployeeID = _EmployeeID;
            Payroll_AnnualConfiguration.FinancialYear = _FinancialYear;
            Payroll_AnnualConfiguration.RentPaid = _RentPaid;
            Payroll_AnnualConfiguration.TDS = _TDS;
            Payroll_AnnualConfiguration.LeaveEncashDays = _LeaveEncashDays;
            Payroll_AnnualConfiguration.ActivatedDate = DateTime.Now;

            if (_IsNew)
            {
                Payroll_AnnualConfiguration.ID = new Payroll_AnnualConfigurationBusinessObject().Create(Payroll_AnnualConfiguration);
            }
            else
            {
                Payroll_AnnualConfiguration.ID = _ID;
                new Payroll_AnnualConfigurationBusinessObject().Update(Payroll_AnnualConfiguration);
            }

            return String.Empty;
        }
        // <summary>
        ///Validate Asset for empty and already exist status and then save Asset.
        /// </summary>
        /// <returns>String return from the SaveAsset method</returns> 
        public String Save()
        {
            String Status = Validate();

            if (Status != String.Empty)
            {
                return Status;
            }

            return SavePayrollAnnualCongiguration();
        }
        /// <summary>
        /// Validate AssetName for empty and already exist status.
        /// </summary>
        /// <returns>empty string</returns>
        private String Validate()
        {
            Payroll_AnnualConfigurationBusinessObject AnnualConfigBO = new Payroll_AnnualConfigurationBusinessObject();

            if (AnnualConfigBO.CheckLeaveEncashStatus(_EmployeeID,_FinancialYear,_LeaveEncashDays))
            {
                return HRPayrollManagerDefs.PayrollAnnualConfigurationMessages.PAYANNUCONFIG_LEAVEENCASH_GREATER;
            }
            //else if (BankBO.IsBankExists(_BankCode, _ID))
            //{
            //    return HRManagerDefs.BankMessages.BANKCODE_EXISTS;
            //}
            //else if (BankBO.IsBankNameExists(_BankName, _ID))
            //{
            //    return HRManagerDefs.BankMessages.BANKNAME_EXISTS;
            //}
            return String.Empty;
        }
        
        ///// <summary>
        ///// Return all Assets
        ///// </summary>
        ///// <returns>Array of the object of Asset class</returns>
        //public static PayrollAnnualCongiguration[] GetAllPayrollAnnualConfiguration(int FYear, int EmpID)
        //{
        //    Payroll_AnnualConfiguration[] Payroll_AnnualConfigurationDT = new Payroll_AnnualConfigurationBusinessObject().GetActiveAnnualConfig(FYear, EmpID);

        //    PayrollAnnualCongiguration[] PayrollAnnualCongigurations = new PayrollAnnualCongiguration[Payroll_AnnualConfigurationDT.Length];

        //    for (int i = 0; i < PayrollAnnualCongigurations.Length; i++)
        //    {
        //        PayrollAnnualCongigurations[i] = new PayrollAnnualCongiguration(Payroll_AnnualConfigurationDT[i]);
        //    }

        //    return PayrollAnnualCongigurations;
        //}

        /// <summary>
        /// Return all Location
        /// </summary>
        /// <returns>Array of the object of Location class</returns>
        public static PayrollAnnualCongiguration GetAllPayrollAnnualConfigurations(int FYear, int EmpID)
        {
            PayrollAnnualCongiguration AnnualsDT = new Payroll_AnnualConfigurationBusinessObject().GetActiveAnnualConfigs(FYear, EmpID);
            return AnnualsDT;
        }

       
        #region JGridDataObject Members

        public object GetGridData()
        {
            PayrollAnnualConfigurationDisplayDetails annualConfig = new PayrollAnnualConfigurationDisplayDetails();

            annualConfig.ID = _ID;
            annualConfig.EmployeeID = _EmployeeID;
            annualConfig.FinancialYear = _FinancialYear;
            annualConfig.RentPaid = _RentPaid;
            annualConfig.TDS = _TDS;
            annualConfig.LeaveEncashDays = _LeaveEncashDays;


            return annualConfig;
        }

        #endregion
    }

    public class PayrollAnnualConfigurationDisplayDetails
    {
        public int ID;
        public int EmployeeID;        
        public int FinancialYear;
        public double RentPaid;
        public double TDS;
        public double LeaveEncashDays;
    }
}
