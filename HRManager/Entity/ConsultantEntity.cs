using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IRCA.Communication;
using IS91.Services.DataBlock;
using System.Collections;
using System.Data;
using HRManager.DTOEXT;

namespace HRManager.Entity
{  
    public class ConsultantEntity : JGridDataObject
    {
        private int _ID;
        private int _DesignationID;
        private String _ConsultantName;
        private String _ContactPerson;
        private String _TelephoneNo;
        private String _EmailID;
        private String _Address;    
        private bool _IsActive;
        private bool _IsNew;
        private int _UpdateBy;
        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;
        private String _LoginName;  
       
        public int ID { get {return _ID; }set { _ID = value;} }
        public int DesignationID { get { return _DesignationID; } set { _DesignationID = value; } }
        public String ConsultantName { get { return _ConsultantName; } set { _ConsultantName = value; } }
        public String ContactPerson { get { return _ContactPerson; } set { _ContactPerson = value; } }
        public String TelephoneNo { get { return _TelephoneNo; } set { _TelephoneNo = value; } }
        public String EmailID { get { return _EmailID; } set { _EmailID = value; } }
        public String Address { get { return _Address; } set { _Address = value; } }
        public bool Status { get { return _IsActive; } set { _IsActive = value; } }

        public bool IsActive {get { return _IsActive; } set{_IsActive = value; } }
        public int UpdatedBy { get { return _UpdateBy; } set { _UpdateBy = value; } }
        public String LoginName { get { return _LoginName; } set { _LoginName = value; } }
        

       
        private void Update(Master_Consultant Consultant)
        {
            if (Consultant != null)
            {
                _ID = Consultant.ID;
                _DesignationID = Consultant.DesignationID;
                _ConsultantName = Consultant.ConsultantName;
                _TelephoneNo = Consultant.TelephoneNo;
                _ContactPerson = Consultant.ContactPerson;
                _EmailID = Consultant.EmailID;
                _Address = Consultant.Address;
                _IsActive = Consultant.IsActive;
                _IsNew = false;
                _CreatedBy = Consultant.CreatedBy;
                _ModifiedBy = Consultant.ModifiedBy;
                _CreatedDate = Consultant.CreatedDate;
                _ModifiedDate = Consultant.ModifiedDate;
                if (Consultant is Master_ConsultantEXT)
                {
                    _LoginName = ((Master_ConsultantEXT)Consultant).LoginName;
                }
               
            }
            else
            {
                _IsNew = true;
            }
        }

       
        public ConsultantEntity(Master_Consultant Consultant)
        {
            Update(Consultant);
        }
      
        public ConsultantEntity(int ID)
        {
            Master_Consultant Consultant = new Master_ConsultantBusinessObject().GetMaster_Consultant(ID);

            if (Consultant == null && ID > 0)
            {
                throw new IRCAException("Invalid Consultant", ID.ToString());
            }

            Update(Consultant);
        }
     
        public ConsultantEntity()
        {
            _ID = 0;
            _IsNew = true;
        }

