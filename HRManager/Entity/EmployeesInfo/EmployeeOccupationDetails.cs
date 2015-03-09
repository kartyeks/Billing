using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IS91.Services.DataBlock;
using HRManager.Entity.ExitManagement;
using CommonManager.Entity;

namespace HRManager.Entity.EmployeesInfo
{
    public class EmployeeOccupationDetails : EmployeeInfo
    {
        private int _ID;
        private int _EmployeeID;
        private int _CountryID;
        private int _LocationID;
        private int _DesignationID;
        private int _TeamID;
        private DateTime _JoiningDate;
        private DateTime _ExitDate;
        private int _TypeOfExitID;
        private Double _LeavesCount;
        private String _EmailID;
        private bool _IsActive;
        private int _ActivatedBy;
        private DateTime _ActivatedDate;
        private int _UpdatedBy;
        private int _FinancialMonth;
        private int _FinancialYear;
        private String _Username;
        private int _ProjectId;// added by archana 17/02/2015 for aratt

        public int ID { get { return _ID; } set { _ID = value; } }
        public int EmployeeID { get { return _EmployeeID; } set { _EmployeeID = value; } }
        public int CountryID { get { return _CountryID; } set { _CountryID = value; } }
        public int LocationID { get { return _LocationID; } set { _LocationID = value; } }
        public int DesignationID { get { return _DesignationID; } set { _DesignationID = value; } }
        public int TeamID { get { return _TeamID; } set { _TeamID = value; } }
        public DateTime JoiningDate { get { return _JoiningDate; } set { _JoiningDate = value; } }
        public DateTime ExitDate { get { return _ExitDate; } set { _ExitDate = value; } }
        public DateTime ActivatedDate { get { return _ActivatedDate; } set { _ActivatedDate = value; } }
        public int TypeOfExitID { get { return _TypeOfExitID; } set { _TypeOfExitID = value; } }
        public Double LeavesCount { get { return _LeavesCount; } set { _LeavesCount = value; } }
        public String EmailID { get { return _EmailID; } set { _EmailID = value; } }
        public String Username { get { return _Username; } set { _Username = value; } }
        
        public int UpdatedBy { get { return _UpdatedBy; } set { _UpdatedBy = value; } }
    

        public bool IsActive { get { return _IsActive; } set { _IsActive = value; } }
        public int FinancialMonth { get { return _FinancialMonth; } set { _FinancialMonth = value; } }
        public int FinancialYear { get { return _FinancialYear; } set { _FinancialYear = value; } }
        public int ProjectId { get { return _ProjectId; } set { _ProjectId = value; } }// added by archana 17/02/2015 for aratt

        public EmployeeOccupationDetails()
        {

        }

        public EmployeeOccupationDetails(int EmployeeID)
        {
          Update(new Employee_OccupationDetailsBusinessObject().GetOccupationalDetails(EmployeeID));
        }

        public void Update(Employee_OccupationDetails DTO)
        {
            if (DTO != null)
            {
                _ID = DTO.ID;
                _EmployeeID = DTO.EmployeeID;
                _CountryID = DTO.CountryID;
                _LocationID = DTO.LocationID;
                _DesignationID = DTO.DesignationID;
                _TeamID = DTO.TeamID;
                _TypeOfExitID = DTO.TypeOfExitID;
                _LeavesCount = DTO.LeavesCount;
                _JoiningDate = DTO.JoiningDate;
                _ExitDate = DTO.ExitDate;
                _EmailID = DTO.EmailID;
                _IsActive = DTO.IsActive;
                _ActivatedBy = DTO.ActivatedBy;
                _ActivatedDate = DTO.ActivatedDate;
                _FinancialMonth = DTO.FinancialMonth;
                _FinancialYear = DTO.FinancialYear;
                _Username = new User(DTO.EmployeeID, "EmployeeID").LoginName;
                _ProjectId = DTO.ProjectId;// added by archana 17/02/2015 for aratt

            }
        }

        private Employee_OccupationDetails GetDTO()
        {
            Employee_OccupationDetails DTO = new Employee_OccupationDetails();
            DTO.ID = _ID;
            DTO.EmployeeID = _EmployeeID;
            DTO.CountryID = _CountryID;
            DTO.LocationID = _LocationID;
            DTO.DesignationID = _DesignationID;
            DTO.TeamID = _TeamID;
            DTO.TypeOfExitID = _TypeOfExitID;
            DTO.LeavesCount = _LeavesCount;
            DTO.EmailID = _EmailID;
            if (_JoiningDate.Year.Equals(0001))
            {
                DTO.JoiningDate = Convert.ToDateTime("1900-01-01");
            }
            else
            {
                DTO.JoiningDate = _JoiningDate;
            }
            if (_ExitDate.Year.Equals(0001))
            {
                DTO.ExitDate = Convert.ToDateTime("1900-01-01");
            }
            else
            {
                DTO.ExitDate = _ExitDate;
            }
            DTO.IsActive = _IsActive;
            DTO.ActivatedBy= _UpdatedBy;
            if (_ActivatedDate.Year.Equals(0001))
            {
                DTO.ActivatedDate = Convert.ToDateTime("1900-01-01");
            }
            else
            {
                DTO.ActivatedDate = _ActivatedDate;
            }
            DTO.FinancialMonth = _FinancialMonth;
            DTO.FinancialYear = _FinancialYear;
            DTO.ProjectId = _ProjectId;// added by archana 17/02/2015 for aratt
            if (_ID == 0)
            {
                CommonManager.Entity.User objUser = new CommonManager.Entity.User();
                objUser.EmployeeID = _EmployeeID;
                objUser.LoginName = _Username;
                objUser.IsActive = true;
                objUser.IsChangePassword = false;
                objUser.IsLocked = false;
                objUser.LastLoginTime = new DateTime(1900, 01, 01);
                objUser.InvalidLoginCount = 0;
                objUser.LoginType = "EMP";
                objUser.ModifiedBy = 0;
                objUser.ModifiedDate = new DateTime(1900, 01, 01); ;
                objUser.Password = "";
                objUser.UserID = 0;
                objUser.SaveUser();
            }
            
            return DTO;
        }

        public String Save()
        {
            try
            {
                Employee_OccupationDetailsBusinessObject BO = new Employee_OccupationDetailsBusinessObject();
                Employee_OccupationDetails DTO = GetDTO();
                bool isExists = BO.IsEmailExists(_EmailID, _ID);
                if (isExists)
                {
                    return HREmployeeManagerDefs.Employee.EMIAL_EXISTS;
                }
                if (_ID != 0)
                {
                    //DTO.IsActive = false;
                    //BO.Update(DTO);
                    Employee_OccupationDetails obj = new Employee_OccupationDetailsBusinessObject().GetEmployee_OccupationDetails(_ID);
                    obj.IsActive = false;
                    BO.Update(obj);
                }

                //else
                //{
                    DTO.ID = 0;
                    DTO.IsActive = true;
                    
                    DTO.ActivatedBy = _UpdatedBy;
                    DTO.ActivatedDate = DateTime.Now;
                   _ID = BO.Create(DTO);
                if(_TypeOfExitID!=0)
                {
                    ExitManagementNotification Notification = new ExitManagementNotification();
                    Notification.ExitNotification(EmployeeID, ExitDate);
                }
                   // EmployeeNotificationService.NewJoineeNotification(DTO.EmployeeID);
                //}

                    return _ID.ToString();
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(ex);
                return ex.Message;
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
