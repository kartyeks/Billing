using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRCAKernel;
using HRManager.DTOEXT.Employees;
using HRManager.BusinessObjects;
using System.Data;
using System.IO;
using System.Web;
using HRManager.DTO;

namespace HRManager.Entity.ExitManagement
{
    public class ExitManagementNotification
    {
        private static String EmployeeExitDate =
            " <html> "
            + " <body> "
            + " <div style='border-style: solid; border-color: #999999;width:450px;height:250px;background-color: #00D2D2'> "
            + " <table align='center'> "
            + " <br/>"
            + " <br/>"
            + " Dear <b>{0}</b>, "
            + " <br/> <br/> "
            + " This mail is to inform that your Exit date is <b>{1}</b>."
            + " <br/>"
            + " <br/>"
            + " Regards,"
                + " <br/> "
            + " Altiostar HR"
            + " <br/>"
            + " <br/>"
            + " </table> "
            + " </div> "
            + " </body> "
            + " </html> ";

        private static String ManagerExitDate =
            " <html> "
            + " <body> "
            + " <div style='border-style: solid; border-color: #999999;width:450px;height:250px;background-color: #00D2D2'> "
            + " <table align='center'> "
            + " <br/>"
            + " <br/>"
            + " Dear <b>{0}</b>, "
            + " <br/> <br/> "
            + " This mail is to inform that the exit date  for <b>{2}</b> is <b>{1}</b>.The exit type is <b>{3}</b>."
            + " <br/>"
            + " <br/>"
            + " Regards,"
                + " <br/> "
            + " Altiostar HR"
            + " <br/>"
            + " <br/>"
            + " </table> "
            + " </div> "
            + " </body> "
            + " </html> ";

        private static String EmployeeExitNoDue =
            " <html> "
            + " <body> "
            + " <div style='border-style: solid; border-color: #999999;width:450px;height:250px;background-color: #00D2D2'> "
            + " <table align='center'> "
            + " <br/>"
            + " <br/>"
            + " Dear <b>{0}</b>, "
            + " <br/> <br/> "
            + " This mail is to inform that your Exit date is <b>{1}</b>."
             + " <br/>"
            + "Please find the attached No due Form, Kindly fill in all the details and upload the form back into the system."
            + " <br/>"
            + " <br/>"
            + " Regards,"
                + " <br/> "
            + " Altiostar HR"
            + " <br/>"
            + " <br/>"
            + " </table> "
            + " </div> "
            + " </body> "
            + " </html> ";

        private static String HRExitNoDue =
            " <html> "
            + " <body> "
            + " <div style='border-style: solid; border-color: #999999;width:450px;height:250px;background-color: #00D2D2'> "
            + " <table align='center'> "
            + " <br/>"
            + " <br/>"
            + " Dear <b>{0}</b>, "
            + " <br/> <br/> "
            + " This mail is to inform that the exit date  for <b>{2}</b> is <b>{1}</b>.The exit type is <b>{3}</b>."
            + " <br/>"
            + " <br/>"
            + " Regards,"
                + " <br/> "
            + " Altiostar HR"
            + " <br/>"
            + " <br/>"
            + " </table> "
            + " </div> "
            + " </body> "
            + " </html> ";

        private static String ManagerExitNoDue =
            " <html> "
            + " <body> "
            + " <div style='border-style: solid; border-color: #999999;width:450px;height:250px;background-color: #00D2D2'> "
            + " <table align='center'> "
            + " <br/>"
            + " <br/>"
            + " Dear <b>{0}</b>, "
            + " <br/> <br/> "
           + " This mail is to inform that the exit date  for <b>{2}</b> is <b>{1}</b>.The exit type is <b>{3}</b>."
            + " <br/>"
            + " <br/>"
            + " Regards,"
                + " <br/> "
            + " Altiostar HR"
            + " <br/>"
            + " <br/>"
            + " </table> "
            + " </div> "
            + " </body> "
            + " </html> ";

        private static String HRExitNoDueEmpSubmit =
            " <html> "
            + " <body> "
            + " <div style='border-style: solid; border-color: #999999;width:450px;height:250px;background-color: #00D2D2'> "
            + " <table align='center'> "
            + " <br/>"
            + " <br/>"
            + " Dear <b>{0}</b>, "
            + " <br/> <br/> "
            + " This mail is to inform that the No Due Form has been submitted by <b>{1}</b>, Kindly Review."
            + " <br/>"
            + " <br/>"
            + " Regards,"
                + " <br/> "
            + " <b>{1}</b>"
            + " <br/>"
            + " <br/>"
            + " </table> "
            + " </div> "
            + " </body> "
            + " </html> ";

        private static String ManagerExitNoDueEmpSubmit =
            " <html> "
            + " <body> "
            + " <div style='border-style: solid; border-color: #999999;width:450px;height:250px;background-color: #00D2D2'> "
            + " <table align='center'> "
            + " <br/>"
            + " <br/>"
            + " Dear <b>{0}</b>, "
            + " <br/> <br/> "
            + " This mail is to inform that the No Due Form has been submitted by <b>{1}</b>, Kindly Review."
            + " <br/>"
            + " <br/>"
            + " Regards,"
                + " <br/> "
            + " <b>{1}</b>"
            + " <br/>"
            + " <br/>"
            + " </table> "
            + " </div> "
            + " </body> "
            + " </html> ";



