using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using IS91.Services;
using IS91.Services.Web;
using HRManager.Entity;
using HRManager.DTO;
using System.Configuration;
using System.Xml;
using System.Net.Mail;
using System.Data;
using System.Drawing.Printing;
using HRManager.BusinessObjects;
using HRManager;
using IRCAKernel;
using System.Net;

namespace AltioStarHR
{
    public class UploadFileHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
          context.Response.Cache.SetNoStore();
            string[] arr = null;
            string mode = string.Empty;
            string id = string.Empty;
            SmtpMail objMail = null;
            string path = context.Request["path"];
            if (path != null)
            {
                arr = path.Split('$');
                mode = arr[1];
            }
            else
            {
                mode = string.Concat(context.Request["mode"]);
                id = string.Concat(context.Request["ID"]);
            }
            if (mode == "employeephoto")
            {
                // TO FETCH EMPLOYEE PHOTO IN IMAGE CNTROL FROM DATABASE
                string employeeID = id;
                Master_Employees objEmp = new Master_EmployeesBusinessObject().GetMaster_Employees(employeeID);
                if (objEmp != null)
                {
                    if (objEmp.Photo.Length == 0) return;
                    System.IO.MemoryStream dataStream = null;

                    dataStream = new System.IO.MemoryStream(objEmp.Photo);
                    context.Response.ContentType = "image/jpeg";
                    dataStream.WriteTo(context.Response.OutputStream);
                    dataStream.Flush();
                    dataStream.Close();
                    dataStream = null;
                 
                }
            }
            else if (mode == "candidateresume")
            {
                WebClient req = new WebClient();

                String DocumentName = string.Concat(context.Request["DocumentName"]);
                String URL = context.Server.MapPath("~/Resources") + "\\ResumeDownloads\\" + DocumentName;

                Byte[] data = (Byte[])req.DownloadData(URL);
                context.Response.Buffer = true;
                context.Response.Charset = "";
                context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                context.Response.AddHeader("content-disposition", "attachment;filename=" + DocumentName);
                if (data.Length != 0)
                {
                    context.Response.BinaryWrite(data);
                }
                context.Response.Flush();
                context.Response.End();
            }
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
