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
namespace HRManager.Entity.EmployeeLeave
{  
    public class IntimationAppraisalEntity : JGridDataObject
    {
        private int _ID;
        private int _Sno;
        private int _IntimationID;
        private int _EmployeeID;
        private String _EmployeeName;
        private String _Goals;
        public String _Grade;
        public DateTime _GoalOn;
        public DateTime _GradeOn;
        public int _GoalBy;
        public int _GradeBy;
        public DateTime _PromotionOn;
        public int _PromotionBy;
        public int _PromotionTo;
        public DateTime _SalaryHikeOn;
        public int _SalaryHikeBy;
        public String _SalaryHikeAmount;
        public String _Status;
        public int _TeamID;
        public String _Team;

        public int ID {get {return _ID;}  set { _ID = value; }}
        public int Sno { get { return _Sno; } set { _Sno = value; } }
        public int IntimationID {get {return _IntimationID;}  set { _IntimationID = value; }}
        public int EmployeeID {get {return _EmployeeID;}  set { _EmployeeID = value; }}
        public String EmployeeName { get { return _EmployeeName; } set { _EmployeeName = value; } }
        public String Goals {get {return _Goals;}  set { _Goals = value; }}
        public String Grade { get { return _Grade; } set { _Grade = value; } }
        public DateTime GoalOn { get { return _GoalOn; } set { _GoalOn = value; } }
        public DateTime GradeOn { get { return _GradeOn; } set { _GradeOn = value; } }
        public int GoalBy { get { return _GoalBy; } set { _GoalBy = value; } }
        public int GradeBy { get { return _GradeBy; } set { _GradeBy = value; } }
        public DateTime PromotionOn { get { return _PromotionOn; } set { _PromotionOn = value; } }
        public int PromotionBy { get { return _PromotionBy; } set { _PromotionBy = value; } }
        public int PromotionTo { get { return _PromotionTo; } set { _PromotionTo = value; } }
        public DateTime SalaryHikeOn { get { return _SalaryHikeOn; } set { _SalaryHikeOn = value; } }
        public int SalaryHikeBy { get { return _SalaryHikeBy; } set { _SalaryHikeBy = value; } }
        public String SalaryHikeAmount { get { return _SalaryHikeAmount; } set { _SalaryHikeAmount = value; } }
        public String Status { get { return _Status; } set { _Status = value; } }
        public int TeamID { get { return _TeamID; } set { _TeamID = value; } }
        public String Team { get { return _Team; } set { _Team = value; } }
        
        public void Update(Appraisal_Employee DTO)
        {
            if (DTO != null)
            {
                _ID = DTO.ID;
                _IntimationID = DTO.IntimationID;
                _EmployeeID = DTO.EmployeeID;
                _Goals = DTO.Goals;
                _Grade = DTO.Grade;
                _GoalOn = DTO.GoalOn;
                _GradeOn = DTO.GradeOn;
                _GoalBy = DTO.GoalBy;
                _GradeBy = DTO.GradeBy;
                _PromotionOn = DTO.PromotionOn;
                _PromotionBy = DTO.PromotionBy;
                _PromotionTo = DTO.PromotionTo;
                _SalaryHikeOn = DTO.SalaryHikeOn;
                _SalaryHikeBy = DTO.SalaryHikeBy;
                _SalaryHikeAmount = DTO.SalaryHikeAmount;
                _Status =DTO.Status;
            }
        }


        public IntimationAppraisalEntity(Appraisal_Employee DTO)
        {
            Update(DTO);
        }

        public IntimationAppraisalEntity[] GetTeamMemberForAppraisal(int IntimationID,int ManagerID)
        {
            return new Appraisal_EmployeeBusinessObject().GetTeamMemberForAppraisal(IntimationID,ManagerID);
        }

        public IntimationAppraisalEntity[] GetTeamMemberForView(int IntimationID)
        {
            return new Appraisal_EmployeeBusinessObject().GetTeamMemberForView(IntimationID);
        }
        public IntimationAppraisalEntity[] GetAllTeamMemberForAppraisal(int IntimationID)
        {
            return new Appraisal_EmployeeBusinessObject().GetAllTeamMemberForAppraisal(IntimationID);
        }
        public void GetAppraisalEmpID(int IntimationID, int EmployeeID)
        {
             Update(new Appraisal_EmployeeBusinessObject().GetAppraisalEmpID(IntimationID, EmployeeID));
        }

