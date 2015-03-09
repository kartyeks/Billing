using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRCA.Communication;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using HRManager.DTOEXT;
using HRManager.Entity.LeaveApp;
using HRManager.Entity.EmployeesInfo;
using HRManager.Entity.Appraisal;
namespace HRManager.Entity.EmployeeLeave
{  
    public class IntimationEntity : JGridDataObject
    {
        private int _ID;
        private DateTime _GoalIntimationDate;
        private DateTime _AppraisalIntimationDate;
        private int _IntimationBy;
        public String _DocumentName;

        public int ID {get {return _ID;}  set { _ID = value; }}
        public DateTime GoalIntimationDate {get {return _GoalIntimationDate;}  set { _GoalIntimationDate = value; }}
        public DateTime AppraisalIntimationDate {get {return _AppraisalIntimationDate;}  set { _AppraisalIntimationDate = value; }}
        public int IntimationBy {get {return _IntimationBy;}  set { _IntimationBy = value; }}
        public String DocumentName { get { return _DocumentName; } set { _DocumentName = value; } }
        
        private void Update(Appraisal_Intimation DTO)
        {
            if (DTO != null)
            {
                _ID = DTO.ID;
                _GoalIntimationDate = DTO.GoalIntimationDate;
                _AppraisalIntimationDate = DTO.AppraisalIntimationDate;
                _IntimationBy = DTO.IntimateBy;
                _DocumentName = DTO.DocumentName;
            }
        }


        public IntimationEntity(Appraisal_Intimation DTO)
        {
            Update(DTO);
        }

        public IntimationEntity[] GetIntimation()
        {
            return GridData(new Appraisal_IntimationBusinessObject().GetAppraisal_Intimation());
        }

        public IntimationEntity()
        {
        }
        public String IntimateForAppraisal(int ID)
        {
            AppraisalNotification noti = new AppraisalNotification();
            noti.GradeNotifination(ID);
            Update(new Appraisal_IntimationBusinessObject().GetAppraisal_Intimation(ID));
            _AppraisalIntimationDate = DateTime.Now;
            return Save();
        }

        public String DeleteIntimation(int ID)
        {
            bool Result =new Appraisal_EmployeeBusinessObject().CheckAnyAppraisalDocSubmitted(ID);
            if (Result)
            {
                return "Goal submisson inprogress. Intimation can be deleted only before goal submission";
                
            }
            else{
                new Appraisal_IntimationBusinessObject().Delete(ID);
                return String.Empty;
            }
        }

        public String IsGoalSubmissionStarted(int ID)
        {
            bool Result =new Appraisal_EmployeeBusinessObject().CheckAnyAppraisalDocSubmitted(ID);
            if (Result)
            {
                return "Goal submisson inprogress.";
                
            }
            else{
                return String.Empty;
            }
        }
        private Appraisal_Intimation GetDTO()
        {
            Appraisal_Intimation DTO = new Appraisal_Intimation();
            DTO.ID = _ID;
            DTO.GoalIntimationDate = _GoalIntimationDate;
            DTO.AppraisalIntimationDate = _AppraisalIntimationDate;
            DTO.IntimateBy = _IntimationBy;
            DTO.DocumentName = _DocumentName;

            return DTO;
        }

        public String Save()
        {            
            try
            {
                Appraisal_IntimationBusinessObject BO = new Appraisal_IntimationBusinessObject();
                Appraisal_Intimation DTO = GetDTO();

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

        private IntimationEntity[] GridData(Appraisal_Intimation[] arr)
        {
            IntimationEntity[] LeavesCal = new IntimationEntity[arr.Length];

            for (int h = 0; h < arr.Length; h++)
            {
                IntimationEntity ur = new IntimationEntity();
                ur.Update(arr[h]);
                LeavesCal[h] = ur;
            }
            return LeavesCal;
        }

        #region JGridDataObject Members

        public object GetGridData()
        {
            IntimationDetails DT = new IntimationDetails();
            DT.ID = _ID;
            DT.GoalIntimationDate = _GoalIntimationDate.ToString("dd/MM/yyyy");
            if (_AppraisalIntimationDate.ToString() != "01/01/1900 00:00:00")
            {
                DT.AppraisalIntimationDate = _AppraisalIntimationDate.ToString("dd/MM/yyyy");
            }
            else
            {
                DT.AppraisalIntimationDate = "";
            }
            DT.IntimationBy = new EmployeePersonalDetails(_IntimationBy).FirstName + " " + new EmployeePersonalDetails(_IntimationBy).LastName;
            DT.View = "<input id='btn_"+_ID+"' type='button' value='View' onclick='viewDoc("+_ID+")'/>";
            DT.DocumentName = _DocumentName;
            return DT;
        }

        #endregion
    }
    public class IntimationDetails
    {
        public int ID;
        public String GoalIntimationDate;
        public String AppraisalIntimationDate;
        public String IntimationBy;
        public String View;
        public String DocumentName;
    }
}
