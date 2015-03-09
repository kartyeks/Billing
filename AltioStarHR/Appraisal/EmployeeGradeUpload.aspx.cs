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
    public partial class EmployeeGradeUpload : System.Web.UI.Page
    {
        int EmpID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            ExtendedUserInfo objCurrUser = ((ExtendedUserInfo)HttpContext.Current.Session["userInfo"]);
            hdnEmployeeID.Value = objCurrUser.GroupName;
            Response.Cache.SetNoStore();
            if (IsPostBack)
            {
                try
                {
                    if (hdnID.Value != "0" )
                        SaveFile(Convert.ToInt32(hdnID.Value));
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
            else {
                
                hdnID.Value = string.Concat(Request.QueryString["ID"]);
            }
        }
        protected void SaveFile(int ID)
        {
            EmpID = Convert.ToInt32(hdnEmployeeID.Value);
            string strFile = string.Empty;
            HttpPostedFile RequestFiles0 = Request.Files[0];
            string FileName = RequestFiles0.FileName;
            if (FileName != string.Empty)
            {
                strFile = System.IO.Path.GetFileName(FileName);

                IntimationAppraisalEntity objEmpDoc = new IntimationAppraisalEntity();// BusinessObject();
                Appraisal_Employee obj = new Appraisal_EmployeeBusinessObject().GetAppraisal_Employee(ID);
                //objEmpDoc.GetAppraisalEmpID(IntimationID,  EmployeeID);
                objEmpDoc.Update(obj);
                objEmpDoc.GradeOn = DateTime.Now;
                objEmpDoc.GradeBy = EmpID;
                objEmpDoc.Grade = strFile;
                objEmpDoc.Save();
                string _directoryName = Server.MapPath("~/Resources") + "\\GoalDocuments\\" + objEmpDoc.IntimationID + "\\EmployeeGrade";

                if (!Directory.Exists(_directoryName))
                {
                    Directory.CreateDirectory(_directoryName);
                }
                string SaveLocation = Server.MapPath("~/Resources") + "\\GoalDocuments\\" + objEmpDoc.IntimationID + "\\EmployeeGrade\\" + ID + "_" + strFile;
                if (System.IO.File.Exists(SaveLocation))
                {
                    System.IO.File.SetAttributes(SaveLocation, System.IO.FileAttributes.Normal);
                }
                string e = Path.GetExtension(strFile);
                uploadDocument.PostedFile.SaveAs(SaveLocation);
                AppraisalNotification noti = new AppraisalNotification();
                noti.GradeSubmissionNotifination(obj.EmployeeID, SaveLocation, e);


                }

                Response.Write("<script>alert('Grade submitted successfully');window.returnValue=true;window.close(); </script>");
        }
    }
}
