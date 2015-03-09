using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.Net.Mail;
using HRManager.Entity.EmployeesInfo;
using System.IO;
using HRManager.DTO;
using HRManager.BusinessObjects;
using HRManager.DTOEXT;

namespace AltioStarHR
{
    public class DownloadFileHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        string EmployeeID = string.Empty;
        string DocumentName = string.Empty;
        string Type = string.Empty;
        string ID = string.Empty;
        WebClient req = new WebClient();
        public void ProcessRequest(HttpContext context)
        {
            EmployeeID = string.Concat(context.Request["EmployeeID"]);
            DocumentName = string.Concat(context.Request["DocumentName"]);
            Type = string.Concat(context.Request["Type"]);
            ID = string.Concat(context.Request["ID"]);
            string URL = string.Empty;
            if (Type == "Resume")
            {
                URL = context.Server.MapPath("~/Resources") + "\\ResumeDownloads\\" + DocumentName;
            }
            else if (Type == "externalresume")
            {
                URL = context.Server.MapPath("~/Resources") + "\\ExternalUploadResumeDownloads\\" + DocumentName;
            }
            else if (Type == "appraisal")
            {

                URL = context.Server.MapPath("~/Resources") + "\\GoalDocuments\\" + ID + "\\" + DocumentName;
            }
            else if (Type == "empappraisal")
            {
                Appraisal_Intimation obj = new Appraisal_IntimationBusinessObject().GetAppraisal_Intimation(ID);
                URL = context.Server.MapPath("~/Resources") + "\\GoalDocuments\\" + ID + "\\" + obj.DocumentName;
                DocumentName = obj.DocumentName;
            }
            else if (Type == "empgoal")
            {
                Appraisal_Employee obj = new Appraisal_EmployeeBusinessObject().GetAppraisal_Employee(ID);
                URL = context.Server.MapPath("~/Resources") + "\\GoalDocuments\\" + obj.IntimationID + "\\Employee\\" + obj.EmployeeID + "_" + obj.Goals;
                DocumentName = obj.Goals;
            }
            else if (Type == "empgrade")
            {
                Appraisal_Employee obj = new Appraisal_EmployeeBusinessObject().GetAppraisal_Employee(ID);
                URL = context.Server.MapPath("~/Resources") + "\\GoalDocuments\\" + obj.IntimationID + "\\EmployeeGrade\\" + obj.ID + "_" + obj.Grade;
                DocumentName = obj.Grade;
            }
            else if (Type == "exitmanagement")
            {
                //Exit_Management obj = new ExitManagementBusinessObject().GetExit_Management(EmployeeID);
                Exit_Management obj = new ExitManagementBusinessObject().DownLoadExitManagement(EmployeeID);
                URL = context.Server.MapPath("~/Resources") + "\\ExitManagement\\" + obj.EmployeeID + "_" + obj.DocumentName;
                if (obj.DocumentName != "")
                {
                    DocumentName = obj.DocumentName;
                }
                else
                {                    
                    return;
                }
               
            }
            else if (Type == "candidateresume")
            {
                URL = context.Server.MapPath("~/Resources") + "\\ResumeDownloads\\" + DocumentName;
            }
            else if (Type == "Help")
            {
                if (DocumentName == "Admin")
                {
                    URL = context.Server.MapPath("~/Resources") + "\\ManualDocuments\\Admin.pdf";
                }
                else if (DocumentName == "Manager")
                {
                    URL = context.Server.MapPath("~/Resources") + "\\ManualDocuments\\Manager.pdf";
                }
                else if (DocumentName == "Employee")
                {
                    URL = context.Server.MapPath("~/Resources") + "\\ManualDocuments\\Employee.pdf";
                }
            }
            else
            {
                if (EmployeeID != string.Empty)
                {
                    URL = context.Server.MapPath("~/Resources") + "\\EmployeeDocuments\\" + EmployeeID;
                    URL = URL + "\\" + DocumentName;
                }
            }
            context.Response.Clear();
            context.Response.ContentType = "application/pdf";
            context.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + DocumentName + "\"");
            context.Response.TransmitFile(URL);
            context.Response.End();
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
}
