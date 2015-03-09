using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRCA.Communication;
using CommonManager.Communication.Request;
//using CommonManager.DTO;
//using CommonManager.Entity;
using IRCAKernel;
using CommonManager.Entity;
using CommonManager.DTO;

namespace CommonManager
{
    public class CommonRequestHandler : IRCARequestHandler
    {
        public override string[] GetCommands()
        {
            if (_Commands.ContainsKey(typeof(CommonAppCommands).Name))
            {
                return _Commands[typeof(CommonAppCommands).Name].ToArray();
            }

            return new String[0];
        }

        public override  CommunicationObject ProcessRequest(String RequestCommand, String RequestData)
        {
            CommunicationObject Response = null;
            CommunicationObject RequestDataObject = new CommunicationObject(RequestData);
            try
            {
                if (RequestCommand == CommonAppCommands.LOGIN_REQUEST)
                {
                    //Response = LoginRequest(RequestDataObject);
                }
                else if (RequestCommand == CommonAppCommands.USER_DETAILS)
                {
                    Response = GetUserDetails(RequestDataObject);
                }
                else if (RequestCommand == CommonAppCommands.EMPBASEDUPDATE_USER)
                {
                    Response = EmpBasedUser(RequestDataObject);
                }
                else if (RequestCommand == CommonAppCommands.UPDATE_USER)
                {
                    Response = UpdateUser(RequestDataObject);
                }

                    
                else if (RequestCommand == CommonAppCommands.UNLOCK_USER)
                {
                    //Response = UnlockUser(RequestDataObject);
                }
                else if (RequestCommand == CommonAppCommands.ACTIVATE_USER)
                {
                    //Response = ActivateUser(RequestDataObject);
                }
                else if (RequestCommand == CommonAppCommands.DEACTIVATE_USER)
                {
                    //Response = DeActivateUser(RequestDataObject);
                }
                else if (RequestCommand == CommonAppCommands.RESET_PASSWORD)
                {
                     Response = ResetPassword(RequestDataObject);
                }
                else if (RequestCommand == CommonAppCommands.FORGOT_PASSWORD)
                {
                    //Response = ForgotPassword(RequestDataObject);
                }
                else if (RequestCommand == CommonAppCommands.CHANGE_PASSWORD)
                {
                    Response = ChangePassword(RequestDataObject);
                }
               
                else if (RequestCommand == CommonAppCommands.STATE_DETAILS)
                {
                    //Response = GetStateDetails(RequestDataObject);
                }
                else if (RequestCommand == CommonAppCommands.INACTIVE_USER)
                {
                    //Response = GetInactiveUser(RequestDataObject);
                }
                else if (RequestCommand == CommonAppCommands.STATECOMBO_DETAILS)
               {
                //    Response = GetStateNameComboDetails(RequestDataObject);
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

        #region State

        ///// <summary>
        ///// Process Country details request. Sends the array of country names to client
        ///// </summary>
        ///// <param name="RequestDataObject"></param>
        ///// <returns></returns>
        //private static CommunicationObject GetCountryDetails(CommunicationObject RequestDataObject)
        //{
        //    CommunicationObject Response = new CommunicationObject();

        //    Country[] Country = CommonManager.GetCountryDetails();

        //    if (Country.Length != null && Country.Length > 0)
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
        //        Response.SetProperty(WebResponse.ResponseObject, Country);
        //    }
        //    else
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
        //        Response.SetProperty(WebResponse.Message, CommonDefs.StateCountryMessages.NO_COUNTRY);
        //    }

        //    return Response;
        //}

        ///// <summary>
        ///// Get all the states for a country.
        ///// </summary>
        ///// <param name="RequestDataObject">EntityRequest - Will be passed.</param>
        ///// <returns></returns>
        //private static CommunicationObject GetStateDetails(CommunicationObject RequestDataObject)
        //{
        //    CommunicationObject Response = new CommunicationObject();

        //    EntityRequest Request = new EntityRequest();

        //    RequestDataObject.UpdateDataObject(Request);

        //    State[] State = CommonManager.GetStatesForCountry(Convert.ToInt32(Request.ID));

        //    if (State.Length != null && State.Length > 0)
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
        //        Response.SetProperty(WebResponse.ResponseObject, State);
        //    }
        //    else
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
        //        Response.SetProperty(WebResponse.Message, CommonDefs.StateCountryMessages.NO_STATES);
        //    }

        //    return Response;
        //}

        //private static CommunicationObject GetStateNameComboDetails(CommunicationObject RequestDataObject)
        //{
        //    CommunicationObject Response = new CommunicationObject();
        //    UpdateStateRequest Request = new UpdateStateRequest();

        //    RequestDataObject.UpdateDataObject(Request);

        //    State[] State = CommonManager.GetStatesForZone(Convert.ToInt32(Request.ZoneID));

        //    if (State.Length != null && State.Length > 0)
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
        //        Response.SetProperty(WebResponse.ResponseObject, State);
        //    }
        //    else
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
        //        Response.SetProperty(WebResponse.Message, CommonDefs.StateCountryMessages.NO_STATES);
        //    }

        //    return Response;
        //}


        #endregion

        #region Login

        /// <summary>
        /// Process Login Request
        /// </summary>
        /// <param name="RequestDataObject">LoginRequest - Will be passed</param>
        /// <returns></returns>
        //private static CommunicationObject LoginRequest(CommunicationObject RequestDataObject)
        //{
        //    CommunicationObject Response = new CommunicationObject();

        //    LoginRequest Request = new LoginRequest();

        //    RequestDataObject.UpdateDataObject(Request);

        //    String ResponseString = CommonManager.LoginRequest(Request.LoginName, Request.Password);

        //    if (ResponseString == String.Empty)
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
        //    }
        //    else
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
        //        Response.SetProperty(WebResponse.Message, ResponseString);
        //    }

        //    return Response;
        //}

        /// <summary>
        /// Process Change Password Request
        /// </summary>
        /// <param name="RequestDataObject">ChangePasswordRequest - Will be passed</param>
        /// <returns></returns>
        private static CommunicationObject ChangePassword(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            ChangePasswordRequest Request = new ChangePasswordRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = CommonManager.ChangePassword(Request.UserID, Request.NewPassword);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, CommonDefs.LoginMessages.PASSWORD_CHANGE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }

        /// <summary>
        /// Process Forgot password request
        /// </summary>
        /// <param name="RequestDataObject">EntityRequest</param>
        /// <returns></returns>
        //private static CommunicationObject ForgotPassword(CommunicationObject RequestDataObject)
        //{

        //    CommunicationObject Response = new CommunicationObject();

        //    UpdateUserRequest Request = new UpdateUserRequest();

        //    RequestDataObject.UpdateDataObject(Request);

        //    String ResponseString = CommonManager.ForgotPassword(Request.LoginName, Request.EMailID);

        //    if (ResponseString == String.Empty)
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
        //        Response.SetProperty(WebResponse.Message, CommonDefs.LoginMessages.FORGOT_PASSWORD_SUCCESS);
        //    }
        //    else
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
        //        Response.SetProperty(WebResponse.Message, ResponseString);
        //    }

        //    return Response;
        //}
        #endregion
        
        #region Users

        /// <summary>
        /// Process Reset password request
        /// </summary>
        /// <param name="RequestDataObject">EntityRequest</param>
        /// <returns></returns>
        private static CommunicationObject ResetPassword(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            Resetpwdupdates Request = new Resetpwdupdates();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = CommonManager.ResetPassword(Convert.ToInt32(Request.ID), Request.EmployeeID, Request.LoginType);

            if (ResponseString != null || ResponseString.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, CommonDefs.UserMessages.RESET_PASSWORD_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }

        ///// <summary>
        ///// Process De Activate User Request
        ///// </summary>
        ///// <param name="RequestDataObject">EntityRequest</param>
        ///// <returns></returns>
        //private static CommunicationObject DeActivateUser(CommunicationObject RequestDataObject)
        //{
        //    CommunicationObject Response = new CommunicationObject();

        //    EntityRequest Request = new EntityRequest();

        //    RequestDataObject.UpdateDataObject(Request);

        //    String ResponseString = CommonManager.DeActivateUser(Convert.ToInt32(Request.ID),Request.ChangedBy);

        //    if (ResponseString == String.Empty)
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
        //        Response.SetProperty(WebResponse.Message, CommonDefs.UserMessages.DEACTIVATE_SUCCESS);
        //    }
        //    else
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
        //        Response.SetProperty(WebResponse.Message, ResponseString);
        //    }

        //    return Response;
        //}

        ///// <summary>
        ///// Process Activate User
        ///// </summary>
        ///// <param name="RequestDataObject">EntityRequest</param>
        ///// <returns></returns>
        //private static CommunicationObject ActivateUser(CommunicationObject RequestDataObject)
        //{

        //    CommunicationObject Response = new CommunicationObject();

        //    EntityRequest Request = new EntityRequest();

        //    RequestDataObject.UpdateDataObject(Request);

        //    String ResponseString = CommonManager.ActivateUser(Convert.ToInt32(Request.ID), Request.ChangedBy);

        //    if (ResponseString == String.Empty)
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
        //        Response.SetProperty(WebResponse.Message, CommonDefs.UserMessages.ACTIVATE_SUCCESS);
        //    }
        //    else
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
        //        Response.SetProperty(WebResponse.Message, ResponseString);
        //    }

        //    return Response;
        //}

        //private static CommunicationObject UnlockUser(CommunicationObject RequestDataObject)
        //{
        //    CommunicationObject Response = new CommunicationObject();

        //    EntityRequest Request = new EntityRequest();

        //    RequestDataObject.UpdateDataObject(Request);

        //    String ResponseString = CommonManager.UnlockUser(Convert.ToInt32(Request.ID), Request.ChangedBy);

        //    if (ResponseString == String.Empty)
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
        //        Response.SetProperty(WebResponse.Message, CommonDefs.UserMessages.UNLOCK_SUCCESS);
        //    }
        //    else
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
        //        Response.SetProperty(WebResponse.Message, ResponseString);
        //    }

        //    return Response;      
        //}

        private static CommunicationObject EmpBasedUser(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = CommonManager.getempbasedusers(Request.ChangedBy, Request.ID);

            if (ResponseString != String.Empty)
            {
                
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);

               
            }
            else
            {
               
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
               
            }
            Response.SetProperty(WebResponse.ResponseObject, ResponseString);
            return Response;
        }
        private static CommunicationObject UpdateUser(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateUserRequest Request = new UpdateUserRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = CommonManager.UpdateUser(Request.UserID, Request.EmployeeID, Request.LoginName, Request.Password, Request.UpdateBy,Request.LoginType);
            
            
            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.LoginName == "")
                    Response.SetProperty(WebResponse.Message, CommonDefs.UserMessages.USER_ADDED_SUCCESS);
                else
                    Response.SetProperty(WebResponse.Message, CommonDefs.UserMessages.USER_UPDATE_SUCCESS);
            
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, "Login Name Already Exists");
            }

            return Response;
        }