        String HREmailID = "";
        String HRName = "";
        String ManagerEmailID = "";
        String ManagerName = "";
        String EMPEmailID = "";
        String EMPName = "";
        String ExiDate = "";
        String ExitType = "";


        public void ExitNotification(int EmployeeID, DateTime ExitDate)
        {

            DataTable HRDetails = new ExitManagementBusinessObject().GetHrEmailIDs();
            HREmailID = HRDetails.Rows[0]["HREmailID"].ToString();
            HRName = HRDetails.Rows[0]["HRName"].ToString();

            EmployeeExitManagementExtened EmpDetails = new Master_EmployeesBusinessObject().GetEmployeeDetails(EmployeeID);

            EMPEmailID = EmpDetails.EmployeeEmailID;
            EMPName = EmpDetails.EmployeeName;
            ExiDate = EmpDetails.ExitDate.ToString("dd/MM/yyyy");
            ExitType = EmpDetails.ExitType;
            int ManagerID = EmpDetails.ManagerID;

            DataTable TeamManager = new ExitManagementBusinessObject().GetManagerEmailIDs(ManagerID);
            ManagerEmailID = TeamManager.Rows[0]["ManagerEmailID"].ToString();
            ManagerName = TeamManager.Rows[0]["ManagerName"].ToString();

            MailContent Mail = new MailContent();
            Mail.AddToAddress(EMPEmailID);
            Mail.Subject = "Employee Exit";
            Mail.Body = String.Format(EmployeeExitDate, EMPName, ExiDate);
            IRCAMailHandler.SendMail(Mail);

            MailContent Mail1 = new MailContent();
            Mail1.AddToAddress(ManagerEmailID);
            Mail1.Subject = "Employee Exit";
            Mail1.Body = String.Format(ManagerExitDate, ManagerName, ExiDate, EMPName,ExitType);
            IRCAMailHandler.SendMail(Mail1);


            //Mail.AddToAddress(EMPEmailID);
            //Mail.Subject = "Submission of No Due Form";
            //Mail.Body = String.Format(EmployeeExitNoDue, EMPName, ExiDate);
            //String URL = System.Web.HttpContext.Current.Server.MapPath("~/Resources") + "\\ClearanceForm\\Clearance Form.doc";
            //Mail.AddAttachment(System.IO.File.ReadAllBytes(URL), "No Due Form", "application/msword");                
            //IRCAMailHandler.SendMail(Mail);


            //Mail.AddToAddress(HREmailID);
            //Mail.Subject = EMPName + ' ' + "ExiDate" + ':' + ExiDate;
            //Mail.Body = String.Format(HRExitNoDue, HRName, ExiDate);
            //IRCAMailHandler.SendMail(Mail);


            //Mail.AddToAddress(ManagerEmailID);
            //Mail.Subject = EMPName + ' ' + "ExiDate" + ':' + ExiDate;
            //Mail.Body = String.Format(ManagerExitNoDue, ManagerName, ExiDate);
            //IRCAMailHandler.SendMail(Mail);         

        }

