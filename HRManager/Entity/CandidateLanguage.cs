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
   public class CandidateLanguage:JGridDataObject
    {
        private int _ID;
        private int _candidateID;
        private String _Language;
        private bool _Read;
        private bool _Write;
        private bool _Speak;
        private bool _MotherTongue;
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

        public String Language
        {
            get
            {
                return _Language;
            }
            set
            {
                _Language = value;
            }
        }

        public bool Read
        {
            get
            {
                return _Read;
            }
            set
            {
                _Read = value;
            }
        }

        public bool Write
        {
            get
            {
                return _Write;
            }
            set
            {
                _Write = value;
            }
        }

        public bool Speak
        {
            get
            {
                return _Speak;
            }
            set
            {
                _Speak = value;
            }
        }

        public bool MotherTongue
        {
            get
            {
                return _MotherTongue;
            }
            set
            {
                _MotherTongue = value;
            }
        }

        /// <summary>
        /// Update the Language field using Assign_Candidate_Language.
        /// </summary>
        /// <param name="Language">Object of Assign_Candidate_Language class</param>
        private void Update( Assign_Candidate_Language  Language)
        {
            if (Language != null)
            {
                _ID = Language.ID;
                _candidateID = Language.CandidateID;
                _Language = Language.CLanguage;
                _Read = Language.CRead;
                _Write = Language.CWrite;
                _Speak = Language.CSpeak;
                _MotherTongue = Language.CMotherTongue;
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
        public CandidateLanguage(Assign_Candidate_Language Language)
        {
            Update(Language);
        }

        /// <summary>
        /// Consturctor of Language class.
        /// Update Role for given Language field.
        /// </summary>
        /// <param name="Language">field contains Language</param>
        public CandidateLanguage(String Language,int candID)
        {
            Update(new Assign_Candidate_LanguageBusinessObject().GetLanguageByCandidate(Language,candID));                        
        }
        /// <summary>
        /// Consturctor of Language class.
       /// Update Language fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains Language ID</param>
        public CandidateLanguage(int ID)
        {
            Assign_Candidate_Language Language = new Assign_Candidate_LanguageBusinessObject().GetAssign_Candidate_Language(ID);

            if (Language == null && ID > 0)
            {
                throw new IRCAException("Invalid Candidate Language", ID.ToString());
            }

            Update(Language);
        }

         /// <summary>
        /// Consturctor of Language class.
        /// Set variables for new Language.  
        /// </summary>
        public CandidateLanguage()
        {
            _ID = 0;
            _IsNew = true;
        }

        /// <summary>
        /// Save Language.If new Language it add and in case of edit it update the Language.
        /// </summary>
        /// <returns>empty string</returns>
        public String SaveLanguage(Session DBSession)
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
                Assign_Candidate_LanguageBusinessObject CandLangBO;
                CandLangBO = new Assign_Candidate_LanguageBusinessObject(DBSession);
                Assign_Candidate_Language Language = new Assign_Candidate_Language();
                Language.ID = _ID;
                Language.CandidateID = _candidateID;
                Language.CLanguage = _Language;
                Language.CRead = _Read;
                Language.CSpeak = _Speak;
                Language.CWrite = _Write;
                Language.CMotherTongue = _MotherTongue;

                if (_IsNew)
                {

                    Language.ID = CandLangBO.Create(Language);
                }
                else
                {
                    Language.ID = _ID;
                    CandLangBO.Update(Language);
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
        //public String Save()
        //{
        //    String Status = string.Empty; // Validate();

        //    //if (Status != String.Empty)
        //    //{
        //    //    return Status;
        //    //}
        //    return Status;
        //   // return SaveLanguage();
        //}
        /// <summary>
        /// Return all Language
        /// </summary>
        /// <returns>Array of the object of Language class</returns>
        public static CandidateLanguage[] GetAllLanguages()
        {
            Assign_Candidate_Language[] LanguageDT = new Assign_Candidate_LanguageBusinessObject().GetAssign_Candidate_Language();

            CandidateLanguage[] Languages = new CandidateLanguage[LanguageDT.Length];

            for (int i = 0; i < Languages.Length; i++)
            {
                Languages[i] = new CandidateLanguage(LanguageDT[i]);
            }

            return Languages;
        }
        /// <summary>
        /// Return all Language
        /// </summary>
        /// <returns>Array of the object of Language class</returns>
        public static CandidateLanguage[] GetAllLanguages(int candidateID)
        {
            Assign_Candidate_Language[] LanguageDT = new Assign_Candidate_LanguageBusinessObject().GetLanguageByCandidate(candidateID);

            CandidateLanguage[] Languages = new CandidateLanguage[LanguageDT.Length];

            for (int i = 0; i < Languages.Length; i++)
            {
                Languages[i] = new CandidateLanguage(LanguageDT[i]);
            }

            return Languages;
        }
        public String Save()
        {
            try
            {
                Assign_Candidate_LanguageBusinessObject BO = new Assign_Candidate_LanguageBusinessObject();
                Assign_Candidate_Language DTO = GetDTO();

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
        private Assign_Candidate_Language GetDTO()
        {
            Assign_Candidate_Language DTO = new Assign_Candidate_Language();
            DTO.ID = _ID;
            DTO.CandidateID = _candidateID;
            DTO.CLanguage = _Language;
            DTO.CRead = _Read;
            DTO.CSpeak = _Speak;
            DTO.CWrite = _Write;
            DTO.CMotherTongue = _MotherTongue;           

            return DTO;
        }
        #region JGridDataObject Members

        public object GetGridData()
        {
            LanguageDisplayDetails Language = new LanguageDisplayDetails();

            Language.LanguageID = _ID;
            Language.LCandidateID = _candidateID;
            Language.Language = _Language;
            String ReadStatus = "<img src='Resources/Images/cross.png' />";
            String WriteStatus = "<img src='Resources/Images/cross.png' />";
            String SpeakStatus = "<img src='Resources/Images/cross.png' />";
            String MotherTongueStatus = "<img src='Resources/Images/cross.png' />";
            if (_Read==true) ReadStatus = "<img src='Resources/Images/tick.png' />";
            if (_Write == true) WriteStatus = "<img src='Resources/Images/tick.png' />";
            if (_Speak == true) SpeakStatus = "<img src='Resources/Images/tick.png' />";
            if (_MotherTongue == true) MotherTongueStatus = "<img src='Resources/Images/tick.png' />";
            Language.read = ReadStatus;
            Language.write = WriteStatus;
            Language.speak = SpeakStatus;
            Language.mothertongue = MotherTongueStatus;
            return Language;
        }

        #endregion
     
    }
   public class LanguageDisplayDetails
   {
       public int LanguageID;
       public int LCandidateID;
       public String Language;
       public String read;
       public String write;
       public String speak;
       public String mothertongue;
   }
}