        private static CommunicationObject GetUserDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateUserRequest Request = new UpdateUserRequest();

            RequestDataObject.UpdateDataObject(Request);

            User[] UserData = CommonManager.GetUsers(Request.Type);

            JGridObjectBuilder Builder = new JGridObjectBuilder("Sno", typeof(UserDisplayDetails));

            Builder.AddRow(UserData);

            if (UserData != null || UserData.Length >= 0)
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

        ///// <summary>
        ///// Send Request to Entity to Get Designation Details
        ///// </summary>
        ///// <param name="RequestDataObject">Designation id in form of Request</param>
        ///// <returns>error message and success message in form of Response and arrar of Designation object</returns>
        //private static CommunicationObject GetInactiveUser(CommunicationObject RequestDataObject)
        //{
        //    CommunicationObject Response = new CommunicationObject();

        //    UpdateUserRequest Request = new UpdateUserRequest();

        //    RequestDataObject.UpdateDataObject(Request);

        //    User[] UserData = CommonManager.GetInActiveUsers(Request.Type);

        //    JGridObjectBuilder Builder = new JGridObjectBuilder("UserID", typeof(UserDisplayDetails));

        //    Builder.AddRow(UserData);

        //    if (UserData != null || UserData.Length >= 0)
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
        //        Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
        //    }
        //    else
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
        //        Response.SetProperty(WebResponse.Message, String.Empty);
        //    }

        //    return Response;
        //}

       

        #endregion

    }
}
