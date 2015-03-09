using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRCA.Communication;
using HRManager.DTO;
using HRManager.BusinessObjects;
using HRManager.DTOEXT;

namespace HRManager.Entity
{
    public class ProjectInfo : JGridDataObject
    {
        public int _ID;
        public int _CompanyID;
        public String _ProjectGroup;
        public String _ProjectType;
        public String _ProjectCode;
        public String _Address;
        public String _ProjectName;
        public String _Contractown;
        public String _CompanyName;
        public bool _IsActive;
        public int _UpdateBy;
        public int _CreatedBy;
        public DateTime _CreatedDate;
        public int _ModifiedBy;
        public DateTime _ModifiedDate;
        public bool _IsNew;


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
        public int CompanyID
        {
            get
            {
                return _CompanyID;
            }
            set
            {
                _CompanyID = value;
            }
        }
        public String ProjectGroup
        {
            get
            {
                return _ProjectGroup;
            }
            set
            {
                _ProjectGroup = value;
            }
        }
         public String ProjectType
        {
            get
            {
                return _ProjectType;
            }
            set
            {
                _ProjectType = value;
            }
        }
        public String ProjectCode
        {
            get
            {
                return _ProjectCode;
            }
            set
            {
                _ProjectCode = value;
            }
        }
         public String ProjectName
        {
            get
            {
                return _ProjectName;
            }
            set
            {
                _ProjectName = value;
            }
        }
         public String Contractown
        {
            get
            {
                return _Contractown;
            }
            set
            {
                _Contractown = value;
            }
        }
        
