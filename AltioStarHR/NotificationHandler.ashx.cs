using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using IS91.Services;
using HRManager.Entity.ExitManagement;
using HRManager.BusinessObjects;
using HRManager.Entity.Recruitment;

namespace AltioStarHR
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class NotificationHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                //Exit Emloyee will get mail one day before
                DateTime dtToDate = DateTime.Today;
                dtToDate = dtToDate.AddDays(1);
                ExitManagementNotification.EmployeeNoDueNotification(dtToDate.ToString("yyyy-MM-dd"));


                //Every financial year Apr 1st TO March 31st anual leave count will update to all the employees
                int curYear = DateTime.Now.Year;
                if (DateTime.Now.Month == 4)
                {
                    DataTable dtTable = new Setting_ConfigurationBusinessObject().GetDataTable();
                    int leaveCnt = 0;
                    if (dtTable != null && dtTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtTable.Rows.Count; i++)
                        {
                            if (dtTable.Rows[i]["Name"].ToString() == "Leave Count")
                            {
                                Int32.TryParse(dtTable.Rows[i]["Value"].ToString(), out leaveCnt);
                            }
                        }
                    }
                    if (leaveCnt != 0)
                    {
                        new Employee_OccupationDetailsBusinessObject().UpdateAnualLeave(leaveCnt, curYear);

                    }
                }

                //HR will get notification 3days before candidate join date
                new RecruitmentNotification().NotifyJoiningDatetoHR3DaysPrior();
            }
            catch (Exception ex)
            {
                Logger.LogThis(ex.Message);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