        public static void EmployeeNoDueNotification(string strDate)
        {
            String EmployeeName = "";
            int ID = 0;
            EmployeeExitManagementExtened[] AllEmployees = new Master_EmployeesBusinessObject().GetAllEmployee(strDate);

            DataTable HRDetails = new ExitManagementBusinessObject().GetHrEmailIDs();
            String HREmailID = HRDetails.Rows[0]["HREmailID"].ToString();
            String HRName = HRDetails.Rows[0]["HRName"].ToString();

            

            for (int i = 0; i < AllEmployees.Length; i++)
            {
                EmployeeExitManagementExtened EmpDetails = new Master_EmployeesBusinessObject().GetEmployeeDetails(AllEmployees[i].EmployeeID);
                int ManagerID = EmpDetails.ManagerID;

                DataTable TeamManager = new ExitManagementBusinessObject().GetManagerEmailIDs(ManagerID);
                String ManagerEmailID = TeamManager.Rows[0]["ManagerEmailID"].ToString();
                String ManagerName = TeamManager.Rows[0]["ManagerName"].ToString();
                ID = AllEmployees[i].EmployeeID;
                EmployeeName = AllEmployees[i].EmployeeName;
                String ExitType = AllEmployees[i].ExitType;

                //if (DateTime.Now.Day == AllEmployees[i].ExitDate.Day && DateTime.Now.Month == AllEmployees[i].ExitDate.Month)
                //{
                MailContent Mail = new MailContent();
                Mail.AddToAddress(HREmailID);
                Mail.Subject = AllEmployees[i].EmployeeName + ' ' + "Exit Date" + ':' + AllEmployees[i].ExitDate.ToString("dd/MM/yyyy");
                Mail.Body = String.Format(HRExitNoDue, HRName, AllEmployees[i].ExitDate.ToString("dd/MM/yyyy"), EmployeeName, ExitType);

                string path = HttpContext.Current.Server.MapPath("Resources\\ClearanceForm\\Clearance Form.doc");
               // String URL = System.Web.HttpContext.Current.Server.MapPath("~/Resources") + "\\ClearanceForm\\Clearance Form.doc";
                Mail.AddAttachment(System.IO.File.ReadAllBytes(path), "Clearance form ", "application/msword");
                IRCAMailHandler.SendMail(Mail);

                MailContent Mail4 = new MailContent();
                Mail4.AddToAddress(ManagerEmailID);
                Mail4.Subject = AllEmployees[i].EmployeeName + ' ' + "Exit Date" + ':' + AllEmployees[i].ExitDate.ToString("dd/MM/yyyy");
                Mail4.Body = String.Format(ManagerExitNoDue, ManagerName, AllEmployees[i].ExitDate.ToString("dd/MM/yyyy"), EmployeeName, ExitType);

                string path1 = HttpContext.Current.Server.MapPath("Resources\\ClearanceForm\\Clearance Form.doc");
                // String URL = System.Web.HttpContext.Current.Server.MapPath("~/Resources") + "\\ClearanceForm\\Clearance Form.doc";
                Mail4.AddAttachment(System.IO.File.ReadAllBytes(path1), "Clearance form ", "application/msword");
                IRCAMailHandler.SendMail(Mail4);

                if (ID != 0 || EmployeeName != "")
                {
                    for (int j = 0; j < AllEmployees.Length; j++) 
                        {
                            if (AllEmployees[j].EmployeeID == ID)
                            {
                                MailContent Mail1 = new MailContent();
                                Mail1.AddToAddress(AllEmployees[j].EmployeeEmailID);
                                Mail1.Subject = "Submission of Clearance Form";
                                Mail1.Body = String.Format(EmployeeExitNoDue, AllEmployees[j].EmployeeName, AllEmployees[j].ExitDate.ToString("yy/MM/yyyy"));
                                //String URL = System.Web.HttpContext.Current.Server.MapPath("~/Resources") + "\\ClearanceForm\\Clearance Form.doc";
                                string path2 = HttpContext.Current.Server.MapPath("Resources\\ClearanceForm\\Clearance Form.doc");
                                Mail1.AddAttachment(System.IO.File.ReadAllBytes(path2), "Clearance form ", "application/msword");
                                IRCAMailHandler.SendMail(Mail1);
                            }
                        }
                }

                // }

            }
        }

        public void EmployeeExitManagement(int EmployeeID, DateTime ExitDate)
        {
            DataTable HRDetails = new ExitManagementBusinessObject().GetHrEmailIDs();
            String HREmailID = HRDetails.Rows[0]["HREmailID"].ToString();
            String HRName = HRDetails.Rows[0]["HRName"].ToString();
            Exit_Management EmpDocument = new ExitManagementBusinessObject().GETExitManagement(EmployeeID);
            String Document = EmpDocument.DocumentName;

            EmployeeExitManagementExtened EmpDetails = new Master_EmployeesBusinessObject().GetEmployeeDetails(EmployeeID);
          

            EMPEmailID = EmpDetails.EmployeeEmailID;
            EMPName = EmpDetails.EmployeeName;
            ExiDate = EmpDetails.ExitDate.ToString("dd/MM/yyyy");
            int ManagerID = EmpDetails.ManagerID;

            DataTable TeamManager = new ExitManagementBusinessObject().GetManagerEmailIDs(ManagerID);
            ManagerEmailID = TeamManager.Rows[0]["ManagerEmailID"].ToString();
            ManagerName = TeamManager.Rows[0]["ManagerName"].ToString();


            MailContent Mail = new MailContent();
            Mail.AddToAddress(HREmailID);
            Mail.Subject = EMPName + ':' + "Clearance form submitted";
            Mail.Body = String.Format(HRExitNoDueEmpSubmit, HRName, EMPName);
            string path3 = HttpContext.Current.Server.MapPath("../Resources\\ExitManagement\\" + EmployeeID + "_" + Document);
            Mail.AddAttachment(System.IO.File.ReadAllBytes(path3), EmployeeID + "_" + Document, "application/msword");
            IRCAMailHandler.SendMail(Mail);

            MailContent Mail3 = new MailContent();
            Mail3.AddToAddress(ManagerEmailID);
            Mail3.Subject = EMPName + ':' + "Clearance form submitted";
            Mail3.Body = String.Format(ManagerExitNoDueEmpSubmit, ManagerName, EMPName);
            string path4 = HttpContext.Current.Server.MapPath("../Resources\\ExitManagement\\" + EmployeeID + "_" + Document);
            Mail3.AddAttachment(System.IO.File.ReadAllBytes(path4), EmployeeID + "_" + Document, "application/msword");
            IRCAMailHandler.SendMail(Mail3);
        }
    }
}