        public IntimationAppraisalEntity()
        {
        }
        public String CheckAllAppraisalDocSubmitted(int IntimationID, int TeamID,String Type)
        {
            if (new Appraisal_EmployeeBusinessObject().CheckAllAppraisalDocSubmitted(IntimationID, TeamID, Type))
            {
                return "PENDING";
            }
            else
            {
                return "DONE";
            }
        }
        public String UpdateEmployeeAppraisalGrade(int ID, String Grade)
        {
            Update(new Appraisal_EmployeeBusinessObject().GetAppraisal_Employee(ID));
            _Grade = Grade;
            _GradeBy = 1;
            _GradeOn = DateTime.Now;
            return Save();
        }

        public String DeleteEmployeeGoals(int ID)
        {
            new Appraisal_EmployeeBusinessObject().Delete(ID);
            return String.Empty;
        }

        public String DeleteEmployeeGrade(int ID)
        {
            Update(new Appraisal_EmployeeBusinessObject().GetAppraisal_Employee(ID));
            _Grade = String.Empty;
            _GradeBy = 0;
            _GradeOn = Convert.ToDateTime("1900-01-01");
            return Save();
        }
        private Appraisal_Employee GetDTO()
        {
            Appraisal_Employee DTO = new Appraisal_Employee();
            DTO.ID = _ID;
            DTO.IntimationID = _IntimationID;
            DTO.EmployeeID = _EmployeeID;
            DTO.Goals = _Goals;
            DTO.Grade = _Grade;
            DTO.GoalOn = _GoalOn;
            DTO.GradeOn = _GradeOn;
            DTO.GoalBy = _GoalBy;
            DTO.GradeBy = _GradeBy;
            DTO.PromotionOn = _PromotionOn;
            DTO.PromotionBy = _PromotionBy;
            DTO.PromotionTo = _PromotionTo;
            DTO.SalaryHikeOn = _SalaryHikeOn;
            DTO.SalaryHikeBy = _SalaryHikeBy;
            DTO.SalaryHikeAmount = _SalaryHikeAmount;
            DTO.Status = _Status;
            return DTO;
        }

        public String Save()
        {            
            try
            {
                Appraisal_EmployeeBusinessObject BO = new Appraisal_EmployeeBusinessObject();
                Appraisal_Employee DTO = GetDTO();

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

        #region JGridDataObject Members

        public object GetGridData()
        {
            AppraisalDetails DT = new AppraisalDetails();
            DT.Sno = _Sno;
            DT.ID = _ID;
            DT.IntimationID = _IntimationID;
            DT.EmployeeID = _EmployeeID;
            DT.Employee = _EmployeeName;
            
            if (_GoalOn.ToString("dd/MM/yyyy") != "01/01/1900")
            {
                DT.Goal = _Goals;
                DT.GoalStatus = "Submitted On : " + _GoalOn.ToString("dd/MM/yyyy");

                if (_GradeOn.ToString("dd/MM/yyyy") != "01/01/1900")
                {
                    DT.Grade = _Grade;
                    DT.GradeStatus = "Submitted On : " + _GradeOn.ToString("dd/MM/yyyy");                   
                }
                else if (_IntimationID != 0)
                {
                    if (new Appraisal_IntimationBusinessObject().GetAppraisal_Intimation(_IntimationID).AppraisalIntimationDate.ToString("dd/MM/yyyy") == "01/01/1900")
                    {
                        DT.Grade = "";
                        DT.GradeStatus = "Not Intimated for grade";
                    }
                    else
                    {
                        DT.Grade = "";
                        DT.GradeStatus = "Not Yet submitted";
                    }

                }
                else
                {
                    DT.Grade = "";
                    DT.GradeStatus = "Not Intimated for grade";
                }
            }
            else
            {
                DT.Goal = "";
                DT.GoalStatus = "Not Yet submitted";
                if (_IntimationID == 0)
                {
                    DT.Grade = "";
                    DT.GradeStatus = "Intimated.But Goal Not Submitted";
                }
                else if (new Appraisal_IntimationBusinessObject().GetAppraisal_Intimation(_IntimationID).AppraisalIntimationDate.ToString("dd/MM/yyyy") == "01/01/1900")
                {
                    DT.Grade = "";
                    DT.GradeStatus = "Not Intimated for grade";
                }
                else
                {
                    DT.Grade = "";
                    DT.GradeStatus = "Intimated.But Goal Not Submitted";
                }
            }
            
            DT.View = "";
            DT.Status = _Status;
            DT.TeamID = _TeamID;
            DT.Team = _Team;
            return DT;
        }

        #endregion
    }
    public class AppraisalDetails
    {
        public int Sno;
        public int ID;
        public int IntimationID;
        public int EmployeeID;
        public String Employee;
        public String Goal;
        public String Grade;
        public String GoalStatus;
        public String GradeStatus;
        public String View;
        public String Status;
        public int TeamID;
        public String Team;
    }
}
