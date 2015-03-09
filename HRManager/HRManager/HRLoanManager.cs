using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.Entity;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IS91.Services;
using IS91.Services.DataBlock;
using System.IO;
using HRManager.Entity.EmployeesInfo;
using HRManager.DTOEXT;

namespace HRManager
{
    public class HRLoanManager
    {

        public static AssignEmpLoan[] GetAssignEmpLoanDetails()
        {
            return AssignEmpLoan.GetAllAssignEmpLoan();
        }
        public static AssignEmpLoan[] GetPendingLoanEmpWise(int EmpID)
        {
            return AssignEmpLoan.GetPendingLoanEmpWise(EmpID);
        }
        //public static SalaryAdvanceRepayment[] GetPendingSalaryAdvanceEmpWise(int EmpID)
        //{
        //    return SalaryAdvanceRepayment.GetPendingSalaryAdvanceEmpWise(EmpID);
        //}

        public static LoanRequest[] GetLoanRequestDetails()
        {
            return LoanRequest.GetAllLoanRequest();
        }
        //public static SalaryAdvance[] GetSalaryAdvanceDetails()
        //{
        //    return SalaryAdvance.GetAllSalaryAdvance();
        //}

        public static LoanActivity[] GetRequestedLoan(int EmpID)
        {
            return LoanActivity.GetRequestedLoan(EmpID);
        }
        public static LoanActivity[] GetProcessedLoan(int EmpID)
        {
            return LoanActivity.GetProcessedLoan(EmpID);
        }
        //public static SalaryAdvance[] GetAppliedToSalaryAdvance(int AppliedToID)
        //{
        //    return SalaryAdvance.GetAppliedToSalaryAdvance(AppliedToID);
        //}
        public static LoanRequest[] GetAppliedToLoans(int AppliedToID)
        {
            return LoanRequest.GetAppliedToLoans(AppliedToID);
        }
        //public static LoanRepayment[] GetLoanRepaymentDetails()
        //{
        //    return LoanRepayment.GetAllLoanRepayment();
        //}
        public static MasterAdvanceType[] GetAdvanceTypes()
        {
            return MasterAdvanceType.GetAllActiveAdvanceType();
        }

        public static MasterAdvanceType[] GetInActiveAdvanceType()
        {
            return MasterAdvanceType.GetInActiveAdvanceType();
        }
        public static MasterAdvanceType[] GetAdvanceTypeForCombo()
        {
            return MasterAdvanceType.GetAdvanceTypeForCombo();
        }



        //kartyek 6.2.2015 commented for future purpose

        ///// <summary>
        ///// Update Role of given ID
        ///// </summary>
        ///// <param name="ID">field contain Role ID</param>
        ///// <param name="ZoneName">field contain Role Name</param>
        ///// <param name="Description">field contain Role Description</param>
        ///// <param name="IsActive">field contaions Active status.</param>
        ///// <param name="UpdatedBy">field contain the user id who update Role</param>
        ///// <returns>empty string for success and error message for failure</returns>
        //public static String DeleteAssignEmpLoan(int ID)
        //{
        //    try
        //    {
        //        AssignEmpLoan AssignEmpLoan = new AssignEmpLoan();
        //        String Status = AssignEmpLoan.DeleteAssignEmpLoan(ID);

        //        return Status;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRManagerDefs.RoleMessages.Role_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRManagerDefs.RoleMessages.Role_UPDATE_FAILURE;
        //    }
        //}

