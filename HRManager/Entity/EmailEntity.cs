using System;
using System.Collections.Generic;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;



namespace HRManager.Entity
{
    /// <summary>
    /// Represents Email fields and methods.
    ///// </summary>
    public class EmailEntity    //: JGridDataObject
    {
        private int _ID;
        private string _ToAddress;
        private string _FromAddress;
        private string _CcList;
        private string _BccList;
        private string _EmailSubject;
        private string _EmailBody;
        private string _Attachment;
        private string _SendStatus;
        private int _RetryCount;
        private DateTime _FirstSendAttempt;
        private DateTime _LastSendAttempt;
        private string _ErrorMsgOnSendFail;
        private bool _IsNew;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }        

        public string ToAddress
        {
            get { return _ToAddress; }
            set { _ToAddress = value; }
        }        

        public string FromAddress
        {
            get { return _FromAddress; }
            set { _FromAddress = value; }
        }        

        public string CcList
        {
            get { return _CcList; }
            set { _CcList = value; }
        }        

        public string BccList
        {
            get { return _BccList; }
            set { _BccList = value; }
        }

        public string EmailSubject
        {
            get { return _EmailSubject; }
            set { _EmailSubject = value; }
        }        

        public string EmailBody
        {
            get { return _EmailBody; }
            set { _EmailBody = value; }
        }
        
        public string Attachment
        {
            get { return _Attachment; }
            set { _Attachment = value; }
        }        

        public string SendStatus
        {
            get { return _SendStatus; }
            set { _SendStatus = value; }
        }
        
        public int RetryCount
        {
            get { return _RetryCount; }
            set { _RetryCount = value; }
        }
        
        public DateTime FirstSendAttempt
        {
            get { return _FirstSendAttempt; }
            set { _FirstSendAttempt = value; }
        }        

        public DateTime LastSendAttempt
        {
            get { return _LastSendAttempt; }
            set { _LastSendAttempt = value; }
        }        

        public string ErrorMsgOnSendFail
        {
            get { return _ErrorMsgOnSendFail; }
            set { _ErrorMsgOnSendFail = value; }
        }

        public EmailEntity()
        {
            _IsNew = true;
        }

        public EmailEntity(Email inEmail)
        {
            Update(inEmail);

        }

        public EmailEntity(int ID)
        {
            Email emailDT = new EmailBusinessObject().GetEmail(ID);

            if (emailDT == null && ID > 0)
            {
                throw new IRCAException("Invalid Email ID", ID.ToString());
            }

            Update(emailDT);
        }
         
        private void Update(Email inEmail)
        {
            if (inEmail != null)
            {
                _ID = inEmail.ID;
                _ToAddress = inEmail.ToAddress;
                _FromAddress = inEmail.FromAddress;
                _CcList = inEmail.CcList;
                _BccList = inEmail.BccList;
                _EmailSubject = inEmail.EmailSubject;
                _EmailBody = inEmail.EmailBody;
                _Attachment = inEmail.Attachment;
                _SendStatus = inEmail.SendStatus;
                _RetryCount = inEmail.RetryCount;
                _FirstSendAttempt = inEmail.FirstSendAttempt;
                _LastSendAttempt = inEmail.LastSendAttempt;
                _ErrorMsgOnSendFail = inEmail.ErrorMsgOnSendFail;
                _IsNew = false;
            }
            else
            {
                _IsNew = true;
            }
        }


        /// <summary>
        /// Save Email
        /// </summary>
        /// <returns>empty string</returns>
        private String SaveEmail()
        {   
            Email email= new Email();
            int strLen = 0;
            email.ID=_ID;
            email.ToAddress=_ToAddress;
            email.FromAddress=_FromAddress;
            email.CcList=_CcList;
            email.BccList=_BccList;
            email.EmailSubject=_EmailSubject;
            
            email.EmailBody = _EmailBody;
            //strLen = email.EmailBody.Length;
            //if(strLen > 2000)
            //    email.EmailBody = email.EmailBody.Substring(0, 1999);       //sql db has varchar 2000 for col body. do this so that email saving doesnt fail(truncated data is known on review & can be fixed)
            
            email.Attachment=_Attachment;
            email.SendStatus=_SendStatus;
            email.RetryCount=_RetryCount;
            email.FirstSendAttempt=_FirstSendAttempt;
            email.LastSendAttempt=_LastSendAttempt;

            email.ErrorMsgOnSendFail = _ErrorMsgOnSendFail;
            strLen = email.ErrorMsgOnSendFail.Length;
            if (strLen > 300)
                email.ErrorMsgOnSendFail = _ErrorMsgOnSendFail.Substring(0, 299); //sql db has varchar 300 for col ErrorMsgOnSendFail. do this so that save doesn't fail for long error msgs

            if (_IsNew)
            {
                email.FirstSendAttempt = Convert.ToDateTime("1900-01-01");
                email.LastSendAttempt = Convert.ToDateTime("1900-01-01");
                email.ID = new EmailBusinessObject().Create(email);
                _IsNew = false;
            }
            else
            {                
                new EmailBusinessObject().Update(email);
            }

            return String.Empty;
        }

        // <summary>
        ///Validate Email for empty and already exist status and then save email.
        /// </summary>
        /// <returns>String return from the Saveemail method</returns> 
        public String Save()
        {
            String Status = Validate();

            if (Status != String.Empty)
            {
                return Status;
            }

            return SaveEmail();
        }


        /// <summary>
        /// Validate toaddress for empty and already exist status.
        /// </summary>
        /// <returns>empty string</returns>
        private String Validate()
        {
            if (_ToAddress==string.Empty || _ToAddress == null)
            {
              return  HRManagerDefs.EmailMessages.TOADDRESS_EMPTY;

            }
            return String.Empty;
        }

        public static EmailEntity[] GetAllUnsentEmails()
        {
            Email[] emailDT=  new EmailBusinessObject().GetAllUnsentEmails();            
           
            EmailEntity[] emails=new EmailEntity[emailDT.Length];
            
            for (int i = 0; i < emails.Length; i++)
            {
                emails[i] = new EmailEntity(emailDT[i]);
            }

            return emails;

        }

        //public EmailEntity GetEmailByID(int ID)
        //{
        //    Email[] emailDT = new EmailBusinessObject().GetEmailByID
        //}

        //#region JGridDataObject Members

        //public object GetGridData()
        //{
        //    EmailDisplayDetails Email = new EmailDisplayDetails();
        //    Email.ToAddress = _ToAddress;
        //    Email.FromAddress = _FromAddress;
        //    Email.CcList = _CcList;
        //    Email.BccList = _BccList;
        //    Email.EmailSubject = _EmailSubject;
        //    Email.EmailBody = _EmailBody;
        //    Email.Attachment = _Attachment;
        //    Email.SendStatus = _SendStatus;
        //    Email.RetryCount = _RetryCount;
        //    Email.FirstSendAttempt = _FirstSendAttempt;
        //    Email.LastSendAttempt = _LastSendAttempt;
        //    Email.ErrorMsgOnSendFail = _ErrorMsgOnSendFail;
            
        //    return Email;
        //}

        //#endregion
    }

    //public class EmailDisplayDetails
    //{
    //    public int ID;
    //    public string ToAddress;
    //    public string FromAddress;
    //    public string CcList;
    //    public string BccList;
    //    public string EmailSubject;
    //    public string EmailBody;
    //    public string Attachment;
    //    public string SendStatus;
    //    public int RetryCount;
    //    public DateTime FirstSendAttempt;
    //    public DateTime LastSendAttempt;
    //    public string ErrorMsgOnSendFail;
    //}
}        

