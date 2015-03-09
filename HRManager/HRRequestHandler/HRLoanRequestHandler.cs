using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRCA.Communication;
using HRManager.Communication.Request;
using HRManager.Entity;
using IRCAKernel;
using HRManager.Communication.Response;
using HRManager.DTO;
using HRManager.Entity.EmployeeLeave;
using HRManager.DTOEXT;
using HRManager.BusinessObjects;
using HRManager.Entity.ExitManagement;
using HRManager.Entity.Appraisal;
using HRManager.Entity.Recruitment;
using System.Data;
using HRManager.Communication;


namespace HRManager
{
    public class HRLoanRequestHandler 
    {
        /// <summary>
        /// Capture the Request from AppRequestHandler and generate response.
        /// </summary>
        /// <param name="RequestCommand">Represents the type of request</param>
        /// <param name="RequestData">contains the data related to this request</param>
        /// <returns>Response according to the request and request data.</returns>
        public static CommunicationObject ProcessRequest(String RequestCommand, String RequestData)
        {
            CommunicationObject Response = null;
            CommunicationObject RequestDataObject = new CommunicationObject(RequestData);
            try
            {
                if (RequestCommand == LoanAppCommands.ASSIGNEMPLOAN_DETAILS)
                {
                 Response = GetAssignEmpLoanDetails(RequestDataObject);
                }
                //else if (RequestCommand == LoanAppCommands.UPDATE_ASSIGNEMPLOAN)
                //{
                //    Response = UpdateAssignEmpLoan(RequestDataObject);
                //}


                //kartyek 06.02.2015 for advance type
                else if (RequestCommand == LoanAppCommands.ADVANCE_TYPE_DETAILS)
                {
                    Response = GetAdvanceTypeDetails(RequestDataObject);
                }
                else if (RequestCommand == LoanAppCommands.UPDATE_ADVANCE_TYPE)
                {
                    Response = UpdateAdvanceType(RequestDataObject);
                }
                else if (RequestCommand == LoanAppCommands.ACTIVATE_ADVANCE_TYPE)
                {
                    Response = ActivateAdvanceType(RequestDataObject);
                }
                else if (RequestCommand == LoanAppCommands.DEACTIVATE_ADVANCE_TYPE)
                {
                    Response = DeActivateAdvanceType(RequestDataObject);
                }
                else if (RequestCommand == LoanAppCommands.INACTIVE_ADVANCE_TYPE)
                {
                    Response = GetInActiveAdvanceType(RequestDataObject);
                }


                    //kartyek 06.02.2015 commented for future linking of loan process
                //else if (RequestCommand == LoanAppCommands.DELETE_ASSIGNEMPLOAN)
                //{
                //   Response = DeleteAssignEmpLoan(RequestDataObject);
                //}
                else if (RequestCommand == LoanAppCommands.LOANREQUEST_DETAILS)
                {
                    Response = GetLoanRequestDetails(RequestDataObject);
                }
                else if (RequestCommand == LoanAppCommands.PLACE_LOANREQUEST)
                {
                    //Response = PlaceLoanRequest(RequestDataObject);
                    Response = PlaceLoanRequestEmail(RequestDataObject);
                }
                ////else if (RequestCommand == LoanAppCommands.ACCEPTLOANREQUEST_DETAILS)
                ////{
                ////   Response = AcceptLoanRequest(RequestDataObject);
                ////}
                else if (RequestCommand == LoanAppCommands.REJECTLOANREQUEST_DETAILS)
                {
                    Response = RejectLoanRequest(RequestDataObject);
                }
                //else if (RequestCommand == LoanAppCommands.LOANREPAYMENT_DETAILS)
                //{
                //    Response = GetLoanRePaymentDetails(RequestDataObject);
                //}
                else if (RequestCommand == LoanAppCommands.LOANREQUEST_APPLIEDTO_DETAILS)
                {
                    Response = GetAppliedToLoans(RequestDataObject);
                }
                //else if (RequestCommand == LoanAppCommands.SALARYADVANCE_DETAILS)
                //{
                //    Response = GetSalaryAdvanceDetails(RequestDataObject);
                //}
                //else if (RequestCommand == LoanAppCommands.SALARYADVANCE_APPLIEDTO_DETAILS)
                //{
                //    Response = GetAppliedToSalaryAdvance(RequestDataObject);
                //}
                //else if (RequestCommand == LoanAppCommands.PLACE_SALARYADVANCE)
                //{
                //   Response = PlaceSalaryAdvance(RequestDataObject);
                //}
                //else if (RequestCommand == LoanAppCommands.ACCEPTSALARYADVANCE_DETAILS)
                //{
                //    Response = AcceptSalaryAdvance(RequestDataObject);
                //}
                //else if (RequestCommand == LoanAppCommands.REJECTSALARYADVANCE_DETAILS)
                //{
                //    Response = RejectSalaryAdvance(RequestDataObject);
                //}
                //else if (RequestCommand == LoanAppCommands.GET_PENDING_LOAN_EMPWISE)
                //{
                //    Response = GetPendingLoanEmpWise(RequestDataObject);
                //}
                //else if (RequestCommand == LoanAppCommands.UPDATE_LOAN_REPAYMENT)
                //{
                //    Response = UpdateLoanRepayment(RequestDataObject);
                //}
                //else if (RequestCommand == LoanAppCommands.GET_PENDING_SALARY_ADVANCE_EMPWISE)
                //{
                //    Response = GetPendingSalaryAdvanceEmpWise(RequestDataObject);
                //}
                //else if (RequestCommand == LoanAppCommands.UPDATE_SALARYADVANCE_REPAYMENT)
                //{
                //    Response = UpdateSalaryAdvanceRepayment(RequestDataObject);
                //}
               


                //else if (RequestCommand == LoanAppCommands.COMBOADVANCETYPE_DETAILS)
                //{
                //    Response = GetAdvanceTypeForCombo(RequestDataObject);
                //}
                else if (RequestCommand == LoanAppCommands.REQUESTED_LOAN)
                {
                    Response = GetRequestedLoan(RequestDataObject);
                }
                else if (RequestCommand == LoanAppCommands.PROCESSED_LOAN)
                {
                    Response = GetProcessedLoan(RequestDataObject);
                }
                else if (RequestCommand == LoanAppCommands.APPROVE_AND_FORWARD_TO_HR)
                {
                    Response = ApproveAndForwaordToHR(RequestDataObject);
                }
                else if (RequestCommand == LoanAppCommands.APPROVE_AND_FORWARD_TO_FINANCE)
                {
                    Response = ApproveAndForwaordToFinance(RequestDataObject);
                }
                else if (RequestCommand == LoanAppCommands.PASS_LOAN_REQUEST)
                {
                    Response = PassLoanRequest(RequestDataObject);
                }
                else if (RequestCommand == LoanAppCommands.REJECT_LOAN_REQUEST)
                {
                    Response = RejectedLoanRequest(RequestDataObject);
                }
                else if (RequestCommand == LoanAppCommands.CHECK_REPORT_HOD)
                {
                    Response = CheckReportToHOD(RequestDataObject);
                }
                else if (RequestCommand == LoanAppCommands.CHECK_REPORT_COO)
                {
                    Response = CheckReportToCOO(RequestDataObject);
                }
                //else if (RequestCommand == LoanAppCommands.MD_APPROVAL)
                //{
                //    Response = MDApproval(RequestDataObject);
                //}
                else if (RequestCommand == LoanAppCommands.CHECK_EGIBLITY_LOAN_REQUEST)
                {
                    Response = CheckForLoanEgiblity(RequestDataObject);
                }
                else if (RequestCommand == LoanAppCommands.CHECK_LOAN_DEPTHOD)
                {
                   // Response = CheckDeptHODForLoan(RequestDataObject);
                }
                else if (RequestCommand == LoanAppCommands.CHECK_LOAN_START_DATE)
                {
                    Response = CheckLoanStartDate(RequestDataObject);
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
        

       // #region  Assign Loan To Employee
        
        /// <summary>
        /// Send Request to Entity to Get Grade Details
        /// </summary>
        /// <param name="RequestDataObject">Grade id in form of Request</param>
        /// <returns>error message and success message in form of Response and arrar of Designation object</returns>
        private static CommunicationObject GetAssignEmpLoanDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            AssignEmpLoan[] AssignEmpLoanData = HRLoanManager.GetAssignEmpLoanDetails();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(AssignEmpLoanDisplayDetails));

            Builder.AddRow(AssignEmpLoanData);

            if (AssignEmpLoanData != null || AssignEmpLoanData.Length >= 0)
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
        ///// Send Request to Entity for Update Candidate
        ///// </summary>
        ///// <param name="RequestDataObject">Candidate details in form of Request</param>
        ///// <returns>error message and success message in form of Response</returns>
        //private static CommunicationObject UpdateAssignEmpLoan(CommunicationObject RequestDataObject)
        //{
        //    CommunicationObject Response = new CommunicationObject();

        //    UpdateAssignEmpLoanRequest Request = new UpdateAssignEmpLoanRequest();

        //    RequestDataObject.UpdateDataObject(Request);

        //    String ResponseString = HRLoanManager.UpdateAssignEmpLoan(Request.ID, Request.EmpID,
                       
        //        Request.LoanID, Request.LoanAmount);

        //    if (ResponseString == String.Empty)
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);

        //        if (Request.ID == 0)
        //            Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.Loan.ASSIGNEMPLOAN_ADDED_SUCCESS);
        //        else
        //            Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.Loan.ASSIGNEMPLOAN_UPDATE_SUCCESS);
        //    }
        //    else
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
        //        Response.SetProperty(WebResponse.Message, ResponseString);
        //    }

        //    return Response;
        //}
                
        /// <summary>
        /// Send Request to Entity for Update Candidate
        /// </summary>
        /// <param name="RequestDataObject">Candidate details in form of Request</param>
        /// <returns>error message and success message in form of Response</returns>
        //private static CommunicationObject DeleteAssignEmpLoan(CommunicationObject RequestDataObject)
        //{
        //    CommunicationObject Response = new CommunicationObject();

        //    EntityRequest Request = new EntityRequest();

        //    RequestDataObject.UpdateDataObject(Request);

        //    String ResponseString = HRLoanManager.DeleteAssignEmpLoan(Convert.ToInt32(Request.ID));

        //    if (ResponseString == String.Empty)
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
        //      Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.Loan.ASSIGNEMPLOAN_DELETE_SUCCESS);
        //    }
        //    else
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
        //        Response.SetProperty(WebResponse.Message, ResponseString);
        //    }

        //    return Response;
        //}

     //   #endregion

        #region  Advance Type

        private static CommunicationObject GetAdvanceTypeDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            MasterAdvanceType[] AdvanceTypeData = HRLoanManager.GetAdvanceTypes();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(AdvanceTypeDetails));