        ///// <summary>
        ///// Reject Loan Request for given Loan Request ID
        ///// </summary>
        ///// <param name="ID">field contain Loan Request ID</param>
        ///// <returns>empty string for success and error message for failure</returns>
        public static String RejectLoanRequest(int ID, String HRRemarks, int RejectedBy)
        {
            bool IsLocalSession = false;
            Session DBSession = null;
            if (DBSession == null)
            {
                IsLocalSession = true;

                DBSession = Session.CreateNewSession();

                DBSession.BeginTransaction();
            }
            try
            {
                LoanRequest LoanRequest = new LoanRequest(ID);
                LoanRequest.Status = LoanAppCommands.LOANREQUEST_REJECTED_STATUS;
                LoanRequest.HRRemarks = HRRemarks;
                LoanRequest.UpdatedBy = RejectedBy;
                LoanRequest.RepliedDateTime = DateTime.Now;
                String Status = LoanRequest.Save(DBSession);
                if (IsLocalSession)
                {
                    DBSession.Commit();
                }

                return Status;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRLoanManagerDefs.Loan.LOANREQUEST_REJECT_FAILURE, ID.ToString())
                    );
                return HRLoanManagerDefs.Loan.LOANREQUEST_REJECT_FAILURE;
            }
        }
        public static String ApproveAndForwaordToHR(int ID, int ChangedBy, String Remarks)
        {
            bool IsLocalSession = false;
            Session DBSession = null;
            if (DBSession == null)
            {
                IsLocalSession = true;

                DBSession = Session.CreateNewSession();

                DBSession.BeginTransaction();
            }
            try
            {
                EmailEntity objEmail = new EmailEntity();
                string LoanAction = "Forwarded";
                string LoanActionByEmpName = new Employee(ChangedBy).FirstName;
                //kartyek commented for approve and forward to hr.
                //string Department = new TeamDetail(new EmployeeOccupationDetails(ChangedBy).TeamID).TeamName;
                string Department = new TeamDetail(new EmployeeOccupationDetails(ChangedBy).TeamID).TeamName;
                string EmpName = new LoanRequest(ID).EmployeeName;
                string LoanName = new Loan(new LoanRequest(ID).LoanID).LoanName;
                string LoanAmount = new LoanRequest(ID).LoanAmount.ToString();
                string lLoanReason = new LoanRequest(ID).Reason;
                // objEmail.ToAddress = new Employees(new LoanRequest(ID).EmpID).EMailID;
                objEmail.ToAddress = new EmployeeOccupationDetails(new Designation(true, "HR").RoleID).EmailID;
                objEmail.FromAddress = IS91.Services.Common.GetAppSetting("smtpFromEmail");
                objEmail.EmailSubject = "Loan Notification";
                String body = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates\\LoanNotify.htm"));
                body = body.Replace("{Prm!LoanAction}", LoanAction);
                body = body.Replace("{Prm!LoanActionByEmpName}", LoanActionByEmpName);
                body = body.Replace("{Prm!Department}", Department);
                body = body.Replace("{Prm!EmpName}", EmpName);
                body = body.Replace("{Prm!LoanName}", LoanName);
                body = body.Replace("{Prm!LoanAmount}", LoanAmount);
                body = body.Replace("{Prm!lLoanReason}", lLoanReason);
                objEmail.EmailBody = body;
                objEmail.Attachment = "";
                objEmail.SendStatus = HRAppCommands.EMAIL_STATUS_NEW;
                objEmail.RetryCount = 0;

                LoanActivity LoanActivity = new LoanActivity();
                LoanActivity.LoanRequestID = ID;
                LoanActivity.ActivityBy = ChangedBy;
                LoanActivity.ActivityDate = DateTime.Now;
                LoanActivity.Status = LoanAppCommands.FORWARDTOHRCHECK;
                LoanActivity.Initiator = ChangedBy;
                //kartyek 12.02.2015 for receiver designation based role id 
                //[Usp_CheckHR]
                //Hr_DesignationBusinessObject obj=new String(new Hr_DesignationBusinessObject().GetHRRoles(ID)).ToString();

                Master_DesignationEXT[] DesignationsDT = new Hr_DesignationBusinessObject().GetHRRoles(ChangedBy);
                //DesignationsDT[0].Role;
                //DesignationsDT[0].ID;


                if (DesignationsDT[0].Role == "HR")
                {
                    LoanActivity.Receiver = DesignationsDT[0].ID;
                    //LoanActivity.Receiver = new Designation(true, "HR").ID;
                }
                if (DesignationsDT[0].Role == "Team Manager")
                {
                    LoanActivity.Receiver = DesignationsDT[0].ID;
                }
                LoanActivity.InitiatorRemark = Remarks;
                String Status = LoanActivity.Save(DBSession);

                LoanRequest LoanRequest = new LoanRequest(ID);
                LoanRequest.Status = LoanAppCommands.APPROVED;
                Status = LoanRequest.SaveAction(DBSession);
                if (IsLocalSession)
                {
                    DBSession.Commit();
                    if (objEmail.ToAddress != string.Empty)
                        objEmail.Save();
                    else
                    {
                        //log it ..email could not be sent
                    }
                }
                return Status;
            }
            catch (Exception ex)
            {
                DBSession.Rollback();
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRLoanManagerDefs.Loan.LOANREQUEST_REJECT_FAILURE, ID.ToString())
                    );
                return HRLoanManagerDefs.Loan.LOANREQUEST_REJECT_FAILURE;
            }
        }
        public static String CheckReportToCOO(int ID, int ChangedBy, String Remarks)
        {
            bool IsLocalSession = false;
            Session DBSession = null;
            if (DBSession == null)
            {
                IsLocalSession = true;

                DBSession = Session.CreateNewSession();

                DBSession.BeginTransaction();
            }
            try
            {
                EmailEntity objEmail = new EmailEntity();
                string LoanAction = "Forwarded";
                string LoanActionByEmpName = new Employee(ChangedBy).FirstName;
                string Department = new TeamDetail(new EmployeeOccupationDetails(ChangedBy).TeamID).ManagerName;
                string EmpName = new LoanRequest(ID).EmployeeName;
                string LoanName = new Loan(new LoanRequest(ID).LoanID).LoanName;
                string LoanAmount = new LoanRequest(ID).LoanAmount.ToString();
                string lLoanReason = new LoanRequest(ID).Reason;
                //kartyek commented
                //objEmail.ToAddress = new EmployeeOccupationDetails("Designationid", 3).EMailID;
                //objEmail.CcList = new EmployeeOccupationDetails("Designationid", 2).EMailID;
                objEmail.FromAddress = IS91.Services.Common.GetAppSetting("smtpFromEmail");
                objEmail.EmailSubject = "Loan Notification";
                String body = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates\\LoanNotify.htm"));
                body = body.Replace("{Prm!LoanAction}", LoanAction);
                body = body.Replace("{Prm!LoanActionByEmpName}", LoanActionByEmpName);
                body = body.Replace("{Prm!Department}", Department);
                body = body.Replace("{Prm!EmpName}", EmpName);
                body = body.Replace("{Prm!LoanName}", LoanName);
                body = body.Replace("{Prm!LoanAmount}", LoanAmount);
                body = body.Replace("{Prm!lLoanReason}", lLoanReason);
                objEmail.EmailBody = body;
                objEmail.Attachment = "";
                objEmail.SendStatus = HRAppCommands.EMAIL_STATUS_NEW;
                objEmail.RetryCount = 0;

                LoanActivity LoanActivity = new LoanActivity();
                LoanActivity.LoanRequestID = ID;
                LoanActivity.ActivityBy = ChangedBy;
                LoanActivity.ActivityDate = DateTime.Now;
                LoanActivity.Status = LoanAppCommands.APPROVEDBYADMINHR;
                LoanActivity.Initiator = ChangedBy;
                LoanActivity.Receiver = 0;
                LoanActivity.InitiatorRemark = Remarks;
                String Status = LoanActivity.Save(DBSession);

                LoanRequest LoanRequest = new LoanRequest(ID);
                LoanRequest.Status = LoanAppCommands.APPROVED;
                Status = LoanRequest.SaveAction(DBSession);
                if (IsLocalSession)
                {
                    DBSession.Commit();
                    if (objEmail.ToAddress != string.Empty)
                        objEmail.Save();
                    else
                    {
                        //log it ..email could not be sent
                    }
                }
                return Status;
            }
            catch (Exception ex)
            {
                DBSession.Rollback();
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRLoanManagerDefs.Loan.LOANREQUEST_REJECT_FAILURE, ID.ToString())
                    );
                return HRLoanManagerDefs.Loan.LOANREQUEST_REJECT_FAILURE;
            }
        }
        //public static String MDApproval(int ID, int ChangedBy, String Remarks)
        //{
        //    bool IsLocalSession = false;
        //    Session DBSession = null;
        //    if (DBSession == null)
        //    {
        //        IsLocalSession = true;

        //        DBSession = Session.CreateNewSession();

        //        DBSession.BeginTransaction();
        //    }
        //    try
        //    {
        //        EmailEntity objEmail = new EmailEntity();
        //        string LoanAction = "Forwarded";
        //        string LoanActionByEmpName = new Employees(ChangedBy).CandidateName;
        //        string Department = new Department(new Employees(ChangedBy).DepartmentID).DepartmentName;
        //        string EmpName = new LoanRequest(ID).EmployeeName;
        //        string LoanName = new Loan(new LoanRequest(ID).LoanID).LoanName;
        //        string LoanAmount = new LoanRequest(ID).LoanAmount.ToString();
        //        string lLoanReason = new LoanRequest(ID).Reason;

        //        //objEmail.ToAddress = new Employees(new LoanRequest(ID).EmpID).EMailID;
        //        objEmail.ToAddress = new Employees("Designationid", 2).EMailID;
        //        objEmail.FromAddress = IS91.Services.Common.GetAppSetting("smtpFromEmail");
        //        objEmail.EmailSubject = "Loan Notification";
        //        String body = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates\\LoanNotify.htm"));
        //        body = body.Replace("{Prm!LoanAction}", LoanAction);
        //        body = body.Replace("{Prm!LoanActionByEmpName}", LoanActionByEmpName);
        //        body = body.Replace("{Prm!Department}", Department);
        //        body = body.Replace("{Prm!EmpName}", EmpName);
        //        body = body.Replace("{Prm!LoanName}", LoanName);
        //        body = body.Replace("{Prm!LoanAmount}", LoanAmount);
        //        body = body.Replace("{Prm!lLoanReason}", lLoanReason);
        //        objEmail.EmailBody = body;
        //        objEmail.Attachment = "";
        //        objEmail.SendStatus = HRAppCommands.EMAIL_STATUS_NEW;
        //        objEmail.RetryCount = 0;

        //        LoanActivity LoanActivity = new LoanActivity();
        //        LoanActivity.LoanRequestID = ID;
        //        LoanActivity.ActivityBy = ChangedBy;
        //        LoanActivity.ActivityDate = DateTime.Now;
        //        LoanActivity.Status = LoanAppCommands.MDAPPROVAL;
        //        LoanActivity.Initiator = ChangedBy;
        //        LoanActivity.Receiver = 0;
        //        //LoanActivity.Receiver = new Employees(new LoanRequest(ID).EmpID).DepartmentID;
        //        LoanActivity.InitiatorRemark = Remarks;
        //        String Status = LoanActivity.Save(DBSession);

        //        LoanRequest LoanRequest = new LoanRequest(ID);
        //        LoanRequest.Status = LoanAppCommands.APPROVED;
        //        Status = LoanRequest.SaveAction(DBSession);
        //        if (IsLocalSession)
        //        {
        //            DBSession.Commit();
        //            if (objEmail.ToAddress != string.Empty)
        //                objEmail.Save();
        //            else
        //            {
        //                //log it ..email could not be sent
        //            }
        //        }
        //        return Status;
        //    }
        //    catch (Exception ex)
        //    {
        //        DBSession.Rollback();
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRLoanManagerDefs.Loan.LOANREQUEST_REJECT_FAILURE, ID.ToString())
        //            );
        //        return HRLoanManagerDefs.Loan.LOANREQUEST_REJECT_FAILURE;
        //    }
        //}
        public static String CheckReportToHOD(int ID, int ChangedBy, String Remarks)
        {
            bool IsLocalSession = false;
            Session DBSession = null;
            if (DBSession == null)
            {
                IsLocalSession = true;

                DBSession = Session.CreateNewSession();

                DBSession.BeginTransaction();
            }
            try
            {
                EmailEntity objEmail = new EmailEntity();
                string LoanAction = "Forwarded";
                string LoanActionByEmpName = new Employee(ChangedBy).FirstName;
                string Department = new TeamDetail(new EmployeeOccupationDetails(ChangedBy).TeamID).ManagerName;
                string EmpName = new LoanRequest(ID).EmployeeName;
                string LoanName = new Loan(new LoanRequest(ID).LoanID).LoanName;
                string LoanAmount = new LoanRequest(ID).LoanAmount.ToString();
                string lLoanReason = new LoanRequest(ID).Reason;
                //kartyek commented
                //objEmail.ToAddress = new EmployeeOccupationDetails(new TeamDetail(new EmployeeOccupationDetails(new LoanRequest(ID).EmpID).TeamID).ManagerName).EmailID;
                objEmail.FromAddress = IS91.Services.Common.GetAppSetting("smtpFromEmail");
                objEmail.EmailSubject = "Loan Notification";
                String body = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates\\LoanNotify.htm"));
                body = body.Replace("{Prm!LoanAction}", LoanAction);
                body = body.Replace("{Prm!LoanActionByEmpName}", LoanActionByEmpName);
                body = body.Replace("{Prm!Department}", Department);
                body = body.Replace("{Prm!EmpName}", EmpName);
                body = body.Replace("{Prm!LoanName}", LoanName);
                body = body.Replace("{Prm!LoanAmount}", LoanAmount);
                body = body.Replace("{Prm!lLoanReason}", lLoanReason);
                objEmail.EmailBody = body;
                objEmail.Attachment = "";
                objEmail.SendStatus = HRAppCommands.EMAIL_STATUS_NEW;
                objEmail.RetryCount = 0;

                LoanActivity LoanActivity = new LoanActivity();
                LoanActivity.LoanRequestID = ID;
                LoanActivity.ActivityBy = ChangedBy;
                LoanActivity.ActivityDate = DateTime.Now;
                LoanActivity.Status = LoanAppCommands.REVERTREPORT;
                LoanActivity.Initiator = ChangedBy;
                LoanActivity.Receiver = new EmployeeOccupationDetails(new LoanRequest(ID).EmpID).TeamID;
                LoanActivity.InitiatorRemark = Remarks;
                String Status = LoanActivity.Save(DBSession);

                LoanRequest LoanRequest = new LoanRequest(ID);
                LoanRequest.Status = LoanAppCommands.APPROVED;
                Status = LoanRequest.SaveAction(DBSession);
                if (IsLocalSession)
                {
                    DBSession.Commit();
                    if (objEmail.ToAddress != string.Empty)
                        objEmail.Save();
                    else
                    {
                        //log it ..email could not be sent
                    }
                }
                return Status;
            }
            catch (Exception ex)
            {
                DBSession.Rollback();
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRLoanManagerDefs.Loan.LOANREQUEST_REJECT_FAILURE, ID.ToString())
                    );
                return HRLoanManagerDefs.Loan.LOANREQUEST_REJECT_FAILURE;
            }
        }
        public static String ApproveAndForwaordToFinance(int ID, int ChangedBy, String Remarks)
        {
            bool IsLocalSession = false;
            Session DBSession = null;
            if (DBSession == null)
            {
                IsLocalSession = true;

                DBSession = Session.CreateNewSession();

                DBSession.BeginTransaction();
            }
            try
            {
                EmailEntity objEmail = new EmailEntity();
                string LoanAction = "Forwarded";
                string LoanActionByEmpName = new Employee(ChangedBy).FirstName;
                string Department = new TeamDetail(new EmployeeOccupationDetails(ChangedBy).TeamID).ManagerName;
                string EmpName = new LoanRequest(ID).EmployeeName;
                string LoanName = new Loan(new LoanRequest(ID).LoanID).LoanName;
                string LoanAmount = new LoanRequest(ID).LoanAmount.ToString();
                string lLoanReason = new LoanRequest(ID).Reason;
                //kartyek commented
                //objEmail.ToAddress = new Employees(new Department(true, "Finance").HOD).EMailID;
                objEmail.FromAddress = IS91.Services.Common.GetAppSetting("smtpFromEmail");
                objEmail.EmailSubject = "Loan Notification";
                String body = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates\\LoanNotify.htm"));
                body = body.Replace("{Prm!LoanAction}", LoanAction);
                body = body.Replace("{Prm!LoanActionByEmpName}", LoanActionByEmpName);
                body = body.Replace("{Prm!Department}", Department);
                body = body.Replace("{Prm!EmpName}", EmpName);
                body = body.Replace("{Prm!LoanName}", LoanName);
                body = body.Replace("{Prm!LoanAmount}", LoanAmount);
                body = body.Replace("{Prm!lLoanReason}", lLoanReason);
                objEmail.EmailBody = body;
                objEmail.Attachment = "";
                objEmail.SendStatus = HRAppCommands.EMAIL_STATUS_NEW;
                objEmail.RetryCount = 0;

                LoanActivity LoanActivity = new LoanActivity();
                LoanActivity.LoanRequestID = ID;
                LoanActivity.ActivityBy = ChangedBy;
                LoanActivity.ActivityDate = DateTime.Now;
                LoanActivity.Status = LoanAppCommands.FORWARDTOFINANCE;
                LoanActivity.Initiator = ChangedBy;
                LoanActivity.Receiver = new Department(true, "Finance").ID;
                LoanActivity.InitiatorRemark = Remarks;
                String Status = LoanActivity.Save(DBSession);

                LoanRequest LoanRequest = new LoanRequest(ID);
                LoanRequest.Status = LoanAppCommands.FORWARDTOFINANCE;
                Status = LoanRequest.SaveAction(DBSession);



                if (IsLocalSession)
                {
                    DBSession.Commit();
                    if (objEmail.ToAddress != string.Empty)
                        objEmail.Save();
                    else
                    {
                        //log it ..email could not be sent
                    }
                }
                return Status;
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRLoanManagerDefs.Loan.LOANREQUEST_REJECT_FAILURE, ID.ToString())
                    );
                return HRLoanManagerDefs.Loan.LOANREQUEST_REJECT_FAILURE;
            }
        }
        public static String PassLoanRequest(int ID, int ChangedBy, String Remarks, DateTime LoanStartOn)
        {
            bool IsLocalSession = false;
            Session DBSession = null;
            if (DBSession == null)
            {
                IsLocalSession = true;

                DBSession = Session.CreateNewSession();

                DBSession.BeginTransaction();
            }
            try
            {
                EmailEntity objEmail = new EmailEntity();
                string LoanAction = "Approved";
                string LoanActionByEmpName = new Employee(ChangedBy).FirstName;
                string LoanName = new Loan(new LoanRequest(ID).LoanID).LoanName;
                string LoanAmount = new LoanRequest(ID).LoanAmount.ToString();
                objEmail.ToAddress = new Employee(new LoanRequest(ID).EmpID).EmailID;
                objEmail.FromAddress = IS91.Services.Common.GetAppSetting("smtpFromEmail");
                objEmail.EmailSubject = "Requested Loan Approved";
                String body = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates\\LoanAppRejEmail.htm"));
                body = body.Replace("{Prm!LoanAction}", LoanAction);
                body = body.Replace("{Prm!LoanActionByEmpName}", LoanActionByEmpName);
                body = body.Replace("{Prm!LoanName}", LoanName);
                body = body.Replace("{Prm!LoanAmount}", LoanAmount);
                objEmail.EmailBody = body;
                objEmail.Attachment = "";
                objEmail.SendStatus = HRAppCommands.EMAIL_STATUS_NEW;
                objEmail.RetryCount = 0;

                LoanActivity LoanActivity = new LoanActivity();
                LoanActivity.LoanRequestID = ID;
                LoanActivity.ActivityBy = ChangedBy;
                LoanActivity.ActivityDate = DateTime.Now;
                LoanActivity.Status = LoanAppCommands.CLOSE;
                LoanActivity.Initiator = ChangedBy;
                LoanActivity.Receiver = 0;
                LoanActivity.InitiatorRemark = Remarks;

                String Status = LoanActivity.Save(DBSession);

                AssignEmpLoan assignLoan = new AssignEmpLoan();
                assignLoan.LoanRequestID = ID;
                assignLoan.LoanAmount = new LoanRequest(ID).LoanAmount;
                assignLoan.RepaidAmount = 0;
                assignLoan.DueAmount = new LoanRequest(ID).LoanAmount;
                assignLoan.LoanTakenOn = LoanStartOn;
                assignLoan.LoanClosedOn = Convert.ToDateTime("1900-01-01");
                assignLoan.UpdatedBy = ChangedBy;
                Status = assignLoan.Save(DBSession);

                LoanRequest LoanRequest = new LoanRequest(ID);
                LoanRequest.Status = LoanAppCommands.CLOSE;
                LoanRequest.RepliedDateTime = DateTime.Now;
                LoanRequest.StartDate = LoanStartOn;
                Status = LoanRequest.SaveAction(DBSession);



                if (IsLocalSession)
                {
                    DBSession.Commit();
                    if (objEmail.ToAddress != string.Empty)
                        objEmail.Save();
                    else
                    {
                        //log it ..email could not be sent
                    }
                }
                return Status;
            }
            catch (Exception ex)
            {
                DBSession.Rollback();
                DBSession.Dispose();
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRLoanManagerDefs.Loan.LOANREQUEST_REJECT_FAILURE, ID.ToString())
                    );
                return HRLoanManagerDefs.Loan.LOANREQUEST_REJECT_FAILURE;
            }
        }

        public static String LoanRequestRejection(int ID, int ChangedBy, String Remarks)
        {
            bool IsLocalSession = false;
            Session DBSession = null;
            if (DBSession == null)
            {
                IsLocalSession = true;

                DBSession = Session.CreateNewSession();

                DBSession.BeginTransaction();
            }
            try
            {
                EmailEntity objEmail = new EmailEntity();
                //int EmpID = new LoanRequest(ID).EmpID;
                string Name = new LoanRequest(ID).EmployeeName;
                string LoanName = new Loan(new LoanRequest(ID).LoanID).LoanName;
                string ReqDate = new LoanRequest(ID).AppliedDateTime.ToString().Substring(0, 10);
                string LoanAmount = new LoanRequest(ID).LoanAmount.ToString();
                string Department = new TeamDetail(new EmployeeOccupationDetails(ChangedBy).TeamID).ManagerName;
                //String EmployeeToEmailID = new Master_EmployeesBusinessObject().GetSelectedEmployeeToEmailID(EmpID);
                //kartyek commented
                //objEmail.ToAddress = new Employees(new Department(true, "HR").HOD).EMailID;
                objEmail.CcList = new Employee(new LoanRequest(ID).EmpID).EmailID;
                objEmail.FromAddress = IS91.Services.Common.GetAppSetting("smtpFromEmail");
                objEmail.EmailSubject = "Disapproval of Loan Request";
                String body = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates\\LoanRejection.htm"));
                body = body.Replace("{Prm!CandidateName}", Name);
                body = body.Replace("{Prm!LoanName}", LoanName);
                body = body.Replace("{Prm!RequestedDate}", ReqDate);
                body = body.Replace("{Prm!LoanAmount}", LoanAmount);
                body = body.Replace("{Prm!Reason}", Remarks);
                body = body.Replace("{Prm!Department}", Department);
                objEmail.EmailBody = body;
                objEmail.Attachment = "";
                objEmail.SendStatus = HRAppCommands.EMAIL_STATUS_NEW;
                objEmail.RetryCount = 0;


                LoanActivity LoanActivity = new LoanActivity();
                LoanActivity.LoanRequestID = ID;
                LoanActivity.ActivityBy = ChangedBy;
                LoanActivity.ActivityDate = DateTime.Now;
                LoanActivity.Status = LoanAppCommands.REJECTED;
                LoanActivity.Initiator = ChangedBy;
                LoanActivity.Receiver = 0;
                LoanActivity.InitiatorRemark = Remarks;
                String Status = LoanActivity.Save(DBSession);

                LoanRequest LoanRequest = new LoanRequest(ID);
                LoanRequest.Status = LoanAppCommands.REJECTED;
                Status = LoanRequest.SaveAction(DBSession);
                if (IsLocalSession)
                {
                    DBSession.Commit();
                    if (objEmail.ToAddress != string.Empty)
                        objEmail.Save();
                    else
                    {
                        //log it ..email could not be sent
                    }
                }
                return Status;
            }
            catch (Exception ex)
            {
                DBSession.Rollback();
                DBSession.Dispose();
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRLoanManagerDefs.Loan.LOANREQUEST_REJECT_FAILURE, ID.ToString())
                    );
                return HRLoanManagerDefs.Loan.LOANREQUEST_REJECT_FAILURE;
            }
        }
        ///// <summary>
        ///// Update Role of given ID
        ///// </summary>
        ///// <param name="ID">field contain Role ID</param>
        ///// <param name="ZoneName">field contain Role Name</param>
        ///// <param name="Description">field contain Role Description</param>
        ///// <param name="IsActive">field contaions Active status.</param>
        ///// <param name="UpdatedBy">field contain the user id who update Role</param>
        ///// <returns>empty string for success and error message for failure</returns>
        ////public static String AcceptLoanRequest(int ID, Double LoanAmount, String HRRemarks,int AcceptedBy)
        ////{
        ////    try
        ////    {
        ////        LoanRequest LoanRequest = new LoanRequest(ID);
        ////        LoanRequest.Status = LoanAppCommands.LOANREQUEST_ACCEPTED_STATUS;
        ////        LoanRequest.UpdatedBy = AcceptedBy;
        ////        LoanRequest.HRRemarks = HRRemarks;
        ////        LoanRequest.RepliedDateTime = DateTime.Now;
        ////        String Status = LoanRequest.SaveAction();
        ////        if (Status==String.Empty)
        ////        {
        ////            AssignEmpLoan AssignEmpLoan = new AssignEmpLoan(0);
        ////            AssignEmpLoan.LoanRequestID = ID;
        ////            AssignEmpLoan.LoanAmount = LoanAmount;
        ////            AssignEmpLoan.LoanTakenOn = DateTime.Now;
        ////            AssignEmpLoan.RepaidAmount = 0;
        ////            AssignEmpLoan.DueAmount = LoanAmount;
        ////            AssignEmpLoan.LoanClosedOn = Convert.ToDateTime("1900-01-01");
        ////            AssignEmpLoan.UpdatedBy = AcceptedBy;
        ////            Status = AssignEmpLoan.Save();
        ////            return Status;
        ////        }
        ////        else  return Status;


        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        IRCAExceptionHandler.HandleException(
        ////            new IRCAException(ex, HRLoanManagerDefs.Loan.LOANREQUEST_ACCEPT_FAILURE, ID.ToString())
        ////            );
        ////        return HRLoanManagerDefs.Loan.LOANREQUEST_ACCEPT_FAILURE;
        ////    }
        ////}
        ///// <summary>
        ///// Update Role of given ID
        ///// </summary>
        ///// <param name="ID">field contain Role ID</param>
        ///// <param name="ZoneName">field contain Role Name</param>
        ///// <param name="Description">field contain Role Description</param>
        ///// <param name="IsActive">field contaions Active status.</param>
        ///// <param name="UpdatedBy">field contain the user id who update Role</param>
        ///// <returns>empty string for success and error message for failure</returns>
        //public static String AcceptSalaryAdvance(int ID, String HRRemarks, int AcceptedBy)
        //{
        //    try
        //    {
        //        SalaryAdvance SalaryAdvance = new SalaryAdvance(ID);
        //        SalaryAdvance.Status = LoanAppCommands.SALARYADVANCE_ACCEPTED_STATUS;
        //        SalaryAdvance.UpdatedBy = AcceptedBy;
        //        SalaryAdvance.HRRemarks = HRRemarks;
        //        String Status = SalaryAdvance.SaveAction();

        //        return Status;


        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRLoanManagerDefs.SalaryAdvance.SALARYADVANCE_ACCEPT_FAILURE, ID.ToString())
        //            );
        //        return HRLoanManagerDefs.SalaryAdvance.SALARYADVANCE_ACCEPT_FAILURE;
        //    }
        //}
        ///// <summary>
        ///// Update Role of given ID
        ///// </summary>
        ///// <param name="ID">field contain Role ID</param>
        ///// <param name="ZoneName">field contain Role Name</param>
        ///// <param name="Description">field contain Role Description</param>
        ///// <param name="IsActive">field contaions Active status.</param>
        ///// <param name="UpdatedBy">field contain the user id who update Role</param>
        ///// <returns>empty string for success and error message for failure</returns>
        //public static String RejectSalaryAdvance(int ID, String HRRemarks, int AcceptedBy)
        //{
        //    try
        //    {
        //        SalaryAdvance SalaryAdvance = new SalaryAdvance(ID);
        //        SalaryAdvance.Status = LoanAppCommands.SALARYADVANCE_REJECTED_STATUS;
        //        SalaryAdvance.UpdatedBy = AcceptedBy;
        //        SalaryAdvance.HRRemarks = HRRemarks;
        //        String Status = SalaryAdvance.SaveAction();

        //        return Status;


        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRLoanManagerDefs.SalaryAdvance.SALARYADVANCE_ACCEPT_FAILURE, ID.ToString())
        //            );
        //        return HRLoanManagerDefs.SalaryAdvance.SALARYADVANCE_ACCEPT_FAILURE;
        //    }
        //}
        ///// <summary>
        ///// Update Role of given ID
        ///// </summary>
        ///// <param name="ID">field contain Role ID</param>
        ///// <param name="ZoneName">field contain Role Name</param>
        ///// <param name="Description">field contain Role Description</param>
        ///// <param name="IsActive">field contaions Active status.</param>
        ///// <param name="UpdatedBy">field contain the user id who update Role</param>
        ///// <returns>empty string for success and error message for failure</returns>
        //public static String PlaceLoanRequest(int ID, int EmpID,
        //        int LoanID, Double LoanAmount, Int16 RepaymentMonths, Double MonthlyAmount,
        //        String Reason, int AppliedTo)
        //{
        //    bool IsLocalSession = false;
        //    Session DBSession = null;
        //    if (DBSession == null)
        //    {
        //        IsLocalSession = true;

        //        DBSession = Session.CreateNewSession();

        //        DBSession.BeginTransaction();
        //    }
        //    try
        //    {
        //        LoanRequest LoanRequest = new LoanRequest(ID);

        //        LoanRequest.EmpID = EmpID;
        //        LoanRequest.LoanID = LoanID;
        //        LoanRequest.LoanAmount = LoanAmount;
        //        LoanRequest.RepaymentMonths = RepaymentMonths;
        //        LoanRequest.MonthlyAmount = MonthlyAmount;
        //        LoanRequest.Reason = Reason;
        //        LoanRequest.AppliedTo = AppliedTo;
        //        LoanRequest.AppliedDateTime = DateTime.Now;
        //        LoanRequest.Status = LoanAppCommands.LOANREQUEST_NEW_STATUS;

        //        String Status = LoanRequest.Save(DBSession);
        //        if (IsLocalSession)
        //        {
        //            DBSession.Commit();
        //        }

        //        return Status;
        //    }
        //    catch (Exception ex)
        //    {
        //        DBSession.Rollback();
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRManagerDefs.RoleMessages.Role_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRManagerDefs.RoleMessages.Role_UPDATE_FAILURE;
        //    }
        //}


        //public static String PlaceSalaryAdvance(int ID, int EmpID, double AdvanceAmount, Int16 RepaymentMonths, double MonthlyAmount, String Reason, int UpdateBy, int AdvanceTypeID)
        //{
        //    try
        //    {
        //        SalaryAdvance SalaryAdvance = new SalaryAdvance(ID);
        //        SalaryAdvance.AdvanceTypeID = AdvanceTypeID;
        //        SalaryAdvance.EmpID = EmpID;
        //        SalaryAdvance.AdvanceAmount = AdvanceAmount;
        //        SalaryAdvance.RepaymentMonths = RepaymentMonths;
        //        SalaryAdvance.MonthlyAmount = MonthlyAmount;
        //        SalaryAdvance.Reason = Reason;
        //        SalaryAdvance.UpdatedBy = UpdateBy;
        //        SalaryAdvance.AppliedDateTime = DateTime.Now;
        //        SalaryAdvance.Status = LoanAppCommands.SALARYADVANCE_NEW_STATUS;

        //        String Status = SalaryAdvance.Save();

        //        return Status;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRManagerDefs.RoleMessages.Role_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRManagerDefs.RoleMessages.Role_UPDATE_FAILURE;
        //    }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="ID"></param>
        ///// <param name="EmpID"></param>
        ///// <param name="LoanID"></param>
        ///// <param name="LoanAmount"></param>
        ///// <param name="RepaymentMonths"></param>
        ///// <param name="MonthlyAmount"></param>
        ///// <param name="Reason"></param>
        ///// <param name="AppliedTo"></param>
        ///// <returns></returns>
        public static String PlaceLoanRequestEmail(int ID, int EmpID,
                int LoanID, Double LoanAmount, Int16 RepaymentMonths, Double MonthlyAmount,
                String Reason, int UpdatedBy, Double MaxAmount, Double Interest, int ActualRepaymentMonth)
        {
            bool IsLocalSession = false;
            Session DBSession = null;
            if (DBSession == null)
            {
                IsLocalSession = true;

                DBSession = Session.CreateNewSession();

                DBSession.BeginTransaction();
            }
            try
            {
                EmailEntity objEmail = new EmailEntity();
                string LoanAction = "Forwarded";
                if (ID != 0) LoanAction = "Modified";
                string LoanActionByEmpName = new Employee(EmpID).FirstName;
                string Department = new TeamDetail(new EmployeeOccupationDetails(EmpID).TeamID).TeamName;
                string EmpName = new Employee(EmpID).FirstName;
                string LoanName1 = new Loan(LoanID).LoanName;
                string LoanAmount1 = LoanAmount.ToString();
                if (ID != 0 && new LoanRequest(ID).LoanAmount != LoanAmount) LoanAmount1 = LoanAmount1 + "<br/><font color='red'><b>[Old Amount] : </b>" + new LoanRequest(ID).LoanAmount.ToString() + "</font>";
                string lLoanReason = Reason;
                if (ID != 0 && new LoanRequest(ID).Reason != Reason) lLoanReason = lLoanReason + "<br/><font color='red'><b>[Old Reason] : </b>" + new LoanRequest(ID).Reason + "</font>";

                objEmail.ToAddress = new EmployeeOccupationDetails(new TeamDetail(new EmployeeOccupationDetails(EmpID).TeamID).ManagerID).EmailID;
                objEmail.FromAddress = IS91.Services.Common.GetAppSetting("smtpFromEmail");
                objEmail.EmailSubject = "Loan Notification";
                if (ID != 0) objEmail.EmailSubject = "Loan Request Modified";
                String body = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates\\LoanNotify.htm"));
                body = body.Replace("{Prm!LoanAction}", LoanAction);
                body = body.Replace("{Prm!LoanActionByEmpName}", LoanActionByEmpName);
                body = body.Replace("{Prm!Department}", Department);
                body = body.Replace("{Prm!EmpName}", EmpName);
                body = body.Replace("{Prm!LoanName}", LoanName1);
                body = body.Replace("{Prm!LoanAmount}", LoanAmount1);
                body = body.Replace("{Prm!lLoanReason}", lLoanReason);
                objEmail.EmailBody = body;
                objEmail.Attachment = "";
                objEmail.SendStatus = HRAppCommands.EMAIL_STATUS_NEW;
                objEmail.RetryCount = 0;

                EmailEntity objEmail2 = new EmailEntity();
                objEmail2.ToAddress = new EmployeeOccupationDetails(EmpID).EmailID;
                objEmail2.FromAddress = IS91.Services.Common.GetAppSetting("smtpFromEmail");
                objEmail2.EmailSubject = "Loan Request";
                if (ID != 0) objEmail2.EmailSubject = "Loan Request Modified";
                String bodys = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates\\LoanRequest.htm"));
                bodys = bodys.Replace("{Prm!EmpName}", EmpName);
                bodys = bodys.Replace("{Prm!LoanName}", LoanName1);
                bodys = bodys.Replace("{Prm!LoanAmount}", LoanAmount1);
                bodys = bodys.Replace("{Prm!lLoanReason}", lLoanReason);
                objEmail2.EmailBody = bodys;
                objEmail2.Attachment = "";
                objEmail2.SendStatus = HRAppCommands.EMAIL_STATUS_NEW;
                objEmail2.RetryCount = 0;

                LoanRequest LoanRequest = new LoanRequest(ID);
                LoanRequest.EmpID = EmpID;
                LoanRequest.LoanID = LoanID;
                LoanRequest.LoanAmount = LoanAmount;
                LoanRequest.RepaymentMonths = RepaymentMonths;
                LoanRequest.MonthlyAmount = MonthlyAmount;
                LoanRequest.Reason = Reason;
                LoanRequest.AppliedDateTime = DateTime.Now;
                LoanRequest.Status = LoanAppCommands.LOANREQUEST_NEW_STATUS;
                LoanRequest.UpdatedBy = UpdatedBy;

                LoanRequest.MaxAmount = MaxAmount;
                LoanRequest.Interest = Interest;
                LoanRequest.ActualRepaymentMonth = ActualRepaymentMonth;

                String LoanRequestID = LoanRequest.SaveEmail(DBSession);
                double Num;
                if (double.TryParse(LoanRequestID, out Num))
                {
                    LoanActivity LoanActivity = new LoanActivity();
                    LoanActivity.LoanRequestID = Convert.ToInt32(Num);
                    LoanActivity.Initiator = EmpID;
//                    LoanActivity.Receiver = new EmployeeOccupationDetails(EmpID).TeamID;
                    
                    //LoanActivity.Receiver = new Designation(EmpID).RoleID;
                    //kartyek for Receivers id as manager id
                    int RoleID = new Master_EmployeesBusinessObject().GetMaangerIDEmployees(EmpID);

                    LoanActivity.Receiver = RoleID;
                    LoanActivity.Status = LoanAppCommands.NEW;
                    LoanActivity.ActivityBy = UpdatedBy;
                    if (LoanActivity.Save(DBSession) == String.Empty)
                    {
                        if (IsLocalSession)
                        {
                            DBSession.Commit();
                            if (objEmail.ToAddress != string.Empty)
                                objEmail.Save();
                            else
                            {
                                //log it ..email could not be sent
                            }
                            if (objEmail2.ToAddress != string.Empty)
                                objEmail2.Save();
                            else
                            {
                                //log it ..email could not be sent
                            }
                        }
                        return LoanRequestID;
                    }
                    else
                    {
                        DBSession.Rollback();
                        return "";
                    }
                }

                else return LoanRequestID;
            }
            catch (Exception ex)
            {
                DBSession.Rollback();
                DBSession.Dispose();
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRManagerDefs.RoleMessages.Role_UPDATE_FAILURE, ID.ToString())
                    );
                return HRManagerDefs.RoleMessages.Role_UPDATE_FAILURE;
            }
        }


        public static String CheckForLoanEgiblity(int ID)
        {
            Master_Loan[] LoansDT = new Master_LoanBusinessObject().GetAllActiveLoan();

            //Loan[] Loans = new Loan[LoansDT.Length];
            String Status = String.Empty;
            for (int i = 0; i < LoansDT.Length; i++)
            {
                Status = LoanRequest.CheckEgibility(ID, LoansDT[i].ID);
                if (Status == String.Empty)
                    break;
            }
            if (LoansDT.Length == 0)
                return "No Loan available";
            else
                return Status;
        }
        public static String CheckDeptHODForLoan(int ID)
        {
            return LoanRequest.CheckDeptHODForLoan(ID);
        }
        public static String CheckLoanStartDate(DateTime LoanDate, int LoanRequestID)
        {
            return LoanRequest.CheckLoanStartDate(LoanDate, LoanRequestID);
        }
        ///// <summary>
        ///// Update Role of given ID
        ///// </summary>
        ///// <param name="ID">field contain Role ID</param>
        ///// <param name="ZoneName">field contain Role Name</param>
        ///// <param name="Description">field contain Role Description</param>
        ///// <param name="IsActive">field contaions Active status.</param>
        ///// <param name="UpdatedBy">field contain the user id who update Role</param>
        ///// <returns>empty string for success and error message for failure</returns>
        //public static String UpdateAssignEmpLoan(int ID, int EmpId, int LoanId, Double LoanAmount)
        //{
        //    try
        //    {
        //        AssignEmpLoan AssignEmpLoan = new AssignEmpLoan(ID);

        //        AssignEmpLoan.EmpID = EmpId;
        //        AssignEmpLoan.LoanID = LoanId;
        //        AssignEmpLoan.LoanAmount = LoanAmount;
        //        AssignEmpLoan.LoanTakenOn = DateTime.Now;

        //        String Status = AssignEmpLoan.Save();

        //        return Status;
        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRManagerDefs.RoleMessages.Role_UPDATE_FAILURE, ID.ToString())
        //            );
        //        return HRManagerDefs.RoleMessages.Role_UPDATE_FAILURE;
        //    }
        //}

        ///// <summary>
        ///// Update Role of given ID
        ///// </summary>
        ///// <param name="ID">field contain Role ID</param>
        ///// <param name="ZoneName">field contain Role Name</param>
        ///// <param name="Description">field contain Role Description</param>
        ///// <param name="IsActive">field contaions Active status.</param>
        ///// <param name="UpdatedBy">field contain the user id who update Role</param>
        ///// <returns>empty string for success and error message for failure</returns>
        //public static String UpdateLoanRepayment(int ID, int LoanRequestID, Double Amount, int UpdateBy)
        //{
        //    try
        //    {
        //        LoanRepayment LoanRepayment = new LoanRepayment(0);
        //        //LoanRepayment.EmpID = EmpID;
        //        LoanRepayment.LoanRequestID = LoanRequestID;
        //        LoanRepayment.Amount = Amount;
        //        LoanRepayment.RepaymentDate = DateTime.Now;
        //        LoanRepayment.UpdatedBy = UpdateBy;
        //        String Status = LoanRepayment.Save();
        //        //if (Status == String.Empty)
        //        //{
        //        //    AssignEmpLoan AssignEmpLoan = new AssignEmpLoan(ID);
        //        //    AssignEmpLoan.RepaidAmount = AssignEmpLoan.RepaidAmount + Amount;
        //        //    AssignEmpLoan.DueAmount = AssignEmpLoan.DueAmount - Amount;
        //        //    if (AssignEmpLoan.DueAmount == 0)
        //        //        AssignEmpLoan.LoanClosedOn = DateTime.Now;
        //        //    AssignEmpLoan.UpdatedBy = UpdateBy;
        //        //    Status = AssignEmpLoan.Save();
        //        //    return Status;
        //        //}
        //        //else 
        //        return Status;


        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRLoanManagerDefs.Loan.LOANREQUEST_ACCEPT_FAILURE, ID.ToString())
        //            );
        //        return HRLoanManagerDefs.Loan.LOANREQUEST_ACCEPT_FAILURE;
        //    }
        //}
        ///// <summary>
        ///// Update Role of given ID
        ///// </summary>
        ///// <param name="ID">field contain Role ID</param>
        ///// <param name="ZoneName">field contain Role Name</param>
        ///// <param name="Description">field contain Role Description</param>
        ///// <param name="IsActive">field contaions Active status.</param>
        ///// <param name="UpdatedBy">field contain the user id who update Role</param>
        ///// <returns>empty string for success and error message for failure</returns>
        //public static String UpdateSalaryAdvanceRepayment(int ID, int EmpID, int AdvanceID, Double Amount, int UpdateBy)
        //{
        //    try
        //    {
        //        SalaryAdvanceRepayment SalaryAdvanceRepayment = new SalaryAdvanceRepayment(0);
        //        SalaryAdvanceRepayment.EmpID = EmpID;
        //        SalaryAdvanceRepayment.AdvanceID = AdvanceID;
        //        SalaryAdvanceRepayment.AdvanceAmount = Amount;
        //        SalaryAdvanceRepayment.RepaymentDate = DateTime.Now;
        //        SalaryAdvanceRepayment.UpdatedBy = UpdateBy;
        //        String Status = SalaryAdvanceRepayment.Save();

        //        return Status;


        //    }
        //    catch (Exception ex)
        //    {
        //        IRCAExceptionHandler.HandleException(
        //            new IRCAException(ex, HRLoanManagerDefs.SalaryAdvanceRepayment.SALARYADVANCEREPAYMENT_ADDED_FAILURE, ID.ToString())
        //            );
        //        return HRLoanManagerDefs.SalaryAdvanceRepayment.SALARYADVANCEREPAYMENT_ADDED_FAILURE;
        //    }
        //}
        public static String UpdateAdvanceType(int ID, string AdvanceType, bool IsActive, int UpdateBy)
        {
            try
            {
                MasterAdvanceType AdvanceTypeEntity = new MasterAdvanceType(ID);

                AdvanceTypeEntity.AdvanceType = AdvanceType;
                AdvanceTypeEntity.IsActive = IsActive;
                AdvanceTypeEntity.UpdatedBy = UpdateBy;
                String Status = AdvanceTypeEntity.Save();

                return Status;


            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRLoanManagerDefs.AdvanceType.ADVANCE_TYPE_ADDED_FAILURE, ID.ToString())
                    );
                return HRLoanManagerDefs.AdvanceType.ADVANCE_TYPE_ADDED_FAILURE;
            }
        }


        public static String ActivateAdvanceType(int ID, int ActivatedBy)
        {
            try
            {
                return new MasterAdvanceType(ID).Activate(ActivatedBy);
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRLoanManagerDefs.AdvanceType.ADVANCE_TYPE_ADDED_FAILURE, ID.ToString())
                    );
                return HRLoanManagerDefs.AdvanceType.ADVANCE_TYPE_ADDED_FAILURE;
            }
        }


        public static String DeActivateAdvanceType(int ID, int DeActivateBy)
        {
            try
            {
                return new MasterAdvanceType(ID).DeActivate(DeActivateBy);
            }
            catch (Exception ex)
            {
                IRCAExceptionHandler.HandleException(
                    new IRCAException(ex, HRLoanManagerDefs.AdvanceType.ADVANCE_TYPE_ADDED_FAILURE, ID.ToString())
                    );
                return HRLoanManagerDefs.AdvanceType.ADVANCE_TYPE_ADDED_FAILURE;
            }
        }
    }
}
