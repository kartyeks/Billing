using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.Communication.Request;
using HRManager.DTO;
using HRManager.Entity;
using IRCAKernel;
using IRCA.Communication;

namespace HRManager
{
    public class HRPayrollRequestHandler :IRCARequestHandler
    {
        public override String[] GetCommands()
        {
            if (_Commands.ContainsKey(typeof(PayrollAppCommands).Name))
            {
                return _Commands[typeof(PayrollAppCommands).Name].ToArray();
            }

            return new String[0];
        }
        /// <summary>
        /// Capture the Request from AppRequestHandler and generate response.
        /// </summary>
        /// <param name="RequestCommand">Represents the type of request</param>
        /// <param name="RequestData">contains the data related to this request</param>
        /// <returns>Response according to the request and request data.</returns>
        public override CommunicationObject ProcessRequest(String RequestCommand, String RequestData)
        {
            CommunicationObject Response = null;
            CommunicationObject RequestDataObject = new CommunicationObject(RequestData);
            try
            {
                if (RequestCommand == PayrollAppCommands.SALARY_ALLOWANCES)
                {
                    Response = GetSalaryAllowances(RequestDataObject);
                }
                else if (RequestCommand == PayrollAppCommands.INACTIVE_SALARYALLOWANCES)
                {
                    Response = GetInactiveSalaryAllowance(RequestDataObject);
                }
                else if (RequestCommand == PayrollAppCommands.UPDATE_SALARYALLOWANCE)
                {
                    Response = UpdateSalaryAllowance(RequestDataObject);
                }
                else if (RequestCommand == PayrollAppCommands.ACTIVATE_SALARYALLOWANCE)
                {
                    Response = ActivateSalaryAllowance(RequestDataObject);
                }
                else if (RequestCommand == PayrollAppCommands.DEACTIVATE_SALARYALLOWANCE)
                {
                    Response = DeActivateSalaryAllowance(RequestDataObject);
                }
                if (RequestCommand == PayrollAppCommands.SALRYDEDUCTION_DETAILS)
                {
                    Response = GetSalryDeductionDetails(RequestDataObject);
                }
                else if (RequestCommand == PayrollAppCommands.INACTIVE_SALRYDEDUCTION)
                {
                    Response = GetInactiveSalryDeductionDetails(RequestDataObject);
                }
                else if (RequestCommand == PayrollAppCommands.UPDATE_SALRYDEDUCTION)
                {
                    Response = UpdateSalryDeduction(RequestDataObject);
                }
                else if (RequestCommand == PayrollAppCommands.DEACTIVATE_SALRYDEDUCTION)
                {
                    Response = DeActivateSalryDeduction(RequestDataObject);
                }
                else if (RequestCommand == PayrollAppCommands.ACTIVATE_SALRYDEDUCTION)
                {
                    Response = ActivateSalryDeduction(RequestDataObject);
                }

                else if (RequestCommand == PayrollAppCommands.GETPAYROLL_DETAILS)
                {
                    Response = GetPayrollDetails(RequestDataObject);
                }
                else if (RequestCommand == PayrollAppCommands.UPDATEPAYROLL_DETAILS)
                {
                    Response = UpdatePayrollDetails(RequestDataObject);
                }
                else if (RequestCommand == PayrollAppCommands.GETANNUL_BENIFITS)
                {
                    Response = GetAnualBenifits(RequestDataObject);
                }
                else if (RequestCommand == PayrollAppCommands.CHECK_PAYROLL_GENERATED)
                {
                    Response = CheckPayrollGenerated(RequestDataObject);
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

        private static CommunicationObject CheckPayrollGenerated(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            UpdatePayrollRequest Request = new UpdatePayrollRequest();
            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRPayrollManager.CheckPayrollGenerated(Request.EmpID, Request.Month, Request.Year);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, "");
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, "Not Generated");
            }

            return Response;
        }
        /// <summary>
        /// Send Request to Entity to Get Salary Allowances
        /// </summary>
        /// <param name="RequestDataObject"></param>
        /// <returns></returns>
        private static CommunicationObject GetSalaryAllowances(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            SalaryAllowance[] SAllow = HRPayrollManager.GetSalaryAllowances();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(SalaryHeadDisplayDetails));

