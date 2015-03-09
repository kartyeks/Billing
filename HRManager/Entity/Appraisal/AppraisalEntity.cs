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
    public class AppraisalEntity : JGridDataObject
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
        public String _OldDesignation;
        public String _OldSalary;
        public Double _HikePer;
        public String _NewDesignation;
        public String _Status;
        public int _TeamID;
        public String _Team;
        public String _PreDesignation;
        public String _PreSalary;

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
        public String OldDesignation { get { return _OldDesignation; } set { _OldDesignation = value; } }
        public String OldSalary { get { return _OldSalary; } set { _OldSalary = value; } }
        public Double HikePer { get { return _HikePer; } set { _HikePer = value; } }
        public String NewDesignation { get { return _NewDesignation; } set { _NewDesignation = value; } }
        public String Status { get { return _Status; } set { _Status = value; } }
        public int TeamID { get { return _TeamID; } set { _TeamID = value; } }
        public String Team { get { return _Team; } set { _Team = value; } }
        public String PreDesignation { get { return _PreDesignation; } set { _PreDesignation = value; } }
        public String PreSalary { get { return _PreSalary; } set { _PreSalary = value; } }
        
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
                _HikePer = DTO.HikePer;
                _Status = DTO.Status;
                _PreDesignation = DTO.OldDesignation;
                _PreSalary = DTO.OldSalary;
            }
        }


        public AppraisalEntity(Appraisal_Employee DTO)
        {
            Update(DTO);
        }
      

        public AppraisalEntity[] GetAllTeamMemberForRating(int IntimationID)
        {
            return new Appraisal_EmployeeBusinessObject().GetAllTeamMemberForRating(IntimationID);
        }

        public AppraisalEntity[] GetAllTeamMemberForRatingView(int IntimationID)
        {
            return new Appraisal_EmployeeBusinessObject().GetAllTeamMemberForRatingView(IntimationID);
        }
        public AppraisalEntity()
        {
        }
        public String EmployeeHike(int ID, int EmployeeID, String Salary, Double HikePercentage, String OldSalary, String Basic)
        {
            EmployeeSalaryDetails obj = new EmployeeSalaryDetails(EmployeeID);
            new Appraisal_EmployeeBusinessObject().InactiveEmployeeSalary(EmployeeID);
            obj.Ctc = Convert.ToDouble(Salary);
            obj.Basic = Convert.ToDouble(Basic);
            obj.IsActive = true;
            obj.Save();
            Update(new Appraisal_EmployeeBusinessObject().GetAppraisal_Employee(ID));
            _SalaryHikeOn = DateTime.Now;
            _SalaryHikeAmount = Salary;//hardcode
            _SalaryHikeBy = 3;//hardcode
            _HikePer = HikePercentage;
            _PreSalary = OldSalary;
            Save();
            return String.Empty;
        }

        public String EmployeePromote(int ID, int EmployeeID, int DesignationID,String OldDesignation)
        {   
            EmployeeOccupationDetails obj = new EmployeeOccupationDetails(EmployeeID);
            Employee_OccupationDetailsBusinessObject BO = new Employee_OccupationDetailsBusinessObject();
            bool isExists = BO.IsEmailExists(obj.EmailID, obj.ID);
            if (isExists)
            {
                return HREmployeeManagerDefs.Employee.EMIAL_EXISTS;
            }
            else
            {
                new Appraisal_EmployeeBusinessObject().InactiveEmployeeDesgnation(EmployeeID);
                obj.DesignationID = DesignationID;
                obj.IsActive = true;
                obj.Save();
                Update(new Appraisal_EmployeeBusinessObject().GetAppraisal_Employee(ID));
                _PromotionTo = DesignationID;
                _PromotionBy = 1;//hardcode
                _PromotionOn = DateTime.Now;
                _PreDesignation = OldDesignation;
                Save();
                return String.Empty;
            }
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
            DTO.HikePer = _HikePer;
            DTO.Status = _Status;
            DTO.OldDesignation = _PreDesignation;
            DTO.OldSalary = _PreSalary;
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
            AppraisalRatingDetails DT = new AppraisalRatingDetails();
            DT.Sno = _Sno;
            DT.ID = _ID;
            DT.IntimationID = _IntimationID;
            DT.EmployeeID = _EmployeeID;
            DT.Employee = _EmployeeName;
            if (_GoalOn.ToString("dd/MM/yyyy") != "01/01/1900")
            {
                DT.Goal = _Goals;
                DT.GoalStatus = "Added On : " + _GoalOn.ToString("dd/MM/yyyy");

                if (_GradeOn.ToString("dd/MM/yyyy") != "01/01/1900")
                {
                    DT.Grade = _Grade;
                    DT.GradeStatus = "Added On : " + _GoalOn.ToString("dd/MM/yyyy");
                }
                else if(_IntimationID != 0)
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
                if (_IntimationID==0)
                {
                    DT.Grade = "";
                    DT.GradeStatus = "Not Intimated for grade";
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
            DT.Designation = _OldDesignation;
            if (_OldSalary != String.Empty)
            {
                DT.Salary = _OldSalary;
            }
            else
            {
                DT.Salary = "0";
            }
            DT.HikePer = _HikePer;            
            DT.TeamID = _TeamID;
            DT.Team = _Team;
            if (_PreDesignation != String.Empty)
            {
                DT.PreDesignation = _PreDesignation;
            }
            else
            {
                DT.PreDesignation = _OldDesignation;
            }
            DT.CurrDesignation = _NewDesignation;
            if (_PreSalary != String.Empty)
            {
                DT.PreSalary = _PreSalary;
            }
            else
            {
                DT.PreSalary = _OldSalary;
            }
            DT.CurrSalary = _SalaryHikeAmount;

            return DT;
        }

        #endregion
    }
    public class AppraisalRatingDetails
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
        public String Designation;
        public String PreDesignation;
        public String CurrDesignation;
        public String Salary;
        public String PreSalary;
        public String CurrSalary;
        public Double HikePer;
        public int TeamID;
        public String Team;
    }
}