            Builder.AddRow(AdvanceTypeData);

            if (AdvanceTypeData != null || AdvanceTypeData.Length >= 0)
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
        private static CommunicationObject UpdateAdvanceType(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateAdvanceTypeRequest Request = new UpdateAdvanceTypeRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRLoanManager.UpdateAdvanceType(Request.ID, Request.AdvanceType, Request.IsActive, Request.UpdateBy);

                
            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.ID == 0)
                {
                    Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.AdvanceType.ADVANCE_TYPE_ADDED_SUCCESS);
                }
                else
                {
                    Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.AdvanceType.ADVANCE_TYPE_UPDATE_SUCCESS);
                }
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }

        private static CommunicationObject DeActivateAdvanceType(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRLoanManager.DeActivateAdvanceType(Convert.ToInt32(Request.ID), Request.ChangedBy);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.AdvanceType.DEACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        
        private static CommunicationObject ActivateAdvanceType(CommunicationObject RequestDataObject)
        {

            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRLoanManager.ActivateAdvanceType(Convert.ToInt32(Request.ID), Request.ChangedBy);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.AdvanceType.ACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }

        private static CommunicationObject GetInActiveAdvanceType(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            MasterAdvanceType[] AdvanceType = HRLoanManager.GetInActiveAdvanceType();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(AdvanceTypeDetails));

            Builder.AddRow(AdvanceType);

            if (AdvanceType != null || AdvanceType.Length >= 0)
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
        /// <summary>
        /// Get all the states for a country.
        /// </summary>
        /// <param name="RequestDataObject">EntityRequest - Will be passed.</param>
        /// <returns></returns>
        private static CommunicationObject GetAdvanceTypeForCombo(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            MasterAdvanceType[] AdvanceType = HRLoanManager.GetAdvanceTypeForCombo();

            if (AdvanceType.Length != null && AdvanceType.Length > 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, AdvanceType);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.AdvanceType.NO_ADVANCETYPE);
            }

            return Response;
        }
        #endregion

       // #region  Loan Request

        /// <summary>
        /// Get all the requested loan details
        /// </summary>
        /// <param name="RequestData">contains the data related to this request</param>
        /// <returns>Response according to the request and request data.</returns>
        private static CommunicationObject GetLoanRequestDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            LoanRequest[] LoanRequestData = HRLoanManager.GetLoanRequestDetails();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(EmployeeLoanInfo));

            Builder.AddRow(LoanRequestData);

            if (LoanRequestData != null || LoanRequestData.Length >= 0)
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

        private static CommunicationObject GetAppliedToLoans(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            UpdateLoanRequestRequest Request = new UpdateLoanRequestRequest();

            RequestDataObject.UpdateDataObject(Request);
            LoanRequest[] LoanRequestData = HRLoanManager.GetAppliedToLoans(Request.AppliedTo);

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(EmployeeLoanInfo));

            Builder.AddRow(LoanRequestData);

            if (LoanRequestData != null || LoanRequestData.Length >= 0)
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
        
        /// <summary>
        /// reject Request as Status to Entity for Update loan
        /// </summary>
        /// <param name="RequestDataObject">Loan id and HR Remarks in form of Request</param>
        /// <returns>error message and success message in form of Response</returns>
        private static CommunicationObject RejectLoanRequest(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateLoanRequestRequest Request = new UpdateLoanRequestRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRLoanManager.RejectLoanRequest(Request.ID, Request.HRRemarks, Convert.ToInt32(Request.ChangedBy));

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.Loan.LOANREQUEST_REJECT_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        /// <summary>
        /// Accept Request as Status to Entity for Update Loan
        /// </summary>
        /// <param name="RequestDataObject">Loan details in form of Request</param>
        /// <returns>error message and success message in form of Response</returns>
        //private static CommunicationObject AcceptLoanRequest(CommunicationObject RequestDataObject)
        //{
        //    CommunicationObject Response = new CommunicationObject();

        //    UpdateLoanRequestRequest Request = new UpdateLoanRequestRequest();

        //    RequestDataObject.UpdateDataObject(Request);

        //    String ResponseString = HRLoanManager.AcceptLoanRequest(Request.ID, Request.LoanAmount, Request.HRRemarks,Convert.ToInt32(Request.ChangedBy));

        //    //String ResponseString = HRLoanManager.AcceptLoanRequest(Request.ID, Request.EmpID,
        //    //    Request.LoanID, Request.LoanAmount, Request.RepaymentMonths, Request.MonthlyAmount,
        //    //    Request.Reason, Request.AppliedTo);

        //    if (ResponseString == String.Empty)
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
        //        Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.Loan.LOANREQUEST_ACCEPT_SUCCESS);
        //    }
        //    else
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
        //        Response.SetProperty(WebResponse.Message, ResponseString);
        //    }

        //    return Response;
        //}
        /// <summary>
        /// Send Request to Entity for Update Candidate
        /// </summary>
        /// <param name="RequestDataObject">Loan details in form of Request</param>
        /// <returns>error message and success message in form of Response</returns>
        //private static CommunicationObject PlaceLoanRequest(CommunicationObject RequestDataObject)
        //{
        //    CommunicationObject Response = new CommunicationObject();

        //    UpdateLoanRequestRequest Request = new UpdateLoanRequestRequest();

        //    RequestDataObject.UpdateDataObject(Request);

        //    String ResponseString = HRLoanManager.PlaceLoanRequest(Request.ID, Request.EmpID,
        //        Request.LoanID, Request.LoanAmount, Request.RepaymentMonths, Request.MonthlyAmount,
        //        Request.Reason, Request.AppliedTo);

        //    if (ResponseString == String.Empty)
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);

        //        if (Request.ID == 0)
        //            Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.Loan.LOANREQUEST_ADDED_SUCCESS);
        //        else
        //            Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.Loan.LOANREQUEST_UPDATE_SUCCESS);
        //    }
        //    else
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
        //        Response.SetProperty(WebResponse.Message, ResponseString);
        //    }

        //    return Response;
        //}
        /// <summary>
        /// Send Request to Entity for Update Candidate
        /// </summary>
        /// <param name="RequestDataObject">Loan details in form of Request</param>
        /// <returns>error message and success message in form of Response</returns>
        private static CommunicationObject PlaceLoanRequestEmail(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateLoanRequestRequest Request = new UpdateLoanRequestRequest();

            RequestDataObject.UpdateDataObject(Request);

            String RequestLoan = HRLoanManager.PlaceLoanRequestEmail(Request.ID, Request.EmpID,
                Request.LoanID, Request.LoanAmount, Request.RepaymentMonths, Request.MonthlyAmount,
                Request.Reason, Convert.ToInt32(Request.UpdateBy), Request.MaxAmount, Request.Interest, Request.ActualRepaymentMonth);
            double Num;
            if (double.TryParse(RequestLoan, out Num))
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, Num);

            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                if (RequestLoan == String.Empty)
                    RequestLoan = HRLoanManagerDefs.Loan.LOANREQUEST_UPDATE_FAILURE;
                Response.SetProperty(WebResponse.Message, RequestLoan);
            }

            return Response;
        }
       
      //  #endregion

        //kartyek 6.2.2015 commented for future

        //#region Loan Repayment
        ///// <summary>
        ///// Send Request to Entity to Get Loan Repayment Details
        ///// </summary>
        ///// <param name="RequestDataObject"></param>
        ///// <returns>error message and success message in form of Response and arrar of Designation object</returns>
        //private static CommunicationObject GetLoanRePaymentDetails(CommunicationObject RequestDataObject)
        //{
        //    CommunicationObject Response = new CommunicationObject();

        //    LoanRepayment[] LoanRepaymentData = HRLoanManager.GetLoanRepaymentDetails();

        //    JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(LoanRepaymentDisplayDetails));

        //    Builder.AddRow(LoanRepaymentData);

        //    if (LoanRepaymentData != null || LoanRepaymentData.Length >= 0)
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
        //#endregion