        private String SaveConsultant()
        {

            Master_Consultant Consultant = new Master_Consultant();
            Consultant.ID = _ID;
            Consultant.DesignationID = _DesignationID;
            Consultant.ConsultantName = _ConsultantName;
            Consultant.TelephoneNo = _TelephoneNo;
            Consultant.ContactPerson = _ContactPerson;
            Consultant.EmailID = _EmailID;
            Consultant.Address = _Address;
            Consultant.IsActive = _IsActive;
            Consultant.ModifiedBy = _ModifiedBy;
            Consultant.ModifiedDate = DateTime.Now;
            Consultant.CreatedBy = _CreatedBy;
            Consultant.CreatedDate = _CreatedDate;

            if (_IsNew)
            {
                Consultant.CreatedBy = _UpdateBy;
                Consultant.CreatedDate = DateTime.Now;
                Consultant.ID = new Master_ConsultantBusinessObject().Create(Consultant);
            }
            else
            {
                Consultant.ModifiedBy = _UpdateBy;
                Consultant.ModifiedDate = DateTime.Now;
                Consultant.ID = _ID;
                new Master_ConsultantBusinessObject().Update(Consultant);
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

            return SaveConsultant();
        }

        private String CheckReference()
        {
          Master_ConsultantBusinessObject ConsultantBO = new Master_ConsultantBusinessObject();

          if (ConsultantBO.IConsultantReferedinCandidate(_ID))
          {
              return "Already Referred";
          }
          
            return String.Empty;
        }

        private String Validate()
        {
            Master_ConsultantBusinessObject ConsultantBO = new Master_ConsultantBusinessObject();

            if (_ConsultantName == String.Empty)
            {
                return HRManagerDefs.ConsultantMessages.EMPTY_CONSULTANT;
            }
            else if (ConsultantBO.IsConsultantExists(_ConsultantName, _ID))
            {
                return HRManagerDefs.ConsultantMessages.CONSULTANT_EXISTS;
            }
            else if (ConsultantBO.IsConsultantEmailIDExists(_EmailID, _ID))
            {
                return HRManagerDefs.ConsultantMessages.CONSULTANT_EMAILID_EXISTS;
            }
            else if (ConsultantBO.IsConsultantTeliPhonenoExists(_TelephoneNo, _ID))
            {
                return HRManagerDefs.ConsultantMessages.CONSULTANT_TEL_EXISTS;
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
    
        public String Activate(int ActivatedBy)
        {
            _UpdateBy = ActivatedBy;
            _IsActive = true;

            return SaveConsultant();
        }
      
        public String DeActivate(int DeActivatedBy)

             {
            String Status = CheckReference();
            _ModifiedBy = DeActivatedBy;
            if (Status != String.Empty)
            {
                return Status;
            }
            else
            {
                _IsActive = false;

                return SaveConsultant();
            }

        }
        
        public static ConsultantEntity[] GetAllConsultants()
        {
            Master_Consultant[] ConsultantsDT = (Master_Consultant[])new Master_ConsultantBusinessObject().GetAllConsultants();

            ConsultantEntity[] Consultants = new ConsultantEntity[ConsultantsDT.Length];

            for (int i = 0; i < Consultants.Length; i++)
            {
                Consultants[i] = new ConsultantEntity(ConsultantsDT[i]);
            }

            return Consultants;
        }

        public static ConsultantEntity[] GetAllConsultantsDetails()
        {
            Master_Consultant[] CountryDT = new Master_ConsultantBusinessObject().GetAllConsultantDetails();
            ConsultantEntity[] Country = new ConsultantEntity[CountryDT.Length];

            for (int i = 0; i < Country.Length; i++)
            {
                Country[i] = new ConsultantEntity();

                Country[i].Update(CountryDT[i]);
            }

            return Country;
        }

      

        internal static ConsultantEntity[] GetAllInActiveConsultants()
        {
            Master_Consultant[] ConsultantsDT = (Master_Consultant[])new Master_ConsultantBusinessObject().GetAllInActiveConsultant();

            ConsultantEntity[] Consultants = new ConsultantEntity[ConsultantsDT.Length];

            for (int i = 0; i < Consultants.Length; i++)
            {
                Consultants[i] = new ConsultantEntity(ConsultantsDT[i]);
            }

            return Consultants;
        }
        #region JGridDataObject Members

        public object GetGridData()
        {
            ConsultantDisplayDetails Consultant = new ConsultantDisplayDetails();
            Consultant.ID = _ID;
            Consultant.DesignationID = _DesignationID;
            Consultant.Consultant = _ConsultantName;
            Consultant.ContactPerson = _ContactPerson;
            Consultant.TelephoneNo = _TelephoneNo;
            Consultant.EmailID = _EmailID;
            Consultant.Address = _Address;
            Consultant.IsActive = _IsActive;
            Consultant.Status = _IsActive;
            Consultant.LoginName = _LoginName;

            return Consultant;
        }

        #endregion

        
    }
    public class ConsultantDisplayDetails
    {
        public int ID;
        public int DesignationID;
        public String Consultant;
        public String ContactPerson;
        public String TelephoneNo;
        public String EmailID;
        public String Address;
        public bool IsActive;
        public bool Status;
        public String LoginName;
    }
}
