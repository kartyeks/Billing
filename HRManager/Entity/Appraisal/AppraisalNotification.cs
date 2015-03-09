using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRCAKernel;
using HRManager.DTOEXT.Employees;
using HRManager.BusinessObjects;
using HRManager.Entity.EmployeesInfo;
using HRManager.DTO;

namespace HRManager.Entity.Appraisal
{   
    public class AppraisalNotification
    {
        private static String GoalIntimation =
            " <html> "
            + " <body> "
            + " <div style='border-style: solid; border-color: #999999;width:450px;height:250px'> "
            + " <table align='center'> "
            + " <br/>"
            + " <br/>"
            + " Hi <b>{0}</b>, "
            + " <br/> <br/> "
            + " <b>Kindly submit goals for self and your team members.</b>"
            + " <br/>"            
            + " <br/> "
            + "Please access the application by clicking on 192.168.1.2/altiohr/default.aspx?serve=AppraisalRatingMailView "
                + " <br/> "
                + " <br/> "
            + " Regards,"
                + " <br/> "
            + " Altiostar HR"
            + " <br/>"
            + " <br/>"
            + " </table> "
            + " </div> "
            + " </body> "
            + " </html> ";
        private static String GradeIntimation =
            " <html> "
            + " <body> "
            + " <div style='border-style: solid; border-color: #999999;width:450px;height:250px'> "
            + " <table align='center'> "
            + " <br/>"
            + " <br/>"
            + " Hi <b>{0}</b>, "
            + " <br/> <br/> "
            + " <b>Kindly submit appraisals for your team members.</b>"
            + " <br/>"
            + " <br/> "
            + "Please access the application by clicking on 192.168.1.2/altiohr/default.aspx?serve=AppraisalRatingMailView "
                + " <br/> "
                + " <br/> "
            + " Regards,"
                + " <br/> "
            + " Altiostar HR"
            + " <br/>"
            + " <br/>"
            + " </table> "
            + " </div> "
            + " </body> "
            + " </html> ";
        private static String GoalSubmitteddata =
            " <html> "
            + " <body> "
            + " <div style='border-style: solid; border-color: #999999;width:450px;height:250px'> "
            + " <table align='center'> "
            + " <br/>"
            + " <br/>"
            + " Dear <b>HR</b>, "
            + " <br/> <br/> "
            + " <b>The goals for the ({0}) have been submitted. Kindly review.</b>"
            + " <br/>"
            + " <br/> "
            + "Please access the application by clicking on 192.168.1.2/altiohr "
                + " <br/> "
                + " <br/> "
            + " Regards,"
                + " <br/> "
            + " Altiostar HR"
            + " <br/>"
            + " <br/>"
            + " </table> "
            + " </div> "
            + " </body> "
            + " </html> ";
        private static String GradeSubmitteddata =
            " <html> "
            + " <body> "
            + " <div style='border-style: solid; border-color: #999999;width:450px;height:250px'> "
            + " <table align='center'> "
            + " <br/>"
            + " <br/>"
            + " Dear <b>HR</b>, "
            + " <br/> <br/> "
            + " <b>The appraisals have been submitted for ({0}).Kindly review.</b>"
            + " <br/>"
            + " <br/> "
            + "Please access the application by clicking on 192.168.1.2/altiohr "
                + " <br/> "
                + " <br/> "
            + " Regards,"
                + " <br/> "
            + " Altiostar HR"
            + " <br/>"
            + " <br/>"
            + " </table> "
            + " </div> "
            + " </body> "
            + " </html> ";

        private static String GoalSubmitteddataemp =
            " <html> "
            + " <body> "
            + " <div style='border-style: solid; border-color: #999999;width:450px;height:250px'> "
            + " <table align='center'> "
            + " <br/>"
            + " <br/>"
            + " Dear <b>{0}</b>, "
            + " <br/> <br/> "
            + " <b>The goals for the coming year have been defined by your manager. Kindly check the attachment</b>"
            + " <br/>"
            + " <br/> "
            + " Regards,"
                + " <br/> "
            + " Altiostar HR"
            + " <br/>"
            + " <br/>"
            + " </table> "
            + " </div> "
            + " </body> "
            + " </html> ";

        private static String GradeSubmitteddataemp =
            " <html> "
            + " <body> "
            + " <div style='border-style: solid; border-color: #999999;width:450px;height:250px'> "
            + " <table align='center'> "
            + " <br/>"
            + " <br/>"
            + " Dear <b>HR</b>, "
            + " <br/> <br/> "
            + " <b>The appraisals have been submitted .Kindly review.</b>"
            + " <br/>"
            + " <br/> "
            + " Regards,"
                + " <br/> "
            + " Altiostar HR"
            + " <br/>"
            + " <br/>"
            + " </table> "
            + " </div> "
            + " </body> "
            + " </html> ";

        String ManagerEmailID = "";
        String ManagerName = "";
        String EMPEmailID = "";