            Builder.AddRow(SAllow);

            if (SAllow != null || SAllow.Length >= 0)
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
        private static CommunicationObject UpdateSalaryAllowance(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            UpdateSalaryAllowanceRequest Request = new UpdateSalaryAllowanceRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRPayrollManager.UpdateSalaryAllowance(Request.ID, Request.AllowanceName, Request.AllowancePeriod, Request.IsPercentage, Request.IsActive, Request.IsTaxExempted, Request.UpdateBy, Request.IsOptional, Request.IsAllowance, Request.DisplayOrder, Request.IsOneMonthBasic, Request.Value,Request.AllowanceCode);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.ID == 0)
                    Response.SetProperty(WebResponse.Message, HRPayrollManagerDefs.SalaryAllowanceMessages.ALLOWANCE_ADDED_SUCCESS);
                else
                    Response.SetProperty(WebResponse.Message, HRPayrollManagerDefs.SalaryAllowanceMessages.ALLOWANCE_UPDATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        private static CommunicationObject GetInactiveSalaryAllowance(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            SalaryAllowance[] SAllow = HRPayrollManager.GetInactiveSalaryAllowances();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(SalaryHeadDisplayDetails));

            Builder.AddRow(SAllow);

            if (SAllow != null || SAllow.Length >= 0)
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
        private static CommunicationObject DeActivateSalaryAllowance(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRPayrollManager.DeActivateSalaryAllowance(Convert.ToInt32(Request.ID), Convert.ToInt32(Request.ChangedBy));

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRPayrollManagerDefs.SalaryAllowanceMessages.DEACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        private static CommunicationObject ActivateSalaryAllowance(CommunicationObject RequestDataObject)
        {

            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRPayrollManager.ActivateSalaryAllowance(Convert.ToInt32(Request.ID), Convert.ToInt32(Request.ChangedBy));

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRPayrollManagerDefs.SalaryAllowanceMessages.ACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        /// <summary>
        /// Send Request to Entity to Get Grade Salary Details
        /// </summary>
        /// <param name="RequestDataObject">Grade Salary id in form of Request</param>
        /// <returns>error message and success message in form of Response and arrar of Designation object</returns>
        private static CommunicationObject GetSalryDeductionDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            SalaryDeductions[] SalaryDeduct = HRPayrollManager.GetAllSalaryDeductions();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(SalaryDeductionDetails));

            Builder.AddRow(SalaryDeduct);

            if (SalaryDeduct != null || SalaryDeduct.Length >= 0)
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
        /// Send Request to Entity to Get Grade Salary Details
        /// </summary>
        /// <param name="RequestDataObject">Grade Salary id in form of Request</param>
        /// <returns>error message and success message in form of Response and arrar of Designation object</returns>
        private static CommunicationObject GetInactiveSalryDeductionDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            SalaryDeductions[] SalaryDeduct = HRPayrollManager.GetAllInactiveSalaryDeductions();

            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(SalaryDeductionDetails));

            Builder.AddRow(SalaryDeduct);

            if (SalaryDeduct != null || SalaryDeduct.Length >= 0)
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
        /// Send Request to Entity for Update Grade Salary
        /// </summary>
        /// <param name="RequestDataObject">Grade Salary details in form of Request</param>
        /// <returns>error message and success message in form of Response</returns>

        private static CommunicationObject UpdateSalryDeduction(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            UpdateSalaryDedctionRequest Request = new UpdateSalaryDedctionRequest();
            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRPayrollManager.UpdateSalaryDeductions(Request.ID, Request.Name, Request.Period, Request.Limit, Request.IsEmployee, Request.IsPercentage, Request.DeductionCode, Request.IsTaxExempted, Request.IsActive, Request.UpdateBy,Request.Code);

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                if (Request.ID == 0)
                    Response.SetProperty(WebResponse.Message, HRPayrollManagerDefs.SalaryDeductionMessges.SALARYDEDUCTION_ADDED_SUCCESS);
                else
                    Response.SetProperty(WebResponse.Message, HRPayrollManagerDefs.SalaryDeductionMessges.SALARYDEDUCTION_UPDATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }

        /// <summary>
        /// Send Request to Entity for DeActivate Grade Salary
        /// </summary>
        /// <param name="RequestDataObject">Grade Salary id and changedby id in form of Request</param>
        /// <returns>error message and success message in form of Response</returns>
        private static CommunicationObject DeActivateSalryDeduction(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRPayrollManager.DeActivateSalaryDeductions(Convert.ToInt32(Request.ID), Convert.ToInt32(Request.ChangedBy));

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRPayrollManagerDefs.SalaryDeductionMessges.DEACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }

        /// <summary>
        /// Send Request to Entity for Activate Grade Salary
        /// </summary>
        /// <param name="RequestDataObject">Grade Salary id and changedby id in form of Request</param>
        /// <returns>error message and success message in form of Response</returns>
        private static CommunicationObject ActivateSalryDeduction(CommunicationObject RequestDataObject)
        {

            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = HRPayrollManager.ActivateSalaryDeductions(Convert.ToInt32(Request.ID), Convert.ToInt32(Request.ChangedBy));

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.Message, HRPayrollManagerDefs.SalaryDeductionMessges.ACTIVATE_SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, ResponseString);
            }

            return Response;
        }
        #region Paroll
        /// <summary>
        /// Gets Tax Excemption Data
        /// </summary>
        /// <param name="RequestDataObject"></param>
        /// <returns>CommunicationObject</returns>
        private static CommunicationObject GetPayrollDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            UpdatePayrollRequest Request = new UpdatePayrollRequest();

