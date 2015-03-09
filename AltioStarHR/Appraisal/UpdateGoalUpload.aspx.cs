using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Serialization;
using IRCAKernel;
using HRManager;
using HRManager.DTO;
using HRManager.BusinessObjects;
using AltioStarHR.App_Code;
using HRManager.Entity.EmployeeLeave;
using HRManager.Entity.Appraisal;

namespace AltioStarHR.Appraisal
{
    public partial class UpdateGoalUpload : System.Web.UI.Page
    {
        //int EmpID = Convert.ToInt32(objCurrUser.GroupName);
        int EmpID = 0;
        int ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            ExtendedUserInfo objCurrUser = ((ExtendedUserInfo)HttpContext.Current.Session["userInfo"]);
            hdnEmployeeID.Value = objCurrUser.GroupName;
            
            if (IsPostBack)
            {
                try
                {
                    EmpID = Convert.ToInt32(hdnEmployeeID.Value);
                    ID = Convert.ToInt32(hdnID.Value);
                    if (EmpID != 0)
                        SaveFile(EmpID,ID);
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
            else
            {
                hdnID.Value = String.Concat(Request.QueryString["ID"]);
                hdnDate.Value = String.Concat(Request.QueryString["date"]);
            }
        }
        protected void SaveFile(int EmpID,int ID)
        {

            string strFile = string.Empty;
            HttpPostedFile RequestFiles0 = Request.Files[0];
            string FileName = RequestFiles0.FileName;
            if (FileName != string.Empty)
            {
                strFile = System.IO.Path.GetFileName(FileName);

                IntimationEntity objEmpDoc = new IntimationEntity(new Appraisal_IntimationBusinessObject().GetAppraisal_Intimation(ID));
                //IntimationEntity objEmpDoc = new Appraisal_IntimationBusinessObject().GetAppraisal_Intimation(ID);
                //objEmpDoc.AppraisalIntimationDate = Convert.ToDateTime("1900-01-01");
                String[] dd = datepick.Value.Split('/');
                objEmpDoc.GoalIntimationDate = new DateTime(Convert.ToInt32(dd[2]), Convert.ToInt32(dd[1]), Convert.ToInt32(dd[0]));
                //objEmpDoc.IntimationBy = EmpID;//hardcode
                objEmpDoc.DocumentName = strFile;
                objEmpDoc.Save();
                string _directoryName = Server.MapPath("~/Resources") + "\\GoalDocuments\\" + ID;

                if (!Directory.Exists(_directoryName))
                {
                    Directory.CreateDirectory(_directoryName);
                }
                string SaveLocation = Server.MapPath("~/Resources") + "\\GoalDocuments\\" + ID  + "\\" + strFile;
                if (System.IO.File.Exists(SaveLocation))
                {
                    System.IO.File.SetAttributes(SaveLocation, System.IO.FileAttributes.Normal);
                }

                uploadDocument.PostedFile.SaveAs(SaveLocation);
                string e = Path.GetExtension(strFile);
                AppraisalNotification noti = new AppraisalNotification();
                noti.GoalNotifination(ID, SaveLocation,e);

                }


            Response.Write("<script>alert('Goal/grade submission intimation updated successfully');window.returnValue=true;window.close(); </script>");
        }
    }
}
