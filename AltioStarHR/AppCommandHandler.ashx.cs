using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApplicationManager;


namespace AltioStarHRMS
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>

    public class AppCommandHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            String RequestCommand = context.Request.Form["RequestCommand"];
            String RequestData = context.Request.Form["RequestData"];
            String RequestHandler = context.Request.Form["RequestHandler"];

            context.Response.ContentType = "application/json";
            context.Response.Write(new AppRequestHandler().ProcessRequest(RequestCommand, RequestData));

            //if (RequestHandler == "LEAVE_REQUEST")
            //{
            //    context.Response.Write(LeaveRequestHandler.ProcessRequest(RequestCommand, RequestData));
            //}
             if (RequestHandler == "LOAN_REQUEST")
            {
                context.Response.Write(LoanRequestHandler.ProcessRequest(RequestCommand, RequestData));
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
