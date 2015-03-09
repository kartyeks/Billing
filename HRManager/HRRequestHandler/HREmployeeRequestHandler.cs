using System;
using IRCA.Communication;
using HRManager.Communication.Request;
using HRManager.Entity.EmployeesInfo;
using IRCAKernel;


namespace HRManager
{
    public class HREmployeeRequestHandler : IRCARequestHandler
    {
        public override string[] GetCommands()
        {
            if (_Commands.ContainsKey(typeof(EmployeeAppCommands).Name))
            {
                return _Commands[typeof(EmployeeAppCommands).Name].ToArray();
            }

            return new String[0];
        }

        public override CommunicationObject ProcessRequest(string RequestCommand, string RequestData)
        {

            CommunicationObject Response = null;
            CommunicationObject RequestDataObject = new CommunicationObject(RequestData);

            try
            {
                if (RequestCommand == EmployeeAppCommands.GET_EMPLOYEE_GRIDDETAILS)
                {
                    Response = GetEmployeeGridDetails(RequestDataObject);
                }
                else if (RequestCommand == EmployeeAppCommands.GET_EMPLOYEE)
                {
                    Response = GetEmployee(RequestDataObject);
                }
                else if (RequestCommand == EmployeeAppCommands.UPDATE_EMPLOYEE_INFO)
                {
                    Response = UpdateEmployeeInfo(RequestDataObject);
                }
                else if (RequestCommand == EmployeeAppCommands.REMOVE_EMPLOYEE_INFO)
                {
                    Response = RemoveEmployeeInfo(RequestDataObject);
                }
                else if (RequestCommand == EmployeeAppCommands.CHECK_EMP_ISFRESHER)
                {
                    Response = CheckIsFresher(RequestDataObject);
                }
                else if (RequestCommand == EmployeeAppCommands.DELETE_EMPLOYEE)
                {
                    Response = DeleteEmployee(RequestDataObject);
                }
                else if (RequestCommand == EmployeeAppCommands.CALCULATE_CTC_DETAILS)
                {
                    Response = CalculateCTCDetails(RequestDataObject);
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

        private CommunicationObject GetEmployeeGridDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EmployeeGridRequest Request = new EmployeeGridRequest();

            RequestDataObject.UpdateDataObject(Request);

            EmployeeGateWay Gateway = new EmployeeGateWay();

            BaseEmployee[] Emplyees = Gateway.GetEmployees(Request.FirstName, Request.LastName, Request.Empcode, Request.DesignationID, Request.CountryID, Request.LocationID, Request.TeamID);

            JGridObjectBuilder Builder = new JGridObjectBuilder("EmpID", typeof(BaseEmployee));

            Builder.AddRow(Emplyees);

            if (Emplyees.Length >= 0)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Builder.GetGridObject());
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, Gateway.Message);
            }

            return Response;
        }
     
        private CommunicationObject GetEmployee(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            String WorkFlowName = RequestDataObject.GetProperty("EmployeeInfoType");
            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);
            IS91.Services.Logger.LogThis("HND EMPID: " + Request.ID);
            EmployeeGateWay Gateway = new EmployeeGateWay();

            Employee Emplyee = Gateway.GetEmployee(Convert.ToInt32(Request.ID));

            if (Emplyee != null)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, Emplyee);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, Gateway.Message);
            }

            return Response;
        }

        private CommunicationObject UpdateEmployeeInfo(CommunicationObject requestDataObject)
        {
            CommunicationObject response = new CommunicationObject();
            EmployeeGateWay gateway = new EmployeeGateWay();

            String employeeInfoType = requestDataObject.GetProperty("EmployeeInfoType");

            EmployeeInfo employeeInfo = gateway.GetEmployeeInfoObject(employeeInfoType);

            requestDataObject.UpdateDataObject(employeeInfo);
            String responseString = gateway.UpdateEmployeeInfo(employeeInfo);
            if (employeeInfoType == "EMP_PERSONAL_INFO" || employeeInfoType == "EMP_OCCUPATIONAL_INFO" || employeeInfoType == "EMP_SALARY_INFO")
            {
                if (responseString == String.Empty || responseString == "0" || responseString == HREmployeeManagerDefs.Employee.EMPLOYEE_UPDATE_FAILURE || responseString == HREmployeeManagerDefs.Employee.EMIAL_EXISTS)
                {
                    response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                }
                else
                {
                    response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                }
            }
            else
            {
                if (responseString == String.Empty)
                {
                    response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                }
                else
                {
                    response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                }
            }

            response.SetProperty(WebResponse.Message, responseString);

            return response;
        }

        private CommunicationObject RemoveEmployeeInfo(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
            EmployeeGateWay Gateway = new EmployeeGateWay();

            String EmployeeInfoType = RequestDataObject.GetProperty("EmployeeInfoType");
            EntityRequest Request = new EntityRequest();
            RequestDataObject.UpdateDataObject(Request);

            String ResponseString = Gateway.RemoveEmployeeInfo(EmployeeInfoType, Convert.ToInt32(Request.ID));

            if (ResponseString == String.Empty)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
            }

            Response.SetProperty(WebResponse.Message, ResponseString);

            return Response;
        }
        private static CommunicationObject CheckIsFresher(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();
             EmployeeGateWay Gateway = new EmployeeGateWay();
            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

           // bool Result = new CostingManager.Entity.Project.Costing.ProjectStatusHistory().IsBudgetExists(Request.DeliverableID, Request.Key);
            bool Result = Gateway.IsEmpFresher(Convert.ToInt32(Request.ID));

            if (Result)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
            }
            else
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                Response.SetProperty(WebResponse.Message, String.Empty);
            }
            return Response;

        }

        private CommunicationObject DeleteEmployee(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EntityRequest Request = new EntityRequest();

            RequestDataObject.UpdateDataObject(Request);

            String EmpData = HREmployeeManager.DeleteEmployee(Convert.ToInt32(Request.ID));

            if (EmpData != null)
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);

            else
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);

            return Response;
        }

        private CommunicationObject CalculateCTCDetails(CommunicationObject RequestDataObject)
        {
            CommunicationObject Response = new CommunicationObject();

            EmployeeGridRequest Request = new EmployeeGridRequest();

            RequestDataObject.UpdateDataObject(Request);

            CTCDetails EmpData = HREmployeeManager.CalculateCTCDetails(Request.CTC);

            if (EmpData != null)
            {
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.SUCCESS);
                Response.SetProperty(WebResponse.ResponseObject, EmpData);
            }
        

            else
                Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);

            return Response;
        }
    }

   
}