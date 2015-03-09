using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using IS91.Services;
using System.IO;
//using IRCAKernel.DTO;
//using IRCAKernel.BusinessObjects;
using System.Net.Mime;
using IRCAKernel.BusinessObjects;
using IRCAKernel.DTO;

namespace IRCAKernel
{
    public class EmailStatus
    {
        public static readonly String SENT = "SNT";
        public static readonly String PENDING = "PEN";
        public static readonly int MAX_RETRY_ATTEMPT = 3;
    }

    public class MailContent
    {
        public int ID;
        public String Subject;
        public String Body;
        public DateTime CreatedTime;
        public String Status;
        public int SendAttempts;
        public DateTime LastSendAttempt;
        public String SendError;

        public bool IsEmbedImage;
        public String EmbededImageSrc;
        public String ImageID;

        public String FromAddress;
        public List<String> _ToAddress = new List<string>();
        public List<String> _CCAddress = new List<string>();
        public List<String> _BCCAddress = new List<string>();
        
        private List<MailAttachment> _Attachments = null;

        private void Update(Email DTO)
        {
            ID = DTO.ID;
            Subject = DTO.EmailSubject;
            Body = DTO.EmailBody;
            CreatedTime = DTO.FirstSendAttempt;
            Status = DTO.SendStatus;
            SendAttempts = DTO.RetryCount;
            LastSendAttempt = DTO.LastSendAttempt;
            SendError = DTO.ErrorMsgOnSendFail;
        }      

        private Email GetDTO()
        {
            Email DTO = new Email();

            DTO.ID = ID;
            DTO.EmailSubject = Subject;
            DTO.EmailBody = Body;
            if (CreatedTime.Year < 1900)
                DTO.FirstSendAttempt = new DateTime(1900, 1, 1);// Convert.ToDateTime("1900-01-01");
            DTO.SendStatus = Status;
            DTO.RetryCount = SendAttempts;
            if (LastSendAttempt.Year < 1900)
                DTO.LastSendAttempt = new DateTime(1900, 1, 1);// Convert.ToDateTime("1900-01-01");
            DTO.ErrorMsgOnSendFail = SendError;
            DTO.ToAddress = String.Join(",", _ToAddress.ToArray());
            DTO.BccList = String.Join(",", _BCCAddress.ToArray())
                          + "," + String.Join(",", _CCAddress.ToArray());

            DTO.FromAddress = FromAddress;

            return DTO;
        }

        public MailAttachment[] Attachments
        {
            get
            {
                return _Attachments.ToArray();
            }
            set
            {
                _Attachments.Clear();
                _Attachments.AddRange(value);
            }
        }

        public MailContent()
        {
            _ToAddress = new List<string>();
            _CCAddress = new List<string>();
            _BCCAddress = new List<string>();
            _Attachments = new List<MailAttachment>();
        }

        public void AddToAddress(String ToAddress)
        {
            _ToAddress.Add(ToAddress);
        }

        public void AddCCAddress(String CCAddress)
        {
            _CCAddress.Add(CCAddress);
        }

        public void AddBCCAddress(String BCCAddress)
        {
            _BCCAddress.Add(BCCAddress);
        }
        
        public void AddAttachment(byte[] Bytes, String Name,String Type)
        {
            _Attachments
                .Add
                (
                    new MailAttachment()
                    {
                        MailContentID = this.ID,
                        AttachmentName = Name,
                        AttachmentBytes = Bytes,
                        Type=Type
                    }
                );
        }

        public String[] ToAddresses
        {
            get
            {
                return _ToAddress.ToArray();
            }
        }

        public String[] CCAddresses
        {
            get
            {
                return _CCAddress.ToArray();
            }
        }

        public String[] BCCAddresses
        {
            get
            {
                return _BCCAddress.ToArray();
            }
        }

        public String Save()
        {
            try
            {
                if (ID <= 0)
                {
                    ID = new EmailBusinessObject().Create(GetDTO());
                }
                else
                {
                    new EmailBusinessObject().Update(GetDTO());
                }
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(ex);
                return ex.Message;
            }

            return String.Empty;
        }