        public String Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }
        public String CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }
        public bool IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                _IsActive = value;
            }
        }
        public int UpdatedBy
        {
            get { return _UpdateBy; }
            set { _UpdateBy = value; }
        }
        public bool Status { get { return _IsActive; } set { _IsActive = value; } }


        private void Update(Master_ProjectInformation Projectinfo)
        {
            if (Projectinfo != null)
            {
                _ID = Projectinfo.ID;
                _CompanyID = Projectinfo.CompanyID;
                _ProjectGroup = Projectinfo.ProjectGroup;
                _ProjectCode=Projectinfo.ProjectCode;
                _ProjectType = Projectinfo.ProjectType;
                _Address = Projectinfo.Address;
                _ProjectName=Projectinfo.ProjectName;
                _Contractown=Projectinfo.checkcontractown;
                _IsActive = Projectinfo.IsActive;
                _CreatedBy = Projectinfo.CreatedBy;
                _ModifiedBy = Projectinfo.ModifiedBy;
                _CreatedDate = Projectinfo.CreatedDate;
                _ModifiedDate = Projectinfo.ModifiedDate;
                _IsNew = false;
                if (Projectinfo is Master_ProjectInfoEXT)
                {
                    _CompanyName = ((Master_ProjectInfoEXT)Projectinfo).CompanyName;
                }

            }
            else
            {
                _IsNew = true;
            }
        }
        private String SaveProjectInfo()
        {

            Master_ProjectInformation ProjectInfos = new Master_ProjectInformation();
            ProjectInfos.ID = _ID;

            ProjectInfos.CompanyID = _CompanyID;
            ProjectInfos.ProjectGroup = _ProjectGroup;
            ProjectInfos.ProjectCode=_ProjectCode;
            ProjectInfos.ProjectType=_ProjectType;
            ProjectInfos.Address = _Address;
            ProjectInfos.ProjectName = _ProjectName;
            ProjectInfos.checkcontractown = _Contractown;
            ProjectInfos.IsActive = _IsActive;
            ProjectInfos.ModifiedBy = _ModifiedBy;
            ProjectInfos.ModifiedDate = DateTime.Now;
            ProjectInfos.CreatedBy = _CreatedBy;
            ProjectInfos.CreatedDate = _CreatedDate;

            if (_IsNew)
            {
                ProjectInfos.CreatedBy = _UpdateBy;
                ProjectInfos.CreatedDate = DateTime.Now;
                ProjectInfos.ID = new Master_ProjectInformationBusinessObject().Create(ProjectInfos);
            }
            else
            {
                ProjectInfos.ModifiedBy = _UpdateBy;
                ProjectInfos.ModifiedDate = DateTime.Now;
                ProjectInfos.ID = _ID;
                new Master_ProjectInformationBusinessObject().Update(ProjectInfos);
            }

            return String.Empty;
        }
        public String Save()
        {
            String Status = Validate();

            if (Status != String.Empty)
            {
                return Status;
            }

            return SaveProjectInfo();
        }
        private String Validate()
        {
            Master_ProjectInformationBusinessObject RelationBO = new Master_ProjectInformationBusinessObject();

            //if (_RelationName == String.Empty)
            //{
            //    return HRManagerDefs.RelationMessages.EMPTY_Relation;
            //}
            //else if (RelationBO.IsRelationExists(_RelationName, _ID))
            //{
            //    return HRManagerDefs.RelationMessages.Relation_EXISTS;
            //}
            return String.Empty;
        }

         public ProjectInfo(int ID)
        {
            Master_ProjectInformation Project = new Master_ProjectInformationBusinessObject().GetMaster_ProjectInformation(ID);
            Update(Project);
        }
        public String DeActivate(int DeActivatedBy)
        {
            _IsActive = false;
            _UpdateBy = DeActivatedBy;
            return SaveProjectInfo();
        }

        public String Activate(int ActivatedBy)
        {
            _IsActive = true;
            _UpdateBy = ActivatedBy;
            return SaveProjectInfo();
        }
        public ProjectInfo(Master_ProjectInformation ProjectName)
        {
            Update(ProjectName);
        }
        public static ProjectInfo[] GetAllActiveProject()
        {
            Master_ProjectInformation[] ProjectDT = new Master_ProjectInformationBusinessObject().GetAllActiveProjectInfo();
            ProjectInfo[] Project = new ProjectInfo[ProjectDT.Length];

            for (int i = 0; i < Project.Length; i++)
            {
                Project[i] = new ProjectInfo(ProjectDT[i]);
            }

            return Project;
        }

        public static ProjectInfo[] GetAllProjectDetails()
        {
            Master_ProjectInformation[] ProjectDT = new Master_ProjectInformationBusinessObject().GetAllProjectInfoDetails();
            ProjectInfo[] Project = new ProjectInfo[ProjectDT.Length];

            for (int i = 0; i < Project.Length; i++)
            {
                Project[i] = new ProjectInfo(ProjectDT[i]);
            }

            return Project;
        }

        public static ProjectInfo[] GetAllInActiveProject()
        {
            Master_ProjectInformation[] ProjectDT = new Master_ProjectInformationBusinessObject().GetAllInActiveProjectInfoOrderByProjectName();

            ProjectInfo[] Project = new ProjectInfo[ProjectDT.Length];

            for (int i = 0; i < Project.Length; i++)
            {
                Project[i] = new ProjectInfo(ProjectDT[i]);
            }

            return Project;
        }


        #region JGridDataObject Members

        public object GetGridData()
        {
            ProjectInfoDetails Companys = new ProjectInfoDetails();

            Companys.ID = _ID;
            Companys.CompanyID = _CompanyID;
            Companys.ProjectGroup = _ProjectGroup;
            Companys.ProjectName = _ProjectName;
            Companys.ProjectType = _ProjectType;
            Companys.ProjectCode = _ProjectCode;
            Companys.Address = _Address;
            Companys.checkcontractown = _Contractown;
            Companys.CompanyName = _CompanyName;
            Companys.Status = _IsActive;
            Companys.IsActive = _IsActive;

            return Companys;
        }

        #endregion



    }

    public class ProjectInfoDetails
    {
        public int ID;
        public int CompanyID;
        public String ProjectGroup;
        public String ProjectCode;
        public String ProjectType;
        public String Address;
        public String ProjectName;
        public String checkcontractown;
        public String CompanyName;
        public bool IsActive;
        public bool Status;

    }
}
