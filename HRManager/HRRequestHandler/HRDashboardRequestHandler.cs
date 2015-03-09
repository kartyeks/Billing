using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRCAKernel;
using IRCA.Communication;
using HRManager.Entity;
using HRManager.BusinessObjects;

namespace HRManager
{
    public class HRDashboardRequestHandler : IRCARequestHandler
    {
        public override string[] GetCommands()
        {
            if (_Commands.ContainsKey(typeof(DashboardAppCommands).Name))
            {
                return _Commands[typeof(DashboardAppCommands).Name].ToArray();
            }

            return new String[0];
        }
        public override CommunicationObject ProcessRequest(string RequestCommand, string RequestData)
        {

            CommunicationObject Response = null;
            CommunicationObject RequestDataObject = new CommunicationObject(RequestData);

            try
            {
                if (RequestCommand == DashboardAppCommands.GET_DASHBOARD_LEAVE_DETAILS)
                {
                    Response = GetDashBoardDetails(RequestDataObject);
                }
                else if (RequestCommand == DashboardAppCommands.CANDIDATE_REFERRED_STATUS)
                {
                    Response = CANDIDATEREFERREDSTATUS(RequestDataObject);
                }
                else if (RequestCommand == DashboardAppCommands.MONTHLY_HOLIDAYS)
                {
                    Response = MonthlyHolidays(RequestDataObject);
                }
                else if (RequestCommand == DashboardAppCommands.LOGGED_EMP_ATTENDANCE)
                {
                    Response = MonthlyAttendanceEmpView(RequestDataObject);
                }
                else if (RequestCommand == DashboardAppCommands.MONTHLY_OFFER_ISSUED)
                {
                    Response = CurrentMonthOfferLetersIssued(RequestDataObject);
                }
                else if (RequestCommand == DashboardAppCommands.MONTHLY_SCHEDULED_CANDIDATES)
                {
                    Response = CurrentMonthScheduledCandidates(RequestDataObject);
                }
                else if (RequestCommand == DashboardAppCommands.EMPLOYEE_APPRAISAL)
                {
                    Response = EmployeeAppraisal(RequestDataObject);
                }
                else if (RequestCommand == DashboardAppCommands.EMPLOYEE_EXIT_IN_THREE_MONTHS)
                {
                    Response = EMPLOYEEEXITINTHREEMONTHS(RequestDataObject);
                }
                else if (RequestCommand == DashboardAppCommands.CURRENT_MONTH_LEAVE_STATUS)
                {
                    Response = CURRENTMONTHLEAVESTATUS(RequestDataObject);
                }
                else if (RequestCommand == DashboardAppCommands.CANDIDATE_REFERRED_COUNT)
                {
                    Response = CANDIDATEREFERREDCOUNT(RequestDataObject);
                }
                
            }
            catch (IRCAException ex)
            {
                IRCAExceptionHandler.HandleException(ex);
            }
            catch (Exception ex)
            {
                Response = new CommunicationObject();
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, "Unknown Application Error");

                IRCAException Exception = new IRCAException(ex, WebResponse.Message, "Request Command = " + RequestCommand + "\n Request Data " + RequestData);

                IRCAExceptionHandler.HandleException(Exception);
            }

            return Response;
        }

        private static CommunicationObject GetDashBoardDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            EntityRequest Request = new EntityRequest();
            RequestDataObject.UpdateDataObject(Request);
            DashBoardDetails[] hrDetails = Dashboard_Display_DetailsBusinessObject.GetDashBoardDetails(Convert.ToInt32(Request.ID));

            if (hrDetails != null)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, hrDetails);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject CANDIDATEREFERREDSTATUS(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            EntityRequest Request = new EntityRequest();
            RequestDataObject.UpdateDataObject(Request);
            NewDashBoardDetails[] details = Dashboard_Display_DetailsBusinessObject.CANDIDATEREFERREDSTATUS(Convert.ToInt32(Request.ID));

            if (details != null)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, details);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject EmployeeAppraisal(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            EntityRequest Request = new EntityRequest();
            RequestDataObject.UpdateDataObject(Request);
            NewEmployeeAppraisal[] details = Dashboard_Display_DetailsBusinessObject.EmployeeAppraisal(Convert.ToInt32(Request.ID));

            if (details != null)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, details);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject MonthlyHolidays(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            NewMonthlyDetails[] details = Dashboard_Display_DetailsBusinessObject.MonthlyHolidays();

            if (details != null)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, details);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject EMPLOYEEEXITINTHREEMONTHS(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            NewEmployeeExitInThreeMonths[] details = Dashboard_Display_DetailsBusinessObject.EMPLOYEEEXITINTHREEMONTHS();

            if (details != null)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, details);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject CURRENTMONTHLEAVESTATUS(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            EntityRequest Request = new EntityRequest();
            RequestDataObject.UpdateDataObject(Request);
            NewCurrentMonthLeaveStatus[] details = Dashboard_Display_DetailsBusinessObject.CURRENTMONTHLEAVESTATUS(Convert.ToInt32(Request.ID));

            if (details != null)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, details);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject MonthlyAttendanceEmpView(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();
            RequestDataObject.UpdateDataObject(Request);

            AttdendanceDasshboard[] details = Dashboard_Display_DetailsBusinessObject.GetLoggedEmpAttendance(Convert.ToInt32(Request.ID));

            if (details != null)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, details);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject CurrentMonthOfferLetersIssued(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            OfferIssuedDashboard[] details = Dashboard_Display_DetailsBusinessObject.GetCurrentMonthOfferIssued();

            if (details != null)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, details);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }

        private static CommunicationObject CANDIDATEREFERREDCOUNT(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            NewCandidateReferredCount[] details = Dashboard_Display_DetailsBusinessObject.CANDIDATEREFERREDCOUNT();

            if (details != null)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, details);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject CurrentMonthScheduledCandidates(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            InterviewScheduledDashboard[] details = Dashboard_Display_DetailsBusinessObject.GetCurrentMonthScheduledCandidates();

            if (details != null)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, details);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
       

    }
}