        public void GoalNotifination(int ID, String Path, string ext)
        {
            Master_Employees[] EmpDetails = new Appraisal_EmployeeBusinessObject().GetTeamManagers(ID);
            for (int i = 0; i < EmpDetails.Length; i++)
            {
                EmployeeOccupationDetails Details = new EmployeeOccupationDetails(EmpDetails[i].ID);
                EMPEmailID = Details.EmailID;
                ManagerName = EmpDetails[i].FirstName + " " + EmpDetails[i].LastName;
                
                MailContent Mail = new MailContent();
                Mail.AddToAddress(Details.EmailID);
                Mail.FromAddress = "noreply@ircaindia.com";
                Mail.Subject = "Goal Intimation";
                Mail.Body = String.Format(GoalIntimation, ManagerName);
                if (ext == ".docx")
                {
                    Mail.AddAttachment(System.IO.File.ReadAllBytes(Path), "Review Form",
                        "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
                }
                else
                {
                    Mail.AddAttachment(System.IO.File.ReadAllBytes(Path), "Review Form",
                        "application/pdf");
                }
                IRCAMailHandler.SendMail(Mail);
            }
        }
        public void GradeNotifination(int ID)
        {
            Master_Employees[] EmpDetails = new Appraisal_EmployeeBusinessObject().GetTeamManagers(ID);
            for (int i = 0; i < EmpDetails.Length; i++)
            {
                EmployeeOccupationDetails Details = new EmployeeOccupationDetails(EmpDetails[i].ID);
                EMPEmailID = Details.EmailID;
                ManagerName = EmpDetails[i].FirstName + " " + EmpDetails[i].LastName;
                
                MailContent Mail = new MailContent();
                Mail.AddToAddress(Details.EmailID);
                Mail.FromAddress = "noreply@ircaindia.com";
                Mail.Subject = "Appraisal Intimation";
                Mail.Body = String.Format(GradeIntimation, ManagerName);
                IRCAMailHandler.SendMail(Mail);
            }
        }

        public void GoalSubmitted(int IntimationID,int EmployeeID,int TeamID)
        {            
            Master_Employees HRDetails = new Appraisal_EmployeeBusinessObject().GetHRManager();
            if (HRDetails != null)
            {
                new Appraisal_EmployeeBusinessObject().UpdateAppraisalStatus("GOL", IntimationID,TeamID);
                EmployeeOccupationDetails Details = new EmployeeOccupationDetails(HRDetails.ID);
                Master_Team Teams = new Master_TeamBusinessObject().GetMaster_Team(TeamID);
                String HREmailID = Details.EmailID;
                String TeamName = Teams.TeamName;
                MailContent Mail = new MailContent();
                Mail.AddToAddress(HREmailID);
                Mail.FromAddress = "noreply@ircaindia.com";
                Mail.Subject = TeamName +" Team Goals submitted";
                Mail.Body = String.Format(GoalSubmitteddata, TeamName);
                IRCAMailHandler.SendMail(Mail);
            }
        }

        public void GradeSubmitted(int IntimationID, int EmployeeID, int TeamID)
        {
            
            Master_Employees HRDetails = new Appraisal_EmployeeBusinessObject().GetHRManager();
            if (HRDetails != null)
            {
                new Appraisal_EmployeeBusinessObject().UpdateAppraisalStatus("GRA", IntimationID,TeamID);
                EmployeeOccupationDetails Details = new EmployeeOccupationDetails(HRDetails.ID);
                Master_Team Teams = new Master_TeamBusinessObject().GetMaster_Team(TeamID);
                String HREmailID = Details.EmailID;
                String TeamName = Teams.TeamName;
                MailContent Mail = new MailContent();
                Mail.AddToAddress(HREmailID);
                Mail.FromAddress = "noreply@ircaindia.com";
                Mail.Subject = TeamName + " Team Grade submitted";
                Mail.Body = String.Format(GradeSubmitteddata, TeamName);
                IRCAMailHandler.SendMail(Mail);
            }
        }

        public void GoalSubmissionNotifination(int EmployeeID,String Path,string ext)
        {
            EmployeeOccupationDetails Details = new EmployeeOccupationDetails(EmployeeID);
            Master_Employees PDetails = new Master_EmployeesBusinessObject().GetMaster_Employees(EmployeeID);
            //String HREmailID = Details.EmailID;
            MailContent Mail = new MailContent();
            Mail.AddToAddress(Details.EmailID);
            Mail.FromAddress = "noreply@ircaindia.com";
            Mail.Subject = "Goals defined";
            if (ext == ".docx")
            {
                Mail.AddAttachment(System.IO.File.ReadAllBytes(Path), "Review Form with Goal",
                    "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
            }
            else
            {
                Mail.AddAttachment(System.IO.File.ReadAllBytes(Path), "Review Form with Goal",
                    "application/pdf");
            }
            Mail.Body = String.Format(GoalSubmitteddataemp,PDetails.FirstName+" "+PDetails.LastName);
            IRCAMailHandler.SendMail(Mail);
        }
        public void GradeSubmissionNotifination(int EmployeeID, String Path, string ext)
        {
            EmployeeOccupationDetails Details = new EmployeeOccupationDetails(EmployeeID);
            Master_Employees PDetails = new Master_EmployeesBusinessObject().GetMaster_Employees(EmployeeID);
            MailContent Mail = new MailContent();
            Mail.AddToAddress(Details.EmailID);
            Mail.FromAddress = "noreply@ircaindia.com";
            Mail.Subject = "Grade defined";
            Mail.Body = String.Format(GradeSubmitteddataemp,PDetails.FirstName+" "+PDetails.LastName);
            if (ext == ".docx")
            {
                Mail.AddAttachment(System.IO.File.ReadAllBytes(Path), "Review Form with Grade",
                    "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
            }
            else
            {
                Mail.AddAttachment(System.IO.File.ReadAllBytes(Path), "Review Form with Grade",
                    "application/pdf");
            }
            IRCAMailHandler.SendMail(Mail);
        }
    }

}
