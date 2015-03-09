using System;
using System.Collections.Generic;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IS91.Services.DataBlock;
using IRCA.Communication;

namespace HRManager.Entity
{
   public class CandidateSkill:JGridDataObject
    {
        private int _ID;
        private int _candidateID;
        private String _SkillSet;
        private short _NoOfMonths;
        private String _LastApplied;
        private bool _IsNew;

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

        public int candidateID
        {
            get
            {
                return _candidateID;
            }
            set
            {
                _candidateID = value;
            }
        }

        public short NoOfMonths
        {
            get
            {
                return _NoOfMonths;
            }
            set
            {
                _NoOfMonths = value;
            }
        }

       public String SkillSet
        {
            get
            {
                return _SkillSet;
            }
            set
            {
                _SkillSet = value;
            }
        }

        public String LastApplied
        {
            get
            {
                return _LastApplied;
            }
            set
            {
                _LastApplied = value;
            }
        }
        

        /// <summary>
        /// Update the Language field using Assign_Candidate_Language.
        /// </summary>
        /// <param name="Language">Object of Assign_Candidate_Language class</param>
        private void Update(Candidate_Skills  Skill)
        {
            if (Skill != null)
            {
                _ID = Skill.ID;
                _candidateID = Skill.CandidateID;
                _SkillSet = Skill.SkillSet;
                _NoOfMonths = Skill.NoOfMonths;
                _LastApplied = Skill.LastApplied;
                _IsNew = false;

            }
            else
            {
                _IsNew = true;
            }
        }

           /// <summary>
       /// Consturctor of Language class.
       /// Update Language fields using Assign_Candidate_Language.
        /// </summary>
       /// <param name="Language">Object of Assign_Candidate_Language class</param>
        public CandidateSkill(Candidate_Skills Skill)
        {
            Update(Skill);
        }

        /// <summary>
        /// Consturctor of Language class.
        /// Update Role for given Language field.
        /// </summary>
        /// <param name="Language">field contains Language</param>
        public CandidateSkill(String Skill,int candID)
        {
            //Update(new Candidate_SkillsBusinessObject().GetSkillByCandidate(Skill,candID));                        
        }
        /// <summary>
        /// Consturctor of Language class.
       /// Update Language fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains Language ID</param>
        public CandidateSkill(int ID)
        {
            Candidate_Skills Skill = new Candidate_SkillsBusinessObject().GetCandidate_Skills(ID);

            if (Skill == null && ID > 0)
            {
                throw new IRCAException("Invalid Candidate Skill", ID.ToString());
            }

            Update(Skill);
        }

         /// <summary>
        /// Consturctor of Language class.
        /// Set variables for new Language.  
        /// </summary>
        public CandidateSkill()
        {
            _ID = 0;
            _IsNew = true;
        }

        /// <summary>
        /// Save Language.If new Language it add and in case of edit it update the Language.
        /// </summary>
        /// <returns>empty string</returns>
        public String SaveSkill(Session DBSession)
        {
            bool IsLocalSession = false;

            if (DBSession == null)
            {
                IsLocalSession = true;

                DBSession = Session.CreateNewSession();

                DBSession.BeginTransaction();
            }
            try
            {
                Candidate_SkillsBusinessObject CandSkillBO;
                CandSkillBO = new Candidate_SkillsBusinessObject(DBSession);
                Candidate_Skills Skill = new Candidate_Skills();
                Skill.ID = _ID;
                Skill.CandidateID = _candidateID;
                Skill.SkillSet = _SkillSet;
                Skill.NoOfMonths = _NoOfMonths;
                Skill.LastApplied = _LastApplied;

                if (_IsNew)
                {

                    Skill.ID = CandSkillBO.Create(Skill);
                }
                else
                {
                    Skill.ID = _ID;
                    CandSkillBO.Update(Skill);
                }

                if (IsLocalSession)
                {
                    DBSession.Commit();
                }
            }
            catch (Exception e)
            {
                if (IsLocalSession)
                {
                    DBSession.Rollback();
                }

                throw e;
            }
            finally
            {
                if (IsLocalSession)
                {
                    DBSession.Dispose();
                }
            }
            return String.Empty;
        }
        // <summary>
        ///Validate Language for empty and already exist status and then save Language.
        /// </summary>
        /// <returns>String return from the SaveLanguage method</returns> 
        public String Save()
        {
            String Status = string.Empty; // Validate();

            //if (Status != String.Empty)
            //{
            //    return Status;
            //}
            return Status;
           // return SaveLanguage();
        }
        /// <summary>
        /// Return all Language
        /// </summary>
        /// <returns>Array of the object of Language class</returns>
        public static CandidateSkill[] GetAllSkills()
        {
            Candidate_Skills[] SkillDT = new Candidate_SkillsBusinessObject().GetCandidate_Skills();

            CandidateSkill[] Skill = new CandidateSkill[SkillDT.Length];

            for (int i = 0; i < Skill.Length; i++)
            {
                Skill[i] = new CandidateSkill(SkillDT[i]);
            }

            return Skill;
        }
        /// <summary>
        /// Return all Language
        /// </summary>
        /// <returns>Array of the object of Language class</returns>
        public static CandidateSkill[] GetAllSkill(int candidateID)
        {
            Candidate_Skills[] SkillDT = new Candidate_SkillsBusinessObject().GetSkillByCandidate(candidateID);

            CandidateSkill[] Skill = new CandidateSkill[SkillDT.Length];

            for (int i = 0; i < Skill.Length; i++)
            {
                Skill[i] = new CandidateSkill(SkillDT[i]);
            }

            return Skill;
        }
        #region JGridDataObject Members

        public object GetGridData()
        {
            SkillDisplayDetails Skill = new SkillDisplayDetails();

            Skill.SkillID = _ID;
            Skill.SCandidateID = _candidateID;
            Skill.SkillSet = _SkillSet;
            Skill.NoOfMonths = _NoOfMonths;
            Skill.LastApplied = _LastApplied;

            return Skill;
        }

        #endregion
     
    }
   public class SkillDisplayDetails
   {
       public int SkillID;
       public int SCandidateID;
       public String SkillSet;
       public short NoOfMonths;
       public String LastApplied;
   }
}
