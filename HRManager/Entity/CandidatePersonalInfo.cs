using System;
using System.Collections.Generic;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;

using CommonManager.DTO;
using CommonManager.Entity;
using IS91.Services.DataBlock;
using IRCA.Communication;

namespace HRManager.Entity
{
    /// <summary>
    /// Represents Candidate fields and methods.
    /// </summary>
  public class CandidatePersonalInfo:JGridDataObject
    {
        private int _ID;
        private String _FirstName;
        private String _LastName;
        private String _FatherName;
        private String _Sex;
        private String _MaritialStatus;
        private String _PAddess;
        private String _PStreet;
        private State _PState = null;
        private String _PStateID;
        private String _PCity;
        private String _PZipCode;
        private String _PPhoneNo;
        private String _PMobileNumber;
        private String _TStreet;
        private State _TState = null;
       // private String _TStateID;
        private String _TCity;
        private String _TAddess;
        private String _TZipCode;
        private String _TMobileNumber;
        private String _TelephoneNoRes;
        private String _TelephoneNoOff;
        private DateTime _DOB;
        private String _PhysicalDisability;
        private String _EMailID;
        private bool _IsPhysicalDisability;
        private bool _IsNew;
        private bool _IsActive;
        private bool _IsFresher;
        private String _Lpcountry;
        private String _Lpstate;
        private String _Ltcountry;
        private String _Ltstate;

        private String _Status;

        private String _Location;
        private String _JobProfile;
        private bool _ExpLevel;
        private String _Graduate;
        private bool _IsTechnical;
        private String _Degree;
        private String _Title;

