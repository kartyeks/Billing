using System;
using System.Data;
using IS91.Services.DataBlock;
using System.Collections;
using IRCAKernel.DTO;

namespace IRCAKernel.BusinessObjects
{
    public partial class EmailBusinessObject
    {
        public Email[] GetAllUnsentEmails(String NewStatus, int MaxAttempt)
        {
            const String Qry = " SELECT * FROM Email WHERE SendStatus = '{0}' AND RetryCount <= {1}";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();
            exQry.Query = string.Format(Qry, NewStatus, MaxAttempt);
            DataTable dt = EE.ExecuteDataTable(exQry);
            Email[] Emails = new Email[dt.Rows.Count];
            for (int i = 0; i < Emails.Length; i++)
            {
                Emails[i] = new Email();
                Emails[i].ID = (int)dt.Rows[i]["ID"];
                Emails[i].ToAddress = (String)dt.Rows[i]["ToAddress"];
                Emails[i].FromAddress = (String)dt.Rows[i]["FromAddress"];
                Emails[i].CcList = (String)dt.Rows[i]["CcList"];
                Emails[i].BccList = (String)dt.Rows[i]["BccList"];
                Emails[i].EmailSubject = (String)dt.Rows[i]["EmailSubject"];
                Emails[i].EmailBody = (String)dt.Rows[i]["EmailBody"];
                Emails[i].Attachment = (String)dt.Rows[i]["Attachment"];
                Emails[i].SendStatus = (String)dt.Rows[i]["SendStatus"];
                Emails[i].RetryCount = (int)dt.Rows[i]["RetryCount"];
                Emails[i].FirstSendAttempt = (DateTime)dt.Rows[i]["FirstSendAttempt"];
                Emails[i].LastSendAttempt = (DateTime)dt.Rows[i]["LastSendAttempt"];
                Emails[i].ErrorMsgOnSendFail = (String)dt.Rows[i]["ErrorMsgOnSendFail"];
            }

            return Emails;
        }
    }
}
