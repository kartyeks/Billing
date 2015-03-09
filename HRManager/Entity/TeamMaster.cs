using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using HRManager.DTOEXT;

namespace HRManager.Entity
{
    public class TeamMaster
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

        public int ID { get { return _ID; } set { _ID = value; } }
        public String TeamName { get { return _TeamName; } set { _TeamName = value; } }
        public int ManagerID { get { return _ManagerID; } set { _ManagerID = value; } }
        public String ManagerName { get { return _ManagerName; } set { _ManagerName = value; } }
        public bool IsActive { get { return _IsActive; } set { _IsActive = value; } }
        public int CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }
        public DateTime CreatedDate { get { return _CreatedDate; } set { _CreatedDate = value; } }
        public int ModifiedBy { get { return _ModifiedBy; } set { _ModifiedBy = value; } }
        public DateTime ModifiedDate { get { return _ModifiedDate; } set { _ModifiedDate = value; } }

        public TeamMaster() { }

        public TeamMaster(Master_Team Team)
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

                if(DTO is Master_TeamEXT)
                {
                    _ManagerName = ((Master_TeamEXT)DTO).ManagerName;
                }
            }
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
            DTO.ModifiedDate = _ModifiedDate;

            return DTO;
        }

        public static TeamMaster[] GeTeamDetailsByID(int TeamID)
        {
            Master_Team[] TeamDT = new Master_TeamBusinessObject().GetAllTeamMaster(" MT.ID = " + TeamID);

            TeamMaster[] Team = new TeamMaster[TeamDT.Length];

            for (int i = 0; i < Team.Length; i++)
            {
                Team[i] = new TeamMaster(TeamDT[i]);
            }

            return Team;
        }

        public String Save()
        {
            try
            {
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

    }
}