        public static MailContent[] GetPendingMails()
        {
            Email[] DTO = new EmailBusinessObject().GetAllUnsentEmails(EmailStatus.PENDING, EmailStatus.MAX_RETRY_ATTEMPT);

            MailContent[] Content = new MailContent[DTO.Length];

            for (int i = 0; i < Content.Length; i++)
            {
                Content[i] = new MailContent();

                Content[i].Update(DTO[i]);
            }

            return Content;
        }       
    }

    public class MailAttachment
    {
        public int ID;
        public int MailContentID;
        public String AttachmentName;
        public byte[] AttachmentBytes;
        public String Type;
    }


    public class MailConfigData
    {
        public string host;
        public int port;
        public bool isSSLEnabled;
        public String emailID;
        public String password;
    }

    public class MailService
    {
        private SmtpClient _mailClient;
        private MailAddress _fromAddress;
        private MailConfigData _ConfigData;

        public MailService()
        {
            _ConfigData = new MailConfigData();

            _ConfigData.host = Common.GetAppSetting("smtpserver");
            _ConfigData.port = Convert.ToInt32(Common.GetAppSetting("smtpserverport"));
            _ConfigData.isSSLEnabled = Convert.ToBoolean(Common.GetAppSetting("smtpEnableSSL"));
            _ConfigData.emailID = Common.GetAppSetting("smtpAuthEmail");
            _ConfigData.password = Common.GetAppSetting("smtpAuthPWD");

            Init();
        }

        private void Init()
        {
            try
            {
                _mailClient = new SmtpClient();

                _mailClient.Host = _ConfigData.host;
                _mailClient.Port = _ConfigData.port;
                _mailClient.EnableSsl = _ConfigData.isSSLEnabled;

                System.Net.NetworkCredential credential = new System.Net.NetworkCredential();

                credential.UserName = _ConfigData.emailID;
                credential.Password = _ConfigData.password;
                _fromAddress = new MailAddress(_ConfigData.emailID);
                _mailClient.Credentials = credential;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(ex);
            }
        }

        public MailService(MailConfigData mailConfigData)
        {
            _ConfigData = mailConfigData;

            Init();
        }

        public bool sendMail(MailContent message)
        {
            try
            {

                MailMessage mailMessage = new MailMessage();

                foreach (String toAddr in message.ToAddresses)
                {
                    if (toAddr != String.Empty)
                    {
                        mailMessage.To.Add(toAddr);
                    }
                }

                if (mailMessage.To.Count == 0)
                {
                    message.SendError = "Missing To Address";

                    return false;
                }

                foreach (String ccAddr in message.CCAddresses)
                {
                    if(ccAddr != String.Empty)
                    mailMessage.CC.Add(ccAddr);
                }

                foreach (String bccAddr in message.BCCAddresses)
                {
                    mailMessage.Bcc.Add(bccAddr);
                }

                mailMessage.From = _fromAddress;
                mailMessage.Subject = message.Subject;
                mailMessage.Body = message.Body;

                mailMessage.IsBodyHtml = true;

                if (message.IsEmbedImage)
                {
                    Attachment item = new Attachment(AppDomain.CurrentDomain.BaseDirectory + "Resources\\images\\altiostar.png");
                    item.ContentDisposition.Inline = true;
                    item.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
                    item.ContentId = message.ImageID;
                    item.ContentType.MediaType = "image/jpeg";
                    item.ContentType.Name = "Logo.JPG";
                    mailMessage.Attachments.Add(item);
                }

                if (message.Attachments != null)
                {
                    foreach (MailAttachment attachment in message.Attachments)
                    {
                        mailMessage.Attachments
                            .Add(new Attachment(new MemoryStream(attachment.AttachmentBytes), attachment.AttachmentName,attachment.Type));
                    }
                }

                _mailClient.Send(mailMessage);
            }
            catch (Exception e)
            {
                IRCAExceptionHandler.HandleException(e);
                message.SendError = e.ToString();

                return false;
            }

            return true;
        }
    }
}
