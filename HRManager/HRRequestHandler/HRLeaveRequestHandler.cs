
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRCA.Communication;
using HRManager.Communication.Request;
using HRManager.DTO;
using HRManager.Entity;
using IRCAKernel;
using System.Configuration;
using HRManager.BusinessObjects;
using HRManager.Entity.LeaveApp;

namespace HRManager
{
    public class HRLeaveRequestHandler : IRCARequestHandler
    {

        public override String[] GetCommands()
        {
            if (_Commands.ContainsKey(typeof(LeaveAppCommands).Name))
            {
                return _Commands[typeof(LeaveAppCommands).Name].ToArray();
            }

            return new String[0];
        }
//        /// <summary>
//        /// Capture the Request from LeaveRequestHandler and generate response.
//        /// </summary>
//        /// <param name="RequestCommand">Represents the type of request</param>
//        /// <param name="RequestData">contains the data related to this request</param>
//        /// <returns>Response according to the request and request data.</returns>
        public override CommunicationObject ProcessRequest(String RequestCommand, String RequestData)
        {
            CommunicationObject Response = null;
            CommunicationObject RequestDataObject = new CommunicationObject(RequestData);
            try
            {
                if (RequestCommand == LeaveAppCommands.LEAVE_DETAILS)
                {
                    Response = GetLeaveDetails(RequestDataObject);
                }
                else if (RequestCommand == LeaveAppCommands.DEACTIVATE_LEAVE)
                {
                    Response = DeActivateLeave(RequestDataObject);
                }
                else if (RequestCommand == LeaveAppCommands.ACTIVATE_LEAVE)
                {
                    Response = ActivateLeave(RequestDataObject);
                }
                else if (RequestCommand == LeaveAppCommands.UPDATE_LEAVE)
                {
                    Response = UpdateLeave(RequestDataObject);
                }
                else if (RequestCommand == LeaveAppCommands.INACTIVE_LEAVE)
                {
                    Response = GetInActiveLeave(RequestDataObject);
                }

            }
            catch (IRCAException e)
            {
                IRCAExceptionHandler.HandleException(e);
            }
            catch (Exception e)
            {
                Response = new CommunicationObject();
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, "Unknown Application Error");

                IRCAException Exception = new IRCAException(e
                                , WebResponse.Message
                                , "Request Command = " + RequestCommand
                                  + "\n Request Data " + RequestData
                                  );

                IRCAExceptionHandler.HandleException(Exception);
            }

            return Response;
        }



        #region Leave


//        /// <summary>
//        /// Send Request to Entity for DeActivate Leave
//        /// </summary>
//        /// <param name="RequestDataObject">Leave id and changedby id in form of Request</param>
//        /// <returns>error message and success message in form of Response</returns>
        private static CommunicationObject DeActivateLeave(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.DeActivateLeave(Convert.ToInt32(Request.ID));

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.LeaveMessages.DEACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }


//        /// <summary>
//        /// Send Request to Entity for Activate Leave
//        /// </summary>
//        /// <param name="RequestDataObject">Leave id and changedby id in form of Request</param>
//        /// <returns>error message and success message in form of Response</returns>
        private static CommunicationObject ActivateLeave(CommunicationObject RequestDataObject)
        {

            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.ActivateLeave(Convert.ToInt32(Request.ID));

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRManagerDefs.LeaveMessages.ACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
//        /// <summary>
//        /// Send Request to Entity for Update Leave
//        /// </summary>
//        /// <param name="RequestDataObject">Leave details in form of Request</param>
//        /// <returns>error message and success message in form of Response</returns>
        private static CommunicationObject UpdateLeave(CommunicationObject RequestDataObject)
        {

            CommunicationObject Response = new CommunicationObject();

            UpdateLeaveMasterRequest Request = new UpdateLeaveMasterRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRManager.UpdateLeave(Request.ID, Request.LeaveType, Request.IsActive, Convert.ToInt32(Request.UpdateBy));

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.ID == 0)
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.LeaveMessages.LEAVE_ADDED_SUCCESS);
                else
                    Response.SetProperty(WebResponse.Message, HRManagerDefs.LeaveMessages.LEAVE_UPDATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }


        private static CommunicationObject GetLeaveDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            Leave[] LeaveData = HRManager.GetLeaves();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(LeaveTypeDetails));

            Builder.AddRow(LeaveData);

            if (LeaveData != null || LeaveData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }
        private static CommunicationObject GetInActiveLeave(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            Leave[] LeaveData = HRManager.GetInActiveLeaves();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(LeaveTypeDetails));

            Builder.AddRow(LeaveData);

            if (LeaveData != null || LeaveData.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }

            return Response;
        }



        #endregion
       
    }
}