        public String Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
            }
        }
        public String Graduate
        {
            get
            {
                return _Graduate;
            }
            set
            {
                _Graduate = value;
            }
        }
        public String Degree
        {
            get
            {
                return _Degree;
            }
            set
            {
                _Degree = value;
            }
        }
        public bool IsTechnical
        {
            get
            {
                return _IsTechnical;
            }
            set
            {
                _IsTechnical = value;
            }
        }
        public String Location
        {
            get
            {
                return _Location;
            }
            set
            {
                _Location = value;
            }
        }
        public String FatherName
        {
            get
            {
                return _FatherName;
            }
            set
            {
                _FatherName = value;
            }
        }
        public String JobProfile
        {
            get
            {
                return _JobProfile;
            }
            set
            {
                _JobProfile = value;
            }
        }
        public bool ExpLevel
        {
            get
            {
                return _ExpLevel;
            }
            set
            {
                _ExpLevel = value;
            }
        }

        public String Lpcountry
        {
            get
            {
                return _Lpcountry;
            }
            set
            {
                _Lpcountry = value;
            }
        }
        public String Lpstate
        {
            get
            {
                return _Lpstate;
            }
            set
            {
                _Lpstate = value;
            }

        }
        public String Ltcountry
        {
            get
            {
                return _Ltcountry;
            }
            set
            {
                _Ltcountry = value;
            }
        }
        public String Ltstate
        {
            get
            {
                return _Ltstate;
            }
            set
            {
                _Ltstate = value;
            }
        }
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
        public String FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
            }
        }
        public String LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
            }
        }
        public String Sex
        {
            get
            {
                return _Sex;
            }
            set
            {
                _Sex = value;
            }
        }
        public String MaritialStatus
        {
            get
            {
                return _MaritialStatus;
            }
            set
            {
                _MaritialStatus = value;
            }
        }
        public String PAddess
        {
            get
            {
                return _PAddess;
            }
            set
            {
                _PAddess = value;
            }
        }
        public String PStreet
        {
            get
            {
                return _PStreet;
            }
            set
            {
                _PStreet = value;
            }
        }
        //public String PStateID
        //{
        //    get
        //    {
        //        return _PStateID;
        //    }
        //    set
        //    {
        //        _PStateID = value;
        //    }
        //}
        public String PCity
        {
            get
            {
                return _PCity;
            }
            set
            {
                _PCity = value;
            }
        }
        public String PZipCode
        {
            get
            {
                return _PZipCode;
            }
            set
            {
                _PZipCode = value;
            }
        }
        public String PPhoneNo
        {
            get
            {
                return _PPhoneNo;
            }
            set
            {
                _PPhoneNo = value;
            }
        }
        public String PMobileNumber
        {
            get
            {
                return _PMobileNumber;
            }
            set
            {
                _PMobileNumber = value;
            }
        }
        public String TStreet
        {
            get
            {
                return _TStreet;
            }
            set
            {
                _TStreet = value;
            }
        }
        //public String TStateID
        //{
        //    get
        //    {
        //        return _TStateID;
        //    }
        //    set
        //    {
        //        _TStateID = value;
        //    }
        //}
        public String TCity
        {
            get
            {
                return _TCity;
            }
            set
            {
                _TCity = value;
            }
        }
        public String TAddess
        {
            get
            {
                return _TAddess;
            }
            set
            {
                _TAddess = value;
            }
        }
        public String TZipCode
        {
            get
            {
                return _TZipCode;
            }
            set
            {
                _TZipCode = value;
            }
        }
        public String TMobileNumber
        {
            get
            {
                return _TMobileNumber;
            }
            set
            {
                _TMobileNumber = value;
            }
        }
        public String TelephoneNoRes
        {
            get
            {
                return _TelephoneNoRes;
            }
            set
            {
                _TelephoneNoRes = value;
            }
        }
        public String TelephoneNoOff
        {
            get
            {
                return _TelephoneNoOff;
            }
            set
            {
                _TelephoneNoOff = value;
            }
        }
        
      public DateTime DOB
        {
            get
            {
                return _DOB;
            }
            set
            {
                _DOB = value;
            }
        }
        public String PhysicalDisability
        {
            get
            {
                return _PhysicalDisability;
            }
            set
            {
                _PhysicalDisability = value;
            }
        }
        public String EMailID
        {
            get
            {
                return _EMailID;
            }
            set
            {
                _EMailID = value;
            }
        }
        public bool IsPhysicalDisability
        {
            get
            {
                return _IsPhysicalDisability;
            }
            set
            {
                _IsPhysicalDisability = value;
            }
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
        public bool IsFresher
        {
            get
            {
                return _IsFresher;
            }
            set
            {
                _IsFresher = value;
            }
        }
        public String Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }
        public int PStateID
        {
            get
            {
                return _PState.ID;
            }
            set
            {
                _PState = new State(value);
            }
        }
        public State PState
        {
            get
            {
                return _PState;
            }
            set
            {
                _PState = value;
            }
        }
        public String PStateName
        {
            get
            {
                if (_PState != null)
                {
                    return _PState.StateName;
                }
                else
                {
                    return String.Empty;
                }
            }
        }
        public int TStateID
        {
            get
            {
                return _TState.ID;
            }
            set
            {
                _TState = new State(value);
            }
        }
        public State TState
        {
            get
            {
                return _TState;
            }
            set
            {
                _TState = value;
            }
        }
        public String TStateName
        {
            get
            {
                if (_TState != null)
                {
                    return _TState.StateName;
                }
                else
                {
                    return String.Empty;
                }
            }
        }
        // <summary> 
        /// Update the Candidate field using Master_Candidate.
        /// </summary>
        /// <param name="Candidate">Object of Master_Candidate class</param>

        private void Update(CandidatePersonalInfo Candidate)
        {
            if (Candidate != null)
            {
                _ID = Candidate.ID;
                _FirstName = Candidate.FirstName;
                _LastName = Candidate.LastName;
                _FatherName = Candidate.FatherName;
                _Sex = Candidate.Sex;
                _MaritialStatus = Candidate.MaritialStatus;
                _PAddess = Candidate.PAddess;
                _PCity = Candidate.PCity;
                _PMobileNumber = Candidate.PMobileNumber;
                _PPhoneNo = Candidate.PPhoneNo;
               // _PState = Candidate.PState;
                _PState = new State(Candidate.PStateID);
                _PStreet = Candidate.PStreet;
                _PZipCode = Candidate.PZipCode;
                _PhysicalDisability = Candidate.PhysicalDisability;
                _TAddess = Candidate.TAddess;
                _TCity = Candidate.TCity;
                _TelephoneNoOff = Candidate.TelephoneNoOff;
                _TelephoneNoRes = Candidate.TelephoneNoRes;
                _TMobileNumber = Candidate.TMobileNumber;
               // _TState = Candidate.TState;
                _TState = new State(Candidate.TStateID);
                _TStreet = Candidate.TStreet;
                _TZipCode = Candidate.TZipCode;
                _DOB = Candidate.DOB;
                _EMailID = Candidate.EMailID;
                _IsPhysicalDisability = Candidate.IsPhysicalDisability;
                _IsNew = false;
                _IsActive = Candidate.IsActive;
                _IsFresher = Candidate.IsFresher;
                _Title = Candidate.Title;

            }
            else
            {
                _IsNew = true;
            }
        }
 
        // <summary> 
        /// Update the Candidate field using Master_Candidate.
        /// </summary>
        /// <param name="Candidate">Object of Master_Candidate class</param>
       
      private void Update(Master_Candidate Candidate)
        {
            if (Candidate != null)
            {
                _ID = Candidate.ID;
                _FirstName = Candidate.FirstName;
                _LastName = Candidate.LastName;
                _FatherName = Candidate.FatherName;
                _Sex = Candidate.Sex;
                _MaritialStatus = Candidate.MaritialStatus;
                _PAddess = Candidate.Per_Addess;
                _PCity = Candidate.Per_City;
                _PMobileNumber = Candidate.Per_MobileNumber;
                _PPhoneNo=Candidate.Per_PhoneNo;
                //_PState=Candidate.Per_State;
                _PState = new State(Candidate.Per_StateID);
                _PStreet=Candidate.Per_Street;
                _PZipCode=Candidate.Per_ZipCode;
                _PhysicalDisability=Candidate.PhysicalDisability;
                _TAddess = Candidate.Temp_Addess;
                _TCity = Candidate.Temp_City;
                _TelephoneNoOff = Candidate.TelephoneNoOff;
                _TelephoneNoRes = Candidate.TelephoneNoRes;
                _TMobileNumber = Candidate.Temp_MobileNumber;
               // _TState = Candidate.Temp_State;
                _TState = new State(Candidate.Temp_StateID);
                _TStreet = Candidate.Temp_Street;
                _TZipCode = Candidate.Temp_ZipCode;
                _DOB = Candidate.DOB;
                _EMailID = Candidate.EMailID;
                _IsPhysicalDisability = Candidate.IsPhysicalDisability;
                _IsNew = false;
                _IsActive = Candidate.IsActive;
                _IsFresher = Candidate.IsFresher;
                _IsTechnical = Candidate.IsTechnical;
                _Graduate = Candidate.Graduate;
                _Degree = Candidate.Degree;
                _Title = Candidate.Title;
            }
            else
            {
                _IsNew = true;
            }
        }
 
        /// <summary>
        /// Consturctor of CandidatePersonalInfo class.
        /// Update Candidate fields using Master_Candidate.
        /// </summary>
        /// <param name="Candidate">Object of Master_Candidate class</param>
        public CandidatePersonalInfo(Master_Candidate Candidate)
        {
            Update(Candidate);
        }

      /// <summary>
       /// Consturctor of CandidatePersonalInfo class.
       /// Update Candidate for given Candidate field.
        /// </summary>
        /// <param name="CandidateName">field contains Candidate Name</param>
        public CandidatePersonalInfo(String Candidate)
        {
            Update(new Master_CandidateBusinessObject().GetCandidateByCandidate(_FirstName,_LastName));                        
        }

       /// <summary>
        /// Consturctor of Master_Candidate class.
       /// Update Candidate fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains Candidate ID</param>
        public CandidatePersonalInfo(int ID)
        {
            Master_Candidate Candidate = new Master_CandidateBusinessObject().GetMaster_Candidate(ID);

            if (Candidate == null && ID > 0)
            {
                throw new IRCAException("Invalid Candidate", ID.ToString());
            }

            Update(Candidate);
        }

       /// <summary>
        /// Consturctor of CandidatePersonalInfo class.
        /// Set variables for new Candidate.  
        /// </summary>
        public CandidatePersonalInfo()
        {
            _ID = 0;
            _IsNew = true;
        }

        /// <summary>
        /// Save Candidate.If new Candidate it add and in case of edit it update the Candidate.
        /// </summary>
        /// <returns>empty string</returns>
        private String SaveCandidate(Session DBSession)
        {

            Master_Candidate Candidate = new Master_Candidate();
            Candidate.ID = _ID;
            Candidate.FirstName = _FirstName;
            Candidate.LastName = _LastName;
            Candidate.FatherName = _FatherName;
            Candidate.Sex = _Sex;
            Candidate.MaritialStatus = _MaritialStatus;
            Candidate.IsPhysicalDisability = _IsPhysicalDisability;
            Candidate.Per_Addess = _PAddess;
            Candidate.Per_City = _PCity;
            Candidate.Per_MobileNumber = _PMobileNumber;
            Candidate.Per_PhoneNo = _PPhoneNo;
           // Candidate.Per_State = _PState;
            Candidate.Per_StateID = _PState.ID;
            Candidate.Per_Street = _PStreet;
            Candidate.Per_ZipCode = _PZipCode;
            Candidate.PhysicalDisability = _PhysicalDisability;
            Candidate.TelephoneNoOff = _TelephoneNoOff;
            Candidate.TelephoneNoRes = _TelephoneNoRes;
            Candidate.DOB =_DOB;
            Candidate.EMailID = _EMailID;
            Candidate.Temp_Addess = _TAddess;
            Candidate.Temp_City = _TCity;
            Candidate.Temp_MobileNumber = _TMobileNumber;
           // Candidate.Temp_State = _TState;
            Candidate.Temp_StateID = _TState.ID;
            Candidate.Temp_Street = _TStreet;
            Candidate.Temp_ZipCode = _TZipCode;
            Candidate.IsActive = _IsActive;
            Candidate.IsFresher = _IsFresher;
            Candidate.IsTechnical = _IsTechnical;
            Candidate.Graduate = _Graduate;
            Candidate.Degree = _Degree;
            Candidate.Title = _Title;

            if (_IsNew)
            {

                Candidate.ID = new Master_CandidateBusinessObject(DBSession).Create(Candidate);
            }
            else
            {
                Candidate.ID = _ID;
                new Master_CandidateBusinessObject(DBSession).Update(Candidate);
            }

            return String.Empty;
        }

        /// <summary>
        /// Save Candidate.If new Candidate it add and in case of edit it update the Candidate.
        /// </summary>
        /// <returns>empty string</returns>
        private String SaveCandidate()
        {

            Master_Candidate Candidate = new Master_Candidate();
            Candidate.ID = _ID;
            Candidate.FirstName = _FirstName;
            Candidate.LastName = _LastName;
            Candidate.FatherName = _FatherName;
            Candidate.Sex = _Sex;
            Candidate.MaritialStatus = _MaritialStatus;
            Candidate.IsPhysicalDisability = _IsPhysicalDisability;
            Candidate.Per_Addess = _PAddess;
            Candidate.Per_City = _PCity;
            Candidate.Per_MobileNumber = _PMobileNumber;
            Candidate.Per_PhoneNo = _PPhoneNo;
            // Candidate.Per_State = _PState;
            if (_PState == null)
            {
            }
            else 
            {
                Candidate.Per_StateID = _PState.ID;
            }
            
            Candidate.Per_Street = _PStreet;
            Candidate.Per_ZipCode = _PZipCode;
            Candidate.PhysicalDisability = _PhysicalDisability;
            Candidate.TelephoneNoOff = _TelephoneNoOff;
            Candidate.TelephoneNoRes = _TelephoneNoRes;
            Candidate.DOB = _DOB;
            Candidate.EMailID = _EMailID;
            Candidate.Temp_Addess = _TAddess;
            Candidate.Temp_City = _TCity;
            Candidate.Temp_MobileNumber = _TMobileNumber;
            // Candidate.Temp_State = _TState;
            if (_PState == null)
            {
            }
            else
            {
                Candidate.Temp_StateID = _TState.ID;
            }
            
            Candidate.Temp_Street = _TStreet;
            Candidate.Temp_ZipCode = _TZipCode;
            Candidate.IsActive = _IsActive;
            Candidate.IsFresher = _IsFresher;
            Candidate.IsTechnical = _IsTechnical;
            Candidate.Graduate = _Graduate;
            Candidate.Degree = _Degree;
            Candidate.Title = _Title;
            if (_IsNew)
            {

                Candidate.ID = new Master_CandidateBusinessObject().Create(Candidate);
            }
            else
            {
                Candidate.ID = _ID;
                new Master_CandidateBusinessObject().Update(Candidate);
            }

            return String.Empty;
        }

        /// <summary>
        /// Update Role of given ID
        /// </summary>
        /// <param name="ID">field contain Role ID</param>
        /// <param name="ZoneName">field contain Role Name</param>
        /// <param name="Description">field contain Role Description</param>
        /// <param name="IsActive">field contaions Active status.</param>
        /// <param name="UpdatedBy">field contain the user id who update Role</param>
        /// <returns>empty string for success and error message for failure</returns>
        public static String UpdateEmployeeCandidate(int ID, String PAddess, String PCity,String PMobileNumber,String PPhoneNo,int PStateID,String PStreet,String PZipCode,
                                                     String TelephoneNoOff, String TelephoneNoRes, String EMailID,String TAddess,String TCity, String TMobileNumber,
                                                     int TStateID, String TStreet, String TZipCode, String Graduate, bool IsTechnical, String Degree, String MaritialStatus,String FatherName, Session DBSession)
        {   
             bool IsLocalSession = false;

           
            try
            {
                if (DBSession == null)
                {
                    IsLocalSession = true;

                    DBSession = Session.CreateNewSession();

                    DBSession.BeginTransaction();
                }
                try
                {

                CandidatePersonalInfo Candidate = new CandidatePersonalInfo(ID);
                Candidate.FatherName = FatherName;
                Candidate.PAddess = PAddess;
                Candidate.PCity = PCity;
                Candidate.PMobileNumber = PMobileNumber;
                Candidate.PPhoneNo = PPhoneNo;
                // Candidate.Per_State = _PState;
                Candidate.PStateID = PStateID;
                Candidate.PStreet= PStreet;
                Candidate.PZipCode = PZipCode;
                Candidate.TelephoneNoOff = TelephoneNoOff;
                Candidate.TelephoneNoRes = TelephoneNoRes;
                Candidate.EMailID = EMailID;
                Candidate.TAddess = TAddess;
                Candidate.TCity = TCity;
                Candidate.TMobileNumber = TMobileNumber;
                // Candidate.Temp_State = _TState;
                Candidate.TStateID = TStateID;
                Candidate.TStreet = TStreet;
                Candidate.TZipCode = TZipCode;
                Candidate.Graduate = Graduate;
                Candidate.IsTechnical = IsTechnical;
                Candidate.Degree = Degree;
                Candidate.MaritialStatus = MaritialStatus;

                String Status = Candidate.SaveCandidate(DBSession);

                if (IsLocalSession)
                {
                    DBSession.Commit();
                }
                return Status;

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
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.ShiftMessages.SHIFT_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.ShiftMessages.SHIFT_UPDATE_FAILURE;
            }
        }
        private int SaveCandidateRetId(Session DBSession)
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
                Master_CandidateBusinessObject CandBO;
                CandBO = new Master_CandidateBusinessObject(DBSession);
                Master_Candidate Candidate = new Master_Candidate();
                Candidate.ID = _ID;
                Candidate.FirstName = _FirstName;
                Candidate.LastName = _LastName;
                Candidate.FatherName = _FatherName;
                Candidate.Sex = _Sex;
                Candidate.MaritialStatus = _MaritialStatus;
                Candidate.IsPhysicalDisability = _IsPhysicalDisability;
                Candidate.Per_Addess = _PAddess;
                Candidate.Per_City = _PCity;
                Candidate.Per_MobileNumber = _PMobileNumber;
                Candidate.Per_PhoneNo = _PPhoneNo;
                // Candidate.Per_State = _PState;
                Candidate.Per_StateID = _PState.ID;
                Candidate.Per_Street = _PStreet;
                Candidate.Per_ZipCode = _PZipCode;
                Candidate.PhysicalDisability = _PhysicalDisability;
                Candidate.TelephoneNoOff = _TelephoneNoOff;
                Candidate.TelephoneNoRes = _TelephoneNoRes;
                Candidate.DOB = _DOB;
                Candidate.EMailID = _EMailID;
                Candidate.Temp_Addess = _TAddess;
                Candidate.Temp_City = _TCity;
                Candidate.Temp_MobileNumber = _TMobileNumber;
                //  Candidate.Temp_State = _TState;
                Candidate.Temp_StateID = _TState.ID;
                Candidate.Temp_Street = _TStreet;
                Candidate.Temp_ZipCode = _TZipCode;
                Candidate.IsActive = _IsActive;
                Candidate.IsFresher = _IsFresher;
                Candidate.IsTechnical = _IsTechnical;
                Candidate.Graduate = _Graduate;
                Candidate.Degree = _Degree;
                Candidate.Title = _Title;
                if (_IsNew)
                {
                    Candidate.IsActive = true;
                    Candidate.ID = CandBO.Create(Candidate);
                }
                else
                {
                    Candidate.ID = _ID;
                     CandBO.Update(Candidate);
                }
                if (IsLocalSession)
                {
                    DBSession.Commit();
                }
                return Candidate.ID;
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
        }
        // <summary>
        ///Validate Candidate for empty and already exist status and then save Candidate.
        /// </summary>
        /// <returns>String return from the SaveCandidate method</returns> 
        public String Save()
        {
            String Status = Validate();

            if (Status != String.Empty)
            {
                return Status;
            }

            return SaveCandidate();
        }

        public int SaveRetId(Session DBSession)
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
                String Status = Validate();

                if (Status != String.Empty)
                {
                    return 0;
                }

                if (IsLocalSession)
                {
                    DBSession.Commit();
                }
                return SaveCandidateRetId(DBSession);

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
           
        }
        public static String CheckCandidate(String InFirstName, String InLastName, int InID,String InEmailID,DateTime InDOB)
        {
            Master_CandidateBusinessObject CandidateBO = new Master_CandidateBusinessObject();
            if (CandidateBO.IsCandidateeExists(InFirstName, InLastName, InID,InEmailID, InDOB))
            {
                if (CandidateBO.IsCandidateeAbleToRejoin(InFirstName, InLastName, InID, InEmailID, InDOB))
                {
                    return String.Empty;
                }
                else
                {
                    return HRManagerDefs.CandidatePersonalInfoMessages.CANDIDATE_EXISTS;

                }
            }
            else
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// Validate CandidateName for empty and already exist status.
        /// </summary>
        /// <returns>empty string</returns>
        private String Validate()
        {
            Master_CandidateBusinessObject CandidateBO = new Master_CandidateBusinessObject();

            if (_FirstName == String.Empty)
            {
                return HRManagerDefs.CandidatePersonalInfoMessages.EMPTY_FIRSTNAME;
            }
            else if (_LastName == String.Empty)
            {
                return HRManagerDefs.CandidatePersonalInfoMessages.EMPTY_LASTNAME;
            }
            else if (CandidateBO.IsCandidateeExists(_FirstName,_LastName, _ID,_EMailID,_DOB))
            {
                return HRManagerDefs.CandidatePersonalInfoMessages.CANDIDATE_EXISTS;
            }           
            return String.Empty;
        }
        /// <summary>
        /// Return all Candidates
        /// </summary>
        /// <returns>Array of the object of CandidatePersonalInfo class</returns>
        public static CandidatePersonalInfo[] GetAllCandidates()
        {
            Master_Candidate[] CandidatesDT = new Master_CandidateBusinessObject().GetMaster_Candidate();

            CandidatePersonalInfo[] Candidates = new CandidatePersonalInfo[CandidatesDT.Length];

            for (int i = 0; i < Candidates.Length; i++)
            {
                Candidates[i] = new CandidatePersonalInfo(CandidatesDT[i]);
            }

            return Candidates;
        }

        /// <summary>
        /// Return all Candidates
        /// </summary>
        /// <returns>Array of the object of CandidatePersonalInfo class</returns>
        public static CandidatePersonalInfo[] GetCandidateInfo(int candidateID)
        {
            Master_Candidate[] CandidatesDT = new Master_CandidateBusinessObject().GetCandidateByCandidate(candidateID);

            CandidatePersonalInfo[] Candidates = new CandidatePersonalInfo[CandidatesDT.Length];

            for (int i = 0; i < Candidates.Length; i++)
            {
                Candidates[i] = new CandidatePersonalInfo(CandidatesDT[i]);
            }

            return Candidates;
        }
        /// <summary>
        /// Return all Candidates
        /// </summary>
        /// <returns>Array of the object of CandidatePersonalInfo class</returns>
        public static CandidatePersonalInfo[] GetCandidateDetailsInfo(int candidateID)
        {
            CandidatePersonalInfo[] Candidates = new Master_CandidateBusinessObject().GetCandidateDetailsByCandidate(candidateID);

            return Candidates;
        }
        /// <summary>
        /// Return all Candidates
        /// </summary>
        /// <returns>Array of the object of CandidatePersonalInfo class</returns>
        public static CandidatePersonalInfo[] GetAllApprovedCandidateInfo()
        {
            Master_Candidate[] CandidatesDT = new Master_CandidateBusinessObject().GetAllApproveCandidates();

            CandidatePersonalInfo[] Candidates = new CandidatePersonalInfo[CandidatesDT.Length];

            for (int i = 0; i < Candidates.Length; i++)
            {
                Candidates[i] = new CandidatePersonalInfo(CandidatesDT[i]);
            }

            return Candidates;
        }
        /// <summary>
        /// Return all GriveanceTypes
        /// </summary>
        /// <returns>Array of the object of GriveanceType class</returns>
        public static CandidatePersonalInfo[] GetEmployeeForInterview(int LocID, int DesgID)
        {
            Master_Candidate[] EmpDT = new Master_CandidateBusinessObject().GetEmployeesForInterview(LocID,DesgID);
            CandidatePersonalInfo[] EmployeeData = new CandidatePersonalInfo[EmpDT.Length];

            for (int i = 0; i < EmpDT.Length; i++)
            {
                EmployeeData[i] = new CandidatePersonalInfo(EmpDT[i]);
            }

            return EmployeeData;
        }
        /// <summary>
        /// Return all GriveanceTypes
        /// </summary>
        /// <returns>Array of the object of GriveanceType class</returns>
        public static CandidatePersonalInfo[] GetEmployeeForInterview(int DepID,int DesgID, int BrnachID,int GradeID, int LocationID)
        {
            Master_Candidate[] EmpDT = new Master_CandidateBusinessObject().GetEmployeesForInterview(DesgID, DepID, BrnachID, GradeID, LocationID);
            CandidatePersonalInfo[] EmployeeData = new CandidatePersonalInfo[EmpDT.Length];

            for (int i = 0; i < EmpDT.Length; i++)
            {
                EmployeeData[i] = new CandidatePersonalInfo(EmpDT[i]);
            }

            return EmployeeData;
        }
        /// <summary>
        /// Return all GriveanceTypes
        /// </summary>
        /// <returns>Array of the object of GriveanceType class</returns>
        public static CandidatePersonalInfo[] GetEmployeeForReportingTo(int LocationID)
        {
            Master_Candidate[] EmpDT = new Master_CandidateBusinessObject().GetEmployeesForReportingTo(LocationID);
            CandidatePersonalInfo[] EmployeeData = new CandidatePersonalInfo[EmpDT.Length];

            for (int i = 0; i < EmpDT.Length; i++)
            {
                EmployeeData[i] = new CandidatePersonalInfo(EmpDT[i]);
            }

            return EmployeeData;
        }

        /// <summary>
        /// Return all Candidates
        /// </summary>
        /// <returns>Array of the object of CandidatePersonalInfo class</returns>
        public static CandidatePersonalInfo[] GetAllNonApprovedCandidateInfo()
        {
            Master_Candidate[] CandidatesDT = new Master_CandidateBusinessObject().GetAllNonApproveCandidates();

            CandidatePersonalInfo[] Candidates = new CandidatePersonalInfo[CandidatesDT.Length];

            for (int i = 0; i < Candidates.Length; i++)
            {
                Candidates[i] = new CandidatePersonalInfo(CandidatesDT[i]);
            }

            return Candidates;
        }
        /// <summary>
        /// Return all Candidates
        /// </summary>
        /// <returns>Array of the object of CandidatePersonalInfo class</returns>
        public static CandidatePersonalInfo[] GetAllCandidateInfoForView(string Emp)
        {
           
            CandidatePersonalInfo[] Candidates;
            if (Emp=="MD")
               Candidates = new Master_CandidateBusinessObject().GetApproveCandidatesForHigherApproval("MD");
            else if (Emp == "COO")
               Candidates = new Master_CandidateBusinessObject().GetApproveCandidatesForHigherApproval("COO");
            else
                Candidates = new Master_CandidateBusinessObject().GetApproveCandidates();
            return Candidates;
        }

        public String SaveCAND()
        {
            try
            {
                Master_CandidateBusinessObject BO = new Master_CandidateBusinessObject();
                Master_Candidate DTO = GetDTO();

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
        private Master_Candidate GetDTO()
        {
            Master_Candidate DTO = new Master_Candidate();           
            DTO.ID = _ID;
            DTO.FirstName = _FirstName;
            DTO.LastName = _LastName;
            DTO.FatherName = _FatherName;
            DTO.Sex = _Sex;
            DTO.MaritialStatus = _MaritialStatus;
            DTO.IsPhysicalDisability = _IsPhysicalDisability;
            DTO.Per_Addess = _PAddess;
            DTO.Per_City = _PCity;
            DTO.Per_MobileNumber = _PMobileNumber;
            DTO.Per_PhoneNo = _PPhoneNo;
            // DTO.Per_State = _PState;
            if (_PState == null)
            {
            }
            else
            {
                DTO.Per_StateID = _PState.ID;
            }

            DTO.Per_Street = _PStreet;
            DTO.Per_ZipCode = _PZipCode;
            DTO.PhysicalDisability = _PhysicalDisability;
            DTO.TelephoneNoOff = _TelephoneNoOff;
            DTO.TelephoneNoRes = _TelephoneNoRes;
            DTO.DOB = _DOB;
            DTO.EMailID = _EMailID;
            DTO.Temp_Addess = _TAddess;
            DTO.Temp_City = _TCity;
            DTO.Temp_MobileNumber = _TMobileNumber;
            // DTO.Temp_State = _TState;
            if (_PState == null)
            {
            }
            else
            {
                DTO.Temp_StateID = _TState.ID;
            }

            DTO.Temp_Street = _TStreet;
            DTO.Temp_ZipCode = _TZipCode;
            DTO.IsActive = _IsActive;
            DTO.IsFresher = _IsFresher;
            DTO.IsTechnical = _IsTechnical;
            DTO.Graduate = _Graduate;
            DTO.Degree = _Degree;
            DTO.Title = _Title;         

            return DTO;
        }
        
        #region JGridDataObject Members

        public object GetGridData()
        {
            CandidatePersonalInfoDisplayDetails Candidate = new CandidatePersonalInfoDisplayDetails();

            Candidate.CandidateID = _ID;
            Candidate.CandidateName = _Title + ' ' + _FirstName+ ' ' +_LastName;
            Candidate.Location = _Location;
            Candidate.JobProfile = _JobProfile;
            if (_IsFresher == true)
                Candidate.ExperienceLevel = "Fresher";
            else
                Candidate.ExperienceLevel = "Experienced";
            Candidate.EMail = _EMailID;
            Candidate.Status = _Status;
            Candidate.IsActive = _IsActive;
            return Candidate;
        }

        #endregion
  }

  public class CandidatePersonalInfoDisplayDetails
  {
      public int CandidateID;
      public String CandidateName;
      public String Location;
      public String JobProfile;
      public String ExperienceLevel;
      public String EMail;
      public String Status;
      public bool IsActive;
  }
}
