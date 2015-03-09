using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRCA.Communication;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using HRManager.DTOEXT;
namespace HRManager.Entity.EmployeeLeave
{
    public class LeaveStatusHistry : JGridDataObject
    {
        private int _ID;
        private int _EmpID;
        private int _LeaveRequestID;
        private int _ProcessedBy;
        private DateTime _ProcessDate;      
        private String _Status;
        private String _Comments;

        public int ID {get {return _ID;}  set { _ID = value; }}
        public int EmpID {get {return _EmpID;}  set { _EmpID = value; }}
        public int LeaveRequestID {get {return _LeaveRequestID;}  set { _LeaveRequestID = value; }}
        public int ProcessedBy {get {return _ProcessedBy;}  set { _ProcessedBy = value; }}
        public DateTime ProcessDate {get {return _ProcessDate;}  set { _ProcessDate = value; }}
        public String Comments { get { return _Comments; } set { _Comments = value; } }
        public String Status { get { return _Status; } set { _Status = value; } }

        private void Update(Leave_Status_History DTO)
        {
            if (DTO != null)
            {
                _ID = DTO.ID;
                _LeaveRequestID = DTO.LeaveRequestID;
                _ProcessedBy = DTO.ProcessedBy;
                _ProcessDate = DTO.ProcessDate;
                _Status = DTO.Status;
                _Comments = DTO.Comments;
               
            }
           
        }
        public LeaveStatusHistry()
        {
        }
        public LeaveStatusHistry(int ID)
        {
            Update(new Leave_Status_HistoryBusinessObject().GetLeave_Status_History(ID));
        } 
        private Leave_Status_History GetDTO()
        {
            Leave_Status_History DTO = new Leave_Status_History();
            DTO.ID = _ID;
            DTO.LeaveRequestID = _LeaveRequestID;
            DTO.ProcessedBy = _ProcessedBy;
            DTO.ProcessDate = DateTime.Now;
            DTO.Status = _Status;
            DTO.Comments = _Comments;
            return DTO;
        }

        public String Save()
        {       
            try
            {
                Leave_Status_HistoryBusinessObject BO = new Leave_Status_HistoryBusinessObject();
                Leave_Status_History DTO = GetDTO();

                if (_ID != 0)
                {
                    BO.Update(DTO);
                }
                else
                {
                    _ID = BO.Create(DTO);
                }

                return String.Empty;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(ex);
                return ex.Message;
            }
        }      

        public String UpdateLeaveRequestApproval(int ID, int LeaveRequestID, int ProcessedBy, String Status, String Comments)
        {
            LeaveRequest LR = new LeaveRequest(LeaveRequestID);
            LR.Status = Status;
            LR.ManagerComments = Comments;
            LR.Save();

            Leave_Status_History DTO = new Leave_Status_History();
            _ID = ID;
            _LeaveRequestID = LeaveRequestID;
            _ProcessedBy = ProcessedBy;
            _Status = Status;
            _Comments = Comments;          
            String Res = Save();
            LeaveRequest LRA = new Leave_RequestBusinessObject().GetApprovalTeamManagerID(ProcessedBy);

            LeaveRequestNotification Notification = new LeaveRequestNotification();
            Notification.LeaveReqStatus(LeaveRequestID, ProcessedBy, Comments, Status, LRA.ManagerID, LRA.TeamID);

            return Res;

        }
        #region JGridDataObject Members

        public object GetGridData()
        {
            LeaveStatusHistryDetails DT = new LeaveStatusHistryDetails();
            DT.EmpID = _ID;
            DT.Status = _Status;
            DT.LeaveRequestID = _LeaveRequestID;
            DT.ProcessedBy = _ProcessedBy;
            DT.ProcessDate = _ProcessDate.ToString();
            DT.Comments = _Comments;          
            return DT;
        }

        #endregion
    }
    public class LeaveStatusHistryDetails
    {
        public int ID;
        public int EmpID;      
        public String Status;
        public int LeaveRequestID;
        public String Comments;
        public int ProcessedBy;
        public String ProcessDate;     
    }
}
