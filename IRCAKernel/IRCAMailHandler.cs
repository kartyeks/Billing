using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace IRCAKernel
{
    /// <summary>
    /// The exception handler will handle all the exceptions. When a exceptions is given to handler
    /// that will be store in a queue. Another thread will pick and log
    /// </summary>
    public class IRCAMailHandler
    {
        private Queue<MailContent> _MailData;
        private Semaphore _Synchronize;
        private static IRCAMailHandler _MailHandler;
        private MailService _MailService;


        /// <summary>
        /// Constructor which creates queue and synchronize object
        /// </summary>
        private IRCAMailHandler()
        {
            _MailData = new Queue<MailContent>();
            _Synchronize = new Semaphore(0, 10000);
            _MailService = new MailService();

            MailContent[] Mail = MailContent.GetPendingMails();

            new Thread(this.LogData).Start();

            foreach (MailContent Tmp in Mail)
            {
                SetMail(Tmp);
            }
        }

        /// <summary>
        /// Sysnchronized call to get the data. This call will be waiting until some one post the data
        /// </summary>
        /// <returns></returns>
        private MailContent GetMail()
        {
            _Synchronize.WaitOne();
            lock (_MailData)
            {
                return _MailData.Dequeue();
            }
        }

        /// <summary>
        /// Synchronized call to set the data.
        /// </summary>
        /// <param name="Message"></param>
        private void SetMail(MailContent Message)
        {
            lock (_MailData)
            {
                _MailData.Enqueue(Message);
                _Synchronize.Release();
            }
        }

        /// <summary>
        /// The method which will be running in a thread. Once the data posted this will pick the data and process.
        /// Based on the exception type, the details will be logged
        /// </summary>
        private void LogData()
        {
            for (; ; )
            {
                try
                {
                    MailContent Data = GetMail();
                    if (!_MailService.sendMail(Data))
                    {
                        Data.SendAttempts++;

                        Data.Status = EmailStatus.PENDING;
                        Data.Save();

                        if (Data.SendAttempts <= EmailStatus.MAX_RETRY_ATTEMPT)
                        {
                            SetMail(Data);
                        }
                    }
                    else
                    {
                        Data.Status = EmailStatus.SENT;
                        Data.Save();
                    }
                }
                catch (Exception ex)
                {
                    IRCAExceptionHandler.HandleException(ex);
                }
            }
        }

        /// <summary>
        /// Ths static method which will be called by others for handle exception
        /// </summary>
        /// <param name="e"></param>
        public static void SendMail(MailContent Mail)
        {
            if (_MailHandler == null)
            {
                _MailHandler = new IRCAMailHandler();
            }

            Mail.IsEmbedImage = true;
            Mail.EmbededImageSrc = "../Resources/Images/altiostar.png";
            Mail.ImageID = "IMAGEID";

            String Mainbody = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates\\IRCAEmailTemplate.htm"));
            Mail.Body = String.Format(Mainbody, Mail.ImageID, Mail.Body);
            

            Mail.Status = EmailStatus.PENDING;
            Mail.Save();
            _MailHandler.SetMail(Mail);
        }
    }
}