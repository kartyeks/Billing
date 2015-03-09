using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonManager.Communication.Request;
using CommonManager;
using IRCAKernel;
using IRCA.Communication;
using HRManager.Communication.Request;
using HRManager;

namespace ApplicationManager
{
    /// <summary>
    /// All the request from the page will come to this class. 
    /// This will be responsible to send to different handlers
    /// The other handlers will convert the request data as the object and process.
    /// The handler will give the response as CommunicationObject and it will be converted as JSON String and sent to client
    /// </summary>
    public class LoanRequestHandler
    {

        /// <summary>
        /// Process the request
        /// </summary>
        /// <param name="RequestCommand">Request Command from client</param>
        /// <param name="RequestData">The data which has been sent for the request</param>
        /// <returns></returns>
        public static String ProcessRequest(String RequestCommand, String RequestData)
        {
            CommunicationObject Response = null;
            CommunicationObject RequestDataObject = new CommunicationObject(RequestData);

            try
            {
                if (
                        // assign employee loan
                        RequestCommand == LoanAppCommands.ASSIGNEMPLOAN_DETAILS
                        //|| RequestCommand == LoanAppCommands.UPDATE_ASSIGNEMPLOAN
                        || RequestCommand == LoanAppCommands.DELETE_ASSIGNEMPLOAN
                        // loan request
                        || RequestCommand == LoanAppCommands.LOANREQUEST_DETAILS
                        || RequestCommand == LoanAppCommands.PLACE_LOANREQUEST
                        || RequestCommand == LoanAppCommands.ACCEPTLOANREQUEST_DETAILS
                        || RequestCommand == LoanAppCommands.REJECTLOANREQUEST_DETAILS
                        || RequestCommand == LoanAppCommands.LOANREPAYMENT_DETAILS
                        || RequestCommand == LoanAppCommands.LOANREQUEST_APPLIEDTO_DETAILS
                        || RequestCommand == LoanAppCommands.SALARYADVANCE_DETAILS
                        || RequestCommand == LoanAppCommands.SALARYADVANCE_APPLIEDTO_DETAILS
                        || RequestCommand == LoanAppCommands.PLACE_SALARYADVANCE
                        || RequestCommand == LoanAppCommands.ACCEPTSALARYADVANCE_DETAILS
                        || RequestCommand == LoanAppCommands.REJECTSALARYADVANCE_DETAILS
                        || RequestCommand == LoanAppCommands.GET_PENDING_LOAN_EMPWISE
                        || RequestCommand == LoanAppCommands.UPDATE_LOAN_REPAYMENT
                        || RequestCommand == LoanAppCommands.GET_PENDING_SALARY_ADVANCE_EMPWISE
                        || RequestCommand == LoanAppCommands.UPDATE_SALARYADVANCE_REPAYMENT
                        || RequestCommand == LoanAppCommands.ADVANCE_TYPE_DETAILS
                        || RequestCommand == LoanAppCommands.UPDATE_ADVANCE_TYPE
                        || RequestCommand == LoanAppCommands.ACTIVATE_ADVANCE_TYPE
                        || RequestCommand == LoanAppCommands.DEACTIVATE_ADVANCE_TYPE
                        || RequestCommand == LoanAppCommands.INACTIVE_ADVANCE_TYPE
                        || RequestCommand == LoanAppCommands.COMBOADVANCETYPE_DETAILS
                        || RequestCommand == LoanAppCommands.REQUESTED_LOAN
                        || RequestCommand == LoanAppCommands.APPROVE_AND_FORWARD_TO_HR
                        || RequestCommand == LoanAppCommands.APPROVE_AND_FORWARD_TO_FINANCE
                        || RequestCommand == LoanAppCommands.PASS_LOAN_REQUEST
                        || RequestCommand == LoanAppCommands.REJECT_LOAN_REQUEST
                        || RequestCommand == LoanAppCommands.CHECK_REPORT_HOD
                        || RequestCommand == LoanAppCommands.CHECK_REPORT_COO
                        || RequestCommand == LoanAppCommands.MD_APPROVAL
                        || RequestCommand == LoanAppCommands.CHECK_EGIBLITY_LOAN_REQUEST
                        || RequestCommand == LoanAppCommands.CHECK_LOAN_DEPTHOD
                        || RequestCommand == LoanAppCommands.PROCESSED_LOAN
                        || RequestCommand == LoanAppCommands.CHECK_LOAN_START_DATE
                    )
                {
                    Response = HRLoanRequestHandler.ProcessRequest(RequestCommand, RequestData);

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

            return CommunicationObject.GetJsonStringResponse(Response);
        }
    }
}