//        #region Salary Advance
        /// <summary>
        /// Get all the requested Salary Advance details
        /// </summary>
        /// <param name="RequestData">contains the data related to this request</param>
        /// <returns>Response according to the request and request data.</returns>
        //private static CommunicationObject GetSalaryAdvanceDetails(CommunicationObject RequestDataObject)
        //{
        //    CommunicationObject Response = new CommunicationObject();

        //    SalaryAdvance[] SalaryAdvanceData = HRLoanManager.GetSalaryAdvanceDetails();

        //    JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(SalaryAdvanceInfo));

        //    Builder.AddRow(SalaryAdvanceData);

        //    if (SalaryAdvanceData != null || SalaryAdvanceData.Length >= 0)
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

        //private static CommunicationObject GetAppliedToSalaryAdvance(CommunicationObject RequestDataObject)
        //{
        //    CommunicationObject Response = new CommunicationObject();
        //    UpdateLoanRequestRequest Request = new UpdateLoanRequestRequest();

        //    RequestDataObject.UpdateDataObject(Request);
        //    SalaryAdvance[] SalaryAdvanceData = HRLoanManager.GetAppliedToSalaryAdvance(Request.AppliedTo);

        //    JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(SalaryAdvanceInfo));

        //    Builder.AddRow(SalaryAdvanceData);

        //    if (SalaryAdvanceData != null || SalaryAdvanceData.Length >= 0)
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

        /// <summary>
        /// Send Request to Entity for Update Candidate
        /// </summary>
        /// <param name="RequestDataObject">Loan details in form of Request</param>
        /// <returns>error message and success message in form of Response</returns>
        //private static CommunicationObject PlaceSalaryAdvance(CommunicationObject RequestDataObject)
        //{
        //    CommunicationObject Response = new CommunicationObject();

        //    UpdateSalaryAdvanceRequest Request = new UpdateSalaryAdvanceRequest();

        //    RequestDataObject.UpdateDataObject(Request);

        //    String ResponseString = HRLoanManager.PlaceSalaryAdvance(Request.ID, Request.EmpID, Request.AdvanceAmount, Request.RepaymentMonths, Request.MonthlyAmount, Request.Reason, Request.UpdateBy,Request.AdvanceTypeID);

        //    if (ResponseString == String.Empty)
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
        //        if (Request.ID == 0)
        //            Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.SalaryAdvance.SALARYADVANCE_ADDED_SUCCESS);
        //        else
        //            Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.SalaryAdvance.SALARYADVANCE_UPDATED_SUCCESS);
        //    }
        //    else
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
        //        Response.SetProperty(WebResponse.Message, ResponseString);
        //    }

        //    return Response;
        //}
        /// <summary>
        /// Accept Request as Status to Entity for Update Loan
        /// </summary>
        /// <param name="RequestDataObject">Loan details in form of Request</param>
        /// <returns>error message and success message in form of Response</returns>
        //private static CommunicationObject RejectSalaryAdvance(CommunicationObject RequestDataObject)
        //{
        //    CommunicationObject Response = new CommunicationObject();

        //    UpdateSalaryAdvanceRequest Request = new UpdateSalaryAdvanceRequest();

        //    RequestDataObject.UpdateDataObject(Request);

        //    String ResponseString = HRLoanManager.RejectSalaryAdvance(Request.ID, Request.HRRemarks, Convert.ToInt32(Request.ChangedBy));

        //    if (ResponseString == String.Empty)
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
        //        Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.SalaryAdvance.SALARYADVANCE_REJECT_SUCCESS);
        //    }
        //    else
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
        //        Response.SetProperty(WebResponse.Message, ResponseString);
        //    }

        //    return Response;
        //}
        /// <summary>
        /// Accept Request as Status to Entity for Update Loan
        /// </summary>
        /// <param name="RequestDataObject">Loan details in form of Request</param>
        /// <returns>error message and success message in form of Response</returns>
        //private static CommunicationObject AcceptSalaryAdvance(CommunicationObject RequestDataObject)
        //{
        //    CommunicationObject Response = new CommunicationObject();

        //    UpdateSalaryAdvanceRequest Request = new UpdateSalaryAdvanceRequest();

        //    RequestDataObject.UpdateDataObject(Request);

        //    String ResponseString = HRLoanManager.AcceptSalaryAdvance(Request.ID, Request.HRRemarks, Convert.ToInt32(Request.ChangedBy));

        //    if (ResponseString == String.Empty)
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
        //        Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.SalaryAdvance.SALARYADVANCE_ACCEPT_SUCCESS);
        //    }
        //    else
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
        //        Response.SetProperty(WebResponse.Message, ResponseString);
        //    }

        //    return Response;
        //}
        //#endregion
        
    //    #region Loan Repayment

        /// <summary>
        /// Send Request to Entity to Get Grade Details
        /// </summary>
        /// <param name="RequestDataObject">Grade id in form of Request</param>
        /// <returns>error message and success message in form of Response and arrar of Designation object</returns>
        //private static CommunicationObject GetPendingLoanEmpWise(CommunicationObject RequestDataObject)
        //{
        //    CommunicationObject Response = new CommunicationObject();

        //    UpdateLoanRepaymentRequest Request = new UpdateLoanRepaymentRequest();

        //    RequestDataObject.UpdateDataObject(Request);

        //    AssignEmpLoan[] AssignEmpLoanData = HRLoanManager.GetPendingLoanEmpWise(Convert.ToInt32(Request.EmpID));
            
        //    JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(AssignEmpLoanDisplayDetails));

        //    Builder.AddRow(AssignEmpLoanData);

        //    if (AssignEmpLoanData != null || AssignEmpLoanData.Length >= 0)
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

        /// <summary>
        /// Send Request to Entity for Update Candidate
        /// </summary>
        /// <param name="RequestDataObject">Candidate details in form of Request</param>
        /// <returns>error message and success message in form of Response</returns>
        //private static CommunicationObject UpdateLoanRepayment(CommunicationObject RequestDataObject)
        //{
        //    CommunicationObject Response = new CommunicationObject();

        //    UpdateLoanRepaymentRequest Request = new UpdateLoanRepaymentRequest();

        //    RequestDataObject.UpdateDataObject(Request);

        //    String ResponseString = HRLoanManager.UpdateLoanRepayment(Request.ID, Request.LoanRequestID,
        //         Request.Amount,Request.UpdateBy);

        //    if (ResponseString == String.Empty)
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
        //        //if (Request.ID == 0)
        //            Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.LoanRepayment.LOANREPAYMENT_ADDED_SUCCESS);
        //       // else
        //       //     Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.Loan.ASSIGNEMPLOAN_UPDATE_SUCCESS);
        //    }
        //    else
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
        //        Response.SetProperty(WebResponse.Message, ResponseString);
        //    }

        //    return Response;
        //}
        //#endregion

        //#region Salary Advance Repayment 
        
        ///// <summary>
        ///// Send Request to Entity to Get Grade Details
        ///// </summary>
        ///// <param name="RequestDataObject">Grade id in form of Request</param>
        ///// <returns>error message and success message in form of Response and arrar of Designation object</returns>
        //private static CommunicationObject GetPendingSalaryAdvanceEmpWise(CommunicationObject RequestDataObject)
        //{
        //    CommunicationObject Response = new CommunicationObject();

        //    UpdateSalaryAdvanceRequest Request = new UpdateSalaryAdvanceRequest();

        //    RequestDataObject.UpdateDataObject(Request);

        //    SalaryAdvanceRepayment[] SalaryAdvanceRepaymentData = HRLoanManager.GetPendingSalaryAdvanceEmpWise(Convert.ToInt32(Request.EmpID));

        //    JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(SalaryAdvanceRepaymentDisplayDetails));

        //    Builder.AddRow(SalaryAdvanceRepaymentData);

        //    if (SalaryAdvanceRepaymentData != null || SalaryAdvanceRepaymentData.Length >= 0)
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
        ///// <summary>
        ///// Send Request to Entity for Update Candidate
        ///// </summary>
        ///// <param name="RequestDataObject">Candidate details in form of Request</param>
        ///// <returns>error message and success message in form of Response</returns>
        //private static CommunicationObject UpdateSalaryAdvanceRepayment(CommunicationObject RequestDataObject)
        //{
        //    CommunicationObject Response = new CommunicationObject();

        //    UpdateSalaryAdvanceRepaymentRequest Request = new UpdateSalaryAdvanceRepaymentRequest();

        //    RequestDataObject.UpdateDataObject(Request);

        //    String ResponseString = HRLoanManager.UpdateSalaryAdvanceRepayment(Request.ID, Request.EmpID,
        //        Request.AdvanceID, Request.Amount, Request.UpdateBy);

        //    if (ResponseString == String.Empty)
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
        //        Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.SalaryAdvanceRepayment.SALARYADVANCEREPAYMENT_ADDED_SUCCESS);
        //    }
        //    else
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
        //        Response.SetProperty(WebResponse.Message, ResponseString);
        //    }

        //    return Response;
        //}
        //#endregion

        //#region Loan Activity

        private static CommunicationObject GetRequestedLoan(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            UpdateLoanActivityRequest Request = new UpdateLoanActivityRequest();
            RequestDataObject.UpdateDataObject(Request);

            LoanActivity[] LoanActivityData = HRLoanManager.GetRequestedLoan(Request.EmpID);

            JGridObjectBuilder Builder = new JGridObjectBuilder("LoanRequestID", typeof(LoanActivityInfo));

            Builder.AddRow(LoanActivityData);

            if (LoanActivityData != null || LoanActivityData.Length >= 0)
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

        private static CommunicationObject GetProcessedLoan(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            UpdateLoanActivityRequest Request = new UpdateLoanActivityRequest();
            RequestDataObject.UpdateDataObject(Request);

            LoanActivity[] LoanActivityData = HRLoanManager.GetProcessedLoan(Request.EmpID);

            JGridObjectBuilder Builder = new JGridObjectBuilder("LoanRequestID", typeof(LoanActivityInfo));

            Builder.AddRow(LoanActivityData);

            if (LoanActivityData != null || LoanActivityData.Length >= 0)
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
        private static CommunicationObject ApproveAndForwaordToHR(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateLoanActivityRequest Request = new UpdateLoanActivityRequest();
            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRLoanManager.ApproveAndForwaordToHR(Convert.ToInt32(Request.LoanRequestID), Request.ChangeBy, Request.Remarks);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.Loan.FORWARDTOHR);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        private static CommunicationObject CheckReportToHOD(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateLoanActivityRequest Request = new UpdateLoanActivityRequest();
            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRLoanManager.CheckReportToHOD(Convert.ToInt32(Request.LoanRequestID), Request.ChangeBy, Request.Remarks);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.Loan.LOANAPPROVEDBYHOD);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        //private static CommunicationObject MDApproval(CommunicationObject RequestDataObject)
        //{
        //    CommunicationObject Response = new CommunicationObject();

        //    UpdateLoanActivityRequest Request = new UpdateLoanActivityRequest();
        //    RequestDataObject.UpdateDataObject(Request);

        //    String ResponseString = HRLoanManager.MDApproval(Convert.ToInt32(Request.LoanRequestID), Request.ChangeBy, Request.Remarks);

        //    if (ResponseString == String.Empty)
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
        //        Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.Loan.FORWARDTOMD);
        //    }
        //    else
        //    {
        //        Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
        //        Response.SetProperty(WebResponse.Message, ResponseString);
        //    }

        //    return Response;
        //}

        private static CommunicationObject CheckForLoanEgiblity(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();
            RequestDataObject.UpdateDataObject(Request);
            int RequestedID = Convert.ToInt32(Request.ID);
            String ResponseString = HRLoanManager.CheckForLoanEgiblity(RequestedID);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.Loan.ELIGIBLE);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.Loan.NOT_ELIGIBLE);
            }

            return Response;
        }
        private static CommunicationObject CheckDeptHODForLoan(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();
            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRLoanManager.CheckDeptHODForLoan(Convert.ToInt32(Request.ID));

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.Loan.ELIGIBLE);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        private static CommunicationObject CheckLoanStartDate(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateLoanRequest Request = new UpdateLoanRequest();
            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRLoanManager.CheckLoanStartDate(Request.LoanStartDate, Request.LoanRequestID);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, "");
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        private static CommunicationObject CheckReportToCOO(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateLoanActivityRequest Request = new UpdateLoanActivityRequest();
            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRLoanManager.CheckReportToCOO(Convert.ToInt32(Request.LoanRequestID), Request.ChangeBy, Request.Remarks);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.Loan.LOANAPPROVEDBYHOD);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        private static CommunicationObject ApproveAndForwaordToFinance(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateLoanActivityRequest Request = new UpdateLoanActivityRequest();
            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRLoanManager.ApproveAndForwaordToFinance(Convert.ToInt32(Request.LoanRequestID), Request.ChangeBy, Request.Remarks);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.Loan.FORWARDTOFINANCE);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        private static CommunicationObject PassLoanRequest(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateLoanActivityRequest Request = new UpdateLoanActivityRequest();
            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRLoanManager.PassLoanRequest(Convert.ToInt32(Request.LoanRequestID), Request.ChangeBy, Request.Remarks, Request.LoanStartOn);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.Loan.PASSANDCLOSE);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }

        private static CommunicationObject RejectedLoanRequest(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdateLoanActivityRequest Request = new UpdateLoanActivityRequest();
            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRLoanManager.LoanRequestRejection(Convert.ToInt32(Request.LoanRequestID), Request.ChangeBy, Request.Remarks);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRLoanManagerDefs.Loan.LOANREQUESTREJECT);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        //#endregion

    }
}
