using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using HRManager.DTOEXT;
using IRCA.Communication;

namespace HRManager.Entity
{
    public class TeamDetail : JGridDataObject
    {
        private int _ID;
        private String _TeamName;
        private int _ManagerID;
        private String _ManagerName;
        private bool _IsActive;
        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;
        private bool _IsNew;
        private int _UpdateBy;

        public int ID { get { return _ID; } set { _ID = value; } }
        public String TeamName { get { return _TeamName; } set { _TeamName = value; } }
        public int ManagerID { get { return _ManagerID; } set { _ManagerID = value; } }
        public String ManagerName { get { return _ManagerName; } set { _ManagerName = value; } }
        public bool IsActive { get { return _IsActive; } set { _IsActive = value; } }
        public int CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }
        public DateTime CreatedDate { get { return _CreatedDate; } set { _CreatedDate = value; } }
        public int ModifiedBy { get { return _ModifiedBy; } set { _ModifiedBy = value; } }
        public DateTime ModifiedDate { get { return _ModifiedDate; } set { _ModifiedDate = value; } }
        public int UpdatedBy { get { return _UpdateBy; } set { _UpdateBy = value; } }
        public bool Status { get { return _IsActive; } set { _IsActive = value; } }

        public TeamDetail(Master_Team Team)
        {
            Update(Team);
        }

        private void Update(Master_Team DTO)
        {
            if (DTO != null)
            {
                _ID = DTO.ID;
                _TeamName = DTO.TeamName;
                _ManagerID = DTO.ManagerID;
                _IsActive = DTO.IsActive;
                _CreatedBy = DTO.CreatedBy;
                _CreatedDate = DTO.CreatedDate;
                _ModifiedBy = DTO.ModifiedBy;
                _ModifiedDate = DTO.ModifiedDate;              
                _IsNew = false;
                if(DTO is Master_TeamEXT)
                {
                    _ManagerName = ((Master_TeamEXT)DTO).ManagerName;
                }
            }
        }
        public TeamDetail()
        {
            _ID = 0;
            _IsNew = true;
        }

        private Master_Team GetDTO()
        {
            Master_Team DTO = new Master_Team();
            DTO.ID = _ID;
            DTO.TeamName = _TeamName;
            DTO.ManagerID = _ManagerID;
            DTO.IsActive = _IsActive;
            DTO.CreatedBy = _CreatedBy;
            DTO.CreatedDate = _CreatedDate;
            DTO.ModifiedBy = _ModifiedBy;
            DTO.ModifiedDate = DateTime.Now;
            if (_ID == 0)
            {
                DTO.CreatedBy = _UpdateBy;
                DTO.CreatedDate = DateTime.Now;
            }
            else
            {
                DTO.CreatedBy = _CreatedBy;
                Master_Team Value = new Master_TeamBusinessObject().GetMaster_Team(_ID);
                DTO.CreatedDate = Value.CreatedDate;
            }
            DTO.ModifiedBy = _UpdateBy;
            DTO.ModifiedDate = DateTime.Now;

            return DTO;
        }        

     
        public TeamDetail(int ID)
        {
            Master_Team Team = new Master_TeamBusinessObject().GetMaster_Team(ID);

            if (Team == null && ID > 0)
            {
                throw new IRCAException("Invalid Team", ID.ToString());
            }

            Update(Team);
        }

        public static TeamDetail[] GetAllTeamDetails()
        {
           //Master_Team[] TeamsDT = new Master_TeamBusinessObject().GetMaster_Team();
            Master_Team[] TeamsDT = new Master_TeamBusinessObject().GetAllTeamDetails();

            TeamDetail[] Teams = new TeamDetail[TeamsDT.Length];

            for (int i = 0; i < Teams.Length; i++)
            {
                Teams[i] = new TeamDetail(TeamsDT[i]);
            }

            return Teams;
        }
        public static TeamDetail[] GetAllTeams()
        {
           //Master_Team[] TeamsDT = new Master_TeamBusinessObject().GetMaster_Team();
            Master_Team[] TeamsDT = new Master_TeamBusinessObject().GetAllTeams();

            TeamDetail[] Teams = new TeamDetail[TeamsDT.Length];

            for (int i = 0; i < Teams.Length; i++)
            {
                Teams[i] = new TeamDetail(TeamsDT[i]);
            }

            return Teams;
        }
        public String Activate(int ActivatedBy)
        {
            _UpdateBy = ActivatedBy;

            _IsActive = true;

            return Save();
        }
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

                return Save();
            }
        }
        private String CheckReference()
        {
            Master_TeamBusinessObject TeamBO = new Master_TeamBusinessObject();

            if (TeamBO.IsTeamRefered(_ID))
            {
                return HRManagerDefs.TeamMessages.TEAM_REFERED;
            }
            return String.Empty;
        }

        public String Save()
        {
            try
            {
                String Status = Validate();
                if (Status != String.Empty)
                {
                    return Status;
                }
                Master_TeamBusinessObject BO = new Master_TeamBusinessObject();
                Master_Team DTO = GetDTO();
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
                IRCAExceptionHandler.HandleException(ex); return ex.Message;
            }
        }
        private String Validate()
        {
            Master_TeamBusinessObject BO = new Master_TeamBusinessObject();

            if (_TeamName == String.Empty)
            {
                return HRManagerDefs.TeamMessages.EMPTY_TEAM;
            }
            else if (BO.IsTeamExists(_TeamName, _ID))
            {
                return HRManagerDefs.TeamMessages.TEAM_EXISTS;
            }
            else if (CheckReference() != String.Empty)
            {
                if (!_IsActive)
                {
                    return CheckReference();
                }
            }
            return String.Empty;
        }

        public static TeamDetail[] GetInActiveTeams()
        {
            Master_Team[] TeamsDT = new Master_TeamBusinessObject().GetTeamMaster();

            TeamDetail[] Teams = new TeamDetail[TeamsDT.Length];

            for (int i = 0; i < Teams.Length; i++)
            {
                Teams[i] = new TeamDetail();

                Teams[i].Update(TeamsDT[i]);
            }

            return Teams;
        }

        #region JGridDataObject Members

        public object GetGridData()
        {
            return this;

        }

        #endregion
    }
}
