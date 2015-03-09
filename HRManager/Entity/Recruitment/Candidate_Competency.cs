using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRCA.Communication;
using HRManager.BusinessObjects;
using HRManager.DTO;
using IRCAKernel;

namespace HRManager.Entity.Recruitment
{
    public class Candidate_Competency :JGridDataObject
    {
        
        private int _ID;
        private String _CompetencyName;
        private String _Description;
       
        private bool _IsActive;

        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;


        public int ID { get { return _ID; } set { _ID = value; } }
        public String CompetencyName { get { return _CompetencyName; } set { _CompetencyName = value; } }
        public String Description { get { return _Description; } set { _Description = value; } }
        
        public bool IsActive { get { return _IsActive; } set { _IsActive = value; } }

        public int CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }
        public DateTime CreatedDate { get { return _CreatedDate; } set { _CreatedDate = value; } }
        public int ModifiedBy { get { return _ModifiedBy; } set { _ModifiedBy = value; } }
        public DateTime ModifiedDate { get { return _ModifiedDate; } set { _ModifiedDate = value; } }
        public bool Status { get { return _IsActive; } set { _IsActive = value; } }

         public Candidate_Competency()
        {
        }
         public Candidate_Competency(int ID)
        {
            Update(new Master_Candidate_CompetencyBusinessObject().GetMaster_Candidate_Competency(ID));
        }
         public void Update(Master_Candidate_Competency DTO)
         {
             if (DTO != null)
             {
                 _ID = DTO.ID;
                 _CompetencyName = DTO.CompetencyName;
                 _Description = DTO.CompetencyDescription;
                 _IsActive = DTO.IsActive;
                 _ModifiedBy = DTO.ModifiedBy;
                 _ModifiedDate = DTO.ModifiedDate;
                 _CreatedBy = DTO.CreatedBy;
                 _CreatedDate = DTO.CreatedDate;
             }
         }
         private Master_Candidate_Competency GetDTO()
         {
             Master_Candidate_Competency DTO = new Master_Candidate_Competency();
             DTO.ID = _ID;
             DTO.CompetencyName = _CompetencyName;
             DTO.CompetencyDescription = _Description;
             DTO.CreatedBy = _CreatedBy;
             DTO.CreatedDate = _CreatedDate;
             DTO.ModifiedBy = _ModifiedBy;
             DTO.ModifiedDate = _ModifiedDate;
             DTO.IsActive = _IsActive;

             if (_ID == 0)
             {
                 DTO.CreatedBy = _CreatedBy;
                 DTO.CreatedDate = DateTime.Now;
             }
             DTO.ModifiedBy = _ModifiedBy;
             DTO.ModifiedDate = DateTime.Now;

             return DTO;
         }
         public String Validate()
         {
             Master_Candidate_CompetencyBusinessObject BO = new Master_Candidate_CompetencyBusinessObject();

             if (BO.IsCandidateCompetencyExists(_CompetencyName, _ID))
             {
                 return "Candidate Competency already exists";
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
         public String Save()
         {
             String Status = Validate();
             if (Status != String.Empty)
             {
                 return Status;
             }
             try
             {
                 Master_Candidate_CompetencyBusinessObject BO = new Master_Candidate_CompetencyBusinessObject();
                 Master_Candidate_Competency DTO = GetDTO();

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
         public object GetGridData()
         {
             return this;
         }
         public static Candidate_Competency[] GetCandidate_Competency()
         {
             Master_Candidate_Competency[] RolesDT = new Master_Candidate_CompetencyBusinessObject().GetCandidateCompetency("IsActive = 1");

             Candidate_Competency[] Roles = new Candidate_Competency[RolesDT.Length];

             for (int i = 0; i < Roles.Length; i++)
             {
                 Roles[i] = new Candidate_Competency();

                 Roles[i].Update(RolesDT[i]);
             }

             return Roles;
         }
         public static Candidate_Competency[] GetInActiveCandidate_Competency()
         {
             Master_Candidate_Competency[] RolesDT = new Master_Candidate_CompetencyBusinessObject().GetCandidateCompetency("IsActive = 0");

             Candidate_Competency[] Roles = new Candidate_Competency[RolesDT.Length];

             for (int i = 0; i < Roles.Length; i++)
             {
                 Roles[i] = new Candidate_Competency();

                 Roles[i].Update(RolesDT[i]);
             }

             return Roles;
         }
         public static Candidate_Competency[] GetAllCandidatecompetencyDetails()
         {
             Master_Candidate_Competency[] CountryDT = new Master_Candidate_CompetencyBusinessObject().GetMaster_Candidate_Competency();
             Candidate_Competency[] Country = new Candidate_Competency[CountryDT.Length];

             for (int i = 0; i < Country.Length; i++)
             {
                 Country[i] = new Candidate_Competency();

                 Country[i].Update(CountryDT[i]);
             }

             return Country;
         }

         public String CheckReference()
         {
             Master_Candidate_CompetencyBusinessObject BO = new Master_Candidate_CompetencyBusinessObject();

             if (BO.IsCompetencyUsedIncandidate(_ID))
             {
                 return "Selected Competency is referred in candidate evaluation form";
             }
             return String.Empty;
         }
    }
}