            RequestDataObject.UpdateDataObject(Request);
            DateTime dtTmp = new DateTime(Request.Year, Request.Month, 1);
            if (dtTmp > DateTime.Today)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, "Invalid Month and Year");
            }
            EmployeePayroll[] employeePays = EmployeePayrollManager.GetPayrollForAllEmployeesList(Request.Month, Request.Year,  Request.UpdatedBy);
            PayrollSession pSession = PayrollSession.CreatePayrollSession();
            pSession.AddEmployeePayroll(Request.SessionID, Request.UniqueID, employeePays);
            JGridObjectBuilder Builder = new JGridObjectBuilder("EmployeeID", typeof(EmployeePayrollDetails));
            Builder.AddRow(employeePays);
            if (employeePays != null || employeePays.Length >= 0)
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
        /// Updates UpdatePayrollDetails Data to database
        /// </summary>
        /// <param name="requestDataObject"></param>
        /// <returns>CommunicationObject</returns> 
        private static CommunicationObject UpdatePayrollDetails(CommunicationObject requestDataObject)
        {
            CommunicationObject response = new CommunicationObject();
            UpdatePayrollRequest request = new UpdatePayrollRequest();

            requestDataObject.UpdateDataObject(request);

            String responseString = HRPayrollManager.UpdateEmployeePayroll(request.SessionID, request.UniqueID,request.Month,request.Year,request.IsAnualbenifitsincluded);

            if (responseString == String.Empty)
            {
                response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                response.SetProperty(WebResponse.Message, HRPayrollManagerDefs.Payroll.PAYROLL_UPDATE_SUCCESS);
            }
            else
            {
                response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                response.SetProperty(WebResponse.Message, responseString);
            }
            return response;
        }
         
        /// <summary>
        /// Gets Tax Excemption Data
        /// </summary>
        /// <param name="RequestDataObject"></param>
        /// <returns>CommunicationObject</returns>
        private static CommunicationObject GetAnualBenifits(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            UpdateAnnualAdditionsRequest Request = new UpdateAnnualAdditionsRequest();

            RequestDataObject.UpdateDataObject(Request);
            AnualBenifits AnualBenifitsDet = HRPayrollManager.GetAnualBenifits(Request.Month, Request.Year, Request.EmployeeID);
            Allowance[] AllowanceDT = AnualBenifitsDet.Allowances;
            JGridObjectBuilder Builder = new JGridObjectBuilder("ID", typeof(AnualBenifitsDetails));

            Builder.AddRow(AllowanceDT);

            if (AnualBenifitsDet != null)
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
