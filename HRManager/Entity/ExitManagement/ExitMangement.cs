using System;
using IRCA.Communication;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using HRManager.DTOEXT;
namespace HRManager.Entity.ExitManagement
{ 
    public class ExitMangement : JGridDataObject
    {
        private int _id;
        private int _employeeId;
        private int _exitTypeId;
        private int _EmpExitID;
        private DateTime _exitDate;
        private String _employeeName;
        private String _exitType;
        private String _documentName;
        private String _employeeCode;
        private bool _IsActive;

        public int Id { get { return _id; } set { _id = value; } }
        public int EmployeeId { get { return _employeeId; } set { _employeeId = value; } }
        public int ExitTypeId { get { return _exitTypeId; } set { _exitTypeId = value; } }
        public int EmpExitID { get { return _EmpExitID; } set { _EmpExitID = value; } }
        public DateTime ExitDate { get { return _exitDate; } set { _exitDate = value; } }
        public String EmployeeName { get { return _employeeName; } set { _employeeName = value; } }
        public String ExitType { get { return _exitType; } set { _exitType = value; } }
        public String DocumentName { get { return _documentName; } set { _documentName = value; } }
        public String EmployeeCode { get { return _employeeCode; } set { _employeeCode = value; } }
        public bool IsActive {get{return _IsActive;}set{_IsActive = value;}}

        private void Update(Exit_Management dto)
        {
            if (dto != null)
            {
                _id = dto.ID;
                _employeeId = dto.EmployeeID;
                _exitTypeId = dto.ExitTypeID;
                _exitDate = dto.ExitDate;
                _documentName = dto.DocumentName;
                _IsActive = dto.IsActive;
                if (dto is Exit_ManagementEXT) 
                {
                    _employeeName = ((Exit_ManagementEXT)dto).EmployeeName;
                    _exitType = ((Exit_ManagementEXT)dto).ExitType;
                    _employeeCode = ((Exit_ManagementEXT)dto).EmployeeCode;
                    _EmpExitID = ((Exit_ManagementEXT)dto).EmpExitID;
                }
            }            
        }

        private Exit_Management GetDto()
        {
            Exit_Management dto = new Exit_Management();
            dto.ID = _id;
            dto.EmployeeID = _employeeId;
            dto.ExitTypeID = ExitTypeId;
            dto.ExitDate = _exitDate;
            dto.DocumentName = _documentName;
            dto.IsActive = _IsActive;
           
            return dto;
        }
        public String Save()
        {
            try
            {
                ExitManagementBusinessObject bo = new ExitManagementBusinessObject();
                Exit_Management dto = GetDto();

                if (_id != 0)
                {
                    bo.Update(dto);
                }
                else
                {
                    _id = bo.Create(dto);
                }

                return String.Empty;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(ex);
                return ex.Message;
            }
        }

        public ExitMangement[] GetExitManagement()
        {
            return LoadGrid(new ExitManagementBusinessObject().GetExitManagement());
        }
        private ExitMangement[] LoadGrid(Exit_ManagementEXT[] arr)
        {
            var em = new ExitMangement[arr.Length];

            for (int h = 0; h < arr.Length; h++)
            {
                var ur = new ExitMangement();
                ur.Update(arr[h]);
                em[h] = ur;
            }
            return em;
        }
        public String UpdateExitManagement(int id, int employeeId, int exitTypeId, DateTime ExitDate)
        {
            var dto = new Exit_Management();
            _id = id;
            _employeeId = employeeId;
            _exitTypeId = exitTypeId;
            _exitDate = ExitDate;          
            string res = Save();
            //LeaveRequestNotification Notification = new LeaveRequestNotification();
            //Notification.LeaveReqNotification(EmployeeID, FromDate, ToDate, LR.ManagerID, Reason, DaysCount, LR.TeamID);
            return res;

        }

        public String ISActiveUpdate(int EmpID)
        {
            String Result = String.Empty;

            try
            {
                if (Result == String.Empty)
                {
                    new ExitManagementBusinessObject().ISActiveUpdate(EmpID);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Result;
        }

        #region JGridDataObject Members
        public object GetGridData()
        {
            var dt = new ExitManagermentDisplay
            {
                Id = _id,
                EmployeeId = _employeeId,
                ExitTypeId = _exitTypeId,
                ExitDate = _exitDate.ToString("dd/MM/yyyy"),
                EmployeeName = _employeeName,
                ExitType = _exitType,
                DocumentName = _documentName,
                EmployeeCode = _employeeCode
            };
            //DT.NDFormView = "<input id='btn_" + _ID + "' type='button' value='View'  style='background-color: #CC3300; color: #000000;width:100px' onclick='viewDoc(" + _ID + ")'/>";
            return dt;
        }

        #endregion
    }
    public class ExitManagermentDisplay
    {
        public int Id;
        public int EmployeeId;
        public int ExitTypeId;
        public String EmployeeCode;
        public String EmployeeName;        
        public String ExitType;
        public String ExitDate;
        //public String NDFormView;
        public String DocumentName;
    }

}
