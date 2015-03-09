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
    public class Intimation : JGridDataObject
    {
        private int _ID;
        private DateTime _GoalIntimationDate;
        private DateTime _AppraisalIntimationDate;
        private int _IntimationBy;

        public int ID {get {return _ID;}  set { _ID = value; }}
        public DateTime GoalIntimationDate {get {return _GoalIntimationDate;}  set { _GoalIntimationDate = value; }}
        public DateTime AppraisalIntimationDate {get {return _AppraisalIntimationDate;}  set { _AppraisalIntimationDate = value; }}
        public int IntimationBy {get {return _IntimationBy;}  set { _IntimationBy = value; }}
        
        private void Update(Appraisal_Intimation DTO)
        {
            if (DTO != null)
            {
                _ID = DTO.ID;
                _GoalIntimationDate = DTO.GoalIntimationDate;
                _AppraisalIntimationDate = DTO.AppraisalIntimationDate;
                _IntimationBy = DTO.IntimateBy;
            }
        }


        public Intimation(Appraisal_Intimation DTO)
        {
            Update(DTO);
        }

        public Intimation[] GetIntimation()
        {
            return GridData(new Appraisal_IntimationBusinessObject().GetAppraisal_Intimation());
        }

        public Intimation()
        {
            GridData(new Appraisal_IntimationBusinessObject().GetAppraisal_Intimation());
        }
        private Appraisal_Intimation GetDTO()
        {
            Appraisal_Intimation DTO = new Appraisal_Intimation();
            DTO.ID = _ID;
            DTO.GoalIntimationDate = _GoalIntimationDate;
            DTO.AppraisalIntimationDate = _AppraisalIntimationDate;
            DTO.IntimateBy = _IntimationBy;

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

        private Intimation[] GridData(Appraisal_Intimation[] arr)
        {
            Intimation[] LeavesCal = new Intimation[arr.Length];

            for (int h = 0; h < arr.Length; h++)
            {
                Intimation ur = new Intimation();
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
            DT.AppraisalIntimationDate = _GoalIntimationDate.ToString("dd/MM/yyyy");
            DT.IntimationBy = new Employee(_IntimationBy).FirstName + " " + new Employee(_IntimationBy).LastName;
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
    }
}
