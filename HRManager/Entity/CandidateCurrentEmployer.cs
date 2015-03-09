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
  public  class CandidateCurrentEmployer:JGridDataObject
    {
        private int _ID;
        private int _candidateID;
        private String _EmployerName;
        private String _Address;
        private String _AnnualSalesTurnOver;
        private String _BusinessNature;
        private int _NoOfEmployess;
        private String _JoinDesignation;
        private DateTime _JoinDate;
        private String _CurrentDesignation;
        private DateTime _DesignationEffectFrom;
        private String _ReportingOfficer;
        private String _ReportingOfficerDesignation;
        private String _ReportingOfficerMobileNo;
        private String _ReportingOfficerTeleNo;
        private String _Responsible;
        private String _Remarks;

        private double _Joining_Basic;
        private double _Joining_DA;
        private double _Joining_HRA;
        private double _Joining_Conveyance;
        private double _Joining_OtherAllowance;
        private double _Joining_GrossSalary;
        private double _Joining_LTA;
        private double _Joining_Medical;
        private double _Joining_AnnualBonus;
        private double _Joining_ClubMembership;
        private double _Joining_Others;
        private double _Joining_MonthlyCTC;
        private double _Current_Basic;
        private double _Current_DA;
        private double _Current_HRA;
        private double _Current_Conveyance;
        private double _Current_OtherAllowance;
        private double _Current_GrossSalary;
        private double _Current_LTA;
        private double _Current_Medical;
        private double _Current_AnnualBonus;
        private double _Current_ClubMembership;
        private double _Current_Others;
        private double _Current_MonthlyCTC;
        private Boolean _IsPF;
        private Boolean _IsGratuity;
        private Boolean _IsSuperAnnuation;
        private String _Others;
        private String _WeeklyOff;
        private String _JobResponsibilities;
        private bool _IsNew;
        private String _ReportingOfficerEmailID;

        
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
        public String EmployerName
        {
            get
            {
                return _EmployerName;
            }
            set
            {
                _EmployerName = value;
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
        public String AnnualSalesTurnOver
        {
            get
            {
                return _AnnualSalesTurnOver;
            }
            set
            {
                _AnnualSalesTurnOver = value;
            }
        }
        public String BusinessNature
        {
            get
            {
                return _BusinessNature;
            }
            set
            {
                _BusinessNature = value;
            }
        }
        public int NoOfEmployess
        {
            get
            {
                return _NoOfEmployess;
            }
            set
            {
                _NoOfEmployess = value;
            }
        }
        public String JoinDesignation
        {
            get
            {
                return _JoinDesignation;
            }
            set
            {
                _JoinDesignation = value;
            }
        }
        public DateTime JoinDate
        {
            get
            {
                return _JoinDate;
            }
            set
            {
                _JoinDate = value;
            }
        }
        public String CurrentDesignation
        {
            get
            {
                return _CurrentDesignation;
            }
            set
            {
                _CurrentDesignation = value;
            }
        }
        public DateTime DesignationEffectFrom
        {
            get
            {
                return _DesignationEffectFrom;
            }
            set
            {
                _DesignationEffectFrom = value;
            }
        }
        public String ReportingOfficer
        {
            get
            {
                return _ReportingOfficer;
            }
            set
            {
                _ReportingOfficer = value;
            }
        }
        public String ReportingOfficerDesignation
        {
            get
            {
                return _ReportingOfficerDesignation;
            }
            set
            {
                _ReportingOfficerDesignation = value;
            }
        }
        public String ReportingOfficerMobileNo
        {
            get
            {
                return _ReportingOfficerMobileNo;
            }
            set
            {
                _ReportingOfficerMobileNo = value;
            }
        }
        public String ReportingOfficerTeleNo
        {
            get
            {
                return _ReportingOfficerTeleNo;
            }
            set
            {
                _ReportingOfficerTeleNo = value;
            }

        }
        public String ReportingOfficerEmailID
        {
            get
            {
                return _ReportingOfficerEmailID;
            }
            set
            {
                _ReportingOfficerEmailID = value;
            }
        }
        public String Responsible
        {
            get
            {
                return _Responsible;
            }
            set
            {
                _Responsible = value;
            }
        }
        public String Remarks
        {
            get
            {
                return _Remarks;
            }
            set
            {
                _Remarks = value;
            }
        }
        public double Joining_Basic
        {    
            get
            {
                return _Joining_Basic;
            }
            set
            {
                _Joining_Basic = value;
            }
        }
        public double Joining_DA
        {
            get
            {
                return _Joining_DA;
            }
            set
            {
                _Joining_DA = value;
            }
        }
        public double Joining_HRA
        {
            get
            {
                return _Joining_HRA;
            }
            set
            {
                _Joining_HRA = value;
            }
        }
        public double Joining_Conveyance
        {
            get
            {
                return _Joining_Conveyance;
            }
            set
            {
                _Joining_Conveyance = value;
            }
        }
        public double Joining_OtherAllowance
        {
            get
            {
                return _Joining_OtherAllowance;
            }
            set
            {
                _Joining_OtherAllowance = value;
            }
        }
        public double Joining_GrossSalary
        {
            get
            {
                return _Joining_GrossSalary;
            }
            set
            {
                _Joining_GrossSalary = value;
            }
        }
        public double Joining_LTA
        {
            get
            {
                return _Joining_LTA;
            }
            set
            {
                _Joining_LTA = value;
            }
        }
        public double Joining_Medical
        {
            get
            {
                return _Joining_Medical;
            }
            set
            {
                _Joining_Medical = value;
            }
        }
        public double Joining_AnnualBonus
        {
            get
            {
                return _Joining_AnnualBonus;
            }
            set
            {
                _Joining_AnnualBonus = value;
            }
        }
        public double Joining_ClubMembership
        {
            get
            {
                return _Joining_ClubMembership;
            }
            set
            {
                _Joining_ClubMembership = value;
            }
        }
        public double Joining_Others
        {
            get
            {
                return _Joining_Others;
            }
            set
            {
                _Joining_Others = value;
            }
        }
        public double Joining_MonthlyCTC
        {
            get
            {
                return _Joining_MonthlyCTC;
            }
            set
            {
                _Joining_MonthlyCTC = value;
            }
        }
        public double Current_Basic
        {
            get
            {
                return _Current_Basic;
            }
            set
            {
                _Current_Basic = value;
            }
        }
        public double Current_DA
        {
            get
            {
                return _Current_DA;
            }
            set
            {
                _Current_DA = value;
            }
        }
        public double Current_HRA
        {
            get
            {
                return _Current_HRA;
            }
            set
            {
                _Current_HRA = value;
            }
        }
        public double Current_Conveyance
        {
            get
            {
                return _Current_Conveyance;
            }
            set
            {
                _Current_Conveyance = value;
            }
        }
        public double Current_OtherAllowance
        {
            get
            {
                return _Current_OtherAllowance;
            }
            set
            {
                _Current_OtherAllowance = value;
            }
        }
        public double Current_GrossSalary
        {
            get
            {
                return _Current_GrossSalary;
            }
            set
            {
                _Current_GrossSalary = value;
            }
        }
        public double Current_LTA
        {
            get
            {
                return _Current_LTA;
            }
            set
            {
                _Current_LTA = value;
            }
        }
        public double Current_Medical
        {
            get
            {
                return _Current_Medical;
            }
            set
            {
                _Current_Medical = value;
            }
        }
        public double Current_AnnualBonus
        {
            get
            {
                return _Current_AnnualBonus;
            }
            set
            {
                _Current_AnnualBonus = value;
            }
        }
        public double Current_ClubMembership
        {
            get
            {
                return _Current_ClubMembership;
            }
            set
            {
                _Current_ClubMembership = value;
            }
        }
        public double Current_Others
        {
            get
            {
                return _Current_Others;
            }
            set
            {
                _Current_Others = value;
            }
        }
        public double Current_MonthlyCTC
        {
            get
            {
                return _Current_MonthlyCTC;
            }
            set
            {
                _Current_MonthlyCTC = value;
            }
        }
        public bool IsPF
        {
            get
            {
                return _IsPF;
            }
            set
            {
                _IsPF = value;
            }
        }
        public bool IsGratuity
        {
            get
            {
                return _IsGratuity;
            }
            set
            {
                _IsGratuity = value;
            }
        }
        public bool IsSuperAnnuation
        {
            get
            {
                return _IsSuperAnnuation;
            }
            set
            {
                _IsSuperAnnuation = value;
            }
        }
        public String Others
        {
            get
            {
                return _Others;
            }
            set
            {
                _Others = value;
            }
        }
        public String WeeklyOff
        {
            get
            {
                return _WeeklyOff;
            }
            set
            {
                _WeeklyOff = value;
            }
        }

        public String JobResponsibilities
        {
            get
            {
                return _JobResponsibilities;
            }
            set
            {
                _JobResponsibilities = value;
            }
        }
        // <summary>
        /// Update the Candidate PrevEmp field using Candidate_Prev_Employer.
        /// </summary>
        /// <param name="Candidate">Object of Candidate_Prev_Employer class</param>

        private void Update(Candidate_Current_Employer CurrEmp)
        {
            if (CurrEmp != null)
            {
                _ID = CurrEmp.ID;
                _candidateID = CurrEmp.CandidateID;
                _EmployerName = CurrEmp.EmployerName;
                _Address = CurrEmp.Address;
                _BusinessNature = CurrEmp.BusinessNature;
                _Current_AnnualBonus = CurrEmp.Current_AnnualBonus;
               _Current_Basic= CurrEmp.Current_Basic;
                _Current_ClubMembership = CurrEmp.Current_ClubMembership;
                _Current_Conveyance = CurrEmp.Current_Conveyance;
                _Current_DA = CurrEmp.Current_DA;
                _Current_GrossSalary = CurrEmp.Current_GrossSalary;
                _Current_HRA = CurrEmp.Current_HRA;
                _Current_LTA = CurrEmp.Current_LTA;
                _Current_Medical = CurrEmp.Current_Medical;
                _Current_MonthlyCTC = CurrEmp.Current_MonthlyCTC;
                _Current_OtherAllowance = CurrEmp.Current_OtherAllowance;
                _Current_Others = CurrEmp.Current_Others;
                _CurrentDesignation = CurrEmp.CurrentDesignation;
                _DesignationEffectFrom = CurrEmp.DesignationEffectFrom;
                _IsGratuity = CurrEmp.IsGratuity;
                _IsPF = CurrEmp.IsPF;
                _IsSuperAnnuation = CurrEmp.IsSuperAnnuation;
                _JoinDate = CurrEmp.JoinDate;
                _JoinDesignation = CurrEmp.JoinDesignation;
                _Joining_AnnualBonus = CurrEmp.Joining_AnnualBonus;
                _Joining_Basic = CurrEmp.Joining_Basic;
                _Joining_ClubMembership = CurrEmp.Joining_ClubMembership;
                _Joining_Conveyance = CurrEmp.Joining_Conveyance;
                _Joining_DA = CurrEmp.Joining_DA;
                _Joining_GrossSalary = CurrEmp.Joining_GrossSalary;
                _Joining_HRA = CurrEmp.Joining_HRA;
                _Joining_LTA = CurrEmp.Joining_LTA;
                _Joining_Medical = CurrEmp.Joining_Medical;
                _Joining_MonthlyCTC = CurrEmp.Joining_MonthlyCTC;
                _Joining_OtherAllowance = CurrEmp.Joining_OtherAllowance;
                _Joining_Others = CurrEmp.Joining_Others;
                _NoOfEmployess = CurrEmp.NoOfEmployess;
                _Others = CurrEmp.Others;
                _Remarks = CurrEmp.Remarks;
                _ReportingOfficer = CurrEmp.ReportingOfficer;
                _ReportingOfficerDesignation = CurrEmp.ReportingOfficerDesignation;
                _ReportingOfficerMobileNo = CurrEmp.ReportingOfficerMobileNo;
                _ReportingOfficerTeleNo = CurrEmp.ReportingOfficerTeleNo;
                _Responsible = CurrEmp.Responsible;
                _WeeklyOff = CurrEmp.WeeklyOff;
                _AnnualSalesTurnOver = CurrEmp.AnnualSalesTurnOver;
                _JobResponsibilities = CurrEmp.JobResponsibilities;
                _ReportingOfficerEmailID = CurrEmp.ReportingOfficerEmailID;
                
            }
            else
            {
                _IsNew = true;
            }
        }
      /// <summary>
        /// Consturctor of CandidatePrevEmp  class.
        /// Update Candidate fields using Candidate_Education.
        /// </summary>
        /// <param name="Candidate">Object of Candidate_Prev_Employer class</param>
        public CandidateCurrentEmployer( Candidate_Current_Employer CurrEmp)
        {
            Update(CurrEmp);
        }
        /// <summary>
        /// Consturctor of CandidateEducation class.
        /// Update Candidate for given Candidate Education field.
        /// </summary>
        /// <param name="CandidateEducation">field contains Candidate Education</param>
        public CandidateCurrentEmployer(string EmployerName)
        {
            Update(new Master_CandidateBusinessObject().GetCurrentEmpByCandidate(EmployerName));
        }
       /// <summary>
        /// Consturctor of Master_Candidate class.
       /// Update Candidate fields for given ID field.
        /// </summary>
        /// <param name="ID">field contains Candidate ID</param>
        public CandidateCurrentEmployer(int ID)
        {
            Candidate_Current_Employer CurrEmp = new Candidate_Current_EmployerBusinessObject().GetCandidate_Current_Employer(ID);

            if (CurrEmp == null && ID > 0)
            {
                throw new IRCAException("Invalid Candidate", ID.ToString());
            }

            Update(CurrEmp);
        }
      /// <summary>
        /// Consturctor of CandidatePersonalInfo class.
        /// Set variables for new Candidate.  
        /// </summary>
        public CandidateCurrentEmployer()
        {
            _ID = 0;
            _IsNew = true;
        }

        /// <summary>
        /// Save Candidate.If new Candidate it add and in case of edit it update the Candidate.
        /// </summary>
        /// <returns>empty string</returns>
        public String SaveCandidateCurrEmp(Session DBSession)
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
                Candidate_Current_EmployerBusinessObject CandCurrBO;
                CandCurrBO = new Candidate_Current_EmployerBusinessObject(DBSession);

                Candidate_Current_Employer CurrEmp = new Candidate_Current_Employer();
                CurrEmp.ID = _ID;
                CurrEmp.CandidateID = _candidateID;
                CurrEmp.EmployerName = _EmployerName;
                CurrEmp.Address = _Address;
                CurrEmp.AnnualSalesTurnOver = _AnnualSalesTurnOver;
                CurrEmp.BusinessNature = _BusinessNature;
                CurrEmp.Current_AnnualBonus = _Current_AnnualBonus;
                CurrEmp.Current_Basic = _Current_Basic;
                CurrEmp.Current_ClubMembership = _Current_ClubMembership;
                CurrEmp.Current_Conveyance = _Current_Conveyance;
                CurrEmp.Current_DA = _Current_DA;
                CurrEmp.Current_GrossSalary = _Current_GrossSalary;
                CurrEmp.Current_HRA = _Current_HRA;
                CurrEmp.Current_LTA = _Current_LTA;
                CurrEmp.Current_Medical = _Current_Medical;
                CurrEmp.Current_MonthlyCTC = _Current_MonthlyCTC;
                CurrEmp.Current_OtherAllowance = _Current_OtherAllowance;
                CurrEmp.Current_Others = _Current_Others;
                CurrEmp.CurrentDesignation = _CurrentDesignation;
                if (DesignationEffectFrom.Year.Equals(0001))
                    CurrEmp.DesignationEffectFrom = Convert.ToDateTime("1900-01-01");
                else
                CurrEmp.DesignationEffectFrom = _DesignationEffectFrom;
                CurrEmp.IsGratuity = _IsGratuity;
                CurrEmp.IsPF = _IsPF;
                CurrEmp.IsSuperAnnuation = _IsSuperAnnuation;
                if (JoinDate.Year.Equals(0001))
                    CurrEmp.JoinDate = Convert.ToDateTime("1900-01-01");
                else
                CurrEmp.JoinDate = _JoinDate;
                CurrEmp.JoinDesignation = _JoinDesignation;
                CurrEmp.Joining_AnnualBonus = _Joining_AnnualBonus;
                CurrEmp.Joining_Basic = _Joining_Basic;
                CurrEmp.Joining_ClubMembership = _Joining_ClubMembership;
                CurrEmp.Joining_Conveyance = _Joining_Conveyance;
                CurrEmp.Joining_DA = _Joining_DA;
                CurrEmp.Joining_GrossSalary = _Joining_GrossSalary;
                CurrEmp.Joining_HRA = _Joining_HRA;
                CurrEmp.Joining_LTA = _Joining_LTA;
                CurrEmp.Joining_Medical = _Joining_Medical;
                CurrEmp.Joining_MonthlyCTC = _Joining_MonthlyCTC;
                CurrEmp.Joining_OtherAllowance = _Joining_OtherAllowance;
                CurrEmp.Joining_Others = _Joining_Others;
                CurrEmp.NoOfEmployess = _NoOfEmployess;
                CurrEmp.Others = _Others;
                CurrEmp.Remarks = _Remarks;
                CurrEmp.ReportingOfficer = _ReportingOfficer;
                CurrEmp.ReportingOfficerDesignation = _ReportingOfficerDesignation;
                CurrEmp.ReportingOfficerMobileNo = _ReportingOfficerMobileNo;
                CurrEmp.ReportingOfficerTeleNo = _ReportingOfficerTeleNo;
                CurrEmp.Responsible = _Responsible;
                CurrEmp.WeeklyOff = _WeeklyOff;
                CurrEmp.JobResponsibilities = _JobResponsibilities;
                CurrEmp.ReportingOfficerEmailID = _ReportingOfficerEmailID;

                if (_IsNew)
                {

                    CurrEmp.ID = CandCurrBO.Create(CurrEmp);
                }
                else
                {
                    CurrEmp.ID = _ID;
                    CandCurrBO.Update(CurrEmp);
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
        ///Validate Candidate for empty and already exist status and then save Candidate.
        /// </summary>
        /// <returns>String return from the SaveCandidate method</returns> 
        public String Save()
        {
             //  return SaveCandidateCurrEmp();
            return string.Empty;
        }
        /// <summary>
        /// Return all Candidates
        /// </summary>
        /// <returns>Array of the object of CandidatePersonalInfo class</returns>
        public static CandidateCurrentEmployer[] GetAllCandidatCurrEmpl()
        {
            Candidate_Current_Employer[] CurrEmplDT = new Candidate_Current_EmployerBusinessObject().GetCandidate_Current_Employer();

            CandidateCurrentEmployer[] CurrEmpl = new CandidateCurrentEmployer[CurrEmplDT.Length];

            for (int i = 0; i < CurrEmpl.Length; i++)
            {
                CurrEmpl[i] = new CandidateCurrentEmployer(CurrEmplDT[i]);
            }

            return CurrEmpl;
        }
        /// <summary>
        /// Return all Candidates
        /// </summary>
        /// <returns>Array of the object of CandidatePersonalInfo class</returns>
        public static CandidateCurrentEmployer[] GetAllCandidatCurrEmpl(int candidateID)
        {
            Candidate_Current_Employer[] CurrEmplDT = new Candidate_Current_EmployerBusinessObject().GetCurrentEmplByCandidate(candidateID);

            CandidateCurrentEmployer[] CurrEmpl = new CandidateCurrentEmployer[CurrEmplDT.Length];

            for (int i = 0; i < CurrEmpl.Length; i++)
            {
                CurrEmpl[i] = new CandidateCurrentEmployer(CurrEmplDT[i]);
            }

            return CurrEmpl;
        }
        #region JGridDataObject Members

        public object GetGridData()
        {
            CandidateCurrEmpDisplayDetails CurrEmp = new CandidateCurrEmpDisplayDetails();

            CurrEmp.CurrEmpID = _ID;
            CurrEmp.candidateID = _candidateID;
            CurrEmp.EmployerName = _EmployerName;
            CurrEmp.Address = _Address;
            CurrEmp.AnnualSalesTurnOver = _AnnualSalesTurnOver;
            CurrEmp.BusinessNature = _BusinessNature;
            CurrEmp.Current_AnnualBonus = _Current_AnnualBonus;
            CurrEmp.Current_Basic = _Current_Basic;
            CurrEmp.Current_ClubMembership = _Current_ClubMembership;
            CurrEmp.Current_Conveyance = _Current_Conveyance;
            CurrEmp.Current_DA = _Current_DA;
            CurrEmp.Current_GrossSalary = _Current_GrossSalary;
            CurrEmp.Current_HRA = _Current_HRA;
            CurrEmp.Current_LTA = _Current_LTA;
            CurrEmp.Current_Medical = _Current_Medical;
            CurrEmp.Current_MonthlyCTC = _Current_MonthlyCTC;
            CurrEmp.Current_OtherAllowance = _Current_OtherAllowance;
            CurrEmp.Current_Others = _Current_Others;
            CurrEmp.CurrentDesignation = _CurrentDesignation;
            CurrEmp.DesignationEffectFrom = _DesignationEffectFrom;
            CurrEmp.IsGratuity = _IsGratuity;
            CurrEmp.IsPF = _IsPF;
            CurrEmp.IsSuperAnnuation = _IsSuperAnnuation;
            CurrEmp.JoinDate = _JoinDate;
            CurrEmp.JoinDesignation = _JoinDesignation;
            CurrEmp.Joining_AnnualBonus = _Joining_AnnualBonus;
            CurrEmp.Joining_Basic = _Joining_Basic;
            CurrEmp.Joining_ClubMembership = _Joining_ClubMembership;
            CurrEmp.Joining_Conveyance = _Joining_Conveyance;
            CurrEmp.Joining_DA = _Joining_DA;
            CurrEmp.Joining_GrossSalary = _Joining_GrossSalary;
            CurrEmp.Joining_HRA = _Joining_HRA;
            CurrEmp.Joining_LTA = _Joining_LTA;
            CurrEmp.Joining_Medical = _Joining_Medical;
            CurrEmp.Joining_MonthlyCTC = _Joining_MonthlyCTC;
            CurrEmp.Joining_OtherAllowance = _Joining_OtherAllowance;
            CurrEmp.Joining_Others = _Joining_Others;
            CurrEmp.NoOfEmployess = _NoOfEmployess;
            CurrEmp.Others = _Others;
            CurrEmp.Remarks = _Remarks;
            CurrEmp.ReportingOfficer = _ReportingOfficer;
            CurrEmp.ReportingOfficerDesignation = _ReportingOfficerDesignation;
            CurrEmp.ReportingOfficerMobileNo = _ReportingOfficerMobileNo;
            CurrEmp.ReportingOfficerTeleNo = _ReportingOfficerTeleNo;
            CurrEmp.Responsible = _Responsible;
            CurrEmp.WeeklyOff = _WeeklyOff;
            CurrEmp.JobResponsibilities = _JobResponsibilities;

            return CurrEmp;
        }

        #endregion
    }
  public class CandidateCurrEmpDisplayDetails
  {
      public int CurrEmpID;
      public int candidateID;
      public String EmployerName;
      public String Address;
      public String AnnualSalesTurnOver;
      public String BusinessNature;
      public int NoOfEmployess;
      public String JoinDesignation;
      public DateTime JoinDate;
      public String CurrentDesignation;
      public DateTime DesignationEffectFrom;
      public String ReportingOfficer;
      public String ReportingOfficerDesignation;
      public String ReportingOfficerMobileNo;
      public String ReportingOfficerTeleNo;
      public String Responsible;
      public String Remarks;
      public double Joining_Basic;
      public double Joining_DA;
      public double Joining_HRA;
      public double Joining_Conveyance;
      public double Joining_OtherAllowance;
      public double Joining_GrossSalary;
      public double Joining_LTA;
      public double Joining_Medical;
      public double Joining_AnnualBonus;
      public double Joining_ClubMembership;
      public double Joining_Others;
      public double Joining_MonthlyCTC;
      public double Current_Basic;
      public double Current_DA;
      public double Current_HRA;
      public double Current_Conveyance;
      public double Current_OtherAllowance;
      public double Current_GrossSalary;
      public double Current_LTA;
      public double Current_Medical;
      public double Current_AnnualBonus;
      public double Current_ClubMembership;
      public double Current_Others;
      public double Current_MonthlyCTC;
      public Boolean IsPF;
      public Boolean IsGratuity;
      public Boolean IsSuperAnnuation;
      public String Others;
      public String WeeklyOff;
      public String JobResponsibilities;

  }
}
